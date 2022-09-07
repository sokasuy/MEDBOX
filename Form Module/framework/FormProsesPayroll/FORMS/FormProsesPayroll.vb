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

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='periode' order by kode;"
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

            rbNonStaff.Checked = True

            If (Now.Day <= 15) Then
                dtpPeriodeMulai.Value = DateSerial(Now.Year, Now.Month - 1, 16)
                dtpPeriodeSelesai.Value = DateSerial(Now.Year, Now.Month - 1, Date.DaysInMonth(Now.Year, Now.Month - 1))
                For i As Short = 0 To cboPeriode.Items.Count - 1
                    If (DirectCast(cboPeriode.Items(i), DataRowView).Item("keterangan") = MonthName(Now.Month - 1, True).ToUpper & Now.Year) Then
                        cboPeriode.SelectedIndex = i
                    End If
                Next
                cboKuartal.SelectedIndex = 1
            Else
                dtpPeriodeMulai.Value = DateSerial(Now.Year, Now.Month, 1)
                dtpPeriodeSelesai.Value = DateSerial(Now.Year, Now.Month, 15)
                For i As Short = 0 To cboPeriode.Items.Count - 1
                    If (DirectCast(cboPeriode.Items(i), DataRowView).Item("keterangan") = MonthName(Now.Month, True).ToUpper & Now.Year) Then
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

                'If Not (sender Is cboDepartemen) Then
                '    isDeptReady = False
                '    stSQL = "SELECT departemen FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' AND perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' AND kelompok='" & strKelompok & "' AND tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "' GROUP BY departemen ORDER BY departemen;"
                '    Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboDepartemen, myBindingDepartemen, cboDepartemen, "T_" & cboDepartemen.Name, "departemen", "departemen", isCboPrepared, True)
                '    isDeptReady = True
                'End If

                'If (sender Is cboDepartemen And isDeptReady And cboDepartemen.SelectedIndex <> -1) Then
                '    stSQL = "SELECT concat(nama,' || ',nip) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian,katpenggajian FROM " & CONN_.schemaHRD & ".mskaryawanaktif " & IIf(USER_.lokasi = "ALL", "", "WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (departemen='" & myCStringManipulation.SafeSqlLiteral(cboDepartemen.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "')") & " GROUP BY concat(nama,' || ',nip),idk,nip,nama,perusahaan,departemen,divisi,bagian,katpenggajian ORDER BY karyawan;"
                '    Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawanIndividu, "T_" & cboKaryawanIndividu.Name, "nip", "karyawan", isCboPrepared, True)
                'Else
                'stSQL = "SELECT concat(nama,' || ',nip,' || ',departemen) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian,katpenggajian FROM " & CONN_.schemaHRD & ".mskaryawanaktif " & IIf(USER_.lokasi = "ALL", "", "WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "')") & " GROUP BY concat(nama,' || ',nip,' || ',departemen),idk,nip,nama,perusahaan,departemen,divisi,bagian,katpenggajian ORDER BY karyawan;"
                'Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawanIndividu, "T_" & cboKaryawanIndividu.Name, "nip", "karyawan", isCboPrepared, True)
                'End If

                stSQL = "SELECT concat(nama,' || ',nip,' || ',departemen) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE (tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') GROUP BY concat(nama,' || ',nip,' || ',departemen),idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian ORDER BY karyawan;"
                Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawanIndividu, "T_" & cboKaryawanIndividu.Name, "nip", "karyawan", isCboPrepared, True)

                'Call myCFormManipulation.ResetForm(gbView)

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

                stSQL = "SELECT concat(nama,' || ',nip) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian FROM " & CONN_.schemaHRD & ".mskaryawanaktif " & IIf(USER_.lokasi = "ALL", "", "WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "')") & " GROUP BY concat(nama,' || ',nip),idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian ORDER BY karyawan;"
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

    Private Sub ProsesPayroll(_conn As Object, _comm As Object, _reader As Object, _idk As String, _nip As String, _nama As String, _periodeMulai As Date, _periodeSelesai As Date, _lokasi As String, _perusahaan As String, _departemen As String, _kelompok As String, _katpenggajian As String, _statuskepegawaian As String, _divisi As String, _bagian As String, Optional _catHRD As String = Nothing, Optional _prosesIndividu As Boolean = False)
        Try
            Dim myDataTableKomponenGaji As New DataTable
            Dim myDataTablePresensi As New DataTable
            Dim myDataTableLemburan As New DataTable
            Dim myDataTableProcessedDetailLalu As New DataTable
            Dim myDataTableDataPresensiSekarang As New DataTable
            Dim myDataTableDataPresensiLalu As New DataTable
            Dim myDataTableInfoPayrollLalu As New DataTable
            Dim myDataTableDataPresensiLaluChanged As New DataTable
            Dim masaKerjaRiil As Double
            Dim tahunMasaKerja As Byte
            Dim tunjanganMasaKerja As Integer
            Dim jamLembur(1) As Double
            Dim jamLemburLama(1) As Double
            Dim totalJamLemburDiperhitungkan As Double
            Dim totalJamLemburDiperhitungkanSusulan As Double
            Dim strNoPayroll As String
            Dim strPeriodeGaji As String
            Dim foundRows As DataRow()
            Dim upahPokok As Double
            Dim upahBersih As Double
            Dim upahYangDibayar As Double
            Dim totalTunjangan As Double
            Dim totalPotongan As Double
            Dim lineNr As Byte
            Dim counter As Double = 0
            Dim faktorPengaliLembur As Double
            Dim totalJamLemburHariBiasa(2) As Double
            Dim upahKerja As Double
            Dim totalHariKerja As Double
            Dim totalJamLemburHariLibur(3) As Double
            Dim totalKerjaShift As Byte
            Dim totalTunjanganShift As Double
            'Dim totalJamLembur As Double
            Dim komponenLain2 As Double
            Dim upahLembur As Double
            Dim kurangJamKerja As Double
            Dim potonganTidakMasukFull As Double
            Dim hariKerja1Periode As Integer
            Dim periodeMulaiQSebelumnya As Date
            Dim periodeSelesaiQSebelumnya As Date
            'Dim strPayrollQSebelumnya As String
            Dim periodeLalu As String = Nothing
            Dim tanggalMasuk As Date
            Dim isBerubah As Boolean
            Dim absen(1) As String
            'Dim tanggalMulaiLembur As Date
            'Dim tanggalSelesaiLembur As Date

            Dim newValuesSummary As String
            Dim newFieldsSummary As String

            Dim revisiJamKerjaPeriodeLalu As Double
            Dim revisiShiftPeriodeLalu As Integer
            Dim revisiLemburPeriodeLalu As TimeSpan
            Dim revisiUpahKerjaPeriodeLalu As Double
            Dim revisiTunjanganShiftPeriodeLalu As Double
            Dim revisiUpahLemburPeriodeLalu As Double
            Dim revisiTunjanganPeriodeLalu As Double
            Dim revisiPotonganPeriodeLalu As Double

            tanggalMasuk = myCDBOperation.GetSpecificRecord(_conn, _comm, _reader, "tanggalmasuk", CONN_.schemaHRD & ".mskaryawan",, "idk='" & myCStringManipulation.SafeSqlLiteral(_idk) & "'")

            newValuesSummary = "'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & Format(tanggalMasuk, "dd-MMM-yyyy") & "'"
            newFieldsSummary = "idk,nip,nama,tanggalmasuk"

            '---1. AMBIL KOMPONEN GAJI
            If (_kelompok = "NON STAFF") Then
                If (dtpPeriodeSelesai.Value.Day <= 15) Then
                    stSQL = "SELECT komponengaji,keterangan,persen,rupiah,faktorqty FROM " & CONN_.schemaHRD & ".mskomponentetappayroll WHERE nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' ORDER BY komponengaji ASC;"
                Else
                    stSQL = "SELECT komponengaji,keterangan,persen,rupiah,faktorqty FROM " & CONN_.schemaHRD & ".mskomponentetappayroll WHERE nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' and kuartal1='False' ORDER BY komponengaji ASC;"
                End If
            Else
                stSQL = "SELECT komponengaji,keterangan,persen,rupiah,faktorqty FROM " & CONN_.schemaHRD & ".mskomponentetappayroll WHERE nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' ORDER BY komponengaji ASC;"
            End If
            myDataTableKomponenGaji = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_KomponenGaji")

            '---2A. AMBIL BANYAK TAHUN KERJA, DIHITUNG TOTAL BULANNYA DIBAGI 12 DAN DILAKUKAN PEMBULATAN SEPERTI BIASA (>0.5 naik ke 1, <0.5 turun ke 0)
            stSQL = "SELECT ((EXTRACT(YEAR FROM age)) + (EXTRACT(MONTH FROM age)/12) + (EXTRACT(DAY FROM age)/365)) AS months_between FROM (SELECT age(CURRENT_DATE,tanggalmasuk) as age FROM " & CONN_.schemaHRD & ".mskaryawan WHERE idk='" & myCStringManipulation.SafeSqlLiteral(_idk) & "') AS t(age);"
            masaKerjaRiil = myCDBOperation.GetDataIndividual(_conn, _comm, _reader, stSQL)
            tahunMasaKerja = Math.Floor(masaKerjaRiil)
            '---2B. AMBIL TUNJANGAN MASA KERJA
            If (IsNothing(_statuskepegawaian) Or (_statuskepegawaian = "TETAP")) And (_kelompok = "NON STAFF") Then
                stSQL = "SELECT tunjangan FROM " & CONN_.schemaHRD & ".mstunjanganmasakerja WHERE mulaimasakerja<=" & tahunMasaKerja & " and sampaimasakerja>=" & tahunMasaKerja & ";"
                tunjanganMasaKerja = myCDBOperation.GetDataIndividual(_conn, _comm, _reader, stSQL)
            Else
                tunjanganMasaKerja = 0
            End If
            newValuesSummary &= "," & masaKerjaRiil & "," & tahunMasaKerja & "," & tunjanganMasaKerja
            newFieldsSummary &= ",masakerjariil,masakerja,tunjanganmasakerja"

            '---3. AMBIL TOTAL JAM KERJA (HARI LIBUR, CUTI, IJIN, DAN SAKIT DENGAN SURAT DOKTER DIHITUNG JAM KERJA)
            If (_kelompok = "NON STAFF") Then
                stSQL = "SELECT (SUM(case when p.absen is null then (case when p.banyakjamkerjanyata is null then 8 else p.banyakjamkerjanyata end) else (k.persengaji/100)*8 end)/8)::numeric(5,2) as totalharikerja, sum(case when p.shift is null then 0 else s.nilai end) as tunjanganshift,sum(case when p.shift is null then 0 else (case when p.shift>1 then 1 else 0 end) end) as totalkerjashift 
                        FROM " & CONN_.schemaHRD & ".trdatapresensi as p left join " & CONN_.schemaHRD & ".mskategoriabsen as k on p.absen=k.absen and p.lokasi=k.lokasi left join " & CONN_.schemaHRD & ".mstunjanganshift as s on p.shift=s.shift and p.lokasi=s.lokasi 
                        WHERE p.nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' and p.tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' and p.tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "';"
                hariKerja1Periode = 15
            ElseIf (_kelompok = "STAFF") Then
                stSQL = ""
                hariKerja1Periode = 30
            ElseIf (_kelompok = "OUTSOURCE") Then
                stSQL = ""
                hariKerja1Periode = 30
            End If
            myDataTablePresensi = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_Presensi")

            If (cboKuartal.SelectedItem = "Q2") Then
                'Kalau kuartal 2 saja
                Dim jumlahHariReal As Byte
                jumlahHariReal = Date.DaysInMonth(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month)
                If (jumlahHariReal <> 30) Then
                    myDataTablePresensi.Rows(0).Item("totalharikerja") -= (jumlahHariReal - 30)
                End If
            End If
            myDataTablePresensi.Rows(0).Item("totalharikerja") = Math.Round(myDataTablePresensi.Rows(0).Item("totalharikerja"), 4)
            totalHariKerja = myDataTablePresensi.Rows(0).Item("totalharikerja")
            totalKerjaShift = myDataTablePresensi.Rows(0).Item("totalkerjashift")
            totalTunjanganShift = myDataTablePresensi.Rows(0).Item("tunjanganshift")

            newValuesSummary &= "," & myDataTablePresensi.Rows(0).Item("totalharikerja")
            newFieldsSummary &= ",totalharikerjariil"

            '---4. AMBIL JAM LEMBURNYA
            stSQL = "SELECT tanggal,ijin,absen,jamlembur,mulailembur,selesailembur FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' and tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' and tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "' ORDER BY tanggal;"
            myDataTableLemburan = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_Lembur")
            totalJamLemburDiperhitungkan = 0
            For i As Byte = 0 To totalJamLemburHariBiasa.Count - 1
                totalJamLemburHariBiasa(i) = 0
            Next
            For i As Byte = 0 To totalJamLemburHariLibur.Count - 1
                totalJamLemburHariLibur(i) = 0
            Next
            'jamLembur(0) untuk hari biasa
            jamLembur(0) = Nothing
            jamLemburLama(0) = Nothing
            'jamLembur(1) untuk hari libur
            jamLembur(1) = Nothing
            jamLemburLama(1) = Nothing
            'absen(0) untuk hari pertama, absen(1) untuk hari kedua
            absen(0) = Nothing
            absen(1) = Nothing
            For i As Integer = 0 To myDataTableLemburan.Rows.Count - 1
                If Not IsDBNull(myDataTableLemburan.Rows(i).Item("jamlembur")) Then
                    'Di cek dulu apakah ada lemburnya atau tidak di tanggal tersebut
                    If (Format(myDataTableLemburan.Rows(i).Item("mulailembur"), "dd-MMM-yyyy") <> Format(myDataTableLemburan.Rows(i).Item("selesailembur"), "dd-MMM-yyyy")) Then
                        'Kalau lembur dilakukan lintas hari, tanggal mulai lembur dan tanggal selesai lembur tidak sama
                        'Maka perlu dilakukan pengecekkan apakah sama2 di hari kerja, sama2 di hari libur, atau dari hari kerja sampai ke hari libur, atau sebaliknya dari hari libur sampai ke hari kerja
                        'Cek apakah di hari mulai lembur adalah hari libur atau bukan
                        If Not IsDBNull(myDataTableLemburan.Rows(i).Item("absen")) Then
                            'Kalau ada absennya
                            absen(0) = myDataTableLemburan.Rows(i).Item("absen")
                            If (absen(0) = "C" Or absen(0) = "L") Then
                                'Kalau mulai lembur hanya dilihat kalau di tanggal tersebut adalah hari cuti atau hari libur, kalau ada ijin tidak masuk, maka lembur tidak dihitung!
                                'Hanya kalau libur cuti atau libur rutin yang dianggap lemburnya
                                jamLembur(1) = Math.Round((DateTime.Parse(myDataTableLemburan.Rows(i).Item("tanggal") & " " & "23:59:59") - DateTime.Parse(myDataTableLemburan.Rows(i).Item("mulailembur"))).TotalHours, 2)
                            End If
                        Else
                            'Kalau tidak ada absennya berarti hari kerja biasa
                            absen(0) = Nothing
                            jamLembur(0) = Math.Round((DateTime.Parse(myDataTableLemburan.Rows(i).Item("tanggal") & " " & "23:59:59") - DateTime.Parse(myDataTableLemburan.Rows(i).Item("mulailembur"))).TotalHours, 2)
                        End If

                        'Cek di hari selesai lembur, hari libur atau bukan
                        'MsgBox(Format(myDataTableLemburan.Rows(i).Item("selesailembur"), "dd-MMM-yyyy"))
                        absen(1) = myCDBOperation.GetSpecificRecord(_conn, _comm, _reader, "absen", CONN_.schemaHRD & ".trdatapresensi",, "nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND tanggal='" & Format(myDataTableLemburan.Rows(i).Item("selesailembur"), "dd-MMM-yyyy") & "'")
                        If Not IsNothing(absen(1)) Then
                            'Kalau tanggal berikutnya adalah hari libur
                            If (absen(1) = "C" Or absen(1) = "L") Then
                                'Kalau cuti atau libur rutin
                                jamLembur(1) += Math.Round((DateTime.Parse(myDataTableLemburan.Rows(i).Item("selesailembur")) - DateTime.Parse(myDataTableLemburan.Rows(i).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
                            Else
                                'Kalau di tanggal berikutnya bukan cuti atau libur, maka diberlakukan seperti hari kerja
                                'Bisa jadi ada absennya, misalkan tanggal berikutnya karyawan tersebut tidak masuk kerja
                                jamLembur(0) += Math.Round((DateTime.Parse(myDataTableLemburan.Rows(i).Item("selesailembur")) - DateTime.Parse(myDataTableLemburan.Rows(i).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
                            End If
                        Else
                            'Kalau tanggal berikutnya adalah hari kerja
                            jamLembur(0) += Math.Round((DateTime.Parse(myDataTableLemburan.Rows(i).Item("selesailembur")) - DateTime.Parse(myDataTableLemburan.Rows(i).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
                        End If
                    Else
                        'Kalau lemburnya tidak lintas tanggal, berarti hanya perlu di cek di tanggal tersebut adalah hari libur atau bukan
                        'Cek apakah di hari tersebut adalah hari libur atau bukan
                        If Not IsDBNull(myDataTableLemburan.Rows(i).Item("absen")) Then
                            'Kalau ada absennya
                            absen(0) = myDataTableLemburan.Rows(i).Item("absen")
                            If (absen(0) = "C" Or absen(0) = "L") Then
                                'Hanya kalau libur cuti atau libur rutin yang dianggap lemburnya
                                jamLembur(1) = myDataTableLemburan.Rows(i).Item("jamlembur").TotalHours
                            End If
                        Else
                            'Kalau bukan hari libur
                            absen(0) = Nothing
                            jamLembur(0) = myDataTableLemburan.Rows(i).Item("jamlembur").TotalHours
                        End If
                    End If

                    'jamLembur = myDataTableLemburan.Rows(i).Item("jamlembur").TotalHours
                    If Not IsNothing(jamLembur(0)) Then
                        'Cek lembur di hari kerja atau hari biasa
                        'Untuk hitung lembur di hari biasa, maka lemburan dihitung sebagai berikut
                        counter = 0
                        While jamLembur(0) > 0
                            counter += 1
                            If (counter <= 1) Then
                                faktorPengaliLembur = 1.5
                                If (jamLembur(0) > 0 And jamLembur(0) < 1) Then
                                    totalJamLemburHariBiasa(1) += jamLembur(0)
                                Else
                                    totalJamLemburHariBiasa(1) += 1
                                End If
                            ElseIf (counter > 1) Then
                                faktorPengaliLembur = 2
                                If (jamLembur(0) > 0 And jamLembur(0) < 1) Then
                                    totalJamLemburHariBiasa(2) += jamLembur(0)
                                Else
                                    totalJamLemburHariBiasa(2) += 1
                                End If
                            End If

                            If (jamLembur(0) - 1 >= 0) Then
                                totalJamLemburDiperhitungkan += faktorPengaliLembur
                                jamLembur(0) -= 1
                            Else
                                totalJamLemburDiperhitungkan += (jamLembur(0) * faktorPengaliLembur)
                                jamLembur(0) = 0
                            End If
                            totalJamLemburHariBiasa(0) += 1
                        End While
                    End If

                    If Not IsNothing(jamLembur(1)) Then
                        'Cek lembur di hari libur
                        'If (myDataTableLemburan.Rows(i).Item("absen") = "C" Or myDataTableLemburan.Rows(i).Item("absen") = "L") Then
                        'Jika di hari Libur atau Cuti Bersama, maka lemburan dihitung sebagai berikut
                        '8 Jam pertama tarif 2x, 1 jam berikutnya tarif 3x, setiap jam berikutnya tarif 4x
                        counter = 0
                        While jamLembur(1) > 0
                            counter += 1
                            If (counter <= 8) Then
                                faktorPengaliLembur = 2
                                If (jamLembur(1) > 0 And jamLembur(1) < 1) Then
                                    totalJamLemburHariLibur(1) += jamLembur(1)
                                Else
                                    totalJamLemburHariLibur(1) += 1
                                End If
                            ElseIf (counter = 9) Then
                                faktorPengaliLembur = 3
                                If (jamLembur(1) > 0 And jamLembur(1) < 1) Then
                                    totalJamLemburHariLibur(2) += jamLembur(1)
                                Else
                                    totalJamLemburHariLibur(2) += 1
                                End If
                            ElseIf (counter > 9) Then
                                faktorPengaliLembur = 4
                                If (jamLembur(1) > 0 And jamLembur(1) < 1) Then
                                    totalJamLemburHariLibur(3) += jamLembur(1)
                                Else
                                    totalJamLemburHariLibur(3) += 1
                                End If
                            End If

                            If (jamLembur(1) - 1 > 0) Then
                                totalJamLemburDiperhitungkan += faktorPengaliLembur
                                jamLembur(1) -= 1
                            Else
                                totalJamLemburDiperhitungkan += (jamLembur(1) * faktorPengaliLembur)
                                jamLembur(1) = 0
                            End If
                            totalJamLemburHariLibur(0) += 1
                        End While
                        'End If
                    End If
                    'MsgBox("Nama: " & _nama & " Tanggal: " & myDataTableLemburan.Rows(i).Item("tanggal") & ControlChars.NewLine & "Jam Lembur hari biasa 1: " & totalJamLemburHariBiasa(1) & ControlChars.NewLine & "Jam Lembur hari biasa 2:" & totalJamLemburHariBiasa(2) & ControlChars.NewLine & "Jam Lembur hari libur 1:" & totalJamLemburHariLibur(1) & ControlChars.NewLine & "Jam Lembur hari libur 2:" & totalJamLemburHariLibur(2) & ControlChars.NewLine & "Jam Lembur hari libur 3:" & totalJamLemburHariLibur(3) & ControlChars.NewLine & "Total Jam Lembur yang diperhitungkan: " & totalJamLemburDiperhitungkan)
                End If
            Next
            'totalJamLembur = (totalJamLemburHariBiasa(0) + totalJamLemburHariLibur(0))

            '5---INSERT KE trpayrollheader
            '==========================================================================================================================================
            prefixCompleted = prefixKode & "-" & DirectCast(cboPerusahaan.SelectedItem, DataRowView).Item("kode")
            strNoPayroll = myCDBOperation.SetDynamicAutoKode(_conn, _comm, _reader, tableNameHeader, tableKey, "rid", prefixCompleted, digitLength, True, dtpPeriodeSelesai.Value, CONN_.dbType, cboKuartal.SelectedItem, False)
            newValuesSummary &= ",'" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "'"
            newFieldsSummary &= "," & tableKey

            'Untuk mencari upah pokok karyawan tersebut
            foundRows = myDataTableKomponenGaji.Select("komponengaji='GAJI POKOK'")
            If (foundRows.Length > 0) Then
                If (_katpenggajian = "MINGGUAN") Then
                    upahPokok = myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah") / 2
                ElseIf (_katpenggajian = "BULANAN") Then
                    upahPokok = myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                End If
                newValuesSummary &= "," & myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(0))).Item("rupiah")
                newFieldsSummary &= ",upahpokokperbulan"
            End If

            strPeriodeGaji = cboPeriode.SelectedValue & "-" & cboKuartal.SelectedItem
            newValues = "'" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "','" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "','" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "','" & myCStringManipulation.SafeSqlLiteral(_departemen) & "','" & _kelompok & "','" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "','" & Now.Date & "','" & strPeriodeGaji & "','" & Format(_periodeMulai, "dd-MMM-yyyy") & "','" & Format(_periodeSelesai, "dd-MMM-yyyy") & "'," & upahPokok & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
            newFields = tableKey & ",idk,nip,nama,lokasi,perusahaan,departemen,kelompok,katpenggajian,tanggalpenggajian,periode,periodemulai,periodeselesai,upahpokok,userpc," & ADD_INFO_.newFields
            If Not IsNothing(_divisi) Then
                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(_divisi) & "'"
                newFields &= ",divisi"
            End If
            If Not IsNothing(_bagian) Then
                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(_bagian) & "'"
                newFields &= ",bagian"
            End If
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
            stSQL = "SELECT '" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "' as " & tableKey & ",kdr,tanggal,idk,nip,nama,ijin,absen,(case when absen='L' or absen='C' or absen='SD' or absen='IM1' or absen='SI' then to_timestamp('08:00:00','hh24:mi:ss')::time WITHOUT TIME ZONE else (case when absen='IM2' then to_timestamp('04:00:00','hh24:mi:ss')::time WITHOUT TIME ZONE else (case when jamkerjanyata is null then (case when absen is null then to_timestamp('08:00:00','hh24:mi:ss')::time WITHOUT TIME ZONE else to_timestamp('00:00:00','hh24:mi:ss')::time WITHOUT TIME ZONE end) else jamkerjanyata end) end) end) as jamkerjanyata,(case when absen='L' or absen='C' or absen='SD' or absen='IM1' or absen='SI' then 8 else (case when absen='IM2' then 4 else (case when banyakjamkerjanyata is null then (case when absen is null then 8 else 0 end) else banyakjamkerjanyata end) end) end) as banyakjamkerjanyata,terlambat,pulangcepat,shift,spkmulai,spkselesai,jamlembur,mulailembur,selesailembur,'" & USER_.username & "' as userid,'" & myCManagementSystem.GetComputerName & "' as userpc 
                    FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE nip='" & _nip & "' AND tanggal>='" & Format(_periodeMulai, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(_periodeSelesai, "dd-MMM-yyyy") & "' ORDER BY tanggal ASC;"
            myDataTableDataPresensiSekarang = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_" & tableNameProcessedDetail)
            Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableDataPresensiSekarang, tableNameProcessedDetail)
            '==========================================================================================================================================

            '==========================================================================================================================================
            '7. Ambil data di periode penggajian sebelumnya untuk nanti dibandingkan dengan data presensi di periode tersebut saat di proses di periode berikutnya, kalau semisal ada perubahan
            If (_katpenggajian = "MINGGUAN") Then
                'Jika mingguan, harus di cek dulu 1 hari ke belakang itu tanggal berapa
                If (dtpPeriodeMulai.Value.Day = 1) Then
                    'Ini kalau Q1, berarti mundur ke Q2 bulan sebelumnya
                    periodeMulaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1, 16)
                    periodeSelesaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1, DateTime.DaysInMonth(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1))
                    periodeLalu = MonthName(periodeMulaiQSebelumnya.Month - 1, True).ToUpper & periodeMulaiQSebelumnya.Year & "-" & "Q2"
                ElseIf (dtpPeriodeMulai.Value.Day = 16) Then
                    'ini kalau Q2, berarti mundur ke Q1 bulan yang sama
                    periodeMulaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month, 1)
                    periodeSelesaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month, 15)
                    periodeLalu = MonthName(periodeMulaiQSebelumnya.Month, True).ToUpper & periodeMulaiQSebelumnya.Year & "-" & "Q1"
                End If
            ElseIf (_katpenggajian = "BULANAN") Then
                'Jika bulanan, langsung saja periode sebelumnya pasti 1 bulan sebelumnya
                periodeLalu = "Q1"
                periodeMulaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1, 1)
                periodeSelesaiQSebelumnya = DateSerial(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1, DateTime.DaysInMonth(dtpPeriodeMulai.Value.Year, dtpPeriodeMulai.Value.Month - 1))
            Else
                periodeLalu = "QX"
            End If
            'strPayrollQSebelumnya = myCDBOperation.GetSpecificRecord(_conn, _comm, _reader, "nopayroll", tableNameHeader,, "nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND periode='" & periodeLalu & "'")
            stSQL = "SELECT " & tableKey & ",periodemulai,periodeselesai FROM " & tableNameHeader & " WHERE nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND periode='" & periodeLalu & "';"
            myDataTableInfoPayrollLalu = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_" & tableNameHeader)
            If (myDataTableInfoPayrollLalu.Rows.Count > 0) Then
                stSQL = "SELECT p.kdr,p.tanggal,p.idk,p.nip,p.nama,p.ijin,p.absen,p.jamkerjanyata,p.banyakjamkerjanyata,p.terlambat,p.pulangcepat,p.shift,(case when p.shift is null then 0 else s.nilai end) as tunjanganshift,p.spkmulai,p.spkselesai,p.jamlembur,p.mulailembur,p.selesailembur FROM (" & tableNameHeader & " as h INNER JOIN " & tableNameProcessedDetail & " as p on h." & tableKey & "=p." & tableKey & ") LEFT JOIN " & CONN_.schemaHRD & ".mstunjanganshift as s on p.shift=s.shift and h.lokasi=s.lokasi WHERE p." & tableKey & "='" & myCStringManipulation.SafeSqlLiteral(myDataTableInfoPayrollLalu.Rows(0).Item("nopayroll")) & "' ORDER BY p.tanggal ASC;"
                myDataTableProcessedDetailLalu = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_" & tableNameProcessedDetail)
            End If
            '==========================================================================================================================================

            '8. INSERT ke trpayrolldetail
            '==========================================================================================================================================
            'GAJI POKOK DAN KOMPONEN GAJI LAIN YANG SUDAH TERDAFTAR
            komponenLain2 = 0
            For i As Integer = 0 To myDataTableKomponenGaji.Rows.Count - 1
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

                If (myDataTableKomponenGaji.Rows(i).Item("faktorqty") = -1) Then
                    totalPotongan += myDataTableKomponenGaji.Rows(i).Item("rupiah")
                End If

                If (myDataTableKomponenGaji.Rows(i).Item("keterangan").ToString.Contains("POTONGAN JHT")) Then
                    newValuesSummary &= "," & myDataTableKomponenGaji.Rows(i).Item("rupiah")
                    newFieldsSummary &= ",potonganjhtjpbpjs"
                End If
                If (myDataTableKomponenGaji.Rows(i).Item("komponengaji") = "BONUS") Then
                    komponenLain2 += myDataTableKomponenGaji.Rows(i).Item("rupiah")
                End If
            Next

            'POTONGAN KARENA TIDAK MASUK FULL DALAM 1 HARI
            kurangJamKerja = hariKerja1Periode - myDataTablePresensi.Rows(0).Item("totalharikerja")
            If (kurangJamKerja > 0) Then
                lineNr += 1
                If (_katpenggajian = "MINGGUAN") Then
                    potonganTidakMasukFull = (kurangJamKerja * (upahPokok + (tunjanganMasaKerja / 2))) / 15
                ElseIf (_katpenggajian = "BULANAN") Then
                    potonganTidakMasukFull = (kurangJamKerja * (upahPokok + tunjanganMasaKerja)) / 30
                End If
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','POTONGAN TIDAK TETAP','POTONGAN TIDAK MASUK FULL DALAM 1 HARI'," & potonganTidakMasukFull & ",-1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
            End If
            upahKerja = ((upahPokok + (tunjanganMasaKerja / 2)) - potonganTidakMasukFull)

            'TUNJANGAN MASA KERJA
            If (tunjanganMasaKerja > 0) Then
                lineNr += 1
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','TUNJANGAN TETAP','TUNJANGAN MASA KERJA " & tahunMasaKerja & " TAHUN'," & tunjanganMasaKerja & ",1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
            End If

            'UPAH LEMBUR
            If (totalJamLemburDiperhitungkan > 0) Then
                lineNr += 1
                If (_katpenggajian = "MINGGUAN") Then
                    upahLembur = ((upahPokok + (tunjanganMasaKerja / 2)) / (173 / 2)) * totalJamLemburDiperhitungkan
                Else
                    upahLembur = (upahPokok + tunjanganMasaKerja / 173) * totalJamLemburDiperhitungkan
                End If
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','UPAH LEMBUR','LEMBUR HARI BIASA: " & totalJamLemburHariBiasa(0) & " JAM, LEMBUR HARI LIBUR: " & totalJamLemburHariLibur(0) & " JAM'," & upahLembur & ",1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
            End If

            'TUNJANGAN SHIFT
            If (myDataTablePresensi.Rows(0).Item("tunjanganshift") > 0) Then
                lineNr += 1
                newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','TUNJANGAN TIDAK TETAP','TUNJANGAN SHIFT'," & myDataTablePresensi.Rows(0).Item("tunjanganshift") & ",1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
            End If

            '==================
            'PENGECEKKAN UNTUK PERIODE SEBELUMNYA JIKA ADA PERUBAHAN
            If (myDataTableProcessedDetailLalu.Rows.Count > 0) Then
                'Melakukan pengecekkan membandingkan data sekarang dengan data dari periode lalu
                'Jika ada yang berbeda, maka akan dilakukan revisi di periode sekarang
                'stSQL = "SELECT p.kdr,p.tanggal,p.idk,p.nip,p.nama,p.ijin,p.absen,p.jamkerjanyata,p.banyakjamkerjanyata,p.terlambat,p.pulangcepat,p.shift,(case when p.shift is null then 0 else s.nilai end) as tunjanganshift,p.spkmulai,p.spkselesai,p.jamlembur,p.mulailembur,p.selesailembur FROM " & tableNameProcessedDetail & " as p INNER JOIN " & CONN_.schemaHRD & ".mstunjanganshift as s on p.shift=s.shift WHERE p." & tableKey & "='" & myCStringManipulation.SafeSqlLiteral(myDataTableInfoPayrollLalu.Rows(0).Item("nopayroll")) & "' ORDER BY p.tanggal ASC;"

                'stSQL = "SELECT '" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "' as " & tableKey & ", 'True' as revised,p.kdr,p.tanggal,p.idk,p.nip,p.nama,p.ijin,p.absen,(case when p.absen='L' or p.absen='C' or p.absen='SD' or p.absen='IM1' or p.absen='SI' then to_timestamp('08:00:00','hh24:mi:ss')::time WITHOUT TIME ZONE else (case when p.absen='IM2' then to_timestamp('04:00:00','hh24:mi:ss')::time WITHOUT TIME ZONE else (case when p.jamkerjanyata is null then (case when p.absen is null then to_timestamp('08:00:00','hh24:mi:ss')::time WITHOUT TIME ZONE else to_timestamp('00:00:00','hh24:mi:ss')::time WITHOUT TIME ZONE end) else jamkerjanyata end) end) end) as jamkerjanyata,(case when absen='L' or absen='C' or absen='SD' or absen='IM1' or absen='SI' then 8 else (case when absen='IM2' then 4 else (case when banyakjamkerjanyata is null then (case when absen is null then 8 else 0 end) else banyakjamkerjanyata end) end) end) as banyakjamkerjanyata,terlambat,pulangcepat,shift,(case when p.shift is null then 0 else s.nilai end) as tunjanganshift,spkmulai,spkselesai,jamlembur,mulailembur,selesailembur,'" & USER_.username & "' as userid,'" & myCManagementSystem.GetComputerName & "' as userpc 
                '        FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND tanggal>='" & Format(myDataTableInfoPayrollLalu.Rows(0).Item("periodemulai"), "dd-MMM-yyyy") & "' AND tanggal<='" & Format(myDataTableInfoPayrollLalu.Rows(0).Item("periodeselesai"), "dd-MMM-yyyy") & "' ORDER BY tanggal ASC;"
                stSQL = "SELECT '" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "' as " & tableKey & ", 'True' as revised,p.kdr,p.tanggal,p.idk,p.nip,p.nama,p.ijin,p.absen,(case when p.absen is null then (case when p.jamkerjanyata is null then to_timestamp('08:00:00','hh24:mi:ss')::time WITHOUT TIME ZONE else p.jamkerjanyata end) else ((k.persengaji/100)*8 *'1 HOUR'::INTERVAL)::time WITHOUT TIME ZONE end) as jamkerjanyata,(case when p.absen is null then (case when p.banyakjamkerjanyata is null then 8 else p.banyakjamkerjanyata end) else (k.persengaji/100)*8 end)::numeric(5,2) as banyakjamkerjanyata,p.terlambat,p.pulangcepat,p.shift,(case when p.shift is null then 0 else s.nilai end) as tunjanganshift,p.spkmulai,p.spkselesai,p.jamlembur,p.mulailembur,p.selesailembur,'" & USER_.username & "' as userid,'" & myCManagementSystem.GetComputerName & "' as userpc 
                        FROM (" & CONN_.schemaHRD & ".trdatapresensi as p LEFT JOIN " & CONN_.schemaHRD & ".mskategoriabsen as k on p.absen=k.absen and p.lokasi=k.lokasi) LEFT JOIN " & CONN_.schemaHRD & ".mstunjanganshift as s on p.shift=s.shift and p.lokasi=s.lokasi WHERE p.nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND p.tanggal>='" & Format(myDataTableInfoPayrollLalu.Rows(0).Item("periodemulai"), "dd-MMM-yyyy") & "' AND p.tanggal<='" & Format(myDataTableInfoPayrollLalu.Rows(0).Item("periodeselesai"), "dd-MMM-yyyy") & "' ORDER BY p.tanggal ASC;"
                myDataTableDataPresensiLalu = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_" & tableNameProcessedDetail)

                myDataTableDataPresensiLaluChanged = myDataTableDataPresensiLalu.Clone
                revisiJamKerjaPeriodeLalu = 0
                revisiShiftPeriodeLalu = 0
                revisiLemburPeriodeLalu = TimeSpan.Parse("00:00")
                revisiUpahKerjaPeriodeLalu = 0
                revisiTunjanganShiftPeriodeLalu = 0
                revisiUpahLemburPeriodeLalu = 0
                revisiTunjanganPeriodeLalu = 0
                revisiPotonganPeriodeLalu = 0

                totalJamLemburDiperhitungkanSusulan = 0
                'For i As Byte = 0 To totalJamLemburHariBiasa.Count - 1
                '    totalJamLemburHariBiasa(i) = 0
                'Next
                'For i As Byte = 0 To totalJamLemburHariLibur.Count - 1
                '    totalJamLemburHariLibur(i) = 0
                'Next
                'jamLembur(0) untuk hari biasa
                jamLembur(0) = Nothing
                jamLemburLama(0) = Nothing
                'jamLembur(1) untuk hari libur
                jamLembur(1) = Nothing
                jamLemburLama(1) = Nothing
                'absen(0) untuk hari pertama, absen(1) untuk hari kedua
                absen(0) = Nothing
                absen(1) = Nothing
                For i As Integer = 0 To myDataTableProcessedDetailLalu.Rows.Count - 1
                    foundRows = myDataTableDataPresensiLalu.Select("tanggal='" & Format(myDataTableProcessedDetailLalu.Rows(i).Item("tanggal"), "dd-MMM-yyyy") & "'")
                    'If (Format(myDataTableProcessedDetailLalu.Rows(i).Item("tanggal"), "dd-MMM-yyyy") = CDate("8-May-2022")) Then
                    '    MsgBox(Format(myDataTableProcessedDetailLalu.Rows(i).Item("tanggal"), "dd-MMM-yyyy"))
                    '    MsgBox(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("jamlembur").ToString)
                    '    MsgBox(myDataTableProcessedDetailLalu.Rows(i).Item("jamlembur").ToString)
                    'End If
                    isBerubah = False
                    'IJIN
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("ijin"), myDataTableProcessedDetailLalu.Rows(i).Item("ijin")) Then
                        isBerubah = True
                    End If
                    'ABSEN
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("absen"), myDataTableProcessedDetailLalu.Rows(i).Item("absen")) Then
                        isBerubah = True
                    End If
                    'JAM KERJA NYATA
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("jamkerjanyata"), myDataTableProcessedDetailLalu.Rows(i).Item("jamkerjanyata")) Then
                        isBerubah = True
                    End If
                    'BANYAK JAM KERJA NYATA
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("banyakjamkerjanyata"), myDataTableProcessedDetailLalu.Rows(i).Item("banyakjamkerjanyata")) Then
                        isBerubah = True
                        'POTONGAN KARENA TIDAK MASUK FULL DALAM 1 HARI
                        'Banyak jam kerja periode lalu di masa sekarang - Banyak jam kerja periode lalu yang sudah tersimpan
                        revisiJamKerjaPeriodeLalu += IIf(IsDBNull(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("banyakjamkerjanyata")), 0, myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("banyakjamkerjanyata")) - IIf(IsDBNull(myDataTableProcessedDetailLalu.Rows(i).Item("banyakjamkerjanyata")), 0, myDataTableProcessedDetailLalu.Rows(i).Item("banyakjamkerjanyata"))
                    End If
                    'TERLAMBAT
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("terlambat"), myDataTableProcessedDetailLalu.Rows(i).Item("terlambat")) Then
                        isBerubah = True
                    End If
                    'PULANG CEPAT
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("pulangcepat"), myDataTableProcessedDetailLalu.Rows(i).Item("pulangcepat")) Then
                        isBerubah = True
                    End If
                    'SHIFT
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("shift"), myDataTableProcessedDetailLalu.Rows(i).Item("shift")) Then
                        isBerubah = True
                        'TUNJANGAN SHIFT
                        If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("tunjanganshift"), myDataTableProcessedDetailLalu.Rows(i).Item("tunjanganshift")) Then
                            revisiShiftPeriodeLalu += IIf(IsDBNull(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("shift")), 0, IIf(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("shift") = 2 Or myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("shift") = 3, 1, 0)) - IIf(IsDBNull(myDataTableProcessedDetailLalu.Rows(i).Item("shift")), 0, IIf(myDataTableProcessedDetailLalu.Rows(i).Item("shift") = 2 Or myDataTableProcessedDetailLalu.Rows(i).Item("shift") = 3, 1, 0))
                            revisiTunjanganShiftPeriodeLalu += myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("tunjanganshift") - myDataTableProcessedDetailLalu.Rows(i).Item("tunjanganshift")
                        End If
                        'Shift periode lalu di masa sekarang - Shift periode lalu yang sudah tersimpan
                    End If
                    'SPK MULAI
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("spkmulai"), myDataTableProcessedDetailLalu.Rows(i).Item("spkmulai")) Then
                        isBerubah = True
                    End If
                    'SPK SELESAI
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("spkselesai"), myDataTableProcessedDetailLalu.Rows(i).Item("spkselesai")) Then
                        isBerubah = True
                    End If
                    'JAM LEMBUR
                    'MsgBox(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("jamlembur").ToString)
                    'MsgBox(myDataTableProcessedDetailLalu.Rows(i).Item("jamlembur").ToString)
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("jamlembur"), myDataTableProcessedDetailLalu.Rows(i).Item("jamlembur")) Then
                        isBerubah = True
                        'HITUNG LEMBUR
                        revisiLemburPeriodeLalu += IIf(IsDBNull(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("jamlembur")), TimeSpan.Parse("00:00"), myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("jamlembur")) - IIf(IsDBNull(myDataTableProcessedDetailLalu.Rows(i).Item("jamlembur")), TimeSpan.Parse("00:00"), myDataTableProcessedDetailLalu.Rows(i).Item("jamlembur"))
                        If revisiLemburPeriodeLalu <> TimeSpan.Parse("00:00") Then
                            'If Not IsDBNull(myDataTableDataPresensiLalu.Rows(i).Item("jamlembur")) Then
                            'Di cek dulu apakah ada lemburnya atau tidak di tanggal tersebut

                            'AMBIL YANG LEMBURAN DI PERIODE SEBELUMNYA UNTUK PENGURANGNYA
                            If Not IsDBNull(myDataTableProcessedDetailLalu.Rows(i).Item("mulailembur")) Then
                                If (Format(myDataTableProcessedDetailLalu.Rows(i).Item("mulailembur"), "dd-MMM-yyyy") <> Format(myDataTableProcessedDetailLalu.Rows(i).Item("selesailembur"), "dd-MMM-yyyy")) Then
                                    'Kalau lembur dilakukan lintas hari, tanggal mulai lembur dan tanggal selesai lembur tidak sama
                                    'Maka perlu dilakukan pengecekkan apakah sama2 di hari kerja, sama2 di hari libur, atau dari hari kerja sampai ke hari libur, atau sebaliknya dari hari libur sampai ke hari kerja
                                    'Cek apakah di hari mulai lembur adalah hari libur atau bukan
                                    If Not IsDBNull(myDataTableProcessedDetailLalu.Rows(i).Item("absen")) Then
                                        'Kalau ada absennya
                                        absen(0) = myDataTableProcessedDetailLalu.Rows(i).Item("absen")
                                        If (absen(0) = "C" Or absen(0) = "L") Then
                                            'Kalau mulai lembur hanya dilihat kalau di tanggal tersebut adalah hari cuti atau hari libur, kalau ada ijin tidak masuk, maka lembur tidak dihitung!
                                            'Hanya kalau libur cuti atau libur rutin yang dianggap lemburnya
                                            jamLemburLama(1) = Math.Round((DateTime.Parse(myDataTableProcessedDetailLalu.Rows(i).Item("tanggal") & " " & "23:59:59") - DateTime.Parse(myDataTableProcessedDetailLalu.Rows(i).Item("mulailembur"))).TotalHours, 2)
                                        End If
                                    Else
                                        'Kalau tidak ada absennya berarti hari kerja biasa
                                        absen(0) = Nothing
                                        jamLemburLama(0) = Math.Round((DateTime.Parse(myDataTableProcessedDetailLalu.Rows(i).Item("tanggal") & " " & "23:59:59") - DateTime.Parse(myDataTableProcessedDetailLalu.Rows(i).Item("mulailembur"))).TotalHours, 2)
                                    End If

                                    'Cek di hari selesai lembur, hari libur atau bukan
                                    'MsgBox(Format(myDataTableLemburan.Rows(i).Item("selesailembur"), "dd-MMM-yyyy"))
                                    absen(1) = myCDBOperation.GetSpecificRecord(_conn, _comm, _reader, "absen", CONN_.schemaHRD & ".trdatapresensi",, "nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND tanggal='" & Format(myDataTableProcessedDetailLalu.Rows(i).Item("selesailembur"), "dd-MMM-yyyy") & "'")
                                    If Not IsNothing(absen(1)) Then
                                        'Kalau tanggal berikutnya adalah hari libur
                                        If (absen(1) = "C" Or absen(1) = "L") Then
                                            'Kalau cuti atau libur rutin
                                            jamLemburLama(1) += Math.Round((DateTime.Parse(myDataTableProcessedDetailLalu.Rows(i).Item("selesailembur")) - DateTime.Parse(myDataTableProcessedDetailLalu.Rows(i).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
                                        Else
                                            'Kalau di tanggal berikutnya bukan cuti atau libur, maka diberlakukan seperti hari kerja
                                            'Bisa jadi ada absennya, misalkan tanggal berikutnya karyawan tersebut tidak masuk kerja
                                            jamLemburLama(0) += Math.Round((DateTime.Parse(myDataTableProcessedDetailLalu.Rows(i).Item("selesailembur")) - DateTime.Parse(myDataTableProcessedDetailLalu.Rows(i).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
                                        End If
                                    Else
                                        'Kalau tanggal berikutnya adalah hari kerja
                                        jamLemburLama(0) += Math.Round((DateTime.Parse(myDataTableProcessedDetailLalu.Rows(i).Item("selesailembur")) - DateTime.Parse(myDataTableProcessedDetailLalu.Rows(i).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
                                    End If
                                Else
                                    'Kalau lemburnya tidak lintas tanggal, berarti hanya perlu di cek di tanggal tersebut adalah hari libur atau bukan
                                    'Cek apakah di hari tersebut adalah hari libur atau bukan
                                    If Not IsDBNull(myDataTableProcessedDetailLalu.Rows(i).Item("absen")) Then
                                        'Kalau ada absennya
                                        absen(0) = myDataTableProcessedDetailLalu.Rows(i).Item("absen")
                                        If (absen(0) = "C" Or absen(0) = "L") Then
                                            'Hanya kalau libur cuti atau libur rutin yang dianggap lemburnya
                                            jamLemburLama(1) = myDataTableProcessedDetailLalu.Rows(i).Item("jamlembur").TotalHours
                                        End If
                                    Else
                                        'Kalau bukan hari libur
                                        absen(0) = Nothing
                                        jamLemburLama(0) = myDataTableProcessedDetailLalu.Rows(i).Item("jamlembur").TotalHours
                                    End If
                                End If
                            End If

                            If Not IsDBNull(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("mulailembur")) Then
                                If (Format(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("mulailembur"), "dd-MMM-yyyy") <> Format(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("selesailembur"), "dd-MMM-yyyy")) Then
                                    'Kalau lembur dilakukan lintas hari, tanggal mulai lembur dan tanggal selesai lembur tidak sama
                                    'Maka perlu dilakukan pengecekkan apakah sama2 di hari kerja, sama2 di hari libur, atau dari hari kerja sampai ke hari libur, atau sebaliknya dari hari libur sampai ke hari kerja
                                    'Cek apakah di hari mulai lembur adalah hari libur atau bukan
                                    If Not IsDBNull(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("absen")) Then
                                        'Kalau ada absennya
                                        absen(0) = myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("absen")
                                        If (absen(0) = "C" Or absen(0) = "L") Then
                                            'Kalau mulai lembur hanya dilihat kalau di tanggal tersebut adalah hari cuti atau hari libur, kalau ada ijin tidak masuk, maka lembur tidak dihitung!
                                            'Hanya kalau libur cuti atau libur rutin yang dianggap lemburnya
                                            jamLembur(1) = Math.Round((DateTime.Parse(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("tanggal") & " " & "23:59:59") - DateTime.Parse(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("mulailembur"))).TotalHours, 2)
                                        End If
                                    Else
                                        'Kalau tidak ada absennya berarti hari kerja biasa
                                        absen(0) = Nothing
                                        jamLembur(0) = Math.Round((DateTime.Parse(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("tanggal") & " " & "23:59:59") - DateTime.Parse(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("mulailembur"))).TotalHours, 2)
                                    End If

                                    'Cek di hari selesai lembur, hari libur atau bukan
                                    'MsgBox(Format(myDataTableLemburan.Rows(i).Item("selesailembur"), "dd-MMM-yyyy"))
                                    absen(1) = myCDBOperation.GetSpecificRecord(_conn, _comm, _reader, "absen", CONN_.schemaHRD & ".trdatapresensi",, "nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "' AND tanggal='" & Format(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("selesailembur"), "dd-MMM-yyyy") & "'")
                                    If Not IsNothing(absen(1)) Then
                                        'Kalau tanggal berikutnya adalah hari libur
                                        If (absen(1) = "C" Or absen(1) = "L") Then
                                            'Kalau cuti atau libur rutin
                                            jamLembur(1) += Math.Round((DateTime.Parse(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("selesailembur")) - DateTime.Parse(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
                                        Else
                                            'Kalau di tanggal berikutnya bukan cuti atau libur, maka diberlakukan seperti hari kerja
                                            'Bisa jadi ada absennya, misalkan tanggal berikutnya karyawan tersebut tidak masuk kerja
                                            jamLembur(0) += Math.Round((DateTime.Parse(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("selesailembur")) - DateTime.Parse(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
                                        End If
                                    Else
                                        'Kalau tanggal berikutnya adalah hari kerja
                                        jamLembur(0) += Math.Round((DateTime.Parse(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("selesailembur")) - DateTime.Parse(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("tanggal").addDays(1) & " " & "00:00:00")).TotalHours, 2)
                                    End If
                                Else
                                    'Kalau lemburnya tidak lintas tanggal, berarti hanya perlu di cek di tanggal tersebut adalah hari libur atau bukan
                                    'Cek apakah di hari tersebut adalah hari libur atau bukan
                                    If Not IsDBNull(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("absen")) Then
                                        'Kalau ada absennya
                                        absen(0) = myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("absen")
                                        If (absen(0) = "C" Or absen(0) = "L") Then
                                            'Hanya kalau libur cuti atau libur rutin yang dianggap lemburnya
                                            jamLembur(1) = myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("jamlembur").TotalHours
                                        End If
                                    Else
                                        'Kalau bukan hari libur
                                        absen(0) = Nothing
                                        jamLembur(0) = myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("jamlembur").TotalHours
                                    End If
                                End If
                            End If

                            'jamLembur(0) -= jamLemburLama(0)
                            'jamLembur(1) -= jamLemburLama(1)
                            'If (jamLembur(0) = 0) Then
                            '    jamLembur(0) = Nothing
                            'End If
                            'If (jamLembur(1) = 0) Then
                            '    jamLembur(1) = Nothing
                            'End If

                            If Not IsNothing(jamLembur(0)) Then
                                'Cek lembur di hari kerja atau hari biasa
                                'Untuk hitung lembur di hari biasa, maka lemburan dihitung sebagai berikut
                                counter = 0
                                While jamLembur(0) > 0
                                    counter += 1
                                    If (jamLemburLama(0) > 0) Then
                                        If (jamLemburLama(0) - 1 >= 0) Then
                                            jamLemburLama(0) -= 1
                                            jamLembur(0) -= 1
                                        Else
                                            jamLemburLama(0) = 0
                                            jamLembur(0) -= jamLemburLama(0)
                                        End If
                                    Else
                                        If (counter <= 1) Then
                                            faktorPengaliLembur = 1.5
                                            If (jamLembur(0) > 0 And jamLembur(0) < 1) Then
                                                totalJamLemburHariBiasa(1) += jamLembur(0)
                                            Else
                                                totalJamLemburHariBiasa(1) += 1
                                            End If
                                        ElseIf (counter > 1) Then
                                            faktorPengaliLembur = 2
                                            If (jamLembur(0) > 0 And jamLembur(0) < 1) Then
                                                totalJamLemburHariBiasa(2) += jamLembur(0)
                                            Else
                                                totalJamLemburHariBiasa(2) += 1
                                            End If
                                        End If

                                        If (jamLembur(0) - 1 >= 0) Then
                                            totalJamLemburDiperhitungkanSusulan += faktorPengaliLembur
                                            jamLembur(0) -= 1
                                        Else
                                            totalJamLemburDiperhitungkanSusulan += (jamLembur(0) * faktorPengaliLembur)
                                            jamLembur(0) = 0
                                        End If
                                        totalJamLemburHariBiasa(0) += 1
                                    End If
                                End While
                            End If

                            If Not IsNothing(jamLembur(1)) Then
                                'Cek lembur di hari libur
                                'If (myDataTableLemburan.Rows(i).Item("absen") = "C" Or myDataTableLemburan.Rows(i).Item("absen") = "L") Then
                                'Jika di hari Libur atau Cuti Bersama, maka lemburan dihitung sebagai berikut
                                '8 Jam pertama tarif 2x, 1 jam berikutnya tarif 3x, setiap jam berikutnya tarif 4x
                                counter = 0
                                While jamLembur(1) > 0
                                    counter += 1
                                    If (jamLemburLama(1) > 0) Then
                                        If (jamLemburLama(1) - 1 >= 0) Then
                                            jamLemburLama(1) -= 1
                                            jamLembur(1) -= 1
                                        Else
                                            jamLemburLama(1) = 0
                                            jamLembur(1) -= jamLemburLama(1)
                                        End If
                                    Else
                                        If (counter <= 8) Then
                                            faktorPengaliLembur = 2
                                            If (jamLembur(1) > 0 And jamLembur(1) < 1) Then
                                                totalJamLemburHariLibur(1) += jamLembur(1)
                                            Else
                                                totalJamLemburHariLibur(1) += 1
                                            End If
                                        ElseIf (counter = 9) Then
                                            faktorPengaliLembur = 3
                                            If (jamLembur(1) > 0 And jamLembur(1) < 1) Then
                                                totalJamLemburHariLibur(2) += jamLembur(1)
                                            Else
                                                totalJamLemburHariLibur(2) += 1
                                            End If
                                        ElseIf (counter > 9) Then
                                            faktorPengaliLembur = 4
                                            If (jamLembur(1) > 0 And jamLembur(1) < 1) Then
                                                totalJamLemburHariLibur(3) += jamLembur(1)
                                            Else
                                                totalJamLemburHariLibur(3) += 1
                                            End If
                                        End If

                                        If (jamLembur(1) - 1 > 0) Then
                                            totalJamLemburDiperhitungkanSusulan += faktorPengaliLembur
                                            jamLembur(1) -= 1
                                        Else
                                            totalJamLemburDiperhitungkanSusulan += (jamLembur(1) * faktorPengaliLembur)
                                            jamLembur(1) = 0
                                        End If
                                        totalJamLemburHariLibur(0) += 1
                                    End If
                                End While
                                'End If
                            End If
                        End If
                    End If
                    'MULAI LEMBUR
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("mulailembur"), myDataTableProcessedDetailLalu.Rows(i).Item("mulailembur")) Then
                        isBerubah = True
                    End If
                    'SELESAI LEMBUR
                    If Not Equals(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))).Item("selesailembur"), myDataTableProcessedDetailLalu.Rows(i).Item("selesailembur")) Then
                        isBerubah = True
                    End If

                    If (isBerubah) Then
                        'Jika ada yang berubah, maka harus diinputkan sebagai baris baru di trpayrollprocesseddetail dengan kolom revised=True
                        myDataTableDataPresensiLaluChanged.ImportRow(myDataTableDataPresensiLalu.Rows(myDataTableDataPresensiLalu.Rows.IndexOf(foundRows(0))))
                    End If
                Next

                If (myDataTableDataPresensiLaluChanged.Rows.Count > 0) Then
                    '9. INSERT KE trpayrollprocesseddetail
                    myDataTableDataPresensiLaluChanged.Columns.Remove("tunjanganshift")
                    Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableDataPresensiLaluChanged, tableNameProcessedDetail)
                    If (revisiJamKerjaPeriodeLalu <> 0) Then
                        'POTONGAN KARENA TIDAK MASUK FULL DALAM 1 HARI
                        If (_katpenggajian = "MINGGUAN") Then
                            revisiUpahKerjaPeriodeLalu = ((revisiJamKerjaPeriodeLalu / 8) * (upahPokok + (tunjanganMasaKerja / 2))) / 15
                        ElseIf (_katpenggajian = "BULANAN") Then
                            revisiUpahKerjaPeriodeLalu = ((revisiJamKerjaPeriodeLalu / 8) * (upahPokok + tunjanganMasaKerja)) / 30
                        End If
                        lineNr += 1
                        newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & IIf(revisiUpahKerjaPeriodeLalu > 0, "TUNJANGAN TIDAK TETAP", "POTONGAN TIDAK TETAP") & "','REVISI JAM KERJA PERIODE " & periodeLalu & "'," & IIf(revisiUpahKerjaPeriodeLalu > 0, revisiUpahKerjaPeriodeLalu, revisiUpahKerjaPeriodeLalu * -1) & "," & IIf(revisiUpahKerjaPeriodeLalu > 0, 1, -1) & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                        newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                        Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                        If (revisiUpahKerjaPeriodeLalu > 0) Then
                            revisiTunjanganPeriodeLalu += revisiUpahKerjaPeriodeLalu
                        Else
                            revisiPotonganPeriodeLalu += (revisiUpahKerjaPeriodeLalu * -1)
                        End If
                        'totalHariKerja += (revisiJamKerjaPeriodeLalu / 8)
                        'upahKerja += revisiUpahKerjaPeriodeLalu
                    End If
                    If (revisiShiftPeriodeLalu <> 0) Then
                        'revisiTunjanganShiftPeriodeLalu = revisiShiftPeriodeLalu
                        lineNr += 1
                        newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & IIf(revisiTunjanganShiftPeriodeLalu > 0, "TUNJANGAN TIDAK TETAP", "POTONGAN TIDAK TETAP") & "','REVISI SHIFT PERIODE " & periodeLalu & "'," & IIf(revisiTunjanganShiftPeriodeLalu > 0, revisiTunjanganShiftPeriodeLalu, revisiTunjanganShiftPeriodeLalu * -1) & "," & IIf(revisiTunjanganShiftPeriodeLalu > 0, 1, -1) & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                        newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                        Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                        If (revisiTunjanganShiftPeriodeLalu > 0) Then
                            revisiTunjanganPeriodeLalu += revisiTunjanganShiftPeriodeLalu
                        Else
                            revisiPotonganPeriodeLalu += (revisiTunjanganShiftPeriodeLalu * -1)
                        End If
                        'totalKerjaShift += revisiShiftPeriodeLalu
                        'totalTunjanganShift += revisiTunjanganShiftPeriodeLalu
                    End If
                    If (revisiLemburPeriodeLalu <> TimeSpan.Parse("00:00")) Then
                        Dim upahLemburPeriodeLaluSebelumnya As Double
                        upahLemburPeriodeLaluSebelumnya = myCDBOperation.GetSpecificRecord(_conn, _comm, _reader, "rupiah", tableNameDetail,, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(myDataTableInfoPayrollLalu.Rows(0).Item("nopayroll")) & "' AND komponengaji='UPAH LEMBUR'")

                        Dim totalJamLemburSummarySebelumnya As Double
                        totalJamLemburSummarySebelumnya = myCDBOperation.GetSpecificRecord(_conn, _comm, _reader, "totaljamlembur", tableNameSummary,, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(myDataTableInfoPayrollLalu.Rows(0).Item("nopayroll")) & "' and nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "'")

                        lineNr += 1
                        If (_katpenggajian = "MINGGUAN") Then
                            'revisiUpahLemburPeriodeLalu = (((upahPokok + (tunjanganMasaKerja / 2)) / (173 / 2)) * totalJamLemburDiperhitungkanSusulan) - upahLemburPeriodeLaluSebelumnya
                            revisiUpahLemburPeriodeLalu = (((upahPokok + (tunjanganMasaKerja / 2)) / (173 / 2)) * (totalJamLemburDiperhitungkanSusulan + totalJamLemburSummarySebelumnya)) - upahLemburPeriodeLaluSebelumnya
                            'revisiUpahLemburPeriodeLalu = (((upahPokok + (tunjanganMasaKerja / 2)) / (173 / 2)) * totalJamLemburDiperhitungkanSusulan)
                        ElseIf (_katpenggajian = "BULANAN") Then
                            revisiUpahLemburPeriodeLalu = ((upahPokok + tunjanganMasaKerja / 173) * (totalJamLemburDiperhitungkanSusulan + totalJamLemburSummarySebelumnya)) - upahLemburPeriodeLaluSebelumnya
                        End If
                        newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','" & IIf(revisiUpahLemburPeriodeLalu > 0, "TUNJANGAN TIDAK TETAP", "POTONGAN TIDAK TETAP") & "','REVISI LEMBUR PERIODE " & periodeLalu & "'," & IIf(revisiUpahLemburPeriodeLalu > 0, revisiUpahLemburPeriodeLalu, revisiUpahLemburPeriodeLalu * -1) & "," & IIf(revisiUpahLemburPeriodeLalu > 0, 1, -1) & ",'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
                        newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
                        Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)

                        If (revisiUpahLemburPeriodeLalu > 0) Then
                            revisiTunjanganPeriodeLalu += revisiUpahLemburPeriodeLalu
                        Else
                            revisiPotonganPeriodeLalu += (revisiUpahLemburPeriodeLalu * -1)
                        End If
                        'totalJamLemburDiperhitungkanSusulan -= totalJamLemburSummarySebelumnya
                        'totalJamLembur += (totalJamLemburHariBiasa(0) + totalJamLemburHariLibur(0))
                        'upahLembur += revisiUpahLemburPeriodeLalu
                    End If
                    myDataTableDataPresensiLalu.Clear()
                End If
            End If
            newValuesSummary &= "," & (upahKerja + revisiUpahKerjaPeriodeLalu) & "," & (totalHariKerja + (revisiJamKerjaPeriodeLalu / 8)) & "," & (upahLembur + revisiUpahLemburPeriodeLalu) & "," & totalJamLemburHariBiasa(1) & "," & totalJamLemburHariBiasa(2) & "," & totalJamLemburHariLibur(1) & "," & totalJamLemburHariLibur(2) & "," & totalJamLemburHariLibur(3) & "," & (totalJamLemburDiperhitungkan + totalJamLemburDiperhitungkanSusulan) & "," & (totalKerjaShift + revisiShiftPeriodeLalu) & "," & (totalTunjanganShift + revisiTunjanganShiftPeriodeLalu)
            newFieldsSummary &= ",upahkerja,totalharikerja,upahlembur,jamlemburharibiasa1,jamlemburharibiasa2,jamlemburharilibur1,jamlemburharilibur2,jamlemburharilibur3,totaljamlembur,totalkerjashift,tunjanganshift"
            '==================

            'Dim bonus As Double
            'foundRows = myDataTableKomponenGaji.Select("komponengaji='BONUS'")
            'If foundRows.Length > 0 Then
            '    For a As Short = 0 To foundRows.Length - 1
            '        bonus += myDataTableKomponenGaji.Rows(myDataTableKomponenGaji.Rows.IndexOf(foundRows(a))).Item("rupiah")
            '    Next
            '    lineNr += 1
            '    newValues = "'" & strNoPayroll & "'," & lineNr & ",'" & myCStringManipulation.SafeSqlLiteral(_idk) & "','" & myCStringManipulation.SafeSqlLiteral(_nip) & "','" & myCStringManipulation.SafeSqlLiteral(_nama) & "','BONUS','LAIN2'," & bonus & ",1,'" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.newValues
            '    newFields = tableKey & ",linenr,idk,nip,nama,komponengaji,keterangan,rupiah,faktorqty,userpc," & ADD_INFO_.newFields
            '    Call myCDBOperation.InsertData(_conn, _comm, tableNameDetail, newValues, newFields)
            'End If

            Dim tambahanLain2 As Double = 0
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

            totalTunjangan = (tunjanganMasaKerja / 2) + upahLembur + totalTunjanganShift + komponenLain2 + revisiTunjanganPeriodeLalu
            totalPotongan += potonganTidakMasukFull + revisiPotonganPeriodeLalu

            upahBersih = upahPokok + totalTunjangan - totalPotongan
            upahYangDibayar = Math.Ceiling(upahBersih / 100) * 100
            Call myCDBOperation.UpdateData(_conn, _comm, tableNameHeader, "totaltunjangan=" & totalTunjangan & ",totalpotongan=" & totalPotongan & ",upahbersih=" & upahBersih & ",upahyangdibayar=" & upahYangDibayar, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "'")

            newValuesSummary &= "," & upahBersih & "," & upahYangDibayar & "," & ADD_INFO_.newValues
            newFieldsSummary &= ",upahtotal,upahyangdibayar," & ADD_INFO_.newFields
            '==========================================================================================================================================

            '==========================================================================================================================================
            '10. INSERT ke trpayrollsummary
            'Hapus dulu record yang sebelumnya
            Call myCDBOperation.DelDbRecords(_conn, _comm, tableNameSummary, tableKey & "='" & myCStringManipulation.SafeSqlLiteral(strNoPayroll) & "' and nip='" & myCStringManipulation.SafeSqlLiteral(_nip) & "'")
            Call myCDBOperation.InsertData(_conn, _comm, tableNameSummary, newValuesSummary, newFieldsSummary)
            '==========================================================================================================================================
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ProsesPayroll Error")
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
            queryBuilder.Append("update " & CONN_.schemaHRD & ".trdatapresensi as a set ijin='TM',absen='L',updated_at=clock_timestamp() WHERE (a.nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "') AND (a.tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') and not exists(select 1 from " & CONN_.schemaHRD & ".kalenderperusahaan as kp where (kp.tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and kp.tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') and (kp.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (kp.libur='False') and (a.tanggal=kp.tanggal)) and (a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (trim(to_char(a.tanggal, 'day')) IN ('saturday','sunday')) AND (a.divisi<>'SECURITY') AND (a.jamlembur is null) AND (a.spkmulai is null and a.spkselesai is null);")
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

                    'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableNameSummary, "nopayroll IN (SELECT " & tableKey & " FROM " & tableNameHeader & " WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "'))")
                    'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableNameProcessedDetail & " as s", "EXISTS(SELECT 1 FROM " & tableNameHeader & " as h WHERE (s." & tableKey & "=h." & tableKey & ") AND (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') AND (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (h.nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "'))")
                    'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableNameDetail & " as s", "EXISTS(SELECT 1 FROM " & tableNameHeader & " as h WHERE (s." & tableKey & "=h." & tableKey & ") AND (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') AND (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (h.nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "'))")
                    'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableNameHeader, "(perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawanIndividu.SelectedValue) & "')")
                    If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                        Call ProsesPayroll(CONN_.dbMain, CONN_.comm, CONN_.reader, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("idk"), cboKaryawanIndividu.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("nama"), dtpPeriodeMulai.Value.Date, dtpPeriodeSelesai.Value.Date, cboLokasi.SelectedValue, cboPerusahaan.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("departemen"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("kelompok"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("katpenggajian"), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), rtbCatatanHRD.Text, True)
                        Call btnTampilkan_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowWarning("Penghapusan data payroll lama gagal!" & ControlChars.NewLine & "Silahkan coba lagi!")
                    End If
                Else
                    Call myCShowMessage.ShowWarning("Proses payroll dibatalkan!")
                End If
            Else
                'Kalau belum ada, langsung di proses saja
                Call ProsesPayroll(CONN_.dbMain, CONN_.comm, CONN_.reader, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("idk"), cboKaryawanIndividu.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("nama"), dtpPeriodeMulai.Value.Date, dtpPeriodeSelesai.Value.Date, cboLokasi.SelectedValue, cboPerusahaan.SelectedValue, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("departemen"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("kelompok"), DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("katpenggajian"), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("statuskepegawaian")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("divisi")), IIf(IsDBNull(DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), Nothing, DirectCast(cboKaryawanIndividu.SelectedItem, DataRowView).Item("bagian")), rtbCatatanHRD.Text, True)
                Call btnTampilkan_Click(sender, e)
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
                    ORDER BY d.linenr;"

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
                        WHERE (p.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (p.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (p.kelompok='" & strKelompok & "') AND (p.tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND p.tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND EXISTS(SELECT 1 FROM " & CONN_.schemaHRD & ".trpayrollheader as h WHERE (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') and (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') and p.nip=h.nip) 
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
                        'MessageBox.Show("No Button Pressed", "MessageBox Title", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'myDataTablePresensi.Clear()

                        stSQL = "SELECT p.idk,p.nip,p.nama,p.departemen,p.divisi,p.bagian,p.kelompok,p.katpenggajian, p.statuskepegawaian  
                                FROM " & CONN_.schemaHRD & ".trdatapresensi  as p
                                WHERE (p.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (p.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (p.kelompok='" & strKelompok & "') AND (p.tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND p.tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND NOT EXISTS(SELECT 1 FROM " & CONN_.schemaHRD & ".trpayrollheader as h WHERE (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') and (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') and p.nip=h.nip) 
                                GROUP BY p.idk,p.nip,p.nama,p.departemen,p.divisi,p.bagian,p.kelompok,p.katpenggajian, p.statuskepegawaian  
                                ORDER BY p.nama;"
                        myDataTablePresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Presensi")
                    ElseIf isConfirm = DialogResult.Yes Then
                        'Proses semuanya ulang
                        'MessageBox.Show("Yes Button Pressed", "MessageBox Title", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'myDataTablePresensi.Clear()
                        'Dim queryBuilder As New Text.StringBuilder
                        queryBuilder.Clear()

                        'Hapus dulu data yang lama
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameSummary, "",, tableKey & " IN (SELECT " & tableKey & " FROM " & tableNameHeader & " WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "'))"))
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameProcessedDetail & " as s", "",, "EXISTS(SELECT 1 FROM " & tableNameHeader & " as h WHERE (s." & tableKey & "=h." & tableKey & ") and (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') AND (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "'))"))
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameDetail & " as s", "",, "EXISTS(SELECT 1 FROM " & tableNameHeader & " as h WHERE (s." & tableKey & "=h." & tableKey & ") and (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') AND (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "'))"))
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableNameHeader, "",, "(perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "')"))

                        'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableNameProcessedDetail & " as s", "EXISTS(SELECT 1 FROM " & tableNameHeader & " as h WHERE (s." & tableKey & "=h." & tableKey & ") and (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') AND (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "'))")
                        'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableNameDetail & " as s", "EXISTS(SELECT 1 FROM " & tableNameHeader & " as h WHERE (s." & tableKey & "=h." & tableKey & ") and (h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') and (h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (h.kelompok='" & strKelompok & "') AND (h.periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND h.periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "'))")
                        'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableNameHeader, "(perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (periodemulai>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND periodeselesai<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "')")

                        'stSQL = "SELECT SETVAL('" & tableNameHeader & "_rid_seq', (SELECT MAX(rid) FROM " & tableNameHeader & "));"
                        'Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)
                        'stSQL = "SELECT SETVAL('" & tableNameDetail & "_rid_seq', (SELECT MAX(rid) FROM " & tableNameDetail & "));"
                        'Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)
                        'stSQL = "SELECT SETVAL('" & tableNameProcessedDetail & "_rid_seq', (SELECT MAX(rid) FROM " & tableNameProcessedDetail & "));"
                        'Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)
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
                            WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') 
                            GROUP BY idk,nip,nama,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian 
                            ORDER BY nama;"
                    myDataTablePresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Presensi")
                End If

                If Not IsNothing(myDataTablePresensi) Then
                    For i As Integer = 0 To myDataTablePresensi.Rows.Count - 1
                        Call ProsesPayroll(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTablePresensi.Rows(i).Item("idk"), myDataTablePresensi.Rows(i).Item("nip"), myDataTablePresensi.Rows(i).Item("nama"), dtpPeriodeMulai.Value.Date, dtpPeriodeSelesai.Value.Date, cboLokasi.SelectedValue, cboPerusahaan.SelectedValue, myDataTablePresensi.Rows(i).Item("departemen"), myDataTablePresensi.Rows(i).Item("kelompok"), myDataTablePresensi.Rows(i).Item("katpenggajian"), IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("statuskepegawaian")), Nothing, myDataTablePresensi.Rows(i).Item("statuskepegawaian")), IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("divisi")), Nothing, myDataTablePresensi.Rows(i).Item("divisi")), IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("bagian")), Nothing, myDataTablePresensi.Rows(i).Item("bagian")), Nothing, True)

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
                stSQL = "SELECT h.nopayroll,h.lokasi,h.perusahaan,h.departemen,h.divisi,h.bagian,h.periode,h.periodemulai,h.periodeselesai,h.idk,h.nip,h.nama,s.tanggalmasuk,s.masakerjariil,s.masakerja,s.upahpokokperbulan,s.tunjanganmasakerja,s.tunjanganprestasi,s.tunjanganhadir,s.totalharikerjariil,s.totalharikerja,s.totalkerjashift,s.jamlemburharibiasa1,s.jamlemburharibiasa2,s.jamlemburharilibur1,s.jamlemburharilibur2,s.jamlemburharilibur3,s.totaljamlembur,s.upahkerja,s.upahlembur,s.premi,s.tunjanganshift,s.lain2,s.potonganjhtjpbpjs,s.potonganpph,s.upahtotal,s.upahyangdibayar,p.tanggal,p.kdr,p.revised,p.ijin,p.absen,p.banyakjamkerjanyata,p.terlambat,p.pulangcepat,p.shift,p.spkmulai,p.spkselesai,p.jamlembur,p.mulailembur,p.selesailembur
                        FROM (" & tableNameHeader & " as h inner join " & tableNameSummary & " as s on h." & tableKey & "=s." & tableKey & ") inner join " & tableNameProcessedDetail & " as p on h." & tableKey & "=p." & tableKey & "
                        WHERE periode='" & cboPeriode.SelectedValue & "-" & cboKuartal.SelectedItem & "' and h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and h.perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' and h.kelompok='" & strKelompok & "'
                        GROUP BY h.nopayroll,h.lokasi,h.perusahaan,h.departemen,h.divisi,h.bagian,h.periode,h.periodemulai,h.periodeselesai,h.idk,h.nip,h.nama,s.tanggalmasuk,s.masakerjariil,s.masakerja,s.upahpokokperbulan,s.tunjanganmasakerja,s.tunjanganprestasi,s.tunjanganhadir,s.totalharikerjariil,s.totalharikerja,s.totalkerjashift,s.jamlemburharibiasa1,s.jamlemburharibiasa2,s.jamlemburharilibur1,s.jamlemburharilibur2,s.jamlemburharilibur3,s.totaljamlembur,s.upahkerja,s.upahlembur,s.premi,s.tunjanganshift,s.lain2,s.potonganjhtjpbpjs,s.potonganpph,s.upahtotal,s.upahyangdibayar,p.tanggal,p.kdr,p.revised,p.ijin,p.absen,p.banyakjamkerjanyata,p.terlambat,p.pulangcepat,p.shift,p.spkmulai,p.spkselesai,p.jamlembur,p.mulailembur,p.selesailembur
                        ORDER BY h.nama;"
                Dim frmdisplayreport As New FormDisplayReport.FormDisplayReport(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, stSQL, "RekapPayroll",, Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strKelompok.ToLower()).Replace(" ", ""))
                Call myCFormManipulation.GoToForm(Me.MdiParent, frmdisplayreport)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCetakRekap_Click Error")
        End Try
    End Sub

    'Private Sub dtpPeriode_Validated(sender As Object, e As EventArgs) Handles dtpPeriodeMulai.Validated, dtpPeriodeSelesai.Validated
    '    Try
    '        If (cboPerusahaan.SelectedIndex <> -1 And cboLokasi.SelectedIndex <> -1) Then
    '            Me.Cursor = Cursors.WaitCursor
    '            Call myCDBConnection.OpenConn(CONN_.dbMain)

    '            'stSQL = "SELECT departemen FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' AND perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "' AND kelompok='" & strKelompok & "' AND tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "' GROUP BY departemen ORDER BY departemen;"
    '            stSQL = "SELECT concat(nama,' || ',nip,' || ',departemen) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE (tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') GROUP BY concat(nama,' || ',nip,' || ',departemen),idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian ORDER BY karyawan;"
    '            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawanIndividu, "T_" & cboKaryawanIndividu.Name, "nip", "karyawan", isCboPrepared, True)
    '        End If
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpPeriode_Validated Error")
    '    Finally
    '        If (cboPerusahaan.SelectedIndex <> -1 And cboLokasi.SelectedIndex <> -1) Then
    '            Call myCDBConnection.CloseConn(CONN_.dbMain)
    '            Me.Cursor = Cursors.Default
    '        End If
    '    End Try
    'End Sub

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

                    stSQL = "SELECT concat(nama,' || ',nip,' || ',departemen) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian FROM " & CONN_.schemaHRD & ".trdatapresensi WHERE (tanggal>='" & Format(dtpPeriodeMulai.Value.Date, "dd-MMM-yyyy") & "' AND tanggal<='" & Format(dtpPeriodeSelesai.Value.Date, "dd-MMM-yyyy") & "') AND (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') GROUP BY concat(nama,' || ',nip,' || ',departemen),idk,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,statuskepegawaian ORDER BY karyawan;"
                    Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawanIndividu, "T_" & cboKaryawanIndividu.Name, "nip", "karyawan", isCboPrepared, True)

                    Call myCDBConnection.CloseConn(CONN_.dbMain)
                    Me.Cursor = Cursors.Default
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboPeriode_SelectedIndexChanged Error")
        End Try
    End Sub

    'Private Sub cboDepartemen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartemen.SelectedIndexChanged
    '    Try
    '        If (isDataPrepared And cboDepartemen.SelectedIndex <> -1) Then
    '            Me.Cursor = Cursors.WaitCursor
    '            Call myCDBConnection.OpenConn(CONN_.dbMain)

    '            stSQL = "SELECT concat(nama,' || ',nip) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian FROM " & CONN_.schemaHRD & ".mskaryawanaktif " & IIf(USER_.lokasi = "ALL", "", "WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (departemen='" & myCStringManipulation.SafeSqlLiteral(cboDepartemen.SelectedValue) & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "')") & " GROUP BY concat(nama,' || ',nip),idk,nip,nama,perusahaan,departemen,divisi,bagian ORDER BY karyawan;"
    '            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawanIndividu, "T_" & cboKaryawanIndividu.Name, "nip", "karyawan", isCboPrepared, True)
    '        Else
    '            Me.Cursor = Cursors.WaitCursor
    '            Call myCDBConnection.OpenConn(CONN_.dbMain)

    '            stSQL = "SELECT concat(nama,' || ',nip) as karyawan,idk,nip,nama,perusahaan,departemen,divisi,bagian FROM " & CONN_.schemaHRD & ".mskaryawanaktif " & IIf(USER_.lokasi = "ALL", "", "WHERE (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaan.SelectedValue) & "') AND (kelompok='" & strKelompok & "') AND (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "')") & " GROUP BY concat(nama,' || ',nip),idk,nip,nama,perusahaan,departemen,divisi,bagian ORDER BY karyawan;"
    '            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawanIndividu, "T_" & cboKaryawanIndividu.Name, "nip", "karyawan", isCboPrepared, True)
    '        End If
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboDepartemen_SelectedIndexChanged Error")
    '    Finally
    '        If (isDataPrepared And cboDepartemen.SelectedIndex <> -1) Then
    '            Call myCDBConnection.CloseConn(CONN_.dbMain)
    '            Me.Cursor = Cursors.Default
    '        End If
    '    End Try
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Try
    '        Dim a As Double = TextBox1.Text
    '        Dim b As Double
    '        b = Math.Ceiling(a / 100) * 100
    '        MsgBox("a:" & a & " ; b:" & b)
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "Button1_Click Error")
    '    End Try
    'End Sub
End Class
