<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDetailSuratPerintahKerja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDetailSuratPerintahKerja))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboLokasi = New System.Windows.Forms.ComboBox()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.lblSPKOke = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpPeriodeSelesai = New System.Windows.Forms.DateTimePicker()
        Me.lblSD1 = New System.Windows.Forms.Label()
        Me.lblPeriode = New System.Windows.Forms.Label()
        Me.dtpPeriodeMulai = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.cboDepartemen = New System.Windows.Forms.ComboBox()
        Me.lblDepartemen = New System.Windows.Forms.Label()
        Me.lblCatatan = New System.Windows.Forms.Label()
        Me.lblBagKepala = New System.Windows.Forms.Label()
        Me.rtbCatatanHeader = New System.Windows.Forms.RichTextBox()
        Me.tbBagKepala = New System.Windows.Forms.TextBox()
        Me.lblDivKepala = New System.Windows.Forms.Label()
        Me.tbDivKepala = New System.Windows.Forms.TextBox()
        Me.lblDeptKepala = New System.Windows.Forms.Label()
        Me.tbDeptKepala = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboKepala = New System.Windows.Forms.ComboBox()
        Me.lblKepala = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNoSPK = New System.Windows.Forms.Label()
        Me.tbNoSPK = New System.Windows.Forms.TextBox()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.lblTanggalPengajuan = New System.Windows.Forms.Label()
        Me.dtpTanggalPengajuan = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPerusahaan = New System.Windows.Forms.ComboBox()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.tbShift = New System.Windows.Forms.TextBox()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.btnTambahkan = New System.Windows.Forms.Button()
        Me.lblPekerjaan = New System.Windows.Forms.Label()
        Me.rtbPekerjaan = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSD2 = New System.Windows.Forms.Label()
        Me.dtpSelesai = New System.Windows.Forms.DateTimePicker()
        Me.lblJadwal = New System.Windows.Forms.Label()
        Me.dtpMulai = New System.Windows.Forms.DateTimePicker()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.btnCetak = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.pnlCetak = New System.Windows.Forms.Panel()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.tbNamaSimpan = New System.Windows.Forms.TextBox()
        Me.tbPathSimpan = New System.Windows.Forms.TextBox()
        Me.lblNamaSimpan = New System.Windows.Forms.Label()
        Me.lblSimpanKeDrive = New System.Windows.Forms.Label()
        Me.gbDataEntry.SuspendLayout()
        Me.gbDetail.SuspendLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(984, 25)
        Me.lblTitle.TabIndex = 182
        Me.lblTitle.Text = "SURAT PERINTAH KERJA"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDataEntry.Controls.Add(Me.Label9)
        Me.gbDataEntry.Controls.Add(Me.cboLokasi)
        Me.gbDataEntry.Controls.Add(Me.lblLokasi)
        Me.gbDataEntry.Controls.Add(Me.lblSPKOke)
        Me.gbDataEntry.Controls.Add(Me.Label7)
        Me.gbDataEntry.Controls.Add(Me.dtpPeriodeSelesai)
        Me.gbDataEntry.Controls.Add(Me.lblSD1)
        Me.gbDataEntry.Controls.Add(Me.lblPeriode)
        Me.gbDataEntry.Controls.Add(Me.dtpPeriodeMulai)
        Me.gbDataEntry.Controls.Add(Me.Label8)
        Me.gbDataEntry.Controls.Add(Me.Label5)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.cboDepartemen)
        Me.gbDataEntry.Controls.Add(Me.lblDepartemen)
        Me.gbDataEntry.Controls.Add(Me.lblCatatan)
        Me.gbDataEntry.Controls.Add(Me.lblBagKepala)
        Me.gbDataEntry.Controls.Add(Me.rtbCatatanHeader)
        Me.gbDataEntry.Controls.Add(Me.tbBagKepala)
        Me.gbDataEntry.Controls.Add(Me.lblDivKepala)
        Me.gbDataEntry.Controls.Add(Me.tbDivKepala)
        Me.gbDataEntry.Controls.Add(Me.lblDeptKepala)
        Me.gbDataEntry.Controls.Add(Me.tbDeptKepala)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.cboKepala)
        Me.gbDataEntry.Controls.Add(Me.lblKepala)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.lblNoSPK)
        Me.gbDataEntry.Controls.Add(Me.tbNoSPK)
        Me.gbDataEntry.Controls.Add(Me.clbUserRight)
        Me.gbDataEntry.Controls.Add(Me.lblTanggalPengajuan)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggalPengajuan)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.cboPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.lblPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.gbDetail)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(960, 561)
        Me.gbDataEntry.TabIndex = 183
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(710, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 15)
        Me.Label9.TabIndex = 261
        Me.Label9.Text = "*"
        '
        'cboLokasi
        '
        Me.cboLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasi.FormattingEnabled = True
        Me.cboLokasi.IntegralHeight = False
        Me.cboLokasi.Location = New System.Drawing.Point(571, 58)
        Me.cboLokasi.Name = "cboLokasi"
        Me.cboLokasi.Size = New System.Drawing.Size(133, 21)
        Me.cboLokasi.TabIndex = 259
        '
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLokasi.Location = New System.Drawing.Point(519, 60)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(46, 15)
        Me.lblLokasi.TabIndex = 260
        Me.lblLokasi.Text = "Lokasi :"
        '
        'lblSPKOke
        '
        Me.lblSPKOke.AutoSize = True
        Me.lblSPKOke.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSPKOke.ForeColor = System.Drawing.Color.Green
        Me.lblSPKOke.Location = New System.Drawing.Point(394, 60)
        Me.lblSPKOke.Name = "lblSPKOke"
        Me.lblSPKOke.Size = New System.Drawing.Size(15, 15)
        Me.lblSPKOke.TabIndex = 249
        Me.lblSPKOke.Text = "√"
        Me.lblSPKOke.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(368, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 15)
        Me.Label7.TabIndex = 248
        Me.Label7.Text = "*"
        '
        'dtpPeriodeSelesai
        '
        Me.dtpPeriodeSelesai.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPeriodeSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodeSelesai.Location = New System.Drawing.Point(242, 37)
        Me.dtpPeriodeSelesai.Name = "dtpPeriodeSelesai"
        Me.dtpPeriodeSelesai.Size = New System.Drawing.Size(120, 20)
        Me.dtpPeriodeSelesai.TabIndex = 4
        '
        'lblSD1
        '
        Me.lblSD1.AutoSize = True
        Me.lblSD1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSD1.Location = New System.Drawing.Point(212, 39)
        Me.lblSD1.Name = "lblSD1"
        Me.lblSD1.Size = New System.Drawing.Size(24, 15)
        Me.lblSD1.TabIndex = 247
        Me.lblSD1.Text = "s/d"
        '
        'lblPeriode
        '
        Me.lblPeriode.AutoSize = True
        Me.lblPeriode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPeriode.Location = New System.Drawing.Point(27, 39)
        Me.lblPeriode.Name = "lblPeriode"
        Me.lblPeriode.Size = New System.Drawing.Size(53, 15)
        Me.lblPeriode.TabIndex = 246
        Me.lblPeriode.Text = "Periode :"
        '
        'dtpPeriodeMulai
        '
        Me.dtpPeriodeMulai.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPeriodeMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodeMulai.Location = New System.Drawing.Point(86, 37)
        Me.dtpPeriodeMulai.Name = "dtpPeriodeMulai"
        Me.dtpPeriodeMulai.Size = New System.Drawing.Size(120, 20)
        Me.dtpPeriodeMulai.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(710, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 15)
        Me.Label8.TabIndex = 244
        Me.Label8.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(710, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 15)
        Me.Label5.TabIndex = 221
        Me.Label5.Text = "*"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(728, 15)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 18
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'cboDepartemen
        '
        Me.cboDepartemen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDepartemen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDepartemen.FormattingEnabled = True
        Me.cboDepartemen.IntegralHeight = False
        Me.cboDepartemen.Location = New System.Drawing.Point(492, 15)
        Me.cboDepartemen.Name = "cboDepartemen"
        Me.cboDepartemen.Size = New System.Drawing.Size(212, 21)
        Me.cboDepartemen.TabIndex = 2
        '
        'lblDepartemen
        '
        Me.lblDepartemen.AutoSize = True
        Me.lblDepartemen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartemen.Location = New System.Drawing.Point(408, 17)
        Me.lblDepartemen.Name = "lblDepartemen"
        Me.lblDepartemen.Size = New System.Drawing.Size(78, 15)
        Me.lblDepartemen.TabIndex = 220
        Me.lblDepartemen.Text = "Departemen :"
        '
        'lblCatatan
        '
        Me.lblCatatan.AutoSize = True
        Me.lblCatatan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCatatan.Location = New System.Drawing.Point(26, 104)
        Me.lblCatatan.Name = "lblCatatan"
        Me.lblCatatan.Size = New System.Drawing.Size(54, 15)
        Me.lblCatatan.TabIndex = 243
        Me.lblCatatan.Text = "Catatan :"
        '
        'lblBagKepala
        '
        Me.lblBagKepala.AutoSize = True
        Me.lblBagKepala.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBagKepala.Location = New System.Drawing.Point(753, 83)
        Me.lblBagKepala.Name = "lblBagKepala"
        Me.lblBagKepala.Size = New System.Drawing.Size(49, 15)
        Me.lblBagKepala.TabIndex = 234
        Me.lblBagKepala.Text = "Bagian :"
        '
        'rtbCatatanHeader
        '
        Me.rtbCatatanHeader.Location = New System.Drawing.Point(86, 102)
        Me.rtbCatatanHeader.Name = "rtbCatatanHeader"
        Me.rtbCatatanHeader.Size = New System.Drawing.Size(868, 62)
        Me.rtbCatatanHeader.TabIndex = 8
        Me.rtbCatatanHeader.Text = ""
        '
        'tbBagKepala
        '
        Me.tbBagKepala.Location = New System.Drawing.Point(808, 81)
        Me.tbBagKepala.Name = "tbBagKepala"
        Me.tbBagKepala.ReadOnly = True
        Me.tbBagKepala.Size = New System.Drawing.Size(146, 20)
        Me.tbBagKepala.TabIndex = 233
        '
        'lblDivKepala
        '
        Me.lblDivKepala.AutoSize = True
        Me.lblDivKepala.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDivKepala.Location = New System.Drawing.Point(568, 83)
        Me.lblDivKepala.Name = "lblDivKepala"
        Me.lblDivKepala.Size = New System.Drawing.Size(41, 15)
        Me.lblDivKepala.TabIndex = 232
        Me.lblDivKepala.Text = "Divisi :"
        '
        'tbDivKepala
        '
        Me.tbDivKepala.Location = New System.Drawing.Point(615, 81)
        Me.tbDivKepala.Name = "tbDivKepala"
        Me.tbDivKepala.ReadOnly = True
        Me.tbDivKepala.Size = New System.Drawing.Size(132, 20)
        Me.tbDivKepala.TabIndex = 231
        '
        'lblDeptKepala
        '
        Me.lblDeptKepala.AutoSize = True
        Me.lblDeptKepala.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDeptKepala.Location = New System.Drawing.Point(345, 83)
        Me.lblDeptKepala.Name = "lblDeptKepala"
        Me.lblDeptKepala.Size = New System.Drawing.Size(76, 15)
        Me.lblDeptKepala.TabIndex = 230
        Me.lblDeptKepala.Text = "Dept Kepala :"
        '
        'tbDeptKepala
        '
        Me.tbDeptKepala.Location = New System.Drawing.Point(427, 81)
        Me.tbDeptKepala.Name = "tbDeptKepala"
        Me.tbDeptKepala.ReadOnly = True
        Me.tbDeptKepala.Size = New System.Drawing.Size(135, 20)
        Me.tbDeptKepala.TabIndex = 229
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(327, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "*"
        '
        'cboKepala
        '
        Me.cboKepala.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKepala.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKepala.FormattingEnabled = True
        Me.cboKepala.IntegralHeight = False
        Me.cboKepala.Location = New System.Drawing.Point(86, 79)
        Me.cboKepala.Name = "cboKepala"
        Me.cboKepala.Size = New System.Drawing.Size(235, 21)
        Me.cboKepala.TabIndex = 7
        '
        'lblKepala
        '
        Me.lblKepala.AutoSize = True
        Me.lblKepala.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKepala.Location = New System.Drawing.Point(9, 81)
        Me.lblKepala.Name = "lblKepala"
        Me.lblKepala.Size = New System.Drawing.Size(71, 15)
        Me.lblKepala.TabIndex = 227
        Me.lblKepala.Text = "SPV/Kabag :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(376, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 225
        Me.Label1.Text = "*"
        '
        'lblNoSPK
        '
        Me.lblNoSPK.AutoSize = True
        Me.lblNoSPK.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNoSPK.Location = New System.Drawing.Point(29, 60)
        Me.lblNoSPK.Name = "lblNoSPK"
        Me.lblNoSPK.Size = New System.Drawing.Size(52, 15)
        Me.lblNoSPK.TabIndex = 224
        Me.lblNoSPK.Text = "No SPK :"
        '
        'tbNoSPK
        '
        Me.tbNoSPK.Location = New System.Drawing.Point(86, 58)
        Me.tbNoSPK.Name = "tbNoSPK"
        Me.tbNoSPK.Size = New System.Drawing.Size(284, 20)
        Me.tbNoSPK.TabIndex = 6
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(854, 15)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 222
        '
        'lblTanggalPengajuan
        '
        Me.lblTanggalPengajuan.AutoSize = True
        Me.lblTanggalPengajuan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTanggalPengajuan.Location = New System.Drawing.Point(465, 39)
        Me.lblTanggalPengajuan.Name = "lblTanggalPengajuan"
        Me.lblTanggalPengajuan.Size = New System.Drawing.Size(113, 15)
        Me.lblTanggalPengajuan.TabIndex = 221
        Me.lblTanggalPengajuan.Text = "Tanggal Pengajuan :"
        '
        'dtpTanggalPengajuan
        '
        Me.dtpTanggalPengajuan.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalPengajuan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalPengajuan.Location = New System.Drawing.Point(584, 37)
        Me.dtpTanggalPengajuan.Name = "dtpTanggalPengajuan"
        Me.dtpTanggalPengajuan.Size = New System.Drawing.Size(120, 20)
        Me.dtpTanggalPengajuan.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(376, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 218
        Me.Label2.Text = "*"
        '
        'cboPerusahaan
        '
        Me.cboPerusahaan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPerusahaan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPerusahaan.FormattingEnabled = True
        Me.cboPerusahaan.IntegralHeight = False
        Me.cboPerusahaan.Location = New System.Drawing.Point(86, 15)
        Me.cboPerusahaan.Name = "cboPerusahaan"
        Me.cboPerusahaan.Size = New System.Drawing.Size(284, 21)
        Me.cboPerusahaan.TabIndex = 1
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPerusahaan.Location = New System.Drawing.Point(6, 17)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaan.TabIndex = 13
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'gbDetail
        '
        Me.gbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetail.Controls.Add(Me.tbShift)
        Me.gbDetail.Controls.Add(Me.lblShift)
        Me.gbDetail.Controls.Add(Me.dgvDetail)
        Me.gbDetail.Controls.Add(Me.btnTambahkan)
        Me.gbDetail.Controls.Add(Me.lblPekerjaan)
        Me.gbDetail.Controls.Add(Me.rtbPekerjaan)
        Me.gbDetail.Controls.Add(Me.Label6)
        Me.gbDetail.Controls.Add(Me.lblSD2)
        Me.gbDetail.Controls.Add(Me.dtpSelesai)
        Me.gbDetail.Controls.Add(Me.lblJadwal)
        Me.gbDetail.Controls.Add(Me.dtpMulai)
        Me.gbDetail.Controls.Add(Me.btnReload)
        Me.gbDetail.Controls.Add(Me.Label4)
        Me.gbDetail.Controls.Add(Me.cboKaryawan)
        Me.gbDetail.Controls.Add(Me.lblKaryawan)
        Me.gbDetail.Location = New System.Drawing.Point(6, 170)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(948, 381)
        Me.gbDetail.TabIndex = 0
        Me.gbDetail.TabStop = False
        Me.gbDetail.Text = "DETAIL"
        '
        'tbShift
        '
        Me.tbShift.Location = New System.Drawing.Point(562, 41)
        Me.tbShift.Name = "tbShift"
        Me.tbShift.ReadOnly = True
        Me.tbShift.Size = New System.Drawing.Size(41, 20)
        Me.tbShift.TabIndex = 256
        Me.tbShift.Text = "1"
        Me.tbShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblShift
        '
        Me.lblShift.AutoSize = True
        Me.lblShift.Location = New System.Drawing.Point(522, 44)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(34, 13)
        Me.lblShift.TabIndex = 255
        Me.lblShift.Text = "Shift :"
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Location = New System.Drawing.Point(3, 123)
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.Size = New System.Drawing.Size(939, 252)
        Me.dgvDetail.TabIndex = 254
        '
        'btnTambahkan
        '
        Me.btnTambahkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTambahkan.Image = CType(resources.GetObject("btnTambahkan.Image"), System.Drawing.Image)
        Me.btnTambahkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTambahkan.Location = New System.Drawing.Point(822, 63)
        Me.btnTambahkan.Name = "btnTambahkan"
        Me.btnTambahkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTambahkan.TabIndex = 13
        Me.btnTambahkan.Text = "TAMBAH"
        Me.btnTambahkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTambahkan.UseVisualStyleBackColor = True
        '
        'lblPekerjaan
        '
        Me.lblPekerjaan.AutoSize = True
        Me.lblPekerjaan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPekerjaan.Location = New System.Drawing.Point(33, 65)
        Me.lblPekerjaan.Name = "lblPekerjaan"
        Me.lblPekerjaan.Size = New System.Drawing.Size(64, 15)
        Me.lblPekerjaan.TabIndex = 252
        Me.lblPekerjaan.Text = "Pekerjaan :"
        '
        'rtbPekerjaan
        '
        Me.rtbPekerjaan.Location = New System.Drawing.Point(103, 63)
        Me.rtbPekerjaan.Name = "rtbPekerjaan"
        Me.rtbPekerjaan.Size = New System.Drawing.Size(713, 54)
        Me.rtbPekerjaan.TabIndex = 12
        Me.rtbPekerjaan.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(475, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 15)
        Me.Label6.TabIndex = 250
        Me.Label6.Text = "*"
        '
        'lblSD2
        '
        Me.lblSD2.AutoSize = True
        Me.lblSD2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSD2.Location = New System.Drawing.Point(274, 46)
        Me.lblSD2.Name = "lblSD2"
        Me.lblSD2.Size = New System.Drawing.Size(24, 15)
        Me.lblSD2.TabIndex = 246
        Me.lblSD2.Text = "s/d"
        '
        'dtpSelesai
        '
        Me.dtpSelesai.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.dtpSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSelesai.Location = New System.Drawing.Point(304, 41)
        Me.dtpSelesai.Name = "dtpSelesai"
        Me.dtpSelesai.Size = New System.Drawing.Size(165, 20)
        Me.dtpSelesai.TabIndex = 11
        '
        'lblJadwal
        '
        Me.lblJadwal.AutoSize = True
        Me.lblJadwal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJadwal.Location = New System.Drawing.Point(49, 46)
        Me.lblJadwal.Name = "lblJadwal"
        Me.lblJadwal.Size = New System.Drawing.Size(48, 15)
        Me.lblJadwal.TabIndex = 244
        Me.lblJadwal.Text = "Jadwal :"
        '
        'dtpMulai
        '
        Me.dtpMulai.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.dtpMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMulai.Location = New System.Drawing.Point(103, 41)
        Me.dtpMulai.Name = "dtpMulai"
        Me.dtpMulai.Size = New System.Drawing.Size(165, 20)
        Me.dtpMulai.TabIndex = 10
        '
        'btnReload
        '
        Me.btnReload.Image = CType(resources.GetObject("btnReload.Image"), System.Drawing.Image)
        Me.btnReload.Location = New System.Drawing.Point(512, 17)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(23, 23)
        Me.btnReload.TabIndex = 7
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(494, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 219
        Me.Label4.Text = "*"
        '
        'cboKaryawan
        '
        Me.cboKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.IntegralHeight = False
        Me.cboKaryawan.Location = New System.Drawing.Point(103, 19)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(385, 21)
        Me.cboKaryawan.TabIndex = 9
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKaryawan.Location = New System.Drawing.Point(33, 22)
        Me.lblKaryawan.Name = "lblKaryawan"
        Me.lblKaryawan.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawan.TabIndex = 13
        Me.lblKaryawan.Text = "Karyawan :"
        '
        'btnCetak
        '
        Me.btnCetak.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCetak.Image = CType(resources.GetObject("btnCetak.Image"), System.Drawing.Image)
        Me.btnCetak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetak.Location = New System.Drawing.Point(581, 3)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(120, 54)
        Me.btnCetak.TabIndex = 15
        Me.btnCetak.Text = "CETAK"
        Me.btnCetak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetak.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnHapus.Image = CType(resources.GetObject("btnHapus.Image"), System.Drawing.Image)
        Me.btnHapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHapus.Location = New System.Drawing.Point(833, 3)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(120, 54)
        Me.btnHapus.TabIndex = 17
        Me.btnHapus.Text = "HAPUS"
        Me.btnHapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(707, 3)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 16
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(455, 3)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 14
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'pnlCetak
        '
        Me.pnlCetak.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlCetak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCetak.Controls.Add(Me.btnBrowse)
        Me.pnlCetak.Controls.Add(Me.btnExportExcel)
        Me.pnlCetak.Controls.Add(Me.tbNamaSimpan)
        Me.pnlCetak.Controls.Add(Me.tbPathSimpan)
        Me.pnlCetak.Controls.Add(Me.lblNamaSimpan)
        Me.pnlCetak.Controls.Add(Me.lblSimpanKeDrive)
        Me.pnlCetak.Controls.Add(Me.btnSimpan)
        Me.pnlCetak.Controls.Add(Me.btnCetak)
        Me.pnlCetak.Controls.Add(Me.btnKeluar)
        Me.pnlCetak.Controls.Add(Me.btnHapus)
        Me.pnlCetak.Location = New System.Drawing.Point(12, 595)
        Me.pnlCetak.Name = "pnlCetak"
        Me.pnlCetak.Size = New System.Drawing.Size(960, 62)
        Me.pnlCetak.TabIndex = 188
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(296, 4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 24)
        Me.btnBrowse.TabIndex = 89
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportExcel.Image = CType(resources.GetObject("btnExportExcel.Image"), System.Drawing.Image)
        Me.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportExcel.Location = New System.Drawing.Point(326, 3)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(120, 54)
        Me.btnExportExcel.TabIndex = 91
        Me.btnExportExcel.Text = "EXCEL"
        Me.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'tbNamaSimpan
        '
        Me.tbNamaSimpan.Location = New System.Drawing.Point(101, 34)
        Me.tbNamaSimpan.Name = "tbNamaSimpan"
        Me.tbNamaSimpan.Size = New System.Drawing.Size(219, 20)
        Me.tbNamaSimpan.TabIndex = 90
        '
        'tbPathSimpan
        '
        Me.tbPathSimpan.Location = New System.Drawing.Point(101, 6)
        Me.tbPathSimpan.Name = "tbPathSimpan"
        Me.tbPathSimpan.Size = New System.Drawing.Size(192, 20)
        Me.tbPathSimpan.TabIndex = 88
        '
        'lblNamaSimpan
        '
        Me.lblNamaSimpan.AutoSize = True
        Me.lblNamaSimpan.Location = New System.Drawing.Point(16, 37)
        Me.lblNamaSimpan.Name = "lblNamaSimpan"
        Me.lblNamaSimpan.Size = New System.Drawing.Size(79, 13)
        Me.lblNamaSimpan.TabIndex = 93
        Me.lblNamaSimpan.Text = "Nama Simpan :"
        '
        'lblSimpanKeDrive
        '
        Me.lblSimpanKeDrive.AutoSize = True
        Me.lblSimpanKeDrive.Location = New System.Drawing.Point(4, 9)
        Me.lblSimpanKeDrive.Name = "lblSimpanKeDrive"
        Me.lblSimpanKeDrive.Size = New System.Drawing.Size(91, 13)
        Me.lblSimpanKeDrive.TabIndex = 92
        Me.lblSimpanKeDrive.Text = "Simpan ke Drive :"
        '
        'FormDetailSuratPerintahKerja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.pnlCetak)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormDetailSuratPerintahKerja"
        Me.Text = "FORM SURAT PERINTAH KERJA"
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCetak.ResumeLayout(False)
        Me.pnlCetak.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents lblCatatan As Label
    Friend WithEvents lblBagKepala As Label
    Friend WithEvents rtbCatatanHeader As RichTextBox
    Friend WithEvents tbBagKepala As TextBox
    Friend WithEvents lblDivKepala As Label
    Friend WithEvents tbDivKepala As TextBox
    Friend WithEvents lblDeptKepala As Label
    Friend WithEvents tbDeptKepala As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboKepala As ComboBox
    Friend WithEvents lblKepala As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNoSPK As Label
    Friend WithEvents tbNoSPK As TextBox
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents lblTanggalPengajuan As Label
    Friend WithEvents dtpTanggalPengajuan As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents cboPerusahaan As ComboBox
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents gbDetail As GroupBox
    Friend WithEvents dgvDetail As DataGridView
    Friend WithEvents btnTambahkan As Button
    Friend WithEvents lblPekerjaan As Label
    Friend WithEvents rtbPekerjaan As RichTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblSD2 As Label
    Friend WithEvents dtpSelesai As DateTimePicker
    Friend WithEvents lblJadwal As Label
    Friend WithEvents dtpMulai As DateTimePicker
    Friend WithEvents btnReload As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents btnCetak As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents pnlCetak As Panel
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents tbNamaSimpan As TextBox
    Friend WithEvents tbPathSimpan As TextBox
    Friend WithEvents lblNamaSimpan As Label
    Friend WithEvents lblSimpanKeDrive As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboDepartemen As ComboBox
    Friend WithEvents lblDepartemen As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblPeriode As Label
    Friend WithEvents dtpPeriodeMulai As DateTimePicker
    Friend WithEvents lblSD1 As Label
    Friend WithEvents dtpPeriodeSelesai As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents lblSPKOke As Label
    Friend WithEvents cboLokasi As ComboBox
    Friend WithEvents lblLokasi As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblShift As Label
    Friend WithEvents tbShift As TextBox
End Class
