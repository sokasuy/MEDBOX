<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProsesPresensi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProsesPresensi))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tcPresensi = New System.Windows.Forms.TabControl()
        Me.tpProsesAbsen = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbKaryawan = New System.Windows.Forms.RadioButton()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.rbSemua = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnTarikDataFingerprint = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblProsesAbsenMesin = New System.Windows.Forms.Label()
        Me.gbProsesPresensiPandaan = New System.Windows.Forms.GroupBox()
        Me.rbProsesPresensiAttendanceManagement = New System.Windows.Forms.RadioButton()
        Me.rbProsesPresensiFingerspot = New System.Windows.Forms.RadioButton()
        Me.rbProsesAbsenBioTime = New System.Windows.Forms.RadioButton()
        Me.rbProsesPresensiSidoarjo = New System.Windows.Forms.RadioButton()
        Me.gbProsesPresensiSidoarjo = New System.Windows.Forms.GroupBox()
        Me.rbProsesPresensiFaceSDA = New System.Windows.Forms.RadioButton()
        Me.rbProsesPresensiFingerSDA = New System.Windows.Forms.RadioButton()
        Me.rbProsesPresensiPandaan = New System.Windows.Forms.RadioButton()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.pbLoading = New System.Windows.Forms.ProgressBar()
        Me.lblTanggalProses = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblPer = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.btnProsesFP = New System.Windows.Forms.Button()
        Me.lblProsesFP = New System.Windows.Forms.Label()
        Me.lblUpdateIjinLemburSPK = New System.Windows.Forms.Label()
        Me.btnUpdateIjinLemburSPK = New System.Windows.Forms.Button()
        Me.lblTarikDataKaryawan = New System.Windows.Forms.Label()
        Me.btnTarikDataKaryawan = New System.Windows.Forms.Button()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.dtpPeriodeAkhir = New System.Windows.Forms.DateTimePicker()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.cboLokasi = New System.Windows.Forms.ComboBox()
        Me.lblPeriode = New System.Windows.Forms.Label()
        Me.dtpPeriodeAwal = New System.Windows.Forms.DateTimePicker()
        Me.tpImportDataFingerFace = New System.Windows.Forms.TabPage()
        Me.gbImportExcel = New System.Windows.Forms.GroupBox()
        Me.gbImportDataPandaan = New System.Windows.Forms.GroupBox()
        Me.rbImportDataFingerspot = New System.Windows.Forms.RadioButton()
        Me.rbImportDataAttendanceManagement = New System.Windows.Forms.RadioButton()
        Me.rbImportDataBioTime = New System.Windows.Forms.RadioButton()
        Me.gbImportDataSidoarjo = New System.Windows.Forms.GroupBox()
        Me.rbImportDataFingerKahuripan = New System.Windows.Forms.RadioButton()
        Me.rbImportDataFaceSDA = New System.Windows.Forms.RadioButton()
        Me.rbImportDataPandaan = New System.Windows.Forms.RadioButton()
        Me.rbImportDataSidoarjo = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.lblImportDataMesin = New System.Windows.Forms.Label()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.tbNamaFile = New System.Windows.Forms.TextBox()
        Me.btnProsesImport = New System.Windows.Forms.Button()
        Me.lblNamaFile = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblNamaSheet = New System.Windows.Forms.Label()
        Me.tbNamaSheet = New System.Windows.Forms.TextBox()
        Me.tpPrintOut = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbJadwalPresensi = New System.Windows.Forms.RadioButton()
        Me.rbLaporanKaryawanTidakMasukHarian = New System.Windows.Forms.RadioButton()
        Me.rbRekapDataPresensi = New System.Windows.Forms.RadioButton()
        Me.cboDepartemenCetak = New System.Windows.Forms.ComboBox()
        Me.rbDataMentah = New System.Windows.Forms.RadioButton()
        Me.cboDaftarMesinCetak = New System.Windows.Forms.ComboBox()
        Me.rbDataPresensi = New System.Windows.Forms.RadioButton()
        Me.rbLaporanPresensiStaff = New System.Windows.Forms.RadioButton()
        Me.lblLokasiCetak = New System.Windows.Forms.Label()
        Me.cboLokasiCetak = New System.Windows.Forms.ComboBox()
        Me.dtpTanggalCetakAkhir = New System.Windows.Forms.DateTimePicker()
        Me.cboPerusahaanCetak = New System.Windows.Forms.ComboBox()
        Me.rbLaporanPresensiKaryawanMingguan = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCetak = New System.Windows.Forms.Button()
        Me.rbLaporanPresensiSecurity = New System.Windows.Forms.RadioButton()
        Me.lblPeriodeCetak = New System.Windows.Forms.Label()
        Me.dtpTanggalCetakAwal = New System.Windows.Forms.DateTimePicker()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.tcPresensi.SuspendLayout()
        Me.tpProsesAbsen.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbProsesPresensiPandaan.SuspendLayout()
        Me.gbProsesPresensiSidoarjo.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        Me.tpImportDataFingerFace.SuspendLayout()
        Me.gbImportExcel.SuspendLayout()
        Me.gbImportDataPandaan.SuspendLayout()
        Me.gbImportDataSidoarjo.SuspendLayout()
        Me.tpPrintOut.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.PowderBlue
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(781, 25)
        Me.lblTitle.TabIndex = 179
        Me.lblTitle.Text = "PROSES PRESENSI"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tcPresensi
        '
        Me.tcPresensi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcPresensi.Controls.Add(Me.tpProsesAbsen)
        Me.tcPresensi.Controls.Add(Me.tpImportDataFingerFace)
        Me.tcPresensi.Controls.Add(Me.tpPrintOut)
        Me.tcPresensi.Location = New System.Drawing.Point(12, 28)
        Me.tcPresensi.Name = "tcPresensi"
        Me.tcPresensi.SelectedIndex = 0
        Me.tcPresensi.Size = New System.Drawing.Size(757, 310)
        Me.tcPresensi.TabIndex = 180
        '
        'tpProsesAbsen
        '
        Me.tpProsesAbsen.Controls.Add(Me.Panel2)
        Me.tpProsesAbsen.Controls.Add(Me.Label3)
        Me.tpProsesAbsen.Controls.Add(Me.btnTarikDataFingerprint)
        Me.tpProsesAbsen.Controls.Add(Me.Panel1)
        Me.tpProsesAbsen.Controls.Add(Me.pnlLoading)
        Me.tpProsesAbsen.Controls.Add(Me.btnProsesFP)
        Me.tpProsesAbsen.Controls.Add(Me.lblProsesFP)
        Me.tpProsesAbsen.Controls.Add(Me.lblUpdateIjinLemburSPK)
        Me.tpProsesAbsen.Controls.Add(Me.btnUpdateIjinLemburSPK)
        Me.tpProsesAbsen.Controls.Add(Me.lblTarikDataKaryawan)
        Me.tpProsesAbsen.Controls.Add(Me.btnTarikDataKaryawan)
        Me.tpProsesAbsen.Controls.Add(Me.lblSD)
        Me.tpProsesAbsen.Controls.Add(Me.dtpPeriodeAkhir)
        Me.tpProsesAbsen.Controls.Add(Me.lblLokasi)
        Me.tpProsesAbsen.Controls.Add(Me.cboLokasi)
        Me.tpProsesAbsen.Controls.Add(Me.lblPeriode)
        Me.tpProsesAbsen.Controls.Add(Me.dtpPeriodeAwal)
        Me.tpProsesAbsen.Location = New System.Drawing.Point(4, 22)
        Me.tpProsesAbsen.Name = "tpProsesAbsen"
        Me.tpProsesAbsen.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProsesAbsen.Size = New System.Drawing.Size(749, 284)
        Me.tpProsesAbsen.TabIndex = 0
        Me.tpProsesAbsen.Text = "PROSES PRESENSI"
        Me.tpProsesAbsen.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbKaryawan)
        Me.Panel2.Controls.Add(Me.cboKaryawan)
        Me.Panel2.Controls.Add(Me.rbSemua)
        Me.Panel2.Location = New System.Drawing.Point(17, 88)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(571, 25)
        Me.Panel2.TabIndex = 232
        '
        'rbKaryawan
        '
        Me.rbKaryawan.AutoSize = True
        Me.rbKaryawan.Location = New System.Drawing.Point(67, 3)
        Me.rbKaryawan.Name = "rbKaryawan"
        Me.rbKaryawan.Size = New System.Drawing.Size(78, 17)
        Me.rbKaryawan.TabIndex = 6
        Me.rbKaryawan.TabStop = True
        Me.rbKaryawan.Text = "Karyawan :"
        Me.rbKaryawan.UseVisualStyleBackColor = True
        '
        'cboKaryawan
        '
        Me.cboKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.IntegralHeight = False
        Me.cboKaryawan.Location = New System.Drawing.Point(151, 2)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(415, 21)
        Me.cboKaryawan.TabIndex = 7
        '
        'rbSemua
        '
        Me.rbSemua.AutoSize = True
        Me.rbSemua.Location = New System.Drawing.Point(3, 3)
        Me.rbSemua.Name = "rbSemua"
        Me.rbSemua.Size = New System.Drawing.Size(58, 17)
        Me.rbSemua.TabIndex = 5
        Me.rbSemua.TabStop = True
        Me.rbSemua.Text = "Semua"
        Me.rbSemua.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 13)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "1. TARIK DATA FINGERPRINT"
        '
        'btnTarikDataFingerprint
        '
        Me.btnTarikDataFingerprint.Location = New System.Drawing.Point(278, 59)
        Me.btnTarikDataFingerprint.Name = "btnTarikDataFingerprint"
        Me.btnTarikDataFingerprint.Size = New System.Drawing.Size(90, 23)
        Me.btnTarikDataFingerprint.TabIndex = 4
        Me.btnTarikDataFingerprint.Text = "1. PROSES"
        Me.btnTarikDataFingerprint.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblProsesAbsenMesin)
        Me.Panel1.Controls.Add(Me.gbProsesPresensiPandaan)
        Me.Panel1.Controls.Add(Me.rbProsesPresensiSidoarjo)
        Me.Panel1.Controls.Add(Me.gbProsesPresensiSidoarjo)
        Me.Panel1.Controls.Add(Me.rbProsesPresensiPandaan)
        Me.Panel1.Location = New System.Drawing.Point(624, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(112, 23)
        Me.Panel1.TabIndex = 226
        Me.Panel1.Visible = False
        '
        'lblProsesAbsenMesin
        '
        Me.lblProsesAbsenMesin.AutoSize = True
        Me.lblProsesAbsenMesin.Location = New System.Drawing.Point(6, 19)
        Me.lblProsesAbsenMesin.Name = "lblProsesAbsenMesin"
        Me.lblProsesAbsenMesin.Size = New System.Drawing.Size(47, 13)
        Me.lblProsesAbsenMesin.TabIndex = 127
        Me.lblProsesAbsenMesin.Text = "MESIN :"
        '
        'gbProsesPresensiPandaan
        '
        Me.gbProsesPresensiPandaan.Controls.Add(Me.rbProsesPresensiAttendanceManagement)
        Me.gbProsesPresensiPandaan.Controls.Add(Me.rbProsesPresensiFingerspot)
        Me.gbProsesPresensiPandaan.Controls.Add(Me.rbProsesAbsenBioTime)
        Me.gbProsesPresensiPandaan.Location = New System.Drawing.Point(133, 46)
        Me.gbProsesPresensiPandaan.Name = "gbProsesPresensiPandaan"
        Me.gbProsesPresensiPandaan.Size = New System.Drawing.Size(315, 35)
        Me.gbProsesPresensiPandaan.TabIndex = 225
        Me.gbProsesPresensiPandaan.TabStop = False
        Me.gbProsesPresensiPandaan.Text = "Pandaan"
        '
        'rbProsesPresensiAttendanceManagement
        '
        Me.rbProsesPresensiAttendanceManagement.AutoSize = True
        Me.rbProsesPresensiAttendanceManagement.Location = New System.Drawing.Point(86, 12)
        Me.rbProsesPresensiAttendanceManagement.Name = "rbProsesPresensiAttendanceManagement"
        Me.rbProsesPresensiAttendanceManagement.Size = New System.Drawing.Size(145, 17)
        Me.rbProsesPresensiAttendanceManagement.TabIndex = 114
        Me.rbProsesPresensiAttendanceManagement.Text = "Attendance Management"
        Me.rbProsesPresensiAttendanceManagement.UseVisualStyleBackColor = True
        '
        'rbProsesPresensiFingerspot
        '
        Me.rbProsesPresensiFingerspot.AutoSize = True
        Me.rbProsesPresensiFingerspot.Location = New System.Drawing.Point(6, 12)
        Me.rbProsesPresensiFingerspot.Name = "rbProsesPresensiFingerspot"
        Me.rbProsesPresensiFingerspot.Size = New System.Drawing.Size(74, 17)
        Me.rbProsesPresensiFingerspot.TabIndex = 113
        Me.rbProsesPresensiFingerspot.Text = "Fingerspot"
        Me.rbProsesPresensiFingerspot.UseVisualStyleBackColor = True
        '
        'rbProsesAbsenBioTime
        '
        Me.rbProsesAbsenBioTime.AutoSize = True
        Me.rbProsesAbsenBioTime.Location = New System.Drawing.Point(237, 12)
        Me.rbProsesAbsenBioTime.Name = "rbProsesAbsenBioTime"
        Me.rbProsesAbsenBioTime.Size = New System.Drawing.Size(66, 17)
        Me.rbProsesAbsenBioTime.TabIndex = 112
        Me.rbProsesAbsenBioTime.Text = "Bio Time"
        Me.rbProsesAbsenBioTime.UseVisualStyleBackColor = True
        '
        'rbProsesPresensiSidoarjo
        '
        Me.rbProsesPresensiSidoarjo.AutoSize = True
        Me.rbProsesPresensiSidoarjo.Location = New System.Drawing.Point(59, 17)
        Me.rbProsesPresensiSidoarjo.Name = "rbProsesPresensiSidoarjo"
        Me.rbProsesPresensiSidoarjo.Size = New System.Drawing.Size(63, 17)
        Me.rbProsesPresensiSidoarjo.TabIndex = 222
        Me.rbProsesPresensiSidoarjo.Text = "Sidoarjo"
        Me.rbProsesPresensiSidoarjo.UseVisualStyleBackColor = True
        '
        'gbProsesPresensiSidoarjo
        '
        Me.gbProsesPresensiSidoarjo.Controls.Add(Me.rbProsesPresensiFaceSDA)
        Me.gbProsesPresensiSidoarjo.Controls.Add(Me.rbProsesPresensiFingerSDA)
        Me.gbProsesPresensiSidoarjo.Location = New System.Drawing.Point(133, 5)
        Me.gbProsesPresensiSidoarjo.Name = "gbProsesPresensiSidoarjo"
        Me.gbProsesPresensiSidoarjo.Size = New System.Drawing.Size(175, 35)
        Me.gbProsesPresensiSidoarjo.TabIndex = 224
        Me.gbProsesPresensiSidoarjo.TabStop = False
        Me.gbProsesPresensiSidoarjo.Text = "Sidoarjo"
        '
        'rbProsesPresensiFaceSDA
        '
        Me.rbProsesPresensiFaceSDA.AutoSize = True
        Me.rbProsesPresensiFaceSDA.Location = New System.Drawing.Point(6, 12)
        Me.rbProsesPresensiFaceSDA.Name = "rbProsesPresensiFaceSDA"
        Me.rbProsesPresensiFaceSDA.Size = New System.Drawing.Size(74, 17)
        Me.rbProsesPresensiFaceSDA.TabIndex = 110
        Me.rbProsesPresensiFaceSDA.Text = "Face SDA"
        Me.rbProsesPresensiFaceSDA.UseVisualStyleBackColor = True
        '
        'rbProsesPresensiFingerSDA
        '
        Me.rbProsesPresensiFingerSDA.AutoSize = True
        Me.rbProsesPresensiFingerSDA.Location = New System.Drawing.Point(86, 12)
        Me.rbProsesPresensiFingerSDA.Name = "rbProsesPresensiFingerSDA"
        Me.rbProsesPresensiFingerSDA.Size = New System.Drawing.Size(79, 17)
        Me.rbProsesPresensiFingerSDA.TabIndex = 111
        Me.rbProsesPresensiFingerSDA.Text = "Finger SDA"
        Me.rbProsesPresensiFingerSDA.UseVisualStyleBackColor = True
        '
        'rbProsesPresensiPandaan
        '
        Me.rbProsesPresensiPandaan.AutoSize = True
        Me.rbProsesPresensiPandaan.Location = New System.Drawing.Point(59, 58)
        Me.rbProsesPresensiPandaan.Name = "rbProsesPresensiPandaan"
        Me.rbProsesPresensiPandaan.Size = New System.Drawing.Size(68, 17)
        Me.rbProsesPresensiPandaan.TabIndex = 223
        Me.rbProsesPresensiPandaan.Text = "Pandaan"
        Me.rbProsesPresensiPandaan.UseVisualStyleBackColor = True
        '
        'pnlLoading
        '
        Me.pnlLoading.Controls.Add(Me.pbLoading)
        Me.pnlLoading.Controls.Add(Me.lblTanggalProses)
        Me.pnlLoading.Controls.Add(Me.lblTotal)
        Me.pnlLoading.Controls.Add(Me.lblPer)
        Me.pnlLoading.Controls.Add(Me.lblCount)
        Me.pnlLoading.Location = New System.Drawing.Point(3, 206)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(733, 68)
        Me.pnlLoading.TabIndex = 125
        Me.pnlLoading.Visible = False
        '
        'pbLoading
        '
        Me.pbLoading.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbLoading.Location = New System.Drawing.Point(3, 39)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(727, 23)
        Me.pbLoading.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbLoading.TabIndex = 2
        '
        'lblTanggalProses
        '
        Me.lblTanggalProses.AutoSize = True
        Me.lblTanggalProses.Location = New System.Drawing.Point(287, 5)
        Me.lblTanggalProses.Name = "lblTanggalProses"
        Me.lblTanggalProses.Size = New System.Drawing.Size(81, 13)
        Me.lblTanggalProses.TabIndex = 126
        Me.lblTanggalProses.Text = "Tanggal Proses"
        Me.lblTanggalProses.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(341, 23)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(31, 13)
        Me.lblTotal.TabIndex = 5
        Me.lblTotal.Text = "Total"
        '
        'lblPer
        '
        Me.lblPer.AutoSize = True
        Me.lblPer.Location = New System.Drawing.Point(317, 23)
        Me.lblPer.Name = "lblPer"
        Me.lblPer.Size = New System.Drawing.Size(18, 13)
        Me.lblPer.TabIndex = 4
        Me.lblPer.Text = " / "
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(272, 23)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(35, 13)
        Me.lblCount.TabIndex = 3
        Me.lblCount.Text = "Count"
        '
        'btnProsesFP
        '
        Me.btnProsesFP.Location = New System.Drawing.Point(278, 177)
        Me.btnProsesFP.Name = "btnProsesFP"
        Me.btnProsesFP.Size = New System.Drawing.Size(90, 23)
        Me.btnProsesFP.TabIndex = 10
        Me.btnProsesFP.Text = "4. PROSES"
        Me.btnProsesFP.UseVisualStyleBackColor = True
        '
        'lblProsesFP
        '
        Me.lblProsesFP.AutoSize = True
        Me.lblProsesFP.Location = New System.Drawing.Point(14, 182)
        Me.lblProsesFP.Name = "lblProsesFP"
        Me.lblProsesFP.Size = New System.Drawing.Size(177, 13)
        Me.lblProsesFP.TabIndex = 124
        Me.lblProsesFP.Text = "4. PROSES FINGERPRINT / FACE"
        '
        'lblUpdateIjinLemburSPK
        '
        Me.lblUpdateIjinLemburSPK.AutoSize = True
        Me.lblUpdateIjinLemburSPK.Location = New System.Drawing.Point(14, 153)
        Me.lblUpdateIjinLemburSPK.Name = "lblUpdateIjinLemburSPK"
        Me.lblUpdateIjinLemburSPK.Size = New System.Drawing.Size(258, 13)
        Me.lblUpdateIjinLemburSPK.TabIndex = 122
        Me.lblUpdateIjinLemburSPK.Text = "3. UPDATE LIBUR, IJIN, LEMBUR, SPK, DAN CUTI"
        '
        'btnUpdateIjinLemburSPK
        '
        Me.btnUpdateIjinLemburSPK.Location = New System.Drawing.Point(278, 148)
        Me.btnUpdateIjinLemburSPK.Name = "btnUpdateIjinLemburSPK"
        Me.btnUpdateIjinLemburSPK.Size = New System.Drawing.Size(90, 23)
        Me.btnUpdateIjinLemburSPK.TabIndex = 9
        Me.btnUpdateIjinLemburSPK.Text = "3. PROSES"
        Me.btnUpdateIjinLemburSPK.UseVisualStyleBackColor = True
        '
        'lblTarikDataKaryawan
        '
        Me.lblTarikDataKaryawan.AutoSize = True
        Me.lblTarikDataKaryawan.Location = New System.Drawing.Point(14, 124)
        Me.lblTarikDataKaryawan.Name = "lblTarikDataKaryawan"
        Me.lblTarikDataKaryawan.Size = New System.Drawing.Size(148, 13)
        Me.lblTarikDataKaryawan.TabIndex = 120
        Me.lblTarikDataKaryawan.Text = "2. TARIK DATA KARYAWAN"
        '
        'btnTarikDataKaryawan
        '
        Me.btnTarikDataKaryawan.Location = New System.Drawing.Point(278, 119)
        Me.btnTarikDataKaryawan.Name = "btnTarikDataKaryawan"
        Me.btnTarikDataKaryawan.Size = New System.Drawing.Size(90, 23)
        Me.btnTarikDataKaryawan.TabIndex = 8
        Me.btnTarikDataKaryawan.Text = "2. PROSES"
        Me.btnTarikDataKaryawan.UseVisualStyleBackColor = True
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(294, 12)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(21, 13)
        Me.lblSD.TabIndex = 118
        Me.lblSD.Text = "s.d"
        '
        'dtpPeriodeAkhir
        '
        Me.dtpPeriodeAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPeriodeAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodeAkhir.Location = New System.Drawing.Point(321, 6)
        Me.dtpPeriodeAkhir.Name = "dtpPeriodeAkhir"
        Me.dtpPeriodeAkhir.Size = New System.Drawing.Size(120, 20)
        Me.dtpPeriodeAkhir.TabIndex = 2
        '
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Location = New System.Drawing.Point(111, 35)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(51, 13)
        Me.lblLokasi.TabIndex = 116
        Me.lblLokasi.Text = "LOKASI :"
        '
        'cboLokasi
        '
        Me.cboLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLokasi.FormattingEnabled = True
        Me.cboLokasi.IntegralHeight = False
        Me.cboLokasi.Location = New System.Drawing.Point(168, 32)
        Me.cboLokasi.Name = "cboLokasi"
        Me.cboLokasi.Size = New System.Drawing.Size(146, 21)
        Me.cboLokasi.TabIndex = 3
        '
        'lblPeriode
        '
        Me.lblPeriode.AutoSize = True
        Me.lblPeriode.Location = New System.Drawing.Point(101, 12)
        Me.lblPeriode.Name = "lblPeriode"
        Me.lblPeriode.Size = New System.Drawing.Size(61, 13)
        Me.lblPeriode.TabIndex = 114
        Me.lblPeriode.Text = "PERIODE :"
        '
        'dtpPeriodeAwal
        '
        Me.dtpPeriodeAwal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPeriodeAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodeAwal.Location = New System.Drawing.Point(168, 6)
        Me.dtpPeriodeAwal.Name = "dtpPeriodeAwal"
        Me.dtpPeriodeAwal.Size = New System.Drawing.Size(120, 20)
        Me.dtpPeriodeAwal.TabIndex = 1
        '
        'tpImportDataFingerFace
        '
        Me.tpImportDataFingerFace.Controls.Add(Me.gbImportExcel)
        Me.tpImportDataFingerFace.Location = New System.Drawing.Point(4, 22)
        Me.tpImportDataFingerFace.Name = "tpImportDataFingerFace"
        Me.tpImportDataFingerFace.Padding = New System.Windows.Forms.Padding(3)
        Me.tpImportDataFingerFace.Size = New System.Drawing.Size(749, 284)
        Me.tpImportDataFingerFace.TabIndex = 1
        Me.tpImportDataFingerFace.Text = "IMPORT DATA FINGERPRINT / FACE"
        Me.tpImportDataFingerFace.UseVisualStyleBackColor = True
        '
        'gbImportExcel
        '
        Me.gbImportExcel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbImportExcel.Controls.Add(Me.gbImportDataPandaan)
        Me.gbImportExcel.Controls.Add(Me.gbImportDataSidoarjo)
        Me.gbImportExcel.Controls.Add(Me.rbImportDataPandaan)
        Me.gbImportExcel.Controls.Add(Me.rbImportDataSidoarjo)
        Me.gbImportExcel.Controls.Add(Me.Label2)
        Me.gbImportExcel.Controls.Add(Me.btnPreview)
        Me.gbImportExcel.Controls.Add(Me.lblImportDataMesin)
        Me.gbImportExcel.Controls.Add(Me.lblTanggal)
        Me.gbImportExcel.Controls.Add(Me.dtpTanggal)
        Me.gbImportExcel.Controls.Add(Me.tbNamaFile)
        Me.gbImportExcel.Controls.Add(Me.btnProsesImport)
        Me.gbImportExcel.Controls.Add(Me.lblNamaFile)
        Me.gbImportExcel.Controls.Add(Me.btnBrowse)
        Me.gbImportExcel.Controls.Add(Me.lblNamaSheet)
        Me.gbImportExcel.Controls.Add(Me.tbNamaSheet)
        Me.gbImportExcel.Location = New System.Drawing.Point(6, 6)
        Me.gbImportExcel.Name = "gbImportExcel"
        Me.gbImportExcel.Size = New System.Drawing.Size(741, 268)
        Me.gbImportExcel.TabIndex = 196
        Me.gbImportExcel.TabStop = False
        Me.gbImportExcel.Text = "IMPORT EXCEL"
        '
        'gbImportDataPandaan
        '
        Me.gbImportDataPandaan.Controls.Add(Me.rbImportDataFingerspot)
        Me.gbImportDataPandaan.Controls.Add(Me.rbImportDataAttendanceManagement)
        Me.gbImportDataPandaan.Controls.Add(Me.rbImportDataBioTime)
        Me.gbImportDataPandaan.Location = New System.Drawing.Point(660, 191)
        Me.gbImportDataPandaan.Name = "gbImportDataPandaan"
        Me.gbImportDataPandaan.Size = New System.Drawing.Size(67, 35)
        Me.gbImportDataPandaan.TabIndex = 224
        Me.gbImportDataPandaan.TabStop = False
        Me.gbImportDataPandaan.Text = "Pandaan"
        Me.gbImportDataPandaan.Visible = False
        '
        'rbImportDataFingerspot
        '
        Me.rbImportDataFingerspot.AutoSize = True
        Me.rbImportDataFingerspot.Location = New System.Drawing.Point(6, 12)
        Me.rbImportDataFingerspot.Name = "rbImportDataFingerspot"
        Me.rbImportDataFingerspot.Size = New System.Drawing.Size(94, 17)
        Me.rbImportDataFingerspot.TabIndex = 113
        Me.rbImportDataFingerspot.Text = "FINGERSPOT"
        Me.rbImportDataFingerspot.UseVisualStyleBackColor = True
        '
        'rbImportDataAttendanceManagement
        '
        Me.rbImportDataAttendanceManagement.AutoSize = True
        Me.rbImportDataAttendanceManagement.Location = New System.Drawing.Point(106, 12)
        Me.rbImportDataAttendanceManagement.Name = "rbImportDataAttendanceManagement"
        Me.rbImportDataAttendanceManagement.Size = New System.Drawing.Size(178, 17)
        Me.rbImportDataAttendanceManagement.TabIndex = 114
        Me.rbImportDataAttendanceManagement.Text = "ATTENDANCE MANAGEMENT"
        Me.rbImportDataAttendanceManagement.UseVisualStyleBackColor = True
        '
        'rbImportDataBioTime
        '
        Me.rbImportDataBioTime.AutoSize = True
        Me.rbImportDataBioTime.Location = New System.Drawing.Point(290, 12)
        Me.rbImportDataBioTime.Name = "rbImportDataBioTime"
        Me.rbImportDataBioTime.Size = New System.Drawing.Size(72, 17)
        Me.rbImportDataBioTime.TabIndex = 112
        Me.rbImportDataBioTime.Text = "BIO TIME"
        Me.rbImportDataBioTime.UseVisualStyleBackColor = True
        '
        'gbImportDataSidoarjo
        '
        Me.gbImportDataSidoarjo.Controls.Add(Me.rbImportDataFingerKahuripan)
        Me.gbImportDataSidoarjo.Controls.Add(Me.rbImportDataFaceSDA)
        Me.gbImportDataSidoarjo.Location = New System.Drawing.Point(187, 65)
        Me.gbImportDataSidoarjo.Name = "gbImportDataSidoarjo"
        Me.gbImportDataSidoarjo.Size = New System.Drawing.Size(136, 35)
        Me.gbImportDataSidoarjo.TabIndex = 223
        Me.gbImportDataSidoarjo.TabStop = False
        Me.gbImportDataSidoarjo.Text = "Sidoarjo"
        '
        'rbImportDataFingerKahuripan
        '
        Me.rbImportDataFingerKahuripan.AutoSize = True
        Me.rbImportDataFingerKahuripan.Location = New System.Drawing.Point(6, 13)
        Me.rbImportDataFingerKahuripan.Name = "rbImportDataFingerKahuripan"
        Me.rbImportDataFingerKahuripan.Size = New System.Drawing.Size(131, 17)
        Me.rbImportDataFingerKahuripan.TabIndex = 30
        Me.rbImportDataFingerKahuripan.Text = "FINGER KAHURIPAN"
        Me.rbImportDataFingerKahuripan.UseVisualStyleBackColor = True
        '
        'rbImportDataFaceSDA
        '
        Me.rbImportDataFaceSDA.AutoSize = True
        Me.rbImportDataFaceSDA.Location = New System.Drawing.Point(143, 13)
        Me.rbImportDataFaceSDA.Name = "rbImportDataFaceSDA"
        Me.rbImportDataFaceSDA.Size = New System.Drawing.Size(77, 17)
        Me.rbImportDataFaceSDA.TabIndex = 110
        Me.rbImportDataFaceSDA.Text = "FACE SDA"
        Me.rbImportDataFaceSDA.UseVisualStyleBackColor = True
        Me.rbImportDataFaceSDA.Visible = False
        '
        'rbImportDataPandaan
        '
        Me.rbImportDataPandaan.AutoSize = True
        Me.rbImportDataPandaan.Location = New System.Drawing.Point(577, 203)
        Me.rbImportDataPandaan.Name = "rbImportDataPandaan"
        Me.rbImportDataPandaan.Size = New System.Drawing.Size(77, 17)
        Me.rbImportDataPandaan.TabIndex = 221
        Me.rbImportDataPandaan.Text = "PANDAAN"
        Me.rbImportDataPandaan.UseVisualStyleBackColor = True
        Me.rbImportDataPandaan.Visible = False
        '
        'rbImportDataSidoarjo
        '
        Me.rbImportDataSidoarjo.AutoSize = True
        Me.rbImportDataSidoarjo.Location = New System.Drawing.Point(104, 78)
        Me.rbImportDataSidoarjo.Name = "rbImportDataSidoarjo"
        Me.rbImportDataSidoarjo.Size = New System.Drawing.Size(79, 17)
        Me.rbImportDataSidoarjo.TabIndex = 29
        Me.rbImportDataSidoarjo.Text = "SIDOARJO"
        Me.rbImportDataSidoarjo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(293, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "*"
        '
        'btnPreview
        '
        Me.btnPreview.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.Location = New System.Drawing.Point(525, 11)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnPreview.TabIndex = 27
        Me.btnPreview.Text = "LIHAT"
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'lblImportDataMesin
        '
        Me.lblImportDataMesin.AutoSize = True
        Me.lblImportDataMesin.Location = New System.Drawing.Point(57, 78)
        Me.lblImportDataMesin.Name = "lblImportDataMesin"
        Me.lblImportDataMesin.Size = New System.Drawing.Size(41, 13)
        Me.lblImportDataMesin.TabIndex = 113
        Me.lblImportDataMesin.Text = "Mesin :"
        '
        'lblTanggal
        '
        Me.lblTanggal.AutoSize = True
        Me.lblTanggal.Location = New System.Drawing.Point(46, 107)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(52, 13)
        Me.lblTanggal.TabIndex = 112
        Me.lblTanggal.Text = "Tanggal :"
        '
        'dtpTanggal
        '
        Me.dtpTanggal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggal.Location = New System.Drawing.Point(104, 101)
        Me.dtpTanggal.Name = "dtpTanggal"
        Me.dtpTanggal.Size = New System.Drawing.Size(120, 20)
        Me.dtpTanggal.TabIndex = 31
        '
        'tbNamaFile
        '
        Me.tbNamaFile.Location = New System.Drawing.Point(104, 13)
        Me.tbNamaFile.Name = "tbNamaFile"
        Me.tbNamaFile.Size = New System.Drawing.Size(385, 20)
        Me.tbNamaFile.TabIndex = 25
        '
        'btnProsesImport
        '
        Me.btnProsesImport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnProsesImport.Image = CType(resources.GetObject("btnProsesImport.Image"), System.Drawing.Image)
        Me.btnProsesImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProsesImport.Location = New System.Drawing.Point(104, 127)
        Me.btnProsesImport.Name = "btnProsesImport"
        Me.btnProsesImport.Size = New System.Drawing.Size(120, 54)
        Me.btnProsesImport.TabIndex = 32
        Me.btnProsesImport.Text = "IMPORT"
        Me.btnProsesImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesImport.UseVisualStyleBackColor = True
        '
        'lblNamaFile
        '
        Me.lblNamaFile.AutoSize = True
        Me.lblNamaFile.Location = New System.Drawing.Point(9, 16)
        Me.lblNamaFile.Name = "lblNamaFile"
        Me.lblNamaFile.Size = New System.Drawing.Size(89, 13)
        Me.lblNamaFile.TabIndex = 108
        Me.lblNamaFile.Text = "Nama File Excel :"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(495, 11)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 23)
        Me.btnBrowse.TabIndex = 26
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblNamaSheet
        '
        Me.lblNamaSheet.AutoSize = True
        Me.lblNamaSheet.Location = New System.Drawing.Point(26, 42)
        Me.lblNamaSheet.Name = "lblNamaSheet"
        Me.lblNamaSheet.Size = New System.Drawing.Size(72, 13)
        Me.lblNamaSheet.TabIndex = 109
        Me.lblNamaSheet.Text = "Nama Sheet :"
        '
        'tbNamaSheet
        '
        Me.tbNamaSheet.Location = New System.Drawing.Point(104, 39)
        Me.tbNamaSheet.Name = "tbNamaSheet"
        Me.tbNamaSheet.Size = New System.Drawing.Size(183, 20)
        Me.tbNamaSheet.TabIndex = 28
        Me.tbNamaSheet.Text = "Sheet1"
        '
        'tpPrintOut
        '
        Me.tpPrintOut.Controls.Add(Me.Label5)
        Me.tpPrintOut.Controls.Add(Me.Label4)
        Me.tpPrintOut.Controls.Add(Me.Label6)
        Me.tpPrintOut.Controls.Add(Me.rbJadwalPresensi)
        Me.tpPrintOut.Controls.Add(Me.rbLaporanKaryawanTidakMasukHarian)
        Me.tpPrintOut.Controls.Add(Me.rbRekapDataPresensi)
        Me.tpPrintOut.Controls.Add(Me.cboDepartemenCetak)
        Me.tpPrintOut.Controls.Add(Me.rbDataMentah)
        Me.tpPrintOut.Controls.Add(Me.cboDaftarMesinCetak)
        Me.tpPrintOut.Controls.Add(Me.rbDataPresensi)
        Me.tpPrintOut.Controls.Add(Me.rbLaporanPresensiStaff)
        Me.tpPrintOut.Controls.Add(Me.lblLokasiCetak)
        Me.tpPrintOut.Controls.Add(Me.cboLokasiCetak)
        Me.tpPrintOut.Controls.Add(Me.dtpTanggalCetakAkhir)
        Me.tpPrintOut.Controls.Add(Me.cboPerusahaanCetak)
        Me.tpPrintOut.Controls.Add(Me.rbLaporanPresensiKaryawanMingguan)
        Me.tpPrintOut.Controls.Add(Me.Label1)
        Me.tpPrintOut.Controls.Add(Me.btnCetak)
        Me.tpPrintOut.Controls.Add(Me.rbLaporanPresensiSecurity)
        Me.tpPrintOut.Controls.Add(Me.lblPeriodeCetak)
        Me.tpPrintOut.Controls.Add(Me.dtpTanggalCetakAwal)
        Me.tpPrintOut.Location = New System.Drawing.Point(4, 22)
        Me.tpPrintOut.Name = "tpPrintOut"
        Me.tpPrintOut.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPrintOut.Size = New System.Drawing.Size(749, 284)
        Me.tpPrintOut.TabIndex = 2
        Me.tpPrintOut.Text = "PRINT OUT"
        Me.tpPrintOut.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(739, 13)
        Me.Label5.TabIndex = 238
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(739, 13)
        Me.Label4.TabIndex = 237
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(739, 13)
        Me.Label6.TabIndex = 236
        Me.Label6.Text = resources.GetString("Label6.Text")
        '
        'rbJadwalPresensi
        '
        Me.rbJadwalPresensi.AutoSize = True
        Me.rbJadwalPresensi.Location = New System.Drawing.Point(163, 41)
        Me.rbJadwalPresensi.Name = "rbJadwalPresensi"
        Me.rbJadwalPresensi.Size = New System.Drawing.Size(126, 17)
        Me.rbJadwalPresensi.TabIndex = 235
        Me.rbJadwalPresensi.Text = "JADWAL PRESENSI"
        Me.rbJadwalPresensi.UseVisualStyleBackColor = True
        '
        'rbLaporanKaryawanTidakMasukHarian
        '
        Me.rbLaporanKaryawanTidakMasukHarian.AutoSize = True
        Me.rbLaporanKaryawanTidakMasukHarian.Location = New System.Drawing.Point(8, 162)
        Me.rbLaporanKaryawanTidakMasukHarian.Name = "rbLaporanKaryawanTidakMasukHarian"
        Me.rbLaporanKaryawanTidakMasukHarian.Size = New System.Drawing.Size(261, 17)
        Me.rbLaporanKaryawanTidakMasukHarian.TabIndex = 23
        Me.rbLaporanKaryawanTidakMasukHarian.Text = "LAPORAN KARYAWAN TIDAK MASUK HARIAN"
        Me.rbLaporanKaryawanTidakMasukHarian.UseVisualStyleBackColor = True
        '
        'rbRekapDataPresensi
        '
        Me.rbRekapDataPresensi.AutoSize = True
        Me.rbRekapDataPresensi.Location = New System.Drawing.Point(8, 139)
        Me.rbRekapDataPresensi.Name = "rbRekapDataPresensi"
        Me.rbRekapDataPresensi.Size = New System.Drawing.Size(150, 17)
        Me.rbRekapDataPresensi.TabIndex = 22
        Me.rbRekapDataPresensi.Text = "REKAP DATA PRESENSI"
        Me.rbRekapDataPresensi.UseVisualStyleBackColor = True
        '
        'cboDepartemenCetak
        '
        Me.cboDepartemenCetak.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDepartemenCetak.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDepartemenCetak.FormattingEnabled = True
        Me.cboDepartemenCetak.IntegralHeight = False
        Me.cboDepartemenCetak.Location = New System.Drawing.Point(505, 41)
        Me.cboDepartemenCetak.Name = "cboDepartemenCetak"
        Me.cboDepartemenCetak.Size = New System.Drawing.Size(214, 21)
        Me.cboDepartemenCetak.TabIndex = 18
        '
        'rbDataMentah
        '
        Me.rbDataMentah.AutoSize = True
        Me.rbDataMentah.Location = New System.Drawing.Point(125, 100)
        Me.rbDataMentah.Name = "rbDataMentah"
        Me.rbDataMentah.Size = New System.Drawing.Size(103, 17)
        Me.rbDataMentah.TabIndex = 20
        Me.rbDataMentah.Text = "DATA MENTAH"
        Me.rbDataMentah.UseVisualStyleBackColor = True
        '
        'cboDaftarMesinCetak
        '
        Me.cboDaftarMesinCetak.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDaftarMesinCetak.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDaftarMesinCetak.FormattingEnabled = True
        Me.cboDaftarMesinCetak.IntegralHeight = False
        Me.cboDaftarMesinCetak.Location = New System.Drawing.Point(295, 99)
        Me.cboDaftarMesinCetak.Name = "cboDaftarMesinCetak"
        Me.cboDaftarMesinCetak.Size = New System.Drawing.Size(189, 21)
        Me.cboDaftarMesinCetak.TabIndex = 21
        '
        'rbDataPresensi
        '
        Me.rbDataPresensi.AutoSize = True
        Me.rbDataPresensi.Location = New System.Drawing.Point(8, 100)
        Me.rbDataPresensi.Name = "rbDataPresensi"
        Me.rbDataPresensi.Size = New System.Drawing.Size(111, 17)
        Me.rbDataPresensi.TabIndex = 19
        Me.rbDataPresensi.Text = "DATA PRESENSI"
        Me.rbDataPresensi.UseVisualStyleBackColor = True
        '
        'rbLaporanPresensiStaff
        '
        Me.rbLaporanPresensiStaff.AutoSize = True
        Me.rbLaporanPresensiStaff.Location = New System.Drawing.Point(8, 64)
        Me.rbLaporanPresensiStaff.Name = "rbLaporanPresensiStaff"
        Me.rbLaporanPresensiStaff.Size = New System.Drawing.Size(58, 17)
        Me.rbLaporanPresensiStaff.TabIndex = 15
        Me.rbLaporanPresensiStaff.Text = "STAFF"
        Me.rbLaporanPresensiStaff.UseVisualStyleBackColor = True
        '
        'lblLokasiCetak
        '
        Me.lblLokasiCetak.AutoSize = True
        Me.lblLokasiCetak.Location = New System.Drawing.Point(352, 8)
        Me.lblLokasiCetak.Name = "lblLokasiCetak"
        Me.lblLokasiCetak.Size = New System.Drawing.Size(51, 13)
        Me.lblLokasiCetak.TabIndex = 230
        Me.lblLokasiCetak.Text = "LOKASI :"
        '
        'cboLokasiCetak
        '
        Me.cboLokasiCetak.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasiCetak.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasiCetak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLokasiCetak.FormattingEnabled = True
        Me.cboLokasiCetak.IntegralHeight = False
        Me.cboLokasiCetak.Location = New System.Drawing.Point(409, 5)
        Me.cboLokasiCetak.Name = "cboLokasiCetak"
        Me.cboLokasiCetak.Size = New System.Drawing.Size(107, 21)
        Me.cboLokasiCetak.TabIndex = 13
        '
        'dtpTanggalCetakAkhir
        '
        Me.dtpTanggalCetakAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalCetakAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalCetakAkhir.Location = New System.Drawing.Point(228, 6)
        Me.dtpTanggalCetakAkhir.Name = "dtpTanggalCetakAkhir"
        Me.dtpTanggalCetakAkhir.Size = New System.Drawing.Size(120, 20)
        Me.dtpTanggalCetakAkhir.TabIndex = 12
        '
        'cboPerusahaanCetak
        '
        Me.cboPerusahaanCetak.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPerusahaanCetak.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPerusahaanCetak.FormattingEnabled = True
        Me.cboPerusahaanCetak.IntegralHeight = False
        Me.cboPerusahaanCetak.Location = New System.Drawing.Point(295, 40)
        Me.cboPerusahaanCetak.Name = "cboPerusahaanCetak"
        Me.cboPerusahaanCetak.Size = New System.Drawing.Size(204, 21)
        Me.cboPerusahaanCetak.TabIndex = 17
        '
        'rbLaporanPresensiKaryawanMingguan
        '
        Me.rbLaporanPresensiKaryawanMingguan.AutoSize = True
        Me.rbLaporanPresensiKaryawanMingguan.Location = New System.Drawing.Point(8, 41)
        Me.rbLaporanPresensiKaryawanMingguan.Name = "rbLaporanPresensiKaryawanMingguan"
        Me.rbLaporanPresensiKaryawanMingguan.Size = New System.Drawing.Size(149, 17)
        Me.rbLaporanPresensiKaryawanMingguan.TabIndex = 14
        Me.rbLaporanPresensiKaryawanMingguan.Text = "KARYAWAN MINGGUAN"
        Me.rbLaporanPresensiKaryawanMingguan.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(201, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 233
        Me.Label1.Text = "s.d"
        '
        'btnCetak
        '
        Me.btnCetak.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCetak.Image = CType(resources.GetObject("btnCetak.Image"), System.Drawing.Image)
        Me.btnCetak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetak.Location = New System.Drawing.Point(295, 220)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(120, 54)
        Me.btnCetak.TabIndex = 24
        Me.btnCetak.Text = "CETAK"
        Me.btnCetak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetak.UseVisualStyleBackColor = True
        '
        'rbLaporanPresensiSecurity
        '
        Me.rbLaporanPresensiSecurity.AutoSize = True
        Me.rbLaporanPresensiSecurity.Location = New System.Drawing.Point(72, 64)
        Me.rbLaporanPresensiSecurity.Name = "rbLaporanPresensiSecurity"
        Me.rbLaporanPresensiSecurity.Size = New System.Drawing.Size(79, 17)
        Me.rbLaporanPresensiSecurity.TabIndex = 16
        Me.rbLaporanPresensiSecurity.Text = "SECURITY"
        Me.rbLaporanPresensiSecurity.UseVisualStyleBackColor = True
        '
        'lblPeriodeCetak
        '
        Me.lblPeriodeCetak.AutoSize = True
        Me.lblPeriodeCetak.Location = New System.Drawing.Point(8, 12)
        Me.lblPeriodeCetak.Name = "lblPeriodeCetak"
        Me.lblPeriodeCetak.Size = New System.Drawing.Size(61, 13)
        Me.lblPeriodeCetak.TabIndex = 232
        Me.lblPeriodeCetak.Text = "PERIODE :"
        '
        'dtpTanggalCetakAwal
        '
        Me.dtpTanggalCetakAwal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalCetakAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalCetakAwal.Location = New System.Drawing.Point(75, 6)
        Me.dtpTanggalCetakAwal.Name = "dtpTanggalCetakAwal"
        Me.dtpTanggalCetakAwal.Size = New System.Drawing.Size(120, 20)
        Me.dtpTanggalCetakAwal.TabIndex = 11
        '
        'ofd1
        '
        '
        'FormProsesPresensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(781, 336)
        Me.Controls.Add(Me.tcPresensi)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormProsesPresensi"
        Me.Text = "FORM PROSES PRESENSI"
        Me.tcPresensi.ResumeLayout(False)
        Me.tpProsesAbsen.ResumeLayout(False)
        Me.tpProsesAbsen.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbProsesPresensiPandaan.ResumeLayout(False)
        Me.gbProsesPresensiPandaan.PerformLayout()
        Me.gbProsesPresensiSidoarjo.ResumeLayout(False)
        Me.gbProsesPresensiSidoarjo.PerformLayout()
        Me.pnlLoading.ResumeLayout(False)
        Me.pnlLoading.PerformLayout()
        Me.tpImportDataFingerFace.ResumeLayout(False)
        Me.gbImportExcel.ResumeLayout(False)
        Me.gbImportExcel.PerformLayout()
        Me.gbImportDataPandaan.ResumeLayout(False)
        Me.gbImportDataPandaan.PerformLayout()
        Me.gbImportDataSidoarjo.ResumeLayout(False)
        Me.gbImportDataSidoarjo.PerformLayout()
        Me.tpPrintOut.ResumeLayout(False)
        Me.tpPrintOut.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents tcPresensi As TabControl
    Friend WithEvents tpProsesAbsen As TabPage
    Friend WithEvents tpImportDataFingerFace As TabPage
    Friend WithEvents gbImportExcel As GroupBox
    Friend WithEvents rbImportDataFaceSDA As RadioButton
    Friend WithEvents tbNamaFile As TextBox
    Friend WithEvents btnProsesImport As Button
    Friend WithEvents lblNamaFile As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents lblNamaSheet As Label
    Friend WithEvents tbNamaSheet As TextBox
    Friend WithEvents rbImportDataFingerKahuripan As RadioButton
    Friend WithEvents ofd1 As OpenFileDialog
    Friend WithEvents dtpTanggal As DateTimePicker
    Friend WithEvents lblTanggal As Label
    Friend WithEvents lblImportDataMesin As Label
    Friend WithEvents btnPreview As Button
    Friend WithEvents lblPeriode As Label
    Friend WithEvents dtpPeriodeAwal As DateTimePicker
    Friend WithEvents cboLokasi As ComboBox
    Friend WithEvents lblLokasi As Label
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpPeriodeAkhir As DateTimePicker
    Friend WithEvents lblTarikDataKaryawan As Label
    Friend WithEvents btnTarikDataKaryawan As Button
    Friend WithEvents lblUpdateIjinLemburSPK As Label
    Friend WithEvents btnUpdateIjinLemburSPK As Button
    Friend WithEvents btnProsesFP As Button
    Friend WithEvents lblProsesFP As Label
    Friend WithEvents pnlLoading As Panel
    Friend WithEvents pbLoading As ProgressBar
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblPer As Label
    Friend WithEvents lblCount As Label
    Friend WithEvents lblTanggalProses As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblProsesAbsenMesin As Label
    Friend WithEvents rbProsesPresensiAttendanceManagement As RadioButton
    Friend WithEvents rbProsesPresensiFingerspot As RadioButton
    Friend WithEvents rbProsesAbsenBioTime As RadioButton
    Friend WithEvents rbProsesPresensiFingerSDA As RadioButton
    Friend WithEvents rbProsesPresensiFaceSDA As RadioButton
    Friend WithEvents rbImportDataSidoarjo As RadioButton
    Friend WithEvents gbImportDataSidoarjo As GroupBox
    Friend WithEvents rbProsesPresensiPandaan As RadioButton
    Friend WithEvents rbProsesPresensiSidoarjo As RadioButton
    Friend WithEvents gbProsesPresensiSidoarjo As GroupBox
    Friend WithEvents gbProsesPresensiPandaan As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tpPrintOut As TabPage
    Friend WithEvents lblLokasiCetak As Label
    Friend WithEvents cboLokasiCetak As ComboBox
    Friend WithEvents cboPerusahaanCetak As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpTanggalCetakAkhir As DateTimePicker
    Friend WithEvents lblPeriodeCetak As Label
    Friend WithEvents dtpTanggalCetakAwal As DateTimePicker
    Friend WithEvents rbLaporanPresensiSecurity As RadioButton
    Friend WithEvents btnCetak As Button
    Friend WithEvents rbLaporanPresensiKaryawanMingguan As RadioButton
    Friend WithEvents rbLaporanPresensiStaff As RadioButton
    Friend WithEvents rbDataPresensi As RadioButton
    Friend WithEvents cboDaftarMesinCetak As ComboBox
    Friend WithEvents rbDataMentah As RadioButton
    Friend WithEvents cboDepartemenCetak As ComboBox
    Friend WithEvents gbImportDataPandaan As GroupBox
    Friend WithEvents rbImportDataFingerspot As RadioButton
    Friend WithEvents rbImportDataAttendanceManagement As RadioButton
    Friend WithEvents rbImportDataBioTime As RadioButton
    Friend WithEvents rbImportDataPandaan As RadioButton
    Friend WithEvents rbRekapDataPresensi As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents btnTarikDataFingerprint As Button
    Friend WithEvents rbLaporanKaryawanTidakMasukHarian As RadioButton
    Friend WithEvents rbSemua As RadioButton
    Friend WithEvents rbKaryawan As RadioButton
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rbJadwalPresensi As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
