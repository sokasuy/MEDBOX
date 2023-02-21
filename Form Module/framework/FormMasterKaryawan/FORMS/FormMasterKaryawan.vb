Public Class FormMasterKaryawan
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
    Private cmbDgvTanggunganButton As New DataGridViewButtonColumn()
    Private cmbDgvAttachmentButton As New DataGridViewButtonColumn()
    Private cekTambahButton(3) As Boolean
    Private arrDefValues(31) As String
    Private tableName(3) As String

    Private myDataTableCboAgama As New DataTable
    Private myBindingAgama As New BindingSource
    Private myDataTableCboStatus As New DataTable
    Private myBindingStatus As New BindingSource
    Private myDataTableCboGolDarah As New DataTable
    Private myBindingGolDarah As New BindingSource
    Private myDataTableCboPendidikan As New DataTable
    Private myBindingPendidikan As New BindingSource
    Private myDataTableCboLokasi As New DataTable
    Private myBindingLokasi As New BindingSource
    Private myDataTableCboPerusahaan As New DataTable
    Private myBindingPerusahaan As New BindingSource
    Private myDataTableCboDepartemen As New DataTable
    Private myBindingDepartemen As New BindingSource
    Private myDataTableColumnNames As New DataTable
    Private myBindingColumnNames As New BindingSource

    Private isCboPrepared As Boolean
    Private strGender As String
    'Private strStatus As String
    Private strStatusBekerja As String
    Private strBPJSTK As String
    Private digitLength As Integer
    Private enableSubForm(1) As Boolean
    Private strStatusAktif As String

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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterKaryawan Error")
        End Try
    End Sub

    Private Sub FormMasterKaryawan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub SetIDK(_conn As Object, _comm As Object, _reader As Object, _tblName As String, _kodeField As String, _idField As String, _prefixKode As String, _digitLength As Integer, _incDate As Boolean, _dateValue As Date, _dbType As String)
        Try
            Call myCDBConnection.OpenConn(_conn)
            stSQL = "SELECT kode FROM " & CONN_.schemaHRD & ".msgeneral where kategori='jeniskelamin' and keterangan='" & _prefixKode & "' order by kode;"
            _prefixKode = myCDBOperation.GetDataIndividual(_conn, _comm, _reader, stSQL)

            'Semua IDK disimpan dalam 1 table logidkmskaryawan, jadi karyawan yang sudah dihapus pun, kalau sudah pernah dibuat, IDK nya gak boleh kembar!!
            '_tblName = CONN_.schemaHRD & ".logidkmskaryawan"
            '_tblName = tableName(3)
            tbIDK.Text = myCDBOperation.SetDynamicAutoKode(_conn, _comm, _reader, _tblName, _kodeField, _idField, _prefixKode, _digitLength, _incDate, _dateValue, _dbType)

            Call myCDBConnection.CloseConn(_conn, -1)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetIDK Error")
        End Try
    End Sub

    Private Sub FormMasterKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"IDK", "NIK", "NAMA", "ALAMAT", "STATUS", "LOKASI"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 2

            lblTanggalTerakhirKerja.Visible = False
            dtpTerakhirKerja.Visible = False

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            'Dim myDataTableJumlahAnak As New DataTable
            'stSQL = "select idk, count(nama) as jumlahanak from " & CONN_.schemaHRD & ".mstanggungankaryawan where hubungan Like 'Anak%' group by idk order by idk;"
            'myDataTableJumlahAnak = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_JumlahAnak")
            'For i As Integer = 0 To myDataTableJumlahAnak.Rows.Count - 1
            '    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".mskaryawan", "jumlahanak=" & myDataTableJumlahAnak.Rows(i).Item("jumlahanak"), "idk='" & myCStringManipulation.SafeSqlLiteral(myDataTableJumlahAnak.Rows(i).Item("idk")) & "'")
            'Next
            'Call myCShowMessage.ShowInfo("DONE!!")

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='agama' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboAgama, myBindingAgama, cboAgama, "T_" & cboAgama.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='status' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboStatus, myBindingStatus, cboStatus, "T_" & cboStatus.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='goldarah' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboGolDarah, myBindingGolDarah, cboGolDarah, "T_" & cboGolDarah.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='lokasi' " & IIf(USER_.lokasi = "ALL", "", "AND keterangan='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "'") & " order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboLokasi, myBindingLokasi, cboLokasi, "T_" & cboLokasi.Name, "keterangan", "keterangan", isCboPrepared)
            cboLokasi.SelectedIndex = 0

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='perusahaan' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPerusahaan, myBindingPerusahaan, cboPerusahaan, "T_" & cboPerusahaan.Name, "keterangan", "keterangan", isCboPrepared)

            arrCbo = {"STAFF", "NON STAFF", "OUTSOURCE"}
            cboKelompok.Items.AddRange(arrCbo)
            'cboKelompok.SelectedIndex = 0

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='departemen' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboDepartemen, myBindingDepartemen, cboDepartemen, "T_" & cboDepartemen.Name, "keterangan", "keterangan", isCboPrepared)

            stSQL = "SELECT column_name FROM INFORMATION_SCHEMA. COLUMNS WHERE TABLE_NAME = 'mskaryawan' and column_name NOT IN('created_at','updated_at') ORDER BY column_name ASC;"
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
                'TANGGUNGAN
                foundRows = USER_.T_USER_RIGHT.Select("formname='FormMasterTanggunganKaryawan'")
                If (foundRows.Length = 0) Then
                    enableSubForm(1) = False
                Else
                    enableSubForm(1) = True
                End If
            End If

            tableName(0) = CONN_.schemaHRD & ".mskaryawan"
            tableName(1) = CONN_.schemaHRD & ".mskaryawanaktif"
            tableName(2) = CONN_.schemaHRD & ".logkaryawanaktif"
            tableName(3) = CONN_.schemaHRD & ".logidkmskaryawan"
            digitLength = 3

            rbPria.Checked = True
            rbAktif.Checked = True
            'rbSingle.Checked = True
            dtpSertifikat.Visible = False

            isDataPrepared = True

            Call CheckAndBackupKaryawanResign()

            Call SetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(3), "idk", "rid", strGender, digitLength, True, dtpTanggalMasuk.Value.Date, CONN_.dbType)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterKaryawan_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormMasterKaryawan_KeyDown(sender As Object, e As KeyEventArgs) Handles tbIDK.KeyDown, dtpTanggalMasuk.KeyDown, dtpTerakhirKerja.KeyDown, cboStatus.KeyDown, tbNIK.KeyDown, tbNama.KeyDown, tbJumlahAnak.KeyDown, cboStatus.KeyDown, tbTempatLahir.KeyDown, dtpTanggalLahir.KeyDown, tbAlamat.KeyDown, mtbNPWP.KeyDown, tbNamaBerdasarNPWP.KeyDown, tbAlamatBerdasarNPWP.KeyDown, tbNoKK.KeyDown, cboAgama.KeyDown, cboGolDarah.KeyDown, tbNoHP.KeyDown, tbEmail.KeyDown, tbPendidikan.KeyDown, tbTahunLulus.KeyDown, tbLulusanDari.KeyDown, tbNomerBPJSTenagaKerja.KeyDown, tbNomerBPJSKesehatan.KeyDown, tbJaminan.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown, cbBPJSKesehatan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbJaminan) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterBarang_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    Private Sub CheckAndBackupKaryawanResign()
        Try
            Dim myDataTableIDK As New DataTable
            'Dim tableName(2) As String
            Dim oldNIP As String

            'tableName(0) = CONN_.schemaHRD & ".mskaryawan"
            'tableName(1) = CONN_.schemaHRD & ".mskaryawanaktif"
            'tableName(2) = CONN_.schemaHRD & ".logkaryawanaktif"

            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT h.idk,h.statusbekerja,h.nama,h.tanggalterakhirbekerja FROM " & tableName(0) & " as h inner join " & tableName(1) & " as d on h.idk=d.idk WHERE h.statusbekerja<>'AKTIF';"
            myDataTableIDK = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Karyawan")
            For i As Short = 0 To myDataTableIDK.Rows.Count - 1
                If (CDate(myDataTableIDK.Rows(i).Item("tanggalterakhirbekerja")) < Now.Date) Then
                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau memproses backup data karyawan " & myDataTableIDK.Rows(i).Item("nama") & " yang " & myDataTableIDK.Rows(i).Item("statusbekerja") & " pada tanggal " & myDataTableIDK.Rows(i).Item("tanggalterakhirbekerja") & "?")
                    If (isConfirm = DialogResult.Yes) Then
                        'MsgBox(myDataTableIDK.Rows(i).Item("nama"))
                        'Jika tanggal berhenti sudah lewat, maka akan langsung di backup
                        'Untuk data di mskaryawanaktif dipindah ke logkaryawan

                        'Ambil NIP nya dulu untuk update data di msposisikaryawan
                        oldNIP = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "nip", tableName(1),, "idk='" & myCStringManipulation.SafeSqlLiteral(myDataTableIDK.Rows(i).Item("idk")) & "'", CONN_.dbType)
                        'non aktifkan di msposisikaryawan
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".msposisikaryawan", "aktif='False',tglselesaimenjabat='" & Format(dtpTerakhirKerja.Value.Date, "dd-MMM-yyyy") & "'", "nip='" & myCStringManipulation.SafeSqlLiteral(oldNIP) & "'")

                        stSQL = "INSERT INTO " & tableName(2) & " (idk,nip,fpid,nama,kelompok,perusahaan,departemen,divisi,bagian,lokasi,statuskepegawaian,katpenggajian,kontrakke,tglmulaikontrak,tglselesaikontrak,hariresetsp,created_at,updated_at,userid) 
                                (SELECT idk,nip,fpid,nama,kelompok,perusahaan,departemen,divisi,bagian,lokasi,statuskepegawaian,katpenggajian,kontrakke,tglmulaikontrak,tglselesaikontrak,hariresetsp,created_at,updated_at,userid FROM " & tableName(1) & " WHERE idk='" & myCStringManipulation.SafeSqlLiteral(myDataTableIDK.Rows(i).Item("idk")) & "')"
                        Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)
                        'Hapus di tabel mskaryawanaktif
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(1), "idk='" & myCStringManipulation.SafeSqlLiteral(myDataTableIDK.Rows(i).Item("idk")) & "'")
                    End If
                End If
            Next
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "CheckAndBackupKaryawanResign Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain)
        End Try
    End Sub

    Private Sub SetDGV(myConn As Object, myComm As Object, myReader As Object, offSet As Integer, ByRef myDataTable As DataTable, ByRef myBindingTable As BindingSource, mKriteria As String, Optional gantiKriteria As Boolean = False, Optional sortingCols As String = Nothing, Optional sortingType As String = Nothing)
        Try
            Dim batas As Integer
            Dim mJumlah As Integer
            Dim mSelectedCriteria As String
            Dim mGroupCriteria As String = Nothing
            Dim mStatusBekerja As String

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mStatusBekerja = IIf(rbFilterAktif.Checked, "((upper(tbl.statusbekerja) = 'AKTIF') or (tbl.tanggalberhentibekerja>CURRENT_DATE))", "(upper(tbl.statusbekerja) IN ('RESIGN','PENSIUN'))")

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")
            If (cboPerusahaan.SelectedIndex <> -1) Then
                mGroupCriteria = " AND (tbl2.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "')"
            End If
            If (cboKelompok.SelectedIndex <> -1) Then
                mGroupCriteria &= " AND (tbl2.kelompok='" & myCStringManipulation.SafeSqlLiteral(cboKelompok.SelectedItem) & "')"
            End If
            If (cboDepartemen.SelectedIndex <> -1) Then
                mGroupCriteria &= " AND (tbl2.departemen='" & myCStringManipulation.SafeSqlLiteral(cboDepartemen.SelectedValue) & "')"
            End If

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                'Dim tampTotalRecords As Integer
                banyakPages = 0
                mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                'Kalau aktif pakai tabel mskaryawanaktif, kalau sudah tidak aktif pakai tabel logkaryawanaktif
                stSQL = "SELECT count(*) FROM " & tableName(0) & " as tbl left join " & IIf(rbFilterAktif.Checked, tableName(1), tableName(2)) & " as tbl2 on tbl.idk=tbl2.idk WHERE " & mStatusBekerja & " AND (upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') " & IIf(USER_.lokasi = "ALL", "", "AND (tbl.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "') ") & mGroupCriteria & ";"

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

            'Kalau aktif pakai tabel mskaryawanaktif, kalau sudah tidak aktif pakai tabel logkaryawanaktif
            stSQL = "SELECT rid,idk,nik,nama,jeniskelamin as jenis_kelamin,alamat,tempatlahir as tempat_lahir,tanggallahir as tanggal_lahir,tanggalmasuk as tanggal_masuk,npwp,namaberdasarnpwp as nama_berdasar_npwp,alamatberdasarnpwp as alamat_berdasar_npwp,nokk as no_kk,status,jumlahanak as jumlah_anak,nohp as no_hp,email,agama,goldarah as gol_darah,pendidikan,lulusandari as lulusan_dari,tahunlulus as tahun_lulus,bpjstk as bpjs_tk,nobpjstk as no_bpjs_tk,bpjskesehatan as bpjs_kesehatan,nobpjskesehatan as no_bpjs_kesehatan,jaminan,statusbekerja as status_bekerja,tanggalberhentibekerja as tanggal_berhenti_bekerja,tanggalterakhirbekerja as tanggal_terakhir_bekerja,lokasi,sertifikat,tanggalsertifikat as tanggal_sertifikat,created_at,updated_at " &
                        "FROM ( " &
                            "SELECT sub.rid,sub.idk,sub.nik,sub.nama,sub.jeniskelamin,sub.alamat,sub.tempatlahir,sub.tanggallahir,sub.tanggalmasuk,sub.npwp,sub.namaberdasarnpwp,sub.alamatberdasarnpwp,sub.nokk,sub.status,sub.jumlahanak,sub.nohp,sub.email,sub.agama,sub.goldarah,sub.pendidikan,sub.lulusandari,sub.tahunlulus,sub.bpjstk,sub.nobpjstk,sub.bpjskesehatan,sub.nobpjskesehatan,sub.jaminan,sub.statusbekerja,sub.tanggalberhentibekerja,sub.tanggalterakhirbekerja,sub.lokasi,sub.sertifikat,sub.tanggalsertifikat,sub.created_at,sub.updated_at " &
                            "FROM ( " &
                                "SELECT tbl.rid,tbl.idk,tbl.nik,tbl.nama,tbl.jeniskelamin,tbl.alamat,tbl.tempatlahir,tbl.tanggallahir,tbl.tanggalmasuk,tbl.npwp,tbl.namaberdasarnpwp,tbl.alamatberdasarnpwp,tbl.nokk,tbl.status,tbl.jumlahanak,tbl.nohp,tbl.email,tbl.agama,tbl.goldarah,tbl.pendidikan,tbl.lulusandari,tbl.tahunlulus,tbl.bpjstk,tbl.nobpjstk,tbl.bpjskesehatan,tbl.nobpjskesehatan,tbl.jaminan,tbl.statusbekerja,tbl.tanggalberhentibekerja,tbl.tanggalterakhirbekerja,tbl.lokasi,tbl.sertifikat,tbl.tanggalsertifikat,tbl.created_at,tbl.updated_at " &
                                "FROM " & tableName(0) & " as tbl left join " & IIf(rbFilterAktif.Checked, tableName(1), tableName(2)) & " as tbl2 on tbl.idk=tbl2.idk " &
                                "WHERE " & mStatusBekerja & " AND ((upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & IIf(USER_.lokasi = "ALL", "", "AND (tbl.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "') ") & mGroupCriteria & " " &
                                "ORDER BY " & IIf(IsNothing(sortingCols), "(case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC ", sortingCols & " " & sortingType) & " " &
                                "LIMIT " & offSet &
                                ") sub " &
                            "ORDER BY " & IIf(IsNothing(sortingCols), "(case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC ", sortingCols & " " & IIf(sortingType = "ASC", "DESC", "ASC")) & " " &
                            "LIMIT " & batas &
                        ") subOrdered " &
                        "ORDER BY " & IIf(IsNothing(sortingCols), "(case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC ", sortingCols & " " & sortingType) & ";"

            myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "TBL " & lblTitle.Text)
            myBindingTable.DataSource = myDataTable

            If (rbFilterHistory.Checked) Then
                dgvView.DataSource = Nothing
                dgvView.Columns.Clear()
            End If

            With dgvView
                .DataSource = myBindingTable
                .ReadOnly = True

                .Columns("rid").Visible = False

                .Columns("rid").Frozen = True
                .Columns("idk").Frozen = True
                .Columns("nik").Frozen = True
                .Columns("nama").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("idk").Width = 75
                .Columns("nik").Width = 110
                .Columns("nama").Width = 125
                .Columns("jenis_kelamin").Width = 80
                .Columns("alamat").Width = 200
                .Columns("tempat_lahir").Width = 100
                .Columns("tanggal_lahir").Width = 80
                .Columns("tanggal_masuk").Width = 80
                .Columns("npwp").Width = 120
                .Columns("nama_berdasar_npwp").Width = 125
                .Columns("alamat_berdasar_npwp").Width = 200
                .Columns("no_kk").Width = 110
                .Columns("status").Width = 90
                .Columns("jumlah_anak").Width = 80
                .Columns("no_hp").Width = 100
                .Columns("email").Width = 100
                .Columns("agama").Width = 80
                .Columns("gol_darah").Width = 60
                .Columns("pendidikan").Width = 100
                .Columns("lulusan_dari").Width = 100
                .Columns("tahun_lulus").Width = 70
                .Columns("bpjs_tk").Width = 80
                .Columns("no_bpjs_tk").Width = 110
                .Columns("bpjs_kesehatan").Width = 70
                .Columns("no_bpjs_kesehatan").Width = 110
                .Columns("jaminan").Width = 100
                .Columns("status_bekerja").Width = 80
                .Columns("tanggal_berhenti_bekerja").Width = 80
                .Columns("tanggal_terakhir_bekerja").Width = 80
                .Columns("lokasi").Width = 70
                .Columns("sertifikat").Width = 70
                .Columns("tanggal_sertifikat").Width = 80

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next

                .Columns("jumlah_anak").HeaderText = "ANAK"
                .Columns("tahun_lulus").HeaderText = "LULUS"

                .Columns("tanggal_lahir").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tanggal_masuk").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tanggal_berhenti_bekerja").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tanggal_sertifikat").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                .Font = New Font("Arial", 8, FontStyle.Regular)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End With

            If (rbFilterAktif.Checked) Then
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

                With cmbDgvTanggunganButton
                    If Not (cekTambahButton(2)) Then
                        .HeaderText = "TANGGUNGAN"
                        .Name = "tanggungan"
                        .Text = "Tanggungan"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = dgvView.ColumnCount
                        dgvView.Columns.Add(cmbDgvTanggunganButton)
                        dgvView.Columns("tanggungan").Width = 90
                        cekTambahButton(2) = True
                        .Visible = enableSubForm(1)
                    End If
                    .HeaderCell.Style.BackColor = Color.SkyBlue
                End With

                With cmbDgvAttachmentButton
                    If Not (cekTambahButton(3)) Then
                        .HeaderText = "ATTACHMENT"
                        .Name = "attachment"
                        .Text = "Attachment"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = dgvView.ColumnCount
                        dgvView.Columns.Add(cmbDgvAttachmentButton)
                        dgvView.Columns("attachment").Width = 90
                        cekTambahButton(3) = True
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
            btnIsiCepat.Enabled = True
            cboLokasi.SelectedIndex = 0
            Call SetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(3), "idk", "rid", strGender, digitLength, True, dtpTanggalMasuk.Value.Date, CONN_.dbType)
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
            If (dgvView.RowCount > 0) Then
                If (e.RowIndex = -1) Then
                    Exit Sub
                End If

                If (rbFilterAktif.Checked) Then
                    If (e.ColumnIndex = dgvView.Columns("delete").Index) Then
                        Me.Cursor = Cursors.WaitCursor
                        Call myCDBConnection.OpenConn(CONN_.dbMain)

                        Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data karyawan " & dgvView.CurrentRow.Cells("idk").Value & " - " & dgvView.CurrentRow.Cells("nama").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                        If (isConfirm = DialogResult.Yes) Then
                            'PER TANGGAL 15 MARET 2022, TOMBOL DELETE DIGANTI JADI UPDATE STATUS MENJADI RESIGN
                            'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "statusbekerja='RESIGN',tanggalterakhirbekerja='" & Format(Now.Date.AddDays(-1), "dd-MMM-yyyy") & "',tanggalberhentibekerja='" & Format(Now.Date(), "dd-MMM-yyyy") & "',updated_at=clock_timestamp(),userid='" & USER_.username & "'", "rid=" & dgvView.CurrentRow.Cells("rid").Value)

                            'Untuk data di mskaryawanaktif dipindah ke logkaryawan
                            stSQL = "INSERT INTO hrd.logkaryawanaktif (idk,nip,fpid,nama,kelompok,perusahaan,departemen,divisi,bagian,lokasi,statuskepegawaian,katpenggajian,kontrakke,tglmulaikontrak,tglselesaikontrak,hariresetsp,created_at,updated_at,userid) 
                                (SELECT idk,nip,fpid,nama,kelompok,perusahaan,departemen,divisi,bagian,lokasi,statuskepegawaian,katpenggajian,kontrakke,tglmulaikontrak,tglselesaikontrak,hariresetsp,created_at,updated_at,userid FROM " & tableName(1) & " WHERE idk='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("idk").Value) & "')"
                            Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)
                            'Hapus di tabel mskaryawanaktif
                            Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(1), "idk='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("idk").Value) & "'")

                            Call myCShowMessage.ShowDeletedMsg("Karyawan " & dgvView.CurrentRow.Cells("idk").Value & " - " & dgvView.CurrentRow.Cells("nama").Value)
                            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
                        Else
                            Call myCShowMessage.ShowInfo("Penghapusan karyawan " & dgvView.CurrentRow.Cells("idk").Value & " - " & dgvView.CurrentRow.Cells("nama").Value & " dibatalkan oleh user")
                        End If
                    ElseIf (e.ColumnIndex = dgvView.Columns("tanggungan").Index) Then
                        Dim frmMasterTanggunganKaryawan As New FormMasterTanggunganKaryawan.FormMasterTanggunganKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, dgvView.CurrentRow.Cells("idk").Value, dgvView.CurrentRow.Cells("nama").Value)
                        Call myCFormManipulation.GoToForm(Me.MdiParent, frmMasterTanggunganKaryawan)
                    ElseIf (e.ColumnIndex = dgvView.Columns("attachment").Index) Then
                        Dim frmAttachmentKaryawan As New FormAttachmentKaryawan.FormAttachmentKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, dgvView.CurrentRow.Cells("idk").Value, dgvView.CurrentRow.Cells("nama").Value)
                        Call myCFormManipulation.GoToForm(Me.MdiParent, frmAttachmentKaryawan)
                    ElseIf (e.ColumnIndex = dgvView.Columns("edit").Index) Then
                        isNew = False
                        lblEntryType.Text = "EDIT"
                        isDataPrepared = False
                        btnIsiCepat.Enabled = False
                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "edit")

                        For i As Integer = 0 To arrDefValues.Count - 1
                            arrDefValues(i) = Nothing
                        Next

                        'RecID
                        arrDefValues(0) = dgvView.CurrentRow.Cells("rid").Value
                        'IDK
                        If Not IsDBNull(dgvView.CurrentRow.Cells("idk").Value) Then
                            tbIDK.Text = dgvView.CurrentRow.Cells("idk").Value
                            arrDefValues(1) = dgvView.CurrentRow.Cells("idk").Value
                            tbIDK.ReadOnly = True
                        End If
                        'NIK
                        If Not IsDBNull(dgvView.CurrentRow.Cells("nik").Value) Then
                            tbNIK.Text = dgvView.CurrentRow.Cells("nik").Value
                            arrDefValues(2) = dgvView.CurrentRow.Cells("nik").Value
                            lblDigitNIK.Text = tbNIK.Text.Length
                        End If
                        'Nama
                        If Not IsDBNull(dgvView.CurrentRow.Cells("nama").Value) Then
                            tbNama.Text = dgvView.CurrentRow.Cells("nama").Value
                            arrDefValues(3) = dgvView.CurrentRow.Cells("nama").Value
                        End If
                        'Jenis Kelamin
                        If Not IsDBNull(dgvView.CurrentRow.Cells("jenis_kelamin").Value) Then
                            If (dgvView.CurrentRow.Cells("jenis_kelamin").Value = "PRIA") Then
                                rbPria.Checked = True
                            ElseIf (dgvView.CurrentRow.Cells("jenis_kelamin").Value = "WANITA") Then
                                rbWanita.Checked = True
                            End If
                            arrDefValues(4) = dgvView.CurrentRow.Cells("jenis_kelamin").Value
                            strGender = dgvView.CurrentRow.Cells("jenis_kelamin").Value
                        End If
                        'Alamat
                        If Not IsDBNull(dgvView.CurrentRow.Cells("alamat").Value) Then
                            tbAlamat.Text = dgvView.CurrentRow.Cells("alamat").Value
                            arrDefValues(5) = dgvView.CurrentRow.Cells("alamat").Value
                        End If
                        'Tempat Lahir
                        If Not IsDBNull(dgvView.CurrentRow.Cells("tempat_lahir").Value) Then
                            tbTempatLahir.Text = dgvView.CurrentRow.Cells("tempat_lahir").Value
                            arrDefValues(6) = dgvView.CurrentRow.Cells("tempat_lahir").Value
                        End If
                        'Tanggal Lahir
                        If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal_lahir").Value) Then
                            dtpTanggalLahir.Value = dgvView.CurrentRow.Cells("tanggal_lahir").Value
                            arrDefValues(7) = dgvView.CurrentRow.Cells("tanggal_lahir").Value
                        End If
                        'Tanggal Masuk
                        If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal_masuk").Value) Then
                            dtpTanggalMasuk.Value = Format(dgvView.CurrentRow.Cells("tanggal_masuk").Value, "dd-MMM-yyyy")
                            arrDefValues(8) = dgvView.CurrentRow.Cells("tanggal_masuk").Value
                        End If
                        'NPWP
                        If Not IsDBNull(dgvView.CurrentRow.Cells("npwp").Value) Then
                            'tbNPWP.Text = dgvView.CurrentRow.Cells("npwp").Value
                            mtbNPWP.Text = dgvView.CurrentRow.Cells("npwp").Value
                            arrDefValues(9) = dgvView.CurrentRow.Cells("npwp").Value
                        End If
                        'Nama berdasar NPWP
                        If Not IsDBNull(dgvView.CurrentRow.Cells("nama_berdasar_npwp").Value) Then
                            tbNamaBerdasarNPWP.Text = dgvView.CurrentRow.Cells("nama_berdasar_npwp").Value
                            arrDefValues(10) = dgvView.CurrentRow.Cells("nama_berdasar_npwp").Value
                        End If
                        'Alamat berdasar NPWP
                        If Not IsDBNull(dgvView.CurrentRow.Cells("alamat_berdasar_npwp").Value) Then
                            tbAlamatBerdasarNPWP.Text = dgvView.CurrentRow.Cells("alamat_berdasar_npwp").Value
                            arrDefValues(11) = dgvView.CurrentRow.Cells("alamat_berdasar_npwp").Value
                        End If
                        'No KK
                        If Not IsDBNull(dgvView.CurrentRow.Cells("no_kk").Value) Then
                            tbNoKK.Text = dgvView.CurrentRow.Cells("no_kk").Value
                            arrDefValues(12) = dgvView.CurrentRow.Cells("no_kk").Value
                            lblDigitKK.Text = tbNoKK.Text.Length
                        End If
                        'Status (SINGLE/MENIKAH/CERAI MATI/HIDUP BERPISAH)
                        If Not IsDBNull(dgvView.CurrentRow.Cells("status").Value) Then
                            For i As Integer = 0 To cboStatus.Items.Count - 1
                                If (DirectCast(cboStatus.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("status").Value) Then
                                    cboStatus.SelectedIndex = i
                                    arrDefValues(13) = dgvView.CurrentRow.Cells("status").Value
                                End If
                            Next
                        End If
                        'No HP
                        If Not IsDBNull(dgvView.CurrentRow.Cells("no_hp").Value) Then
                            tbNoHP.Text = dgvView.CurrentRow.Cells("no_hp").Value
                            arrDefValues(14) = dgvView.CurrentRow.Cells("no_hp").Value
                        End If
                        'Email
                        If Not IsDBNull(dgvView.CurrentRow.Cells("email").Value) Then
                            tbEmail.Text = dgvView.CurrentRow.Cells("email").Value
                            arrDefValues(15) = dgvView.CurrentRow.Cells("email").Value
                        End If
                        'Agama
                        If Not IsDBNull(dgvView.CurrentRow.Cells("agama").Value) Then
                            For i As Integer = 0 To cboAgama.Items.Count - 1
                                If (DirectCast(cboAgama.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("agama").Value) Then
                                    cboAgama.SelectedIndex = i
                                    arrDefValues(16) = dgvView.CurrentRow.Cells("agama").Value
                                End If
                            Next
                        End If
                        'Gol Darah
                        If Not IsDBNull(dgvView.CurrentRow.Cells("gol_darah").Value) Then
                            For i As Integer = 0 To cboGolDarah.Items.Count - 1
                                If (DirectCast(cboGolDarah.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("gol_darah").Value) Then
                                    cboGolDarah.SelectedIndex = i
                                    arrDefValues(17) = dgvView.CurrentRow.Cells("gol_darah").Value
                                End If
                            Next
                        End If
                        'Pendidikan
                        If Not IsDBNull(dgvView.CurrentRow.Cells("pendidikan").Value) Then
                            tbPendidikan.Text = dgvView.CurrentRow.Cells("pendidikan").Value
                            arrDefValues(18) = dgvView.CurrentRow.Cells("pendidikan").Value
                        End If
                        'Lulusan Dari
                        If Not IsDBNull(dgvView.CurrentRow.Cells("lulusan_dari").Value) Then
                            tbLulusanDari.Text = dgvView.CurrentRow.Cells("lulusan_dari").Value
                            arrDefValues(19) = dgvView.CurrentRow.Cells("lulusan_dari").Value
                        End If
                        'Tahun lulus
                        If Not IsDBNull(dgvView.CurrentRow.Cells("tahun_lulus").Value) Then
                            tbTahunLulus.Text = dgvView.CurrentRow.Cells("tahun_lulus").Value
                            arrDefValues(20) = dgvView.CurrentRow.Cells("tahun_lulus").Value
                        End If
                        'BPJS TK
                        If Not IsDBNull(dgvView.CurrentRow.Cells("bpjs_tk").Value) Then
                            Dim bpjstk() As String
                            bpjstk = dgvView.CurrentRow.Cells("bpjs_tk").Value.ToString.Split(",")

                            For i As Integer = 0 To clbBPJSTK.Items.Count - 1
                                clbBPJSTK.SetItemChecked(i, False)
                            Next

                            For i As Integer = 0 To bpjstk.Count - 1
                                clbBPJSTK.SetItemChecked(clbBPJSTK.Items.IndexOf(bpjstk(i)), True)
                            Next
                            arrDefValues(21) = dgvView.CurrentRow.Cells("bpjs_tk").Value
                            strBPJSTK = dgvView.CurrentRow.Cells("bpjs_tk").Value
                        End If
                        'Nomer BPJS TK
                        If Not IsDBNull(dgvView.CurrentRow.Cells("no_bpjs_tk").Value) Then
                            tbNomerBPJSTenagaKerja.Text = dgvView.CurrentRow.Cells("no_bpjs_tk").Value
                            arrDefValues(27) = dgvView.CurrentRow.Cells("no_bpjs_tk").Value
                        End If
                        'BPJS Kesehatan
                        If Not IsDBNull(dgvView.CurrentRow.Cells("bpjs_kesehatan").Value) Then
                            cbBPJSKesehatan.Checked = dgvView.CurrentRow.Cells("bpjs_kesehatan").Value
                            arrDefValues(22) = dgvView.CurrentRow.Cells("bpjs_kesehatan").Value
                        End If
                        'Nomer BPJS Kesehatan
                        If Not IsDBNull(dgvView.CurrentRow.Cells("no_bpjs_kesehatan").Value) Then
                            tbNomerBPJSKesehatan.Text = dgvView.CurrentRow.Cells("no_bpjs_kesehatan").Value
                            arrDefValues(28) = dgvView.CurrentRow.Cells("no_bpjs_kesehatan").Value
                        End If
                        'Jaminan
                        If Not IsDBNull(dgvView.CurrentRow.Cells("jaminan").Value) Then
                            tbJaminan.Text = dgvView.CurrentRow.Cells("jaminan").Value
                            arrDefValues(23) = dgvView.CurrentRow.Cells("jaminan").Value
                        End If
                        'Status Bekerja (AKTIF/RESIGN/PENSIUN)
                        If Not IsDBNull(dgvView.CurrentRow.Cells("status_bekerja").Value) Then
                            If (dgvView.CurrentRow.Cells("status_bekerja").Value = "AKTIF") Then
                                rbAktif.Checked = True
                            ElseIf (dgvView.CurrentRow.Cells("status_bekerja").Value = "RESIGN") Then
                                rbResign.Checked = True
                            ElseIf (dgvView.CurrentRow.Cells("status_bekerja").Value = "PENSIUN") Then
                                rbPensiun.Checked = True
                            End If
                            arrDefValues(24) = dgvView.CurrentRow.Cells("status_bekerja").Value
                            strStatusBekerja = dgvView.CurrentRow.Cells("status_bekerja").Value
                        End If
                        'Tanggal Berhenti Bekerja
                        If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal_terakhir_bekerja").Value) Then
                            dtpTerakhirKerja.Value = dgvView.CurrentRow.Cells("tanggal_terakhir_bekerja").Value
                            arrDefValues(25) = dgvView.CurrentRow.Cells("tanggal_terakhir_bekerja").Value
                        Else
                            arrDefValues(25) = Nothing
                        End If
                        'JumlahAnak
                        If Not IsDBNull(dgvView.CurrentRow.Cells("jumlah_anak").Value) Then
                            tbJumlahAnak.Text = dgvView.CurrentRow.Cells("jumlah_anak").Value
                            arrDefValues(26) = dgvView.CurrentRow.Cells("jumlah_anak").Value
                        End If
                        'Lokasi
                        If Not IsDBNull(dgvView.CurrentRow.Cells("lokasi").Value) Then
                            For i As Integer = 0 To cboLokasi.Items.Count - 1
                                If (DirectCast(cboLokasi.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("lokasi").Value) Then
                                    cboLokasi.SelectedIndex = i
                                    arrDefValues(29) = dgvView.CurrentRow.Cells("lokasi").Value
                                End If
                            Next
                        End If
                        'Sertifikat
                        If Not IsDBNull(dgvView.CurrentRow.Cells("sertifikat").Value) Then
                            cbSertifikat.Checked = dgvView.CurrentRow.Cells("sertifikat").Value
                            arrDefValues(30) = dgvView.CurrentRow.Cells("sertifikat").Value
                        End If
                        'Tanggal Sertifikat
                        If Not IsDBNull(dgvView.CurrentRow.Cells("tanggal_sertifikat").Value) Then
                            dtpSertifikat.Value = dgvView.CurrentRow.Cells("tanggal_sertifikat").Value
                            arrDefValues(31) = dgvView.CurrentRow.Cells("tanggal_sertifikat").Value
                        Else
                            arrDefValues(31) = Nothing
                        End If
                        isDataPrepared = True
                    End If
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
            mtbNPWP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            'MsgBox("Exclude Prompt and Literals: " & mtbNPWP.Text & " Panjang: " & Trim(mtbNPWP.Text).Length)
            If (mtbNPWP.MaskFull) Then
                'Kalau Full maka literalnya semua diikutkan
                mtbNPWP.TextMaskFormat = MaskFormat.IncludeLiterals
                'MsgBox("Include Literals: " & Trim(mtbNPWP.Text) & " Panjang: " & Trim(mtbNPWP.Text).Length)
            End If
            If (Trim(tbIDK.Text).Length > 0 And Trim(tbNIK.Text).Length > 0 And Trim(tbNama.Text).Length > 0 And Trim(tbAlamat.Text).Length > 0 And cboStatus.SelectedIndex <> -1 And (lblDigitNIK.Text = "16" Or tbNIK.Text = "-") And (lblDigitKK.Text = "16" Or tbNoKK.Text = "-") And (Trim(mtbNPWP.Text).Length = 20 Or Trim(mtbNPWP.Text).Length = 0) And cboLokasi.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                'Dim created_at As Date
                'created_at = Now
                'ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"
                If isNew Then
                    'CREATE NEW
                    If (Trim(tbNIK.Text) = "-") Then
                        'Jika NIK diisi - maka boleh diinputkan langsung tanpa dilakukan pengecekkan kembar
                        isExist = False
                    Else
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "nik='" & myCStringManipulation.SafeSqlLiteral(tbNIK.Text) & "'")
                    End If
                    If Not isExist Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(3), "idk='" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "'")
                        While (isExist)
                            'Buat memastikan IDK tidak kembar
                            Call SetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(3), "idk", "rid", strGender, digitLength, True, dtpTanggalMasuk.Value.Date, CONN_.dbType)
                            Call myCDBConnection.OpenConn(CONN_.dbMain)
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(3), "idk='" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "'")
                        End While

                        'CREATE NEW
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "','" & myCStringManipulation.SafeSqlLiteral(tbNIK.Text) & "','" & myCStringManipulation.SafeSqlLiteral(tbNama.Text) & "','" & Format(dtpTanggalLahir.Value.Date, "dd-MMM-yyyy") & "','" & Format(dtpTanggalMasuk.Value.Date, "dd-MMM-yyyy") & "','" & strGender & "','" & myCStringManipulation.SafeSqlLiteral(cboStatus.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(strStatusBekerja) & "','" & cbBPJSKesehatan.Checked & "','" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "'," & ADD_INFO_.newValues
                        newFields = "idk,nik,nama,tanggallahir,tanggalmasuk,jeniskelamin,status,statusbekerja,bpjskesehatan,lokasi," & ADD_INFO_.newFields
                        If Trim(tbJumlahAnak.Text).Length > 0 Then
                            newValues &= "," & tbJumlahAnak.Text
                            newFields &= ",jumlahanak"
                        End If
                        If Trim(tbAlamat.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbAlamat.Text) & "'"
                            newFields &= ",alamat"
                        End If
                        If Trim(tbTempatLahir.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbTempatLahir.Text) & "'"
                            newFields &= ",tempatlahir"
                        End If
                        If Trim(mtbNPWP.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(mtbNPWP.Text) & "'"
                            newFields &= ",npwp"
                        End If
                        If Trim(tbNamaBerdasarNPWP.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbNamaBerdasarNPWP.Text) & "'"
                            newFields &= ",namaberdasarnpwp"
                        End If
                        If Trim(tbAlamatBerdasarNPWP.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbAlamatBerdasarNPWP.Text) & "'"
                            newFields &= ",alamatberdasarnpwp"
                        End If
                        If Trim(tbNoKK.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbNoKK.Text) & "'"
                            newFields &= ",nokk"
                        End If
                        If Trim(tbNoHP.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbNoHP.Text) & "'"
                            newFields &= ",nohp"
                        End If
                        If Trim(tbEmail.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbEmail.Text) & "'"
                            newFields &= ",email"
                        End If
                        If cboAgama.SelectedIndex <> -1 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboAgama.SelectedValue) & "'"
                            newFields &= ",agama"
                        End If
                        If cboGolDarah.SelectedIndex <> -1 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboGolDarah.SelectedValue) & "'"
                            newFields &= ",goldarah"
                        End If
                        If Trim(tbPendidikan.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbPendidikan.Text) & "'"
                            newFields &= ",pendidikan"
                        End If
                        If Trim(tbLulusanDari.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbLulusanDari.Text) & "'"
                            newFields &= ",lulusandari"
                        End If
                        If Trim(tbTahunLulus.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbTahunLulus.Text) & "'"
                            newFields &= ",tahunlulus"
                        End If
                        If Not IsNothing(strBPJSTK) Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(strBPJSTK) & "'"
                            newFields &= ",bpjstk"
                        End If
                        If Trim(tbNomerBPJSTenagaKerja.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbNomerBPJSTenagaKerja.Text) & "'"
                            newFields &= ",nobpjstk"
                        End If
                        If Trim(tbNomerBPJSKesehatan.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbNomerBPJSKesehatan.Text) & "'"
                            newFields &= ",nobpjskesehatan"
                        End If
                        If Trim(tbJaminan.Text).Length > 0 Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbJaminan.Text) & "'"
                            newFields &= ",jaminan"
                        End If
                        If (strStatusBekerja <> "AKTIF") Then
                            newValues &= ",'" & Format(dtpTerakhirKerja.Value.Date, "dd-MMM-yyyy") & "','" & Format(dtpTerakhirKerja.Value.Date.AddDays(1), "dd-MMM-yyyy") & "'"
                            newFields &= ",tanggalterakhirbekerja,tanggalberhentibekerja"
                        End If
                        If cbSertifikat.Checked Then
                            newValues &= ",'" & cbSertifikat.Checked & "','" & Format(dtpSertifikat.Value.Date, "dd-MMM-yyyy") & "'"
                            newFields &= ",sertifikat,tanggalsertifikat"
                        End If
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(0), newValues, newFields)

                        'INSERT ke logidkmskaryawan
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "'"
                        newFields = "idk"
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(3), newValues, newFields)

                        Call myCShowMessage.ShowSavedMsg("Karyawan " & Trim(tbNama.Text) & " dengan NIK " & Trim(tbNIK.Text))
                        Call btnTampilkan_Click(sender, e)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowWarning("Karyawan dengan NIK " & Trim(tbNIK.Text) & " sudah terdaftar!!")
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    updateString = Nothing
                    foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    If (arrDefValues(2) <> Trim(tbNIK.Text)) Then
                        If (Trim(tbNIK.Text) = "-") Then
                            isExist = False
                        Else
                            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "nik='" & myCStringManipulation.SafeSqlLiteral(tbNIK.Text) & "' and rid<>" & arrDefValues(0))
                        End If
                        If Not isExist Then
                            updateString = "nik='" & myCStringManipulation.SafeSqlLiteral(tbNIK.Text) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nik") = Trim(tbNIK.Text)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Karyawan dengan nik " & Trim(tbNIK.Text) & " sudah terdaftar!!")
                        End If
                    End If
                    If (arrDefValues(3) <> Trim(tbNama.Text)) Then
                        updateString = "nama='" & myCStringManipulation.SafeSqlLiteral(tbNama.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama") = Trim(tbNama.Text)
                        End If
                    End If
                    If (arrDefValues(4) <> strGender) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "jeniskelamin='" & myCStringManipulation.SafeSqlLiteral(strGender) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("jenis_kelamin") = strGender
                        End If
                    End If
                    If (arrDefValues(5) <> Trim(tbAlamat.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "alamat='" & myCStringManipulation.SafeSqlLiteral(tbAlamat.Text) & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("alamat") = Trim(tbAlamat.Text)
                        End If
                    End If
                    If (arrDefValues(6) <> Trim(tbTempatLahir.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tempatlahir=" & IIf(Trim(tbTempatLahir.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbTempatLahir.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tempat_lahir") = Trim(tbTempatLahir.Text)
                        End If
                    End If
                    If (IIf(IsNothing(arrDefValues(7)), CDate("01-01-0001"), Format(CDate(arrDefValues(7)), "dd-MMM-yyyy")) <> Format(dtpTanggalLahir.Value.Date, "dd-MMM-yyyy")) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tanggallahir='" & Format(dtpTanggalLahir.Value.Date, "dd-MMM-yyyy") & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_lahir") = dtpTanggalLahir.Value.Date
                        End If
                    End If
                    If (IIf(IsNothing(arrDefValues(8)), CDate("01-01-0001"), Format(CDate(arrDefValues(8)), "dd-MMM-yyyy")) <> Format(dtpTanggalMasuk.Value.Date, "dd-MMM-yyyy")) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tanggalmasuk='" & Format(dtpTanggalMasuk.Value.Date, "dd-MMM-yyyy") & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_masuk") = dtpTanggalMasuk.Value.Date
                        End If
                    End If
                    If (arrDefValues(9) <> Trim(mtbNPWP.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "npwp=" & IIf(Trim(mtbNPWP.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(mtbNPWP.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("npwp") = Trim(mtbNPWP.Text)
                        End If
                    End If
                    If (arrDefValues(10) <> Trim(tbNamaBerdasarNPWP.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "namaberdasarnpwp=" & IIf(Trim(tbNamaBerdasarNPWP.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbNamaBerdasarNPWP.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama_berdasar_npwp") = Trim(tbNamaBerdasarNPWP.Text)
                        End If
                    End If
                    If (arrDefValues(11) <> Trim(tbAlamatBerdasarNPWP.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "alamatberdasarnpwp=" & IIf(Trim(tbAlamatBerdasarNPWP.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbAlamatBerdasarNPWP.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("alamat_berdasar_npwp") = Trim(tbAlamatBerdasarNPWP.Text)
                        End If
                    End If
                    If (arrDefValues(12) <> Trim(tbNoKK.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "nokk=" & IIf(Trim(tbNoKK.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbNoKK.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("no_kk") = Trim(tbNoKK.Text)
                        End If
                    End If
                    If (arrDefValues(13) <> cboStatus.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "status=" & IIf(IsNothing(cboStatus.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboStatus.SelectedValue) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("status") = Trim(cboStatus.SelectedValue)
                        End If
                    End If
                    If (arrDefValues(14) <> Trim(tbNoHP.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "nohp=" & IIf(Trim(tbNoHP.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbNoHP.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("no_hp") = Trim(tbNoHP.Text)
                        End If
                    End If
                    If (arrDefValues(15) <> Trim(tbEmail.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "email=" & IIf(Trim(tbEmail.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbEmail.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("email") = Trim(tbEmail.Text)
                        End If
                    End If
                    If (arrDefValues(16) <> cboAgama.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "agama=" & IIf(IsNothing(cboAgama.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboAgama.SelectedValue) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("agama") = cboAgama.SelectedValue
                        End If
                    End If
                    If (arrDefValues(17) <> cboGolDarah.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "goldarah=" & IIf(IsNothing(cboGolDarah.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboGolDarah.SelectedValue) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("gol_darah") = cboGolDarah.SelectedValue
                        End If
                    End If
                    If (arrDefValues(18) <> Trim(tbPendidikan.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "pendidikan=" & IIf(Trim(tbPendidikan.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbPendidikan.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("pendidikan") = Trim(tbPendidikan.Text)
                        End If
                    End If
                    If (arrDefValues(19) <> Trim(tbLulusanDari.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "lulusandari=" & IIf(Trim(tbLulusanDari.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbLulusanDari.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("lulusan_dari") = Trim(tbLulusanDari.Text)
                        End If
                    End If
                    If (arrDefValues(20) <> Trim(tbTahunLulus.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "tahunlulus=" & IIf(Trim(tbTahunLulus.Text).Length = 0, "Null", "'" & Trim(tbTahunLulus.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tahun_lulus") = Trim(tbTahunLulus.Text)
                        End If
                    End If
                    If (arrDefValues(21) <> strBPJSTK) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "bpjstk=" & IIf(IsNothing(strBPJSTK), "Null", "'" & myCStringManipulation.SafeSqlLiteral(strBPJSTK) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("bpjs_tk") = strBPJSTK
                        End If
                    End If
                    If (arrDefValues(27) <> Trim(tbNomerBPJSTenagaKerja.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "nobpjstk=" & IIf(Trim(tbNomerBPJSTenagaKerja.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbNomerBPJSTenagaKerja.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("no_bpjs_tk") = Trim(tbNomerBPJSTenagaKerja.Text)
                        End If
                    End If
                    If (arrDefValues(22) <> cbBPJSKesehatan.Checked) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "bpjskesehatan='" & cbBPJSKesehatan.Checked & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("bpjs_kesehatan") = cbBPJSKesehatan.Checked
                        End If
                    End If
                    If (arrDefValues(28) <> Trim(tbNomerBPJSKesehatan.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "nobpjskesehatan=" & IIf(Trim(tbNomerBPJSKesehatan.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbNomerBPJSKesehatan.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("no_bpjs_kesehatan") = Trim(tbNomerBPJSKesehatan.Text)
                        End If
                    End If
                    If (arrDefValues(23) <> Trim(tbJaminan.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "jaminan=" & IIf(Trim(tbJaminan.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbJaminan.Text) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("jaminan") = Trim(tbJaminan.Text)
                        End If
                    End If
                    If (arrDefValues(24) <> strStatusBekerja) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "statusbekerja=" & IIf(IsNothing(strStatusBekerja), "Null", "'" & myCStringManipulation.SafeSqlLiteral(strStatusBekerja) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("status_bekerja") = strStatusBekerja
                        End If
                    End If
                    If (strStatusBekerja <> "AKTIF") Then
                        If Not IsNothing(arrDefValues(25)) Then
                            If (IIf(IsNothing(arrDefValues(25)), CDate("01-01-0001"), arrDefValues(25)) <> dtpTerakhirKerja.Value.Date) Then
                                updateString &= IIf(IsNothing(updateString), "", ",") & "tanggalterakhirbekerja='" & Format(dtpTerakhirKerja.Value.Date, "dd-MMM-yyyy") & "',tanggalberhentibekerja='" & Format(dtpTerakhirKerja.Value.Date.AddDays(1), "dd-MMM-yyyy") & "'"
                                If (foundRows.Length > 0) Then
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_terakhir_bekerja") = dtpTerakhirKerja.Value.Date
                                    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_berhenti_bekerja") = dtpTerakhirKerja.Value.Date.AddDays(1)
                                End If
                            End If
                        Else
                            updateString &= IIf(IsNothing(updateString), "", ",") & "tanggalterakhirbekerja='" & Format(dtpTerakhirKerja.Value.Date, "dd-MMM-yyyy") & "',tanggalberhentibekerja='" & Format(dtpTerakhirKerja.Value.Date.AddDays(1), "dd-MMM-yyyy") & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_terakhir_bekerja") = dtpTerakhirKerja.Value.Date
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_berhenti_bekerja") = dtpTerakhirKerja.Value.Date.AddDays(1)
                            End If
                        End If
                    Else
                        If Not IsNothing(arrDefValues(25)) Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "tanggalterakhirbekerja=Null,tanggalberhentibekerja=Null"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_terakhir_bekerja") = DBNull.Value
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_berhenti_bekerja") = DBNull.Value
                            End If
                        End If
                    End If
                    If (arrDefValues(26) <> Trim(tbJumlahAnak.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "jumlahanak=" & IIf(Trim(tbJumlahAnak.Text).Length = 0, "Null", Trim(tbJumlahAnak.Text))
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("jumlah_anak") = Trim(tbJumlahAnak.Text)
                        End If
                    End If
                    If (arrDefValues(29) <> cboLokasi.SelectedValue) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "lokasi=" & IIf(IsNothing(cboLokasi.SelectedValue), "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "'")
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("lokasi") = cboLokasi.SelectedValue
                        End If
                        If (USER_.lokasi = "ALL") Then
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(1), "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "'", "idk='" & arrDefValues(1) & "'")
                        End If
                    End If
                    If (arrDefValues(30) <> cbSertifikat.Checked) Then
                        If (cbSertifikat.Checked) Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "sertifikat='" & cbSertifikat.Checked & "',tanggalsertifikat='" & Format(dtpSertifikat.Value.Date, "dd-MMM-yyyy") & "'"
                        Else
                            updateString &= IIf(IsNothing(updateString), "", ",") & "sertifikat='False',tanggalsertifikat=Null"
                        End If
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("sertifikat") = cbSertifikat.Checked
                            If (cbSertifikat.Checked) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_sertifikat") = Format(dtpSertifikat.Value.Date, "dd-MMM-yyyy")
                            Else
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("tanggal_sertifikat") = DBNull.Value
                            End If
                        End If
                    End If

                    If Not IsNothing(updateString) Then
                        updateString &= "," & ADD_INFO_.updateString
                        'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName(0), CONN_.dbType)
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), updateString, "rid=" & arrDefValues(0))
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(1), "nama='" & myCStringManipulation.SafeSqlLiteral(tbNama.Text) & "',lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "'", "idk='" & myCStringManipulation.SafeSqlLiteral(tbIDK.Text) & "'")
                        If (strStatusBekerja <> "AKTIF") Then
                            'PER TANGGAL 15 MARET 2022, TOMBOL DELETE DIGANTI JADI UPDATE STATUS MENJADI RESIGN
                            'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                            'Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "statusbekerja='RESIGN',tanggalberhentibekerja='" & Now.Date() & "',updated_at=clock_timestamp(),userid='" & USER_.username & "'", "rid=" & dgvView.CurrentRow.Cells("rid").Value)

                            If (dtpTerakhirKerja.Value.Date < Now.Date) Then
                                'Jika tanggal berhenti sudah lewat, maka akan langsung di backup
                                'Untuk data di mskaryawanaktif dipindah ke logkaryawan

                                'Ambil NIP nya dulu untuk update data di msposisikaryawan
                                Dim oldNIP As String
                                oldNIP = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "nip", tableName(1),, "idk='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("idk").Value) & "'", CONN_.dbType)
                                'non aktifkan di msposisikaryawan
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".msposisikaryawan", "aktif='False',tglselesaimenjabat='" & Format(dtpTerakhirKerja.Value.Date, "dd-MMM-yyyy") & "'", "nip='" & myCStringManipulation.SafeSqlLiteral(oldNIP) & "'")

                                stSQL = "INSERT INTO " & tableName(2) & " (idk,nip,fpid,nama,kelompok,perusahaan,departemen,divisi,bagian,lokasi,statuskepegawaian,katpenggajian,kontrakke,tglmulaikontrak,tglselesaikontrak,hariresetsp,created_at,updated_at,userid) 
                                        (SELECT idk,nip,fpid,nama,kelompok,perusahaan,departemen,divisi,bagian,lokasi,statuskepegawaian,katpenggajian,kontrakke,tglmulaikontrak,tglselesaikontrak,hariresetsp,created_at,updated_at,userid FROM " & tableName(1) & " WHERE idk='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("idk").Value) & "')"
                                Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)
                                'Hapus di tabel mskaryawanaktif
                                Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(1), "idk='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("idk").Value) & "'")
                            End If
                        End If
                        Call myCShowMessage.ShowUpdatedMsg("Karyawan " & Trim(tbNama.Text) & " dengan NIK " & Trim(tbNIK.Text))

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "save")
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                tbNama.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub rbJenisKelamin_CheckedChanged(sender As Object, e As EventArgs) Handles rbPria.CheckedChanged, rbWanita.CheckedChanged
        Try
            strGender = sender.text

            If (isDataPrepared) Then
                If Not isNew Then
                    'ID KARYAWAN TIDAK BOLEH BERUBAH
                Else
                    Call SetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(3), "idk", "rid", strGender, digitLength, True, dtpTanggalMasuk.Value.Date, CONN_.dbType)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbJenisKelamin_CheckedChanged Error")
        End Try
    End Sub

    Private Sub dtpTanggalMasuk_ValueChanged(sender As Object, e As EventArgs) Handles dtpTanggalMasuk.ValueChanged
        Try
            If (isDataPrepared) Then
                If Not isNew Then
                    'ID KARYAWAN TIDAK BOLEH BERUBAH
                Else
                    Call SetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(3), "idk", "rid", strGender, digitLength, True, dtpTanggalMasuk.Value.Date, CONN_.dbType)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpTanggalMasuk_ValueChanged Error")
        End Try
    End Sub

    Private Sub rbPilihanData_CheckedChanged(sender As Object, e As EventArgs) Handles rbFilterAktif.CheckedChanged, rbFilterHistory.CheckedChanged
        Try
            strStatusAktif = sender.Text
            If (rbFilterAktif.Checked) Then
                lblPilihanData.Text = "DATA AKTIF"
                'viewPilihanData = "AKTIF"
                gbDataEntry.Enabled = True
                btnCreateNew.Enabled = True
            ElseIf (rbFilterHistory.Checked) Then
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

    'Private Sub rbStatus_CheckedChanged(sender As Object, e As EventArgs) Handles rbSingle.CheckedChanged, rbMenikah.CheckedChanged
    '    Try
    '        strStatus = sender.text
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbStatus_CheckedChanged Error")
    '    End Try
    'End Sub

    Private Sub rbStatusBekerja_CheckedChanged(sender As Object, e As EventArgs) Handles rbAktif.CheckedChanged, rbResign.CheckedChanged, rbPensiun.CheckedChanged
        Try
            strStatusBekerja = sender.text
            If (rbAktif.Checked) Then
                lblTanggalTerakhirKerja.Visible = False
                dtpTerakhirKerja.Visible = False
            ElseIf (rbResign.Checked) Then
                lblTanggalTerakhirKerja.Visible = True
                dtpTerakhirKerja.Visible = True
            ElseIf (rbPensiun.Checked) Then
                lblTanggalTerakhirKerja.Visible = True
                dtpTerakhirKerja.Visible = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbStatusBekerja_CheckedChanged Error")
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboAgama.Validated, cboGolDarah.Validated, cboStatus.Validated, cboLokasi.Validated, cboPerusahaan.Validated, cboDepartemen.Validated, cboKelompok.Validated, cboSortingCriteria.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub clbBPJSTK_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbBPJSTK.Validated
        Try
            If (isDataPrepared) Then
                strBPJSTK = Nothing
                For i As Integer = 0 To clbBPJSTK.Items.Count - 1
                    If (clbBPJSTK.GetItemChecked(i)) Then
                        If Not IsNothing(strBPJSTK) Then
                            strBPJSTK &= ","
                        End If
                        strBPJSTK &= clbBPJSTK.Items(i)
                    End If
                Next
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "clbBPJSTK_SelectedIndexChanged Error")
        End Try
    End Sub

    Private Sub tbEmail_Validated(sender As Object, e As EventArgs) Handles tbEmail.Validated
        Try
            If (isDataPrepared) Then
                If (Trim(tbEmail.Text).Length > 0) Then
                    If Not (myCStringManipulation.EmailAddressCheck(tbEmail.Text)) Then
                        Call myCShowMessage.ShowWarning("Format email salah")
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbEmail_Validated Error")
        End Try
    End Sub

    Private Sub tbSpecialFields_Validated(sender As Object, e As EventArgs) Handles tbNIK.Validated, tbNoKK.Validated, tbJumlahAnak.Validated, tbAlamat.Validated
        Try
            If (sender Is tbAlamat) Then
                If (Trim(sender.Text).Length = 0) Then
                    sender.Text = "-"
                Else
                    sender.text = sender.text.ToString.ToUpper
                End If
            ElseIf (sender Is tbNIK) Then
                If (Trim(sender.Text).Length = 0) Then
                    sender.Text = "-"
                ElseIf (Trim(sender.text).Length <> 16) Then
                    'Jika tidak persis 16 digit, maka tampilkan keterangannya
                    Call myCShowMessage.ShowWarning("NIK harus 16 digit!!")
                Else
                    sender.text = sender.text.ToString.ToUpper
                End If
                lblDigitNIK.Text = Trim(sender.text).Length
            ElseIf (sender Is tbNoKK) Then
                If (Trim(sender.Text).Length = 0) Then
                    sender.Text = "-"
                ElseIf (Trim(sender.text).Length <> 16) Then
                    'Jika tidak persis 16 digit, maka tampilkan keterangannya
                    Call myCShowMessage.ShowWarning("No KK harus 16 digit!!")
                Else
                    sender.text = sender.text.ToString.ToUpper
                End If
                lblDigitKK.Text = Trim(sender.text).Length
            ElseIf (sender Is tbJumlahAnak) Then
                sender.Text = myCStringManipulation.CleanInputInteger(sender.text)
                If (Trim(sender.Text).Length = 0) Then
                    sender.Text = ""
                End If
            End If

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbSpecialFields_Validated Error")
        End Try
    End Sub

    Private Sub tbAutoCapital_Validated(sender As Object, e As EventArgs) Handles tbTempatLahir.Validated, tbNama.Validated, tbNamaBerdasarNPWP.Validated, tbAlamatBerdasarNPWP.Validated, tbPendidikan.Validated, tbLulusanDari.Validated, tbJaminan.Validated
        Try
            sender.text = sender.text.ToString.ToUpper
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbAutoCapital_Validated Error")
        End Try
    End Sub

    Private Sub tbNomerBPJSKesehatan_Validated(sender As Object, e As EventArgs) Handles tbNomerBPJSKesehatan.Validated
        Try
            If (Trim(tbNomerBPJSKesehatan.Text).Length > 0) Then
                cbBPJSKesehatan.Checked = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNomerBPJSKesehatan_Validated Error")
        End Try
    End Sub

    Private Sub btnIsiCepat_Click(sender As Object, e As EventArgs) Handles btnIsiCepat.Click
        Try
            Call myCFormManipulation.ResetForm(gbDataEntry)
            Call SetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(3), "idk", "rid", strGender, digitLength, True, dtpTanggalMasuk.Value.Date, CONN_.dbType)
            tbNIK.Text = "-"
            tbNoKK.Text = "-"
            cboStatus.SelectedIndex = 1
            tbAlamat.Text = "-"
            cboLokasi.SelectedIndex = 0
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnIsiCepat_Click Error")
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
                Dim tblNameDetail As String

                If (USER_.lokasi = "ALL" And cboLokasi.SelectedIndex = -1) Then
                    cboLokasi.Focus()
                    Call myCShowMessage.ShowWarning("Tolong tentukan dulu lokasi karyawan yang akan di ekspor datanya ke excel!")
                Else
                    If (rbFilterAktif.Checked) Then
                        strStatusAktif = "AKTIF"
                        tblNameDetail = tableName(1)
                    ElseIf (rbFilterHistory.Checked) Then
                        strStatusAktif = "RESIGN"
                        tblNameDetail = tableName(2)
                    End If
                    stSQL = "SELECT h.idk as idk,'''' || d.nip as nip,d.fpid,'''' || h.nik as nik,'''' || h.nokk as nokk,h.nama,h.jeniskelamin,d.perusahaan,d.departemen,d.divisi,d.bagian,h.lokasi,d.kelompok,d.katpenggajian,d.statuskepegawaian,d.kontrakke,d.tglmulaikontrak,d.tglselesaikontrak,h.statusbekerja,h.tanggalterakhirbekerja,h.agama,h.alamat,'''' || h.nohp as nohp,h.email,h.pendidikan,h.lulusandari,h.tahunlulus,h.tempatlahir,h.tanggallahir,h.tanggalmasuk,h.npwp,h.namaberdasarnpwp,h.alamatberdasarnpwp,h.status,h.jumlahanak,h.bpjstk,'''' || h.nobpjstk as nobpjstk,h.bpjskesehatan,'''' || h.nobpjskesehatan as nobpjskesehatan
                            FROM " & tableName(0) & " as h inner join " & tblNameDetail & " as d on h.idk=d.idk 
                            WHERE h.statusbekerja='" & strStatusAktif & "' and h.lokasi='" & IIf(USER_.lokasi = "ALL", cboLokasi.SelectedValue, myCStringManipulation.SafeSqlLiteral(USER_.lokasi)) & "' 
                            GROUP BY h.idk,'''' || d.nip,d.fpid,'''' || h.nik,'''' || h.nokk,h.nama,h.jeniskelamin,d.perusahaan,d.departemen,d.divisi,d.bagian,h.lokasi,d.kelompok,d.katpenggajian,d.statuskepegawaian,d.kontrakke,d.tglmulaikontrak,d.tglselesaikontrak,h.statusbekerja,h.tanggalterakhirbekerja,h.agama,h.alamat,'''' || h.nohp,h.email,h.pendidikan,h.lulusandari,h.tahunlulus,h.tempatlahir,h.tanggallahir,h.tanggalmasuk,h.npwp,h.namaberdasarnpwp,h.alamatberdasarnpwp,h.status,h.jumlahanak,h.bpjstk,'''' || h.nobpjstk,h.bpjskesehatan,'''' || h.nobpjskesehatan 
                            ORDER BY nama;"
                    myDataTableExportExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "Karyawan" & strStatusAktif)

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

    Private Sub cbSertifikat_CheckedChanged(sender As Object, e As EventArgs) Handles cbSertifikat.CheckedChanged
        Try
            If (cbSertifikat.Checked) Then
                dtpSertifikat.Visible = True
            Else
                dtpSertifikat.Visible = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cbSertifikat_CheckedChanged Error")
        End Try
    End Sub
End Class
