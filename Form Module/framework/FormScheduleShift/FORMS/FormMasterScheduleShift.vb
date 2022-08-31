Public Class FormMasterScheduleShift
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
    Private arrStrTanggal() As String

    Private isDataPrepared As Boolean
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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterScheduleShift Error")
        End Try
    End Sub

    Private Sub FormMasterScheduleShift_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormMasterScheduleShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            If (USER_.lokasi = "ALL") Then
                arrCbo = {"LOKASI", "PERUSAHAAN", "DEPARTEMEN", "TANGGAL", "NIP", "NAMA"}
            Else
                arrCbo = {"PERUSAHAAN", "DEPARTEMEN", "TANGGAL", "NIP", "NAMA"}
            End If
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            btnCreateNew.Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menambah"))
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

            tableNameHeader = CONN_.schemaHRD & ".trscheduleshiftheader"
            tableNameDetail = CONN_.schemaHRD & ".trscheduleshiftdetail"
            tableKey = "noscheduleshift"

            dtpAwal.Value = DateSerial(Now.Year, Now.Month, Now.Day - 14)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterScheduleShift_Load Error")
        End Try
    End Sub

    Private Sub FormMasterScheduleShift_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)

            If (dgvDetail.Rows.Count > 0) Then
                'Untuk mengatur warna background cell, agar dapat lebih mudah dibedakan saja
                With dgvDetail
                    For i As UShort = 0 To .Rows.Count - 1
                        For j As UShort = 0 To .Columns.Count - 1
                            If Not (.Columns(j).HeaderText.Contains("(")) Then
                                .Columns(j).DefaultCellStyle.BackColor = Color.White
                            Else
                                .CurrentCell = .Item(j, i)
                                If Not IsDBNull(.CurrentCell.Value) Then
                                    If (.CurrentCell.Value = "P") Then
                                        .CurrentCell.Style.BackColor = Color.Yellow
                                    ElseIf (.CurrentCell.Value = "S") Then
                                        .CurrentCell.Style.BackColor = Color.Aqua
                                    ElseIf (.CurrentCell.Value = "M") Then
                                        .CurrentCell.Style.BackColor = Color.Lime
                                    ElseIf (.CurrentCell.Value = "X") Then
                                        .CurrentCell.Style.BackColor = Color.LightSalmon
                                    End If
                                Else
                                    .CurrentCell.Style.BackColor = Color.Silver
                                End If
                            End If
                        Next
                    Next
                    'Untuk kembalikan current cell ke kolom paling awal lagi dan baris paling atas
                    .CurrentCell = .Item(.Columns("nip").Index, 0)
                End With
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterScheduleShift_Activated Error")
        End Try
    End Sub

    Private Sub FormMasterScheduleShift_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpAwal.KeyDown, dtpAkhir.KeyDown, cboKriteria.KeyDown, btnCreateNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown, btnKeluar.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbCari) Then
                    'Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterScheduleShift_KeyDown Error")
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
                    mWhereString = "(upper(d." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') "
                ElseIf (mSelectedCriteria = "LOKASI" Or mSelectedCriteria = "PERUSAHAAN" Or mSelectedCriteria = "DEPARTEMEN") Then
                    mWhereString = "(upper(h." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') "
                ElseIf (mSelectedCriteria = "TANGGAL") Then
                    mWhereString = "(h.tanggalawal>='" & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & "' and h.tanggalakhir<='" & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy") & "') "
                End If

                If (gantiKriteria) Then
                    Dim tempSisa As Integer
                    'Dim tampTotalRecords As Integer
                    banyakPages = 0
                    stSQL = "SELECT COUNT(*) as JUM FROM (SELECT h.rid FROM (" & tableNameHeader & " as h inner join " & tableNameDetail & " as d on h." & tableKey & "=d." & tableKey & ") WHERE " & mWhereString & IIf(USER_.lokasi = "ALL", "", "AND (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " GROUP BY h.rid) as TBL;"
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

                stSQL = "SELECT rid,perusahaan,lokasi,departemen,grup,ketgrup as ket_grup," & tableKey & " as no_schedule_shift,tanggalawal as tanggal_awal,tanggalakhir as tanggal_akhir,catatan,created_at,updated_at " &
                        "FROM ( " &
                            "SELECT sub.rid,sub.perusahaan,sub.departemen,sub.lokasi,sub.grup,sub.ketgrup,sub." & tableKey & ",sub.tanggalawal,sub.tanggalakhir,sub.catatan,sub.created_at,sub.updated_at " &
                            "FROM ( " &
                                "SELECT h.rid,h.perusahaan,h.departemen,h.lokasi,h.grup,h.ketgrup,h." & tableKey & ",h.tanggalawal,h.tanggalakhir,h.catatan,h.created_at,h.updated_at " &
                                "FROM (" & tableNameHeader & " as h inner join " & tableNameDetail & " as d on h." & tableKey & "=d." & tableKey & ") " &
                                "WHERE " & mWhereString & IIf(USER_.lokasi = "ALL", "", "AND (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " " &
                                "GROUP BY h.rid,h.perusahaan,h.departemen,h.lokasi,h.grup,h.ketgrup,h." & tableKey & ",h.tanggalawal,h.tanggalakhir,h.catatan,h.created_at,h.updated_at " &
                                "ORDER BY (case when h.updated_at is null then h.created_at else h.updated_at end) DESC, h.rid DESC " &
                                "LIMIT " & offSet &
                                ") sub " &
                            "ORDER BY (case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC " &
                            "LIMIT " & batas &
                        ") subOrdered " &
                        "ORDER BY (case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC;"
                myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "T_Header" & lblTitle.Text)
                myBindingTable.DataSource = myDataTable

                With dgvView
                    .DataSource = myBindingTable
                    .ReadOnly = True

                    .Columns("rid").Visible = False

                    .Columns("rid").Frozen = True
                    .Columns("perusahaan").Frozen = True
                    .Columns("departemen").Frozen = True
                    .Columns("grup").Frozen = True
                    .Columns("ket_grup").Frozen = True

                    .EnableHeadersVisualStyles = False
                    For i As Integer = 0 To .Columns.Count - 1
                        If (.Columns(i).Frozen) Then
                            .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                        End If
                    Next

                    .Columns("perusahaan").Width = 130
                    .Columns("departemen").Width = 100
                    .Columns("grup").Width = 70
                    .Columns("ket_grup").Width = 100
                    .Columns("no_schedule_shift").Width = 110
                    .Columns("tanggal_awal").Width = 80
                    .Columns("tanggal_akhir").Width = 80
                    .Columns("catatan").Width = 200
                    .Columns("lokasi").Width = 70

                    For a As Integer = 0 To myDataTable.Columns.Count - 1
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                    Next

                    .Columns("tanggal_awal").DefaultCellStyle.Format = "dd-MMM-yyyy"
                    .Columns("tanggal_akhir").DefaultCellStyle.Format = "dd-MMM-yyyy"
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
                        .DisplayIndex = dgvView.Columns("ket_grup").Index + 1
                        dgvView.Columns.Add(cmbDgvEditButton)
                        dgvView.Columns("edit").Width = 70
                        cekTambahButton(0) = True
                        .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                        .Frozen = True
                    End If
                    .HeaderCell.Style.BackColor = Color.Lime
                End With

                With cmbDgvAttachmentButton
                    If Not (cekTambahButton(1)) Then
                        .HeaderText = "ATTACHMENT"
                        .Name = "attachment"
                        .Text = "Attachment"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = dgvView.ColumnCount
                        dgvView.Columns.Add(cmbDgvAttachmentButton)
                        dgvView.Columns("attachment").Width = 90
                        cekTambahButton(1) = True
                        .Visible = enableSubForm(0)
                    End If
                    .HeaderCell.Style.BackColor = Color.Yellow
                End With

                With cmbDgvCetakButton
                    If Not (cekTambahButton(2)) Then
                        .HeaderText = "CETAK"
                        .Name = "cetak"
                        .Text = "Cetak"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = dgvView.ColumnCount
                        dgvView.Columns.Add(cmbDgvCetakButton)
                        dgvView.Columns("cetak").Width = 70
                        cekTambahButton(2) = True
                    End If
                    .HeaderCell.Style.BackColor = Color.SkyBlue
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
            ElseIf (tipe = "detail") Then
                Dim queryBuilder As New Text.StringBuilder
                Dim subSQL As String
                Dim myDataTableTemp As New DataTable
                Dim myDataTablePeriode As New DataTable
                'Dim hitungTanggal As UShort
                'Dim arrColsHeader(2) As String
                Dim dateCols As Date
                Dim tanggalBerjalan As Date
                Dim tanggalAkhir As Date

                '================
                'INI YANG DIPAKAI UNTUK SQL SERVER
                'GANTI PAKAI POSTGRESQL
                'queryBuilder.Clear()
                'queryBuilder.Append("DECLARE @cols AS VARCHAR(MAX), @query  AS VARCHAR(MAX);")
                'queryBuilder.Append("SET @cols = STUFF((SELECT distinct ',' + QUOTENAME(c.tanggal) 
                '                    FROM " & tableNameDetail & " c WHERE c." & tableKey & "='" & myCStringManipulation.SafeSqlLiteral(mKriteria) & "'
                '                    FOR XML PATH(''), TYPE
                '                    ).value('.', 'VARCHAR(MAX)') 
                '                    ,1,1,'');")
                'queryBuilder.Append("set @query = 'SELECT 0 as rid,perusahaan,lokasi,departemen,idk,nip,nama,posisi,linenr, ' + @cols + ' from 
                '                    (
                '                        select d.perusahaan,d.lokasi,d.departemen,d.idk,d.nip,d.nama,d.waktushift,d.tanggal,d.posisi,d.linenr
                '                        from " & tableNameHeader & " as h INNER JOIN " & tableNameDetail & " as d ON h." & tableKey & " = d." & tableKey & "
                '                        where d." & tableKey & "=''" & myCStringManipulation.SafeSqlLiteral(mKriteria) & "''
                '                    ) x
                '                    pivot 
                '                    (
                '                        max(waktushift)
                '                        for tanggal in (' + @cols + ')
                '                    ) p
                '                    order by nama'")
                'queryBuilder.Append("execute(@query)")
                '================

                '================
                'POSTGRESQL
                stSQL = "select tanggalawal,tanggalakhir from " & tableNameHeader & " where " & tableKey & "='" & myCStringManipulation.SafeSqlLiteral(mKriteria) & "';"
                myDataTablePeriode = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "T_PeriodeShift")

                tanggalBerjalan = myDataTablePeriode.Rows(0).Item("tanggalawal")
                tanggalAkhir = myDataTablePeriode.Rows(0).Item("tanggalakhir")
                subSQL = Nothing
                While tanggalBerjalan <= tanggalAkhir
                    subSQL &= "MAX(CASE WHEN tanggal = '" & Format(tanggalBerjalan, "dd-MMM-yyyy") & "' THEN waktushift END) AS """ & Format(tanggalBerjalan, "dd-MMM-yyyy") & """"
                    tanggalBerjalan = tanggalBerjalan.AddDays(1)
                    If (tanggalBerjalan <= tanggalAkhir) Then
                        subSQL &= ","
                    End If
                End While

                stSQL = "SELECT 0 as rid, d.linenr,d.perusahaan,d.lokasi,d.departemen,d.grup,d.ketgrup as ket_grup,d.idk,d.nip,d.nama,d.posisi,
                        " & subSQL & "
                        FROM " & tableNameHeader & " as h INNER JOIN " & tableNameDetail & " as d ON h." & tableKey & " = d." & tableKey & "
                        WHERE h." & tableKey & "='" & myCStringManipulation.SafeSqlLiteral(mKriteria) & "'
                        GROUP BY d.linenr,d.perusahaan,d.lokasi,d.departemen,d.grup,d.ketgrup,d.idk,d.nip,d.nama,d.posisi
                        ORDER BY d.linenr;"
                '================
                'InputBox("", "", stSQL)
                '================
                'TIDAK DIPAKAI!! GAK PERLU DIBUKA!!
                'stSQL = "SELECT d.rid,d.perusahaan,d.lokasi,d.departemen,d." & tableKey & ",d.tanggal,d.nip,d.nama,d.waktushift as waktu_shift,d.created_at,d.updated_at
                '        FROM " & tableNameHeader & " as h INNER JOIN " & tableNameDetail & " as d ON h." & tableKey & " = d." & tableKey & "
                '        WHERE (((d." & tableKey & ")='" & myCStringManipulation.SafeSqlLiteral(mKriteria) & "'))
                '        ORDER BY d.nama;"

                'queryBuilder.Append("set @query = 'SELECT 0 as rid,perusahaan,lokasi,departemen,idk,nip,nama,posisi,linenr, ' + @cols + ' from 
                '                    (
                '                        select d.perusahaan,d.lokasi,d.departemen,d.idk,d.nip,d.nama,d.waktushift,d.tanggal,d.posisi,d.linenr
                '                        from " & tableNameHeader & " as h INNER JOIN " & tableNameDetail & " as d ON h." & tableKey & " = d." & tableKey & "
                '                        where d." & tableKey & "=''" & myCStringManipulation.SafeSqlLiteral(mKriteria) & "''
                '                    ) x
                '                    pivot 
                '                    (
                '                        max(waktushift)
                '                        for tanggal in (' + @cols + ')
                '                    ) p
                '                    union
                '                    SELECT 0 as rid,perusahaan,lokasi,departemen,idk,nip,nama,posisi,linenr, ' + @cols + ' from 
                '                    (
                '                        select d.perusahaan,d.lokasi,d.departemen,d.idk,d.nip,d.nama,d.waktushift,d.tanggal,d.posisi,d.linenr
                'from " & tableNameHeader & " as h INNER JOIN " & tableNameDetail & " as d ON h." & tableKey & " = d." & tableKey & " LEFT JOIN (select perusahaan,idk,nip,nama,max(waktushift) as waktushift,tanggal,posisi from trscheduleshiftdetail where " & tableKey & "=''" & myCStringManipulation.SafeSqlLiteral(mKriteria) & "'' group by perusahaan,idk,nip,nama,tanggal,posisi) as x on d.perusahaan=x.perusahaan and d.nip = x.nip and d.tanggal=x.tanggal and d.waktushift=x.waktushift
                'where d." & tableKey & "=''" & myCStringManipulation.SafeSqlLiteral(mKriteria) & "'' and x.waktushift is null
                'group by d.perusahaan,d.lokasi,d.departemen,d.idk,d.nip,d.nama,d.waktushift,d.tanggal,d.posisi,d.linenr
                '                    ) x
                '                    pivot 
                '                    (
                '                        max(waktushift)
                '                        for tanggal in (' + @cols + ')
                '                    ) p
                '                    order by nama'")


                'myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, queryBuilder.ToString, "T_Detail" & lblTitle.Text)
                'For i As Integer = 0 To myDataTableTemp.Columns.Count - 1
                '    myDataTable.Columns(i).ReadOnly = False
                'Next
                '==================================

                '==================================
                'SQL SERVER
                'myDataTableTemp = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, queryBuilder.ToString, "T_Detail" & lblTitle.Text)
                'myDataTable.Clear()
                'myDataTable = Nothing
                'myDataTable = New DataTable
                ''myDataTable = myDataTableTemp.Clone

                'tanggalBerjalan = dgvHeader.CurrentRow.Cells("tanggal_awal").Value
                'tanggalAkhir = dgvHeader.CurrentRow.Cells("tanggal_akhir").Value
                'hitungTanggal = myCStringManipulation.CalculateDaysBetweenDates(tanggalBerjalan, tanggalAkhir) + 10
                'Array.Resize(arrStrTanggal, hitungTanggal)
                'Dim x As UShort = 9
                'While tanggalBerjalan <= tanggalAkhir
                '    arrStrTanggal(x) = Format(tanggalBerjalan, "yyyy-MM-dd")

                '    tanggalBerjalan = tanggalBerjalan.AddDays(1)
                '    x += 1
                '    If (x Mod 100 = 0) Then
                '        GC.Collect()
                '    End If
                'End While
                ''MsgBox("hitungTanggal: " & hitungTanggal & " ;x: " & x & " ;arrStrTanggal:" & arrStrTanggal.Count)

                'For i As Integer = 0 To hitungTanggal - 1
                '    If (i < myDataTableTemp.Columns.Count) Then
                '        If Not (myDataTableTemp.Columns(i).ColumnName.Contains("-")) Then
                '            myDataTable.Columns.Add(myDataTableTemp.Columns(i).ColumnName)
                '        Else
                '            myDataTable.Columns.Add(arrStrTanggal(i))
                '        End If
                '    Else
                '        myDataTable.Columns.Add(arrStrTanggal(i))
                '    End If
                'Next

                ''For i As Integer = 0 To myDataTableTemp.Columns.Count - 1
                ''    If (myDataTableTemp.Columns(i).ColumnName.Contains("-")) Then
                ''        If (arrStrTanggal(i) <> myDataTableTemp.Columns(i).ColumnName) Then
                ''            myDataTable.Columns.Add(arrStrTanggal(i))
                ''        End If
                ''    End If
                ''    myDataTable.Columns.Add(myDataTableTemp.Columns(i).ColumnName)
                ''Next

                'For i As Integer = 0 To myDataTableTemp.Rows.Count - 1
                '    myDataTable.ImportRow(myDataTableTemp.Rows(i))
                'Next
                'myBindingTable.DataSource = myDataTable
                '==================================

                '==================================
                'PGSQL
                myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "T_Detail" & lblTitle.Text)
                myBindingTable.DataSource = myDataTable
                '==================================

                With dgvView
                    .DataSource = myBindingTable
                    .ReadOnly = True

                    .Columns("rid").Visible = False
                    '.Columns("perusahaan").Visible = False
                    '.Columns("lokasi").Visible = False
                    '.Columns("departemen").Visible = False
                    .Columns("idk").Visible = False
                    .Columns("linenr").Visible = False

                    .Columns("rid").Frozen = True
                    .Columns("linenr").Frozen = True
                    .Columns("idk").Frozen = True
                    .Columns("nip").Frozen = True
                    .Columns("nama").Frozen = True

                    .EnableHeadersVisualStyles = False
                    For i As Integer = 0 To .Columns.Count - 1
                        If (.Columns(i).Frozen) Then
                            .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                        End If
                    Next

                    .Columns("linenr").Width = 60
                    .Columns("nip").Width = 75
                    .Columns("nama").Width = 125
                    .Columns("posisi").Width = 100
                    .Columns("perusahaan").Width = 130
                    .Columns("departemen").Width = 100
                    .Columns("grup").Width = 70
                    .Columns("ket_grup").Width = 100
                    .Columns("lokasi").Width = 70

                    .Font = New Font("Arial", 8, FontStyle.Regular)

                    '==================================
                    'SQL SERVER
                    'For a As UShort = 0 To myDataTable.Columns.Count - 1
                    '    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    '    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")

                    '    If (.Columns(myDataTable.Columns(a).ColumnName).HeaderText.Contains("-")) Then
                    '        'Untuk menjadikan format tanggal yang asalnya 2021-11-21 menjadi 21-Nov-2021
                    '        arrColsHeader = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Split("-")
                    '        dateCols = CDate(arrColsHeader(2) & "-" & MonthName(arrColsHeader(1), True) & "-" & arrColsHeader(0))
                    '        myDataTable.Columns(a).ColumnName = Format(dateCols, "ddMMMyyyy")
                    '        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myCStringManipulation.TranslateWeekdayName(WeekdayName(Weekday(dateCols))).ToUpper & " (" & Format(dateCols, "ddMMMyyyy") & ")"
                    '        .Columns(myDataTable.Columns(a).ColumnName).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                    '    End If
                    'Next
                    '==================================
                    '==================================
                    'PGSQL
                    For a As UShort = 0 To myDataTable.Columns.Count - 1
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")

                        If (.Columns(myDataTable.Columns(a).ColumnName).HeaderText.Contains("-")) Then
                            'Kalau postgres, format tanggalnya sudah langsung dd-MMM-yyyy
                            'Jadi cuman perlu di dempetin dan dikasih hari
                            dateCols = CDate(myDataTable.Columns(a).ColumnName)
                            myDataTable.Columns(a).ColumnName = Format(dateCols, "ddMMMyyyy")
                            .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myCStringManipulation.TranslateWeekdayName(WeekdayName(Weekday(dateCols))).ToUpper & " (" & Format(dateCols, "ddMMMyyyy") & ")"
                            .Columns(myDataTable.Columns(a).ColumnName).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                        End If
                    Next
                    '==================================
                    .Columns("posisi").HeaderText = "JABATAN"

                    '.Columns("tanggal").DefaultCellStyle.Format = "dd-MMM-yyyy"
                    '.Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                    '.Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                    '.Columns("tanggal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.Columns("mulai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.Columns("selesai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
                End With

                'Untuk mengatur warna background cell, agar dapat lebih mudah dibedakan saja
                With dgvDetail
                    For i As UShort = 0 To .Rows.Count - 1
                        For j As UShort = 0 To .Columns.Count - 1
                            If Not (.Columns(j).HeaderText.Contains("(")) Then
                                .Columns(j).DefaultCellStyle.BackColor = Color.White
                            Else
                                .CurrentCell = .Item(j, i)
                                If Not IsDBNull(.CurrentCell.Value) Then
                                    If (.CurrentCell.Value = "P") Then
                                        .CurrentCell.Style.BackColor = Color.Yellow
                                    ElseIf (.CurrentCell.Value = "S") Then
                                        .CurrentCell.Style.BackColor = Color.Aqua
                                    ElseIf (.CurrentCell.Value = "M") Then
                                        .CurrentCell.Style.BackColor = Color.Lime
                                    ElseIf (.CurrentCell.Value = "X") Then
                                        .CurrentCell.Style.BackColor = Color.LightSalmon
                                    End If
                                Else
                                    .CurrentCell.Style.BackColor = Color.Silver
                                End If
                            End If
                        Next
                    Next
                    'Untuk kembalikan current cell ke kolom paling awal lagi dan baris paling atas
                    .CurrentCell = .Item(.Columns("nip").Index, 0)
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
                'untuk menampilkan auto number pada rowHeaders
                Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithPaging(sender, (Integer.Parse(tbRecordPage.Text) - 1) * 10)
            ElseIf (sender Is dgvDetail) Then
                'Untuk mengatur warna background cell, agar dapat lebih mudah dibedakan saja
                With dgvDetail
                    For i As UShort = 0 To .Rows.Count - 1
                        For j As UShort = 0 To .Columns.Count - 1
                            If Not (.Columns(j).HeaderText.Contains("(")) Then
                                .Columns(j).DefaultCellStyle.BackColor = Color.White
                            Else
                                .CurrentCell = .Item(j, i)
                                If Not IsDBNull(.CurrentCell.Value) Then
                                    If (.CurrentCell.Value = "P") Then
                                        .CurrentCell.Style.BackColor = Color.Yellow
                                    ElseIf (.CurrentCell.Value = "S") Then
                                        .CurrentCell.Style.BackColor = Color.Aqua
                                    ElseIf (.CurrentCell.Value = "M") Then
                                        .CurrentCell.Style.BackColor = Color.Lime
                                    ElseIf (.CurrentCell.Value = "X") Then
                                        .CurrentCell.Style.BackColor = Color.LightSalmon
                                    End If
                                Else
                                    .CurrentCell.Style.BackColor = Color.Silver
                                End If
                            End If
                        Next
                    Next
                    'Untuk kembalikan current cell ke kolom paling awal lagi dan baris paling atas
                    .CurrentCell = .Item(.Columns("nip").Index, 0)
                End With

                'untuk menampilkan auto number pada rowHeaders
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
                    Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGVDetail, myBindingTableDGVDetail, dgvDetail, dgvHeader.CurrentRow.Cells("no_schedule_shift").Value, True, "detail")
                    If (e.ColumnIndex = dgvHeader.Columns("edit").Index) Then
                        isNew = False
                        Dim foundRows As DataRow()
                        foundRows = myDataTableDGVHeader.Select("rid=" & dgvHeader.CurrentRow.Cells("rid").Value)
                        Dim frmDetailScheduleShift As New FormDetailScheduleShift(myDataTableDGVHeader, myDataTableDGVDetail, dgvDetail, tableNameHeader, tableNameDetail, tableKey, isNew, dgvHeader.CurrentRow.Cells("rid").Value, myDataTableDGVHeader.Rows.IndexOf(foundRows(0)), Me.Name)
                        Call myCFormManipulation.GoToForm(Me.MdiParent, frmDetailScheduleShift)
                    ElseIf (e.ColumnIndex = dgvHeader.Columns("attachment").Index) Then
                        Dim frmAttachmentDokumen As New FormAttachmentDokumen.FormAttachmentDokumen(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, Trim(lblTitle.Text.Replace("MASTER", "")), Trim(dgvHeader.CurrentRow.Cells("no_schedule_shift").Value))
                        Call myCFormManipulation.GoToForm(Me.MdiParent, frmAttachmentDokumen)
                    ElseIf (e.ColumnIndex = dgvHeader.Columns("cetak").Index) Then
                        stSQL = "SELECT h.perusahaan,h." & tableKey & ",h.lokasi,h.departemen,h.grup,h.ketgrup,h.tanggalawal,h.tanggalakhir,h.catatan,d.tanggal,d.nip,d.nama,d.posisi,d.linenr,d.waktushift
                                FROM " & tableNameHeader & " as h inner join " & tableNameDetail & " as d on h." & tableKey & "=d." & tableKey & " " & "
                                WHERE h." & tableKey & " = '" & myCStringManipulation.SafeSqlLiteral(dgvHeader.CurrentRow.Cells("no_schedule_shift").Value) & "'
                                ORDER BY d.linenr,d.tanggal;"
                        Dim frmDisplayReport As New FormDisplayReport.FormDisplayReport(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, stSQL, "ScheduleShift")
                        Call myCFormManipulation.GoToForm(Me.MdiParent, frmDisplayReport)
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
            Dim frmDetailScheduleShift As New FormDetailScheduleShift(myDataTableDGVHeader, myDataTableDGVDetail, dgvDetail, tableNameHeader, tableNameDetail, tableKey, isNew,,, Me.Name)
            Call myCFormManipulation.GoToForm(Me.MdiParent, frmDetailScheduleShift)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCreateNew_Click Error")
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
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

    Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles btnForward.Click
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

    Private Sub btnFFBack_Click(sender As Object, e As EventArgs) Handles btnFFBack.Click
        Try
            tbRecordPage.Text = 1
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGVHeader, myBindingTableDGVHeader, dgvHeader, mCari, True, "header")
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFForward_Click(sender As Object, e As EventArgs) Handles btnFFForward.Click
        Try
            tbRecordPage.Text = banyakPages
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, banyakPages * 10, myDataTableDGVHeader, myBindingTableDGVHeader, dgvHeader, mCari, True, "header")
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

    Private Sub dgvView_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvHeader.CellMouseDown, dgvDetail.CellMouseDown
        Try
            'if di bawah ditambahkan pada 3 feb 2012 agar bisa pilih full row lebih dari 1,
            'karena kalau tidak ada if dibawah maka apabila sudah pilih full row pakai klik kiri
            'anggap saja mau pilih 3 full row, lalu di klik kanan, maka hanya row terakhir yang akan terpilih
            'oleh karena itu diberi if row yang dipilih tidak lebih dari 1, jadi klw milih banyak, fungsi di dalam if tidak akan dijalankan
            'dengan kata lain pada kasus ini klik kanan hanya untuk menampilkan konteks menu.
            'singkatnya, kalau sudah ada full row yang terpilih, maka fungsi di event ini tidak akan dijalankan
            If Not (sender.SelectedRows.Count > 1) Then
                'fungsi ini ditujukan agar user bisa memilih cell dengan klik kanan juga
                If e.Button = MouseButtons.Right Then
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