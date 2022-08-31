Public Class FormAttachmentDokumen
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
    Private cmbDgvPreviewButton As New DataGridViewButtonColumn()
    Private cekTambahButton(2) As Boolean
    Private arrDefValues(7) As String
    Private tableName As String

    Private Structure document
        Dim jenis As String
        Dim nomer As String
    End Structure

    Private Structure fileTempel
        Dim name As String
        Dim path As String
        Dim extension As String
    End Structure

    Private fileAttachment As fileTempel
    Private dokumen As document
    Private strGroupData As String
    Private strTujuanFile As String

    Const STR_MYCOMPUTER_CLSID As String = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"

    Public Sub New(_dbType As String, _ConnMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValue As String, _addNewFields As String, _addUpdateString As String, _groupData As String, _jenis As String, _nomer As String)
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

            With dokumen
                .jenis = _jenis
                .nomer = _nomer
            End With
            strGroupData = _groupData

            tbJenisDokumen.Text = dokumen.jenis
            tbNoDokumen.Text = dokumen.nomer
            tbGroupData.Text = strGroupData
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormAttachmentDokumen Error")
        End Try
    End Sub

    Private Sub FormAttachmentDokumen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormAttachmentDokumen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"NAMA FILE", "KETERANGAN", "GROUP DATA"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            Call myCMiscFunction.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call SetButtonSimpanAvailabilty("load")

            ofd1.InitialDirectory = STR_MYCOMPUTER_CLSID
            ofd1.Title = "Pilih File"
            ofd1.Multiselect = False

            tableName = "attachmentdokumen"

            isDataPrepared = True

            strTujuanFile = "G:\ATTACHMENT\DOKUMEN\" & dokumen.jenis & "\" & dokumen.nomer & "\"
            tbLokasiTujuanFile.Text = strTujuanFile

            myCFileIO.CreateDirectory(strTujuanFile)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormAttachmentDokumen_Load Error")
        End Try
    End Sub

    Private Sub FormAttachmentDokumen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbJenisDokumen.KeyDown, tbNoDokumen.KeyDown, tbGroupData.KeyDown, tbLokasiAsalFile.KeyDown, tbLokasiTujuanFile.KeyDown, btnBrowse.KeyDown, tbNamaFile.KeyDown, tbExtensionFile.KeyDown, rtbKeterangan.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is rtbKeterangan) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormAttachmentDokumen_KeyDown Error")
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

                stSQL = "SELECT count(*) FROM " & tableName & " WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') AND (jenisdokumen='" & dokumen.jenis & "') AND (nodokumen='" & dokumen.nomer & "' AND groupdata='" & strGroupData & "'));"
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

            stSQL = "SELECT rid,jenisdokumen as jenis_dokumen,nodokumen as no_dokumen,keterangan,pathtofile as path_to_file,namafile as nama_file,groupdata as group_data,ispublic as is_public,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT Top " & batas & " sub.rid,sub.jenisdokumen,sub.nodokumen,sub.groupdata,sub.ispublic,sub.keterangan,sub.pathtofile,sub.namafile,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT TOP " & offSet & " tbl.rid,tbl.jenisdokumen,tbl.nodokumen,tbl.groupdata,tbl.ispublic,tbl.keterangan,tbl.pathtofile,tbl.namafile,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName & " as tbl " &
                            "WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') AND (jenisdokumen='" & dokumen.jenis & "') AND (nodokumen='" & dokumen.nomer & "' AND groupdata='" & strGroupData & "')) " &
                            "ORDER BY (case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC " &
                            ") sub " &
                        "ORDER BY (case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC" &
                    ") subOrdered " &
                    "ORDER BY (case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC;"
            myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "T_Attachment")
            myBindingTable.DataSource = myDataTable

            With dgvView
                .DataSource = myBindingTable
                .ReadOnly = True

                .Columns("rid").Visible = False
                .Columns("jenis_dokumen").Visible = False
                .Columns("no_dokumen").Visible = False
                .Columns("is_public").Visible = False

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                .Font = New Font("Arial", 9, FontStyle.Regular)
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

            With cmbDgvPreviewButton
                If Not (cekTambahButton(2)) Then
                    .HeaderText = "PREVIEW"
                    .Name = "preview"
                    .Text = "Preview"
                    .UseColumnTextForButtonValue = True
                    dgvView.Columns.Add(cmbDgvPreviewButton)
                    dgvView.Columns("preview").Width = 100
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

            tbJenisDokumen.Text = dokumen.jenis
            tbNoDokumen.Text = dokumen.nomer
            tbGroupData.Text = strGroupData
            tbLokasiTujuanFile.Text = strTujuanFile

            With fileAttachment
                .name = Nothing
                .path = Nothing
                .extension = Nothing
            End With
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

                    isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus file " & dgvView.CurrentRow.Cells("nama_file").Value & " dari dokumen " & dgvView.CurrentRow.Cells("jenis_dokumen").Value & " dengan nomer dokumen " & dgvView.CurrentRow.Cells("no_dokumen").Value & " pada group data " & dgvView.CurrentRow.Cells("group_data").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = 6) Then
                        If (myCFileIO.DeleteFile(dgvView.CurrentRow.Cells("path_to_file").Value)) Then
                            Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName, "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                            Call myCShowMessage.ShowDeletedMsg("File dokumen " & dgvView.CurrentRow.Cells("jenis_dokumen").Value & " dari nomer dokumen " & dgvView.CurrentRow.Cells("no_dokumen").Value & " pada group data " & dgvView.CurrentRow.Cells("group_data").Value)
                            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)

                            'Call myCMiscFunction.ResetForm(gbDataEntry)
                            'Call btnCreateNew_Click(sender, e)
                        Else
                            Call myCShowMessage.ShowWarning("Penghapusan file " & dgvView.CurrentRow.Cells("nama_file").Value & " gagal!" & ControlChars.NewLine & "Silahkan hubungi Technical Support")
                        End If
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan file " & dgvView.CurrentRow.Cells("nama_file").Value & " dari dokumen " & dgvView.CurrentRow.Cells("jenis_dokumen").Value & " dengan nomer " & dgvView.CurrentRow.Cells("no_dokumen").Value & " pada group data " & dgvView.CurrentRow.Cells("group_data").Value & " dibatalkan oleh user")
                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("preview").Index) Then
                    Dim processInfo As ProcessStartInfo = New ProcessStartInfo()
                    processInfo = myCFileIO.SetProcessInfo(processInfo, dgvView.CurrentRow.Cells("path_to_file").Value.ToString.Substring(dgvView.CurrentRow.Cells("path_to_file").Value.ToString.LastIndexOf(".")), dgvView.CurrentRow.Cells("path_to_file").Value)
                    Dim myProcess As Process = Process.Start(processInfo)
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
                    'Karyawan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("no_dokumen").Value) Then
                        tbJenisDokumen.Text = dgvView.CurrentRow.Cells("jenis_dokumen").Value
                        tbNoDokumen.Text = dgvView.CurrentRow.Cells("no_dokumen").Value
                        arrDefValues(1) = dgvView.CurrentRow.Cells("jenis_dokumen").Value
                        arrDefValues(2) = dgvView.CurrentRow.Cells("no_dokumen").Value
                    End If
                    'Group Data
                    If Not IsDBNull(dgvView.CurrentRow.Cells("group_data").Value) Then
                        tbGroupData.Text = dgvView.CurrentRow.Cells("group_data").Value
                        arrDefValues(3) = dgvView.CurrentRow.Cells("group_data").Value
                    End If
                    'Is Public
                    If Not IsDBNull(dgvView.CurrentRow.Cells("is_public").Value) Then
                        cbIsPublic.Checked = dgvView.CurrentRow.Cells("is_public").Value
                        arrDefValues(4) = dgvView.CurrentRow.Cells("is_public").Value
                    End If
                    'Keterangan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("keterangan").Value) Then
                        rtbKeterangan.Text = dgvView.CurrentRow.Cells("keterangan").Value
                        arrDefValues(5) = dgvView.CurrentRow.Cells("keterangan").Value
                    End If
                    'PathToFile
                    If Not IsDBNull(dgvView.CurrentRow.Cells("path_to_file").Value) Then
                        fileAttachment.path = dgvView.CurrentRow.Cells("path_to_file").Value
                        tbLokasiTujuanFile.Text = dgvView.CurrentRow.Cells("path_to_file").Value
                        arrDefValues(6) = dgvView.CurrentRow.Cells("path_to_file").Value
                    End If
                    'NamaFile
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nama_file").Value) Then
                        fileAttachment.name = dgvView.CurrentRow.Cells("nama_file").Value
                        fileAttachment.extension = fileAttachment.name.Substring(fileAttachment.name.LastIndexOf("."))
                        tbNamaFile.Text = fileAttachment.name
                        tbExtensionFile.Text = fileAttachment.extension
                        arrDefValues(7) = dgvView.CurrentRow.Cells("nama_file").Value
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
            If (Trim(tbLokasiTujuanFile.Text).Length > 0 And Trim(tbNamaFile.Text).Length > 0) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                Dim created_at As Date
                created_at = Now
                ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                If isNew Then
                    If (Trim(tbLokasiAsalFile.Text).Length > 0) Then
                        'CREATE NEW
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "pathtofile='" & myCStringManipulation.SafeSqlLiteral(tbLokasiTujuanFile.Text) & "'")
                        If Not isExist Then
                            If (myCFileIO.CopyFile(tbLokasiAsalFile.Text, tbLokasiTujuanFile.Text)) Then
                                'Jika copy file berhasil saja, datanya akan disimpan
                                newValues = "'" & myCStringManipulation.SafeSqlLiteral(dokumen.jenis) & "','" & myCStringManipulation.SafeSqlLiteral(dokumen.nomer) & "','" & myCStringManipulation.SafeSqlLiteral(tbGroupData.Text) & "','" & cbIsPublic.Checked & "','" & myCStringManipulation.SafeSqlLiteral(tbLokasiTujuanFile.Text) & "','" & myCStringManipulation.SafeSqlLiteral(tbNamaFile.Text) & "'," & ADD_INFO_.newValues
                                newFields = "jenisdokumen,nodokumen,groupdata,ispublic,pathtofile,namafile," & ADD_INFO_.newFields
                                If Trim(rtbKeterangan.Text).Length > 0 Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(rtbKeterangan.Text) & "'"
                                    newFields &= ",keterangan"
                                End If
                                Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName, newValues, newFields)
                                Call myCShowMessage.ShowSavedMsg("Informasi file " & Trim(tbNamaFile.Text) & " dari dokumen " & Trim(tbJenisDokumen.Text) & " dengan nomer " & Trim(tbNoDokumen.Text) & " pada group data " & Trim(tbGroupData.Text))
                                Call btnTampilkan_Click(sender, e)
                            Else
                                'Copy File gagal
                                Call myCShowMessage.ShowWarning("Copy file ke lokasi tujuan gagal!" & ControlChars.NewLine & "Silahkan hubungi Technical Support")
                            End If
                            Call myCMiscFunction.ResetForm(gbDataEntry)
                            Call btnCreateNew_Click(sender, e)
                        Else
                            Call myCShowMessage.ShowWarning("Sudah ada file " & Trim(tbLokasiTujuanFile.Text) & " !!")
                        End If
                    Else
                        Call myCShowMessage.ShowWarning("Silahkan pilih dulu file attachment nya!")
                        tbLokasiAsalFile.Focus()
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    'Dim copyNew As Boolean
                    'Dim renameFile As Boolean
                    Dim fileOperation As Boolean
                    Dim copyOperation As Boolean
                    Dim renameOperation As Boolean
                    updateString = Nothing
                    foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    'If (arrDefValues(1) <> DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) Then
                    '    'Seharusnya nama tidak boleh di update, karena buat melakukan pengecekan apabila sampai terjadi kesalahan karena keliru input nama di data karyawan
                    '    'Sementara di comment dulu PER 12 NOVEMBER 2021
                    '    updateString = "nama='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & "'"
                    '    If (foundRows.Length > 0) Then
                    '        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama") = Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama"))
                    '    End If
                    'End If
                    If (arrDefValues(3) <> tbGroupData.Text) Then
                        updateString = "groupdata='" & myCStringManipulation.SafeSqlLiteral(tbGroupData.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("group_data") = Trim(tbGroupData.Text)
                        End If
                    End If
                    If (arrDefValues(4) <> cbIsPublic.Checked) Then
                        updateString = "ispublic='" & cbIsPublic.Checked & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("is_public") = cbIsPublic.Checked
                        End If
                    End If
                    If (arrDefValues(5) <> Trim(rtbKeterangan.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "keterangan='" & myCStringManipulation.SafeSqlLiteral(rtbKeterangan.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("keterangan") = Trim(rtbKeterangan.Text)
                        End If
                    End If
                    If (arrDefValues(6) <> Trim(tbLokasiTujuanFile.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "pathtofile='" & myCStringManipulation.SafeSqlLiteral(tbLokasiTujuanFile.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("path_to_file") = Trim(tbLokasiTujuanFile.Text)
                        End If

                        'Kalau tujuannya berubah, bisa jadi nama file berubah atau ada di copy kan file baru
                        fileOperation = True
                        If (Trim(tbLokasiAsalFile.Text).Length > 0) Then
                            'Berarti copy file baru karena ada dipilih file baru
                            If (myCFileIO.CopyFile(tbLokasiAsalFile.Text, tbLokasiTujuanFile.Text)) Then
                                copyOperation = True
                            Else
                                copyOperation = False
                            End If
                        Else
                            'Berarti rename file
                            If (myCFileIO.RenameFile(arrDefValues(6), tbLokasiTujuanFile.Text)) Then
                                renameOperation = True
                            Else
                                renameOperation = False
                            End If
                        End If
                    End If
                    If (arrDefValues(7) <> Trim(tbNamaFile.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "namafile='" & myCStringManipulation.SafeSqlLiteral(tbNamaFile.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama_file") = Trim(tbNamaFile.Text)
                        End If
                    End If

                    If Not IsNothing(updateString) Then
                        If (fileOperation) Then
                            If (copyOperation) Or (renameOperation) Then
                                updateString &= "," & ADD_INFO_.updateString
                                Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName, CONN_.dbType)
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, updateString, "rid=" & arrDefValues(0))
                                Call myCShowMessage.ShowUpdatedMsg("Informasi file " & Trim(tbNamaFile.Text) & " dari dokumen " & Trim(tbJenisDokumen.Text) & " dengan nomer " & Trim(tbNoDokumen.Text) & " pada group data " & Trim(tbGroupData.Text))

                                If (copyOperation) Then
                                    Dim isConfirm As Integer
                                    isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus file " & arrDefValues(8) & " yang sebelumnya?")
                                    If (isConfirm = 6) Then
                                        'Ya
                                        Call myCFileIO.DeleteFile(arrDefValues(7))
                                    End If
                                End If
                            Else
                                Call myCShowMessage.ShowWarning("Operasi copy atau rename file gagal!" & ControlChars.NewLine & "Silahkan hubungi Technical Support")
                            End If
                        Else
                            updateString &= "," & ADD_INFO_.updateString
                            Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName, CONN_.dbType)
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, updateString, "rid=" & arrDefValues(0))
                            Call myCShowMessage.ShowUpdatedMsg("Informasi file " & Trim(tbNamaFile.Text) & " dari dokumen " & Trim(tbJenisDokumen.Text) & " dengan nomer " & Trim(tbNoDokumen.Text) & " pada group data " & Trim(tbGroupData.Text))
                        End If
                        Call myCMiscFunction.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                Call SetButtonSimpanAvailabilty("save")
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub cbIsPublic_CheckedChanged(sender As Object, e As EventArgs) Handles cbIsPublic.CheckedChanged
        Try
            If (cbIsPublic.Checked) Then
                lblPerhatian.Visible = True
            Else
                lblPerhatian.Visible = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cbIsPublic_CheckedChanged Error")
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'OK
        Try
            ofd1.Filter = myCFileIO.SetFilterForAttachment("all")
            ofd1.FilterIndex = 1
            ofd1.ShowDialog()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBrowse_Click Error")
        End Try
    End Sub

    Private Sub tbLokasiAsalFile_Click(sender As Object, e As EventArgs) Handles tbLokasiAsalFile.Click
        'OK
        Try
            ofd1.Filter = myCFileIO.SetFilterForAttachment("all")
            ofd1.FilterIndex = 1
            ofd1.ShowDialog()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbLokasiAsalFile_Click Error")
        End Try
    End Sub

    Private Sub ofd1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofd1.FileOk
        Try
            fileAttachment.path = ofd1.FileName
            fileAttachment.name = ofd1.SafeFileName
            fileAttachment.extension = ofd1.SafeFileName.Substring(ofd1.SafeFileName.LastIndexOf("."))

            tbLokasiAsalFile.Text = fileAttachment.path
            tbNamaFile.Text = fileAttachment.name
            tbExtensionFile.Text = fileAttachment.extension
            tbLokasiTujuanFile.Text = strTujuanFile & tbNamaFile.Text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ofd1_FileOk Error")
        End Try
    End Sub

    Private Sub tbNamaFile_Validated(sender As Object, e As EventArgs) Handles tbNamaFile.Validated
        Try
            If (Trim(tbNamaFile.Text).Length > 0) Then
                Dim mNamaFile As String
                mNamaFile = Trim(tbNamaFile.Text).Substring(0, tbNamaFile.Text.LastIndexOf("."))
                If (mNamaFile.Length = 0) Then
                    Call myCShowMessage.ShowWarning("Nama file tidak boleh hanya ekstensi file nya saja!!" & ControlChars.NewLine & "Nama file dikembalikan semula")
                    tbNamaFile.Text = fileAttachment.name
                End If
                tbLokasiTujuanFile.Text = strTujuanFile & Trim(tbNamaFile.Text)
            Else
                tbLokasiTujuanFile.Text = strTujuanFile
                tbNamaFile.Clear()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNamaFile_Validated Error")
        End Try
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Try
            Dim processInfo As ProcessStartInfo = New ProcessStartInfo()
            processInfo = myCFileIO.SetProcessInfo(processInfo, fileAttachment.extension, fileAttachment.path)
            Dim myProcess As Process = Process.Start(processInfo)

            'HARUS DITUTUP UNTUK MELEPAS RESOURCES NYA, MASIH BELUM BISA DIPAKAI!!
            'myProcess.CloseMainWindow()
            'myProcess.Close()
            'If Not (myProcess.HasExited) Then
            '    myProcess.Kill()
            'End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnPreview_Click Error")
        End Try
    End Sub
End Class
