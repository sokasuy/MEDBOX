Public Class FormMasterGeneral
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
    Private cekTambahButton(1) As Boolean
    Private arrDefValues(3) As String
    Private tableName(1) As String

    Private myDataTableCboKategori As New DataTable
    Private myBindingKategori As New BindingSource
    Private myDataTableCboCariKategori As New DataTable
    Private myBindingCariKategori As New BindingSource
    Private myDataTableColumnNames As New DataTable
    Private myBindingColumnNames As New BindingSource

    Private isCboPrepared As Boolean

    Private Structure employee
        Dim idk As String
        Dim nip As String
        Dim nama As String
    End Structure

    Private karyawan As employee

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaHRD As String, _ConnMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            isDataPrepared = False
            With CONN_
                .dbType = _dbType
                .dbMain = _ConnMain
                .schemaTmp = _schemaTmp
                .schemaHRD = _schemaHRD
            End With
            With USER_
                .username = _username
                .isSuperuser = _superuser
                .T_USER_RIGHT = _dtTableUserRights
            End With
            With ADD_INFO_
                .newValues = _addNewValues
                .newFields = _addNewFields
                .updateString = _addUpdateString
            End With
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterGeneral Error")
        End Try
    End Sub

    Private Sub FormMasterGeneral_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormMasterGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"KODE", "KETERANGAN"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 1

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT kategori,locked FROM " & CONN_.schemaHRD & ".msgeneralcategorylist WHERE locked='False' ORDER BY kategori;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKategori, myBindingKategori, cboKategori, "T_" & cboKategori.Name, "kategori", "kategori", isCboPrepared)
            stSQL = "SELECT kategori,locked FROM " & CONN_.schemaHRD & ".msgeneralcategorylist ORDER BY kategori;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboCariKategori, myBindingCariKategori, cboCariKategori, "T_" & cboCariKategori.Name, "kategori", "kategori", isCboPrepared)

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "load")

            stSQL = "SELECT column_name FROM INFORMATION_SCHEMA. COLUMNS WHERE TABLE_NAME = 'msgeneral' and column_name NOT IN('created_at','updated_at') ORDER BY column_name ASC;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableColumnNames, myBindingColumnNames, cboSortingCriteria, "T_" & cboSortingCriteria.Name, "column_name", "column_name", isCboPrepared)

            arrCbo = {"ASC", "DESC"}
            cboSortingType.Items.AddRange(arrCbo)
            cboSortingType.SelectedIndex = 0

            tableName(0) = CONN_.schemaHRD & ".msgeneral"
            tableName(1) = CONN_.schemaHRD & ".msgeneralcategorylist"

            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterGeneral_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormMasterGeneral_KeyDown(sender As Object, e As KeyEventArgs) Handles cboKategori.KeyDown, tbKeterangan.KeyDown, tbKode.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbKode) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterGeneral_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    Private Sub SetDGV(myConn As Object, myComm As Object, myReader As Object, offSet As Integer, ByRef myDataTable As DataTable, ByRef myBindingTable As BindingSource, mKriteria As String, Optional gantiKriteria As Boolean = False, Optional sortingCols As String = Nothing, Optional sortingType As String = Nothing)
        Try
            Dim batas As Integer
            Dim mJumlah As Integer
            Dim mSelectedCriteria As String
            Dim mGroupCriteria As String = Nothing

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")
            If (cboCariKategori.SelectedIndex <> -1) Then
                mGroupCriteria = " AND (tbl2.kategori='" & myCStringManipulation.SafeSqlLiteral(cboCariKategori.SelectedValue) & "')"
            End If

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                'Dim tampTotalRecords As Integer
                banyakPages = 0
                mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                stSQL = "SELECT count(*) FROM " & tableName(0) & " as tbl INNER JOIN " & tableName(1) & " as tbl2 on tbl.kategori=tbl2.kategori WHERE ((upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & mGroupCriteria & ";"
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

            stSQL = "SELECT rid,kategori,kode,keterangan,locked,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.kategori,sub.kode,sub.keterangan,sub.locked,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.kategori,tbl.kode,tbl.keterangan,tbl2.locked,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName(0) & " as tbl INNER JOIN " & tableName(1) & " as tbl2 on tbl.kategori=tbl2.kategori " &
                            "WHERE ((upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & mGroupCriteria & " " &
                            "ORDER BY " & IIf(IsNothing(sortingCols), "(case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC ", sortingCols & " " & sortingType) & " " &
                            "LIMIT " & offSet &
                            ") sub " &
                        "ORDER BY " & IIf(IsNothing(sortingCols), "(case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC ", sortingCols & " " & IIf(sortingType = "ASC", "DESC", "ASC")) & " " &
                        "LIMIT " & batas &
                    ") subOrdered " &
                    "ORDER BY " & IIf(IsNothing(sortingCols), "(case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC ", sortingCols & " " & sortingType) & ";"
            myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "TBL " & lblTitle.Text)
            myBindingTable.DataSource = myDataTable

            With dgvView
                .DataSource = myBindingTable
                .ReadOnly = True

                .Columns("rid").Visible = False

                .Columns("rid").Frozen = True
                .Columns("kategori").Frozen = True
                .Columns("keterangan").Frozen = True

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
                    .DisplayIndex = dgvView.Columns("keterangan").Index + 1
                    dgvView.Columns.Add(cmbDgvEditButton)
                    dgvView.Columns("edit").Width = 70
                    cekTambahButton(0) = True
                    .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Frozen = True
                End If
                .HeaderCell.Style.BackColor = Color.Lime
            End With

            With cmbDgvHapusButton
                If Not (cekTambahButton(1)) Then
                    .HeaderText = "HAPUS"
                    .Name = "delete"
                    .Text = "Hapus Record"
                    .UseColumnTextForButtonValue = True
                    .DisplayIndex = dgvView.ColumnCount
                    dgvView.Columns.Add(cmbDgvHapusButton)
                    dgvView.Columns("delete").Width = 100
                    cekTambahButton(1) = True
                    .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                End If
                .HeaderCell.Style.BackColor = Color.LightSalmon
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
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTampilkan_Click Error")
        End Try
    End Sub

    Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
        Try
            isNew = True
            lblEntryType.Text = "INSERT NEW"
            isDataPrepared = True

            cboKategori.Enabled = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCreateNew_Click Error")
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Try
            If (Integer.Parse(tbRecordPage.Text) - 1 > 0) Then
                tbRecordPage.Text = Integer.Parse(tbRecordPage.Text) - 1
                logRecordPage = tbRecordPage.Text
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
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
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
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
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFForward_Click(sender As Object, e As EventArgs) Handles btnFFForward.Click
        Try
            tbRecordPage.Text = banyakPages
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, banyakPages * 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
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
                    Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, temp * 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
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

                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data di master general dengan keterangan " & dgvView.CurrentRow.Cells("keterangan").Value & " untuk kategori " & dgvView.CurrentRow.Cells("kategori").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = DialogResult.Yes) Then
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                        Call myCShowMessage.ShowDeletedMsg("Data di master general dengan keterangan " & dgvView.CurrentRow.Cells("keterangan").Value & " untuk kategori " & dgvView.CurrentRow.Cells("kategori").Value)
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan data di master general dengan keterangan " & dgvView.CurrentRow.Cells("keterangan").Value & " untuk kategori " & dgvView.CurrentRow.Cells("kategori").Value)
                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("edit").Index) Then
                    If (dgvView.CurrentRow.Cells("locked").Value) Then
                        Call myCShowMessage.ShowWarning("Kategori " & dgvView.CurrentRow.Cells("kategori").Value & " dikunci! Tidak dapat dilakukan perubahan data")
                    Else
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
                        'Kategori
                        If Not IsDBNull(dgvView.CurrentRow.Cells("kategori").Value) Then
                            For i As Integer = 0 To cboKategori.Items.Count - 1
                                If (DirectCast(cboKategori.Items(i), DataRowView).Item("kategori") = dgvView.CurrentRow.Cells("kategori").Value) Then
                                    cboKategori.SelectedIndex = i
                                    arrDefValues(1) = dgvView.CurrentRow.Cells("kategori").Value
                                End If
                            Next
                            cboKategori.Enabled = False
                        End If
                        'Keterangan
                        If Not IsDBNull(dgvView.CurrentRow.Cells("keterangan").Value) Then
                            tbKeterangan.Text = dgvView.CurrentRow.Cells("keterangan").Value
                            arrDefValues(2) = dgvView.CurrentRow.Cells("keterangan").Value
                        End If
                        'Kode
                        If Not IsDBNull(dgvView.CurrentRow.Cells("kode").Value) Then
                            tbKode.Text = dgvView.CurrentRow.Cells("kode").Value
                            arrDefValues(3) = dgvView.CurrentRow.Cells("kode").Value
                        End If
                        isDataPrepared = True
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
            If (Trim(tbKeterangan.Text).Length > 0 And cboKategori.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                'Dim created_at As Date
                'created_at = Now
                'ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                If isNew Then
                    'CREATE NEW
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "kategori='" & myCStringManipulation.SafeSqlLiteral(cboKategori.SelectedValue) & "' and keterangan='" & myCStringManipulation.SafeSqlLiteral(tbKeterangan.Text) & "'")
                    If Not isExist Then
                        'CREATE NEW
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(cboKategori.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(tbKeterangan.Text) & "'," & ADD_INFO_.newValues
                        newFields = "kategori,keterangan," & ADD_INFO_.newFields
                        If (Trim(tbKode.Text).Length > 0) Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbKode.Text) & "'"
                            newFields &= ",kode"
                        End If
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(0), newValues, newFields)
                        Call myCShowMessage.ShowSavedMsg("Data di master general dengan keterangan " & tbKeterangan.Text & " untuk kategori " & cboKategori.SelectedValue)
                        Call btnTampilkan_Click(sender, e)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowWarning("Sudah ada data di master general dengan keterangan " & tbKeterangan.Text & " untuk kategori " & cboKategori.SelectedValue & " !!")
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    updateString = Nothing
                    foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    If (arrDefValues(1) <> cboKategori.SelectedValue) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "kategori='" & myCStringManipulation.SafeSqlLiteral(cboKategori.SelectedValue) & "' and keterangan='" & myCStringManipulation.SafeSqlLiteral(tbKeterangan.Text) & "'")
                        If Not isExist Then
                            updateString = "kategori='" & myCStringManipulation.SafeSqlLiteral(cboKategori.SelectedValue) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kategori") = Trim(cboKategori.SelectedValue)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Sudah ada data di master general dengan keterangan " & tbKeterangan.Text & " untuk kategori " & cboKategori.SelectedValue & " !!")
                        End If
                    End If
                    If (arrDefValues(2) <> Trim(tbKeterangan.Text)) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "kategori='" & myCStringManipulation.SafeSqlLiteral(cboKategori.SelectedValue) & "' and keterangan='" & myCStringManipulation.SafeSqlLiteral(tbKeterangan.Text) & "'")
                        If Not isExist Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "keterangan='" & myCStringManipulation.SafeSqlLiteral(tbKeterangan.Text) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("keterangan") = Trim(tbKeterangan.Text)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Sudah ada data di master general dengan keterangan " & tbKeterangan.Text & " untuk kategori " & cboKategori.SelectedValue & " !!")
                        End If
                    End If
                    If (arrDefValues(3) <> Trim(tbKode.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "kode=" & IIf(Trim(tbKode.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbKode.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kode") = Trim(tbKode.Text)
                        End If
                    End If

                    If Not IsNothing(updateString) Then
                        updateString &= "," & ADD_INFO_.updateString
                        'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName(0), CONN_.dbType)
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), updateString, "rid=" & arrDefValues(0))
                        Call myCShowMessage.ShowUpdatedMsg("Data di master general dengan keterangan " & tbKeterangan.Text & " untuk kategori " & cboKategori.SelectedValue)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "save")
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                cboKategori.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub tbAutoCapital_Validated(sender As Object, e As EventArgs) Handles tbKeterangan.Validated, tbKode.Validated
        Try
            sender.text = sender.text.ToString.ToUpper
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbAutoCapital_Validated Error")
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

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Try
            If (Trim(tbPathSimpan.Text).Length > 0 And Trim(tbNamaSimpan.Text).Length > 0) Then
                If (cboCariKategori.SelectedIndex <> -1) Then
                    Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    Dim myDataTableExportExcel As New DataTable
                    Dim xlspath As String
                    Dim xlsfilename As String
                    Dim xlsLocFile As String

                    stSQL = "SELECT kategori,kode,keterangan,faktorqty FROM " & CONN_.schemaHRD & ".msgeneral WHERE kategori='" & myCStringManipulation.SafeSqlLiteral(cboCariKategori.SelectedValue) & "' GROUP BY kategori,kode,keterangan,faktorqty ORDER BY keterangan;"
                    myDataTableExportExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "MasterGeneral")

                    xlspath = tbPathSimpan.Text
                    xlsfilename = tbNamaSimpan.Text

                    xlsLocFile = xlspath & xlsfilename & "_" & Format(Now(), "ddMMMyyyy")

                    Call myCFileIO.PopulateSheet(myDataTableExportExcel, xlsLocFile, cboCariKategori.SelectedValue & " " & Format(Now(), "ddMMMyyyy HHmm"))

                    Call myCShowMessage.ShowInfo("Export ke excel sukses, dengan nama " & xlsfilename & "_" & Format(Now(), "ddMMMyyyy"), "Export Complete")
                Else
                    cboCariKategori.Focus()
                    Call myCShowMessage.ShowWarning("Silahkan tentukan dulu kategorinya yang akan di ekspor")
                End If
            Else
                Call myCShowMessage.ShowInfo("Tolong tentukan dulu nama dan lokasi file excel yang akan di ekspor!")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnExportExcel_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Cursor = Cursors.Default
        End Try
    End Sub
End Class
