Public Class FormImportData
    Private isDataPrepared As Boolean
    Private stSQL As String
    Private newValues As String
    Private newFields As String
    Private tableName(3) As String
    'Private tableNameDetail As String

    Private Structure fileTempel
        Dim name As String
        Dim path As String
        Dim extension As String
    End Structure

    Private fileAttachment As fileTempel

    Const STR_MYCOMPUTER_CLSID As String = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaHRD As String, _connMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String)
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

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormImportData Error")
        End Try
    End Sub

    Private Sub FormImportData_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormImportData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ofd1.InitialDirectory = STR_MYCOMPUTER_CLSID
            ofd1.Title = "Pilih File Excel"
            ofd1.Multiselect = False

            rbKaryawan.Checked = True

            CONN_.excelPrvdrType = myCFileIO.ReadIniFile("EXCEL", "PRVDRTYPE", Application.StartupPath & "\SETTING.ini")
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormImportData_Load Error")
        End Try
    End Sub

    Private Sub FormImportData_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNamaFile.KeyDown, tbNamaSheet.KeyDown, btnBrowse.KeyDown, btnProsesImport.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormImportData_KeyDown Error")
        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        'OK
        Try
            ofd1.Filter = "Excel file (*.xls,*.xlsx)|*.xls;*.xlsx"
            ofd1.FilterIndex = 1
            ofd1.ShowDialog()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBrowse_Click Error")
        End Try
    End Sub

    Private Sub tbNamaFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNamaFile.Click
        'OK
        Try
            ofd1.Filter = "Excel file (*.xls,*.xlsx)|*.xls;*.xlsx"
            ofd1.FilterIndex = 1
            ofd1.ShowDialog()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNamaFile_Click Error")
        End Try
    End Sub

    Private Sub ofd1_FileOk(ByVal sender As Object, ByVal e As ComponentModel.CancelEventArgs) Handles ofd1.FileOk
        Try
            fileAttachment.path = ofd1.FileName
            fileAttachment.name = ofd1.SafeFileName
            fileAttachment.extension = ofd1.SafeFileName.Substring(ofd1.SafeFileName.LastIndexOf("."))

            tbNamaFile.Text = fileAttachment.name
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ofd1_FileOk Error")
        End Try
    End Sub

    Private Function GetIDK(_conn As Object, _comm As Object, _reader As Object, _tblName As String, _kodeField As String, _idField As String, _prefixKode As String, _digitLength As Integer, _incDate As Boolean, _dateValue As Date, _dbType As String) As String
        Try
            Select Case _prefixKode
                Case "P"
                    _prefixKode = "WANITA"
                Case "L"
                    _prefixKode = "PRIA"
            End Select
            stSQL = "SELECT kode FROM " & CONN_.schemaHRD & ".msgeneral where kategori='jeniskelamin' and keterangan='" & _prefixKode & "' order by kode;"
            _prefixKode = myCDBOperation.GetDataIndividual(_conn, _comm, _reader, stSQL)
            GetIDK = myCDBOperation.SetDynamicAutoKode(_conn, _comm, _reader, _tblName, _kodeField, _idField, _prefixKode, _digitLength, _incDate, _dateValue, _dbType)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetIDK Error")
            GetIDK = Nothing
        End Try
    End Function

    Private Sub btnImportData_Click(sender As Object, e As EventArgs) Handles btnProsesImport.Click
        Try
            Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Dim myDataTableExcel As New DataTable

            'Dim myDataTableMasterKaryawan As New DataTable
            'With myDataTableMasterKaryawan
            '    .Columns.Add("idk", GetType(String))
            '    .Columns.Add("nik", GetType(String))
            '    .Columns.Add("nama", GetType(String))
            '    .Columns.Add("jeniskelamin", GetType(String))
            '    .Columns.Add("tanggalmasuk", GetType(Date))
            '    .Columns.Add("statusbekerja", GetType(String))
            '    .Columns.Add("created_at", GetType(Date))
            '    .Columns.Add("userid", GetType(String))
            'End With

            Call myCDBConnection.SetAndOpenConnForExcel(CONN_.dbExcel, fileAttachment.path, fileAttachment.extension.Replace(".", ""), CONN_.excelPrvdrType)

            'Dim created_at As Date
            'created_at = Now
            'ADD_INFO_.newValues = "'" & created_at & "','" & USER_.username & "'"

            If (rbKaryawan.Checked) Then
                Dim idk As String
                Dim nip As String
                Dim strPrefixKode As String
                Dim strKodePerusahaan As String
                'Dim strKodeStatusPegawai As String
                Dim arrCols() As String
                Dim arrColsExcel() As String
                Dim isExist As Boolean
                Dim strTanggungan As String = Nothing
                Dim banyakTanggungan As Byte = Integer.Parse(tbJumlahTanggungan.Text)
                'Dim mJumlahKolom As Integer

                'stSQL = "SELECT [NO FINGER] as fpid,[NIK KTP] as nik,ucase([NAMA LENGKAP]) as nama,ucase([ALAMAT KTP]) as alamat,ucase([TEMPAT LAHIR]) as tempatlahir,[TGL LAHIR] as tanggallahir,ucase([JK]) as jeniskelamin,ucase(kelompok) as kelompok,ucase(perusahaan) as perusahaan,ucase(lokasi) as lokasi,ucase(departemen) as departemen,ucase(divisi) as divisi,ucase(bagian) as bagian,[TGL MASUK] as tanggalmasuk,npwp,ucase([NAMA DI NPWP]) as namaberdasarnpwp,ucase([ALAMAT DI NPWP]) as alamatberdasarnpwp,[NOMOR KARTU KELUARGA] as nokk,ucase(status) as status,[JUMLAH ANAK] as jumlahanak,[NO HP] as nohp,email,ucase(agama) as agama,ucase([GOL DARAH]) as goldarah,ucase(pendidikan) as pendidikan,ucase([LULUSAN DARI]) as lulusandari,[TAHUN LULUS] as tahunlulus,'AKTIF' as statusbekerja,ucase([CUT GAJI]) as katpenggajian,ucase([NAMA_TANGGUNGAN_1]) as nama_tanggungan1,[NIK_TANGGUNGAN_1] as nik_tanggungan1,ucase([HUBUNGAN_TANGGUNGAN_1]) as hubungan_tanggungan1,ucase([TEMPAT_LAHIR_TANGGUNGAN_1]) as tempatlahir_tanggungan1,[TGL_LAHIR_TANGGUNGAN_1] as tanggallahir_tanggungan1,ucase([NAMA_TANGGUNGAN_2]) as nama_tanggungan2,[NIK_TANGGUNGAN_2] as nik_tanggungan2,ucase([HUBUNGAN_TANGGUNGAN_2]) as hubungan_tanggungan2,ucase([TEMPAT_LAHIR_TANGGUNGAN_2]) as tempatlahir_tanggungan2,[TGL_LAHIR_TANGGUNGAN_2] as tanggallahir_tanggungan2,ucase([NAMA_TANGGUNGAN_3]) as nama_tanggungan3,[NIK_TANGGUNGAN_3] as nik_tanggungan3,ucase([HUBUNGAN_TANGGUNGAN_3]) as hubungan_tanggungan3,ucase([TEMPAT_LAHIR_TANGGUNGAN_3]) as tempatlahir_tanggungan3,[TGL_LAHIR_TANGGUNGAN_3] as tanggallahir_tanggungan3,ucase([NAMA_TANGGUNGAN_4]) as nama_tanggungan4,[NIK_TANGGUNGAN_4] as nik_tanggungan4,ucase([HUBUNGAN_TANGGUNGAN_4]) as hubungan_tanggungan4,ucase([TEMPAT_LAHIR_TANGGUNGAN_4]) as tempatlahir_tanggungan4,[TGL_LAHIR_TANGGUNGAN_4] as tanggallahir_tanggungan4,ucase([NAMA_TANGGUNGAN_5]) as nama_tanggungan5,[NIK_TANGGUNGAN_5] as nik_tanggungan5,ucase([HUBUNGAN_TANGGUNGAN_5]) as hubungan_tanggungan5,ucase([TEMPAT_LAHIR_TANGGUNGAN_5]) as tempatlahir_tanggungan5,[TGL_LAHIR_TANGGUNGAN_5] as tanggallahir_tanggungan5,ucase([NAMA_TANGGUNGAN_6]) as nama_tanggungan6,[NIK_TANGGUNGAN_6] as nik_tanggungan6,ucase([HUBUNGAN_TANGGUNGAN_6]) as hubungan_tanggungan6,ucase([TEMPAT_LAHIR_TANGGUNGAN_6]) as tempatlahir_tanggungan6,[TGL_LAHIR_TANGGUNGAN_6] as tanggallahir_tanggungan6,ucase([NAMA_TANGGUNGAN_7]) as nama_tanggungan7,[NIK_TANGGUNGAN_7] as nik_tanggungan7,ucase([HUBUNGAN_TANGGUNGAN_7]) as hubungan_tanggungan7,ucase([TEMPAT_LAHIR_TANGGUNGAN_7]) as tempatlahir_tanggungan7,[TGL_LAHIR_TANGGUNGAN_7] as tanggallahir_tanggungan7 FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE masuk='belum' AND [NAMA LENGKAP] is not null AND [NIK KTP] is not null AND [ALAMAT KTP] is not null AND JK is not null AND [TGL MASUK] is not null AND perusahaan is not null AND lokasi is not null AND [CUT GAJI] is not null ORDER BY [NAMA LENGKAP] ASC;"
                'stSQL = "SELECT [NO FINGER] as fpid,[NIK KTP] as nik,ucase([NAMA LENGKAP]) as nama,ucase([ALAMAT KTP]) as alamat,ucase([TEMPAT LAHIR]) as tempatlahir,[TGL LAHIR] as tanggallahir,ucase([JK]) as jeniskelamin,ucase(kelompok) as kelompok,ucase(perusahaan) as perusahaan,ucase(lokasi) as lokasi,ucase(departemen) as departemen,ucase(divisi) as divisi,ucase(bagian) as bagian,[TGL MASUK] as tanggalmasuk,npwp,ucase([NAMA DI NPWP]) as namaberdasarnpwp,ucase([ALAMAT DI NPWP]) as alamatberdasarnpwp,[NOMOR KARTU KELUARGA] as nokk,ucase(status) as status,[JUMLAH ANAK] as jumlahanak,[NO HP] as nohp,email,ucase(agama) as agama,ucase([GOL DARAH]) as goldarah,ucase(pendidikan) as pendidikan,ucase([LULUSAN DARI]) as lulusandari,[TAHUN LULUS] as tahunlulus,'AKTIF' as statusbekerja,ucase([CUT GAJI]) as katpenggajian,ucase([NAMA_TANGGUNGAN_1]) as nama_tanggungan1,[NIK_TANGGUNGAN_1] as nik_tanggungan1,ucase([HUBUNGAN_TANGGUNGAN_1]) as hubungan_tanggungan1,ucase([TEMPAT_LAHIR_TANGGUNGAN_1]) as tempatlahir_tanggungan1,[TGL_LAHIR_TANGGUNGAN_1] as tanggallahir_tanggungan1,ucase([NAMA_TANGGUNGAN_2]) as nama_tanggungan2,[NIK_TANGGUNGAN_2] as nik_tanggungan2,ucase([HUBUNGAN_TANGGUNGAN_2]) as hubungan_tanggungan2,ucase([TEMPAT_LAHIR_TANGGUNGAN_2]) as tempatlahir_tanggungan2,[TGL_LAHIR_TANGGUNGAN_2] as tanggallahir_tanggungan2,ucase([NAMA_TANGGUNGAN_3]) as nama_tanggungan3,[NIK_TANGGUNGAN_3] as nik_tanggungan3,ucase([HUBUNGAN_TANGGUNGAN_3]) as hubungan_tanggungan3,ucase([TEMPAT_LAHIR_TANGGUNGAN_3]) as tempatlahir_tanggungan3,[TGL_LAHIR_TANGGUNGAN_3] as tanggallahir_tanggungan3,ucase([NAMA_TANGGUNGAN_4]) as nama_tanggungan4,[NIK_TANGGUNGAN_4] as nik_tanggungan4,ucase([HUBUNGAN_TANGGUNGAN_4]) as hubungan_tanggungan4,ucase([TEMPAT_LAHIR_TANGGUNGAN_4]) as tempatlahir_tanggungan4,[TGL_LAHIR_TANGGUNGAN_4] as tanggallahir_tanggungan4,ucase([NAMA_TANGGUNGAN_5]) as nama_tanggungan5,[NIK_TANGGUNGAN_5] as nik_tanggungan5,ucase([HUBUNGAN_TANGGUNGAN_5]) as hubungan_tanggungan5,ucase([TEMPAT_LAHIR_TANGGUNGAN_5]) as tempatlahir_tanggungan5,[TGL_LAHIR_TANGGUNGAN_5] as tanggallahir_tanggungan5,ucase([NAMA_TANGGUNGAN_6]) as nama_tanggungan6,[NIK_TANGGUNGAN_6] as nik_tanggungan6,ucase([HUBUNGAN_TANGGUNGAN_6]) as hubungan_tanggungan6,ucase([TEMPAT_LAHIR_TANGGUNGAN_6]) as tempatlahir_tanggungan6,[TGL_LAHIR_TANGGUNGAN_6] as tanggallahir_tanggungan6 FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE masuk='belum' AND [NAMA LENGKAP] is not null AND [NIK KTP] is not null AND [ALAMAT KTP] is not null AND JK is not null AND [TGL MASUK] is not null AND perusahaan is not null AND lokasi is not null AND [CUT GAJI] is not null ORDER BY [NAMA LENGKAP] ASC;"
                'stSQL = "SELECT [NO FINGER] as fpid,[NIK KTP] as nik,ucase([NAMA LENGKAP]) as nama,ucase([ALAMAT KTP]) as alamat,ucase([TEMPAT LAHIR]) as tempatlahir,[TGL LAHIR] as tanggallahir,ucase([JK]) as jeniskelamin,ucase(kelompok) as kelompok,ucase(perusahaan) as perusahaan,ucase(lokasi) as lokasi,ucase(departemen) as departemen,ucase(divisi) as divisi,ucase(bagian) as bagian,[TGL MASUK] as tanggalmasuk,npwp,ucase([NAMA DI NPWP]) as namaberdasarnpwp,ucase([ALAMAT DI NPWP]) as alamatberdasarnpwp,[NOMOR KARTU KELUARGA] as nokk,ucase(status) as status,[JUMLAH ANAK] as jumlahanak,[NO HP] as nohp,email,ucase(agama) as agama,ucase([GOL DARAH]) as goldarah,ucase(pendidikan) as pendidikan,ucase([LULUSAN DARI]) as lulusandari,[TAHUN LULUS] as tahunlulus,'AKTIF' as statusbekerja,ucase([CUT GAJI]) as katpenggajian,ucase([NAMA_TANGGUNGAN_1]) as nama_tanggungan1,[NIK_TANGGUNGAN_1] as nik_tanggungan1,ucase([HUBUNGAN_TANGGUNGAN_1]) as hubungan_tanggungan1,ucase([TEMPAT_LAHIR_TANGGUNGAN_1]) as tempatlahir_tanggungan1,[TGL_LAHIR_TANGGUNGAN_1] as tanggallahir_tanggungan1,ucase([NAMA_TANGGUNGAN_2]) as nama_tanggungan2,[NIK_TANGGUNGAN_2] as nik_tanggungan2,ucase([HUBUNGAN_TANGGUNGAN_2]) as hubungan_tanggungan2,ucase([TEMPAT_LAHIR_TANGGUNGAN_2]) as tempatlahir_tanggungan2,[TGL_LAHIR_TANGGUNGAN_2] as tanggallahir_tanggungan2,ucase([NAMA_TANGGUNGAN_3]) as nama_tanggungan3,[NIK_TANGGUNGAN_3] as nik_tanggungan3,ucase([HUBUNGAN_TANGGUNGAN_3]) as hubungan_tanggungan3,ucase([TEMPAT_LAHIR_TANGGUNGAN_3]) as tempatlahir_tanggungan3,[TGL_LAHIR_TANGGUNGAN_3] as tanggallahir_tanggungan3,ucase([NAMA_TANGGUNGAN_4]) as nama_tanggungan4,[NIK_TANGGUNGAN_4] as nik_tanggungan4,ucase([HUBUNGAN_TANGGUNGAN_4]) as hubungan_tanggungan4,ucase([TEMPAT_LAHIR_TANGGUNGAN_4]) as tempatlahir_tanggungan4,[TGL_LAHIR_TANGGUNGAN_4] as tanggallahir_tanggungan4 FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE masuk='belum' AND [NAMA LENGKAP] is not null AND [NIK KTP] is not null AND [ALAMAT KTP] is not null AND JK is not null AND [TGL MASUK] is not null AND perusahaan is not null AND lokasi is not null AND [CUT GAJI] is not null ORDER BY [NAMA LENGKAP] ASC;"
                For i As Byte = 1 To banyakTanggungan
                    strTanggungan &= ",ucase([NAMA_TANGGUNGAN_" & i & "]) as nama_tanggungan" & i & ",[NIK_TANGGUNGAN_" & i & "] as nik_tanggungan" & i & ",ucase([HUBUNGAN_TANGGUNGAN_" & i & "]) as hubungan_tanggungan" & i & ",ucase([TEMPAT_LAHIR_TANGGUNGAN_" & i & "]) as tempatlahir_tanggungan" & i & ",[TGL_LAHIR_TANGGUNGAN_" & i & "] as tanggallahir_tanggungan" & i
                Next

                stSQL = "SELECT [NO FINGER] as fpid,[NIK KTP] as nik,ucase([NAMA LENGKAP]) as nama,ucase([ALAMAT KTP]) as alamat,ucase([TEMPAT LAHIR]) as tempatlahir,[TGL LAHIR] as tanggallahir,ucase([JK]) as jeniskelamin,ucase(kelompok) as kelompok,ucase(perusahaan) as perusahaan,ucase(lokasi) as lokasi,ucase(departemen) as departemen,ucase(divisi) as divisi,ucase(bagian) as bagian,[TGL MASUK] as tanggalmasuk,npwp,ucase([NAMA DI NPWP]) as namaberdasarnpwp,ucase([ALAMAT DI NPWP]) as alamatberdasarnpwp,[NOMOR KARTU KELUARGA] as nokk,ucase(status) as status,[JUMLAH ANAK] as jumlahanak,[NO HP] as nohp,email,ucase(agama) as agama,ucase([GOL DARAH]) as goldarah,ucase(pendidikan) as pendidikan,ucase([LULUSAN DARI]) as lulusandari,[TAHUN LULUS] as tahunlulus,'AKTIF' as statusbekerja,ucase([CUT GAJI]) as katpenggajian " & strTanggungan & " FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE masuk='belum' AND [NAMA LENGKAP] is not null AND [NIK KTP] is not null AND [ALAMAT KTP] is not null AND JK is not null AND [TGL MASUK] is not null AND perusahaan is not null AND lokasi is not null AND [CUT GAJI] is not null ORDER BY [NAMA LENGKAP] ASC;"

                myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "T_EXCEL")
                myDataTableExcel.Columns.Add("idk", GetType(String))
                myDataTableExcel.Columns.Add("nip", GetType(String))
                myDataTableExcel.Columns.Add("userid", GetType(String))
                myDataTableExcel.Columns("jeniskelamin").ReadOnly = False
                'For i As Integer = 1 To 5
                '    myDataTableExcel.Columns("nama_tanggungan" & i).DataType = GetType(String)
                '    myDataTableExcel.Columns("nik_tanggungan" & i).DataType = GetType(String)
                '    myDataTableExcel.Columns("hubungan_tanggungan" & i).DataType = GetType(String)
                '    myDataTableExcel.Columns("tempatlahir_tanggungan" & i).DataType = GetType(String)
                '    myDataTableExcel.Columns("tanggallahir_tanggungan" & i).DataType = GetType(Date)
                'Next

                'MsgBox(myDataTableExcel.Rows(0).Item("nama"))

                'Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableExcel, tableName(0))
                'MsgBox(myDataTableExcel.Columns.Count)

                For idx As Integer = 0 To myDataTableExcel.Rows.Count - 1
                    isExist = False
                    If (myDataTableExcel.Rows(idx).Item("nik") <> "-") Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "nik", tableName(0), "nik='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("nik")) & "'")
                    End If
                    '==================================================================================
                    If Not isExist Then
                        'mskaryawan
                        'arrCols = {"idk", "nik", "nama", "jeniskelamin", "alamat", "tempatlahir", "tanggallahir", "tanggalmasuk", "npwp", "namaberdasarnpwp", "alamatberdasarnpwp", "nokk", "status", "jumlahanak", "nohp", "email", "agama", "goldarah", "pendidikan", "lulusandari", "tahunlulus", "bpjstk", "nobpjstk", "bpjskesehatan", "nobpjskesehatan", "jaminan", "statusbekerja", "tanggalberhentibekerja", "userid"}
                        arrCols = {"idk", "nik", "nama", "jeniskelamin", "alamat", "tempatlahir", "tanggallahir", "tanggalmasuk", "npwp", "namaberdasarnpwp", "alamatberdasarnpwp", "nokk", "status", "jumlahanak", "nohp", "email", "agama", "goldarah", "pendidikan", "lulusandari", "tahunlulus", "statusbekerja", "userid", "lokasi"}
                        idk = GetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(0), "idk", "rid", myDataTableExcel.Rows(idx).Item("jeniskelamin"), 3, True, myDataTableExcel.Rows(idx).Item("tanggalmasuk"), CONN_.dbType)
                        myDataTableExcel.Rows(idx).Item("idk") = idk
                        myDataTableExcel.Rows(idx).Item("userid") = USER_.username
                        If (myDataTableExcel.Rows(idx).Item("jeniskelamin") = "L" Or myDataTableExcel.Rows(idx).Item("jeniskelamin") = "P") Then
                            myDataTableExcel.Rows(idx).Item("jeniskelamin") = IIf(myDataTableExcel.Rows(idx).Item("jeniskelamin") = "L", "PRIA", "WANITA")
                        End If
                        newValues = Nothing
                        For i As Integer = 0 To arrCols.Count - 1
                            If Not IsNothing(newValues) Then
                                newValues &= "," & myCStringManipulation.SetInsertValues(myDataTableExcel.Rows(idx).Item(arrCols(i)), myDataTableExcel.Columns(arrCols(i)).DataType.Name)
                                newFields &= "," & arrCols(i)
                            Else
                                newValues = myCStringManipulation.SetInsertValues(myDataTableExcel.Rows(idx).Item(arrCols(i)), myDataTableExcel.Columns(arrCols(i)).DataType.Name)
                                newFields = arrCols(i)
                            End If
                        Next
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(0), newValues, newFields)
                        '==================================================================================

                        '==================================================================================
                        'mskaryawanaktif
                        arrCols = {"idk", "nip", "fpid", "nama", "kelompok", "perusahaan", "divisi", "departemen", "bagian", "lokasi", "katpenggajian", "userid"}
                        strKodePerusahaan = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "kode", CONN_.schemaHRD & ".msgeneral",, "kategori='perusahaan' AND keterangan='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("perusahaan")) & "'", CONN_.dbType)
                        strPrefixKode = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "kode", CONN_.schemaHRD & ".msgeneral",, "kategori='kodenip' AND keterangan='" & myCStringManipulation.SafeSqlLiteral(strKodePerusahaan) & "'", CONN_.dbType)
                        nip = myCDBOperation.SetDynamicAutoKode(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(1), "nip", "rid", strPrefixKode, 3, True, myDataTableExcel.Rows(idx).Item("tanggalmasuk"), CONN_.dbType,, False)
                        myDataTableExcel.Rows(idx).Item("nip") = nip
                        newValues = Nothing
                        For i As Integer = 0 To arrCols.Count - 1
                            If Not IsNothing(newValues) Then
                                newValues &= "," & myCStringManipulation.SetInsertValues(myDataTableExcel.Rows(idx).Item(arrCols(i)), myDataTableExcel.Columns(arrCols(i)).DataType.Name)
                                newFields &= "," & arrCols(i)
                            Else
                                newValues = myCStringManipulation.SetInsertValues(myDataTableExcel.Rows(idx).Item(arrCols(i)), myDataTableExcel.Columns(arrCols(i)).DataType.Name)
                                newFields = arrCols(i)
                            End If
                        Next
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(1), newValues, newFields)
                        '==================================================================================


                        '==================================================================================
                        'mstanggungankaryawan
                        arrCols = {"idk", "nama", "nik", "hubungan", "tempatlahir", "tanggallahir", "userid"}
                        arrColsExcel = arrCols.Clone

                        For a As Byte = 1 To banyakTanggungan
                            newValues = Nothing
                            'If (myDataTableExcel.Rows(idx).Item("nama") = "Virgina Sekar Ayu") Then
                            '    MsgBox(a)
                            '    'MsgBox(myDataTableExcel.Rows(idx).Item("nama_tanggungan3"))
                            'End If
                            For i As Integer = 0 To arrCols.Count - 1
                                If Not IsDBNull(myDataTableExcel.Rows(idx).Item("nama_tanggungan" & a)) Then
                                    If (myDataTableExcel.Rows(idx).Item("nama_tanggungan" & a) <> "-") Then
                                        'Hanya jika tanggungannya ada dan namanya bukan '-'
                                        If (arrCols(i) <> "idk" And arrCols(i) <> "userid") Then
                                            'Selain idk dan userid
                                            arrColsExcel(a) = arrCols(i) & "_tanggungan" & a
                                            If Not IsDBNull(myDataTableExcel.Rows(idx).Item(arrColsExcel(a))) Then
                                                If Not IsNothing(newValues) Then
                                                    newValues &= "," & myCStringManipulation.SetInsertValues(myDataTableExcel.Rows(idx).Item(arrColsExcel(a)), myDataTableExcel.Columns(arrColsExcel(a)).DataType.Name)
                                                    newFields &= "," & arrCols(i)
                                                Else
                                                    newValues = myCStringManipulation.SetInsertValues(myDataTableExcel.Rows(idx).Item(arrColsExcel(a)), myDataTableExcel.Columns(arrColsExcel(a)).DataType.Name)
                                                    newFields = arrCols(i)
                                                End If
                                            End If
                                        Else
                                            'Jika idk dan userid
                                            If Not IsNothing(newValues) Then
                                                newValues &= "," & myCStringManipulation.SetInsertValues(myDataTableExcel.Rows(idx).Item(arrCols(i)), myDataTableExcel.Columns(arrCols(i)).DataType.Name)
                                                newFields &= "," & arrCols(i)
                                            Else
                                                newValues = myCStringManipulation.SetInsertValues(myDataTableExcel.Rows(idx).Item(arrCols(i)), myDataTableExcel.Columns(arrCols(i)).DataType.Name)
                                                newFields = arrCols(i)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            If Not IsNothing(newValues) Then
                                Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(2), newValues, newFields)
                            End If
                        Next
                        '==================================================================================
                    End If
                    'idk = GetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(0), "idk", "rid", myDataTableExcel.Rows(idx).Item("jeniskelamin"), 3, True, myDataTableExcel.Rows(idx).Item("tanggalmasuk"), CONN_.dbType)
                    'newValues = "'" & idk & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("nik")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("nama")).ToUpper & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("jeniskelamin")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("alamat")) & "','" & Format(myDataTableExcel.Rows(idx).Item("tanggalmasuk"), "dd-MMM-yyyy") & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("statusbekerja")) & "'," & ADD_INFO_.newValues
                    'newFields = "idk,nik,nama,jeniskelamin,alamat,tanggalmasuk,statusbekerja," & ADD_INFO_.newFields
                    'If Not IsDBNull(myDataTableExcel.Rows(idx).Item("tempatlahir")) Then
                    '    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("tempatlahir")) & "'"
                    '    newFields &= ",tempatlahir"
                    'End If
                    'If Not IsDBNull(myDataTableExcel.Rows(idx).Item("npwp")) Then
                    '    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("npwp")) & "'"
                    '    newFields &= ",npwp"
                    'End If
                    'Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(0), newValues, newFields)

                    'mskaryawanaktif
                    'strKodePerusahaan = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "kode", CONN_.schemaHRD & ".msgeneral",, "kategori='perusahaan' AND keterangan='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("perusahaan")) & "'", CONN_.dbType)
                    'strKodeStatusPegawai = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "kode", CONN_.schemaHRD & ".msgeneral",, "kategori='statuspegawai' AND keterangan='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("statuskepegawaian")) & "'", CONN_.dbType)
                    'strPrefixKode = strKodePerusahaan & strKodeStatusPegawai
                    'nip = myCDBOperation.SetDynamicAutoKode(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(1), "nip", "rid", strPrefixKode, 3, True, myDataTableExcel.Rows(idx).Item("tanggalmasuk"), CONN_.dbType)
                    'newValues = "'" & idk & "','" & nip & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("nama")).ToUpper & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("perusahaan")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("lokasi")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("statuskepegawaian")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("katpenggajian")) & "'," & ADD_INFO_.newValues
                    'newFields = "idk,nip,nama,perusahaan,lokasi,statuskepegawaian,katpenggajian," & ADD_INFO_.newFields
                    'If Not IsDBNull(myDataTableExcel.Rows(idx).Item("fpid")) Then
                    '    newValues &= "," & myDataTableExcel.Rows(idx).Item("fpid")
                    '    newFields &= ",fpid"
                    'End If
                    'If Not IsDBNull(myDataTableExcel.Rows(idx).Item("departemen")) Then
                    '    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("departemen")) & "'"
                    '    newFields &= ",departemen"
                    'End If
                    'Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(1), newValues, newFields)

                    '==================================================================
                    'insert ke datatabale sementara gak dipake dulu
                    'Call myCMiscFunction.Wait(15)
                    'With myDataTableMasterKaryawan
                    'Dim newDataRow As DataRow = .NewRow()
                    'newDataRow("idk") = GetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName, "idk", "rid", myDataTableExcel.Rows(idx).Item("jeniskelamin"), 3, True, myDataTableExcel.Rows(idx).Item("tanggalmasuk"), CONN_.dbType)
                    'newDataRow("nik") = "-"
                    'newDataRow("nama") = myDataTableExcel.Rows(idx).Item("nama")
                    'newDataRow("jeniskelamin") = myDataTableExcel.Rows(idx).Item("jeniskelamin")
                    'newDataRow("tanggalmasuk") = myDataTableExcel.Rows(idx).Item("tanggalmasuk")
                    'newDataRow("statusbekerja") = myDataTableExcel.Rows(idx).Item("statusbekerja")
                    'newDataRow("created_at") = Now
                    'newDataRow("userid") = USER_.username
                    '.Rows.Add(newDataRow)
                    'End With
                    '==================================================================

                    If (idx Mod 1000 = 0) Then
                        GC.Collect()
                    End If
                Next
                'Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableMasterKaryawan, "mskaryawan")
            ElseIf (rbKomponenPayroll.Checked) Then
                'Untuk import Excel Komponen Payroll
                stSQL = "SELECT idk,nip,nama,gaji_pokok,potongan_bpjs FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE kelompok='NON STAFF' and kat_gaji='MINGGUAN' and gaji_pokok is not null;"
                myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "T_EXCEL")

                For idx As Integer = 0 To myDataTableExcel.Rows.Count - 1
                    If Not IsDBNull(myDataTableExcel.Rows(idx).Item("gaji_pokok")) Then
                        'BUAT INPUT GAJI POKOK
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("idk")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("nip")) & "','GAJI POKOK','GAJI POKOK'," & myDataTableExcel.Rows(idx).Item("gaji_pokok") & ",1,'" & USER_.username & "'"
                        newFields = "idk,nip,komponengaji,keterangan,rupiah,faktorqty,userid"
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".mskomponentetappayroll", newValues, newFields)
                    End If

                    If Not IsDBNull(myDataTableExcel.Rows(idx).Item("gaji_pokok")) Then
                        'BUAT INPUT POTONGAN TETAP BPJS
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("idk")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("nip")) & "','POTONGAN TETAP','POTONGAN JHT+JP 3% + BPJS 1 %'," & IIf(IsDBNull(myDataTableExcel.Rows(idx).Item("potongan_bpjs")), 0, myDataTableExcel.Rows(idx).Item("potongan_bpjs")) & ",-1,'" & USER_.username & "'"
                        newFields = "idk,nip,komponengaji,keterangan,rupiah,faktorqty,userid"
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".mskomponentetappayroll", newValues, newFields)
                    End If

                    If (idx Mod 1000 = 0) Then
                        GC.Collect()
                    End If
                Next
            ElseIf (rbNomerBPJSKesehatan.Checked) Then
                'Untuk update nomer BPJS Kesehatan
                stSQL = "SELECT idk,[NO BPJS KESEHATAN] as nobpjskesehatan FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE [NO BPJS KESEHATAN]<>'RESIGN' AND [NO BPJS KESEHATAN]<>'PENSIUN';"
                myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "T_EXCEL")
                For idx As Integer = 0 To myDataTableExcel.Rows.Count - 1
                    If (Not IsDBNull(myDataTableExcel.Rows(idx).Item("nobpjskesehatan"))) Then
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".mskaryawan", "bpjskesehatan='True',nobpjskesehatan='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("nobpjskesehatan")) & "'", "idk='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("idk")) & "'")
                    End If

                    If (idx Mod 1000 = 0) Then
                        GC.Collect()
                    End If
                Next
            ElseIf (rbStatusKepegawaian.Checked) Then
                'Untuk update status kontrak atau tetap
                Dim tanggalMasuk As Date

                stSQL = "SELECT idk,[STATUS KARYAWAN] as statuskaryawan FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE [STATUS KARYAWAN]='TETAP' OR [STATUS KARYAWAN]='KONTRAK';"
                myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "T_EXCEL")
                For idx As Integer = 0 To myDataTableExcel.Rows.Count - 1
                    If (Not IsDBNull(myDataTableExcel.Rows(idx).Item("statuskaryawan"))) Then
                        If (myDataTableExcel.Rows(idx).Item("statuskaryawan") = "TETAP") Then
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".mskaryawanaktif", "statuskepegawaian='" & myDataTableExcel.Rows(idx).Item("statuskaryawan") & "',kontrakke=Null,tglmulaikontrak=Null,tglselesaikontrak=Null", "idk='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("idk")) & "'")
                        ElseIf (myDataTableExcel.Rows(idx).Item("statuskaryawan") = "KONTRAK") Then
                            'stSQL = "SELECT tanggalmasuk FROM " & CONN_.schemaHRD & ".mskaryawan WHERE idk='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("idk")) & "';"
                            'tanggalMasuk = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                            tanggalMasuk = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "tanggalmasuk", CONN_.schemaHRD & ".mskaryawan",, "idk='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("idk")) & "'")
                            If (tanggalMasuk < CDate(Now.AddYears(-1))) Then
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".mskaryawanaktif", "statuskepegawaian='" & myDataTableExcel.Rows(idx).Item("statuskaryawan") & "',kontrakke=1,tglmulaikontrak='1-Jul-2022',tglselesaikontrak=CURRENT_DATE", "idk='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("idk")) & "'")
                            Else
                                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".mskaryawanaktif", "statuskepegawaian='" & myDataTableExcel.Rows(idx).Item("statuskaryawan") & "',kontrakke=1,tglmulaikontrak='" & tanggalMasuk & "',tglselesaikontrak=CURRENT_DATE", "idk='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(idx).Item("idk")) & "'")
                            End If
                        End If
                    End If

                    If (idx Mod 1000 = 0) Then
                        GC.Collect()
                    End If
                Next
            End If

            Call myCDBConnection.CloseConn(CONN_.dbExcel, -1)
            Call myCShowMessage.ShowInfo("IMPORT EXCEL SELESAI!!")
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnImportData_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub rbKategori_CheckedChanged(sender As Object, e As EventArgs) Handles rbKaryawan.CheckedChanged
        Try
            If (rbKaryawan.Checked) Then
                'Master Karyawan
                tableName(0) = CONN_.schemaHRD & ".mskaryawan"
                tableName(1) = CONN_.schemaHRD & ".mskaryawanaktif"
                tableName(2) = CONN_.schemaHRD & ".mstanggungankaryawan"
                tbNamaSheet.Text = "masterkaryawan"
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbKategori_CheckedChanged Error")
        End Try
    End Sub

    Private Sub btnUpdateData_Click(sender As Object, e As EventArgs) Handles btnUpdateData.Click
        Try
            Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)
            Dim myDataTableKaryawan As New DataTable
            Dim jk As String = Nothing
            Dim idk As String

            stSQL = "SELECT rid,idk,jeniskelamin,tanggalmasuk FROM " & tableName(0) & " WHERE idk not like 'M%' and idk not like 'F%' order by rid;"
            myDataTableKaryawan = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_mskaryawan")

            For i As Integer = 0 To myDataTableKaryawan.Rows.Count - 1
                If (myDataTableKaryawan.Rows(i).Item("jeniskelamin") = "PRIA") Then
                    jk = "L"
                ElseIf (myDataTableKaryawan.Rows(i).Item("jeniskelamin") = "WANITA") Then
                    jk = "P"
                End If
                'idk = jk & myDataTableKaryawan.Rows(i).Item("idk")

                idk = GetIDK(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(0), "idk", "rid", jk, 3, True, myDataTableKaryawan.Rows(i).Item("tanggalmasuk"), CONN_.dbType)

                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "idk='" & idk & "'", "idk='" & myDataTableKaryawan.Rows(i).Item("idk") & "'")
                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(1), "idk='" & idk & "'", "idk='" & myDataTableKaryawan.Rows(i).Item("idk") & "'")
                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(2), "idk='" & idk & "'", "idk='" & myDataTableKaryawan.Rows(i).Item("idk") & "'")

                If (i Mod 100 = 0) Then
                    GC.Collect()
                End If
            Next

            Call myCShowMessage.ShowInfo("DONE!!")

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnUpdateData_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tbJumlahTanggungan_Validated(sender As Object, e As EventArgs) Handles tbJumlahTanggungan.Validated
        Try
            tbJumlahTanggungan.Text = myCStringManipulation.CleanInputInteger(tbJumlahTanggungan.Text)
            If (Trim(tbJumlahTanggungan.Text).Length = 0) Then
                Call myCShowMessage.ShowWarning("Jumlah tanggungan tidak boleh kosong!!")
                tbJumlahTanggungan.Text = 5
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbJumlahTanggungan_Validated Error")
        End Try
    End Sub
End Class
