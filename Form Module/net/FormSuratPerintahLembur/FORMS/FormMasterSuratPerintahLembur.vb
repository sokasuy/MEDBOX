Public Class FormMasterSuratPerintahLembur
    Private stSQL As String
    Private myDataTableDGVHeader As New DataTable
    Private myBindingTableDGVHeader As New BindingSource
    Private myDataTableDGVDetail As New DataTable
    Private myBindingTableDGVDetail As New BindingSource
    Private banyakPages As Integer
    Private logRecordPage As Integer
    Private mCari As String
    Private isNew As Boolean
    'Private cmbDgvHeaderHapusButton As New DataGridViewButtonColumn()
    'Private cmbDgvDetailHapusButton As New DataGridViewButtonColumn()
    Private cmbDgvEditButton As New DataGridViewButtonColumn()
    Private cmbDgvCetakButton As New DataGridViewButtonColumn()
    Private cmbDgvAttachmentButton As New DataGridViewButtonColumn()
    Private cekTambahButton(3) As Boolean
    Private tableNameHeader As String
    Private tableNameDetail As String
    Private tableKey As String

    Private isDataPrepared As Boolean

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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterSuratPerintahLembur Error")
        End Try
    End Sub

    Private Sub FormMasterSuratPerintahLembur_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub
    Private Sub FormMasterSuratPerintahLembur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"TANGGAL", "PERUSAHAAN", "NO SPL", "NIP", "NAMA", "NIP KEPALA", "NAMA KEPALA"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            Call myCMiscFunction.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            If (clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menambah"))) Then
                btnCreateNew.Visible = True
            Else
                btnCreateNew.Visible = False
            End If

            tableNameHeader = "trsplheaderkaryawan"
            tableNameDetail = "trspldetailkaryawan"
            tableKey = "nospl"

            dtpAwal.Value = DateSerial(Now.Year, Now.Month, Now.Day - 14)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterSuratPerintahLembur_Load Error")
        End Try
    End Sub

    Private Sub FormMasterSuratPerintahLembur_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterSuratPerintahLembur_Activated Error")
        End Try
    End Sub

    Private Sub FormMasterSuratPerintahLembur_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpAwal.KeyDown, dtpAkhir.KeyDown, cboKriteria.KeyDown, btnCreateNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown, btnKeluar.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterSuratPerintahLembur_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    Private Sub SetDGV(myConn As Object, myComm As Object, myReader As Object, offSet As Integer, ByRef myDataTable As DataTable, ByRef myBindingTable As BindingSource, ByRef dgvView As DataGridView, mKriteria As String, Optional gantiKriteria As Boolean = False, Optional tipe As String = "header")
        Try
            Dim batas As Integer
            Dim mJumlah As Integer
            Dim mSelectedCriteria As String

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")

            If (tipe = "header") Then
                Dim mWhereString As String = Nothing
                mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                If (mSelectedCriteria = "NIP" Or mSelectedCriteria = "NAMA") Then
                    mWhereString = "(upper(d." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')"
                ElseIf (mSelectedCriteria = "NIPKEPALA" Or mSelectedCriteria = "NAMAKEPALA" Or mSelectedCriteria = "NOSPL" Or mSelectedCriteria = "PERUSAHAAN") Then
                    mWhereString = "(upper(h." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')"
                ElseIf (mSelectedCriteria = "TANGGAL") Then
                    mWhereString = "(h." & mSelectedCriteria & ">='" & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & "' and h." & mSelectedCriteria & "<='" & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy") & "')"
                End If

                If (gantiKriteria) Then
                    Dim tempSisa As Integer
                    'Dim tampTotalRecords As Integer
                    banyakPages = 0
                    stSQL = "SELECT COUNT(*) as JUM FROM (SELECT h.rid FROM (" & tableNameHeader & " as h inner join " & tableNameDetail & " as d on h." & tableKey & "=d." & tableKey & ") WHERE " & mWhereString & " GROUP BY h.rid) as TBL;"
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

                stSQL = "SELECT rid,perusahaan,tanggal,nospl as no_spl,idkkepala as idk_kepala,nipkepala as nip_kepala,namakepala as nama_kepala,bagian,divisi,departemen,catatan,created_at,updated_at " &
                        "FROM ( " &
                            "SELECT Top " & batas & " sub.rid,sub.perusahaan,sub.tanggal,sub.nospl,sub.idkkepala,sub.nipkepala,sub.namakepala,sub.bagian,sub.divisi,sub.departemen,sub.catatan,sub.created_at,sub.updated_at " &
                            "FROM ( " &
                                "SELECT TOP " & offSet & " h.rid,h.perusahaan,h.tanggal,h.nospl,h.idkkepala,h.nipkepala,h.namakepala,h.bagian,h.divisi,h.departemen,h.catatan,h.created_at,h.updated_at " &
                                "FROM (" & tableNameHeader & " as h inner join " & tableNameDetail & " as d on h." & tableKey & "=d." & tableKey & ") " &
                                "WHERE " & mWhereString &
                                "GROUP BY h.rid,h.perusahaan,h.tanggal,h.nospl,h.idkkepala,h.nipkepala,h.namakepala,h.bagian,h.divisi,h.departemen,h.catatan,h.created_at,h.updated_at " &
                                "ORDER BY (case when h.updated_at is null then h.created_at else h.updated_at end) DESC, h.rid DESC" &
                                ") sub " &
                            "ORDER BY (case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC" &
                        ") subOrdered " &
                        "ORDER BY (case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC;"
                myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "T_Header")
                myBindingTable.DataSource = myDataTable

                With dgvView
                    .DataSource = myBindingTable
                    .ReadOnly = True

                    .Columns("rid").Visible = False
                    .Columns("idk_kepala").Visible = False

                    For a As Integer = 0 To myDataTable.Columns.Count - 1
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                    Next

                    .Columns("tanggal").DefaultCellStyle.Format = "dd-MMM-yyyy"
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

                With cmbDgvAttachmentButton
                    If Not (cekTambahButton(1)) Then
                        .HeaderText = "ATTACHMENT"
                        .Name = "attachment"
                        .Text = "Attachment"
                        .UseColumnTextForButtonValue = True
                        dgvView.Columns.Add(cmbDgvAttachmentButton)
                        dgvView.Columns("attachment").Width = 90
                        cekTambahButton(1) = True
                    End If
                    .DisplayIndex = 1
                End With

                With cmbDgvCetakButton
                    If Not (cekTambahButton(2)) Then
                        .HeaderText = "CETAK"
                        .Name = "cetak"
                        .Text = "Cetak"
                        .UseColumnTextForButtonValue = True
                        dgvView.Columns.Add(cmbDgvCetakButton)
                        dgvView.Columns("cetak").Width = 70
                        cekTambahButton(2) = True
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
            ElseIf (tipe = "detail") Then
                stSQL = "SELECT d.rid, d.tanggal, d.nospl as no_spl, d.kdr, d.idk, d.nip, d.nama,d.bagian,d.divisi,d.departemen,d.perusahaan, d.pekerjaan, d.jamlembur as jam_lembur, d.mulai, d.selesai, d.catatan, d.created_at, d.updated_at
                        FROM " & tableNameHeader & " as h INNER JOIN " & tableNameDetail & " as d ON h." & tableKey & " = d." & tableKey & "
                        WHERE (((d." & tableKey & ")='" & myCStringManipulation.SafeSqlLiteral(mKriteria) & "'))
                        ORDER BY d.nama;"
                myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "T_Detail")
                myBindingTable.DataSource = myDataTable

                With dgvView
                    .DataSource = myBindingTable
                    .ReadOnly = True

                    .Columns("rid").Visible = False
                    .Columns("kdr").Visible = False
                    .Columns("idk").Visible = False
                    .Columns("perusahaan").Visible = False

                    For a As Integer = 0 To myDataTable.Columns.Count - 1
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                    Next
                    .Columns("tanggal").DefaultCellStyle.Format = "dd-MMM-yyyy"
                    .Columns("mulai").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                    .Columns("selesai").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                    .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                    .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                    .Font = New Font("Arial", 9, FontStyle.Regular)
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
                End With

                'untuk menampilkan auto number pada rowHeaders
                Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvView, dgvView.RowCount)

                'atur warna selang seling datagrid
                Call myCDataGridViewManipulation.SetDGVColour(dgvView)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetDGV Error")
        Finally
            Call myCDBConnection.CloseConn(myConn, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgv_Sorted(sender As Object, e As EventArgs) Handles dgvHeader.Sorted, dgvDetail.Sorted
        Try
            ''untuk menampilkan auto number pada rowHeaders
            If (sender Is dgvHeader) Then
                Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithPaging(sender, (Integer.Parse(tbRecordPage.Text) - 1) * 10)
            ElseIf (sender Is dgvDetail) Then
                Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(sender, sender.RowCount)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgv_Sorted Error")
        End Try
    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        Try
            mCari = myCStringManipulation.SafeSqlLiteral(tbCari.Text, 1)
            tbRecordPage.Text = 1
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGVHeader, myBindingTableDGVHeader, dgvHeader, mCari, True, "header")
            myDataTableDGVDetail.Clear()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTampilkan_Click Error")
        End Try
    End Sub

    Private Sub dgvHeader_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHeader.CellContentClick
        Try
            If (e.RowIndex <> -1) Then
                If (dgvHeader.RowCount > 0) Then
                    'Untuk menampilkan data detailnya
                    Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGVDetail, myBindingTableDGVDetail, dgvDetail, dgvHeader.CurrentRow.Cells("no_spl").Value, True, "detail")
                    If (e.ColumnIndex = dgvHeader.Columns("edit").Index) Then
                        isNew = False
                        Dim foundRows As DataRow()
                        foundRows = myDataTableDGVHeader.Select("rid=" & dgvHeader.CurrentRow.Cells("rid").Value)
                        Dim frmSuratPerintahLemburDetail As New FormSuratPerintahLemburDetail(myDataTableDGVHeader, myDataTableDGVDetail, tableNameHeader, tableNameDetail, tableKey, isNew, dgvHeader.CurrentRow.Cells("rid").Value, myDataTableDGVHeader.Rows.IndexOf(foundRows(0)), Me.Name)
                        Call myCFormManipulation.GoToForm(Me.MdiParent, frmSuratPerintahLemburDetail)
                    ElseIf (e.ColumnIndex = dgvHeader.Columns("attachment").Index) Then
                        Dim frmAttachmentDokumen As New FormAttachmentDokumen.FormAttachmentDokumen(CONN_.dbType, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, Trim(lblTitle.Text.Replace("MASTER", "")), Trim(dgvHeader.CurrentRow.Cells("no_spl").Value))
                        Call myCFormManipulation.GoToForm(Me.MdiParent, frmAttachmentDokumen)
                    ElseIf (e.ColumnIndex = dgvHeader.Columns("cetak").Index) Then
                        stSQL = "SELECT h." & tableKey & ", h.tanggal, h.nipkepala, h.namakepala, h.catatan as catheader, d.nip, d.nama, d.pekerjaan, d.jamlembur, d.mulai, d.selesai, d.catatan as catdetail
                                FROM (" & tableNameHeader & " AS h INNER JOIN " & tableNameDetail & " AS d ON h." & tableKey & " = d." & tableKey & ")
                                WHERE ((h." & tableKey & ")='" & dgvHeader.CurrentRow.Cells("no_spl").Value & "');"
                        'Dim frmDisplayReport As New FormDisplayReport.FormDisplayReport(CONN_.dbGlobal, stSQL, "BPP")
                        'Call myCFormManipulation.GoToForm(Me.MdiParent, frmDisplayReport)
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvHeader_CellContentClick Error")
        End Try
    End Sub

    Private Sub dgvDetail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellContentClick
        Try
            If (e.RowIndex <> -1) Then
                If (dgvDetail.RowCount > 0) Then
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_CellContentClick Error")
        End Try
    End Sub

    Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
        Try
            isNew = True
            Dim frmSuratPerintahLemburDetail As New FormSuratPerintahLemburDetail(myDataTableDGVHeader, myDataTableDGVDetail, tableNameHeader, tableNameDetail, tableKey, isNew,,, Me.Name)
            Call myCFormManipulation.GoToForm(Me.MdiParent, frmSuratPerintahLemburDetail)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCreateNew_Click Error")
        End Try
    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Try
            If (Integer.Parse(tbRecordPage.Text) - 1 > 0) Then
                tbRecordPage.Text = Integer.Parse(tbRecordPage.Text) - 1
                logRecordPage = tbRecordPage.Text
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, myDataTableDGVHeader, myBindingTableDGVHeader, dgvHeader, mCari, True, "header")
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
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, myDataTableDGVHeader, myBindingTableDGVHeader, dgvHeader, mCari, True, "header")
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
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGVHeader, myBindingTableDGVHeader, dgvHeader, mCari, True, "header")
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFForward_Click(sender As System.Object, e As System.EventArgs) Handles btnFFForward.Click
        Try
            tbRecordPage.Text = banyakPages
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, banyakPages * 10, myDataTableDGVHeader, myBindingTableDGVHeader, dgvHeader, mCari, True, "header")
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
                    Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, temp * 10, myDataTableDGVHeader, myBindingTableDGVHeader, dgvHeader, mCari, True, "header")
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

    Private Sub dgvView_CellMouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvHeader.CellMouseDown, dgvDetail.CellMouseDown
        Try
            'if di bawah ditambahkan pada 3 feb 2012 agar bisa pilih full row lebih dari 1,
            'karena kalau tidak ada if dibawah maka apabila sudah pilih full row pakai klik kiri
            'anggap saja mau pilih 3 full row, lalu di klik kanan, maka hanya row terakhir yang akan terpilih
            'oleh karena itu diberi if row yang dipilih tidak lebih dari 1, jadi klw milih banyak, fungsi di dalam if tidak akan dijalankan
            'dengan kata lain pada kasus ini klik kanan hanya untuk menampilkan konteks menu.
            'singkatnya, kalau sudah ada full row yang terpilih, maka fungsi di event ini tidak akan dijalankan
            If Not (sender.SelectedRows.Count > 1) Then
                'fungsi ini ditujukan agar user bisa memilih cell dengan klik kanan juga
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    If e.ColumnIndex = -1 = False And e.RowIndex = -1 = False Then
                        'kondisi ini untuk kalau user meng-klik kanan dalam area dgv bukan di header2nya
                        sender.ClearSelection()
                        sender.CurrentCell = sender.Item(e.ColumnIndex, e.RowIndex)
                        sender.Rows(e.RowIndex).Selected = True
                    Else
                        'kondisi ini untuk kalau user mengklik di header dgv nya
                        'selected cell sebelumnya di clear dulu
                        sender.ClearSelection()
                        'untuk mindah pointer
                        sender.CurrentCell = sender.Item(1, e.RowIndex)
                        'untuk select 1 baris penuh
                        sender.Rows(e.RowIndex).Selected = True
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellMouseDown Error")
        End Try
    End Sub

    Private Sub cboKriteria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKriteria.SelectedIndexChanged
        Try
            If (cboKriteria.SelectedItem = "TANGGAL") Then
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
