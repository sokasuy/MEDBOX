<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSuratPeringatan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSuratPeringatan))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.btnBackupDataLama = New System.Windows.Forms.Button()
        Me.lblPilihanData = New System.Windows.Forms.Label()
        Me.pnlPilihanData = New System.Windows.Forms.Panel()
        Me.rbHistory = New System.Windows.Forms.RadioButton()
        Me.rbAktif = New System.Windows.Forms.RadioButton()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.lblCari = New System.Windows.Forms.Label()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.lblSanksi = New System.Windows.Forms.Label()
        Me.rtbSanksi = New System.Windows.Forms.RichTextBox()
        Me.lblKeterangan = New System.Windows.Forms.Label()
        Me.rtbKeterangan = New System.Windows.Forms.RichTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblKesalahan = New System.Windows.Forms.Label()
        Me.tbKesalahan = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSPKeBerapa = New System.Windows.Forms.Label()
        Me.tbSPKe = New System.Windows.Forms.TextBox()
        Me.lblJenisSP = New System.Windows.Forms.Label()
        Me.pnlJenisSP = New System.Windows.Forms.Panel()
        Me.rbTertulis = New System.Windows.Forms.RadioButton()
        Me.rbLisan = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboKepala = New System.Windows.Forms.ComboBox()
        Me.lblKepala = New System.Windows.Forms.Label()
        Me.lblBagian = New System.Windows.Forms.Label()
        Me.tbBagian = New System.Windows.Forms.TextBox()
        Me.lblDivisi = New System.Windows.Forms.Label()
        Me.tbDivisi = New System.Windows.Forms.TextBox()
        Me.lblDepartemen = New System.Windows.Forms.Label()
        Me.tbDepartemen = New System.Windows.Forms.TextBox()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.tbPerusahaan = New System.Windows.Forms.TextBox()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbView.SuspendLayout()
        Me.pnlPilihanData.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDataEntry.SuspendLayout()
        Me.pnlJenisSP.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(1084, 25)
        Me.lblTitle.TabIndex = 179
        Me.lblTitle.Text = "SURAT PERINGATAN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.btnBackupDataLama)
        Me.gbView.Controls.Add(Me.lblPilihanData)
        Me.gbView.Controls.Add(Me.pnlPilihanData)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 332)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(1060, 370)
        Me.gbView.TabIndex = 193
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'btnBackupDataLama
        '
        Me.btnBackupDataLama.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackupDataLama.Image = CType(resources.GetObject("btnBackupDataLama.Image"), System.Drawing.Image)
        Me.btnBackupDataLama.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBackupDataLama.Location = New System.Drawing.Point(833, 11)
        Me.btnBackupDataLama.Name = "btnBackupDataLama"
        Me.btnBackupDataLama.Size = New System.Drawing.Size(120, 54)
        Me.btnBackupDataLama.TabIndex = 11
        Me.btnBackupDataLama.Text = "BACKUP"
        Me.btnBackupDataLama.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBackupDataLama.UseVisualStyleBackColor = True
        '
        'lblPilihanData
        '
        Me.lblPilihanData.AutoSize = True
        Me.lblPilihanData.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPilihanData.ForeColor = System.Drawing.Color.Blue
        Me.lblPilihanData.Location = New System.Drawing.Point(46, -4)
        Me.lblPilihanData.Name = "lblPilihanData"
        Me.lblPilihanData.Size = New System.Drawing.Size(98, 21)
        Me.lblPilihanData.TabIndex = 194
        Me.lblPilihanData.Text = "DATA AKTIF"
        '
        'pnlPilihanData
        '
        Me.pnlPilihanData.Controls.Add(Me.rbHistory)
        Me.pnlPilihanData.Controls.Add(Me.rbAktif)
        Me.pnlPilihanData.Location = New System.Drawing.Point(570, 29)
        Me.pnlPilihanData.Name = "pnlPilihanData"
        Me.pnlPilihanData.Size = New System.Drawing.Size(131, 25)
        Me.pnlPilihanData.TabIndex = 199
        '
        'rbHistory
        '
        Me.rbHistory.AutoSize = True
        Me.rbHistory.Location = New System.Drawing.Point(59, 4)
        Me.rbHistory.Name = "rbHistory"
        Me.rbHistory.Size = New System.Drawing.Size(57, 17)
        Me.rbHistory.TabIndex = 1
        Me.rbHistory.Text = "History"
        Me.rbHistory.UseVisualStyleBackColor = True
        '
        'rbAktif
        '
        Me.rbAktif.AutoSize = True
        Me.rbAktif.Checked = True
        Me.rbAktif.Location = New System.Drawing.Point(3, 4)
        Me.rbAktif.Name = "rbAktif"
        Me.rbAktif.Size = New System.Drawing.Size(46, 17)
        Me.rbAktif.TabIndex = 0
        Me.rbAktif.TabStop = True
        Me.rbAktif.Text = "Aktif"
        Me.rbAktif.UseVisualStyleBackColor = True
        '
        'pnlNavigasi
        '
        Me.pnlNavigasi.Controls.Add(Me.btnAddNew)
        Me.pnlNavigasi.Controls.Add(Me.btnFFBack)
        Me.pnlNavigasi.Controls.Add(Me.lblRecord)
        Me.pnlNavigasi.Controls.Add(Me.btnForward)
        Me.pnlNavigasi.Controls.Add(Me.lblOfPages)
        Me.pnlNavigasi.Controls.Add(Me.tbRecordPage)
        Me.pnlNavigasi.Controls.Add(Me.btnFFForward)
        Me.pnlNavigasi.Controls.Add(Me.btnBack)
        Me.pnlNavigasi.Location = New System.Drawing.Point(6, 334)
        Me.pnlNavigasi.Name = "pnlNavigasi"
        Me.pnlNavigasi.Size = New System.Drawing.Size(425, 29)
        Me.pnlNavigasi.TabIndex = 172
        '
        'btnAddNew
        '
        Me.btnAddNew.Enabled = False
        Me.btnAddNew.Location = New System.Drawing.Point(280, 3)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(31, 23)
        Me.btnAddNew.TabIndex = 169
        Me.btnAddNew.Text = ">*"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnFFBack
        '
        Me.btnFFBack.Location = New System.Drawing.Point(56, 3)
        Me.btnFFBack.Name = "btnFFBack"
        Me.btnFFBack.Size = New System.Drawing.Size(31, 23)
        Me.btnFFBack.TabIndex = 164
        Me.btnFFBack.Text = "<<"
        Me.btnFFBack.UseVisualStyleBackColor = True
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.Location = New System.Drawing.Point(2, 8)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(38, 13)
        Me.lblRecord.TabIndex = 163
        Me.lblRecord.Text = "Page :"
        '
        'btnForward
        '
        Me.btnForward.Location = New System.Drawing.Point(206, 3)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(31, 23)
        Me.btnForward.TabIndex = 167
        Me.btnForward.Text = ">"
        Me.btnForward.UseVisualStyleBackColor = True
        '
        'lblOfPages
        '
        Me.lblOfPages.AutoSize = True
        Me.lblOfPages.Location = New System.Drawing.Point(317, 8)
        Me.lblOfPages.Name = "lblOfPages"
        Me.lblOfPages.Size = New System.Drawing.Size(65, 13)
        Me.lblOfPages.TabIndex = 170
        Me.lblOfPages.Text = "Of : x Pages"
        '
        'tbRecordPage
        '
        Me.tbRecordPage.Location = New System.Drawing.Point(130, 5)
        Me.tbRecordPage.Name = "tbRecordPage"
        Me.tbRecordPage.Size = New System.Drawing.Size(70, 20)
        Me.tbRecordPage.TabIndex = 166
        Me.tbRecordPage.Text = "1"
        Me.tbRecordPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnFFForward
        '
        Me.btnFFForward.Location = New System.Drawing.Point(243, 3)
        Me.btnFFForward.Name = "btnFFForward"
        Me.btnFFForward.Size = New System.Drawing.Size(31, 23)
        Me.btnFFForward.TabIndex = 168
        Me.btnFFForward.Text = ">>"
        Me.btnFFForward.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(93, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(31, 23)
        Me.btnBack.TabIndex = 165
        Me.btnBack.Text = "<"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(184, 29)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(380, 20)
        Me.tbCari.TabIndex = 9
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(707, 11)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 10
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Location = New System.Drawing.Point(11, 32)
        Me.lblCari.Name = "lblCari"
        Me.lblCari.Size = New System.Drawing.Size(45, 13)
        Me.lblCari.TabIndex = 132
        Me.lblCari.Text = "Kriteria :"
        '
        'cboKriteria
        '
        Me.cboKriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKriteria.FormattingEnabled = True
        Me.cboKriteria.Location = New System.Drawing.Point(62, 29)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboKriteria.TabIndex = 11
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Location = New System.Drawing.Point(6, 67)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.Size = New System.Drawing.Size(1048, 263)
        Me.dgvView.TabIndex = 130
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.lblSanksi)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.rtbSanksi)
        Me.gbDataEntry.Controls.Add(Me.lblKeterangan)
        Me.gbDataEntry.Controls.Add(Me.rtbKeterangan)
        Me.gbDataEntry.Controls.Add(Me.Label5)
        Me.gbDataEntry.Controls.Add(Me.lblKesalahan)
        Me.gbDataEntry.Controls.Add(Me.tbKesalahan)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.lblSPKeBerapa)
        Me.gbDataEntry.Controls.Add(Me.tbSPKe)
        Me.gbDataEntry.Controls.Add(Me.lblJenisSP)
        Me.gbDataEntry.Controls.Add(Me.pnlJenisSP)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.cboKepala)
        Me.gbDataEntry.Controls.Add(Me.lblKepala)
        Me.gbDataEntry.Controls.Add(Me.lblBagian)
        Me.gbDataEntry.Controls.Add(Me.tbBagian)
        Me.gbDataEntry.Controls.Add(Me.lblDivisi)
        Me.gbDataEntry.Controls.Add(Me.tbDivisi)
        Me.gbDataEntry.Controls.Add(Me.lblDepartemen)
        Me.gbDataEntry.Controls.Add(Me.tbDepartemen)
        Me.gbDataEntry.Controls.Add(Me.lblPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.tbPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.lblTanggal)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggal)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.cboKaryawan)
        Me.gbDataEntry.Controls.Add(Me.lblKaryawan)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(800, 300)
        Me.gbDataEntry.TabIndex = 194
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'lblSanksi
        '
        Me.lblSanksi.AutoSize = True
        Me.lblSanksi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSanksi.Location = New System.Drawing.Point(47, 184)
        Me.lblSanksi.Name = "lblSanksi"
        Me.lblSanksi.Size = New System.Drawing.Size(46, 15)
        Me.lblSanksi.TabIndex = 243
        Me.lblSanksi.Text = "Sanksi :"
        '
        'rtbSanksi
        '
        Me.rtbSanksi.Location = New System.Drawing.Point(99, 181)
        Me.rtbSanksi.Name = "rtbSanksi"
        Me.rtbSanksi.Size = New System.Drawing.Size(695, 49)
        Me.rtbSanksi.TabIndex = 6
        Me.rtbSanksi.Text = ""
        '
        'lblKeterangan
        '
        Me.lblKeterangan.AutoSize = True
        Me.lblKeterangan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKeterangan.Location = New System.Drawing.Point(20, 142)
        Me.lblKeterangan.Name = "lblKeterangan"
        Me.lblKeterangan.Size = New System.Drawing.Size(73, 15)
        Me.lblKeterangan.TabIndex = 241
        Me.lblKeterangan.Text = "Keterangan :"
        '
        'rtbKeterangan
        '
        Me.rtbKeterangan.Location = New System.Drawing.Point(99, 139)
        Me.rtbKeterangan.Name = "rtbKeterangan"
        Me.rtbKeterangan.Size = New System.Drawing.Size(695, 40)
        Me.rtbKeterangan.TabIndex = 5
        Me.rtbKeterangan.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(617, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 15)
        Me.Label5.TabIndex = 239
        Me.Label5.Text = "*"
        '
        'lblKesalahan
        '
        Me.lblKesalahan.AutoSize = True
        Me.lblKesalahan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKesalahan.Location = New System.Drawing.Point(27, 118)
        Me.lblKesalahan.Name = "lblKesalahan"
        Me.lblKesalahan.Size = New System.Drawing.Size(66, 15)
        Me.lblKesalahan.TabIndex = 238
        Me.lblKesalahan.Text = "Kesalahan :"
        '
        'tbKesalahan
        '
        Me.tbKesalahan.Location = New System.Drawing.Point(99, 115)
        Me.tbKesalahan.Name = "tbKesalahan"
        Me.tbKesalahan.Size = New System.Drawing.Size(512, 23)
        Me.tbKesalahan.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(779, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 236
        Me.Label3.Text = "*"
        '
        'lblSPKeBerapa
        '
        Me.lblSPKeBerapa.AutoSize = True
        Me.lblSPKeBerapa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSPKeBerapa.Location = New System.Drawing.Point(239, 91)
        Me.lblSPKeBerapa.Name = "lblSPKeBerapa"
        Me.lblSPKeBerapa.Size = New System.Drawing.Size(42, 15)
        Me.lblSPKeBerapa.TabIndex = 235
        Me.lblSPKeBerapa.Text = "SP Ke :"
        '
        'tbSPKe
        '
        Me.tbSPKe.Location = New System.Drawing.Point(286, 88)
        Me.tbSPKe.Name = "tbSPKe"
        Me.tbSPKe.ReadOnly = True
        Me.tbSPKe.Size = New System.Drawing.Size(90, 23)
        Me.tbSPKe.TabIndex = 234
        '
        'lblJenisSP
        '
        Me.lblJenisSP.AutoSize = True
        Me.lblJenisSP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJenisSP.Location = New System.Drawing.Point(39, 94)
        Me.lblJenisSP.Name = "lblJenisSP"
        Me.lblJenisSP.Size = New System.Drawing.Size(54, 15)
        Me.lblJenisSP.TabIndex = 233
        Me.lblJenisSP.Text = "Jenis SP :"
        '
        'pnlJenisSP
        '
        Me.pnlJenisSP.Controls.Add(Me.rbTertulis)
        Me.pnlJenisSP.Controls.Add(Me.rbLisan)
        Me.pnlJenisSP.Location = New System.Drawing.Point(99, 88)
        Me.pnlJenisSP.Name = "pnlJenisSP"
        Me.pnlJenisSP.Size = New System.Drawing.Size(131, 25)
        Me.pnlJenisSP.TabIndex = 232
        '
        'rbTertulis
        '
        Me.rbTertulis.AutoSize = True
        Me.rbTertulis.Location = New System.Drawing.Point(59, 4)
        Me.rbTertulis.Name = "rbTertulis"
        Me.rbTertulis.Size = New System.Drawing.Size(62, 19)
        Me.rbTertulis.TabIndex = 1
        Me.rbTertulis.TabStop = True
        Me.rbTertulis.Text = "Tertulis"
        Me.rbTertulis.UseVisualStyleBackColor = True
        '
        'rbLisan
        '
        Me.rbLisan.AutoSize = True
        Me.rbLisan.Checked = True
        Me.rbLisan.Location = New System.Drawing.Point(3, 4)
        Me.rbLisan.Name = "rbLisan"
        Me.rbLisan.Size = New System.Drawing.Size(52, 19)
        Me.rbLisan.TabIndex = 0
        Me.rbLisan.TabStop = True
        Me.rbLisan.Text = "Lisan"
        Me.rbLisan.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(490, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 231
        Me.Label1.Text = "*"
        '
        'cboKepala
        '
        Me.cboKepala.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKepala.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKepala.FormattingEnabled = True
        Me.cboKepala.IntegralHeight = False
        Me.cboKepala.Location = New System.Drawing.Point(99, 64)
        Me.cboKepala.Name = "cboKepala"
        Me.cboKepala.Size = New System.Drawing.Size(385, 23)
        Me.cboKepala.TabIndex = 3
        '
        'lblKepala
        '
        Me.lblKepala.AutoSize = True
        Me.lblKepala.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKepala.Location = New System.Drawing.Point(45, 67)
        Me.lblKepala.Name = "lblKepala"
        Me.lblKepala.Size = New System.Drawing.Size(48, 15)
        Me.lblKepala.TabIndex = 230
        Me.lblKepala.Text = "Kepala :"
        '
        'lblBagian
        '
        Me.lblBagian.AutoSize = True
        Me.lblBagian.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBagian.Location = New System.Drawing.Point(617, 43)
        Me.lblBagian.Name = "lblBagian"
        Me.lblBagian.Size = New System.Drawing.Size(49, 15)
        Me.lblBagian.TabIndex = 228
        Me.lblBagian.Text = "Bagian :"
        '
        'tbBagian
        '
        Me.tbBagian.Location = New System.Drawing.Point(672, 40)
        Me.tbBagian.Name = "tbBagian"
        Me.tbBagian.ReadOnly = True
        Me.tbBagian.Size = New System.Drawing.Size(122, 23)
        Me.tbBagian.TabIndex = 227
        '
        'lblDivisi
        '
        Me.lblDivisi.AutoSize = True
        Me.lblDivisi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDivisi.Location = New System.Drawing.Point(474, 43)
        Me.lblDivisi.Name = "lblDivisi"
        Me.lblDivisi.Size = New System.Drawing.Size(41, 15)
        Me.lblDivisi.TabIndex = 226
        Me.lblDivisi.Text = "Divisi :"
        '
        'tbDivisi
        '
        Me.tbDivisi.Location = New System.Drawing.Point(521, 40)
        Me.tbDivisi.Name = "tbDivisi"
        Me.tbDivisi.ReadOnly = True
        Me.tbDivisi.Size = New System.Drawing.Size(90, 23)
        Me.tbDivisi.TabIndex = 225
        '
        'lblDepartemen
        '
        Me.lblDepartemen.AutoSize = True
        Me.lblDepartemen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartemen.Location = New System.Drawing.Point(289, 43)
        Me.lblDepartemen.Name = "lblDepartemen"
        Me.lblDepartemen.Size = New System.Drawing.Size(78, 15)
        Me.lblDepartemen.TabIndex = 224
        Me.lblDepartemen.Text = "Departemen :"
        '
        'tbDepartemen
        '
        Me.tbDepartemen.Location = New System.Drawing.Point(373, 40)
        Me.tbDepartemen.Name = "tbDepartemen"
        Me.tbDepartemen.ReadOnly = True
        Me.tbDepartemen.Size = New System.Drawing.Size(95, 23)
        Me.tbDepartemen.TabIndex = 223
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPerusahaan.Location = New System.Drawing.Point(19, 43)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaan.TabIndex = 222
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'tbPerusahaan
        '
        Me.tbPerusahaan.Location = New System.Drawing.Point(99, 40)
        Me.tbPerusahaan.Name = "tbPerusahaan"
        Me.tbPerusahaan.ReadOnly = True
        Me.tbPerusahaan.Size = New System.Drawing.Size(184, 23)
        Me.tbPerusahaan.TabIndex = 221
        '
        'lblTanggal
        '
        Me.lblTanggal.AutoSize = True
        Me.lblTanggal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTanggal.Location = New System.Drawing.Point(593, 22)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(54, 15)
        Me.lblTanggal.TabIndex = 219
        Me.lblTanggal.Text = "Tanggal :"
        '
        'dtpTanggal
        '
        Me.dtpTanggal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggal.Location = New System.Drawing.Point(653, 16)
        Me.dtpTanggal.Name = "dtpTanggal"
        Me.dtpTanggal.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggal.TabIndex = 2
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(952, 274)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 8
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(674, 240)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 7
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(490, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 217
        Me.Label2.Text = "*"
        '
        'cboKaryawan
        '
        Me.cboKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.IntegralHeight = False
        Me.cboKaryawan.Location = New System.Drawing.Point(99, 16)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(385, 23)
        Me.cboKaryawan.TabIndex = 1
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKaryawan.Location = New System.Drawing.Point(29, 19)
        Me.lblKaryawan.Name = "lblKaryawan"
        Me.lblKaryawan.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawan.TabIndex = 11
        Me.lblKaryawan.Text = "Karyawan :"
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(818, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 197
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(548, 240)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 195
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(972, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 196
        '
        'FormSuratPeringatan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1084, 706)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnKeluar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSuratPeringatan"
        Me.Text = "FORM SURAT PERINGATAN"
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlPilihanData.ResumeLayout(False)
        Me.pnlPilihanData.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.pnlJenisSP.ResumeLayout(False)
        Me.pnlJenisSP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents gbView As GroupBox
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnFFBack As Button
    Friend WithEvents lblRecord As Label
    Friend WithEvents btnForward As Button
    Friend WithEvents lblOfPages As Label
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnFFForward As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents tbCari As TextBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lblCari As Label
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents pnlPilihanData As Panel
    Friend WithEvents rbHistory As RadioButton
    Friend WithEvents rbAktif As RadioButton
    Friend WithEvents lblPilihanData As Label
    Friend WithEvents btnBackupDataLama As Button
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents lblTanggal As Label
    Friend WithEvents dtpTanggal As DateTimePicker
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents tbPerusahaan As TextBox
    Friend WithEvents lblDepartemen As Label
    Friend WithEvents tbDepartemen As TextBox
    Friend WithEvents lblDivisi As Label
    Friend WithEvents tbDivisi As TextBox
    Friend WithEvents lblBagian As Label
    Friend WithEvents tbBagian As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboKepala As ComboBox
    Friend WithEvents lblKepala As Label
    Friend WithEvents lblJenisSP As Label
    Friend WithEvents pnlJenisSP As Panel
    Friend WithEvents rbTertulis As RadioButton
    Friend WithEvents rbLisan As RadioButton
    Friend WithEvents lblSPKeBerapa As Label
    Friend WithEvents tbSPKe As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblKesalahan As Label
    Friend WithEvents tbKesalahan As TextBox
    Friend WithEvents rtbKeterangan As RichTextBox
    Friend WithEvents lblKeterangan As Label
    Friend WithEvents lblSanksi As Label
    Friend WithEvents rtbSanksi As RichTextBox
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents clbUserRight As CheckedListBox
End Class
