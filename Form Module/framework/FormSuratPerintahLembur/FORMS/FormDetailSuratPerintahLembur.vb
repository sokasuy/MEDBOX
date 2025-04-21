Public Class FormDetailSuratPerintahLembur
    Private isNew As Boolean
    Private parentFormName As String
    Private rid As Long
    Private dgvPosNow As Integer
    Private myDataTableHeader As New DataTable
    Private myDataTableDGVDetail As New DataTable
    Private tableNameHeader As String
    Private tableNameDetail As String
    Private tableKey As String
    Private cmbDgvNewCheckbox As New DataGridViewCheckBoxColumn()
    Private cmbDgvEditedCheckbox As New DataGridViewCheckBoxColumn()
    Private cmbDgvDetailHapusButton As New DataGridViewButtonColumn()
    Private cekTambahButton(2) As Boolean
    Private arrDefValues(16) As String
    Private isDataPrepared As Boolean
    Private newValues As String
    Private newFields As String
    Private updateString As String

    Private stSQL As String
    Private myDataTableCboPerusahaan As New DataTable
    Private myBindingPerusahaan As New BindingSource
    Private myDataTableCboLokasi As New DataTable
    Private myBindingLokasi As New BindingSource
    Private myDataTableCboDepartemen As New DataTable
    Private myBindingDepartemen As New BindingSource
    Private myDataTableCboKepala As New DataTable
    Private myBindingKepala As New BindingSource
    Private myDataTableCboKaryawan As New DataTable
    Private myBindingKaryawan As New BindingSource
    Private isCboPrepared As Boolean
    Private isExist As Boolean

    'Private strSPL As String
    Private strKDR As String
    Private strJamLembur As TimeSpan
    Private prefixKode As String
    Private prefixCompleted As String
    Private digitLength As Integer
    Private isBinding As Boolean
    Private isValueChanged As Boolean
    Private initialValue As Object
    Private isPartialChanged As Boolean
    Private updatePart(2) As Boolean

    Private jarakPanelBawah As UShort
    Private jumPersonil As UShort

    Private WithEvents tbCellText As New DataGridViewTextBoxEditingControl
    Public Sub New(ByRef _myDataTableHeader As DataTable, ByRef _myDataTableDGVDetail As DataTable, _tableNameHeader As String, _tableNameDetail As String, _tableKey As String, Optional _isNew As Boolean = True, Optional _rid As Long = 0, Optional _dgvPosNow As Integer = 0, Optional _parentFormName As String = "")
        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            If Not IsNothing(_myDataTableHeader) Then
                isNew = _isNew
                parentFormName = _parentFormName
                tableNameHeader = _tableNameHeader
                tableNameDetail = _tableNameDetail
                myDataTableHeader = _myDataTableHeader
                tableKey = _tableKey
                If Not (isNew) Then
                    rid = _rid
                    dgvPosNow = _dgvPosNow
                    myDataTableDGVDetail = _myDataTableDGVDetail
                ElseIf (isNew) Then
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormDetailSuratPerintahLembur Error")
        End Try
    End Sub

    Private Sub FormDetailSuratPerintahLembur_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If Not isNew Then
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableNameDetail, "tobedel='False'", tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'")
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
            Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDetailSuratPerintahLembur_FormClosed Error")
        End Try
    End Sub

    Private Sub FormDetailSuratPerintahLembur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            isDataPrepared = False
            dtpTanggalPengajuan.Enabled = False

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='perusahaan' and keterangan like '%" & USER_.entityChose & "' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPerusahaan, myBindingPerusahaan, cboPerusahaan, "T_" & cboPerusahaan.Name, "keterangan", "keterangan", isCboPrepared, True)

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='departemen' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboDepartemen, myBindingDepartemen, cboDepartemen, "T_" & cboDepartemen.Name, "keterangan", "keterangan", isCboPrepared, True)

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='lokasi' " & IIf(USER_.lokasi = "ALL", "", "AND keterangan='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "'") & " order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboLokasi, myBindingLokasi, cboLokasi, "T_" & cboLokasi.Name, "keterangan", "keterangan", isCboPrepared, True)
            cboLokasi.SelectedIndex = 0

            stSQL = "SELECT concat(d.nama,' || ',d.nip,' || ',d.departemen,' || ',d.divisi,' || ',d.bagian) as karyawan,d.idk,d.nip,d.nama,d.perusahaan,d.departemen,d.divisi,d.bagian FROM " & CONN_.schemaHRD & ".mskaryawanaktif as d inner join " & CONN_.schemaHRD & ".mskaryawan as h on h.idk=d.idk WHERE d.perusahaan is not null " & IIf(USER_.lokasi = "ALL", "", "AND (d.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " AND (case when d.statuskepegawaian is null or d.statuskepegawaian='TETAP' then h.tanggalmasuk<=CURRENT_DATE else d.tglmulaikontrak<=CURRENT_DATE end) GROUP BY concat(d.nama,' || ',d.nip,' || ',d.departemen,' || ',d.divisi,' || ',d.bagian),d.idk,d.nip,d.nama,d.perusahaan,d.departemen,d.divisi,d.bagian ORDER BY karyawan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKepala, myBindingKepala, cboKepala, "T_" & cboKepala.Name, "nip", "karyawan", isCboPrepared, True)

            digitLength = 4
            prefixKode = "SPL"
            'gbDetail.Enabled = False

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, parentFormName, USER_.T_USER_RIGHT)
            Call SetDGVEntry_()

            If (Me.WindowState = FormWindowState.Maximized) Then
                jarakPanelBawah = 105
                pnlCetak.Top = Me.Size.Height - jarakPanelBawah
            Else
                jarakPanelBawah = Me.Size.Height - pnlCetak.Location.Y
            End If

            If Not isNew Then
                'Berarti Edit
                'Set Header
                'RecID
                arrDefValues(0) = myDataTableHeader.Rows(dgvPosNow).Item("rid")
                'Perusahaan
                For i As Byte = 0 To cboPerusahaan.Items.Count - 1
                    If (DirectCast(cboPerusahaan.Items(i), DataRowView).Item("keterangan") = myDataTableHeader.Rows(dgvPosNow).Item("perusahaan")) Then
                        cboPerusahaan.SelectedIndex = i
                        arrDefValues(1) = myDataTableHeader.Rows(dgvPosNow).Item("perusahaan")
                    End If
                Next
                'Departemen
                For i As Byte = 0 To cboDepartemen.Items.Count - 1
                    If (DirectCast(cboDepartemen.Items(i), DataRowView).Item("keterangan") = myDataTableHeader.Rows(dgvPosNow).Item("departemen")) Then
                        cboDepartemen.SelectedIndex = i
                        arrDefValues(2) = myDataTableHeader.Rows(dgvPosNow).Item("departemen")
                    End If
                Next
                'Tanggal Pengajuan
                dtpTanggalPengajuan.Value = myDataTableHeader.Rows(dgvPosNow).Item("tanggal_pengajuan")
                arrDefValues(3) = myDataTableHeader.Rows(dgvPosNow).Item("tanggal_pengajuan")
                'Periode Mulai
                dtpPeriodeMulai.Value = myDataTableHeader.Rows(dgvPosNow).Item("periode_mulai")
                arrDefValues(4) = myDataTableHeader.Rows(dgvPosNow).Item("periode_mulai")
                'Periode Selesai
                dtpPeriodeSelesai.Value = myDataTableHeader.Rows(dgvPosNow).Item("periode_selesai")
                arrDefValues(5) = myDataTableHeader.Rows(dgvPosNow).Item("periode_selesai")
                'No SPL
                tbNoSPL.Text = myDataTableHeader.Rows(dgvPosNow).Item("no_spl")
                arrDefValues(6) = myDataTableHeader.Rows(dgvPosNow).Item("no_spl")
                'Kepala
                For i As UShort = 0 To cboKepala.Items.Count - 1
                    If (DirectCast(cboKepala.Items(i), DataRowView).Item("nip") = myDataTableHeader.Rows(dgvPosNow).Item("nip_kepala")) Then
                        cboKepala.SelectedIndex = i
                        arrDefValues(7) = myDataTableHeader.Rows(dgvPosNow).Item("idk_kepala")
                        arrDefValues(8) = myDataTableHeader.Rows(dgvPosNow).Item("nip_kepala")
                        arrDefValues(9) = myDataTableHeader.Rows(dgvPosNow).Item("nama_kepala")
                    End If
                Next
                'bagkepala
                If Not IsDBNull(myDataTableHeader.Rows(dgvPosNow).Item("bag_kepala")) Then
                    arrDefValues(10) = myDataTableHeader.Rows(dgvPosNow).Item("bag_kepala")
                End If
                'divkepala
                If Not IsDBNull(myDataTableHeader.Rows(dgvPosNow).Item("div_kepala")) Then
                    arrDefValues(11) = myDataTableHeader.Rows(dgvPosNow).Item("div_kepala")
                End If
                'deptkepala
                If Not IsDBNull(myDataTableHeader.Rows(dgvPosNow).Item("dept_kepala")) Then
                    arrDefValues(12) = myDataTableHeader.Rows(dgvPosNow).Item("dept_kepala")
                End If
                'pershkepala
                If Not IsDBNull(myDataTableHeader.Rows(dgvPosNow).Item("persh_kepala")) Then
                    arrDefValues(16) = myDataTableHeader.Rows(dgvPosNow).Item("persh_kepala")
                End If
                'Catatan
                If Not IsDBNull(myDataTableHeader.Rows(dgvPosNow).Item("catatan")) Then
                    rtbCatatanHeader.Text = myDataTableHeader.Rows(dgvPosNow).Item("catatan")
                    arrDefValues(13) = myDataTableHeader.Rows(dgvPosNow).Item("catatan")
                End If
                arrDefValues(14) = myDataTableHeader.Rows(dgvPosNow).Item("jumlah_personil")
                jumPersonil = myDataTableHeader.Rows(dgvPosNow).Item("jumlah_personil")
                'Lokasi
                For i As Byte = 0 To cboLokasi.Items.Count - 1
                    If (DirectCast(cboLokasi.Items(i), DataRowView).Item("keterangan") = myDataTableHeader.Rows(dgvPosNow).Item("lokasi")) Then
                        cboLokasi.SelectedIndex = i
                        arrDefValues(15) = myDataTableHeader.Rows(dgvPosNow).Item("lokasi")
                    End If
                Next

                'Set Detail
                isPartialChanged = True
                Dim mRows As String()
                Dim tmpWaktuRealisasi(1) As Object
                For i As Integer = 0 To myDataTableDGVDetail.Rows.Count - 1
                    If Not IsDBNull(myDataTableDGVDetail.Rows(i).Item("realisasi_mulai")) Then
                        tmpWaktuRealisasi(0) = Format(myDataTableDGVDetail.Rows(i).Item("realisasi_mulai"), "dd-MMM-yyyy HH:mm")
                    Else
                        tmpWaktuRealisasi(0) = Nothing
                    End If
                    If Not IsDBNull(myDataTableDGVDetail.Rows(i).Item("realisasi_selesai")) Then
                        tmpWaktuRealisasi(1) = Format(myDataTableDGVDetail.Rows(i).Item("realisasi_selesai"), "dd-MMM-yyyy HH:mm")
                    Else
                        tmpWaktuRealisasi(1) = Nothing
                    End If
                    mRows = New String() {
                        myDataTableDGVDetail.Rows(i).Item("rid"),
                        Format(myDataTableDGVDetail.Rows(i).Item("tanggal_pengajuan"), "dd-MMM-yyyy"),
                        myDataTableDGVDetail.Rows(i).Item("no_spl"),
                        myDataTableDGVDetail.Rows(i).Item("kdr"),
                        myDataTableDGVDetail.Rows(i).Item("idk"),
                        myDataTableDGVDetail.Rows(i).Item("nip"),
                        myDataTableDGVDetail.Rows(i).Item("nama"),
                        IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item("bagian")), Nothing, myDataTableDGVDetail.Rows(i).Item("bagian")),
                        IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item("divisi")), Nothing, myDataTableDGVDetail.Rows(i).Item("divisi")),
                        IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item("departemen")), Nothing, myDataTableDGVDetail.Rows(i).Item("departemen")),
                        myDataTableDGVDetail.Rows(i).Item("perusahaan"),
                        myDataTableDGVDetail.Rows(i).Item("pekerjaan"),
                        myDataTableDGVDetail.Rows(i).Item("rencana_jam_lembur").ToString,
                        Format(myDataTableDGVDetail.Rows(i).Item("rencana_mulai"), "dd-MMM-yyyy HH:mm"),
                        Format(myDataTableDGVDetail.Rows(i).Item("rencana_selesai"), "dd-MMM-yyyy HH:mm"),
                        IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item("realisasi_jam_lembur")), Nothing, myDataTableDGVDetail.Rows(i).Item("realisasi_jam_lembur").ToString),
                        tmpWaktuRealisasi(0),
                        tmpWaktuRealisasi(1),
                        IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item("catatan")), Nothing, myDataTableDGVDetail.Rows(i).Item("catatan"))
                    }
                    With dgvDetail
                        .Rows.Add(mRows)
                    End With
                    Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
                Next
                isPartialChanged = False

                'If (clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))) Then
                '    Call myCFormManipulation.SetReadOnly(gbDataEntry, False)
                '    btnSimpan.Visible = True
                'Else
                '    Call myCFormManipulation.SetReadOnly(gbDataEntry, True)
                '    btnSimpan.Visible = False
                'End If
                Call myCFormManipulation.SetReadOnly(gbDataEntry, Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui")))
                btnSimpan.Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                'cboPerusahaan.Enabled = False
                'dtpTanggalPengajuan.Enabled = False
                tbNoSPL.ReadOnly = True
                tbDeptKepala.ReadOnly = True
                tbDivKepala.ReadOnly = True
                tbBagKepala.ReadOnly = True

                lblSPKOke.Visible = False
                btnCreateNew.Visible = False
            Else
                Call myCFormManipulation.SetReadOnly(gbDetail, True, False)
                btnCreateNew.Visible = True
                btnHapus.Visible = False
                jumPersonil = 0

                dtpPeriodeMulai.Value = Now.Date.AddDays(3)
                dtpPeriodeSelesai.Value = Now.Date.AddDays(8)

                'dtpRencanaMulai.Value = New Date(Now.Year, Now.Month, Now.Day, 16, 0, 0)
                'dtpRencanaSelesai.Value = New Date(Now.Year, Now.Month, Now.Day, 17, 0, 0)
            End If

            dtpRencanaMulai.MinDate = Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy")
            dtpRencanaMulai.MaxDate = Format(dtpPeriodeSelesai.Value.Date.AddDays(1), "dd-MMM-yyyy")
            dtpRencanaSelesai.MinDate = Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy")
            dtpRencanaSelesai.MaxDate = Format(dtpPeriodeSelesai.Value.Date.AddDays(1), "dd-MMM-yyyy")

            dtpRencanaMulai.Value = dtpPeriodeMulai.Value
            dtpRencanaSelesai.Value = dtpPeriodeMulai.Value
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDetailSuratPerintahLembur_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormDetailSuratPerintahLembur_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            isPartialChanged = True
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
            isDataPrepared = True
            isPartialChanged = False
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDetailSuratPerintahLembur_Activated Error")
        End Try
    End Sub

    Private Sub FormDetailSuratPerintahLembur_KeyDown(sender As Object, e As KeyEventArgs) Handles cboPerusahaan.KeyDown, cboLokasi.KeyDown, dtpTanggalPengajuan.KeyDown, tbNoSPL.KeyDown, cboKepala.KeyDown, rtbCatatanHeader.KeyDown, cboKaryawan.KeyDown, tbPekerjaan.KeyDown, dtpRencanaMulai.KeyDown, dtpRencanaSelesai.KeyDown, rtbCatatanDetail.KeyDown, btnTambahkan.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnHapus.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is rtbCatatanDetail) Then
                    'Call btnSimpan_Click(btnSimpan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDetailSuratPerintahLembur_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Try
            If Not isNew Then
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableNameDetail, "tobedel='False'", tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'")
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
            Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnKeluar_Click Error")
        End Try
    End Sub

    Private Sub FormDetailSuratPerintahLembur_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Try
            If (isDataPrepared) Then
                pnlCetak.Top = Me.Size.Height - jarakPanelBawah
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDetailSuratPerintahLembur_SizeChanged Error")
        End Try
    End Sub

    Private Sub SetDGVEntry_()
        Try
            With dgvDetail
                .Columns.Add("rid", "RID")
                .Columns.Add("tanggalpengajuan", "TANGGAL PENGAJUAN")
                .Columns.Add("nospl", "NO SPL")
                .Columns.Add("kdr", "KDR")
                .Columns.Add("idk", "IDK")
                .Columns.Add("nip", "NIP")
                .Columns.Add("nama", "NAMA")
                .Columns.Add("bagian", "BAGIAN")
                .Columns.Add("divisi", "DIVISI")
                .Columns.Add("departemen", "DEPARTEMEN")
                .Columns.Add("perusahaan", "PERUSAHAAN")
                .Columns.Add("pekerjaan", "PEKERJAAN")
                .Columns.Add("rencanajamlembur", "RENCANA JAM LEMBUR")
                .Columns.Add("rencanamulai", "RENCANA MULAI")
                .Columns.Add("rencanaselesai", "RENCANA SELESAI")
                .Columns.Add("realisasijamlembur", "REALISASI JAM LEMBUR")
                .Columns.Add("realisasimulai", "REALISASI MULAI")
                .Columns.Add("realisasiselesai", "REALISASI SELESAI")
                .Columns.Add("catatan", "CATATAN")

                .Columns("rid").Visible = False
                .Columns("tanggalpengajuan").Visible = False
                .Columns("nospl").Visible = False
                .Columns("kdr").Visible = False
                .Columns("idk").Visible = False
                .Columns("perusahaan").Visible = False

                .Columns("rid").Frozen = True
                .Columns("tanggalpengajuan").Frozen = True
                .Columns("nospl").Frozen = True
                .Columns("kdr").Frozen = True
                .Columns("idk").Frozen = True
                .Columns("nip").Frozen = True
                .Columns("nama").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("tanggalpengajuan").Width = 80
                .Columns("nospl").Width = 100
                .Columns("nip").Width = 75
                .Columns("nama").Width = 125
                .Columns("bagian").Width = 100
                .Columns("divisi").Width = 100
                .Columns("departemen").Width = 100
                .Columns("perusahaan").Width = 130
                .Columns("pekerjaan").Width = 100
                .Columns("rencanajamlembur").Width = 60
                .Columns("rencanamulai").Width = 120
                .Columns("rencanaselesai").Width = 120
                .Columns("realisasijamlembur").Width = 60
                .Columns("realisasimulai").Width = 120
                .Columns("realisasiselesai").Width = 120
                .Columns("catatan").Width = 120

                .Columns("tanggalpengajuan").ValueType = GetType(Date)
                .Columns("rencanajamlembur").ValueType = GetType(Object)
                .Columns("rencanamulai").ValueType = GetType(Date)
                .Columns("rencanaselesai").ValueType = GetType(Date)
                .Columns("realisasijamlembur").ValueType = GetType(Object)
                .Columns("realisasimulai").ValueType = GetType(Date)
                .Columns("realisasiselesai").ValueType = GetType(Date)

                .Columns("tanggalpengajuan").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tanggalpengajuan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("rencanajamlembur").DefaultCellStyle.Format = "HH:mm:ss"
                .Columns("rencanajamlembur").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("rencanamulai").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm"
                .Columns("rencanamulai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("rencanaselesai").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm"
                .Columns("rencanaselesai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("realisasijamlembur").DefaultCellStyle.Format = "HH:mm:ss"
                .Columns("realisasijamlembur").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("realisasimulai").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm"
                .Columns("realisasimulai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("realisasiselesai").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm"
                .Columns("realisasiselesai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns("nip").ReadOnly = True
                .Columns("nama").ReadOnly = True
                .Columns("bagian").ReadOnly = True
                .Columns("divisi").ReadOnly = True
                .Columns("departemen").ReadOnly = True
                .Columns("perusahaan").ReadOnly = True

                For i As Short = 0 To dgvDetail.Columns.Count - 1
                    If (.Columns(i).ReadOnly) Then
                        .Columns(i).DefaultCellStyle.BackColor = Color.Gainsboro
                    End If
                Next

                .Font = New Font("Arial", 8, FontStyle.Regular)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False

                .Columns("rencanajamlembur").DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                .Columns("rencanajamlembur").DefaultCellStyle.ForeColor = Color.Blue
                .Columns("rencanamulai").DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                .Columns("rencanamulai").DefaultCellStyle.ForeColor = Color.Blue
                .Columns("rencanaselesai").DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                .Columns("rencanaselesai").DefaultCellStyle.ForeColor = Color.Blue

                .Columns("realisasijamlembur").DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                .Columns("realisasijamlembur").DefaultCellStyle.ForeColor = Color.OrangeRed
                .Columns("realisasimulai").DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                .Columns("realisasimulai").DefaultCellStyle.ForeColor = Color.OrangeRed
                .Columns("realisasiselesai").DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                .Columns("realisasiselesai").DefaultCellStyle.ForeColor = Color.OrangeRed
            End With

            With cmbDgvNewCheckbox
                If Not (cekTambahButton(0)) Then
                    .HeaderText = "NEW"
                    .Name = "new"
                    .DataPropertyName = "new"
                    .DisplayIndex = dgvDetail.ColumnCount
                    dgvDetail.Columns.Add(cmbDgvNewCheckbox)
                    dgvDetail.Columns("new").Width = 70
                    cekTambahButton(0) = True
                    .ReadOnly = True
                    .DefaultCellStyle.BackColor = Color.Gainsboro
                End If
                .HeaderCell.Style.BackColor = Color.Yellow
            End With
            With cmbDgvEditedCheckbox
                If Not (cekTambahButton(1)) Then
                    .HeaderText = "EDITED"
                    .Name = "edited"
                    .DataPropertyName = "edited"
                    .DisplayIndex = dgvDetail.ColumnCount
                    dgvDetail.Columns.Add(cmbDgvEditedCheckbox)
                    dgvDetail.Columns("edited").Width = 70
                    cekTambahButton(1) = True
                    .ReadOnly = True
                    .DefaultCellStyle.BackColor = Color.Gainsboro
                End If
                .HeaderCell.Style.BackColor = Color.Lime
            End With
            With cmbDgvDetailHapusButton
                If Not (cekTambahButton(2)) Then
                    .HeaderText = "DELETE"
                    .Name = "delete"
                    .Text = "Delete"
                    .UseColumnTextForButtonValue = True
                    .DisplayIndex = dgvDetail.ColumnCount
                    dgvDetail.Columns.Add(cmbDgvDetailHapusButton)
                    dgvDetail.Columns("delete").Width = 100
                    cekTambahButton(2) = True
                    If (isNew) Then
                        btnHapus.Enabled = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                        .Visible = True
                    Else
                        btnHapus.Enabled = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                        .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                    End If
                End If
                .HeaderCell.Style.BackColor = Color.LightSalmon
            End With

            'untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
            dgvDetail.RowHeadersWidth = 70
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetDGVEntry_ Error")
        End Try
    End Sub

    Private Sub dgvDetail_Sorted(sender As Object, e As EventArgs) Handles dgvDetail.Sorted
        Try
            'untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_Sorted Error")
        End Try
    End Sub

    Private Sub cboPerusahaan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPerusahaan.SelectedIndexChanged
        Try
            If (isCboPrepared) Then
                If (cboPerusahaan.SelectedIndex <> -1) Then
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    isDataPrepared = False

                    stSQL = "SELECT concat(d.nama,' || ',d.nip,' || ',d.departemen,' || ',d.divisi,' || ',d.bagian) as karyawan,d.idk,d.nip,d.nama,d.perusahaan,d.departemen,d.divisi,d.bagian FROM " & CONN_.schemaHRD & ".mskaryawanaktif as d inner join " & CONN_.schemaHRD & ".mskaryawan as h on h.idk=d.idk WHERE d.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' " & IIf(USER_.lokasi = "ALL", "", "AND (d.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " AND (case when d.statuskepegawaian is null or d.statuskepegawaian='TETAP' then h.tanggalmasuk<=CURRENT_DATE else d.tglmulaikontrak<=CURRENT_DATE end) GROUP BY concat(d.nama,' || ',d.nip,' || ',d.departemen,' || ',d.divisi,' || ',d.bagian),d.idk,d.nip,d.nama,d.perusahaan,d.departemen,d.divisi,d.bagian ORDER BY karyawan;"
                    Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared, True)

                    'Per 18 Jan 2022 diganti tidak lagi pakai nomer SPL otomatis
                    'prefixCompleted = prefixKode & "-" & DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("kode")
                    'strSPL = myCDBOperation.SetDynamicAutoKode(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameHeader, tableKey, "rid", prefixCompleted, digitLength, False,, CONN_.dbType, Format(dtpTanggalPengajuan.Value.Date, "MMMyy"))
                    'tbNoSPL.Text = strSPL

                    isBinding = False
                    tbDeptKepala.DataBindings.Clear()
                    tbDivKepala.DataBindings.Clear()
                    tbBagKepala.DataBindings.Clear()
                    tbDeptKepala.Clear()
                    tbDivKepala.Clear()
                    tbBagKepala.Clear()
                    'gbDetail.Enabled = True
                    isDataPrepared = True

                    Call myCFormManipulation.SetReadOnly(gbDetail, False, False)
                    'cboKaryawan.Enabled = True
                    'tbPekerjaan.ReadOnly = False
                    'dtpRencanaMulai.Enabled = True
                    'dtpRencanaSelesai.Enabled = True
                    'tbRencanaJamLembur.ReadOnly = False
                    'rtbCatatanDetail.ReadOnly = False

                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                    Me.Cursor = Cursors.Default
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboPerusahaan_SelectedIndexChanged Error")
        End Try
    End Sub

    Private Sub cboKepala_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKepala.SelectedIndexChanged
        Try
            If (isCboPrepared) Then
                If (cboKepala.SelectedIndex <> -1) Then
                    'Buat binding data
                    If Not (isBinding) Then
                        tbDeptKepala.DataBindings.Add(New Binding("text", myBindingKepala, "departemen"))
                        tbDivKepala.DataBindings.Add(New Binding("text", myBindingKepala, "divisi"))
                        tbBagKepala.DataBindings.Add(New Binding("text", myBindingKepala, "bagian"))
                        isBinding = True
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboKepala_SelectedIndexChanged Error")
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboPerusahaan.Validated, cboKepala.Validated, cboKaryawan.Validated, cboDepartemen.Validated, cboLokasi.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
                If (sender Is cboPerusahaan) Then
                    Call myCFormManipulation.SetReadOnly(gbDetail, True, False)
                    'gbDetail.Enabled = False
                    'strSPL = Nothing
                    'tbNoSPL.Clear()

                    isBinding = False
                    myDataTableCboKepala.Clear()
                    cboKepala.SelectedIndex = -1
                    tbDeptKepala.DataBindings.Clear()
                    tbDivKepala.DataBindings.Clear()
                    tbBagKepala.DataBindings.Clear()
                    tbDeptKepala.Clear()
                    tbDivKepala.Clear()
                    tbBagKepala.Clear()

                    myDataTableCboKaryawan.Clear()
                    cboKaryawan.SelectedIndex = -1
                ElseIf (sender Is cboKepala) Then
                    tbDeptKepala.Clear()
                    tbDivKepala.Clear()
                    tbBagKepala.Clear()
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Try
            If (cboPerusahaan.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                stSQL = "SELECT concat(d.nama,' || ',d.nip,' || ',d.departemen,' || ',d.divisi,' || ',d.bagian) as karyawan,d.idk,d.nip,d.nama,d.perusahaan,d.departemen,d.divisi,d.bagian FROM " & CONN_.schemaHRD & ".mskaryawanaktif as d inner join " & CONN_.schemaHRD & ".mskaryawan as h on h.idk=d.idk WHERE d.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' " & IIf(USER_.lokasi = "ALL", "", "AND (d.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " AND (case when d.statuskepegawaian is null or d.statuskepegawaian='TETAP' then h.tanggalmasuk<=CURRENT_DATE else d.tglmulaikontrak<=CURRENT_DATE end) GROUP BY concat(d.nama,' || ',d.nip,' || ',d.departemen,' || ',d.divisi,' || ',d.bagian),d.idk,d.nip,d.nama,d.perusahaan,d.departemen,d.divisi,d.bagian ORDER BY karyawan;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared, True)

                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnReload_Click Error")
        End Try
    End Sub

    Private Sub dtpRencanaSPL_ValueChanged(sender As Object, e As EventArgs) Handles dtpRencanaMulai.ValueChanged, dtpRencanaSelesai.ValueChanged
        Try
            If Not isPartialChanged Then
                isPartialChanged = True
                dtpRencanaSelesai.Checked = dtpRencanaMulai.Checked
                dtpRencanaSelesai.MinDate = dtpRencanaMulai.Value
                If (dtpRencanaMulai.Value > dtpRencanaSelesai.Value) Then
                    dtpRencanaSelesai.Value = dtpRencanaMulai.Value
                End If
                strJamLembur = dtpRencanaSelesai.Value - dtpRencanaMulai.Value
                tbRencanaJamLembur.Text = myCStringManipulation.CleanInputTime(strJamLembur.ToString)
                isPartialChanged = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpRencanaSPL_ValueChanged Error")
        End Try
    End Sub

    Private Sub tbRencanaJamLembur_Validated(sender As Object, e As EventArgs) Handles tbRencanaJamLembur.Validated
        Try
            If Not isPartialChanged Then
                isPartialChanged = True
                tbRencanaJamLembur.Text = myCStringManipulation.CleanInputTime(Trim(tbRencanaJamLembur.Text))
                If (tbRencanaJamLembur.Text.Length > 0) Then
                    strJamLembur = TimeSpan.Parse(tbRencanaJamLembur.Text)
                    dtpRencanaSelesai.Value = dtpRencanaMulai.Value + strJamLembur
                Else
                    tbRencanaJamLembur.Text = myCStringManipulation.CleanInputTime(strJamLembur.ToString)
                End If
                isPartialChanged = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbRencanaJamLembur_Validated Error")
        End Try
    End Sub

    Private Sub btnTambahkan_Click(sender As Object, e As EventArgs) Handles btnTambahkan.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Dim mRows As String()
            Dim mFound As Boolean

            isPartialChanged = True
            If (cboPerusahaan.SelectedIndex <> -1 And cboLokasi.SelectedIndex <> -1 And cboDepartemen.SelectedIndex <> -1 And Trim(tbNoSPL.Text).Length > 0 And cboKepala.SelectedIndex <> -1 And cboKaryawan.SelectedIndex <> -1 And Trim(tbPekerjaan.Text).Length > 0 And Trim(tbRencanaJamLembur.Text).Length > 0) Then
                If (dtpRencanaMulai.Value = dtpRencanaSelesai.Value) Then
                    Call myCShowMessage.ShowWarning("Rencana waktu mulai lembur tidak boleh sama dengan rencana waktu selesai lembur!!")
                    dtpRencanaSelesai.Focus()
                Else
                    mFound = False
                    For i As Integer = 0 To dgvDetail.RowCount - 1
                        If (cboKaryawan.SelectedValue = dgvDetail.Rows(i).Cells("nip").Value And (Format(dtpRencanaMulai.Value.Date, "dd-MMM-yyyy") = Format(CDate(dgvDetail.Rows(i).Cells("rencanamulai").Value), "dd-MMM-yyyy") Or Format(dtpRencanaSelesai.Value.Date, "dd-MMM-yyyy") = Format(CDate(dgvDetail.Rows(i).Cells("rencanaselesai").Value), "dd-MMM-yyyy"))) Then
                            mFound = True
                        End If
                    Next

                    If Not mFound Then
                        strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameDetail, "kdr", "rid", Format(dtpRencanaMulai.Value.Date, "dd-MMM-yyyy"), cboKaryawan.SelectedValue, 0, CONN_.dbType).ToUpper
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameDetail, "kdr='" & strKDR & "'")
                        If Not (isExist) Then
                            mRows = New String() {
                                0,
                                Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy"),
                                tbNoSPL.Text,
                                strKDR,
                                DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("idk"),
                                cboKaryawan.SelectedValue,
                                DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama"),
                                IIf(IsDBNull(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("bagian")), Nothing, DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("bagian")),
                                IIf(IsDBNull(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("divisi")), Nothing, DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("divisi")),
                                IIf(IsDBNull(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("departemen")), Nothing, DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("departemen")),
                                DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("perusahaan"),
                                Trim(tbPekerjaan.Text),
                                strJamLembur.ToString,
                                Format(dtpRencanaMulai.Value, "dd-MMM-yyyy HH:mm"),
                                Format(dtpRencanaSelesai.Value, "dd-MMM-yyyy HH:mm"),
                                strJamLembur.ToString,
                                Format(dtpRencanaMulai.Value, "dd-MMM-yyyy HH:mm"),
                                Format(dtpRencanaSelesai.Value, "dd-MMM-yyyy HH:mm"),
                                IIf(Trim(rtbCatatanDetail.Text).Length = 0, Nothing, Trim(rtbCatatanDetail.Text)),
                                True,
                                False
                            }
                            With dgvDetail
                                .Rows.Add(mRows)
                            End With
                            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
                            Call myCFormManipulation.SetReadOnly(gbDataEntry, True)
                        Else
                            Call myCShowMessage.ShowWarning("Karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("karyawan") & " sudah terdaftar untuk lembur di tanggal " & Format(dtpRencanaMulai.Value.Date, "dd-MMM-yyyy"))
                        End If
                    Else
                        Call myCShowMessage.ShowWarning("Karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("karyawan") & " periode lembur " & Format(dtpRencanaMulai.Value, "dd-MMM-yyyy HH:mm") & " sampai " & Format(dtpRencanaSelesai.Value, "dd-MMM-yyyy HH:mm") & " sudah ada di daftar" & ControlChars.NewLine & "Tidak boleh ada data lembur yang kembar dalam 1 SPL!!")
                    End If
                End If
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua field yang bertanda *")
            End If
            isPartialChanged = False
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTambahkan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub dgvDetail_EditingControlShowing(sender As Object, e As EventArgs) Handles dgvDetail.EditingControlShowing
        Try
            If (dgvDetail.CurrentCell.ColumnIndex = dgvDetail.Columns("rencanajamlembur").Index Or dgvDetail.CurrentCell.ColumnIndex = dgvDetail.Columns("rencanamulai").Index Or dgvDetail.CurrentCell.ColumnIndex = dgvDetail.Columns("rencanaselesai").Index Or dgvDetail.CurrentCell.ColumnIndex = dgvDetail.Columns("realisasijamlembur").Index Or dgvDetail.CurrentCell.ColumnIndex = dgvDetail.Columns("realisasimulai").Index Or dgvDetail.CurrentCell.ColumnIndex = dgvDetail.Columns("realisasiselesai").Index) Then
                tbCellText = CType(dgvDetail.EditingControl, DataGridViewTextBoxEditingControl)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_EditingControlShowing Error")
        End Try
    End Sub

    Private Sub tbCellText_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tbCellText.KeyUp
        Try
            'If (Trim(tbCellText.Text).Length = 4) Then
            If (tbCellText.Text.Contains(".")) Then
                Dim mCellSelection As Integer
                mCellSelection = tbCellText.SelectionStart
                tbCellText.Text = tbCellText.Text.Replace(".", ":")
                tbCellText.SelectionStart = mCellSelection
            End If

            'End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbCellText_KeyUp Error")
        End Try
    End Sub

    Private Sub dgvDetail_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles dgvDetail.CellBeginEdit
        Try
            If (isDataPrepared) Then
                If Not IsNothing(dgvDetail.CurrentCell.Value) Then
                    If (e.ColumnIndex = dgvDetail.Columns("rencanajamlembur").Index Or e.ColumnIndex = dgvDetail.Columns("realisasijamlembur").Index) Then
                        initialValue = dgvDetail.CurrentCell.Value
                    Else
                        initialValue = Trim(dgvDetail.CurrentCell.Value)
                    End If
                Else
                    initialValue = Nothing
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_CellBeginEdit Error")
        End Try
    End Sub

    Private Sub dgvDetail_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvDetail.CellValueChanged
        Try
            If (isDataPrepared) Then
                If Not isPartialChanged Then
                    If Not IsDBNull(dgvDetail.CurrentCell.Value) And Not IsNothing(dgvDetail.CurrentCell.Value) Then
                        'kalau tidak null isinya
                        If (initialValue <> dgvDetail.CurrentCell.Value) Then
                            Dim cekLembur As String
                            If (e.ColumnIndex = dgvDetail.Columns("rencanajamlembur").Index Or e.ColumnIndex = dgvDetail.Columns("realisasijamlembur").Index) Then
                                cekLembur = myCStringManipulation.CleanInputTime(dgvDetail.CurrentCell.Value)
                                If IsNothing(cekLembur) Then
                                    Call myCShowMessage.ShowWarning("Format pengisian jam lembur salah dan jam lembur tidak boleh lebih dari 24 jam!!" & ControlChars.NewLine & "Jam lembur dikembalikan ke waktu semula")
                                    isPartialChanged = True
                                    dgvDetail.CurrentCell.Value = initialValue
                                    isPartialChanged = False
                                    isValueChanged = False
                                Else
                                    isValueChanged = True
                                End If
                            ElseIf (e.ColumnIndex = dgvDetail.Columns("rencanamulai").Index Or e.ColumnIndex = dgvDetail.Columns("rencanaselesai").Index) Then
                                If (e.ColumnIndex = dgvDetail.Columns("rencanamulai").Index) Then
                                    'Hanya mulai saja yang dipakai jadi patokkan
                                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                                    strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameDetail, "kdr", "rid", Format(Date.Parse(dgvDetail.CurrentRow.Cells("rencanamulai").Value), "dd-MMM-yyyy"), cboKaryawan.SelectedValue, 0, CONN_.dbType).ToUpper
                                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameDetail, "kdr='" & strKDR & "'")
                                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                                Else
                                    isExist = False
                                End If
                                If Not isExist Then
                                    strJamLembur = Date.Parse(dgvDetail.CurrentRow.Cells("rencanaselesai").Value) - Date.Parse(dgvDetail.CurrentRow.Cells("rencanamulai").Value)
                                    cekLembur = myCStringManipulation.CleanInputTime(strJamLembur.ToString)
                                    If IsNothing(cekLembur) Then
                                        Call myCShowMessage.ShowWarning("Format pengisian jam lembur salah dan jam lembur tidak boleh lebih dari 24 jam!!" & ControlChars.NewLine & "Jam lembur dikembalikan ke waktu semula")
                                        isPartialChanged = True
                                        dgvDetail.CurrentCell.Value = Format(Date.Parse(initialValue), "dd-MMM-yyyy HH:mm")
                                        isPartialChanged = False
                                        isValueChanged = False
                                    Else
                                        isValueChanged = True
                                    End If
                                Else
                                    isPartialChanged = True
                                    dgvDetail.CurrentCell.Value = initialValue
                                    Call myCShowMessage.ShowWarning("Karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("karyawan") & " sudah terdaftar untuk lembur di tanggal " & Format(Date.Parse(dgvDetail.CurrentRow.Cells("rencanamulai").Value), "dd-MMM-yyyy"))
                                    isPartialChanged = False
                                    isValueChanged = False
                                End If
                            ElseIf (e.ColumnIndex = dgvDetail.Columns("realisasimulai").Index Or e.ColumnIndex = dgvDetail.Columns("realisasiselesai").Index) Then
                                If Not IsNothing(dgvDetail.CurrentRow.Cells("realisasimulai").Value) And Not IsNothing(dgvDetail.CurrentRow.Cells("realisasiselesai").Value) Then
                                    strJamLembur = Date.Parse(dgvDetail.CurrentRow.Cells("realisasiselesai").Value) - Date.Parse(dgvDetail.CurrentRow.Cells("realisasimulai").Value)
                                    cekLembur = myCStringManipulation.CleanInputTime(strJamLembur.ToString)
                                    If IsNothing(cekLembur) Then
                                        Call myCShowMessage.ShowWarning("Format pengisian jam lembur salah dan jam lembur tidak boleh lebih dari 24 jam!!" & ControlChars.NewLine & "Jam lembur dikembalikan ke waktu semula")
                                        isPartialChanged = True
                                        dgvDetail.CurrentCell.Value = Format(Date.Parse(initialValue), "dd-MMM-yyyy HH:mm")
                                        isPartialChanged = False
                                        isValueChanged = False
                                    Else
                                        isValueChanged = True
                                    End If
                                Else
                                    isValueChanged = True
                                End If
                            Else
                                isValueChanged = True
                            End If
                        Else
                            isValueChanged = False
                        End If
                        'End If
                    Else
                        'Jika diisi nothing
                        If (e.ColumnIndex <> dgvDetail.Columns("pekerjaan").Index And e.ColumnIndex <> dgvDetail.Columns("rencanajamlembur").Index And e.ColumnIndex <> dgvDetail.Columns("rencanamulai").Index And e.ColumnIndex <> dgvDetail.Columns("rencanaselesai").Index And e.ColumnIndex) Then
                            If Not IsNothing(initialValue) Then
                                isPartialChanged = True
                                isValueChanged = True
                                dgvDetail.CurrentCell.Value = Nothing
                                isPartialChanged = False
                            Else
                                isValueChanged = False
                            End If
                        ElseIf (e.ColumnIndex = dgvDetail.Columns("pekerjaan").Index) Then
                            'Pekerjaan tidak boleh kosong
                            Call myCShowMessage.ShowWarning("Pekerjaan tidak boleh kosong")
                            If Not IsNothing(initialValue) Then
                                isPartialChanged = True
                                isValueChanged = True
                                dgvDetail.CurrentCell.Value = initialValue
                                isPartialChanged = False
                            Else
                                isValueChanged = False
                            End If
                        Else
                            'rencana jam lembur, rencana mulai dan rencana selesai tidak boleh null
                            Call myCShowMessage.ShowWarning("Rencana jam lembur, rencana mulai lembur dan rencana selesai lembur tidak boleh kosong!!" & ControlChars.NewLine & "Jam lembur dikembalikan ke waktu semula")
                            isPartialChanged = True
                            If (e.ColumnIndex = dgvDetail.Columns("rencanamulai").Index Or e.ColumnIndex = dgvDetail.Columns("rencanaselesai").Index) Then
                                dgvDetail.CurrentCell.Value = Format(Date.Parse(initialValue), "dd-MMM-yyyy HH:mm")
                            ElseIf (e.ColumnIndex = dgvDetail.Columns("rencanajamlembur").Index) Then
                                dgvDetail.CurrentCell.Value = initialValue
                            End If
                            isPartialChanged = False
                            isValueChanged = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_CellValueChanged Error")
        End Try
    End Sub

    Private Sub dgvDetail_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellValidated
        Try
            If (isDataPrepared) Then
                If (isValueChanged) Then
                    Select Case dgvDetail.Columns(e.ColumnIndex).Name
                        Case "rencanajamlembur"
                            isPartialChanged = True
                            If Not IsDBNull(dgvDetail.CurrentRow.Cells("rencanajamlembur").Value) Then
                                Dim spl As Date
                                spl = Date.Parse(dgvDetail.CurrentRow.Cells("rencanamulai").Value) + TimeSpan.Parse(dgvDetail.CurrentRow.Cells("rencanajamlembur").Value)
                                dgvDetail.CurrentRow.Cells("rencanaselesai").Value = Format(spl, "dd-MMM-yyyy HH:mm")
                                If (dgvDetail.CurrentRow.Cells("new").Value = False) Then
                                    dgvDetail.CurrentRow.Cells("edited").Value = True
                                End If
                            Else
                                'SEHARUSNYA GAK MUNGKIN MASUK SINI!!
                                dgvDetail.CurrentRow.Cells("rencanajamlembur").Value = initialValue
                            End If
                            isPartialChanged = False
                        Case "realisasijamlembur"
                            'realisasi jam lembur boleh null
                            isPartialChanged = True
                            If Not IsNothing(dgvDetail.CurrentRow.Cells("realisasijamlembur").Value) Then
                                Dim splselesai As Date
                                If Not IsNothing(dgvDetail.CurrentRow.Cells("realisasimulai").Value) Then
                                    splselesai = Date.Parse(dgvDetail.CurrentRow.Cells("realisasimulai").Value) + TimeSpan.Parse(dgvDetail.CurrentRow.Cells("realisasijamlembur").Value)
                                    dgvDetail.CurrentRow.Cells("realisasiselesai").Value = Format(splselesai, "dd-MMM-yyyy HH:mm")
                                ElseIf Not IsNothing(dgvDetail.CurrentRow.Cells("realisasiselesai").Value) Then
                                    splselesai = Date.Parse(dgvDetail.CurrentRow.Cells("realisasiselesai").Value) - TimeSpan.Parse(dgvDetail.CurrentRow.Cells("realisasijamlembur").Value)
                                    dgvDetail.CurrentRow.Cells("realisasimulai").Value = Format(splselesai, "dd-MMM-yyyy HH:mm")
                                Else
                                    'Gak bisa kalau realisasi mulai dan selesainya sama2 nothing
                                End If
                            Else
                                'dgvDetail.CurrentRow.Cells("realisasijamlembur").Value = DBNull.Value
                                dgvDetail.CurrentRow.Cells("realisasiselesai").Value = Nothing
                            End If
                            If (dgvDetail.CurrentRow.Cells("new").Value = False) Then
                                dgvDetail.CurrentRow.Cells("edited").Value = True
                            End If
                            isPartialChanged = False
                        Case "rencanamulai", "rencanaselesai"
                            'rencana mulai dan rencana selesai tidak boleh null
                            isPartialChanged = True
                            If (dgvDetail.CurrentRow.Cells("rencanamulai").Value > dgvDetail.CurrentRow.Cells("rencanaselesai").Value) Then
                                'SEHARUSNYA GAK MUNGKIN MASUK SINI!!
                                Call myCShowMessage.ShowWarning("Waktu selesai tidak boleh lebih kecil daripada waktu mulai!" & ControlChars.NewLine & "Waktu dikembalikan semula!")
                                'dgvDetail.CurrentRow.Cells("rencanaselesai").Value = dgvDetail.CurrentRow.Cells("rencanamulai").Value
                                sender.value = initialValue
                            Else
                                If (dgvDetail.CurrentRow.Cells("new").Value = False) Then
                                    dgvDetail.CurrentRow.Cells("edited").Value = True
                                End If
                            End If
                            strJamLembur = Date.Parse(dgvDetail.CurrentRow.Cells("rencanaselesai").Value) - Date.Parse(dgvDetail.CurrentRow.Cells("rencanamulai").Value)
                            dgvDetail.CurrentRow.Cells("rencanajamlembur").Value = strJamLembur.ToString
                            isPartialChanged = False
                        Case "realisasimulai", "realisasiselesai"
                            'realisasi mulai dan realisasi selesai boleh null
                            isPartialChanged = True
                            If Not IsNothing(dgvDetail.CurrentRow.Cells("realisasimulai").Value) And Not IsNothing(dgvDetail.CurrentRow.Cells("realisasiselesai").Value) Then
                                If (dgvDetail.CurrentRow.Cells("realisasimulai").Value > dgvDetail.CurrentRow.Cells("realisasiselesai").Value) Then
                                    'SEHARUSNYA GAK MUNGKIN MASUK SINI!!
                                    Call myCShowMessage.ShowWarning("Waktu selesai tidak boleh lebih kecil daripada waktu mulai!" & ControlChars.NewLine & "Waktu dikembalikan semula!")
                                    'dgvDetail.CurrentRow.Cells("realisasiselesai").Value = dgvDetail.CurrentRow.Cells("realisasimulai").Value
                                    sender.value = initialValue
                                Else
                                    If (dgvDetail.CurrentRow.Cells("new").Value = False) Then
                                        dgvDetail.CurrentRow.Cells("edited").Value = True
                                    End If
                                End If
                                strJamLembur = Date.Parse(dgvDetail.CurrentRow.Cells("realisasiselesai").Value) - Date.Parse(dgvDetail.CurrentRow.Cells("realisasimulai").Value)
                                dgvDetail.CurrentRow.Cells("realisasijamlembur").Value = strJamLembur.ToString
                            Else
                                'Kalau salah 1 entah realisasi mulai atau realisasi selesainya null atau bisa juga keduanya null
                                If Not IsNothing(dgvDetail.CurrentRow.Cells("realisasijamlembur").Value) Then
                                    'Kalau jam lemburnya ada isinya, maka bisa dihitung jam mulai atau jam selesainya
                                    Dim spl As Date
                                    If Not IsNothing(dgvDetail.CurrentRow.Cells("realisasimulai").Value) And IsNothing(dgvDetail.CurrentRow.Cells("realisasiselesai").Value) Then
                                        'Jika realisasi mulai tidak null, realisasi selesai yang null
                                        spl = Date.Parse(dgvDetail.CurrentRow.Cells("realisasimulai").Value) + TimeSpan.Parse(dgvDetail.CurrentRow.Cells("realisasijamlembur").Value)
                                        dgvDetail.CurrentRow.Cells("realisasiselesai").Value = Format(spl, "dd-MMM-yyyy HH:mm")
                                    ElseIf IsNothing(dgvDetail.CurrentRow.Cells("realisasimulai").Value) And Not IsNothing(dgvDetail.CurrentRow.Cells("realisasiselesai").Value) Then
                                        'Jika realisasi mulai null, realisasi selesai yang tidak null
                                        spl = Date.Parse(dgvDetail.CurrentRow.Cells("realisasiselesai").Value) - TimeSpan.Parse(dgvDetail.CurrentRow.Cells("realisasijamlembur").Value)
                                        dgvDetail.CurrentRow.Cells("realisasimulai").Value = Format(spl, "dd-MMM-yyyy HH:mm")
                                    Else
                                        'Kalau keduanya null, maka tidak bisa dihitung baik mulai dan selesainya
                                    End If
                                Else
                                    'Kalau jam lemburnya null, dan salah 1 dari mulai atau selesainya juga null, maka tidak bisa dihitung juga baik jam lemburnya maupun mulai dan selesainya
                                End If
                                If (dgvDetail.CurrentRow.Cells("new").Value = False) Then
                                    dgvDetail.CurrentRow.Cells("edited").Value = True
                                End If
                            End If

                            isPartialChanged = False
                        Case "pekerjaan", "catatan"
                            isPartialChanged = True
                            If (dgvDetail.CurrentRow.Cells("new").Value = False) Then
                                dgvDetail.CurrentRow.Cells("edited").Value = True
                            End If
                            isPartialChanged = False
                    End Select
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_CellValidated Error")
        Finally
            isValueChanged = False
        End Try
    End Sub

    Private Sub dgvDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetail.DataError
        Try
            Call myCShowMessage.ShowWarning("Ada error pada pengisian datagrid!!")
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_DataError Error")
        End Try
    End Sub

    Private Sub dgvDetail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellContentClick
        Try
            If (dgvDetail.RowCount > 0) Then
                If (e.RowIndex <> -1) Then
                    If (e.ColumnIndex = dgvDetail.Columns("delete").Index) Then
                        'Dim foundRows As DataRow()
                        If Not isNew Then
                            If (dgvDetail.CurrentRow.Cells("new").Value) Then
                                'langsung hapus aja kalau ini adalah record baru
                                dgvDetail.Rows.RemoveAt(e.RowIndex)
                            Else
                                'kalau ini adalah record lama, maka ditanyakan dulu apa benar mau dihapus
                                Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data lembur untuk karyawan " & dgvDetail.CurrentRow.Cells("nama").Value & " pada periode lembur " & dgvDetail.CurrentRow.Cells("rencanamulai").Value & " sampai " & dgvDetail.CurrentRow.Cells("rencanaselesai").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                                If (isConfirm = DialogResult.Yes) Then
                                    Me.Cursor = Cursors.WaitCursor
                                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableNameDetail, "tobedel='True'", "rid=" & dgvDetail.CurrentRow.Cells("rid").Value)
                                    'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableNameDetail, "rid=" & dgvDetail.CurrentRow.Cells("rid").Value, "sql")
                                    'Call myCShowMessage.ShowInfo("Penghapusan data lembur untuk karyawan " & dgvDetail.CurrentRow.Cells("nama").Value & " pada periode lembur " & dgvDetail.CurrentRow.Cells("rencanamulai").Value & " sampai " & dgvDetail.CurrentRow.Cells("rencanaselesai").Value & " berhasil!")
                                    'foundRows = myDataTableDGVDetail.Select("rid=" & dgvDetail.CurrentRow.Cells("rid").Value)
                                    'myDataTableDGVDetail.Rows.RemoveAt(myDataTableDGVDetail.Rows.IndexOf(foundRows(0)))
                                    dgvDetail.Rows.RemoveAt(e.RowIndex)
                                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                                    Me.Cursor = Cursors.Default
                                Else
                                    Call myCShowMessage.ShowInfo("Penghapusan data lembur untuk karyawan " & dgvDetail.CurrentRow.Cells("nama").Value & " pada periode lembur " & dgvDetail.CurrentRow.Cells("rencanamulai").Value & " sampai " & dgvDetail.CurrentRow.Cells("rencanaselesai").Value & " dibatalkan oleh user")
                                End If
                            End If
                        Else
                            dgvDetail.Rows.RemoveAt(e.RowIndex)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_CellContentClick Error")
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If (dgvDetail.Rows.Count > 0) Then
                Me.Cursor = Cursors.Default
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim queryBuilder As New Text.StringBuilder
                queryBuilder.Clear()

                'Dim created_at As Date
                'created_at = Now
                'ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                If (cboPerusahaan.SelectedIndex <> -1 And cboDepartemen.SelectedIndex <> -1 And cboKepala.SelectedIndex <> -1 And Trim(tbNoSPL.Text).Length > 0) Then
                    If isNew Then
                        'JIKA INPUT BARU
                        'HEADER
                        'CEK APAKAH NO SPL SUDAH EXIST ATAU NGGAK
                        'isExist = True
                        'While isExist
                        '    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameHeader, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'")
                        '    If (isExist) Then
                        '        prefixCompleted = prefixKode & " -" & DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("kode")
                        '        strSPL = myCDBOperation.SetDynamicAutoKode(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameHeader, tableKey, "rid", prefixCompleted, digitLength, False,, CONN_.dbType, Format(dtpTanggalPengajuan.Value.Date, "MMMyy"))
                        '        tbNoSPL.Text = strSPL
                        '    End If
                        'End While
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameHeader, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'")
                        If Not isExist Then
                            'HEADER
                            newValues = "'" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(cboDepartemen.SelectedValue) & "','" & Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy") & "','" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "','" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk")) & "','" & myCStringManipulation.SafeSqlLiteral(cboKepala.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama")) & "'," & ADD_INFO_.newValues
                            newFields = "perusahaan,lokasi,departemen,tanggalpengajuan,periodemulai,periodeselesai," & tableKey & ",idkkepala,nipkepala,namakepala," & ADD_INFO_.newFields
                            If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) & "'"
                                newFields &= ",bagkepala"
                            End If
                            If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) & "'"
                                newFields &= ",divkepala"
                            End If
                            If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) & "'"
                                newFields &= ",deptkepala"
                            End If
                            If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("perusahaan")) Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("perusahaan")) & "'"
                                newFields &= ",pershkepala"
                            End If
                            If Trim(rtbCatatanHeader.Text).Length > 0 Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(rtbCatatanHeader.Text) & "'"
                                newFields &= ",catatan"
                            End If
                            queryBuilder.Append(myCStringManipulation.QueryBuilder("insert", tableNameHeader, newValues, newFields))

                            'DETAIL
                            For i As Integer = 0 To dgvDetail.Rows.Count - 1
                                newValues = "'" & Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("kdr").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("idk").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nip").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nama").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("perusahaan").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("pekerjaan").Value) & "','" & dgvDetail.Rows(i).Cells("rencanajamlembur").Value & "','" & dgvDetail.Rows(i).Cells("rencanamulai").Value & "','" & dgvDetail.Rows(i).Cells("rencanaselesai").Value & "'," & ADD_INFO_.newValues
                                newFields = "tanggalpengajuan," & tableKey & ",kdr,idk,nip,nama,perusahaan,pekerjaan,rencanajamlembur,rencanamulai,rencanaselesai," & ADD_INFO_.newFields
                                If Not IsNothing(dgvDetail.Rows(i).Cells("bagian").Value) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("bagian").Value) & "'"
                                    newFields &= ",bagian"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("divisi").Value) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("divisi").Value) & "'"
                                    newFields &= ",divisi"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("departemen").Value) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("departemen").Value) & "'"
                                    newFields &= ",departemen"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("realisasijamlembur").Value) Then
                                    newValues &= ",'" & dgvDetail.Rows(i).Cells("realisasijamlembur").Value & "'"
                                    newFields &= ",realisasijamlembur"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("realisasimulai").Value) Then
                                    newValues &= ",'" & dgvDetail.Rows(i).Cells("realisasimulai").Value & "'"
                                    newFields &= ",realisasimulai"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("realisasiselesai").Value) Then
                                    newValues &= ",'" & dgvDetail.Rows(i).Cells("realisasiselesai").Value & "'"
                                    newFields &= ",realisasiselesai"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("catatan").Value) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("catatan").Value) & "'"
                                    newFields &= ",catatan"
                                End If
                                queryBuilder.Append(myCStringManipulation.QueryBuilder("insert", tableNameDetail, newValues, newFields))
                            Next

                            'JALANKAN TRANSACTIONNYA
                            If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                                'If (myDataTableHeader.Rows.Count < 10) Then
                                '    'HEADER
                                '    Dim myRID As Integer
                                '    myRID = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameHeader, "desc", tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'", CONN_.dbType)
                                '    With myDataTableHeader
                                '        Dim newDataTableHeader As DataRow = .NewRow()
                                '        newDataTableHeader("rid") = myRID
                                '        newDataTableHeader("perusahaan") = Trim(cboPerusahaan.SelectedValue)
                                '        newDataTableHeader("tanggal") = Format(dtpTanggal.Value.Date, "dd-MMM-yyyy")
                                '        newDataTableHeader("no_spl") = Trim(tbNoSPL.Text)
                                '        newDataTableHeader("idk_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk"))
                                '        newDataTableHeader("nip_kepala") = Trim(cboKepala.SelectedValue)
                                '        newDataTableHeader("nama_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama"))
                                '        newDataTableHeader("bagian") = IIf(Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")), Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")), DBNull.Value)
                                '        newDataTableHeader("divisi") = IIf(Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")), Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")), DBNull.Value)
                                '        newDataTableHeader("departemen") = IIf(Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")), Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")), DBNull.Value)
                                '        newDataTableHeader("catatan") = IIf(Trim(rtbCatatanHeader.Text).Length > 0, Trim(rtbCatatanHeader.Text), DBNull.Value)
                                '        newDataTableHeader("created_at") = created_at
                                '        'memasukkan row baru tersebut ke data tabel master barang
                                '        .Rows.Add(newDataTableHeader)
                                '    End With
                                'End If
                                'Update jumlah personil
                                stSQL = "select count(distinct(nip)) as jumlahpersonil from " & tableNameDetail & " where nospl='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "';"
                                jumPersonil = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableNameHeader, "jumlahpersonil=" & jumPersonil, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'")

                                Call myCShowMessage.ShowSavedMsg("SPL " & Trim(tbNoSPL.Text))
                                Call myCFormManipulation.SetReadOnly(gbDataEntry, True)
                                Call myCFormManipulation.SetReadOnly(gbDetail, True)
                                btnSimpan.Enabled = False
                                btnTambahkan.Enabled = False
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Nomer SPK tersebut telah terpakai!" & ControlChars.NewLine & "Silahkan ganti dengan nomer SPL yang lain")
                        End If
                    Else
                        'JIKA EDIT
                        'HEADER
                        If (arrDefValues(1) <> DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("keterangan")) Then
                            updateString = "perusahaan='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("keterangan")) & "'"
                        End If
                        If (arrDefValues(2) <> DirectCast(cboDepartemen.SelectedItem, DataRowView).Item("keterangan")) Then
                            updateString = IIf(IsNothing(updateString), "", ",") & "departemen='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboDepartemen.SelectedItem, DataRowView).Item("keterangan")) & "'"
                        End If
                        If (arrDefValues(3) <> dtpTanggalPengajuan.Value.Date) Then
                            updateString = IIf(IsNothing(updateString), "", ",") & "tanggalpengajuan='" & Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy") & "'"
                        End If
                        If (arrDefValues(4) <> dtpPeriodeMulai.Value.Date) Then
                            updateString = IIf(IsNothing(updateString), "", ",") & "periodemulai='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "'"
                        End If
                        If (arrDefValues(5) <> dtpPeriodeSelesai.Value.Date) Then
                            updateString = IIf(IsNothing(updateString), "", ",") & "periodeselesai='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "'"
                        End If
                        'If (arrDefValues(6) <> Trim(tbNoSPL.Text)) Then
                        '    updateString = IIf(IsNothing(updateString), "", ",") & tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'"
                        'End If
                        If (arrDefValues(7) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk")) Then
                            updateString = "idkkepala='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk")) & "',nipkepala='" & myCStringManipulation.SafeSqlLiteral(cboKepala.SelectedValue) & "',namakepala='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama")) & "'"
                            If (arrDefValues(10) <> IIf(IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")), Nothing, DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian"))) Then
                                If (IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian"))) Then
                                    updateString &= ",bagkepala=Null"
                                Else
                                    updateString &= ",bagkepala='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) & "'"
                                End If
                                'updateString &= ",bagkepala=" & IIf(IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")), "Null", "'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) & "'")
                            End If
                            If (arrDefValues(11) <> IIf(IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")), Nothing, DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi"))) Then
                                If (IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi"))) Then
                                    updateString &= ",divkepala=Null"
                                Else
                                    updateString &= ",divkepala='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) & "'"
                                End If
                            End If
                            If (arrDefValues(12) <> IIf(IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")), Nothing, DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen"))) Then
                                If (IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen"))) Then
                                    updateString &= ",deptkepala=Null"
                                Else
                                    updateString &= ",deptkepala='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) & "'"
                                End If
                                'updateString &= ",deptkepala=" & IIf(IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")), "Null", "'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) & "'")
                            End If
                            If (arrDefValues(16) <> IIf(IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("perusahaan")), Nothing, DirectCast(cboKepala.SelectedItem, DataRowView).Item("perusahaan"))) Then
                                If (IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("perusahaan"))) Then
                                    updateString &= ",pershkepala=Null"
                                Else
                                    updateString &= ",pershkepala='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("perusahaan")) & "'"
                                End If
                            End If
                        End If
                        If (arrDefValues(13) <> Trim(rtbCatatanHeader.Text)) Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "catatan=" & IIf(Trim(rtbCatatanHeader.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(rtbCatatanHeader.Text) & "'")
                        End If
                        If (arrDefValues(15) <> DirectCast(cboLokasi.SelectedItem, DataRowView).Item("keterangan")) Then
                            updateString = "lokasi='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboLokasi.SelectedItem, DataRowView).Item("keterangan")) & "'"
                        End If
                        If Not IsNothing(updateString) Then
                            updateString &= "," & ADD_INFO_.updateString
                            'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableNameHeader, CONN_.dbType)
                            queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableNameHeader, updateString,, "rid=" & arrDefValues(0)))
                            updatePart(0) = True
                        End If

                        updateString = Nothing
                        'DETAIL
                        For i As Integer = 0 To dgvDetail.RowCount - 1
                            If (dgvDetail.Rows(i).Cells("new").Value) Then
                                newValues = "'" & Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("kdr").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("idk").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nip").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nama").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("perusahaan").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("pekerjaan").Value) & "','" & dgvDetail.Rows(i).Cells("rencanajamlembur").Value & "','" & dgvDetail.Rows(i).Cells("rencanamulai").Value & "','" & dgvDetail.Rows(i).Cells("rencanaselesai").Value & "'," & ADD_INFO_.newValues
                                newFields = "tanggalpengajuan," & tableKey & ",kdr,idk,nip,nama,perusahaan,pekerjaan,rencanajamlembur,rencanamulai,rencanaselesai," & ADD_INFO_.newFields
                                If Not IsNothing(dgvDetail.Rows(i).Cells("bagian").Value) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("bagian").Value) & "'"
                                    newFields &= ",bagian"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("divisi").Value) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("divisi").Value) & "'"
                                    newFields &= ",divisi"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("departemen").Value) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("departemen").Value) & "'"
                                    newFields &= ",departemen"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("realisasijamlembur").Value) Then
                                    newValues &= ",'" & dgvDetail.Rows(i).Cells("realisasijamlembur").Value & "'"
                                    newFields &= ",realisasijamlembur"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("realisasimulai").Value) Then
                                    newValues &= ",'" & dgvDetail.Rows(i).Cells("realisasimulai").Value & "'"
                                    newFields &= ",realisasimulai"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("realisasiselesai").Value) Then
                                    newValues &= ",'" & dgvDetail.Rows(i).Cells("realisasiselesai").Value & "'"
                                    newFields &= ",realisasiselesai"
                                End If
                                If Not IsNothing(dgvDetail.Rows(i).Cells("catatan").Value) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("catatan").Value) & "'"
                                    newFields &= ",catatan"
                                End If
                                queryBuilder.Append(myCStringManipulation.QueryBuilder("insert", tableNameDetail, newValues, newFields))
                                updatePart(1) = True
                            ElseIf (dgvDetail.Rows(i).Cells("edited").Value) Then
                                updateString = "pekerjaan='" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("pekerjaan").Value) & "',rencanajamlembur='" & dgvDetail.Rows(i).Cells("rencanajamlembur").Value & "',rencanamulai='" & dgvDetail.Rows(i).Cells("rencanamulai").Value & "',rencanaselesai='" & dgvDetail.Rows(i).Cells("rencanaselesai").Value & "'," & ADD_INFO_.updateString
                                'If Not IsNothing(dgvDetail.Rows(i).Cells("realisasijamlembur").Value) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "realisasijamlembur=" & IIf(IsNothing(dgvDetail.Rows(i).Cells("realisasijamlembur").Value), "Null", "'" & dgvDetail.Rows(i).Cells("realisasijamlembur").Value & "'")
                                'Else
                                '    updateString &= IIf(IsNothing(updateString), "", ",") & "realisasijamlembur=Null"
                                'End If
                                'If Not IsNothing(dgvDetail.Rows(i).Cells("realisasimulai").Value) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "realisasimulai=" & IIf(IsNothing(dgvDetail.Rows(i).Cells("realisasimulai").Value), "Null", "'" & dgvDetail.Rows(i).Cells("realisasimulai").Value & "'")
                                'Else
                                '    updateString &= IIf(IsNothing(updateString), "", ",") & "realisasimulai=Null"
                                'End If
                                'If Not IsNothing(dgvDetail.Rows(i).Cells("realisasiselesai").Value) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "realisasiselesai=" & IIf(IsNothing(dgvDetail.Rows(i).Cells("realisasiselesai").Value), "Null", "'" & dgvDetail.Rows(i).Cells("realisasiselesai").Value & "'")
                                'Else
                                '    updateString &= IIf(IsNothing(updateString), "", ",") & "realisasiselesai=Null"
                                'End If
                                'If Not IsNothing(dgvDetail.Rows(i).Cells("catatan").Value) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "catatan=" & IIf(IsNothing(dgvDetail.Rows(i).Cells("catatan").Value), "Null", "'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("catatan").Value) & "'")
                                'Else
                                '    updateString &= IIf(IsNothing(updateString), "", ",") & "catatan=Null"
                                'End If
                                'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableNameDetail, CONN_.dbType)
                                queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableNameDetail, updateString,, "rid=" & dgvDetail.Rows(i).Cells("rid").Value))
                                updatePart(1) = True
                            End If
                        Next
                        'Bersihkan yang ditandai tobedel
                        'DELETE
                        Dim myDataTableToBeDel As New DataTable
                        stSQL = "SELECT rid FROM " & tableNameDetail & " WHERE " & tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "' AND tobedel='True' ORDER BY rid;"
                        myDataTableToBeDel = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Tobedel")
                        For i As Integer = 0 To myDataTableToBeDel.Rows.Count - 1
                            queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameDetail, "",, "rid=" & myDataTableToBeDel.Rows(i).Item("rid")))
                            updatePart(2) = True
                        Next

                        'JALANKAN TRANSACTIONNYA UNTUK SAVE DATANYA!!
                        If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                            'Update jumlah personil
                            stSQL = "select count(distinct(nip)) as jumlahpersonil from " & tableNameDetail & " where nospl='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "';"
                            jumPersonil = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableNameHeader, "jumlahpersonil=" & jumPersonil, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'")
                            arrDefValues(14) = jumPersonil
                            myDataTableHeader.Rows(dgvPosNow).Item("jumlah_personil") = jumPersonil

                            'JIKA TRANSACTION BERHASIL, MAKA UPDATE SEGALA ISI DATAGRID NYA
                            Dim foundRows As DataRow()
                            If (updatePart(0)) Then
                                'HEADER
                                If (arrDefValues(1) <> DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("keterangan")) Then
                                    arrDefValues(1) = DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("keterangan")
                                    myDataTableHeader.Rows(dgvPosNow).Item("perusahaan") = Trim(DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("keterangan"))
                                End If
                                If (arrDefValues(2) <> DirectCast(cboDepartemen.SelectedItem, DataRowView).Item("keterangan")) Then
                                    arrDefValues(2) = DirectCast(cboDepartemen.SelectedItem, DataRowView).Item("keterangan")
                                    myDataTableHeader.Rows(dgvPosNow).Item("departemen") = Trim(DirectCast(cboDepartemen.SelectedItem, DataRowView).Item("keterangan"))
                                End If
                                If (arrDefValues(3) <> dtpTanggalPengajuan.Value.Date) Then
                                    arrDefValues(3) = Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy")
                                    myDataTableHeader.Rows(dgvPosNow).Item("tanggal_pengajuan") = Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy")
                                End If
                                If (arrDefValues(4) <> dtpPeriodeMulai.Value.Date) Then
                                    arrDefValues(4) = Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy")
                                    myDataTableHeader.Rows(dgvPosNow).Item("periode_mulai") = Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy")
                                End If
                                If (arrDefValues(5) <> dtpPeriodeSelesai.Value.Date) Then
                                    arrDefValues(5) = Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy")
                                    myDataTableHeader.Rows(dgvPosNow).Item("periode_selesai") = Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy")
                                End If
                                'If (arrDefValues(6) <> Trim(tbNoSPL.Text)) Then
                                '    arrDefValues(6) = Trim(tbNoSPL.Text)
                                '    myDataTableHeader.Rows(dgvPosNow).Item("no_spk") = Trim(tbNoSPL.Text)
                                'End If
                                If (arrDefValues(7) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk")) Then
                                    arrDefValues(7) = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk"))
                                    arrDefValues(8) = Trim(cboKepala.SelectedValue)
                                    arrDefValues(9) = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama"))
                                    myDataTableHeader.Rows(dgvPosNow).Item("idk_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk"))
                                    myDataTableHeader.Rows(dgvPosNow).Item("nip_kepala") = Trim(cboKepala.SelectedValue)
                                    myDataTableHeader.Rows(dgvPosNow).Item("nama_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama"))
                                    If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) Then
                                        If (arrDefValues(10) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) Then
                                            arrDefValues(10) = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian"))
                                            myDataTableHeader.Rows(dgvPosNow).Item("bag_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian"))
                                        End If
                                    Else
                                        If Not IsNothing(arrDefValues(10)) Then
                                            arrDefValues(10) = Nothing
                                            myDataTableHeader.Rows(dgvPosNow).Item("bag_kepala") = DBNull.Value
                                        End If
                                    End If
                                    If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) Then
                                        If (arrDefValues(11) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) Then
                                            arrDefValues(11) = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi"))
                                            myDataTableHeader.Rows(dgvPosNow).Item("div_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi"))
                                        End If
                                    Else
                                        If Not IsNothing(arrDefValues(11)) Then
                                            arrDefValues(11) = Nothing
                                            myDataTableHeader.Rows(dgvPosNow).Item("div_kepala") = DBNull.Value
                                        End If
                                    End If
                                    If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) Then
                                        If (arrDefValues(12) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) Then
                                            arrDefValues(12) = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen"))
                                            myDataTableHeader.Rows(dgvPosNow).Item("dept_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen"))
                                        End If
                                    Else
                                        If Not IsNothing(arrDefValues(12)) Then
                                            arrDefValues(12) = Nothing
                                            myDataTableHeader.Rows(dgvPosNow).Item("dept_kepala") = DBNull.Value
                                        End If
                                    End If
                                    If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("perusahaan")) Then
                                        If (arrDefValues(16) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("perusahaan")) Then
                                            arrDefValues(16) = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("perusahaan"))
                                            myDataTableHeader.Rows(dgvPosNow).Item("persh_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("perusahaan"))
                                        End If
                                    Else
                                        If Not IsNothing(arrDefValues(16)) Then
                                            arrDefValues(16) = Nothing
                                            myDataTableHeader.Rows(dgvPosNow).Item("persh_kepala") = DBNull.Value
                                        End If
                                    End If
                                End If
                                If (arrDefValues(13) <> Trim(rtbCatatanHeader.Text)) Then
                                    If (Trim(rtbCatatanHeader.Text).Length > 0) Then
                                        arrDefValues(13) = Trim(rtbCatatanHeader.Text)
                                        myDataTableHeader.Rows(dgvPosNow).Item("catatan") = Trim(rtbCatatanHeader.Text)
                                    Else
                                        arrDefValues(13) = Nothing
                                        myDataTableHeader.Rows(dgvPosNow).Item("catatan") = DBNull.Value
                                    End If
                                End If
                                If (arrDefValues(15) <> DirectCast(cboLokasi.SelectedItem, DataRowView).Item("keterangan")) Then
                                    arrDefValues(15) = DirectCast(cboLokasi.SelectedItem, DataRowView).Item("keterangan")
                                    myDataTableHeader.Rows(dgvPosNow).Item("lokasi") = Trim(DirectCast(cboLokasi.SelectedItem, DataRowView).Item("keterangan"))
                                End If
                                'Update kolom UPDATED_AT
                                myDataTableHeader.Rows(dgvPosNow).Item("updated_at") = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "updated_at", tableNameHeader, "desc", "rid=" & arrDefValues(0), CONN_.dbType)
                            End If
                            If (updatePart(1)) Then
                                'DETAIL
                                For i As Integer = 0 To dgvDetail.RowCount - 1
                                    If (dgvDetail.Rows(i).Cells("new").Value) Then
                                        Dim myRID As Integer
                                        Dim myCreatedAt As String
                                        myRID = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameDetail, "desc", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("kdr").Value) & "'", CONN_.dbType)
                                        myCreatedAt = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "created_at", tableNameDetail, "desc", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("kdr").Value) & "'", CONN_.dbType)
                                        With myDataTableDGVDetail
                                            Dim newDataTableDetail As DataRow = .NewRow()
                                            newDataTableDetail("rid") = myRID
                                            newDataTableDetail("tanggal_pengajuan") = dgvDetail.Rows(i).Cells("tanggalpengajuan").Value
                                            newDataTableDetail("no_spl") = Trim(dgvDetail.Rows(i).Cells("nospl").Value)
                                            newDataTableDetail("kdr") = Trim(dgvDetail.Rows(i).Cells("kdr").Value)
                                            newDataTableDetail("idk") = Trim(dgvDetail.Rows(i).Cells("idk").Value)
                                            newDataTableDetail("nip") = Trim(dgvDetail.Rows(i).Cells("nip").Value)
                                            newDataTableDetail("nama") = Trim(dgvDetail.Rows(i).Cells("nama").Value)
                                            newDataTableDetail("bagian") = IIf(IsNothing(dgvDetail.Rows(i).Cells("bagian").Value), DBNull.Value, Trim(dgvDetail.Rows(i).Cells("bagian").Value))
                                            newDataTableDetail("divisi") = IIf(IsNothing(dgvDetail.Rows(i).Cells("divisi").Value), DBNull.Value, Trim(dgvDetail.Rows(i).Cells("divisi").Value))
                                            newDataTableDetail("departemen") = IIf(IsNothing(dgvDetail.Rows(i).Cells("departemen").Value), DBNull.Value, Trim(dgvDetail.Rows(i).Cells("departemen").Value))
                                            newDataTableDetail("perusahaan") = Trim(dgvDetail.Rows(i).Cells("perusahaan").Value)
                                            newDataTableDetail("pekerjaan") = Trim(dgvDetail.Rows(i).Cells("pekerjaan").Value)
                                            newDataTableDetail("rencana_jam_lembur") = dgvDetail.Rows(i).Cells("rencanajamlembur").Value
                                            newDataTableDetail("rencana_mulai") = dgvDetail.Rows(i).Cells("rencanamulai").Value
                                            newDataTableDetail("rencana_selesai") = dgvDetail.Rows(i).Cells("rencanaselesai").Value
                                            newDataTableDetail("realisasi_jam_lembur") = IIf(IsNothing(dgvDetail.Rows(i).Cells("realisasijamlembur").Value), DBNull.Value, dgvDetail.Rows(i).Cells("realisasijamlembur").Value)
                                            newDataTableDetail("realisasi_mulai") = IIf(IsNothing(dgvDetail.Rows(i).Cells("realisasimulai").Value), DBNull.Value, dgvDetail.Rows(i).Cells("realisasimulai").Value)
                                            newDataTableDetail("realisasi_selesai") = IIf(IsNothing(dgvDetail.Rows(i).Cells("realisasiselesai").Value), DBNull.Value, dgvDetail.Rows(i).Cells("realisasiselesai").Value)
                                            newDataTableDetail("catatan") = IIf(IsNothing(dgvDetail.Rows(i).Cells("catatan").Value), DBNull.Value, Trim(dgvDetail.Rows(i).Cells("catatan").Value))
                                            newDataTableDetail("created_at") = myCreatedAt
                                            'memasukkan row baru tersebut ke data tabel master barang
                                            .Rows.Add(newDataTableDetail)
                                        End With
                                    ElseIf (dgvDetail.Rows(i).Cells("edited").Value) Then
                                        foundRows = myDataTableDGVDetail.Select("rid=" & dgvDetail.Rows(i).Cells("rid").Value)
                                        With myDataTableDGVDetail
                                            .Rows(.Rows.IndexOf(foundRows(0))).Item("pekerjaan") = Trim(dgvDetail.Rows(i).Cells("pekerjaan").Value)
                                            .Rows(.Rows.IndexOf(foundRows(0))).Item("rencana_jam_lembur") = dgvDetail.Rows(i).Cells("rencanajamlembur").Value
                                            .Rows(.Rows.IndexOf(foundRows(0))).Item("rencana_mulai") = dgvDetail.Rows(i).Cells("rencanamulai").Value
                                            .Rows(.Rows.IndexOf(foundRows(0))).Item("rencana_selesai") = dgvDetail.Rows(i).Cells("rencanaselesai").Value
                                            .Rows(.Rows.IndexOf(foundRows(0))).Item("realisasi_jam_lembur") = IIf(IsNothing(dgvDetail.Rows(i).Cells("realisasijamlembur").Value), DBNull.Value, dgvDetail.Rows(i).Cells("realisasijamlembur").Value)
                                            .Rows(.Rows.IndexOf(foundRows(0))).Item("realisasi_mulai") = IIf(IsNothing(dgvDetail.Rows(i).Cells("realisasimulai").Value), DBNull.Value, dgvDetail.Rows(i).Cells("realisasimulai").Value)
                                            .Rows(.Rows.IndexOf(foundRows(0))).Item("realisasi_selesai") = IIf(IsNothing(dgvDetail.Rows(i).Cells("realisasiselesai").Value), DBNull.Value, dgvDetail.Rows(i).Cells("realisasiselesai").Value)
                                            .Rows(.Rows.IndexOf(foundRows(0))).Item("catatan") = IIf(IsNothing(dgvDetail.Rows(i).Cells("catatan").Value), DBNull.Value, Trim(dgvDetail.Rows(i).Cells("catatan").Value))
                                            .Rows(.Rows.IndexOf(foundRows(0))).Item("updated_at") = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "updated_at", tableNameDetail, "desc", "rid=" & dgvDetail.Rows(i).Cells("rid").Value, CONN_.dbType)
                                        End With
                                    End If
                                Next
                            End If
                            If (updatePart(2)) Then
                                'DELETE
                                For i As Integer = 0 To myDataTableToBeDel.Rows.Count - 1
                                    foundRows = myDataTableDGVDetail.Select("rid=" & myDataTableToBeDel.Rows(i).Item("rid"))
                                    If (foundRows.Count > 0) Then
                                        myDataTableDGVDetail.Rows.RemoveAt(myDataTableDGVDetail.Rows.IndexOf(foundRows(0)))
                                    End If
                                Next
                            End If
                            Call myCShowMessage.ShowUpdatedMsg("SPL " & Trim(tbNoSPL.Text))
                            Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
                        End If
                    End If
                Else
                    Call myCShowMessage.ShowWarning("Lengkapi dulu semua field yang bertanda bintang (*)!")
                    cboPerusahaan.Focus()
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
        Try
            isNew = True
            Call myCFormManipulation.ResetForm(gbDataEntry)
            Call myCFormManipulation.ResetForm(gbDetail)
            Call myCFormManipulation.SetReadOnly(gbDataEntry, False)
            Call myCFormManipulation.SetReadOnly(gbDetail, True, False)
            'tbNoSPL.ReadOnly = True
            tbDeptKepala.ReadOnly = True
            tbDivKepala.ReadOnly = True
            tbBagKepala.ReadOnly = True
            btnSimpan.Enabled = True
            btnTambahkan.Enabled = True
            cboLokasi.SelectedIndex = 0
            'dtpRencanaMulai.Value = New Date(Now.Year, Now.Month, Now.Day, 16, 0, 0)
            'dtpRencanaSelesai.Value = New Date(Now.Year, Now.Month, Now.Day, 17, 0, 0)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCreateNew_Click Error")
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Try
            Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus SPL " & tbNoSPL.Text & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
            If (isConfirm = DialogResult.Yes) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim foundRows As DataRow()
                Dim queryBuilder As New Text.StringBuilder

                queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameHeader, "",, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'"))
                queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameDetail, "",, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'"))

                If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                    Call myCShowMessage.ShowDeletedMsg("SPL " & Trim(tbNoSPL.Text))
                    foundRows = myDataTableHeader.Select("rid=" & arrDefValues(0))
                    If (foundRows.Count > 0) Then
                        myDataTableHeader.Rows.RemoveAt(myDataTableHeader.Rows.IndexOf(foundRows(0)))
                    End If
                    myDataTableDGVDetail.Clear()
                    Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
                End If
            Else
                Call myCShowMessage.ShowInfo("Penghapusan SPL " & tbNoSPL.Text & " dibatalkan oleh user")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnHapus_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Try
            stSQL = "SELECT h.perusahaan,h.departemen as deptspl,h.periodemulai,h.periodeselesai,h.jumlahpersonil,h." & tableKey & ",h.tanggalpengajuan,h.nipkepala,h.namakepala,h.jumlahpersonil,h.catatan as catheader,d.nip,d.nama,d.departemen,d.divisi,d.bagian,d.pekerjaan,d.rencanajamlembur,d.rencanamulai,d.rencanaselesai,d.realisasijamlembur,d.realisasimulai,d.realisasiselesai,d.catatan as catdetail
                    FROM " & tableNameHeader & " as h inner join " & tableNameDetail & " as d on h." & tableKey & "=d." & tableKey & " " & "
                    WHERE h." & tableKey & " = '" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'
                    ORDER BY d.rencanamulai,d.nama;"
            Dim frmDisplayReport As New FormDisplayReport.FormDisplayReport(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, stSQL, "SPL")
            Call myCFormManipulation.GoToForm(Me.MdiParent, frmDisplayReport)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCetak_Click Error")
        End Try
    End Sub

    Private Sub tbNoSPL_Validated(sender As Object, e As EventArgs) Handles tbNoSPL.Validated
        Try
            tbNoSPL.Text = Trim(tbNoSPL.Text)
            If (tbNoSPL.Text.Length > 0) Then
                tbNoSPL.Text = tbNoSPL.Text.ToUpper

                Call myCDBConnection.OpenConn(CONN_.dbMain)
                isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameHeader, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'")
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                If Not isExist Then
                    lblSPKOke.Text = "√"
                    lblSPKOke.ForeColor = Color.Green
                Else
                    lblSPKOke.Text = "X"
                    lblSPKOke.ForeColor = Color.Red
                    Call myCShowMessage.ShowWarning("No SPK : " & Trim(tbNoSPL.Text) & " sudah terdaftar!" & ControlChars.NewLine & "Silahkan ganti dengan No SPK yang lain")
                End If
                lblSPKOke.Visible = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNoSPK_Validated Error")
        End Try
    End Sub

    Private Sub dtpPeriode_Enter(sender As Object, e As EventArgs) Handles dtpPeriodeMulai.Enter, dtpPeriodeSelesai.Enter
        Try
            initialValue = sender.Value.Date
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpPeriode_Enter Error")
        End Try
    End Sub

    Private Sub dtpPeriode_Validated(sender As Object, e As EventArgs) Handles dtpPeriodeMulai.Validated, dtpPeriodeSelesai.Validated
        Try
            If (sender Is dtpPeriodeMulai) Then
                If (dtpPeriodeMulai.Value.Date > dtpPeriodeSelesai.Value.Date) Then
                    Call myCShowMessage.ShowWarning("Periode mulai tidak boleh lebih dari periode selesai!!")
                    dtpPeriodeMulai.Value = CDate(initialValue)
                Else
                    dtpRencanaMulai.MinDate = Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy")
                    dtpRencanaSelesai.MinDate = Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy")
                End If
            ElseIf (sender Is dtpPeriodeSelesai) Then
                If (dtpPeriodeSelesai.Value.Date < dtpPeriodeMulai.Value.Date) Then
                    Call myCShowMessage.ShowWarning("Periode selesai tidak boleh kurang dari periode mulai!!")
                    dtpPeriodeSelesai.Value = CDate(initialValue)
                Else
                    dtpRencanaMulai.MaxDate = Format(dtpPeriodeSelesai.Value.Date.AddDays(1), "dd-MMM-yyyy")
                    dtpRencanaSelesai.MaxDate = Format(dtpPeriodeSelesai.Value.Date.AddDays(1), "dd-MMM-yyyy")

                    dtpRencanaMulai.Value = dtpPeriodeMulai.Value
                    dtpRencanaSelesai.Value = dtpPeriodeMulai.Value
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpPeriode_Validated Error")
        End Try
    End Sub
End Class