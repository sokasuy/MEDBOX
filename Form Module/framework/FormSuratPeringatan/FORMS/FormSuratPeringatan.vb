Public Class FormSuratPeringatan
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
    Private arrDefValues(12) As String
    Private tableName As String
    Private tableNameLog As String

    Private myDataTableCboKaryawan As New DataTable
    Private myBindingKaryawan As New BindingSource
    Private myDataTableCboKepala As New DataTable
    Private myBindingKepala As New BindingSource

    Private isBinding As Boolean
    Private isCboPrepared As Boolean
    Private strJenisSP As String
    Private strKDR As String
    Private digitLength As Integer
    Private enableSubForm(0) As Boolean

    Private Structure fileTempel
        'Dim name As String
        Dim path As String
        Dim extension As String
    End Structure

    Private fileAttachment As fileTempel
    Const STR_MYCOMPUTER_CLSID As String = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"

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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormSuratPeringatan Error")
        End Try
    End Sub

    Private Sub FormSuratPeringatan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormSuratPeringatan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"IDK", "NIP", "NAMA"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT concat(nama,' || ',nip) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian FROM " & CONN_.schemaHRD & ".mskaryawanaktif " & IIf(USER_.lokasi = "ALL", "", "WHERE (lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " GROUP BY concat(nama,' || ',nip),idk,nip,nama,perusahaan,departemen,divisi,bagian ORDER BY karyawan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared)

            stSQL = "SELECT concat(nama,' || ',nip) as karyawan,idk,nip,nama FROM " & CONN_.schemaHRD & ".mskaryawanaktif " & IIf(USER_.lokasi = "ALL", "", "WHERE (lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " GROUP BY concat(nama,' || ',nip),idk,nip,nama ORDER BY karyawan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKepala, myBindingKepala, cboKepala, "T_" & cboKepala.Name, "nip", "karyawan", isCboPrepared)

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

            'ofd1.InitialDirectory = STR_MYCOMPUTER_CLSID
            'ofd1.Title = "Pilih File"
            'ofd1.Multiselect = False

            tableName = CONN_.schemaHRD & ".trsuratperingatan"
            tableNameLog = CONN_.schemaHRD & ".logtrsuratperingatan"
            digitLength = 1

            isDataPrepared = True

            'ATTACHMENT SUDAH DIPINDAH KE DETAILNYA
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormSuratPeringatan_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormSuratPeringatan_KeyDown(sender As Object, e As KeyEventArgs) Handles cboKaryawan.KeyDown, dtpTanggal.KeyDown, cboKepala.KeyDown, tbKesalahan.KeyDown, rtbKeterangan.KeyDown, rtbSanksi.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown, btnBackupDataLama.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is rtbSanksi) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormSuratPeringatan_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    Private Sub SetDGV(myConn As Object, myComm As Object, myReader As Object, offSet As Integer, ByRef myDataTable As DataTable, ByRef myBindingTable As BindingSource, mKriteria As String, Optional gantiKriteria As Boolean = False)
        Try
            Dim batas As Integer
            Dim mJumlah As Integer
            Dim mTableName As String
            Dim mSelectedCriteria As String

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mTableName = IIf(rbAktif.Checked, tableName, tableNameLog)
            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                'Dim tampTotalRecords As Integer
                banyakPages = 0
                mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                stSQL = "SELECT count(*) FROM " & mTableName & " WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%'));"
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

            stSQL = "SELECT rid,kdr,tanggal,idk,nip,nama,bagian,divisi,departemen,perusahaan,idkkepala as idk_kepala,nipkepala as nip_kepala,namakepala as nama_kepala,jenissp as jenis_sp,kesalahan,keterangan,sanksi,spke as sp_ke,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.kdr,sub.tanggal,sub.idk,sub.nip,sub.nama,sub.bagian,sub.divisi,sub.departemen,sub.perusahaan,sub.idkkepala,sub.nipkepala,sub.namakepala,sub.jenissp,sub.kesalahan,sub.keterangan,sub.sanksi,sub.spke,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.kdr,tbl.tanggal,tbl.idk,tbl.nip,tbl.nama,tbl.bagian,tbl.divisi,tbl.departemen,tbl.perusahaan,tbl.idkkepala,tbl.nipkepala,tbl.namakepala,tbl.jenissp,tbl.kesalahan,tbl.keterangan,tbl.sanksi,tbl.spke,tbl.created_at,tbl.updated_at " &
                            "FROM " & mTableName & " as tbl " &
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

            If (rbHistory.Checked) Then
                dgvView.DataSource = Nothing
                dgvView.Columns.Clear()
            End If

            With dgvView
                .DataSource = myBindingTable
                .ReadOnly = True

                .Columns("rid").Visible = False
                .Columns("kdr").Visible = False

                .Columns("rid").Frozen = True
                .Columns("kdr").Frozen = True
                .Columns("tanggal").Frozen = True
                .Columns("idk").Frozen = True
                .Columns("nip").Frozen = True
                .Columns("nama").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("tanggal").Width = 80
                .Columns("nip").Width = 75
                .Columns("nama").Width = 125
                .Columns("bagian").Width = 100
                .Columns("divisi").Width = 100
                .Columns("departemen").Width = 100
                .Columns("perusahaan").Width = 130
                .Columns("idk_kepala").Width = 75
                .Columns("nip_kepala").Width = 75
                .Columns("nama_kepala").Width = 125
                .Columns("jenis_sp").Width = 90
                .Columns("kesalahan").Width = 125
                .Columns("keterangan").Width = 125
                .Columns("sanksi").Width = 125
                .Columns("sp_ke").Width = 60

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

                .Columns("tanggal").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                .Font = New Font("Arial", 9, FontStyle.Regular)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End With

            If (rbAktif.Checked) Then
                'Kalau menampilkan data aktif
                With cmbDgvEditButton
                    If Not (cekTambahButton(0)) Then
                        .HeaderText = "EDIT"
                        .Name = "edit"
                        .Text = "Edit"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = dgvView.Columns("nama").Index + 1
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
            Else
                'Kalau menampilkan data history
                For i As Integer = 0 To cekTambahButton.Count - 1
                    cekTambahButton(i) = False
                Next
            End If

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
            dtpTanggal.Enabled = True

            'lnklblAttachment.Text = "Attachment"
            'lnklblAttachment.Visible = False

            'fileAttachment.name = Nothing
            'fileAttachment.path = Nothing
            'fileAttachment.extension = Nothing
            'lnklblAttachment.Text = "Attachment"
            'lnklblAttachment.Visible = False

            isBinding = False
            tbPerusahaan.DataBindings.Clear()
            tbDepartemen.DataBindings.Clear()
            tbDivisi.DataBindings.Clear()
            tbBagian.DataBindings.Clear()

            If (cboKaryawan.SelectedIndex <> -1) Then
                'Sebelumnya backup dulu kalau misalkan datanya adalah data lama
                Call ProsesSuratPeringatanLama(sender, e, CONN_.dbMain, CONN_.comm, CONN_.reader, CONN_.dbType, cboKaryawan.SelectedValue)

                'Buat ambil KDR
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "kdr", "rid", dtpTanggal.Value.Date, cboKaryawan.SelectedValue, digitLength, CONN_.dbType).ToUpper

                'Buat Ambil SP Ke
                tbSPKe.Text = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "spke", tableName,, "nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", CONN_.dbType) + 1
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
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
            If (dgvView.RowCount > 0 And rbAktif.Checked) Then
                If (e.RowIndex = -1) Then
                    Exit Sub
                End If

                If (e.ColumnIndex = dgvView.Columns("delete").Index) Then
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus surat peringatan karyawan " & dgvView.CurrentRow.Cells("nama").Value & " di tanggal " & dgvView.CurrentRow.Cells("tanggal").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = DialogResult.Yes) Then
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName, "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                        Call myCShowMessage.ShowDeletedMsg("Surat peringatan karyawan " & dgvView.CurrentRow.Cells("nama").Value & " di tanggal " & dgvView.CurrentRow.Cells("tanggal").Value)
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan surat peringatan karyawan " & dgvView.CurrentRow.Cells("nama").Value & " di tanggal " & dgvView.CurrentRow.Cells("tanggal").Value & " dibatalkan oleh user")
                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("attachment").Index) Then
                    Dim frmAttachmentKaryawan As New FormAttachmentKaryawan.FormAttachmentKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, dgvView.CurrentRow.Cells("idk").Value, dgvView.CurrentRow.Cells("nama").Value, dgvView.CurrentRow.Cells("nip").Value)
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
                    'INI TIDAK BOLEH DI EDIT
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nip").Value) Then
                        For i As Integer = 0 To cboKaryawan.Items.Count - 1
                            If (DirectCast(cboKaryawan.Items(i), DataRowView).Item("nip") = dgvView.CurrentRow.Cells("nip").Value) Then
                                cboKaryawan.SelectedIndex = i
                                arrDefValues(1) = dgvView.CurrentRow.Cells("idk").Value
                                arrDefValues(2) = dgvView.CurrentRow.Cells("nip").Value
                                arrDefValues(3) = dgvView.CurrentRow.Cells("nama").Value
                            End If
                        Next
                        cboKaryawan.Enabled = False
                    End If
                    'Perusahaan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("perusahaan").Value) Then
                        tbPerusahaan.Text = dgvView.CurrentRow.Cells("perusahaan").Value
                    End If
                    'Departemen
                    If Not IsDBNull(dgvView.CurrentRow.Cells("departemen").Value) Then
                        tbDepartemen.Text = dgvView.CurrentRow.Cells("departemen").Value
                    End If
                    'Divisi
                    If Not IsDBNull(dgvView.CurrentRow.Cells("divisi").Value) Then
                        tbDivisi.Text = dgvView.CurrentRow.Cells("divisi").Value
                    End If
                    'Bagian
                    If Not IsDBNull(dgvView.CurrentRow.Cells("bagian").Value) Then
                        tbBagian.Text = dgvView.CurrentRow.Cells("bagian").Value
                    End If
                    'Tanggal
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal").Value) Then
                        'tanggal juga tidak boleh di edit
                        dtpTanggal.Value = dgvView.CurrentRow.Cells("tanggal").Value
                        arrDefValues(4) = dgvView.CurrentRow.Cells("tanggal").Value
                        dtpTanggal.Enabled = False
                    End If
                    'Kepala
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nip").Value) Then
                        For i As Integer = 0 To cboKepala.Items.Count - 1
                            If (DirectCast(cboKepala.Items(i), DataRowView).Item("idk") = dgvView.CurrentRow.Cells("idk_kepala").Value) Then
                                cboKepala.SelectedIndex = i
                                arrDefValues(5) = dgvView.CurrentRow.Cells("idk_kepala").Value
                                arrDefValues(6) = dgvView.CurrentRow.Cells("nip_kepala").Value
                                arrDefValues(7) = dgvView.CurrentRow.Cells("nama_kepala").Value
                            End If
                        Next
                        cboKaryawan.Enabled = False
                    End If
                    'Jenis SP
                    If Not IsDBNull(dgvView.CurrentRow.Cells("jenis_sp").Value) Then
                        If (dgvView.CurrentRow.Cells("jenis_sp").Value = "Lisan") Then
                            rbLisan.Checked = True
                        ElseIf (dgvView.CurrentRow.Cells("jenis_sp").Value = "Tertulis") Then
                            rbTertulis.Checked = True
                        End If
                        arrDefValues(8) = dgvView.CurrentRow.Cells("jenis_sp").Value
                        strJenisSP = dgvView.CurrentRow.Cells("jenis_sp").Value
                    End If
                    'SP Ke
                    If Not IsDBNull(dgvView.CurrentRow.Cells("sp_ke").Value) Then
                        tbSPKe.Text = dgvView.CurrentRow.Cells("sp_ke").Value
                        arrDefValues(9) = dgvView.CurrentRow.Cells("sp_ke").Value
                    End If
                    'Kesalahan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("kesalahan").Value) Then
                        tbKesalahan.Text = dgvView.CurrentRow.Cells("kesalahan").Value
                        arrDefValues(10) = dgvView.CurrentRow.Cells("kesalahan").Value
                    End If
                    'Keterangan SP
                    If Not IsDBNull(dgvView.CurrentRow.Cells("keterangan").Value) Then
                        rtbKeterangan.Text = dgvView.CurrentRow.Cells("keterangan").Value
                        arrDefValues(11) = dgvView.CurrentRow.Cells("keterangan").Value
                    End If
                    'Sanksi
                    If Not IsDBNull(dgvView.CurrentRow.Cells("sanksi").Value) Then
                        rtbSanksi.Text = dgvView.CurrentRow.Cells("sanksi").Value
                        arrDefValues(12) = dgvView.CurrentRow.Cells("sanksi").Value
                    End If
                    ''PathToAttachment
                    'If Not IsDBNull(dgvView.CurrentRow.Cells("path_to_attachment").Value) Then
                    '    'SUDAH DIPINDAH KE DETAILNYA
                    '    fileAttachment.path = dgvView.CurrentRow.Cells("path_to_attachment").Value
                    '    fileAttachment.extension = fileAttachment.path.Substring(fileAttachment.path.LastIndexOf("."))
                    '    'tbNamaFile.Text = dgvView.CurrentRow.Cells("path_to_attachment").Value
                    '    'lnklblAttachment.Text = dgvView.CurrentRow.Cells("path_to_attachment").Value
                    '    'lnklblAttachment.Visible = True
                    '    arrDefValues(13) = dgvView.CurrentRow.Cells("path_to_attachment").Value

                    'Else
                    '    fileAttachment.path = Nothing
                    '    fileAttachment.extension = Nothing
                    '    'tbNamaFile.Clear()
                    '    'lnklblAttachment.Text = "Attachment"
                    '    'lnklblAttachment.Visible = False
                    'End If

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
            If (cboKaryawan.SelectedIndex <> -1 And cboKepala.SelectedIndex <> -1 And Trim(tbKesalahan.Text).Length > 0) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                'Dim created_at As Date
                'created_at = Now
                'ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                If isNew Then
                    'CREATE NEW
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "kdr='" & myCStringManipulation.SafeSqlLiteral(strKDR) & "'")
                    If Not isExist Then
                        'CREATE NEW
                        newValues = "'" & strKDR & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("idk")) & "','" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & "','" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(tbPerusahaan.Text) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk")) & "','" & myCStringManipulation.SafeSqlLiteral(cboKepala.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama")) & "','" & myCStringManipulation.SafeSqlLiteral(strJenisSP) & "','" & myCStringManipulation.SafeSqlLiteral(tbKesalahan.Text) & "'," & tbSPKe.Text & "," & ADD_INFO_.newValues
                        newFields = "kdr,idk,nip,nama,tanggal,perusahaan,idkkepala,nipkepala,namakepala,jenissp,kesalahan,spke," & ADD_INFO_.newFields
                        If Trim(tbDepartemen.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbDepartemen.Text) & "'"
                            newFields &= ",departemen"
                        End If
                        If Trim(tbDivisi.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbDivisi.Text) & "'"
                            newFields &= ",divisi"
                        End If
                        If Trim(tbBagian.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbBagian.Text) & "'"
                            newFields &= ",bagian"
                        End If
                        If Trim(rtbKeterangan.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(rtbKeterangan.Text) & "'"
                            newFields &= ",keterangan"
                        End If
                        If Trim(rtbSanksi.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(rtbSanksi.Text) & "'"
                            newFields &= ",sanksi"
                        End If
                        If Not IsNothing(fileAttachment.path) Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(fileAttachment.path) & "'"
                            newFields &= ",pathtoattachment"
                        End If
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName, newValues, newFields)
                        Call myCShowMessage.ShowSavedMsg("Surat peringatan karyawan " & Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di tanggal " & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy"))
                        Call btnTampilkan_Click(sender, e)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowWarning("Kalau ada karyawan yang terkena SP 2x dalam 1 hari, dijadikan 1 saja" & ControlChars.NewLine & "Silahkan edit data yang sudah ada!")
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    updateString = Nothing
                    foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    'If (arrDefValues(2) <> DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) Then
                    '    'Seharusnya nama tidak boleh di update, karena buat melakukan pengecekan apabila sampai terjadi kesalahan karena keliru input nama di data karyawan
                    '    'Sementara di comment dulu PER 12 NOVEMBER 2021
                    '    updateString = "nama='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & "'"
                    '    If (foundRows.Length > 0) Then
                    '        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama") = Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama"))
                    '    End If
                    'End If
                    If (arrDefValues(4) <> dtpTanggal.Value.Date) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tanggal='" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal") = dtpTanggal.Value.Date
                        End If
                    End If
                    If (arrDefValues(5) <> cboKepala.SelectedValue) Then
                        updateString = "idkkepala='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk")) & "',nipkepala='" & myCStringManipulation.SafeSqlLiteral(cboKepala.SelectedValue) & "',namakepala='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama")) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("idk_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("idk"))
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nip_kepala") = Trim(cboKepala.SelectedValue)
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama_kepala") = Trim(DirectCast(cboKepala.SelectedItem, DataRowView).Item("nama"))
                        End If
                    End If
                    If (arrDefValues(8) <> strJenisSP) Then
                        updateString = "jenissp='" & myCStringManipulation.SafeSqlLiteral(strJenisSP) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("jenis_sp") = Trim(strJenisSP)
                        End If
                    End If
                    If (arrDefValues(9) <> Trim(tbSPKe.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "spke='" & myCStringManipulation.SafeSqlLiteral(tbSPKe.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("sp_ke") = Trim(tbSPKe.Text)
                        End If
                    End If
                    If (arrDefValues(10) <> Trim(tbKesalahan.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "kesalahan='" & myCStringManipulation.SafeSqlLiteral(tbKesalahan.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kesalahan") = Trim(tbKesalahan.Text)
                        End If
                    End If
                    If (arrDefValues(11) <> Trim(rtbKeterangan.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "keterangan=" & IIf(Trim(rtbKeterangan.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(rtbKeterangan.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("keterangan") = Trim(rtbKeterangan.Text)
                        End If
                    End If
                    If (arrDefValues(12) <> Trim(rtbSanksi.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "sanksi=" & IIf(Trim(rtbSanksi.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(rtbSanksi.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("sanksi") = Trim(rtbSanksi.Text)
                        End If
                    End If
                    'If (arrDefValues(13) <> Trim(fileAttachment.path)) Then
                    '    updateString &= IIf(IsNothing(updateString), "", ",") & "pathtoattachment='" & myCStringManipulation.SafeSqlLiteral(fileAttachment.path) & "'"
                    '    If (foundRows.Length > 0) Then
                    '        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("path_to_attachment") = Trim(fileAttachment.path)
                    '    End If
                    'End If

                    If Not IsNothing(updateString) Then
                        updateString &= "," & ADD_INFO_.updateString
                        'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName, CONN_.dbType)
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, updateString, "rid=" & arrDefValues(0))
                        Call myCShowMessage.ShowUpdatedMsg("Surat peringatan karyawan " & Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di tanggal " & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy"))

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "save")
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                cboKaryawan.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub rbJenisSP_CheckedChanged(sender As Object, e As EventArgs) Handles rbLisan.CheckedChanged, rbTertulis.CheckedChanged
        Try
            strJenisSP = sender.text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbJenisSP_CheckedChanged Error")
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboKaryawan.Validated, cboKepala.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
                If (sender Is cboKaryawan) Then
                    tbSPKe.Clear()
                    tbPerusahaan.Clear()
                    tbDepartemen.Clear()
                    tbDivisi.Clear()
                    tbBagian.Clear()
                    strKDR = Nothing
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub cboKaryawan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKaryawan.SelectedIndexChanged
        Try
            If isNew Then
                If (isDataPrepared) Then
                    If (cboKaryawan.SelectedIndex <> -1) Then
                        'Buat binding data
                        If Not (isBinding) Then
                            tbPerusahaan.DataBindings.Add(New Binding("text", myBindingKaryawan, "perusahaan"))
                            tbDepartemen.DataBindings.Add(New Binding("text", myBindingKaryawan, "departemen"))
                            tbDivisi.DataBindings.Add(New Binding("text", myBindingKaryawan, "divisi"))
                            tbBagian.DataBindings.Add(New Binding("text", myBindingKaryawan, "bagian"))
                            isBinding = True
                        End If

                        'Sebelumnya backup dulu kalau misalkan datanya adalah data lama
                        Call ProsesSuratPeringatanLama(sender, e, CONN_.dbMain, CONN_.comm, CONN_.reader, CONN_.dbType, cboKaryawan.SelectedValue)

                        'Buat ambil KDR
                        Call myCDBConnection.OpenConn(CONN_.dbMain)
                        strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "kdr", "rid", dtpTanggal.Value.Date, cboKaryawan.SelectedValue, digitLength, CONN_.dbType).ToUpper

                        'Buat Ambil SP Ke
                        tbSPKe.Text = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "spke", tableName,, "nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", CONN_.dbType) + 1
                        Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub dtpTanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtpTanggal.ValueChanged
        Try
            If isNew Then
                If (isDataPrepared) Then
                    If (cboKaryawan.SelectedIndex <> -1) Then
                        Call myCDBConnection.OpenConn(CONN_.dbMain)
                        strKDR = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "kdr", "rid", dtpTanggal.Value.Date, cboKaryawan.SelectedValue, digitLength, CONN_.dbType).ToUpper
                        Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpTanggal_ValueChanged Error")
        End Try
    End Sub

    'Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
    '    'OK
    '    Try
    '        'ofd1.Filter = "Microsoft Excel 97-2003 (*.xls)|*.xls|Microsoft Excel 2007-2013 (*.xlsx)|*.xlsx|PDF Files (*.pdf)|Text Document (*.txt)"
    '        ofd1.Filter = myCFileIO.SetFilterForAttachment("all")
    '        'ofd1.Filter = "All Supported File|*.xls;*.xlsx;*.docx;*.doc;*.pdf;*.txt|Excel file (*.xls,*.xlsx)|*.xls;*.xlsx|Word file (*.doc,*.docx)|*.doc;*.docx|PDF file (*.pdf)|*.pdf|Normal text file (*.txt)|*.txt|Image file (*.jpeg,*.jpg,*.png)|*.jpeg;*.jpg;*.png"
    '        ofd1.FilterIndex = 1
    '        ofd1.ShowDialog()
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBrowse_Click Error")
    '    End Try
    'End Sub

    'Private Sub tbNamaFile_Click(sender As Object, e As EventArgs) Handles tbNamaFile.Click
    '    'OK
    '    Try
    '        'ofd1.InitialDirectory = Application.StartupPath
    '        ofd1.Filter = myCFileIO.SetFilterForAttachment("all")
    '        'ofd1.Filter = "All Supported File|*.xls;*.xlsx;*.docx;*.doc;*.pdf;*.txt|Excel file (*.xls,*.xlsx)|*.xls;*.xlsx|Word file (*.doc,*.docx)|*.doc;*.docx|PDF file (*.pdf)|*.pdf|Normal text file (*.txt)|*.txt|Image file (*.jpeg,*.jpg,*.png)|*.jpeg;*.jpg;*.png"
    '        ofd1.FilterIndex = 1
    '        ofd1.ShowDialog()
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNamaFile_Click Error")
    '    End Try
    'End Sub

    'Private Sub ofd1_FileOk(ByVal sender As Object, ByVal e As ComponentModel.CancelEventArgs) Handles ofd1.FileOk
    '    Try
    '        tbNamaFile.Text = ofd1.SafeFileName
    '        fileAttachment.path = ofd1.FileName
    '        'fileAttachment.name = ofd1.SafeFileName
    '        fileAttachment.extension = ofd1.SafeFileName.Substring(ofd1.SafeFileName.LastIndexOf("."))
    '        lnklblAttachment.Text = fileAttachment.path
    '        lnklblAttachment.Visible = True
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ofd1_FileOk Error")
    '    End Try
    'End Sub

    'Private Sub lnklblAttachment_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblAttachment.LinkClicked
    '    Try
    '        Dim processInfo As ProcessStartInfo = New ProcessStartInfo()
    '        'Dim namaFile As String
    '        'Process.StartInfo.FileName = lnklblAttachment.Text
    '        'Diagnostics.Process.Start("" & lnklblAttachment.Text & "")
    '        'Process.Start("notepad.exe", "/select," + "G:\coba.txt")

    '        'Diagnostics.Process.Start(lnklblAttachment.Text)
    '        'Dim proses As Process = New Process { StartInfo = New ProcessStartInfo(lnklblAttachment.Text) { UseShellExecute = True } }.Start()
    '        'New Process { StartInfo = New ProcessStartInfo(fileName) { UseShellExecute = true } }.Start()

    '        'MsgBox(fileAttachment.extension)
    '        'processInfo.Arguments = "\"" + lnklblAttachment.Text + " \ ""
    '        'processInfo.Arguments = lnklblAttachment.Text

    '        'namaFile = """" & lnklblAttachment.Text & """"

    '        processInfo = myCFileIO.SetProcessInfo(processInfo, fileAttachment.extension, fileAttachment.path)

    '        'processInfo.Arguments = namaFile
    '        'processInfo.UseShellExecute = True
    '        'processInfo.Verb = "open"

    '        'If (fileAttachment.extension = ".txt") Then
    '        '    'Process.Start("notepad", lnklblAttachment.Text)
    '        '    processInfo.FileName = "notepad"
    '        'ElseIf (fileAttachment.extension = ".pdf") Then
    '        '    'processInfo.FileName = "C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe"
    '        '    'processInfo.FileName = "msedge"
    '        '    processInfo.FileName = "acrobat"
    '        '    'Process.Start("C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe", "\"" + lnklblAttachment.Text + " \ "")
    '        '    'processInfo.FileName = "@" & lnklblAttachment.Text
    '        'ElseIf (fileAttachment.extension = ".xls" Or fileAttachment.extension = ".xlsx") Then
    '        '    processInfo.FileName = "excel"
    '        'ElseIf (fileAttachment.extension = ".doc" Or fileAttachment.extension = ".docx") Then
    '        '    processInfo.FileName = "winword"
    '        'ElseIf (fileAttachment.extension = ".doc" Or fileAttachment.extension = ".docx") Then
    '        '    processInfo.FileName = "winword"
    '        'End If
    '        Dim myProcess As Process = Process.Start(processInfo)
    '        'Dim myProcess As Process = Process.Start("""" & fileAttachment.path & """")

    '        'HARUS DITUTUP UNTUK MELEPAS RESOURCES NYA
    '        'myProcess.CloseMainWindow()
    '        'myProcess.Close()
    '        'If Not (myProcess.HasExited) Then
    '        '    myProcess.Kill()
    '        'End If
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "lnklblAttachment_LinkClicked Error")
    '    End Try
    'End Sub

    Private Sub rbPilihanData_CheckedChanged(sender As Object, e As EventArgs) Handles rbAktif.CheckedChanged, rbHistory.CheckedChanged
        Try
            'If (rbAktif.Checked) Then
            '    lblPilihanData.Text = "DATA AKTIF"
            '    'viewPilihanData = "AKTIF"
            '    gbDataEntry.Enabled = True
            '    btnCreateNew.Enabled = True
            '    btnBackupDataLama.Visible = True
            'ElseIf (rbHistory.Checked) Then
            '    lblPilihanData.Text = "DATA HISTORY"
            '    'viewPilihanData = "HISTORY"
            '    gbDataEntry.Enabled = False
            '    btnCreateNew.Enabled = False
            '    btnBackupDataLama.Visible = False
            'End If
            lblPilihanData.Text = "DATA " & sender.text.toupper
            gbDataEntry.Enabled = rbAktif.Checked
            btnCreateNew.Enabled = rbAktif.Checked
            btnBackupDataLama.Visible = rbAktif.Checked

            myDataTableDGV.Clear()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbPilihanData_CheckedChanged Error")
        End Try
    End Sub

    Private Sub btnBackupDataLama_Click(sender As Object, e As EventArgs) Handles btnBackupDataLama.Click
        Try
            Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau memproses SP yang sudah melewati periode resetnya untuk dipindah ke data history?")
            If (isConfirm = DialogResult.Yes) Then
                Call ProsesSuratPeringatanLama(sender, e, CONN_.dbMain, CONN_.comm, CONN_.reader, CONN_.dbType)
            Else
                Call myCShowMessage.ShowInfo("Proses SP lama dibatalkan!!")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBackupDataLama_Click Error")
        End Try
    End Sub

    Private Sub ProsesSuratPeringatanLama(sender As Object, e As EventArgs, _conn As Object, _comm As Object, _reader As Object, _type As String, Optional _nip As String = Nothing)
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(_conn)

            Dim myDataTableSP As New DataTable
            Dim myDataTableKaryawanAktif As New DataTable
            Dim foundRows() As DataRow
            Dim dataTerbackup As Integer = 0

            Dim myDataTableSPLama As New DataTable

            If IsNothing(_nip) Then
                stSQL = "SELECT k.nip,k.hariresetsp FROM " & tableName & " as p inner join " & CONN_.schemaHRD & ".mskaryawanaktif as k ON k.nip=p.nip GROUP BY k.nip,k.hariresetsp ORDER BY k.nip;"
            Else
                stSQL = "SELECT k.nip,k.hariresetsp FROM " & tableName & " as p inner join " & CONN_.schemaHRD & ".mskaryawanaktif as k ON k.nip=p.nip WHERE k.nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' GROUP BY k.nip,k.hariresetsp ORDER BY k.nip;"
            End If
            myDataTableKaryawanAktif = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_KaryawanAktif")
            myDataTableKaryawanAktif.Columns.Add("tanggalawalsp", GetType(Date))
            myDataTableKaryawanAktif.Columns.Add("tanggalakhirsp", GetType(Date))

            If IsNothing(_nip) Then
                stSQL = "select nip,min(tanggal) as tanggalawalsp FROM " & tableName & " GROUP BY nip ORDER BY nip,tanggalawalsp;"
            Else
                stSQL = "select nip,min(tanggal) as tanggalawalsp FROM " & tableName & " WHERE nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' GROUP BY nip ORDER BY nip,tanggalawalsp;"
            End If

            myDataTableSP = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_DataSP")

            For i As Integer = 0 To myDataTableKaryawanAktif.Rows.Count - 1
                foundRows = myDataTableSP.Select("nip='" & myDataTableKaryawanAktif.Rows(i).Item("nip") & "'")
                myDataTableKaryawanAktif.Rows(i).Item("tanggalawalsp") = myDataTableSP.Rows(myDataTableSP.Rows.IndexOf(foundRows(0))).Item("tanggalawalsp")
                myDataTableKaryawanAktif.Rows(i).Item("tanggalakhirsp") = myDataTableKaryawanAktif.Rows(i).Item("tanggalawalsp").addDays(myDataTableKaryawanAktif.Rows(i).Item("hariresetsp"))

                If (myDataTableKaryawanAktif.Rows(i).Item("tanggalakhirsp") < Now.Date) Then
                    'MsgBox(myDataTableKaryawanAktif.Rows(i).Item("tanggalakhirsp"))
                    'Jika ada karyawan yang SP nya sudah lewat dari masa kadaluarsa, maka di backup semua 1 periode!
                    stSQL = "SELECT * FROM " & tableName & " WHERE nip='" & myCStringManipulation.SafeSqlLiteral(myDataTableKaryawanAktif.Rows(i).Item("nip")) & "';"
                    myDataTableSPLama = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_DataSPLama")
                    myDataTableSPLama.Columns.Remove("rid")
                    'Untuk insert ke logtrsuratperingatan
                    Call myCDBOperation.ConstructorInsertData(_conn, _comm, _reader, myDataTableSPLama, tableNameLog)
                    Call myCDBOperation.DelDbRecords(_conn, _comm, tableName, "nip='" & myCStringManipulation.SafeSqlLiteral(myDataTableKaryawanAktif.Rows(i).Item("nip")) & "'", _type)

                    dataTerbackup += 1
                End If
            Next

            If IsNothing(_nip) Then
                If (dataTerbackup > 0) Then
                    Call myCShowMessage.ShowInfo("Proses backup SP lama selesai !!" & ControlChars.NewLine & "SP dari " & dataTerbackup & " karyawan telah dibackup")
                    Call btnTampilkan_Click(sender, e)
                Else
                    Call myCShowMessage.ShowInfo("Tidak ada data SP yang perlu dibackup")
                End If
            Else
                If (dataTerbackup > 0) Then
                    Call btnTampilkan_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ProsesSuratPeringatanLama Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(_conn, -1)
        End Try
    End Sub
End Class
