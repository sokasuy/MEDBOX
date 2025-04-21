Public Class FormMasterTunjanganMasaKerja
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
    Private cekTambahButton(2) As Boolean
    Private arrDefValues(5) As String
    Private tableName As String

    Private myDataTableCboPerusahaan As New DataTable
    Private myBindingPerusahaan As New BindingSource

    Private isCboPrepared As Boolean
    Private strKelompok As String

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaHRD As String, _connMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _entityChose As String, _addNewValues As String, _addNewFields As String, _addUpdateString As String, _lokasi As String)
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
                .entityChose = _entityChose
            End With
            With ADD_INFO_
                .newValues = _addNewValues
                .newFields = _addNewFields
                .updateString = _addUpdateString
            End With
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterTunjanganMasaKerja Error")
        End Try
    End Sub

    Private Sub FormMasterTunjanganMasaKerja_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormMasterTunjanganMasaKerja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"PERUSAHAAN", "KELOMPOK"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='perusahaan' and keterangan like '%" & USER_.entityChose & "' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPerusahaan, myBindingPerusahaan, cboPerusahaan, "T_" & cboPerusahaan.Name, "keterangan", "keterangan", isCboPrepared)

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "load")

            rbStaff.Checked = True

            numMulaiMasaKerja.Minimum = 0
            numMulaiMasaKerja.Maximum = 1000

            numSampaiMasaKerja.Minimum = 0
            numSampaiMasaKerja.Maximum = 1000

            numMulaiMasaKerja.Value = 0
            numSampaiMasaKerja.Value = 10

            tbTunjangan.Text = 0

            tableName = CONN_.schemaHRD & ".mstunjanganmasakerja"
            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterTunjanganMasaKerja_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormMasterTunjanganMasaKerja_KeyDown(sender As Object, e As KeyEventArgs) Handles cboPerusahaan.KeyDown, rbStaff.KeyDown, rbNonStaff.KeyDown, rbOutsource.KeyDown, numMulaiMasaKerja.KeyDown, numSampaiMasaKerja.KeyDown, tbTunjangan.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbTunjangan) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterTunjanganMasaKerja_KeyDown Error")
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

                stSQL = "SELECT count(*) FROM " & tableName & " WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%'));"
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

            stSQL = "SELECT rid,perusahaan,kelompok,mulaimasakerja as mulai_masa_kerja,sampaimasakerja as sampai_masa_kerja,tunjangan,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.perusahaan,sub.kelompok,sub.mulaimasakerja,sub.sampaimasakerja,sub.tunjangan,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.perusahaan,tbl.kelompok,tbl.mulaimasakerja,tbl.sampaimasakerja,tbl.tunjangan,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName & " as tbl " &
                            "WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " &
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
                .Columns("perusahaan").Frozen = True
                .Columns("kelompok").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("perusahaan").Width = 130
                .Columns("kelompok").Width = 80
                .Columns("mulai_masa_kerja").Width = 60
                .Columns("sampai_masa_kerja").Width = 60
                .Columns("tunjangan").Width = 80

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next

                .Columns("tunjangan").DefaultCellStyle.Format = "#,##"

                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                .Columns("tunjangan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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
                    .DisplayIndex = dgvView.Columns("kelompok").Index + 1
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

            rbNonStaff.Checked = True
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
                    If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then
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

                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus tunjangan karyawan untuk masa kerja " & dgvView.CurrentRow.Cells("mulaimasakerja").Value & " sampai masa kerja " & dgvView.CurrentRow.Cells("sampaimasakerja").Value & " tahun untuk kelompok " & dgvView.CurrentRow.Cells("kelompok").Value & " di perusahaan " & dgvView.CurrentRow.Cells("perusahaan").Value & " ?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = DialogResult.Yes) Then
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName, "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                        Call myCShowMessage.ShowDeletedMsg("Tunjangan karyawan untuk masa kerja " & dgvView.CurrentRow.Cells("mulaimasakerja").Value & " sampai masa kerja " & dgvView.CurrentRow.Cells("sampaimasakerja").Value & " tahun untuk kelompok " & dgvView.CurrentRow.Cells("kelompok").Value & " di perusahaan " & dgvView.CurrentRow.Cells("perusahaan").Value)
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan tunjangan karyawan untuk masa kerja " & dgvView.CurrentRow.Cells("mulaimasakerja").Value & " sampai masa kerja " & dgvView.CurrentRow.Cells("sampaimasakerja").Value & " tahun untuk kelompok " & dgvView.CurrentRow.Cells("kelompok").Value & " di perusahaan " & dgvView.CurrentRow.Cells("perusahaan").Value & " dibatalkan oleh user")
                    End If
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
                    'Perusahaan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("perusahaan").Value) Then
                        For i As Integer = 0 To cboPerusahaan.Items.Count - 1
                            If (DirectCast(cboPerusahaan.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("perusahaan").Value) Then
                                cboPerusahaan.SelectedIndex = i
                                arrDefValues(1) = dgvView.CurrentRow.Cells("perusahaan").Value
                            End If
                        Next
                    End If
                    'Kelompok
                    If Not IsDBNull(dgvView.CurrentRow.Cells("kelompok").Value) Then
                        If (dgvView.CurrentRow.Cells("kelompok").Value = "STAFF") Then
                            rbStaff.Checked = True
                        ElseIf (dgvView.CurrentRow.Cells("kelompok").Value = "NON STAFF") Then
                            rbNonStaff.Checked = True
                        ElseIf (dgvView.CurrentRow.Cells("kelompok").Value = "OUTSOURCE") Then
                            rbOutsource.Checked = True
                        End If
                        arrDefValues(2) = dgvView.CurrentRow.Cells("kelompok").Value
                        strKelompok = dgvView.CurrentRow.Cells("kelompok").Value
                    End If
                    'Mulai Masa Kerja
                    If Not IsDBNull(dgvView.CurrentRow.Cells("mulai_masa_kerja").Value) Then
                        numMulaiMasaKerja.Value = 999
                        numMulaiMasaKerja.Value = dgvView.CurrentRow.Cells("mulai_masa_kerja").Value
                        arrDefValues(3) = dgvView.CurrentRow.Cells("mulai_masa_kerja").Value
                    End If
                    'Sampai Masa Kerja
                    If Not IsDBNull(dgvView.CurrentRow.Cells("sampai_masa_kerja").Value) Then
                        numSampaiMasaKerja.Value = 0
                        numSampaiMasaKerja.Value = dgvView.CurrentRow.Cells("sampai_masa_kerja").Value
                        arrDefValues(4) = dgvView.CurrentRow.Cells("sampai_masa_kerja").Value
                    End If
                    'Tunjangan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tunjangan").Value) Then
                        tbTunjangan.Text = Double.Parse(dgvView.CurrentRow.Cells("tunjangan").Value)
                        arrDefValues(5) = Double.Parse(dgvView.CurrentRow.Cells("tunjangan").Value)
                    End If
                    Call tbTunjangan_Validated(tbTunjangan, e)
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
            If (cboPerusahaan.SelectedIndex <> -1 And Trim(tbTunjangan.Text).Length > 0) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                'Dim created_at As Date
                'created_at = Now
                'ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                If isNew Then
                    'CREATE NEW
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(strKelompok) & "' and mulaimasakerja=" & numMulaiMasaKerja.Value & " and sampaimasakerja=" & numSampaiMasaKerja.Value)
                    If Not isExist Then
                        'CREATE NEW
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(strKelompok) & "'," & numMulaiMasaKerja.Value & "," & numSampaiMasaKerja.Value & "," & Double.Parse(tbTunjangan.Text) & "," & ADD_INFO_.newValues
                        newFields = "perusahaan,kelompok,mulaimasakerja,sampaimasakerja,tunjangan," & ADD_INFO_.newFields
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName, newValues, newFields)
                        Call myCShowMessage.ShowSavedMsg("Tunjangan masa karyawan untuk masa kerja " & numMulaiMasaKerja.Value & " sampai masa kerja " & numSampaiMasaKerja.Value & " tahun untuk kelompok " & strKelompok & " di perusahaan " & cboPerusahaan.SelectedValue)
                        Call btnTampilkan_Click(sender, e)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowWarning("Sudah ada tunjangan karyawan untuk masa kerja " & numMulaiMasaKerja.Value & " sampai masa kerja " & numSampaiMasaKerja.Value & " tahun untuk kelompok " & strKelompok & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    updateString = Nothing
                    foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    If (arrDefValues(1) <> cboPerusahaan.SelectedValue) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(strKelompok) & "' and mulaimasakerja=" & numMulaiMasaKerja.Value & " and sampaimasakerja=" & numSampaiMasaKerja.Value)
                        If Not isExist Then
                            updateString = "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("perusahaan") = Trim(cboPerusahaan.SelectedValue)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Sudah ada tunjangan karyawan untuk masa kerja " & numMulaiMasaKerja.Value & " sampai masa kerja " & numSampaiMasaKerja.Value & " tahun untuk kelompok " & strKelompok & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                        End If
                    End If
                    If (arrDefValues(2) <> Trim(strKelompok)) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(strKelompok) & "' and mulaimasakerja=" & numMulaiMasaKerja.Value & " and sampaimasakerja=" & numSampaiMasaKerja.Value)
                        If Not isExist Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "kelompok='" & myCStringManipulation.SafeSqlLiteral(strKelompok) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kelompok") = Trim(strKelompok)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Sudah ada tunjangan karyawan untuk masa kerja " & numMulaiMasaKerja.Value & " sampai masa kerja " & numSampaiMasaKerja.Value & " tahun untuk kelompok " & strKelompok & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                        End If
                    End If
                    If (arrDefValues(3) <> Trim(numMulaiMasaKerja.Value)) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(strKelompok) & "' and mulaimasakerja=" & numMulaiMasaKerja.Value & " and sampaimasakerja=" & numSampaiMasaKerja.Value)
                        If Not isExist Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "mulaimasakerja='" & myCStringManipulation.SafeSqlLiteral(numMulaiMasaKerja.Value) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("mulai_masa_kerja") = Trim(numMulaiMasaKerja.Value)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Sudah ada tunjangan karyawan untuk masa kerja " & numMulaiMasaKerja.Value & " sampai masa kerja " & numSampaiMasaKerja.Value & " tahun untuk kelompok " & strKelompok & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                        End If
                    End If
                    If (arrDefValues(4) <> Trim(numSampaiMasaKerja.Value)) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(strKelompok) & "' and mulaimasakerja=" & numMulaiMasaKerja.Value & " and sampaimasakerja=" & numSampaiMasaKerja.Value)
                        If Not isExist Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "sampaimasakerja='" & myCStringManipulation.SafeSqlLiteral(numSampaiMasaKerja.Value) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("sampai_masa_kerja") = Trim(numSampaiMasaKerja.Value)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Sudah ada tunjangan karyawan untuk masa kerja " & numMulaiMasaKerja.Value & " sampai masa kerja " & numSampaiMasaKerja.Value & " tahun untuk kelompok " & strKelompok & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                        End If
                    End If

                    If Not IsNothing(updateString) Then
                        updateString &= "," & ADD_INFO_.updateString
                        'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName, CONN_.dbType)
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, updateString, "rid=" & arrDefValues(0))
                        Call myCShowMessage.ShowUpdatedMsg("Tunjangan karyawan untuk masa kerja " & numMulaiMasaKerja.Value & " sampai masa kerja " & numSampaiMasaKerja.Value & " tahun untuk kelompok " & strKelompok & " di perusahaan " & cboPerusahaan.SelectedValue)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "save")
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                tbTunjangan.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboPerusahaan.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub tbTunjangan_Enter(sender As Object, e As EventArgs) Handles tbTunjangan.Enter
        Try
            If (Trim(tbTunjangan.Text).Length > 0) Then
                tbTunjangan.Text = Double.Parse(tbTunjangan.Text)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbTunjangan_Enter Error")
        End Try
    End Sub

    Private Sub tbTunjangan_Validated(sender As Object, e As EventArgs) Handles tbTunjangan.Validated
        Try
            If (Trim(tbTunjangan.Text).Length > 0) Then
                tbTunjangan.Text = myCStringManipulation.CleanInputInteger(tbTunjangan.Text)
                Call myCStringManipulation.ValidateTextBoxNumber(tbTunjangan, tbTunjangan.Name)
            Else
                tbTunjangan.Text = 0
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbTunjangan_Validated Error")
        End Try
    End Sub

    Private Sub rbKelompok_CheckedChanged(sender As Object, e As EventArgs) Handles rbStaff.CheckedChanged, rbNonStaff.CheckedChanged, rbOutsource.CheckedChanged
        Try
            strKelompok = sender.text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbKelompok_CheckedChanged Error")
        End Try
    End Sub
End Class
