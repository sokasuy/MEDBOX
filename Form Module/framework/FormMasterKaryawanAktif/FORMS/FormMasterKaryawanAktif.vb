Public Class FormMasterKaryawanAktif
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
    Private cmbDgvPosisiButton As New DataGridViewButtonColumn()
    Private cmbDgvKomponenGajiButton As New DataGridViewButtonColumn()
    Private cmbDgvPerbaharuiKontrakButton As New DataGridViewButtonColumn()
    Private cmbDgvAttachmentButton As New DataGridViewButtonColumn()
    Private cekTambahButton(5) As Boolean
    Private arrDefValues(16) As String
    Private tableName(3) As String
    Private tableNameLog As String

    Private myDataTableCboLokasi As New DataTable
    Private myBindingLokasi As New BindingSource
    Private myDataTableCboKaryawan As New DataTable
    Private myBindingKaryawan As New BindingSource
    Private myDataTableCboPerusahaan As New DataTable
    Private myBindingPerusahaan As New BindingSource
    Private myBindingFilterPerusahaan As New BindingSource
    Private myDataTableCboDepartemen As New DataTable
    Private myBindingDepartemen As New BindingSource
    Private myBindingFilterDepartemen As New BindingSource
    Private myDataTableCboDivisi As New DataTable
    Private myBindingDivisi As New BindingSource
    Private myDataTableCboBagian As New DataTable
    Private myBindingBagian As New BindingSource
    Private myDataTableCboStatusPegawai As New DataTable
    Private myBindingStatusPegawai As New BindingSource
    Private myDataTableBackupKaryawan As New DataTable
    Private myDataTableColumnNames As New DataTable
    Private myBindingColumnNames As New BindingSource

    Private isCboPrepared As Boolean
    Private strStatusPegawai As String
    Private strKodeStatusPegawai As String
    Private strKatGaji As String
    Private strPerusahaan As String
    Private strKodePerusahaan As String
    Private strKelompok As String
    Private arrTableUsingActiveNIP() As String
    Private arrTableUsingActiveNIPKepala() As String
    Private digitLength As Integer
    Private enableSubForm(2) As Boolean
    Private tglKaryawanTerdaftar As Date
    Private strStatusAktif As String

    Private Structure fileTempel
        Dim name As String
        Dim path As String
        Dim extension As String
    End Structure

    Private fileAttachment As fileTempel

    Const STR_MYCOMPUTER_CLSID As String = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"

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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterKaryawanAktif Error")
        End Try
    End Sub

    Private Sub FormMasterKaryawanAktif_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub SetNIP(_conn As Object, _comm As Object, _reader As Object, _tblName As String, _kodeField As String, _idField As String, _prefixKode As String, _digitLength As Integer, _incDate As Boolean, _dateValue As Date, _dbType As String)
        Try
            Call myCDBConnection.OpenConn(_conn)
            Dim updateNIP As Boolean
            Dim tabelTerpakai As String = Nothing
            Dim i As Integer = 0

            updateNIP = True
            If Not isNew Then
                'Jika edit
                If (lblEntryType.Text = "EDIT") Then
                    'JIKA EDIT BUKAN PERBAHARUI KONTRAK
                    While (updateNIP) And (i < arrTableUsingActiveNIP.Count)
                        'MsgBox("arrTableUsingActiveNIP.Count: " & arrTableUsingActiveNIP.Count & "i: " & i)
                        'Untuk mencegah NIP dirubah kalau sudah terpakai di tabel transaction nya
                        isExist = myCDBOperation.IsExistRecords(_conn, _comm, _reader, "rid", arrTableUsingActiveNIP(i), "nip='" & arrDefValues(3) & "'")
                        If isExist Then
                            updateNIP = False
                            tabelTerpakai = arrTableUsingActiveNIP(i)
                            i = arrTableUsingActiveNIP.Count
                        End If
                        i += 1
                        If (i Mod 100 = 0) Then
                            GC.Collect()
                        End If
                    End While

                    i = 0
                    While (updateNIP) And (i < arrTableUsingActiveNIPKepala.Count)
                        'MsgBox("arrTableUsingActiveNIP.Count: " & arrTableUsingActiveNIP.Count & "i: " & i)
                        'Untuk mencegah NIP dirubah kalau sudah terpakai di tabel transaction nya
                        isExist = myCDBOperation.IsExistRecords(_conn, _comm, _reader, "rid", arrTableUsingActiveNIPKepala(i), "nipkepala='" & arrDefValues(3) & "'")
                        If isExist Then
                            updateNIP = False
                            tabelTerpakai = arrTableUsingActiveNIPKepala(i)
                            i = arrTableUsingActiveNIPKepala.Count
                        End If
                        i += 1
                        If (i Mod 100 = 0) Then
                            GC.Collect()
                        End If
                    End While
                End If
            End If
            'Untuk mengganti kode huruf dengan angka pada NIP nya
            'PIM = 1
            'HPS = 2
            'SRF = 3
            _prefixKode = myCDBOperation.GetSpecificRecord(_conn, _comm, _reader, "kode", CONN_.schemaHRD & ".msgeneral",, "keterangan='" & _prefixKode & "'", CONN_.dbType)

            If updateNIP Then
                'Semua NIP disimpan dalam 1 table lognipkmskaryawan, jadi karyawan yang sudah dihapus pun, kalau sudah pernah dibuat, NIP nya gak boleh kembar!!
                '_tblName = CONN_.schemaHRD & ".lognipmskaryawan"
                tbNIP.Text = myCDBOperation.SetDynamicAutoKode(_conn, _comm, _reader, _tblName, _kodeField, _idField, _prefixKode, _digitLength, _incDate, _dateValue, _dbType,, False)
            Else
                Call myCShowMessage.ShowInfo("Tidak dapat melakukan perubahan NIP karyawan," & ControlChars.NewLine & "Karena NIP yang terdaftar sudah dipakai di tabel " & tabelTerpakai & "!")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetNIP Error")
        Finally
            Call myCDBConnection.CloseConn(_conn, -1)
        End Try
    End Sub

    Private Sub FormMasterKaryawanAktif_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"NIP", "NAMA", "PERUSAHAAN", "DEPARTEMEN", "DIVISI", "BAGIAN", "STATUS KEPEGAWAIAN", "KELOMPOK", "FPID"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 1

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT concat(tbl.nama,' || ',tbl.idk) as karyawan,tbl.idk,tbl.nama FROM " & CONN_.schemaHRD & ".mskaryawan as tbl left join " & CONN_.schemaHRD & ".mskaryawanaktif as tbl2 ON tbl.idk=tbl2.idk WHERE tbl.statusbekerja='AKTIF' " & IIf(USER_.lokasi = "ALL", "", "AND (tbl2.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "' OR tbl2.lokasi is null)") & " GROUP BY concat(tbl.nama,' || ',tbl.idk),tbl.idk,tbl.nama ORDER BY karyawan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "idk", "karyawan", isCboPrepared)

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='perusahaan' and keterangan like '%" & USER_.entityChose & "' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPerusahaan, myBindingPerusahaan, cboPerusahaan, "T_" & cboPerusahaan.Name, "keterangan", "keterangan", isCboPrepared)
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPerusahaan, myBindingFilterPerusahaan, cboFilterPerusahaan, "T_" & cboFilterPerusahaan.Name, "keterangan", "keterangan", isCboPrepared, True)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='departemen' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboDepartemen, myBindingDepartemen, cboDepartemen, "T_" & cboDepartemen.Name, "keterangan", "keterangan", isCboPrepared)
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboDepartemen, myBindingFilterDepartemen, cboFilterDepartemen, "T_" & cboFilterDepartemen.Name, "keterangan", "keterangan", isCboPrepared, True)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='divisi' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboDivisi, myBindingDivisi, cboDivisi, "T_" & cboDivisi.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='bagian' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboBagian, myBindingBagian, cboBagian, "T_" & cboBagian.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='statuspegawai' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboStatusPegawai, myBindingStatusPegawai, cboStatusPegawai, "T_" & cboStatusPegawai.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='lokasi' " & IIf(USER_.lokasi = "ALL", "", "AND keterangan='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "'") & " order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboLokasi, myBindingLokasi, cboLokasi, "T_" & cboLokasi.Name, "keterangan", "keterangan", isCboPrepared)
            cboLokasi.SelectedIndex = 0

            'stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='perusahaan' order by keterangan;"

            arrCbo = {"STAFF", "NON STAFF", "OUTSOURCE"}
            cboKelompok.Items.AddRange(arrCbo)

            'stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='departemen' order by keterangan;"

            stSQL = "SELECT column_name FROM INFORMATION_SCHEMA. COLUMNS WHERE TABLE_NAME = 'mskaryawanaktif' and column_name NOT IN('created_at','updated_at') ORDER BY column_name ASC;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableColumnNames, myBindingColumnNames, cboSortingCriteria, "T_" & cboSortingCriteria.Name, "column_name", "column_name", isCboPrepared)

            arrCbo = {"ASC", "DESC"}
            cboSortingType.Items.AddRange(arrCbo)
            cboSortingType.SelectedIndex = 0

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
                'POSISI
                foundRows = USER_.T_USER_RIGHT.Select("formname='FormMasterPosisiKaryawan'")
                If (foundRows.Length = 0) Then
                    enableSubForm(1) = False
                Else
                    enableSubForm(1) = True
                End If
                'KOMPONEN GAJI
                foundRows = USER_.T_USER_RIGHT.Select("formname='FormMasterKomponenTetapPayroll'")
                If (foundRows.Length = 0) Then
                    enableSubForm(2) = False
                Else
                    enableSubForm(2) = True
                End If
            End If

            rbMingguan.Checked = True
            rbStaff.Checked = True

            lblInfoNIPKosong.Visible = True
            lblEditingWarning.Visible = False

            pnlPeriodeKontrak.Visible = False
            pnlTanggalMulaiKerjaTetap.Visible = False

            arrTableUsingActiveNIP = {CONN_.schemaHRD & ".trsuratperingatan", CONN_.schemaHRD & ".trijinabsen", CONN_.schemaHRD & ".trspldetail", CONN_.schemaHRD & ".trspkdetail", CONN_.schemaHRD & ".trdatapresensi", CONN_.schemaHRD & ".trscheduleshiftdetail", CONN_.schemaHRD & ".mskomponentetappayroll", CONN_.schemaHRD & ".msposisikaryawan", CONN_.schemaHRD & ".msskemapresensi", CONN_.schemaHRD & ".trpayrollheader", CONN_.schemaHRD & ".trpayrolldetail", CONN_.schemaHRD & ".trpayrollprocesseddetail", CONN_.schemaHRD & ".trpayrollsummary"}
            arrTableUsingActiveNIPKepala = {CONN_.schemaHRD & ".trsuratperingatan", CONN_.schemaHRD & ".trsplheader", CONN_.schemaHRD & ".trspkheader"}

            tableName(0) = CONN_.schemaHRD & ".mskaryawanaktif"
            tableName(1) = CONN_.schemaHRD & ".msgeneral"
            tableName(2) = CONN_.schemaHRD & ".mskaryawan"
            tableName(3) = CONN_.schemaHRD & ".lognipmskaryawan"
            tableNameLog = CONN_.schemaHRD & ".logkaryawanaktif"

            digitLength = 3
            isDataPrepared = True

            ofd1.InitialDirectory = STR_MYCOMPUTER_CLSID
            ofd1.Title = "Pilih File Excel"
            ofd1.Multiselect = False
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterKaryawanAktif_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormMasterKaryawanAktif_KeyDown(sender As Object, e As KeyEventArgs) Handles cboKaryawan.KeyDown, tbFPID.KeyDown, tbNIP.KeyDown, cboPerusahaan.KeyDown, cboLokasi.KeyDown, cboDepartemen.KeyDown, cboDivisi.KeyDown, cboBagian.KeyDown, cboStatusPegawai.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is cboStatusPegawai) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterKaryawanAktif_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    Private Sub SetDGV(myConn As Object, myComm As Object, myReader As Object, offSet As Integer, ByRef myDataTable As DataTable, ByRef myBindingTable As BindingSource, mKriteria As String, Optional gantiKriteria As Boolean = False, Optional sortingCols As String = Nothing, Optional sortingType As String = Nothing)
        Try
            Dim batas As Integer
            Dim mJumlah As Integer
            Dim mTableName As String
            Dim mSelectedCriteria As String
            Dim mGroupCriteria As String = Nothing

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mTableName = IIf(rbAktif.Checked, tableName(0), tableNameLog)
            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")
            If (cboFilterPerusahaan.SelectedIndex <> -1) Then
                mGroupCriteria = " AND (tbl.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboFilterPerusahaan.SelectedValue) & "')"
            Else
                mGroupCriteria = " AND (tbl.perusahaan like '%" & myCStringManipulation.SafeSqlLiteral(USER_.entityChose) & "')"
            End If
            If (cboKelompok.SelectedIndex <> -1) Then
                mGroupCriteria &= " AND (tbl.kelompok='" & myCStringManipulation.SafeSqlLiteral(cboKelompok.SelectedItem) & "')"
            End If
            If (cboFilterDepartemen.SelectedIndex <> -1) Then
                mGroupCriteria &= " AND (tbl.departemen='" & myCStringManipulation.SafeSqlLiteral(cboFilterDepartemen.SelectedValue) & "')"
            End If

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                'Dim tampTotalRecords As Integer
                banyakPages = 0
                mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                stSQL = "SELECT count(*) FROM " & mTableName & " as tbl inner join " & tableName(1) & " as tbl2 on tbl.perusahaan=tbl2.keterangan WHERE ((" & IIf(mSelectedCriteria.ToLower = "fpid", IIf((mKriteria.Length = 0), "(tbl." & mSelectedCriteria & " is null)", "(tbl." & mSelectedCriteria & ")=" & mKriteria), "upper(tbl." & mSelectedCriteria & ") Like '%" & mKriteria.ToUpper & "%'") & ")) " & IIf(USER_.lokasi = "ALL", "", "AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & mGroupCriteria & ";"
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

            stSQL = "SELECT rid,idk,nip,fpid,nama,kelompok,bagian,divisi,departemen,kode,perusahaan,lokasi,statuskepegawaian as status_kepegawaian,katpenggajian as kat_penggajian,kontrakke as kontrak_ke,tglmulaikontrak as tgl_mulai_kontrak,tglselesaikontrak as tgl_selesai_kontrak,hariresetsp as hari_reset_sp,created_at,updated_at " &
                        "FROM ( " &
                            "SELECT sub.rid,sub.idk,sub.nip,sub.fpid,sub.nama,sub.kelompok,sub.bagian,sub.divisi,sub.departemen,sub.kode,sub.perusahaan,sub.lokasi,sub.statuskepegawaian,sub.katpenggajian,sub.kontrakke,sub.tglmulaikontrak,sub.tglselesaikontrak,sub.hariresetsp,sub.created_at,sub.updated_at " &
                            "FROM ( " &
                                "SELECT tbl.rid,tbl.idk,tbl.nip,tbl.fpid,tbl.nama,tbl.kelompok,tbl.bagian,tbl.divisi,tbl.departemen,tbl2.kode,tbl.perusahaan,tbl.lokasi,tbl.statuskepegawaian,tbl.katpenggajian,tbl.kontrakke,tbl.tglmulaikontrak,tbl.tglselesaikontrak,tbl.hariresetsp,tbl.created_at,tbl.updated_at " &
                                "FROM (" & mTableName & " as tbl inner join " & tableName(1) & " as tbl2 on tbl.perusahaan=tbl2.keterangan) " &
                                "WHERE ((" & IIf(mSelectedCriteria.ToLower = "fpid", IIf((mKriteria.Length = 0), "(tbl." & mSelectedCriteria & ") is null", "(tbl." & mSelectedCriteria & ") = " & mKriteria), "upper(tbl." & mSelectedCriteria & ") Like '%" & mKriteria.ToUpper & "%'") & ")) " & IIf(USER_.lokasi = "ALL", "", "AND (tbl.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "')") & mGroupCriteria & " " &
                                 "ORDER BY " & IIf(IsNothing(sortingCols), "(case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC ", sortingCols & " " & sortingType) & " " &
                                "LIMIT " & offSet &
                                ") sub " &
                            "ORDER BY " & IIf(IsNothing(sortingCols), "(case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC ", sortingCols & " " & IIf(sortingType = "ASC", "DESC", "ASC")) & " " &
                            "LIMIT " & batas &
                        ") subOrdered " &
                        "ORDER BY " & IIf(IsNothing(sortingCols), "(case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC ", sortingCols & " " & sortingType) & ";"

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
                .Columns("perusahaan").Visible = False

                .Columns("rid").Frozen = True
                .Columns("idk").Frozen = True
                .Columns("nip").Frozen = True
                .Columns("fpid").Frozen = True
                .Columns("nama").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("idk").Width = 75
                .Columns("nip").Width = 75
                .Columns("fpid").Width = 50
                .Columns("nama").Width = 125
                .Columns("kelompok").Width = 80
                .Columns("bagian").Width = 100
                .Columns("divisi").Width = 100
                .Columns("departemen").Width = 100
                .Columns("kode").Width = 60
                .Columns("perusahaan").Width = 130
                .Columns("lokasi").Width = 70
                .Columns("status_kepegawaian").Width = 70
                .Columns("kat_penggajian").Width = 70
                .Columns("kontrak_ke").Width = 50
                .Columns("tgl_mulai_kontrak").Width = 80
                .Columns("tgl_selesai_kontrak").Width = 80
                .Columns("hari_reset_sp").Width = 50

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next

                .Columns("kode").HeaderText = "PERUSAHAAN"

                .Columns("tgl_mulai_kontrak").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tgl_selesai_kontrak").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                .Font = New Font("Arial", 8, FontStyle.Regular)
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

                With cmbDgvPosisiButton
                    If Not (cekTambahButton(2)) Then
                        .HeaderText = "POSISI"
                        .Name = "posisi"
                        .Text = "Posisi"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = dgvView.ColumnCount
                        dgvView.Columns.Add(cmbDgvPosisiButton)
                        dgvView.Columns("posisi").Width = 100
                        cekTambahButton(2) = True
                        .Visible = enableSubForm(1)
                    End If
                    .HeaderCell.Style.BackColor = Color.Violet
                End With

                With cmbDgvKomponenGajiButton
                    If Not (cekTambahButton(5)) Then
                        .HeaderText = "KOMPONEN GAJI"
                        .Name = "komponengaji"
                        .Text = "Komponen Gaji"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = dgvView.ColumnCount
                        dgvView.Columns.Add(cmbDgvKomponenGajiButton)
                        dgvView.Columns("komponengaji").Width = 100
                        cekTambahButton(5) = True
                        .Visible = enableSubForm(2)
                    End If
                    .HeaderCell.Style.BackColor = Color.LightPink
                End With

                With cmbDgvPerbaharuiKontrakButton
                    If Not (cekTambahButton(3)) Then
                        .HeaderText = "PERBAHARUI KONTRAK"
                        .Name = "perbaharuikontrak"
                        .Text = "Perbaharui Kontrak"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = dgvView.ColumnCount
                        dgvView.Columns.Add(cmbDgvPerbaharuiKontrakButton)
                        dgvView.Columns("perbaharuikontrak").Width = 120
                        cekTambahButton(3) = True
                        .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    End If
                    .HeaderCell.Style.BackColor = Color.SkyBlue
                End With

                With cmbDgvAttachmentButton
                    If Not (cekTambahButton(4)) Then
                        .HeaderText = "ATTACHMENT"
                        .Name = "attachment"
                        .Text = "Attachment"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = dgvView.ColumnCount
                        dgvView.Columns.Add(cmbDgvAttachmentButton)
                        dgvView.Columns("attachment").Width = 90
                        cekTambahButton(4) = True
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
            cboKaryawan.Enabled = True
            tbResetSP.Text = 180

            lblInfoNIPKosong.Visible = True
            lblEditingWarning.Visible = False
            cboLokasi.SelectedIndex = 0

            Call cboFields_SelectedIndexChanged(cboPerusahaan, e)
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
            If (dgvView.RowCount > 0 And rbAktif.Checked) Then
                If (e.RowIndex = -1) Then
                    Exit Sub
                End If

                If (e.ColumnIndex = dgvView.Columns("delete").Index) Then
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus karyawan " & dgvView.CurrentRow.Cells("nip").Value & " || " & dgvView.CurrentRow.Cells("nama").Value & " dari data karyawan aktif ?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = DialogResult.Yes) Then
                        Dim deleteRecord As Boolean
                        Dim tabelTerpakai As String = Nothing
                        Dim i As Integer

                        deleteRecord = True
                        If Not isNew Then
                            'Jika edit
                            If (lblEntryType.Text = "EDIT") Then
                                'JIKA EDIT BUKAN PERBAHARUI KONTRAK
                                While (deleteRecord) And (i < arrTableUsingActiveNIP.Count)
                                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", arrTableUsingActiveNIP(i), "nip='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("nip").Value) & "'")
                                    If isExist Then
                                        deleteRecord = False
                                        tabelTerpakai = arrTableUsingActiveNIP(i)
                                        i = arrTableUsingActiveNIP.Count - 1
                                    End If
                                    i += 1
                                    If (i Mod 100 = 0) Then
                                        GC.Collect()
                                    End If
                                End While

                                i = 0
                                While (deleteRecord) And (i < arrTableUsingActiveNIPKepala.Count)
                                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", arrTableUsingActiveNIPKepala(i), "nipkepala='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("nip").Value) & "'")
                                    If isExist Then
                                        deleteRecord = False
                                        tabelTerpakai = arrTableUsingActiveNIPKepala(i)
                                        i = arrTableUsingActiveNIPKepala.Count - 1
                                    End If
                                    i += 1
                                    If (i Mod 100 = 0) Then
                                        GC.Collect()
                                    End If
                                End While
                            End If
                        End If
                        If (deleteRecord) Then
                            Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                            Call myCShowMessage.ShowDeletedMsg("Karyawan " & dgvView.CurrentRow.Cells("nip").Value & " || " & dgvView.CurrentRow.Cells("nama").Value & " dari data karyawan aktif")
                            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
                        Else
                            Call myCShowMessage.ShowInfo("Tidak dapat melakukan penghapusan karyawan " & dgvView.CurrentRow.Cells("nama").Value & "," & ControlChars.NewLine & "Karena data karyawan sudah terpakai di tabel " & tabelTerpakai & "!")
                        End If
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan karyawan " & dgvView.CurrentRow.Cells("nip").Value & " || " & dgvView.CurrentRow.Cells("nama").Value & " dari data karyawan aktif dibatalkan oleh user")
                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("posisi").Index) Then
                    Dim frmMasterPosisiKaryawan As New FormMasterPosisiKaryawan.FormMasterPosisiKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, dgvView.CurrentRow.Cells("idk").Value, dgvView.CurrentRow.Cells("nip").Value, dgvView.CurrentRow.Cells("nama").Value)
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmMasterPosisiKaryawan)
                ElseIf (e.ColumnIndex = dgvView.Columns("komponengaji").Index) Then
                    Dim frmMasterKomponenGajiTetap As New FormMasterKomponenTetapPayroll.FormMasterKomponenTetapPayroll(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, dgvView.CurrentRow.Cells("idk").Value, dgvView.CurrentRow.Cells("nip").Value, dgvView.CurrentRow.Cells("nama").Value)
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmMasterKomponenGajiTetap)
                ElseIf (e.ColumnIndex = dgvView.Columns("attachment").Index) Then
                    Dim frmAttachmentKaryawan As New FormAttachmentKaryawan.FormAttachmentKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, dgvView.CurrentRow.Cells("idk").Value, dgvView.CurrentRow.Cells("nama").Value, dgvView.CurrentRow.Cells("nip").Value)
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmAttachmentKaryawan)
                ElseIf (e.ColumnIndex = dgvView.Columns("edit").Index) Or (e.ColumnIndex = dgvView.Columns("perbaharuikontrak").Index) Then
                    Dim foundRows() As DataRow

                    If (e.ColumnIndex = dgvView.Columns("edit").Index) Then
                        lblEntryType.Text = "EDIT"
                        btnCreateNew.Enabled = True
                        lblEditingWarning.Visible = True
                    ElseIf (e.ColumnIndex = dgvView.Columns("perbaharuikontrak").Index) Then
                        lblEntryType.Text = "PERBAHARUI KONTRAK"
                        btnCreateNew.Enabled = False
                        lblEditingWarning.Visible = False

                        myDataTableBackupKaryawan = myDataTableDGV.Clone()
                        foundRows = myDataTableDGV.Select("rid=" & dgvView.CurrentRow.Cells("rid").Value)
                        'ImportRow ini tidak perlu nama kolom sama, hanya saja kolomnya harus sama persis urutannya dan kegunaannya, dalam hal ini tabel logkaryawanaktif dan mskaryawanaktif identik
                        myDataTableBackupKaryawan.ImportRow(myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))))
                        myDataTableBackupKaryawan.Columns.Remove("rid")
                        myDataTableBackupKaryawan.Columns.Remove("kode")
                        myDataTableBackupKaryawan.Columns.Add("userid", GetType(String))
                        myDataTableBackupKaryawan.Rows(0).Item("userid") = USER_.username
                        For i As Integer = 0 To myDataTableBackupKaryawan.Columns.Count - 1
                            If (myDataTableBackupKaryawan.Columns(i).ColumnName.Contains("_")) Then
                                'MsgBox("ColumnName: " & myDataTableBackupKaryawan.Columns(i).ColumnName)
                                If (myDataTableBackupKaryawan.Columns(i).ColumnName <> "created_at" And myDataTableBackupKaryawan.Columns(i).ColumnName <> "updated_at") Then
                                    myDataTableBackupKaryawan.Columns(i).ColumnName = myDataTableBackupKaryawan.Columns(i).ColumnName.Replace("_", "")
                                End If
                            End If
                        Next
                    End If
                    isNew = False
                    isDataPrepared = False
                    Call myCFormManipulation.ResetForm(gbDataEntry)
                    Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "edit")

                    For i As Integer = 0 To arrDefValues.Count - 1
                        arrDefValues(i) = Nothing
                    Next

                    lblInfoNIPKosong.Visible = False

                    'RecID
                    arrDefValues(0) = dgvView.CurrentRow.Cells("rid").Value
                    'Karyawan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("idk").Value) Then
                        For i As Integer = 0 To cboKaryawan.Items.Count - 1
                            If (DirectCast(cboKaryawan.Items(i), DataRowView).Item("idk") = dgvView.CurrentRow.Cells("idk").Value) Then
                                cboKaryawan.SelectedIndex = i
                                'HARUS DIBUAT READ ONLY, EDIT TIDAK BOLEH MENGGANTI KARYAWAN
                                cboKaryawan.Enabled = False
                                arrDefValues(1) = dgvView.CurrentRow.Cells("idk").Value
                                arrDefValues(2) = dgvView.CurrentRow.Cells("nama").Value
                            End If
                        Next
                    End If
                    'NIP
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nip").Value) Then
                        tbNIP.Text = dgvView.CurrentRow.Cells("nip").Value
                        arrDefValues(3) = dgvView.CurrentRow.Cells("nip").Value
                    End If
                    'Perusahaan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("perusahaan").Value) Then
                        For i As Integer = 0 To cboPerusahaan.Items.Count - 1
                            If (DirectCast(cboPerusahaan.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("perusahaan").Value) Then
                                cboPerusahaan.SelectedIndex = i
                                arrDefValues(4) = dgvView.CurrentRow.Cells("perusahaan").Value
                                foundRows = myDataTableCboPerusahaan.Select("keterangan='" & arrDefValues(4) & "'")
                                strKodePerusahaan = myDataTableCboPerusahaan.Rows(myDataTableCboPerusahaan.Rows.IndexOf(foundRows(0))).Item("kode")
                            End If
                        Next
                    End If
                    'Departemen
                    If Not IsDBNull(dgvView.CurrentRow.Cells("departemen").Value) Then
                        For i As Integer = 0 To cboDepartemen.Items.Count - 1
                            If (DirectCast(cboDepartemen.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("departemen").Value) Then
                                cboDepartemen.SelectedIndex = i
                                arrDefValues(5) = dgvView.CurrentRow.Cells("departemen").Value
                            End If
                        Next
                    End If
                    'Divisi
                    If Not IsDBNull(dgvView.CurrentRow.Cells("divisi").Value) Then
                        For i As Integer = 0 To cboDivisi.Items.Count - 1
                            If (DirectCast(cboDivisi.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("divisi").Value) Then
                                cboDivisi.SelectedIndex = i
                                arrDefValues(6) = dgvView.CurrentRow.Cells("divisi").Value
                            End If
                        Next
                    End If
                    'Bagian
                    If Not IsDBNull(dgvView.CurrentRow.Cells("bagian").Value) Then
                        For i As Integer = 0 To cboBagian.Items.Count - 1
                            If (DirectCast(cboBagian.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("bagian").Value) Then
                                cboBagian.SelectedIndex = i
                                arrDefValues(7) = dgvView.CurrentRow.Cells("bagian").Value
                            End If
                        Next
                    End If
                    'Status kepegawaian
                    If Not IsDBNull(dgvView.CurrentRow.Cells("status_kepegawaian").Value) Then
                        For i As Integer = 0 To cboStatusPegawai.Items.Count - 1
                            If (DirectCast(cboStatusPegawai.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("status_kepegawaian").Value) Then
                                cboStatusPegawai.SelectedIndex = i
                                arrDefValues(8) = dgvView.CurrentRow.Cells("status_kepegawaian").Value
                                foundRows = myDataTableCboStatusPegawai.Select("keterangan='" & arrDefValues(8) & "'")
                                strKodeStatusPegawai = myDataTableCboStatusPegawai.Rows(myDataTableCboStatusPegawai.Rows.IndexOf(foundRows(0))).Item("kode")
                            End If
                        Next
                        If (arrDefValues(8) <> "TETAP") Then
                            pnlPeriodeKontrak.Visible = True
                        Else
                            pnlPeriodeKontrak.Visible = False
                        End If
                    End If
                    'KONTRAK KE ==> KHUSUS KALAU PERBAHARUI KONTRAK
                    If (e.ColumnIndex = dgvView.Columns("perbaharuikontrak").Index) Then
                        If Not IsDBNull(dgvView.CurrentRow.Cells("kontrak_ke").Value) Then
                            Call myCDBConnection.OpenConn(CONN_.dbMain)
                            tbKontrakKe.Text = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameLog, "Count", "idk='" & cboKaryawan.SelectedValue & "' and (statuskepegawaian<>'TETAP')", CONN_.dbType) + 2
                            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                            arrDefValues(9) = dgvView.CurrentRow.Cells("kontrak_ke").Value
                        End If
                    ElseIf (e.ColumnIndex = dgvView.Columns("edit").Index) Then
                        If Not IsDBNull(dgvView.CurrentRow.Cells("kontrak_ke").Value) Then
                            tbKontrakKe.Text = dgvView.CurrentRow.Cells("kontrak_ke").Value
                            arrDefValues(9) = dgvView.CurrentRow.Cells("kontrak_ke").Value
                        End If
                    End If
                    'Tanggal Mulai Kontrak
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tgl_mulai_kontrak").Value) Then
                        dtpTanggalMulaiKontrak.Value = dgvView.CurrentRow.Cells("tgl_mulai_kontrak").Value
                        arrDefValues(10) = dgvView.CurrentRow.Cells("tgl_mulai_kontrak").Value
                    End If
                    'Tanggal Selesai Kontrak
                    If Not IsDBNull(dgvView.CurrentRow.Cells("tgl_selesai_kontrak").Value) Then
                        dtpTanggalSelesaiKontrak.Value = dgvView.CurrentRow.Cells("tgl_selesai_kontrak").Value
                        arrDefValues(11) = dgvView.CurrentRow.Cells("tgl_selesai_kontrak").Value
                    End If
                    'Status Kat Gaji
                    If Not IsDBNull(dgvView.CurrentRow.Cells("kat_penggajian").Value) Then
                        If (dgvView.CurrentRow.Cells("kat_penggajian").Value = "MINGGUAN") Then
                            rbMingguan.Checked = True
                        ElseIf (dgvView.CurrentRow.Cells("kat_penggajian").Value = "BULANAN") Then
                            rbBulanan.Checked = True
                        End If
                        arrDefValues(12) = dgvView.CurrentRow.Cells("kat_penggajian").Value
                        strKatGaji = dgvView.CurrentRow.Cells("kat_penggajian").Value
                    End If
                    'Hari Reset SP
                    If Not IsDBNull(dgvView.CurrentRow.Cells("hari_reset_sp").Value) Then
                        arrDefValues(13) = dgvView.CurrentRow.Cells("hari_reset_sp").Value
                        tbResetSP.Text = dgvView.CurrentRow.Cells("hari_reset_sp").Value
                    End If
                    'FPID
                    If Not IsDBNull(dgvView.CurrentRow.Cells("fpid").Value) Then
                        arrDefValues(14) = dgvView.CurrentRow.Cells("fpid").Value
                        tbFPID.Text = dgvView.CurrentRow.Cells("fpid").Value
                    End If
                    'Lokasi
                    If Not IsDBNull(dgvView.CurrentRow.Cells("lokasi").Value) Then
                        For i As Integer = 0 To cboLokasi.Items.Count - 1
                            If (DirectCast(cboLokasi.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("lokasi").Value) Then
                                cboLokasi.SelectedIndex = i
                                arrDefValues(15) = dgvView.CurrentRow.Cells("lokasi").Value
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
                        arrDefValues(16) = dgvView.CurrentRow.Cells("kelompok").Value
                        strKelompok = dgvView.CurrentRow.Cells("kelompok").Value
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
            If (cboKaryawan.SelectedIndex <> -1 And cboPerusahaan.SelectedIndex <> -1 And cboDepartemen.SelectedIndex <> -1 And cboDivisi.SelectedIndex <> -1 And cboBagian.SelectedIndex <> -1 And cboLokasi.SelectedIndex <> -1 And Trim(tbNIP.Text).Length > 0 And cboStatusPegawai.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                'Dim created_at As Date
                'created_at = Now
                'ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                If isNew Then
                    'CREATE NEW
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "idk='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'")
                    If Not isExist Then
                        'CREATE NEW
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(3), "nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "'")
                        While isExist
                            'Buat memastikan NIP tidak kembar
                            strKodePerusahaan = DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("kode")
                            Call SetNIP(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(3), "nip", "rid", strKodePerusahaan, digitLength, True, tglKaryawanTerdaftar, CONN_.dbType)
                            Call myCDBConnection.OpenConn(CONN_.dbMain)
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(3), "nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "'")
                        End While
                        If Not isExist Then
                            newValues = "'" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & "','" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(strKatGaji) & "'," & tbResetSP.Text & ",'" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "','" & strKelompok & "'," & ADD_INFO_.newValues
                            newFields = "idk,nip,nama,perusahaan,katpenggajian,hariresetsp,lokasi,kelompok," & ADD_INFO_.newFields
                            If (cboStatusPegawai.SelectedIndex <> -1) Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboStatusPegawai.SelectedValue) & "'"
                                newFields &= ",statuskepegawaian"
                            End If
                            If Trim(tbFPID.Text).Length > 0 Then
                                newValues &= "," & tbFPID.Text
                                newFields &= ",fpid"
                            End If
                            If cboBagian.SelectedIndex <> -1 Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboBagian.SelectedValue) & "'"
                                newFields &= ",bagian"
                            End If
                            If cboDivisi.SelectedIndex <> -1 Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboDivisi.SelectedValue) & "'"
                                newFields &= ",divisi"
                            End If
                            If cboDepartemen.SelectedIndex <> -1 Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboDepartemen.SelectedValue) & "'"
                                newFields &= ",departemen"
                            End If
                            If (cboStatusPegawai.SelectedValue = "KONTRAK" Or cboStatusPegawai.SelectedValue = "LEPAS") Then
                                'Hanya kalau bukan tetap
                                newValues &= ",'" & Format(dtpTanggalMulaiKontrak.Value.Date, "dd-MMM-yyyy") & "','" & Format(dtpTanggalSelesaiKontrak.Value.Date, "dd-MMM-yyyy") & "'"
                                newFields &= ",tglmulaikontrak,tglselesaikontrak"
                                If tbKontrakKe.Text.Length > 0 Then
                                    newValues &= "," & tbKontrakKe.Text
                                    newFields &= ",kontrakke"
                                End If
                            End If
                            Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(0), newValues, newFields)

                            'INSERT ke lognipmskaryawan
                            newValues = "'" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "'"
                            newFields = "nip"
                            Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(3), newValues, newFields)

                            Call myCShowMessage.ShowSavedMsg("Karyawan dengan nama " & Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")))
                            Call btnTampilkan_Click(sender, e)

                            isDataPrepared = False
                            Call myCFormManipulation.ResetForm(gbDataEntry)
                            isDataPrepared = True

                            Call btnCreateNew_Click(sender, e)
                        Else
                            'Gak mungkin masuk sini harusnya
                            Call myCShowMessage.ShowWarning("Karyawan dengan NIP " & tbNIP.Text & " sudah terdaftar!!")
                        End If
                    Else
                        Call myCShowMessage.ShowWarning("Karyawan " & DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama") & " dengan ID Karyawan " & Trim(cboKaryawan.SelectedValue) & " sudah terdaftar!!")
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    updateString = Nothing
                    foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    If (arrDefValues(2) <> Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama"))) Then
                        updateString = "nama='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama") = Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama"))
                        End If
                    End If
                    If (arrDefValues(3) <> tbNIP.Text) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nip") = Trim(tbNIP.Text)
                        End If
                    End If
                    If (arrDefValues(4) <> cboPerusahaan.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("perusahaan") = Trim(cboPerusahaan.SelectedValue)
                        End If
                    End If
                    If (arrDefValues(5) <> cboDepartemen.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "departemen=" & IIf(IsNothing(cboDepartemen.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboDepartemen.SelectedValue) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("departemen") = cboDepartemen.SelectedValue
                        End If
                    End If
                    If (arrDefValues(6) <> cboDivisi.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "divisi=" & IIf(IsNothing(cboDivisi.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboDivisi.SelectedValue) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("divisi") = Trim(cboDivisi.SelectedValue)
                        End If
                    End If
                    If (arrDefValues(7) <> cboBagian.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "bagian=" & IIf(IsNothing(cboBagian.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboBagian.SelectedValue) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("bagian") = Trim(cboBagian.SelectedValue)
                        End If
                    End If
                    If (arrDefValues(8) <> cboStatusPegawai.SelectedValue) Then
                        'Kalau status kepegawaiannya berubah
                        updateString &= IIf(IsNothing(updateString), "", ",") & "statuskepegawaian=" & IIf(IsNothing(cboStatusPegawai.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboStatusPegawai.SelectedValue) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("status_kepegawaian") = Trim(cboStatusPegawai.SelectedValue)
                        End If
                    End If
                    If (cboStatusPegawai.SelectedValue <> "TETAP") Then
                        'Berarti kontrak atau lepas
                        'If (lblEntryType.Text = "PERBAHARUI KONTRAK") Then
                        '    updateString &= IIf(IsNothing(updateString), "", ",") & "kontrakke='" & tbKontrakKe.Text & "'"
                        '    If (foundRows.Length > 0) Then
                        '        myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kontrak_ke") = Trim(tbKontrakKe.Text)
                        '    End If
                        'End If
                        'MsgBox("arrDefValues(9): " & arrDefValues(9) & " <> tbKontrakKe.Text: " & tbKontrakKe.Text)
                        If (arrDefValues(9) <> tbKontrakKe.Text) Then
                            'Cek kontrak ke nya
                            updateString &= IIf(IsNothing(updateString), "", ",") & "kontrakke=" & IIf(Trim(tbKontrakKe.Text).Length = 0, "Null", Trim(tbKontrakKe.Text))
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kontrak_ke") = Trim(tbKontrakKe.Text)
                            End If
                        End If
                        If Not IsNothing(arrDefValues(10)) Then
                            If (arrDefValues(10) <> dtpTanggalMulaiKontrak.Value.Date) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "tglmulaikontrak='" & Format(dtpTanggalMulaiKontrak.Value.Date, "dd-MMM-yyyy") & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tgl_mulai_kontrak") = dtpTanggalMulaiKontrak.Value.Date
                                End If
                            End If
                        Else
                            updateString &= IIf(IsNothing(updateString), "", ",") & "tglmulaikontrak='" & Format(dtpTanggalMulaiKontrak.Value.Date, "dd-MMM-yyyy") & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tgl_mulai_kontrak") = dtpTanggalMulaiKontrak.Value.Date
                            End If
                        End If
                        If Not IsNothing(arrDefValues(11)) Then
                            If (arrDefValues(11) <> dtpTanggalSelesaiKontrak.Value.Date) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "tglselesaikontrak='" & Format(dtpTanggalSelesaiKontrak.Value.Date, "dd-MMM-yyyy") & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tgl_selesai_kontrak") = dtpTanggalSelesaiKontrak.Value.Date
                                End If
                            End If
                        Else
                            updateString &= IIf(IsNothing(updateString), "", ",") & "tglselesaikontrak='" & Format(dtpTanggalSelesaiKontrak.Value.Date, "dd-MMM-yyyy") & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tgl_selesai_kontrak") = dtpTanggalSelesaiKontrak.Value.Date
                            End If
                        End If
                    Else
                        'Berarti tetap
                        If Not IsNothing(arrDefValues(9)) Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "kontrakke=Null"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kontrak_ke") = DBNull.Value
                            End If
                        End If
                        If Not IsNothing(arrDefValues(10)) Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "tglmulaikontrak=Null"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tgl_mulai_kontrak") = DBNull.Value
                            End If
                        End If
                        If Not IsNothing(arrDefValues(11)) Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "tglselesaikontrak=Null"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tgl_selesai_kontrak") = DBNull.Value
                            End If
                        End If
                    End If
                    If (arrDefValues(12) <> strKatGaji) Then
                        'Kalau status kepegawaiannya berubah
                        updateString &= IIf(IsNothing(updateString), "", ",") & "katpenggajian=" & IIf(Trim(strKatGaji).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(strKatGaji) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kat_penggajian") = Trim(strKatGaji)
                        End If
                    End If
                    If (arrDefValues(13) <> tbResetSP.Text) Then
                        'Kalau status kepegawaiannya berubah
                        updateString &= IIf(IsNothing(updateString), "", ",") & "hariresetsp=" & tbResetSP.Text
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("hari_reset_sp") = tbResetSP.Text
                        End If
                    End If
                    If (arrDefValues(14) <> tbFPID.Text) Then
                        'Kalau status kepegawaiannya berubah
                        updateString &= IIf(IsNothing(updateString), "", ",") & "fpid=" & IIf(Trim(tbFPID.Text).Length = 0, "Null", Trim(tbFPID.Text))
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("fpid") = tbFPID.Text
                        End If
                    End If
                    If (arrDefValues(15) <> cboLokasi.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "lokasi=" & IIf(IsNothing(cboLokasi.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("lokasi") = cboLokasi.SelectedValue
                        End If
                        If (USER_.lokasi = "ALL") Then
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".mskaryawan", "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "'", "idk='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("idk")) & "'")
                        End If
                    End If
                    If (arrDefValues(16) <> strKelompok) Then
                        'Kelompok karyawan, staff, non staff, outsource
                        updateString &= IIf(IsNothing(updateString), "", ",") & "kelompok=" & IIf(Trim(strKelompok).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(strKelompok) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kelompok") = Trim(strKelompok)
                        End If
                    End If

                    If Not IsNothing(updateString) Then
                        updateString &= "," & ADD_INFO_.updateString
                        'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName(0), CONN_.dbType)
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), updateString, "rid=" & arrDefValues(0))
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(2), "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "'", "idk='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'")
                        Call myCShowMessage.ShowUpdatedMsg("Karyawan dengan nama " & Trim(DirectCast(cboKaryawan.SelectedItem, DataRowView).Item("nama")))
                        'INSERT ke lognipmskaryawan
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "nip", tableName(3), "nip='" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "'")
                        If Not isExist Then
                            newValues = "'" & myCStringManipulation.SafeSqlLiteral(tbNIP.Text) & "'"
                            newFields = "nip"
                            Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(3), newValues, newFields)
                        End If

                        If (lblEntryType.Text = "PERBAHARUI KONTRAK") Then
                            'Untuk insert ke logkaryawanaktif
                            Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableBackupKaryawan, tableNameLog)

                            'Untuk backup SP lama, karena kontrak berubah, maka SP di reset langsung
                            Dim myDataTableSPLama As New DataTable
                            stSQL = "SELECT * FROM " & CONN_.schemaHRD & ".trsuratperingatan WHERE nip='" & myCStringManipulation.SafeSqlLiteral(arrDefValues(3)) & "';"
                            myDataTableSPLama = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_DataSPLama")
                            myDataTableSPLama.Columns.Remove("rid")
                            'Untuk insert ke logtrsuratperingatan
                            Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableSPLama, CONN_.schemaHRD & ".logtrsuratperingatan")
                            Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".trsuratperingatan", "nip='" & myCStringManipulation.SafeSqlLiteral((arrDefValues(3))) & "'", CONN_.dbType)
                        End If
                        isDataPrepared = False
                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        isDataPrepared = True
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                pnlTanggalMulaiKerjaTetap.Visible = False
                pnlPeriodeKontrak.Visible = False
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

    Private Sub cboFields_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPerusahaan.SelectedIndexChanged, cboStatusPegawai.SelectedIndexChanged
        Try
            If (isDataPrepared) Then
                If (sender.SelectedIndex <> -1) Then
                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                    tglKaryawanTerdaftar = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "tanggalmasuk", tableName(2),, "idk='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", CONN_.dbType)
                    If (sender Is cboStatusPegawai) Then
                        If (sender.SelectedValue <> "TETAP") Then
                            pnlPeriodeKontrak.Visible = True
                            pnlTanggalMulaiKerjaTetap.Visible = False
                            tglKaryawanTerdaftar = dtpTanggalMulaiKontrak.Value.Date
                            'Untuk perhitungan kontrak ke berapa
                            If (isNew) Then
                                tbKontrakKe.Text = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameLog, "Count", "idk='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "'", CONN_.dbType) + 1
                            Else
                                If (lblEntryType.Text = "PERBAHARUI KONTRAK") Then
                                    If (arrDefValues(8) = "KONTRAK") Then
                                        'Kalau asalnya memang sudah kontrak atau lepas, maka ditambah 2, karena 1 dari yang aktif, dan kita pakai yang angka berikutnya
                                        'Cari di logkaryawanaktif hanya yang statusnya tidak sama dengan tetap saja
                                        tbKontrakKe.Text = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameLog, "Count", "idk='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "' and (statuskepegawaian<>'TETAP')", CONN_.dbType) + 2
                                    Else
                                        'Kalau sebelumnya tetap, cek di logkaryawanaktif kapan dia pernah kontrak statusnya lalu ditambah 1 saja, karena dari karyawan aktif statusnya tetap
                                        tbKontrakKe.Text = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameLog, "Count", "idk='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "' and (statuskepegawaian<>'TETAP')", CONN_.dbType) + 1
                                    End If
                                ElseIf (lblEntryType.Text = "EDIT") Then
                                    tbKontrakKe.Text = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameLog, "Count", "idk='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "' and (statuskepegawaian<>'TETAP')", CONN_.dbType) + 1
                                End If
                            End If
                        Else
                            tglKaryawanTerdaftar = dtpTanggalMulaiKerjaTetap.Value.Date
                            pnlPeriodeKontrak.Visible = False
                            'pnlTanggalMulaiKerjaTetap.Visible = True
                            tbKontrakKe.Clear()
                        End If
                        strStatusPegawai = sender.SelectedValue
                        strKodeStatusPegawai = DirectCast(sender.SelectedItem, DataRowView).Item("kode")
                        'strKodePerusahaan = Nothing
                    ElseIf (sender Is cboPerusahaan) Then
                        strPerusahaan = sender.SelectedValue
                        strKodePerusahaan = DirectCast(sender.SelectedItem, DataRowView).Item("kode")
                    End If
                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)

                    If Not IsNothing(strKodePerusahaan) Then
                        'PER TANGGAL 4 FEBRUARI STATUS PEGAWAI TIDAK DIIKUTKAN, EVENT HANDLER NYA DIMATIKAN, KARENA MEMANG TIDAK DIBUTUHKAN UNTUK MASUK KE KOMPONEN NIP
                        Dim strPrefixKode As String

                        'strPrefixKode = strKodePerusahaan & strKodeStatusPegawai
                        strPrefixKode = strKodePerusahaan
                        Call SetNIP(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(3), "nip", "rid", strPrefixKode, digitLength, True, tglKaryawanTerdaftar, CONN_.dbType)
                        lblInfoNIPKosong.Visible = False
                    End If
                Else
                    If (sender Is cboStatusPegawai) Then
                        pnlPeriodeKontrak.Visible = False
                        pnlTanggalMulaiKerjaTetap.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_SelectedIndexChanged Error")
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboKaryawan.Validated, cboPerusahaan.Validated, cboLokasi.Validated, cboDepartemen.Validated, cboDivisi.Validated, cboBagian.Validated, cboStatusPegawai.Validated
        Try
            If (isDataPrepared) Then
                If (Trim(sender.Text).Length = 0) Then
                    sender.SelectedIndex = -1

                    If (sender Is cboStatusPegawai) Then
                        '10 Februari 2022 Status TETAP,KONTRAK,LEPAS tidak dilihat
                        'tbNIP.Clear()
                        'lblInfoNIPKosong.Visible = True
                        'strStatusPegawai = Nothing
                        pnlPeriodeKontrak.Visible = False
                        pnlTanggalMulaiKerjaTetap.Visible = False
                    ElseIf (sender Is cboPerusahaan) Then
                        tbNIP.Clear()
                        lblInfoNIPKosong.Visible = True
                        strPerusahaan = Nothing
                        strKodePerusahaan = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub dtpTanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtpTanggalMulaiKontrak.ValueChanged, dtpTanggalMulaiKerjaTetap.ValueChanged
        Try
            If (isDataPrepared) Then
                If Not IsNothing(strKodeStatusPegawai) And Not IsNothing(strKodePerusahaan) Then
                    'Jika status pegawai dan perusahaan keduanya sama2 sudah ada isinya
                    Dim strPrefixKode As String
                    Dim tglKaryawanTerdaftar As Date

                    'strPrefixKode = strKodePerusahaan & strKodeStatusPegawai
                    strPrefixKode = strKodePerusahaan
                    tglKaryawanTerdaftar = sender.Value.Date
                    Call SetNIP(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(3), "nip", "rid", strPrefixKode, digitLength, True, tglKaryawanTerdaftar, CONN_.dbType)
                    lblInfoNIPKosong.Visible = False
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpTanggal_ValueChanged Error")
        End Try
    End Sub

    Private Sub rbPilihanData_CheckedChanged(sender As Object, e As EventArgs) Handles rbAktif.CheckedChanged, rbHistory.CheckedChanged
        Try
            strStatusAktif = sender.Text
            If (rbAktif.Checked) Then
                lblPilihanData.Text = "DATA AKTIF"
                'viewPilihanData = "AKTIF"
                gbDataEntry.Enabled = True
                btnCreateNew.Enabled = True
            ElseIf (rbHistory.Checked) Then
                lblPilihanData.Text = "DATA HISTORY"
                'viewPilihanData = "HISTORY"
                gbDataEntry.Enabled = False
                btnCreateNew.Enabled = False
            End If
            myDataTableDGV.Clear()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbPilihanData_CheckedChanged Error")
        End Try
    End Sub

    Private Sub rbKatGaji_CheckedChanged(sender As Object, e As EventArgs) Handles rbMingguan.CheckedChanged, rbBulanan.CheckedChanged
        Try
            strKatGaji = sender.text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbKatGaji_CheckedChanged Error")
        End Try
    End Sub

    Private Sub rbKelompok_CheckedChanged(sender As Object, e As EventArgs) Handles rbStaff.CheckedChanged, rbNonStaff.CheckedChanged, rbOutsource.CheckedChanged
        Try
            strKelompok = sender.text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbKelompok_CheckedChanged Error")
        End Try
    End Sub

    Private Sub tbResetSP_Validated(sender As Object, e As EventArgs) Handles tbResetSP.Validated
        Try
            If (Trim(sender.Text).Length > 0) Then
                sender.Text = myCStringManipulation.CleanInputInteger(sender.Text)
                If (Trim(sender.Text).Length = 0) Then
                    Call myCShowMessage.ShowWarning("Field ini direset, tidak boleh kosong!!" & ControlChars.NewLine & "Isi field dikembalikan ke defaultnya")
                    tbResetSP.Text = 180
                End If
            Else
                Call myCShowMessage.ShowWarning("Field ini tidak boleh kosong!!" & ControlChars.NewLine & "Isi field dikembalikan ke defaultnya")
                sender.Text = 180
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbResetSP_Validated Error")
        End Try
    End Sub

    'Private Sub btnBrowseImportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseImportExcel.Click
    '    'OK
    '    Try
    '        ofd1.Filter = "Excel file (*.xls,*.xlsx)|*.xls;*.xlsx"
    '        ofd1.FilterIndex = 1
    '        ofd1.ShowDialog()
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBrowseImportExcel_Click Error")
    '    End Try
    'End Sub

    'Private Sub tbNamaFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNamaFile.Click
    '    'OK
    '    Try
    '        ofd1.Filter = "Excel file (*.xls,*.xlsx)|*.xls;*.xlsx"
    '        ofd1.FilterIndex = 1
    '        ofd1.ShowDialog()
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNamaFile_Click Error")
    '    End Try
    'End Sub

    'Private Sub ofd1_FileOk(ByVal sender As Object, ByVal e As ComponentModel.CancelEventArgs) Handles ofd1.FileOk
    '    Try
    '        fileAttachment.path = ofd1.FileName
    '        fileAttachment.name = ofd1.SafeFileName
    '        fileAttachment.extension = ofd1.SafeFileName.Substring(ofd1.SafeFileName.LastIndexOf("."))

    '        tbNamaFile.Text = fileAttachment.name
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ofd1_FileOk Error")
    '    End Try
    'End Sub

    Private Sub tbNamaSimpan_Enter(sender As Object, e As EventArgs) Handles tbNamaSimpan.Enter
        Try

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNamaSimpan_Enter Error")
        End Try
    End Sub

    Private Sub tbNamaSimpan_Validated(sender As Object, e As EventArgs) Handles tbNamaSimpan.Validated
        Try

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNamaSimpan_Validated Error")
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
                Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim myDataTableExportExcel As New DataTable
                Dim xlspath As String
                Dim xlsfilename As String
                Dim xlsLocFile As String
                Dim tblName As String

                If (USER_.lokasi = "ALL" And cboLokasi.SelectedIndex = -1) Then
                    cboLokasi.Focus()
                    Call myCShowMessage.ShowWarning("Tolong tentukan dulu lokasi karyawan yang akan di ekspor datanya ke excel!")
                Else
                    If (rbAktif.Checked) Then
                        tblName = tableName(0)
                    ElseIf (rbHistory.Checked) Then
                        tblName = tableNameLog
                    End If
                    stSQL = "SELECT idk,nip,nama,kelompok,perusahaan,departemen,divisi,bagian,katpenggajian FROM " & tblName & " WHERE lokasi='" & IIf(USER_.lokasi = "ALL", cboLokasi.SelectedValue, myCStringManipulation.SafeSqlLiteral(USER_.lokasi)) & "' GROUP BY idk,nip,nama,kelompok,perusahaan,departemen,divisi,bagian,katpenggajian ORDER BY perusahaan,departemen,divisi,nama;"
                    myDataTableExportExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "MasterKaryawan" & strStatusAktif)

                    xlspath = tbPathSimpan.Text
                    xlsfilename = tbNamaSimpan.Text

                    xlsLocFile = xlspath & xlsfilename & "_" & Format(Now(), "ddMMMyyyy")

                    Call myCFileIO.PopulateSheet(myDataTableExportExcel, xlsLocFile, "Karyawan" & strStatusAktif & " " & Format(Now(), "ddMMMyyyy HHmm"))

                    Call myCShowMessage.ShowInfo("Export ke excel sukses, dengan nama " & xlsfilename & "_" & Format(Now(), "ddMMMyyyy"), "Export Complete")
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

    'Private Function GetIDK(_conn As Object, _comm As Object, _reader As Object, _tblName As String, _kodeField As String, _idField As String, _prefixKode As String, _digitLength As Integer, _incDate As Boolean, _dateValue As Date, _dbType As String) As String
    '    Try
    '        stSQL = "SELECT kode FROM " & CONN_.schemaHRD & ".msgeneral where kategori='jeniskelamin' and keterangan='" & _prefixKode & "' order by kode;"
    '        _prefixKode = myCDBOperation.GetDataIndividual(_conn, _comm, _reader, stSQL)
    '        GetIDK = myCDBOperation.SetDynamicAutoKode(_conn, _comm, _reader, _tblName, _kodeField, _idField, _prefixKode, _digitLength, _incDate, _dateValue, _dbType)
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetIDK Error")
    '        GetIDK = Nothing
    '    End Try
    'End Function

    'Private Sub btnImportData_Click(sender As Object, e As EventArgs) Handles btnProsesImport.Click
    '    'DIPINDAH KE FORM IMPORT DATA
    '    Try
    '        Call myCDBConnection.OpenConn(CONN_.dbMain)
    '        Me.Cursor = Cursors.WaitCursor

    '        Dim prvdrTypeExcel As String
    '        Dim oleConExcel As New OleDb.OleDbConnection
    '        Dim myDataTableExcel As New DataTable
    '        'Dim myDataTableMasterKaryawan As New DataTable
    '        Dim idk As String
    '        Dim created_at As Date

    '        'With myDataTableMasterKaryawan
    '        '    .Columns.Add("idk", GetType(String))
    '        '    .Columns.Add("nik", GetType(String))
    '        '    .Columns.Add("nama", GetType(String))
    '        '    .Columns.Add("jeniskelamin", GetType(String))
    '        '    .Columns.Add("tanggalmasuk", GetType(Date))
    '        '    .Columns.Add("statusbekerja", GetType(String))
    '        '    .Columns.Add("created_at", GetType(Date))
    '        '    .Columns.Add("userid", GetType(String))
    '        'End With

    '        prvdrTypeExcel = myCFileIO.ReadIniFile("EXCEL", "PRVDRTYPE", Application.StartupPath & "\SETTING.ini")
    '        Call myCDBConnection.SetAndOpenConnForExcel(oleConExcel, fileAttachment.path, fileAttachment.extension.Replace(".", ""), prvdrTypeExcel)

    '        stSQL = "SELECT machineid,nama,jeniskelamin,perusahaan,department,tanggalmasuk,statusbekerja,statuskepegawaian,katpenggajian FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE nama is not null ORDER BY nama ASC;"
    '        myDataTableExcel = myCDBOperation.GetDataTableUsingReader(oleConExcel, CONN_.comm, CONN_.reader, stSQL, "T_EXCEL")

    '        created_at = Now
    '        ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"

    '        For i As Integer = 0 To myDataTableExcel.Rows.Count - 1
    '            idk = GetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, CONN_.schemaHRD & ".mskaryawan", "idk", "rid", myDataTableExcel.Rows(i).Item("jeniskelamin"), 3, True, myDataTableExcel.Rows(i).Item("tanggalmasuk"), CONN_.dbType)
    '            newValues = "'" & idk & "','-','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("nama")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("jeniskelamin")) & "','" & Format(myDataTableExcel.Rows(i).Item("tanggalmasuk"), "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("statusbekerja")) & "'," & ADD_INFO_.newValues
    '            newFields = "idk,nik,nama,jeniskelamin,tanggalmasuk,statusbekerja," & ADD_INFO_.newFields
    '            Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".mskaryawan", newValues, newFields)

    '            '==================================================================
    '            'insert ke datatabale sementara gak dipake dulu
    '            'Call myCMiscFunction.Wait(15)
    '            'With myDataTableMasterKaryawan
    '            'Dim newDataRow As DataRow = .NewRow()
    '            'newDataRow("idk") = GetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(0), "idk", "rid", myDataTableExcel.Rows(i).Item("jeniskelamin"), 3, True, myDataTableExcel.Rows(i).Item("tanggalmasuk"), CONN_.dbType)
    '            'newDataRow("nik") = "-"
    '            'newDataRow("nama") = myDataTableExcel.Rows(i).Item("nama")
    '            'newDataRow("jeniskelamin") = myDataTableExcel.Rows(i).Item("jeniskelamin")
    '            'newDataRow("tanggalmasuk") = myDataTableExcel.Rows(i).Item("tanggalmasuk")
    '            'newDataRow("statusbekerja") = myDataTableExcel.Rows(i).Item("statusbekerja")
    '            'newDataRow("created_at") = Now
    '            'newDataRow("userid") = USER_.username
    '            '.Rows.Add(newDataRow)
    '            'End With
    '            '==================================================================

    '            If (i Mod 1000 = 0) Then
    '                GC.Collect()
    '            End If
    '        Next
    '        'Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableMasterKaryawan, CONN_.schemaHRD & ".mskaryawan")

    '        Call myCDBConnection.CloseConn(oleConExcel, -1)

    '        Call myCShowMessage.ShowInfo("IMPORT EXCEL SELESAI!!")
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnImportData_Click Error")
    '    Finally
    '        Me.Cursor = Cursors.Default
    '        Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
    '    End Try
    'End Sub
End Class
