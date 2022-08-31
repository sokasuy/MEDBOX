<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSuratPerintahLemburDetail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSuratPerintahLemburDetail))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.lblBagian = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboPerusahaan = New System.Windows.Forms.ComboBox()
        Me.tbBagian = New System.Windows.Forms.TextBox()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.lblKetJamLembur = New System.Windows.Forms.Label()
        Me.btnTambahkan = New System.Windows.Forms.Button()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rtbCatatanDetail = New System.Windows.Forms.RichTextBox()
        Me.lblCatatanDetail = New System.Windows.Forms.Label()
        Me.lblJamLembur = New System.Windows.Forms.Label()
        Me.tbJamLembur = New System.Windows.Forms.TextBox()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.dtpSelesai = New System.Windows.Forms.DateTimePicker()
        Me.lblWaktuLembur = New System.Windows.Forms.Label()
        Me.dtpMulai = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbPekerjaan = New System.Windows.Forms.TextBox()
        Me.lblPekerjaan = New System.Windows.Forms.Label()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.lblDivisi = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rtbCatatanHeader = New System.Windows.Forms.RichTextBox()
        Me.tbDivisi = New System.Windows.Forms.TextBox()
        Me.lblCatatanHeader = New System.Windows.Forms.Label()
        Me.lblDepartemen = New System.Windows.Forms.Label()
        Me.cboKepala = New System.Windows.Forms.ComboBox()
        Me.lblKepala = New System.Windows.Forms.Label()
        Me.tbDepartemen = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNoSPL = New System.Windows.Forms.Label()
        Me.tbNoSPL = New System.Windows.Forms.TextBox()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnCetak = New System.Windows.Forms.Button()
        Me.gbDataEntry.SuspendLayout()
        Me.gbDetail.SuspendLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.PowderBlue
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(984, 25)
        Me.lblTitle.TabIndex = 19
        Me.lblTitle.Text = "SURAT PERINTAH LEMBUR"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDataEntry.Controls.Add(Me.clbUserRight)
        Me.gbDataEntry.Controls.Add(Me.lblBagian)
        Me.gbDataEntry.Controls.Add(Me.Label7)
        Me.gbDataEntry.Controls.Add(Me.cboPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.tbBagian)
        Me.gbDataEntry.Controls.Add(Me.lblPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.gbDetail)
        Me.gbDataEntry.Controls.Add(Me.lblDivisi)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.rtbCatatanHeader)
        Me.gbDataEntry.Controls.Add(Me.tbDivisi)
        Me.gbDataEntry.Controls.Add(Me.lblCatatanHeader)
        Me.gbDataEntry.Controls.Add(Me.lblDepartemen)
        Me.gbDataEntry.Controls.Add(Me.cboKepala)
        Me.gbDataEntry.Controls.Add(Me.lblKepala)
        Me.gbDataEntry.Controls.Add(Me.tbDepartemen)
        Me.gbDataEntry.Controls.Add(Me.Label4)
        Me.gbDataEntry.Controls.Add(Me.lblTanggal)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggal)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.lblNoSPL)
        Me.gbDataEntry.Controls.Add(Me.tbNoSPL)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(960, 561)
        Me.gbDataEntry.TabIndex = 20
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(854, 16)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 95
        '
        'lblBagian
        '
        Me.lblBagian.AutoSize = True
        Me.lblBagian.Location = New System.Drawing.Point(334, 91)
        Me.lblBagian.Name = "lblBagian"
        Me.lblBagian.Size = New System.Drawing.Size(49, 15)
        Me.lblBagian.TabIndex = 94
        Me.lblBagian.Text = "Bagian :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(436, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 15)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "*"
        '
        'cboPerusahaan
        '
        Me.cboPerusahaan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPerusahaan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPerusahaan.FormattingEnabled = True
        Me.cboPerusahaan.IntegralHeight = False
        Me.cboPerusahaan.Location = New System.Drawing.Point(92, 16)
        Me.cboPerusahaan.Name = "cboPerusahaan"
        Me.cboPerusahaan.Size = New System.Drawing.Size(338, 23)
        Me.cboPerusahaan.TabIndex = 1
        '
        'tbBagian
        '
        Me.tbBagian.Location = New System.Drawing.Point(389, 88)
        Me.tbBagian.Name = "tbBagian"
        Me.tbBagian.ReadOnly = True
        Me.tbBagian.Size = New System.Drawing.Size(131, 23)
        Me.tbBagian.TabIndex = 92
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Location = New System.Drawing.Point(12, 19)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaan.TabIndex = 87
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'gbDetail
        '
        Me.gbDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetail.Controls.Add(Me.lblKetJamLembur)
        Me.gbDetail.Controls.Add(Me.btnTambahkan)
        Me.gbDetail.Controls.Add(Me.btnReload)
        Me.gbDetail.Controls.Add(Me.Label8)
        Me.gbDetail.Controls.Add(Me.rtbCatatanDetail)
        Me.gbDetail.Controls.Add(Me.lblCatatanDetail)
        Me.gbDetail.Controls.Add(Me.lblJamLembur)
        Me.gbDetail.Controls.Add(Me.tbJamLembur)
        Me.gbDetail.Controls.Add(Me.lblSD)
        Me.gbDetail.Controls.Add(Me.dtpSelesai)
        Me.gbDetail.Controls.Add(Me.lblWaktuLembur)
        Me.gbDetail.Controls.Add(Me.dtpMulai)
        Me.gbDetail.Controls.Add(Me.Label5)
        Me.gbDetail.Controls.Add(Me.Label3)
        Me.gbDetail.Controls.Add(Me.tbPekerjaan)
        Me.gbDetail.Controls.Add(Me.lblPekerjaan)
        Me.gbDetail.Controls.Add(Me.cboKaryawan)
        Me.gbDetail.Controls.Add(Me.lblKaryawan)
        Me.gbDetail.Controls.Add(Me.dgvDetail)
        Me.gbDetail.Location = New System.Drawing.Point(6, 171)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(948, 380)
        Me.gbDetail.TabIndex = 85
        Me.gbDetail.TabStop = False
        Me.gbDetail.Text = "DETAIL"
        '
        'lblKetJamLembur
        '
        Me.lblKetJamLembur.AutoSize = True
        Me.lblKetJamLembur.Location = New System.Drawing.Point(685, 73)
        Me.lblKetJamLembur.Name = "lblKetJamLembur"
        Me.lblKetJamLembur.Size = New System.Drawing.Size(84, 15)
        Me.lblKetJamLembur.TabIndex = 100
        Me.lblKetJamLembur.Text = "Format 24 Jam"
        '
        'btnTambahkan
        '
        Me.btnTambahkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnTambahkan.Image = CType(resources.GetObject("btnTambahkan.Image"), System.Drawing.Image)
        Me.btnTambahkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTambahkan.Location = New System.Drawing.Point(822, 93)
        Me.btnTambahkan.Name = "btnTambahkan"
        Me.btnTambahkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTambahkan.TabIndex = 12
        Me.btnTambahkan.Text = "TAMBAH"
        Me.btnTambahkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTambahkan.UseVisualStyleBackColor = True
        '
        'btnReload
        '
        Me.btnReload.Image = CType(resources.GetObject("btnReload.Image"), System.Drawing.Image)
        Me.btnReload.Location = New System.Drawing.Point(463, 22)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(23, 23)
        Me.btnReload.TabIndex = 99
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(667, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 15)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "*"
        '
        'rtbCatatanDetail
        '
        Me.rtbCatatanDetail.Location = New System.Drawing.Point(101, 94)
        Me.rtbCatatanDetail.Name = "rtbCatatanDetail"
        Me.rtbCatatanDetail.Size = New System.Drawing.Size(715, 53)
        Me.rtbCatatanDetail.TabIndex = 11
        Me.rtbCatatanDetail.Text = ""
        '
        'lblCatatanDetail
        '
        Me.lblCatatanDetail.AutoSize = True
        Me.lblCatatanDetail.Location = New System.Drawing.Point(41, 97)
        Me.lblCatatanDetail.Name = "lblCatatanDetail"
        Me.lblCatatanDetail.Size = New System.Drawing.Size(54, 15)
        Me.lblCatatanDetail.TabIndex = 97
        Me.lblCatatanDetail.Text = "Catatan :"
        '
        'lblJamLembur
        '
        Me.lblJamLembur.AutoSize = True
        Me.lblJamLembur.Location = New System.Drawing.Point(514, 73)
        Me.lblJamLembur.Name = "lblJamLembur"
        Me.lblJamLembur.Size = New System.Drawing.Size(78, 15)
        Me.lblJamLembur.TabIndex = 95
        Me.lblJamLembur.Text = "Jam Lembur :"
        '
        'tbJamLembur
        '
        Me.tbJamLembur.Location = New System.Drawing.Point(598, 70)
        Me.tbJamLembur.Name = "tbJamLembur"
        Me.tbJamLembur.Size = New System.Drawing.Size(63, 23)
        Me.tbJamLembur.TabIndex = 10
        Me.tbJamLembur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(272, 76)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(22, 15)
        Me.lblSD.TabIndex = 92
        Me.lblSD.Text = "s.d"
        '
        'dtpSelesai
        '
        Me.dtpSelesai.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.dtpSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSelesai.Location = New System.Drawing.Point(300, 70)
        Me.dtpSelesai.Name = "dtpSelesai"
        Me.dtpSelesai.Size = New System.Drawing.Size(165, 23)
        Me.dtpSelesai.TabIndex = 9
        '
        'lblWaktuLembur
        '
        Me.lblWaktuLembur.AutoSize = True
        Me.lblWaktuLembur.Location = New System.Drawing.Point(4, 73)
        Me.lblWaktuLembur.Name = "lblWaktuLembur"
        Me.lblWaktuLembur.Size = New System.Drawing.Size(91, 15)
        Me.lblWaktuLembur.TabIndex = 90
        Me.lblWaktuLembur.Text = "Waktu Lembur :"
        '
        'dtpMulai
        '
        Me.dtpMulai.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.dtpMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMulai.Location = New System.Drawing.Point(101, 70)
        Me.dtpMulai.Name = "dtpMulai"
        Me.dtpMulai.Size = New System.Drawing.Size(165, 23)
        Me.dtpMulai.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(445, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 15)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(776, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "*"
        '
        'tbPekerjaan
        '
        Me.tbPekerjaan.Location = New System.Drawing.Point(101, 46)
        Me.tbPekerjaan.Name = "tbPekerjaan"
        Me.tbPekerjaan.Size = New System.Drawing.Size(669, 23)
        Me.tbPekerjaan.TabIndex = 7
        '
        'lblPekerjaan
        '
        Me.lblPekerjaan.AutoSize = True
        Me.lblPekerjaan.Location = New System.Drawing.Point(31, 49)
        Me.lblPekerjaan.Name = "lblPekerjaan"
        Me.lblPekerjaan.Size = New System.Drawing.Size(64, 15)
        Me.lblPekerjaan.TabIndex = 86
        Me.lblPekerjaan.Text = "Pekerjaan :"
        '
        'cboKaryawan
        '
        Me.cboKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.IntegralHeight = False
        Me.cboKaryawan.Location = New System.Drawing.Point(101, 22)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(338, 23)
        Me.cboKaryawan.TabIndex = 6
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Location = New System.Drawing.Point(31, 25)
        Me.lblKaryawan.Name = "lblKaryawan"
        Me.lblKaryawan.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawan.TabIndex = 84
        Me.lblKaryawan.Text = "Karyawan :"
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Location = New System.Drawing.Point(6, 153)
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.RowTemplate.Height = 25
        Me.dgvDetail.Size = New System.Drawing.Size(936, 221)
        Me.dgvDetail.TabIndex = 77
        '
        'lblDivisi
        '
        Me.lblDivisi.AutoSize = True
        Me.lblDivisi.Location = New System.Drawing.Point(184, 91)
        Me.lblDivisi.Name = "lblDivisi"
        Me.lblDivisi.Size = New System.Drawing.Size(41, 15)
        Me.lblDivisi.TabIndex = 93
        Me.lblDivisi.Text = "Divisi :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(548, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "*"
        '
        'rtbCatatanHeader
        '
        Me.rtbCatatanHeader.Location = New System.Drawing.Point(92, 112)
        Me.rtbCatatanHeader.Name = "rtbCatatanHeader"
        Me.rtbCatatanHeader.Size = New System.Drawing.Size(730, 53)
        Me.rtbCatatanHeader.TabIndex = 5
        Me.rtbCatatanHeader.Text = ""
        '
        'tbDivisi
        '
        Me.tbDivisi.Location = New System.Drawing.Point(231, 88)
        Me.tbDivisi.Name = "tbDivisi"
        Me.tbDivisi.ReadOnly = True
        Me.tbDivisi.Size = New System.Drawing.Size(97, 23)
        Me.tbDivisi.TabIndex = 91
        '
        'lblCatatanHeader
        '
        Me.lblCatatanHeader.AutoSize = True
        Me.lblCatatanHeader.Location = New System.Drawing.Point(32, 115)
        Me.lblCatatanHeader.Name = "lblCatatanHeader"
        Me.lblCatatanHeader.Size = New System.Drawing.Size(54, 15)
        Me.lblCatatanHeader.TabIndex = 81
        Me.lblCatatanHeader.Text = "Catatan :"
        '
        'lblDepartemen
        '
        Me.lblDepartemen.AutoSize = True
        Me.lblDepartemen.Location = New System.Drawing.Point(8, 91)
        Me.lblDepartemen.Name = "lblDepartemen"
        Me.lblDepartemen.Size = New System.Drawing.Size(78, 15)
        Me.lblDepartemen.TabIndex = 89
        Me.lblDepartemen.Text = "Departemen :"
        '
        'cboKepala
        '
        Me.cboKepala.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKepala.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKepala.FormattingEnabled = True
        Me.cboKepala.IntegralHeight = False
        Me.cboKepala.Location = New System.Drawing.Point(92, 64)
        Me.cboKepala.Name = "cboKepala"
        Me.cboKepala.Size = New System.Drawing.Size(450, 23)
        Me.cboKepala.TabIndex = 4
        '
        'lblKepala
        '
        Me.lblKepala.AutoSize = True
        Me.lblKepala.Location = New System.Drawing.Point(38, 67)
        Me.lblKepala.Name = "lblKepala"
        Me.lblKepala.Size = New System.Drawing.Size(48, 15)
        Me.lblKepala.TabIndex = 79
        Me.lblKepala.Text = "Kepala :"
        '
        'tbDepartemen
        '
        Me.tbDepartemen.Location = New System.Drawing.Point(92, 88)
        Me.tbDepartemen.Name = "tbDepartemen"
        Me.tbDepartemen.ReadOnly = True
        Me.tbDepartemen.Size = New System.Drawing.Size(86, 23)
        Me.tbDepartemen.TabIndex = 90
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(674, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "*"
        '
        'lblTanggal
        '
        Me.lblTanggal.AutoSize = True
        Me.lblTanggal.Location = New System.Drawing.Point(488, 22)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(54, 15)
        Me.lblTanggal.TabIndex = 75
        Me.lblTanggal.Text = "Tanggal :"
        '
        'dtpTanggal
        '
        Me.dtpTanggal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggal.Enabled = False
        Me.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggal.Location = New System.Drawing.Point(548, 16)
        Me.dtpTanggal.Name = "dtpTanggal"
        Me.dtpTanggal.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggal.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(239, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "*"
        '
        'lblNoSPL
        '
        Me.lblNoSPL.AutoSize = True
        Me.lblNoSPL.Location = New System.Drawing.Point(35, 43)
        Me.lblNoSPL.Name = "lblNoSPL"
        Me.lblNoSPL.Size = New System.Drawing.Size(51, 15)
        Me.lblNoSPL.TabIndex = 1
        Me.lblNoSPL.Text = "No SPL :"
        '
        'tbNoSPL
        '
        Me.tbNoSPL.Location = New System.Drawing.Point(92, 40)
        Me.tbNoSPL.Name = "tbNoSPL"
        Me.tbNoSPL.ReadOnly = True
        Me.tbNoSPL.Size = New System.Drawing.Size(141, 23)
        Me.tbNoSPL.TabIndex = 3
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(452, 595)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 14
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(326, 595)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 13
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnHapus.Image = CType(resources.GetObject("btnHapus.Image"), System.Drawing.Image)
        Me.btnHapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHapus.Location = New System.Drawing.Point(578, 595)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(120, 54)
        Me.btnHapus.TabIndex = 15
        Me.btnHapus.Text = "HAPUS"
        Me.btnHapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnCetak
        '
        Me.btnCetak.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnCetak.Image = CType(resources.GetObject("btnCetak.Image"), System.Drawing.Image)
        Me.btnCetak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetak.Location = New System.Drawing.Point(852, 595)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(120, 54)
        Me.btnCetak.TabIndex = 16
        Me.btnCetak.Text = "CETAK"
        Me.btnCetak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetak.UseVisualStyleBackColor = True
        '
        'FormSuratPerintahLemburDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 651)
        Me.Controls.Add(Me.btnCetak)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSuratPerintahLemburDetail"
        Me.Text = "FORM SURAT PERINTAH LEMBUR"
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents tbNoSPL As TextBox
    Friend WithEvents lblNoSPL As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTanggal As Label
    Friend WithEvents dtpTanggal As DateTimePicker
    Friend WithEvents dgvDetail As DataGridView
    Friend WithEvents cboKepala As ComboBox
    Friend WithEvents lblKepala As Label
    Friend WithEvents rtbCatatanHeader As RichTextBox
    Friend WithEvents lblCatatanHeader As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents gbDetail As GroupBox
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbPekerjaan As TextBox
    Friend WithEvents lblPekerjaan As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpMulai As DateTimePicker
    Friend WithEvents lblWaktuLembur As Label
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpSelesai As DateTimePicker
    Friend WithEvents lblJamLembur As Label
    Friend WithEvents tbJamLembur As TextBox
    Friend WithEvents rtbCatatanDetail As RichTextBox
    Friend WithEvents lblCatatanDetail As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cboPerusahaan As ComboBox
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblBagian As Label
    Friend WithEvents tbBagian As TextBox
    Friend WithEvents lblDivisi As Label
    Friend WithEvents tbDivisi As TextBox
    Friend WithEvents lblDepartemen As Label
    Friend WithEvents tbDepartemen As TextBox
    Friend WithEvents btnReload As Button
    Friend WithEvents btnTambahkan As Button
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents lblKetJamLembur As Label
    Friend WithEvents btnCetak As Button
End Class
