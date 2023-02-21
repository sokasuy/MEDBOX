Public Class FormMasterPosisiKaryawan
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

    Private myDataTableCboPosisi As New DataTable
    Private myBindingPosisi As New BindingSource

    Private isCboPrepared As Boolean
    Private enableSubForm(0) As Boolean

    Private Structure employee
        Dim idk As String
        Dim nip As String
        Dim nama As String
    End Structure

    Private karyawan As employee

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaHRD As String, _connMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String, _idk As String, _nip As String, _nama As String)
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
                .isSuperuser = _superuser
                .T_USER_RIGHT = _dtTableUserRights
            End With
            With ADD_INFO_
                .newValues = _addNewValues
                .newFields = _addNewFields
                .updateString = _addUpdateString
            End With

            With karyawan
                .idk = _idk
                .nip = _nip
                .nama = _nama
            End With

            tbNIP.Text = karyawan.nip
            tbNamaKaryawan.Text = karyawan.nama
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterPosisiKaryawan Error")
        End Try
    End Sub

    Private Sub FormMasterPosisiKaryawan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormMasterPosisiKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"POSISI"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT keterangan,kode FROM " & CONN_.schemaHRD & ".msgeneral where kategori='posisi' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPosisi, myBindingPosisi, cboPosisi, "T_" & cboPosisi.Name, "keterangan", "keterangan", isCboPrepared)

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

            lblSD.Visible = False
            dtpTanggalSelesaiMenjabat.Visible = False

            tableName = CONN_.schemaHRD & ".msposisikaryawan"

            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterPosisiKaryawan_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormMasterPosisiKaryawan_KeyDown(sender As Object, e As KeyEventArgs) Handles cboPosisi.KeyDown, dtpTanggalMulaiMenjabat.KeyDown, dtpTanggalSelesaiMenjabat.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is dtpTanggalMulaiMenjabat) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterPosisiKaryawan_KeyDown Error")
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

                stSQL = "SELECT count(*) FROM " & tableName & " WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') AND (nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "'));"
                mJumlah = Integer.Parse(myCDBOperation.GetDataIndividual(myConn, myComm, myReader, stSQL))

                If (mJumlah > 10) Then
                    banyakPages = mJumlah / 10
                Else
                    banyakPages = 1
                End If
                tempSisa = mJumlah Mod 10
                If (tempSisa <= 5 And tempSisa > 0 And mJumlah > 10) Then
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

            stSQL = "SELECT rid,idk,nip,posisi,aktif,untukskemafp as untuk_skema_fp,tglmulaimenjabat as tgl_mulai_menjabat,tglselesaimenjabat as tgl_selesai_menjabat,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.idk,sub.nip,sub.posisi,sub.aktif,sub.untukskemafp,sub.tglmulaimenjabat,sub.tglselesaimenjabat,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.idk,tbl.nip,tbl.posisi,tbl.aktif,tbl.untukskemafp,tbl.tglmulaimenjabat,tbl.tglselesaimenjabat,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName & " as tbl " &
                            "WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') AND (nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "')) " &
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
                .Columns("idk").Visible = False

                .Columns("rid").Frozen = True
                .Columns("idk").Frozen = True
                .Columns("nip").Frozen = True
                .Columns("posisi").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("nip").Width = 75
                .Columns("posisi").Width = 100
                .Columns("aktif").Width = 60
                .Columns("untuk_skema_fp").Width = 60
                .Columns("tgl_mulai_menjabat").Width = 80
                .Columns("tgl_selesai_menjabat").Width = 80

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next

                .Columns("tgl_mulai_menjabat").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tgl_selesai_menjabat").DefaultCellStyle.Format = "dd-MMM-yyyy"
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
                    .DisplayIndex = dgvView.Columns("posisi").Index + 1
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

            tbNIP.Text = karyawan.nip
            tbNamaKaryawan.Text = karyawan.nama
            cbAktif.Checked = True
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
                    If Not (dgvView.CurrentRow.Cells("untuk_skema_fp").Value) Then
                        'Kalau bukan untukskemafp
                        Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus posisi " & dgvView.CurrentRow.Cells("posisi").Value & " untuk karyawan " & tbNamaKaryawan.Text & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                        If (isConfirm = DialogResult.Yes) Then

                            Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName, "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                            Call myCShowMessage.ShowDeletedMsg("Posisi " & dgvView.CurrentRow.Cells("posisi").Value & " untuk karyawan " & tbNamaKaryawan.Text)
                            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)
                        Else
                            Call myCShowMessage.ShowInfo("Penghapusan posisi " & dgvView.CurrentRow.Cells("posisi").Value & " untuk karyawan " & tbNamaKaryawan.Text & " dibatalkan oleh user")
                        End If
                    Else
                        'Kalau untukskemafp, maka tidak diperbolehkan dihapus
                        Call myCShowMessage.ShowWarning("Posisi " & dgvView.CurrentRow.Cells("posisi").Value & " adalah jabatan untukskemafp" & ControlChars.NewLine & "Tidak diperkenankan dihapus!")
                    End If

                ElseIf (e.ColumnIndex = dgvView.Columns("attachment").Index) Then
                    Dim frmAttachmentKaryawan As New FormAttachmentKaryawan.FormAttachmentKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, dgvView.CurrentRow.Cells("idk").Value, karyawan.nama, dgvView.CurrentRow.Cells("nip").Value)
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
                    tbNIP.Text = karyawan.nip
                    tbNamaKaryawan.Text = karyawan.nama
                    'Posisi
                    If Not IsDBNull(dgvView.CurrentRow.Cells("posisi").Value) Then
                        For i As Integer = 0 To cboPosisi.Items.Count - 1
                            If (DirectCast(cboPosisi.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("posisi").Value) Then
                                cboPosisi.SelectedIndex = i
                                arrDefValues(1) = dgvView.CurrentRow.Cells("posisi").Value
                            End If
                        Next
                    End If
                    'Aktif
                    If Not IsDBNull(dgvView.CurrentRow.Cells("aktif").Value) Then
                        cbAktif.Checked = dgvView.CurrentRow.Cells("aktif").Value
                        arrDefValues(2) = dgvView.CurrentRow.Cells("aktif").Value
                    End If
                    'Tanggal Mulai Menjabat
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tgl_mulai_menjabat").Value) Then
                        dtpTanggalMulaiMenjabat.Value = dgvView.CurrentRow.Cells("tgl_mulai_menjabat").Value
                        arrDefValues(3) = dgvView.CurrentRow.Cells("tgl_mulai_menjabat").Value
                    End If
                    'Tanggal Selesai Menjabat
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tgl_selesai_menjabat").Value) Then
                        lblSD.Visible = True
                        dtpTanggalSelesaiMenjabat.Visible = True
                        dtpTanggalSelesaiMenjabat.Value = dgvView.CurrentRow.Cells("tgl_selesai_menjabat").Value
                        arrDefValues(4) = dgvView.CurrentRow.Cells("tgl_selesai_menjabat").Value
                    Else
                        lblSD.Visible = False
                        dtpTanggalSelesaiMenjabat.Visible = False
                    End If
                    'untukskemafp
                    If Not IsDBNull(dgvView.CurrentRow.Cells("untuk_skema_fp").Value) Then
                        cbUntukSkemaFP.Checked = dgvView.CurrentRow.Cells("untuk_skema_fp").Value
                        arrDefValues(5) = dgvView.CurrentRow.Cells("untuk_skema_fp").Value
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
            If (cboPosisi.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                'Dim created_at As Date
                'created_at = Now
                'ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                If isNew Then
                    'CREATE NEW
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "nip='" & tbNIP.Text & "' and posisi='" & myCStringManipulation.SafeSqlLiteral(cboPosisi.SelectedValue) & "' and aktif='True'")
                    If Not isExist Then
                        'CREATE NEW
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(karyawan.idk) & "','" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "','" & myCStringManipulation.SafeSqlLiteral(cboPosisi.SelectedValue) & "','" & cbAktif.Checked & "','" & cbUntukSkemaFP.Checked & "','" & Format(dtpTanggalMulaiMenjabat.Value.Date, "dd-MMM-yyyy") & "'," & ADD_INFO_.newValues
                        newFields = "idk,nip,posisi,aktif,untukskemafp,tglmulaimenjabat," & ADD_INFO_.newFields
                        If Not IsNothing(DirectCast(cboPosisi.SelectedItem, DataRowView).Item("kode")) Then
                            newValues &= "," & DirectCast(cboPosisi.SelectedItem, DataRowView).Item("kode")
                            newFields &= ",level"
                        Else
                            newValues &= ",1"
                            newFields &= ",level"
                        End If
                        If Not cbAktif.Checked Then
                            newValues &= ",'" & Format(dtpTanggalSelesaiMenjabat, "dd-MMM-yyyy") & "'"
                            newFields &= ",tglselesaimenjabat"
                        End If
                        If (cbUntukSkemaFP.Checked) Then
                            'Jika dicentang, maka bersihkan dulu centang di record lain
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, "untukskemafp='False'", "nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "'")
                        End If
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName, newValues, newFields)
                        Call myCShowMessage.ShowSavedMsg("Posisi " & cboPosisi.SelectedValue & " aktif untuk karyawan " & Trim(tbNamaKaryawan.Text))
                        Call btnTampilkan_Click(sender, e)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowWarning("Sudah ada posisi " & cboPosisi.SelectedValue & " yang aktif untuk karyawan " & Trim(tbNamaKaryawan.Text) & " !!")
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    updateString = Nothing
                    foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    If (arrDefValues(1) <> cboPosisi.SelectedValue) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "' and posisi='" & myCStringManipulation.SafeSqlLiteral(cboPosisi.SelectedValue) & "' and aktif='True'")
                        If Not isExist Then
                            updateString = "posisi='" & myCStringManipulation.SafeSqlLiteral(cboPosisi.SelectedValue) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("posisi") = Trim(cboPosisi.SelectedValue)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Posisi " & Trim(cboPosisi.SelectedValue) & " untuk karyawan " & Trim(tbNamaKaryawan.Text) & " sudah terdaftar!!")
                        End If
                    End If
                    If (arrDefValues(2) <> cbAktif.Checked) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "' and posisi='" & myCStringManipulation.SafeSqlLiteral(cboPosisi.SelectedValue) & "' and aktif='True'")
                        If Not isExist Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "aktif='" & cbAktif.Checked & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("aktif") = cbAktif.Checked
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Posisi " & Trim(cboPosisi.SelectedValue) & " untuk karyawan " & Trim(tbNamaKaryawan.Text) & " sudah terdaftar!!")
                        End If
                    End If
                    If (arrDefValues(3) <> dtpTanggalMulaiMenjabat.Value.Date) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tglmulaimenjabat='" & Format(dtpTanggalMulaiMenjabat.Value.Date, "dd-MMM-yyyy") & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tgl_mulai_menjabat") = dtpTanggalMulaiMenjabat.Value.Date
                        End If
                    End If
                    If (cbAktif.Checked) Then
                        If Not IsNothing(arrDefValues(4)) Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "tglselesaimenjabat=Null"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tgl_selesai_menjabat") = DBNull.Value
                            End If
                        End If
                    Else
                        If Not IsNothing(arrDefValues(4)) Then
                            If (arrDefValues(4) <> dtpTanggalSelesaiMenjabat.Value.Date) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "tglselesaimenjabat='" & Format(dtpTanggalSelesaiMenjabat.Value.Date, "dd-MMM-yyyy") & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tgl_selesai_menjabat") = dtpTanggalSelesaiMenjabat.Value.Date
                                End If
                            End If
                        Else
                            updateString &= IIf(IsNothing(updateString), "", ",") & "tglselesaimenjabat='" & Format(dtpTanggalSelesaiMenjabat.Value.Date, "dd-MMM-yyyy") & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tgl_selesai_menjabat") = dtpTanggalSelesaiMenjabat.Value.Date
                            End If
                        End If
                    End If
                    If (arrDefValues(5) <> cbUntukSkemaFP.Checked) Then
                        If (cbUntukSkemaFP.Checked) Then
                            'Jika dicentang, maka bersihkan dulu centang di record lain
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, "untukskemafp='False'", "nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "'")
                        End If
                        updateString &= IIf(IsNothing(updateString), "", ",") & "untukskemafp='" & cbUntukSkemaFP.Checked & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("untuk_skema_fp") = cbUntukSkemaFP.Checked
                        End If
                    End If

                    If Not IsNothing(updateString) Then
                        updateString &= "," & ADD_INFO_.updateString
                        'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName, CONN_.dbType)
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, updateString, "rid=" & arrDefValues(0))
                        Call myCShowMessage.ShowUpdatedMsg("Posisi " & Trim(cboPosisi.SelectedValue) & " untuk karyawan " & Trim(tbNamaKaryawan.Text))
                        Call btnTampilkan_Click(sender, e)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "save")
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                cboPosisi.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub cbAktif_CheckedChanged(sender As Object, e As EventArgs) Handles cbAktif.CheckedChanged
        Try
            'If (cbAktif.Checked) Then
            '    lblSD.Visible = False
            '    dtpTanggalSelesaiMenjabat.Visible = False
            'Else
            '    lblSD.Visible = True
            '    dtpTanggalSelesaiMenjabat.Visible = True
            'End If
            lblSD.Visible = Not cbAktif.Checked
            dtpTanggalSelesaiMenjabat.Visible = Not cbAktif.Checked
            If Not (cbAktif.Checked) Then
                cbUntukSkemaFP.Checked = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cbAktif_CheckedChanged Error")
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboPosisi.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub cboPosisi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPosisi.SelectedIndexChanged
        Try
            'If (isDataPrepared) Then
            '    Cursor = Cursors.WaitCursor
            '    Call myCDBConnection.OpenConn(CONN_.dbMain)

            '    Dim myRID As Integer
            '    myRID = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName,, "nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "' and untukskemafp='True'", CONN_.dbType)
            '    'stSQL = "SELECT rid FROM " & CONN_.schemaHRD & ".msposisikaryawan WHERE nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "' and untukskemafp='True';"
            '    isDataPrepared = False
            '    If (myRID = 0) Then
            '        'Kalau belum ada yang untukskemafp, maka harus dijadikan untukskemafp
            '        cbUntukSkemaFP.Checked = True
            '    Else
            '        cbUntukSkemaFP.Checked = False
            '    End If
            '    isDataPrepared = True
            'End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboPosisi_SelectedIndexChanged Error")
        Finally
            'If (isDataPrepared) Then
            '    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            '    Cursor = Cursors.Default
            'End If
        End Try
    End Sub

    Private Sub cbUntukSkemaFP_CheckedChanged(sender As Object, e As EventArgs) Handles cbUntukSkemaFP.CheckedChanged
        Try
            'If (isDataPrepared) Then
            '    If Not (cbUntukSkemaFP.Checked) Then
            '        Cursor = Cursors.WaitCursor
            '        Call myCDBConnection.OpenConn(CONN_.dbMain)

            '        Dim myRID As Integer
            '        myRID = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName,, "nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "' and untukskemafp='True'", CONN_.dbType)
            '        isDataPrepared = False
            '        If (myRID = 0) Then
            '            'Kalau belum ada yang untukskemafp, maka harus dijadikan untukskemafp
            '            Call myCShowMessage.ShowWarning("Data posisi yang pertama diinputkan harus jadi yang untukskemafp!!")
            '            cbUntukSkemaFP.Checked = True
            '        End If
            '        isDataPrepared = True
            '    End If
            'End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cbUtama_CheckedChanged Error")
        Finally
            'If (isDataPrepared) Then
            '    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            '    Cursor = Cursors.Default
            'End If
        End Try
    End Sub
End Class
