Public Class FormMasterTanggunganKaryawan
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
    Private cmbDgvAttachmentButton As New DataGridViewButtonColumn()
    Private cekTambahButton(2) As Boolean
    Private arrDefValues(5) As String
    Private tableName As String

    Private myDataTableCboHubungan As New DataTable
    Private myBindingHubungan As New BindingSource

    'Private karyawan.idk As String
    'Private karyawan.nama As String
    Private isCboPrepared As Boolean

    Private Structure employee
        Dim idk As String
        Dim nip As String
        Dim nama As String
    End Structure

    Private karyawan As employee

    Public Sub New(_dbType As String, _ConnMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValue As String, _addNewFields As String, _addUpdateString As String, _idk As String, _nama As String)
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

            With karyawan
                .idk = _idk
                .nama = _nama
            End With

            tbIDK.Text = karyawan.idk
            tbNamaKaryawan.Text = karyawan.nama
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterTanggunganKaryawan Error")
        End Try
    End Sub

    Private Sub FormMasterTanggunganKaryawan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormMasterTanggunganKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"NIK", "NAMA", "HUBUNGAN"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT keterangan FROM msgeneral where kategori='tanggungan' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboHubungan, myBindingHubungan, cboHubungan, "T_" & cboHubungan.Name, "keterangan", "keterangan", isCboPrepared)

            Call myCMiscFunction.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call SetButtonSimpanAvailabilty("load")

            tableName = "mstanggungankaryawan"
            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterTanggunganKaryawan_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormMasterTanggunganKaryawan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbNamaTanggungan.KeyDown, tbNIKTanggungan.KeyDown, cboHubungan.KeyDown, tbTempatLahir.KeyDown, dtpTanggalLahir.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbTempatLahir) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterTanggunganKaryawan_KeyDown Error")
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

                stSQL = "SELECT count(*) FROM " & tableName & " WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') AND (idk='" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "'));"
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

            stSQL = "SELECT rid,idk,nik,nama,hubungan,tempatlahir as tempat_lahir,tanggallahir as tanggal_lahir,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT Top " & batas & " sub.rid,sub.idk,sub.nik,sub.nama,sub.hubungan,sub.tempatlahir,sub.tanggallahir,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT TOP " & offSet & " tbl.rid,tbl.idk,tbl.nik,tbl.nama,tbl.hubungan,tbl.tempatlahir,tbl.tanggallahir,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName & " as tbl " &
                            "WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') AND (idk='" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "')) " &
                            "ORDER BY (case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC " &
                            ") sub " &
                        "ORDER BY (case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC" &
                    ") subOrdered " &
                    "ORDER BY (case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC;"
            myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "T_TanggunganKaryawan")
            myBindingTable.DataSource = myDataTable

            With dgvView
                .DataSource = myBindingTable
                .ReadOnly = True

                .Columns("rid").Visible = False
                .Columns("idk").Visible = False

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next

                .Columns("tanggal_lahir").DefaultCellStyle.Format = "dd-MMM-yyyy"
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

            With cmbDgvAttachmentButton
                If Not (cekTambahButton(2)) Then
                    .HeaderText = "ATTACHMENT"
                    .Name = "attachment"
                    .Text = "Attachment"
                    .UseColumnTextForButtonValue = True
                    dgvView.Columns.Add(cmbDgvAttachmentButton)
                    dgvView.Columns("attachment").Width = 90
                    cekTambahButton(2) = True
                End If
                .DisplayIndex = 1
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
            tbNIKTanggungan.Text = "-"

            tbIDK.Text = karyawan.idk
            tbNamaKaryawan.Text = karyawan.nama
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

                    isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus tanggungan " & dgvView.CurrentRow.Cells("nama").Value & " yang memiliki hubungan " & dgvView.CurrentRow.Cells("hubungan").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = 6) Then
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName, "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                        Call myCShowMessage.ShowDeletedMsg("Tanggungan " & dgvView.CurrentRow.Cells("nama").Value & " yang memiliki hubungan " & dgvView.CurrentRow.Cells("hubungan").Value)
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan tanggungan " & dgvView.CurrentRow.Cells("nama").Value & " yang memiliki hubungan " & dgvView.CurrentRow.Cells("hubungan").Value & " dibatalkan oleh user")
                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("attachment").Index) Then
                    Dim frmAttachmentKaryawan As New FormAttachmentKaryawan.FormAttachmentKaryawan(CONN_.dbType, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, dgvView.CurrentRow.Cells("idk").Value, karyawan.nama)
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

                    tbIDK.Text = karyawan.idk
                    tbNamaKaryawan.Text = karyawan.nama

                    'RecID
                    arrDefValues(0) = dgvView.CurrentRow.Cells("rid").Value
                    'Nama
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nama").Value) Then
                        tbNamaTanggungan.Text = dgvView.CurrentRow.Cells("nama").Value
                        arrDefValues(1) = dgvView.CurrentRow.Cells("nama").Value
                    End If
                    'NIK
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nik").Value) Then
                        tbNIKTanggungan.Text = dgvView.CurrentRow.Cells("nik").Value
                        arrDefValues(2) = dgvView.CurrentRow.Cells("nik").Value
                    Else
                        tbNIKTanggungan.Text = "-"
                    End If
                    'Hubungan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("hubungan").Value) Then
                        For i As Integer = 0 To cboHubungan.Items.Count - 1
                            If (DirectCast(cboHubungan.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("hubungan").Value) Then
                                cboHubungan.SelectedIndex = i
                                arrDefValues(3) = dgvView.CurrentRow.Cells("hubungan").Value
                            End If
                        Next
                    End If
                    'Tempat Lahir
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tempat_lahir").Value) Then
                        tbTempatLahir.Text = dgvView.CurrentRow.Cells("tempat_lahir").Value
                        arrDefValues(4) = dgvView.CurrentRow.Cells("tempat_lahir").Value
                    End If
                    'Tanggal Lahir
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal_lahir").Value) Then
                        dtpTanggalLahir.Value = dgvView.CurrentRow.Cells("tanggal_lahir").Value
                        arrDefValues(5) = dgvView.CurrentRow.Cells("tanggal_lahir").Value
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
            If (Trim(tbNIKTanggungan.Text).Length > 0 And Trim(tbNamaTanggungan.Text).Length > 0 And cboHubungan.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                Dim created_at As Date
                created_at = Now
                ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                If isNew Then
                    'CREATE NEW
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "idk='" & tbIDK.Text & "' and nama='" & myCStringManipulation.SafeSqlLiteral(tbNamaTanggungan.Text) & "' and hubungan='" & myCStringManipulation.SafeSqlLiteral(cboHubungan.SelectedValue) & "'")
                    If Not isExist Then
                        'CREATE NEW
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "','" & myCStringManipulation.SafeSqlLiteral(tbNIKTanggungan.Text) & "','" & myCStringManipulation.SafeSqlLiteral(tbNamaTanggungan.Text) & "','" & Format(dtpTanggalLahir.Value.Date, "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(cboHubungan.SelectedValue) & "'," & ADD_INFO_.newValues
                        newFields = "idk,nik,nama,tanggallahir,hubungan," & ADD_INFO_.newFields
                        If Trim(tbTempatLahir.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbTempatLahir.Text) & "'"
                            newFields &= ",tempatlahir"
                        End If
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName, newValues, newFields)
                        Call myCShowMessage.ShowSavedMsg("Tanggungan dengan nama " & Trim(tbNamaTanggungan.Text) & " yang memiliki hubungan " & Trim(cboHubungan.SelectedValue))
                        Call btnTampilkan_Click(sender, e)

                        Call myCMiscFunction.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowWarning("Tanggungan untuk karyawan " & tbNamaKaryawan.Text & " dengan nama " & Trim(tbNamaTanggungan.Text) & " yang memiliki hubungan " & Trim(cboHubungan.SelectedValue) & " sudah terdaftar!!")
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    updateString = Nothing
                    foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    If (arrDefValues(1) <> Trim(tbNamaTanggungan.Text)) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "idk='" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "' and nama='" & myCStringManipulation.SafeSqlLiteral(tbNamaTanggungan.Text) & "' and hubungan='" & myCStringManipulation.SafeSqlLiteral(cboHubungan.SelectedValue) & "'")
                        If Not isExist Then
                            updateString = "nama='" & myCStringManipulation.SafeSqlLiteral(tbNamaTanggungan.Text) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama") = Trim(tbNamaTanggungan.Text)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Tanggungan dengan nama " & Trim(tbNamaTanggungan.Text) & " dan hubungan " & Trim(cboHubungan.SelectedValue) & " sudah terdaftar!!")
                        End If
                    End If
                    If (arrDefValues(2) <> Trim(tbNIKTanggungan.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "nik='" & myCStringManipulation.SafeSqlLiteral(tbNIKTanggungan.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nik") = Trim(tbNIKTanggungan.Text)
                        End If
                    End If
                    If (arrDefValues(3) <> cboHubungan.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "hubungan='" & myCStringManipulation.SafeSqlLiteral(cboHubungan.SelectedValue) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("hubungan") = cboHubungan.SelectedValue
                        End If
                    End If
                    If (arrDefValues(4) <> Trim(tbTempatLahir.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tempatlahir='" & myCStringManipulation.SafeSqlLiteral(tbTempatLahir.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tempat_lahir") = Trim(tbTempatLahir.Text)
                        End If
                    End If
                    If (arrDefValues(5) <> dtpTanggalLahir.Value.Date) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tanggallahir='" & Format(dtpTanggalLahir.Value.Date, "dd-MMM-yyyy") & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_lahir") = dtpTanggalLahir.Value.Date
                        End If
                    End If

                    If Not IsNothing(updateString) Then
                        updateString &= "," & ADD_INFO_.updateString
                        Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName, CONN_.dbType)
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, updateString, "rid=" & arrDefValues(0))
                        Call myCShowMessage.ShowUpdatedMsg("Tanggungan karyawan " & Trim(tbNamaKaryawan.Text) & " dengan nama " & Trim(tbNamaTanggungan.Text))

                        Call myCMiscFunction.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                Call SetButtonSimpanAvailabilty("save")
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                tbNamaTanggungan.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboHubungan.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub tbNIKTanggungan_Validated(sender As Object, e As EventArgs) Handles tbNIKTanggungan.Validated
        Try
            If (Trim(tbNIKTanggungan.Text).Length = 0) Then
                tbNIKTanggungan.Text = "-"
            End If

            If (tbNIKTanggungan.Text <> "-") Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                'Harus di cek apakah sudah ada yang memakai NIK yang kembar atau nggak
                If Not isNew Then
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "nik='" & myCStringManipulation.SafeSqlLiteral(tbNIKTanggungan.Text) & "' and rid<>" & arrDefValues(0))
                Else
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "nik='" & myCStringManipulation.SafeSqlLiteral(tbNIKTanggungan.Text) & "'")
                End If
                If (isExist) Then
                    'Kalau sudah ada yang pakai NIK tersebut, kasih warning
                    Dim myDataTableTanggunganExist As New DataTable
                    If Not isNew Then
                        stSQL = "SELECT k.idk,k.nama FROM mskaryawan as k inner join " & tableName & " as g ON k.idk=g.idk WHERE g.nik='" & myCStringManipulation.SafeSqlLiteral(tbNIKTanggungan.Text) & "' and g.rid<>" & arrDefValues(0) & ";"
                    Else
                        stSQL = "SELECT k.idk,k.nama FROM mskaryawan as k inner join " & tableName & " as g ON k.idk=g.idk WHERE g.nik='" & myCStringManipulation.SafeSqlLiteral(tbNIKTanggungan.Text) & "';"
                    End If
                    myDataTableTanggunganExist = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_TanggunganExist")
                    If (myDataTableTanggunganExist.Rows.Count > 0) Then
                        Call myCShowMessage.ShowWarning("Sudah ada yang memakai NIK tersebut di tanggungan untuk karyawan " & myDataTableTanggunganExist.Rows(0).Item("idk") & " - " & myDataTableTanggunganExist.Rows(0).Item("nama"))
                    End If
                End If
                Me.Cursor = Cursors.Default
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If

            If Not isNew Then
                If (isExist) Then
                    tbNIKTanggungan.Text = arrDefValues(2)
                End If
            Else
                If (isExist) Then
                    tbNIKTanggungan.Text = "-"
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNIKTanggungan_Validated Error")
        End Try
    End Sub
End Class
