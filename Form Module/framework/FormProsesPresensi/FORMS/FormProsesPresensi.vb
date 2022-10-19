Public Class FormProsesPresensi
    Private tableName(14) As String
    Private isDataPrepared As Boolean = False
    Private stSQL As String
    Private newValues As String
    Private newFields As String
    Private myDataTableExcel As New DataTable
    Private myDataTableCboLokasi As New DataTable
    Private myBindingLokasi As New BindingSource
    Private myDataTableCboLokasiCetak As New DataTable
    Private myBindingLokasiCetak As New BindingSource
    Private myDataTableCboPerusahaanCetak As New DataTable
    Private myBindingPerusahaanCetak As New BindingSource
    Private myDataTableCboDepartemenCetak As New DataTable
    Private myBindingDepartemenCetak As New BindingSource
    Private myDataTableCboMesinCetak As New DataTable
    Private myBindingMesinCetak As New BindingSource
    Private myDataTableCboKaryawan As New DataTable
    Private myBindingKaryawan As New BindingSource
    Private isCboPrepared As Boolean

    Private tanggalBerjalan As Date
    Private tanggalAkhir As Date
    Private tanggalProses As Date
    Private hitungTanggal As Short
    Private isProses As Boolean
    Private isExist As Boolean
    Private selectedMachine As String

    Private Structure fileTempel
        Dim name As String
        Dim path As String
        Dim extension As String
    End Structure

    Private fileAttachment As fileTempel

    Const STR_MYCOMPUTER_CLSID As String = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaHRD As String, _connMain As Object, _connFinger As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String, _lokasi As String)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            isDataPrepared = False
            With CONN_
                .dbType = _dbType
                .dbMain = _connMain
                .dbFinger = _connFinger
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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormProsesPresensi Error")
        End Try
    End Sub

    Private Sub FormProsesPresensi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormProsesPresensi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'MsgBox(Application.CurrentCulture.ToString)
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            CONN_.excelPrvdrType = myCFileIO.ReadIniFile("EXCEL", "PRVDRTYPE", Application.StartupPath & "\SETTING.ini")

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='lokasi' " & IIf(USER_.lokasi = "ALL", "", "AND keterangan='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "'") & " order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboLokasi, myBindingLokasi, cboLokasi, "T_" & cboLokasi.Name, "keterangan", "keterangan", isCboPrepared)
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboLokasiCetak, myBindingLokasiCetak, cboLokasiCetak, "T_" & cboLokasiCetak.Name, "keterangan", "keterangan", isCboPrepared, True)
            cboLokasi.SelectedIndex = 0
            cboLokasiCetak.SelectedIndex = 0

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='perusahaan' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPerusahaanCetak, myBindingPerusahaanCetak, cboPerusahaanCetak, "T_" & cboPerusahaanCetak.Name, "keterangan", "keterangan", isCboPrepared)
            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='departemen' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboDepartemenCetak, myBindingDepartemenCetak, cboDepartemenCetak, "T_" & cboDepartemenCetak.Name, "keterangan", "keterangan", isCboPrepared)
            stSQL = "SELECT lokasi,mesin FROM " & CONN_.schemaHRD & ".msdaftarmesinpresensi " & IIf(USER_.lokasi = "ALL", "", "WHERE lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "'") & " order by lokasi,mesin;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboMesinCetak, myBindingMesinCetak, cboDaftarMesinCetak, "T_" & cboDaftarMesinCetak.Name, "mesin", "mesin", isCboPrepared)

            If (USER_.lokasi = "ALL") Then
                rbImportDataSidoarjo.Enabled = True
                gbImportDataSidoarjo.Enabled = True
                rbImportDataPandaan.Enabled = True
                gbImportDataPandaan.Enabled = True

                rbImportDataSidoarjo.Checked = True
                rbProsesPresensiSidoarjo.Checked = True
            ElseIf (USER_.lokasi = "SIDOARJO") Then
                rbImportDataSidoarjo.Enabled = True
                gbImportDataSidoarjo.Enabled = True
                rbImportDataPandaan.Enabled = False
                gbImportDataPandaan.Enabled = False

                rbImportDataSidoarjo.Checked = True
                rbProsesPresensiSidoarjo.Checked = True
            ElseIf (USER_.lokasi = "PANDAAN") Then
                rbImportDataSidoarjo.Enabled = False
                gbImportDataSidoarjo.Enabled = False
                rbImportDataPandaan.Enabled = True
                gbImportDataPandaan.Enabled = True

                rbImportDataPandaan.Checked = True
                rbProsesPresensiPandaan.Checked = True
            End If

            ofd1.InitialDirectory = STR_MYCOMPUTER_CLSID
            ofd1.Title = "Pilih File Excel"
            ofd1.Multiselect = False

            dtpPeriodeAwal.Value = Now.AddDays(-15)

            'Dim a As TimeSpan
            'Dim b As TimeSpan
            'Dim c As TimeSpan
            'Dim d As TimeSpan

            'a = CDate("07:48:01") - CDate("08:00:00")
            'b = CDate("07:48:01") - CDate("17:00:00")
            'MsgBox("a: " & a.ToString & " || b: " & b.ToString & " || a <= b ? " & IIf(a <= b, True, False) & " || a >= b ? " & IIf(a >= b, True, False))
            'MsgBox("a: " & IIf(a < TimeSpan.Parse("00:00:00"), a.Duration.ToString, a.ToString) & " || b: " & IIf(b < TimeSpan.Parse("00:00:00"), b.Duration.ToString, b.ToString))
            'MsgBox("a: " & a.Duration.ToString & " || b: " & b.Duration.ToString & " || a <= b ? " & IIf(a.Duration <= b.Duration, True, False) & " || a >= b ? " & IIf(a.Duration >= b.Duration, True, False))
            'a = CDate("17:19:31") - CDate("08:00:00")
            'b = CDate("17:19:31") - CDate("17:00:00")
            'MsgBox("a: " & a.ToString & " || b: " & b.ToString & " || a <= b ? " & IIf(a <= b, True, False) & " || a >= b ? " & IIf(a >= b, True, False))

            'a = TimeSpan.Parse("08:00:00")
            'b = TimeSpan.Parse("00:10:00")
            'c = TimeSpan.Parse("01:16:30")

            'd = TimeSpan.Parse(a.Hours - c.Hours & ":00:00")
            'If (c.Minutes > 0 And c.Minutes > b.Minutes) Then
            '    d = TimeSpan.Parse(d.Hours - 1 & ":00:00")
            'End If
            'MsgBox("Jam Kerja Sisa: " & d.ToString)

            tableName(0) = CONN_.schemaHRD & ".trdatapresensi"
            tableName(1) = CONN_.schemaHRD & ".trspkheader"
            tableName(2) = CONN_.schemaHRD & ".trspkdetail"
            tableName(3) = CONN_.schemaHRD & ".trsplheader"
            tableName(4) = CONN_.schemaHRD & ".trspldetail"
            tableName(5) = CONN_.schemaHRD & ".trijinabsen"
            tableName(6) = CONN_.schemaHRD & ".trscheduleshiftheader"
            tableName(7) = CONN_.schemaHRD & ".trscheduleshiftdetail"
            tableName(8) = CONN_.schemaTmp & ".datapresensi"
            tableName(9) = CONN_.schemaHRD & ".msskemapresensi"
            tableName(10) = CONN_.schemaHRD & ".mskaryawan"
            tableName(11) = CONN_.schemaHRD & ".mskaryawanaktif"
            tableName(12) = CONN_.schemaHRD & ".mstoleransimenit"
            tableName(13) = CONN_.schemaTmp & ".fpcheckclock"
            tableName(14) = CONN_.schemaHRD & ".msdefaultjamistirahat"

            rbLaporanPresensiKaryawanMingguan.Checked = True
            rbSemua.Checked = True

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormProsesPresensi_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormProsesPresensi_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNamaFile.KeyDown, tbNamaSheet.KeyDown, btnBrowse.KeyDown, dtpTanggal.KeyDown, btnProsesImport.KeyDown, cboLokasi.KeyDown, dtpPeriodeAwal.KeyDown, dtpPeriodeAkhir.KeyDown, btnTarikDataFingerprint.KeyDown, cboKaryawan.KeyDown, btnTarikDataKaryawan.KeyDown, btnUpdateIjinLemburSPK.KeyDown, btnProsesFP.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormProsesPresensi_KeyDown Error")
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
            tbNamaSheet.Text = fileAttachment.name.Substring(0, fileAttachment.name.LastIndexOf("."))

            isDataPrepared = False
            Cursor = Cursors.WaitCursor
            Call myCDBConnection.SetAndOpenConnForExcel(CONN_.dbExcel, fileAttachment.path, fileAttachment.extension.Replace(".", ""), CONN_.excelPrvdrType)

            Dim dateField As String
            Dim machineName As String

            Select Case True
                'Case rbImportDataFaceSDA.Checked
                '    dateField = "[Record Date]"
                '    machineName = "T_" & rbImportDataFaceSDA.Text.Replace(" ", "")
                Case rbImportDataFingerKahuripan.Checked
                    dateField = "[Date And Time]"
                    machineName = "T_" & rbImportDataFingerKahuripan.Text.Replace(" ", "")
                    'Case rbImportDataFingerspot.Checked
                    '    dateField = "Tanggal"
                    '    machineName = "T_" & rbImportDataFingerspot.Text.Replace(" ", "")
                    'Case rbImportDataAttendanceManagement.Checked
                    '    dateField = "[Date]"
                    '    machineName = "T_" & rbImportDataAttendanceManagement.Text.Replace(" ", "")
                    'Case rbImportDataBioTime.Checked
                    '    dateField = "[Date]"
                    '    machineName = "T_" & rbImportDataBioTime.Text.Replace(" ", "")
                Case Else
                    dateField = Nothing
                    machineName = Nothing
            End Select

            If Not IsNothing(dateField) Then
                If (myCFileIO.SheetExists(tbNamaSheet.Text, fileAttachment.path)) Then
                    stSQL = "SELECT " & dateField & IIf(dateField.ToUpper <> "TANGGAL", " as tanggal", "") & " FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE " & dateField & "  is not null GROUP BY " & dateField & " ORDER BY " & dateField & " ASC;"
                    myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, machineName)

                    If (myDataTableExcel.Rows.Count > 0) Then
                        dtpTanggal.MaxDate = myDataTableExcel.Rows(myDataTableExcel.Rows.Count - 1).Item("tanggal")
                        dtpTanggal.MinDate = myDataTableExcel.Rows(0).Item("tanggal")
                        dtpTanggal.Value = myDataTableExcel.Rows(0).Item("tanggal")
                    Else
                        Call myCShowMessage.ShowWarning("Data excel pada sheet " & tbNamaSheet.Text & " kosong!!")
                    End If
                Else
                    Call myCShowMessage.ShowWarning("Sheet " & Trim(tbNamaSheet.Text) & " tidak ditemukan!")
                End If
            End If
            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ofd1_FileOk Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbExcel, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub rbMesinImportData_CheckedChanged(sender As Object, e As EventArgs) Handles rbImportDataFaceSDA.CheckedChanged, rbImportDataFingerKahuripan.CheckedChanged, rbImportDataFingerspot.CheckedChanged, rbImportDataAttendanceManagement.CheckedChanged, rbImportDataBioTime.CheckedChanged, tbNamaSheet.Validated
        Try
            If ((sender Is tbNamaSheet) Or (tbNamaSheet.Text <> sender.Text)) Then
                If Not IsNothing(fileAttachment.name) Then
                    If Not (sender Is tbNamaSheet) Then
                        tbNamaSheet.Text = fileAttachment.name.Substring(0, fileAttachment.name.LastIndexOf("."))
                    End If
                End If

                If isDataPrepared Then
                    Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbExcel)

                    Dim datefield As String
                    Dim machinename As String

                    Select Case True
                        'Case rbImportDataFaceSDA.Checked
                        '    datefield = "[record date]"
                        '    machinename = "t_" & rbImportDataFaceSDA.Text.Replace(" ", "")
                        '    'tbNamaSheet.Text = rbImportDataFaceSDA.Text
                        Case rbImportDataFingerKahuripan.Checked
                            datefield = "[Date And Time]"
                            machinename = "t_" & rbImportDataFingerKahuripan.Text.Replace(" ", "")
                            'tbNamaSheet.Text = rbImportDataFingerKahuripan.Text
                            'Case rbImportDataFingerspot.Checked
                            '    datefield = "tanggal"
                            '    machinename = "t_" & rbImportDataFingerspot.Text.Replace(" ", "")
                            '    'tbNamaSheet.Text = rbImportDataFingerspot.Text
                            'Case rbImportDataAttendanceManagement.Checked
                            '    datefield = "[date]"
                            '    machinename = "t_" & rbImportDataAttendanceManagement.Text.Replace(" ", "")
                            '    'tbNamaSheet.Text = rbImportDataAttendanceManagement.Text
                            'Case rbImportDataBioTime.Checked
                            '    datefield = "[date]"
                            '    machinename = "t_" & rbImportDataBioTime.Text.Replace(" ", "")
                            '    'tbNamaSheet.Text = rbImportDataBioTime.Text
                        Case Else
                            datefield = Nothing
                            machinename = Nothing
                            tbNamaSheet.Clear()
                    End Select

                    If Not IsNothing(datefield) Then
                        If (myCFileIO.SheetExists(tbNamaSheet.Text, fileAttachment.path)) Then
                            stSQL = "SELECT " & datefield & IIf(datefield.ToUpper <> "tanggal", " as tanggal", "") & " FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE " & datefield & "  is not null group by " & datefield & " order by " & datefield & " asc;"
                            myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, machinename)

                            If (myDataTableExcel.Rows.Count > 0) Then
                                dtpTanggal.MaxDate = myDataTableExcel.Rows(myDataTableExcel.Rows.Count - 1).Item("tanggal")
                                dtpTanggal.MinDate = myDataTableExcel.Rows(0).Item("tanggal")
                                dtpTanggal.Value = myDataTableExcel.Rows(0).Item("tanggal")
                            Else
                                Call myCShowMessage.ShowWarning("data excel pada sheet " & tbNamaSheet.Text & " kosong!!")
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Sheet " & Trim(tbNamaSheet.Text) & " tidak ditemukan!")
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbMesinImportData_CheckedChanged Error")
        Finally
            If isDataPrepared Then
                Call myCDBConnection.CloseConn(CONN_.dbExcel, -1)
                Cursor = Cursors.Default
            End If
        End Try
    End Sub

    Private Sub rbMesinProsesAbsen_CheckedChanged(sender As Object, e As EventArgs) Handles rbProsesPresensiFaceSDA.CheckedChanged, rbProsesPresensiFingerSDA.CheckedChanged, rbProsesPresensiFingerspot.CheckedChanged, rbProsesPresensiAttendanceManagement.CheckedChanged, rbProsesAbsenBioTime.CheckedChanged
        Try
            selectedMachine = sender.text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbMesinProsesAbsen_CheckedChanged Error")
        End Try
    End Sub

    Private Sub btnProsesImport_Click(sender As Object, e As EventArgs) Handles btnProsesImport.Click
        Try
            If Not IsDBNull(CONN_.dbExcel) And (Trim(tbNamaSheet.Text).Length > 0) And (Trim(tbNamaFile.Text).Length > 0) Then
                If (myCFileIO.SheetExists(tbNamaSheet.Text, fileAttachment.path)) Then
                    Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                    Call myCDBConnection.OpenConn(CONN_.dbExcel)

                    Dim machineName As String
                    Dim myDataTableDataPresensi As New DataTable
                    Dim jamKeluar As TimeSpan
                    'Dim foundRows() As DataRow

                    stSQL = Nothing
                    Select Case True
                        'Case rbImportDataFaceSDA.Checked
                        '    stSQL = "SELECT '" & rbImportDataFaceSDA.Text & "' as mesin,[Record Date] as tanggal,[Personnel ID] as fpid,ucase([First Name]) & ' ' & ucase([Last Name]) as nama,ucase([Department Name]) as departemen,'' as kodewaktushift,[Earliest Time] as jammasuk,[Latest Time] as jamkeluar,'" & rbImportDataSidoarjo.Text & "' as lokasi FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE [First Name] <>'' AND [Record Date]=#" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "# AND ([Earliest Time] <>'' OR [Latest Time] <>'') GROUP BY '" & rbImportDataFaceSDA.Text & "',[Record Date],[Personnel ID],ucase([First Name]) & ' ' & ucase([Last Name]),[Department Name],[Earliest Time],[Latest Time],'" & rbImportDataSidoarjo.Text & "' ORDER BY ucase([First Name]) & ' ' & ucase([Last Name]) ASC;"
                        '    machineName = "t_" & rbImportDataFaceSDA.Text.Replace(" ", "")
                        Case rbImportDataFingerKahuripan.Checked
                            stSQL = "SELECT '" & rbImportDataFingerKahuripan.Text & "' as mesin, datevalue([Date And Time]) as tanggal,[personnel id] as fpid,ucase([First Name]) & ' ' & ucase([Last Name]) as nama,'' as kodewaktushift,Format([Date And Time], 'Long Time') as checkclock,'" & rbImportDataSidoarjo.Text & "' as lokasi FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE ([First Name] <>'' AND datevalue([Date And Time])=#" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "#) GROUP BY '" & rbImportDataFingerKahuripan.Text & "',[Date And Time],[Personnel ID],ucase([First Name]) & ' ' & ucase([Last Name]),'" & rbImportDataSidoarjo.Text & "' ORDER BY ucase([First Name]) & ' ' & ucase([Last Name]) ASC,[Date and Time];"
                            machineName = "t_" & rbImportDataFingerKahuripan.Text.Replace(" ", "")
                            'Case rbImportDataFingerspot.Checked
                            '    stSQL = "SELECT '" & rbImportDataFingerspot.Text & "' as mesin,tanggal,pin as fpid,ucase(nama) as nama,ucase(departemen) as departemen,ucase(kode) as kodewaktushift,[Scan 1] as jammasuk,[Scan 2] as jamkeluar,'" & rbImportDataPandaan.Text & "' as lokasi FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE nama <>'' AND tanggal=#" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "# AND ([Scan 1] <>'' OR [Scan 2] <>'') GROUP BY '" & rbImportDataFingerspot.Text & "',tanggal,pin,ucase(nama),departemen,kode,[Scan 1],[Scan 2],'" & rbImportDataPandaan.Text & "' ORDER BY ucase(nama) ASC;"
                            '    machineName = "t_" & rbImportDataFingerspot.Text.Replace(" ", "")
                            'Case rbImportDataAttendanceManagement.Checked
                            '    stSQL = "SELECT '" & rbImportDataAttendanceManagement.Text & "' as mesin,[Date] as tanggal,[AC-No] as fpid,ucase(name) as nama,'' as kodewaktushift,[Clock In] as jammasuk,[Clock Out] as jamkeluar,'" & rbImportDataPandaan.Text & "' as lokasi FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE name <>'' AND [Date]=#" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "# AND ([Clock In] <>'' OR [Clock Out] <>'') GROUP BY '" & rbImportDataAttendanceManagement.Text & "',[Date],[AC-No],ucase(name),[Clock In],[Clock Out],'" & rbImportDataPandaan.Text & "' ORDER BY ucase(name) ASC;"
                            '    machineName = "t_" & rbImportDataAttendanceManagement.Text.Replace(" ", "")
                            'Case rbImportDataBioTime.Checked
                            '    stSQL = "SELECT '" & rbImportDataBioTime.Text & "' as mesin,[Date] as tanggal,[Employee ID] as fpid,ucase([First Name]) as nama,ucase(Department) as departemen,'' as kodewaktushift,[First Punch] as jammasuk,[Last Punch] as jamkeluar,'" & rbImportDataPandaan.Text & "' as lokasi FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE [First Name] <>'' AND [Date]=#" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "# AND ([First Punch] <>'' OR [Last Punch] <>'') GROUP BY '" & rbImportDataBioTime.Text & "',[Date],[Employee ID],ucase([First Name]),Department,[First Punch],[Last Punch],'" & rbImportDataPandaan.Text & "' ORDER BY ucase([First Name]) ASC;"
                            '    machineName = "t_" & rbImportDataBioTime.Text.Replace(" ", "")
                        Case Else
                            stSQL = Nothing
                            machineName = Nothing
                    End Select

                    If Not IsNothing(stSQL) Then
                        myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, machineName)

                        If (myDataTableExcel.Rows.Count > 0) Then
                            myDataTableExcel.Columns("kodewaktushift").ReadOnly = False
                            For i As UShort = 0 To myDataTableExcel.Rows.Count - 1
                                If Not IsDBNull(myDataTableExcel.Rows(i).Item("kodewaktushift")) And Not IsNothing(myDataTableExcel.Rows(i).Item("kodewaktushift")) Then
                                    myDataTableExcel.Rows(i).Item("kodewaktushift") = Trim(myDataTableExcel.Rows(i).Item("kodewaktushift"))
                                    If (myDataTableExcel.Rows(i).Item("kodewaktushift").ToString.Length > 0) Then
                                        If IsNumeric(myDataTableExcel.Rows(i).Item("kodewaktushift").ToString.Substring(myDataTableExcel.Rows(i).Item("kodewaktushift").ToString.Length - 1)) Then
                                            Dim lastNumber As Byte = myDataTableExcel.Rows(i).Item("kodewaktushift").ToString.Substring(myDataTableExcel.Rows(i).Item("kodewaktushift").ToString.Length - 1)
                                            If (lastNumber = 1) Then
                                                myDataTableExcel.Rows(i).Item("kodewaktushift") = "P"
                                            ElseIf (lastNumber = 2) Then
                                                myDataTableExcel.Rows(i).Item("kodewaktushift") = "S"
                                            ElseIf (lastNumber = 3) Then
                                                myDataTableExcel.Rows(i).Item("kodewaktushift") = "M"
                                            End If
                                        Else
                                            myDataTableExcel.Rows(i).Item("kodewaktushift") = "-"
                                        End If
                                    End If
                                Else
                                    myDataTableExcel.Rows(i).Item("kodewaktushift") = "-"
                                End If
                            Next
                            Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(13), "mesin='" & myDataTableExcel.Rows(0).Item("mesin") & "' AND tanggal='" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "'", CONN_.dbType)
                            Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableExcel, tableName(13))

                            'KHUSUS KALAU TANGGAL DAN JAM JADI 1 KOLOM DAN TIDAK ADA KOLOM MASUK DAN KELUAR
                            stSQL = "SELECT mesin,tanggal,fpid,nama,departemen,MIN(checkclock) as jammasuk,lokasi,kodewaktushift FROM " & tableName(13) & " WHERE mesin='" & myDataTableExcel.Rows(0).Item("mesin") & "' AND tanggal='" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "' GROUP BY mesin,tanggal,fpid,nama,departemen,lokasi,kodewaktushift ORDER BY tanggal,nama;"
                            myDataTableDataPresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, machineName)
                            'MsgBox(myDataTableDataPresensi.Rows(0).Item("jammasuk").GetType.ToString)
                            myDataTableDataPresensi.Columns.Add("jamkeluar", GetType(TimeSpan))
                            'MsgBox(myDataTableDataPresensi.Rows(0).Item("jamkeluar").GetType.ToString)
                            For i As Integer = 0 To myDataTableDataPresensi.Rows.Count - 1
                                jamKeluar = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "checkclock", tableName(13),, "mesin='" & myCStringManipulation.SafeSqlLiteral(myDataTableDataPresensi.Rows(i).Item("mesin")) & "' and fpid=" & myDataTableDataPresensi.Rows(i).Item("fpid") & " and tanggal='" & Format(myDataTableDataPresensi.Rows(i).Item("tanggal"), "dd-MMM-yyyy") & "'")
                                myDataTableDataPresensi.Rows(i).Item("jamkeluar") = jamKeluar
                                If (i Mod 200 = 0) Then
                                    GC.Collect()
                                End If
                            Next
                            'MsgBox(myDataTableDataPresensi.Rows(0).Item("jamkeluar").GetType.ToString)
                            Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(8), "mesin='" & myDataTableDataPresensi.Rows(0).Item("mesin") & "' AND tanggal='" & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy") & "'", CONN_.dbType)
                            Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableDataPresensi, tableName(8))

                            Call myCShowMessage.ShowInfo("IMPORT SELESAI!!")
                        Else
                            Call myCShowMessage.ShowWarning("Tidak ada data FP di excel di tanggal " & Format(dtpTanggal.Value.Date, "dd-MMM-yyyy"))
                        End If
                    Else
                        Call myCShowMessage.ShowWarning("Silahkan pilih dulu data mesin mana yang mau diimport datanya!")
                    End If
                    Call myCDBConnection.CloseConn(CONN_.dbExcel, -1)
                Else
                    Call myCShowMessage.ShowWarning("Sheet " & Trim(tbNamaSheet.Text) & " tidak ditemukan!")
                End If
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua field yang bertanda *")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesImport_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Try
            Dim processInfo As ProcessStartInfo = New ProcessStartInfo()
            processInfo = myCFileIO.SetProcessInfo(processInfo, fileAttachment.extension, fileAttachment.path)
            Dim myProcess As Process = Process.Start(processInfo)

            If Not IsNothing(myProcess) Then
                'HARUS DITUTUP UNTUK MELEPAS RESOURCES NYA, MASIH BELUM BISA DIPAKAI!!
                myProcess.CloseMainWindow()
                myProcess.Close()
                'If Not (myProcess.HasExited) Then
                '    myProcess.Kill()
                'End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnPreview_Click Error")
        End Try
    End Sub

    Private Sub btnTarikDataFingerprint_Click(sender As Object, e As EventArgs) Handles btnTarikDataFingerprint.Click
        Try
            Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)
            Call myCDBConnection.OpenConn(CONN_.dbFinger)

            Dim myDataTableFinger As New DataTable
            Dim myDataTableDataPresensi As New DataTable
            Dim jamKeluar As TimeSpan

            tanggalBerjalan = Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy")
            tanggalAkhir = Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy")

            hitungTanggal = 0

            While tanggalBerjalan <= tanggalAkhir
                Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(13), "mesin='FINGER KAHURIPAN' and tanggal='" & Format(tanggalBerjalan, "dd-MMM-yyyy") & "'", CONN_.dbType)

                stSQL = "SELECT USERINFO.USERID, USERINFO.Badgenumber, USERINFO.SSN, USERINFO.name, Format([CHECKTIME],'dd-mmm-yyyy') AS tanggal, Format([CHECKTIME],'hh:nn:ss') AS checkclock
                        FROM USERINFO INNER JOIN CHECKINOUT ON USERINFO.USERID = CHECKINOUT.USERID
                        WHERE (((USERINFO.USERID) Is Not Null) AND ((USERINFO.name) Is Not Null) AND ((Format([CHECKTIME],'dd-mmm-yyyy'))='" & Format(tanggalBerjalan, "dd-MMM-yyyy") & "'))
                        GROUP BY USERINFO.USERID, USERINFO.Badgenumber, USERINFO.SSN, USERINFO.name, Format([CHECKTIME],'dd-mmm-yyyy'), Format([CHECKTIME],'hh:nn:ss')
                        ORDER BY USERINFO.name, Format([CHECKTIME],'dd-mmm-yyyy'), Format([CHECKTIME],'hh:nn:ss');"
                myDataTableFinger = myCDBOperation.GetDataTableUsingReader(CONN_.dbFinger, CONN_.comm, CONN_.reader, stSQL, "T_Finger")

                If (myDataTableFinger.Rows.Count > 0) Then
                    For i As Integer = 0 To myDataTableFinger.Rows.Count - 1
                        newValues = "'FINGER KAHURIPAN','" & Format(CDate(myDataTableFinger.Rows(i).Item("tanggal")), "dd-MMM-yyyy") & "'," & myDataTableFinger.Rows(i).Item("Badgenumber") & ",'" & myCStringManipulation.SafeSqlLiteral(myDataTableFinger.Rows(i).Item("name")) & "','" & myDataTableFinger.Rows(i).Item("checkclock") & "','" & cboLokasi.SelectedValue & "'"
                        newFields = "mesin,tanggal,fpid,nama,checkclock,lokasi"
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(13), newValues, newFields)

                        If (i Mod 100 = 0) Then
                            GC.Collect()
                        End If
                    Next

                    'KHUSUS KALAU TANGGAL DAN JAM JADI 1 KOLOM DAN TIDAK ADA KOLOM MASUK DAN KELUAR
                    stSQL = "SELECT mesin,tanggal,fpid,nama,departemen,MIN(checkclock) as jammasuk,lokasi,kodewaktushift FROM " & tableName(13) & " WHERE mesin='FINGER KAHURIPAN' and tanggal='" & Format(tanggalBerjalan, "dd-MMM-yyyy") & "' GROUP BY mesin,tanggal,fpid,nama,departemen,lokasi,kodewaktushift ORDER BY tanggal,nama;"
                    myDataTableDataPresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_PresensiMedbox")
                    myDataTableDataPresensi.Columns.Add("jamkeluar", GetType(TimeSpan))
                    For i As Integer = 0 To myDataTableDataPresensi.Rows.Count - 1
                        jamKeluar = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "checkclock", tableName(13),, "mesin='" & myCStringManipulation.SafeSqlLiteral(myDataTableDataPresensi.Rows(i).Item("mesin")) & "' and fpid=" & myDataTableDataPresensi.Rows(i).Item("fpid") & " and tanggal='" & Format(tanggalBerjalan, "dd-MMM-yyyy") & "'")
                        myDataTableDataPresensi.Rows(i).Item("jamkeluar") = jamKeluar
                        If (i Mod 100 = 0) Then
                            GC.Collect()
                        End If
                    Next
                    Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(8), "mesin='" & myDataTableDataPresensi.Rows(0).Item("mesin") & "' AND tanggal='" & Format(tanggalBerjalan, "dd-MMM-yyyy") & "'", CONN_.dbType)
                    Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableDataPresensi, tableName(8))
                End If

                tanggalBerjalan = tanggalBerjalan.AddDays(1)
                hitungTanggal += 1
                If (hitungTanggal Mod 10 = 0) Then
                    GC.Collect()
                End If
            End While

            Call myCShowMessage.ShowInfo("PROSES SELESAI!!")

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTarikDataFingerprint_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbFinger, -1)
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnTarikDataKaryawan_Click(sender As Object, e As EventArgs) Handles btnTarikDataKaryawan.Click
        Try
            If (cboLokasi.SelectedIndex <> -1) Then
                Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim myDataTableKaryawan As New DataTable
                Dim idx As Short
                Dim kdr As String
                Dim shiftPerDay As Byte
                Dim totalKaryawan As UShort

                tanggalBerjalan = Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy")
                tanggalAkhir = Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy")

                hitungTanggal = 0
                isProses = False
                While tanggalBerjalan <= tanggalAkhir
                    tanggalProses = tanggalBerjalan
                    lblTanggalProses.Text = Format(tanggalProses, "dd-MMM-yyyy")

                    If (WeekdayName(Weekday(DateSerial(tanggalProses.Year, tanggalProses.Month, tanggalProses.Day))) = "Sunday") Then
                        Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau memproses presensi untuk hari minggu " & Format(tanggalProses, "dd-MMM-yyyy") & "?", "PROSES PRESENSI HARI MINGGU??")
                        If (isConfirm = DialogResult.Yes) Then
                            'YES
                            isProses = True
                        Else
                            'NO
                            isProses = False
                        End If
                    Else
                        isProses = True
                    End If

                    If (isProses) Then
                        stSQL = Nothing
                        If (rbSemua.Checked) Then
                            stSQL = "SELECT tbl2.idk,tbl2.nip,tbl2.fpid,tbl2.nama,tbl2.bagian,tbl2.divisi,tbl2.departemen,tbl2.perusahaan,tbl2.lokasi,tbl2.kelompok,tbl2.katpenggajian,tbl2.statuskepegawaian,(case when tbl2.statuskepegawaian='KONTRAK' then tbl2.tglmulaikontrak else tbl1.tanggalmasuk end) as tanggalmasuk
                                    FROM (" & tableName(10) & " as tbl1 inner join " & tableName(11) & " as tbl2 on tbl1.idk=tbl2.idk) 
                                    WHERE (tbl2.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND ((tbl1.statusbekerja='AKTIF' AND tbl1.tanggalmasuk<='" & Format(tanggalProses, "dd-MMM-yyyy") & "') OR (tbl1.statusbekerja<>'AKTIF' AND tbl1.tanggalterakhirbekerja>='" & Format(tanggalProses, "dd-MMM-yyyy") & "'))
                                    ORDER BY tbl2.lokasi,tbl2.perusahaan,tbl2.departemen,tbl2.nama;"
                        ElseIf (rbKaryawan.Checked And cboKaryawan.SelectedIndex <> -1) Then
                            stSQL = "SELECT tbl2.idk,tbl2.nip,tbl2.fpid,tbl2.nama,tbl2.bagian,tbl2.divisi,tbl2.departemen,tbl2.perusahaan,tbl2.lokasi,tbl2.kelompok,tbl2.katpenggajian,tbl2.statuskepegawaian,(case when tbl2.statuskepegawaian='KONTRAK' then tbl2.tglmulaikontrak else tbl1.tanggalmasuk end) as tanggalmasuk
                                    FROM (" & tableName(10) & " as tbl1 inner join " & tableName(11) & " as tbl2 on tbl1.idk=tbl2.idk) 
                                    WHERE (tbl2.nip='" & myCStringManipulation.SafeSqlLiteral(cboKaryawan.SelectedValue) & "') AND (tbl2.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND ((tbl1.statusbekerja='AKTIF' AND tbl1.tanggalmasuk<='" & Format(tanggalProses, "dd-MMM-yyyy") & "') OR (tbl1.statusbekerja<>'AKTIF' AND tbl1.tanggalterakhirbekerja>='" & Format(tanggalProses, "dd-MMM-yyyy") & "'))
                                    ORDER BY tbl2.lokasi,tbl2.perusahaan,tbl2.departemen,tbl2.nama;"
                        End If
                        If Not (IsNothing(stSQL)) Then
                            myDataTableKaryawan = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Karyawan")
                            myDataTableKaryawan.Columns.Add("kdr", GetType(String))
                            myDataTableKaryawan.Columns.Add("tanggal", GetType(Date))
                            'myDataTableKaryawan.Columns.Add("created_at", GetType(Date))
                            myDataTableKaryawan.Columns.Add("userid", GetType(String))
                            myDataTableKaryawan.Columns.Add("userpc", GetType(String))
                            myDataTableKaryawan.Columns.Add("isnew", GetType(Boolean))

                            idx = 0
                            'ini harus ditampung di total karyawan, karena kalau nggak, nanti pada saat proses di bawah jumlah data table karyawannya bisa bertambah
                            totalKaryawan = myDataTableKaryawan.Rows.Count
                            lblTotal.Text = totalKaryawan


                            pnlLoading.Visible = True
                            lblTanggalProses.Visible = True
                            pbLoading.Minimum = 0
                            pbLoading.Maximum = totalKaryawan
                            pbLoading.ForeColor = Color.Green

                            While idx < totalKaryawan
                                kdr = (Format(tanggalProses, "ddMMMyyyy") & myDataTableKaryawan.Rows(idx).Item("nip") & "A").ToString.ToUpper
                                'kdr = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(0), "kdr", "rid", Format(tanggalProses, "dd-MMM-yyyy"), myDataTableKaryawan.Rows(idx).Item("nip"), 1, CONN_.dbType)
                                isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "kdr", tableName(0), "kdr='" & myCStringManipulation.SafeSqlLiteral(kdr) & "'")
                                myDataTableKaryawan.Rows(idx).Item("kdr") = kdr
                                myDataTableKaryawan.Rows(idx).Item("tanggal") = Format(tanggalProses, "dd-MMM-yyyy")
                                'myDataTableKaryawan.Rows(idx).Item("created_at") = Now
                                myDataTableKaryawan.Rows(idx).Item("userid") = USER_.username
                                myDataTableKaryawan.Rows(idx).Item("userpc") = myCManagementSystem.GetComputerName
                                myDataTableKaryawan.Rows(idx).Item("isnew") = Not isExist

                                'Buat ambil yang 1 hari bisa ada 2 shift, ditambahkan baris baru
                                'banyak = "select count(nama) FROM datapresensi WHERE lokasi='Pandaan' and tanggal='2021-12-01' and fpid=5016;"
                                shiftPerDay = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "linenr", tableName(7), "Count", "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and tanggal='" & Format(tanggalProses, "dd-MMM-yyyy") & "' and nip='" & myDataTableKaryawan.Rows(idx).Item("nip") & "'")
                                If (shiftPerDay = 2) Then
                                    With myDataTableKaryawan
                                        Dim newRow As DataRow = .NewRow()
                                        'kdr = myCDBOperation.SetDynamicKDR(CONN_.dbMain, CONN_.comm, CONN_.reader, tableName(0), "kdr", "rid", Format(tanggalProses, "dd-MMM-yyyy"), myDataTableKaryawan.Rows(idx).Item("nip"), 1, CONN_.dbType)
                                        kdr = Format(tanggalProses, "ddMMMyyyy") & myDataTableKaryawan.Rows(idx).Item("nip") & "B"
                                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "kdr", tableName(0), "kdr='" & myCStringManipulation.SafeSqlLiteral(kdr) & "'")
                                        newRow("idk") = .Rows(idx).Item("idk")
                                        newRow("nip") = .Rows(idx).Item("nip")
                                        newRow("fpid") = .Rows(idx).Item("fpid")
                                        newRow("nama") = .Rows(idx).Item("nama")
                                        newRow("bagian") = .Rows(idx).Item("bagian")
                                        newRow("divisi") = .Rows(idx).Item("divisi")
                                        newRow("departemen") = .Rows(idx).Item("departemen")
                                        newRow("perusahaan") = .Rows(idx).Item("perusahaan")
                                        newRow("lokasi") = .Rows(idx).Item("lokasi")
                                        newRow("kelompok") = .Rows(idx).Item("kelompok")
                                        newRow("katpenggajian") = .Rows(idx).Item("katpenggajian")
                                        newRow("statuskepegawaian") = .Rows(idx).Item("statuskepegawaian")
                                        newRow("kdr") = kdr
                                        newRow("tanggal") = Format(tanggalProses, "dd-MMM-yyyy")
                                        newRow("userid") = USER_.username
                                        newRow("userpc") = myCManagementSystem.GetComputerName
                                        newRow("isnew") = Not isExist
                                        .Rows.Add(newRow)
                                    End With
                                End If

                                pbLoading.Value = idx
                                idx += 1
                                lblCount.Text = idx
                                If (idx Mod 100 = 0) Then
                                    GC.Collect()
                                End If
                            End While
                            'Hanya yang baru saja yang diinputkan, yang sudah ada, tidak perlu diinputkan lagi!!
                            Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableKaryawan, tableName(0),, "isnew")
                        Else
                            Call myCShowMessage.ShowWarning("Pastikan kriteria yang mau diproses sudah dipilih!" & ControlChars.NewLine & "Jika memilih karyawan, pastikan sudah memilih spesifik karyawannya dari dropdown")
                        End If
                    End If

                    tanggalBerjalan = tanggalBerjalan.AddDays(1)
                    hitungTanggal += 1
                    If (hitungTanggal Mod 10 = 0) Then
                        GC.Collect()
                    End If
                End While

                Call myCShowMessage.ShowInfo("DONE!!" & ControlChars.NewLine & "Sebanyak " & totalKaryawan & " data karyawan dari tanggal " & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & " - " & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & " siap untuk diproses presensinya!")
                pnlLoading.Visible = False
                lblTanggalProses.Visible = False
            Else
                Call myCShowMessage.ShowWarning("Pilih dulu lokasinya!!")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTarikDataKaryawan_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnUpdateIjinLemburSPK_Click(sender As Object, e As EventArgs) Handles btnUpdateIjinLemburSPK.Click
        Try
            If (cboLokasi.SelectedIndex <> -1) Then
                Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim queryBuilder As New Text.StringBuilder
                queryBuilder.Clear()
                Dim countError As Byte = 0
                Dim nipKaryawan As String = Nothing

                If (rbSemua.Checked) Then
                    nipKaryawan = Nothing
                ElseIf (rbKaryawan.Checked) Then
                    If (cboKaryawan.SelectedIndex <> -1) Then
                        nipKaryawan = cboKaryawan.SelectedValue
                    Else
                        Call myCShowMessage.ShowWarning("Silahkan pilih dulu karyawannya")
                        cboKaryawan.Focus()
                        nipKaryawan = Nothing
                        Exit Sub
                    End If
                End If

                'NULL KAN DULU KOLOM IJIN DAN ABSEN
                queryBuilder.Clear()
                queryBuilder.Append("update " & tableName(0) & " set ijin=null,absen=null WHERE " & IIf(Not IsNothing(nipKaryawan), "(nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "');")
                'IJIN ABSEN
                queryBuilder.Append("update " & tableName(0) & " as a set ijin=i.kodeijin,absen=i.kodeabsen,updated_at=clock_timestamp() FROM " & tableName(5) & " as i WHERE " & IIf(Not IsNothing(nipKaryawan), "(a.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & " a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and (a.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (a.tanggal>=i.tanggalmulai and a.tanggal<=i.tanggalselesai) and (a.nip=i.nip);")
                If Not (myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString)) Then
                    countError += 1
                    Call myCShowMessage.ShowWarning("Ada kesalahan saat eksekusi perintah update ijin absen" & ControlChars.NewLine & "Silahkan hubungi EDP yang bertugas!")
                End If

                'LEMBUR
                queryBuilder.Clear()
                queryBuilder.Append("update " & tableName(0) & " set jamlembur=null,mulailembur=null,selesailembur=null WHERE " & IIf(Not IsNothing(nipKaryawan), "(nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "');")
                queryBuilder.Append("update " & tableName(0) & " as a set jamlembur=spl.jamlembur,mulailembur=spl.mulai,selesailembur=spl.selesai,updated_at=clock_timestamp() FROM (select d.nip,d.nama,d.realisasijamlembur as jamlembur,CAST(d.realisasimulai AS DATE) as tanggalmulailembur,CAST(d.realisasiselesai AS DATE) as tanggalselesailembur,d.realisasimulai as mulai,d.realisasiselesai as selesai from " & tableName(3) & " as h inner join " & tableName(4) & " as d on h.nospl=d.nospl where " & IIf(Not IsNothing(nipKaryawan), "(d.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (CAST(d.realisasimulai AS DATE)>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and CAST(d.realisasimulai AS DATE)<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "')) as spl WHERE " & IIf(Not IsNothing(nipKaryawan), "(a.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (a.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (a.tanggal=spl.tanggalmulailembur) and (a.nip=spl.nip);")
                If Not (myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString)) Then
                    countError += 1
                    Call myCShowMessage.ShowWarning("Ada kesalahan saat eksekusi perintah update lembur" & ControlChars.NewLine & "Silahkan hubungi EDP yang bertugas!")
                End If

                'SPK
                queryBuilder.Clear()
                queryBuilder.Append("update " & tableName(0) & " set shift=1,jadwalmasuk=null,jadwalkeluar=null,terlambat=null,pulangcepat=null,spkmulai=null,spkselesai=null WHERE " & IIf(Not IsNothing(nipKaryawan), "(nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (spkmulai is not null and spkselesai is not null);")
                queryBuilder.Append("update " & tableName(0) & " as a set shift=spk.shift,spkmulai=spk.mulai,spkselesai=spk.selesai,updated_at=clock_timestamp() FROM (select d.nip,d.nama,CAST(d.mulai AS DATE) as tanggalspkmulai,CAST(d.selesai AS DATE) as tanggalspkselesai,d.shift,d.mulai,d.selesai from " & tableName(1) & " as h inner join " & tableName(2) & " as d on h.nospk=d.nospk where " & IIf(Not IsNothing(nipKaryawan), "(d.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (CAST(d.mulai AS DATE)>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and CAST(d.mulai AS DATE)<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "')) as spk WHERE " & IIf(Not IsNothing(nipKaryawan), "(a.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (a.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (a.tanggal=spk.tanggalspkmulai) and (a.nip=spk.nip);")
                If Not (myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString)) Then
                    countError += 1
                    Call myCShowMessage.ShowWarning("Ada kesalahan saat eksekusi perintah update SPK" & ControlChars.NewLine & "Silahkan hubungi EDP yang bertugas!")
                End If

                'KECUALI YANG ADA IJIN LEMBUR ATAU SPK NYA
                'UNTUK SET SESUAI KALENDER LIBUR DAN CUTI BERSAMA
                queryBuilder.Clear()
                queryBuilder.Append("update " & tableName(0) & " as a set ijin='TM',absen=kp.kode,updated_at=clock_timestamp() FROM (select g.kode,k.tanggal FROM " & CONN_.schemaHRD & ".msgeneral as g inner join " & CONN_.schemaHRD & ".kalenderperusahaan as k on g.keterangan=k.katlibur WHERE (k.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and k.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (k.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (k.libur='True')) as kp WHERE " & IIf(Not IsNothing(nipKaryawan), "(a.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(a.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (a.tanggal=kp.tanggal) AND (a.departemen<>'APOTEK') AND (a.spkmulai is null) AND (a.spkselesai is null);")
                'Untuk update yang belum 1 tahun kerja belum mendapatkan jatah cuti atau yang non staff dan kontrak, tidak punya jatah cuti
                queryBuilder.Append("update " & tableName(0) & " as a set absen='NC' FROM " & CONN_.schemaHRD & ".mskaryawan as k inner join " & CONN_.schemaHRD & ".mskaryawanaktif as f on k.idk=f.idk where " & IIf(Not IsNothing(nipKaryawan), "(a.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(a.idk=k.idk) and (a.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and ((f.statuskepegawaian='TETAP' and k.tanggalmasuk>='" & Format(DateSerial(dtpPeriodeAwal.Value.Year - 1, dtpPeriodeAwal.Value.Month - 1, 1), "dd-MMM-yyyy") & "') or (f.statuskepegawaian='KONTRAK' or f.statuskepegawaian='LEPAS' or f.statuskepegawaian is null)) and (a.ijin='TM') and (a.absen='C');")
                'SCHEDULE LIBUR SESUAI JADWAL SCHEDULE SHIFT
                queryBuilder.Append("update " & tableName(0) & " as a set ijin='TM',absen='L',updated_at=clock_timestamp() FROM (select d.nip,d.tanggal,d.waktushift FROM " & tableName(6) & " as h inner join " & tableName(7) & " as d on h.noscheduleshift=d.noscheduleshift where " & IIf(Not IsNothing(nipKaryawan), "(d.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(d.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and d.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (d.waktushift='X') and (d.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "')) as sch WHERE " & IIf(Not IsNothing(nipKaryawan), "(a.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(a.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (a.nip=sch.nip) and (a.tanggal=sch.tanggal) and (sch.waktushift='X') AND (a.jamlembur is null) AND (a.spkmulai is null AND a.spkselesai is null);")
                'UNTUK APOTEK, SABTU MINGGU TETAP MASUK, JADWAL LIBUR MENGIKUT SCHEDULE SHIFT SAJA, TIDAK MELIHAT KALENDER
                'KHUSUS DOKTER SAJA YANG LIBUR SABTU MINGGU
                'PAKAI NOT IN
                'queryBuilder.Append("update " & tableName(0) & " as a set ijin='TM',absen='L',updated_at=clock_timestamp() WHERE " & IIf(Not IsNothing(nipKaryawan), "(a.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(a.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and a.tanggal not in(select tanggal from " & CONN_.schemaHRD & ".kalenderperusahaan where (tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (libur='False')) and (a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (trim(to_char(a.tanggal, 'day')) IN ('saturday','sunday')) AND ((a.bagian='DOKTER')) AND (a.jamlembur is null) AND (a.spkmulai is null and a.spkselesai is null);")
                'PAKAI NOT EXISTS
                queryBuilder.Append("update " & tableName(0) & " as a set ijin='TM',absen='L',updated_at=clock_timestamp() WHERE " & IIf(Not IsNothing(nipKaryawan), "(a.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(a.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and not exists(select 1 from " & CONN_.schemaHRD & ".kalenderperusahaan as kp where (kp.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and kp.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (kp.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (kp.libur='False') and (a.tanggal=kp.tanggal)) and (a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (trim(to_char(a.tanggal, 'day')) IN ('saturday','sunday')) AND ((a.departemen='KLINIK')) AND (a.spkmulai is null and a.spkselesai is null);")
                If Not (myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString)) Then
                    countError += 1
                    Call myCShowMessage.ShowWarning("Ada kesalahan saat eksekusi perintah update IJIN dan ABSEN untuk libur, cuti bersama, dan hari sabtu minggu" & ControlChars.NewLine & "Silahkan hubungi EDP yang bertugas!")
                End If

                'KALAU YANG KOLOM IJINNYA TM (TIDAK MASUK) MAKA JAM MASUK DAN JAM PULANGNYA DI NULL KAN
                queryBuilder.Clear()
                queryBuilder.Append("update " & tableName(0) & " as a set masuk=Null,keluar=Null,terlambat=Null,pulangcepat=Null,updated_at=clock_timestamp() WHERE " & IIf(Not IsNothing(nipKaryawan), "(a.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (a.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and (a.ijin='TM') and (a.absen is not null) AND (a.jamlembur is null) AND (a.spkmulai is null)")
                If Not (myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString)) Then
                    countError += 1
                    Call myCShowMessage.ShowWarning("Ada kesalahan saat eksekusi perintah update JAM MASUK DAN JAM KELUAR" & ControlChars.NewLine & "Silahkan hubungi EDP yang bertugas!")
                End If

                If (countError = 0) Then
                    Call myCShowMessage.ShowInfo("DONE!!")
                End If
            Else
                Call myCShowMessage.ShowWarning("Pilih dulu lokasinya!!")
            End If

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnUpdateIjinLemburSPK_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dtpPeriode_Validated(sender As Object, e As EventArgs) Handles dtpPeriodeAwal.Validated, dtpPeriodeAkhir.Validated
        Try
            If (sender Is dtpPeriodeAwal) Then
                If (dtpPeriodeAkhir.Value < dtpPeriodeAwal.Value) Then
                    dtpPeriodeAkhir.Value = dtpPeriodeAwal.Value
                End If
            ElseIf (sender Is dtpPeriodeAkhir) Then
                If (dtpPeriodeAkhir.Value < dtpPeriodeAwal.Value) Then
                    dtpPeriodeAwal.Value = dtpPeriodeAkhir.Value
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dtpPeriode_Validated Error")
        End Try
    End Sub

    Private Sub btnProsesFP_Click(sender As Object, e As EventArgs) Handles btnProsesFP.Click
        Try
            If (cboLokasi.SelectedIndex <> -1) Then
                Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim myDataTableSPK As New DataTable
                Dim myDataTableSkemaPresensi As New DataTable
                Dim myDataTableTmpFP As New DataTable
                Dim myDataTablePresensi As New DataTable
                Dim myDataTableScheduleShift As New DataTable
                Dim countUpdate As UInteger
                Dim jumDataPresensi As Short
                Dim updateString As String
                Dim foundRows As DataRow()
                Dim arrUpdateValues(15) As String
                Dim strSelisihJam As TimeSpan
                Dim strSelisihJamKeluar As TimeSpan
                Dim strSelisihJamMasuk As TimeSpan
                Dim queryBuilder As New Text.StringBuilder
                Dim shiftPerDay As Byte
                'Dim waktuShift As Char
                Dim arrGrup(2) As String
                Dim jabatan As String
                'Dim batasToleransi As TimeSpan
                'Dim pengurangJamKerja As String
                Dim nipKaryawan As String = Nothing

                tanggalBerjalan = dtpPeriodeAwal.Value.Date
                tanggalAkhir = dtpPeriodeAkhir.Value.Date

                hitungTanggal = 0
                countUpdate = 0

                'NOTES
                'arrUpdateValues(0) = kodewaktushift
                'arrUpdateValues(1) = jadwal jam masuk
                'arrUpdateValues(2) = jadwal jam pulang
                'arrUpdateValues(3) = fp masuk
                'arrUpdateValues(4) = fp pulang
                'arrUpdateValues(5) = jam masuk (hasil proses)
                'arrUpdateValues(6) = jam pulang (hasil proses)
                'arrUpdateValues(7) = terlambat
                'arrUpdateValues(8) = pulang cepat
                'arrUpdateValues(9) = shift
                'arrUpdateValues(10) = jam kerja
                'arrUpdateValues(11) = banyak jam kerja
                'arrUpdateValues(12) = mohon ijin
                'arrUpdateValues(13) = tidak masuk
                'arrUpdateValues(14) = jam kerja nyata
                'arrUpdateValues(15) = banyak jam kerja nyata

                While tanggalBerjalan <= tanggalAkhir
                    queryBuilder.Clear()

                    lblTanggalProses.Text = Format(tanggalBerjalan, "dd-MMM-yyyy")

                    If (rbSemua.Checked) Then
                        nipKaryawan = Nothing
                    ElseIf (rbKaryawan.Checked) Then
                        If (cboKaryawan.SelectedIndex <> -1) Then
                            nipKaryawan = cboKaryawan.SelectedValue
                        Else
                            Call myCShowMessage.ShowWarning("Silahkan pilih dulu karyawannya")
                            cboKaryawan.Focus()
                            nipKaryawan = Nothing
                            Exit Sub
                        End If
                    End If

                    stSQL = "SELECT d.tanggal,d.perusahaan,d.departemen,d.grup,d.ketgrup,d.linenr,d.nip,d.nama,d.posisi,d.waktushift FROM " & tableName(6) & " as h inner join " & tableName(7) & " as d on h.noscheduleshift=d.noscheduleshift WHERE " & IIf(Not IsNothing(nipKaryawan), "(d.nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(d.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (d.tanggal='" & Format(tanggalBerjalan, "dd-MMM-yyyy") & "') ORDER BY d.nama,d.linenr;"
                    myDataTableScheduleShift = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_ScheduleShift")
                    Dim newColumn As New DataColumn("sudah", GetType(Boolean))
                    newColumn.DefaultValue = False
                    myDataTableScheduleShift.Columns.Add(newColumn)

                    stSQL = "SELECT grup,ketgrup,spesifik,nip,nama,perusahaan,departemen,posisi,kodewaktushift,jammasuk,jamkeluar FROM " & tableName(9) & " WHERE (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (hari='" & myCStringManipulation.TranslateWeekdayName(WeekdayName(Weekday(tanggalBerjalan))).ToUpper & "');"
                    myDataTableSkemaPresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_SkemaPresensi")

                    stSQL = "SELECT fpid,nama,jammasuk,jamkeluar,kodewaktushift FROM " & tableName(8) & " WHERE (lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND (tanggal='" & Format(tanggalBerjalan, "dd-MMM-yyyy") & "');"
                    myDataTableTmpFP = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_DataFP")

                    stSQL = "SELECT rid,kdr,tanggal,lokasi,fpid,nip,nama,kelompok,katpenggajian,perusahaan,departemen,divisi,bagian,absen,cast(spkmulai as time) as jammulai,cast(spkselesai as time) as jamselesai,jamlembur,mulailembur,selesailembur,date(spkmulai) as tanggalshift FROM " & tableName(0) & " WHERE " & IIf(Not IsNothing(nipKaryawan), "(nip='" & myCStringManipulation.SafeSqlLiteral(nipKaryawan) & "') AND ", "") & "(lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') and (tanggal='" & Format(tanggalBerjalan, "dd-MMM-yyyy") & "') and ((masuk is null or keluar is null) or (jadwalmasuk is null or jadwalkeluar is null)) order by nama,kdr;"
                    myDataTablePresensi = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_PRESENSI")
                    jumDataPresensi = myDataTablePresensi.Rows.Count
                    lblTotal.Text = jumDataPresensi

                    pnlLoading.Visible = True
                    lblTanggalProses.Visible = True
                    pbLoading.Minimum = 0
                    pbLoading.Maximum = jumDataPresensi
                    pbLoading.ForeColor = Color.Green
                    countUpdate = 0

                    For i As Short = 0 To jumDataPresensi - 1
                        For a As Byte = 0 To arrUpdateValues.Length - 1
                            arrUpdateValues(a) = Nothing
                        Next
                        updateString = Nothing

                        'If (myDataTablePresensi.Rows(i).Item("nip") = "11112002") Then
                        '    InputBox("", "", myDataTablePresensi.Rows(i).Item("nama"))
                        'End If

                        'If (myDataTablePresensi.Rows(i).Item("nip") = "PIMT20210104001") Then
                        '    MsgBox("TES")
                        '    foundRows = myDataTableScheduleShift.Select("perusahaan='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("perusahaan")) & "' AND departemen='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("departemen")) & "' AND nip='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("nip")) & "'")
                        '    If (foundRows.Length > 0) Then
                        '        Jika ditemukan, maka ikut shift dari data schedule shift
                        '        MsgBox("WAKTU SHIFT: " & myDataTableScheduleShift.Rows(myDataTableScheduleShift.Rows.IndexOf(foundRows(0))).Item("waktushift") & " ; SUDAH: " & myDataTableScheduleShift.Rows(myDataTableScheduleShift.Rows.IndexOf(foundRows(0))).Item("sudah"))
                        '    End If
                        'End If

                        If IsDBNull(myDataTablePresensi.Rows(i).Item("departemen")) Then
                            arrGrup(0) = Nothing
                        Else
                            arrGrup(0) = myDataTablePresensi.Rows(i).Item("departemen")
                        End If

                        If IsDBNull(myDataTablePresensi.Rows(i).Item("divisi")) Then
                            arrGrup(1) = Nothing
                        Else
                            arrGrup(1) = myDataTablePresensi.Rows(i).Item("divisi")
                        End If

                        If IsDBNull(myDataTablePresensi.Rows(i).Item("bagian")) Then
                            arrGrup(2) = Nothing
                        Else
                            arrGrup(2) = myDataTablePresensi.Rows(i).Item("bagian")
                        End If

                        '===============================================================================================
                        '0. Cek dulu karyawan ini ada berapa shift sehari
                        shiftPerDay = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "kdr", tableName(0), "Count", "tanggal='" & Format(CDate(myDataTablePresensi.Rows(i).Item("tanggal")), "dd-MMM-yyyy") & "' AND perusahaan='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("perusahaan")) & "' AND nip='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("nip")) & "'")
                        'MsgBox(shiftPerDay)
                        'If (shiftPerDay = 2) Then
                        '    'Berarti sehari karyawan ini masuk 2x, maka diambil 

                        'End If
                        '===============================================================================================

                        '===============================================================================================
                        '1. Ambil schedule shift
                        'foundRows = myDataTableScheduleShift.Select("perusahaan='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("perusahaan")) & "' AND ((grup='DEPARTEMEN' and ketgrup='" & IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("departemen")), "", myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("departemen"))) & "') or (grup='DIVISI' and ketgrup='" & IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("divisi")), "", myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("divisi"))) & "') or (grup='BAGIAN' and ketgrup='" & IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("bagian")), "", myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("bagian"))) & "')) AND nip='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("nip")) & "' and sudah='False'")
                        'BAGIAN
                        'foundRows = myDataTableScheduleShift.Select("perusahaan='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("perusahaan")) & "' AND (departemen='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("departemen")) & "') AND (grup='BAGIAN' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(arrGrup(2)) & "') And nip ='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("nip")) & "' and sudah='False'")
                        foundRows = myDataTableScheduleShift.Select("nip ='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("nip")) & "' and sudah='False'")
                        If (foundRows.Length > 0) Then
                            'Jika ditemukan, maka ikut shift dari data schedule shift
                            arrUpdateValues(0) = myDataTableScheduleShift.Rows(myDataTableScheduleShift.Rows.IndexOf(foundRows(0))).Item("waktushift")
                            myDataTableScheduleShift.Rows(myDataTableScheduleShift.Rows.IndexOf(foundRows(0))).Item("sudah") = True
                        Else
                            '18 April 2022
                            'Gak perlu filter lagi berdasarkan perusahaan, departemen, ataupun divisi dan bagian, cukup NIP saja
                            'Kalau tidak ditemukan NIP nya, maka langsung jadikan 
                            arrUpdateValues(0) = "P"

                            'SEBELUM 18 April 2022
                            ''Jika tidak ditemukan di bagian, maka cari yang divisi
                            ''DIVISI
                            'foundRows = myDataTableScheduleShift.Select("perusahaan='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("perusahaan")) & "' AND (departemen='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("departemen")) & "') AND (grup='DIVISI' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(arrGrup(1)) & "') And nip ='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("nip")) & "' and sudah='False'")
                            'If (foundRows.Length > 0) Then
                            '    'Jika ditemukan, maka ikut shift dari data schedule shift
                            '    arrUpdateValues(0) = myDataTableScheduleShift.Rows(myDataTableScheduleShift.Rows.IndexOf(foundRows(0))).Item("waktushift")
                            '    myDataTableScheduleShift.Rows(myDataTableScheduleShift.Rows.IndexOf(foundRows(0))).Item("sudah") = True
                            'Else
                            '    '24 Februari 2022, departemen dijadikan mandatory dan kolom sendiri, karena untuk memudahkan penggolongan skema presensinya
                            '    ''Jika tidak ditemukan di divisi, maka cari yang departemen
                            '    ''DEPARTEMEN
                            '    'foundRows = myDataTableScheduleShift.Select("perusahaan='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("perusahaan")) & "' AND (grup='DEPARTEMEN' and ketgrup='" & arrGrup(0) & "') And nip ='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("nip")) & "' and sudah='False'")
                            '    'If (foundRows.Length > 0) Then
                            '    '    'Jika ditemukan, maka ikut shift dari data schedule shift
                            '    '    arrUpdateValues(0) = myDataTableScheduleShift.Rows(myDataTableScheduleShift.Rows.IndexOf(foundRows(0))).Item("waktushift")
                            '    '    myDataTableScheduleShift.Rows(myDataTableScheduleShift.Rows.IndexOf(foundRows(0))).Item("sudah") = True
                            '    'Else
                            '    '    'Jika tidak ditemukan juga di departemen, maka langsung dianggap shift pagi
                            '    arrUpdateValues(0) = "P"
                            '    'End If
                            'End If
                        End If
                        updateString = "kodewaktushift='" & myCStringManipulation.SafeSqlLiteral(arrUpdateValues(0)) & "'"
                        '===============================================================================================

                        '===============================================================================================
                        '2. Ambil jadwal masuk dan jadwal pulang sesuai shift nya
                        If Not IsDBNull(myDataTablePresensi.Rows(i).Item("jammulai")) And Not IsDBNull(myDataTablePresensi.Rows(i).Item("jamselesai")) Then
                            'Kalau ada SPK nya, maka pakai data SPK, langsung menumpuk schedule shift yang reguler
                            arrUpdateValues(1) = myDataTablePresensi.Rows(i).Item("jammulai").ToString
                            arrUpdateValues(2) = myDataTablePresensi.Rows(i).Item("jamselesai").ToString
                        Else
                            'Kalau gak ada SPK nya, maka pakai dari skema presensi
                            'foundRows = myDataTableSkemaPresensi.Select("perusahaan='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("perusahaan")) & "' AND ((grup='DEPARTEMEN' and ketgrup='" & IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("departemen")), "", myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("departemen"))) & "') or (grup='DIVISI' and ketgrup='" & IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("divisi")), "", myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("divisi"))) & "') or (grup='BAGIAN' and ketgrup='" & IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("bagian")), "", myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("bagian"))) & "')) AND kodewaktushift='" & arrUpdateValues(0) & "'")
                            'Ambil skema presensi sesuai NIP dulu
                            foundRows = myDataTableSkemaPresensi.Select("spesifik='True' and nip='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("nip")) & "' and kodewaktushift='" & arrUpdateValues(0) & "'")
                            If (foundRows.Length > 0) Then
                                'Jika ada skema presensi yang spesifik untuk karyawan tersebut saja, maka pake data skema presensi yang spesifik ini
                                arrUpdateValues(1) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jammasuk").ToString
                                arrUpdateValues(2) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jamkeluar").ToString
                            Else
                                'ambil jabatan dulu di table msposisikaryawan
                                jabatan = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "posisi", CONN_.schemaHRD & ".msposisikaryawan",, "nip='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("nip")) & "' AND untukskemafp='True'", CONN_.dbType)
                                'If Not IsNothing(jabatan) Then
                                '    'Jika jabatannya ada
                                '    'Jika tidak ada skema presensi yang spesifik untuk karyawan tersebut, maka cek yang sesuai jabatan
                                '    foundRows = myDataTableSkemaPresensi.Select("kodewaktushift='" & arrUpdateValues(0) & "' and posisi=" & IIf(IsNothing(jabatan), "'-'", "'" & myCStringManipulation.SafeSqlLiteral(jabatan) & "'"))
                                'End If
                                'If (foundRows.Length > 0) Then
                                '    'Jika ada skema presensi yang spesifik untuk karyawan tersebut saja, maka pake data skema presensi yang spesifik ini
                                '    arrUpdateValues(1) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jammasuk").ToString
                                '    arrUpdateValues(2) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jamkeluar").ToString
                                'Else
                                'Jika tidak ada skema presensi yang sesuai jabatan, maka pakai data skema presensi yang untuk departemen, atau divisi, atau bagiannya
                                'BAGIAN
                                foundRows = myDataTableSkemaPresensi.Select("perusahaan='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("perusahaan")) & "' AND (departemen='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("departemen")) & "') AND (grup='BAGIAN' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(arrGrup(2)) & "') AND kodewaktushift='" & myCStringManipulation.SafeSqlLiteral(arrUpdateValues(0)) & "' AND posisi=" & IIf(IsNothing(jabatan), "'-'", "'" & myCStringManipulation.SafeSqlLiteral(jabatan) & "'"))
                                If (foundRows.Length > 0) Then
                                    arrUpdateValues(1) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jammasuk").ToString
                                    arrUpdateValues(2) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jamkeluar").ToString
                                Else
                                    'DIVISI
                                    foundRows = myDataTableSkemaPresensi.Select("perusahaan='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("perusahaan")) & "' AND (departemen='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("departemen")) & "') AND (grup='DIVISI' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(arrGrup(1)) & "') AND kodewaktushift='" & myCStringManipulation.SafeSqlLiteral(arrUpdateValues(0)) & "' AND posisi=" & IIf(IsNothing(jabatan), "'-'", "'" & myCStringManipulation.SafeSqlLiteral(jabatan) & "'"))
                                    If (foundRows.Length > 0) Then
                                        arrUpdateValues(1) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jammasuk").ToString
                                        arrUpdateValues(2) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jamkeluar").ToString
                                    Else
                                        'TANPA JABATAN
                                        'BAGIAN
                                        foundRows = myDataTableSkemaPresensi.Select("perusahaan='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("perusahaan")) & "' AND (departemen='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("departemen")) & "')  AND (grup='BAGIAN' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(arrGrup(2)) & "') AND kodewaktushift='" & arrUpdateValues(0) & "'")
                                        If (foundRows.Length > 0) Then
                                            arrUpdateValues(1) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jammasuk").ToString
                                            arrUpdateValues(2) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jamkeluar").ToString
                                        Else
                                            'DIVISI
                                            foundRows = myDataTableSkemaPresensi.Select("perusahaan='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("perusahaan")) & "' AND (departemen='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("departemen")) & "')  AND (grup='DIVISI' and ketgrup='" & myCStringManipulation.SafeSqlLiteral(arrGrup(1)) & "') AND kodewaktushift='" & arrUpdateValues(0) & "'")
                                            If (foundRows.Length > 0) Then
                                                arrUpdateValues(1) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jammasuk").ToString
                                                arrUpdateValues(2) = myDataTableSkemaPresensi.Rows(myDataTableSkemaPresensi.Rows.IndexOf(foundRows(0))).Item("jamkeluar").ToString
                                            Else
                                                If (myDataTablePresensi.Rows(i).Item("lokasi") = "SIDOARJO") And (myDataTablePresensi.Rows(i).Item("kelompok") <> "OUTSOURCE") Then
                                                    arrUpdateValues(1) = "07:00:00"
                                                    arrUpdateValues(2) = "15:00:00"
                                                Else
                                                    'yang selain kriteria di atas, SIDOARJO dan bukan OUTSOURCE, JADWAL MASUK DAN JADWAL KELUARNYA BERVARIASI
                                                    arrUpdateValues(1) = Nothing
                                                    arrUpdateValues(2) = Nothing
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                                'End If
                            End If
                        End If
                        updateString &= ",jadwalmasuk=" & IIf(IsNothing(arrUpdateValues(1)), "Null", "'" & arrUpdateValues(1) & "'") & ",jadwalkeluar=" & IIf(IsNothing(arrUpdateValues(2)), "Null", "'" & arrUpdateValues(2) & "'")
                        '===============================================================================================

                        '===============================================================================================
                        '3. Ambil FP masuk dan FP Keluar
                        If IsDBNull(myDataTablePresensi.Rows(i).Item("absen")) Then
                            'Hanya proses yang tidak ada ijin absennya saja
                            If (shiftPerDay = 1) Then
                                foundRows = myDataTableTmpFP.Select("fpid=" & IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("fpid")), -1, myDataTablePresensi.Rows(i).Item("fpid")))
                            Else
                                foundRows = myDataTableTmpFP.Select("fpid=" & IIf(IsDBNull(myDataTablePresensi.Rows(i).Item("fpid")), -1, myDataTablePresensi.Rows(i).Item("fpid")) & " AND kodewaktushift='" & myCStringManipulation.SafeSqlLiteral(arrUpdateValues(0)) & "'")
                            End If
                            If (foundRows.Length > 0) Then
                                'MsgBox("FP masuk: " & myDataTableTmpFP.Rows(myDataTableTmpFP.Rows.IndexOf(foundRows(0))).Item("jammasuk").ToString)
                                arrUpdateValues(3) = IIf(IsDBNull(myDataTableTmpFP.Rows(myDataTableTmpFP.Rows.IndexOf(foundRows(0))).Item("jammasuk")), Nothing, myDataTableTmpFP.Rows(myDataTableTmpFP.Rows.IndexOf(foundRows(0))).Item("jammasuk").ToString)
                                arrUpdateValues(4) = IIf(IsDBNull(myDataTableTmpFP.Rows(myDataTableTmpFP.Rows.IndexOf(foundRows(0))).Item("jamkeluar")), Nothing, myDataTableTmpFP.Rows(myDataTableTmpFP.Rows.IndexOf(foundRows(0))).Item("jamkeluar").ToString)
                            Else
                                arrUpdateValues(3) = Nothing
                                arrUpdateValues(4) = Nothing
                            End If
                            updateString &= ",fpmasuk=" & IIf(IsNothing(arrUpdateValues(3)), "Null", "'" & arrUpdateValues(3) & "'") & ",fpkeluar=" & IIf(IsNothing(arrUpdateValues(4)), "Null", "'" & arrUpdateValues(4) & "'")
                            '===============================================================================================

                            '===============================================================================================
                            '4. Proses jam masuk dan jam keluar, serta terlambat dan pulang cepat
                            If Not IsNothing(arrUpdateValues(1)) And Not IsNothing(arrUpdateValues(2)) Then
                                'Jadwal masuk ada
                                If Not IsNothing(arrUpdateValues(3)) And Not IsNothing(arrUpdateValues(4)) Then
                                    'FP Masuk dan FP keluar ada
                                    'Cek dulu apakah keduanya tidak ada yang kosong
                                    'Cek dulu apakah fp masuk dan fp keluarnya sama, kalau keduanya dilakukan di jam yang berdekatan atau sama, maka salah 1 harus di eliminasi
                                    strSelisihJam = CDate(arrUpdateValues(4)) - CDate(arrUpdateValues(3))
                                    If (strSelisihJam.Duration <= TimeSpan.Parse("00:15:00")) Then
                                        'Cek jika selisih di bawah 15 menit, maka dianggap masih di jam yang sama
                                        'Setelah itu harus cek, apakah jam yang ada ini lebih dekat ke jam jadwal masuk atau jam jadwal keluar
                                        'Kalau acuan jadwal jam masuk dan jadwal jam keluarnya ada
                                        strSelisihJamMasuk = CDate(arrUpdateValues(3)) - CDate(arrUpdateValues(1))
                                        strSelisihJamKeluar = CDate(arrUpdateValues(3)) - CDate(arrUpdateValues(2))
                                        If (strSelisihJamMasuk.Duration <= strSelisihJamKeluar.Duration) Then
                                            'Kalau fp masuk lebih dekat ke jadwal masuk, maka fp masuk dianggap jam masuk
                                            'PERLU DICATAT BAHWA SELISIH FP MASUK DAN FP KELUAR HANYA KURANG DARI 15 MENIT
                                            'Jadi untuk jam masuk, diambil FP masuk, karena yang lebih awal
                                            arrUpdateValues(5) = arrUpdateValues(3)
                                            arrUpdateValues(6) = Nothing
                                            'Kalau selisih jam masuknya positif (lebih dari 59 detik), berarti fp masuknya lebih besar dari jadwal jam masuknya, berarti terlambat
                                            arrUpdateValues(7) = IIf(strSelisihJamMasuk > TimeSpan.Parse("00:00:00"), strSelisihJamMasuk.Duration.ToString, Nothing)
                                            arrUpdateValues(8) = Nothing
                                        Else
                                            'Kalau fp masuk lebih dekat ke jadwal pulang, maka fp pulang dianggap jam pulang
                                            'PERLU DICATAT BAHWA SELISIH FP MASUK DAN FP KELUAR HANYA KURANG DARI 15 MENIT
                                            'Sedangkan untuk jam keluar, diambil FP pulang, karena yang lebih akhir
                                            arrUpdateValues(5) = Nothing
                                            arrUpdateValues(6) = arrUpdateValues(4)
                                            arrUpdateValues(7) = Nothing
                                            'Kalau selisih jam keluarnya negatif (kurang dari 59 detik), berarti fp keluarnya lebih kecil dari jadwal jam keluarnya, berarti pulang lebih cepat
                                            arrUpdateValues(8) = IIf(strSelisihJamKeluar < TimeSpan.Parse("00:00:00"), strSelisihJamKeluar.Duration.ToString, Nothing)
                                        End If
                                    Else
                                        'Kalau selisihnya di atas 15 menit, maka dianggap sendiri2
                                        'Ini nanti bisa disesuaikan, sesuai kebijakkan
                                        strSelisihJamMasuk = CDate(arrUpdateValues(3)) - CDate(arrUpdateValues(1))
                                        strSelisihJamKeluar = CDate(arrUpdateValues(4)) - CDate(arrUpdateValues(2))

                                        arrUpdateValues(5) = arrUpdateValues(3)
                                        arrUpdateValues(6) = arrUpdateValues(4)
                                        'Kalau selisih jam masuknya positif, berarti fp masuknya lebih besar dari jadwal jam masuknya, berarti terlambat
                                        arrUpdateValues(7) = IIf(strSelisihJamMasuk > TimeSpan.Parse("00:00:00"), strSelisihJamMasuk.Duration.ToString, Nothing)
                                        'Kalau selisih jam keluarnya negatif, berarti fp keluarnya lebih kecil dari jadwal jam keluarnya, berarti pulang lebih cepat
                                        arrUpdateValues(8) = IIf(strSelisihJamKeluar < TimeSpan.Parse("00:00:00"), strSelisihJamKeluar.Duration.ToString, Nothing)
                                    End If
                                Else
                                    'Kalau salah 1 ada yang kosong, atau keduanya kosong maka harus di cek
                                    If IsNothing(arrUpdateValues(3)) Or IsNothing(arrUpdateValues(4)) Then
                                        'Kalau salah 1 kosong
                                        If Not IsNothing(arrUpdateValues(3)) Then
                                            'Kalau yang ada isi yang fp masuknya
                                            strSelisihJamMasuk = CDate(arrUpdateValues(3)) - CDate(arrUpdateValues(1))
                                            strSelisihJamKeluar = CDate(arrUpdateValues(3)) - CDate(arrUpdateValues(2))
                                            If (strSelisihJamMasuk.Duration <= strSelisihJamKeluar.Duration) Then
                                                'Kalau fp masuk lebih dekat ke jadwal masuk, maka fp masuk dianggap jam masuk
                                                'PERLU DICATAT BAHWA SELISIH FP MASUK DAN FP KELUAR HANYA KURANG DARI 15 MENIT
                                                arrUpdateValues(5) = arrUpdateValues(3)
                                                arrUpdateValues(6) = Nothing
                                                'Kalau selisih jam masuknya positif, berarti fp masuknya lebih besar dari jadwal jam masuknya, berarti terlambat
                                                arrUpdateValues(7) = IIf(strSelisihJamMasuk > TimeSpan.Parse("00:00:00"), strSelisihJamMasuk.Duration.ToString, Nothing)
                                                arrUpdateValues(8) = Nothing
                                            Else
                                                'Kalau fp masuk lebih dekat ke jadwal pulang, maka fp masuk dianggap jam pulang
                                                'PERLU DICATAT BAHWA SELISIH FP MASUK DAN FP KELUAR HANYA KURANG DARI 15 MENIT
                                                'Perhatikan di sini pakai arrUpdateValues(3) karena yang ada isi hanya yang FP masuknya saja
                                                arrUpdateValues(5) = Nothing
                                                arrUpdateValues(6) = arrUpdateValues(3)
                                                arrUpdateValues(7) = Nothing
                                                'Kalau selisih jam keluarnya negatif, berarti fp keluarnya lebih kecil dari jadwal jam keluarnya, berarti pulang lebih cepat
                                                arrUpdateValues(8) = IIf(strSelisihJamKeluar < TimeSpan.Parse("00:00:00"), strSelisihJamKeluar.Duration.ToString, Nothing)
                                            End If
                                        ElseIf Not IsNothing(arrUpdateValues(4)) Then
                                            'Kalau yang ada isi yang fp keluarnya
                                            strSelisihJamMasuk = CDate(arrUpdateValues(4)) - CDate(arrUpdateValues(1))
                                            strSelisihJamKeluar = CDate(arrUpdateValues(4)) - CDate(arrUpdateValues(2))
                                            If (strSelisihJamMasuk.Duration <= strSelisihJamKeluar.Duration) Then
                                                'Kalau fp masuk lebih dekat ke jadwal masuk, maka fp masuk dianggap jam masuk
                                                'PERLU DICATAT BAHWA SELISIH FP MASUK DAN FP KELUAR HANYA KURANG DARI 15 MENIT
                                                arrUpdateValues(5) = arrUpdateValues(4)
                                                arrUpdateValues(6) = Nothing
                                                'Kalau selisih jam masuknya positif, berarti fp masuknya lebih besar dari jadwal jam masuknya, berarti terlambat
                                                arrUpdateValues(7) = IIf(strSelisihJamMasuk > TimeSpan.Parse("00:00:00"), strSelisihJamMasuk.Duration.ToString, Nothing)
                                                arrUpdateValues(8) = Nothing
                                            Else
                                                'Kalau fp masuk lebih dekat ke jadwal pulang, maka fp masuk dianggap jam pulang
                                                'PERLU DICATAT BAHWA SELISIH FP MASUK DAN FP KELUAR HANYA KURANG DARI 15 MENIT
                                                'Perhatikan di sini pakai arrUpdateValues(4) karena yang ada isi hanya yang FP keluarnya saja
                                                arrUpdateValues(5) = Nothing
                                                arrUpdateValues(6) = arrUpdateValues(4)
                                                arrUpdateValues(7) = Nothing
                                                'Kalau selisih jam keluarnya negatif, berarti fp keluarnya lebih kecil dari jadwal jam keluarnya, berarti pulang lebih cepat
                                                arrUpdateValues(8) = IIf(strSelisihJamKeluar < TimeSpan.Parse("00:00:00"), strSelisihJamKeluar.Duration.ToString, Nothing)
                                            End If
                                        End If
                                    Else
                                        'Kalau keduanya kosong
                                        'Otomatis jam masuk, jam pulang, terlambat dan pulang cepat kosong semua.
                                        arrUpdateValues(5) = Nothing
                                        arrUpdateValues(6) = Nothing
                                        arrUpdateValues(7) = Nothing
                                        arrUpdateValues(8) = Nothing
                                    End If
                                End If
                            Else
                                'Kalau jadwal jam masuk dan jadwal jam keluarnya yang jadi acuan gak ada
                                'Maka langsung dimasukkan apa adanya sesuai dengan FP nya
                                'waktu terlambat dan pulang cepat juga tidak bisa ditentukan
                                If Not IsNothing(arrUpdateValues(3)) And Not IsNothing(arrUpdateValues(4)) Then
                                    'FP Masuk dan FP keluar ada
                                    'Cek dulu apakah fp masuk dan fp keluarnya sama, kalau keduanya dilakukan di jam yang berdekatan atau sama, maka salah 1 harus di eliminasi
                                    strSelisihJam = CDate(arrUpdateValues(4)) - CDate(arrUpdateValues(3))
                                    If (strSelisihJam.Duration <= TimeSpan.Parse("00:15:00")) Then
                                        'Jika selisihnya tidak sampai 15 menit, maka dihilangkan salah 1
                                        'Kalau tidak ada jadwal masuk, maka tidak bisa tau ini jam pulang atau jam masuk, jadi dianggap jam masuk saja
                                        arrUpdateValues(5) = IIf(IsNothing(arrUpdateValues(3)), Nothing, arrUpdateValues(3))
                                        arrUpdateValues(6) = Nothing
                                    Else
                                        'kalau selisihnya lebih dari 15 menit, maka langsung dimasukkan sesuai FP nya
                                        arrUpdateValues(5) = IIf(IsNothing(arrUpdateValues(3)), Nothing, arrUpdateValues(3))
                                        arrUpdateValues(6) = IIf(IsNothing(arrUpdateValues(4)), Nothing, arrUpdateValues(4))
                                    End If
                                Else
                                    'Begitu juga jika salah 1 ada yang kosong, maka langsung dimasukkan sesuai FP nya
                                    arrUpdateValues(5) = IIf(IsNothing(arrUpdateValues(3)), Nothing, arrUpdateValues(3))
                                    arrUpdateValues(6) = IIf(IsNothing(arrUpdateValues(4)), Nothing, arrUpdateValues(4))
                                End If
                                arrUpdateValues(7) = Nothing
                                arrUpdateValues(8) = Nothing
                            End If
                            updateString &= ",masuk=" & IIf(IsNothing(arrUpdateValues(5)), "Null", "'" & arrUpdateValues(5) & "'") & ",keluar=" & IIf(IsNothing(arrUpdateValues(6)), "Null", "'" & arrUpdateValues(6) & "'") & ",terlambat=" & IIf(IsNothing(arrUpdateValues(7)), "Null", "'" & arrUpdateValues(7) & "'") & ",pulangcepat=" & IIf(IsNothing(arrUpdateValues(8)), "Null", "'" & arrUpdateValues(8) & "'")
                            '===============================================================================================

                            '===============================================================================================
                            If Not (IsNothing(arrUpdateValues(6))) Then
                                'Kalau jam pulangnya gak kosong
                                '===============================================================================================
                                '5. Untuk menghitung jam kerja dan banyak jam kerja
                                If Not (IsNothing(arrUpdateValues(5))) Then
                                    ''Jam masuk dan jam keluarnya harus sama2 ada isinya, tidak boleh salah 1 kosong!!
                                    ''Untuk hitung jam kerja dan banyaknya jam kerjanya
                                    Dim levelJabatan As Byte
                                    levelJabatan = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "level", CONN_.schemaHRD & ".msposisikaryawan",, "nip='" & myCStringManipulation.SafeSqlLiteral(myDataTablePresensi.Rows(i).Item("nip")) & "'", CONN_.dbType)
                                    If (arrGrup(0) = "SECURITY" Or arrGrup(1) = "SECURITY" Or arrGrup(2) = "SECURITY") Then
                                        arrUpdateValues(10) = GetJamKerja(arrUpdateValues(5), arrUpdateValues(6), myDataTablePresensi.Rows(i).Item("lokasi"), myDataTablePresensi.Rows(i).Item("perusahaan"), WeekdayName(Weekday(myDataTablePresensi.Rows(i).Item("tanggal"))), True)
                                    Else
                                        arrUpdateValues(10) = GetJamKerja(arrUpdateValues(5), arrUpdateValues(6), myDataTablePresensi.Rows(i).Item("lokasi"), myDataTablePresensi.Rows(i).Item("perusahaan"), WeekdayName(Weekday(myDataTablePresensi.Rows(i).Item("tanggal"))))
                                    End If
                                    arrUpdateValues(11) = GetBanyakJamKerja(arrUpdateValues(10))
                                    updateString &= ",jamkerja=" & IIf(IsNothing(arrUpdateValues(10)), "Null", "'" & arrUpdateValues(10) & "'") & ",banyakjamkerja=" & IIf(arrUpdateValues(11) = 0, "Null", arrUpdateValues(11))
                                    '===============================================================================================

                                    '===============================================================================================
                                    '6. Untuk menghitung jam kerja nyata dan banyak jam kerja nyata, ((jadwal jam masuk - jadwal jam keluar) - 30 menit untuk pandaan atau - 60 menit untuk sidoarjo atau maks 8 jam)
                                    If (arrGrup(0) = "SECURITY" Or arrGrup(1) = "SECURITY" Or arrGrup(2) = "SECURITY") Then
                                        arrUpdateValues(14) = GetJamKerjaNyata(arrUpdateValues(1), arrUpdateValues(2), arrUpdateValues(5), arrUpdateValues(6), arrUpdateValues(10), myDataTablePresensi.Rows(i).Item("lokasi"), myDataTablePresensi.Rows(i).Item("tanggal"), myDataTablePresensi.Rows(i).Item("perusahaan"), myDataTablePresensi.Rows(i).Item("kelompok"), myDataTablePresensi.Rows(i).Item("katpenggajian"), True, arrUpdateValues(7), arrUpdateValues(8), levelJabatan, myDataTablePresensi.Rows(i).Item("bagian"))
                                    Else
                                        arrUpdateValues(14) = GetJamKerjaNyata(arrUpdateValues(1), arrUpdateValues(2), arrUpdateValues(5), arrUpdateValues(6), arrUpdateValues(10), myDataTablePresensi.Rows(i).Item("lokasi"), myDataTablePresensi.Rows(i).Item("tanggal"), myDataTablePresensi.Rows(i).Item("perusahaan"), myDataTablePresensi.Rows(i).Item("kelompok"), myDataTablePresensi.Rows(i).Item("katpenggajian"), False, arrUpdateValues(7), arrUpdateValues(8), levelJabatan, myDataTablePresensi.Rows(i).Item("bagian"))
                                    End If

                                    If Not IsNothing(arrUpdateValues(14)) Then
                                        If (TimeSpan.Parse(arrUpdateValues(14)) < TimeSpan.Parse("00:00:00")) Then
                                            arrUpdateValues(14) = Nothing
                                            arrUpdateValues(15) = Nothing
                                        Else
                                            arrUpdateValues(15) = GetBanyakJamKerja(arrUpdateValues(14), False)
                                        End If
                                    Else
                                        arrUpdateValues(15) = Nothing
                                    End If
                                    updateString &= ",jamkerjanyata=" & IIf(IsNothing(arrUpdateValues(14)), "Null", "'" & arrUpdateValues(14) & "'") & ",banyakjamkerjanyata=" & IIf(arrUpdateValues(15) = 0, "Null", arrUpdateValues(15))
                                    '===============================================================================================
                                End If

                                '===============================================================================================
                                '7. Untuk menentukan dia masuk shift berapa
                                'Shift 1	Pulang di bawah jam 11 malam
                                'Shift 2	Pulang tepat jam 11 malam
                                'Shift 3	Pulang di atas jam 11 malam
                                'Hanya kalau jam pulangnya gak kosong saja yang akan masuk ke perhitungan karyawan tersebut shift apa tidak
                                arrUpdateValues(9) = GetShift(arrUpdateValues(5), arrUpdateValues(6), arrUpdateValues(15), arrUpdateValues(1), arrUpdateValues(2))
                                updateString &= ",shift=" & IIf(IsNothing(arrUpdateValues(9)), "1", arrUpdateValues(9))
                                '===============================================================================================
                            End If
                        End If
                        '===============================================================================================
                        If Not IsNothing(updateString) Then
                            countUpdate += 1
                            updateString &= ",userpc='" & myCManagementSystem.GetComputerName & "'," & ADD_INFO_.updateString
                            'Call myCDBOperation.EditUpdatedAt(CONN_.dbMain, CONN_.comm, CONN_.reader, updateString, tableName, CONN_.dbType)
                            queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableName(0), updateString,, "rid=" & myDataTablePresensi.Rows(i).Item("rid")))
                            'Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), updateString, "rid=" & myDataTablePresensi.Rows(i).Item("rid"))
                        End If

                        pbLoading.Value = i + 1
                        lblCount.Text = i + 1
                        If (i Mod 100 = 0) Then
                            GC.Collect()
                        End If
                    Next

                    If (countUpdate > 0) Then
                        If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                            queryBuilder.Clear()
                            queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableName(0), "isnew='False'",, "tanggal='" & Format(tanggalBerjalan, "dd-MMM-yyyy") & "' AND lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "'"))
                            'Untuk update kolom absen jadi L, untuk yang kodewaktushift nya X alias libur
                            queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableName(0), "ijin='TM',absen='L',updated_at=clock_timestamp()",, "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and (tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and kodewaktushift='X'"))
                            'Kalau tidak ada lembur dan tidak ada SPK, tapi ada checkclock nya, makan akan dikosongkan!
                            queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableName(0), "masuk=Null,keluar=Null,terlambat=Null,pulangcepat=Null,updated_at=clock_timestamp()",, "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and (tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and ijin='TM' and absen is not null AND jamlembur is null AND spkmulai is null AND spkselesai is null"))
                            'queryBuilder.Append("update " & tableName(0) & " as a set masuk=Null,keluar=Null,terlambat=Null,pulangcepat=Null,updated_at=clock_timestamp() WHERE a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and (a.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and a.ijin='TM' and a.absen is not null AND a.jamlembur is null AND a.spkmulai is null AND a.spkselesai is null;")
                            'queryBuilder.Append("update " & tableName(0) & " as a set ijin='TM',absen='L',updated_at=clock_timestamp() WHERE a.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and (a.tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and a.tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and a.kodewaktushift='X';")
                            If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                                'Tidak perlu melakukan apa2 kalau berhasil
                                'Call myCShowMessage.ShowInfo("Proses presensi tanggal " & tanggalBerjalan & " berhasil!")
                            Else
                                Call myCShowMessage.ShowWarning("Update kolom isnew dan juga masuk keluar null untuk yang ijin tidak masuk di tanggal " & tanggalBerjalan & " gagal!")
                            End If
                            'Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "isnew='False'", "tanggal='" & Format(tanggalBerjalan, "dd-MMM-yyyy") & "' AND lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "'")
                        Else
                            Call myCShowMessage.ShowWarning("Proses presensi tanggal " & tanggalBerjalan & " gagal!")
                        End If
                    End If

                    tanggalBerjalan = tanggalBerjalan.AddDays(1)
                    hitungTanggal += 1
                    If (hitungTanggal Mod 10 = 0) Then
                        GC.Collect()
                    End If
                End While

                'Untuk null kan jadwal masuk untuk hari yang libur
                Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "jadwalmasuk=Null,jadwalkeluar=Null", "lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "' and (tanggal>='" & Format(dtpPeriodeAwal.Value.Date, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpPeriodeAkhir.Value.Date, "dd-MMM-yyyy") & "') and ijin='TM' and (absen='L' or absen='C')")

                Call myCShowMessage.ShowInfo("DONE!!!" & ControlChars.NewLine & "Proses Data Absen " & cboLokasi.SelectedValue & " dari tanggal " & dtpPeriodeAwal.Value.Date & " - " & dtpPeriodeAkhir.Value.Date & " Selesai" & ControlChars.NewLine & "Sebanyak " & countUpdate & " data karyawan")
                pnlLoading.Visible = False
                lblTanggalProses.Visible = False
            Else
                Call myCShowMessage.ShowWarning("Pilih lokasinya terlebih dahulu!!")
                cboLokasi.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesFP_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function GetShift(_jamMasuk As String, _jamKeluar As String, _banyakJamKerja As Double, Optional _jadwalMasuk As String = Nothing, Optional _jadwalKeluar As String = Nothing) As Byte
        Try
            '========================= UNTUK SET SHIFT NYA, SHIFT 1 < 23:00, SHIFT 2 = 23:00, SHIFT 3 > 23:00
            If Not IsNothing(_jadwalMasuk) And Not IsNothing(_jadwalKeluar) And _jadwalMasuk <> "" And _jadwalKeluar <> "" Then
                'Jika jadwal masuk dan jadwal pulangnya ada
                If (TimeSpan.Parse(_jadwalKeluar) < TimeSpan.Parse(_jadwalMasuk)) Then
                    'Kalau jam pulangnya lebih kecil dari jam masuknya, maka bisa dipastikan shift 3
                    'Contoh: masuk 23:00 dan pulang 07:00
                    If (_banyakJamKerja >= 4) Then
                        'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                        GetShift = 3
                    Else
                        GetShift = 1
                    End If
                Else
                    If (TimeSpan.Parse(_jadwalKeluar) < TimeSpan.Parse("23:00")) Then
                        'Kalau kurang dari jam 23, maka shift 1
                        GetShift = 1
                    ElseIf (TimeSpan.Parse(_jadwalKeluar) = TimeSpan.Parse("23:00")) Then
                        'Kalau sama dengan jam 23, maka shift 2
                        If (_banyakJamKerja >= 4) Then
                            'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                            GetShift = 2
                        Else
                            GetShift = 1
                        End If
                    ElseIf (TimeSpan.Parse(_jadwalKeluar) > TimeSpan.Parse("23:00")) Then
                        'Kalau lebih dari 23 maka shift 3
                        If (_banyakJamKerja >= 4) Then
                            'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                            GetShift = 3
                        Else
                            GetShift = 1
                        End If
                    Else
                        GetShift = 1
                    End If
                End If
            Else
                'Jika jadwal masuk dan jadwal pulangnya tidak ada, hanya bisa ditentukan jika jam pulangnya menyentuh jam 11 malam
                If Not IsNothing(_jamKeluar) And Not (_jamKeluar = "") Then
                    'Kalau jam keluarnya ada
                    If Not IsNothing(_jamMasuk) And Not (_jamMasuk = "") Then
                        'Kalau jam masuk dan jam keluarnya ada isinya
                        If (TimeSpan.Parse(_jamKeluar) < TimeSpan.Parse(_jamMasuk)) Then
                            'Kalau jam pulangnya lebih kecil dari jam masuknya, maka bisa dipastikan shift 3
                            'Contoh: masuk 23:00 dan pulang 07:00
                            If (_banyakJamKerja >= 4) Then
                                'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                                GetShift = 3
                            Else
                                GetShift = 1
                            End If
                        Else
                            If (TimeSpan.Parse(_jamKeluar) < TimeSpan.Parse("23:00")) Then
                                'Kalau kurang dari jam 23, maka shift 1
                                GetShift = 1
                            ElseIf (TimeSpan.Parse(_jamKeluar) = TimeSpan.Parse("23:00")) Then
                                'Kalau sama dengan jam 23, maka shift 2
                                If (_banyakJamKerja >= 4) Then
                                    'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                                    GetShift = 2
                                Else
                                    GetShift = 1
                                End If
                            ElseIf (TimeSpan.Parse(_jamKeluar) > TimeSpan.Parse("23:00")) Then
                                'Kalau lebih dari 23 maka shift 3
                                If (_banyakJamKerja >= 4) Then
                                    'Hanya kalau banyak jam kerjanya minimal sudah 4 jam / sudah masuk setengah hari
                                    GetShift = 3
                                Else
                                    GetShift = 1
                                End If
                            Else
                                GetShift = 1
                            End If
                        End If
                    Else
                        'Kalau jam masuknya kosong
                        If (TimeSpan.Parse(_jamKeluar) <= TimeSpan.Parse("07:30")) Then
                            'Kalau jam pulangnya kurang dari sama dengan jam 7:30 pagi, maka dianggap shift 3
                            GetShift = 3
                        Else
                            If (TimeSpan.Parse(_jamKeluar) < TimeSpan.Parse("23:00")) Then
                                'Kalau kurang dari jam 23, maka shift 1
                                GetShift = 1
                            ElseIf (TimeSpan.Parse(_jamKeluar) = TimeSpan.Parse("23:00")) Then
                                'Kalau sama dengan jam 23, maka shift 2
                                'Memang tak kasih spare jarak jam setengah jam, karena bisa jadi fingernya gak persis jam 11
                                GetShift = 2
                            ElseIf (TimeSpan.Parse(_jamKeluar) > TimeSpan.Parse("23:00")) Then
                                'Kalau lebih dari 23 maka shift 3
                                GetShift = 3
                            Else
                                GetShift = 1
                            End If
                        End If
                    End If
                Else
                    'Kalau jam keluarnya kosong
                    If Not IsNothing(_jamMasuk) And Not (_jamMasuk = "") Then
                        'Kalau jam masuknya ada isinya, tidak bisa melakukan apa2, karena patokannya di jam keluarnya
                        GetShift = 1
                    Else
                        GetShift = 1
                    End If
                End If
            End If
            '==================================
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetShift Error")
            GetShift = 1
        End Try
    End Function

    Private Function GetJamKerja(_jamMasuk As String, _jamKeluar As String, _lokasi As String, _perusahaan As String, _hari As String, Optional _isSecurity As Boolean = False) As String
        Try
            If Not IsNothing(_jamMasuk) And (_jamMasuk <> "") And Not IsNothing(_jamKeluar) And (_jamKeluar <> "") Then
                'Jam masuk dan jam keluarnya harus sama2 ada isinya, tidak boleh salah 1 kosong!!
                'Untuk hitung jam kerja dan banyaknya jam kerjanya
                Dim jamIstirahat As String
                jamIstirahat = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "jamistirahat", tableName(14),, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' AND perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' AND issecurity='" & _isSecurity & "' AND hari='" & _hari & "'")


                If (TimeSpan.Parse(_jamKeluar) >= TimeSpan.Parse(_jamMasuk)) Then
                    'kalau jam pulangnya masih lebih besar dari jam masuknya
                    'jam kerja  = jam pulang - jam masuk
                    If ((TimeSpan.Parse(_jamKeluar).Subtract(TimeSpan.Parse(_jamMasuk)) - TimeSpan.Parse(jamIstirahat)) > TimeSpan.Parse("00:00:00")) Then
                        GetJamKerja = (TimeSpan.Parse(_jamKeluar).Subtract(TimeSpan.Parse(_jamMasuk)) - TimeSpan.Parse(jamIstirahat)).ToString
                    Else
                        GetJamKerja = Nothing
                    End If
                Else
                    'kalau jam pulangnya lebih kecil dari jam masuknya, berarti pulangnya di hari besoknya, maka untuk mendapatkan banyak jam kerjanya rumusnya beda
                    'jam kerja = (jam pulang - 00:00) + (23:59 - jam masuk)
                    'Harus ditambah 1 menit, karena jam 24:00 tidak bisa dimasukkan ke perhitungan
                    If ((((TimeSpan.Parse(_jamKeluar) - TimeSpan.Parse("00:00")) + (TimeSpan.Parse("23:59") - TimeSpan.Parse(_jamMasuk)) + (TimeSpan.Parse("00:01"))) - TimeSpan.Parse(jamIstirahat)) > TimeSpan.Parse("00:00:00")) Then
                        GetJamKerja = (((TimeSpan.Parse(_jamKeluar) - TimeSpan.Parse("00:00")) + (TimeSpan.Parse("23:59") - TimeSpan.Parse(_jamMasuk)) + (TimeSpan.Parse("00:01"))) - TimeSpan.Parse(jamIstirahat)).ToString
                    Else
                        GetJamKerja = Nothing
                    End If
                End If
            Else
                GetJamKerja = Nothing
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetJamKerja Error")
            GetJamKerja = 0
        End Try
    End Function

    Private Function GetJamKerjaNyata(_jadwalMasuk As String, _jadwalPulang As String, _masuk As String, _pulang As String, _jamKerja As String, _lokasi As String, _tanggal As Date, _perusahaan As String, _kelompok As String, _katpenggajian As String, _isSecurity As Boolean, _terlambat As String, _pulangCepat As String, _levelJabatan As Byte, _bagian As String) As String
        Try
            Dim batasToleransi As TimeSpan
            Dim hitungJamKerjaNyata As TimeSpan
            Dim alreadyProcessed As Boolean = False
            If (Not IsNothing(_jadwalMasuk) And Not IsNothing(_jadwalPulang)) And ((_jadwalMasuk <> "") And (_jadwalPulang <> "")) Then
                'Kalau jadwal masuk dan jadwal pulangnya ada
                'Dihitung dari jadwal jam pulang dikurangkan dengan jadwal jam masuknya, khusus untuk security, tanpa dikurangi jam istirahat
                'Lembur tidak perlu ditambahkan di sini, karena perhitungan gajinya beda
                'GetJamKerjaNyata = (TimeSpan.Parse(GetJamKerja(_jadwalMasuk, _jadwalPulang, _lokasi, WeekdayName(Weekday(_tanggal)), _isSecurity)) - TimeSpan.Parse(IIf(IsNothing(_terlambat), "00:00:00", _terlambat)) - TimeSpan.Parse(IIf(IsNothing(_pulangCepat), "00:00:00", _pulangCepat))).ToString
                GetJamKerjaNyata = GetJamKerja(_jadwalMasuk, _jadwalPulang, _lokasi, _perusahaan, WeekdayName(Weekday(_tanggal)), _isSecurity)
            Else
                'Kalau jadwal masuk dan jadwal pulangnya tidak ada, maka langsung dianggap 8 jam kerja
                GetJamKerjaNyata = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "jamkerja", CONN_.schemaHRD & ".msdefaultjamkerja",, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' AND perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' AND issecurity='" & _isSecurity & "' AND hari='" & WeekdayName(Weekday(_tanggal)) & "' AND bagian='" & myCStringManipulation.SafeSqlLiteral(_bagian) & "'")

                If Not IsNothing(_jamKerja) And _jamKerja <> "" Then
                    'Jika tidak ada jadwal, dan jam kerja sebelumnya lebih kecil dari jam kerja sesungguhnya (8 dan 12 jam), maka jam kerja nyata disesuaikan dengan jam kerja yang sebelumnya
                    If (TimeSpan.Parse(_jamKerja) < TimeSpan.Parse(GetJamKerjaNyata)) Then
                        'Diambil jam nya saja, dibulatkan ke bawah
                        If (Trim(_lokasi) = "SIDOARJO") Then
                            GetJamKerjaNyata = TimeSpan.Parse(_jamKerja).Hours & ":00:00".ToString
                        ElseIf (Trim(_lokasi) = "PANDAAN") Then
                            'Kalau Pandaan, diambil persis sesuai jam kerjanya
                            GetJamKerjaNyata = _jamKerja
                        End If
                    End If
                Else
                    'Jika tidak ada semuanya, maka jam kerjanya berarti memang kosong
                    GetJamKerjaNyata = Nothing
                End If
            End If

            If Not IsNothing(GetJamKerjaNyata) Then
                'Sekarang cek pengurangnya, jam terlambat atau pulang cepat
                If (_kelompok = "STAFF") Then
                    'Untuk STAFF
                    If (IsNothing(_terlambat) And IsNothing(_pulangCepat)) And (_terlambat = "" And _pulangCepat = "") Then
                        'Jika tidak terlambat dan pulang cepat, maka jam kerjanya full
                    Else
                        'Jika ada jam terlambatnya atau pulang cepat, maka dilakukan pengecekkan sesuai data yang ada di tabel mstoleransimenit
                        If Not IsNothing(_terlambat) And (_terlambat <> "") Then
                            'DATANG TERLAMBAT
                            batasToleransi = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "batastoleransi", tableName(12),, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(_kelompok) & "' and katpenggajian='" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "' and leveljabatan=" & _levelJabatan & " and ijin='DT'")
                            If Not IsNothing(batasToleransi) Then
                                'Jika jam terlambatnya kurang dari batas toleransinya
                                If (TimeSpan.Parse(_terlambat) <= TimeSpan.Parse(GetJamKerjaNyata)) Then
                                    Dim lebihanJamPulang As TimeSpan
                                    If Not IsNothing(_pulang) Then
                                        If (TimeSpan.Parse(_pulang) > TimeSpan.Parse(_jadwalPulang)) Then
                                            lebihanJamPulang = (TimeSpan.Parse(_pulang) - TimeSpan.Parse(_jadwalPulang))
                                            If (lebihanJamPulang > batasToleransi) Then
                                                lebihanJamPulang = batasToleransi
                                            End If
                                        Else
                                            lebihanJamPulang = TimeSpan.Parse("00:00:00")
                                        End If
                                    Else
                                        lebihanJamPulang = TimeSpan.Parse("00:00:00")
                                    End If
                                    hitungJamKerjaNyata = (TimeSpan.Parse(GetJamKerjaNyata) - TimeSpan.Parse(_terlambat)) + lebihanJamPulang
                                    If (hitungJamKerjaNyata <= TimeSpan.Parse(GetJamKerjaNyata)) Then
                                        GetJamKerjaNyata = hitungJamKerjaNyata.ToString
                                    End If
                                Else
                                    GetJamKerjaNyata = Nothing
                                End If
                            End If
                            alreadyProcessed = True
                        End If
                        If Not IsNothing(_pulangCepat) And (_pulangCepat <> "") Then
                            'PULANG CEPAT
                            batasToleransi = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "batastoleransi", tableName(12),, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(_kelompok) & "' and katpenggajian='" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "' and leveljabatan=" & _levelJabatan & " and ijin='PC'")
                            If Not IsNothing(batasToleransi) Then
                                If (TimeSpan.Parse(_pulangCepat) > batasToleransi) Then
                                    'Jika jam pulangnya melebihi batas toleransinya, kalau untuk staff maka langsung dianggap tidak masuk kerja
                                    If (TimeSpan.Parse(_pulangCepat) <= TimeSpan.Parse(GetJamKerjaNyata)) Then
                                        GetJamKerjaNyata = (TimeSpan.Parse(GetJamKerjaNyata) - TimeSpan.Parse(_pulangCepat)).ToString
                                    Else
                                        GetJamKerjaNyata = Nothing
                                    End If
                                End If
                            End If
                        Else
                            If Not alreadyProcessed Then
                                'JIKA TIDAK PULANG CEPAT, CEK JAM KERJA, APAKAH PULANGNYA LEBIH DARI TOLERANSI TERLAMBAT
                                If Not IsNothing(_terlambat) And (_terlambat <> "") Then
                                    'Kalau tidak terlambat dan tidak pulang cepat, maka gak perlu di cek di sini
                                    batasToleransi = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "batastoleransi", tableName(12),, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(_kelompok) & "' and katpenggajian='" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "' and leveljabatan=" & _levelJabatan & " and ijin='DT'")
                                    If Not IsNothing(batasToleransi) Then
                                        'Jika jam terlambatnya kurang dari batas toleransinya
                                        If (TimeSpan.Parse(_terlambat) <= TimeSpan.Parse(GetJamKerjaNyata)) Then
                                            Dim lebihanJamPulang As TimeSpan
                                            If Not IsNothing(_pulang) Then
                                                If (TimeSpan.Parse(_pulang) > TimeSpan.Parse(_jadwalPulang)) Then
                                                    lebihanJamPulang = (TimeSpan.Parse(_pulang) - TimeSpan.Parse(_jadwalPulang))
                                                    If (lebihanJamPulang > batasToleransi) Then
                                                        lebihanJamPulang = batasToleransi
                                                    End If
                                                Else
                                                    lebihanJamPulang = TimeSpan.Parse("00:00:00")
                                                End If
                                            Else
                                                lebihanJamPulang = TimeSpan.Parse("00:00:00")
                                            End If
                                            hitungJamKerjaNyata = (TimeSpan.Parse(GetJamKerjaNyata) - TimeSpan.Parse(_terlambat)) + lebihanJamPulang
                                            If (hitungJamKerjaNyata <= TimeSpan.Parse(GetJamKerjaNyata)) Then
                                                GetJamKerjaNyata = hitungJamKerjaNyata.ToString
                                            End If
                                        Else
                                            GetJamKerjaNyata = Nothing
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Else
                    'Untuk NON STAFF dan OUTSOURCING. Perlakuan terlambatnya berbeda, jadi harus dipisah
                    'SEMENTARA TIDAK DIPAKAI DI MEDBOX
                    If (IsNothing(_terlambat) And IsNothing(_pulangCepat)) And (_terlambat = "" And _pulangCepat = "") Then
                        'Jika tidak terlambat dan pulang cepat, maka jam kerjanya full
                    Else
                        'Jika ada jam terlambatnya atau pulang cepat, maka dilakukan pengecekkan sesuai data yang ada di tabel mstoleransimenit
                        If (Not IsNothing(_terlambat) And Not IsNothing(GetJamKerjaNyata)) And (_terlambat <> "" And GetJamKerjaNyata <> "") Then
                            'DATANG TERLAMBAT
                            batasToleransi = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "batastoleransi", tableName(12),, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(_kelompok) & "' and katpenggajian='" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "' and ijin='DT'")
                            If Not IsNothing(batasToleransi) Then
                                If (TimeSpan.Parse(_terlambat) > batasToleransi) Then
                                    'Jika jam terlambatnya melebihi batas toleransinya, kalau untuk non staff maka akan dihitung gaji per jam
                                    If (Trim(_lokasi) = "SIDOARJO") Then
                                        GetJamKerjaNyata = TimeSpan.Parse(TimeSpan.Parse(GetJamKerjaNyata).Hours - TimeSpan.Parse(_terlambat).Hours & ":00:00").ToString
                                        If (TimeSpan.Parse(_terlambat).Minutes > 0 And TimeSpan.Parse(_terlambat).Minutes > batasToleransi.Minutes) Then
                                            If (TimeSpan.Parse(GetJamKerjaNyata).Hours > 1) Then
                                                GetJamKerjaNyata = TimeSpan.Parse(TimeSpan.Parse(GetJamKerjaNyata).Hours - 1 & ":00:00").ToString
                                            Else
                                                GetJamKerjaNyata = Nothing
                                            End If
                                        End If
                                    ElseIf (Trim(_lokasi) = "PANDAAN") Then
                                        'Kalau di Pandaan dihitung sampai ke menitnya, jam kerja nyatanya berapa
                                        GetJamKerjaNyata = (TimeSpan.Parse(GetJamKerjaNyata) - TimeSpan.Parse(_terlambat)).ToString
                                    End If
                                End If
                            End If
                        End If
                        If (Not IsNothing(_pulangCepat) And Not IsNothing(GetJamKerjaNyata)) And (_pulangCepat <> "" And GetJamKerjaNyata <> "") Then
                            'PULANG CEPAT
                            batasToleransi = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "batastoleransi", tableName(12),, "lokasi='" & myCStringManipulation.SafeSqlLiteral(_lokasi) & "' and perusahaan='" & myCStringManipulation.SafeSqlLiteral(_perusahaan) & "' and kelompok='" & myCStringManipulation.SafeSqlLiteral(_kelompok) & "' and katpenggajian='" & myCStringManipulation.SafeSqlLiteral(_katpenggajian) & "' and ijin='PC'")
                            If Not IsNothing(batasToleransi) Then
                                If (TimeSpan.Parse(_pulangCepat) > batasToleransi) Then
                                    'Jika jam pulangnya melebihi batas toleransinya, kalau untuk non staff maka akan dihitung gaji per jam
                                    If (Trim(_lokasi) = "SIDOARJO") Then
                                        GetJamKerjaNyata = TimeSpan.Parse(TimeSpan.Parse(GetJamKerjaNyata).Hours - TimeSpan.Parse(_pulangCepat).Hours & ":00:00").ToString
                                        If (TimeSpan.Parse(_pulangCepat).Minutes > 0 And TimeSpan.Parse(_pulangCepat).Minutes > batasToleransi.Minutes) Then
                                            If (TimeSpan.Parse(GetJamKerjaNyata).Hours > 1) Then
                                                GetJamKerjaNyata = TimeSpan.Parse(TimeSpan.Parse(GetJamKerjaNyata).Hours - 1 & ":00:00").ToString
                                            Else
                                                GetJamKerjaNyata = Nothing
                                            End If
                                        End If
                                    ElseIf (Trim(_lokasi) = "PANDAAN") Then
                                        'Kalau di Pandaan dihitung sampai ke menitnya, jam kerja nyatanya berapa
                                        GetJamKerjaNyata = (TimeSpan.Parse(GetJamKerjaNyata) - TimeSpan.Parse(_pulangCepat)).ToString
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetJamKerjaNyata Error")
            GetJamKerjaNyata = Nothing
        End Try
    End Function

    Private Function GetBanyakJamKerja(_jamKerja As String, Optional _pembulatan As Boolean = True) As Double
        Try
            If Not IsNothing(_jamKerja) And _jamKerja <> "" Then
                If (_pembulatan) Then
                    If (TimeSpan.Parse(_jamKerja) > TimeSpan.Parse("00:00:00")) Then
                        'Kalau banyak jam kerjanya dibulatkan, pasti cuman 1 atau 0.5
                        If (TimeSpan.Parse(_jamKerja).Minutes >= 0 And TimeSpan.Parse(_jamKerja).Minutes <= 29) Then
                            'Jika menitnya kurang dari 29 menit, maka dianggap 0
                            'Jika menitnya lebih dari atau sama dengan 29 menit, maka dianggap 0.5
                            ' 0 - 28 masuk ke 0 || menit ke 29 menjadi 0.5 jam
                            GetBanyakJamKerja = TimeSpan.Parse(_jamKerja).Hours & "." & IIf(TimeSpan.Parse(_jamKerja).Minutes < 29, 0, 5)
                        ElseIf (TimeSpan.Parse(_jamKerja).Minutes > 29 And TimeSpan.Parse(_jamKerja).Minutes <= 59) Then
                            'jika lebih dari 29 menit dan kurang dari atau sama dengan 59 menit maka dihitung jam nya masuk ke 1
                            If (TimeSpan.Parse(_jamKerja).Minutes >= 59) Then
                                'Kalau menitnya lebih dari atau sama dengan 59, maka jam nya dianggap naik 1
                                GetBanyakJamKerja = TimeSpan.Parse(_jamKerja).Hours + 1
                            Else
                                'Kalau menitnya di bawah 59 tapi di atas 29, maka dianggap 0.5
                                GetBanyakJamKerja = TimeSpan.Parse(_jamKerja).Hours & ".5"
                            End If
                        Else
                            GetBanyakJamKerja = 0
                        End If
                    Else
                        GetBanyakJamKerja = 0
                    End If
                Else
                    'Kalau banyak jam kerjanya tidak dibulatkan, jadi bisa 0.2, 0.7 dll
                    If (TimeSpan.Parse(_jamKerja) > TimeSpan.Parse("00:00:00")) Then
                        GetBanyakJamKerja = (TimeSpan.Parse(_jamKerja).Hours) + Math.Round(TimeSpan.Parse(_jamKerja).Minutes / 60, 2)
                    Else
                        GetBanyakJamKerja = 0
                    End If
                End If
            Else
                GetBanyakJamKerja = 0
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetBanyakJamKerja Error")
            GetBanyakJamKerja = 0
        End Try
    End Function

    Private Sub rbLokasiMesin_CheckedChanged(sender As Object, e As EventArgs) Handles rbImportDataSidoarjo.CheckedChanged, rbImportDataPandaan.CheckedChanged, rbProsesPresensiSidoarjo.CheckedChanged, rbProsesPresensiPandaan.CheckedChanged
        Try
            If (tcPresensi.SelectedTab.Equals(tpProsesAbsen)) Then
                Select Case True
                    Case rbProsesPresensiSidoarjo.Checked
                        gbProsesPresensiSidoarjo.Enabled = True
                        gbProsesPresensiPandaan.Enabled = False
                        'Call myCFormManipulation.ResetForm(gbProsesPresensiPandaan)
                        rbProsesPresensiFingerspot.Checked = False
                        rbProsesPresensiAttendanceManagement.Checked = False
                        rbProsesAbsenBioTime.Checked = False
                    Case rbProsesPresensiPandaan.Checked
                        gbProsesPresensiSidoarjo.Enabled = False
                        gbProsesPresensiPandaan.Enabled = True
                        'Call myCFormManipulation.ResetForm(gbProsesPresensiSidoarjo)
                        rbProsesPresensiFaceSDA.Checked = False
                        rbProsesPresensiFingerSDA.Checked = False
                End Select
            ElseIf (tcPresensi.SelectedTab.Equals(tpImportDataFingerFace)) Then
                Select Case True
                    Case rbImportDataSidoarjo.Checked
                        gbImportDataSidoarjo.Enabled = True
                        gbImportDataPandaan.Enabled = False
                        'Call myCFormManipulation.ResetForm(gbImportDataPandaan)
                        rbImportDataFingerspot.Checked = False
                        rbImportDataAttendanceManagement.Checked = False
                        rbImportDataBioTime.Checked = False
                    Case rbImportDataPandaan.Checked
                        gbImportDataSidoarjo.Enabled = False
                        gbImportDataPandaan.Enabled = True
                        'Call myCFormManipulation.ResetForm(gbImportDataSidoarjo)
                        rbImportDataFaceSDA.Checked = False
                        rbImportDataFingerKahuripan.Checked = False
                End Select
            End If

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbLokasiMesin_CheckedChanged Error")
        End Try
    End Sub

    Private Sub tcPresensi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcPresensi.SelectedIndexChanged
        Call rbLokasiMesin_CheckedChanged(sender, e)
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Try
            Dim isCetak As Boolean = False
            Dim rptType As String
            Dim subSQL As String
            If (rbLaporanPresensiKaryawanMingguan.Checked) Then
                rptType = "PresensiMingguan"
                If (cboPerusahaanCetak.SelectedIndex <> -1 And cboLokasiCetak.SelectedIndex <> -1) Then
                    isCetak = True
                Else
                    isCetak = False
                    Call myCShowMessage.ShowWarning("Perusahaan dan lokasi harus dilengkapi dulu!")
                    cboLokasiCetak.Focus()
                End If
            ElseIf (rbLaporanPresensiSecurity.Checked) Then
                rptType = "PresensiSecurity"
                If (cboLokasiCetak.SelectedIndex <> -1) Then
                    isCetak = True
                Else
                    isCetak = False
                    Call myCShowMessage.ShowWarning("Lokasi harus dilengkapi dulu!")
                    cboLokasiCetak.Focus()
                End If
            ElseIf (rbLaporanPresensiStaff.Checked) Then
                rptType = "PresensiStaff"
                If (cboLokasiCetak.SelectedIndex <> -1) Then
                    isCetak = True
                Else
                    isCetak = False
                    Call myCShowMessage.ShowWarning("Lokasi harus dilengkapi dulu!")
                    cboLokasiCetak.Focus()
                End If
            ElseIf (rbDataPresensi.Checked) Then
                rptType = "DataPresensi"
                If (cboDaftarMesinCetak.SelectedIndex <> -1 And cboLokasiCetak.SelectedIndex <> -1) Then
                    isCetak = True
                Else
                    isCetak = False
                    Call myCShowMessage.ShowWarning("Jenis mesin dan lokasi harus dilengkapi dulu!")
                    cboDaftarMesinCetak.Focus()
                End If
            ElseIf (rbDataMentah.Checked) Then
                rptType = "DataMentah"
                If (cboDaftarMesinCetak.SelectedIndex <> -1 And cboLokasiCetak.SelectedIndex <> -1) Then
                    isCetak = True
                Else
                    isCetak = False
                    Call myCShowMessage.ShowWarning("Jenis mesin dan lokasi harus dilengkapi dulu!")
                    cboDaftarMesinCetak.Focus()
                End If
            ElseIf (rbRekapDataPresensi.Checked) Then
                rptType = "RekapDataPresensi"
                If (cboLokasiCetak.SelectedIndex <> -1) Then
                    isCetak = True
                Else
                    isCetak = False
                    Call myCShowMessage.ShowWarning("Lokasi harus dilengkapi dulu!")
                    cboLokasiCetak.Focus()
                End If
            ElseIf (rbLaporanKaryawanTidakMasukHarian.Checked) Then
                rptType = "KaryawanTidakMasuk"
                If (cboLokasiCetak.SelectedIndex <> -1) Then
                    isCetak = True
                Else
                    isCetak = False
                    Call myCShowMessage.ShowWarning("Lokasi harus dilengkapi dulu!")
                    cboLokasiCetak.Focus()
                End If
            ElseIf (rbJadwalPresensi.Checked) Then
                rptType = "JadwalPresensi"
                If (cboLokasiCetak.SelectedIndex <> -1 And cboPerusahaanCetak.SelectedIndex <> -1) Then
                    isCetak = True
                Else
                    isCetak = False
                    Call myCShowMessage.ShowWarning("Lokasi dan Perusahaan harus dilengkapi dulu!")
                    cboLokasiCetak.Focus()
                End If
            Else
                rptType = "-"
                isCetak = True
            End If

            If (isCetak) Then
                Select Case rptType
                    Case "PresensiMingguan"
                        If (cboLokasiCetak.SelectedValue = "PANDAAN") Then
                            'NON STAFF PANDAAN
                            stSQL = "SELECT lokasi,'" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' as tanggalawal, '" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "' as tanggalakhir,tanggal,fpid,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,ijin,absen,masuk,keluar,jamkerja,jamkerjanyata,banyakjamkerja,banyakjamkerjanyata,shift,terlambat,pulangcepat,jamlembur,mulailembur,selesailembur
                                    FROM " & tableName(0) & " " & "
                                    WHERE (tanggal>='" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "') and perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaanCetak.SelectedValue) & "' " & IIf(cboDepartemenCetak.SelectedIndex <> -1, "and departemen='" & myCStringManipulation.SafeSqlLiteral(cboDepartemenCetak.SelectedValue) & "'", "") & " and lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasiCetak.SelectedValue) & "' and kelompok='NON STAFF' and katpenggajian='MINGGUAN'
                                    ORDER BY tanggal,nama,departemen,divisi,bagian;"
                        ElseIf (cboLokasiCetak.SelectedValue = "SIDOARJO") Then
                            stSQL = Nothing
                        End If
                    Case "PresensiSecurity"
                        If (cboLokasiCetak.SelectedValue = "PANDAAN") Then
                            'SECURITY PANDAAN
                            stSQL = "SELECT lokasi,'" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' as tanggalawal, '" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "' as tanggalakhir,tanggal,fpid,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,ijin,absen,masuk,keluar,jamkerja,jamkerjanyata,banyakjamkerja,banyakjamkerjanyata,shift,terlambat,pulangcepat,jamlembur,mulailembur,selesailembur
                                    FROM " & tableName(0) & " " & "
                                    WHERE (tanggal>='" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "') and divisi='SECURITY' and lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasiCetak.SelectedValue) & "'
                                    ORDER BY tanggal,nama,departemen,divisi,bagian;"
                        ElseIf (cboLokasiCetak.SelectedValue = "SIDOARJO") Then
                            stSQL = Nothing
                        End If
                    Case "PresensiStaff"
                        If (cboLokasiCetak.SelectedValue = "PANDAAN") Then
                            stSQL = Nothing
                        ElseIf (cboLokasiCetak.SelectedValue = "SIDOARJO") Then
                            'PRESENSI STAFF SIDOARJO
                            subSQL = "SELECT k.idk,k.nip,k.nama,case when e.level is null then 1 else e.level end as level
                                    FROM " & tableName(11) & " as k LEFT JOIN " & CONN_.schemaHRD & ".msposisikaryawan as e on k.nip=e.nip and (e.tglmulaimenjabat<='" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' and (e.tglselesaimenjabat is null or e.tglselesaimenjabat>='" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "'))
                                    GROUP BY k.idk,k.nip,k.nama,e.level"

                            stSQL = "SELECT d.lokasi,'" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' as tanggalawal, '" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "' as tanggalakhir,d.tanggal,d.fpid,d.nip,d.nama,d.perusahaan,d.departemen,d.divisi,d.bagian,d.kelompok,d.katpenggajian,d.ijin,d.absen,a.kategori as kategoriabsen,d.masuk,d.keluar,d.jamkerja,d.jamkerjanyata,d.banyakjamkerja,d.banyakjamkerjanyata,d.shift,d.terlambat,d.pulangcepat,d.jamlembur,d.mulailembur,d.selesailembur,t.dendaharian,t.toleransi,t.dendapenalty
                                    FROM " & tableName(0) & " as d INNER JOIN (" & subSQL & ") as p on d.nip=p.nip left join " & CONN_.schemaHRD & ".msdendaterlambat as t on p.level=t.leveljabatan and d.lokasi=t.lokasi left join " & CONN_.schemaHRD & ".mskategoriabsen as a on d.absen=a.absen and d.lokasi=a.lokasi
                                    WHERE (d.tanggal>='" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' and d.tanggal<='" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "') and d.kelompok='STAFF' and d.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasiCetak.SelectedValue) & "' 
                                    ORDER BY tanggal,nama,departemen,divisi,bagian;"
                        End If
                    Case "DataPresensi"
                        If (cboLokasiCetak.SelectedValue = "PANDAAN") Then
                            stSQL = Nothing
                        ElseIf (cboLokasiCetak.SelectedValue = "SIDOARJO") Then
                            stSQL = "SELECT d.lokasi,'" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' as tanggalawal, '" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "' as tanggalakhir,d.tanggal,d.nip,d.fpid,d.nama,d.perusahaan,d.fpmasuk,d.fpkeluar,d.terlambat,d.pulangcepat,p.mesin
                                    FROM " & tableName(0) & " as d LEFT JOIN " & tableName(8) & " as p on d.tanggal=p.tanggal and d.fpid=p.fpid and d.lokasi=p.lokasi
                                    WHERE (d.tanggal>='" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' and d.tanggal<='" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "') and p.mesin='" & myCStringManipulation.SafeSqlLiteral(cboDaftarMesinCetak.SelectedValue) & "'  and d.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasiCetak.SelectedValue) & "' and p.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasiCetak.SelectedValue) & "'
                                    ORDER BY d.tanggal,d.nama;"
                        End If
                    Case "DataMentah"
                        If (cboLokasiCetak.SelectedValue = "PANDAAN") Then
                            stSQL = "SELECT h.tanggal,h.fpid,h.idk,d.mesin,h.nip,h.nama,h.masuk,h.keluar,h.fpmasuk,h.fpkeluar
                                    FROM " & tableName(0) & " as h left join " & tableName(8) & " as d on h.fpid=d.fpid and h.lokasi=d.lokasi and h.tanggal=d.tanggal
                                    WHERE h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasiCetak.SelectedValue) & "' and h.tanggal>='" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' and h.tanggal<='" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "' and d.mesin='" & myCStringManipulation.SafeSqlLiteral(cboDaftarMesinCetak.SelectedValue) & "'
                                    GROUP BY h.tanggal,h.fpid,h.idk,d.mesin,h.nip,h.nama,h.masuk,h.keluar,h.fpmasuk,h.fpkeluar
                                    ORDER BY h.tanggal,h.nama;"
                        ElseIf (cboLokasiCetak.SelectedValue = "SIDOARJO") Then
                            stSQL = Nothing
                        End If
                    Case "RekapDataPresensi"
                        If (cboLokasiCetak.SelectedValue = "PANDAAN") Then
                            stSQL = "SELECT h.tanggal,g.kode,h.perusahaan,h.lokasi,h.fpid,h.idk,tbl2.mesin,h.nip,h.nama,h.kelompok,h.departemen,h.divisi,h.bagian,p.posisi,h.ijin,h.absen,h.masuk,h.keluar,h.terlambat,h.pulangcepat,h.fpmasuk,h.fpkeluar,h.kodewaktushift,(case when h.departemen='SECURITY' then 'SATPAM' else (case when h.divisi='SECURITY' then 'SATPAM' else (case when h.bagian='SECURITY' then 'SATPAM' else (case when h.kelompok='STAFF' then (case when p.posisi like '%MANAGER%' then 'MANAGER' else 'STAFF' end) else 'NON STAFF' end) end) end) end) as grupkelompok,h.tanggalmasuk
                                    FROM (" & tableName(0) & " as h left join " & CONN_.schemaHRD & ".msgeneral as g on h.perusahaan=g.keterangan) left join " & CONN_.schemaHRD & ".msposisikaryawan as p on h.nip=p.nip and p.aktif='True' left join (
                                        SELECT d.fpid,d.mesin
                                        FROM " & tableName(8) & " as d
                                        WHERE d.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasiCetak.SelectedValue) & "' and d.tanggal>='" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' and d.tanggal<='" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "'
                                        GROUP BY d.fpid,d.mesin
                                        ORDER BY d.mesin,d.fpid) as tbl2 on tbl2.fpid=h.fpid
                                    WHERE h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasiCetak.SelectedValue) & "' and h.tanggal>='" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' and h.tanggal<='" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "'
                                    GROUP BY h.tanggal,h.perusahaan,g.kode,h.lokasi,h.fpid,h.idk,tbl2.mesin,h.nip,h.nama,h.kelompok,h.departemen,h.divisi,h.bagian,p.posisi,h.ijin,h.absen,h.masuk,h.keluar,h.terlambat,h.pulangcepat,h.fpmasuk,h.fpkeluar,h.kodewaktushift,h.tanggalmasuk
                                    ORDER BY h.tanggalmasuk;"
                        ElseIf (cboLokasiCetak.SelectedValue = "SIDOARJO") Then
                            stSQL = Nothing
                        End If
                    Case "KaryawanTidakMasuk"
                        If (cboLokasiCetak.SelectedValue = "PANDAAN") Then
                            stSQL = "SELECT h.tanggal,h.fpid,h.nip,h.nama,h.perusahaan,h.departemen,h.divisi,h.bagian,h.kelompok,h.katpenggajian,h.ijin,h.absen,(case when h.absen='M' then 'N/I' else g.keterangan end) as keterangan,(case when exists(select 1 FROM " & CONN_.schemaHRD & ".trijinabsen as i where h.nip=i.nip and h.absen=i.kodeabsen and h.tanggal>=i.tanggalmulai and h.tanggal<=i.tanggalselesai) then (select i.tanggalmulai FROM " & CONN_.schemaHRD & ".trijinabsen as i where h.nip=i.nip and h.absen=i.kodeabsen and h.tanggal>=i.tanggalmulai and h.tanggal<=i.tanggalselesai) else h.tanggal end) as tglmulaitidakmasuk, (case when exists(select 1 FROM " & CONN_.schemaHRD & ".trijinabsen as i where h.nip=i.nip and h.absen=i.kodeabsen and h.tanggal>=i.tanggalmulai and h.tanggal<=i.tanggalselesai) then (select i.catatan FROM " & CONN_.schemaHRD & ".trijinabsen as i where h.nip=i.nip and h.absen=i.kodeabsen and h.tanggal>=i.tanggalmulai and h.tanggal<=i.tanggalselesai) else (case when h.absen='M' then 'N/I' else g.keterangan end) end) as ketabsen
                                    FROM " & tableName(0) & " as h left join " & CONN_.schemaHRD & ".msgeneral as g on h.absen=g.kode and g.kategori='absen' 
                                    WHERE h.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasiCetak.SelectedValue) & "' and (h.tanggal='" & Format(dtpTanggalCetakAwal.Value.Date, "dd-MMM-yyyy") & "') and h.ijin='TM' and (h.absen<>'L' and h.absen<>'C' and h.absen<>'NC') 
                                    ORDER BY h.perusahaan,h.nama;"
                        ElseIf (cboLokasiCetak.SelectedValue = "SIDOARJO") Then
                            stSQL = Nothing
                        End If
                    Case "JadwalPresensi"
                        stSQL = "SELECT lokasi,'" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' as tanggalawal, '" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "' as tanggalakhir,tanggal,fpid,nip,nama,perusahaan,departemen,divisi,bagian,kelompok,katpenggajian,ijin,absen,jadwalmasuk,jadwalkeluar,masuk,keluar,jamkerja,jamkerjanyata,banyakjamkerja,banyakjamkerjanyata,shift,terlambat,pulangcepat,jamlembur,mulailembur,selesailembur,spkmulai,spkselesai
                                FROM " & tableName(0) & " " & "
                                WHERE (tanggal>='" & Format(dtpTanggalCetakAwal.Value, "dd-MMM-yyyy") & "' and tanggal<='" & Format(dtpTanggalCetakAkhir.Value, "dd-MMM-yyyy") & "') and (perusahaan='" & myCStringManipulation.SafeSqlLiteral(cboPerusahaanCetak.SelectedValue) & "') " & IIf(cboDepartemenCetak.SelectedIndex <> -1, "and departemen='" & myCStringManipulation.SafeSqlLiteral(cboDepartemenCetak.SelectedValue) & "'", "") & "
                                ORDER BY tanggal,nama,departemen,divisi,bagian;"
                    Case Else
                        stSQL = Nothing
                End Select

                If (rptType = "PresensiMingguan") Or (rptType = "PresensiSecurity") Or (rptType = "PresensiStaff") Or (rptType = "DataPresensi") Or (rptType = "DataMentah") Or (rptType = "RekapDataPresensi") Or (rptType = "KaryawanTidakMasuk") Then
                    Dim frmDisplayReport As New FormDisplayReport.FormDisplayReport(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, stSQL, rptType,, cboLokasiCetak.SelectedValue)
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmDisplayReport)
                ElseIf (rptType = "JadwalPresensi") Then
                    Dim frmDisplayReport As New FormDisplayReport.FormDisplayReport(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, stSQL, rptType)
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmDisplayReport)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCetak_Click Error")
        End Try
    End Sub

    Private Sub rbLaporanPresensi_CheckedChanged(sender As Object, e As EventArgs) Handles rbLaporanPresensiKaryawanMingguan.CheckedChanged, rbJadwalPresensi.CheckedChanged, rbLaporanPresensiSecurity.CheckedChanged, rbDataPresensi.CheckedChanged, rbDataMentah.CheckedChanged
        Try
            If (rbLaporanPresensiKaryawanMingguan.Checked Or rbLaporanPresensiSecurity.Checked Or rbLaporanPresensiStaff.Checked Or rbJadwalPresensi.Checked) Then
                cboPerusahaanCetak.Enabled = True
                cboDaftarMesinCetak.Enabled = False
                If (rbLaporanPresensiKaryawanMingguan.Checked Or rbLaporanPresensiStaff.Checked Or rbJadwalPresensi.Checked) Then
                    cboDepartemenCetak.Enabled = True
                ElseIf (rbLaporanPresensiSecurity.Checked) Then
                    cboDepartemenCetak.Enabled = False
                End If
            ElseIf (rbDataPresensi.Checked) Or (rbDataMentah.Checked) Then
                cboPerusahaanCetak.Enabled = False
                cboDepartemenCetak.Enabled = False
                cboDaftarMesinCetak.Enabled = True
            ElseIf (rbRekapDataPresensi.Checked) Or (rbLaporanKaryawanTidakMasukHarian.Checked) Then
                cboPerusahaanCetak.Enabled = False
                cboDepartemenCetak.Enabled = False
                cboDaftarMesinCetak.Enabled = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbLaporanPresensi_CheckedChanged Error")
        End Try
    End Sub

    Private Sub cboLokasi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLokasi.SelectedIndexChanged
        Try
            If (rbKaryawan.Checked) Then
                cboKaryawan.Enabled = True
                'If (cboKaryawan.Items.Count = 0) Then
                If (cboLokasi.SelectedIndex <> -1) Then
                    Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    stSQL = "SELECT concat(d.nama,' || ',d.nip,' || ',d.departemen,' || ',d.divisi,' || ',d.bagian) as karyawan,d.idk,d.nip,d.nama,d.perusahaan,d.departemen,d.divisi,d.bagian FROM " & CONN_.schemaHRD & ".mskaryawanaktif as d inner join " & CONN_.schemaHRD & ".mskaryawan as h on h.idk=d.idk WHERE " & IIf(USER_.lokasi = "ALL", "(d.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND ", "(d.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "') AND ") & "(case when d.statuskepegawaian is null or d.statuskepegawaian='TETAP' then h.tanggalmasuk<=CURRENT_DATE else d.tglmulaikontrak<=CURRENT_DATE end) GROUP BY concat(d.nama,' || ',d.nip,' || ',d.departemen,' || ',d.divisi,' || ',d.bagian),d.idk,d.nip,d.nama,d.perusahaan,d.departemen,d.divisi,d.bagian ORDER BY karyawan;"
                    Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared, True)

                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                    Cursor = Cursors.Default
                Else
                    Call myCShowMessage.ShowWarning("Silahkan tentukan lokasinya dulu!")
                    cboLokasi.Focus()
                End If
                'End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboLokasi_SelectedIndexChanged Error")
        End Try
    End Sub

    Private Sub rbKategoriProses_CheckedChanged(sender As Object, e As EventArgs) Handles rbSemua.CheckedChanged, rbKaryawan.CheckedChanged
        Try
            If (rbSemua.Checked) Then
                cboKaryawan.SelectedIndex = -1
                cboKaryawan.Enabled = False
            Else
                cboKaryawan.Enabled = True
                'If (cboKaryawan.Items.Count = 0) Then
                If (cboLokasi.SelectedIndex <> -1) Then
                    Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    stSQL = "SELECT concat(d.nama,' || ',d.nip,' || ',d.departemen,' || ',d.divisi,' || ',d.bagian) as karyawan,d.idk,d.nip,d.nama,d.perusahaan,d.departemen,d.divisi,d.bagian FROM " & CONN_.schemaHRD & ".mskaryawanaktif as d inner join " & CONN_.schemaHRD & ".mskaryawan as h on h.idk=d.idk WHERE " & IIf(USER_.lokasi = "ALL", "(d.lokasi='" & myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue) & "') AND ", "(d.lokasi='" & myCStringManipulation.SafeSqlLiteral(USER_.lokasi) & "') AND ") & "(case when d.statuskepegawaian is null or d.statuskepegawaian='TETAP' then h.tanggalmasuk<=CURRENT_DATE else d.tglmulaikontrak<=CURRENT_DATE end) GROUP BY concat(d.nama,' || ',d.nip,' || ',d.departemen,' || ',d.divisi,' || ',d.bagian),d.idk,d.nip,d.nama,d.perusahaan,d.departemen,d.divisi,d.bagian ORDER BY karyawan;"
                    Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboKaryawan, myBindingKaryawan, cboKaryawan, "T_" & cboKaryawan.Name, "nip", "karyawan", isCboPrepared, True)

                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                    Cursor = Cursors.Default
                Else
                    Call myCShowMessage.ShowWarning("Silahkan tentukan lokasinya dulu!")
                    cboLokasi.Focus()
                End If
                'End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbKategoriProses_CheckedChanged Error")
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboKaryawan.Validated
        Try
            If (isDataPrepared) Then
                If (Trim(sender.Text).Length = 0) Then
                    sender.SelectedIndex = -1
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub cboLokasiCetak_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLokasiCetak.SelectedIndexChanged
        Try
            If (isCboPrepared) Then
                If (cboLokasiCetak.SelectedValue = "SIDOARJO") Then
                    rbLaporanPresensiKaryawanMingguan.Enabled = False
                    rbLaporanPresensiStaff.Enabled = True
                    rbLaporanPresensiSecurity.Enabled = False
                    rbDataPresensi.Enabled = True
                    rbDataMentah.Enabled = False
                    rbRekapDataPresensi.Enabled = False
                    rbLaporanKaryawanTidakMasukHarian.Enabled = False
                    rbJadwalPresensi.Enabled = True
                ElseIf (cboLokasiCetak.SelectedValue = "PANDAAN") Then
                    rbLaporanPresensiKaryawanMingguan.Enabled = True
                    rbLaporanPresensiStaff.Enabled = False
                    rbLaporanPresensiSecurity.Enabled = True
                    rbDataPresensi.Enabled = False
                    rbDataMentah.Enabled = True
                    rbRekapDataPresensi.Enabled = True
                    rbLaporanKaryawanTidakMasukHarian.Enabled = True
                    rbJadwalPresensi.Enabled = True
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboLokasiCetak_SelectedIndexChanged Error")
        End Try
    End Sub
End Class
