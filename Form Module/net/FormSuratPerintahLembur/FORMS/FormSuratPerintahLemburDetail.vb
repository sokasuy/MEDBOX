Public Class FormSuratPerintahLemburDetail
    Private isNew As Boolean
    Private parentFormName As String
    Private rid As Long
    Private dgvPosNow As Integer
    Private myDataTableHeader As New DataTable
    Private myDataTableDGVDetail As New DataTable
    Private tableNameHeader As String
    Private tableNameDetail As String
    Private tableKey As String
    Private cmbDgvNewCheckbox As New DataGridViewCheckBoxColumn()
    Private cmbDgvEditedCheckbox As New DataGridViewCheckBoxColumn()
    Private cmbDgvDetailHapusButton As New DataGridViewButtonColumn()
    Private cekTambahButton(2) As Boolean
    Private arrDefValues(10) As String
    Private isDataPrepared As Boolean
    Private newValues As String
    Private newFields As String
    Private updateString As String

    Private stSQL As String
    Private myDataTableCboPerusahaan As New DataTable
    Private myBindingPerusahaan As New BindingSource
    Private myDataTableCboKepala As New DataTable
    Private myBindingKepala As New BindingSource
    Private myDataTableCboKaryawan As New DataTable
    Private myBindingKaryawan As New BindingSource
    Private isCboPrepared As Boolean
    Private isExist As Boolean

    Private strSPL As String
    Private strKDR As String
    Private strJamLembur As TimeSpan
    Private prefixKode As String
    Private prefixCompleted As String
    Private digitLength As Integer
    Private isBinding As Boolean
    Private isValueChanged As Boolean
    Private mInitialValue As Object
    Private isPartialChanged As Boolean
    Private updatePart(2) As Boolean

    Public Sub New(ByRef _myDataTableHeader As DataTable, ByRef _myDataTableDGVDetail As DataTable, _tableNameHeader As String, _tableNameDetail As String, _tableKey As String, Optional _isNew As Boolean = True, Optional _rid As Long = 0, Optional _dgvPosNow As Integer = 0, Optional _parentFormName As String = "")
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
                ElseIf (isNew) Then
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormSuratPerintahLemburDetail Error")
        End Try
    End Sub

    Private Sub FormSuratPerintahLemburDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If Not isNew Then
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableNameDetail, "tobedel='False'", "nospl='" & tbNoSPL.Text & "'")
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
            Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormSuratPerintahLemburDetail_FormClosed Error")
        End Try
    End Sub

    Private Sub FormSuratPerintahLemburDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            isDataPrepared = False
            dtpTanggal.Enabled = False

            stSQL = "SELECT kode,keterangan FROM msgeneral where kategori='perusahaan' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPerusahaan, myBindingPerusahaan, cboPerusahaan, "T_" & cboPerusahaan.Name, "keterangan", "keterangan", isCboPrepared, True)

            digitLength = 4
            prefixKode = "SPL"
            gbDetail.Enabled = False

            dtpMulai.Value = New Date(Now.Year, Now.Month, Now.Day, 17, 0, 0)
            dtpSelesai.Value = New Date(Now.Year, Now.Month, Now.Day, 18, 0, 0)

            Call myCMiscFunction.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, parentFormName, USER_.T_USER_RIGHT)
            Call SetDGVEntry_()

            If Not isNew Then
                'Berarti Edit
                'Set Header
                'RecID
                arrDefValues(0) = myDataTableHeader.Rows(dgvPosNow).Item("rid")
                'Perusahaan
                For i As Integer = 0 To cboPerusahaan.Items.Count - 1
                    If (DirectCast(cboPerusahaan.Items(i), DataRowView).Item("keterangan") = myDataTableHeader.Rows(dgvPosNow).Item("perusahaan")) Then
                        cboPerusahaan.SelectedIndex = i
                        arrDefValues(1) = myDataTableHeader.Rows(dgvPosNow).Item("perusahaan")
                    End If
                Next
                'Tanggal
                dtpTanggal.Value = myDataTableHeader.Rows(dgvPosNow).Item("tanggal")
                arrDefValues(2) = myDataTableHeader.Rows(dgvPosNow).Item("tanggal")
                'No SPL
                tbNoSPL.Text = myDataTableHeader.Rows(dgvPosNow).Item("no_spl")
                arrDefValues(3) = myDataTableHeader.Rows(dgvPosNow).Item("no_spl")
                'Kepala
                For i As Integer = 0 To cboKepala.Items.Count - 1
                    If (DirectCast(cboKepala.Items(i), DataRowView).Item("nip") = myDataTableHeader.Rows(dgvPosNow).Item("nip_kepala")) Then
                        cboKepala.SelectedIndex = i
                        arrDefValues(4) = myDataTableHeader.Rows(dgvPosNow).Item("idk_kepala")
                        arrDefValues(5) = myDataTableHeader.Rows(dgvPosNow).Item("nip_kepala")
                        arrDefValues(6) = myDataTableHeader.Rows(dgvPosNow).Item("nama_kepala")
                    End If
                Next
                'bagian
                If Not IsDBNull(myDataTableHeader.Rows(dgvPosNow).Item("bagian")) Then
                    arrDefValues(7) = myDataTableHeader.Rows(dgvPosNow).Item("bagian")
                End If
                'divisi
                If Not IsDBNull(myDataTableHeader.Rows(dgvPosNow).Item("divisi")) Then
                    arrDefValues(8) = myDataTableHeader.Rows(dgvPosNow).Item("divisi")
                End If
                'departemen
                If Not IsDBNull(myDataTableHeader.Rows(dgvPosNow).Item("departemen")) Then
                    arrDefValues(9) = myDataTableHeader.Rows(dgvPosNow).Item("departemen")
                End If
                'Catatan
                If Not IsDBNull(myDataTableHeader.Rows(dgvPosNow).Item("catatan")) Then
                    rtbCatatanHeader.Text = myDataTableHeader.Rows(dgvPosNow).Item("catatan")
                    arrDefValues(10) = myDataTableHeader.Rows(dgvPosNow).Item("catatan")
                End If

                'Set Detail
                Dim mRows As String()
                'Dim jamLembur As TimeSpan
                For i As Integer = 0 To myDataTableDGVDetail.Rows.Count - 1
                    'jamLembur = myDataTableDGVDetail.Rows(i).Item("jam_lembur")
                    mRows = New String() {
                        myDataTableDGVDetail.Rows(i).Item("rid"),
                        Format(myDataTableDGVDetail.Rows(i).Item("tanggal"), "dd-MMM-yyyy"),
                        myDataTableDGVDetail.Rows(i).Item("no_spl"),
                        myDataTableDGVDetail.Rows(i).Item("kdr"),
                        myDataTableDGVDetail.Rows(i).Item("idk"),
                        myDataTableDGVDetail.Rows(i).Item("nip"),
                        myDataTableDGVDetail.Rows(i).Item("nama"),
                        IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item("bagian")), "", myDataTableDGVDetail.Rows(i).Item("bagian")),
                        IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item("divisi")), "", myDataTableDGVDetail.Rows(i).Item("divisi")),
                        IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item("departemen")), "", myDataTableDGVDetail.Rows(i).Item("departemen")),
                        myDataTableDGVDetail.Rows(i).Item("perusahaan"),
                        myDataTableDGVDetail.Rows(i).Item("pekerjaan"),
                        myDataTableDGVDetail.Rows(i).Item("jam_lembur").ToString,
                        Format(myDataTableDGVDetail.Rows(i).Item("mulai"), "dd-MMM-yyyy HH:mm"),
                        Format(myDataTableDGVDetail.Rows(i).Item("selesai"), "dd-MMM-yyyy HH:mm"),
                        IIf(IsDBNull(myDataTableDGVDetail.Rows(i).Item("catatan")), "", myDataTableDGVDetail.Rows(i).Item("catatan"))
                    }
                    With dgvDetail
                        .Rows.Add(mRows)
                    End With
                    Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
                Next

                If (clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))) Then
                    Call myCMiscFunction.SetReadOnly(gbDataEntry, False)
                    btnSimpan.Visible = True
                Else
                    Call myCMiscFunction.SetReadOnly(gbDataEntry, True)
                    btnSimpan.Visible = False
                End If
                cboPerusahaan.Enabled = False
                dtpTanggal.Enabled = False
                tbNoSPL.ReadOnly = True
                tbDepartemen.ReadOnly = True
                tbDivisi.ReadOnly = True
                tbBagian.ReadOnly = True
            Else
                btnHapus.Visible = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormSuratPerintahLemburDetail_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormSuratPerintahLemburDetail_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormSuratPerintahLemburDetail_Activated Error")
        End Try
    End Sub

    Private Sub FormSuratPerintahLemburDetail_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboPerusahaan.KeyDown, dtpTanggal.KeyDown, tbNoSPL.KeyDown, cboKepala.KeyDown, rtbCatatanHeader.KeyDown, cboKaryawan.KeyDown, tbPekerjaan.KeyDown, dtpMulai.KeyDown, dtpSelesai.KeyDown, rtbCatatanDetail.KeyDown, btnTambahkan.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnHapus.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is rtbCatatanDetail) Then
                    'Call btnSimpan_Click(btnSimpan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormSuratPerintahLemburDetail_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Try
            If Not isNew Then
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableNameDetail, "tobedel='False'", "nospl='" & tbNoSPL.Text & "'")
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
            Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnKeluar_Click Error")
        End Try
    End Sub

    Private Sub SetDGVEntry_()
        Try
            With dgvDetail
                .Columns.Add("rid", "RID")
                .Columns.Add("tanggal", "TANGGAL")
                .Columns.Add("nospl", "NO SPL")
                .Columns.Add("kdr", "KDR")
                .Columns.Add("idk", "IDK")
                .Columns.Add("nip", "NIP")
                .Columns.Add("nama", "NAMA")
                .Columns.Add("bagian", "BAGIAN")
                .Columns.Add("divisi", "DIVISI")
                .Columns.Add("departemen", "DEPARTEMEN")
                .Columns.Add("perusahaan", "PERUSAHAAN")
                .Columns.Add("pekerjaan", "PEKERJAAN")
                .Columns.Add("jamlembur", "JAM LEMBUR")
                .Columns.Add("mulai", "MULAI")
                .Columns.Add("selesai", "SELESAI")
                .Columns.Add("catatan", "CATATAN")

                .Columns("rid").Visible = False
                .Columns("tanggal").Visible = False
                .Columns("nospl").Visible = False
                .Columns("kdr").Visible = False
                .Columns("idk").Visible = False
                .Columns("perusahaan").Visible = False

                .Columns("tanggal").ValueType = GetType(Date)
                .Columns("jamlembur").ValueType = GetType(Object)
                .Columns("mulai").ValueType = GetType(Date)
                .Columns("selesai").ValueType = GetType(Date)

                .Columns("tanggal").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tanggal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("jamlembur").DefaultCellStyle.Format = "HH:mm:ss"
                .Columns("jamlembur").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("mulai").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm"
                .Columns("mulai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("selesai").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm"
                .Columns("selesai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns("nip").DefaultCellStyle.BackColor = Color.Gainsboro
                .Columns("nama").DefaultCellStyle.BackColor = Color.Gainsboro
                .Columns("bagian").DefaultCellStyle.BackColor = Color.Gainsboro
                .Columns("divisi").DefaultCellStyle.BackColor = Color.Gainsboro
                .Columns("departemen").DefaultCellStyle.BackColor = Color.Gainsboro
                .Columns("perusahaan").DefaultCellStyle.BackColor = Color.Gainsboro
                '.Columns("jamlembur").DefaultCellStyle.BackColor = Color.Gainsboro

                .Columns("nip").ReadOnly = True
                .Columns("nama").ReadOnly = True
                .Columns("bagian").ReadOnly = True
                .Columns("divisi").ReadOnly = True
                .Columns("departemen").ReadOnly = True
                .Columns("perusahaan").ReadOnly = True
                '.Columns("jamlembur").ReadOnly = True

                .Font = New Font("Arial", 9, FontStyle.Regular)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False

                .Columns("jamlembur").DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                .Columns("jamlembur").DefaultCellStyle.ForeColor = Color.Blue
                .Columns("mulai").DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                .Columns("mulai").DefaultCellStyle.ForeColor = Color.Blue
                .Columns("selesai").DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                .Columns("selesai").DefaultCellStyle.ForeColor = Color.Blue
            End With

            With cmbDgvNewCheckbox
                If Not (cekTambahButton(0)) Then
                    .HeaderText = "NEW"
                    .Name = "new"
                    .DataPropertyName = "new"
                    dgvDetail.Columns.Add(cmbDgvNewCheckbox)
                    dgvDetail.Columns("new").Width = 70
                    cekTambahButton(0) = True
                    .ReadOnly = True
                    .DefaultCellStyle.BackColor = Color.Gainsboro
                End If
                .DisplayIndex = dgvDetail.ColumnCount - 1
            End With
            With cmbDgvEditedCheckbox
                If Not (cekTambahButton(1)) Then
                    .HeaderText = "EDITED"
                    .Name = "edited"
                    .DataPropertyName = "edited"
                    dgvDetail.Columns.Add(cmbDgvEditedCheckbox)
                    dgvDetail.Columns("edited").Width = 70
                    cekTambahButton(1) = True
                    .ReadOnly = True
                    .DefaultCellStyle.BackColor = Color.Gainsboro
                End If
                .DisplayIndex = dgvDetail.ColumnCount - 1
            End With
            With cmbDgvDetailHapusButton
                If Not (cekTambahButton(2)) Then
                    .HeaderText = "DELETE"
                    .Name = "delete"
                    .Text = "Delete"
                    .UseColumnTextForButtonValue = True
                    dgvDetail.Columns.Add(cmbDgvDetailHapusButton)
                    dgvDetail.Columns("delete").Width = 100
                    cekTambahButton(2) = True
                    If (clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))) Then
                        btnHapus.Enabled = True
                        .Visible = True
                    Else
                        btnHapus.Enabled = False
                        If (isNew) Then
                            .Visible = True
                        Else
                            .Visible = False
                        End If
                    End If
                End If
                .DisplayIndex = dgvDetail.ColumnCount - 1
            End With

            'untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetDGVEntry_ Error")
        End Try
    End Sub

    Private Sub dgvDetail_Sorted(sender As Object, e As EventArgs) Handles dgvDetail.Sorted
        Try
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

                    stSQL = "SELECT nama + ' || ' + nip as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian FROM mskaryawanaktif WHERE perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' GROUP BY nama + ' || ' + nip,idk,nip,nama,perusahaan,departemen,divisi,bagian ORDER BY karyawan;"
                    Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared, True)

                    stSQL = "SELECT nama + ' || ' + nip as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian FROM mskaryawanaktif WHERE perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' GROUP BY nama + ' || ' + nip,idk,nip,nama,perusahaan,departemen,divisi,bagian ORDER BY karyawan;"
                    Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKepala, myBindingKepala, cboKepala, "T_" & cboKepala.Name, "nip", "karyawan", isCboPrepared, True)

                    prefixCompleted = prefixKode & "-" & DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("kode")
                    strSPL = myCDBOperation.SetDynamicAutoKode(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameHeader, tableKey, "rid", prefixCompleted, digitLength, False,, CONN_.dbType, Format(dtpTanggal.Value.Date, "MMMyy"))
                    tbNoSPL.Text = strSPL

                    isBinding = False
                    tbDepartemen.DataBindings.Clear()
                    tbDivisi.DataBindings.Clear()
                    tbBagian.DataBindings.Clear()
                    tbDepartemen.Clear()
                    tbDivisi.Clear()
                    tbBagian.Clear()
                    gbDetail.Enabled = True
                    'isDataPrepared = True

                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                    Me.Cursor = Cursors.Default
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboPerusahaan_SelectedIndexChanged Error")
        End Try
    End Sub

    Private Sub cboKepala_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKepala.SelectedIndexChanged
        Try
            If (isCboPrepared) Then
                If (cboKepala.SelectedIndex <> -1) Then
                    'Buat binding data
                    If Not (isBinding) Then
                        tbDepartemen.DataBindings.Add(New Binding("text", myBindingKepala, "departemen"))
                        tbDivisi.DataBindings.Add(New Binding("text", myBindingKepala, "divisi"))
                        tbBagian.DataBindings.Add(New Binding("text", myBindingKepala, "bagian"))
                        isBinding = True
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboKepala_SelectedIndexChanged Error")
        End Try
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Try
            If (cboPerusahaan.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                stSQL = "SELECT nama + ' || ' + nip as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian FROM mskaryawanaktif WHERE perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' GROUP BY nama + ' || ' + nip,idk,nip,nama,perusahaan,departemen,divisi,bagian ORDER BY karyawan;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared, True)

                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnReload_Click Error")
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboPerusahaan.Validated, cboKepala.Validated, cboKaryawan.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
                If (sender Is cboPerusahaan) Then
                    gbDetail.Enabled = False
                    strSPL = Nothing
                    tbNoSPL.Clear()

                    isBinding = False
                    myDataTableCboKepala.Clear()
                    'myBindingKepala.Clear()
                    cboKepala.SelectedIndex = -1
                    tbDepartemen.DataBindings.Clear()
                    tbDivisi.DataBindings.Clear()
                    tbBagian.DataBindings.Clear()
                    tbDepartemen.Clear()
                    tbDivisi.Clear()
                    tbBagian.Clear()
                ElseIf (sender Is cboKepala) Then
                    tbDepartemen.Clear()
                    tbDivisi.Clear()
                    tbBagian.Clear()
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub dtpSPL_ValueChanged(sender As Object, e As EventArgs) Handles dtpMulai.ValueChanged, dtpSelesai.ValueChanged
        Try
            If Not isPartialChanged Then
                isPartialChanged = True
                dtpSelesai.Checked = dtpMulai.Checked
                dtpSelesai.MinDate = dtpMulai.Value
                If (dtpMulai.Value > dtpSelesai.Value) Then
                    dtpSelesai.Value = dtpMulai.Value
                End If
                strJamLembur = dtpSelesai.Value - dtpMulai.Value
                tbJamLembur.Text = myCStringManipulation.CleanInputTime(strJamLembur.ToString)
                isPartialChanged = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpSPL_ValueChanged Error")
        End Try
    End Sub

    Private Sub tbJamLembur_Validated(sender As Object, e As EventArgs) Handles tbJamLembur.Validated
        Try
            If Not isPartialChanged Then
                isPartialChanged = True
                tbJamLembur.Text = myCStringManipulation.CleanInputTime(Trim(tbJamLembur.Text))
                If (tbJamLembur.Text.Length > 0) Then
                    strJamLembur = TimeSpan.Parse(tbJamLembur.Text)
                    dtpSelesai.Value = dtpMulai.Value + strJamLembur
                Else
                    tbJamLembur.Text = myCStringManipulation.CleanInputTime(strJamLembur.ToString)
                End If
                isPartialChanged = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbJamLembur_Validated Error")
        End Try
    End Sub

    Private Sub btnTambahkan_Click(sender As Object, e As EventArgs) Handles btnTambahkan.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Dim mRows As String()
            Dim mFound As Boolean

            If (cboKaryawan.SelectedIndex <> -1 And Trim(tbPekerjaan.Text).Length > 0) Then
                If (dtpMulai.Value = dtpSelesai.Value) Then
                    Call myCShowMessage.ShowWarning("Waktu mulai lembur tidak boleh sama dengan waktu selesai lembur!!")
                    dtpSelesai.Focus()
                Else
                    mFound = False
                    For i As Integer = 0 To dgvDetail.RowCount - 1
                        If (cboKaryawan.SelectedValue = dgvDetail.Rows(i).Cells("nip").Value And (dtpMulai.Value = dgvDetail.Rows(i).Cells("mulai").Value Or dtpSelesai.Value = dgvDetail.Rows(i).Cells("selesai").Value)) Then
                            mFound = True
                        End If
                    Next

                    If Not mFound Then
                        strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameDetail, "kdr", "rid", dtpTanggal.Value.Date, cboKaryawan.SelectedValue, digitLength, CONN_.dbType)
                        mRows = New String() {
                            0,
                            Format(dtpTanggal.Value.Date),
                            tbNoSPL.Text,
                            strKDR,
                            DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("idk"),
                            cboKaryawan.SelectedValue,
                            DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama"),
                            DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("bagian"),
                            DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("divisi"),
                            DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("departemen"),
                            DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("perusahaan"),
                            Trim(tbPekerjaan.Text),
                            strJamLembur.ToString,
                            Format(dtpMulai.Value, "dd-MMM-yyyy HH:mm"),
                            Format(dtpSelesai.Value, "dd-MMM-yyyy HH:mm"),
                            rtbCatatanDetail.Text,
                            True,
                            False
                        }
                        With dgvDetail
                            .Rows.Add(mRows)
                        End With
                        Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvDetail, dgvDetail.RowCount)
                    Else
                        Call myCShowMessage.ShowWarning("Karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("karyawan") & " periode lembur " & Format(dtpMulai.Value, "dd-MMM-yyyy HH:mm") & " sampai " & Format(dtpSelesai.Value, "dd-MMM-yyyy HH:mm") & " sudah ada di daftar" & ControlChars.NewLine & "Tidak boleh ada data lembur yang kembar dalam 1 SPL!!")
                    End If
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

    Private Sub dgvDetail_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDetail.CellBeginEdit
        Try
            If (isDataPrepared) Then
                If Not IsDBNull(dgvDetail.CurrentCell.Value) Then
                    If (e.ColumnIndex = dgvDetail.Columns("jamlembur").Index) Then
                        mInitialValue = dgvDetail.CurrentCell.Value
                    Else
                        mInitialValue = Trim(dgvDetail.CurrentCell.Value)
                    End If
                Else
                    mInitialValue = Nothing
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_CellBeginEdit Error")
        End Try
    End Sub

    Private Sub dgvDetail_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetail.CellValueChanged
        Try
            If (isDataPrepared) Then
                If Not isPartialChanged Then
                    If Not IsDBNull(dgvDetail.CurrentCell.Value) Then
                        'kalau tidak null isinya
                        'If (e.ColumnIndex = dgvDetail.Columns("jamlembur").Index) Then
                        '    If (TimeSpan.Parse(mInitialValue) <> TimeSpan.Parse(dgvDetail.CurrentCell.Value)) Then
                        '        isValueChanged = True
                        '    Else
                        '        isValueChanged = False
                        '    End If
                        'Else
                        If (mInitialValue <> dgvDetail.CurrentCell.Value) Then
                            Dim cekLembur As String
                            If (e.ColumnIndex = dgvDetail.Columns("jamlembur").Index) Then
                                cekLembur = myCStringManipulation.CleanInputTime(dgvDetail.CurrentRow.Cells("jamlembur").Value)
                                If IsNothing(cekLembur) Then
                                    Call myCShowMessage.ShowWarning("Format pengisian jam lembur salah dan jam lembur tidak boleh lebih dari 24 jam!!" & ControlChars.NewLine & "Jam lembur dikembalikan ke waktu semula")
                                    isPartialChanged = True
                                    dgvDetail.CurrentCell.Value = mInitialValue
                                    isPartialChanged = False
                                    isValueChanged = False
                                Else
                                    isValueChanged = True
                                End If
                            ElseIf (e.ColumnIndex = dgvDetail.Columns("mulai").Index Or e.ColumnIndex = dgvDetail.Columns("selesai").Index) Then
                                strJamLembur = Date.Parse(dgvDetail.CurrentRow.Cells("selesai").Value) - Date.Parse(dgvDetail.CurrentRow.Cells("mulai").Value)
                                cekLembur = myCStringManipulation.CleanInputTime(strJamLembur.ToString)
                                If IsNothing(cekLembur) Then
                                    Call myCShowMessage.ShowWarning("Format pengisian jam lembur salah dan jam lembur tidak boleh lebih dari 24 jam!!" & ControlChars.NewLine & "Jam lembur dikembalikan ke waktu semula")
                                    isPartialChanged = True
                                    dgvDetail.CurrentCell.Value = Format(Date.Parse(mInitialValue), "dd-MMM-yyyy HH:mm")
                                    'If (e.ColumnIndex = dgvDetail.Columns("mulai").Index) Then
                                    '    dgvDetail.CurrentRow.Cells("mulai").Value = Format(Date.Parse(mInitialValue), "dd-MMM-yyyy HH:mm")
                                    'ElseIf (e.ColumnIndex = dgvDetail.Columns("selesai").Index) Then
                                    '    dgvDetail.CurrentRow.Cells("selesai").Value = Format(Date.Parse(mInitialValue), "dd-MMM-yyyy HH:mm")
                                    'End If
                                    isPartialChanged = False
                                    isValueChanged = False
                                Else
                                    isValueChanged = True
                                End If
                            Else
                                isValueChanged = True
                            End If
                        Else
                            isValueChanged = False
                        End If
                        'End If
                    Else
                        If (e.ColumnIndex <> dgvDetail.Columns("jamlembur").Index And e.ColumnIndex <> dgvDetail.Columns("mulai").Index And e.ColumnIndex <> dgvDetail.Columns("selesai").Index) Then
                            If Not IsNothing(mInitialValue) Then
                                isPartialChanged = True
                                isValueChanged = True
                                dgvDetail.CurrentCell.Value = Nothing
                                isPartialChanged = False
                            Else
                                isValueChanged = False
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Format pengisian jam lembur salah dan jam lembur tidak boleh lebih dari 24 jam!!" & ControlChars.NewLine & "Jam lembur dikembalikan ke waktu semula")
                            isPartialChanged = True
                            If (e.ColumnIndex = dgvDetail.Columns("mulai").Index Or e.ColumnIndex = dgvDetail.Columns("selesai").Index) Then
                                dgvDetail.CurrentCell.Value = Format(Date.Parse(mInitialValue), "dd-MMM-yyyy HH:mm")
                            ElseIf (e.ColumnIndex = dgvDetail.Columns("jamlembur").Index) Then
                                dgvDetail.CurrentRow.Cells("jamlembur").Value = mInitialValue
                            End If
                            isPartialChanged = False
                            isValueChanged = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_CellValueChanged Error")
        End Try
    End Sub

    Private Sub dgvDetail_CellValidated(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetail.CellValidated
        Try
            If (isDataPrepared) Then
                If (isValueChanged) Then
                    Select Case dgvDetail.Columns(e.ColumnIndex).Name
                        Case "jamlembur"
                            isPartialChanged = True
                            'dgvDetail.CurrentRow.Cells("jamlembur").Value = myCStringManipulation.CleanInputTime(Trim(dgvDetail.CurrentRow.Cells("jamlembur").Value))
                            If Not IsDBNull(dgvDetail.CurrentRow.Cells("jamlembur").Value) Then
                                Dim splselesai As Date
                                splselesai = Date.Parse(dgvDetail.CurrentRow.Cells("mulai").Value) + TimeSpan.Parse(dgvDetail.CurrentRow.Cells("jamlembur").Value)
                                dgvDetail.CurrentRow.Cells("selesai").Value = Format(splselesai, "dd-MMM-yyyy HH:mm")
                                If (dgvDetail.CurrentRow.Cells("new").Value = False) Then
                                    dgvDetail.CurrentRow.Cells("edited").Value = True
                                End If
                            Else
                                dgvDetail.CurrentRow.Cells("jamlembur").Value = mInitialValue
                                'If (dgvDetail.CurrentRow.Cells("new").Value = False) Then
                                '    dgvDetail.CurrentRow.Cells("edited").Value = False
                                'End If
                            End If
                            isPartialChanged = False
                        Case "mulai", "selesai"
                            If (dgvDetail.CurrentRow.Cells("mulai").Value > dgvDetail.CurrentRow.Cells("selesai").Value) Then
                                'SEHARUSNYA GAK MUNGKIN MASUK SINI!!
                                Call myCShowMessage.ShowWarning("Waktu selesai tidak boleh lebih kecil daripada waktu mulai!" & ControlChars.NewLine & "Waktu dikembalikan semula!")
                                dgvDetail.CurrentRow.Cells("selesai").Value = dgvDetail.CurrentRow.Cells("mulai").Value
                                'If (dgvDetail.CurrentRow.Cells("new").Value = False) Then
                                '    dgvDetail.CurrentRow.Cells("edited").Value = False
                                'End If
                            Else
                                If (dgvDetail.CurrentRow.Cells("new").Value = False) Then
                                    dgvDetail.CurrentRow.Cells("edited").Value = True
                                End If
                            End If
                            isPartialChanged = True
                            strJamLembur = Date.Parse(dgvDetail.CurrentRow.Cells("selesai").Value) - Date.Parse(dgvDetail.CurrentRow.Cells("mulai").Value)
                            dgvDetail.CurrentRow.Cells("jamlembur").Value = strJamLembur.ToString
                            isPartialChanged = False
                        Case "pekerjaan", "catatan"
                            isPartialChanged = True
                            If (dgvDetail.CurrentRow.Cells("new").Value = False) Then
                                dgvDetail.CurrentRow.Cells("edited").Value = True
                            End If
                            isPartialChanged = False
                    End Select
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_CellValidated Error")
        Finally
            isValueChanged = False
        End Try
    End Sub

    Private Sub dgvDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetail.DataError
        Try
            Call myCShowMessage.ShowWarning("Ada error pada pengisian datagrid!!")
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvDetail_DataError Error")
        End Try
    End Sub

    Private Sub dgvDetail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellContentClick
        Try
            If (dgvDetail.RowCount > 0) Then
                If (e.RowIndex <> -1) Then
                    If (e.ColumnIndex = dgvDetail.Columns("delete").Index) Then
                        'Dim foundRows As DataRow()
                        If Not isNew Then
                            If (dgvDetail.CurrentRow.Cells("new").Value) Then
                                'langsung hapus aja kalau ini adalah record baru
                                dgvDetail.Rows.RemoveAt(e.RowIndex)
                            Else
                                'kalau ini adalah record lama, maka ditanyakan dulu apa benar mau dihapus
                                Dim isConfirm As Integer
                                isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data lembur untuk karyawan " & dgvDetail.CurrentRow.Cells("nama").Value & " pada periode lembur " & dgvDetail.CurrentRow.Cells("mulai").Value & " sampai " & dgvDetail.CurrentRow.Cells("selesai").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                                If (isConfirm = 6) Then
                                    Me.Cursor = Cursors.WaitCursor
                                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableNameDetail, "tobedel='True'", "rid=" & dgvDetail.CurrentRow.Cells("rid").Value)
                                    'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableNameDetail, "rid=" & dgvDetail.CurrentRow.Cells("rid").Value, "sql")
                                    'Call myCShowMessage.ShowInfo("Penghapusan data lembur untuk karyawan " & dgvDetail.CurrentRow.Cells("nama").Value & " pada periode lembur " & dgvDetail.CurrentRow.Cells("mulai").Value & " sampai " & dgvDetail.CurrentRow.Cells("selesai").Value & " berhasil!")
                                    'foundRows = myDataTableDGVDetail.Select("rid=" & dgvDetail.CurrentRow.Cells("rid").Value)
                                    'myDataTableDGVDetail.Rows.RemoveAt(myDataTableDGVDetail.Rows.IndexOf(foundRows(0)))
                                    dgvDetail.Rows.RemoveAt(e.RowIndex)
                                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                                    Me.Cursor = Cursors.Default
                                Else
                                    Call myCShowMessage.ShowInfo("Penghapusan data lembur untuk karyawan " & dgvDetail.CurrentRow.Cells("nama").Value & " pada periode lembur " & dgvDetail.CurrentRow.Cells("mulai").Value & " sampai " & dgvDetail.CurrentRow.Cells("selesai").Value & " dibatalkan oleh user")
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
            If (dgvDetail.Rows.Count > 0) Then
                Me.Cursor = Cursors.Default
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim queryBuilder As New Text.StringBuilder
                queryBuilder.Clear()

                Dim created_at As Date
                created_at = Now
                ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"

                If isNew Then
                    If (cboPerusahaan.SelectedIndex <> -1 And cboKepala.SelectedIndex <> -1) Then
                        'JIKA INPUT BARU
                        'HEADER
                        'CEK APAKAH NO SPL SUDAH EXIST ATAU NGGAK
                        isExist = True
                        While isExist
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameHeader, "nospl='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'")
                            If (isExist) Then
                                prefixCompleted = prefixKode & " -" & DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("kode")
                                strSPL = myCDBOperation.SetDynamicAutoKode(CONN_.dbMain, CONN_.comm, CONN_.reader, tableNameHeader, tableKey, "rid", prefixCompleted, digitLength, False,, CONN_.dbType, Format(dtpTanggal.Value.Date, "MMMyy"))
                                tbNoSPL.Text = strSPL
                            End If
                        End While

                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "','" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk")) & "','" & myCStringManipulation.SafeSqlLiteral(cboKepala.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama")) & "'," & ADD_INFO_.newValues
                        newFields = "perusahaan,tanggal,nospl,idkkepala,nipkepala,namakepala," & ADD_INFO_.newFields
                        If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) & "'"
                            newFields &= ",bagian"
                        End If
                        If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) & "'"
                            newFields &= ",divisi"
                        End If
                        If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) & "'"
                            newFields &= ",departemen"
                        End If
                        If Trim(rtbCatatanHeader.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(rtbCatatanHeader.Text) & "'"
                            newFields &= ",catatan"
                        End If
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("insert", tableNameHeader, newValues, newFields))

                        'DETAIL
                        For i As Integer = 0 To dgvDetail.Rows.Count - 1
                            newValues = "'" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("kdr").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("idk").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nip").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nama").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("perusahaan").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("pekerjaan").Value) & "','" & dgvDetail.Rows(i).Cells("jamlembur").Value & "','" & dgvDetail.Rows(i).Cells("mulai").Value & "','" & dgvDetail.Rows(i).Cells("selesai").Value & "'," & ADD_INFO_.newValues
                            newFields = "tanggal,nospl,kdr,idk,nip,nama,perusahaan,pekerjaan,jamlembur,mulai,selesai," & ADD_INFO_.newFields
                            If (Trim(dgvDetail.Rows(i).Cells("bagian").Value).Length > 0) Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("bagian").Value) & "'"
                                newFields &= ",bagian"
                            End If
                            If (Trim(dgvDetail.Rows(i).Cells("divisi").Value).Length > 0) Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("divisi").Value) & "'"
                                newFields &= ",divisi"
                            End If
                            If (Trim(dgvDetail.Rows(i).Cells("departemen").Value).Length > 0) Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("departemen").Value) & "'"
                                newFields &= ",departemen"
                            End If
                            If (Trim(dgvDetail.Rows(i).Cells("catatan").Value).Length > 0) Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("catatan").Value) & "'"
                                newFields &= ",catatan"
                            End If
                            queryBuilder.Append(myCStringManipulation.QueryBuilder("insert", tableNameDetail, newValues, newFields))
                        Next

                        'JALANKAN TRANSACTIONNYA
                        If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                            'If (myDataTableHeader.Rows.Count < 10) Then
                            '    'HEADER
                            '    Dim myRID As Integer
                            '    myRID = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameHeader, "desc", "nospl='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'", CONN_.dbType)
                            '    With myDataTableHeader
                            '        Dim newDataTableHeader As DataRow = .NewRow()
                            '        newDataTableHeader("rid") = myRID
                            '        newDataTableHeader("perusahaan") = Trim(cboPerusahaan.SelectedValue)
                            '        newDataTableHeader("tanggal") = Format(dtpTanggal.Value.Date, "dd-MMM-yyyy")
                            '        newDataTableHeader("no_spl") = Trim(tbNoSPL.Text)
                            '        newDataTableHeader("idk_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk"))
                            '        newDataTableHeader("nip_kepala") = Trim(cboKepala.SelectedValue)
                            '        newDataTableHeader("nama_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama"))
                            '        newDataTableHeader("bagian") = IIf(Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")), Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")), DBNull.Value)
                            '        newDataTableHeader("divisi") = IIf(Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")), Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")), DBNull.Value)
                            '        newDataTableHeader("departemen") = IIf(Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")), Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")), DBNull.Value)
                            '        newDataTableHeader("catatan") = IIf(Trim(rtbCatatanHeader.Text).Length > 0, Trim(rtbCatatanHeader.Text), DBNull.Value)
                            '        newDataTableHeader("created_at") = created_at
                            '        'memasukkan row baru tersebut ke data tabel master barang
                            '        .Rows.Add(newDataTableHeader)
                            '    End With
                            'End If
                            Call myCShowMessage.ShowSavedMsg("SPL " & Trim(tbNoSPL.Text))
                            Call myCMiscFunction.ResetForm(gbDataEntry)
                        End If
                    Else
                        Call myCShowMessage.ShowWarning("Lengkapi dulu semua field yang bertanda bintang (*)!")
                        cboPerusahaan.Focus()
                    End If
                Else
                    'JIKA EDIT
                    If (cboKepala.SelectedIndex <> -1) Then
                        'HEADER
                        If (arrDefValues(4) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk")) Then
                            updateString = "idkkepala='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk")) & "',nipkepala='" & myCStringManipulation.SafeSqlLiteral(cboKepala.SelectedValue) & "',namakepala='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama")) & "'"
                            If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) Then
                                If (arrDefValues(7) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) Then
                                    updateString &= ",bagian='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) & "'"
                                End If
                            Else
                                If Not IsNothing(arrDefValues(7)) Then
                                    updateString &= ",bagian=Null"
                                End If
                            End If
                            If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) Then
                                If (arrDefValues(8) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) Then
                                    updateString &= ",divisi='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) & "'"
                                End If
                            Else
                                If Not IsNothing(arrDefValues(8)) Then
                                    updateString &= ",divisi=Null"
                                End If
                            End If
                            If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) Then
                                If (arrDefValues(9) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) Then
                                    updateString &= ",departemen='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) & "'"
                                End If
                            Else
                                If Not IsNothing(arrDefValues(9)) Then
                                    updateString &= ",departemen=Null"
                                End If
                            End If
                        End If
                        If (arrDefValues(10) <> Trim(rtbCatatanHeader.Text)) Then
                            If (Trim(rtbCatatanHeader.Text).Length > 0) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "catatan='" & myCStringManipulation.SafeSqlLiteral(rtbCatatanHeader.Text) & "'"
                            Else
                                updateString &= IIf(IsNothing(updateString), "", ",") & "catatan=Null"
                            End If
                        End If
                        If Not IsNothing(updateString) Then
                            updateString &= "," & ADD_INFO_.updateString
                            Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableNameHeader, CONN_.dbType)
                            queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableNameHeader, updateString,, "rid=" & arrDefValues(0)))
                            updatePart(0) = True
                        End If

                        updateString = Nothing
                        'DETAIL
                        For i As Integer = 0 To dgvDetail.RowCount - 1
                            If (dgvDetail.Rows(i).Cells("new").Value) Then
                                newValues = "'" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("kdr").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("idk").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nip").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("nama").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("perusahaan").Value) & "','" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("pekerjaan").Value) & "','" & dgvDetail.Rows(i).Cells("jamlembur").Value & "','" & dgvDetail.Rows(i).Cells("mulai").Value & "','" & dgvDetail.Rows(i).Cells("selesai").Value & "'," & ADD_INFO_.newValues
                                newFields = "tanggal,nospl,kdr,idk,nip,nama,perusahaan,pekerjaan,jamlembur,mulai,selesai," & ADD_INFO_.newFields
                                If (Trim(dgvDetail.Rows(i).Cells("bagian").Value).Length > 0) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("bagian").Value) & "'"
                                    newFields &= ",bagian"
                                End If
                                If (Trim(dgvDetail.Rows(i).Cells("divisi").Value).Length > 0) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("divisi").Value) & "'"
                                    newFields &= ",divisi"
                                End If
                                If (Trim(dgvDetail.Rows(i).Cells("departemen").Value).Length > 0) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("departemen").Value) & "'"
                                    newFields &= ",departemen"
                                End If
                                If (Trim(dgvDetail.Rows(i).Cells("catatan").Value).Length > 0) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("catatan").Value) & "'"
                                    newFields &= ",catatan"
                                End If
                                queryBuilder.Append(myCStringManipulation.QueryBuilder("insert", tableNameDetail, newValues, newFields))
                                updatePart(1) = True
                            ElseIf (dgvDetail.Rows(i).Cells("edited").Value) Then
                                updateString = "pekerjaan='" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("pekerjaan").Value) & "',jamlembur='" & dgvDetail.Rows(i).Cells("jamlembur").Value & "',mulai='" & dgvDetail.Rows(i).Cells("mulai").Value & "',selesai='" & dgvDetail.Rows(i).Cells("selesai").Value & "'"
                                If Trim(dgvDetail.Rows(i).Cells("catatan").Value).Length > 0 Then
                                    updateString &= IIf(IsNothing(updateString), "", ",") & "catatan='" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("catatan").Value) & "'"
                                Else
                                    updateString &= IIf(IsNothing(updateString), "", ",") & "catatan=Null"
                                End If
                                Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableNameDetail, CONN_.dbType)
                                queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableNameDetail, updateString,, "rid=" & dgvDetail.Rows(i).Cells("rid").Value))
                                updatePart(1) = True
                            End If
                        Next
                        'Bersihkan yang ditandai tobedel
                        'DELETE
                        Dim myDataTableToBeDel As New DataTable
                        stSQL = "SELECT rid FROM " & tableNameDetail & " WHERE nospl='" & tbNoSPL.Text & "' AND tobedel='True' ORDER BY rid;"
                        myDataTableToBeDel = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Tobedel")
                        For i As Integer = 0 To myDataTableToBeDel.Rows.Count - 1
                            queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameDetail, "",, "rid=" & myDataTableToBeDel.Rows(i).Item("rid")))
                            updatePart(2) = True
                        Next

                        'JALANKAN TRANSACTIONNYA UNTUK SAVE DATANYA!!
                        If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                            'JIKA TRANSACTION BERHASIL, MAKA UPDATE SEGALA ISI DATAGRID NYA
                            Dim foundRows As DataRow()
                            If (updatePart(0)) Then
                                'HEADER
                                If (arrDefValues(4) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk")) Then
                                    arrDefValues(4) = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk"))
                                    arrDefValues(5) = Trim(cboKepala.SelectedValue)
                                    arrDefValues(6) = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama"))
                                    myDataTableHeader.Rows(dgvPosNow).Item("idk_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk"))
                                    myDataTableHeader.Rows(dgvPosNow).Item("nip_kepala") = Trim(cboKepala.SelectedValue)
                                    myDataTableHeader.Rows(dgvPosNow).Item("nama_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama"))
                                    If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) Then
                                        If (arrDefValues(7) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian")) Then
                                            arrDefValues(7) = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian"))
                                            myDataTableHeader.Rows(dgvPosNow).Item("bagian") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("bagian"))
                                        End If
                                    Else
                                        If Not IsNothing(arrDefValues(7)) Then
                                            arrDefValues(7) = Nothing
                                            myDataTableHeader.Rows(dgvPosNow).Item("bagian") = DBNull.Value
                                        End If
                                    End If
                                    If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) Then
                                        If (arrDefValues(8) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi")) Then
                                            arrDefValues(8) = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi"))
                                            myDataTableHeader.Rows(dgvPosNow).Item("divisi") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("divisi"))
                                        End If
                                    Else
                                        If Not IsNothing(arrDefValues(8)) Then
                                            arrDefValues(8) = Nothing
                                            myDataTableHeader.Rows(dgvPosNow).Item("divisi") = DBNull.Value
                                        End If
                                    End If
                                    If Not IsDBNull(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) Then
                                        If (arrDefValues(9) <> DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen")) Then
                                            arrDefValues(9) = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen"))
                                            myDataTableHeader.Rows(dgvPosNow).Item("departemen") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("departemen"))
                                        End If
                                    Else
                                        If Not IsNothing(arrDefValues(9)) Then
                                            arrDefValues(9) = Nothing
                                            myDataTableHeader.Rows(dgvPosNow).Item("departemen") = DBNull.Value
                                        End If
                                    End If
                                End If
                                If (arrDefValues(10) <> Trim(rtbCatatanHeader.Text)) Then
                                    If (Trim(rtbCatatanHeader.Text).Length > 0) Then
                                        arrDefValues(10) = Trim(rtbCatatanHeader.Text)
                                        myDataTableHeader.Rows(dgvPosNow).Item("catatan") = Trim(rtbCatatanHeader.Text)
                                    Else
                                        arrDefValues(10) = Nothing
                                        myDataTableHeader.Rows(dgvPosNow).Item("catatan") = DBNull.Value
                                    End If
                                End If
                                'Update kolom UPDATED_AT
                                myDataTableHeader.Rows(dgvPosNow).Item("updated_at") = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "updated_at", tableNameHeader, "desc", "rid=" & arrDefValues(0), CONN_.dbType)
                            End If
                            If (updatePart(1)) Then
                                'DETAIL
                                For i As Integer = 0 To dgvDetail.RowCount - 1
                                    If (dgvDetail.Rows(i).Cells("new").Value) Then
                                        Dim myRID As Integer
                                        myRID = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameDetail, "desc", "kdr='" & myCStringManipulation.SafeSqlLiteral(dgvDetail.Rows(i).Cells("kdr").Value) & "'", CONN_.dbType)
                                        With myDataTableDGVDetail
                                            Dim newDataTableDetail As DataRow = .NewRow()
                                            newDataTableDetail("rid") = myRID
                                            newDataTableDetail("tanggal") = dgvDetail.Rows(i).Cells("tanggal").Value
                                            newDataTableDetail("no_spl") = Trim(dgvDetail.Rows(i).Cells("nospl").Value)
                                            newDataTableDetail("kdr") = Trim(dgvDetail.Rows(i).Cells("kdr").Value)
                                            newDataTableDetail("idk") = Trim(dgvDetail.Rows(i).Cells("idk").Value)
                                            newDataTableDetail("nip") = Trim(dgvDetail.Rows(i).Cells("nip").Value)
                                            newDataTableDetail("nama") = Trim(dgvDetail.Rows(i).Cells("nama").Value)
                                            newDataTableDetail("bagian") = Trim(dgvDetail.Rows(i).Cells("bagian").Value)
                                            newDataTableDetail("divisi") = Trim(dgvDetail.Rows(i).Cells("divisi").Value)
                                            newDataTableDetail("departemen") = Trim(dgvDetail.Rows(i).Cells("departemen").Value)
                                            newDataTableDetail("perusahaan") = Trim(dgvDetail.Rows(i).Cells("perusahaan").Value)
                                            newDataTableDetail("pekerjaan") = Trim(dgvDetail.Rows(i).Cells("pekerjaan").Value)
                                            newDataTableDetail("jam_lembur") = dgvDetail.Rows(i).Cells("jamlembur").Value
                                            newDataTableDetail("mulai") = dgvDetail.Rows(i).Cells("mulai").Value
                                            newDataTableDetail("selesai") = dgvDetail.Rows(i).Cells("selesai").Value
                                            newDataTableDetail("catatan") = IIf(Trim(dgvDetail.Rows(i).Cells("catatan").Value).Length > 0, Trim(dgvDetail.Rows(i).Cells("catatan").Value), DBNull.Value)
                                            newDataTableDetail("created_at") = created_at
                                            'memasukkan row baru tersebut ke data tabel master barang
                                            .Rows.Add(newDataTableDetail)
                                        End With
                                    ElseIf (dgvDetail.Rows(i).Cells("edited").Value) Then
                                        foundRows = myDataTableDGVDetail.Select("rid=" & dgvDetail.Rows(i).Cells("rid").Value)
                                        myDataTableDGVDetail.Rows(myDataTableDGVDetail.Rows.IndexOf(foundRows(0))).Item("pekerjaan") = Trim(dgvDetail.Rows(i).Cells("pekerjaan").Value)
                                        myDataTableDGVDetail.Rows(myDataTableDGVDetail.Rows.IndexOf(foundRows(0))).Item("jam_lembur") = dgvDetail.Rows(i).Cells("jamlembur").Value
                                        myDataTableDGVDetail.Rows(myDataTableDGVDetail.Rows.IndexOf(foundRows(0))).Item("mulai") = dgvDetail.Rows(i).Cells("mulai").Value
                                        myDataTableDGVDetail.Rows(myDataTableDGVDetail.Rows.IndexOf(foundRows(0))).Item("selesai") = dgvDetail.Rows(i).Cells("selesai").Value
                                        myDataTableDGVDetail.Rows(myDataTableDGVDetail.Rows.IndexOf(foundRows(0))).Item("catatan") = IIf(Trim(dgvDetail.Rows(i).Cells("catatan").Value).Length > 0, Trim(dgvDetail.Rows(i).Cells("catatan").Value), DBNull.Value)
                                        myDataTableDGVDetail.Rows(myDataTableDGVDetail.Rows.IndexOf(foundRows(0))).Item("updated_at") = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "updated_at", tableNameDetail, "desc", "rid=" & dgvDetail.Rows(i).Cells("rid").Value, CONN_.dbType)
                                    End If
                                Next
                            End If
                            If (updatePart(2)) Then
                                'DELETE
                                For i As Integer = 0 To myDataTableToBeDel.Rows.Count - 1
                                    foundRows = myDataTableDGVDetail.Select("rid=" & myDataTableToBeDel.Rows(i).Item("rid"))
                                    If (foundRows.Count > 0) Then
                                        myDataTableDGVDetail.Rows.RemoveAt(myDataTableDGVDetail.Rows.IndexOf(foundRows(0)))
                                    End If
                                Next
                            End If
                            Call myCShowMessage.ShowUpdatedMsg("SPL " & Trim(tbNoSPL.Text))
                            Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Try
            Dim isConfirm As Integer
            isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus SPL " & tbNoSPL.Text & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
            If (isConfirm = 6) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim foundRows As DataRow()
                Dim queryBuilder As New Text.StringBuilder

                queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameHeader, "",, "nospl='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'"))
                queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameDetail, "",, "nospl='" & myCStringManipulation.SafeSqlLiteral(tbNoSPL.Text) & "'"))

                If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                    Call myCShowMessage.ShowDeletedMsg("SPL " & Trim(tbNoSPL.Text))
                    foundRows = myDataTableHeader.Select("rid=" & arrDefValues(0))
                    If (foundRows.Count > 0) Then
                        myDataTableHeader.Rows.RemoveAt(myDataTableHeader.Rows.IndexOf(foundRows(0)))
                    End If
                    myDataTableDGVDetail.Clear()
                    Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
                End If
            Else
                Call myCShowMessage.ShowInfo("Penghapusan SPL " & tbNoSPL.Text & " dibatalkan oleh user")
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

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCetak_Click Error")
        End Try
    End Sub
End Class