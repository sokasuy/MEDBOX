<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormView))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.lblKriteria = New System.Windows.Forms.Label()
        Me.lblKelompok = New System.Windows.Forms.Label()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.cboFilterPerusahaan = New System.Windows.Forms.ComboBox()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.cboKelompok = New System.Windows.Forms.ComboBox()
        Me.cboLokasi = New System.Windows.Forms.ComboBox()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbProsesCepat = New System.Windows.Forms.GroupBox()
        Me.cbTampilkanYangKosong = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlJamYangKosong = New System.Windows.Forms.Panel()
        Me.rbKosongJamMasukPulang = New System.Windows.Forms.RadioButton()
        Me.lblJamYangKosong = New System.Windows.Forms.Label()
        Me.rbKosongJamPulang = New System.Windows.Forms.RadioButton()
        Me.rbKosongJamMasuk = New System.Windows.Forms.RadioButton()
        Me.btnSesuaikanJamMasukKeluarCellTerpilih = New System.Windows.Forms.Button()
        Me.gbKodeIjinAbsen = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboMohonIjin = New System.Windows.Forms.ComboBox()
        Me.lblAbsen = New System.Windows.Forms.Label()
        Me.lblIjin = New System.Windows.Forms.Label()
        Me.cboAbsen = New System.Windows.Forms.ComboBox()
        Me.gbKosongkan = New System.Windows.Forms.GroupBox()
        Me.rbKosongkanSPK = New System.Windows.Forms.RadioButton()
        Me.btnNullkanData = New System.Windows.Forms.Button()
        Me.rbKosongkanLembur = New System.Windows.Forms.RadioButton()
        Me.rbKosongkanFP = New System.Windows.Forms.RadioButton()
        Me.gbSetJamInOut = New System.Windows.Forms.GroupBox()
        Me.lblDash = New System.Windows.Forms.Label()
        Me.lblJamYangDiset = New System.Windows.Forms.Label()
        Me.rbJamMasuk = New System.Windows.Forms.RadioButton()
        Me.btnProsesCepat = New System.Windows.Forms.Button()
        Me.rbJamMasukKeluar = New System.Windows.Forms.RadioButton()
        Me.dtpJamMasuk = New System.Windows.Forms.DateTimePicker()
        Me.rbJamKeluar = New System.Windows.Forms.RadioButton()
        Me.dtpJamKeluar = New System.Windows.Forms.DateTimePicker()
        Me.lblJamMasuk = New System.Windows.Forms.Label()
        Me.lblJamKeluar = New System.Windows.Forms.Label()
        Me.pnlTanggal = New System.Windows.Forms.Panel()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.dtpAkhir = New System.Windows.Forms.DateTimePicker()
        Me.dtpAwal = New System.Windows.Forms.DateTimePicker()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.pnlCetak = New System.Windows.Forms.Panel()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.btnCetak = New System.Windows.Forms.Button()
        Me.tbNamaSimpan = New System.Windows.Forms.TextBox()
        Me.tbPathSimpan = New System.Windows.Forms.TextBox()
        Me.lblNamaSimpan = New System.Windows.Forms.Label()
        Me.lblSimpanKeDrive = New System.Windows.Forms.Label()
        Me.fbdExport = New System.Windows.Forms.FolderBrowserDialog()
        Me.gbView.SuspendLayout()
        Me.gbProsesCepat.SuspendLayout()
        Me.pnlJamYangKosong.SuspendLayout()
        Me.gbKodeIjinAbsen.SuspendLayout()
        Me.gbKosongkan.SuspendLayout()
        Me.gbSetJamInOut.SuspendLayout()
        Me.pnlTanggal.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCetak.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(1334, 25)
        Me.lblTitle.TabIndex = 180
        Me.lblTitle.Text = "VIEW"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbView
        '
        Me.gbView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.lblKriteria)
        Me.gbView.Controls.Add(Me.lblKelompok)
        Me.gbView.Controls.Add(Me.lblPerusahaan)
        Me.gbView.Controls.Add(Me.cboFilterPerusahaan)
        Me.gbView.Controls.Add(Me.lblLokasi)
        Me.gbView.Controls.Add(Me.cboKelompok)
        Me.gbView.Controls.Add(Me.cboLokasi)
        Me.gbView.Controls.Add(Me.clbUserRight)
        Me.gbView.Controls.Add(Me.gbProsesCepat)
        Me.gbView.Controls.Add(Me.pnlTanggal)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 28)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(1310, 553)
        Me.gbView.TabIndex = 189
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'lblKriteria
        '
        Me.lblKriteria.AutoSize = True
        Me.lblKriteria.Location = New System.Drawing.Point(706, 14)
        Me.lblKriteria.Name = "lblKriteria"
        Me.lblKriteria.Size = New System.Drawing.Size(45, 13)
        Me.lblKriteria.TabIndex = 211
        Me.lblKriteria.Text = "Kriteria :"
        '
        'lblKelompok
        '
        Me.lblKelompok.AutoSize = True
        Me.lblKelompok.Location = New System.Drawing.Point(577, 14)
        Me.lblKelompok.Name = "lblKelompok"
        Me.lblKelompok.Size = New System.Drawing.Size(60, 13)
        Me.lblKelompok.TabIndex = 210
        Me.lblKelompok.Text = "Kelompok :"
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Location = New System.Drawing.Point(390, 14)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(70, 13)
        Me.lblPerusahaan.TabIndex = 209
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'cboFilterPerusahaan
        '
        Me.cboFilterPerusahaan.FormattingEnabled = True
        Me.cboFilterPerusahaan.IntegralHeight = False
        Me.cboFilterPerusahaan.Location = New System.Drawing.Point(393, 30)
        Me.cboFilterPerusahaan.Name = "cboFilterPerusahaan"
        Me.cboFilterPerusahaan.Size = New System.Drawing.Size(181, 21)
        Me.cboFilterPerusahaan.TabIndex = 4
        '
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Location = New System.Drawing.Point(294, 14)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(44, 13)
        Me.lblLokasi.TabIndex = 207
        Me.lblLokasi.Text = "Lokasi :"
        '
        'cboKelompok
        '
        Me.cboKelompok.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKelompok.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKelompok.FormattingEnabled = True
        Me.cboKelompok.Location = New System.Drawing.Point(580, 30)
        Me.cboKelompok.Name = "cboKelompok"
        Me.cboKelompok.Size = New System.Drawing.Size(123, 21)
        Me.cboKelompok.TabIndex = 5
        '
        'cboLokasi
        '
        Me.cboLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLokasi.FormattingEnabled = True
        Me.cboLokasi.Location = New System.Drawing.Point(297, 30)
        Me.cboLokasi.Name = "cboLokasi"
        Me.cboLokasi.Size = New System.Drawing.Size(90, 21)
        Me.cboLokasi.TabIndex = 3
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(1204, 12)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 191
        '
        'gbProsesCepat
        '
        Me.gbProsesCepat.Controls.Add(Me.cbTampilkanYangKosong)
        Me.gbProsesCepat.Controls.Add(Me.Label1)
        Me.gbProsesCepat.Controls.Add(Me.pnlJamYangKosong)
        Me.gbProsesCepat.Controls.Add(Me.btnSesuaikanJamMasukKeluarCellTerpilih)
        Me.gbProsesCepat.Controls.Add(Me.gbKodeIjinAbsen)
        Me.gbProsesCepat.Controls.Add(Me.gbKosongkan)
        Me.gbProsesCepat.Controls.Add(Me.gbSetJamInOut)
        Me.gbProsesCepat.Location = New System.Drawing.Point(6, 81)
        Me.gbProsesCepat.Name = "gbProsesCepat"
        Me.gbProsesCepat.Size = New System.Drawing.Size(1148, 116)
        Me.gbProsesCepat.TabIndex = 193
        Me.gbProsesCepat.TabStop = False
        Me.gbProsesCepat.Text = "PROSES CEPAT"
        '
        'cbTampilkanYangKosong
        '
        Me.cbTampilkanYangKosong.AutoSize = True
        Me.cbTampilkanYangKosong.Location = New System.Drawing.Point(6, 90)
        Me.cbTampilkanYangKosong.Name = "cbTampilkanYangKosong"
        Me.cbTampilkanYangKosong.Size = New System.Drawing.Size(139, 17)
        Me.cbTampilkanYangKosong.TabIndex = 206
        Me.cbTampilkanYangKosong.Text = "Tampilkan yang kosong"
        Me.cbTampilkanYangKosong.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(513, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 203
        Me.Label1.Text = "Klik kanan pada kolom"
        '
        'pnlJamYangKosong
        '
        Me.pnlJamYangKosong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlJamYangKosong.Controls.Add(Me.rbKosongJamMasukPulang)
        Me.pnlJamYangKosong.Controls.Add(Me.lblJamYangKosong)
        Me.pnlJamYangKosong.Controls.Add(Me.rbKosongJamPulang)
        Me.pnlJamYangKosong.Controls.Add(Me.rbKosongJamMasuk)
        Me.pnlJamYangKosong.Location = New System.Drawing.Point(151, 87)
        Me.pnlJamYangKosong.Name = "pnlJamYangKosong"
        Me.pnlJamYangKosong.Size = New System.Drawing.Size(429, 23)
        Me.pnlJamYangKosong.TabIndex = 205
        '
        'rbKosongJamMasukPulang
        '
        Me.rbKosongJamMasukPulang.AutoSize = True
        Me.rbKosongJamMasukPulang.Location = New System.Drawing.Point(283, 3)
        Me.rbKosongJamMasukPulang.Name = "rbKosongJamMasukPulang"
        Me.rbKosongJamMasukPulang.Size = New System.Drawing.Size(136, 17)
        Me.rbKosongJamMasukPulang.TabIndex = 10
        Me.rbKosongJamMasukPulang.TabStop = True
        Me.rbKosongJamMasukPulang.Text = "Jam Masuk dan Pulang"
        Me.rbKosongJamMasukPulang.UseVisualStyleBackColor = True
        '
        'lblJamYangKosong
        '
        Me.lblJamYangKosong.AutoSize = True
        Me.lblJamYangKosong.Location = New System.Drawing.Point(13, 5)
        Me.lblJamYangKosong.Name = "lblJamYangKosong"
        Me.lblJamYangKosong.Size = New System.Drawing.Size(96, 13)
        Me.lblJamYangKosong.TabIndex = 79
        Me.lblJamYangKosong.Text = "Jam yang kosong :"
        '
        'rbKosongJamPulang
        '
        Me.rbKosongJamPulang.AutoSize = True
        Me.rbKosongJamPulang.Location = New System.Drawing.Point(200, 3)
        Me.rbKosongJamPulang.Name = "rbKosongJamPulang"
        Me.rbKosongJamPulang.Size = New System.Drawing.Size(80, 17)
        Me.rbKosongJamPulang.TabIndex = 9
        Me.rbKosongJamPulang.TabStop = True
        Me.rbKosongJamPulang.Text = "Jam Pulang"
        Me.rbKosongJamPulang.UseVisualStyleBackColor = True
        '
        'rbKosongJamMasuk
        '
        Me.rbKosongJamMasuk.AutoSize = True
        Me.rbKosongJamMasuk.Location = New System.Drawing.Point(115, 3)
        Me.rbKosongJamMasuk.Name = "rbKosongJamMasuk"
        Me.rbKosongJamMasuk.Size = New System.Drawing.Size(79, 17)
        Me.rbKosongJamMasuk.TabIndex = 8
        Me.rbKosongJamMasuk.TabStop = True
        Me.rbKosongJamMasuk.Text = "Jam Masuk"
        Me.rbKosongJamMasuk.UseVisualStyleBackColor = True
        '
        'btnSesuaikanJamMasukKeluarCellTerpilih
        '
        Me.btnSesuaikanJamMasukKeluarCellTerpilih.Location = New System.Drawing.Point(662, 53)
        Me.btnSesuaikanJamMasukKeluarCellTerpilih.Name = "btnSesuaikanJamMasukKeluarCellTerpilih"
        Me.btnSesuaikanJamMasukKeluarCellTerpilih.Size = New System.Drawing.Size(287, 23)
        Me.btnSesuaikanJamMasukKeluarCellTerpilih.TabIndex = 14
        Me.btnSesuaikanJamMasukKeluarCellTerpilih.Text = "Sesuaikan jam masuk keluar cell terpilih dengan jadwal"
        Me.btnSesuaikanJamMasukKeluarCellTerpilih.UseVisualStyleBackColor = True
        '
        'gbKodeIjinAbsen
        '
        Me.gbKodeIjinAbsen.Controls.Add(Me.Label2)
        Me.gbKodeIjinAbsen.Controls.Add(Me.cboMohonIjin)
        Me.gbKodeIjinAbsen.Controls.Add(Me.lblAbsen)
        Me.gbKodeIjinAbsen.Controls.Add(Me.lblIjin)
        Me.gbKodeIjinAbsen.Controls.Add(Me.cboAbsen)
        Me.gbKodeIjinAbsen.Location = New System.Drawing.Point(441, 19)
        Me.gbKodeIjinAbsen.Name = "gbKodeIjinAbsen"
        Me.gbKodeIjinAbsen.Size = New System.Drawing.Size(215, 62)
        Me.gbKodeIjinAbsen.TabIndex = 202
        Me.gbKodeIjinAbsen.TabStop = False
        Me.gbKodeIjinAbsen.Text = "IJIN ABSEN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(72, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 206
        Me.Label2.Text = "untuk mengaplikasikan"
        '
        'cboMohonIjin
        '
        Me.cboMohonIjin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMohonIjin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMohonIjin.FormattingEnabled = True
        Me.cboMohonIjin.IntegralHeight = False
        Me.cboMohonIjin.Location = New System.Drawing.Point(53, 14)
        Me.cboMohonIjin.Name = "cboMohonIjin"
        Me.cboMohonIjin.Size = New System.Drawing.Size(157, 21)
        Me.cboMohonIjin.TabIndex = 12
        '
        'lblAbsen
        '
        Me.lblAbsen.AutoSize = True
        Me.lblAbsen.Location = New System.Drawing.Point(4, 40)
        Me.lblAbsen.Name = "lblAbsen"
        Me.lblAbsen.Size = New System.Drawing.Size(43, 13)
        Me.lblAbsen.TabIndex = 201
        Me.lblAbsen.Text = "Absen :"
        '
        'lblIjin
        '
        Me.lblIjin.AutoSize = True
        Me.lblIjin.Location = New System.Drawing.Point(21, 17)
        Me.lblIjin.Name = "lblIjin"
        Me.lblIjin.Size = New System.Drawing.Size(26, 13)
        Me.lblIjin.TabIndex = 199
        Me.lblIjin.Text = "Ijin :"
        '
        'cboAbsen
        '
        Me.cboAbsen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAbsen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAbsen.FormattingEnabled = True
        Me.cboAbsen.IntegralHeight = False
        Me.cboAbsen.Location = New System.Drawing.Point(53, 37)
        Me.cboAbsen.Name = "cboAbsen"
        Me.cboAbsen.Size = New System.Drawing.Size(157, 21)
        Me.cboAbsen.TabIndex = 13
        '
        'gbKosongkan
        '
        Me.gbKosongkan.Controls.Add(Me.rbKosongkanSPK)
        Me.gbKosongkan.Controls.Add(Me.btnNullkanData)
        Me.gbKosongkan.Controls.Add(Me.rbKosongkanLembur)
        Me.gbKosongkan.Controls.Add(Me.rbKosongkanFP)
        Me.gbKosongkan.Location = New System.Drawing.Point(976, 19)
        Me.gbKosongkan.Name = "gbKosongkan"
        Me.gbKosongkan.Size = New System.Drawing.Size(166, 62)
        Me.gbKosongkan.TabIndex = 197
        Me.gbKosongkan.TabStop = False
        Me.gbKosongkan.Text = "KOSONGKAN DATA"
        '
        'rbKosongkanSPK
        '
        Me.rbKosongkanSPK.AutoSize = True
        Me.rbKosongkanSPK.Location = New System.Drawing.Point(116, 16)
        Me.rbKosongkanSPK.Name = "rbKosongkanSPK"
        Me.rbKosongkanSPK.Size = New System.Drawing.Size(46, 17)
        Me.rbKosongkanSPK.TabIndex = 3
        Me.rbKosongkanSPK.Text = "SPK"
        Me.rbKosongkanSPK.UseVisualStyleBackColor = True
        '
        'btnNullkanData
        '
        Me.btnNullkanData.Location = New System.Drawing.Point(36, 34)
        Me.btnNullkanData.Name = "btnNullkanData"
        Me.btnNullkanData.Size = New System.Drawing.Size(74, 23)
        Me.btnNullkanData.TabIndex = 15
        Me.btnNullkanData.Text = "Kosongkan"
        Me.btnNullkanData.UseVisualStyleBackColor = True
        '
        'rbKosongkanLembur
        '
        Me.rbKosongkanLembur.AutoSize = True
        Me.rbKosongkanLembur.Location = New System.Drawing.Point(50, 16)
        Me.rbKosongkanLembur.Name = "rbKosongkanLembur"
        Me.rbKosongkanLembur.Size = New System.Drawing.Size(60, 17)
        Me.rbKosongkanLembur.TabIndex = 1
        Me.rbKosongkanLembur.Text = "Lembur"
        Me.rbKosongkanLembur.UseVisualStyleBackColor = True
        '
        'rbKosongkanFP
        '
        Me.rbKosongkanFP.AutoSize = True
        Me.rbKosongkanFP.Checked = True
        Me.rbKosongkanFP.Location = New System.Drawing.Point(6, 16)
        Me.rbKosongkanFP.Name = "rbKosongkanFP"
        Me.rbKosongkanFP.Size = New System.Drawing.Size(38, 17)
        Me.rbKosongkanFP.TabIndex = 0
        Me.rbKosongkanFP.TabStop = True
        Me.rbKosongkanFP.Text = "FP"
        Me.rbKosongkanFP.UseVisualStyleBackColor = True
        '
        'gbSetJamInOut
        '
        Me.gbSetJamInOut.Controls.Add(Me.lblDash)
        Me.gbSetJamInOut.Controls.Add(Me.lblJamYangDiset)
        Me.gbSetJamInOut.Controls.Add(Me.rbJamMasuk)
        Me.gbSetJamInOut.Controls.Add(Me.btnProsesCepat)
        Me.gbSetJamInOut.Controls.Add(Me.rbJamMasukKeluar)
        Me.gbSetJamInOut.Controls.Add(Me.dtpJamMasuk)
        Me.gbSetJamInOut.Controls.Add(Me.rbJamKeluar)
        Me.gbSetJamInOut.Controls.Add(Me.dtpJamKeluar)
        Me.gbSetJamInOut.Controls.Add(Me.lblJamMasuk)
        Me.gbSetJamInOut.Controls.Add(Me.lblJamKeluar)
        Me.gbSetJamInOut.Location = New System.Drawing.Point(6, 19)
        Me.gbSetJamInOut.Name = "gbSetJamInOut"
        Me.gbSetJamInOut.Size = New System.Drawing.Size(429, 62)
        Me.gbSetJamInOut.TabIndex = 194
        Me.gbSetJamInOut.TabStop = False
        Me.gbSetJamInOut.Text = "SET JAM IN OUT"
        '
        'lblDash
        '
        Me.lblDash.AutoSize = True
        Me.lblDash.Location = New System.Drawing.Point(162, 39)
        Me.lblDash.Name = "lblDash"
        Me.lblDash.Size = New System.Drawing.Size(10, 13)
        Me.lblDash.TabIndex = 85
        Me.lblDash.Text = "-"
        '
        'lblJamYangDiset
        '
        Me.lblJamYangDiset.AutoSize = True
        Me.lblJamYangDiset.Location = New System.Drawing.Point(16, 16)
        Me.lblJamYangDiset.Name = "lblJamYangDiset"
        Me.lblJamYangDiset.Size = New System.Drawing.Size(86, 13)
        Me.lblJamYangDiset.TabIndex = 79
        Me.lblJamYangDiset.Text = "Jam yang di set :"
        '
        'rbJamMasuk
        '
        Me.rbJamMasuk.AutoSize = True
        Me.rbJamMasuk.Location = New System.Drawing.Point(108, 14)
        Me.rbJamMasuk.Name = "rbJamMasuk"
        Me.rbJamMasuk.Size = New System.Drawing.Size(79, 17)
        Me.rbJamMasuk.TabIndex = 8
        Me.rbJamMasuk.Text = "Jam Masuk"
        Me.rbJamMasuk.UseVisualStyleBackColor = True
        '
        'btnProsesCepat
        '
        Me.btnProsesCepat.Location = New System.Drawing.Point(332, 34)
        Me.btnProsesCepat.Name = "btnProsesCepat"
        Me.btnProsesCepat.Size = New System.Drawing.Size(90, 23)
        Me.btnProsesCepat.TabIndex = 11
        Me.btnProsesCepat.Text = "Proses Cepat"
        Me.btnProsesCepat.UseVisualStyleBackColor = True
        '
        'rbJamMasukKeluar
        '
        Me.rbJamMasukKeluar.AutoSize = True
        Me.rbJamMasukKeluar.Location = New System.Drawing.Point(276, 14)
        Me.rbJamMasukKeluar.Name = "rbJamMasukKeluar"
        Me.rbJamMasukKeluar.Size = New System.Drawing.Size(133, 17)
        Me.rbJamMasukKeluar.TabIndex = 10
        Me.rbJamMasukKeluar.Text = "Jam Masuk dan Keluar"
        Me.rbJamMasukKeluar.UseVisualStyleBackColor = True
        '
        'dtpJamMasuk
        '
        Me.dtpJamMasuk.CustomFormat = "HH:mm"
        Me.dtpJamMasuk.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpJamMasuk.Location = New System.Drawing.Point(76, 35)
        Me.dtpJamMasuk.Name = "dtpJamMasuk"
        Me.dtpJamMasuk.Size = New System.Drawing.Size(80, 20)
        Me.dtpJamMasuk.TabIndex = 9
        '
        'rbJamKeluar
        '
        Me.rbJamKeluar.AutoSize = True
        Me.rbJamKeluar.Location = New System.Drawing.Point(193, 14)
        Me.rbJamKeluar.Name = "rbJamKeluar"
        Me.rbJamKeluar.Size = New System.Drawing.Size(77, 17)
        Me.rbJamKeluar.TabIndex = 9
        Me.rbJamKeluar.Text = "Jam Keluar"
        Me.rbJamKeluar.UseVisualStyleBackColor = True
        '
        'dtpJamKeluar
        '
        Me.dtpJamKeluar.CustomFormat = "HH:mm"
        Me.dtpJamKeluar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpJamKeluar.Location = New System.Drawing.Point(246, 35)
        Me.dtpJamKeluar.Name = "dtpJamKeluar"
        Me.dtpJamKeluar.Size = New System.Drawing.Size(80, 20)
        Me.dtpJamKeluar.TabIndex = 10
        '
        'lblJamMasuk
        '
        Me.lblJamMasuk.AutoSize = True
        Me.lblJamMasuk.Location = New System.Drawing.Point(6, 39)
        Me.lblJamMasuk.Name = "lblJamMasuk"
        Me.lblJamMasuk.Size = New System.Drawing.Size(64, 13)
        Me.lblJamMasuk.TabIndex = 0
        Me.lblJamMasuk.Text = "Jam Masuk:"
        '
        'lblJamKeluar
        '
        Me.lblJamKeluar.AutoSize = True
        Me.lblJamKeluar.Location = New System.Drawing.Point(178, 39)
        Me.lblJamKeluar.Name = "lblJamKeluar"
        Me.lblJamKeluar.Size = New System.Drawing.Size(62, 13)
        Me.lblJamKeluar.TabIndex = 83
        Me.lblJamKeluar.Text = "Jam Keluar:"
        '
        'pnlTanggal
        '
        Me.pnlTanggal.Controls.Add(Me.lblSD)
        Me.pnlTanggal.Controls.Add(Me.dtpAkhir)
        Me.pnlTanggal.Controls.Add(Me.dtpAwal)
        Me.pnlTanggal.Location = New System.Drawing.Point(6, 21)
        Me.pnlTanggal.Name = "pnlTanggal"
        Me.pnlTanggal.Size = New System.Drawing.Size(285, 30)
        Me.pnlTanggal.TabIndex = 191
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(129, 12)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(21, 13)
        Me.lblSD.TabIndex = 5
        Me.lblSD.Text = "s.d"
        '
        'dtpAkhir
        '
        Me.dtpAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAkhir.Location = New System.Drawing.Point(156, 6)
        Me.dtpAkhir.Name = "dtpAkhir"
        Me.dtpAkhir.Size = New System.Drawing.Size(120, 20)
        Me.dtpAkhir.TabIndex = 2
        '
        'dtpAwal
        '
        Me.dtpAwal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAwal.Location = New System.Drawing.Point(3, 6)
        Me.dtpAwal.Name = "dtpAwal"
        Me.dtpAwal.Size = New System.Drawing.Size(120, 20)
        Me.dtpAwal.TabIndex = 1
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(831, 30)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(241, 20)
        Me.tbCari.TabIndex = 7
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(1078, 12)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 8
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'cboKriteria
        '
        Me.cboKriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKriteria.FormattingEnabled = True
        Me.cboKriteria.Location = New System.Drawing.Point(709, 30)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboKriteria.TabIndex = 6
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.AllowUserToOrderColumns = True
        Me.dgvView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Location = New System.Drawing.Point(6, 203)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.Size = New System.Drawing.Size(1298, 344)
        Me.dgvView.TabIndex = 130
        '
        'pnlCetak
        '
        Me.pnlCetak.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCetak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCetak.Controls.Add(Me.btnKeluar)
        Me.pnlCetak.Controls.Add(Me.btnBrowse)
        Me.pnlCetak.Controls.Add(Me.btnExportExcel)
        Me.pnlCetak.Controls.Add(Me.btnCetak)
        Me.pnlCetak.Controls.Add(Me.tbNamaSimpan)
        Me.pnlCetak.Controls.Add(Me.tbPathSimpan)
        Me.pnlCetak.Controls.Add(Me.lblNamaSimpan)
        Me.pnlCetak.Controls.Add(Me.lblSimpanKeDrive)
        Me.pnlCetak.Location = New System.Drawing.Point(12, 587)
        Me.pnlCetak.Name = "pnlCetak"
        Me.pnlCetak.Size = New System.Drawing.Size(1310, 62)
        Me.pnlCetak.TabIndex = 190
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(833, 3)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 21
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(444, 1)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 24)
        Me.btnBrowse.TabIndex = 17
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportExcel.Image = CType(resources.GetObject("btnExportExcel.Image"), System.Drawing.Image)
        Me.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportExcel.Location = New System.Drawing.Point(473, 3)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(120, 54)
        Me.btnExportExcel.TabIndex = 19
        Me.btnExportExcel.Text = "EXCEL"
        Me.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'btnCetak
        '
        Me.btnCetak.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCetak.Image = CType(resources.GetObject("btnCetak.Image"), System.Drawing.Image)
        Me.btnCetak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetak.Location = New System.Drawing.Point(707, 3)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(120, 54)
        Me.btnCetak.TabIndex = 20
        Me.btnCetak.Text = "CETAK"
        Me.btnCetak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetak.UseVisualStyleBackColor = True
        '
        'tbNamaSimpan
        '
        Me.tbNamaSimpan.Location = New System.Drawing.Point(107, 31)
        Me.tbNamaSimpan.Name = "tbNamaSimpan"
        Me.tbNamaSimpan.Size = New System.Drawing.Size(360, 20)
        Me.tbNamaSimpan.TabIndex = 18
        '
        'tbPathSimpan
        '
        Me.tbPathSimpan.Location = New System.Drawing.Point(107, 3)
        Me.tbPathSimpan.Name = "tbPathSimpan"
        Me.tbPathSimpan.Size = New System.Drawing.Size(333, 20)
        Me.tbPathSimpan.TabIndex = 16
        '
        'lblNamaSimpan
        '
        Me.lblNamaSimpan.AutoSize = True
        Me.lblNamaSimpan.Location = New System.Drawing.Point(22, 34)
        Me.lblNamaSimpan.Name = "lblNamaSimpan"
        Me.lblNamaSimpan.Size = New System.Drawing.Size(79, 13)
        Me.lblNamaSimpan.TabIndex = 87
        Me.lblNamaSimpan.Text = "Nama Simpan :"
        '
        'lblSimpanKeDrive
        '
        Me.lblSimpanKeDrive.AutoSize = True
        Me.lblSimpanKeDrive.Location = New System.Drawing.Point(10, 6)
        Me.lblSimpanKeDrive.Name = "lblSimpanKeDrive"
        Me.lblSimpanKeDrive.Size = New System.Drawing.Size(91, 13)
        Me.lblSimpanKeDrive.TabIndex = 86
        Me.lblSimpanKeDrive.Text = "Simpan ke Drive :"
        '
        'FormView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1334, 661)
        Me.Controls.Add(Me.pnlCetak)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormView"
        Me.Text = "FORM VIEW"
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.gbProsesCepat.ResumeLayout(False)
        Me.gbProsesCepat.PerformLayout()
        Me.pnlJamYangKosong.ResumeLayout(False)
        Me.pnlJamYangKosong.PerformLayout()
        Me.gbKodeIjinAbsen.ResumeLayout(False)
        Me.gbKodeIjinAbsen.PerformLayout()
        Me.gbKosongkan.ResumeLayout(False)
        Me.gbKosongkan.PerformLayout()
        Me.gbSetJamInOut.ResumeLayout(False)
        Me.gbSetJamInOut.PerformLayout()
        Me.pnlTanggal.ResumeLayout(False)
        Me.pnlTanggal.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCetak.ResumeLayout(False)
        Me.pnlCetak.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents gbView As GroupBox
    Friend WithEvents tbCari As TextBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents pnlCetak As Panel
    Friend WithEvents tbNamaSimpan As TextBox
    Friend WithEvents tbPathSimpan As TextBox
    Friend WithEvents lblNamaSimpan As Label
    Friend WithEvents lblSimpanKeDrive As Label
    Friend WithEvents pnlTanggal As Panel
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpAkhir As DateTimePicker
    Friend WithEvents dtpAwal As DateTimePicker
    Friend WithEvents rbJamMasukKeluar As RadioButton
    Friend WithEvents lblJamYangDiset As Label
    Friend WithEvents rbJamKeluar As RadioButton
    Friend WithEvents rbJamMasuk As RadioButton
    Friend WithEvents btnNullkanData As Button
    Friend WithEvents btnProsesCepat As Button
    Friend WithEvents gbSetJamInOut As GroupBox
    Friend WithEvents lblDash As Label
    Friend WithEvents dtpJamMasuk As DateTimePicker
    Friend WithEvents dtpJamKeluar As DateTimePicker
    Friend WithEvents lblJamMasuk As Label
    Friend WithEvents lblJamKeluar As Label
    Friend WithEvents gbProsesCepat As GroupBox
    Friend WithEvents gbKosongkan As GroupBox
    Friend WithEvents rbKosongkanFP As RadioButton
    Friend WithEvents rbKosongkanLembur As RadioButton
    Friend WithEvents btnCetak As Button
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents btnBrowse As Button
    Friend WithEvents rbKosongkanSPK As RadioButton
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents fbdExport As FolderBrowserDialog
    Friend WithEvents cboLokasi As ComboBox
    Friend WithEvents cboMohonIjin As ComboBox
    Friend WithEvents lblIjin As Label
    Friend WithEvents lblAbsen As Label
    Friend WithEvents cboAbsen As ComboBox
    Friend WithEvents gbKodeIjinAbsen As GroupBox
    Friend WithEvents btnSesuaikanJamMasukKeluarCellTerpilih As Button
    Friend WithEvents cboKelompok As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbTampilkanYangKosong As CheckBox
    Friend WithEvents pnlJamYangKosong As Panel
    Friend WithEvents rbKosongJamMasukPulang As RadioButton
    Friend WithEvents lblJamYangKosong As Label
    Friend WithEvents rbKosongJamPulang As RadioButton
    Friend WithEvents rbKosongJamMasuk As RadioButton
    Friend WithEvents lblLokasi As Label
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents cboFilterPerusahaan As ComboBox
    Friend WithEvents lblKriteria As Label
    Friend WithEvents lblKelompok As Label
End Class
