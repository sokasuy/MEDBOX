Public Class FormMasterKaryawan
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
    Private cmbDgvTanggunganButton As New DataGridViewButtonColumn()
    Private cmbDgvAttachmentButton As New DataGridViewButtonColumn()
    Private cekTambahButton(3) As Boolean
    Private arrDefValues(25) As String
    Private tableName As String

    Private myDataTableCboAgama As New DataTable
    Private myBindingAgama As New BindingSource
    Private myDataTableCboGolDarah As New DataTable
    Private myBindingGolDarah As New BindingSource
    Private myDataTableCboPendidikan As New DataTable
    Private myBindingPendidikan As New BindingSource

    Private isCboPrepared As Boolean
    Private strGender As String
    Private strStatus As String
    Private strStatusBekerja As String
    Private strBPJSTK As String
    Private digitLength As Integer

    Public Sub New(_dbType As String, _ConnMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValue As String, _addNewFields As String, _addUpdateString As String)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            isDataPrepared = False
            With CONN_
                .dbType = _dbType
                .dbMain = _ConnMain
            End With
            With USER_
                .username = _username
                .isSuperuser = _superuser
                .T_USER_RIGHT = _dtTableUserRights
            End With
            With ADD_INFO_
                .newValues = _addNewValue
                .newFields = _addNewFields
                .updateString = _addUpdateString
            End With
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterKaryawan Error")
        End Try
    End Sub

    Private Sub FormMasterKaryawan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub SetIDK(_conn As Object, _comm As Object, _reader As Object, _tblName As String, _kodeField As String, _idField As String, _prefixKode As String, _digitLength As Integer, _incDate As Boolean, _dateValue As Date, _dbType As String)
        Try
            Call myCDBConnection.OpenConn(CONN_.dbMain)
            If (_prefixKode = "Pria") Then
                _prefixKode = "PRA"
            ElseIf (_prefixKode = "Wanita") Then
                _prefixKode = "WNT"
            End If
            tbIDK.Text = myCDBOperation.SetDynamicAutoKode(_conn, _comm, _reader, _tblName, _kodeField, _idField, _prefixKode, _digitLength, _incDate, _dateValue, _dbType)

            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetIDK Error")
        End Try
    End Sub

    Private Sub FormMasterKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"IDK", "NIK", "NAMA", "ALAMAT", "STATUS"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            lblTanggalBerhentiKerja.Visible = False
            dtpBerhentiKerja.Visible = False

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT keterangan FROM msgeneral where kategori='agama' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboAgama, myBindingAgama, cboAgama, "T_" & cboAgama.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT keterangan FROM msgeneral where kategori='goldarah' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboGolDarah, myBindingGolDarah, cboGolDarah, "T_" & cboGolDarah.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT keterangan FROM msgeneral where kategori='pendidikan' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPendidikan, myBindingPendidikan, cboPendidikan, "T_" & cboPendidikan.Name, "keterangan", "keterangan", isCboPrepared)

            Call myCMiscFunction.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call SetButtonSimpanAvailabilty("load")

            tableName = "mskaryawan"
            digitLength = 3

            isDataPrepared = True

            rbPria.Checked = True
            Call SetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "idk", "rid", strGender, digitLength, True, dtpTanggalMasuk.Value.Date, CONN_.dbType)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterKaryawan_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormMasterKaryawan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbIDK.KeyDown, dtpTanggalMasuk.KeyDown, dtpBerhentiKerja.KeyDown, tbNIK.KeyDown, tbNama.KeyDown, tbTempatLahir.KeyDown, dtpTanggalLahir.KeyDown, tbAlamat.KeyDown, tbNPWP.KeyDown, tbNamaBerdasarNPWP.KeyDown, tbAlamatBerdasarNPWP.KeyDown, tbNoKK.KeyDown, cboAgama.KeyDown, cboGolDarah.KeyDown, tbNoHP.KeyDown, tbEmail.KeyDown, cboPendidikan.KeyDown, tbTahunLulus.KeyDown, tbLulusanDari.KeyDown, tbBPJSKesehatan.KeyDown, tbJaminan.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbJaminan) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterBarang_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    Private Sub SetButtonSimpanAvailabilty(action As String)
        Try
            Dim idx As Integer

            'Hanya index 1 dan 2 saja yang bisa melakukan save
            Select Case action
                Case "load", "save"
                    idx = clbUserRight.Items.IndexOf("Menambah")
                Case "edit"
                    idx = clbUserRight.Items.IndexOf("Memperbaharui")
            End Select

            If (clbUserRight.GetItemChecked(idx)) Then
                btnSimpan.Enabled = True
            Else
                btnSimpan.Enabled = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetButtonSimpanAvailabilty Error")
        End Try
    End Sub

    Private Sub SetDGV(myConn As Object, myComm As Object, myReader As Object, offSet As Integer, ByRef myDataTable As DataTable, ByRef myBindingTable As BindingSource, mKriteria As String, Optional gantiKriteria As Boolean = False)
        Try
            Dim batas As Integer
            Dim mJumlah As Integer
            Dim mSelectedCriteria As String

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                'Dim tampTotalRecords As Integer
                banyakPages = 0
                mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                stSQL = "SELECT count(*) FROM " & tableName & " WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%'));"
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

            stSQL = "SELECT rid,idk,nik,nama,jeniskelamin as jenis_kelamin,alamat,tempatlahir as tempat_lahir,tanggallahir as tanggal_lahir,tanggalmasuk as tanggal_masuk,npwp,namaberdasarnpwp as nama_berdasar_npwp,alamatberdasarnpwp as alamat_berdasar_npwp,nokk as no_kk,status,nohp as no_hp,email,agama,goldarah as gol_darah,pendidikan,lulusandari as lulusan_dari,tahunlulus as tahun_lulus,bpjstk as bpjs_tk,bpjskesehatan as bpjs_kesehatan,jaminan,statusbekerja as status_bekerja,tanggalberhentibekerja as tanggal_berhenti_bekerja,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT Top " & batas & " sub.rid,sub.idk,sub.nik,sub.nama,sub.jeniskelamin,sub.alamat,sub.tempatlahir,sub.tanggallahir,sub.tanggalmasuk,sub.npwp,sub.namaberdasarnpwp,sub.alamatberdasarnpwp,sub.nokk,sub.status,sub.nohp,sub.email,sub.agama,sub.goldarah,sub.pendidikan,sub.lulusandari,sub.tahunlulus,sub.bpjstk,sub.bpjskesehatan,sub.jaminan,sub.statusbekerja,sub.tanggalberhentibekerja,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT TOP " & offSet & " tbl.rid,tbl.idk,tbl.nik,tbl.nama,tbl.jeniskelamin,tbl.alamat,tbl.tempatlahir,tbl.tanggallahir,tbl.tanggalmasuk,tbl.npwp,tbl.namaberdasarnpwp,tbl.alamatberdasarnpwp,tbl.nokk,tbl.status,tbl.nohp,tbl.email,tbl.agama,tbl.goldarah,tbl.pendidikan,tbl.lulusandari,tbl.tahunlulus,tbl.bpjstk,tbl.bpjskesehatan,tbl.jaminan,tbl.statusbekerja,tbl.tanggalberhentibekerja,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName & " as tbl " &
                            "WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " &
                            "ORDER BY (case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC " &
                            ") sub " &
                        "ORDER BY (case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC" &
                    ") subOrdered " &
                    "ORDER BY (case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC;"
            myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "T_Karyawan")
            myBindingTable.DataSource = myDataTable

            With dgvView
                .DataSource = myBindingTable
                .ReadOnly = True

                .Columns("rid").Visible = False

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next

                .Columns("tanggal_lahir").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tanggal_masuk").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tanggal_berhenti_bekerja").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                .Font = New Font("Arial", 9, FontStyle.Regular)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End With

            With cmbDgvEditButton
                If Not (cekTambahButton(0)) Then
                    .HeaderText = "EDIT"
                    .Name = "edit"
                    .Text = "Edit"
                    .UseColumnTextForButtonValue = True
                    dgvView.Columns.Add(cmbDgvEditButton)
                    dgvView.Columns("edit").Width = 70
                    cekTambahButton(0) = True
                    If (clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))) Then
                        .Visible = True
                    Else
                        .Visible = False
                    End If
                End If
                .DisplayIndex = 0
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
                    If (clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))) Then
                        .Visible = True
                    Else
                        .Visible = False
                    End If
                End If
                .DisplayIndex = dgvView.ColumnCount - 1
            End With

            With cmbDgvTanggunganButton
                If Not (cekTambahButton(2)) Then
                    .HeaderText = "TANGGUNGAN"
                    .Name = "tanggungan"
                    .Text = "Tanggungan"
                    .UseColumnTextForButtonValue = True
                    dgvView.Columns.Add(cmbDgvTanggunganButton)
                    dgvView.Columns("tanggungan").Width = 90
                    cekTambahButton(2) = True
                End If
                .DisplayIndex = 1
            End With

            With cmbDgvAttachmentButton
                If Not (cekTambahButton(3)) Then
                    .HeaderText = "ATTACHMENT"
                    .Name = "attachment"
                    .Text = "Attachment"
                    .UseColumnTextForButtonValue = True
                    dgvView.Columns.Add(cmbDgvAttachmentButton)
                    dgvView.Columns("attachment").Width = 90
                    cekTambahButton(3) = True
                End If
                .DisplayIndex = 2
            End With

            ''untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithPaging(dgvView, (Integer.Parse(tbRecordPage.Text) - 1) * 10)

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
            Call SetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "idk", "rid", strGender, digitLength, True, dtpTanggalMasuk.Value.Date, CONN_.dbType)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCreateNew_Click Error")
        End Try
    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
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

    Private Sub btnForward_Click(sender As System.Object, e As System.EventArgs) Handles btnForward.Click
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

    Private Sub btnFFBack_Click(sender As System.Object, e As System.EventArgs) Handles btnFFBack.Click
        Try
            tbRecordPage.Text = 1
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFForward_Click(sender As System.Object, e As System.EventArgs) Handles btnFFForward.Click
        Try
            tbRecordPage.Text = banyakPages
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, banyakPages * 10, myDataTableDGV, myBindingTableDGV, mCari, True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFForward_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub tbRecordPage_GotFocus(sender As System.Object, e As System.EventArgs) Handles tbRecordPage.GotFocus
        Try
            logRecordPage = tbRecordPage.Text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbRecordPage_GotFocus Error")
        End Try
    End Sub

    Private Sub tbRecordPage_Validated(sender As System.Object, e As System.EventArgs) Handles tbRecordPage.Validated
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

    Private Sub dgvView_CellMouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvView.CellMouseDown
        Try
            'if di bawah ditambahkan pada 3 feb 2012 agar bisa pilih full row lebih dari 1,
            'karena kalau tidak ada if dibawah maka apabila sudah pilih full row pakai klik kiri
            'anggap saja mau pilih 3 full row, lalu di klik kanan, maka hanya row terakhir yang akan terpilih
            'oleh karena itu diberi if row yang dipilih tidak lebih dari 1, jadi klw milih banyak, fungsi di dalam if tidak akan dijalankan
            'dengan kata lain pada kasus ini klik kanan hanya untuk menampilkan konteks menu.
            'singkatnya, kalau sudah ada full row yang terpilih, maka fungsi di event ini tidak akan dijalankan
            If Not (dgvView.SelectedRows.Count > 1) Then
                'fungsi ini ditujukan agar user bisa memilih cell dengan klik kanan juga
                If e.Button = Windows.Forms.MouseButtons.Right Then
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
                    Dim isConfirm As Integer
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data karyawan " & dgvView.CurrentRow.Cells("idk").Value & " - " & dgvView.CurrentRow.Cells("nama").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = 6) Then
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName, "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                        Call myCShowMessage.ShowDeletedMsg("Karyawan " & dgvView.CurrentRow.Cells("idk").Value & " - " & dgvView.CurrentRow.Cells("nama").Value)
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan karyawan " & dgvView.CurrentRow.Cells("idk").Value & " - " & dgvView.CurrentRow.Cells("nama").Value & " dibatalkan oleh user")
                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("tanggungan").Index) Then
                    Dim frmMasterTanggunganKaryawan As New FormMasterTanggunganKaryawan.FormMasterTanggunganKaryawan(CONN_.dbType, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, dgvView.CurrentRow.Cells("idk").Value, dgvView.CurrentRow.Cells("nama").Value)
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmMasterTanggunganKaryawan)
                ElseIf (e.ColumnIndex = dgvView.Columns("attachment").Index) Then
                    Dim frmAttachmentKaryawan As New FormAttachmentKaryawan.FormAttachmentKaryawan(CONN_.dbType, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, dgvView.CurrentRow.Cells("idk").Value, dgvView.CurrentRow.Cells("nama").Value)
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmAttachmentKaryawan)
                ElseIf (e.ColumnIndex = dgvView.Columns("edit").Index) Then
                    isNew = False
                    lblEntryType.Text = "EDIT"
                    isDataPrepared = False
                    Call myCMiscFunction.ResetForm(gbDataEntry)
                    Call SetButtonSimpanAvailabilty("edit")

                    For i As Integer = 0 To arrDefValues.Count - 1
                        arrDefValues(i) = Nothing
                    Next

                    'RecID
                    arrDefValues(0) = dgvView.CurrentRow.Cells("rid").Value
                    'IDK
                    If Not IsDBNull(dgvView.CurrentRow.Cells("idk").Value) Then
                        tbIDK.Text = dgvView.CurrentRow.Cells("idk").Value
                        arrDefValues(1) = dgvView.CurrentRow.Cells("idk").Value
                        tbIDK.ReadOnly = True

                        'MsgBox("IDK : " & tbIDK.Text)
                    End If
                    'NIK
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nik").Value) Then
                        tbNIK.Text = dgvView.CurrentRow.Cells("nik").Value
                        arrDefValues(2) = dgvView.CurrentRow.Cells("nik").Value
                    End If
                    'Nama
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nama").Value) Then
                        tbNama.Text = dgvView.CurrentRow.Cells("nama").Value
                        arrDefValues(3) = dgvView.CurrentRow.Cells("nama").Value
                    End If
                    'Jenis Kelamin
                    If Not IsDBNull(dgvView.CurrentRow.Cells("jenis_kelamin").Value) Then
                        If (dgvView.CurrentRow.Cells("jenis_kelamin").Value = "Pria") Then
                            rbPria.Checked = True
                        ElseIf (dgvView.CurrentRow.Cells("jenis_kelamin").Value = "Wanita") Then
                            rbWanita.Checked = True
                        End If
                        arrDefValues(4) = dgvView.CurrentRow.Cells("jenis_kelamin").Value
                        strGender = dgvView.CurrentRow.Cells("jenis_kelamin").Value
                    End If
                    'Alamat
                    If Not IsDBNull(dgvView.CurrentRow.Cells("alamat").Value) Then
                        tbAlamat.Text = dgvView.CurrentRow.Cells("alamat").Value
                        arrDefValues(5) = dgvView.CurrentRow.Cells("alamat").Value
                    End If
                    'Tempat Lahir
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tempat_lahir").Value) Then
                        tbTempatLahir.Text = dgvView.CurrentRow.Cells("tempat_lahir").Value
                        arrDefValues(6) = dgvView.CurrentRow.Cells("tempat_lahir").Value
                    End If
                    'Tanggal Lahir
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal_lahir").Value) Then
                        dtpTanggalLahir.Value = dgvView.CurrentRow.Cells("tanggal_lahir").Value
                        arrDefValues(7) = dgvView.CurrentRow.Cells("tanggal_lahir").Value
                    End If
                    'Tanggal Masuk
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal_masuk").Value) Then
                        dtpTanggalMasuk.Value = Format(dgvView.CurrentRow.Cells("tanggal_masuk").Value, "dd-MMM-yyyy")
                        arrDefValues(8) = dgvView.CurrentRow.Cells("tanggal_masuk").Value
                    End If
                    'NPWP
                    If Not IsDBNull(dgvView.CurrentRow.Cells("npwp").Value) Then
                        tbNPWP.Text = dgvView.CurrentRow.Cells("npwp").Value
                        arrDefValues(9) = dgvView.CurrentRow.Cells("npwp").Value
                    End If
                    'Nama berdasar NPWP
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nama_berdasar_npwp").Value) Then
                        tbNamaBerdasarNPWP.Text = dgvView.CurrentRow.Cells("nama_berdasar_npwp").Value
                        arrDefValues(10) = dgvView.CurrentRow.Cells("nama_berdasar_npwp").Value
                    End If
                    'Alamat berdasar NPWP
                    If Not IsDBNull(dgvView.CurrentRow.Cells("alamat_berdasar_npwp").Value) Then
                        tbAlamatBerdasarNPWP.Text = dgvView.CurrentRow.Cells("alamat_berdasar_npwp").Value
                        arrDefValues(11) = dgvView.CurrentRow.Cells("alamat_berdasar_npwp").Value
                    End If
                    'No KK
                    If Not IsDBNull(dgvView.CurrentRow.Cells("no_kk").Value) Then
                        tbNoKK.Text = dgvView.CurrentRow.Cells("no_kk").Value
                        arrDefValues(12) = dgvView.CurrentRow.Cells("no_kk").Value
                    End If
                    'Status (Single/Menikah)
                    If Not IsDBNull(dgvView.CurrentRow.Cells("status").Value) Then
                        If (dgvView.CurrentRow.Cells("status").Value = "Single") Then
                            rbSingle.Checked = True
                        ElseIf (dgvView.CurrentRow.Cells("status").Value = "Menikah") Then
                            rbMenikah.Checked = True
                        End If
                        arrDefValues(13) = dgvView.CurrentRow.Cells("status").Value
                        strStatus = dgvView.CurrentRow.Cells("status").Value
                    End If
                    'No HP
                    If Not IsDBNull(dgvView.CurrentRow.Cells("no_hp").Value) Then
                        tbNoHP.Text = dgvView.CurrentRow.Cells("no_hp").Value
                        arrDefValues(14) = dgvView.CurrentRow.Cells("no_hp").Value
                    End If
                    'Email
                    If Not IsDBNull(dgvView.CurrentRow.Cells("email").Value) Then
                        tbEmail.Text = dgvView.CurrentRow.Cells("email").Value
                        arrDefValues(15) = dgvView.CurrentRow.Cells("email").Value
                    End If
                    'Agama
                    If Not IsDBNull(dgvView.CurrentRow.Cells("agama").Value) Then
                        For i As Integer = 0 To cboAgama.Items.Count - 1
                            If (DirectCast(cboAgama.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("agama").Value) Then
                                cboAgama.SelectedIndex = i
                                arrDefValues(16) = dgvView.CurrentRow.Cells("agama").Value
                            End If
                        Next
                    End If
                    'Gol Darah
                    If Not IsDBNull(dgvView.CurrentRow.Cells("gol_darah").Value) Then
                        For i As Integer = 0 To cboGolDarah.Items.Count - 1
                            If (DirectCast(cboGolDarah.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("gol_darah").Value) Then
                                cboGolDarah.SelectedIndex = i
                                arrDefValues(17) = dgvView.CurrentRow.Cells("gol_darah").Value
                            End If
                        Next
                    End If
                    'Pendidikan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("pendidikan").Value) Then
                        For i As Integer = 0 To cboPendidikan.Items.Count - 1
                            If (DirectCast(cboPendidikan.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("pendidikan").Value) Then
                                cboPendidikan.SelectedIndex = i
                                arrDefValues(18) = dgvView.CurrentRow.Cells("pendidikan").Value
                            End If
                        Next
                    End If
                    'Lulusan Dari
                    If Not IsDBNull(dgvView.CurrentRow.Cells("lulusan_dari").Value) Then
                        tbLulusanDari.Text = dgvView.CurrentRow.Cells("lulusan_dari").Value
                        arrDefValues(19) = dgvView.CurrentRow.Cells("lulusan_dari").Value
                    End If
                    'Tahun lulus
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tahun_lulus").Value) Then
                        tbTahunLulus.Text = dgvView.CurrentRow.Cells("tahun_lulus").Value
                        arrDefValues(20) = dgvView.CurrentRow.Cells("tahun_lulus").Value
                    End If
                    'BPJS TK
                    If Not IsDBNull(dgvView.CurrentRow.Cells("bpjs_tk").Value) Then
                        Dim bpjstk() As String
                        bpjstk = dgvView.CurrentRow.Cells("bpjs_tk").Value.ToString.Split(",")

                        For i As Integer = 0 To clbBPJSTK.Items.Count - 1
                            clbBPJSTK.SetItemChecked(i, False)
                        Next

                        For i As Integer = 0 To bpjstk.Count - 1
                            clbBPJSTK.SetItemChecked(clbBPJSTK.Items.IndexOf(bpjstk(i)), True)
                            'Select Case bpjstk(i)
                            '    Case "JKK"
                            '        clbBPJSTK.SetItemChecked(clbBPJSTK.Items.IndexOf("JKK"), True)
                            '    Case "JKM"
                            '        clbBPJSTK.SetItemChecked(clbBPJSTK.Items.IndexOf("JKM"), True)
                            '    Case "JHT"
                            '        clbBPJSTK.SetItemChecked(clbBPJSTK.Items.IndexOf("JHT"), True)
                            '    Case "JP"
                            '        clbBPJSTK.SetItemChecked(clbBPJSTK.Items.IndexOf("JP"), True)
                            'End Select
                        Next
                        arrDefValues(21) = dgvView.CurrentRow.Cells("bpjs_tk").Value
                        strBPJSTK = dgvView.CurrentRow.Cells("bpjs_tk").Value
                    End If
                    'BPJS Kesehatan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("bpjs_kesehatan").Value) Then
                        tbBPJSKesehatan.Text = dgvView.CurrentRow.Cells("bpjs_kesehatan").Value
                        arrDefValues(22) = dgvView.CurrentRow.Cells("bpjs_kesehatan").Value
                    End If
                    'Jaminan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("jaminan").Value) Then
                        tbJaminan.Text = dgvView.CurrentRow.Cells("jaminan").Value
                        arrDefValues(23) = dgvView.CurrentRow.Cells("jaminan").Value
                    End If
                    'Status Bekerja (Aktif/Resign/Pensiun)
                    If Not IsDBNull(dgvView.CurrentRow.Cells("status_bekerja").Value) Then
                        If (dgvView.CurrentRow.Cells("status_bekerja").Value = "Aktif") Then
                            rbAktif.Checked = True
                        ElseIf (dgvView.CurrentRow.Cells("status_bekerja").Value = "Resign") Then
                            rbResign.Checked = True
                        ElseIf (dgvView.CurrentRow.Cells("status_bekerja").Value = "Pensiun") Then
                            rbPensiun.Checked = True
                        End If
                        arrDefValues(24) = dgvView.CurrentRow.Cells("status_bekerja").Value
                        strStatusBekerja = dgvView.CurrentRow.Cells("status_bekerja").Value
                    End If
                    'Tanggal Berhenti Bekerja
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal_berhenti_bekerja").Value) Then
                        dtpBerhentiKerja.Value = dgvView.CurrentRow.Cells("tanggal_berhenti_bekerja").Value
                        arrDefValues(25) = dgvView.CurrentRow.Cells("tanggal_berhenti_bekerja").Value
                    Else
                        arrDefValues(25) = Nothing
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
            If (Trim(tbIDK.Text).Length > 0 And Trim(tbNIK.Text).Length > 0 And Trim(tbNama.Text).Length > 0 And Trim(tbAlamat.Text).Length > 0) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                Dim created_at As Date
                created_at = Now
                ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                If isNew Then
                    'CREATE NEW
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "nik='" & myCStringManipulation.SafeSqlLiteral(tbNIK.Text) & "'")
                    If Not isExist Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "idk='" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "'")
                        While (isExist)
                            Call SetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "idk", "rid", strGender, digitLength, True, dtpTanggalMasuk.Value.Date, CONN_.dbType)
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "idk='" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "'")
                        End While

                        'CREATE NEW
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "','" & myCStringManipulation.SafeSqlLiteral(tbNIK.Text) & "','" & myCStringManipulation.SafeSqlLiteral(tbNama.Text) & "','" & Format(dtpTanggalLahir.Value.Date, "dd-MMM-yyyy") & "','" & Format(dtpTanggalMasuk.Value.Date, "dd-MMM-yyyy") & "','" & strGender & "','" & myCStringManipulation.SafeSqlLiteral(strStatus) & "','" & myCStringManipulation.SafeSqlLiteral(strStatusBekerja) & "'," & ADD_INFO_.newValues
                        newFields = "idk,nik,nama,tanggallahir,tanggalmasuk,jeniskelamin,status,statusbekerja," & ADD_INFO_.newFields
                        If Trim(tbAlamat.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbAlamat.Text) & "'"
                            newFields &= ",alamat"
                        End If
                        If Trim(tbTempatLahir.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbTempatLahir.Text) & "'"
                            newFields &= ",tempatlahir"
                        End If
                        If Trim(tbNPWP.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbNPWP.Text) & "'"
                            newFields &= ",npwp"
                        End If
                        If Trim(tbNamaBerdasarNPWP.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbNamaBerdasarNPWP.Text) & "'"
                            newFields &= ",namaberdasarnpwp"
                        End If
                        If Trim(tbAlamatBerdasarNPWP.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbAlamatBerdasarNPWP.Text) & "'"
                            newFields &= ",alamatberdasarnpwp"
                        End If
                        If Trim(tbNoKK.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbNoKK.Text) & "'"
                            newFields &= ",nokk"
                        End If
                        If Trim(tbNoHP.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbNoHP.Text) & "'"
                            newFields &= ",nohp"
                        End If
                        If Trim(tbEmail.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbEmail.Text) & "'"
                            newFields &= ",email"
                        End If
                        If cboAgama.SelectedIndex <> -1 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboAgama.SelectedValue) & "'"
                            newFields &= ",agama"
                        End If
                        If cboGolDarah.SelectedIndex <> -1 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboGolDarah.SelectedValue) & "'"
                            newFields &= ",goldarah"
                        End If
                        If cboPendidikan.SelectedIndex <> -1 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboPendidikan.SelectedValue) & "'"
                            newFields &= ",pendidikan"
                        End If
                        If Trim(tbLulusanDari.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbLulusanDari.Text) & "'"
                            newFields &= ",lulusandari"
                        End If
                        If Trim(tbTahunLulus.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbTahunLulus.Text) & "'"
                            newFields &= ",tahunlulus"
                        End If
                        If Not IsNothing(strBPJSTK) Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(strBPJSTK) & "'"
                            newFields &= ",bpjstk"
                        End If
                        If Trim(tbBPJSKesehatan.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbBPJSKesehatan.Text) & "'"
                            newFields &= ",bpjskesehatan"
                        End If
                        If Trim(tbJaminan.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbJaminan.Text) & "'"
                            newFields &= ",jaminan"
                        End If
                        If (strStatusBekerja <> "Aktif") Then
                            newValues &= ",'" & Format(dtpBerhentiKerja.Value.Date, "dd-MMM-yyyy") & "'"
                            newFields &= ",tanggalberhentibekerja"
                        End If
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName, newValues, newFields)
                        Call myCShowMessage.ShowSavedMsg("Karyawan " & Trim(tbNama.Text) & " dengan NIK " & Trim(tbNIK.Text))
                        Call btnTampilkan_Click(sender, e)

                        Call myCMiscFunction.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowWarning("Karyawan dengan NIK " & Trim(tbNIK.Text) & " sudah terdaftar!!")
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    updateString = Nothing
                    foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    If (arrDefValues(2) <> Trim(tbNIK.Text)) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "nik='" & myCStringManipulation.SafeSqlLiteral(tbNIK.Text) & "' and rid<>" & arrDefValues(0))
                        If Not isExist Then
                            updateString = "nik='" & myCStringManipulation.SafeSqlLiteral(tbNIK.Text) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nik") = Trim(tbNIK.Text)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Karyawan dengan nik " & Trim(tbNIK.Text) & " sudah terdaftar!!")
                        End If
                    End If
                    If (arrDefValues(3) <> Trim(tbNama.Text)) Then
                        updateString = "nama='" & myCStringManipulation.SafeSqlLiteral(tbNama.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama") = Trim(tbNama.Text)
                        End If
                    End If
                    If (arrDefValues(4) <> strGender) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "jeniskelamin='" & myCStringManipulation.SafeSqlLiteral(strGender) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("jenis_kelamin") = strGender
                        End If
                    End If
                    If (arrDefValues(5) <> Trim(tbAlamat.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "alamat='" & myCStringManipulation.SafeSqlLiteral(tbAlamat.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("alamat") = Trim(tbAlamat.Text)
                        End If
                    End If
                    If (arrDefValues(6) <> Trim(tbTempatLahir.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tempatlahir='" & myCStringManipulation.SafeSqlLiteral(tbTempatLahir.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tempat_lahir") = Trim(tbTempatLahir.Text)
                        End If
                    End If
                    'MsgBox("def Values tanggal lahir: " & arrDefValues(7) & " || dtpTanggalLahir: " & dtpTanggalLahir.Value.Date)
                    If (arrDefValues(7) <> dtpTanggalLahir.Value.Date) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tanggallahir='" & Format(dtpTanggalLahir.Value.Date, "dd-MMM-yyyy") & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_lahir") = dtpTanggalLahir.Value.Date
                        End If
                    End If
                    'MsgBox("def Values tanggal masuk: " & arrDefValues(8) & " || dtpTanggalMasuk: " & dtpTanggalMasuk.Value.Date)
                    If (arrDefValues(8) <> dtpTanggalMasuk.Value.Date) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tanggalmasuk='" & Format(dtpTanggalMasuk.Value.Date, "dd-MMM-yyyy") & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_masuk") = dtpTanggalMasuk.Value.Date
                        End If
                    End If
                    If (arrDefValues(9) <> Trim(tbNPWP.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "npwp='" & myCStringManipulation.SafeSqlLiteral(tbNPWP.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("npwp") = Trim(tbNPWP.Text)
                        End If
                    End If
                    If (arrDefValues(10) <> Trim(tbNamaBerdasarNPWP.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "namaberdasarnpwp='" & myCStringManipulation.SafeSqlLiteral(tbNamaBerdasarNPWP.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama_berdasar_npwp") = Trim(tbNamaBerdasarNPWP.Text)
                        End If
                    End If
                    If (arrDefValues(11) <> Trim(tbAlamatBerdasarNPWP.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "alamatberdasarnpwp='" & myCStringManipulation.SafeSqlLiteral(tbAlamatBerdasarNPWP.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("alamat_berdasar_npwp") = Trim(tbAlamatBerdasarNPWP.Text)
                        End If
                    End If
                    If (arrDefValues(12) <> Trim(tbNoKK.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "nokk='" & myCStringManipulation.SafeSqlLiteral(tbNoKK.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("no_kk") = Trim(tbNoKK.Text)
                        End If
                    End If
                    If (arrDefValues(13) <> strStatus) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "status='" & myCStringManipulation.SafeSqlLiteral(strStatus) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("status") = strStatus
                        End If
                    End If
                    If (arrDefValues(14) <> Trim(tbNoHP.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "nohp='" & myCStringManipulation.SafeSqlLiteral(tbNoHP.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("no_hp") = Trim(tbNoHP.Text)
                        End If
                    End If
                    If (arrDefValues(15) <> Trim(tbEmail.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "email='" & myCStringManipulation.SafeSqlLiteral(tbEmail.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("email") = Trim(tbEmail.Text)
                        End If
                    End If
                    If (arrDefValues(16) <> cboAgama.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "agama='" & myCStringManipulation.SafeSqlLiteral(cboAgama.SelectedValue) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("agama") = cboAgama.SelectedValue
                        End If
                    End If
                    If (arrDefValues(17) <> cboGolDarah.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "goldarah='" & myCStringManipulation.SafeSqlLiteral(cboGolDarah.SelectedValue) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("gol_darah") = cboGolDarah.SelectedValue
                        End If
                    End If
                    If (arrDefValues(18) <> cboPendidikan.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "pendidikan='" & myCStringManipulation.SafeSqlLiteral(cboPendidikan.SelectedValue) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("pendidikan") = cboPendidikan.SelectedValue
                        End If
                    End If
                    If (arrDefValues(19) <> Trim(tbLulusanDari.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "lulusandari='" & myCStringManipulation.SafeSqlLiteral(tbLulusanDari.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("lulusan_dari") = Trim(tbLulusanDari.Text)
                        End If
                    End If
                    If (arrDefValues(20) <> Trim(tbTahunLulus.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tahunlulus='" & myCStringManipulation.SafeSqlLiteral(tbTahunLulus.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tahun_lulus") = Trim(tbTahunLulus.Text)
                        End If
                    End If
                    If (arrDefValues(21) <> strBPJSTK) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "bpjstk='" & myCStringManipulation.SafeSqlLiteral(strBPJSTK) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("bpjs_tk") = strBPJSTK
                        End If
                    End If
                    If (arrDefValues(22) <> Trim(tbBPJSKesehatan.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "bpjskesehatan='" & myCStringManipulation.SafeSqlLiteral(tbBPJSKesehatan.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("bpjs_kesehatan") = Trim(tbBPJSKesehatan.Text)
                        End If
                    End If
                    If (arrDefValues(23) <> Trim(tbJaminan.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "jaminan='" & myCStringManipulation.SafeSqlLiteral(tbJaminan.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("jaminan") = Trim(tbJaminan.Text)
                        End If
                    End If
                    'MsgBox("arrDefValues(24): " & arrDefValues(24) & " <> strStatusBekerja: " & strStatusBekerja)
                    If (arrDefValues(24) <> strStatusBekerja) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "statusbekerja='" & myCStringManipulation.SafeSqlLiteral(strStatusBekerja) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("status_bekerja") = strStatusBekerja
                        End If
                    End If
                    If (strStatusBekerja <> "Aktif") Then
                        If Not IsNothing(arrDefValues(25)) Then
                            If (arrDefValues(25) <> dtpBerhentiKerja.Value.Date) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "tanggalberhentibekerja='" & Format(dtpBerhentiKerja.Value.Date, "dd-MMM-yyyy") & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_berhenti_bekerja") = dtpBerhentiKerja.Value.Date
                                End If
                            End If
                        Else
                            updateString &= IIf(IsNothing(updateString), "", ",") & "tanggalberhentibekerja='" & Format(dtpBerhentiKerja.Value.Date, "dd-MMM-yyyy") & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_berhenti_bekerja") = dtpBerhentiKerja.Value.Date
                            End If
                        End If
                    Else
                        If Not IsNothing(arrDefValues(25)) Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "tanggalberhentibekerja=Null"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_berhenti_bekerja") = DBNull.Value
                            End If
                        End If
                    End If

                    If Not IsNothing(updateString) Then
                        updateString &= "," & ADD_INFO_.updateString
                        Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName, CONN_.dbType)
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, updateString, "rid=" & arrDefValues(0))
                        Call myCShowMessage.ShowUpdatedMsg("Karyawan " & Trim(tbNama.Text) & " dengan NIK " & Trim(tbNIK.Text))

                        Call myCMiscFunction.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                Call SetButtonSimpanAvailabilty("save")
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                tbNama.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub rbJenisKelamin_CheckedChanged(sender As Object, e As EventArgs) Handles rbPria.CheckedChanged, rbWanita.CheckedChanged
        Try
            If (rbPria.Checked) Then
                strGender = "Pria"
            ElseIf (rbWanita.Checked) Then
                strGender = "Wanita"
            End If

            If (isDataPrepared) Then
                If Not isNew Then
                    'ID KARYAWAN TIDAK BOLEH BERUBAH
                    'If (arrDefValues(4) <> strGender) Then
                    '    Call SetIDK()
                    'Else
                    '    tbIDK.Text = arrDefValues(1)
                    'End If
                Else
                    Call SetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "idk", "rid", strGender, digitLength, True, dtpTanggalMasuk.Value.Date, CONN_.dbType)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbJenisKelamin_CheckedChanged Error")
        End Try
    End Sub

    Private Sub dtpTanggalMasuk_ValueChanged(sender As Object, e As EventArgs) Handles dtpTanggalMasuk.ValueChanged
        Try
            If (isDataPrepared) Then
                If Not isNew Then
                    'ID KARYAWAN TIDAK BOLEH BERUBAH
                    'MsgBox("dtpTanggalMasuk_ValueChanged: " & dtpTanggalMasuk.Value.Date)
                    'If (arrDefValues(8) <> dtpTanggalMasuk.Value.Date) Then
                    '    Call SetIDK()
                    'Else
                    '    tbIDK.Text = arrDefValues(1)
                    'End If
                Else
                    Call SetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "idk", "rid", strGender, digitLength, True, dtpTanggalMasuk.Value.Date, CONN_.dbType)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpTanggalMasuk_ValueChanged Error")
        End Try
    End Sub

    Private Sub rbStatus_CheckedChanged(sender As Object, e As EventArgs) Handles rbSingle.CheckedChanged, rbMenikah.CheckedChanged
        Try
            If (rbSingle.Checked) Then
                strStatus = "Single"
            ElseIf (rbMenikah.Checked) Then
                strStatus = "Menikah"
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbStatus_CheckedChanged Error")
        End Try
    End Sub

    Private Sub rbStatusBekerja_CheckedChanged(sender As Object, e As EventArgs) Handles rbAktif.CheckedChanged, rbResign.CheckedChanged, rbPensiun.CheckedChanged
        Try
            If (rbAktif.Checked) Then
                strStatusBekerja = "Aktif"
                lblTanggalBerhentiKerja.Visible = False
                dtpBerhentiKerja.Visible = False
            ElseIf (rbResign.Checked) Then
                strStatusBekerja = "Resign"
                lblTanggalBerhentiKerja.Visible = True
                dtpBerhentiKerja.Visible = True
            ElseIf (rbPensiun.Checked) Then
                strStatusBekerja = "Pensiun"
                lblTanggalBerhentiKerja.Visible = True
                dtpBerhentiKerja.Visible = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbStatusBekerja_CheckedChanged Error")
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboAgama.Validated, cboGolDarah.Validated, cboPendidikan.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub clbBPJSTK_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbBPJSTK.Validated
        Try
            If (isDataPrepared) Then
                strBPJSTK = Nothing
                For i As Integer = 0 To clbBPJSTK.Items.Count - 1
                    If (clbBPJSTK.GetItemChecked(i)) Then
                        If Not IsNothing(strBPJSTK) Then
                            strBPJSTK &= ","
                        End If
                        strBPJSTK &= clbBPJSTK.Items(i)
                    End If
                Next
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "clbBPJSTK_SelectedIndexChanged Error")
        End Try
    End Sub

    Private Sub tbEmail_Validated(sender As Object, e As EventArgs) Handles tbEmail.Validated
        Try
            If (isDataPrepared) Then
                If Not (myCStringManipulation.EmailAddressCheck(tbEmail.Text)) Then
                    Call myCShowMessage.ShowWarning("Format email salah")
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbEmail_Validated Error")
        End Try
    End Sub

    Private Sub tbNIK_Validated(sender As Object, e As EventArgs) Handles tbNIK.Validated
        Try
            If (Trim(tbNIK.Text).Length = 0) Then
                tbNIK.Text = "-"
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNIK_Validated Error")
        End Try
    End Sub
End Class
