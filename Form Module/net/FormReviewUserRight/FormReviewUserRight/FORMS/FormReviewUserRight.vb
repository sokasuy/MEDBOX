Public Class FormReviewUserRight

    Private stSQL As String
    Private myDataTableDGV As New DataTable
    Private myBindingTableDGV As New BindingSource
    Private updateString As String
    Private newValues As String
    Private newFields As String
    Private banyakPages As Integer
    Private logRecordPage As Integer
    Private mCari As String
    Private isCboPrepared As Boolean
    Private isProsesCboKategori As Boolean
    Private isStarted As Boolean
    Private isNew As Boolean
    Private isExist As Boolean
    Private cmbDgvHapusButton As New DataGridViewButtonColumn()
    Private cmbDgvEditButton As New DataGridViewButtonColumn()
    Private cekTambahButton(2) As Boolean
    Private arrDefValues(7) As String

    Private myDataTableCboUsername As New DataTable
    Private myDataTableCboFormName As New DataTable
    Private myBindingUsername As New BindingSource
    Private myBindingFormList As New BindingSource

    Public Sub New(_dbType As String, _connMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValue As String, _addNewFields As String, _addUpdateString As String, _schemaTmp As String, _schemaHRD As String)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            With CONN_
                .dbType = _dbType
                .dbMain = _connMain
                .schemaTmp = _schemaTmp
                .schemaHRD = _schemaHRD
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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormReviewUserRight Error")
        End Try
    End Sub

    Private Sub FormReviewUserRight_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormReviewUserRight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"USERID", "FORM NAME"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)
            stSQL = "SELECT userid,superuser FROM " & CONN_.schemaHRD & ".msuser WHERE block='False' and superuser='False' order by userid;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboUsername, myBindingUsername, cboUserID, "T_Username", "userid", "userid", isCboPrepared)
            stSQL = "SELECT formname,displayname FROM " & CONN_.schemaHRD & ".msformlist WHERE block='False' order by displayname;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboFormName, myBindingFormList, cboFormName, "T_FormName", "formname", "displayname", isCboPrepared)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormReviewUserRight_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormReviewUserRight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboUserID.KeyDown, cboFormName.KeyDown, btnSimpan.KeyDown, btnBack.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormReviewPengguna_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    Private Sub SetDGV(ByVal myConn As Object, ByVal myComm As Object, ByVal myReader As Object, ByVal offSet As Integer, ByRef myDataTable As DataTable, ByVal mKriteria As String, Optional ByVal gantiKriteria As Boolean = False)
        Try
            Dim batas As Integer
            Dim mJumlah As Integer

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                'Dim tampTotalRecords As Integer
                banyakPages = 0
                mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                stSQL = "SELECT count(*) FROM " & CONN_.schemaHRD & ".msuserright as u INNER JOIN " & CONN_.schemaHRD & ".msformlist as f on u.formname=f.formname WHERE ((upper(" & IIf(cboKriteria.SelectedItem = "USERID", "u.userid", "f.displayname") & ") LIKE '%" & mKriteria.ToUpper & "%'));"
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

            stSQL = "SELECT rid,userid,formname,displayname,melihat,menambah,memperbaharui,menghapus,mencetak,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.userid,sub.formname,sub.displayname,sub.menambah,sub.memperbaharui,sub.menghapus,sub.melihat,sub.mencetak,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.userid,tbl.formname,f.displayname,tbl.menambah,tbl.memperbaharui,tbl.menghapus,tbl.melihat,tbl.mencetak,tbl.created_at,tbl.updated_at " &
                            "FROM " & CONN_.schemaHRD & ".msuserright as tbl INNER JOIN " & CONN_.schemaHRD & ".msformlist as f on tbl.formname=f.formname " &
                            "WHERE ((upper(" & IIf(cboKriteria.SelectedItem = "USERID", "tbl.userid", "f.displayname") & ") LIKE '%" & mKriteria.ToUpper & "%')) " &
                            "ORDER BY (case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC " &
                            "LIMIT " & offSet &
                            ") sub " &
                        "ORDER BY (case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC " &
                        "LIMIT " & batas &
                    ") subOrdered " &
                    "ORDER BY (case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC;"
            myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "T_USERRIGHT")
            myBindingTableDGV.DataSource = myDataTable

            With dgvView
                .DataSource = myBindingTableDGV
                .ReadOnly = True

                .Columns("rid").Visible = False
                .Columns("formname").Visible = False

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next
                .Columns("userid").HeaderText = "USER ID"
                .Columns("displayname").HeaderText = "FORM NAME"

                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                .Columns("userid").Width = 100
                .Columns("displayname").Width = 200
                .Columns("menambah").Width = 80
                .Columns("memperbaharui").Width = 80
                .Columns("menghapus").Width = 80
                .Columns("melihat").Width = 80
                .Columns("mencetak").Width = 80

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
                End If
                .DisplayIndex = dgvView.ColumnCount - 1
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
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, mCari, True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTampilkan_Click Error")
        End Try
    End Sub

    Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
        Try
            isNew = True
            lblEntryType.Text = "INSERT NEW"
            cboUserID.Enabled = True
            cboFormName.Enabled = True
            Call myCFormManipulation.ResetForm(gbDataEntry)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCreateNew_Click Error")
        End Try
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            If (Integer.Parse(tbRecordPage.Text) - 1 > 0) Then
                tbRecordPage.Text = Integer.Parse(tbRecordPage.Text) - 1
                logRecordPage = tbRecordPage.Text
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, myDataTableDGV, mCari, True)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForward.Click
        Try
            If (Integer.Parse(tbRecordPage.Text) + 1 <= banyakPages) Then
                tbRecordPage.Text = Integer.Parse(tbRecordPage.Text) + 1
                logRecordPage = tbRecordPage.Text
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, myDataTableDGV, mCari, True)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnForward_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFFBack.Click
        Try
            tbRecordPage.Text = 1
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, mCari, True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFFForward.Click
        Try
            tbRecordPage.Text = banyakPages
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, banyakPages * 10, myDataTableDGV, mCari, True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFForward_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub tbRecordPage_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbRecordPage.GotFocus
        Try
            logRecordPage = tbRecordPage.Text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbRecordPage_GotFocus Error")
        End Try
    End Sub

    Private Sub tbRecordPage_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbRecordPage.Validated
        Try
            If (IsNumeric(tbRecordPage.Text)) Then
                Dim temp As Integer
                temp = Integer.Parse(tbRecordPage.Text)
                If (temp > 0 And temp <= banyakPages) Then
                    Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, temp * 10, myDataTableDGV, mCari, True)
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

    Private Sub dgvView_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvView.CellMouseDown
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
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus hak user " & dgvView.CurrentRow.Cells("userid").Value & " untuk form " & dgvView.CurrentRow.Cells("displayname").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = DialogResult.Yes) Then
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".msuserright", "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                        Call myCShowMessage.ShowDeletedMsg("Hak pengguna " & dgvView.CurrentRow.Cells("userid").Value & " untuk form " & dgvView.CurrentRow.Cells("displayname").Value)
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, mCari, True)
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan hak pengguna " & dgvView.CurrentRow.Cells("userid").Value & " untuk form " & dgvView.CurrentRow.Cells("displayname").Value & " dibatalkan")
                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("edit").Index) Then
                    isNew = False
                    lblEntryType.Text = "EDIT"
                    Call myCFormManipulation.ResetForm(gbDataEntry)
                    'RecID
                    arrDefValues(0) = dgvView.CurrentRow.Cells("rid").Value
                    'username
                    If Not IsDBNull(dgvView.CurrentRow.Cells("userid").Value) Then
                        For i As Integer = 0 To cboUserID.Items.Count - 1
                            If (DirectCast(cboUserID.Items(i), DataRowView).Item("userid") = dgvView.CurrentRow.Cells("userid").Value) Then
                                cboUserID.SelectedIndex = i
                                arrDefValues(1) = dgvView.CurrentRow.Cells("userid").Value
                            End If
                        Next
                        cboUserID.Enabled = False
                    End If
                    'Form Name
                    If Not IsDBNull(dgvView.CurrentRow.Cells("formname").Value) Then
                        For i As Integer = 0 To cboFormName.Items.Count - 1
                            If (DirectCast(cboFormName.Items(i), DataRowView).Item("formname") = dgvView.CurrentRow.Cells("formname").Value) Then
                                cboFormName.SelectedIndex = i
                                arrDefValues(2) = dgvView.CurrentRow.Cells("formname").Value
                            End If
                        Next
                        cboFormName.Enabled = False
                    End If
                    'create
                    If Not IsDBNull(dgvView.CurrentRow.Cells("menambah").Value) Then
                        cbCreate.Checked = dgvView.CurrentRow.Cells("menambah").Value
                        arrDefValues(3) = dgvView.CurrentRow.Cells("menambah").Value
                    End If
                    'read
                    If Not IsDBNull(dgvView.CurrentRow.Cells("melihat").Value) Then
                        cbRead.Checked = dgvView.CurrentRow.Cells("melihat").Value
                        arrDefValues(4) = dgvView.CurrentRow.Cells("melihat").Value
                    End If
                    'update
                    If Not IsDBNull(dgvView.CurrentRow.Cells("memperbaharui").Value) Then
                        cbUpdate.Checked = dgvView.CurrentRow.Cells("memperbaharui").Value
                        arrDefValues(5) = dgvView.CurrentRow.Cells("memperbaharui").Value
                    End If
                    'delete
                    If Not IsDBNull(dgvView.CurrentRow.Cells("menghapus").Value) Then
                        cbDelete.Checked = dgvView.CurrentRow.Cells("menghapus").Value
                        arrDefValues(6) = dgvView.CurrentRow.Cells("menghapus").Value
                    End If
                    'print
                    If Not IsDBNull(dgvView.CurrentRow.Cells("mencetak").Value) Then
                        cbPrint.Checked = dgvView.CurrentRow.Cells("mencetak").Value
                        arrDefValues(7) = dgvView.CurrentRow.Cells("mencetak").Value
                    End If
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
            If (cboFormName.SelectedIndex <> -1 And cboUserID.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                'Dim created_at As Date

                'created_at = Now
                'ADD_INFO_.newValues = "'" & created_at & "'"
                If isNew Then
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaHRD & ".msuserright", "userid='" & myCStringManipulation.SafeSqlLiteral(cboUserID.SelectedValue) & "' and formname='" & myCStringManipulation.SafeSqlLiteral(cboFormName.SelectedValue) & "'")
                    If Not isExist Then
                        'CREATE NEW
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(cboUserID.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(cboFormName.SelectedValue) & "','" & cbCreate.Checked & "','" & cbRead.Checked & "','" & cbUpdate.Checked & "','" & cbDelete.Checked & "','" & cbPrint.Checked & "'," & ADD_INFO_.newValues
                        'Call myCDBOperation.SaveUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, newValues, "msuserright")
                        newFields = "userid,formname,menambah,melihat,memperbaharui,menghapus,mencetak," & ADD_INFO_.newFields
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".msuserright", newValues, newFields)
                        Call myCShowMessage.ShowSavedMsg("Hak pengguna " & cboUserID.SelectedValue & " pada form " & DirectCast(cboFormName.SelectedItem, DataRowView).Item("displayname"))
                        Call btnTampilkan_Click(sender, e)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                    Else
                        Call myCShowMessage.ShowInfo("Hak pengguna " & cboUserID.SelectedValue & " pada form " & DirectCast(cboFormName.SelectedItem, DataRowView).Item("displayname") & " sudah terdaftar")
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    updateString = Nothing
                    If (arrDefValues(3) <> cbCreate.Checked) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "menambah='" & cbCreate.Checked & "'"
                        foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("menambah") = cbCreate.Checked
                        End If
                    End If
                    If (arrDefValues(4) <> cbRead.Checked) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "melihat='" & cbRead.Checked & "'"
                        foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("melihat") = cbRead.Checked
                        End If
                    End If
                    If (arrDefValues(5) <> cbUpdate.Checked) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "memperbaharui='" & cbUpdate.Checked & "'"
                        foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("memperbaharui") = cbUpdate.Checked
                        End If
                    End If
                    If (arrDefValues(6) <> cbDelete.Checked) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "menghapus='" & cbDelete.Checked & "'"
                        foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("menghapus") = cbDelete.Checked
                        End If
                    End If
                    If (arrDefValues(7) <> cbPrint.Checked) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "mencetak='" & cbPrint.Checked & "'"
                        foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("mencetak") = cbPrint.Checked
                        End If
                    End If
                    If Not IsNothing(updateString) Then
                        updateString &= "," & ADD_INFO_.updateString
                        'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, CONN_.schemaHRD & ".msuserright", CONN_.dbType)
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".msuserright", updateString, "rid=" & arrDefValues(0))
                        Call myCShowMessage.ShowUpdatedMsg("Hak pengguna " & cboUserID.SelectedValue & " pada form " & DirectCast(cboFormName.SelectedItem, DataRowView).Item("displayname"))

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    End If
                End If
            Else
                Call myCShowMessage.ShowWarning("Pilih dulu username dan form nya!")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboPengguna_Validated(sender As Object, e As EventArgs) Handles cboUserID.Validated, cboFormName.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboPengguna_Validated Error")
        End Try
    End Sub

    Private Sub cbUserRights_CheckedChanged(sender As Object, e As EventArgs) Handles cbCreate.CheckedChanged, cbRead.CheckedChanged, cbUpdate.CheckedChanged, cbDelete.CheckedChanged
        Try
            If (cbCreate.Checked Or cbUpdate.Checked Or cbDelete.Checked) Then
                cbRead.Checked = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cbUserRights_CheckedChanged Error")
        End Try
    End Sub
End Class
