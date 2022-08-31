Public Class FormIjinAbsen
    Private isDataPrepared As Boolean
    Private stSQL As String
    Private isNew As Boolean
    Private isExist As Boolean
    Private myDataTableDGV As New DataTable
    Private myBindingTableDGV As New BindingSource
    Private updateString As String
    Private newValues As String
    Private newFields As String
    Private banyakPages As Integer
    Private logRecordPage As Integer
    Private mCari As String
    Private cmbDgvHapusButton As New DataGridViewButtonColumn()
    Private cmbDgvEditButton As New DataGridViewButtonColumn()
    Private cmbDgvCetakButton As New DataGridViewButtonColumn()
    Private cmbDgvAttachmentButton As New DataGridViewButtonColumn()
    Private cekTambahButton(3) As Boolean
    Private arrDefValues(14) As String
    Private tableName As String

    Private myDataTableCboKaryawan As New DataTable
    Private myBindingKaryawan As New BindingSource
    Private myDataTableCboAbsen As New DataTable
    Private myBindingAbsen As New BindingSource
    Private myDataTableCboMohonIjin As New DataTable
    Private myBindingMohonIjin As New BindingSource
    Private myDataTableCboJabatan As New DataTable
    Private myBindingJabatan As New BindingSource

    Private isBinding As Boolean
    Private isCboPrepared As Boolean
    Private strKDR As String
    Private digitLength As Integer
    Private enableSubForm(0) As Boolean

    'Private WithEvents tbCellText As New DataGridViewTextBoxEditingControl

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaHRD As String, _connMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String, _lokasi As String)
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
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormIjinAbsen Error")
        End Try
    End Sub

    Private Sub FormIjinAbsen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormIjinAbsen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"IDK", "TANGGAL MULAI", "TANGGAL SELESAI", "NIP", "NAMA"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 1

            lblAbsen.Visible = False
            cboAbsen.Visible = False

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT concat(nama,' || ',nip) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian FROM " & CONN_.schemaHRD & ".mskaryawanaktif " & IIf(USER_.lokasi = "ALL", "", "WHERE (lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " GROUP BY concat(nama,' || ',nip),idk,nip,nama,perusahaan,departemen,divisi,bagian ORDER BY karyawan;"
            'stSQL = "SELECT concat(tbl.nama,' || ',tbl.nip) as karyawan,tbl.idk,tbl.nip,tbl.nama,tbl.perusahaan,tbl.departemen,tbl.divisi,tbl.bagian FROM " & CONN_.schemaHRD & ".mskaryawanaktif as tbl " & IIf(USER_.lokasi = "ALL", "", "WHERE (tbl.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "' OR tbl.lokasi is null)") & " GROUP BY concat(tbl.nama,' || ',tbl.nip),tbl.idk,tbl.nip,tbl.nama,tbl.perusahaan,tbl.departemen,tbl.divisi,tbl.bagian ORDER BY karyawan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared)

            stSQL = "SELECT concat(kode,' || ',keterangan) as mohonijin,kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='mohonijin' order by mohonijin;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboMohonIjin, myBindingMohonIjin, cboMohonIjin, "T_" & cboMohonIjin.Name, "kode", "mohonijin", isCboPrepared)

            stSQL = "SELECT concat(kode,' || ',keterangan) as absen,kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='absen' order by absen;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboAbsen, myBindingAbsen, cboAbsen, "T_" & cboAbsen.Name, "kode", "absen", isCboPrepared)

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "load")
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
                foundRows = USER_.T_USER_RIGHT.Select("formname='FormAttachmentDokumen'")
                If (foundRows.Length = 0) Then
                    enableSubForm(0) = False
                Else
                    enableSubForm(0) = True
                End If
            End If

            tableName = CONN_.schemaHRD & ".trijinabsen"
            digitLength = 2

            isDataPrepared = True

            'ATTACHMENT SUDAH DIPINDAH KE DETAILNYA
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormIjinAbsen_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormIjinAbsen_KeyDown(sender As Object, e As KeyEventArgs) Handles cboKaryawan.KeyDown, dtpTanggalPengajuan.KeyDown, cboMohonIjin.KeyDown, cboAbsen.KeyDown, rtbCatatan.KeyDown, dtpTanggalMulai.KeyDown, dtpTanggalSelesai.KeyDown, tbDariJam.KeyDown, tbSampaiJam.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbSampaiJam) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormIjinAbsen_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    Private Sub SetDGV(myConn As Object, myComm As Object, myReader As Object, offSet As Integer, ByRef myDataTable As DataTable, ByRef myBindingTable As BindingSource, mKriteria As String, Optional gantiKriteria As Boolean = False)
        Try
            Dim batas As Integer
            Dim mJumlah As Integer
            Dim mSelectedCriteria As String
            Dim mWhereString As String = Nothing

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")
            mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

            If (mSelectedCriteria = "IDK" Or mSelectedCriteria = "NIP" Or mSelectedCriteria = "NAMA") Then
                mWhereString = "(upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') "
            Else
                mWhereString = "(tbl." & mSelectedCriteria & ">='" & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & "' and tbl." & mSelectedCriteria & "<='" & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy") & "') "
            End If

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                'Dim tampTotalRecords As Integer
                banyakPages = 0
                mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                stSQL = "SELECT count(*) FROM " & tableName & " as tbl inner join " & CONN_.schemaHRD & ".mskaryawanaktif as tbl2 ON tbl.nip=tbl2.nip WHERE " & mWhereString & IIf(USER_.lokasi = "ALL", "", "AND (tbl2.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & ";"
                mJumlah = Integer.Parse(myCDBOperation.GetDataIndividual(myConn, myComm, myReader, stSQL))

                If (mJumlah > 10) Then
                    banyakPages = mJumlah / 10
                Else
                    banyakPages = 1
                End If
                tempSisa = mJumlah Mod 10
                If (tempSisa < 5 And tempSisa > 0 And mJumlah > 10) Then
                    'karena 5 ke atas dibulatkan ke atas
                    'misal 15/10 hasilnya adalah 2
                    'sedangkan kalau 14/10 hasilnya adalah 1
                    'jadi kalau sisanya kurang dari 5, maka halaman ditambah 1
                    banyakPages = banyakPages + 1
                End If
                gantiKriteria = False
            End If
            lblOfPages.Text = "Of: " & banyakPages & " Pages"

            If (mJumlah - offSet < 0) Then
                If (mJumlah <> 0) Then
                    batas = mJumlah Mod 10
                Else
                    Call myCShowMessage.ShowWarning("Belum ada data tersedia", "Perhatian")
                    batas = 10
                End If
            Else
                batas = 10
            End If

            stSQL = "SELECT rid,kdr,tanggalpengajuan as tanggal_pengajuan,nip,nama,tanggalmulai as tanggal_mulai,darijam as dari_jam,tanggalselesai as tanggal_selesai,sampaijam as sampai_jam,kodeijin as kode_ijin,ketijin as ket_ijin,kodeabsen as kode_absen,ketabsen as ket_absen,catatan,idk,posisi,bagian,divisi,departemen,perusahaan,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.kdr,sub.tanggalpengajuan,sub.tanggalmulai,sub.tanggalselesai,sub.darijam,sub.sampaijam,sub.idk,sub.nip,sub.nama,sub.posisi,sub.bagian,sub.divisi,sub.departemen,sub.perusahaan,sub.kodeijin,sub.ketijin,sub.kodeabsen,sub.ketabsen,sub.catatan,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.kdr,tbl.tanggalpengajuan,tbl.tanggalmulai,tbl.tanggalselesai,tbl.darijam,tbl.sampaijam,tbl.idk,tbl.nip,tbl.nama,tbl.posisi,tbl.bagian,tbl.divisi,tbl.departemen,tbl.perusahaan,tbl.kodeijin,tbl.ketijin,tbl.kodeabsen,tbl.ketabsen,tbl.catatan,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName & " as tbl inner join " & CONN_.schemaHRD & ".mskaryawanaktif as tbl2 on tbl.nip=tbl2.nip " &
                            "WHERE " & mWhereString & IIf(USER_.lokasi = "ALL", "", "AND (tbl2.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " " &
                            "ORDER BY (case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC " &
                            "LIMIT " & offSet &
                            ") sub " &
                        "ORDER BY (case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC " &
                        "LIMIT " & batas &
                    ") subOrdered " &
                    "ORDER BY (case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC;"

            myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "TBL " & lblTitle.Text)
            myBindingTable.DataSource = myDataTable

            With dgvView
                .DataSource = myBindingTable
                .ReadOnly = True

                .Columns("rid").Visible = False
                .Columns("kdr").Visible = False

                .Columns("rid").Frozen = True
                .Columns("kdr").Frozen = True
                .Columns("tanggal_pengajuan").Frozen = True
                .Columns("nip").Frozen = True
                .Columns("nama").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("tanggal_pengajuan").Width = 80
                .Columns("idk").Width = 75
                .Columns("nip").Width = 60
                .Columns("nama").Width = 100
                .Columns("tanggal_mulai").Width = 80
                .Columns("dari_jam").Width = 80
                .Columns("tanggal_selesai").Width = 80
                .Columns("sampai_jam").Width = 80
                .Columns("kode_ijin").Width = 80
                .Columns("ket_ijin").Width = 80
                .Columns("kode_absen").Width = 80
                .Columns("ket_absen").Width = 80
                .Columns("catatan").Width = 100
                .Columns("posisi").Width = 100
                .Columns("bagian").Width = 120
                .Columns("divisi").Width = 120
                .Columns("departemen").Width = 120
                .Columns("perusahaan").Width = 130

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

                .Columns("tanggal_pengajuan").HeaderText = "PENGAJUAN"
                .Columns("tanggal_mulai").HeaderText = "MULAI"
                .Columns("tanggal_selesai").HeaderText = "SELESAI"
                .Columns("dari_jam").HeaderText = "DARI"
                .Columns("sampai_jam").HeaderText = "SAMPAI"
                .Columns("kode_ijin").HeaderText = "IJIN"
                .Columns("ket_ijin").HeaderText = "KET IJIN"
                .Columns("kode_absen").HeaderText = "ABSEN"
                .Columns("ket_absen").HeaderText = "KET ABSEN"

                .Columns("tanggal_pengajuan").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tanggal_mulai").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tanggal_selesai").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                .Font = New Font("Arial", 8, FontStyle.Regular)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End With

            'Kalau menampilkan data aktif
            With cmbDgvEditButton
                If Not (cekTambahButton(0)) Then
                    .HeaderText = "EDIT"
                    .Name = "edit"
                    .Text = "Edit"
                    .UseColumnTextForButtonValue = True
                    dgvView.Columns.Add(cmbDgvEditButton)
                    dgvView.Columns("edit").Width = 70
                    cekTambahButton(0) = True
                    .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .DisplayIndex = dgvView.Columns("nama").Index + 1
                    .Frozen = True
                End If
                .HeaderCell.Style.BackColor = Color.Lime
            End With

            With cmbDgvAttachmentButton
                If Not (cekTambahButton(2)) Then
                    .HeaderText = "ATTACHMENT"
                    .Name = "attachment"
                    .Text = "Attachment"
                    .UseColumnTextForButtonValue = True
                    dgvView.Columns.Add(cmbDgvAttachmentButton)
                    dgvView.Columns("attachment").Width = 90
                    cekTambahButton(2) = True
                    .Visible = enableSubForm(0)
                End If
                .HeaderCell.Style.BackColor = Color.Yellow
                .DisplayIndex = dgvView.ColumnCount - 1
            End With

            With cmbDgvCetakButton
                If Not (cekTambahButton(3)) Then
                    .HeaderText = "CETAK"
                    .Name = "cetak"
                    .Text = "Cetak"
                    .UseColumnTextForButtonValue = True
                    dgvView.Columns.Add(cmbDgvCetakButton)
                    dgvView.Columns("cetak").Width = 70
                    cekTambahButton(3) = True
                End If
                .HeaderCell.Style.BackColor = Color.SkyBlue
                .DisplayIndex = dgvView.ColumnCount - 1
            End With

            With cmbDgvHapusButton
                If Not (cekTambahButton(1)) Then
                    .HeaderText = "HAPUS"
                    .Name = "delete"
                    .Text = "Hapus Record"
                    .UseColumnTextForButtonValue = True
                    dgvView.Columns.Add(cmbDgvHapusButton)
                    dgvView.Columns("delete").Width = 100
                    cekTambahButton(1) = True
                    .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                End If
                .HeaderCell.Style.BackColor = Color.LightSalmon
                .DisplayIndex = dgvView.ColumnCount - 1
            End With

            ''untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithPaging(dgvView, (Integer.Parse(tbRecordPage.Text) - 1) * 10)
            dgvView.RowHeadersWidth = 70

            'atur warna selang seling datagrid
            Call myCDataGridViewManipulation.SetDGVColour(dgvView)

            'ATUR PANEL NAVIGASI
            If (tbRecordPage.Text = 1) Then
                'di awal sendiri
                btnFFBack.Enabled = False
                btnBack.Enabled = False
                If (banyakPages > 1) Then
                    btnFFForward.Enabled = True
                    btnForward.Enabled = True
                Else
                    btnFFForward.Enabled = False
                    btnForward.Enabled = False
                End If
            ElseIf (tbRecordPage.Text > 1) Then
                'di tengah2 halaman record
                btnBack.Enabled = True
                If (tbRecordPage.Text < banyakPages) Then
                    btnFFBack.Enabled = True
                    btnFFForward.Enabled = True
                    btnForward.Enabled = True
                Else
                    btnFFBack.Enabled = True
                    btnFFForward.Enabled = False
                    btnForward.Enabled = False
                End If
            End If

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetDGV Error")
        Finally
            Call myCDBConnection.CloseConn(myConn, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvView_Sorted(sender As Object, e As EventArgs) Handles dgvView.Sorted
        Try
            ''untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithPaging(dgvView, (Integer.Parse(tbRecordPage.Text) - 1) * 10)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_Sorted Error")
        End Try
    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        Try
            mCari = myCStringManipulation.SafeSqlLiteral(tbCari.Text, 1)
            tbRecordPage.Text = 1
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTampilkan_Click Error")
        End Try
    End Sub

    Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
        Try
            isNew = True
            lblEntryType.Text = "INSERT NEW"
            isDataPrepared = True

            cboKaryawan.Enabled = True

            isBinding = False
            tbPerusahaan.DataBindings.Clear()
            tbDepartemen.DataBindings.Clear()
            tbDivisi.DataBindings.Clear()
            tbBagian.DataBindings.Clear()

            tbDariJam.Text = "08:00"
            tbSampaiJam.Text = "17:00"

            If (cboKaryawan.SelectedIndex <> -1) Then
                'Buat ambil KDR
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "kdr", "rid", dtpTanggalMulai.Value.Date, cboKaryawan.SelectedValue, digitLength, CONN_.dbType).ToUpper
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCreateNew_Click Error")
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Try
            If (Integer.Parse(tbRecordPage.Text) - 1 > 0) Then
                tbRecordPage.Text = Integer.Parse(tbRecordPage.Text) - 1
                logRecordPage = tbRecordPage.Text
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, myDataTableDGV, myBindingTableDGV, mCari, True)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles btnForward.Click
        Try
            If (Integer.Parse(tbRecordPage.Text) + 1 <= banyakPages) Then
                tbRecordPage.Text = Integer.Parse(tbRecordPage.Text) + 1
                logRecordPage = tbRecordPage.Text
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, myDataTableDGV, myBindingTableDGV, mCari, True)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnForward_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFBack_Click(sender As Object, e As EventArgs) Handles btnFFBack.Click
        Try
            tbRecordPage.Text = 1
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFForward_Click(sender As Object, e As EventArgs) Handles btnFFForward.Click
        Try
            tbRecordPage.Text = banyakPages
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, banyakPages * 10, myDataTableDGV, myBindingTableDGV, mCari, True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFForward_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub tbRecordPage_GotFocus(sender As Object, e As EventArgs) Handles tbRecordPage.GotFocus
        Try
            logRecordPage = tbRecordPage.Text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbRecordPage_GotFocus Error")
        End Try
    End Sub

    Private Sub tbRecordPage_Validated(sender As Object, e As EventArgs) Handles tbRecordPage.Validated
        Try
            If (IsNumeric(tbRecordPage.Text)) Then
                Dim temp As Integer
                temp = Integer.Parse(tbRecordPage.Text)
                If (temp > 0 And temp <= banyakPages) Then
                    Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, temp * 10, myDataTableDGV, myBindingTableDGV, mCari, True)
                    logRecordPage = tbRecordPage.Text
                Else
                    Call myCShowMessage.ShowWarning("Tidak ada record pada halaman tersebut!", "Perhatian")
                    tbRecordPage.Text = logRecordPage
                End If
            Else
                Call myCShowMessage.ShowWarning("Inputan harus berupa angka saja", "Perhatian")
                tbRecordPage.Text = logRecordPage
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbRecordPage_Validated Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    'Private Sub dgvView_EditingControlShowing(sender As Object, e As EventArgs) Handles dgvView.EditingControlShowing
    '    Try
    '        If (dgvView.CurrentCell.ColumnIndex = dgvView.Columns("mulai").Index Or dgvView.CurrentCell.ColumnIndex = dgvView.Columns("selesai").Index) Then
    '            tbCellText = CType(dgvView.EditingControl, DataGridViewTextBoxEditingControl)
    '        End If
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_EditingControlShowing Error")
    '    End Try
    'End Sub

    'Private Sub tbCellText_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tbCellText.KeyUp
    '    Try
    '        'If (Trim(tbCellText.Text).Length = 4) Then
    '        If (tbCellText.Text.Contains(".")) Then
    '            Dim mCellSelection As Integer
    '            mCellSelection = tbCellText.SelectionStart
    '            tbCellText.Text = tbCellText.Text.Replace(".", ":")
    '            tbCellText.SelectionStart = mCellSelection
    '        End If

    '        'End If
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbCellText_KeyUp Error")
    '    End Try
    'End Sub

    Private Sub dgvView_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvView.CellMouseDown
        Try
            'if di bawah ditambahkan pada 3 feb 2012 agar bisa pilih full row lebih dari 1,
            'karena kalau tidak ada if dibawah maka apabila sudah pilih full row pakai klik kiri
            'anggap saja mau pilih 3 full row, lalu di klik kanan, maka hanya row terakhir yang akan terpilih
            'oleh karena itu diberi if row yang dipilih tidak lebih dari 1, jadi klw milih banyak, fungsi di dalam if tidak akan dijalankan
            'dengan kata lain pada kasus ini klik kanan hanya untuk menampilkan konteks menu.
            'singkatnya, kalau sudah ada full row yang terpilih, maka fungsi di event ini tidak akan dijalankan
            If Not (dgvView.SelectedRows.Count > 1) Then
                'fungsi ini ditujukan agar user bisa memilih cell dengan klik kanan juga
                If e.Button = MouseButtons.Right Then
                    If e.ColumnIndex = -1 = False And e.RowIndex = -1 = False Then
                        'kondisi ini untuk kalau user meng-klik kanan dalam area dgv bukan di header2nya
                        dgvView.ClearSelection()
                        dgvView.CurrentCell = dgvView.Item(e.ColumnIndex, e.RowIndex)
                        dgvView.Rows(e.RowIndex).Selected = True
                    Else
                        'kondisi ini untuk kalau user mengklik di header dgv nya
                        'selected cell sebelumnya di clear dulu
                        dgvView.ClearSelection()
                        'untuk mindah pointer
                        dgvView.CurrentCell = dgvView.Item(1, e.RowIndex)
                        'untuk select 1 baris penuh
                        dgvView.Rows(e.RowIndex).Selected = True
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellMouseDown Error")
        End Try
    End Sub

    Private Sub dgvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellContentClick
        Try
            If (dgvView.RowCount > 0) Then
                If (e.RowIndex = -1) Then
                    Exit Sub
                End If

                If (e.ColumnIndex = dgvView.Columns("delete").Index) Then
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus ijin absen " & dgvView.CurrentRow.Cells("nama").Value & " dari tanggal " & Format(dgvView.CurrentRow.Cells("tanggal_mulai").Value, "dd-MMM-yyyy") & " sampai tanggal " & Format(dgvView.CurrentRow.Cells("tanggal_selesai").Value, "dd-MMM-yyyy") & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = DialogResult.Yes) Then
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName, "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                        Call myCShowMessage.ShowDeletedMsg("Ijin absen " & dgvView.CurrentRow.Cells("nama").Value & " dari tanggal " & Format(dgvView.CurrentRow.Cells("tanggal_mulai").Value, "dd-MMM-yyyy") & " sampai tanggal " & Format(dgvView.CurrentRow.Cells("tanggal_selesai").Value, "dd-MMM-yyyy"))
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan ijin absen " & dgvView.CurrentRow.Cells("nama").Value & " dari tanggal " & Format(dgvView.CurrentRow.Cells("tanggal_mulai").Value, "dd-MMM-yyyy") & " sampai tanggal " & Format(dgvView.CurrentRow.Cells("tanggal_selesai").Value, "dd-MMM-yyyy") & " dibatalkan oleh user")
                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("attachment").Index) Then
                    'Dim frmAttachmentKaryawan As New FormAttachmentKaryawan.FormAttachmentKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, dgvView.CurrentRow.Cells("idk").Value, dgvView.CurrentRow.Cells("nama").Value, dgvView.CurrentRow.Cells("nip").Value)
                    'Call myCFormManipulation.GoToForm(Me.MdiParent, frmAttachmentKaryawan)
                    Dim frmAttachmentDokumen As New FormAttachmentDokumen.FormAttachmentDokumen(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, Trim(lblTitle.Text.Replace("MASTER", "")), Trim(dgvView.CurrentRow.Cells("kdr").Value), Trim(dgvView.CurrentRow.Cells("nip").Value), Format(dgvView.CurrentRow.Cells("tanggal_mulai").Value, "ddMMMyyyy") & "_" & Format(dgvView.CurrentRow.Cells("tanggal_selesai").Value, "ddMMMyyyy"))
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmAttachmentDokumen)
                ElseIf (e.ColumnIndex = dgvView.Columns("cetak").Index) Then
                    stSQL = "SELECT nip,nama,posisi,perusahaan,departemen,divisi,bagian,tanggalpengajuan,tanggalmulai,tanggalselesai,darijam,sampaijam,kodeijin,ketijin,kodeabsen,ketabsen,catatan
                            FROM " & tableName & "
                            WHERE rid = " & dgvView.CurrentRow.Cells("rid").Value & "
                            ORDER BY nama,tanggalmulai,darijam;"
                    Dim frmDisplayReport As New FormDisplayReport.FormDisplayReport(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, stSQL, "IjinAbsen")
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmDisplayReport)
                ElseIf (e.ColumnIndex = dgvView.Columns("edit").Index) Then
                    isNew = False
                    lblEntryType.Text = "EDIT"
                    isDataPrepared = False
                    Call myCFormManipulation.ResetForm(gbDataEntry)
                    Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "edit")

                    For i As Integer = 0 To arrDefValues.Count - 1
                        arrDefValues(i) = Nothing
                    Next

                    'RecID
                    arrDefValues(0) = dgvView.CurrentRow.Cells("rid").Value
                    'Karyawan
                    'INI TIDAK BOLEH DI EDIT
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nip").Value) Then
                        For i As Integer = 0 To cboKaryawan.Items.Count - 1
                            If (DirectCast(cboKaryawan.Items(i), DataRowView).Item("nip") = dgvView.CurrentRow.Cells("nip").Value) Then
                                cboKaryawan.SelectedIndex = i
                                arrDefValues(1) = dgvView.CurrentRow.Cells("idk").Value
                                arrDefValues(2) = dgvView.CurrentRow.Cells("nip").Value
                                arrDefValues(3) = dgvView.CurrentRow.Cells("nama").Value

                                'Ambil Jabatan
                                Call myCDBConnection.OpenConn(CONN_.dbMain)
                                stSQL = "SELECT posisi FROM " & CONN_.schemaHRD & ".msposisikaryawan where nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "' and aktif='True' order by posisi;"
                                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboJabatan, myBindingJabatan, cboJabatan, "T_" & cboJabatan.Name, "posisi", "posisi", isCboPrepared)
                                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                            End If
                        Next
                        cboKaryawan.Enabled = False
                    End If
                    'Perusahaan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("perusahaan").Value) Then
                        tbPerusahaan.Text = dgvView.CurrentRow.Cells("perusahaan").Value
                    End If
                    'Departemen
                    If Not IsDBNull(dgvView.CurrentRow.Cells("departemen").Value) Then
                        tbDepartemen.Text = dgvView.CurrentRow.Cells("departemen").Value
                    End If
                    'Divisi
                    If Not IsDBNull(dgvView.CurrentRow.Cells("divisi").Value) Then
                        tbDivisi.Text = dgvView.CurrentRow.Cells("divisi").Value
                    End If
                    'Bagian
                    If Not IsDBNull(dgvView.CurrentRow.Cells("bagian").Value) Then
                        tbBagian.Text = dgvView.CurrentRow.Cells("bagian").Value
                    End If
                    'Tanggal Pengajuan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal_pengajuan").Value) Then
                        'Tanggal pengajuan juga tidak boleh di edit
                        dtpTanggalPengajuan.Value = dgvView.CurrentRow.Cells("tanggal_pengajuan").Value
                        arrDefValues(4) = dgvView.CurrentRow.Cells("tanggal_pengajuan").Value
                        'dtpTanggalPengajuan.Enabled = False
                    End If
                    'Mohon Ijin
                    If Not IsDBNull(dgvView.CurrentRow.Cells("kode_ijin").Value) Then
                        For i As Integer = 0 To cboMohonIjin.Items.Count - 1
                            If (DirectCast(cboMohonIjin.Items(i), DataRowView).Item("kode") = dgvView.CurrentRow.Cells("kode_ijin").Value) Then
                                cboMohonIjin.SelectedIndex = i
                                arrDefValues(5) = dgvView.CurrentRow.Cells("kode_ijin").Value
                                arrDefValues(6) = dgvView.CurrentRow.Cells("ket_ijin").Value
                            End If
                        Next
                        cboKaryawan.Enabled = False
                    End If
                    'Absen
                    If Not IsDBNull(dgvView.CurrentRow.Cells("kode_absen").Value) Then
                        For i As Integer = 0 To cboAbsen.Items.Count - 1
                            If (DirectCast(cboAbsen.Items(i), DataRowView).Item("kode") = dgvView.CurrentRow.Cells("kode_absen").Value) Then
                                cboAbsen.SelectedIndex = i
                                arrDefValues(7) = dgvView.CurrentRow.Cells("kode_absen").Value
                                arrDefValues(8) = dgvView.CurrentRow.Cells("ket_absen").Value
                            End If
                        Next
                        cboKaryawan.Enabled = False
                    End If
                    'Catatan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("catatan").Value) Then
                        rtbCatatan.Text = dgvView.CurrentRow.Cells("catatan").Value
                        arrDefValues(9) = dgvView.CurrentRow.Cells("catatan").Value
                    End If
                    'Tanggal Mulai
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal_mulai").Value) Then
                        dtpTanggalMulai.Value = dgvView.CurrentRow.Cells("tanggal_mulai").Value
                        arrDefValues(10) = dgvView.CurrentRow.Cells("tanggal_mulai").Value
                    End If
                    'Tanggal Selesai
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal_selesai").Value) Then
                        dtpTanggalSelesai.Value = dgvView.CurrentRow.Cells("tanggal_selesai").Value
                        arrDefValues(11) = dgvView.CurrentRow.Cells("tanggal_selesai").Value
                    End If
                    'Jam Mulai
                    If Not IsDBNull(dgvView.CurrentRow.Cells("dari_jam").Value) Then
                        tbDariJam.Text = dgvView.CurrentRow.Cells("dari_jam").Value.ToString
                        arrDefValues(12) = dgvView.CurrentRow.Cells("dari_jam").Value.ToString
                    End If
                    'Jam Selesai
                    If Not IsDBNull(dgvView.CurrentRow.Cells("sampai_jam").Value) Then
                        tbSampaiJam.Text = dgvView.CurrentRow.Cells("sampai_jam").Value.ToString
                        arrDefValues(13) = dgvView.CurrentRow.Cells("sampai_jam").Value.ToString
                    End If
                    'Posisi
                    If Not IsDBNull(dgvView.CurrentRow.Cells("posisi").Value) Then
                        For i As Integer = 0 To cboJabatan.Items.Count - 1
                            If (DirectCast(cboJabatan.Items(i), DataRowView).Item("posisi") = dgvView.CurrentRow.Cells("posisi").Value) Then
                                cboJabatan.SelectedIndex = i
                                arrDefValues(14) = dgvView.CurrentRow.Cells("posisi").Value
                            End If
                        Next
                        cboKaryawan.Enabled = False
                    End If
                    isDataPrepared = True
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellContentClick Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If (cboKaryawan.SelectedIndex <> -1 And cboMohonIjin.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                'Dim created_at As Date
                'created_at = Now
                'ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                Dim lanjut As Boolean
                Dim lanjut2 As Boolean
                Dim tanggalTerakhirBekerja As String
                If (cboMohonIjin.SelectedValue = "TM") Then
                    'kalau ijinnya tidak masuk bekerja,
                    'Maka harus cek ket absennya
                    If (cboAbsen.SelectedIndex <> -1) Then
                        lanjut = True
                    Else
                        lanjut = False
                    End If
                Else
                    'Kalau bukan tidak masuk bekerja, maka gak perlu cek keterangan absennya
                    lanjut = True
                End If

                If (lanjut) Then
                    stSQL = "SELECT tanggalterakhirbekerja FROM " & CONN_.schemaHRD & ".mskaryawan WHERE idk='" & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("idk") & "' and statusbekerja<>'AKTIF';"
                    tanggalTerakhirBekerja = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                    If Not IsNothing(tanggalTerakhirBekerja) Then
                        'Jika tanggal terakhir bekerja ada isinya, maka berarti statusbekerjanya sudah tidak aktif lagi
                        'Maka harus di cek tanggal terakhir bekerjanya tanggal berapa
                        If (dtpTanggalMulai.Value.Date <= Date.Parse(tanggalTerakhirBekerja) And dtpTanggalSelesai.Value.Date <= Date.Parse(tanggalTerakhirBekerja)) Then
                            lanjut2 = True
                        Else
                            lanjut2 = False
                        End If
                    Else
                        lanjut2 = True
                    End If

                    If (lanjut2) Then
                        If isNew Then
                            'CREATE NEW
                            isExist = True
                            While isExist
                                'Buat memastikan KDR tidak kembar
                                strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "kdr", "rid", dtpTanggalMulai.Value.Date, cboKaryawan.SelectedValue, digitLength, CONN_.dbType).ToUpper
                                isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "kdr='" & myCStringManipulation.SafeSqlLiteral(strKDR) & "'")
                            End While
                            If Not isExist Then
                                newValues = "'" & strKDR & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("idk")) & "','" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & "','" & Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(tbPerusahaan.Text) & "','" & myCStringManipulation.SafeSqlLiteral(cboMohonIjin.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboMohonIjin.SelectedItem, DataRowView).Item("keterangan")) & "','" & Format(dtpTanggalMulai.Value.Date, "dd-MMM-yyyy") & "','" & Format(dtpTanggalSelesai.Value.Date, "dd-MMM-yyyy") & "','" & tbDariJam.Text & "','" & tbSampaiJam.Text & "'," & ADD_INFO_.newValues
                                newFields = "kdr,idk,nip,nama,tanggalpengajuan,perusahaan,kodeijin,ketijin,tanggalmulai,tanggalselesai,darijam,sampaijam," & ADD_INFO_.newFields
                                If (cboMohonIjin.SelectedValue = "TM") Then
                                    'Jika Tidak Masuk Bekerja, maka cek combo box absen
                                    If (cboAbsen.SelectedIndex <> -1) Then
                                        newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboAbsen.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboAbsen.SelectedItem, DataRowView).Item("keterangan")) & "'"
                                        newFields &= ",kodeabsen,ketabsen"
                                    End If
                                End If
                                If (cboJabatan.SelectedIndex <> -1) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboJabatan.SelectedValue) & "'"
                                    newFields &= ",posisi"
                                End If
                                If Trim(tbDepartemen.Text).Length > 0 Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbDepartemen.Text) & "'"
                                    newFields &= ",departemen"
                                End If
                                If Trim(tbDivisi.Text).Length > 0 Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbDivisi.Text) & "'"
                                    newFields &= ",divisi"
                                End If
                                If Trim(tbBagian.Text).Length > 0 Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbBagian.Text) & "'"
                                    newFields &= ",bagian"
                                End If
                                If Trim(rtbCatatan.Text).Length > 0 Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(rtbCatatan.Text) & "'"
                                    newFields &= ",catatan"
                                End If
                                Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName, newValues, newFields)
                                Call myCShowMessage.ShowSavedMsg("Ijin absen " & Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di tanggal " & Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy"))
                                Call btnTampilkan_Click(sender, e)

                                Call myCFormManipulation.ResetForm(gbDataEntry)
                                Call btnCreateNew_Click(sender, e)
                            Else
                                'Gak mungkin masuk sini harusnya
                                Call myCShowMessage.ShowWarning("Ijin absen " & Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di tanggal " & Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy") & " sudah ada!!")
                            End If
                        Else
                            'UDPATE
                            Dim foundRows() As DataRow
                            updateString = Nothing
                            foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                            If (arrDefValues(4) <> dtpTanggalPengajuan.Value.Date) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "tanggalpengajuan='" & Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy") & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_pengajuan") = dtpTanggalPengajuan.Value.Date
                                End If
                            End If
                            If (arrDefValues(5) <> cboMohonIjin.SelectedValue) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "kodeijin='" & myCStringManipulation.SafeSqlLiteral(cboMohonIjin.SelectedValue) & "',ketijin='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboMohonIjin.SelectedItem, DataRowView).Item("keterangan")) & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kode_ijin") = Trim(cboMohonIjin.SelectedValue)
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("ket_ijin") = Trim(DirectCast(cboMohonIjin.SelectedItem, DataRowView).Item("keterangan"))
                                End If
                            End If
                            If (cboMohonIjin.SelectedValue = "TM") Then
                                If (arrDefValues(7) <> cboAbsen.SelectedValue) Then
                                    updateString &= IIf(IsNothing(updateString), "", ",") & "kodeabsen=" & IIf(IsNothing(cboAbsen.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboAbsen.SelectedValue) & "'") & ",ketabsen=" & IIf(IsNothing(cboAbsen.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboAbsen.SelectedItem, DataRowView).Item("keterangan")) & "'")
                                    If (foundRows.Length > 0) Then
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kode_absen") = Trim(cboAbsen.SelectedValue)
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("ket_absen") = Trim(DirectCast(cboAbsen.SelectedItem, DataRowView).Item("keterangan"))
                                    End If
                                End If
                            Else
                                If Not IsNothing(arrDefValues(7)) Then
                                    updateString &= IIf(IsNothing(updateString), "", ",") & "kodeabsen=Null,ketabsen=Null"
                                    If (foundRows.Length > 0) Then
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kode_absen") = DBNull.Value
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("ket_absen") = DBNull.Value
                                    End If
                                End If
                            End If
                            If (arrDefValues(9) <> Trim(rtbCatatan.Text)) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "catatan=" & IIf(Trim(rtbCatatan.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(rtbCatatan.Text) & "'")
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("catatan") = Trim(rtbCatatan.Text)
                                End If
                            End If
                            If (arrDefValues(10) <> dtpTanggalMulai.Value.Date) Then
                                strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "kdr", "rid", dtpTanggalMulai.Value.Date, cboKaryawan.SelectedValue, digitLength, CONN_.dbType).ToUpper
                                updateString &= IIf(IsNothing(updateString), "", ",") & "kdr='" & strKDR & "',tanggalmulai='" & Format(dtpTanggalMulai.Value.Date, "dd-MMM-yyyy") & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kdr") = strKDR
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_mulai") = dtpTanggalMulai.Value.Date
                                End If
                            End If
                            If (arrDefValues(11) <> dtpTanggalSelesai.Value.Date) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "tanggalselesai='" & Format(dtpTanggalSelesai.Value.Date, "dd-MMM-yyyy") & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_selesai") = dtpTanggalSelesai.Value.Date
                                End If
                            End If
                            If (arrDefValues(12) <> tbDariJam.Text) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "darijam='" & tbDariJam.Text & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("dari_jam") = tbDariJam.Text
                                End If
                            End If
                            If (arrDefValues(13) <> tbSampaiJam.Text) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "sampaijam='" & tbSampaiJam.Text & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("sampai_jam") = tbSampaiJam.Text
                                End If
                            End If
                            If (arrDefValues(14) <> cboJabatan.SelectedValue) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "posisi=" & IIf(IsNothing(cboJabatan.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboJabatan.SelectedValue) & "'")
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("posisi") = Trim(cboJabatan.SelectedValue)
                                End If
                            End If

                            If Not IsNothing(updateString) Then
                                updateString &= "," & ADD_INFO_.updateString
                                'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName, CONN_.dbType)
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, updateString, "rid=" & arrDefValues(0))
                                Call myCShowMessage.ShowUpdatedMsg("Ijin absen " & Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di tanggal " & Format(dtpTanggalPengajuan.Value.Date, "dd-MMM-yyyy"))

                                Call myCFormManipulation.ResetForm(gbDataEntry)
                                Call btnCreateNew_Click(sender, e)
                            Else
                                Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                            End If
                        End If
                        Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "save")
                    Else
                        Call myCShowMessage.ShowWarning("Karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama") & " resign per tanggal " & Format(Date.Parse(tanggalTerakhirBekerja), "dd-MMM-yyyy") & ControlChars.NewLine & "Ijin absen tidak bisa diinputkan setelah tanggal resign tersebut!")
                    End If
                Else
                    Call myCShowMessage.ShowWarning("Kalau mohon ijin Tidak Masuk Bekerja, maka keterangan absennya harus dipilih!!")
                    cboAbsen.Focus()
                End If
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                cboKaryawan.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboKaryawan.Validated, cboAbsen.Validated, cboMohonIjin.Validated, cboJabatan.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
                If (sender Is cboKaryawan) Then
                    myDataTableCboJabatan.Clear()
                    tbPerusahaan.Clear()
                    tbDepartemen.Clear()
                    tbDivisi.Clear()
                    tbBagian.Clear()
                    strKDR = Nothing
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub cboKaryawan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKaryawan.SelectedIndexChanged
        Try
            'If isNew Then
            If (isDataPrepared) Then
                If (cboKaryawan.SelectedIndex <> -1) Then
                    'Buat binding data
                    If Not (isBinding) Then
                        tbPerusahaan.DataBindings.Add(New Binding("text", myBindingKaryawan, "perusahaan"))
                        tbDepartemen.DataBindings.Add(New Binding("text", myBindingKaryawan, "departemen"))
                        tbDivisi.DataBindings.Add(New Binding("text", myBindingKaryawan, "divisi"))
                        tbBagian.DataBindings.Add(New Binding("text", myBindingKaryawan, "bagian"))
                        isBinding = True
                    End If

                    'Buat ambil KDR
                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                    strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "kdr", "rid", dtpTanggalMulai.Value.Date, cboKaryawan.SelectedValue, digitLength, CONN_.dbType).ToUpper

                    'Ambil Jabatan
                    stSQL = "SELECT posisi FROM " & CONN_.schemaHRD & ".msposisikaryawan where nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "' and aktif='True' order by posisi;"
                    Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboJabatan, myBindingJabatan, cboJabatan, "T_" & cboJabatan.Name, "posisi", "posisi", isCboPrepared)
                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                Else
                    myDataTableCboJabatan.Clear()
                End If
            End If
            'End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub dtpTanggalIjin_Validated(sender As Object, e As EventArgs) Handles dtpTanggalMulai.Validated, dtpTanggalSelesai.Validated
        Try
            'If isNew Then
            If (isDataPrepared) Then
                If (cboKaryawan.SelectedIndex <> -1) Then
                    'Buat ambil KDR
                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                    strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "kdr", "rid", dtpTanggalMulai.Value.Date, cboKaryawan.SelectedValue, digitLength, CONN_.dbType).ToUpper
                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                End If
                If (dtpTanggalMulai.Value.Date > dtpTanggalSelesai.Value.Date) Then
                    If (sender Is dtpTanggalMulai) Then
                        dtpTanggalSelesai.Value = dtpTanggalMulai.Value
                    Else
                        dtpTanggalMulai.Value = dtpTanggalSelesai.Value
                    End If
                End If
            End If
            'End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpTanggalIjin_Validated Error")
        End Try
    End Sub

    Private Sub cboMohonIjin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMohonIjin.SelectedIndexChanged
        Try
            If (isCboPrepared) Then
                If (cboMohonIjin.SelectedValue = "TM") Then
                    'Tidak Masuk Bekerja
                    lblAbsen.Visible = True
                    cboAbsen.Visible = True
                Else
                    cboAbsen.SelectedIndex = -1
                    lblAbsen.Visible = False
                    cboAbsen.Visible = False
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboMohonIjin_SelectedIndexChanged Error")
        End Try
    End Sub

    Private Sub tbJam_Validated(sender As Object, e As EventArgs) Handles tbDariJam.Validated, tbSampaiJam.Validated
        Try
            tbDariJam.Text = tbDariJam.Text.Replace(".", ":")
            sender.Text = myCStringManipulation.CleanInputTime(sender.Text)
            If (Trim(sender.text).Length = 0) Then
                If (sender Is tbDariJam) Then
                    sender.text = "08:00"
                Else
                    sender.text = "17:00"
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbJam_Validated Error")
        End Try
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Try
            stSQL = "SELECT i.kdr,i.nip,i.nama,i.posisi,i.tanggalpengajuan,i.perusahaan,i.departemen,i.divisi,i.bagian,i.tanggalmulai,i.tanggalselesai,i.darijam,i.sampaijam,i.kodeijin,i.ketijin,i.kodeabsen,i.ketabsen,i.catatan,j.pathtofile,j.keterangan 
                    FROM " & tableName & " as i left join " & CONN_.schemaHRD & ".attachmentdokumen as j on i.kdr=j.nodokumen and j.jenisdokumen='" & Trim(lblTitle.Text.Replace("MASTER", "")) & "' 
                    WHERE i.kodeijin='TM' and tanggalmulai>='" & Format(dtpTanggalMulaiCetak.Value.Date, "dd-MMM-yyyy") & "' and tanggalselesai<='" & Format(dtpTanggalSelesaiCetak.Value.Date, "dd-MMM-yyyy") & "';"
            Dim frmDisplayReport As New FormDisplayReport.FormDisplayReport(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, stSQL, "RekapIjinAbsen")
            Call myCFormManipulation.GoToForm(Me.MdiParent, frmDisplayReport)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCetak_Click Error")
        End Try
    End Sub

    Private Sub rtbCatatan_Validated(sender As Object, e As EventArgs) Handles rtbCatatan.Validated
        Try
            rtbCatatan.Text = Trim(rtbCatatan.Text).ToUpper
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCetak_Click Error")
        End Try
    End Sub

    Private Sub cboKriteria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKriteria.SelectedIndexChanged
        Try
            If (cboKriteria.SelectedItem = "TANGGAL MULAI" Or cboKriteria.SelectedItem = "TANGGAL SELESAI") Then
                pnlTanggal.Visible = True
                tbCari.Visible = False
            Else
                pnlTanggal.Visible = False
                tbCari.Visible = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboKriteria_SelectedIndexChanged Error")
        End Try
    End Sub
End Class
