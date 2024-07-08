Public Class FormMasterSkemaPresensi
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
    Private arrDefValues(16) As String
    Private tableName As String

    Private myDataTableCboLokasi As New DataTable
    Private myBindingLokasi As New BindingSource
    Private myDataTableCboPerusahaan As New DataTable
    Private myBindingPerusahaan As New BindingSource
    Private myDataTableCboDepartemen As New DataTable
    Private myBindingDepartemen As New BindingSource
    Private myDataTableCboKetGroup As New DataTable
    Private myBindingKetGroup As New BindingSource
    Private myDataTableCboKaryawan As New DataTable
    Private myBindingKaryawan As New BindingSource
    Private myDataTableCboJabatan As New DataTable
    Private myBindingJabatan As New BindingSource

    Private isCboPrepared As Boolean
    Private strWaktuShift As String

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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterSkemaPresensi Error")
        End Try
    End Sub

    Private Sub FormMasterSkemaPresensi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormMasterSkemaPresensi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            If (USER_.lokasi = "ALL") Then
                arrCbo = {"LOKASI", "PERUSAHAAN", "DEPARTEMEN", "GRUP", "KET GRUP", "HARI", "NIP", "NAMA"}
            Else
                arrCbo = {"PERUSAHAAN", "DEPARTEMEN", "GRUP", "KET GRUP", "HARI", "NIP", "NAMA"}
            End If
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            arrCbo = {"DIVISI", "BAGIAN"}
            cboGrup.Items.AddRange(arrCbo)
            cboGrup.SelectedIndex = 0

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='lokasi' " & IIf(USER_.lokasi = "ALL", "", "AND keterangan='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "'") & " order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboLokasi, myBindingLokasi, cboLokasi, "T_" & cboLokasi.Name, "keterangan", "keterangan", isCboPrepared)
            cboLokasi.SelectedIndex = 0

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='perusahaan' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPerusahaan, myBindingPerusahaan, cboPerusahaan, "T_" & cboPerusahaan.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='posisi' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboJabatan, myBindingJabatan, cboJabatan, "T_" & cboJabatan.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT concat(nama,' || ',nip) as karyawan,idk,nip,nama FROM " & CONN_.schemaHRD & ".mskaryawanaktif " & IIf(USER_.lokasi = "ALL", "", "WHERE (lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " GROUP BY concat(nama,' || ',nip),idk,nip,nama ORDER BY karyawan;"
            'stSQL = "SELECT concat(tbl.nama,' || ',tbl.nip) as karyawan,tbl.idk,tbl.nip,tbl.nama FROM " & CONN_.schemaHRD & ".mskaryawanaktif as tbl " & IIf(USER_.lokasi = "ALL", "", "WHERE (tbl.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " GROUP BY concat(tbl.nama,' || ',tbl.nip),tbl.idk,tbl.nip,tbl.nama ORDER BY karyawan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='departemen' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboDepartemen, myBindingDepartemen, cboDepartemen, "T_" & cboDepartemen.Name, "keterangan", "keterangan", isCboPrepared)

            arrCbo = {"SENIN", "SELASA", "RABU", "KAMIS", "JUMAT", "SABTU", "MINGGU"}
            cboHari.Items.AddRange(arrCbo)
            cboHari.SelectedIndex = 0

            If (USER_.lokasi.ToUpper = "PANDAAN") Then
                tbJamMasuk.Text = "07:30"
                tbJamKeluar.Text = "16:00"
            Else
                tbJamMasuk.Text = "08:00"
                tbJamKeluar.Text = "17:00"
            End If

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "load")

            tableName = CONN_.schemaHRD & ".msskemapresensi"

            isDataPrepared = True
            rbPagi.Checked = True
            rbUmum.Checked = True
            'cbSpesifik.Checked = False
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterSkemaPresensi_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormMasterSkemaPresensi_KeyDown(sender As Object, e As KeyEventArgs) Handles cboLokasi.KeyDown, cboPerusahaan.KeyDown, cboKetGrup.KeyDown, cboKaryawan.KeyDown, cboHari.KeyDown, tbJamMasuk.KeyDown, tbJamKeluar.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbJamKeluar) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterSkemaPresensi_KeyDown Error")
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

                stSQL = "SELECT count(*) FROM " & tableName & " WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & IIf(USER_.lokasi = "ALL", "", "AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & ";"
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

            stSQL = "SELECT rid,lokasi,perusahaan,umum,departemen,grup,ketgrup as ket_grup,posisi,hari,waktushift as waktu_shift,kodewaktushift as kode_waktu_shift,jammasuk as jam_masuk,jamkeluar as jam_keluar,maxtoleransi as max_toleransi,spesifik,nip,nama,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.lokasi,sub.perusahaan,sub.departemen,sub.umum,sub.grup,sub.ketgrup,sub.posisi,sub.spesifik,sub.nip,sub.nama,sub.hari,sub.waktushift,sub.kodewaktushift,sub.jammasuk,sub.jamkeluar,sub.maxtoleransi,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.lokasi,tbl.perusahaan,tbl.departemen,tbl.umum,tbl.grup,tbl.ketgrup,tbl.posisi,tbl.spesifik,tbl.nip,tbl.nama,tbl.hari,tbl.waktushift,tbl.kodewaktushift,tbl.jammasuk,tbl.jamkeluar,tbl.maxtoleransi,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName & " as tbl " &
                            "WHERE ((upper(" & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & IIf(USER_.lokasi = "ALL", "", "AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & " " &
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
                .Columns("kode_waktu_shift").Visible = False

                .Columns("rid").Frozen = True
                .Columns("lokasi").Frozen = True
                .Columns("perusahaan").Frozen = True
                .Columns("umum").Frozen = True
                .Columns("departemen").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("lokasi").Width = 70
                .Columns("perusahaan").Width = 130
                .Columns("departemen").Width = 100
                .Columns("umum").Width = 60
                .Columns("grup").Width = 80
                .Columns("ket_grup").Width = 100
                .Columns("posisi").Width = 100
                .Columns("waktu_shift").Width = 80
                .Columns("kode_waktu_shift").Width = 50
                .Columns("jam_masuk").Width = 60
                .Columns("jam_keluar").Width = 60
                .Columns("max_toleransi").Width = 60
                .Columns("spesifik").Width = 60
                .Columns("nip").Width = 60
                .Columns("nama").Width = 100

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

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
                    .DisplayIndex = dgvView.Columns("departemen").Index + 1
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
            cboLokasi.SelectedIndex = 0
            isDataPrepared = True
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

                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data skema presensi di hari " & dgvView.CurrentRow.Cells("hari").Value & " untuk " & IIf(dgvView.CurrentRow.Cells("umum").Value, dgvView.CurrentRow.Cells("grup").Value & " " & dgvView.CurrentRow.Cells("ket_grup").Value, "karyawan " & dgvView.CurrentRow.Cells("nama").Value) & " di " & dgvView.CurrentRow.Cells("perusahaan").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = DialogResult.Yes) Then
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName, "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                        Call myCShowMessage.ShowDeletedMsg("Data skema presensi di hari " & dgvView.CurrentRow.Cells("hari").Value & " untuk " & IIf(dgvView.CurrentRow.Cells("umum").Value, dgvView.CurrentRow.Cells("grup").Value & " " & dgvView.CurrentRow.Cells("ket_grup").Value, " karyawan " & dgvView.CurrentRow.Cells("nama").Value) & " di " & dgvView.CurrentRow.Cells("perusahaan").Value)
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True)
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan data skema presensi di hari " & dgvView.CurrentRow.Cells("hari").Value & " untuk " & IIf(dgvView.CurrentRow.Cells("umum").Value, dgvView.CurrentRow.Cells("grup").Value & " " & dgvView.CurrentRow.Cells("ket_grup").Value, " karyawan " & dgvView.CurrentRow.Cells("nama").Value) & " di " & dgvView.CurrentRow.Cells("perusahaan").Value & " dibatalkan oleh user")
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
                    'Lokasi
                    If Not IsDBNull(dgvView.CurrentRow.Cells("lokasi").Value) Then
                        For i As Integer = 0 To cboLokasi.Items.Count - 1
                            If (DirectCast(cboLokasi.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("lokasi").Value) Then
                                cboLokasi.SelectedIndex = i
                                arrDefValues(1) = dgvView.CurrentRow.Cells("lokasi").Value
                            End If
                        Next
                        'cboLokasi.Enabled = False
                    End If
                    'Perusahaan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("perusahaan").Value) Then
                        For i As Integer = 0 To cboPerusahaan.Items.Count - 1
                            If (DirectCast(cboPerusahaan.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("perusahaan").Value) Then
                                cboPerusahaan.SelectedIndex = i
                                arrDefValues(2) = dgvView.CurrentRow.Cells("perusahaan").Value
                            End If
                        Next
                    End If
                    'Departemen
                    If Not IsDBNull(dgvView.CurrentRow.Cells("perusahaan").Value) Then
                        For i As Integer = 0 To cboDepartemen.Items.Count - 1
                            If (DirectCast(cboDepartemen.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("departemen").Value) Then
                                cboDepartemen.SelectedIndex = i
                                arrDefValues(15) = dgvView.CurrentRow.Cells("departemen").Value
                            End If
                        Next
                    End If
                    'Umum
                    rbUmum.Checked = dgvView.CurrentRow.Cells("umum").Value
                    arrDefValues(3) = dgvView.CurrentRow.Cells("umum").Value
                    'Spesifik
                    rbSpesifik.Checked = dgvView.CurrentRow.Cells("spesifik").Value
                    arrDefValues(4) = dgvView.CurrentRow.Cells("spesifik").Value
                    If (rbUmum.Checked) Then
                        'UMUM
                        'Grup
                        If Not IsDBNull(dgvView.CurrentRow.Cells("grup").Value) Then
                            cboGrup.SelectedItem = dgvView.CurrentRow.Cells("grup").Value
                            arrDefValues(5) = dgvView.CurrentRow.Cells("grup").Value
                        End If
                        'KetGrup
                        If Not IsDBNull(dgvView.CurrentRow.Cells("ket_grup").Value) Then
                            For i As Integer = 0 To cboKetGrup.Items.Count - 1
                                If (DirectCast(cboKetGrup.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("ket_grup").Value) Then
                                    cboKetGrup.SelectedIndex = i
                                    arrDefValues(6) = dgvView.CurrentRow.Cells("ket_grup").Value
                                End If
                            Next
                        End If
                        'Jabatan
                        If Not IsDBNull(dgvView.CurrentRow.Cells("posisi").Value) Then
                            For i As Integer = 0 To cboJabatan.Items.Count - 1
                                If (DirectCast(cboJabatan.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("posisi").Value) Then
                                    cboJabatan.SelectedIndex = i
                                    arrDefValues(7) = dgvView.CurrentRow.Cells("posisi").Value
                                End If
                            Next
                        End If
                    ElseIf (rbSpesifik.Checked) Then
                        'SPESIFIK
                        'Karyawan
                        If Not IsDBNull(dgvView.CurrentRow.Cells("nip").Value) Then
                            For i As Integer = 0 To cboKaryawan.Items.Count - 1
                                If (DirectCast(cboKaryawan.Items(i), DataRowView).Item("nip") = dgvView.CurrentRow.Cells("nip").Value) Then
                                    cboKaryawan.SelectedIndex = i
                                    arrDefValues(8) = dgvView.CurrentRow.Cells("nip").Value
                                    arrDefValues(9) = dgvView.CurrentRow.Cells("nama").Value
                                End If
                            Next
                        End If
                    End If
                    'Hari
                    If Not IsDBNull(dgvView.CurrentRow.Cells("hari").Value) Then
                        For i As Integer = 0 To cboHari.Items.Count - 1
                            If (cboHari.Items(i) = dgvView.CurrentRow.Cells("hari").Value) Then
                                cboHari.SelectedIndex = i
                                arrDefValues(10) = dgvView.CurrentRow.Cells("hari").Value
                            End If
                        Next
                    End If
                    'Waktu Shift
                    If Not IsDBNull(dgvView.CurrentRow.Cells("waktu_shift").Value) Then
                        If (dgvView.CurrentRow.Cells("waktu_shift").Value = "PAGI") Then
                            rbPagi.Checked = True
                        ElseIf (dgvView.CurrentRow.Cells("waktu_shift").Value = "SIANG") Then
                            rbSiang.Checked = True
                        ElseIf (dgvView.CurrentRow.Cells("waktu_shift").Value = "MALAM") Then
                            rbMalam.Checked = True
                        End If
                        arrDefValues(11) = dgvView.CurrentRow.Cells("waktu_shift").Value
                        arrDefValues(12) = dgvView.CurrentRow.Cells("kode_waktu_shift").Value
                        strWaktuShift = dgvView.CurrentRow.Cells("waktu_shift").Value
                    End If
                    'Jam Masuk
                    If Not IsDBNull(dgvView.CurrentRow.Cells("jam_masuk").Value) Then
                        tbJamMasuk.Text = dgvView.CurrentRow.Cells("jam_masuk").Value.ToString
                        arrDefValues(13) = dgvView.CurrentRow.Cells("jam_masuk").Value.ToString
                    End If
                    'Jam Keluar
                    If Not IsDBNull(dgvView.CurrentRow.Cells("jam_keluar").Value) Then
                        tbJamKeluar.Text = dgvView.CurrentRow.Cells("jam_keluar").Value.ToString
                        arrDefValues(14) = dgvView.CurrentRow.Cells("jam_keluar").Value.ToString
                    End If
                    'Max Toleransi
                    If Not IsDBNull(dgvView.CurrentRow.Cells("max_toleransi").Value) Then
                        tbMaxToleransi.Text = dgvView.CurrentRow.Cells("max_toleransi").Value.ToString
                        arrDefValues(16) = dgvView.CurrentRow.Cells("max_toleransi").Value.ToString
                    End If
                    isDataPrepared = True
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error:    " & ex.Message, "dgvView_CellContentClick Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If (cboLokasi.SelectedIndex <> -1 And cboPerusahaan.SelectedIndex <> -1 And cboHari.SelectedIndex <> -1 And Trim(tbJamMasuk.Text).Length > 0 And Trim(tbJamKeluar.Text).Length > 0) Then
                Dim lanjut As Boolean

                If (rbUmum.Checked) Then
                    If (cboDepartemen.SelectedIndex <> -1 And cboGrup.SelectedIndex <> -1 And cboKetGrup.SelectedIndex <> -1) Then
                        lanjut = True
                    Else
                        lanjut = False
                    End If
                ElseIf (rbSpesifik.Checked) Then
                    If (cboKaryawan.SelectedIndex <> -1) Then
                        lanjut = True
                    Else
                        lanjut = False
                    End If
                End If

                If (lanjut) Then
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                    If isNew Then
                        'CREATE NEW
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and umum='" & rbUmum.Checked & "'" & IIf(rbUmum.Checked, " and grup='" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "' and posisi='" & IIf(cboJabatan.SelectedIndex = -1, "-", cboJabatan.SelectedValue) & "'", Nothing) & " and spesifik='" & rbSpesifik.Checked & "'" & IIf(rbSpesifik.Checked, " and nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", Nothing) & " and hari='" & myCStringManipulation.SafeSqlLiteral(cboHari.SelectedItem) & "' and waktushift='" & strWaktuShift & "' and jammasuk='" & tbJamMasuk.Text & "' and jamkeluar='" & tbJamKeluar.Text & "'")
                        If Not isExist Then
                            'CREATE NEW
                            newValues = "'" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "','" & rbUmum.Checked & "','" & rbSpesifik.Checked & "','" & myCStringManipulation.SafeSqlLiteral(cboHari.SelectedItem) & "','" & strWaktuShift & "','" & strWaktuShift.Substring(0, 1).ToUpper & "','" & tbJamMasuk.Text & "','" & tbJamKeluar.Text & "'," & ADD_INFO_.newValues
                            newFields = "lokasi,perusahaan,umum,spesifik,hari,waktushift,kodewaktushift,jammasuk,jamkeluar," & ADD_INFO_.newFields
                            If (rbUmum.Checked) Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboDepartemen.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "','" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "'"
                                newFields &= ",departemen,grup,ketgrup"
                                If (cboJabatan.SelectedIndex <> -1) Then
                                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboJabatan.SelectedValue) & "'"
                                    newFields &= ",posisi"
                                End If
                            ElseIf (rbSpesifik.Checked) Then
                                newValues &= ",'-','-','-','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("idk")) & "','" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & "'"
                                newFields &= ",departemen,grup,ketgrup,idk,nip,nama"
                            End If
                            If (Trim(tbMaxToleransi.Text).Length > 0) Then
                                newValues &= ",'" & tbMaxToleransi.Text & "'"
                                newFields &= ",maxtoleransi"
                            End If
                            Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName, newValues, newFields)
                            Call myCShowMessage.ShowSavedMsg("Data skema presensi di hari " & cboHari.SelectedItem & " untuk departemen " & cboKetGrup.SelectedValue & " di perusahaan " & cboPerusahaan.SelectedValue)
                            Call btnTampilkan_Click(sender, e)

                            Call myCFormManipulation.ResetForm(gbDataEntry)
                            tbJamMasuk.Text = "08:00"
                            tbJamKeluar.Text = "17:00"
                            Call btnCreateNew_Click(sender, e)
                        Else
                            Call myCShowMessage.ShowWarning("Sudah ada data skema presensi di hari " & cboHari.SelectedItem & " untuk departemen " & cboKetGrup.SelectedValue & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                        End If
                    Else
                        'UDPATE
                        Dim foundRows() As DataRow
                        updateString = Nothing
                        foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                        If (arrDefValues(1) <> cboLokasi.SelectedValue) Then
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and umum='" & rbUmum.Checked & "'" & IIf(rbUmum.Checked, " and grup='" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "' and posisi='" & IIf(cboJabatan.SelectedIndex = -1, "-", cboJabatan.SelectedValue) & "'", Nothing) & " and spesifik='" & rbSpesifik.Checked & "'" & IIf(rbSpesifik.Checked, " and nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", Nothing) & " and hari='" & myCStringManipulation.SafeSqlLiteral(cboHari.SelectedItem) & "' and waktushift='" & strWaktuShift & "' and jammasuk='" & tbJamMasuk.Text & "' and jamkeluar='" & tbJamKeluar.Text & "'")
                            If Not isExist Then
                                updateString = "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("lokasi") = Trim(cboLokasi.SelectedValue)
                                End If
                            Else
                                Call myCShowMessage.ShowWarning("Sudah ada data skema presensi di hari " & cboHari.SelectedItem & " untuk " & IIf(rbUmum.Checked, cboGrup.SelectedItem & " " & cboKetGrup.SelectedValue, "karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                            End If
                        End If
                        If (arrDefValues(2) <> cboPerusahaan.SelectedValue) Then
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and umum='" & rbUmum.Checked & "'" & IIf(rbUmum.Checked, " and grup='" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "' and posisi='" & IIf(cboJabatan.SelectedIndex = -1, "-", cboJabatan.SelectedValue) & "'", Nothing) & " and spesifik='" & rbSpesifik.Checked & "'" & IIf(rbSpesifik.Checked, " and nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", Nothing) & " and hari='" & myCStringManipulation.SafeSqlLiteral(cboHari.SelectedItem) & "' and waktushift='" & strWaktuShift & "' and jammasuk='" & tbJamMasuk.Text & "' and jamkeluar='" & tbJamKeluar.Text & "'")
                            If Not isExist Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("perusahaan") = Trim(cboPerusahaan.SelectedValue)
                                End If
                            Else
                                Call myCShowMessage.ShowWarning("Sudah ada data skema presensi di hari " & cboHari.SelectedItem & " untuk " & IIf(rbUmum.Checked, cboGrup.SelectedItem & " " & cboKetGrup.SelectedValue, "karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                            End If
                        End If
                        If (rbUmum.Checked) Then
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and umum='" & rbUmum.Checked & "'" & IIf(rbUmum.Checked, " and grup='" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "' and posisi='" & IIf(cboJabatan.SelectedIndex = -1, "-", cboJabatan.SelectedValue) & "'", Nothing) & " and spesifik='" & rbSpesifik.Checked & "'" & IIf(rbSpesifik.Checked, " and nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", Nothing) & " and hari='" & myCStringManipulation.SafeSqlLiteral(cboHari.SelectedItem) & "' and waktushift='" & strWaktuShift & "' and jammasuk='" & tbJamMasuk.Text & "' and jamkeluar='" & tbJamKeluar.Text & "' and rid<>" & arrDefValues(0))
                            If Not isExist Then
                                If (arrDefValues(3) <> rbUmum.Checked) Then
                                    updateString &= IIf(IsNothing(updateString), "", ",") & "umum='" & rbUmum.Checked & "',spesifik='False',nip=Null,nama=Null"
                                    If (foundRows.Length > 0) Then
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("umum") = rbUmum.Checked
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("spesifik") = rbSpesifik.Checked
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("idk") = DBNull.Value
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nip") = DBNull.Value
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama") = DBNull.Value
                                    End If
                                End If
                                If (arrDefValues(15) <> cboDepartemen.SelectedValue) Then
                                    updateString &= IIf(IsNothing(updateString), "", ",") & "departemen='" & myCStringManipulation.SafeSqlLiteral(cboDepartemen.SelectedValue) & "'"
                                    If (foundRows.Length > 0) Then
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("departemen") = Trim(cboDepartemen.SelectedValue)
                                    End If
                                End If
                                If (arrDefValues(5) <> cboGrup.SelectedItem) Then
                                    updateString &= IIf(IsNothing(updateString), "", ",") & "grup='" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "'"
                                    If (foundRows.Length > 0) Then
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("grup") = Trim(cboGrup.SelectedItem)
                                    End If
                                End If
                                If (arrDefValues(6) <> cboKetGrup.SelectedValue) Then
                                    updateString &= IIf(IsNothing(updateString), "", ",") & "ketgrup='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "'"
                                    If (foundRows.Length > 0) Then
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("ket_grup") = Trim(cboKetGrup.SelectedValue)
                                    End If
                                End If
                            Else
                                Call myCShowMessage.ShowWarning("Sudah ada data skema presensi di hari " & cboHari.SelectedItem & " untuk " & IIf(rbUmum.Checked, cboGrup.SelectedItem & " " & cboKetGrup.SelectedValue, "karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                            End If
                            If (arrDefValues(7) <> cboJabatan.SelectedValue) Then
                                If (cboJabatan.SelectedIndex <> -1) Then
                                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and umum='" & rbUmum.Checked & "'" & IIf(rbUmum.Checked, " and grup='" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "' and posisi='" & IIf(cboJabatan.SelectedIndex = -1, "-", cboJabatan.SelectedValue) & "'", Nothing) & " and spesifik='" & rbSpesifik.Checked & "'" & IIf(rbSpesifik.Checked, " and nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", Nothing) & " and hari='" & myCStringManipulation.SafeSqlLiteral(cboHari.SelectedItem) & "' and waktushift='" & strWaktuShift & "' and jammasuk='" & tbJamMasuk.Text & "' and jamkeluar='" & tbJamKeluar.Text & "'")
                                    If Not isExist Then
                                        updateString &= IIf(IsNothing(updateString), "", ",") & "posisi='" & myCStringManipulation.SafeSqlLiteral(cboJabatan.SelectedValue) & "'"
                                        If (foundRows.Length > 0) Then
                                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("posisi") = Trim(cboJabatan.SelectedValue)
                                        End If
                                    Else
                                        Call myCShowMessage.ShowWarning("Sudah ada data skema presensi di hari " & cboHari.SelectedItem & " untuk " & IIf(rbUmum.Checked, cboGrup.SelectedItem & " " & cboKetGrup.SelectedValue, "karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " untuk jabatan " & cboJabatan.SelectedValue & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                                    End If
                                Else
                                    updateString &= IIf(IsNothing(updateString), "", ",") & "posisi=Null"
                                    If (foundRows.Length > 0) Then
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("posisi") = DBNull.Value
                                    End If
                                End If
                            End If
                        ElseIf (rbSpesifik.Checked) Then
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and umum='" & rbUmum.Checked & "'" & IIf(rbUmum.Checked, " and grup='" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "' and posisi='" & IIf(cboJabatan.SelectedIndex = -1, "-", cboJabatan.SelectedValue) & "'", Nothing) & " and spesifik='" & rbSpesifik.Checked & "'" & IIf(rbSpesifik.Checked, " and nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", Nothing) & " and hari='" & myCStringManipulation.SafeSqlLiteral(cboHari.SelectedItem) & "' and waktushift='" & strWaktuShift & "' and jammasuk='" & tbJamMasuk.Text & "' and jamkeluar='" & tbJamKeluar.Text & "'")
                            If Not isExist Then
                                If (arrDefValues(4) <> rbSpesifik.Checked) Then
                                    updateString &= IIf(IsNothing(updateString), "", ",") & "spesifik='" & rbSpesifik.Checked & "',umum='False',grup='-',ketgrup='-'"
                                    If (foundRows.Length > 0) Then
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("spesifik") = rbSpesifik.Checked
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("umum") = rbUmum.Checked
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("grup") = "-"
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("ket_grup") = "-"
                                    End If
                                End If
                                If (arrDefValues(8) <> Trim(cboKaryawan.SelectedValue)) Then
                                    updateString &= IIf(IsNothing(updateString), "", ",") & "nip=" & IIf(IsNothing(cboKaryawan.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'") & ",nama=" & IIf(IsNothing(cboKaryawan.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & "'")
                                    If (foundRows.Length > 0) Then
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("idk") = Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("idk"))
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nip") = Trim(cboKaryawan.SelectedValue)
                                        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama") = Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama"))
                                    End If
                                End If
                            Else
                                Call myCShowMessage.ShowWarning("Sudah ada data skema presensi di hari " & cboHari.SelectedItem & " untuk " & IIf(rbUmum.Checked, cboGrup.SelectedItem & " " & cboKetGrup.SelectedValue, "karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                            End If
                        End If
                        If (arrDefValues(10) <> cboHari.SelectedItem) Then
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and umum='" & rbUmum.Checked & "'" & IIf(rbUmum.Checked, " and grup='" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "' and posisi='" & IIf(cboJabatan.SelectedIndex = -1, "-", cboJabatan.SelectedValue) & "'", Nothing) & " and spesifik='" & rbSpesifik.Checked & "'" & IIf(rbSpesifik.Checked, " and nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", Nothing) & " and hari='" & myCStringManipulation.SafeSqlLiteral(cboHari.SelectedItem) & "' and waktushift='" & strWaktuShift & "' and jammasuk='" & tbJamMasuk.Text & "' and jamkeluar='" & tbJamKeluar.Text & "'")
                            If Not isExist Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "hari='" & myCStringManipulation.SafeSqlLiteral(cboHari.SelectedItem) & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("hari") = Trim(cboHari.SelectedItem)
                                End If
                            Else
                                Call myCShowMessage.ShowWarning("Sudah ada data skema presensi di hari " & cboHari.SelectedItem & " untuk " & IIf(rbUmum.Checked, cboGrup.SelectedItem & " " & cboKetGrup.SelectedValue, "karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                            End If
                        End If
                        If (arrDefValues(11) <> strWaktuShift) Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "waktushift='" & strWaktuShift & "',kodewaktushift='" & strWaktuShift.Substring(0, 1).ToUpper & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("waktu_shift") = strWaktuShift
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kode_waktu_shift") = strWaktuShift.Substring(0, 1).ToUpper
                            End If
                        End If
                        If (arrDefValues(13) <> tbJamMasuk.Text) Then
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and umum='" & rbUmum.Checked & "'" & IIf(rbUmum.Checked, " and grup='" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "' and posisi='" & IIf(cboJabatan.SelectedIndex = -1, "-", cboJabatan.SelectedValue) & "'", Nothing) & " and spesifik='" & rbSpesifik.Checked & "'" & IIf(rbSpesifik.Checked, " and nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", Nothing) & " and hari='" & myCStringManipulation.SafeSqlLiteral(cboHari.SelectedItem) & "' and waktushift='" & strWaktuShift & "' and jammasuk='" & tbJamMasuk.Text & "' and jamkeluar='" & tbJamKeluar.Text & "'")
                            If Not isExist Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "jammasuk='" & tbJamMasuk.Text & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("jam_masuk") = tbJamMasuk.Text
                                End If
                            Else
                                Call myCShowMessage.ShowWarning("Sudah ada data skema presensi di hari " & cboHari.SelectedItem & " untuk " & IIf(rbUmum.Checked, cboGrup.SelectedItem & " " & cboKetGrup.SelectedValue, "karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                            End If
                        End If
                        If (arrDefValues(14) <> tbJamKeluar.Text) Then
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName, "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and umum='" & rbUmum.Checked & "'" & IIf(rbUmum.Checked, " and grup='" & myCStringManipulation.SafeSqlLiteral(cboGrup.SelectedItem) & "' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(cboKetGrup.SelectedValue) & "' and posisi='" & IIf(cboJabatan.SelectedIndex = -1, "-", cboJabatan.SelectedValue) & "'", Nothing) & " and spesifik='" & rbSpesifik.Checked & "'" & IIf(rbSpesifik.Checked, " and nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", Nothing) & " and hari='" & myCStringManipulation.SafeSqlLiteral(cboHari.SelectedItem) & "' and waktushift='" & strWaktuShift & "' and jammasuk='" & tbJamMasuk.Text & "' and jamkeluar='" & tbJamKeluar.Text & "'")
                            If Not isExist Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "jamkeluar='" & tbJamKeluar.Text & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("jam_keluar") = tbJamKeluar.Text
                                End If
                            Else
                                Call myCShowMessage.ShowWarning("Sudah ada data skema presensi di hari " & cboHari.SelectedItem & " untuk " & IIf(rbUmum.Checked, cboGrup.SelectedItem & " " & cboKetGrup.SelectedValue, "karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & " di perusahaan " & cboPerusahaan.SelectedValue & " !!")
                            End If
                        End If
                        If (arrDefValues(16) <> tbMaxToleransi.Text) Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "maxtoleransi='" & tbMaxToleransi.Text & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("max_toleransi") = tbMaxToleransi.Text
                            End If
                        End If

                        If Not IsNothing(updateString) Then
                            updateString &= "," & ADD_INFO_.updateString
                            'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName, CONN_.dbType)
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName, updateString, "rid=" & arrDefValues(0))
                            Call myCShowMessage.ShowUpdatedMsg("Data skema presensi di hari " & cboHari.SelectedItem & " untuk departemen " & cboKetGrup.SelectedValue & " di perusahaan " & cboPerusahaan.SelectedValue)

                            Call myCFormManipulation.ResetForm(gbDataEntry)
                            tbJamMasuk.Text = "08:00"
                            tbJamKeluar.Text = "17:00"
                            rbSpesifik.Checked = False
                            Call btnCreateNew_Click(sender, e)
                        Else
                            Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                        End If
                    End If
                    Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "save")
                Else
                    If (rbUmum.Checked) Then
                        Call myCShowMessage.ShowWarning("Silahkan lengkapi dulu data grup dan keterangan grup nya!")
                        cboGrup.Focus()
                    ElseIf (rbSpesifik.Checked) Then
                        Call myCShowMessage.ShowWarning("Silahkan pilih dulu karyawannya!")
                        cboKaryawan.Focus()
                    End If
                End If
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                cboLokasi.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboKaryawan.Validated, cboLokasi.Validated, cboPerusahaan.Validated, cboKetGrup.Validated, cboHari.Validated, cboGrup.Validated, cboKetGrup.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    'Private Sub tbMaxToleransi_Validated(sender As Object, e As EventArgs) Handles tbMaxToleransi.Validated
    '    Try
    '        tbMaxToleransi.Text = myCStringManipulation.CleanInputInteger(tbMaxToleransi.Text)
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbMaxToleransi_Validated Error")
    '    End Try
    'End Sub

    Private Sub tbJam_Validated(sender As Object, e As EventArgs) Handles tbJamMasuk.Validated, tbJamKeluar.Validated, tbMaxToleransi.Validated
        Try
            If (isDataPrepared) Then
                tbJamMasuk.Text = myCStringManipulation.CleanInputTime(tbJamMasuk.Text)
                tbJamKeluar.Text = myCStringManipulation.CleanInputTime(tbJamKeluar.Text)
                If (Trim(tbJamMasuk.Text).Length > 0 And Trim(tbJamKeluar.Text).Length > 0) Then
                    'Dim strJamMasuk As TimeSpan
                    'Dim strJamKeluar As TimeSpan

                    'strJamMasuk = TimeSpan.Parse(tbJamMasuk.Text)
                    'strJamKeluar = TimeSpan.Parse(tbJamKeluar.Text)

                    'If (sender Is tbJamMasuk) Then
                    '    If (strJamMasuk > strJamKeluar) Then
                    '        strJamKeluar = strJamMasuk
                    '        tbJamKeluar.Text = strJamKeluar.ToString
                    '    End If
                    'ElseIf (sender Is tbJamKeluar) Then
                    '    If (strJamMasuk > strJamKeluar) Then
                    '        strJamMasuk = strJamKeluar
                    '        tbJamMasuk.Text = strJamMasuk.ToString
                    '    End If
                    'End If
                Else
                    Call myCShowMessage.ShowWarning("Jam masuk dan jam keluar tidak boleh kosong!!")
                    tbJamMasuk.Text = "08:00"
                    tbJamKeluar.Text = "17:00"
                End If
                tbMaxToleransi.Text = myCStringManipulation.CleanInputTime(tbMaxToleransi.Text)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbJam_Validated Error")
        End Try
    End Sub

    Private Sub rbWaktuHari_CheckedChanged(sender As Object, e As EventArgs) Handles rbPagi.CheckedChanged, rbSiang.CheckedChanged, rbMalam.CheckedChanged
        Try
            strWaktuShift = sender.text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbWaktuHari_CheckedChanged Error")
        End Try
    End Sub

    Private Sub rbKategori_CheckedChanged(sender As Object, e As EventArgs) Handles rbUmum.CheckedChanged, rbSpesifik.CheckedChanged
        Try
            Select Case True
                Case rbUmum.Checked
                    pnlUmum.Visible = True
                    pnlSpesifik.Visible = False
                    cboKaryawan.SelectedIndex = -1
                Case rbSpesifik.Checked
                    pnlUmum.Visible = False
                    pnlSpesifik.Visible = True
            End Select
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbKategori_CheckedChanged Error")
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
