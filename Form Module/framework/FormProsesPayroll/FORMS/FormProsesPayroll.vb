Imports Microsoft.Reporting.WinForms
Public Class FormProsesPayroll
    'Private tableName(11) As String
    Private isDataPrepared As Boolean = False
    Private stSQL As String
    Private newValues As String
    Private newFields As String
    Private myDataTableExcel As New DataTable
    Private myDataTableCboLokasi As New DataTable
    Private myBindingLokasi As New BindingSource
    Private myDataTableCboPerusahaan As New DataTable
    Private myBindingPerusahaan As New BindingSource
    Private myDataTableCboKaryawan As New DataTable
    Private myBindingKaryawan As New BindingSource
    Private myDataTableCboPeriode As New DataTable
    Private myBindingPeriode As New BindingSource
    'Private myDataTableCboDepartemen As New DataTable
    'Private myBindingDepartemen As New BindingSource
    Private isCboPrepared As Boolean
    Private isDeptReady As Boolean

    Private tanggalBerjalan As Date
    Private tanggalAkhir As Date
    Private tanggalProses As Date
    Private hitungTanggal As Short
    Private isProses As Boolean
    Private konfirmasi As Byte
    Private isExist As Boolean
    Private selectedMachine As String
    Private strKelompok As String
    Private isBinding As Boolean
    Private jarakPanelBawah As UShort

    Private tableNameHeader As String
    Private tableNameDetail As String
    Private tableNameTrackingStatus As String
    Private tableNameProcessedDetail As String
    Private tableNameSummary As String
    Private tableKey As String
    Private digitLength As Byte
    Private prefixKode As String
    Private prefixCompleted As String

    Private Structure fileTempel
        Dim name As String
        Dim path As String
        Dim extension As String
    End Structure

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaHRD As String, _connMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String, _lokasi As String, _connMySql As Object)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            isDataPrepared = False
            With CONN_
                .dbType = _dbType
                .dbMain = _connMain
                .dbMySql = _connMySql
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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormProsesPayroll Error")
        End Try
    End Sub

    Private Sub FormProsesPayroll_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormProsesPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Dim arrCbo() As String
            arrCbo = {"Q1", "Q2"}
            cboKuartal.Items.AddRange(arrCbo)
            cboKuartal.SelectedIndex = 0

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='periode' order by substring(kode from 4 for 4) ASC, substring(kode from 1 for 2);"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPeriode, myBindingPeriode, cboPeriode, "T_" & cboPeriode.Name, "keterangan", "keterangan", isCboPrepared)
            cboPeriode.SelectedIndex = 0

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='lokasi' " & IIf(USER_.lokasi = "ALL", "", "AND keterangan='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "'") & " order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboLokasi, myBindingLokasi, cboLokasi, "T_" & cboLokasi.Name, "keterangan", "keterangan", isCboPrepared)
            cboLokasi.SelectedIndex = 0

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='perusahaan' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPerusahaan, myBindingPerusahaan, cboPerusahaan, "T_" & cboPerusahaan.Name, "keterangan", "keterangan", isCboPrepared)

            tableNameHeader = CONN_.schemaHRD & ".trpayrollheader"
            tableNameDetail = CONN_.schemaHRD & ".trpayrolldetail"
            tableNameTrackingStatus = CONN_.schemaHRD & ".trpayrolltrackingstatus"
            tableNameProcessedDetail = CONN_.schemaHRD & ".trpayrollprocesseddetail"
            tableNameSummary = CONN_.schemaHRD & ".trpayrollsummary"
            tableKey = "nopayroll"
            digitLength = 4
            prefixKode = "PR"


            arrCbo = {"1", "-1"}
            cboFaktorQty.Items.AddRange(arrCbo)
            cboFaktorQty.SelectedIndex = 0

            rbStaff.Checked = True

            If (Now.Day <= 20) Then
                dtpPeriodeMulai.Value = DateSerial(Now.Year, Now.Month - 2, 21)
                dtpPeriodeSelesai.Value = DateSerial(Now.Year, Now.Month - 1, 20)
                For i As Short = 0 To cboPeriode.Items.Count - 1
                    If (DirectCast(cboPeriode.Items(i), DataRowView).Item("keterangan") = MonthName(Now.Month - 2, True).ToUpper & Now.Year) Then
                        cboPeriode.SelectedIndex = i
                    End If
                Next
                cboKuartal.SelectedIndex = 1
            Else
                dtpPeriodeMulai.Value = DateSerial(Now.Year, Now.Month - 1, 21)
                dtpPeriodeSelesai.Value = DateSerial(Now.Year, Now.Month, 20)
                For i As Short = 0 To cboPeriode.Items.Count - 1
                    If (DirectCast(cboPeriode.Items(i), DataRowView).Item("keterangan") = MonthName(Now.Month - 1, True).ToUpper & Now.Year) Then
                        cboPeriode.SelectedIndex = i
                    End If
                Next
                cboKuartal.SelectedIndex = 0
            End If

            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormProsesPayroll_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
        Me.rptViewer.RefreshReport()
    End Sub

    Private Sub FormProsesPayroll_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPeriodeMulai.KeyDown, dtpPeriodeSelesai.KeyDown, cboPerusahaan.KeyDown, cboLokasi.KeyDown, btnProsesSemua.KeyDown, cboKaryawanIndividu.KeyDown, tbLain2.KeyDown, cboFaktorQty.KeyDown, rtbLain2.KeyDown, btnTampilkan.KeyDown, btnProsesIndividu.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                If (sender Is cboKaryawanIndividu) Then
                    Call btnTampilkan_Click(sender, e)
                End If
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormProsesPayroll_KeyDown Error")
        End Try
    End Sub

    Private Sub cboPosKaryawan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPerusahaan.SelectedIndexChanged, cboLokasi.SelectedIndexChanged
        Try
            If (cboPerusahaan.SelectedIndex <> -1 And cboLokasi.SelectedIndex <> -1 And Not IsNothing(strKelompok)) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                isDataPrepared = False

                stSQL = "SELECT concat(nama,' || ',nip,' || ',bagian) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE (tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (parentnip is null) GROUP BY concat(nama,' || ',nip,' || ',departemen),idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian ORDER BY karyawan;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawanIndividu, "T_" & cboKaryawanIndividu.Name, "nip", "karyawan", isCboPrepared, True)

                isDataPrepared = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboPosKaryawan_SelectedIndexChanged Error")
        Finally
            If (cboPerusahaan.SelectedIndex <> -1 And cboLokasi.SelectedIndex <> -1 And Not IsNothing(strKelompok) And isDataPrepared) Then
                Call myCDBConnection.CloseConn(CONN_.dbMain)
                Me.Cursor = Cursors.Default
            End If
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboPerusahaan.Validated, cboLokasi.Validated, cboKaryawanIndividu.Validated, cboKuartal.Validated
        Try
            If (Trim(sender.Text).Length = 0) Then
                sender.SelectedIndex = -1
                If (sender Is cboKaryawanIndividu) Then
                    'Call myCFormManipulation.ResetForm(gbView)
                    'cboKaryawanIndividu.SelectedIndex = -1
                    tbDepartemenIndividu.Clear()
                    tbDivisiIndividu.Clear()
                    tbBagianIndividu.Clear()
                End If
                If (sender Is cboPerusahaan Or sender Is cboLokasi) Then
                    cboKaryawanIndividu.SelectedIndex = -1
                    myDataTableCboKaryawan.Clear()
                    myBindingKaryawan.Clear()
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub rbKelompok_CheckedChanged(sender As Object, e As EventArgs) Handles rbStaff.CheckedChanged, rbNonStaff.CheckedChanged, rbOutsource.CheckedChanged
        Try
            strKelompok = sender.text
            If (cboPerusahaan.SelectedIndex <> -1 And cboLokasi.SelectedIndex <> -1) Then
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                'stSQL = "SELECT concat(nama,' || ',nip,' || ',bagian) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian FROM " & CONN_.schemaHRD & ".mskaryawanaktif " & IIf(USER_.lokasi = "ALL", "", "WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "')") & " GROUP BY concat(nama,' || ',nip),idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian ORDER BY karyawan;"
                stSQL = "SELECT concat(nama,' || ',nip,' || ',bagian) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE (tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') GROUP BY concat(nama,' || ',nip,' || ',departemen),idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian ORDER BY karyawan;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawanIndividu, "T_" & cboKaryawanIndividu.Name, "nip", "karyawan", isCboPrepared, True)

                Call myCDBConnection.CloseConn(CONN_.dbMain)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbKelompok_CheckedChanged Error")
        End Try
    End Sub

    Private Sub cboKaryawanIndividu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKaryawanIndividu.SelectedIndexChanged
        Try
            If (isDataPrepared) Then
                If (cboKaryawanIndividu.SelectedIndex <> -1) Then
                    'Buat binding data
                    If Not (isBinding) Then
                        tbDepartemenIndividu.DataBindings.Add(New Binding("text", myBindingKaryawan, "departemen"))
                        tbDivisiIndividu.DataBindings.Add(New Binding("text", myBindingKaryawan, "divisi"))
                        tbBagianIndividu.DataBindings.Add(New Binding("text", myBindingKaryawan, "bagian"))
                        isBinding = True
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboKaryawanIndividu_SelectedIndexChanged Error")
        End Try
    End Sub

    Private Sub ProsesPayrollDokter(_conn As Object, _comm As Object, _reader As Object, _idk As String, _nip As String, _nama As String, _periodeMulai As Date, _periodeSelesai As Date, _lokasi As String, _perusahaan As String, _departemen As String, _kelompok As String, _katpenggajian As String, _statuskepegawaian As String, _divisi As String, _bagian As String, Optional _catHRD As String = Nothing, Optional _prosesIndividu As Boolean = False)
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(_conn)
            Call myCDBConnection.OpenConn(CONN_.dbMySql)

            Dim myDataTableKomponenGaji As New DataTable
            Dim myDataTablePresensi As New DataTable
            Dim myDataTableAbsen As New DataTable
            Dim myDataTableLemburan As New DataTable
            Dim myDataTableDataPresensiSekarang As New DataTable
            Dim myDataTableInfoPayrollLalu As New DataTable
            Dim myDataTableProcessedDetailLalu As New DataTable
            Dim myDataTableDataPresensiLalu As New DataTable
            Dim myDataTableDataPresensiLaluChanged As New DataTable
            Dim myDataTableKomisiDokter As New DataTable

            Dim tanggalMasuk As Date
            Dim newValuesSummary As String
            Dim newFieldsSummary As String
            Dim masaKerjaRiil As Double
            Dim tahunMasaKerja As Byte
            Dim tunjanganMasaKerja As Integer
            Dim isProbation As Boolean
            Dim hariKerja1Periode As Byte
            Dim totalJamKerja As Double
            'Dim totalKerjaLongShift As Byte
            Dim tunjanganLongShift As Double
            Dim jamLembur(1) As Double
            Dim jamLemburLama(1) As Double
            'Dim totalJamLemburDiperhitungkan As Double
            Dim absen(1) As String
            Dim totalJamLemburHariBiasa(2) As Double
            Dim totalJamLemburHariLibur(3) As Double
            'Dim faktorPengaliLembur As Double
            Dim counter As Integer = 0
            Dim strNoPayroll As String
            Dim foundRows As DataRow()
            Dim strPeriodeGaji As String
            Dim upahPokok As Double
            'Dim periodeMulaiQSebelumnya As Date
            'Dim periodeSelesaiQSebelumnya As Date
            Dim periodeLalu As String = Nothing
            Dim komponenLain2 As Double
            Dim lineNr As Byte
            Dim totalPotongan As Double
            'Dim kurangJamKerja As Double
            'Dim potonganTidakMasukFull As Double
            'Dim upahLembur As Double
            Dim upahKerja As Double
            'Dim totalJamLemburDiperhitungkanSusulan As Double
            Dim terlambat As Byte
            Dim myDataDendaTerlambat As New DataTable
            Dim nominalTerlambat As Double
            Dim tidakCheckClock As Byte
            Dim myDataDendaTidakCheckClock As New DataTable
            Dim nominalTidakCheckClock As Double
            'Dim potonganTransportKehadiran As Double
            Dim tunjanganSertifikat As Double
            Dim tunjanganHadir As Double
            Dim tunjanganTransport As Double
            'Dim totalTidakMasuk As Byte
            Dim potonganTidakMasuk As Double
            'Dim totalMasukHariLiburNasional As Double
            Dim tunjanganHariLiburNasional As Double
            Dim totalTunjangan As Double
            Dim upahBersih As Double
            Dim upahYangDibayar As Double
            Dim komisiDokter As Double

            tanggalMasuk = myCDBOperation.GetSpecificRecord(_conn, _comm, _reader, "tanggalmasuk", CONN_.schemaHRD & ".mskaryawan",, "idk='" & myCStringManipulation.SafeSqlLiteral(_idk) & "'")

            newValuesSummary = "'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & Format(tanggalMasuk, "dd-MMM-yyyy") & "'"
            newFieldsSummary = "idk,nip,nama,tanggalmasuk"

            '---1. AMBIL KOMPONEN GAJI
            '==========================================================================================================================================
            stSQL = "SELECT komponengaji,keterangan,persen,rupiah,faktorqty FROM " & CONN_.schemaHRD & ".mskomponentetappayroll WHERE nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' ORDER BY komponengaji ASC;"
            myDataTableKomponenGaji = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_KomponenGaji")
            '==========================================================================================================================================

            '---2A. AMBIL BANYAK TAHUN KERJA, DIHITUNG TOTAL BULANNYA DIBAGI 12 DAN DILAKUKAN PEMBULATAN SEPERTI BIASA (>0.5 naik ke 1, <0.5 turun ke 0)
            '==========================================================================================================================================
            stSQL = "SELECT ((EXTRACT(YEAR FROM age)) + (EXTRACT(MONTH FROM age)/12) + (EXTRACT(DAY FROM age)/365)) AS months_between FROM (SELECT age(CURRENT_DATE,tanggalmasuk) as age FROM " & CONN_.schemaHRD & ".mskaryawan WHERE idk='" & myCStringManipulation.SafeSqlLiteral(_idk) & "') AS t(age);"
            masaKerjaRiil = myCDBOperation.GetDataIndividual(_conn, _comm, _reader, stSQL)
            tahunMasaKerja = Math.Floor(Math.Round(masaKerjaRiil, 2) * 12)
            '---2B. AMBIL TUNJANGAN MASA KERJA
            If (IsNothing(_statuskepegawaian) Or (_statuskepegawaian = "TETAP")) And (_kelompok = "NON STAFF") Then
                stSQL = "SELECT tunjangan FROM " & CONN_.schemaHRD & ".mstunjanganmasakerja WHERE mulaimasakerja<=" & tahunMasaKerja & " and sampaimasakerja>=" & tahunMasaKerja & ";"
                tunjanganMasaKerja = myCDBOperation.GetDataIndividual(_conn, _comm, _reader, stSQL)
            Else
                tunjanganMasaKerja = 0
            End If
            newValuesSummary &= "," & masaKerjaRiil & "," & tahunMasaKerja & "," & tunjanganMasaKerja
            newFieldsSummary &= ",masakerjariil,masakerja,tunjanganmasakerja"
            '2C. CEK PROBATION. APAKAH MASA KERJA SUDAH LEBIH DARI 3 BULAN ATAU BELUM
            If (tahunMasaKerja > (0.25)) Then '3/12 bulan = 0.25
                isProbation = False
            Else
                isProbation = True
            End If
            '==========================================================================================================================================

            '---3. AMBIL TOTAL JAM KERJA (HARI LIBUR, CUTI, IJIN, DAN SAKIT DENGAN SURAT DOKTER DIHITUNG JAM KERJA)
            '==========================================================================================================================================
            If (_kelompok = "NON STAFF") Then
                stSQL = ""
                hariKerja1Periode = 15
            ElseIf (_kelompok = "STAFF") Then
                If (_departemen = "KLINIK") Then
                    'hariKerja1Periode = Byte.Parse((_periodeMulai - _periodeSelesai).ToString)
                    'Seharusnya hari kerja 1 periode di sini tidak diperlukan, karena gaji dokter dihitung harian
                    hariKerja1Periode = 30
                    stSQL = "SELECT (SUM(case when p.absen is null then (case when p.banyakjamkerjanyata is null then 0 else p.banyakjamkerjanyata end) else (k.persengaji/100)*4 end))::numeric(5,2) as totaljamkerja, sum(case when p.shift is null then 0 else s.nilai end) as tunjanganshift,sum(case when p.shift is null then 0 else (case when p.shift>1 then 1 else 0 end) end) as totalkerjashift 
                            FROM " & CONN_.schemaHRD & ".trdatapresensi as p left join " & CONN_.schemaHRD & ".mskategoriabsen as k on p.absen=k.absen and p.lokasi=k.lokasi left join " & CONN_.schemaHRD & ".mstunjanganshift as s on p.shift=s.shift and p.lokasi=s.lokasi 
                            WHERE (p.nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' or p.parentnip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "') and (p.tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' and p.tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "') and (p.ijin<>'TM' or p.ijin is null);"
                End If
            ElseIf (_kelompok = "OUTSOURCE") Then
                stSQL = ""
                hariKerja1Periode = 30
            End If
            myDataTablePresensi = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_Presensi")

            myDataTablePresensi.Rows(0).Item("totalJamKerja") = Math.Round(myDataTablePresensi.Rows(0).Item("totalJamKerja"), 4)
            totalJamKerja = myDataTablePresensi.Rows(0).Item("totaljamkerja")
            'totalKerjaShift = myDataTablePresensi.Rows(0).Item("totalkerjashift")
            'totalTunjanganShift = myDataTablePresensi.Rows(0).Item("tunjanganshift")
            newValuesSummary &= "," & myDataTablePresensi.Rows(0).Item("totaljamkerja")
            newFieldsSummary &= ",totaljamkerja"
            '==========================================================================================================================================

            '4---INSERT KE trpayrollheader
            '==========================================================================================================================================
            prefixCompleted = prefixKode & "-" & DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("kode")
            'Untuk mencari upah pokok karyawan tersebut
            foundRows = myDataTableKomponenGaji.Select("komponengaji='GAJI POKOK'")
            If (foundRows.Length > 0) Then
                If (_katpenggajian = "MINGGUAN") Then
                    strNoPayroll = myCDBOperation.SetDynamicAutoKode(_conn, _comm, _reader, tableNameHeader, tableKey, "rid", prefixCompleted, digitLength, True, dtpPeriodeSelesai.Value, CONN_.dbType, cboKuartal.SelectedItem, False)
                    upahPokok = myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah") / 2
                    strPeriodeGaji = cboPeriode.SelectedValue & "-" & cboKuartal.SelectedItem
                ElseIf (_katpenggajian = "BULANAN") Then
                    strNoPayroll = myCDBOperation.SetDynamicAutoKode(_conn, _comm, _reader, tableNameHeader, tableKey, "rid", prefixCompleted, digitLength, True, dtpPeriodeSelesai.Value, CONN_.dbType,, False)
                    upahPokok = myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                    strPeriodeGaji = cboPeriode.SelectedValue
                Else
                    strNoPayroll = Nothing
                    strPeriodeGaji = Nothing
                End If
                newValuesSummary &= ",'" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "'," & myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                newFieldsSummary &= "," & tableKey & ",upahpokokperbulan"
            Else
                strNoPayroll = Nothing
                strPeriodeGaji = Nothing
            End If
            newValues = "'" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "','" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "','" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "','" & myCStringManipulation.SafeSqlLiteral(_departemen) & "','" & myCStringManipulation.SafeSqlLiteral(_divisi) & "','" & myCStringManipulation.SafeSqlLiteral(_bagian) & "','" & _kelompok & "','" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "','" & Now.Date & "','" & strPeriodeGaji & "','" & Format(_periodeMulai, "dd-MMM-yyyy") & "','" & Format(_periodeSelesai, "dd-MMM-yyyy") & "'," & upahPokok & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
            newFields = tableKey & ",idk,nip,nama,lokasi,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,tanggalpenggajian,periode,periodemulai,periodeselesai,upahpokok,userpc," & ADD_INFO_.newFields
            If Not IsNothing(_catHRD) Then
                If (_catHRD.Length > 0) Then
                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(_catHRD) & "'"
                    newFields &= ",keterangan"
                End If
            End If
            Call myCDBOperation.InsertData(_conn, _comm, tableNameHeader, newValues, newFields)
            '==========================================================================================================================================

            '==========================================================================================================================================
            '5. INSERT ke trpayrollprocesseddetail untuk data presensi periode yang sekarang
            stSQL = "SELECT '" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "' as " & tableKey & ",p.kdr,p.tanggal,p.idk,p.nip,p.nama,p.ijin,p.absen,(case when p.absen is null then (case when p.jamkerjanyata is null then to_timestamp('00:00:00','hh24:mi:ss')::time WITHOUT TIME ZONE else p.jamkerjanyata end) else ((k.persengaji/100)*8 *'1 HOUR'::INTERVAL)::time WITHOUT TIME ZONE end) as jamkerjanyata,(case when p.absen is null then (case when p.banyakjamkerjanyata is null then 0 else p.banyakjamkerjanyata end) else (k.persengaji/100)*8 end)::NUMERIC(5,2) as banyakjamkerjanyata,terlambat,pulangcepat,shift,spkmulai,spkselesai,jamlembur,mulailembur,selesailembur,'" & USER_.username & "' as userid,'" & myCManagementSystem.GetComputerName & "' as userpc 
                    FROM " & CONN_.schemaHRD & ".trdatapresensi as p left join " & CONN_.schemaHRD & ".mskategoriabsen as k on p.absen=k.absen and p.lokasi=k.lokasi
                    WHERE p.nip='" & _nip & "' AND (p.tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' AND p.tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "') 
                    ORDER BY p.tanggal ASC;"
            myDataTableDataPresensiSekarang = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_" & tableNameProcessedDetail)
            Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableDataPresensiSekarang, tableNameProcessedDetail)
            '==========================================================================================================================================

            '6. INSERT ke trpayrolldetail
            '==========================================================================================================================================
            'GAJI POKOK DAN KOMPONEN GAJI LAIN YANG SUDAH TERDAFTAR
            komponenLain2 = 0
            tunjanganSertifikat = 0
            For i As Integer = 0 To myDataTableKomponenGaji.Rows.Count - 1
                If (myDataTableKomponenGaji.Rows(i).Item("komponengaji") = "TUNJANGAN TETAP" Or myDataTableKomponenGaji.Rows(i).Item("komponengaji") = "POTONGAN TETAP" Or myDataTableKomponenGaji.Rows(i).Item("komponengaji") = "BONUS") Then
                    If (isProbation) Then
                        'Jika masa percobaan, SIPA atau SIPTTK tidak dihitung
                        If (myDataTableKomponenGaji.Rows(i).Item("keterangan") <> "SIP") Then
                            lineNr = i + 1
                            newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("komponengaji")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("keterangan")) & "'," & myDataTableKomponenGaji.Rows(i).Item("faktorqty") & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                            newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,faktorqty,userpc," & ADD_INFO_.newFields
                            If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) Then
                                foundRows = myDataTableKomponenGaji.Select("komponengaji='GAJI POKOK'")
                                myDataTableKomponenGaji.Rows(i).Item("rupiah") = (myDataTableKomponenGaji.Rows(i).Item("persen") / 100) * myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                                newValues &= "," & myDataTableKomponenGaji.Rows(i).Item("persen") & "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                newFields &= ",persen,rupiah"
                            End If
                            If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) Then
                                newValues &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                newFields &= ",rupiah"
                            End If
                            Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                            'tmpUpahKerja += myDataTableKomponenGaji.Rows(i).Item("rupiah")
                        End If
                    Else
                        'Sudah lewat masa percobaan
                        'Cek apakah ada sertifikat (SIPA / SIPTTK)
                        Dim myDataTableSertifikat As New DataTable
                        stSQL = "SELECT sertifikat,tanggalsertifikat FROM " & CONN_.schemaHRD & ".mskaryawan WHERE idk='" & myCStringManipulation.SafeSqlLiteral(_idk) & "';"
                        myDataTableSertifikat = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_DataSertifikat")
                        If (myDataTableSertifikat.Rows(0).Item("sertifikat")) Then
                            'Berarti ada sertifikat
                            'Cek tanggal sertifikat, harus diproporsional
                            Dim proporsional As Double
                            If (myDataTableKomponenGaji.Rows(i).Item("keterangan") = "SIP") Then
                                Dim banyakHari As Byte
                                banyakHari = DateDiff(DateInterval.Day, Date.Parse(myDataTableSertifikat.Rows(0).Item("tanggalsertifikat")), _periodeSelesai)
                                If (banyakHari < hariKerja1Periode) Then
                                    proporsional = banyakHari / hariKerja1Periode
                                Else
                                    proporsional = 1
                                End If
                                tunjanganSertifikat = myDataTableKomponenGaji.Rows(i).Item("rupiah") * proporsional

                                newValuesSummary &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                newFieldsSummary &= ",tunjangansertifikat"
                            Else
                                proporsional = 1
                            End If
                            lineNr = i + 1
                            newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("komponengaji")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("keterangan")) & "'," & myDataTableKomponenGaji.Rows(i).Item("faktorqty") & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                            newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,faktorqty,userpc," & ADD_INFO_.newFields
                            If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) Then
                                foundRows = myDataTableKomponenGaji.Select("komponengaji='GAJI POKOK'")
                                myDataTableKomponenGaji.Rows(i).Item("rupiah") = ((myDataTableKomponenGaji.Rows(i).Item("persen") * proporsional) / 100) * myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                                newValues &= "," & (myDataTableKomponenGaji.Rows(i).Item("persen") * proporsional) & "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                newFields &= ",persen,rupiah"
                            End If
                            If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) Then
                                newValues &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah") * proporsional
                                newFields &= ",rupiah"
                            End If
                            Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
                            'tmpUpahKerja += myDataTableKomponenGaji.Rows(i).Item("rupiah")
                        Else
                            'Berarti gak ada sertifikat
                            If (myDataTableKomponenGaji.Rows(i).Item("keterangan") <> "SIP") Then
                                lineNr = i + 1
                                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("komponengaji")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("keterangan")) & "'," & myDataTableKomponenGaji.Rows(i).Item("faktorqty") & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,faktorqty,userpc," & ADD_INFO_.newFields
                                If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) Then
                                    foundRows = myDataTableKomponenGaji.Select("komponengaji='GAJI POKOK'")
                                    myDataTableKomponenGaji.Rows(i).Item("rupiah") = (myDataTableKomponenGaji.Rows(i).Item("persen") / 100) * myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                                    newValues &= "," & myDataTableKomponenGaji.Rows(i).Item("persen") & "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                    newFields &= ",persen,rupiah"
                                End If
                                If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) Then
                                    newValues &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                    newFields &= ",rupiah"
                                End If
                                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
                                'tmpUpahKerja += myDataTableKomponenGaji.Rows(i).Item("rupiah")
                            End If
                        End If
                    End If

                    If (myDataTableKomponenGaji.Rows(i).Item("faktorqty") = -1) Then
                        totalPotongan += myDataTableKomponenGaji.Rows(i).Item("rupiah")
                    End If

                    If (myDataTableKomponenGaji.Rows(i).Item("keterangan").ToString.Contains("POTONGAN JHT")) Then
                        newValuesSummary &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                        newFieldsSummary &= ",potonganjhtjpbpjs"
                    End If
                    If (myDataTableKomponenGaji.Rows(i).Item("keterangan").ToString.Contains("POTONGAN PPH")) Then
                        newValuesSummary &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                        newFieldsSummary &= ",potonganpph"
                    End If
                    If (myDataTableKomponenGaji.Rows(i).Item("komponengaji") = "BONUS") Then
                        komponenLain2 += myDataTableKomponenGaji.Rows(i).Item("rupiah")
                    End If
                End If
            Next

            'GAJI POKOK = GAJI PER JAM * JUMLAH JAM
            lineNr += 1
            upahKerja = myDataTablePresensi.Rows(0).Item("totaljamkerja") * (upahPokok)
            newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','GAJI POKOK','SITTING FEE " & myDataTablePresensi.Rows(0).Item("totaljamkerja") & " JAM'," & upahKerja & ",1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
            newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
            Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
            newValuesSummary &= "," & upahKerja
            newFieldsSummary &= ",upahkerja"

            'RESEP / KONSUL / TINDAKAN (Konsul: pdokter * (qty*(harga-potongan)))
            'AMBIL DATA DARI MYSQL
            stSQL = "SELECT kodekontak,dokter,pdokter,qty,harga,potongan FROM trjuald WHERE entiti='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' AND (tanggal>='" & Format(_periodeMulai, "yyyy-MM-dd") & "' AND tanggal='" & Format(_periodeMulai, "yyyy-MM-dd") & "') AND kodekontak='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND pdokter>0;"
            myDataTableKomisiDokter = myCDBOperation.GetDataTableUsingReader(CONN_.dbMySql, CONN_.comm, CONN_.reader, stSQL, "T_KomisiDokter")

            For i As Integer = 0 To myDataTableKomisiDokter.Rows.Count - 1
                komisiDokter += (myDataTableKomisiDokter.Rows(i).Item("pdokter") / 100) * (myDataTableKomisiDokter.Rows(i).Item("qty") * (myDataTableKomisiDokter.Rows(i).Item("harga") - myDataTableKomisiDokter.Rows(i).Item("potongan")))
            Next
            If (komisiDokter > 0) Then
                lineNr += 1
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','TUNJANGAN TIDAK TETAP','KOMISI DOKTER'," & komisiDokter & ",1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
                newValuesSummary &= "," & komisiDokter
                newFieldsSummary &= ",totalkomisi"
            End If

            'DENDA TIDAK CHECK CLOCK
            stSQL = "SELECT Sum(case when fpmasuk is null then 1 else 0 end) + Sum(case when fpkeluar is null then 1 else 0 end) as hitung FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE (nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "') AND (tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "') and (fpmasuk is null or fpkeluar is null) and (absen is null);"
            tidakCheckClock = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
            If (tidakCheckClock > 0) Then
                Dim pengaliKelipatan As Byte
                stSQL = "SELECT d.dendaharian,d.toleransi,d.dendapenalty,d.kelipatan FROM " & CONN_.schemaHRD & ".msdendatidakcheckclock as d inner join " & CONN_.schemaHRD & ".msposisikaryawan as p on d.leveljabatan=p.level WHERE p.nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "';"
                myDataDendaTidakCheckClock = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_DataDenda")
                If (myDataDendaTidakCheckClock.Rows.Count > 0) Then
                    If (tidakCheckClock > myDataDendaTidakCheckClock.Rows(0).Item("toleransi")) Then
                        If (myDataDendaTidakCheckClock.Rows(0).Item("kelipatan")) Then
                            'Jika kelipatan true, maka denda penalty nya akan berulang tiap kelipatan toleransinya
                            pengaliKelipatan = tidakCheckClock / myDataDendaTidakCheckClock.Rows(0).Item("toleransi")
                        Else
                            pengaliKelipatan = 1
                        End If
                        nominalTidakCheckClock = (tidakCheckClock * myDataDendaTidakCheckClock.Rows(0).Item("dendaharian")) + (myDataDendaTidakCheckClock.Rows(0).Item("dendapenalty") * pengaliKelipatan)
                    Else
                        nominalTidakCheckClock = tidakCheckClock * myDataDendaTidakCheckClock.Rows(0).Item("dendaharian")
                    End If
                Else
                    If (tidakCheckClock > 3) Then
                        'pengaliKelipatan = terlambat / 4
                        nominalTidakCheckClock = (tidakCheckClock * 5000) + (50000)
                    Else
                        nominalTidakCheckClock = tidakCheckClock * 5000
                    End If
                End If
                lineNr += 1
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','POTONGAN TIDAK TETAP','TIDAK CHECK CLOCK " & tidakCheckClock & "X'," & nominalTidakCheckClock & ",-1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
                newValuesSummary &= "," & tidakCheckClock & "," & nominalTidakCheckClock
                newFieldsSummary &= ",tidakcheckclock,dendatidakcheckclock"
            End If

            'TERLAMBAT (KHUSUS DOKTER DIKASIH TOLERANSI 30 MENIT)
            Dim terlambatSuper As Byte
            terlambat = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "nip", CONN_.schemaHRD & ".trdatapresensi", "Count", "nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND (tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "')", CONN_.dbType)
            If (terlambat > 0) Then
                Dim pengaliKelipatan As Byte
                stSQL = "SELECT d.dendaharian,d.toleransi,d.dendapenalty,d.kelipatan FROM " & CONN_.schemaHRD & ".msdendaterlambat as d inner join " & CONN_.schemaHRD & ".msposisikaryawan as p on d.leveljabatan=p.level WHERE p.nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "';"
                myDataDendaTerlambat = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_DataDenda")
                terlambatSuper = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "nip", CONN_.schemaHRD & ".trdatapresensi", "Count", "nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND (tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "') AND terlambat >'00:30:00'", CONN_.dbType)
                If (myDataDendaTerlambat.Rows.Count > 0) Then
                    If (terlambatSuper > myDataDendaTerlambat.Rows(0).Item("toleransi")) Then
                        If (myDataDendaTerlambat.Rows(0).Item("kelipatan")) Then
                            'Jika kelipatan true, maka denda penalty nya akan berulang tiap kelipatan toleransinya
                            pengaliKelipatan = terlambatSuper / myDataDendaTerlambat.Rows(0).Item("toleransi")
                        Else
                            pengaliKelipatan = 1
                        End If
                        nominalTerlambat = (terlambat * myDataDendaTerlambat.Rows(0).Item("dendaharian")) + (myDataDendaTerlambat.Rows(0).Item("dendapenalty") * pengaliKelipatan)
                    Else
                        nominalTerlambat = terlambat * myDataDendaTerlambat.Rows(0).Item("dendaharian")
                    End If
                Else
                    If (terlambatSuper > 4) Then
                        pengaliKelipatan = terlambatSuper / 4
                        nominalTerlambat = (terlambat * 2500) + (pengaliKelipatan * 50000)
                    Else
                        nominalTerlambat = terlambat * 2500
                    End If
                End If
                lineNr += 1
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','POTONGAN TIDAK TETAP','TERLAMBAT " & terlambat & "X'," & nominalTerlambat & ",-1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                'potonganTransportKehadiran = terlambat * ((tunjanganHadir + tunjanganTransport) / hariKerja1Periode)
                'lineNr += 1
                'newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','POTONGAN TIDAK TETAP','POTONGAN KEHADIRAN DAN TRANSPORT KARENA TERLAMBAT " & terlambat & "X'," & potonganTransportKehadiran & ",-1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                'newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                'Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                newValuesSummary &= "," & terlambat & "," & nominalTerlambat
                newFieldsSummary &= ",terlambat,dendaterlambat"
            End If
            '==========================================================================================================================================

            '==========================================================================================================================================
            '7. LAIN2
            Dim tambahanLain2 As Double = 0
            'Dim tambahanSisaCuti As Double = 0
            If (_prosesIndividu) Then
                'LAIN2
                Dim KetLain2 As String
                Dim keterangan As String
                If (Trim(tbLain2.Text).Length > 0) Then
                    lineNr += 1

                    If (cboFaktorQty.SelectedItem = 1) Then
                        KetLain2 = "TUNJANGAN TIDAK TETAP"
                    Else
                        KetLain2 = "POTONGAN TIDAK TETAP"
                    End If
                    If (Trim(rtbLain2.Text).Length > 0) Then
                        keterangan = Trim(rtbLain2.Text).ToUpper
                    Else
                        keterangan = ""
                    End If
                    tambahanLain2 = Double.Parse(tbLain2.Text)
                    newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & KetLain2 & "','" & keterangan & "'," & tambahanLain2 & "," & cboFaktorQty.SelectedItem & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                    newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                    Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
                End If
            End If
            komponenLain2 += (tambahanLain2 * cboFaktorQty.SelectedItem)
            If (komponenLain2 <> 0) Then
                newValuesSummary &= "," & komponenLain2
                newFieldsSummary &= ",lain2"
            End If

            totalTunjangan = tunjanganSertifikat + tunjanganHadir + tunjanganTransport + tunjanganHariLiburNasional + tunjanganLongShift + IIf(komponenLain2 > 0, komponenLain2, 0) + komisiDokter
            totalPotongan += potonganTidakMasuk + nominalTerlambat + nominalTidakCheckClock + IIf(komponenLain2 < 0, -komponenLain2, 0)

            upahBersih = upahPokok + totalTunjangan - totalPotongan
            upahYangDibayar = Math.Ceiling(upahBersih / 100) * 100
            Call myCDBOperation.UpdateData(_conn, _comm, tableNameHeader, "totaltunjangan=" & totalTunjangan & ",totalpotongan=" & totalPotongan & ",upahbersih=" & upahBersih & ",upahyangdibayar=" & upahYangDibayar, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "'")

            newValuesSummary &= "," & upahBersih & "," & upahYangDibayar & "," & ADD_INFO_.newValues
            newFieldsSummary &= ",upahtotal,upahyangdibayar," & ADD_INFO_.newFields
            Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableNameSummary, newValuesSummary, newFieldsSummary)
            '==========================================================================================================================================
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ProsesPayrollDokter Error")
        Finally
            Call myCDBConnection.CloseConn(_conn)
            Call myCDBConnection.CloseConn(CONN_.dbMySql)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ProsesPayrollApotek(_conn As Object, _comm As Object, _reader As Object, _idk As String, _nip As String, _nama As String, _periodeMulai As Date, _periodeSelesai As Date, _lokasi As String, _perusahaan As String, _departemen As String, _kelompok As String, _katpenggajian As String, _statuskepegawaian As String, _divisi As String, _bagian As String, Optional _catHRD As String = Nothing, Optional _prosesIndividu As Boolean = False)
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(_conn)
            Call myCDBConnection.OpenConn(CONN_.dbMySql)

            Dim myDataTableKomponenGaji As New DataTable
            Dim myDataTablePresensi As New DataTable
            Dim myDataTableAbsen As New DataTable
            Dim myDataTableLemburan As New DataTable
            Dim myDataTableDataPresensiSekarang As New DataTable
            Dim myDataTableInfoPayrollLalu As New DataTable
            Dim myDataTableProcessedDetailLalu As New DataTable
            Dim myDataTableDataPresensiLalu As New DataTable
            Dim myDataTableDataPresensiLaluChanged As New DataTable
            Dim myDataDendaTerlambat As New DataTable
            Dim myDataDendaTidakCheckClock As New DataTable

            Dim tanggalMasuk As Date
            Dim newValuesSummary As String
            Dim newFieldsSummary As String
            Dim masaKerjaRiil As Double
            Dim tahunMasaKerja As Byte
            Dim tunjanganMasaKerja As Integer
            Dim isProbation As Boolean
            Dim hariKerja1Periode As Byte
            Dim totalHariKerja As Double
            Dim totalKerjaLongShift As Byte
            Dim tunjanganLongShift As Double
            Dim jamLembur(1) As Double
            Dim jamLemburLama(1) As Double
            'Dim totalJamLemburDiperhitungkan As Double
            Dim absen(1) As String
            Dim totalJamLemburHariBiasa(2) As Double
            Dim totalJamLemburHariLibur(3) As Double
            'Dim faktorPengaliLembur As Double
            Dim counter As Integer = 0
            Dim strNoPayroll As String
            Dim foundRows As DataRow()
            Dim strPeriodeGaji As String
            Dim upahPokok As Double
            'Dim periodeMulaiQSebelumnya As Date
            'Dim periodeSelesaiQSebelumnya As Date
            Dim periodeLalu As String = Nothing
            Dim komponenLain2 As Double
            Dim lineNr As Byte
            Dim totalPotongan As Double
            'Dim kurangJamKerja As Double
            'Dim potonganTidakMasukFull As Double
            'Dim upahLembur As Double
            Dim upahKerja As Double
            'Dim totalJamLemburDiperhitungkanSusulan As Double
            'Dim tmpUpahKerja As Double
            Dim terlambat As Byte
            Dim tidakCheckClock As Byte
            Dim nominalTerlambat As Double
            Dim nominalTidakCheckClock As Double
            'Dim potonganTransportKehadiran As Double
            Dim tunjanganSertifikat As Double
            Dim tunjanganHadir As Double
            Dim tunjanganTransport As Double
            Dim totalTidakMasuk As Byte
            Dim potonganTidakMasuk As Double
            Dim totalMasukHariLiburNasional As Double
            Dim tunjanganHariLiburNasional As Double
            Dim totalTunjangan As Double
            Dim upahBersih As Double
            Dim upahYangDibayar As Double
            Dim tunjanganTetap As Double
            Dim tuslahDibagikan As Double
            Dim totalTuslah As Double

            'Dim revisiJamKerjaPeriodeLalu As Double
            'Dim revisiShiftPeriodeLalu As Integer
            'Dim revisiLemburPeriodeLalu As TimeSpan
            'Dim revisiUpahKerjaPeriodeLalu As Double
            'Dim revisiTunjanganShiftPeriodeLalu As Double
            'Dim revisiUpahLemburPeriodeLalu As Double
            'Dim revisiTunjanganPeriodeLalu As Double
            'Dim revisiPotonganPeriodeLalu As Double

            'Dim isBerubah As Boolean

            tanggalMasuk = myCDBOperation.GetSpecificRecord(_conn, _comm, _reader, "tanggalmasuk", CONN_.schemaHRD & ".mskaryawan",, "idk='" & myCStringManipulation.SafeSqlLiteral(_idk) & "'")

            newValuesSummary = "'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & Format(tanggalMasuk, "dd-MMM-yyyy") & "'"
            newFieldsSummary = "idk,nip,nama,tanggalmasuk"

            '---1. AMBIL KOMPONEN GAJI
            '==========================================================================================================================================
            stSQL = "SELECT komponengaji,keterangan,persen,rupiah,faktorqty FROM " & CONN_.schemaHRD & ".mskomponentetappayroll WHERE nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' ORDER BY komponengaji ASC;"
            myDataTableKomponenGaji = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_KomponenGaji")
            '==========================================================================================================================================

            '---2A. AMBIL BANYAK TAHUN KERJA, DIHITUNG TOTAL BULANNYA DIBAGI 12 DAN DILAKUKAN PEMBULATAN SEPERTI BIASA (>0.5 naik ke 1, <0.5 turun ke 0)
            '==========================================================================================================================================
            stSQL = "SELECT ((EXTRACT(YEAR FROM age)) + (EXTRACT(MONTH FROM age)/12) + (EXTRACT(DAY FROM age)/365)) AS months_between FROM (SELECT age(CURRENT_DATE,tanggalmasuk) as age FROM " & CONN_.schemaHRD & ".mskaryawan WHERE idk='" & myCStringManipulation.SafeSqlLiteral(_idk) & "') AS t(age);"
            masaKerjaRiil = myCDBOperation.GetDataIndividual(_conn, _comm, _reader, stSQL)
            tahunMasaKerja = Math.Floor(Math.Round(masaKerjaRiil, 2) * 12)
            '---2B. AMBIL TUNJANGAN MASA KERJA
            If (IsNothing(_statuskepegawaian) Or (_statuskepegawaian = "TETAP")) And (_kelompok = "NON STAFF") Then
                stSQL = "SELECT tunjangan FROM " & CONN_.schemaHRD & ".mstunjanganmasakerja WHERE mulaimasakerja<=" & tahunMasaKerja & " and sampaimasakerja>=" & tahunMasaKerja & ";"
                tunjanganMasaKerja = myCDBOperation.GetDataIndividual(_conn, _comm, _reader, stSQL)
            Else
                tunjanganMasaKerja = 0
            End If
            newValuesSummary &= "," & masaKerjaRiil & "," & tahunMasaKerja & "," & tunjanganMasaKerja
            newFieldsSummary &= ",masakerjariil,masakerja,tunjanganmasakerja"
            '2C. CEK PROBATION. APAKAH MASA KERJA SUDAH LEBIH DARI 3 BULAN ATAU BELUM
            If (tahunMasaKerja > (0.25)) Then '3/12 bulan = 0.25
                isProbation = False
            Else
                isProbation = True
            End If
            '==========================================================================================================================================

            '---3. AMBIL TOTAL JAM KERJA (HARI LIBUR, CUTI, IJIN, DAN SAKIT DENGAN SURAT DOKTER DIHITUNG JAM KERJA)
            '==========================================================================================================================================
            If (_kelompok = "NON STAFF") Then
                stSQL = ""
                hariKerja1Periode = 15
            ElseIf (_kelompok = "STAFF") Then
                If (_departemen = "APOTEK") Then
                    hariKerja1Periode = 25

                    stSQL = "SELECT count(p.nip) as totalharikerja, sum(case when p.shift is null then 0 else s.nilai end) as tunjanganshift,sum(case when p.shift is null then 0 else (case when p.shift>1 then 1 else 0 end) end) as totalkerjashift 
                            FROM " & CONN_.schemaHRD & ".trdatapresensi as p left join " & CONN_.schemaHRD & ".mskategoriabsen as k on p.absen=k.absen and p.lokasi=k.lokasi left join " & CONN_.schemaHRD & ".mstunjanganshift as s on p.shift=s.shift and p.lokasi=s.lokasi 
                            WHERE p.nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' and (p.tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' and p.tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "') and (p.ijin is null or p.ijin<>'TM');"
                End If
            ElseIf (_kelompok = "OUTSOURCE") Then
                stSQL = ""
                hariKerja1Periode = 30
            End If
            myDataTablePresensi = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_Presensi")

            myDataTablePresensi.Rows(0).Item("totalharikerja") = Math.Round(myDataTablePresensi.Rows(0).Item("totalharikerja"), 4)
            totalHariKerja = myDataTablePresensi.Rows(0).Item("totalharikerja")
            'totalKerjaShift = myDataTablePresensi.Rows(0).Item("totalkerjashift")
            'totalTunjanganShift = myDataTablePresensi.Rows(0).Item("tunjanganshift")
            newValuesSummary &= "," & myDataTablePresensi.Rows(0).Item("totalharikerja")
            newFieldsSummary &= ",totalharikerjariil"
            '==========================================================================================================================================

            ''---4. AMBIL JAM LEMBURNYA
            ''==========================================================================================================================================
            'stSQL = "SELECT tanggal,ijin,absen,jamlembur,mulailembur,selesailembur FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' and tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' and tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "' ORDER BY tanggal;"
            'myDataTableLemburan = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_Lembur")
            'totalJamLemburDiperhitungkan = 0
            'For i As Byte = 0 To totalJamLemburHariBiasa.Count - 1
            '    totalJamLemburHariBiasa(i) = 0
            'Next
            'For i As Byte = 0 To totalJamLemburHariLibur.Count - 1
            '    totalJamLemburHariLibur(i) = 0
            'Next
            ''jamLembur(0) untuk hari biasa
            'jamLembur(0) = Nothing
            'jamLemburLama(0) = Nothing
            ''jamLembur(1) untuk hari libur
            'jamLembur(1) = Nothing
            'jamLemburLama(1) = Nothing
            ''absen(0) untuk hari pertama, absen(1) untuk hari kedua
            'absen(0) = Nothing
            'absen(1) = Nothing
            'For i As Integer = 0 To myDataTableLemburan.Rows.Count - 1
            '    If Not IsDBNull(myDataTableLemburan.Rows(i).Item("jamlembur")) Then
            '        'Di cek dulu apakah ada lemburnya atau tidak di tanggal tersebut
            '        If (Format(myDataTableLemburan.Rows(i).Item("mulailembur"), "dd-MMM-yyyy") <> Format(myDataTableLemburan.Rows(i).Item("selesailembur"), "dd-MMM-yyyy")) Then
            '            'Kalau lembur dilakukan lintas hari, tanggal mulai lembur dan tanggal selesai lembur tidak sama
            '            'Maka perlu dilakukan pengecekkan apakah sama2 di hari kerja, sama2 di hari libur, atau dari hari kerja sampai ke hari libur, atau sebaliknya dari hari libur sampai ke hari kerja
            '            'Cek apakah di hari mulai lembur adalah hari libur atau bukan
            '            If Not IsDBNull(myDataTableLemburan.Rows(i).Item("absen")) Then
            '                'Kalau ada absennya
            '                absen(0) = myDataTableLemburan.Rows(i).Item("absen")
            '                If (absen(0) = "C" Or absen(0) = "L") Then
            '                    'Kalau mulai lembur hanya dilihat kalau di tanggal tersebut adalah hari cuti atau hari libur, kalau ada ijin tidak masuk, maka lembur tidak dihitung!
            '                    'Hanya kalau libur cuti atau libur rutin yang dianggap lemburnya
            '                    jamLembur(1) = Math.Round((DateTime.Parse(myDataTableLemburan.Rows(i).Item("tanggal") & " " & "23:59:59") - DateTime.Parse(myDataTableLemburan.Rows(i).Item("mulailembur"))).TotalHours, 2)
            '                End If
            '            Else
            '                'Kalau tidak ada absennya berarti hari kerja biasa
            '                absen(0) = Nothing
            '                jamLembur(0) = Math.Round((DateTime.Parse(myDataTableLemburan.Rows(i).Item("tanggal") & " " & "23:59:59") - DateTime.Parse(myDataTableLemburan.Rows(i).Item("mulailembur"))).TotalHours, 2)
            '            End If

            '            'Cek di hari selesai lembur, hari libur atau bukan
            '            'MsgBox(Format(myDataTableLemburan.Rows(i).Item("selesailembur"), "dd-MMM-yyyy"))
            '            absen(1) = myCDBOperation.GetSpecificRecord(_conn, _comm, _reader, "absen", CONN_.schemaHRD & ".trdatapresensi",, "nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND tanggal='" & Format(myDataTableLemburan.Rows(i).Item("selesailembur"), "dd-MMM-yyyy") & "'")
            '            If Not IsNothing(absen(1)) Then
            '                'Kalau tanggal berikutnya adalah hari libur
            '                If (absen(1) = "C" Or absen(1) = "L") Then
            '                    'Kalau cuti atau libur rutin
            '                    jamLembur(1) += Math.Round((DateTime.Parse(myDataTableLemburan.Rows(i).Item("selesailembur")) - DateTime.Parse(myDataTableLemburan.Rows(i).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
            '                Else
            '                    'Kalau di tanggal berikutnya bukan cuti atau libur, maka diberlakukan seperti hari kerja
            '                    'Bisa jadi ada absennya, misalkan tanggal berikutnya karyawan tersebut tidak masuk kerja
            '                    jamLembur(0) += Math.Round((DateTime.Parse(myDataTableLemburan.Rows(i).Item("selesailembur")) - DateTime.Parse(myDataTableLemburan.Rows(i).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
            '                End If
            '            Else
            '                'Kalau tanggal berikutnya adalah hari kerja
            '                jamLembur(0) += Math.Round((DateTime.Parse(myDataTableLemburan.Rows(i).Item("selesailembur")) - DateTime.Parse(myDataTableLemburan.Rows(i).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
            '            End If
            '        Else
            '            'Kalau lemburnya tidak lintas tanggal, berarti hanya perlu di cek di tanggal tersebut adalah hari libur atau bukan
            '            'Cek apakah di hari tersebut adalah hari libur atau bukan
            '            If Not IsDBNull(myDataTableLemburan.Rows(i).Item("absen")) Then
            '                'Kalau ada absennya
            '                absen(0) = myDataTableLemburan.Rows(i).Item("absen")
            '                If (absen(0) = "C" Or absen(0) = "L") Then
            '                    'Hanya kalau libur cuti atau libur rutin yang dianggap lemburnya
            '                    jamLembur(1) = myDataTableLemburan.Rows(i).Item("jamlembur").TotalHours
            '                End If
            '            Else
            '                'Kalau bukan hari libur
            '                absen(0) = Nothing
            '                jamLembur(0) = myDataTableLemburan.Rows(i).Item("jamlembur").TotalHours
            '            End If
            '        End If

            '        'jamLembur = myDataTableLemburan.Rows(i).Item("jamlembur").TotalHours
            '        If Not IsNothing(jamLembur(0)) Then
            '            'Cek lembur di hari kerja atau hari biasa
            '            'Untuk hitung lembur di hari biasa, maka lemburan dihitung sebagai berikut
            '            counter = 0
            '            While jamLembur(0) > 0
            '                counter += 1
            '                If (counter <= 1) Then
            '                    faktorPengaliLembur = 1.5
            '                    If (jamLembur(0) > 0 And jamLembur(0) < 1) Then
            '                        totalJamLemburHariBiasa(1) += jamLembur(0)
            '                    Else
            '                        totalJamLemburHariBiasa(1) += 1
            '                    End If
            '                ElseIf (counter > 1) Then
            '                    faktorPengaliLembur = 2
            '                    If (jamLembur(0) > 0 And jamLembur(0) < 1) Then
            '                        totalJamLemburHariBiasa(2) += jamLembur(0)
            '                    Else
            '                        totalJamLemburHariBiasa(2) += 1
            '                    End If
            '                End If

            '                If (jamLembur(0) - 1 >= 0) Then
            '                    totalJamLemburDiperhitungkan += faktorPengaliLembur
            '                    jamLembur(0) -= 1
            '                Else
            '                    totalJamLemburDiperhitungkan += (jamLembur(0) * faktorPengaliLembur)
            '                    jamLembur(0) = 0
            '                End If
            '                totalJamLemburHariBiasa(0) += 1
            '            End While
            '        End If

            '        If Not IsNothing(jamLembur(1)) Then
            '            'Cek lembur di hari libur
            '            'Jika di hari Libur atau Cuti Bersama, maka lemburan dihitung sebagai berikut
            '            '8 Jam pertama tarif 2x, 1 jam berikutnya tarif 3x, setiap jam berikutnya tarif 4x
            '            counter = 0
            '            While jamLembur(1) > 0
            '                counter += 1
            '                If (counter <= 8) Then
            '                    faktorPengaliLembur = 2
            '                    If (jamLembur(1) > 0 And jamLembur(1) < 1) Then
            '                        totalJamLemburHariLibur(1) += jamLembur(1)
            '                    Else
            '                        totalJamLemburHariLibur(1) += 1
            '                    End If
            '                ElseIf (counter = 9) Then
            '                    faktorPengaliLembur = 3
            '                    If (jamLembur(1) > 0 And jamLembur(1) < 1) Then
            '                        totalJamLemburHariLibur(2) += jamLembur(1)
            '                    Else
            '                        totalJamLemburHariLibur(2) += 1
            '                    End If
            '                ElseIf (counter > 9) Then
            '                    faktorPengaliLembur = 4
            '                    If (jamLembur(1) > 0 And jamLembur(1) < 1) Then
            '                        totalJamLemburHariLibur(3) += jamLembur(1)
            '                    Else
            '                        totalJamLemburHariLibur(3) += 1
            '                    End If
            '                End If

            '                If (jamLembur(1) - 1 > 0) Then
            '                    totalJamLemburDiperhitungkan += faktorPengaliLembur
            '                    jamLembur(1) -= 1
            '                Else
            '                    totalJamLemburDiperhitungkan += (jamLembur(1) * faktorPengaliLembur)
            '                    jamLembur(1) = 0
            '                End If
            '                totalJamLemburHariLibur(0) += 1
            '            End While
            '        End If
            '    End If
            'Next
            ''==========================================================================================================================================

            '5---INSERT KE trpayrollheader
            '==========================================================================================================================================
            prefixCompleted = prefixKode & "-" & DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("kode")
            'Untuk mencari upah pokok karyawan tersebut
            foundRows = myDataTableKomponenGaji.Select("komponengaji='GAJI POKOK'")
            If (foundRows.Length > 0) Then
                If (_katpenggajian = "MINGGUAN") Then
                    strNoPayroll = myCDBOperation.SetDynamicAutoKode(_conn, _comm, _reader, tableNameHeader, tableKey, "rid", prefixCompleted, digitLength, True, dtpPeriodeSelesai.Value, CONN_.dbType, cboKuartal.SelectedItem, False)
                    upahPokok = myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah") / 2
                    strPeriodeGaji = cboPeriode.SelectedValue & "-" & cboKuartal.SelectedItem
                ElseIf (_katpenggajian = "BULANAN") Then
                    strNoPayroll = myCDBOperation.SetDynamicAutoKode(_conn, _comm, _reader, tableNameHeader, tableKey, "rid", prefixCompleted, digitLength, True, dtpPeriodeSelesai.Value, CONN_.dbType,, False)
                    upahPokok = myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                    strPeriodeGaji = cboPeriode.SelectedValue
                Else
                    strNoPayroll = Nothing
                    strPeriodeGaji = Nothing
                End If
                newValuesSummary &= ",'" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "'," & myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                newFieldsSummary &= "," & tableKey & ",upahpokokperbulan"
            Else
                strNoPayroll = Nothing
                strPeriodeGaji = Nothing
            End If
            newValues = "'" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "','" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "','" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "','" & myCStringManipulation.SafeSqlLiteral(_departemen) & "','" & myCStringManipulation.SafeSqlLiteral(_divisi) & "','" & myCStringManipulation.SafeSqlLiteral(_bagian) & "','" & _kelompok & "','" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "','" & Now.Date & "','" & strPeriodeGaji & "','" & Format(_periodeMulai, "dd-MMM-yyyy") & "','" & Format(_periodeSelesai, "dd-MMM-yyyy") & "'," & upahPokok & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
            newFields = tableKey & ",idk,nip,nama,lokasi,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,tanggalpenggajian,periode,periodemulai,periodeselesai,upahpokok,userpc," & ADD_INFO_.newFields
            If Not IsNothing(_catHRD) Then
                If (_catHRD.Length > 0) Then
                    newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(_catHRD) & "'"
                    newFields &= ",keterangan"
                End If
            End If
            Call myCDBOperation.InsertData(_conn, _comm, tableNameHeader, newValues, newFields)
            '==========================================================================================================================================

            '==========================================================================================================================================
            '6. INSERT ke trpayrollprocesseddetail untuk data presensi periode yang sekarang
            stSQL = "SELECT '" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "' as " & tableKey & ",p.kdr,p.tanggal,p.idk,p.nip,p.nama,p.ijin,p.absen,(case when p.absen is null then (case when p.jamkerjanyata is null then to_timestamp('00:00:00','hh24:mi:ss')::time WITHOUT TIME ZONE else p.jamkerjanyata end) else ((k.persengaji/100)*8 *'1 HOUR'::INTERVAL)::time WITHOUT TIME ZONE end) as jamkerjanyata,(case when p.absen is null then (case when p.banyakjamkerjanyata is null then 0 else p.banyakjamkerjanyata end) else (k.persengaji/100)*8 end)::NUMERIC(5,2) as banyakjamkerjanyata,terlambat,pulangcepat,shift,spkmulai,spkselesai,jamlembur,mulailembur,selesailembur,'" & USER_.username & "' as userid,'" & myCManagementSystem.GetComputerName & "' as userpc 
                    FROM " & CONN_.schemaHRD & ".trdatapresensi as p left join " & CONN_.schemaHRD & ".mskategoriabsen as k on p.absen=k.absen and p.lokasi=k.lokasi
                    WHERE p.nip='" & _nip & "' AND (p.tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' AND p.tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "') 
                    ORDER BY p.tanggal ASC;"
            myDataTableDataPresensiSekarang = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_" & tableNameProcessedDetail)
            Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableDataPresensiSekarang, tableNameProcessedDetail)
            '==========================================================================================================================================

            ''==========================================================================================================================================
            ''7. Ambil data di periode penggajian sebelumnya untuk nanti dibandingkan dengan data presensi di periode tersebut saat di proses di periode berikutnya, kalau semisal ada perubahan
            'If (_katpenggajian = "MINGGUAN") Then
            '    'Jika mingguan, harus di cek dulu 1 hari ke belakang itu tanggal berapa
            '    If (dtpPeriodeMulai.Value.Day = 1) Then
            '        'Ini kalau Q1, berarti mundur ke Q2 bulan sebelumnya
            '        periodeMulaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1, 16)
            '        periodeSelesaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1, DateTime.DaysInMonth(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1))
            '        periodeLalu = MonthName(periodeMulaiQSebelumnya.Month - 1, True).ToUpper & periodeMulaiQSebelumnya.Year & "-" & "Q2"
            '    ElseIf (dtpPeriodeMulai.Value.Day = 16) Then
            '        'ini kalau Q2, berarti mundur ke Q1 bulan yang sama
            '        periodeMulaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month, 1)
            '        periodeSelesaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month, 15)
            '        periodeLalu = MonthName(periodeMulaiQSebelumnya.Month, True).ToUpper & periodeMulaiQSebelumnya.Year & "-" & "Q1"
            '    End If
            'ElseIf (_katpenggajian = "BULANAN") Then
            '    'Jika bulanan, langsung saja periode sebelumnya pasti 1 bulan sebelumnya
            '    periodeLalu = MonthName(periodeMulaiQSebelumnya.Month, True).ToUpper & periodeMulaiQSebelumnya.Year
            '    periodeMulaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1, 1)
            '    periodeSelesaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1, DateTime.DaysInMonth(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1))
            'Else
            '    periodeLalu = "QX"
            'End If
            'stSQL = "SELECT " & tableKey & ",periodemulai,periodeselesai FROM " & tableNameHeader & " WHERE nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND periode='" & periodeLalu & "';"
            'myDataTableInfoPayrollLalu = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_" & tableNameHeader)
            'If (myDataTableInfoPayrollLalu.Rows.Count > 0) Then
            '    stSQL = "SELECT p.kdr,p.tanggal,p.idk,p.nip,p.nama,p.ijin,p.absen,p.jamkerjanyata,p.banyakjamkerjanyata,p.terlambat,p.pulangcepat,p.shift,(case when p.shift is null then 0 else s.nilai end) as tunjanganshift,p.spkmulai,p.spkselesai,p.jamlembur,p.mulailembur,p.selesailembur 
            '            FROM (" & tableNameHeader & " as h INNER JOIN " & tableNameProcessedDetail & " as p on h." & tableKey & "=p." & tableKey & ") LEFT JOIN " & CONN_.schemaHRD & ".mstunjanganshift as s on p.shift=s.shift and h.lokasi=s.lokasi 
            '            WHERE p." & tableKey & "='" & myCStringManipulation.SafeSqlLiteral(myDataTableInfoPayrollLalu.Rows(0).Item("nopayroll")) & "' 
            '            ORDER BY p.tanggal ASC;"
            '    myDataTableProcessedDetailLalu = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_" & tableNameProcessedDetail)
            'End If
            ''==========================================================================================================================================

            '8. INSERT ke trpayrolldetail
            '==========================================================================================================================================
            'GAJI POKOK DAN KOMPONEN GAJI LAIN YANG SUDAH TERDAFTAR
            komponenLain2 = 0
            tunjanganSertifikat = 0
            tunjanganTetap = 0
            For i As Integer = 0 To myDataTableKomponenGaji.Rows.Count - 1
                If (myDataTableKomponenGaji.Rows(i).Item("komponengaji") = "GAJI POKOK" Or myDataTableKomponenGaji.Rows(i).Item("komponengaji") = "TUNJANGAN TETAP" Or myDataTableKomponenGaji.Rows(i).Item("komponengaji") = "POTONGAN TETAP" Or myDataTableKomponenGaji.Rows(i).Item("komponengaji") = "BONUS") Then
                    If (isProbation) Then
                        'Jika masa percobaan, SIPA atau SIPTTK tidak dihitung
                        If (myDataTableKomponenGaji.Rows(i).Item("keterangan") <> "SIPA/SIPTTK") Then
                            lineNr = i + 1
                            newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("komponengaji")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("keterangan")) & "'," & myDataTableKomponenGaji.Rows(i).Item("faktorqty") & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                            newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,faktorqty,userpc," & ADD_INFO_.newFields
                            If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) Then
                                foundRows = myDataTableKomponenGaji.Select("komponengaji='GAJI POKOK'")
                                myDataTableKomponenGaji.Rows(i).Item("rupiah") = (myDataTableKomponenGaji.Rows(i).Item("persen") / 100) * myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                                newValues &= "," & myDataTableKomponenGaji.Rows(i).Item("persen") & "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                newFields &= ",persen,rupiah"
                            End If
                            If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) Then
                                newValues &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                newFields &= ",rupiah"
                            End If
                            Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
                        End If
                    Else
                        'Sudah lewat masa percobaan
                        'Cek apakah ada sertifikat (SIPA / SIPTTK)
                        Dim myDataTableSertifikat As New DataTable
                        stSQL = "SELECT sertifikat,tanggalsertifikat FROM " & CONN_.schemaHRD & ".mskaryawan WHERE idk='" & myCStringManipulation.SafeSqlLiteral(_idk) & "';"
                        myDataTableSertifikat = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_DataSertifikat")
                        If (myDataTableSertifikat.Rows(0).Item("sertifikat")) Then
                            'Berarti ada sertifikat
                            'Cek tanggal sertifikat, harus diproporsional
                            Dim proporsional As Double
                            If (myDataTableKomponenGaji.Rows(i).Item("keterangan") = "SIPA/SIPTTK") Then
                                Dim banyakHari As Byte
                                banyakHari = DateDiff(DateInterval.Day, Date.Parse(myDataTableSertifikat.Rows(0).Item("tanggalsertifikat")), _periodeSelesai)
                                If (banyakHari < hariKerja1Periode) Then
                                    proporsional = banyakHari / hariKerja1Periode
                                Else
                                    proporsional = 1
                                End If
                                tunjanganSertifikat = myDataTableKomponenGaji.Rows(i).Item("rupiah") * proporsional
                                tunjanganTetap += tunjanganSertifikat
                                newValuesSummary &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                newFieldsSummary &= ",tunjangansertifikat"
                            Else
                                proporsional = 1
                            End If
                            lineNr = i + 1
                            newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("komponengaji")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("keterangan")) & "'," & myDataTableKomponenGaji.Rows(i).Item("faktorqty") & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                            newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,faktorqty,userpc," & ADD_INFO_.newFields
                            If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) Then
                                foundRows = myDataTableKomponenGaji.Select("komponengaji='GAJI POKOK'")
                                myDataTableKomponenGaji.Rows(i).Item("rupiah") = ((myDataTableKomponenGaji.Rows(i).Item("persen") * proporsional) / 100) * myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                                newValues &= "," & (myDataTableKomponenGaji.Rows(i).Item("persen") * proporsional) & "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                newFields &= ",persen,rupiah"
                            End If
                            If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) Then
                                newValues &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah") * proporsional
                                newFields &= ",rupiah"
                            End If
                            Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
                            'tmpUpahKerja += myDataTableKomponenGaji.Rows(i).Item("rupiah")
                        Else
                            'Berarti gak ada sertifikat
                            If (myDataTableKomponenGaji.Rows(i).Item("keterangan") <> "SIPA/SIPTTK") Then
                                lineNr = i + 1
                                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("komponengaji")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableKomponenGaji.Rows(i).Item("keterangan")) & "'," & myDataTableKomponenGaji.Rows(i).Item("faktorqty") & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,faktorqty,userpc," & ADD_INFO_.newFields
                                If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) Then
                                    foundRows = myDataTableKomponenGaji.Select("komponengaji='GAJI POKOK'")
                                    myDataTableKomponenGaji.Rows(i).Item("rupiah") = (myDataTableKomponenGaji.Rows(i).Item("persen") / 100) * myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                                    newValues &= "," & myDataTableKomponenGaji.Rows(i).Item("persen") & "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                    newFields &= ",persen,rupiah"
                                End If
                                If Not IsDBNull(myDataTableKomponenGaji.Rows(i).Item("rupiah")) And IsDBNull(myDataTableKomponenGaji.Rows(i).Item("persen")) Then
                                    newValues &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                                    newFields &= ",rupiah"
                                End If
                                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
                                'tmpUpahKerja += myDataTableKomponenGaji.Rows(i).Item("rupiah")
                            End If
                        End If
                    End If

                    If (myDataTableKomponenGaji.Rows(i).Item("faktorqty") = -1) Then
                        totalPotongan += myDataTableKomponenGaji.Rows(i).Item("rupiah")
                    End If

                    If (myDataTableKomponenGaji.Rows(i).Item("keterangan").ToString.Contains("POTONGAN JHT")) Then
                        newValuesSummary &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                        newFieldsSummary &= ",potonganjhtjpbpjs"
                    End If
                    If (myDataTableKomponenGaji.Rows(i).Item("keterangan").ToString.Contains("POTONGAN PPH")) Then
                        newValuesSummary &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                        newFieldsSummary &= ",potonganpph"
                    End If
                    If (myDataTableKomponenGaji.Rows(i).Item("komponengaji") = "BONUS") Then
                        komponenLain2 += myDataTableKomponenGaji.Rows(i).Item("rupiah")
                    End If
                End If
            Next
            upahKerja = (upahPokok + tunjanganSertifikat)
            newValuesSummary &= "," & upahKerja
            newFieldsSummary &= ",upahkerja"

            foundRows = myDataTableKomponenGaji.Select("keterangan='TUNJANGAN HADIR'")
            If (foundRows.Length > 0) Then
                tunjanganHadir = myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                newValuesSummary &= "," & tunjanganHadir
                newFieldsSummary &= ",tunjanganhadir"
            End If

            foundRows = myDataTableKomponenGaji.Select("keterangan='TUNJANGAN TRANSPORT'")
            If (foundRows.Length > 0) Then
                tunjanganTransport = myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                newValuesSummary &= "," & tunjanganTransport
                newFieldsSummary &= ",tunjangantransport"
            End If

            'DENDA TIDAK CHECK CLOCK
            stSQL = "SELECT Sum(case when fpmasuk is null then 1 else 0 end) + Sum(case when fpkeluar is null then 1 else 0 end) as hitung FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE (nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "') AND (tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "') and (fpmasuk is null or fpkeluar is null) and (absen is null);"
            tidakCheckClock = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
            If (tidakCheckClock > 0) Then
                Dim pengaliKelipatan As Byte
                stSQL = "SELECT d.dendaharian,d.toleransi,d.dendapenalty,d.kelipatan FROM " & CONN_.schemaHRD & ".msdendatidakcheckclock as d inner join " & CONN_.schemaHRD & ".msposisikaryawan as p on d.leveljabatan=p.level WHERE p.nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "';"
                myDataDendaTidakCheckClock = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_DataDenda")
                If (myDataDendaTidakCheckClock.Rows.Count > 0) Then
                    If (tidakCheckClock > myDataDendaTidakCheckClock.Rows(0).Item("toleransi")) Then
                        If (myDataDendaTidakCheckClock.Rows(0).Item("kelipatan")) Then
                            'Jika kelipatan true, maka denda penalty nya akan berulang tiap kelipatan toleransinya
                            pengaliKelipatan = tidakCheckClock / myDataDendaTidakCheckClock.Rows(0).Item("toleransi")
                        Else
                            pengaliKelipatan = 1
                        End If
                        nominalTidakCheckClock = (tidakCheckClock * myDataDendaTidakCheckClock.Rows(0).Item("dendaharian")) + (myDataDendaTidakCheckClock.Rows(0).Item("dendapenalty") * pengaliKelipatan)
                    Else
                        nominalTidakCheckClock = tidakCheckClock * myDataDendaTidakCheckClock.Rows(0).Item("dendaharian")
                    End If
                Else
                    If (tidakCheckClock > 3) Then
                        'pengaliKelipatan = terlambat / 4
                        nominalTidakCheckClock = (tidakCheckClock * 5000) + (50000)
                    Else
                        nominalTidakCheckClock = tidakCheckClock * 5000
                    End If
                End If
                lineNr += 1
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','POTONGAN TIDAK TETAP','TIDAK CHECK CLOCK " & tidakCheckClock & "X'," & nominalTidakCheckClock & ",-1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                newValuesSummary &= "," & tidakCheckClock & "," & nominalTidakCheckClock
                newFieldsSummary &= ",tidakcheckclock,dendatidakcheckclock"
            End If

            'TERLAMBAT
            terlambat = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "nip", CONN_.schemaHRD & ".trdatapresensi", "Count", "nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND (tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "') AND terlambat >'00:00:59'", CONN_.dbType)
            If (terlambat > 0) Then
                Dim pengaliKelipatan As Byte
                stSQL = "SELECT d.dendaharian,d.toleransi,d.dendapenalty,d.kelipatan FROM " & CONN_.schemaHRD & ".msdendaterlambat as d inner join " & CONN_.schemaHRD & ".msposisikaryawan as p on d.leveljabatan=p.level WHERE p.nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "';"
                myDataDendaTerlambat = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_DataDenda")
                If (myDataDendaTerlambat.Rows.Count > 0) Then
                    If (terlambat > myDataDendaTerlambat.Rows(0).Item("toleransi")) Then
                        If (myDataDendaTerlambat.Rows(0).Item("kelipatan")) Then
                            'Jika kelipatan true, maka denda penalty nya akan berulang tiap kelipatan toleransinya
                            pengaliKelipatan = terlambat / myDataDendaTerlambat.Rows(0).Item("toleransi")
                        Else
                            pengaliKelipatan = 1
                        End If
                        nominalTerlambat = (terlambat * myDataDendaTerlambat.Rows(0).Item("dendaharian")) + (myDataDendaTerlambat.Rows(0).Item("dendapenalty") * pengaliKelipatan)
                    Else
                        nominalTerlambat = terlambat * myDataDendaTerlambat.Rows(0).Item("dendaharian")
                    End If
                Else
                    If (terlambat > 4) Then
                        'pengaliKelipatan = terlambat / 4
                        nominalTerlambat = (terlambat * 2500) + (50000)
                    Else
                        nominalTerlambat = terlambat * 2500
                    End If
                End If
                lineNr += 1
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','POTONGAN TIDAK TETAP','TERLAMBAT " & terlambat & "X'," & nominalTerlambat & ",-1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                'potonganTransportKehadiran = terlambat * ((tunjanganHadir + tunjanganTransport) / hariKerja1Periode)
                'lineNr += 1
                'newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','POTONGAN TIDAK TETAP','POTONGAN KEHADIRAN DAN TRANSPORT KARENA TERLAMBAT " & terlambat & "X'," & potonganTransportKehadiran & ",-1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                'newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                'Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                newValuesSummary &= "," & terlambat & "," & nominalTerlambat
                newFieldsSummary &= ",terlambat,dendaterlambat"
            End If

            'POTONGAN TIDAK MASUK
            stSQL = "SELECT count(p.nip) as totaltidakmasuk,p.absen,k.keterangan,k.potonggaji,k.persengaji,k.potongtunjangankehadiran,k.potongtunjangantransport,k.potongtunjangansertifikat
                    FROM " & CONN_.schemaHRD & ".trdatapresensi as p left join " & CONN_.schemaHRD & ".mskategoriabsen as k on p.absen=k.absen and p.lokasi=k.lokasi 
                    WHERE p.nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' and (p.tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' and p.tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "') AND (p.ijin='TM' AND p.absen<>'L')
                    GROUP BY p.absen,k.keterangan,k.potonggaji,k.persengaji,k.potongtunjangankehadiran,k.potongtunjangantransport,k.potongtunjangansertifikat
                    ORDER BY p.absen;"
            myDataTableAbsen = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_ABSEN")
            Dim keteranganAbsenLama As String = Nothing
            Dim totalPotTidakMasuk As Double
            Dim tidakMasuk As Integer
            Dim alpha As Byte
            If (totalHariKerja < hariKerja1Periode) Then
                totalTidakMasuk = (hariKerja1Periode - totalHariKerja)
            End If
            If (myDataTableAbsen.Rows.Count > 0) Then
                'Ini kalau ada hari yang tidak masuk
                'Jika ada tidak masuknya, maka harus di cek
                For i As Integer = 0 To myDataTableAbsen.Rows.Count - 1
                    If (keteranganAbsenLama <> myDataTableAbsen.Rows(i).Item("keterangan")) Then
                        keteranganAbsenLama = myDataTableAbsen.Rows(i).Item("keterangan")
                        tidakMasuk = myDataTableAbsen.Rows(i).Item("totaltidakmasuk")
                        potonganTidakMasuk = tidakMasuk * (((upahPokok * (IIf(myDataTableAbsen.Rows(i).Item("persengaji") = 100, 0, 100) / 100)) / hariKerja1Periode) + ((IIf(myDataTableAbsen.Rows(i).Item("potongtunjangankehadiran"), tunjanganHadir, 0) + IIf(myDataTableAbsen.Rows(i).Item("potongtunjangantransport"), tunjanganTransport, 0) + IIf(myDataTableAbsen.Rows(i).Item("potongtunjangansertifikat"), tunjanganSertifikat, 0)) / hariKerja1Periode))
                        totalTidakMasuk += tidakMasuk
                        totalPotTidakMasuk += potonganTidakMasuk
                        lineNr += 1
                        newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','POTONGAN TIDAK TETAP','" & myDataTableAbsen.Rows(i).Item("keterangan") & " " & tidakMasuk & " HARI'," & potonganTidakMasuk & ",-1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                        newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                        Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                        If (myDataTableAbsen.Rows(i).Item("absen") = "SD") Then
                            newValuesSummary &= "," & myDataTableAbsen.Rows(i).Item("totaltidakmasuk")
                            newFieldsSummary &= ",sakit"
                        ElseIf (myDataTableAbsen.Rows(i).Item("absen") = "IP") Then
                            newValuesSummary &= "," & myDataTableAbsen.Rows(i).Item("totaltidakmasuk")
                            newFieldsSummary &= ",ijinpemerintah"
                        Else
                            alpha += myDataTableAbsen.Rows(i).Item("totaltidakmasuk")
                        End If
                    End If
                Next
                If (alpha > 0) Then
                    newValuesSummary &= "," & alpha
                    newFieldsSummary &= ",alpha"
                End If
                newValuesSummary &= "," & totalPotTidakMasuk
                newFieldsSummary &= ",potongantidakmasuk"
            Else
                If (totalTidakMasuk > 0) Then
                    potonganTidakMasuk = totalTidakMasuk * ((upahPokok / hariKerja1Periode) + ((tunjanganHadir + tunjanganTransport + tunjanganSertifikat) / hariKerja1Periode))
                    lineNr += 1
                    newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','POTONGAN TIDAK TETAP','PROPORSIONAL BARU MASUK DARI TANGGAL " & _periodeMulai & "'," & potonganTidakMasuk & ",-1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                    newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                    Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                    newValuesSummary &= "," & potonganTidakMasuk
                    newFieldsSummary &= ",potongantidakmasuk"
                End If
            End If

            'TUNJANGAN HARI LIBUR NASIONAL (PUBLIC HOLIDAY)
            'CEK KALENDER
            stSQL = "SELECT count(p.tanggal) as banyakmasuk FROM " & CONN_.schemaHRD & ".kalenderperusahaan as kp inner join " & CONN_.schemaHRD & ".trdatapresensi as p on kp.tanggal=p.tanggal and kp.lokasi=p.lokasi WHERE p.nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND p.absen='L' AND p.banyakjamkerjanyata is not null AND kp.libur='True' and kp.katlibur='LIBUR NASIONAL' and p.tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' and p.tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "' and p.lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "';"
            totalMasukHariLiburNasional = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
            If (totalMasukHariLiburNasional > 0) Then
                foundRows = myDataTableKomponenGaji.Select("keterangan='PUBLIC HOLIDAY'")
                If (foundRows.Length > 0) Then
                    tunjanganHariLiburNasional = myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah") * totalMasukHariLiburNasional
                Else
                    tunjanganHariLiburNasional = 0
                End If
                lineNr += 1
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','TUNJANGAN TIDAK TETAP','LIBUR NASIONAL " & totalMasukHariLiburNasional & " HARI'," & tunjanganHariLiburNasional & ",1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                newValuesSummary &= "," & totalMasukHariLiburNasional & "," & tunjanganHariLiburNasional
                newFieldsSummary &= ",publicholiday,totaltunjanganharilibur"
            End If

            'CEK LONG SHIFT
            totalKerjaLongShift = 0
            For i As Integer = 0 To myDataTableDataPresensiSekarang.Rows.Count - 1
                If (myDataTableDataPresensiSekarang.Rows(i).Item("banyakjamkerjanyata") > 12.5) Then
                    'Jika lebih dari 12.5 maka dihitung long shift
                    totalKerjaLongShift += 1
                End If
            Next
            If (totalKerjaLongShift > 0) Then
                'DAPAT TUNJANGAN LONG SHIFT
                foundRows = myDataTableKomponenGaji.Select("keterangan='LONG SHIFT'")
                If (foundRows.Length > 0) Then
                    tunjanganLongShift = myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah") * totalKerjaLongShift
                Else
                    tunjanganLongShift = 0
                End If
                lineNr += 1
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','TUNJANGAN TIDAK TETAP','LONG SHIFT " & totalKerjaLongShift & " HARI'," & tunjanganLongShift & ",1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                newValuesSummary &= "," & totalKerjaLongShift & "," & tunjanganLongShift
                newFieldsSummary &= ",longshift,totaltunjanganlongshift"
            End If

            'TUSLAH
            Dim jumlahKaryawan As UShort
            stSQL = "select sum(d.tuslah) as totaltuslah from trjualh as h inner join trjuald as d on h.noinvoice=d.noinvoice and h.entiti=d.entiti where h.entiti='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' and h.tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' and h.tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "';"
            totalTuslah = myCDBOperation.GetDataIndividual(CONN_.dbMySql, CONN_.comm, CONN_.reader, stSQL)
            If (totalTuslah > 0) Then
                'Jika ada tuslah, maka dibagi rata untuk semua apotekernya
                jumlahKaryawan = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "nip", CONN_.schemaHRD & ".mskaryawanaktif", "Count", "perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' and departemen='" & myCStringManipulation.SafeSqlLiteral(_departemen) & "'", CONN_.dbType)
                tuslahDibagikan = Math.Ceiling(totalTuslah / jumlahKaryawan)

                lineNr += 1
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','TUNJANGAN TIDAK TETAP','TUSLAH YANG DIBAGIKAN'," & tuslahDibagikan & ",1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                'newValuesSummary &= "," & tuslahDibagikan
                'newFieldsSummary &= ",tuslah"
            End If
            '==========================================================================================================================================

            '==========================================================================================================================================
            '10. LAIN2
            Dim tambahanLain2 As Double = 0
            'Dim tambahanSisaCuti As Double = 0
            If (_prosesIndividu) Then
                'LAIN2
                Dim KetLain2 As String
                Dim keterangan As String
                If (Trim(tbLain2.Text).Length > 0) Then
                    lineNr += 1

                    If (cboFaktorQty.SelectedItem = 1) Then
                        KetLain2 = "TUNJANGAN TIDAK TETAP"
                    Else
                        KetLain2 = "POTONGAN TIDAK TETAP"
                    End If
                    If (Trim(rtbLain2.Text).Length > 0) Then
                        keterangan = Trim(rtbLain2.Text).ToUpper
                    Else
                        keterangan = ""
                    End If
                    tambahanLain2 = Double.Parse(tbLain2.Text)
                    newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & KetLain2 & "','" & keterangan & "'," & tambahanLain2 & "," & cboFaktorQty.SelectedItem & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                    newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                    Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
                End If
            End If
            komponenLain2 += (tambahanLain2 * cboFaktorQty.SelectedItem)
            If (komponenLain2 <> 0) Then
                newValuesSummary &= "," & komponenLain2
                newFieldsSummary &= ",lain2"
            End If

            totalTunjangan = tunjanganSertifikat + tunjanganHadir + tunjanganTransport + tunjanganHariLiburNasional + tunjanganLongShift + IIf(komponenLain2 > 0, komponenLain2, 0) + tuslahDibagikan
            totalPotongan += potonganTidakMasuk + nominalTerlambat + nominalTidakCheckClock + IIf(komponenLain2 < 0, -komponenLain2, 0)

            upahBersih = upahPokok + totalTunjangan - totalPotongan
            upahYangDibayar = Math.Ceiling(upahBersih / 100) * 100
            Call myCDBOperation.UpdateData(_conn, _comm, tableNameHeader, "totaltunjangan=" & totalTunjangan & ",totalpotongan=" & totalPotongan & ",upahbersih=" & upahBersih & ",upahyangdibayar=" & upahYangDibayar, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "'")

            newValuesSummary &= "," & upahBersih & "," & upahYangDibayar & "," & ADD_INFO_.newValues
            newFieldsSummary &= ",upahtotal,upahyangdibayar," & ADD_INFO_.newFields

            Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableNameSummary, newValuesSummary, newFieldsSummary)
            '==========================================================================================================================================
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ProsesPayrollApotek Error")
        Finally
            Call myCDBConnection.CloseConn(_conn)
            Call myCDBConnection.CloseConn(CONN_.dbMySql)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnProsesIndividu_Click(sender As Object, e As EventArgs) Handles btnProsesIndividu.Click
        Try
            Dim banyakHariDalamSebulan As Byte
            Dim isExist As Boolean

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            'UPDATE HARI SABTU DAN MINGGU LIBUR KECUALI UNTUK SECURITY
            Dim queryBuilder As New Text.StringBuilder
            queryBuilder.Clear()
            queryBuilder.Append("update " & CONN_.schemaHRD & ".trdatapresensi as a set ijin='TM',absen='L',updated_at=clock_timestamp() WHERE (a.nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "') AND (a.tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') and not exists(select 1 from " & CONN_.schemaHRD & ".kalenderperusahaan as kp where (kp.tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and kp.tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') and (kp.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (kp.libur='False') and (a.tanggal=kp.tanggal)) and (a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (trim(to_char(a.tanggal, 'day')) IN ('saturday','sunday')) AND (a.bagian='DOKTER') AND (a.jamlembur is null) AND (a.spkmulai is null and a.spkselesai is null);")
            If Not (myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString)) Then
                Call myCShowMessage.ShowWarning("Ada kesalahan saat eksekusi perintah update libur hari sabtu dan minggu" & ControlChars.NewLine & "Silahkan hubungi EDP yang bertugas!")
            End If

            'CEK TANGGAL
            If (dtpPeriodeMulai.Value.Date >= dtpPeriodeSelesai.Value.Date) Then
                Call myCShowMessage.ShowWarning("Tanggal periode mulai tidak boleh lebih besar atau sama dengan tanggal periode selesai!")
                Exit Sub
            End If

            'CEK KARYAWAN
            If (cboKaryawanIndividu.SelectedIndex = -1) Then
                Call myCShowMessage.ShowWarning("Tentukan dulu karyawannya!")
                Exit Sub
            End If

            'CEK LAIN2
            If (rtbLain2.Text.Length > 255) Then
                Call myCShowMessage.ShowWarning("Catatan HRD tidak boleh lebih dari 255 karakter!")
                Exit Sub
            End If

            banyakHariDalamSebulan = DateTime.DaysInMonth(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month)
            If (strKelompok = "NON STAFF") Then
                If (dtpPeriodeMulai.Value.Month <> dtpPeriodeSelesai.Value.Month) Then
                    Call myCShowMessage.ShowWarning("Proses payroll harus dalam 1 bulan yang sama")
                    Exit Sub
                Else
                    If (dtpPeriodeMulai.Value.Day = 1 Or dtpPeriodeMulai.Value.Day = 16) Then
                    Else
                        Call myCShowMessage.ShowWarning("Periode awal harus tanggal 1 atau tanggal 16")
                        Exit Sub
                    End If
                    If (dtpPeriodeSelesai.Value.Day = 15 Or dtpPeriodeSelesai.Value.Day = banyakHariDalamSebulan) Then
                    Else
                        Call myCShowMessage.ShowWarning("Periode akhir harus tanggal 15 atau tanggal akhir di bulan " & dtpPeriodeMulai.Value.Month)
                        Exit Sub
                    End If
                End If
            ElseIf (strKelompok = "STAFF") Then
                If (dtpPeriodeMulai.Value.Day <> 21) Then
                    Call myCShowMessage.ShowWarning("Periode awal harus tanggal 21")
                    Exit Sub
                End If
                If (dtpPeriodeSelesai.Value.Day <> 20 And dtpPeriodeSelesai.Value.Month <> dtpPeriodeMulai.Value.AddMonths(1).Month) Then
                    Call myCShowMessage.ShowWarning("Periode akhir harus tanggal 20 di bulan " & MonthName(dtpPeriodeMulai.Value.AddMonths(1).Month))
                    Exit Sub
                End If
            End If

            'Cek apakah gaji pokoknya sudah diinputkan
            isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaHRD & ".mskomponentetappayroll", "komponengaji='GAJI POKOK' AND nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "'")
            If isExist Then
                'CEK APAKAH SUDAH ADA ATAU BELUM
                isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableNameHeader, "nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "' AND periodemulai='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND periodeselesai='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "'")
                If (isExist) Then
                    Dim isConfirm = myCShowMessage.GetUserResponse("Karyawan " & DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("nama") & " sudah pernah di proses payroll nya" & ControlChars.NewLine & "Apakah mau memproses ulang payroll untuk karyawan " & DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("nama") & "?")
                    If (isConfirm = DialogResult.Yes) Then
                        'Hapus dulu data yang lama
                        'Dim queryBuilder As New Text.StringBuilder
                        queryBuilder.Clear()
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameSummary, "",, tableKey & " IN (SELECT " & tableKey & " FROM " & tableNameHeader & " WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "'))"))
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameProcessedDetail & " as s", "",, "EXISTS(SELECT 1 FROM " & tableNameHeader & " as h WHERE (s." & tableKey & "=h." & tableKey & ") AND (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') AND (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (h.nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "'))"))
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameDetail & " as s", "",, "EXISTS(SELECT 1 FROM " & tableNameHeader & " as h WHERE (s." & tableKey & "=h." & tableKey & ") AND (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') AND (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (h.nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "'))"))
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameHeader, "",, "(perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "')"))
                        If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                            If (DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("departemen") = "APOTEK") Then
                                Call ProsesPayrollApotek(CONN_.dbMain, CONN_.comm, CONN_.reader, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("idk"), cboKaryawanIndividu.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("nama"), dtpPeriodeMulai.Value.Date, dtpPeriodeSelesai.Value.Date, cboLokasi.SelectedValue, cboPerusahaan.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("departemen"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("kelompok"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("katpenggajian"), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), rtbCatatanHRD.Text, True)
                            ElseIf (DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("departemen") = "KLINIK") Then
                                Call ProsesPayrollDokter(CONN_.dbMain, CONN_.comm, CONN_.reader, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("idk"), cboKaryawanIndividu.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("nama"), dtpPeriodeMulai.Value.Date, dtpPeriodeSelesai.Value.Date, cboLokasi.SelectedValue, cboPerusahaan.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("departemen"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("kelompok"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("katpenggajian"), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), rtbCatatanHRD.Text, True)
                            End If
                            Call btnTampilkan_Click(sender, e)
                        Else
                            Call myCShowMessage.ShowWarning("Penghapusan data payroll lama gagal!" & ControlChars.NewLine & "Silahkan coba lagi!")
                        End If
                    Else
                        Call myCShowMessage.ShowWarning("Proses payroll dibatalkan!")
                    End If
                Else
                    'Kalau belum ada, langsung di proses saja
                    If (DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("departemen") = "APOTEK") Then
                        Call ProsesPayrollApotek(CONN_.dbMain, CONN_.comm, CONN_.reader, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("idk"), cboKaryawanIndividu.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("nama"), dtpPeriodeMulai.Value.Date, dtpPeriodeSelesai.Value.Date, cboLokasi.SelectedValue, cboPerusahaan.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("departemen"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("kelompok"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("katpenggajian"), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), rtbCatatanHRD.Text, True)
                    ElseIf (DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("departemen") = "KLINIK") Then
                        Call ProsesPayrollDokter(CONN_.dbMain, CONN_.comm, CONN_.reader, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("idk"), cboKaryawanIndividu.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("nama"), dtpPeriodeMulai.Value.Date, dtpPeriodeSelesai.Value.Date, cboLokasi.SelectedValue, cboPerusahaan.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("departemen"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("kelompok"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("katpenggajian"), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), rtbCatatanHRD.Text, True)
                    End If
                    Call btnTampilkan_Click(sender, e)
                End If
            Else
                Call myCShowMessage.ShowWarning("Gaji Pokok untuk karyawan " & DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("nama") & " belum ditentukan" & ControlChars.NewLine & "Tidak bisa melakukan proses payroll!")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesIndividu_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        Try
            If (dtpPeriodeMulai.Value.Date >= dtpPeriodeSelesai.Value.Date) Then
                Call myCShowMessage.ShowWarning("Tanggal periode mulai tidak boleh lebih besar atau sama dengan tanggal periode selesai!")
            Else
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                If (cboKaryawanIndividu.SelectedIndex <> -1) Then
                    stSQL = "SELECT h." & tableKey & ",h.idk,h.nip,h.nama,h.lokasi,h.perusahaan,h.departemen,h.divisi,h.bagian,h.kelompok,h.katpenggajian,h.tanggalpenggajian,h.periode,h.periodemulai,h.periodeselesai,h.upahpokok,h.totaltunjangan,h.totalpotongan,h.upahbersih,h.upahyangdibayar,h.keterangan as catatanhrd,d.linenr,d.komponengaji,d.keterangan,d.persen,d.rupiah,d.faktorqty
                            FROM " & tableNameHeader & " as h inner join " & tableNameDetail & " as d on h." & tableKey & "=d." & tableKey & "
                            WHERE h.nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "' and h.periodemulai='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and h.periodeselesai='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "'
                            ORDER BY d.faktorqty DESC,d.linenr ASC;"

                    Dim rdlcRptSource As New ReportDataSource
                    Dim myDataTable As New DataTable
                    Dim reportType As String
                    Dim docType As String
                    Me.rptViewer.Reset()

                    docType = "SlipPayroll"

                    myDataTable = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, docType)
                    reportType = "rpt" & docType
                    rdlcRptSource.Name = "dtSet" & docType

                    Me.rptViewer.LocalReport.DataSources.Clear()
                    rdlcRptSource.Value = myDataTable
                    Me.rptViewer.LocalReport.DataSources.Add(rdlcRptSource)
                    'AddHandler Me.rptViewer.LocalReport.SubreportProcessing, AddressOf MySubreportCompanyProfile
                    Me.rptViewer.LocalReport.EnableExternalImages = True
                    Me.rptViewer.LocalReport.ReportEmbeddedResource = "FormProsesPayroll." & reportType & ".rdlc"
                    Me.Text = docType.ToUpper
                    Me.rptViewer.RefreshReport()
                Else
                    Call myCShowMessage.ShowWarning("Silahkan pilih karyawannya dulu!")
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTampilkan_Click Error")
        Finally
            If (dtpPeriodeMulai.Value.Date <= dtpPeriodeSelesai.Value.Date) Then
                Call myCDBConnection.CloseConn(CONN_.dbMain)
                Me.Cursor = Cursors.Default
            End If
        End Try
    End Sub

    Private Sub btnProsesSemua_Click(sender As Object, e As EventArgs) Handles btnProsesSemua.Click
        Try
            If (cboPerusahaan.SelectedIndex <> -1 And cboLokasi.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim queryBuilder As New Text.StringBuilder
                'UPDATE HARI SABTU DAN MINGGU LIBUR KECUALI UNTUK SECURITY
                queryBuilder.Clear()
                queryBuilder.Append("update " & CONN_.schemaHRD & ".trdatapresensi as a set ijin='TM',absen='L',updated_at=clock_timestamp() WHERE (a.tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') and not exists(select 1 from " & CONN_.schemaHRD & ".kalenderperusahaan as kp where (kp.tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and kp.tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') and (kp.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (kp.libur='False') and (a.tanggal=kp.tanggal)) and (a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (trim(to_char(a.tanggal, 'day')) IN ('saturday','sunday')) AND (a.divisi<>'SECURITY') AND (a.jamlembur is null) AND (a.spkmulai is null and a.spkselesai is null);")
                If Not (myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString)) Then
                    Call myCShowMessage.ShowWarning("Ada kesalahan saat eksekusi perintah update libur hari sabtu dan minggu" & ControlChars.NewLine & "Silahkan hubungi EDP yang bertugas!")
                End If

                Dim myDataTablePresensi As New DataTable
                stSQL = "SELECT p.idk,p.nip,p.nama,p.departemen,p.divisi,p.bagian,p.kelompok,p.katpenggajian, p.statuskepegawaian 
                        FROM " & CONN_.schemaHRD & ".trdatapresensi  as p
                        WHERE (p.parentnip is null) AND (p.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (p.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (p.kelompok='" & strKelompok & "') AND (p.tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND p.tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND EXISTS(SELECT 1 FROM " & CONN_.schemaHRD & ".trpayrollheader as h WHERE (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') and (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') and p.nip=h.nip) 
                        GROUP BY p.idk,p.nip,p.nama,p.departemen,p.divisi,p.bagian,p.kelompok,p.katpenggajian, p.statuskepegawaian  
                        ORDER BY p.nama;"
                myDataTablePresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Presensi")

                If (myDataTablePresensi.Rows.Count > 0) Then
                    'Sudah ada karyawan yang payroll nya sudah di proses, ditawarkan apa mau diproses ulang atau hanya proses yang belum diproses saja
                    Dim isConfirm = myCShowMessage.GetUserResponseWithCancel("Untuk periode " & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & " sampai " & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & " sudah ada data karyawan yang sudah diproses payrollnya" & ControlChars.NewLine & "Apakah mau memproses ulang semua?" & ControlChars.NewLine & "YES: Proses ulang semua ; NO: Proses yang belum saja; Cancel: Tunda proses")
                    If isConfirm = DialogResult.Cancel Then
                        'Batalkan proses, tidak melakukan apa2
                        Call myCShowMessage.ShowWarning("Proses Dibatalkan")
                        myDataTablePresensi.Clear()
                        myDataTablePresensi = Nothing
                    ElseIf isConfirm = DialogResult.No Then
                        'Proses yang belum diproses saja

                        stSQL = "SELECT p.idk,p.nip,p.nama,p.departemen,p.divisi,p.bagian,p.kelompok,p.katpenggajian, p.statuskepegawaian  
                                FROM " & CONN_.schemaHRD & ".trdatapresensi  as p
                                WHERE (p.parentnip is null) AND (p.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (p.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (p.kelompok='" & strKelompok & "') AND (p.tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND p.tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND NOT EXISTS(SELECT 1 FROM " & CONN_.schemaHRD & ".trpayrollheader as h WHERE (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') and (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') and p.nip=h.nip) 
                                GROUP BY p.idk,p.nip,p.nama,p.departemen,p.divisi,p.bagian,p.kelompok,p.katpenggajian, p.statuskepegawaian  
                                ORDER BY p.nama;"
                        myDataTablePresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Presensi")
                    ElseIf isConfirm = DialogResult.Yes Then
                        'Proses semuanya ulang
                        queryBuilder.Clear()

                        'Hapus dulu data yang lama
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameSummary, "",, tableKey & " IN (SELECT " & tableKey & " FROM " & tableNameHeader & " WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "'))"))
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameProcessedDetail & " as s", "",, "EXISTS(SELECT 1 FROM " & tableNameHeader & " as h WHERE (s." & tableKey & "=h." & tableKey & ") and (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') AND (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "'))"))
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameDetail & " as s", "",, "EXISTS(SELECT 1 FROM " & tableNameHeader & " as h WHERE (s." & tableKey & "=h." & tableKey & ") and (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') AND (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "'))"))
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameHeader, "",, "(perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "')"))

                        If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                            stSQL = "SELECT idk,nip,nama,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian  
                                    FROM " & CONN_.schemaHRD & ".trdatapresensi 
                                    WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') 
                                    GROUP BY idk,nip,nama,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian 
                                    ORDER BY nama;"
                            myDataTablePresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Presensi")
                        Else
                            Call myCShowMessage.ShowWarning("Penghapusan data payroll lama gagal!" & ControlChars.NewLine & "Silahkan coba lagi!")
                        End If
                    End If
                Else
                    'Jika memang masih kosong data payroll nya
                    'myDataTablePresensi.Clear()
                    stSQL = "SELECT idk,nip,nama,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian  
                            FROM " & CONN_.schemaHRD & ".trdatapresensi 
                            WHERE (parentnip is null) AND (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') 
                            GROUP BY idk,nip,nama,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian 
                            ORDER BY nama;"
                    myDataTablePresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Presensi")
                End If

                If Not IsNothing(myDataTablePresensi) Then
                    For i As Integer = 0 To myDataTablePresensi.Rows.Count - 1
                        'Cek apakah gaji pokoknya sudah diinputkan
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaHRD & ".mskomponentetappayroll", "komponengaji='GAJI POKOK' AND nip='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("nip")) & "'")
                        If isExist Then
                            If (myDataTablePresensi.Rows(i).Item("departemen") = "APOTEK") Then
                                Call ProsesPayrollApotek(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTablePresensi.Rows(i).Item("idk"), myDataTablePresensi.Rows(i).Item("nip"), myDataTablePresensi.Rows(i).Item("nama"), dtpPeriodeMulai.Value.Date, dtpPeriodeSelesai.Value.Date, cboLokasi.SelectedValue, cboPerusahaan.SelectedValue, myDataTablePresensi.Rows(i).Item("departemen"), myDataTablePresensi.Rows(i).Item("kelompok"), myDataTablePresensi.Rows(i).Item("katpenggajian"), IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("statuskepegawaian")), Nothing, myDataTablePresensi.Rows(i).Item("statuskepegawaian")), IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("divisi")), Nothing, myDataTablePresensi.Rows(i).Item("divisi")), IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("bagian")), Nothing, myDataTablePresensi.Rows(i).Item("bagian")), Nothing, True)
                            ElseIf (myDataTablePresensi.Rows(i).Item("departemen") = "KLINIK") Then
                                Call ProsesPayrollDokter(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTablePresensi.Rows(i).Item("idk"), myDataTablePresensi.Rows(i).Item("nip"), myDataTablePresensi.Rows(i).Item("nama"), dtpPeriodeMulai.Value.Date, dtpPeriodeSelesai.Value.Date, cboLokasi.SelectedValue, cboPerusahaan.SelectedValue, myDataTablePresensi.Rows(i).Item("departemen"), myDataTablePresensi.Rows(i).Item("kelompok"), myDataTablePresensi.Rows(i).Item("katpenggajian"), IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("statuskepegawaian")), Nothing, myDataTablePresensi.Rows(i).Item("statuskepegawaian")), IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("divisi")), Nothing, myDataTablePresensi.Rows(i).Item("divisi")), IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("bagian")), Nothing, myDataTablePresensi.Rows(i).Item("bagian")), Nothing, True)
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Gaji Pokok untuk karyawan " & myDataTablePresensi.Rows(i).Item("nama") & " belum ditentukan" & ControlChars.NewLine & "Tidak bisa melakukan proses payroll untuk karyawan tersebut!")
                        End If

                        If (i Mod 50 = 0) Then
                            GC.Collect()
                        End If
                    Next
                    Call myCShowMessage.ShowInfo("Proses payroll " & strKelompok & " " & cboPerusahaan.SelectedValue & " untuk lokasi " & cboLokasi.SelectedValue & " dari periode " & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & " sampai periode " & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & " selesai!")
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesSemua_Click Error")
        Finally
            'If (cboPerusahaan.SelectedIndex <> -1 And cboLokasi.SelectedIndex <> -1) Then
            'MsgBox("tes")
            Call myCDBConnection.CloseConn(CONN_.dbMain)
            Me.Cursor = Cursors.Default
            'End If
        End Try
    End Sub

    Private Sub tbLain2_Validated(sender As Object, e As EventArgs) Handles tbLain2.Validated
        Try
            tbLain2.Text = myCStringManipulation.CleanInputInteger(tbLain2.Text)
            If (Trim(tbLain2.Text).Length > 0) Then
                myCStringManipulation.ValidateTextBoxNumber(tbLain2, tbLain2.Name)
                If (Trim(rtbLain2.Text).Length = 0) Then
                    rtbLain2.Text = "Lain2"
                End If
            Else
                rtbLain2.Clear()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbLain2_Validated Error")
        End Try
    End Sub

    Private Sub tbLain2_Enter(sender As Object, e As EventArgs) Handles tbLain2.Enter
        Try
            If (Trim(tbLain2.Text).Length > 0) Then
                tbLain2.Text = Double.Parse(tbLain2.Text)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbLain2_Enter Error")
        End Try
    End Sub

    Private Sub rtbKeterangan_Validated(sender As Object, e As EventArgs) Handles rtbLain2.Validated
        Try
            rtbLain2.Text = Trim(rtbLain2.Text)
            If (rtbLain2.Text.Length > 255) Then
                Call myCShowMessage.ShowWarning("Keterangan tidak boleh lebih dari 255 karakter!")
            Else
                rtbLain2.Text = rtbLain2.Text.ToUpper
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbLain2_Enter Error")
        End Try
    End Sub

    Private Sub btnCetakRekap_Click(sender As Object, e As EventArgs) Handles btnCetakRekap.Click
        Try
            If (cboPeriode.SelectedIndex <> -1 And cboKuartal.SelectedIndex <> -1) Then
                stSQL = "SELECT h.nopayroll,h.lokasi,h.perusahaan,h.departemen,h.divisi,h.bagian,h.periode,h.periodemulai,h.periodeselesai,h.idk,h.nip,h.nama,s.tanggalmasuk,s.masakerjariil,s.masakerja,s.upahpokokperbulan,s.tunjanganmasakerja,s.tunjangantransport,s.tunjanganhadir,s.totalharikerjariil,s.totalharikerja,s.totalkerjashift,s.jamlemburharibiasa1,s.jamlemburharibiasa2,s.jamlemburharilibur1,s.jamlemburharilibur2,s.jamlemburharilibur3,s.totaljamlembur,s.upahkerja,s.upahlembur,s.premi,s.tunjanganshift,s.lain2,s.potonganjhtjpbpjs,s.potonganpph,s.upahtotal,s.upahyangdibayar,s.terlambat,s.dendaterlambat,s.sakit,s.alpha,s.ijinpemerintah,s.longshift,s.publicholiday,s.tunjangansertifikat,s.tidakcheckclock,s.dendatidakcheckclock,s.totaltunjanganharilibur,s.totaltunjanganlongshift,s.potongantidakmasuk,s.totaljamkerja
                        FROM (" & tableNameHeader & " as h inner join " & tableNameSummary & " as s on h." & tableKey & "=s." & tableKey & ")
                        WHERE periode='" & cboPeriode.SelectedValue & "' and h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and h.kelompok='" & strKelompok & "'
                        GROUP BY h.nopayroll,h.lokasi,h.perusahaan,h.departemen,h.divisi,h.bagian,h.periode,h.periodemulai,h.periodeselesai,h.idk,h.nip,h.nama,s.tanggalmasuk,s.masakerjariil,s.masakerja,s.upahpokokperbulan,s.tunjanganmasakerja,s.tunjangantransport,s.tunjanganhadir,s.totalharikerjariil,s.totalharikerja,s.totalkerjashift,s.jamlemburharibiasa1,s.jamlemburharibiasa2,s.jamlemburharilibur1,s.jamlemburharilibur2,s.jamlemburharilibur3,s.totaljamlembur,s.upahkerja,s.upahlembur,s.premi,s.tunjanganshift,s.lain2,s.potonganjhtjpbpjs,s.potonganpph,s.upahtotal,s.upahyangdibayar,s.terlambat,s.dendaterlambat,s.sakit,s.alpha,s.ijinpemerintah,s.longshift,s.publicholiday,s.tunjangansertifikat,s.tidakcheckclock,s.dendatidakcheckclock,s.totaltunjanganharilibur,s.totaltunjanganlongshift,s.potongantidakmasuk,s.totaljamkerja
                        ORDER BY h.departemen,h.nama;"
                Dim frmdisplayreport As New FormDisplayReport.FormDisplayReport(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, stSQL, "RekapPayroll",, Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strKelompok.ToLower()).Replace(" ", ""))
                Call myCFormManipulation.GoToForm(Me.MdiParent, frmdisplayreport)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCetakRekap_Click Error")
        End Try
    End Sub

    Private Sub cboPeriode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPeriode.SelectedIndexChanged, cboKuartal.SelectedIndexChanged
        Try
            If (isDataPrepared And cboPeriode.SelectedIndex <> -1 And cboKuartal.SelectedIndex <> -1) Then
                Dim bulan As String
                Dim tahun As Short
                Dim periodeMulai As Date
                Dim periodeSelesai As Date

                bulan = myCStringManipulation.CleanInputAlphabet(myCStringManipulation.SafeSqlLiteral(cboPeriode.SelectedValue))
                tahun = myCStringManipulation.CleanInputInteger(myCStringManipulation.SafeSqlLiteral(cboPeriode.SelectedValue))

                If (rbNonStaff.Checked) Then
                    periodeMulai = CDate(IIf(cboKuartal.SelectedItem = "Q1", 1, 16) & "-" & bulan & "-" & tahun)
                    periodeSelesai = CDate(IIf(cboKuartal.SelectedItem = "Q1", 15, Date.DaysInMonth(tahun, Month(CDate("1-" & bulan & "-" & tahun)))) & "-" & bulan & "-" & tahun)
                Else
                    periodeMulai = CDate("21-" & bulan & "-" & tahun)
                    periodeSelesai = periodeMulai.AddMonths(1).AddDays(-1)
                End If

                dtpPeriodeMulai.Value = periodeMulai
                dtpPeriodeSelesai.Value = periodeSelesai

                If (cboPerusahaan.SelectedIndex <> -1 And cboLokasi.SelectedIndex <> -1) Then
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    stSQL = "SELECT concat(nama,' || ',nip,' || ',bagian) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE (tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') GROUP BY concat(nama,' || ',nip,' || ',departemen),idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian ORDER BY karyawan;"
                    Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawanIndividu, "T_" & cboKaryawanIndividu.Name, "nip", "karyawan", isCboPrepared, True)

                    Call myCDBConnection.CloseConn(CONN_.dbMain)
                    Me.Cursor = Cursors.Default
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboPeriode_SelectedIndexChanged Error")
        End Try
    End Sub
End Class
