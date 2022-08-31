Public Class FormDetailScheduleShift
    Private isNew As Boolean
    Private parentFormName As String
    Private rid As UInteger
    Private dgvPosNow As UShort
    Private myDataTableHeader As New DataTable
    Private myDataTableDGVDetail As New DataTable
    Private tableNameHeader As String
    Private tableNameDetail As String
    Private tableKey As String
    Private cmbDgvShiftCheckbox As New DataGridViewCheckBoxColumn()
    Private cmbDgvNewCheckbox As New DataGridViewCheckBoxColumn()
    Private cmbDgvEditedCheckbox As New DataGridViewCheckBoxColumn()
    Private cmbDgvDetailHapusButton As New DataGridViewButtonColumn()
    Private cekTambahButton(2) As Boolean
    Private arrDefValues(8) As String
    Private isDataPrepared As Boolean
    Private newValues As String
    Private newFields As String
    Private updateString As String

    Private stSQL As String
    Private myDataTableCboPerusahaan As New DataTable
    Private myBindingPerusahaan As New BindingSource
    Private myDataTableCboKaryawan As New DataTable
    Private myBindingKaryawan As New BindingSource
    Private myDataTableCboLokasi As New DataTable
    Private myBindingLokasi As New BindingSource
    Private myDataTableCboKetGroup As New DataTable
    Private myBindingKetGroup As New BindingSource
    Private myDataTableCboDepartemen As New DataTable
    Private myBindingDepartemen As New BindingSource
    Private isCboPrepared As Boolean
    Private isExist As Boolean

    Private strScheduleShift As String
    Private strKDR As String
    Private prefixKode As String
    Private prefixCompleted As String
    Private digitLength As Byte
    'Private isValueChanged As Boolean
    'Private mInitialValue As Object
    Private isPartialChanged As Boolean
    Private updatePart(2) As Boolean

    Private strWaktuShift As String
    'Private strPanjangKolom As UShort
    Private tanggalBerjalan As Date
    Private tanggalAkhir As Date
    Private arrStrHari() As String
    Private arrStrTanggal() As String

    'Private jarakPanelBawah As UShort
    Private vendorName As String
    Private initialValue As String
    'Private arrShiftDefValues(300, 365) As String
    'Private idxDetailDeleted() As UShort
    'Private banyakDihapus As UShort
    Private foundRows As DataRow()
    Private whereString As String
    Private lineNr As UShort
    Private dgvDetailku As DataGridView

    Public Sub New(ByRef _myDataTableHeader As DataTable, ByRef _myDataTableDGVDetail As DataTable, ByRef _dgvDetailku As DataGridView, _tableNameHeader As String, _tableNameDetail As String, _tableKey As String, Optional _isNew As Boolean = True, Optional _rid As Long = 0, Optional _dgvPosNow As UShort = 0, Optional _parentFormName As String = "")
        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            If Not IsNothing(_myDataTableHeader) Then
                isNew = _isNew
                parentFormName = _parentFormName
                tableNameHeader = _tableNameHeader
                tableNameDetail = _tableNameDetail
                myDataTableHeader = _myDataTableHeader
                tableKey = _tableKey
                If Not (isNew) Then
                    rid = _rid
                    dgvPosNow = _dgvPosNow
                    myDataTableDGVDetail = _myDataTableDGVDetail
                    dgvDetailku = _dgvDetailku
                    'Array.Resize(idxDetailDeleted, myDataTableDGVDetail.Rows.Count - 1)
                ElseIf (isNew) Then
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormDetailScheduleShift Error")
        End Try
    End Sub

    Private Sub FormDetailScheduleShift_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If Not isNew Then
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableNameDetail, "tobedel='False'", tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "'")
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
            Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDetailScheduleShift_FormClosed Error")
        End Try
    End Sub

    Private Sub FormDetailScheduleShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim arrCbo() As String
            arrCbo = {"DIVISI", "BAGIAN"}
            cboGrup.Items.AddRange(arrCbo)
            cboGrup.SelectedIndex = 0

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            isDataPrepared = False

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='lokasi' " & IIf(USER_.lokasi = "ALL", "", "AND keterangan='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "'") & " order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboLokasi, myBindingLokasi, cboLokasi, "T_" & cboLokasi.Name, "keterangan", "keterangan", isCboPrepared)
            cboLokasi.SelectedIndex = 0

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='perusahaan' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPerusahaan, myBindingPerusahaan, cboPerusahaan, "T_" & cboPerusahaan.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='departemen' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboDepartemen, myBindingDepartemen, cboDepartemen, "T_" & cboDepartemen.Name, "keterangan", "keterangan", isCboPrepared)

            digitLength = 4
            prefixKode = "SCH"
            gbDetail.Enabled = False

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, parentFormName, USER_.T_USER_RIGHT)

            'If (Me.WindowState = FormWindowState.Maximized) Then
            '    jarakPanelBawah = 105
            '    pnlCetak.Top = Me.Size.Height - jarakPanelBawah
            'Else
            '    jarakPanelBawah = Me.Size.Height - pnlCetak.Location.Y
            'End If

            If Not isNew Then
                'Berarti Edit
                'Set Header
                'RecID
                arrDefValues(0) = myDataTableHeader.Rows(dgvPosNow).Item("rid")
                'Perusahaan
                For i As Byte = 0 To cboPerusahaan.Items.Count - 1
                    If (DirectCast(cboPerusahaan.Items(i), DataRowView).Item("keterangan") = myDataTableHeader.Rows(dgvPosNow).Item("perusahaan")) Then
                        cboPerusahaan.SelectedIndex = i
                        arrDefValues(1) = myDataTableHeader.Rows(dgvPosNow).Item("perusahaan")
                    End If
                Next
                'Departemen
                For i As Byte = 0 To cboDepartemen.Items.Count - 1
                    If (DirectCast(cboDepartemen.Items(i), DataRowView).Item("keterangan") = myDataTableHeader.Rows(dgvPosNow).Item("departemen")) Then
                        cboDepartemen.SelectedIndex = i
                        arrDefValues(2) = myDataTableHeader.Rows(dgvPosNow).Item("departemen")
                    End If
                Next
                'No Schedule Shift
                tbNoScheduleShift.Text = myDataTableHeader.Rows(dgvPosNow).Item("no_schedule_shift")
                arrDefValues(3) = myDataTableHeader.Rows(dgvPosNow).Item("no_schedule_shift")
                'lokasi
                For i As Byte = 0 To cboLokasi.Items.Count - 1
                    If (DirectCast(cboLokasi.Items(i), DataRowView).Item("keterangan") = myDataTableHeader.Rows(dgvPosNow).Item("lokasi")) Then
                        cboLokasi.SelectedIndex = i
                        arrDefValues(4) = myDataTableHeader.Rows(dgvPosNow).Item("lokasi")
                    End If
                Next
                'grup
                For i As UShort = 0 To cboGrup.Items.Count - 1
                    If (cboGrup.Items(i) = myDataTableHeader.Rows(dgvPosNow).Item("grup")) Then
                        cboGrup.SelectedIndex = i
                        arrDefValues(5) = myDataTableHeader.Rows(dgvPosNow).Item("grup")
                    End If
                Next
                'ket grup
                For i As UShort = 0 To cboKetGrup.Items.Count - 1
                    If (DirectCast(cboKetGrup.Items(i), DataRowView).Item("keterangan") = myDataTableHeader.Rows(dgvPosNow).Item("ket_grup")) Then
                        cboKetGrup.SelectedIndex = i
                        arrDefValues(6) = myDataTableHeader.Rows(dgvPosNow).Item("ket_grup")
                    End If
                Next
                'Tanggal Awal
                dtpAwal.Value = myDataTableHeader.Rows(dgvPosNow).Item("tanggal_awal")
                arrDefValues(7) = myDataTableHeader.Rows(dgvPosNow).Item("tanggal_awal")
                'Tanggal Akhir
                dtpAkhir.Value = myDataTableHeader.Rows(dgvPosNow).Item("tanggal_akhir")
                arrDefValues(8) = myDataTableHeader.Rows(dgvPosNow).Item("tanggal_akhir")

                'Dim hitungTanggal As UShort
                'hitungTanggal = myCStringManipulation.CalculateDaysBetweenDates(dtpAwal.Value.Date, dtpAkhir.Value.Date) + 1
                'Array.Resize(arrShiftDefValues, hitungTanggal)
                'Set Detail
                'Panggil ini untuk generate kerangka grid nya
                Call btnGenerate_Click(btnGenerate, e)
                Dim mRows(dgvDetail.ColumnCount - 1) As String
                'Array.Resize(arrShiftDefValues, dgvDetail.ColumnCount - 1)
                Dim a As UShort = 0
                For i As UShort = 0 To myDataTableDGVDetail.Rows.Count - 1
                    'arrShiftDefValues(i, 0) = "0"
                    'arrShiftDefValues(i, 1) = myDataTableDGVDetail.Rows(i).Item("perusahaan")
                    'arrShiftDefValues(i, 2) = myDataTableDGVDetail.Rows(i).Item("lokasi")
                    'arrShiftDefValues(i, 3) = myDataTableDGVDetail.Rows(i).Item("grup")
                    'arrShiftDefValues(i, 4) = myDataTableDGVDetail.Rows(i).Item("ket_grup")
                    'arrShiftDefValues(i, 5) = myDataTableDGVDetail.Rows(i).Item("idk")
                    'arrShiftDefValues(i, 6) = myDataTableDGVDetail.Rows(i).Item("nip")
                    'arrShiftDefValues(i, 7) = myDataTableDGVDetail.Rows(i).Item("nama")
                    'arrShiftDefValues(i, 8) = IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item("posisi")), "", myDataTableDGVDetail.Rows(i).Item("posisi"))
                    'arrShiftDefValues(i, 9) = myDataTableDGVDetail.Rows(i).Item("linenr")

                    mRows(0) = "0"
                    mRows(1) = myDataTableDGVDetail.Rows(i).Item("perusahaan")
                    mRows(2) = myDataTableDGVDetail.Rows(i).Item("lokasi")
                    mRows(3) = myDataTableDGVDetail.Rows(i).Item("departemen")
                    mRows(4) = myDataTableDGVDetail.Rows(i).Item("grup")
                    mRows(5) = myDataTableDGVDetail.Rows(i).Item("ket_grup")
                    mRows(6) = myDataTableDGVDetail.Rows(i).Item("idk")
                    mRows(7) = myDataTableDGVDetail.Rows(i).Item("nip")
                    mRows(8) = myDataTableDGVDetail.Rows(i).Item("nama")
                    mRows(9) = IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item("posisi")), Nothing, myDataTableDGVDetail.Rows(i).Item("posisi"))
                    mRows(10) = myDataTableDGVDetail.Rows(i).Item("linenr")
                    If (lineNr < myDataTableDGVDetail.Rows(i).Item("linenr")) Then
                        lineNr = myDataTableDGVDetail.Rows(i).Item("linenr")
                    End If

                    a = 11
                    While a < myDataTableDGVDetail.Columns.Count
                        'MsgBox("nama kolom: " & myDataTableDGVDetail.Columns(a).ColumnName)
                        'arrShiftDefValues(i, a) = IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item(a)), Nothing, myDataTableDGVDetail.Rows(i).Item(a))
                        mRows(a) = IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item(a)), Nothing, myDataTableDGVDetail.Rows(i).Item(a))
                        'If (dgvDetail.Columns(a).Name = myDataTableDGVDetail.Columns(a).ColumnName) Then

                        'Else
                        '    mRows(a) = Nothing
                        'End If
                        a += 1
                    End While
                    'arrShiftDefValues(i, a) = False
                    'arrShiftDefValues(i, a + 1) = False
                    mRows(a) = False
                    mRows(a + 1) = False

                    dgvDetail.Rows.Add(mRows)

                    'Untuk mengatur warna background cell, agar dapat lebih mudah dibedakan saja
                    With dgvDetail
                        'For r As UShort = 0 To .Rows.Count - 1
                        For c As UShort = 0 To .ColumnCount - 1
                            If Not (.Columns(c).HeaderText.Contains("(")) Then
                                .Columns(c).DefaultCellStyle.BackColor = Color.White
                            Else
                                .CurrentCell = .Item(c, .RowCount - 1)
                                If Not IsNothing(.CurrentCell.Value) Then
                                    If (.CurrentCell.Value = "P") Then
                                        .CurrentCell.Style.BackColor = rbPagi.BackColor
                                    ElseIf (.CurrentCell.Value = "S") Then
                                        .CurrentCell.Style.BackColor = rbSiang.BackColor
                                    ElseIf (.CurrentCell.Value = "M") Then
                                        .CurrentCell.Style.BackColor = rbMalam.BackColor
                                    ElseIf (.CurrentCell.Value = "X") Then
                                        .CurrentCell.Style.BackColor = rbLibur.BackColor
                                    End If
                                Else
                                    .CurrentCell.Style.BackColor = rbKosong.BackColor
                                End If
                            End If
                        Next
                        'Next
                        'Untuk kembalikan current cell ke kolom paling awal lagi dan baris paling atas
                        .CurrentCell = .Item(.Columns("nip").Index, 0)
                    End With

                    'untuk menampilkan auto number pada rowHeaders
                    Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
                Next
                Call myCFormManipulation.SetReadOnly(gbDataEntry, Not clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui")))
                btnSimpan.Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                tbNoScheduleShift.ReadOnly = True
                btnCreateNew.Visible = False
            Else
                dtpAkhir.Value = dtpAwal.Value.AddDays(30)

                btnCreateNew.Visible = True
                btnHapus.Visible = False
            End If

            rbPagi.Checked = True
            'lblScheduleShift.Visible = False
            'vendorName = "PT. PRIMA ENERGY GLOBALINDO"
            'lblScheduleShift.Text = "SCHEDULE " & vendorName & " PERIODE " & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & " S/D " & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy")
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDetailScheduleShift_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormDetailScheduleShift_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDetailScheduleShift_Activated Error")
        End Try
    End Sub

    Private Sub FormDetailScheduleShift_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNoScheduleShift.KeyDown, cboPerusahaan.KeyDown, cboLokasi.KeyDown, cboKetGrup.KeyDown, dtpAkhir.KeyDown, dtpAwal.KeyDown, cboKaryawan.KeyDown, btnTambahkan.KeyDown, tbNamaSimpan.KeyDown, tbPathSimpan.KeyDown, btnBrowse.KeyDown, btnExportExcel.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnCetak.KeyDown, btnHapus.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is cboKaryawan) Then
                    Call btnTambahkan_Click(btnTambahkan, e)
                End If
                'If (sender Is tbCari) Then
                '    Call btnTampilkan_Click(btnTampilkan, e)
                'End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDetailScheduleShift_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Try
            If Not isNew Then
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableNameDetail, "tobedel='False'", tableKey & "='" & tbNoScheduleShift.Text & "'")
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
            Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnKeluar_Click Error")
        End Try
    End Sub

    'Private Sub FormDetailScheduleShift_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
    '    Try
    '        If (isDataPrepared) Then
    '            pnlCetak.Top = Me.Size.Height - jarakPanelBawah
    '        End If
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDetailScheduleShift_SizeChanged Error")
    '    End Try
    'End Sub

    Private Sub SetDGVDetail(_perusahaan As String, _tanggalAwal As Date, _tanggalAkhir As Date)
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            'stSQL = "SELECT concat(nama,' || ',nip) as karyawan,nip,nama FROM " & CONN_.schemaHRD & ".mskaryawanaktif WHERE perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' " & IIf(USER_.lokasi = "ALL", "", "AND (tbl.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " GROUP BY concat(nama,' || ',nip),nip,nama ORDER BY karyawan;"
            'Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared)

            'BUAT CETAK HEADER KOLOM DENGAN NAMA HARI
            '===============================================================================================
            Dim hitungTanggal As UShort

            dgvDetail.Columns.Clear()
            dgvDetail.Rows.Clear()
            dgvDetail.Refresh()
            For i As Byte = 0 To cekTambahButton.Count - 1
                cekTambahButton(i) = False
            Next
            tanggalBerjalan = _tanggalAwal
            tanggalAkhir = _tanggalAkhir

            hitungTanggal = myCStringManipulation.CalculateDaysBetweenDates(tanggalBerjalan, tanggalAkhir) + 1

            Array.Resize(arrStrTanggal, hitungTanggal)
            Array.Resize(arrStrHari, hitungTanggal)

            Dim a As UShort = 0
            While tanggalBerjalan <= tanggalAkhir
                arrStrHari(a) = myCStringManipulation.TranslateWeekdayName(WeekdayName(Weekday(tanggalBerjalan)))
                arrStrTanggal(a) = tanggalBerjalan

                tanggalBerjalan = tanggalBerjalan.AddDays(1)
                a += 1
                If (a Mod 100 = 0) Then
                    GC.Collect()
                End If
            End While


            With dgvDetail
                .ReadOnly = True

                .Columns.Add("rid", "RID")
                .Columns.Add("perusahaan", "PERUSAHAAN")
                .Columns.Add("lokasi", "LOKASI")
                .Columns.Add("departemen", "DEPARTEMEN")
                .Columns.Add("grup", "GRUP")
                .Columns.Add("ketgrup", "KET GRUP")
                .Columns.Add("idk", "IDK")
                .Columns.Add("nip", "NIP")
                .Columns.Add("nama", "NAMA")
                .Columns.Add("posisi", "JABATAN")
                .Columns.Add("linenr", "LINE NR")
                For i As UShort = 0 To arrStrHari.Count - 1
                    .Columns.Add(arrStrTanggal(i), arrStrHari(i).ToUpper & " (" & Format(CDate(arrStrTanggal(i)), "ddMMMyyyy") & ")")
                Next

                .Columns("rid").Visible = False
                .Columns("perusahaan").Visible = False
                .Columns("lokasi").Visible = False
                .Columns("departemen").Visible = False
                .Columns("grup").Visible = False
                .Columns("ketgrup").Visible = False
                '.Columns("kdr").Visible = False
                .Columns("idk").Visible = False
                .Columns("linenr").Visible = False

                .Columns("rid").Frozen = True
                .Columns("perusahaan").Frozen = True
                .Columns("lokasi").Frozen = True
                .Columns("departemen").Frozen = True
                .Columns("grup").Frozen = True
                .Columns("ketgrup").Frozen = True
                .Columns("idk").Frozen = True
                .Columns("nip").Frozen = True
                .Columns("nama").Frozen = True
                .Columns("posisi").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("nip").Width = 75
                .Columns("nama").Width = 125
                .Columns("posisi").Width = 100

                '.Columns("nip").ValueType = GetType(String)
                '.Columns("nama").ValueType = GetType(String)
                '.Columns("posisi").ValueType = GetType(String)

                '.Columns("rid").ReadOnly = True
                '.Columns("nip").ReadOnly = True
                '.Columns("nama").ReadOnly = True
                '.Columns("posisi").ReadOnly = True
                'For i As UShort = 0 To arrStrHari.Count - 1
                '    .Columns(arrStrHari(i)).ReadOnly = True
                'Next

                .Font = New Font("Arial", 8, FontStyle.Regular)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False

                For i As UShort = 0 To arrStrTanggal.Count - 1
                    .Columns(arrStrTanggal(i)).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                Next
            End With

            With cmbDgvNewCheckbox
                If Not (cekTambahButton(0)) Then
                    .HeaderText = "NEW"
                    .Name = "new"
                    .DataPropertyName = "new"
                    .DisplayIndex = dgvDetail.ColumnCount
                    dgvDetail.Columns.Add(cmbDgvNewCheckbox)
                    dgvDetail.Columns("new").Width = 70
                    cekTambahButton(0) = True
                    .ReadOnly = True
                    .DefaultCellStyle.BackColor = Color.Gainsboro
                End If
                .HeaderCell.Style.BackColor = Color.Yellow
            End With
            With cmbDgvEditedCheckbox
                If Not (cekTambahButton(1)) Then
                    .HeaderText = "EDITED"
                    .Name = "edited"
                    .DataPropertyName = "edited"
                    .DisplayIndex = dgvDetail.ColumnCount
                    dgvDetail.Columns.Add(cmbDgvEditedCheckbox)
                    dgvDetail.Columns("edited").Width = 70
                    cekTambahButton(1) = True
                    .ReadOnly = True
                    .DefaultCellStyle.BackColor = Color.Gainsboro
                End If
                .HeaderCell.Style.BackColor = Color.Lime
            End With
            With cmbDgvDetailHapusButton
                If Not (cekTambahButton(2)) Then
                    .HeaderText = "DELETE"
                    .Name = "delete"
                    .Text = "Delete"
                    .UseColumnTextForButtonValue = True
                    .DisplayIndex = dgvDetail.ColumnCount
                    dgvDetail.Columns.Add(cmbDgvDetailHapusButton)
                    dgvDetail.Columns("delete").Width = 100
                    cekTambahButton(2) = True
                    If (isNew) Then
                        btnHapus.Enabled = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                        .Visible = True
                    Else
                        btnHapus.Enabled = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                        .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                    End If
                End If
                .HeaderCell.Style.BackColor = Color.LightSalmon
            End With
            Call myCDataGridViewManipulation.SetGridViewSortState(dgvDetail, DataGridViewColumnSortMode.NotSortable)
            dgvDetail.RowHeadersWidth = 70
            '===============================================================================================

            ''ISI BARIS PERTAMA DENGAN TANGGAL
            ''===============================================================================================
            'strPanjangKolom = 9 + (hitungTanggal + 1)   'Harus ditambah 1 karena kalau misal cuman 1 tanggal aja, berarti 0, padahal gak boleh 0 kan berarti tanggalnya gak ada
            'strPanjangKolom = dgvDetail.ColumnCount
            'Dim mRows(strPanjangKolom) As String

            'mRows(0) = "0"
            'mRows(1) = "-"
            'mRows(2) = "-"
            'mRows(3) = "-"

            'a = 4
            'tanggalBerjalan = dtpAwal.Value.Date
            'While tanggalBerjalan <= tanggalAkhir
            '    mRows(a) = tanggalBerjalan.Day

            '    tanggalBerjalan = tanggalBerjalan.AddDays(1)
            '    a += 1
            '    If (a Mod 100 = 0) Then
            '        GC.Collect()
            '    End If
            'End While
            ''MsgBox(dgvDetail.Columns.GetColumnCount(DataGridViewElementStates.None))
            'mRows(a) = False
            'mRows(a + 1) = False

            'dgvDetail.Rows.Add(mRows)

            ''untuk menampilkan auto number pada rowHeaders
            'Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)

            'dgvDetail.Rows(0).Frozen = True
            'dgvDetail.Rows(0).DefaultCellStyle.BackColor = Color.Gray
            ''===============================================================================================
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetDGVDetail Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub dgvDetail_Sorted(sender As Object, e As EventArgs) Handles dgvDetail.Sorted
        Try
            'Untuk mengatur warna background cell, agar dapat lebih mudah dibedakan saja
            With dgvDetail
                For i As UShort = 0 To .ColumnCount - 1
                    If Not (.Columns(i).HeaderText.Contains("(")) Then
                        .Columns(i).DefaultCellStyle.BackColor = Color.White
                    Else
                        .CurrentCell = .Item(i, .RowCount - 1)
                        If (.CurrentCell.Value = "P") Then
                            .CurrentCell.Style.BackColor = rbPagi.BackColor
                        ElseIf (.CurrentCell.Value = "S") Then
                            .CurrentCell.Style.BackColor = rbSiang.BackColor
                        ElseIf (.CurrentCell.Value = "M") Then
                            .CurrentCell.Style.BackColor = rbMalam.BackColor
                        ElseIf (.CurrentCell.Value = "X") Then
                            .CurrentCell.Style.BackColor = rbLibur.BackColor
                        ElseIf IsNothing(.CurrentCell.Value) Then
                            .CurrentCell.Style.BackColor = rbKosong.BackColor
                        End If
                    End If
                Next
                'Untuk kembalikan current cell ke kolom paling awal lagi dan baris paling akhir
                .CurrentCell = dgvDetail.Item(.Columns("nip").Index, dgvDetail.RowCount - 1)
            End With
            'untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_Sorted Error")
        End Try
    End Sub

    Private Sub cboPerusahaan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPerusahaan.SelectedIndexChanged
        Try
            If (isCboPrepared) Then
                If (cboPerusahaan.SelectedIndex <> -1) Then
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    isDataPrepared = False
                    prefixCompleted = prefixKode & "-" & DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("kode")
                    strScheduleShift = myCDBOperation.SetDynamicAutoKode(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameHeader, tableKey, "rid", prefixCompleted, digitLength, False,, CONN_.dbType, Format(dtpAwal.Value.Date, "MMMyy"))
                    tbNoScheduleShift.Text = strScheduleShift.ToUpper
                    isDataPrepared = True

                    Me.Cursor = Cursors.Default
                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboPerusahaan_SelectedIndexChanged Error")
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboPerusahaan.Validated, cboLokasi.Validated, cboDepartemen.Validated, cboKetGrup.Validated, cboKaryawan.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
                If (sender Is cboPerusahaan) Then
                    cboLokasi.SelectedIndex = -1
                    cboDepartemen.SelectedIndex = -1
                    cboKetGrup.SelectedIndex = -1
                    gbDetail.Enabled = False
                    strScheduleShift = Nothing
                    tbNoScheduleShift.Clear()

                    myDataTableCboKaryawan.Clear()
                    Call myCFormManipulation.ResetForm(gbDetail)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub dtpPeriode_Validated(sender As Object, e As EventArgs) Handles dtpAwal.Validated, dtpAkhir.Validated
        Try
            If Not isPartialChanged Then
                isPartialChanged = True
                If (sender Is dtpAwal) Then
                    If (dtpAwal.Value > dtpAkhir.Value) Then
                        dtpAkhir.Value = dtpAwal.Value.AddDays(30)
                    End If
                ElseIf (sender Is dtpAkhir) Then
                    If (dtpAwal.Value > dtpAkhir.Value) Then
                        dtpAwal.Value = dtpAkhir.Value.AddDays(-30)
                    End If
                End If
                isPartialChanged = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpPeriode_Validated Error")
        End Try
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            If (cboLokasi.SelectedIndex <> -1 And cboPerusahaan.SelectedIndex <> -1 And cboDepartemen.SelectedIndex <> -1 And cboGrup.SelectedIndex <> -1 And cboKetGrup.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                gbDetail.Enabled = True
                Call myCFormManipulation.ResetForm(gbDetail)
                Call myCFormManipulation.SetReadOnly(gbDetail, False)

                Dim indukPerusahaan As String = Nothing
                isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaHRD & ".mscompanymapping", "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and outsource='True'")
                If (isExist) Then
                    'stSQL = "SELECT induk FROM " & CONN_.schemaHRD & ".mscompanymapping WHERE perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and outsource='True';"
                    'indukPerusahaan = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                    indukPerusahaan = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "induk", CONN_.schemaHRD & ".mscompanymapping",, "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and outsource='True'", CONN_.dbType)
                End If
                stSQL = "SELECT concat(nama,' || ',nip) as karyawan,idk,nip,nama FROM " & CONN_.schemaHRD & ".mskaryawanaktif WHERE lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' AND (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "'" & IIf(IsNothing(indukPerusahaan), Nothing, " or perusahaan='" & myCStringManipulation.SafeSqlLiteral(indukPerusahaan) & "'") & ") And departemen='" & myCStringManipulation.SafeSqlLiteral(cboDepartemen.SelectedValue) & "' And " & cboGrup.SelectedItem & " ='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "' GROUP BY concat(nama,' || ',nip),idk,nip,nama ORDER BY karyawan;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared, True)

                Call SetDGVDetail(cboPerusahaan.SelectedValue, dtpAwal.Value.Date, dtpAkhir.Value.Date)
                'lblScheduleShift.Text = "SCHEDULE " & cboPerusahaan.SelectedValue & " PERIODE " & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & " S/D " & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy")
                'lblScheduleShift.Visible = True
                gbDataEntry.Enabled = False

                Me.Cursor = Cursors.Default
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua field yang bertanda *")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnGenerate_Click Error")
        End Try
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Try
            If (cboPerusahaan.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim indukPerusahaan As String = Nothing
                isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaHRD & ".mscompanymapping", "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and outsource='True'")
                If (isExist) Then
                    indukPerusahaan = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "induk", CONN_.schemaHRD & ".mscompanymapping",, "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and outsource='True'", CONN_.dbType)
                End If
                stSQL = "SELECT concat(nama,' || ',nip) as karyawan,idk,nip,nama FROM " & CONN_.schemaHRD & ".mskaryawanaktif WHERE lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' AND (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "'" & IIf(IsNothing(indukPerusahaan), Nothing, " or perusahaan='" & myCStringManipulation.SafeSqlLiteral(indukPerusahaan) & "'") & ") And " & cboGrup.SelectedItem & " ='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "' GROUP BY concat(nama,' || ',nip),idk,nip,nama ORDER BY karyawan;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared, True)

                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnReload_Click Error")
        End Try
    End Sub

    Private Sub btnTambahkan_Click(sender As Object, e As EventArgs) Handles btnTambahkan.Click
        Try
            Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Dim mRows(dgvDetail.ColumnCount) As String
            Dim a As UShort
            Dim mFound As Boolean
            Dim idxFound As Short = 0

            If (cboKaryawan.SelectedIndex <> -1) Then
                mFound = False
                For i As Short = 0 To dgvDetail.RowCount - 1
                    If (cboKaryawan.SelectedValue = dgvDetail.Rows(i).Cells("nip").Value And strWaktuShift <> "Kosong") Then
                        mFound = True
                        idxFound += 1
                    End If
                Next

                If Not mFound Then
                    'Hanya boleh 2 shift saja maksimal dalam 1 hari
                    'Dibiarkan dulu, karena harusnya sesuai kebijakkan
                    'If (idxFound < 2) Then
                    'Cek isexist nya hanya yang di luar schedule shift yang lagi di edit
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameDetail, "noscheduleshift<>'" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "' and nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "' AND tanggal>='" & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy") & "'")
                    If Not (isExist) Then
                        lineNr += 1
                        mRows(0) = "0"
                        mRows(1) = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "perusahaan", CONN_.schemaHRD & ".mskaryawanaktif",, "nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", CONN_.dbType)
                        mRows(2) = cboLokasi.SelectedValue
                        mRows(3) = cboDepartemen.SelectedValue
                        mRows(4) = cboGrup.SelectedItem
                        mRows(5) = cboKetGrup.SelectedValue
                        mRows(6) = DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("idk")
                        mRows(7) = cboKaryawan.SelectedValue
                        mRows(8) = DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")
                        mRows(9) = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "posisi", CONN_.schemaHRD & ".msposisikaryawan",, "nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", CONN_.dbType)
                        mRows(10) = lineNr

                        a = 11
                        tanggalBerjalan = dtpAwal.Value.Date
                        While tanggalBerjalan <= tanggalAkhir
                            If (strWaktuShift = "Pagi" Or strWaktuShift = "Siang" Or strWaktuShift = "Malam") Then
                                mRows(a) = strWaktuShift.Substring(0, 1).ToUpper
                            ElseIf (strWaktuShift = "Libur") Then
                                mRows(a) = "X"
                            ElseIf (strWaktuShift = "Kosong") Then
                                mRows(a) = Nothing
                            End If

                            tanggalBerjalan = tanggalBerjalan.AddDays(1)
                            a += 1
                            If (a Mod 100 = 0) Then
                                GC.Collect()
                            End If
                        End While

                        mRows(a) = True
                        mRows(a + 1) = False

                        dgvDetail.Rows.Add(mRows)

                        'atur warna selang seling datagrid
                        'Call myCDataGridViewManipulation.SetDGVColour(dgvDetail)

                        'Untuk mengatur warna background cell, agar dapat lebih mudah dibedakan saja
                        With dgvDetail
                            For i As Short = 0 To .ColumnCount - 1
                                If Not (.Columns(i).HeaderText.Contains("(")) Then
                                    .Columns(i).DefaultCellStyle.BackColor = Color.White
                                Else
                                    .CurrentCell = .Item(i, .RowCount - 1)
                                    .CurrentCell.Style.BackColor = lblWaktuShift.BackColor
                                End If
                            Next
                            'Untuk kembalikan current cell ke kolom paling awal lagi dan baris paling akhir
                            .CurrentCell = .Item(.Columns("nip").Index, .RowCount - 1)
                        End With
                        'untuk menampilkan auto number pada rowHeaders
                        Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
                    Else
                        Call myCShowMessage.ShowWarning("Karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("karyawan") & " sudah terdaftar schedule shift di tanggal " & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & " sampai " & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy"))
                    End If
                    'Else
                    '    Call myCShowMessage.ShowWarning("Maksimal 2 jadwal shift saja dalam 1 hari")
                    'End If
                Else
                    Call myCShowMessage.ShowWarning("Karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("karyawan") & " sudah ada dalam daftar!!" & ControlChars.NewLine & "Jika ingin memasukkan 2 shift dalam 1 tanggal, pilih shift kedua sebagai kosong dulu!")
                    rbKosong.Checked = True
                End If
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua field yang bertanda *")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTambahkan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub rbWaktuShift_CheckedChanged(sender As Object, e As EventArgs) Handles rbPagi.CheckedChanged, rbSiang.CheckedChanged, rbMalam.CheckedChanged, rbLibur.CheckedChanged, rbKosong.CheckedChanged
        Try
            strWaktuShift = sender.text
            If (sender Is rbPagi Or sender Is rbSiang Or sender Is rbMalam) Then
                lblWaktuShift.Text = sender.text & "(" & sender.text.ToString.Substring(0, 1).ToUpper & ")"
            ElseIf (sender Is rbLibur) Then
                lblWaktuShift.Text = sender.text & "(X)"
            ElseIf (sender Is rbKosong) Then
                lblWaktuShift.Text = sender.text & "()"
            End If
            lblWaktuShift.BackColor = sender.BackColor
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbWaktuShift_CheckedChanged Error")
        End Try
    End Sub

    Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
        Try
            isNew = True
            Call myCFormManipulation.ResetForm(gbDataEntry)
            Call myCFormManipulation.ResetForm(gbDetail)
            Call myCFormManipulation.SetReadOnly(gbDataEntry, False)
            myDataTableCboKaryawan.Clear()
            tbNoScheduleShift.ReadOnly = True
            gbDataEntry.Enabled = True
            gbDetail.Enabled = False
            btnSimpan.Enabled = True
            dtpAkhir.Value = dtpAwal.Value.AddDays(30)
            rbPagi.Checked = True
            lineNr = 0
            cboLokasi.SelectedIndex = 0
            'lblScheduleShift.Visible = False
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCreateNew_Click Error")
        End Try
    End Sub

    Private Sub dgvDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetail.DataError
        Try
            Call myCShowMessage.ShowWarning("Ada error pada pengisian datagrid!!")
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_DataError Error")
        End Try
    End Sub

    Private Sub dgvDetail_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDetail.CellMouseDown
        Try
            If (dgvDetail.RowCount > 0) Then
                'fungsi ini ditujukan agar user bisa memilih cell dengan klik kanan juga
                If e.Button = MouseButtons.Right Then
                    If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then
                        'kondisi ini untuk kalau user meng-klik kanan dalam area dgv bukan di header2nya
                        If (e.ColumnIndex <> dgvDetail.Columns("rid").Index And e.ColumnIndex <> dgvDetail.Columns("lokasi").Index And e.ColumnIndex <> dgvDetail.Columns("grup").Index And e.ColumnIndex <> dgvDetail.Columns("ketgrup").Index And e.ColumnIndex <> dgvDetail.Columns("perusahaan").Index And e.ColumnIndex <> dgvDetail.Columns("nip").Index And e.ColumnIndex <> dgvDetail.Columns("nama").Index And e.ColumnIndex <> dgvDetail.Columns("posisi").Index And e.ColumnIndex <> dgvDetail.Columns("linenr").Index And e.ColumnIndex <> dgvDetail.Columns("new").Index And e.ColumnIndex <> dgvDetail.Columns("edited").Index) Then
                            isExist = False
                            Dim isExist2 As Boolean = False
                            For i As UShort = 0 To dgvDetail.RowCount - 1
                                If (i <> e.RowIndex) Then
                                    If (dgvDetail.Rows(i).Cells("nip").Value = dgvDetail.Rows(e.RowIndex).Cells("nip").Value And dgvDetail.Rows(i).Cells(e.ColumnIndex).Value = IIf(strWaktuShift = "Pagi" Or strWaktuShift = "Siang" Or strWaktuShift = "Malam", strWaktuShift.Substring(0, 1).ToUpper, IIf(strWaktuShift = "Libur", "X", Nothing))) Then
                                        isExist = True
                                    Else
                                        If (strWaktuShift = "Libur") Then
                                            'Jika ditandai libur, maka sisi satunya tidak boleh ada isian selain kosong atau libur juga
                                            If (dgvDetail.Rows(i).Cells("nip").Value = dgvDetail.Rows(e.RowIndex).Cells("nip").Value And (dgvDetail.Rows(i).Cells(e.ColumnIndex).Value = "P" Or dgvDetail.Rows(i).Cells(e.ColumnIndex).Value = "S" Or dgvDetail.Rows(i).Cells(e.ColumnIndex).Value = "M")) Then
                                                isExist2 = True
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            With dgvDetail
                                initialValue = Nothing
                                '.ClearSelection()
                                .CurrentCell = dgvDetail.Item(e.ColumnIndex, e.RowIndex)
                                .CurrentCell.Selected = True
                                initialValue = .CurrentCell.Value
                                If Not (isExist) Then
                                    If Not (isExist2) Then
                                        If (strWaktuShift = "Pagi" Or strWaktuShift = "Siang" Or strWaktuShift = "Malam") Then
                                            '.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = strWaktuShift.Substring(0, 1).ToUpper
                                            .CurrentCell.Value = strWaktuShift.Substring(0, 1).ToUpper
                                        ElseIf (strWaktuShift = "Libur") Then
                                            '.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "X"
                                            .CurrentCell.Value = "X"
                                        ElseIf (strWaktuShift = "Kosong") Then
                                            '.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
                                            .CurrentCell.Value = Nothing
                                        End If

                                        If (initialValue <> .CurrentCell.Value) Then
                                            'jika berubah saja nilainya, maka dilakukan pewarnaan back color yang sesuai
                                            .CurrentCell.Style.BackColor = lblWaktuShift.BackColor
                                            If Not isNew Then
                                                'Hanya jika editing saja, maka dilakukan pengecekkan apakah datanya berubah dari default nya atau nggak
                                                If (.Rows(e.RowIndex).Cells("new").Value = False) Then
                                                    'Cek yang bukan kolom baru (new) saja
                                                    whereString = "nip='" & dgvDetail.CurrentRow.Cells("nip").Value & "' and linenr=" & dgvDetail.CurrentRow.Cells("linenr").Value
                                                    'If Not IsNothing(dgvDetail.CurrentRow.Cells(e.ColumnIndex).Value) Then
                                                    '    whereString &= " and [" & Format(CDate(dgvDetail.Columns(e.ColumnIndex).Name), "ddMMMyyyy") & "]='" & initialValue & "'"
                                                    'Else
                                                    '    whereString &= " and [" & Format(CDate(dgvDetail.Columns(e.ColumnIndex).Name), "ddMMMyyyy") & "] is nothing"
                                                    'End If
                                                    foundRows = myDataTableDGVDetail.Select(whereString)

                                                    If (foundRows.Count > 0) Then
                                                        'Harusnya pasti masuk ke sini
                                                        If Not (myDataTableDGVDetail.Rows(myDataTableDGVDetail.Rows.IndexOf(foundRows(0))).Item(e.ColumnIndex).Equals(.CurrentCell.Value)) Then
                                                            .Rows(e.RowIndex).Cells("edited").Value = True
                                                        Else
                                                            .Rows(e.RowIndex).Cells("edited").Value = False
                                                        End If
                                                        'Else
                                                        '    'Harusnya gak mungkin masuk ke sini
                                                        '    'Bisa masuk ke sini apabila data diganti beberapa kali, misal asal dari S, diganti ke P, terus diganti lagi ke M (nah pas diganti ke M ini, bisa masuk ke sini)
                                                        '    'Karena initialValue akan berganti jadi P
                                                        '    whereString = "nip='" & dgvDetail.CurrentRow.Cells("nip").Value & "'"
                                                        '    foundRows = myDataTableDGVDetail.Select(whereString)
                                                        '    If (foundRows.Count > 0) Then
                                                        '        'Jika datanya ditemukan di data default nya
                                                        '        For i As Integer = 0 To foundRows.Length - 1
                                                        '            If (myDataTableDGVDetail.Rows(myDataTableDGVDetail.Rows.IndexOf(foundRows(i))).Item(Format(CDate(dgvDetail.Columns(e.ColumnIndex).Name), "ddMMMyyyy")) <> .CurrentCell.Value) Then
                                                        '                .Rows(e.RowIndex).Cells("edited").Value = True
                                                        '            Else
                                                        '                .Rows(e.RowIndex).Cells("edited").Value = False
                                                        '            End If
                                                        '        Next
                                                        '    Else
                                                        '        'Harusnya gak mungkin masuk ke sini
                                                        '        .Rows(e.RowIndex).Cells("edited").Value = False
                                                        '    End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Else
                                        Call myCShowMessage.ShowWarning("Kalau 1 sisi ada shift pagi atau siang atau malam, maka sisi yang lain tidak boleh libur!" & ControlChars.NewLine & "Bisa diganti dengan memilih shift kosong")
                                    End If
                                Else
                                    Call myCShowMessage.ShowWarning("Tidak boleh input shift kembar untuk karyawan yang sama dan di tanggal yang sama!!")
                                End If
                            End With
                        End If
                    Else
                        With dgvDetail
                            'kondisi ini untuk kalau user mengklik di header dgv nya
                            'selected cell sebelumnya di clear dulu
                            .ClearSelection()
                            'untuk mindah pointer
                            .CurrentCell = dgvDetail.Item(1, e.RowIndex)
                            'untuk select 1 baris penuh
                            .Rows(e.RowIndex).Selected = True
                        End With
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_CellMouseDown Error")
        End Try
    End Sub

    Private Sub dgvDetail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellContentClick
        Try
            If (dgvDetail.RowCount > 0) Then
                If (e.RowIndex <> -1) Then
                    If (e.ColumnIndex = dgvDetail.Columns("delete").Index) Then
                        If Not isNew Then
                            If (dgvDetail.CurrentRow.Cells("new").Value) Then
                                'langsung hapus aja kalau ini adalah record baru
                                dgvDetail.Rows.RemoveAt(e.RowIndex)
                            Else
                                'kalau ini adalah record lama, maka ditanyakan dulu apa benar mau dihapus
                                Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data di schedule shift periode " & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & " S/D " & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy") & " untuk karyawan " & dgvDetail.CurrentRow.Cells("nip").Value & "-" & dgvDetail.CurrentRow.Cells("nama").Value & " pada baris ini?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                                If (isConfirm = DialogResult.Yes) Then
                                    Me.Cursor = Cursors.WaitCursor
                                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                                    'whereString = "nip='" & dgvDetail.CurrentRow.Cells("nip").Value & "' and linenr=" & dgvDetail.CurrentRow.Cells("linenr").Value
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableNameDetail, "tobedel='True'", tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "' and nip='" & myCStringManipulation.SafeSqlLiteral(dgvDetail.CurrentRow.Cells("nip").Value) & "' and linenr='" & dgvDetail.CurrentRow.Cells("linenr").Value & "'")
                                    'For j As UShort = 0 To dgvDetail.ColumnCount - 1
                                    '    If (dgvDetail.Columns(j).HeaderText.Contains("(")) Then
                                    '        If Not IsNothing(dgvDetail.CurrentRow.Cells(j).Value) Then
                                    '            whereString &= " and [" & Format(CDate(dgvDetail.Columns(j).Name), "ddMMMyyyy") & "]='" & dgvDetail.CurrentRow.Cells(j).Value & "'"
                                    '        Else
                                    '            whereString &= " and [" & Format(CDate(dgvDetail.Columns(j).Name), "ddMMMyyyy") & "] is nothing"
                                    '        End If
                                    '    End If
                                    'Next
                                    'foundRows = myDataTableDGVDetail.Select(whereString)
                                    'If (foundRows.Count > 0) Then
                                    '    idxDetailDeleted(banyakDihapus) = myDataTableDGVDetail.Rows.IndexOf(foundRows(0))
                                    '    MsgBox(idxDetailDeleted(banyakDihapus))
                                    '    banyakDihapus += 1
                                    'End If

                                    dgvDetail.Rows.RemoveAt(e.RowIndex)
                                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                                    Me.Cursor = Cursors.Default
                                Else
                                    Call myCShowMessage.ShowInfo("Penghapusan data di schedule shift periode " & dgvDetail.CurrentRow.Cells("tanggal_awal").Value & " S/D " & dgvDetail.CurrentRow.Cells("tanggal_akhir").Value & " untuk karyawan " & dgvDetail.CurrentRow.Cells("nip").Value & "-" & dgvDetail.CurrentRow.Cells("nama").Value & " dibatalkan oleh user")
                                End If
                            End If
                        Else
                            dgvDetail.Rows.RemoveAt(e.RowIndex)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_CellContentClick Error")
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If (dgvDetail.RowCount > 0) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim queryBuilder As New Text.StringBuilder
                queryBuilder.Clear()

                Dim newValuesG As String
                Dim newFieldsG As String
                'Dim created_at As Date
                'created_at = Now
                'ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"

                If isNew Then
                    'JIKA INPUT BARU
                    If (cboPerusahaan.SelectedIndex <> -1 And cboLokasi.SelectedIndex <> -1 And cboDepartemen.SelectedIndex <> -1 And cboGrup.SelectedIndex <> -1 And cboKetGrup.SelectedIndex <> -1) Then
                        'CEK APAKAH NO SCHEDULE SUDAH EXIST ATAU NGGAK
                        isExist = True
                        While isExist
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameHeader, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "'")
                            If (isExist) Then
                                prefixCompleted = prefixKode & " -" & DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("kode")
                                strScheduleShift = myCDBOperation.SetDynamicAutoKode(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameHeader, tableKey, "rid", prefixCompleted, digitLength, False,, CONN_.dbType, Format(dtpAwal.Value.Date, "MMMyy"))
                                tbNoScheduleShift.Text = strScheduleShift
                            End If
                        End While

                        'HEADER
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "','" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(cboDepartemen.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "','" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "','" & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & "','" & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy") & "'," & ADD_INFO_.newValues
                        newFields = "perusahaan," & tableKey & ",lokasi,departemen,grup,ketgrup,tanggalawal,tanggalakhir," & ADD_INFO_.newFields
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("insert", tableNameHeader, newValues, newFields))

                        'DETAIL
                        For i As UShort = 0 To dgvDetail.RowCount - 1
                            newValuesG = "'" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("perusahaan").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("lokasi").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("departemen").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("grup").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("ketgrup").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("idk").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nip").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nama").Value) & "'," & dgvDetail.Rows(i).Cells("linenr").Value & "," & ADD_INFO_.newValues
                            newFieldsG = "noscheduleshift,perusahaan,lokasi,departemen,grup,ketgrup,idk,nip,nama,linenr," & ADD_INFO_.newFields
                            If Not IsNothing(dgvDetail.Rows(i).Cells("posisi").Value) Then
                                newValuesG &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("posisi").Value) & "'"
                                newFieldsG &= ",posisi"
                            End If
                            For j As UShort = 0 To dgvDetail.ColumnCount - 1
                                If (dgvDetail.Columns(j).HeaderText.Contains("(")) Then
                                    If Not IsNothing(dgvDetail.Rows(i).Cells(j).Value) Then
                                        'Kalau jadwal shift nya kosong, tidak perlu dimasukkan
                                        strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameDetail, "kdr", "rid", Format(CDate(dgvDetail.Columns(j).Name), "dd-MMM-yyyy"), dgvDetail.Rows(i).Cells("nip").Value, 0, CONN_.dbType)
                                        newValues = newValuesG & ",'" & Format(CDate(dgvDetail.Columns(j).Name), "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(strKDR).ToUpper & "','" & dgvDetail.Rows(i).Cells(j).Value & "'"
                                        newFields = newFieldsG & ",tanggal,kdr,waktushift"
                                        queryBuilder.Append(myCStringManipulation.QueryBuilder("insert", tableNameDetail, newValues, newFields))
                                    End If
                                End If
                            Next
                        Next

                        'JALANKAN TRANSACTIONNYA
                        If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                            Call myCShowMessage.ShowSavedMsg("Schedule shift " & Trim(tbNoScheduleShift.Text))
                            Call myCFormManipulation.SetReadOnly(gbDataEntry, True)
                            Call myCFormManipulation.SetReadOnly(gbDetail, True)
                            btnSimpan.Enabled = False
                        End If
                    Else
                        Call myCShowMessage.ShowWarning("Lengkapi dulu semua field yang bertanda bintang (*)!")
                        cboPerusahaan.Focus()
                    End If
                Else
                    'JIKA EDIT
                    'HEADER TIDAK BOLEH UPDATE APA2
                    updatePart(0) = False

                    'DETAIL
                    updateString = Nothing
                    For i As UShort = 0 To dgvDetail.RowCount - 1
                        whereString = "nip='" & dgvDetail.Rows(i).Cells("nip").Value & "' and linenr=" & dgvDetail.Rows(i).Cells("linenr").Value
                        'For j As UShort = 0 To dgvDetail.ColumnCount - 1
                        '    If (dgvDetail.Columns(j).HeaderText.Contains("(")) Then
                        '        If Not IsNothing(dgvDetail.Rows(i).Cells(j).Value) Then
                        '            whereString &= " and " & Format(CDate(dgvDetail.Columns(j).Name), "ddMMMyyyy") & "='" & dgvDetail.Rows(i).Cells(j).Value & "'"
                        '        Else
                        '            whereString &= " and " & Format(CDate(dgvDetail.Columns(j).Name), "ddMMMyyyy") & " is nothing"
                        '        End If

                        '    End If
                        'Next
                        foundRows = myDataTableDGVDetail.Select(whereString)

                        If (dgvDetail.Rows(i).Cells("new").Value) Then
                            'Jika baris baru ditambahkan, sudah pasti headernya ditambahkan
                            newValuesG = "'" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("perusahaan").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("lokasi").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("departemen").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("grup").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("ketgrup").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("idk").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nip").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nama").Value) & "'," & dgvDetail.Rows(i).Cells("linenr").Value & "," & ADD_INFO_.newValues
                            newFieldsG = "noscheduleshift,perusahaan,lokasi,departemen,grup,ketgrup,idk,nip,nama,linenr," & ADD_INFO_.newFields
                            If Not IsNothing(dgvDetail.Rows(i).Cells("posisi").Value) Then
                                newValuesG &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("posisi").Value) & "'"
                                newFieldsG &= ",posisi"
                            End If
                            For j As UShort = 0 To dgvDetail.ColumnCount - 1
                                If (dgvDetail.Columns(j).HeaderText.Contains("(")) Then
                                    If Not IsNothing(dgvDetail.Rows(i).Cells(j).Value) Then
                                        'Kalau jadwal shift nya kosong, tidak perlu dimasukkan
                                        strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameDetail, "kdr", "rid", Format(CDate(dgvDetail.Columns(j).Name), "dd-MMM-yyyy"), dgvDetail.Rows(i).Cells("nip").Value, 0, CONN_.dbType)
                                        newValues = newValuesG & ",'" & Format(CDate(dgvDetail.Columns(j).Name), "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(strKDR).ToUpper & "','" & dgvDetail.Rows(i).Cells(j).Value & "'"
                                        newFields = newFieldsG & ",tanggal,kdr,waktushift"
                                        queryBuilder.Append(myCStringManipulation.QueryBuilder("insert", tableNameDetail, newValues, newFields))

                                    End If
                                End If
                            Next
                            updatePart(1) = True
                        ElseIf (dgvDetail.Rows(i).Cells("edited").Value) Then
                            'Jika ditandai edit, bisa jadi edit data yang sudah ada,
                            'atau yang dari kosong ada isinya, berarti nambahkan data baru,
                            'atau yang dari ada isi jadi kosong berarti hapus data dari database
                            For j As UShort = 0 To dgvDetail.Columns.Count - 1
                                'MsgBox("isi kolom 1 dgv: " & dgvDetail.Rows(i).Cells(j).Value & " banding isi kolom 1 arrDef: " & myDataTableDGVDetail.Rows(myDataTableDGVDetail.Rows.IndexOf(foundRows(0))).Item(j))
                                If (dgvDetail.Columns(j).HeaderText.Contains("(")) Then
                                    If Not IsNothing(dgvDetail.Rows(i).Cells(j).Value) Then
                                        'Jika ada isinya, maka harus di cek dulu, apa record sebelumnya
                                        'Jika record sebelumnya kosong, maka entry baru
                                        'Tapi jika record sebelumnya ada isi shift selain kosong maka update datanya saja
                                        'MsgBox(myDataTableDGVDetail.Columns(j).ColumnName)
                                        If IsDBNull(myDataTableDGVDetail.Rows(myDataTableDGVDetail.Rows.IndexOf(foundRows(0))).Item(j)) Then
                                            'Kalau isi sebelumnya shift kosong, berarti masih belum ada datanya di database, maka langsung entry kan data baru
                                            strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameDetail, "kdr", "rid", Format(CDate(dgvDetail.Columns(j).Name), "dd-MMM-yyyy"), dgvDetail.Rows(i).Cells("nip").Value, 0, CONN_.dbType)
                                            newValues = "'" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("perusahaan").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("lokasi").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("departemen").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("grup").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("ketgrup").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("idk").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nip").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nama").Value) & "'," & dgvDetail.Rows(i).Cells("linenr").Value & ",'" & Format(CDate(dgvDetail.Columns(j).Name), "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(strKDR).ToUpper & "','" & dgvDetail.Rows(i).Cells(j).Value & "'," & ADD_INFO_.newValues
                                            newFields = "noscheduleshift,perusahaan,lokasi,departemen,grup,ketgrup,idk,nip,nama,linenr,tanggal,kdr,waktushift," & ADD_INFO_.newFields
                                            If Not IsNothing(dgvDetail.Rows(i).Cells("posisi").Value) Then
                                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("posisi").Value) & "'"
                                                newFields &= ",posisi"
                                            End If
                                            queryBuilder.Append(myCStringManipulation.QueryBuilder("insert", tableNameDetail, newValues, newFields))
                                        Else
                                            If Not (myDataTableDGVDetail.Rows(myDataTableDGVDetail.Rows.IndexOf(foundRows(0))).Item(j).Equals(dgvDetail.Rows(i).Cells(j).Value)) Then
                                                'Lakukan pengecekan, sama nggak isinya, kalau tidak sama saja yang di update
                                                'Kalau sebelumnya sudah ada isinya, dan bukan shift kosong, dan sekarang mau diganti dengan shift lain, maka tinggal update saja
                                                updateString = "waktushift='" & dgvDetail.Rows(i).Cells(j).Value & "'," & ADD_INFO_.updateString
                                                'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableNameDetail, CONN_.dbType)
                                                queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableNameDetail, updateString,, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "' and tanggal='" & Format(CDate(dgvDetail.Columns(j).Name), "dd-MMM-yyyy") & "' and nip='" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nip").Value) & "' and linenr=" & dgvDetail.Rows(i).Cells("linenr").Value))
                                            End If
                                        End If
                                    Else
                                        'Kalau dijadikan kosong jadwal shift nya, berarti record nya dihapus di database
                                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameDetail, "",, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "' and tanggal='" & Format(CDate(dgvDetail.Columns(j).Name), "dd-MMM-yyyy") & "' and nip='" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nip").Value) & "' and linenr=" & dgvDetail.Rows(i).Cells("linenr").Value))
                                    End If
                                End If
                            Next
                            updatePart(1) = True
                        End If
                    Next
                    'Bersihkan yang ditandai tobedel
                    'DELETE
                    Dim myDataTableToBeDel As New DataTable
                    stSQL = "SELECT rid,nip,linenr FROM " & tableNameDetail & " WHERE " & tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "' AND tobedel='True' GROUP BY rid,nip,linenr ORDER BY rid;"
                    myDataTableToBeDel = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Tobedel")
                    For i As Short = 0 To myDataTableToBeDel.Rows.Count - 1
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameDetail, "",, "rid=" & myDataTableToBeDel.Rows(i).Item("rid")))
                        updatePart(2) = True
                    Next

                    If (updatePart(0) Or updatePart(1) Or updatePart(2)) Then
                        'JALANKAN TRANSACTIONNYA UNTUK SAVE DATANYA!!
                        If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                            'JIKA TRANSACTION BERHASIL, MAKA UPDATE SEGALA ISI DATAGRID NYA
                            If (updatePart(0)) Then
                                'HEADER
                                'Tidak ada data di header schedule shift yang bisa di update waktu dilakukan editing
                            End If
                            If (updatePart(1)) Then
                                'DETAIL
                                For i As UShort = 0 To dgvDetail.RowCount - 1
                                    whereString = "nip='" & dgvDetail.Rows(i).Cells("nip").Value & "' and linenr=" & dgvDetail.Rows(i).Cells("linenr").Value
                                    'For j As UShort = 0 To dgvDetail.ColumnCount - 1
                                    '    If (dgvDetail.Columns(j).HeaderText.Contains("(")) Then
                                    '        If Not IsNothing(dgvDetail.Rows(i).Cells(j).Value) Then
                                    '            whereString &= " and " & Format(CDate(dgvDetail.Columns(j).Name), "ddMMMyyyy") & "='" & dgvDetail.Rows(i).Cells(j).Value & "'"
                                    '        Else
                                    '            whereString &= " and " & Format(CDate(dgvDetail.Columns(j).Name), "ddMMMyyyy") & " is nothing"
                                    '        End If

                                    '    End If
                                    'Next
                                    foundRows = myDataTableDGVDetail.Select(whereString)

                                    If (dgvDetail.Rows(i).Cells("new").Value) Then
                                        'Tambah baris baru, maka juga menambahkan record baru ke grid nya beserta isi shift nya di masing2 tanggal
                                        With myDataTableDGVDetail
                                            Dim newDataTableDetail As DataRow = .NewRow()
                                            newDataTableDetail("rid") = 0
                                            newDataTableDetail("perusahaan") = Trim(dgvDetail.Rows(i).Cells("perusahaan").Value)
                                            newDataTableDetail("lokasi") = Trim(dgvDetail.Rows(i).Cells("lokasi").Value)
                                            newDataTableDetail("departemen") = Trim(dgvDetail.Rows(i).Cells("departemen").Value)
                                            newDataTableDetail("grup") = Trim(dgvDetail.Rows(i).Cells("grup").Value)
                                            newDataTableDetail("ket_grup") = Trim(dgvDetail.Rows(i).Cells("ketgrup").Value)
                                            newDataTableDetail("idk") = Trim(dgvDetail.Rows(i).Cells("idk").Value)
                                            newDataTableDetail("nip") = Trim(dgvDetail.Rows(i).Cells("nip").Value)
                                            newDataTableDetail("nama") = Trim(dgvDetail.Rows(i).Cells("nama").Value)
                                            newDataTableDetail("posisi") = IIf(IsNothing(dgvDetail.Rows(i).Cells("posisi").Value), "", Trim(dgvDetail.Rows(i).Cells("posisi").Value))
                                            newDataTableDetail("linenr") = dgvDetail.Rows(i).Cells("linenr").Value
                                            For j As UShort = 0 To dgvDetail.ColumnCount - 1
                                                If (dgvDetail.Columns(j).HeaderText.Contains("(")) Then
                                                    If Not IsNothing(dgvDetail.Rows(i).Cells(j).Value) Then
                                                        newDataTableDetail(Format(CDate(dgvDetail.Columns(j).Name), "ddMMMyyyy")) = dgvDetail.Rows(i).Cells(j).Value
                                                    End If
                                                End If
                                            Next
                                            'memasukkan row baru tersebut ke data tabel master barang
                                            .Rows.Add(newDataTableDetail)
                                        End With
                                    ElseIf (dgvDetail.Rows(i).Cells("edited").Value) Then
                                        'Kalau edit, kalau di grid nya gak perlu menambahkan record baru, beda dengan kalau insert ke database
                                        For j As UShort = 0 To dgvDetail.ColumnCount - 1
                                            If (dgvDetail.Columns(j).HeaderText.Contains("(")) Then
                                                foundRows = myDataTableDGVDetail.Select("nip='" & dgvDetail.Rows(i).Cells("nip").Value & "' AND linenr=" & dgvDetail.Rows(i).Cells("linenr").Value)
                                                If Not IsNothing(dgvDetail.Rows(i).Cells(j).Value) Then
                                                    'If IsNothing(arrShiftDefValues(myDataTableDGVDetail.Rows.IndexOf(foundRows(0)), j)) Then
                                                    '    'Kalau waktu shift sebelumnya kosong
                                                    '    foundRows = myDataTableDGVDetail.Select("tanggal='" & Format(CDate(dgvDetail.Columns(j).Name), "dd-MMM-yyyy") & "' AND nip='" & dgvDetail.Rows(i).Cells("nip").Value & "' AND waktushift is nothing")
                                                    '    With myDataTableDGVDetail
                                                    '        .Rows(.Rows.IndexOf(foundRows(0))).Item(Format(CDate(dgvDetail.Columns(j).Name), "ddMMMyyyy")) = dgvDetail.Rows(i).Cells(j).Value
                                                    '    End With
                                                    'Else
                                                    '    If (dgvDetail.Rows(i).Cells(j).Value <> arrShiftDefValues(myDataTableDGVDetail.Rows.IndexOf(foundRows(0)), j)) Then
                                                    '        'Kalau waktu shift sebelumnya tidak kosong
                                                    '        foundRows = myDataTableDGVDetail.Select("tanggal='" & Format(CDate(dgvDetail.Columns(j).Name), "dd-MMM-yyyy") & "' AND nip='" & dgvDetail.Rows(i).Cells("nip").Value & "' AND waktushift='" & arrShiftDefValues(myDataTableDGVDetail.Rows.IndexOf(foundRows(0)), j) & "'")
                                                    '        With myDataTableDGVDetail
                                                    '            .Rows(.Rows.IndexOf(foundRows(0))).Item(Format(CDate(dgvDetail.Columns(j).Name), "ddMMMyyyy")) = dgvDetail.Rows(i).Cells(j).Value
                                                    '        End With
                                                    '    End If
                                                    'End If
                                                    With myDataTableDGVDetail
                                                        .Rows(.Rows.IndexOf(foundRows(0))).Item(Format(CDate(dgvDetail.Columns(j).Name), "ddMMMyyyy")) = dgvDetail.Rows(i).Cells(j).Value
                                                    End With
                                                Else
                                                    'Kalau waktu shift nya dijadikan kosong, dari sebelumnya ada isinya
                                                    With myDataTableDGVDetail
                                                        .Rows(.Rows.IndexOf(foundRows(0))).Item(Format(CDate(dgvDetail.Columns(j).Name), "ddMMMyyyy")) = Nothing
                                                    End With
                                                End If
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                            If (updatePart(2)) Then
                                'DELETE
                                For i As Short = 0 To myDataTableToBeDel.Rows.Count - 1
                                    whereString = "nip='" & myCStringManipulation.SafeSqlLiteral(myDataTableToBeDel.Rows(i).Item("nip")) & "' and linenr=" & myDataTableToBeDel.Rows(i).Item("linenr")

                                    foundRows = myDataTableDGVDetail.Select(whereString)
                                    If (foundRows.Count > 0) Then
                                        myDataTableDGVDetail.Rows.RemoveAt(myDataTableDGVDetail.Rows.IndexOf(foundRows(0)))
                                    End If
                                Next
                            End If
                            Call myCShowMessage.ShowUpdatedMsg("SPK " & Trim(tbNoScheduleShift.Text))
                            Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
                        End If
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Try
            Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus Schedule Shift " & tbNoScheduleShift.Text & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
            If (isConfirm = DialogResult.Yes) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim foundRows As DataRow()
                Dim queryBuilder As New Text.StringBuilder

                queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameHeader, "",, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "'"))
                queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameDetail, "",, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "'"))

                If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                    Call myCShowMessage.ShowDeletedMsg("Schedule Shift " & Trim(tbNoScheduleShift.Text))
                    foundRows = myDataTableHeader.Select("rid=" & arrDefValues(0))
                    If (foundRows.Count > 0) Then
                        myDataTableHeader.Rows.RemoveAt(myDataTableHeader.Rows.IndexOf(foundRows(0)))
                    End If
                    myDataTableDGVDetail.Clear()
                    Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
                End If
            Else
                Call myCShowMessage.ShowInfo("Penghapusan SPK " & tbNoScheduleShift.Text & " dibatalkan oleh user")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnHapus_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Try
            stSQL = "SELECT h.perusahaan,h." & tableKey & ",h.lokasi,h.departemen,h.grup,h.ketgrup,h.tanggalawal,h.tanggalakhir,h.catatan,d.tanggal,d.nip,d.nama,d.posisi,d.linenr,d.waktushift
                    FROM " & tableNameHeader & " as h inner join " & tableNameDetail & " as d on h." & tableKey & "=d." & tableKey & " " & "
                    WHERE h." & tableKey & " = '" & myCStringManipulation.SafeSqlLiteral(tbNoScheduleShift.Text) & "'
                    ORDER BY d.nama,d.tanggal;"
            Dim frmDisplayReport As New FormDisplayReport.FormDisplayReport(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, stSQL, "ScheduleShift")
            Call myCFormManipulation.GoToForm(Me.MdiParent, frmDisplayReport)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCetak_Click Error")
        End Try
    End Sub

    Private Sub cboGrup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrup.SelectedIndexChanged
        Try
            If (cboGrup.SelectedIndex <> -1) Then
                Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem.ToString.ToLower) & "' order by keterangan;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKetGroup, myBindingKetGroup, cboKetGrup, "T_" & cboKetGrup.Name, "keterangan", "keterangan", isCboPrepared, True)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboGrup_SelectedIndexChanged Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class
