Public Class FormMasterRekeningKaryawan
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
    Private arrDefValues(8) As String
    Private tableName As String

    Private myDataTableCboKaryawan As New DataTable
    Private myBindingKaryawan As New BindingSource
    Private myDataTableCboBank As New DataTable
    Private myBindingBank As New BindingSource

    Private isCboPrepared As Boolean
    Private enableSubForm(0) As Boolean

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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterRekeningKaryawan Error")
        End Try
    End Sub

    Private Sub FormMasterRekeningKaryawan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormMasterRekeningKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"IDK", "NAMA", "BANK", "NO REK", "ATAS NAMA"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            'stSQL = "SELECT concat(tbl.nama,' || ',tbl.idk) as karyawan,idk,nama FROM " & CONN_.schemaHRD & ".mskaryawan as tbl left join " & CONN_.schemaHRD & ".mskaryawanaktif as tbl2 ON tbl.idk=tbl2.idk WHERE statusbekerja='AKTIF' GROUP BY concat(nama,' || ',idk),idk,nama ORDER BY karyawan;"
            'stSQL = "SELECT concat(tbl.nama,' || ',tbl.idk) as karyawan,tbl.idk,tbl.nama FROM " & CONN_.schemaHRD & ".mskaryawan as tbl left join " & CONN_.schemaHRD & ".mskaryawanaktif as tbl2 ON tbl.idk=tbl2.idk WHERE tbl.statusbekerja='AKTIF' " & IIf(USER_.lokasi = "ALL", "", "AND (tbl2.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "' OR tbl2.lokasi is null)") & " GROUP BY concat(tbl.nama,' || ',tbl.idk),tbl.idk,tbl.nama ORDER BY karyawan;"
            stSQL = "SELECT concat(tbl.nama,' || ',tbl.idk) as karyawan,tbl.idk,tbl.nama FROM " & CONN_.schemaHRD & ".mskaryawan as tbl WHERE tbl.statusbekerja='AKTIF' " & IIf(USER_.lokasi = "ALL", "", "AND (tbl.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " GROUP BY concat(tbl.nama,' || ',tbl.idk),tbl.idk,tbl.nama ORDER BY karyawan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "idk", "karyawan", isCboPrepared)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='bank' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboBank, myBindingBank, cboBank, "T_" & cboBank.Name, "keterangan", "keterangan", isCboPrepared)

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
                foundRows = USER_.T_USER_RIGHT.Select("formname='FormAttachmentKaryawan'")
                If (foundRows.Length = 0) Then
                    enableSubForm(0) = False
                Else
                    enableSubForm(0) = True
                End If
            End If

            tableName = CONN_.schemaHRD & ".msrekeningkaryawan"

            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterRekeningKaryawan_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormMasterRekeningKaryawan_KeyDown(sender As Object, e As KeyEventArgs) Handles cboKaryawan.KeyDown, cboBank.KeyDown, tbNoRekening.KeyDown, dtpTanggal.KeyDown, tbAtasNama.KeyDown, rtbKeterangan.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterRekeningKaryawan_KeyDown Error")
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

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                'Dim tampTotalRecords As Integer
                banyakPages = 0
                mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                'stSQL = "SELECT count(*) FROM " & tableName & " as tbl inner join (" & CONN_.schemaHRD & ".mskaryawan as tbl2 inner join " & CONN_.schemaHRD & ".mskaryawanaktif as tbl3 on tbl2.idk=tbl3.idk) on tbl.idk=tbl2.idk WHERE ((upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & IIf(USER_.lokasi = "ALL", "", "AND (tbl3.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & ";"
                stSQL = "SELECT count(*) FROM " & tableName & " as tbl inner join " & CONN_.schemaHRD & ".mskaryawan as tbl2 on tbl.idk=tbl2.idk WHERE ((upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & IIf(USER_.lokasi = "ALL", "", "AND (tbl2.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & ";"
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

            stSQL = "SELECT rid,idk,nama,bank,norek as no_rek,tanggal,atasnama as atas_nama,aktif,keterangan,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.idk,sub.nama,sub.bank,sub.norek,sub.tanggal,sub.atasnama,sub.aktif,sub.keterangan,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.idk,tbl.nama,tbl.bank,tbl.norek,tbl.tanggal,tbl.atasnama,tbl.aktif,tbl.keterangan,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName & " as tbl inner join " & CONN_.schemaHRD & ".mskaryawan as tbl2 on tbl.idk=tbl2.idk " &
                            "WHERE ((upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & IIf(USER_.lokasi = "ALL", "", "AND (tbl2.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " " &
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

                .Columns("rid").Frozen = True
                .Columns("idk").Frozen = True
                .Columns("nama").Frozen = True
                .Columns("bank").Frozen = True
                .Columns("no_rek").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("idk").Width = 75
                .Columns("nama").Width = 100
                .Columns("bank").Width = 80
                .Columns("no_rek").Width = 90
                .Columns("tanggal").Width = 80
                .Columns("atas_nama").Width = 100
                .Columns("aktif").Width = 100
                .Columns("keterangan").Width = 100

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

                .Columns("tanggal").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                .Font = New Font("Arial", 8, FontStyle.Regular)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End With

            With cmbDgvEditButton
                If Not (cekTambahButton(0)) Then
                    .HeaderText = "EDIT"
                    .Name = "edit"
                    .Text = "Edit"
                    .UseColumnTextForButtonValue = True
                    .DisplayIndex = dgvView.Columns("no_rek").Index + 1
                    dgvView.Columns.Add(cmbDgvEditButton)
                    dgvView.Columns("edit").Width = 70
                    cekTambahButton(0) = True
                    .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
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
                    .DisplayIndex = dgvView.ColumnCount
                    dgvView.Columns.Add(cmbDgvAttachmentButton)
                    dgvView.Columns("attachment").Width = 90
                    cekTambahButton(2) = True
                    .Visible = enableSubForm(0)
                End If
                .HeaderCell.Style.BackColor = Color.Yellow
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

                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data rekening " & dgvView.CurrentRow.Cells("no_rek").Value & " di bank " & dgvView.CurrentRow.Cells("bank").Value & " milik karyawan " & dgvView.CurrentRow.Cells("nama").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = DialogResult.Yes) Then
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName, "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                        Call myCShowMessage.ShowDeletedMsg("Rekening " & dgvView.CurrentRow.Cells("no_rek").Value & " di bank " & dgvView.CurrentRow.Cells("bank").Value & " milik karyawan " & dgvView.CurrentRow.Cells("nama").Value)
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan data rekening " & dgvView.CurrentRow.Cells("no_rek").Value & " di bank " & dgvView.CurrentRow.Cells("bank").Value & " milik karyawan " & dgvView.CurrentRow.Cells("nama").Value & " dibatalkan oleh user")
                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("attachment").Index) Then
                    Dim frmAttachmentKaryawan As New FormAttachmentKaryawan.FormAttachmentKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, dgvView.CurrentRow.Cells("idk").Value, dgvView.CurrentRow.Cells("nama").Value)
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmAttachmentKaryawan)
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
                    If Not IsDBNull(dgvView.CurrentRow.Cells("idk").Value) Then
                        For i As Integer = 0 To cboKaryawan.Items.Count - 1
                            If (DirectCast(cboKaryawan.Items(i), DataRowView).Item("idk") = dgvView.CurrentRow.Cells("idk").Value) Then
                                cboKaryawan.SelectedIndex = i
                                arrDefValues(1) = dgvView.CurrentRow.Cells("idk").Value
                                arrDefValues(2) = dgvView.CurrentRow.Cells("nama").Value
                            End If
                        Next
                        cboKaryawan.Enabled = False
                    End If
                    'Bank
                    If Not IsDBNull(dgvView.CurrentRow.Cells("bank").Value) Then
                        For i As Integer = 0 To cboBank.Items.Count - 1
                            If (DirectCast(cboBank.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("bank").Value) Then
                                cboBank.SelectedIndex = i
                                arrDefValues(3) = dgvView.CurrentRow.Cells("bank").Value
                            End If
                        Next
                    End If
                    'NoRek
                    If Not IsDBNull(dgvView.CurrentRow.Cells("no_rek").Value) Then
                        tbNoRekening.Text = dgvView.CurrentRow.Cells("no_rek").Value
                        arrDefValues(4) = dgvView.CurrentRow.Cells("no_rek").Value
                    End If
                    'Tanggal
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal").Value) Then
                        dtpTanggal.Value = dgvView.CurrentRow.Cells("tanggal").Value
                        arrDefValues(5) = dgvView.CurrentRow.Cells("tanggal").Value
                    End If
                    'Atas Nama
                    If Not IsDBNull(dgvView.CurrentRow.Cells("atas_nama").Value) Then
                        tbAtasNama.Text = dgvView.CurrentRow.Cells("atas_nama").Value
                        arrDefValues(6) = dgvView.CurrentRow.Cells("atas_nama").Value
                    End If
                    'Aktif
                    If Not IsDBNull(dgvView.CurrentRow.Cells("aktif").Value) Then
                        cbAktif.Checked = dgvView.CurrentRow.Cells("aktif").Value
                        arrDefValues(7) = dgvView.CurrentRow.Cells("aktif").Value
                    End If
                    'Keterangan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("keterangan").Value) Then
                        rtbKeterangan.Text = dgvView.CurrentRow.Cells("keterangan").Value
                        arrDefValues(8) = dgvView.CurrentRow.Cells("keterangan").Value
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
            If (cboKaryawan.SelectedIndex <> -1 And cboBank.SelectedIndex <> -1 And Trim(tbNoRekening.Text).Length > 0 And Trim(tbAtasNama.Text).Length > 0) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                'Dim created_at As Date
                'created_at = Now
                'ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                If isNew Then
                    'CREATE NEW
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "bank='" & myCStringManipulation.SafeSqlLiteral(cboBank.SelectedValue) & "' and norek='" & myCStringManipulation.SafeSqlLiteral(tbNoRekening.Text) & "'")
                    If Not isExist Then
                        'CREATE NEW
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & "','" & myCStringManipulation.SafeSqlLiteral(cboBank.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(tbNoRekening.Text) & "','" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(tbAtasNama.Text) & "','" & cbAktif.Checked & "'," & ADD_INFO_.newValues
                        newFields = "idk,nama,bank,norek,tanggal,atasnama,aktif," & ADD_INFO_.newFields
                        If Trim(rtbKeterangan.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(rtbKeterangan.Text) & "'"
                            newFields &= ",keterangan"
                        End If
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName, newValues, newFields)
                        Call myCShowMessage.ShowSavedMsg("Rekening " & Trim(tbNoRekening.Text) & " di Bank " & Trim(cboBank.SelectedValue) & " milik karyawan " & Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")))
                        Call btnTampilkan_Click(sender, e)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowWarning("Sudah ada data rekening " & Trim(tbNoRekening.Text) & " di Bank " & Trim(cboBank.SelectedValue) & " !!")
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    updateString = Nothing
                    foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    'If (arrDefValues(2) <> DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) Then
                    '    'Seharusnya nama tidak boleh di update, karena buat melakukan pengecekan apabila sampai terjadi kesalahan transfer karena keliru input nama di data karyawan
                    '    'Sementara di comment dulu PER 12 NOVEMBER 2021
                    '    updateString = "nama='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & "'"
                    '    If (foundRows.Length > 0) Then
                    '        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama") = Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama"))
                    '    End If
                    'End If
                    If (arrDefValues(3) <> cboBank.SelectedValue) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "bank='" & myCStringManipulation.SafeSqlLiteral(cboBank.SelectedValue) & "' and norek='" & myCStringManipulation.SafeSqlLiteral(tbNoRekening.Text) & "'")
                        If Not isExist Then
                            updateString = "bank='" & myCStringManipulation.SafeSqlLiteral(cboBank.SelectedValue) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("bank") = Trim(cboBank.SelectedValue)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Sudah ada data rekening " & Trim(tbNoRekening.Text) & " di Bank " & Trim(cboBank.SelectedValue) & " !!")
                        End If
                    End If
                    If (arrDefValues(4) <> Trim(tbNoRekening.Text)) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "bank='" & myCStringManipulation.SafeSqlLiteral(cboBank.SelectedValue) & "' and norek='" & myCStringManipulation.SafeSqlLiteral(tbNoRekening.Text) & "'")
                        If Not isExist Then
                            updateString = "norek='" & myCStringManipulation.SafeSqlLiteral(tbNoRekening.Text) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("no_rek") = Trim(tbNoRekening.Text)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Sudah ada data rekening " & Trim(tbNoRekening.Text) & " di Bank " & Trim(cboBank.SelectedValue) & " !!")
                        End If
                    End If
                    If (arrDefValues(5) <> dtpTanggal.Value.Date) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tanggal='" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal") = dtpTanggal.Value.Date
                        End If
                    End If
                    If (arrDefValues(6) <> Trim(tbAtasNama.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "atasnama=" & IIf(Trim(tbAtasNama.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbAtasNama.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("atas_nama") = Trim(tbAtasNama.Text)
                        End If
                    End If
                    If (arrDefValues(7) <> cbAktif.Checked) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "aktif='" & cbAktif.Checked & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("aktif") = cbAktif.Checked
                        End If
                    End If
                    If (arrDefValues(8) <> Trim(rtbKeterangan.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "keterangan=" & IIf(Trim(rtbKeterangan.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(rtbKeterangan.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("keterangan") = Trim(rtbKeterangan.Text)
                        End If
                    End If

                    If Not IsNothing(updateString) Then
                        updateString &= "," & ADD_INFO_.updateString
                        'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName, CONN_.dbType)
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, updateString, "rid=" & arrDefValues(0))
                        Call myCShowMessage.ShowUpdatedMsg("Rekening " & Trim(tbNoRekening.Text) & " di Bank " & Trim(cboBank.SelectedValue) & " milik karyawan " & Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")))

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                cbAktif.Checked = True
                Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "save")
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                cboBank.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboKaryawan.Validated, cboBank.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub tbAutoCapital_Validated(sender As Object, e As EventArgs) Handles tbAtasNama.Validated
        Try
            sender.text = sender.text.ToString.ToUpper
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbAutoCapital_Validated Error")
        End Try
    End Sub
End Class
