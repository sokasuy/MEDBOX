Public Class FormView
    Private tableName(12) As String
    Private myDataTableDGV As New DataTable
    Private myBindingTableDGV As New BindingSource
    Private cmbDgvHapusButton As New DataGridViewButtonColumn()
    Private cmbDgvAttachmentButton As New DataGridViewButtonColumn()
    Private cekTambahButton(1) As Boolean
    Private mCari As String

    Private myDataTableCboLokasi As New DataTable
    Private myBindingLokasi As New BindingSource
    Private myDataTableCboIjin As New DataTable
    Private myBindingIjin As New BindingSource
    Private myDataTableCboAbsen As New DataTable
    Private myBindingAbsen As New BindingSource
    Private myDataTableCboPerusahaan As New DataTable
    Private myBindingFilterPerusahaan As New BindingSource
    Private myDataTableCboMesin As New DataTable
    Private myBindingMesin As New BindingSource

    Private isDataPrepared As Boolean
    Private stSQL As String
    Private contentView As String
    Private enableSubForm(0) As Boolean

    Private initialValue As String
    Private isValueChanged As Boolean
    Private isPartialChanged As Boolean
    Private isCboPrepared As Boolean
    Private isExist As Boolean

    Private WithEvents tbCellText As New DataGridViewTextBoxEditingControl

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaHRD As String, _connMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String, _contentView As String, _lokasi As String)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            isDataPrepared = False
            With CONN_
                .dbType = _dbType
                .dbMain = _connMain
                .schemaTmp = _schemaTmp
                .schemaHRD = _schemaHRD
            End With
            With USER_
                .username = _username
                .lokasi = _lokasi
                .isSuperuser = _superuser
                .T_USER_RIGHT = _dtTableUserRights
            End With
            With ADD_INFO_
                .newValues = _addNewValues
                .newFields = _addNewFields
                .updateString = _addUpdateString
            End With
            contentView = _contentView
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormView Error")
        End Try
    End Sub

    Private Sub FormView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Dim arrCbo() As String
            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name & contentView, USER_.T_USER_RIGHT)

            Me.Text &= " " & contentView.ToUpper
            lblTitle.Text &= " " & contentView.ToUpper
            gbView.Text = "VIEW " & contentView.ToUpper

            If (contentView = "Presensi") Then
                tableName(0) = CONN_.schemaHRD & ".trdatapresensi"
                tableName(1) = CONN_.schemaHRD & ".trspkheader"
                tableName(2) = CONN_.schemaHRD & ".trspkdetail"
                tableName(3) = CONN_.schemaHRD & ".trsplheader"
                tableName(4) = CONN_.schemaHRD & ".trspldetail"
                tableName(5) = CONN_.schemaHRD & ".trijinabsen"
                tableName(6) = CONN_.schemaHRD & ".trscheduleshiftheader"
                tableName(7) = CONN_.schemaHRD & ".trscheduleshiftdetail"
                tableName(8) = CONN_.schemaTmp & ".datapresensi"
                tableName(9) = CONN_.schemaHRD & ".msgeneral"
                tableName(10) = CONN_.schemaHRD & ".mskaryawan"
                tableName(11) = CONN_.schemaHRD & ".mskaryawanaktif"
                tableName(12) = CONN_.schemaHRD & ".mstoleransimenit"

                stSQL = "SELECT lokasi FROM " & tableName(0) & " " & IIf(USER_.lokasi = "ALL", "", "where upper(lokasi)='" & USER_.lokasi.ToUpper & "'") & " group by lokasi order by lokasi;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboLokasi, myBindingLokasi, cboLokasi, "T_" & cboLokasi.Name, "lokasi", "lokasi", isCboPrepared)

                stSQL = "SELECT kode,keterangan,(kode || '-' || keterangan) as ket FROM " & tableName(9) & " where kategori='mohonijin' order by keterangan;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboIjin, myBindingIjin, cboMohonIjin, "T_" & cboMohonIjin.Name, "kode", "ket", isCboPrepared)

                stSQL = "SELECT kode,keterangan,(kode || '-' || keterangan) as ket FROM " & tableName(9) & " where kategori='absen' order by keterangan;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboAbsen, myBindingAbsen, cboAbsen, "T_" & cboAbsen.Name, "kode", "ket", isCboPrepared)

                stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='perusahaan' order by keterangan;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPerusahaan, myBindingFilterPerusahaan, cboFilterPerusahaan, "T_" & cboFilterPerusahaan.Name, "keterangan", "keterangan", isCboPrepared, True)

                If (myDataTableCboLokasi.Rows.Count > 0) Then
                    cboLokasi.SelectedIndex = 0
                End If

                arrCbo = {"STAFF", "NON STAFF", "OUTSOURCE"}
                cboKelompok.Items.AddRange(arrCbo)
                cboKelompok.SelectedIndex = -1

                arrCbo = {"IDK", "NIP", "NAMA"}
                cboKriteria.Items.AddRange(arrCbo)
                cboKriteria.SelectedIndex = 2

                'BUAT FORM YANG DIAKSES DARI GRID
                If USER_.isSuperuser Then
                    'Kalau superuser, maka di enable semua
                    For i As Integer = 0 To enableSubForm.Count - 1
                        enableSubForm(i) = True
                    Next
                Else
                    'Kalau bukan superuser aja yang di cek
                    Dim foundRows As DataRow()
                    'ATTACHMENT
                    foundRows = USER_.T_USER_RIGHT.Select("formname='FormAttachmentKaryawan'")
                    If (foundRows.Length = 0) Then
                        enableSubForm(0) = False
                    Else
                        enableSubForm(0) = True
                    End If
                End If

                rbJamMasukKeluar.Checked = True
                pnlJamYangKosong.Enabled = False

                If (USER_.lokasi = "ALL") Or (USER_.lokasi = "SIDOARJO") Then
                    dtpJamMasuk.Value = Date.Parse(Now.Date & " 08:00:00")
                    dtpJamKeluar.Value = Date.Parse(Now.Date & " 17:00:00")
                ElseIf (USER_.lokasi = "PANDAAN") Then
                    dtpJamMasuk.Value = Date.Parse(Now.Date & " 07:30:00")
                    dtpJamKeluar.Value = Date.Parse(Now.Date & " 16:00:00")
                End If
            ElseIf (contentView = "Fingerprint") Then
                tableName(8) = CONN_.schemaTmp & ".datapresensi"

                gbProsesCepat.Visible = False
                'lblLokasi.Visible = False
                'cboLokasi.Visible = False
                lblPerusahaan.Visible = False
                cboFilterPerusahaan.Visible = False

                lblKelompok.Location = lblPerusahaan.Location
                cboKelompok.Location = cboFilterPerusahaan.Location
                lblKriteria.Location = New Point(cboKelompok.Location.X + cboKelompok.Size.Width + 6, lblKriteria.Location.Y)
                cboKriteria.Location = New Point(cboKelompok.Location.X + cboKelompok.Size.Width + 6, cboKriteria.Location.Y)
                tbCari.Location = New Point(cboKriteria.Location.X + cboKriteria.Size.Width + 6, tbCari.Location.Y)
                btnTampilkan.Location = New Point(tbCari.Location.X + tbCari.Size.Width + 6, btnTampilkan.Location.Y)
                dgvView.Location = New Point(dgvView.Location.X, clbUserRight.Location.Y + clbUserRight.Size.Height + 5)
                dgvView.Size = New Size(dgvView.Size.Width, 465)

                stSQL = "SELECT lokasi FROM " & tableName(8) & " " & IIf(USER_.lokasi = "ALL", "", "where upper(lokasi)='" & USER_.lokasi.ToUpper & "'") & " group by lokasi order by lokasi;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboLokasi, myBindingLokasi, cboLokasi, "T_" & cboLokasi.Name, "lokasi", "lokasi", isCboPrepared)

                lblKelompok.Text = "Mesin: "
                stSQL = "SELECT ('(' || tbl2.nomer || ') ' || tbl.mesin) as mesinku,tbl.mesin FROM " & tableName(8) & " as tbl inner join " & CONN_.schemaHRD & ".msdaftarmesinpresensi as tbl2 on tbl.mesin=tbl2.mesin and tbl.lokasi=tbl2.lokasi " & IIf(USER_.lokasi = "ALL", "", "where upper(tbl.lokasi)='" & USER_.lokasi.ToUpper & "'") & " group by tbl2.nomer,tbl.mesin order by tbl2.nomer;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboMesin, myBindingMesin, cboKelompok, "T_" & cboKelompok.Name, "mesin", "mesinku", isCboPrepared)

                If (myDataTableCboLokasi.Rows.Count > 0) Then
                    cboLokasi.SelectedIndex = 0
                End If

                arrCbo = {"FPID", "NAMA"}
                cboKriteria.Items.AddRange(arrCbo)
                cboKriteria.SelectedIndex = 1
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormView_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormView_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpAwal.KeyDown, dtpAkhir.KeyDown, cboKriteria.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown, dtpJamMasuk.KeyDown, dtpJamKeluar.KeyDown, cboMohonIjin.KeyDown, cboAbsen.KeyDown, tbPathSimpan.KeyDown, tbNamaSimpan.KeyDown, btnExportExcel.KeyDown, btnCetak.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormView_KeyDown Error")
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Try
            Select Case msg.WParam.ToInt32()
                Case 13 ' enter Key
                    If Not (Me.ActiveControl Is tbCari) Then
                        If TypeOf Me.ActiveControl Is TextBox Or TypeOf Me.ActiveControl Is ComboBox Or TypeOf Me.ActiveControl Is DateTimePicker Then
                            SendKeys.Send("{Tab}")
                            Return True
                        End If
                    End If
            End Select
            Return MyBase.ProcessCmdKey(msg, keyData)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ProcessCmdKey Error")
            Return Nothing
        End Try
    End Function

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    'Private Sub FormView_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
    '    Try
    '        pnlCetak.Top = Me.Height - 113
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormView_SizeChanged Error")
    '    End Try
    'End Sub

    Private Sub SetDGV(myConn As Object, myComm As Object, myReader As Object, offSet As Integer, ByRef myDataTable As DataTable, ByRef myBindingTable As BindingSource, mKriteria As String, _contentView As String, Optional gantiKriteria As Boolean = False)
        Try
            Dim mSelectedCriteria As String
            Dim mGroupCriteria As String = Nothing

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")
            mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

            isDataPrepared = False
            If (_contentView = "Presensi") Then
                If (cboFilterPerusahaan.SelectedIndex <> -1) Then
                    mGroupCriteria = " AND (tbl.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboFilterPerusahaan.SelectedValue) & "')"
                End If
                If (cboKelompok.SelectedIndex <> -1) Then
                    mGroupCriteria &= " AND (tbl.kelompok='" & myCStringManipulation.SafeSqlLiteral(cboKelompok.SelectedItem) & "')"
                End If

                stSQL = "SELECT tbl.rid,tbl.kdr,tbl.tanggal,to_char(tbl.tanggal, 'DAY') as hari,tbl.perusahaan,tbl2.kode,tbl.nip,tbl.nama,tbl.jadwalmasuk,tbl.jadwalkeluar,tbl.masuk,tbl.keluar,tbl.cekfp,tbl.jamkerjanyata,tbl.banyakjamkerjanyata,tbl.jamkerja,tbl.banyakjamkerja,tbl.fpmasuk,tbl.fpkeluar,tbl.terlambat,tbl.pulangcepat,tbl.shift,tbl.ijin,tbl.absen,tbl.kodewaktushift,tbl.spkmulai,tbl.spkselesai,tbl.cekspk,tbl.jamlembur,tbl.mulailembur,tbl.selesailembur,tbl.ceklembur,tbl.keterangan,tbl.idk,tbl.bagian,tbl.divisi,tbl.departemen,tbl.lokasi,tbl.kelompok,tbl.katpenggajian,tbl.isfpmanual,tbl.isspkmanual,tbl.islemburmanual,tbl.isjamkerjamanual
                        FROM (" & tableName(0) & " as tbl inner join " & tableName(9) & " as tbl2 on tbl.perusahaan=tbl2.keterangan) " &
                        "WHERE (tbl.tanggal>='" & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & "' AND tbl.tanggal<='" & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy") & "') AND (tbl.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')" & mGroupCriteria & "
                        ORDER BY tbl.lokasi,tbl.nama,tbl.tanggal,tbl.perusahaan;"
                myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "TBL " & lblTitle.Text)
                myBindingTable.DataSource = myDataTable

                With dgvView
                    .DataSource = myBindingTable
                    '.ReadOnly = True

                    .Columns("rid").Visible = False
                    .Columns("kdr").Visible = False
                    .Columns("isfpmanual").Visible = False
                    .Columns("isspkmanual").Visible = False
                    .Columns("islemburmanual").Visible = False
                    .Columns("isjamkerjamanual").Visible = False
                    .Columns("kelompok").Visible = False
                    .Columns("katpenggajian").Visible = False
                    .Columns("perusahaan").Visible = False

                    .Columns("rid").Frozen = True
                    .Columns("kdr").Frozen = True
                    .Columns("tanggal").Frozen = True
                    .Columns("hari").Frozen = True
                    .Columns("perusahaan").Frozen = True
                    .Columns("kode").Frozen = True
                    .Columns("nip").Frozen = True
                    .Columns("nama").Frozen = True

                    .EnableHeadersVisualStyles = False
                    For i As Integer = 0 To .Columns.Count - 1
                        If (.Columns(i).Frozen) Then
                            .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                        End If
                    Next

                    For a As Integer = 0 To myDataTable.Columns.Count - 1
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                    Next
                    .Columns(myDataTable.Columns("kodewaktushift").ColumnName).HeaderText = "JADWAL SHIFT"
                    .Columns(myDataTable.Columns("jadwalmasuk").ColumnName).HeaderText = "JD MASUK"
                    .Columns(myDataTable.Columns("jadwalkeluar").ColumnName).HeaderText = "JD KELUAR"
                    .Columns(myDataTable.Columns("jamkerja").ColumnName).HeaderText = "JAM KERJA"
                    .Columns(myDataTable.Columns("banyakjamkerja").ColumnName).HeaderText = "BANYAK JAM KERJA"
                    .Columns(myDataTable.Columns("jamkerjanyata").ColumnName).HeaderText = "JAM KERJA NYATA"
                    .Columns(myDataTable.Columns("banyakjamkerjanyata").ColumnName).HeaderText = "BANYAK JAM KERJA NYATA"
                    .Columns(myDataTable.Columns("fpmasuk").ColumnName).HeaderText = "FP MASUK"
                    .Columns(myDataTable.Columns("fpkeluar").ColumnName).HeaderText = "FP KELUAR"
                    .Columns(myDataTable.Columns("cekfp").ColumnName).HeaderText = "CEK FP"
                    .Columns(myDataTable.Columns("pulangcepat").ColumnName).HeaderText = "PULANG CEPAT"
                    .Columns(myDataTable.Columns("spkmulai").ColumnName).HeaderText = "SPK MULAI"
                    .Columns(myDataTable.Columns("spkselesai").ColumnName).HeaderText = "SPK SELESAI"
                    .Columns(myDataTable.Columns("cekspk").ColumnName).HeaderText = "CEK SPK"
                    .Columns(myDataTable.Columns("jamlembur").ColumnName).HeaderText = "JAM LEMBUR"
                    .Columns(myDataTable.Columns("mulailembur").ColumnName).HeaderText = "MULAI LEMBUR"
                    .Columns(myDataTable.Columns("selesailembur").ColumnName).HeaderText = "SELESAI LEMBUR"
                    .Columns(myDataTable.Columns("ceklembur").ColumnName).HeaderText = "CEK LEMBUR"
                    .Columns(myDataTable.Columns("kode").ColumnName).HeaderText = "PERUSAHAAN"

                    .Columns("tanggal").Width = 80
                    .Columns("hari").Width = 80
                    .Columns("nip").Width = 60
                    .Columns("nama").Width = 100
                    .Columns("jadwalmasuk").Width = 60
                    .Columns("jadwalkeluar").Width = 60
                    .Columns("masuk").Width = 60
                    .Columns("keluar").Width = 60
                    .Columns("cekfp").Width = 60
                    .Columns("jamkerjanyata").Width = 60
                    .Columns("banyakjamkerjanyata").Width = 50
                    .Columns("jamkerja").Width = 60
                    .Columns("banyakjamkerja").Width = 50
                    .Columns("fpmasuk").Width = 60
                    .Columns("fpkeluar").Width = 60
                    .Columns("terlambat").Width = 60
                    .Columns("pulangcepat").Width = 60
                    .Columns("shift").Width = 50
                    .Columns("ijin").Width = 50
                    .Columns("absen").Width = 50
                    .Columns("kodewaktushift").Width = 50
                    .Columns("spkmulai").Width = 120
                    .Columns("spkselesai").Width = 120
                    .Columns("cekspk").Width = 60
                    .Columns("jamlembur").Width = 60
                    .Columns("mulailembur").Width = 120
                    .Columns("selesailembur").Width = 120
                    .Columns("ceklembur").Width = 60
                    .Columns("keterangan").Width = 120
                    .Columns("idk").Width = 80
                    .Columns("bagian").Width = 100
                    .Columns("divisi").Width = 100
                    .Columns("departemen").Width = 100
                    .Columns("perusahaan").Width = 130
                    .Columns("kode").Width = 60
                    .Columns("lokasi").Width = 70
                    .Columns("isspkmanual").Width = 60
                    .Columns("isfpmanual").Width = 60
                    .Columns("islemburmanual").Width = 60
                    .Columns("isjamkerjamanual").Width = 60

                    .Columns("tanggal").DefaultCellStyle.Format = "dd-MMM-yyyy"
                    '.Columns("jadwal_masuk").DefaultCellStyle.Format = "HH:mm"
                    '.Columns("jadwal_keluar").DefaultCellStyle.Format = "HH:mm"
                    '.Columns("masuk").DefaultCellStyle.Format = "HH:mm"
                    '.Columns("keluar").DefaultCellStyle.Format = "HH:mm"
                    '.Columns("fp_masuk").DefaultCellStyle.Format = "HH:mm:ss"
                    '.Columns("fp_keluar").DefaultCellStyle.Format = "HH:mm:ss"
                    '.Columns("terlambat").DefaultCellStyle.Format = "HH:mm"
                    '.Columns("pulang_cepat").DefaultCellStyle.Format = "HH:mm"
                    .Columns("banyakjamkerja").DefaultCellStyle.Format = "#,##0.00"
                    .Columns("banyakjamkerjanyata").DefaultCellStyle.Format = "#,##0.00"
                    .Columns("spkmulai").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm"
                    .Columns("spkselesai").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm"
                    '.Columns("jam_lembur").DefaultCellStyle.Format = "HH:mm"
                    .Columns("mulailembur").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm"
                    .Columns("selesailembur").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm"

                    .Columns("rid").ReadOnly = True
                    .Columns("kdr").ReadOnly = True
                    .Columns("tanggal").ReadOnly = True
                    .Columns("hari").ReadOnly = True
                    .Columns("idk").ReadOnly = True
                    .Columns("nip").ReadOnly = True
                    .Columns("nama").ReadOnly = True
                    .Columns("bagian").ReadOnly = True
                    .Columns("divisi").ReadOnly = True
                    .Columns("departemen").ReadOnly = True
                    .Columns("kode").ReadOnly = True
                    .Columns("perusahaan").ReadOnly = True
                    .Columns("lokasi").ReadOnly = True
                    .Columns("jadwalmasuk").ReadOnly = True
                    .Columns("jadwalkeluar").ReadOnly = True
                    .Columns("jamkerja").ReadOnly = True
                    .Columns("banyakjamkerja").ReadOnly = True
                    .Columns("banyakjamkerjanyata").ReadOnly = True
                    .Columns("fpmasuk").ReadOnly = True
                    .Columns("fpkeluar").ReadOnly = True
                    .Columns("isfpmanual").ReadOnly = True
                    .Columns("isspkmanual").ReadOnly = True
                    .Columns("islemburmanual").ReadOnly = True
                    .Columns("isjamkerjamanual").ReadOnly = True

                    '.Columns("lokasi").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("ijin").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("absen").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("kodewaktushift").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("masuk").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("keluar").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("jamkerjanyata").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("terlambat").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("pulangcepat").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("shift").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("cekfp").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("spkmulai").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("spkselesai").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("cekspk").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("jamlembur").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("mulailembur").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("selesailembur").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("ceklembur").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Columns("keterangan").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))

                    For i As Short = 0 To dgvView.Columns.Count - 1
                        If (.Columns(i).ReadOnly) Then
                            .Columns(i).DefaultCellStyle.BackColor = Color.Gainsboro
                        End If
                    Next

                    .Font = New Font("Arial", 8, FontStyle.Regular)
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
                End With

                'Kalau menampilkan data aktif
                With cmbDgvAttachmentButton
                    If Not (cekTambahButton(1)) Then
                        .HeaderText = "ATTACHMENT"
                        .Name = "attachment"
                        .Text = "Attachment"
                        .UseColumnTextForButtonValue = True
                        dgvView.Columns.Add(cmbDgvAttachmentButton)
                        dgvView.Columns("attachment").Width = 90
                        cekTambahButton(1) = True
                        .Visible = enableSubForm(0)
                    End If
                    .HeaderCell.Style.BackColor = Color.Yellow
                    .DisplayIndex = dgvView.ColumnCount - 1
                End With
                With cmbDgvHapusButton
                    If Not (cekTambahButton(0)) Then
                        .HeaderText = "HAPUS"
                        .Name = "delete"
                        .Text = "Hapus Record"
                        .UseColumnTextForButtonValue = True
                        dgvView.Columns.Add(cmbDgvHapusButton)
                        dgvView.Columns("delete").Width = 100
                        cekTambahButton(0) = True
                        .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                    End If
                    .HeaderCell.Style.BackColor = Color.LightSalmon
                    .DisplayIndex = dgvView.ColumnCount - 1
                End With
            ElseIf (contentView = "Fingerprint") Then
                If (cboKelompok.SelectedIndex <> -1) Then
                    mGroupCriteria &= " AND (tbl.mesin='" & myCStringManipulation.SafeSqlLiteral(cboKelompok.SelectedValue) & "')"
                End If

                stSQL = "SELECT tbl.mesin,tbl2.nomer,tbl.tanggal,tbl.fpid,tbl.nama,tbl.departemen,tbl.jammasuk,tbl.jamkeluar,tbl.lokasi,tbl.kodewaktushift,tbl.created_at,tbl.updated_at
                        FROM " & tableName(8) & " as tbl inner join " & CONN_.schemaHRD & ".msdaftarmesinpresensi as tbl2 on tbl.mesin=tbl2.mesin and tbl.lokasi=tbl2.lokasi
                        WHERE (tbl.tanggal>='" & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & "' AND tbl.tanggal<='" & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy") & "') AND (tbl.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')" & mGroupCriteria & "
                        ORDER BY tbl.lokasi ASC,tbl.nama ASC,tbl.tanggal ASC,tbl.mesin ASC;"
                myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "TBL " & lblTitle.Text)
                myBindingTable.DataSource = myDataTable

                With dgvView
                    .DataSource = myBindingTable
                    .ReadOnly = True

                    .Columns("departemen").Visible = False
                    .Columns("kodewaktushift").Visible = False

                    .Columns("mesin").Frozen = True
                    .Columns("nomer").Frozen = True
                    .Columns("tanggal").Frozen = True
                    .Columns("fpid").Frozen = True
                    .Columns("nama").Frozen = True

                    .EnableHeadersVisualStyles = False
                    For i As Integer = 0 To .Columns.Count - 1
                        If (.Columns(i).Frozen) Then
                            .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                        End If
                    Next

                    For a As Integer = 0 To myDataTable.Columns.Count - 1
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                    Next
                    .Columns("nomer").HeaderText = "NOMER MESIN"
                    .Columns("jammasuk").HeaderText = "MASUK"
                    .Columns("jamkeluar").HeaderText = "KELUAR"

                    .Columns("nomer").Width = 90
                    .Columns("mesin").Width = 125
                    .Columns("tanggal").Width = 80
                    .Columns("fpid").Width = 60
                    .Columns("nama").Width = 180
                    .Columns("departemen").Width = 150
                    .Columns("jammasuk").Width = 60
                    .Columns("jamkeluar").Width = 60
                    .Columns("lokasi").Width = 70

                    .Columns("tanggal").DefaultCellStyle.Format = "dd-MMM-yyyy"

                    .Columns("nomer").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    For i As Short = 0 To dgvView.Columns.Count - 1
                        If (.Columns(i).ReadOnly) Then
                            .Columns(i).DefaultCellStyle.BackColor = Color.Gainsboro
                        End If
                    Next

                    .Font = New Font("Arial", 8, FontStyle.Regular)
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
                End With
            End If

            Call SetReadOnlyDgv(contentView)

            ''untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvView, dgvView.Rows.Count)
            dgvView.RowHeadersWidth = 70

            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetDGV Error")
        Finally
            Call myCDBConnection.CloseConn(myConn, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SetReadOnlyDgv(_contentView As String, Optional _oneRow As Boolean = False)
        Try
            If (_contentView = "Presensi") Then
                If Not (_oneRow) Then
                    For i As Integer = 0 To dgvView.Rows.Count - 1
                        If IsDBNull(dgvView.Rows(i).Cells("ijin").Value) Then
                            'Jika kolom ijinnya kosong, maka kolom absen dibuat read only
                            With dgvView
                                .Rows(i).Cells("absen").ReadOnly = True
                                .Rows(i).Cells("absen").Style.BackColor = Color.Gainsboro

                                .Rows(i).Cells("masuk").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                                .Rows(i).Cells("keluar").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))

                                .Rows(i).Cells("masuk").Style.BackColor = IIf(.Rows(i).Cells("masuk").ReadOnly, Color.Gainsboro, Color.White)
                                .Rows(i).Cells("keluar").Style.BackColor = IIf(.Rows(i).Cells("masuk").ReadOnly, Color.Gainsboro, Color.White)
                            End With
                        Else
                            'Jika kolom ijinnya tidak kosong, maka di cek isinya apa
                            If (dgvView.Rows(i).Cells("ijin").Value = "TM") Then
                                'Kalau isinya TM, maka kolom absen dibuat tidak read only
                                With dgvView
                                    .Rows(i).Cells("absen").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                                    .Rows(i).Cells("absen").Style.BackColor = IIf(.Rows(i).Cells("absen").ReadOnly, Color.Gainsboro, Color.White)

                                    .Rows(i).Cells("masuk").ReadOnly = True
                                    .Rows(i).Cells("keluar").ReadOnly = True
                                    .Rows(i).Cells("cekfp").ReadOnly = True
                                    .Rows(i).Cells("terlambat").ReadOnly = True
                                    .Rows(i).Cells("pulangcepat").ReadOnly = True
                                    .Rows(i).Cells("shift").ReadOnly = True

                                    .Rows(i).Cells("masuk").Style.BackColor = Color.Gainsboro
                                    .Rows(i).Cells("keluar").Style.BackColor = Color.Gainsboro
                                    .Rows(i).Cells("cekfp").Style.BackColor = Color.Gainsboro
                                    .Rows(i).Cells("terlambat").Style.BackColor = Color.Gainsboro
                                    .Rows(i).Cells("pulangcepat").Style.BackColor = Color.Gainsboro
                                    .Rows(i).Cells("shift").Style.BackColor = Color.Gainsboro
                                End With
                            Else
                                'Kalau isinya bukan TM, maka kolom absen dibuat read only
                                With dgvView
                                    .Rows(i).Cells("absen").ReadOnly = True
                                    .Rows(i).Cells("absen").Style.BackColor = Color.Gainsboro

                                    .Rows(i).Cells("masuk").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                                    .Rows(i).Cells("keluar").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))

                                    .Rows(i).Cells("masuk").Style.BackColor = IIf(.Rows(i).Cells("masuk").ReadOnly, Color.Gainsboro, Color.White)
                                    .Rows(i).Cells("keluar").Style.BackColor = IIf(.Rows(i).Cells("masuk").ReadOnly, Color.Gainsboro, Color.White)
                                End With
                            End If
                        End If
                    Next
                Else
                    'Jika 1 baris
                    If IsDBNull(dgvView.CurrentRow.Cells("ijin").Value) Then
                        'Jika kolom ijinnya kosong, maka kolom absen dibuat read only
                        With dgvView
                            .CurrentRow.Cells("absen").ReadOnly = True
                            .CurrentRow.Cells("absen").Style.BackColor = Color.Gainsboro

                            .CurrentRow.Cells("masuk").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                            .CurrentRow.Cells("keluar").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))

                            .CurrentRow.Cells("masuk").Style.BackColor = IIf(.CurrentRow.Cells("masuk").ReadOnly, Color.Gainsboro, Color.White)
                            .CurrentRow.Cells("keluar").Style.BackColor = IIf(.CurrentRow.Cells("masuk").ReadOnly, Color.Gainsboro, Color.White)
                        End With
                    Else
                        'Jika kolom ijinnya tidak kosong, maka di cek isinya apa
                        If (dgvView.CurrentRow.Cells("ijin").Value = "TM") Then
                            'Kalau isinya TM, maka kolom absen dibuat tidak read only
                            With dgvView
                                .CurrentRow.Cells("absen").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                                .CurrentRow.Cells("absen").Style.BackColor = IIf(.CurrentRow.Cells("absen").ReadOnly, Color.Gainsboro, Color.White)

                                .CurrentRow.Cells("masuk").ReadOnly = True
                                .CurrentRow.Cells("keluar").ReadOnly = True

                                .CurrentRow.Cells("masuk").Style.BackColor = Color.Gainsboro
                                .CurrentRow.Cells("keluar").Style.BackColor = Color.Gainsboro
                            End With
                        Else
                            'Kalau isinya bukan TM, maka kolom absen dibuat read only
                            With dgvView
                                .CurrentRow.Cells("absen").ReadOnly = True
                                .CurrentRow.Cells("absen").Style.BackColor = Color.Gainsboro

                                .CurrentRow.Cells("masuk").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                                .CurrentRow.Cells("keluar").ReadOnly = Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))

                                .CurrentRow.Cells("masuk").Style.BackColor = IIf(.CurrentRow.Cells("masuk").ReadOnly, Color.Gainsboro, Color.White)
                                .CurrentRow.Cells("keluar").Style.BackColor = IIf(.CurrentRow.Cells("masuk").ReadOnly, Color.Gainsboro, Color.White)
                            End With
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetReadOnlyDgv Error")
        End Try
    End Sub

    Private Function GetShift(_jamMasuk As String, _jamKeluar As String, _banyakJamKerja As Double, Optional _jadwalMasuk As String = Nothing, Optional _jadwalKeluar As String = Nothing) As Byte
        Try
            '========================= UNTUK SET SHIFT NYA, SHIFT 1 < 23:00, SHIFT 2 = 23:00, SHIFT 3 > 23:00
            If Not IsNothing(_jadwalMasuk) And Not IsNothing(_jadwalKeluar) And _jadwalMasuk <> "" And _jadwalKeluar <> "" Then
                'Jika jadwal masuk dan jadwal pulangnya ada
                If (TimeSpan.Parse(_jadwalKeluar) < TimeSpan.Parse(_jadwalMasuk)) Then
                    'Kalau jam pulangnya lebih kecil dari jam masuknya, maka bisa dipastikan shift 3
                    'Contoh: masuk 23:00 dan pulang 07:00
                    If (_banyakJamKerja >= 4) Then
                        'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                        GetShift = 3
                    Else
                        GetShift = 1
                    End If
                Else
                    If (TimeSpan.Parse(_jadwalKeluar) < TimeSpan.Parse("23:00")) Then
                        'Kalau kurang dari jam 23, maka shift 1
                        GetShift = 1
                    ElseIf (TimeSpan.Parse(_jadwalKeluar) = TimeSpan.Parse("23:00")) Then
                        'Kalau sama dengan jam 23, maka shift 2
                        If (_banyakJamKerja >= 4) Then
                            'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                            GetShift = 2
                        Else
                            GetShift = 1
                        End If
                    ElseIf (TimeSpan.Parse(_jadwalKeluar) > TimeSpan.Parse("23:00")) Then
                        'Kalau lebih dari 23 maka shift 3
                        If (_banyakJamKerja >= 4) Then
                            'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                            GetShift = 3
                        Else
                            GetShift = 1
                        End If
                    Else
                        GetShift = 1
                    End If
                End If
            Else
                'Jika jadwal masuk dan jadwal pulangnya tidak ada, hanya bisa ditentukan jika jam pulangnya menyentuh jam 11 malam
                If Not IsNothing(_jamKeluar) And Not (_jamKeluar = "") Then
                    'Kalau jam keluarnya ada
                    If Not IsNothing(_jamMasuk) And Not (_jamMasuk = "") Then
                        'Kalau jam masuk dan jam keluarnya ada isinya
                        If (TimeSpan.Parse(_jamKeluar) < TimeSpan.Parse(_jamMasuk)) Then
                            'Kalau jam pulangnya lebih kecil dari jam masuknya, maka bisa dipastikan shift 3
                            'Contoh: masuk 23:00 dan pulang 07:00
                            If (_banyakJamKerja >= 4) Then
                                'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                                GetShift = 3
                            Else
                                GetShift = 1
                            End If
                        Else
                            If (TimeSpan.Parse(_jamKeluar) < TimeSpan.Parse("23:00")) Then
                                'Kalau kurang dari jam 23, maka shift 1
                                GetShift = 1
                            ElseIf (TimeSpan.Parse(_jamKeluar) = TimeSpan.Parse("23:00")) Then
                                'Kalau sama dengan jam 23, maka shift 2
                                If (_banyakJamKerja >= 4) Then
                                    'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                                    GetShift = 2
                                Else
                                    GetShift = 1
                                End If
                            ElseIf (TimeSpan.Parse(_jamKeluar) > TimeSpan.Parse("23:00")) Then
                                'Kalau lebih dari 23 maka shift 3
                                If (_banyakJamKerja >= 4) Then
                                    'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                                    GetShift = 3
                                Else
                                    GetShift = 1
                                End If
                            Else
                                GetShift = 1
                            End If
                        End If
                    Else
                        'Kalau jam masuknya kosong
                        If (TimeSpan.Parse(_jamKeluar) <= TimeSpan.Parse("07:30")) Then
                            'Kalau jam pulangnya kurang dari sama dengan jam 7:30 pagi, maka dianggap shift 3
                            GetShift = 3
                        Else
                            If (TimeSpan.Parse(_jamKeluar) < TimeSpan.Parse("23:00")) Then
                                'Kalau kurang dari jam 23, maka shift 1
                                GetShift = 1
                            ElseIf (TimeSpan.Parse(_jamKeluar) = TimeSpan.Parse("23:00")) Then
                                'Kalau sama dengan jam 23, maka shift 2
                                'Memang tak kasih spare jarak jam setengah jam, karena bisa jadi fingernya gak persis jam 11
                                GetShift = 2
                            ElseIf (TimeSpan.Parse(_jamKeluar) > TimeSpan.Parse("23:00")) Then
                                'Kalau lebih dari 23 maka shift 3
                                GetShift = 3
                            Else
                                GetShift = 1
                            End If
                        End If
                    End If
                Else
                    'Kalau jam keluarnya kosong
                    If Not IsNothing(_jamMasuk) And Not (_jamMasuk = "") Then
                        'Kalau jam masuknya ada isinya, tidak bisa melakukan apa2, karena patokannya di jam keluarnya
                        GetShift = 1
                    Else
                        GetShift = 1
                    End If
                End If
            End If
            '==================================
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetShift Error")
            GetShift = 1
        End Try
    End Function

    Private Function GetJamKerjaNyata(_jadwalMasuk As String, _jadwalPulang As String, _jamKerja As String, _lokasi As String, _tanggal As Date, _perusahaan As String, _kelompok As String, _katpenggajian As String, _isSecurity As Boolean, _terlambat As String, _pulangCepat As String) As String
        Try
            Dim batasToleransi As TimeSpan
            If (Not IsNothing(_jadwalMasuk) And Not IsNothing(_jadwalPulang)) And ((_jadwalMasuk <> "") And (_jadwalPulang <> "")) Then
                'Kalau jadwal masuk dan jadwal pulangnya ada
                'Dihitung dari jadwal jam pulang dikurangkan dengan jadwal jam masuknya, khusus untuk security, tanpa dikurangi jam istirahat
                'Lembur tidak perlu ditambahkan di sini, karena perhitungan gajinya beda
                'GetJamKerjaNyata = (TimeSpan.Parse(GetJamKerja(_jadwalMasuk, _jadwalPulang, _lokasi, WeekdayName(Weekday(_tanggal)), _isSecurity)) - TimeSpan.Parse(IIf(IsNothing(_terlambat), "00:00:00", _terlambat)) - TimeSpan.Parse(IIf(IsNothing(_pulangCepat), "00:00:00", _pulangCepat))).ToString
                GetJamKerjaNyata = GetJamKerja(_jadwalMasuk, _jadwalPulang, _lokasi, _perusahaan, WeekdayName(Weekday(_tanggal)), _isSecurity)
            Else
                'Kalau jadwal masuk dan jadwal pulangnya tidak ada, maka langsung dianggap 8 jam kerja dulu
                'If (_isSecurity) Then
                '    If (Trim(_lokasi) = "SIDOARJO") Then
                '        'Khusus untuk security di Sidoarjo jam kerjanya 12 jam
                '        GetJamKerjaNyata = "12:00:00"
                '    Else
                '        GetJamKerjaNyata = "08:00:00"
                '    End If
                'Else
                '    If (WeekdayName(Weekday(_tanggal)) = "Friday") Then
                '        If Not (_perusahaan.ToUpper.Contains("APOTEK")) Then
                '            GetJamKerjaNyata = "08:30:00"
                '        Else
                '            GetJamKerjaNyata = "08:00:00"
                '        End If
                '    Else
                '        GetJamKerjaNyata = "08:00:00"
                '    End If
                'End If
                GetJamKerjaNyata = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "jamkerja", CONN_.schemaHRD & ".msdefaultjamkerja",, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' AND perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' AND issecurity='" & _isSecurity & "' AND hari='" & WeekdayName(Weekday(_tanggal)) & "'")

                If Not IsNothing(_jamKerja) And _jamKerja <> "" Then
                    'Jika tidak ada jadwal, dan jam kerja sebelumnya lebih kecil dari jam kerja sesungguhnya (8 dan 12 jam), maka jam kerja nyata disesuaikan dengan jam kerja yang sebelumnya
                    If (TimeSpan.Parse(_jamKerja) < TimeSpan.Parse(GetJamKerjaNyata)) Then
                        If (Trim(_lokasi) = "SIDOARJO") Then
                            'Diambil jam nya saja, dibulatkan ke bawah
                            GetJamKerjaNyata = TimeSpan.Parse(_jamKerja).Hours & ":00:00".ToString
                        ElseIf (Trim(_lokasi) = "PANDAAN") Then
                            'Kalau Pandaan, diambil persis sesuai jam kerjanya
                            GetJamKerjaNyata = _jamKerja
                        End If
                    End If
                Else
                    'Jika tidak ada semuanya, maka jam kerjanya berarti memang kosong
                    GetJamKerjaNyata = Nothing
                End If
            End If

            If Not IsNothing(GetJamKerjaNyata) Then
                'Sekarang cek pengurangnya, jam terlambat atau pulang cepat
                If (_kelompok = "STAFF") Then
                    'Untuk STAFF
                    If (IsNothing(_terlambat) And IsNothing(_pulangCepat)) And (_terlambat = "" And _pulangCepat = "") Then
                        'Jika tidak terlambat dan pulang cepat, maka jam kerjanya full
                    Else
                        'Jika ada jam terlambatnya atau pulang cepat, maka dilakukan pengecekkan sesuai data yang ada di tabel mstoleransimenit
                        If Not IsNothing(_terlambat) And (_terlambat <> "") Then
                            'DATANG TERLAMBAT
                            batasToleransi = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "batastoleransi", tableName(12),, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(_kelompok) & "' and katpenggajian='" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "' and ijin='DT'")
                            If Not IsNothing(batasToleransi) Then
                                If (TimeSpan.Parse(_terlambat) > batasToleransi) Then
                                    'Jika jam terlambatnya melebihi batas toleransinya, kalau untuk staff maka langsung dianggap tidak masuk kerja
                                    'If (Trim(_lokasi) = "SIDOARJO") Then
                                    '    'Kalau di Sidoarjo, kalau lebih dari batas toleransi telat, maka langsung dianggap tidak masuk
                                    '    'Nanti denda terlambatnya diperhitungkan kemudian, tetap ada denda telat 2500
                                    '    'Kalau di Sidoarjo, kalau telatnya masih di bawah batas toleransi, hanya dikenakan denda telat 2500
                                    '    GetJamKerjaNyata = Nothing
                                    'ElseIf (Trim(_lokasi) = "PANDAAN") Then
                                    '    'kalau di Pandaan, kalau lebih dari batas toleransi telat, maka nanti perhitungan jam kerjanya akan dihitung jam2an
                                    '    'Nanti denda terlambatnya diperhitungkan kemudian, tetap ada denda telat 2500
                                    '    'Jadi di Pandaan selain potongan gaji per jam, juga ditambah denda telat 2500
                                    GetJamKerjaNyata = (TimeSpan.Parse(GetJamKerjaNyata) - TimeSpan.Parse(_terlambat)).ToString
                                    'End If
                                End If
                            End If
                        End If
                        If Not IsNothing(_pulangCepat) And (_pulangCepat <> "") Then
                            'PULANG CEPAT
                            batasToleransi = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "batastoleransi", tableName(12),, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(_kelompok) & "' and katpenggajian='" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "' and ijin='PC'")
                            If Not IsNothing(batasToleransi) Then
                                If (TimeSpan.Parse(_pulangCepat) > batasToleransi) Then
                                    'Jika jam pulangnya melebihi batas toleransinya, kalau untuk staff maka langsung dianggap tidak masuk kerja
                                    'If (Trim(_lokasi) = "SIDOARJO") Then
                                    '    'Jika jam pulangnya melebihi batas toleransinya, kalau untuk staff di Sidoarjo maka langsung dianggap tidak masuk kerja
                                    '    GetJamKerjaNyata = Nothing
                                    'ElseIf (Trim(_lokasi) = "PANDAAN") Then
                                    '    'Jika jam pulangnya melebihi batas toleransinya, kalau untuk staff di Pandaan maka akan dihitung gaji per jam
                                    GetJamKerjaNyata = (TimeSpan.Parse(GetJamKerjaNyata) - TimeSpan.Parse(_pulangCepat)).ToString
                                    'End If
                                End If
                            End If
                        End If
                    End If
                Else
                    'Untuk NON STAFF dan OUTSOURCING. Perlakuan terlambatnya berbeda, jadi harus dipisah
                    If (IsNothing(_terlambat) And IsNothing(_pulangCepat)) And (_terlambat = "" And _pulangCepat = "") Then
                        'Jika tidak terlambat dan pulang cepat, maka jam kerjanya full
                    Else
                        'Jika ada jam terlambatnya atau pulang cepat, maka dilakukan pengecekkan sesuai data yang ada di tabel mstoleransimenit
                        If (Not IsNothing(_terlambat) And Not IsNothing(GetJamKerjaNyata)) And (_terlambat <> "" And GetJamKerjaNyata <> "") Then
                            'DATANG TERLAMBAT
                            batasToleransi = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "batastoleransi", tableName(12),, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(_kelompok) & "' and katpenggajian='" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "' and ijin='DT'")
                            If Not IsNothing(batasToleransi) Then
                                If (TimeSpan.Parse(_terlambat) > batasToleransi) Then
                                    'Jika jam terlambatnya melebihi batas toleransinya, kalau untuk non staff maka akan dihitung gaji per jam
                                    If (Trim(_lokasi) = "SIDOARJO") Then
                                        GetJamKerjaNyata = TimeSpan.Parse(TimeSpan.Parse(GetJamKerjaNyata).Hours - TimeSpan.Parse(_terlambat).Hours & ":00:00").ToString
                                        If (TimeSpan.Parse(_terlambat).Minutes > 0 And TimeSpan.Parse(_terlambat).Minutes > batasToleransi.Minutes) Then
                                            If (TimeSpan.Parse(GetJamKerjaNyata).Hours > 1) Then
                                                GetJamKerjaNyata = TimeSpan.Parse(TimeSpan.Parse(GetJamKerjaNyata).Hours - 1 & ":00:00").ToString
                                            Else
                                                GetJamKerjaNyata = Nothing
                                            End If
                                        End If
                                    ElseIf (Trim(_lokasi) = "PANDAAN") Then
                                        'Kalau di Pandaan dihitung sampai ke menitnya, jam kerja nyatanya berapa
                                        GetJamKerjaNyata = (TimeSpan.Parse(GetJamKerjaNyata) - TimeSpan.Parse(_terlambat)).ToString
                                    End If
                                End If
                            End If
                        End If
                        If (Not IsNothing(_pulangCepat) And Not IsNothing(GetJamKerjaNyata)) And (_pulangCepat <> "" And GetJamKerjaNyata <> "") Then
                            'PULANG CEPAT
                            batasToleransi = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "batastoleransi", tableName(12),, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(_kelompok) & "' and katpenggajian='" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "' and ijin='PC'")
                            If Not IsNothing(batasToleransi) Then
                                If (TimeSpan.Parse(_pulangCepat) > batasToleransi) Then
                                    'Jika jam pulangnya melebihi batas toleransinya, kalau untuk non staff maka akan dihitung gaji per jam
                                    If (Trim(_lokasi) = "SIDOARJO") Then
                                        GetJamKerjaNyata = TimeSpan.Parse(TimeSpan.Parse(GetJamKerjaNyata).Hours - TimeSpan.Parse(_pulangCepat).Hours & ":00:00").ToString
                                        If (TimeSpan.Parse(_pulangCepat).Minutes > 0 And TimeSpan.Parse(_pulangCepat).Minutes > batasToleransi.Minutes) Then
                                            If (TimeSpan.Parse(GetJamKerjaNyata).Hours > 1) Then
                                                GetJamKerjaNyata = TimeSpan.Parse(TimeSpan.Parse(GetJamKerjaNyata).Hours - 1 & ":00:00").ToString
                                            Else
                                                GetJamKerjaNyata = Nothing
                                            End If
                                        End If
                                    ElseIf (Trim(_lokasi) = "PANDAAN") Then
                                        'Kalau di Pandaan dihitung sampai ke menitnya, jam kerja nyatanya berapa
                                        GetJamKerjaNyata = (TimeSpan.Parse(GetJamKerjaNyata) - TimeSpan.Parse(_pulangCepat)).ToString
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetJamKerjaNyata Error")
            GetJamKerjaNyata = Nothing
        End Try
    End Function

    Private Function GetJamKerja(_jamMasuk As String, _jamKeluar As String, _lokasi As String, _perusahaan As String, _hari As String, Optional _isSecurity As Boolean = False) As String
        Try
            If Not IsNothing(_jamMasuk) And (_jamMasuk <> "") And Not IsNothing(_jamKeluar) And (_jamKeluar <> "") Then
                'Jam masuk dan jam keluarnya harus sama2 ada isinya, tidak boleh salah 1 kosong!!
                'Untuk hitung jam kerja dan banyaknya jam kerjanya
                Dim jamIstirahat As String
                'If (_isSecurity) Then
                '    'Security jam istirahatnya tidak dihitung
                '    jamIstirahat = "00:00:00"
                'Else
                '    Select Case _lokasi
                '        Case "SIDOARJO"
                '            jamIstirahat = "01:00:00"
                '        Case "PANDAAN"
                '            If (_hari = "Friday") Then
                '                jamIstirahat = "01:00:00"
                '            Else
                '                jamIstirahat = "00:30:00"
                '            End If
                '        Case Else
                '            'Defaultnya kita kasih jam istirahat 1 jam
                '            jamIstirahat = "01:00:00"
                '    End Select
                'End If
                jamIstirahat = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "jamistirahat", CONN_.schemaHRD & ".msdefaultjamistirahat",, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' AND perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' AND issecurity='" & _isSecurity & "' AND hari='" & _hari & "'")

                If (TimeSpan.Parse(_jamKeluar) >= TimeSpan.Parse(_jamMasuk)) Then
                    'kalau jam pulangnya masih lebih besar dari jam masuknya
                    'jam kerja  = jam pulang - jam masuk
                    If ((TimeSpan.Parse(_jamKeluar).Subtract(TimeSpan.Parse(_jamMasuk)) - TimeSpan.Parse(jamIstirahat)) > TimeSpan.Parse("00:00:00")) Then
                        GetJamKerja = (TimeSpan.Parse(_jamKeluar).Subtract(TimeSpan.Parse(_jamMasuk)) - TimeSpan.Parse(jamIstirahat)).ToString
                    Else
                        GetJamKerja = Nothing
                    End If
                Else
                    'kalau jam pulangnya lebih kecil dari jam masuknya, berarti pulangnya di hari besoknya, maka untuk mendapatkan banyak jam kerjanya rumusnya beda
                    'jam kerja = (jam pulang - 00:00) + (23:59 - jam masuk)
                    'Harus ditambah 1 menit, karena jam 24:00 tidak bisa dimasukkan ke perhitungan
                    If ((((TimeSpan.Parse(_jamKeluar) - TimeSpan.Parse("00:00")) + (TimeSpan.Parse("23:59") - TimeSpan.Parse(_jamMasuk)) + (TimeSpan.Parse("00:01"))) - TimeSpan.Parse(jamIstirahat)) > TimeSpan.Parse("00:00:00")) Then
                        GetJamKerja = (((TimeSpan.Parse(_jamKeluar) - TimeSpan.Parse("00:00")) + (TimeSpan.Parse("23:59") - TimeSpan.Parse(_jamMasuk)) + (TimeSpan.Parse("00:01"))) - TimeSpan.Parse(jamIstirahat)).ToString
                    Else
                        GetJamKerja = Nothing
                    End If
                End If
            Else
                GetJamKerja = Nothing
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetJamKerja Error")
            GetJamKerja = 0
        End Try
    End Function

    Private Function GetBanyakJamKerja(_jamKerja As String, Optional _pembulatan As Boolean = True) As Double
        Try
            If Not IsNothing(_jamKerja) And _jamKerja <> "" Then
                If (_pembulatan) Then
                    If (TimeSpan.Parse(_jamKerja) > TimeSpan.Parse("00:00:00")) Then
                        If (TimeSpan.Parse(_jamKerja).Minutes >= 0 And TimeSpan.Parse(_jamKerja).Minutes <= 29) Then
                            'Jika menitnya kurang dari 29 menit, maka dianggap 0
                            'Jika menitnya lebih dari atau sama dengan 29 menit, maka dianggap 0.5
                            ' 0 - 28 masuk ke 0 || menit ke 29 menjadi 0.5 jam
                            GetBanyakJamKerja = TimeSpan.Parse(_jamKerja).Hours & "." & IIf(TimeSpan.Parse(_jamKerja).Minutes < 29, 0, 5)
                        ElseIf (TimeSpan.Parse(_jamKerja).Minutes > 29 And TimeSpan.Parse(_jamKerja).Minutes <= 59) Then
                            'jika lebih dari 29 menit dan kurang dari atau sama dengan 59 menit maka dihitung jam nya masuk ke 1
                            If (TimeSpan.Parse(_jamKerja).Minutes >= 59) Then
                                'Kalau menitnya lebih dari atau sama dengan 59, maka jam nya dianggap naik 1
                                GetBanyakJamKerja = TimeSpan.Parse(_jamKerja).Hours + 1
                            Else
                                'Kalau menitnya di bawah 59 tapi di atas 29, maka dianggap 0.5
                                GetBanyakJamKerja = TimeSpan.Parse(_jamKerja).Hours & ".5"
                            End If
                        Else
                            GetBanyakJamKerja = 0
                        End If
                    Else
                        GetBanyakJamKerja = 0
                    End If
                Else
                    'Kalau banyak jam kerjanya tidak dibulatkan, jadi bisa 0.2, 0.7 dll
                    If (TimeSpan.Parse(_jamKerja) > TimeSpan.Parse("00:00:00")) Then
                        GetBanyakJamKerja = (TimeSpan.Parse(_jamKerja).Hours) + Math.Round(TimeSpan.Parse(_jamKerja).Minutes / 60, 2)
                    Else
                        GetBanyakJamKerja = 0
                    End If
                End If
            Else
                GetBanyakJamKerja = 0
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetBanyakJamKerja Error")
            GetBanyakJamKerja = 0
        End Try
    End Function

    Private Sub dgvView_Sorted(sender As Object, e As EventArgs) Handles dgvView.Sorted
        Try
            ''untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvView, dgvView.Rows.Count)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_Sorted Error")
        End Try
    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        Try
            mCari = myCStringManipulation.SafeSqlLiteral(tbCari.Text, 1)
            cbTampilkanYangKosong.Checked = False
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, contentView, True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTampilkan_Click Error")
        End Try
    End Sub

    Private Sub dgvView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvView.DataError

    End Sub

    Private Sub dgvView_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvView.CellMouseDown
        Try
            If (contentView = "Presensi") Then
                If (dgvView.RowCount > 0) Then
                    'fungsi ini ditujukan agar user bisa memilih cell dengan klik kanan juga
                    If e.Button = MouseButtons.Right Then
                        If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then
                            dgvView.CurrentCell = dgvView.Item(e.ColumnIndex, e.RowIndex)
                            dgvView.CurrentCell.Selected = True
                            If (contentView = "Presensi") Then
                                If (e.ColumnIndex = dgvView.Columns("ijin").Index Or e.ColumnIndex = dgvView.Columns("absen").Index) Then
                                    If (isDataPrepared) Then
                                        If Not IsDBNull(dgvView.CurrentCell.Value) Then
                                            initialValue = Trim(dgvView.CurrentCell.Value.ToString)
                                        Else
                                            initialValue = Nothing
                                        End If
                                    End If
                                    If (e.ColumnIndex = dgvView.Columns("ijin").Index) Then
                                        If (cboMohonIjin.SelectedIndex <> -1) Then
                                            dgvView.CurrentCell.Value = cboMohonIjin.SelectedValue
                                        Else
                                            Call myCShowMessage.ShowWarning("Silahkan tentukan dulu jenis ijinnya!!")
                                        End If
                                    ElseIf (e.ColumnIndex = dgvView.Columns("absen").Index) Then
                                        If (cboAbsen.SelectedIndex <> -1) Then
                                            dgvView.CurrentCell.Value = cboAbsen.SelectedValue
                                        Else
                                            Call myCShowMessage.ShowWarning("Silahkan tentukan dulu jenis absennya!!")
                                        End If
                                    End If
                                    Call SetReadOnlyDgv(contentView, True)
                                End If
                            End If
                        Else
                            With dgvView
                                'kondisi ini untuk kalau user mengklik di header dgv nya
                                'selected cell sebelumnya di clear dulu
                                .ClearSelection()
                                'untuk mindah pointer
                                .CurrentCell = dgvView.Item(1, e.RowIndex)
                                'untuk select 1 baris penuh
                                .Rows(e.RowIndex).Selected = True
                            End With
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellMouseDown Error")
        End Try
    End Sub

    Private Sub tbPathSimpan_Click(sender As System.Object, e As System.EventArgs) Handles tbPathSimpan.Click
        Try
            fbdExport.ShowDialog()
            'di cek apakah char terakhir pada string path adalah \ atw gak
            'klw gak, maka harus dikasih \, kalau sudah ada, misal kalau user pilih lokasi di C:\, maka tidak ditambahi \ lagi
            If (fbdExport.SelectedPath.Length > 0) Then
                If (fbdExport.SelectedPath.Chars(fbdExport.SelectedPath.Count - 1) <> "\") Then
                    tbPathSimpan.Text = fbdExport.SelectedPath & "\"
                Else
                    tbPathSimpan.Text = fbdExport.SelectedPath
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbPathSimpan_Click Error")
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        Try
            fbdExport.ShowDialog()
            'di cek apakah char terakhir pada string path adalah \ atw gak
            'klw gak, maka harus dikasih \, kalau sudah ada, misal kalau user pilih lokasi di C:\, maka tidak ditambahi \ lagi
            If (fbdExport.SelectedPath.Length > 0) Then
                If (fbdExport.SelectedPath.Chars(fbdExport.SelectedPath.Count - 1) <> "\") Then
                    tbPathSimpan.Text = fbdExport.SelectedPath & "\"
                Else
                    tbPathSimpan.Text = fbdExport.SelectedPath
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBrowse_Click Error")
        End Try
    End Sub

    Private Sub btnCetakExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim b As String
            Dim xlspath As String
            Dim xlsfilename As String

            xlspath = tbPathSimpan.Text
            b = tbNamaSimpan.Text

            If (xlspath.Length > 0) Then
                xlsfilename = xlspath & b & "_" & Format(Now(), "ddMMMyyyy")

                Call myCFileIO.ExportDataGridViewToExcel(dgvView, xlsfilename, "EXPORT EXCEL")

                Call myCShowMessage.ShowInfo(" Export ke excel sukses, dengan nama " & xlsfilename & ".xls", "Export Complete")
            Else
                Call myCShowMessage.ShowWarning("Silahkan pilih terlebih dahulu lokasi untuk menyimpan file", "Perhatian")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error:  " & ex.Message, "btnCetakExcel_Click Error")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub rbJamYangDiset_CheckedChanged(sender As Object, e As EventArgs) Handles rbJamMasuk.CheckedChanged, rbJamKeluar.CheckedChanged, rbJamMasukKeluar.CheckedChanged
        Try
            Select Case True
                Case rbJamMasuk.Checked
                    lblJamMasuk.Visible = True
                    dtpJamMasuk.Visible = True
                    lblDash.Visible = False
                    lblJamKeluar.Visible = False
                    dtpJamKeluar.Visible = False
                Case rbJamKeluar.Checked
                    lblJamMasuk.Visible = False
                    dtpJamMasuk.Visible = False
                    lblDash.Visible = False
                    lblJamKeluar.Visible = True
                    dtpJamKeluar.Visible = True
                Case rbJamMasukKeluar.Checked
                    lblJamMasuk.Visible = True
                    dtpJamMasuk.Visible = True
                    lblDash.Visible = True
                    lblJamKeluar.Visible = True
                    dtpJamKeluar.Visible = True
            End Select
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error:  " & ex.Message, "rbJamYangDiset_CheckedChanged Error")
        End Try
    End Sub

    Private Sub dgvView_EditingControlShowing(sender As Object, e As EventArgs) Handles dgvView.EditingControlShowing
        Try
            If (contentView = "Presensi") Then
                If (dgvView.CurrentCell.ColumnIndex = dgvView.Columns("masuk").Index Or dgvView.CurrentCell.ColumnIndex = dgvView.Columns("keluar").Index Or dgvView.CurrentCell.ColumnIndex = dgvView.Columns("jamkerjanyata").Index Or dgvView.CurrentCell.ColumnIndex = dgvView.Columns("terlambat").Index Or dgvView.CurrentCell.ColumnIndex = dgvView.Columns("pulangcepat").Index Or dgvView.CurrentCell.ColumnIndex = dgvView.Columns("mulailembur").Index Or dgvView.CurrentCell.ColumnIndex = dgvView.Columns("selesailembur").Index Or dgvView.CurrentCell.ColumnIndex = dgvView.Columns("jamlembur").Index Or dgvView.CurrentCell.ColumnIndex = dgvView.Columns("spkmulai").Index Or dgvView.CurrentCell.ColumnIndex = dgvView.Columns("spkselesai").Index) Then
                    tbCellText = CType(dgvView.EditingControl, DataGridViewTextBoxEditingControl)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_EditingControlShowing Error")
        End Try
    End Sub

    Private Sub tbCellText_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tbCellText.KeyUp
        Try
            If (contentView = "Presensi") Then
                If (tbCellText.Text.Contains(".")) Then
                    Dim mCellSelection As Integer
                    mCellSelection = tbCellText.SelectionStart
                    tbCellText.Text = tbCellText.Text.Replace(".", ":")
                    tbCellText.SelectionStart = mCellSelection
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbCellText_KeyUp Error")
        End Try
    End Sub

    Private Sub dgvView_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvView.CellBeginEdit
        Try
            If (isDataPrepared) Then
                If (contentView = "Presensi") Then
                    If Not IsDBNull(dgvView.CurrentCell.Value) Then
                        initialValue = Trim(dgvView.CurrentCell.Value.ToString)
                    Else
                        initialValue = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellBeginEdit Error")
        End Try
    End Sub

    Private Sub dgvView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellValueChanged
        Try
            If (isDataPrepared) Then
                If (contentView = "Presensi") Then
                    If Not isPartialChanged Then
                        If Not IsDBNull(dgvView.CurrentCell.Value) Then
                            'kalau tidak null isinya
                            If (initialValue <> (dgvView.CurrentCell.Value.ToString)) Then
                                Dim cekLembur As String
                                Dim strJamLembur As TimeSpan
                                Dim strJamSPK As TimeSpan
                                Dim cekSPK As String
                                If (e.ColumnIndex = dgvView.Columns("jamlembur").Index) Then
                                    cekLembur = myCStringManipulation.CleanInputTime(dgvView.CurrentRow.Cells("jamlembur").Value.ToString)
                                    If IsNothing(cekLembur) Then
                                        Call myCShowMessage.ShowWarning("Format pengisian jam lembur salah dan jam lembur tidak boleh lebih dari 24 jam!!" & ControlChars.NewLine & "Jam lembur dikembalikan ke waktu semula")
                                        isPartialChanged = True
                                        dgvView.CurrentCell.Value = initialValue
                                        isPartialChanged = False
                                        isValueChanged = False
                                    Else
                                        isValueChanged = True
                                    End If
                                ElseIf (e.ColumnIndex = dgvView.Columns("mulailembur").Index Or e.ColumnIndex = dgvView.Columns("selesailembur").Index) Then
                                    If (Format(dgvView.CurrentCell.Value, "dd-MMM-yyyy") <> Format(dgvView.CurrentRow.Cells("tanggal").Value, "dd-MMM-yyyy")) Then
                                        'Hanya jika tanggal lembur tidak sama dengan tanggal presensinya, maka akan dilakukan pengecekkan terlebih dahulu
                                        isPartialChanged = True
                                        If (e.ColumnIndex = dgvView.Columns("mulailembur").Index) Then
                                            'Jika mulai lembur, maka langsung ditambahkan tanggal di baris tersebut
                                            If (Format(dgvView.CurrentCell.Value, "dd-MMM-yyyy") <> Format(Now.Date, "dd-MMM-yyyy")) Then
                                                Call myCShowMessage.ShowWarning("tanggal mulai lembur harus sama dengan tanggal presensinya!")
                                            End If
                                            dgvView.CurrentCell.Value = DateTime.Parse(Format(dgvView.CurrentRow.Cells("tanggal").Value, "dd-MMM-yyyy") & " " & Format(dgvView.CurrentCell.Value, "HH:mm:ss tt"))
                                        ElseIf (e.ColumnIndex = dgvView.Columns("selesailembur").Index) Then
                                            If (Format(dgvView.CurrentCell.Value, "dd-MMM-yyyy") <> Format(Date.Parse(dgvView.CurrentRow.Cells("tanggal").Value).AddDays(1), "dd-MMM-yyyy")) Then
                                                If (Format(dgvView.CurrentCell.Value, "dd-MMM-yyyy") <> Format(Now.Date, "dd-MMM-yyyy")) Then
                                                    Call myCShowMessage.ShowWarning("Tanggal selesai lembur tidak boleh lewat lebih dari 2 hari atau kurang dari tanggal presensinya!")
                                                End If
                                                If Not IsDBNull(dgvView.CurrentRow.Cells("mulailembur").Value) And Not IsDBNull(dgvView.CurrentRow.Cells("selesailembur").Value) Then
                                                    dgvView.CurrentCell.Value = DateTime.Parse(Format(dgvView.CurrentRow.Cells("tanggal").Value, "dd-MMM-yyyy") & " " & Format(dgvView.CurrentCell.Value, "HH:mm:ss tt"))
                                                    strJamLembur = dgvView.CurrentRow.Cells("selesailembur").Value - dgvView.CurrentRow.Cells("mulailembur").Value
                                                    If (strJamLembur < TimeSpan.Parse("00:00:00")) Then
                                                        'Kalau jam selesai lemburnya lebih kecil dari jam mulai lemburnya, berarti selesai lemburnya di hari berikutnya
                                                        dgvView.CurrentCell.Value = DateTime.Parse(Format(dgvView.CurrentRow.Cells("tanggal").Value.AddDays(1), "dd-MMM-yyyy") & " " & Format(dgvView.CurrentCell.Value, "HH:mm:ss tt"))
                                                    End If
                                                Else
                                                    'Jika salah 1 masih tidak ada isinya
                                                    If Not IsNothing(initialValue) Then
                                                        dgvView.CurrentCell.Value = DateTime.Parse(Format(CDate(initialValue), "dd-MMM-yyyy") & " " & Format(dgvView.CurrentCell.Value, "HH:mm:ss tt"))
                                                    Else
                                                        dgvView.CurrentCell.Value = DateTime.Parse(Format(dgvView.CurrentRow.Cells("tanggal").Value, "dd-MMM-yyyy") & " " & Format(dgvView.CurrentCell.Value, "HH:mm:ss tt"))
                                                    End If
                                                End If
                                            End If
                                        End If
                                        isPartialChanged = False
                                    End If

                                    If Not IsDBNull(dgvView.CurrentRow.Cells("mulailembur").Value) And Not IsDBNull(dgvView.CurrentRow.Cells("selesailembur").Value) Then
                                        strJamLembur = dgvView.CurrentRow.Cells("selesailembur").Value - dgvView.CurrentRow.Cells("mulailembur").Value
                                        cekLembur = myCStringManipulation.CleanInputTime(strJamLembur.ToString)
                                        If IsNothing(cekLembur) Then
                                            Call myCShowMessage.ShowWarning("Format pengisian jam lembur salah dan jam lembur tidak boleh lebih dari 24 jam!!" & ControlChars.NewLine & "Jam lembur dikembalikan ke waktu semula")
                                            isPartialChanged = True
                                            dgvView.CurrentCell.Value = Format(Date.Parse(initialValue), "dd-MMM-yyyy HH:mm:ss")
                                            isPartialChanged = False
                                            isValueChanged = False
                                        Else
                                            isValueChanged = True
                                        End If
                                    Else
                                        isValueChanged = True
                                    End If
                                ElseIf (e.ColumnIndex = dgvView.Columns("spkmulai").Index Or e.ColumnIndex = dgvView.Columns("spkselesai").Index) Then
                                    If (Format(dgvView.CurrentCell.Value, "dd-MMM-yyyy") <> Format(dgvView.CurrentRow.Cells("tanggal").Value, "dd-MMM-yyyy")) Then
                                        'Hanya jika tanggal SPK tidak sama dengan tanggal presensinya, maka akan dilakukan pengecekkan terlebih dahulu
                                        isPartialChanged = True
                                        If (e.ColumnIndex = dgvView.Columns("spkmulai").Index) Then
                                            'Jika mulai lembur, maka langsung ditambahkan tanggal di baris tersebut
                                            If (Format(dgvView.CurrentCell.Value, "dd-MMM-yyyy") <> Format(Now.Date, "dd-MMM-yyyy")) Then
                                                Call myCShowMessage.ShowWarning("tanggal mulai SPK harus sama dengan tanggal presensinya!")
                                            End If
                                            dgvView.CurrentCell.Value = DateTime.Parse(Format(dgvView.CurrentRow.Cells("tanggal").Value, "dd-MMM-yyyy") & " " & Format(dgvView.CurrentCell.Value, "HH:mm:ss tt"))
                                        ElseIf (e.ColumnIndex = dgvView.Columns("spkselesai").Index) Then
                                            If (Format(dgvView.CurrentCell.Value, "dd-MMM-yyyy") <> Format(Date.Parse(dgvView.CurrentRow.Cells("tanggal").Value).AddDays(1), "dd-MMM-yyyy")) Then
                                                If (Format(dgvView.CurrentCell.Value, "dd-MMM-yyyy") <> Format(Now.Date, "dd-MMM-yyyy")) Then
                                                    Call myCShowMessage.ShowWarning("Tanggal selesai SPK tidak boleh lewat lebih dari 2 hari atau kurang dari tanggal presensinya!")
                                                End If
                                                If Not IsDBNull(dgvView.CurrentRow.Cells("spkmulai").Value) And Not IsDBNull(dgvView.CurrentRow.Cells("spkselesai").Value) Then
                                                    dgvView.CurrentCell.Value = DateTime.Parse(Format(dgvView.CurrentRow.Cells("tanggal").Value, "dd-MMM-yyyy") & " " & Format(dgvView.CurrentCell.Value, "HH:mm:ss tt"))
                                                    strJamLembur = dgvView.CurrentRow.Cells("spkselesai").Value - dgvView.CurrentRow.Cells("spkmulai").Value
                                                    If (strJamLembur < TimeSpan.Parse("00:00:00")) Then
                                                        'Kalau jam selesai SPK lebih kecil dari jam mulai SPK, berarti selesai SPK nya di hari berikutnya
                                                        dgvView.CurrentCell.Value = DateTime.Parse(Format(dgvView.CurrentRow.Cells("tanggal").Value.AddDays(1), "dd-MMM-yyyy") & " " & Format(dgvView.CurrentCell.Value, "HH:mm:ss tt"))
                                                    End If
                                                Else
                                                    'Jika salah 1 masih tidak ada isinya
                                                    If Not IsNothing(initialValue) Then
                                                        dgvView.CurrentCell.Value = DateTime.Parse(Format(CDate(initialValue), "dd-MMM-yyyy") & " " & Format(dgvView.CurrentCell.Value, "HH:mm:ss tt"))
                                                    Else
                                                        dgvView.CurrentCell.Value = DateTime.Parse(Format(dgvView.CurrentRow.Cells("tanggal").Value, "dd-MMM-yyyy") & " " & Format(dgvView.CurrentCell.Value, "HH:mm:ss tt"))
                                                    End If
                                                End If
                                            End If
                                        End If
                                        isPartialChanged = False
                                    End If

                                    If Not IsDBNull(dgvView.CurrentRow.Cells("spkmulai").Value) And Not IsDBNull(dgvView.CurrentRow.Cells("spkselesai").Value) Then
                                        strJamSPK = dgvView.CurrentRow.Cells("spkselesai").Value - dgvView.CurrentRow.Cells("spkmulai").Value
                                        cekSPK = myCStringManipulation.CleanInputTime(strJamLembur.ToString)
                                        If IsNothing(cekSPK) Then
                                            Call myCShowMessage.ShowWarning("Format pengisian jam SPK salah dan jam SPK tidak boleh lebih dari 24 jam!!" & ControlChars.NewLine & "Jam SPK dikembalikan ke waktu semula")
                                            isPartialChanged = True
                                            dgvView.CurrentCell.Value = Format(Date.Parse(initialValue), "dd-MMM-yyyy HH:mm:ss")
                                            isPartialChanged = False
                                            isValueChanged = False
                                        Else
                                            isValueChanged = True
                                        End If
                                    Else
                                        isValueChanged = True
                                    End If
                                ElseIf (e.ColumnIndex = dgvView.Columns("jamkerjanyata").Index) Then
                                    Dim limitJamKerja As String
                                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                                    limitJamKerja = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "jamkerja", CONN_.schemaHRD & ".msdefaultjamkerja",, "lokasi='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("lokasi").Value) & "' AND perusahaan='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("perusahaan").Value) & "' AND issecurity='" & IIf(dgvView.CurrentRow.Cells("departemen").Value = "SECURITY", "True", "False") & "' AND hari='" & WeekdayName(Weekday(dgvView.CurrentRow.Cells("tanggal").Value)) & "'")
                                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                                    If (dgvView.CurrentCell.Value > TimeSpan.Parse(limitJamKerja)) Then
                                        'Jam Kerja di PANDAAN tidak boleh lebih dari 8 Jam, Lemburan dihitung terpisah, tidak dihitung sebagai jam kerja normal
                                        Call myCShowMessage.ShowWarning("Jam kerja di " & dgvView.CurrentRow.Cells("lokasi").Value & " untuk departemen " & dgvView.CurrentRow.Cells("departemen").Value & " tidak boleh lebih dari " & limitJamKerja & " jam!!" & ControlChars.NewLine & "Jika ada lembur masukkan di kolom lemburan")
                                        isValueChanged = False
                                    Else
                                        isValueChanged = True
                                    End If
                                    If Not (isValueChanged) Then
                                        isPartialChanged = True
                                        If Not IsNothing(initialValue) Then
                                            dgvView.CurrentCell.Value = TimeSpan.Parse(initialValue)
                                        Else
                                            dgvView.CurrentCell.Value = DBNull.Value
                                        End If
                                        isPartialChanged = False
                                    End If
                                    'If (dgvView.CurrentRow.Cells("departemen").Value = "SECURITY") Then
                                    '    If (dgvView.CurrentRow.Cells("lokasi").Value = "PANDAAN") Then
                                    '        If (dgvView.CurrentCell.Value > TimeSpan.Parse("08:00:00")) Then
                                    '            'Jam Kerja di PANDAAN tidak boleh lebih dari 8 Jam, Lemburan dihitung terpisah, tidak dihitung sebagai jam kerja normal
                                    '            Call myCShowMessage.ShowWarning("Jam kerja Security tidak boleh lebih dari 8 jam!!" & ControlChars.NewLine & "Jika ada lembur masukkan di kolom lemburan")
                                    '            isValueChanged = False
                                    '        Else
                                    '            isValueChanged = True
                                    '        End If
                                    '    ElseIf (dgvView.CurrentRow.Cells("lokasi").Value = "SIDOARJO") Then
                                    '        If (dgvView.CurrentCell.Value > TimeSpan.Parse("12:00:00")) Then
                                    '            'Jam Kerja di PANDAAN tidak boleh lebih dari 8 Jam, Lemburan dihitung terpisah, tidak dihitung sebagai jam kerja normal
                                    '            Call myCShowMessage.ShowWarning("Jam kerja Security tidak boleh lebih dari 12 jam!!" & ControlChars.NewLine & "Jika ada lembur masukkan di kolom lemburan")
                                    '            isValueChanged = False
                                    '        Else
                                    '            isValueChanged = True
                                    '        End If
                                    '    End If
                                    'Else
                                    '    If (dgvView.CurrentRow.Cells("lokasi").Value = "PANDAAN") Then
                                    '        If (dgvView.CurrentCell.Value > TimeSpan.Parse("08:00:00")) Then
                                    '            'Jam Kerja di PANDAAN tidak boleh lebih dari 8 Jam, Lemburan dihitung terpisah, tidak dihitung sebagai jam kerja normal
                                    '            Call myCShowMessage.ShowWarning("Jam kerja tidak boleh lebih dari 8 jam!!" & ControlChars.NewLine & "Jika ada lembur masukkan di kolom lemburan")
                                    '            isValueChanged = False
                                    '        Else
                                    '            isValueChanged = True
                                    '        End If
                                    '    ElseIf (dgvView.CurrentRow.Cells("lokasi").Value = "SIDOARJO") Then
                                    '        If (dgvView.CurrentRow.Cells("perusahaan").Value.ToString.ToUpper.Contains("APOTEK")) Then
                                    '            If (dgvView.CurrentCell.Value > TimeSpan.Parse("08:00:00")) Then
                                    '                'Jam Kerja di APOTEK tidak boleh lebih dari 8 Jam, Lemburan dihitung terpisah, tidak dihitung sebagai jam kerja normal
                                    '                Call myCShowMessage.ShowWarning("Jam kerja tidak boleh lebih dari 8 jam!!" & ControlChars.NewLine & "Jika ada lembur masukkan di kolom lemburan")
                                    '                isValueChanged = False
                                    '            Else
                                    '                isValueChanged = True
                                    '            End If
                                    '        Else
                                    '            If (WeekdayName(Weekday(dgvView.CurrentRow.Cells("tanggal").Value)) = "Friday") Then
                                    '                'Kalau jumat boleh sampai 8.30 jam
                                    '                If (dgvView.CurrentCell.Value > TimeSpan.Parse("08:30:00")) Then
                                    '                    'Jam Kerja di PANDAAN tidak boleh lebih dari 8 Jam, Lemburan dihitung terpisah, tidak dihitung sebagai jam kerja normal
                                    '                    Call myCShowMessage.ShowWarning("Jam kerja khusus di hari Jumat tidak boleh lebih dari 8.5 jam!!" & ControlChars.NewLine & "Jika ada lembur masukkan di kolom lemburan")
                                    '                    isValueChanged = False
                                    '                Else
                                    '                    isValueChanged = True
                                    '                End If
                                    '            Else
                                    '                'Selain hari jumat, maks sampai 8 jam
                                    '                If (dgvView.CurrentCell.Value > TimeSpan.Parse("08:00:00")) Then
                                    '                    'Jam Kerja selain hari Jumat tidak boleh lebih dari 8 Jam, Lemburan dihitung terpisah, tidak dihitung sebagai jam kerja normal
                                    '                    Call myCShowMessage.ShowWarning("Jam kerja selain hari Jumat tidak boleh lebih dari 8 jam!!" & ControlChars.NewLine & "Jika ada lembur masukkan di kolom lemburan")
                                    '                    isValueChanged = False
                                    '                Else
                                    '                    isValueChanged = True
                                    '                End If
                                    '            End If
                                    '        End If
                                    '    End If
                                    'End If
                                Else
                                    isPartialChanged = True
                                    dgvView.CurrentCell.Value = dgvView.CurrentCell.Value.ToString.ToUpper
                                    Cursor = Cursors.WaitCursor
                                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                                    If (e.ColumnIndex = dgvView.Columns("ijin").Index) Then
                                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(9), "kategori='mohonijin' and kode='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentCell.Value) & "'")
                                        If isExist Then
                                            Call SetReadOnlyDgv(contentView, True)
                                            isValueChanged = True
                                        Else
                                            isValueChanged = False
                                            Call myCShowMessage.ShowWarning("Kode ijin " & dgvView.CurrentCell.Value & " tidak terdaftar!!")
                                            dgvView.CurrentCell.Value = initialValue
                                        End If
                                    ElseIf (e.ColumnIndex = dgvView.Columns("absen").Index) Then
                                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(9), "kategori='absen' and kode='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentCell.Value) & "'")
                                        If isExist Then
                                            isValueChanged = True
                                        Else
                                            isValueChanged = False
                                            Call myCShowMessage.ShowWarning("Kode absen " & dgvView.CurrentCell.Value & " tidak terdaftar!!")
                                            dgvView.CurrentCell.Value = initialValue
                                        End If
                                    Else
                                        isValueChanged = True
                                    End If
                                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                                    Cursor = Cursors.Default
                                    isPartialChanged = False
                                End If
                            Else
                                isValueChanged = False
                            End If
                        Else
                            If Not IsNothing(initialValue) Then
                                isPartialChanged = True
                                'dgvView.CurrentCell.Value = DBNull.Value
                                isPartialChanged = False
                                If (e.ColumnIndex = dgvView.Columns("ijin").Index) Then
                                    Call SetReadOnlyDgv(contentView, True)
                                End If
                                isValueChanged = True
                            Else
                                isValueChanged = False
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellValueChanged Error")
        End Try
    End Sub

    Private Sub dgvView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellValidated
        Try
            If (isValueChanged) And Not (isPartialChanged) Then
                If (contentView = "Presensi") Then
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                    Select Case dgvView.Columns(e.ColumnIndex).DataPropertyName
                        Case "lokasi", "ijin", "absen", "kodewaktushift", "keterangan"
                            If Not IsDBNull(dgvView.CurrentCell.Value) Then
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentCell.Value) & "',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                            Else
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "=Null,userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                            End If
                            If (dgvView.Columns(e.ColumnIndex).DataPropertyName = "ijin") Then
                                If Not IsDBNull(dgvView.CurrentRow.Cells("ijin").Value) Then
                                    If (dgvView.CurrentRow.Cells("ijin").Value <> "TM") Then
                                        'Kalau bukan tidak masuk, maka kolom absennya harus dihapus
                                        If Not IsDBNull(dgvView.CurrentRow.Cells("absen").Value) Then
                                            'Hanya dilakukan penghapusan kalau kolom absennya sebelumnya belum null
                                            isPartialChanged = True
                                            dgvView.CurrentRow.Cells("absen").Value = DBNull.Value
                                            isPartialChanged = False
                                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "absen=Null", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                        End If
                                    Else
                                        'Kalau ijinnya tidak masuk, maka kolom jam mulai, selesai, banyakjamkerja,dll harus di null kan
                                        isPartialChanged = True
                                        dgvView.CurrentRow.Cells("masuk").Value = DBNull.Value
                                        dgvView.CurrentRow.Cells("keluar").Value = DBNull.Value
                                        dgvView.CurrentRow.Cells("jamkerja").Value = DBNull.Value
                                        dgvView.CurrentRow.Cells("banyakjamkerja").Value = DBNull.Value
                                        dgvView.CurrentRow.Cells("jamkerjanyata").Value = DBNull.Value
                                        dgvView.CurrentRow.Cells("banyakjamkerjanyata").Value = DBNull.Value
                                        dgvView.CurrentRow.Cells("terlambat").Value = DBNull.Value
                                        dgvView.CurrentRow.Cells("pulangcepat").Value = DBNull.Value
                                        isPartialChanged = False
                                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "masuk=Null,keluar=Null,jamkerja=Null,banyakjamkerja=Null,jamkerjanyata=Null,banyakjamkerjanyata=Null,terlambat=Null,pulangcepat=Null", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                    End If
                                Else
                                    'Kalau kolom ijinnya dihapus, maka otomatis kolom absen juga harus dikosongkan
                                    If Not IsDBNull(dgvView.CurrentRow.Cells("absen").Value) Then
                                        'Hanya dilakukan penghapusan kalau kolom absennya sebelumnya belum null
                                        isPartialChanged = True
                                        dgvView.CurrentRow.Cells("absen").Value = Nothing
                                        isPartialChanged = False
                                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "absen=Null", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                    End If
                                End If
                            End If
                        Case "masuk", "keluar"
                            isPartialChanged = True
                            If Not IsDBNull(dgvView.CurrentCell.Value) Then
                                Dim terlambat As TimeSpan
                                Dim pulangCepat As TimeSpan
                                If (e.ColumnIndex = dgvView.Columns("masuk").Index) Then
                                    If Not IsDBNull(dgvView.CurrentRow.Cells("jadwalmasuk").Value) Then
                                        If (dgvView.CurrentRow.Cells("masuk").Value > dgvView.CurrentRow.Cells("jadwalmasuk").Value) Then
                                            terlambat = dgvView.CurrentRow.Cells("jadwalmasuk").Value - dgvView.CurrentRow.Cells("masuk").Value
                                            dgvView.CurrentRow.Cells("terlambat").Value = terlambat.Duration.ToString
                                        Else
                                            dgvView.CurrentRow.Cells("terlambat").Value = DBNull.Value
                                        End If
                                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value.ToString & "',terlambat=" & IIf(Not IsDBNull(dgvView.CurrentRow.Cells("terlambat").Value), "'" & dgvView.CurrentRow.Cells("terlambat").Value.ToString & "'", "Null") & ",isfpmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                    Else
                                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value.ToString & "',isfpmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                    End If
                                ElseIf (e.ColumnIndex = dgvView.Columns("keluar").Index) Then
                                    If Not IsDBNull(dgvView.CurrentRow.Cells("jadwalkeluar").Value) Then
                                        If (dgvView.CurrentRow.Cells("keluar").Value < dgvView.CurrentRow.Cells("jadwalkeluar").Value) Then
                                            pulangCepat = dgvView.CurrentRow.Cells("jadwalkeluar").Value - dgvView.CurrentRow.Cells("keluar").Value
                                            dgvView.CurrentRow.Cells("pulangcepat").Value = pulangCepat.Duration.ToString
                                        Else
                                            dgvView.CurrentRow.Cells("pulangcepat").Value = DBNull.Value
                                        End If
                                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value.ToString & "',pulangcepat=" & IIf(Not IsDBNull(dgvView.CurrentRow.Cells("pulangcepat").Value), "'" & dgvView.CurrentRow.Cells("pulangcepat").Value.ToString & "'", "Null") & ",isfpmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                    Else
                                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value.ToString & "',isfpmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                    End If
                                End If

                                '=================================== UNTUK SET JAM KERJA
                                If Not IsDBNull(dgvView.CurrentRow.Cells("masuk").Value) And Not IsDBNull(dgvView.CurrentRow.Cells("keluar").Value) Then
                                    'Tidak boleh ada yang null
                                    Dim jamKerja As String
                                    Dim jamKerjaNyata As String
                                    Dim banyakJamKerja As Double
                                    Dim banyakJamKerjaNyata As Double
                                    Dim arrGrup(2) As String

                                    arrGrup(0) = IIf(IsDBNull(dgvView.CurrentRow.Cells("departemen").Value), Nothing, dgvView.CurrentRow.Cells("departemen").Value)
                                    arrGrup(1) = IIf(IsDBNull(dgvView.CurrentRow.Cells("divisi").Value), Nothing, dgvView.CurrentRow.Cells("divisi").Value)
                                    arrGrup(2) = IIf(IsDBNull(dgvView.CurrentRow.Cells("bagian").Value), Nothing, dgvView.CurrentRow.Cells("bagian").Value)

                                    If (arrGrup(0) = "SECURITY" Or arrGrup(1) = "SECURITY" Or arrGrup(2) = "SECURITY") Then
                                        jamKerja = GetJamKerja(dgvView.CurrentRow.Cells("masuk").Value.ToString, dgvView.CurrentRow.Cells("keluar").Value.ToString, dgvView.CurrentRow.Cells("lokasi").Value, dgvView.CurrentRow.Cells("perusahaan").Value, WeekdayName(Weekday(dgvView.CurrentRow.Cells("tanggal").Value)), True)
                                        jamKerjaNyata = GetJamKerjaNyata(dgvView.CurrentRow.Cells("jadwalmasuk").Value.ToString, dgvView.CurrentRow.Cells("jadwalkeluar").Value.ToString, jamKerja, dgvView.CurrentRow.Cells("lokasi").Value, dgvView.CurrentRow.Cells("tanggal").Value, dgvView.CurrentRow.Cells("perusahaan").Value, dgvView.CurrentRow.Cells("kelompok").Value, dgvView.CurrentRow.Cells("katpenggajian").Value.ToString, True, dgvView.CurrentRow.Cells("terlambat").Value.ToString, dgvView.CurrentRow.Cells("pulangcepat").Value.ToString)
                                    Else
                                        jamKerja = GetJamKerja(dgvView.CurrentRow.Cells("masuk").Value.ToString, dgvView.CurrentRow.Cells("keluar").Value.ToString, dgvView.CurrentRow.Cells("lokasi").Value, dgvView.CurrentRow.Cells("perusahaan").Value, WeekdayName(Weekday(dgvView.CurrentRow.Cells("tanggal").Value)))
                                        jamKerjaNyata = GetJamKerjaNyata(dgvView.CurrentRow.Cells("jadwalmasuk").Value.ToString, dgvView.CurrentRow.Cells("jadwalkeluar").Value.ToString, jamKerja, dgvView.CurrentRow.Cells("lokasi").Value, dgvView.CurrentRow.Cells("tanggal").Value, dgvView.CurrentRow.Cells("perusahaan").Value, dgvView.CurrentRow.Cells("kelompok").Value, dgvView.CurrentRow.Cells("katpenggajian").Value.ToString, False, dgvView.CurrentRow.Cells("terlambat").Value.ToString, dgvView.CurrentRow.Cells("pulangcepat").Value.ToString)
                                    End If
                                    dgvView.CurrentRow.Cells("jamkerja").Value = IIf(IsNothing(jamKerja), DBNull.Value, jamKerja)
                                    dgvView.CurrentRow.Cells("jamkerjanyata").Value = IIf(IsNothing(jamKerjaNyata), DBNull.Value, jamKerjaNyata)
                                    banyakJamKerja = GetBanyakJamKerja(dgvView.CurrentRow.Cells("jamkerja").Value.ToString)
                                    banyakJamKerjaNyata = GetBanyakJamKerja(dgvView.CurrentRow.Cells("jamkerjanyata").Value.ToString, False)
                                    dgvView.CurrentRow.Cells("banyakjamkerja").Value = IIf(banyakJamKerja = 0, DBNull.Value, banyakJamKerja)
                                    dgvView.CurrentRow.Cells("banyakjamkerjanyata").Value = IIf(banyakJamKerjaNyata = 0, DBNull.Value, banyakJamKerjaNyata)
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "jamkerja=" & IIf(IsDBNull(dgvView.CurrentRow.Cells("jamkerja").Value), "Null", "'" & dgvView.CurrentRow.Cells("jamkerja").Value.ToString & "'") & ",banyakjamkerja=" & IIf(IsDBNull(dgvView.CurrentRow.Cells("banyakjamkerja").Value), "Null", dgvView.CurrentRow.Cells("banyakjamkerja").Value) & ",jamkerjanyata=" & IIf(IsDBNull(dgvView.CurrentRow.Cells("jamkerjanyata").Value), "Null", "'" & dgvView.CurrentRow.Cells("jamkerjanyata").Value.ToString & "'") & ",banyakjamkerjanyata=" & IIf(IsDBNull(dgvView.CurrentRow.Cells("banyakjamkerjanyata").Value), "Null", dgvView.CurrentRow.Cells("banyakjamkerjanyata").Value), "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                End If
                                '===================================

                                '================================= UNTUK SET SHIFT NYA, SHIFT 1 < 23:00, SHIFT 2 = 23:00, SHIFT 3 > 23:00
                                dgvView.CurrentRow.Cells("shift").Value = GetShift(dgvView.CurrentRow.Cells("masuk").Value.ToString, dgvView.CurrentRow.Cells("keluar").Value.ToString, IIf(IsDBNull(dgvView.CurrentRow.Cells("banyakjamkerja").Value), 0, dgvView.CurrentRow.Cells("banyakjamkerja").Value), dgvView.CurrentRow.Cells("jadwalmasuk").Value.ToString, dgvView.CurrentRow.Cells("jadwalkeluar").Value.ToString)
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "shift='" & dgvView.CurrentRow.Cells("shift").Value & "'", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                '==================================
                            Else
                                dgvView.CurrentRow.Cells("jamkerja").Value = DBNull.Value
                                dgvView.CurrentRow.Cells("banyakjamkerja").Value = DBNull.Value
                                dgvView.CurrentRow.Cells("jamkerjanyata").Value = DBNull.Value
                                dgvView.CurrentRow.Cells("banyakjamkerjanyata").Value = DBNull.Value
                                If (e.ColumnIndex = dgvView.Columns("masuk").Index) Then
                                    dgvView.CurrentRow.Cells("terlambat").Value = DBNull.Value
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "=Null,terlambat=Null,jamkerja=Null,banyakjamkerja=Null,jamkerjanyata=Null,banyakjamkerjanyata=Null,isfpmanual='True'", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                ElseIf (e.ColumnIndex = dgvView.Columns("keluar").Index) Then
                                    dgvView.CurrentRow.Cells("pulangcepat").Value = DBNull.Value
                                    dgvView.CurrentRow.Cells("shift").Value = 1
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "=Null,pulangcepat=Null,shift=1,jamkerja=Null,banyakjamkerja=Null,jamkerjanyata=Null,banyakjamkerjanyata=Null,isfpmanual='True'", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                End If
                            End If
                            isPartialChanged = False
                        Case "spkmulai", "spkselesai"
                            If Not IsDBNull(dgvView.CurrentCell.Value) Then
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value & "',isspkmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                            Else
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "=Null,isspkmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                            End If
                        Case "terlambat", "pulangcepat"
                            If Not IsDBNull(dgvView.CurrentCell.Value) Then
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value.ToString & "',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                            Else
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "=Null,userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                            End If
                        Case "jamkerjanyata"
                            isPartialChanged = True
                            If Not IsDBNull(dgvView.CurrentCell.Value) Then
                                dgvView.CurrentRow.Cells("banyakjamkerjanyata").Value = IIf(GetBanyakJamKerja(dgvView.CurrentRow.Cells("jamkerjanyata").Value.ToString, False) = 0, DBNull.Value, GetBanyakJamKerja(dgvView.CurrentRow.Cells("jamkerjanyata").Value.ToString, False))
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value.ToString & "',banyakjamkerjanyata=" & IIf(IsDBNull(dgvView.CurrentRow.Cells("banyakjamkerjanyata").Value), "Null", dgvView.CurrentRow.Cells("banyakjamkerjanyata").Value) & ",isjamkerjamanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                            Else
                                dgvView.CurrentRow.Cells("banyakjamkerjanyata").Value = DBNull.Value
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "=Null,banyakjamkerjanyata=Null,isjamkerjamanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                            End If
                            isPartialChanged = False
                        Case "jamlembur"
                            isPartialChanged = True
                            If Not IsDBNull(dgvView.CurrentCell.Value) Then
                                If Not IsDBNull(dgvView.CurrentRow.Cells("mulailembur").Value) Then
                                    Dim splselesai As Date
                                    splselesai = dgvView.CurrentRow.Cells("mulailembur").Value + dgvView.CurrentRow.Cells("jamlembur").Value
                                    isPartialChanged = True
                                    dgvView.CurrentRow.Cells("selesailembur").Value = Format(splselesai, "dd-MMM-yyyy HH:mm")
                                    isPartialChanged = False
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value.ToString & "',selesailembur='" & dgvView.CurrentRow.Cells("selesailembur").Value.ToString & "',islemburmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                Else
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value.ToString & "',islemburmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                End If
                            Else
                                isPartialChanged = True
                                dgvView.CurrentRow.Cells("mulailembur").Value = DBNull.Value
                                dgvView.CurrentRow.Cells("selesailembur").Value = DBNull.Value
                                isPartialChanged = False
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "=Null,mulailembur=Null,selesailembur=Null,islemburmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                            End If
                            isPartialChanged = False
                        Case "mulailembur", "selesailembur"
                            Dim strJamLembur As TimeSpan
                            isPartialChanged = True
                            If Not IsDBNull(dgvView.CurrentCell.Value) Then
                                If Not IsDBNull(dgvView.CurrentRow.Cells("mulailembur").Value) And Not IsDBNull(dgvView.CurrentRow.Cells("selesailembur").Value) Then
                                    'Kalau keduanya sudah ada isinya, maka jam lemburnya bisa didapatkan
                                    If (dgvView.CurrentRow.Cells("mulailembur").Value > dgvView.CurrentRow.Cells("selesailembur").Value) Then
                                        'SEHARUSNYA GAK MUNGKIN MASUK SINI!!
                                        'Karena sudah dicegat di event value changed
                                        Call myCShowMessage.ShowWarning("Waktu selesai lembur tidak boleh lebih kecil daripada waktu mulai lembur!" & ControlChars.NewLine & "Waktu lembur dikembalikan semula!")
                                        isPartialChanged = True
                                        dgvView.CurrentCell.Value = initialValue
                                        isPartialChanged = False
                                    End If
                                    strJamLembur = dgvView.CurrentRow.Cells("selesailembur").Value - dgvView.CurrentRow.Cells("mulailembur").Value
                                    isPartialChanged = True
                                    dgvView.CurrentRow.Cells("jamlembur").Value = strJamLembur.ToString
                                    isPartialChanged = False
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value.ToString & "',jamlembur='" & dgvView.CurrentRow.Cells("jamlembur").Value.ToString & "',islemburmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                Else
                                    'Kalau salah 1 masih ada yang null, maka jam lemburnya tidak bisa dihitung
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value.ToString & "',jamlembur=Null,islemburmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                                End If
                            Else
                                isPartialChanged = True
                                dgvView.CurrentRow.Cells("jamlembur").Value = DBNull.Value
                                'dgvView.CurrentRow.Cells("mulailembur").Value = DBNull.Value
                                'dgvView.CurrentRow.Cells("selesailembur").Value = DBNull.Value
                                isPartialChanged = False
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "jamlembur=Null," & dgvView.Columns(e.ColumnIndex).DataPropertyName & "=Null,islemburmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                            End If
                            isPartialChanged = False
                        Case "shift", "cekfp", "cekspk", "ceklembur"
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName & "='" & dgvView.CurrentCell.Value & "',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'")
                    End Select
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellValidated Error")
        Finally
            If (isValueChanged And Not isPartialChanged) Then
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                Me.Cursor = Cursors.Default
                isValueChanged = False
            End If
        End Try
    End Sub

    Private Sub dgvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellContentClick
        Try
            If (contentView = "Presensi") Then
                If (dgvView.RowCount > 0) Then
                    If (e.RowIndex = -1) Then
                        Exit Sub
                    End If

                    If (e.ColumnIndex = dgvView.Columns("delete").Index) Then
                        Me.Cursor = Cursors.WaitCursor
                        Call myCDBConnection.OpenConn(CONN_.dbMain)

                        Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data presensi karyawan " & dgvView.CurrentRow.Cells("nama").Value & " untuk tanggal " & dgvView.CurrentRow.Cells("tanggal").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                        If (isConfirm = DialogResult.Yes) Then
                            Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kdr").Value) & "'", CONN_.dbType)
                            Call myCShowMessage.ShowDeletedMsg("Data presensi karyawan " & dgvView.CurrentRow.Cells("nama").Value & " untuk tanggal " & dgvView.CurrentRow.Cells("tanggal").Value)
                            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, contentView, True)
                        Else
                            Call myCShowMessage.ShowInfo("Penghapusan data presensi karyawan " & dgvView.CurrentRow.Cells("nama").Value & " untuk tanggal " & dgvView.CurrentRow.Cells("tanggal").Value & " dibatalkan oleh user")
                        End If
                    ElseIf (e.ColumnIndex = dgvView.Columns("attachment").Index) Then
                        Dim frmAttachmentKaryawan As New FormAttachmentKaryawan.FormAttachmentKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, dgvView.CurrentRow.Cells("idk").Value, dgvView.CurrentRow.Cells("nama").Value)
                        Call myCFormManipulation.GoToForm(Me.MdiParent, frmAttachmentKaryawan)
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellContentClick Error")
        Finally
            If (contentView = "Presensi") Then
                Me.Cursor = Cursors.Default
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
        End Try
    End Sub

    Private Sub btnProsesCepat_Click(sender As Object, e As EventArgs) Handles btnProsesCepat.Click
        Try
            If (contentView = "Presensi") Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim hitungCek As UShort
                Dim updateSukses As Byte = 0
                Dim jamMasuk As String = Nothing
                Dim jamKeluar As String = Nothing
                stSQL = "SELECT count(*) FROM " & tableName(0) & " WHERE cekfp='True';"
                hitungCek = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                If hitungCek > 0 Then
                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau memproses cepat untuk mengisi jam masuk dan jam keluar " & hitungCek & " records data presensi yang dicentang?" & ControlChars.NewLine & "jam masuk dan pulang yang lama akan ditumpuk dengan jam yang ditentukan di sini" & ControlChars.NewLine & "APAKAH MAU MEMPROSES CEPAT?", "PROSES INI TIDAK BISA DIKEMBALIKAN!!")
                    If (isConfirm = DialogResult.Yes) Then
                        'YES
                        Dim jamKerja As String
                        Dim jamKerjaNyata As String
                        Dim banyakJamKerja As Double
                        Dim banyakJamKerjaNyata As Double
                        Dim shift As Byte
                        Dim tmpDataPresensi As New DataTable
                        Dim lokasi As String
                        Dim hari As String
                        Dim arrGrup(2) As String
                        Dim jadwalMasuk As String
                        Dim jadwalKeluar As String
                        Dim terlambat As String
                        Dim pulangCepat As String

                        stSQL = "SELECT tanggal,jadwalmasuk,jadwalkeluar,masuk,keluar,lokasi,perusahaan,kelompok,katpenggajian,departemen,divisi,bagian,kdr,terlambat,pulangcepat FROM " & tableName(0) & " WHERE cekfp='True' and (ijin<>'TM' or ijin is null) and absen is null;"
                        tmpDataPresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_tmpDataPresensi")
                        For i As Integer = 0 To tmpDataPresensi.Rows.Count - 1
                            If (rbJamMasuk.Checked) Then
                                jamMasuk = Format(dtpJamMasuk.Value, "HH:mm")
                                If Not (IsDBNull(tmpDataPresensi.Rows(i).Item("keluar"))) Then
                                    jamKeluar = tmpDataPresensi.Rows(i).Item("keluar").ToString
                                Else
                                    jamKeluar = Format(dtpJamMasuk.Value, "HH:mm")
                                End If
                            ElseIf (rbJamKeluar.Checked) Then
                                If Not (IsDBNull(tmpDataPresensi.Rows(i).Item("masuk"))) Then
                                    jamMasuk = tmpDataPresensi.Rows(i).Item("masuk").ToString
                                Else
                                    jamMasuk = Format(dtpJamKeluar.Value, "HH:mm")
                                End If
                                jamKeluar = Format(dtpJamKeluar.Value, "HH:mm")
                            ElseIf (rbJamMasukKeluar.Checked) Then
                                jamMasuk = Format(dtpJamMasuk.Value, "HH:mm")
                                jamKeluar = Format(dtpJamKeluar.Value, "HH:mm")
                            End If

                            lokasi = tmpDataPresensi.Rows(i).Item("lokasi")
                            hari = WeekdayName(Weekday(tmpDataPresensi.Rows(i).Item("tanggal")))
                            jadwalMasuk = IIf(IsDBNull(tmpDataPresensi.Rows(i).Item("jadwalmasuk")), Nothing, tmpDataPresensi.Rows(i).Item("jadwalmasuk").ToString)
                            jadwalKeluar = IIf(IsDBNull(tmpDataPresensi.Rows(i).Item("jadwalkeluar")), Nothing, tmpDataPresensi.Rows(i).Item("jadwalkeluar").ToString)
                            terlambat = IIf(IsDBNull(tmpDataPresensi.Rows(i).Item("terlambat")), Nothing, tmpDataPresensi.Rows(i).Item("terlambat").ToString)
                            pulangCepat = IIf(IsDBNull(tmpDataPresensi.Rows(i).Item("pulangcepat")), Nothing, tmpDataPresensi.Rows(i).Item("pulangcepat").ToString)

                            If IsDBNull(tmpDataPresensi.Rows(i).Item("departemen")) Then
                                arrGrup(0) = Nothing
                            Else
                                arrGrup(0) = tmpDataPresensi.Rows(i).Item("departemen")
                            End If
                            If IsDBNull(tmpDataPresensi.Rows(i).Item("divisi")) Then
                                arrGrup(1) = Nothing
                            Else
                                arrGrup(1) = tmpDataPresensi.Rows(i).Item("divisi")
                            End If
                            If IsDBNull(tmpDataPresensi.Rows(i).Item("bagian")) Then
                                arrGrup(2) = Nothing
                            Else
                                arrGrup(2) = tmpDataPresensi.Rows(i).Item("bagian")
                            End If

                            If (arrGrup(0) = "SECURITY" Or arrGrup(1) = "SECURITY" Or arrGrup(2) = "SECURITY") Then
                                jamKerja = GetJamKerja(jamMasuk, jamKeluar, lokasi, tmpDataPresensi.Rows(i).Item("perusahaan"), hari, True)
                                jamKerjaNyata = GetJamKerjaNyata(jadwalMasuk, jadwalKeluar, jamKerja, tmpDataPresensi.Rows(i).Item("lokasi"), tmpDataPresensi.Rows(i).Item("tanggal"), tmpDataPresensi.Rows(i).Item("perusahaan"), tmpDataPresensi.Rows(i).Item("kelompok"), tmpDataPresensi.Rows(i).Item("katpenggajian"), True, terlambat, pulangCepat)
                            Else
                                jamKerja = GetJamKerja(jamMasuk, jamKeluar, lokasi, tmpDataPresensi.Rows(i).Item("perusahaan"), hari)
                                jamKerjaNyata = GetJamKerjaNyata(jadwalMasuk, jadwalKeluar, jamKerja, tmpDataPresensi.Rows(i).Item("lokasi"), tmpDataPresensi.Rows(i).Item("tanggal"), tmpDataPresensi.Rows(i).Item("perusahaan"), tmpDataPresensi.Rows(i).Item("kelompok"), tmpDataPresensi.Rows(i).Item("katpenggajian"), False, terlambat, pulangCepat)
                            End If
                            banyakJamKerja = GetBanyakJamKerja(jamKerja)
                            banyakJamKerjaNyata = GetBanyakJamKerja(jamKerjaNyata, False)
                            shift = GetShift(jamMasuk, jamKeluar, banyakJamKerjaNyata, jadwalMasuk, jadwalKeluar)

                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "masuk='" & jamMasuk & "', keluar='" & jamKeluar & "',jamkerja=" & IIf(IsNothing(jamKerja), "Null", "'" & jamKerja & "'") & ",banyakjamkerja=" & IIf(banyakJamKerja = 0, "Null", banyakJamKerja) & ",jamkerjanyata=" & IIf(IsNothing(jamKerjaNyata), "Null", "'" & jamKerjaNyata & "'") & ",banyakjamkerjanyata=" & IIf(banyakJamKerjaNyata = 0, "Null", banyakJamKerjaNyata) & ",shift=" & shift & ",cekfp='False',isfpmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "cekfp='True' and kdr='" & myCStringManipulation.SafeSqlLiteral(tmpDataPresensi.Rows(i).Item("kdr")) & "'")

                            updateSukses += 1
                            If (i Mod 100 = 0) Then
                                GC.Collect()
                            End If
                        Next
                    End If
                End If

                stSQL = "SELECT count(*) FROM " & tableName(0) & " WHERE cekspk='True' and (ijin<>'TM' or ijin is null) and absen is null;"
                hitungCek = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                If hitungCek > 0 Then
                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau memproses cepat untuk mengisi SPK masuk dan SPK keluar " & hitungCek & " records data presensi yang dicentang?" & ControlChars.NewLine & "spk mulai dan spk selesai yang lama akan ditumpuk dengan jam yang ditentukan di sini" & ControlChars.NewLine & "APAKAH MAU MEMPROSES CEPAT?", "PROSES INI TIDAK BISA DIKEMBALIKAN!!")
                    If (isConfirm = DialogResult.Yes) Then
                        'YES
                        Dim tmpDataPresensi As New DataTable
                        stSQL = "SELECT tanggal,kdr FROM " & tableName(0) & " WHERE cekspk='True';"
                        tmpDataPresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_tmpDataPresensi")

                        For i As Integer = 0 To tmpDataPresensi.Rows.Count - 1
                            jamMasuk = Format(tmpDataPresensi.Rows(i).Item("tanggal"), "dd-MMM-yyyy") & " " & Format(dtpJamMasuk.Value, "HH:mm")
                            If (dtpJamKeluar.Value >= dtpJamMasuk.Value) Then
                                'Kalau jam keluarnya lebih besar dari jam masuknya, berarti pulangnya masih di hari yang sama
                                jamKeluar = Format(tmpDataPresensi.Rows(i).Item("tanggal"), "dd-MMM-yyyy") & " " & Format(dtpJamKeluar.Value, "HH:mm")
                            Else
                                'Jika jam keluar lebih kecil dari jam masuknya, berarti pulangnya di hari berikutnya
                                jamKeluar = Format(CDate(tmpDataPresensi.Rows(i).Item("tanggal")).AddDays(1), "dd-MMM-yyyy") & " " & Format(dtpJamKeluar.Value, "HH:mm")
                            End If
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "spkmulai='" & jamMasuk & "', spkselesai='" & jamKeluar & "',cekspk='False',isspkmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "cekspk='True' and kdr='" & myCStringManipulation.SafeSqlLiteral(tmpDataPresensi.Rows(i).Item("kdr")) & "'")
                            updateSukses += 1

                            If (i Mod 100 = 0) Then
                                GC.Collect()
                            End If
                        Next
                    End If
                End If

                stSQL = "SELECT count(*) FROM " & tableName(0) & " WHERE ceklembur='True' and (ijin<>'TM' or ijin is null) and absen is null;"
                hitungCek = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                If hitungCek > 0 Then
                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau memproses cepat untuk mengisi mulai lembur dan selesai lembur " & hitungCek & " records data presensi yang dicentang?" & ControlChars.NewLine & "jam lembur, mulai lembur dan selesai lembur yang lama akan ditumpuk dengan jam yang ditentukan di sini" & ControlChars.NewLine & "APAKAH MAU MEMPROSES CEPAT?", "PROSES INI TIDAK BISA DIKEMBALIKAN!!")
                    If (isConfirm = DialogResult.Yes) Then
                        'YES
                        Dim tmpDataPresensi As New DataTable
                        Dim jamlembur As String
                        stSQL = "SELECT tanggal,kdr FROM " & tableName(0) & " WHERE ceklembur='True';"
                        tmpDataPresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_tmpDataPresensi")

                        For i As Integer = 0 To tmpDataPresensi.Rows.Count - 1
                            jamMasuk = Format(tmpDataPresensi.Rows(i).Item("tanggal"), "dd-MMM-yyyy") & " " & Format(dtpJamMasuk.Value, "HH:mm")
                            If (dtpJamKeluar.Value >= dtpJamMasuk.Value) Then
                                'Kalau jam keluarnya lebih besar dari jam masuknya, berarti pulangnya masih di hari yang sama
                                jamKeluar = Format(tmpDataPresensi.Rows(i).Item("tanggal"), "dd-MMM-yyyy") & " " & Format(dtpJamKeluar.Value, "HH:mm")
                            Else
                                'Jika jam keluar lebih kecil dari jam masuknya, berarti pulangnya di hari berikutnya
                                jamKeluar = Format(CDate(tmpDataPresensi.Rows(i).Item("tanggal")).AddDays(1), "dd-MMM-yyyy") & " " & Format(dtpJamKeluar.Value, "HH:mm")
                            End If
                            jamlembur = (TimeSpan.Parse(Format(dtpJamKeluar.Value, "HH:mm")).Subtract(TimeSpan.Parse(Format(dtpJamMasuk.Value, "HH:mm")))).Duration.ToString
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "mulailembur='" & jamMasuk & "', selesailembur='" & jamKeluar & "',jamlembur='" & jamlembur & "',ceklembur='False',islemburmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "ceklembur='True' and kdr='" & myCStringManipulation.SafeSqlLiteral(tmpDataPresensi.Rows(i).Item("kdr")) & "'")
                            updateSukses += 1

                            If (i Mod 100 = 0) Then
                                GC.Collect()
                            End If
                        Next
                    End If
                End If

                If (updateSukses > 0) Then
                    Call btnTampilkan_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesCepat_Click Error")
        Finally
            If (contentView = "Presensi") Then
                Me.Cursor = Cursors.Default
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
        End Try
    End Sub

    Private Sub btnNullkanData_Click(sender As Object, e As EventArgs) Handles btnNullkanData.Click
        Try
            If (contentView = "Presensi") Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim hitungCek As UShort
                Dim updateSukses As Byte = 0
                If (rbKosongkanFP.Checked) Then
                    stSQL = "SELECT count(*) FROM " & tableName(0) & " WHERE cekfp='True';"
                    hitungCek = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                    If hitungCek > 0 Then
                        Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau memproses cepat untuk mengosongkan jam masuk dan jam keluar " & hitungCek & " records data presensi yang dicentang?" & ControlChars.NewLine & "jam masuk dan pulang yang lama akan ditumpuk dengan jam yang ditentukan di sini" & ControlChars.NewLine & "APAKAH MAU MEMPROSES CEPAT?", "PROSES INI TIDAK BISA DIKEMBALIKAN!!")
                        If (isConfirm = DialogResult.Yes) Then
                            'YES
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "masuk=Null,keluar=Null,jamkerja=Null,banyakjamkerja=Null,jamkerjanyata=Null,banyakjamkerjanyata=Null,terlambat=Null,pulangcepat=Null,shift=1,cekfp='False',isfpmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "cekfp='True'")
                            updateSukses = 1
                        End If
                    End If
                ElseIf (rbKosongkanLembur.Checked) Then
                    stSQL = "SELECT count(*) FROM " & tableName(0) & " WHERE ceklembur='True';"
                    hitungCek = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                    If hitungCek > 0 Then
                        Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau memproses cepat untuk mengosongkan lemburan " & hitungCek & " records data presensi yang dicentang?" & ControlChars.NewLine & "jam masuk dan pulang yang lama akan ditumpuk dengan jam yang ditentukan di sini" & ControlChars.NewLine & "APAKAH MAU MEMPROSES CEPAT?", "PROSES INI TIDAK BISA DIKEMBALIKAN!!")
                        If (isConfirm = DialogResult.Yes) Then
                            'YES
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "jamlembur=Null,mulailembur=Null,selesailembur=Null,ceklembur='False',islemburmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "ceklembur='True'")
                            updateSukses = 1
                        End If
                    End If
                ElseIf (rbKosongkanSPK.Checked) Then
                    stSQL = "SELECT count(*) FROM " & tableName(0) & " WHERE cekspk='True';"
                    hitungCek = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                    If hitungCek > 0 Then
                        Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau memproses cepat untuk mengosongkan SPK " & hitungCek & " records data presensi yang dicentang?" & ControlChars.NewLine & "jam masuk dan pulang yang lama akan ditumpuk dengan jam yang ditentukan di sini" & ControlChars.NewLine & "APAKAH MAU MEMPROSES CEPAT?", "PROSES INI TIDAK BISA DIKEMBALIKAN!!")
                        If (isConfirm = DialogResult.Yes) Then
                            'YES
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "spkmulai=Null,spkselesai=Null,cekspk='False',isspkmanual='True',userid='" & USER_.username & "',userpc='" & myCManagementSystem.GetComputerName & "',updated_at=clock_timestamp()", "cekspk='True'")
                            updateSukses = 1
                        End If
                    End If
                End If

                If (updateSukses > 0) Then
                    Call btnTampilkan_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnNullkanData_Click Error")
        Finally
            If (contentView = "Presensi") Then
                Me.Cursor = Cursors.Default
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboMohonIjin.Validated, cboAbsen.Validated, cboKelompok.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub btnSesuaikanJamMasukKeluarCellTerpilih_Click(sender As Object, e As EventArgs) Handles btnSesuaikanJamMasukKeluarCellTerpilih.Click
        Try
            If (contentView = "Presensi") Then
                Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                'Dim mySelectedCells As List(Of Integer) = New List(Of Integer)
                Dim arrGrup(2) As String
                Dim jamKerja As String
                Dim jamKerjaNyata As String
                Dim cekIjin As String
                Dim banyakJamKerja As Double
                Dim banyakJamKerjaNyata As Double

                For Each selectedCells As DataGridViewCell In dgvView.SelectedCells
                    Dim rowIndex As Integer = selectedCells.RowIndex
                    Dim colIndex As Integer = selectedCells.ColumnIndex
                    If (colIndex = dgvView.Columns("masuk").Index Or colIndex = dgvView.Columns("keluar").Index) Then
                        If Not IsDBNull(dgvView.Rows(rowIndex).Cells("ijin").Value) Then
                            If (dgvView.Rows(rowIndex).Cells("ijin").Value = "TM") Then
                                cekIjin = "TM"
                            Else
                                cekIjin = "-"
                            End If
                        Else
                            cekIjin = "-"
                        End If

                        If (cekIjin <> "TM") And IsDBNull(dgvView.Rows(rowIndex).Cells("absen").Value) Then
                            'Hanya kalau yang di blok itu kolom masuk atau kolom keluar
                            'mySelectedCells.Add(rowIndex)
                            isPartialChanged = True
                            If Not IsDBNull(dgvView.Rows(rowIndex).Cells("jadwalmasuk").Value) And Not IsDBNull(dgvView.Rows(rowIndex).Cells("jadwalkeluar").Value) Then
                                If (colIndex = dgvView.Columns("masuk").Index) Then
                                    dgvView.Rows(rowIndex).Cells("masuk").Value = dgvView.Rows(rowIndex).Cells("jadwalmasuk").Value
                                    'If IsDBNull(dgvView.Rows(rowIndex).Cells("keluar").Value) Then
                                    '    dgvView.Rows(rowIndex).Cells("keluar").Value = dgvView.Rows(rowIndex).Cells("jadwalkeluar").Value
                                    'End If
                                    dgvView.Rows(rowIndex).Cells("terlambat").Value = DBNull.Value
                                ElseIf (colIndex = dgvView.Columns("keluar").Index) Then
                                    dgvView.Rows(rowIndex).Cells("keluar").Value = dgvView.Rows(rowIndex).Cells("jadwalkeluar").Value
                                    'If IsDBNull(dgvView.Rows(rowIndex).Cells("masuk").Value) Then
                                    '    dgvView.Rows(rowIndex).Cells("masuk").Value = dgvView.Rows(rowIndex).Cells("jadwalmasuk").Value
                                    'End If
                                    dgvView.Rows(rowIndex).Cells("pulangcepat").Value = DBNull.Value
                                End If
                                If Not IsDBNull(dgvView.Rows(rowIndex).Cells("masuk").Value) And Not IsDBNull(dgvView.Rows(rowIndex).Cells("keluar").Value) Then
                                    If IsDBNull(dgvView.Rows(rowIndex).Cells("departemen").Value) Then
                                        arrGrup(0) = Nothing
                                    Else
                                        arrGrup(0) = dgvView.Rows(rowIndex).Cells("departemen").Value
                                    End If
                                    If IsDBNull(dgvView.Rows(rowIndex).Cells("divisi").Value) Then
                                        arrGrup(1) = Nothing
                                    Else
                                        arrGrup(1) = dgvView.Rows(rowIndex).Cells("divisi").Value
                                    End If
                                    If IsDBNull(dgvView.Rows(rowIndex).Cells("bagian").Value) Then
                                        arrGrup(2) = Nothing
                                    Else
                                        arrGrup(2) = dgvView.Rows(rowIndex).Cells("bagian").Value
                                    End If

                                    If (arrGrup(0) = "SECURITY" Or arrGrup(1) = "SECURITY" Or arrGrup(2) = "SECURITY") Then
                                        jamKerja = GetJamKerja(dgvView.Rows(rowIndex).Cells("masuk").Value.ToString, dgvView.Rows(rowIndex).Cells("keluar").Value.ToString, dgvView.CurrentRow.Cells("lokasi").Value, dgvView.Rows(rowIndex).Cells("perusahaan").Value, WeekdayName(Weekday(Date.Parse(dgvView.CurrentRow.Cells("tanggal").Value))), True)
                                        jamKerjaNyata = GetJamKerjaNyata(dgvView.Rows(rowIndex).Cells("jadwalmasuk").Value.ToString, dgvView.Rows(rowIndex).Cells("jadwalkeluar").Value.ToString, jamKerja, dgvView.Rows(rowIndex).Cells("lokasi").Value, dgvView.Rows(rowIndex).Cells("tanggal").Value, dgvView.Rows(rowIndex).Cells("perusahaan").Value, dgvView.Rows(rowIndex).Cells("kelompok").Value, dgvView.Rows(rowIndex).Cells("katpenggajian").Value.ToString, True, dgvView.Rows(rowIndex).Cells("terlambat").Value.ToString, dgvView.Rows(rowIndex).Cells("pulangcepat").Value.ToString)
                                    Else
                                        jamKerja = GetJamKerja(dgvView.Rows(rowIndex).Cells("masuk").Value.ToString, dgvView.Rows(rowIndex).Cells("keluar").Value.ToString, dgvView.CurrentRow.Cells("lokasi").Value, dgvView.Rows(rowIndex).Cells("perusahaan").Value, WeekdayName(Weekday(Date.Parse(dgvView.CurrentRow.Cells("tanggal").Value))))
                                        jamKerjaNyata = GetJamKerjaNyata(dgvView.Rows(rowIndex).Cells("jadwalmasuk").Value.ToString, dgvView.Rows(rowIndex).Cells("jadwalkeluar").Value.ToString, jamKerja, dgvView.Rows(rowIndex).Cells("lokasi").Value, dgvView.Rows(rowIndex).Cells("tanggal").Value, dgvView.Rows(rowIndex).Cells("perusahaan").Value, dgvView.Rows(rowIndex).Cells("kelompok").Value, dgvView.Rows(rowIndex).Cells("katpenggajian").Value.ToString, False, dgvView.Rows(rowIndex).Cells("terlambat").Value.ToString, dgvView.Rows(rowIndex).Cells("pulangcepat").Value.ToString)
                                    End If
                                    dgvView.Rows(rowIndex).Cells("jamkerja").Value = IIf(IsNothing(jamKerja), DBNull.Value, jamKerja)
                                    dgvView.Rows(rowIndex).Cells("jamkerjanyata").Value = IIf(IsNothing(jamKerjaNyata), DBNull.Value, jamKerjaNyata)
                                    banyakJamKerja = GetBanyakJamKerja(dgvView.Rows(rowIndex).Cells("jamkerja").Value.ToString)
                                    banyakJamKerjaNyata = GetBanyakJamKerja(dgvView.CurrentRow.Cells("jamkerjanyata").Value.ToString, False)
                                    dgvView.Rows(rowIndex).Cells("banyakjamkerja").Value = IIf(banyakJamKerja = 0, DBNull.Value, banyakJamKerja)
                                    dgvView.Rows(rowIndex).Cells("banyakjamkerjanyata").Value = IIf(banyakJamKerjaNyata = 0, DBNull.Value, banyakJamKerjaNyata)

                                    dgvView.Rows(rowIndex).Cells("shift").Value = GetShift(dgvView.Rows(rowIndex).Cells("masuk").Value.ToString, dgvView.Rows(rowIndex).Cells("keluar").Value.ToString, dgvView.Rows(rowIndex).Cells("banyakjamkerjanyata").Value, dgvView.Rows(rowIndex).Cells("jadwalmasuk").Value.ToString, dgvView.Rows(rowIndex).Cells("jadwalkeluar").Value.ToString)
                                End If
                            Else
                                If (colIndex = dgvView.Columns("masuk").Index) Then
                                    dgvView.Rows(rowIndex).Cells("masuk").Value = DBNull.Value
                                    dgvView.Rows(rowIndex).Cells("terlambat").Value = DBNull.Value
                                ElseIf (colIndex = dgvView.Columns("keluar").Index) Then
                                    dgvView.Rows(rowIndex).Cells("keluar").Value = DBNull.Value
                                    dgvView.Rows(rowIndex).Cells("pulangcepat").Value = DBNull.Value
                                    dgvView.Rows(rowIndex).Cells("shift").Value = 1
                                End If
                                dgvView.Rows(rowIndex).Cells("jamkerja").Value = DBNull.Value
                                dgvView.Rows(rowIndex).Cells("banyakjamkerja").Value = DBNull.Value
                                dgvView.Rows(rowIndex).Cells("jamkerjanyata").Value = DBNull.Value
                                dgvView.Rows(rowIndex).Cells("banyakjamkerjanyata").Value = DBNull.Value
                            End If
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "masuk=" & IIf(IsDBNull(dgvView.Rows(rowIndex).Cells("masuk").Value), "Null", "'" & dgvView.Rows(rowIndex).Cells("masuk").Value.ToString & "'") & ",keluar=" & IIf(IsDBNull(dgvView.Rows(rowIndex).Cells("keluar").Value), "Null", "'" & dgvView.Rows(rowIndex).Cells("keluar").Value.ToString & "'") & ",shift=" & dgvView.Rows(rowIndex).Cells("shift").Value & ",jamkerja=" & IIf(IsDBNull(dgvView.Rows(rowIndex).Cells("jamkerja").Value), "Null", "'" & dgvView.Rows(rowIndex).Cells("jamkerja").Value.ToString & "'") & ",banyakjamkerja=" & IIf(IsDBNull(dgvView.Rows(rowIndex).Cells("banyakjamkerja").Value), "Null", dgvView.Rows(rowIndex).Cells("banyakjamkerja").Value) & ",jamkerjanyata=" & IIf(IsDBNull(dgvView.Rows(rowIndex).Cells("jamkerjanyata").Value), "Null", "'" & dgvView.Rows(rowIndex).Cells("jamkerjanyata").Value.ToString & "'") & ",banyakjamkerjanyata=" & IIf(IsDBNull(dgvView.Rows(rowIndex).Cells("banyakjamkerjanyata").Value), "Null", dgvView.Rows(rowIndex).Cells("banyakjamkerjanyata").Value) & ",terlambat=" & IIf(IsDBNull(dgvView.Rows(rowIndex).Cells("terlambat").Value), "Null", "'" & dgvView.Rows(rowIndex).Cells("terlambat").Value.ToString & "'") & ",pulangcepat=" & IIf(IsDBNull(dgvView.Rows(rowIndex).Cells("pulangcepat").Value), "Null", "'" & dgvView.Rows(rowIndex).Cells("pulangcepat").Value.ToString & "'") & ",isfpmanual='True'", "kdr='" & dgvView.Rows(rowIndex).Cells("kdr").Value & "'")
                            isPartialChanged = False
                            isValueChanged = False
                        Else
                            Call myCShowMessage.ShowWarning("Karyawan " & dgvView.Rows(rowIndex).Cells("nama").Value & " di tanggal " & dgvView.Rows(rowIndex).Cells("tanggal").Value & " absen!")
                        End If
                    End If
                Next selectedCells
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSesuaikanJamMasukKeluarCellTerpilih_Click Error")
        Finally
            If (contentView = "Presensi") Then
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                Cursor = Cursors.Default
            End If
        End Try
    End Sub

    Private Sub rbCekKosong_CheckedChanged(sender As Object, e As EventArgs) Handles rbKosongJamMasuk.CheckedChanged, rbKosongJamMasukPulang.CheckedChanged, rbKosongJamPulang.CheckedChanged
        Try
            If (isDataPrepared) Then
                If (contentView = "Presensi") Then
                    If (cbTampilkanYangKosong.Checked) Then
                        If (contentView = "Presensi") Then
                            If Not IsNothing(myDataTableDGV) Then
                                Dim dv As DataView
                                If (rbKosongJamMasuk.Checked) Then
                                    If (contentView = "Presensi") Then
                                        dv = New DataView(myDataTableDGV, "masuk is null", "lokasi Asc, nama Asc, tanggal Asc, perusahaan Asc", DataViewRowState.CurrentRows)
                                    End If
                                    dgvView.DataSource = dv
                                ElseIf (rbKosongJamMasukPulang.Checked) Then
                                    If (contentView = "Presensi") Then
                                        dv = New DataView(myDataTableDGV, "masuk is null AND keluar is null", "lokasi Asc, nama Asc, tanggal Asc, perusahaan Asc", DataViewRowState.CurrentRows)
                                    End If
                                    dgvView.DataSource = dv
                                ElseIf (rbKosongJamPulang.Checked) Then
                                    If (contentView = "Presensi") Then
                                        dv = New DataView(myDataTableDGV, "keluar is null", "lokasi Asc, nama Asc, tanggal Asc, perusahaan Asc", DataViewRowState.CurrentRows)
                                    End If
                                    dgvView.DataSource = dv
                                End If

                                Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvView, dgvView.RowCount)
                                dgvView.RowHeadersWidth = 70
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbCekKosong_CheckedChanged Error")
        End Try
    End Sub

    Private Sub cbTampilkanYangKosong_CheckedChanged(sender As Object, e As EventArgs) Handles cbTampilkanYangKosong.CheckedChanged
        Try
            If (isDataPrepared) Then
                If (contentView = "Presensi") Then
                    If (cbTampilkanYangKosong.Checked) Then
                        pnlJamYangKosong.Enabled = True
                    Else
                        pnlJamYangKosong.Enabled = False
                        Dim dv As DataView
                        dv = New DataView(myDataTableDGV, "", "lokasi Asc, nama Asc, tanggal Asc, perusahaan Asc", DataViewRowState.CurrentRows)
                        dgvView.DataSource = dv

                        Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvView, dgvView.RowCount)
                        dgvView.RowHeadersWidth = 70
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cbTampilkanYangKosong_CheckedChanged Error")
        End Try
    End Sub
End Class
