<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSuratPeringatan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSuratPeringatan))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblKriteria = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.lblPilihanData = New System.Windows.Forms.Label()
        Me.btnBackupDataLama = New System.Windows.Forms.Button()
        Me.pnlPilihanData = New System.Windows.Forms.Panel()
        Me.rbHistory = New System.Windows.Forms.RadioButton()
        Me.rbAktif = New System.Windows.Forms.RadioButton()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.lblBagian = New System.Windows.Forms.Label()
        Me.tbBagian = New System.Windows.Forms.TextBox()
        Me.lblDivisi = New System.Windows.Forms.Label()
        Me.tbDivisi = New System.Windows.Forms.TextBox()
        Me.lblDepartemen = New System.Windows.Forms.Label()
        Me.tbDepartemen = New System.Windows.Forms.TextBox()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.tbPerusahaan = New System.Windows.Forms.TextBox()
        Me.pnlAttachmentLama = New System.Windows.Forms.Panel()
        Me.tbNamaFile = New System.Windows.Forms.TextBox()
        Me.lnklblAttachment = New System.Windows.Forms.LinkLabel()
        Me.lblAttachment = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbSPKe = New System.Windows.Forms.TextBox()
        Me.lblSPKeBerapa = New System.Windows.Forms.Label()
        Me.rtbSanksi = New System.Windows.Forms.RichTextBox()
        Me.lblSanksi = New System.Windows.Forms.Label()
        Me.rtbKeterangan = New System.Windows.Forms.RichTextBox()
        Me.lblKeterangan = New System.Windows.Forms.Label()
        Me.tbKesalahan = New System.Windows.Forms.TextBox()
        Me.lblKesalahan = New System.Windows.Forms.Label()
        Me.lblJenisSP = New System.Windows.Forms.Label()
        Me.pnlJenisSP = New System.Windows.Forms.Panel()
        Me.rbTertulis = New System.Windows.Forms.RadioButton()
        Me.rbLisan = New System.Windows.Forms.RadioButton()
        Me.cboKepala = New System.Windows.Forms.ComboBox()
        Me.lblKepala = New System.Windows.Forms.Label()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigasi.SuspendLayout()
        Me.gbView.SuspendLayout()
        Me.pnlPilihanData.SuspendLayout()
        Me.gbDataEntry.SuspendLayout()
        Me.pnlAttachmentLama.SuspendLayout()
        Me.pnlJenisSP.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(1084, 25)
        Me.lblTitle.TabIndex = 17
        Me.lblTitle.Text = "SURAT PERINGATAN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKriteria
        '
        Me.lblKriteria.AutoSize = True
        Me.lblKriteria.Location = New System.Drawing.Point(7, 25)
        Me.lblKriteria.Name = "lblKriteria"
        Me.lblKriteria.Size = New System.Drawing.Size(50, 15)
        Me.lblKriteria.TabIndex = 2
        Me.lblKriteria.Text = "Kriteria :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(443, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "*"
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(682, 8)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 10
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(100, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(31, 23)
        Me.btnBack.TabIndex = 165
        Me.btnBack.Text = "<"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnFFBack
        '
        Me.btnFFBack.Location = New System.Drawing.Point(63, 3)
        Me.btnFFBack.Name = "btnFFBack"
        Me.btnFFBack.Size = New System.Drawing.Size(31, 23)
        Me.btnFFBack.TabIndex = 164
        Me.btnFFBack.Text = "<<"
        Me.btnFFBack.UseVisualStyleBackColor = True
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.Location = New System.Drawing.Point(7, 7)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(50, 15)
        Me.lblRecord.TabIndex = 163
        Me.lblRecord.Text = "Record :"
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(190, 22)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(339, 23)
        Me.tbCari.TabIndex = 9
        '
        'btnForward
        '
        Me.btnForward.Location = New System.Drawing.Point(213, 4)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(31, 23)
        Me.btnForward.TabIndex = 167
        Me.btnForward.Text = ">"
        Me.btnForward.UseVisualStyleBackColor = True
        '
        'cboKaryawan
        '
        Me.cboKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.IntegralHeight = False
        Me.cboKaryawan.Location = New System.Drawing.Point(99, 22)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(338, 23)
        Me.cboKaryawan.TabIndex = 1
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Location = New System.Drawing.Point(29, 25)
        Me.lblKaryawan.Name = "lblKaryawan"
        Me.lblKaryawan.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawan.TabIndex = 33
        Me.lblKaryawan.Text = "Karyawan :"
        '
        'tbRecordPage
        '
        Me.tbRecordPage.Location = New System.Drawing.Point(137, 4)
        Me.tbRecordPage.Name = "tbRecordPage"
        Me.tbRecordPage.Size = New System.Drawing.Size(70, 23)
        Me.tbRecordPage.TabIndex = 166
        Me.tbRecordPage.Text = "1"
        Me.tbRecordPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(672, 242)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 8
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Location = New System.Drawing.Point(6, 70)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.RowTemplate.Height = 25
        Me.dgvView.Size = New System.Drawing.Size(1048, 255)
        Me.dgvView.TabIndex = 0
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(546, 242)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 7
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'lblOfPages
        '
        Me.lblOfPages.AutoSize = True
        Me.lblOfPages.Location = New System.Drawing.Point(324, 11)
        Me.lblOfPages.Name = "lblOfPages"
        Me.lblOfPages.Size = New System.Drawing.Size(79, 15)
        Me.lblOfPages.TabIndex = 170
        Me.lblOfPages.Text = "of : X Records"
        '
        'btnAddNew
        '
        Me.btnAddNew.Enabled = False
        Me.btnAddNew.Location = New System.Drawing.Point(287, 4)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(31, 23)
        Me.btnAddNew.TabIndex = 169
        Me.btnAddNew.Text = ">*"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'pnlNavigasi
        '
        Me.pnlNavigasi.Controls.Add(Me.lblOfPages)
        Me.pnlNavigasi.Controls.Add(Me.btnAddNew)
        Me.pnlNavigasi.Controls.Add(Me.btnFFForward)
        Me.pnlNavigasi.Controls.Add(Me.btnForward)
        Me.pnlNavigasi.Controls.Add(Me.tbRecordPage)
        Me.pnlNavigasi.Controls.Add(Me.btnBack)
        Me.pnlNavigasi.Controls.Add(Me.btnFFBack)
        Me.pnlNavigasi.Controls.Add(Me.lblRecord)
        Me.pnlNavigasi.Location = New System.Drawing.Point(7, 331)
        Me.pnlNavigasi.Name = "pnlNavigasi"
        Me.pnlNavigasi.Size = New System.Drawing.Size(415, 30)
        Me.pnlNavigasi.TabIndex = 7
        '
        'btnFFForward
        '
        Me.btnFFForward.Location = New System.Drawing.Point(250, 4)
        Me.btnFFForward.Name = "btnFFForward"
        Me.btnFFForward.Size = New System.Drawing.Size(31, 23)
        Me.btnFFForward.TabIndex = 168
        Me.btnFFForward.Text = ">>"
        Me.btnFFForward.UseVisualStyleBackColor = True
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.lblPilihanData)
        Me.gbView.Controls.Add(Me.btnBackupDataLama)
        Me.gbView.Controls.Add(Me.pnlPilihanData)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.lblKriteria)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 334)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(1060, 368)
        Me.gbView.TabIndex = 46
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'lblPilihanData
        '
        Me.lblPilihanData.AutoSize = True
        Me.lblPilihanData.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblPilihanData.ForeColor = System.Drawing.Color.Blue
        Me.lblPilihanData.Location = New System.Drawing.Point(45, -3)
        Me.lblPilihanData.Name = "lblPilihanData"
        Me.lblPilihanData.Size = New System.Drawing.Size(98, 21)
        Me.lblPilihanData.TabIndex = 55
        Me.lblPilihanData.Text = "DATA AKTIF"
        '
        'btnBackupDataLama
        '
        Me.btnBackupDataLama.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnBackupDataLama.Image = CType(resources.GetObject("btnBackupDataLama.Image"), System.Drawing.Image)
        Me.btnBackupDataLama.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBackupDataLama.Location = New System.Drawing.Point(808, 10)
        Me.btnBackupDataLama.Name = "btnBackupDataLama"
        Me.btnBackupDataLama.Size = New System.Drawing.Size(120, 54)
        Me.btnBackupDataLama.TabIndex = 11
        Me.btnBackupDataLama.Text = "BACKUP"
        Me.btnBackupDataLama.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBackupDataLama.UseVisualStyleBackColor = True
        '
        'pnlPilihanData
        '
        Me.pnlPilihanData.Controls.Add(Me.rbHistory)
        Me.pnlPilihanData.Controls.Add(Me.rbAktif)
        Me.pnlPilihanData.Location = New System.Drawing.Point(535, 20)
        Me.pnlPilihanData.Name = "pnlPilihanData"
        Me.pnlPilihanData.Size = New System.Drawing.Size(141, 25)
        Me.pnlPilihanData.TabIndex = 54
        '
        'rbHistory
        '
        Me.rbHistory.AutoSize = True
        Me.rbHistory.Location = New System.Drawing.Point(72, 4)
        Me.rbHistory.Name = "rbHistory"
        Me.rbHistory.Size = New System.Drawing.Size(63, 19)
        Me.rbHistory.TabIndex = 52
        Me.rbHistory.Text = "History"
        Me.rbHistory.UseVisualStyleBackColor = True
        '
        'rbAktif
        '
        Me.rbAktif.AutoSize = True
        Me.rbAktif.Checked = True
        Me.rbAktif.Location = New System.Drawing.Point(6, 4)
        Me.rbAktif.Name = "rbAktif"
        Me.rbAktif.Size = New System.Drawing.Size(50, 19)
        Me.rbAktif.TabIndex = 51
        Me.rbAktif.TabStop = True
        Me.rbAktif.Text = "Aktif"
        Me.rbAktif.UseVisualStyleBackColor = True
        '
        'cboKriteria
        '
        Me.cboKriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKriteria.FormattingEnabled = True
        Me.cboKriteria.Location = New System.Drawing.Point(63, 22)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(121, 23)
        Me.cboKriteria.TabIndex = 6
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(972, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 45
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(816, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 44
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(816, 52)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 12
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.lblBagian)
        Me.gbDataEntry.Controls.Add(Me.tbBagian)
        Me.gbDataEntry.Controls.Add(Me.lblDivisi)
        Me.gbDataEntry.Controls.Add(Me.tbDivisi)
        Me.gbDataEntry.Controls.Add(Me.lblDepartemen)
        Me.gbDataEntry.Controls.Add(Me.tbDepartemen)
        Me.gbDataEntry.Controls.Add(Me.lblPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.tbPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.pnlAttachmentLama)
        Me.gbDataEntry.Controls.Add(Me.Label4)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.tbSPKe)
        Me.gbDataEntry.Controls.Add(Me.lblSPKeBerapa)
        Me.gbDataEntry.Controls.Add(Me.rtbSanksi)
        Me.gbDataEntry.Controls.Add(Me.lblSanksi)
        Me.gbDataEntry.Controls.Add(Me.rtbKeterangan)
        Me.gbDataEntry.Controls.Add(Me.lblKeterangan)
        Me.gbDataEntry.Controls.Add(Me.tbKesalahan)
        Me.gbDataEntry.Controls.Add(Me.lblKesalahan)
        Me.gbDataEntry.Controls.Add(Me.lblJenisSP)
        Me.gbDataEntry.Controls.Add(Me.pnlJenisSP)
        Me.gbDataEntry.Controls.Add(Me.cboKepala)
        Me.gbDataEntry.Controls.Add(Me.lblKepala)
        Me.gbDataEntry.Controls.Add(Me.lblTanggal)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggal)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.cboKaryawan)
        Me.gbDataEntry.Controls.Add(Me.lblKaryawan)
        Me.gbDataEntry.Controls.Add(Me.btnKeluar)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(798, 300)
        Me.gbDataEntry.TabIndex = 43
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'lblBagian
        '
        Me.lblBagian.AutoSize = True
        Me.lblBagian.Location = New System.Drawing.Point(606, 49)
        Me.lblBagian.Name = "lblBagian"
        Me.lblBagian.Size = New System.Drawing.Size(49, 15)
        Me.lblBagian.TabIndex = 85
        Me.lblBagian.Text = "Bagian :"
        '
        'tbBagian
        '
        Me.tbBagian.Location = New System.Drawing.Point(661, 46)
        Me.tbBagian.Name = "tbBagian"
        Me.tbBagian.ReadOnly = True
        Me.tbBagian.Size = New System.Drawing.Size(131, 23)
        Me.tbBagian.TabIndex = 83
        '
        'lblDivisi
        '
        Me.lblDivisi.AutoSize = True
        Me.lblDivisi.Location = New System.Drawing.Point(456, 49)
        Me.lblDivisi.Name = "lblDivisi"
        Me.lblDivisi.Size = New System.Drawing.Size(41, 15)
        Me.lblDivisi.TabIndex = 83
        Me.lblDivisi.Text = "Divisi :"
        '
        'tbDivisi
        '
        Me.tbDivisi.Location = New System.Drawing.Point(503, 46)
        Me.tbDivisi.Name = "tbDivisi"
        Me.tbDivisi.ReadOnly = True
        Me.tbDivisi.Size = New System.Drawing.Size(97, 23)
        Me.tbDivisi.TabIndex = 82
        '
        'lblDepartemen
        '
        Me.lblDepartemen.AutoSize = True
        Me.lblDepartemen.Location = New System.Drawing.Point(280, 49)
        Me.lblDepartemen.Name = "lblDepartemen"
        Me.lblDepartemen.Size = New System.Drawing.Size(78, 15)
        Me.lblDepartemen.TabIndex = 81
        Me.lblDepartemen.Text = "Departemen :"
        '
        'tbDepartemen
        '
        Me.tbDepartemen.Location = New System.Drawing.Point(364, 46)
        Me.tbDepartemen.Name = "tbDepartemen"
        Me.tbDepartemen.ReadOnly = True
        Me.tbDepartemen.Size = New System.Drawing.Size(86, 23)
        Me.tbDepartemen.TabIndex = 81
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Location = New System.Drawing.Point(19, 49)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaan.TabIndex = 79
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'tbPerusahaan
        '
        Me.tbPerusahaan.Location = New System.Drawing.Point(99, 46)
        Me.tbPerusahaan.Name = "tbPerusahaan"
        Me.tbPerusahaan.ReadOnly = True
        Me.tbPerusahaan.Size = New System.Drawing.Size(175, 23)
        Me.tbPerusahaan.TabIndex = 80
        '
        'pnlAttachmentLama
        '
        Me.pnlAttachmentLama.Controls.Add(Me.tbNamaFile)
        Me.pnlAttachmentLama.Controls.Add(Me.lnklblAttachment)
        Me.pnlAttachmentLama.Controls.Add(Me.lblAttachment)
        Me.pnlAttachmentLama.Controls.Add(Me.btnBrowse)
        Me.pnlAttachmentLama.Location = New System.Drawing.Point(6, 246)
        Me.pnlAttachmentLama.Name = "pnlAttachmentLama"
        Me.pnlAttachmentLama.Size = New System.Drawing.Size(15, 15)
        Me.pnlAttachmentLama.TabIndex = 77
        Me.pnlAttachmentLama.Visible = False
        '
        'tbNamaFile
        '
        Me.tbNamaFile.Location = New System.Drawing.Point(3, 27)
        Me.tbNamaFile.Name = "tbNamaFile"
        Me.tbNamaFile.ReadOnly = True
        Me.tbNamaFile.Size = New System.Drawing.Size(216, 23)
        Me.tbNamaFile.TabIndex = 76
        '
        'lnklblAttachment
        '
        Me.lnklblAttachment.AutoSize = True
        Me.lnklblAttachment.Location = New System.Drawing.Point(3, 53)
        Me.lnklblAttachment.Name = "lnklblAttachment"
        Me.lnklblAttachment.Size = New System.Drawing.Size(70, 15)
        Me.lnklblAttachment.TabIndex = 47
        Me.lnklblAttachment.TabStop = True
        Me.lnklblAttachment.Text = "Attachment"
        '
        'lblAttachment
        '
        Me.lblAttachment.AutoSize = True
        Me.lblAttachment.Location = New System.Drawing.Point(3, 9)
        Me.lblAttachment.Name = "lblAttachment"
        Me.lblAttachment.Size = New System.Drawing.Size(70, 15)
        Me.lblAttachment.TabIndex = 74
        Me.lblAttachment.Text = "Attachment"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(219, 26)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 24)
        Me.btnBrowse.TabIndex = 75
        Me.btnBrowse.Text = ",.."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(676, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(683, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(443, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "*"
        '
        'tbSPKe
        '
        Me.tbSPKe.Location = New System.Drawing.Point(316, 102)
        Me.tbSPKe.Name = "tbSPKe"
        Me.tbSPKe.ReadOnly = True
        Me.tbSPKe.Size = New System.Drawing.Size(60, 23)
        Me.tbSPKe.TabIndex = 69
        Me.tbSPKe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSPKeBerapa
        '
        Me.lblSPKeBerapa.AutoSize = True
        Me.lblSPKeBerapa.Location = New System.Drawing.Point(268, 105)
        Me.lblSPKeBerapa.Name = "lblSPKeBerapa"
        Me.lblSPKeBerapa.Size = New System.Drawing.Size(42, 15)
        Me.lblSPKeBerapa.TabIndex = 70
        Me.lblSPKeBerapa.Text = "SP Ke :"
        '
        'rtbSanksi
        '
        Me.rtbSanksi.Location = New System.Drawing.Point(99, 196)
        Me.rtbSanksi.Name = "rtbSanksi"
        Me.rtbSanksi.Size = New System.Drawing.Size(693, 40)
        Me.rtbSanksi.TabIndex = 6
        Me.rtbSanksi.Text = ""
        '
        'lblSanksi
        '
        Me.lblSanksi.AutoSize = True
        Me.lblSanksi.Location = New System.Drawing.Point(47, 199)
        Me.lblSanksi.Name = "lblSanksi"
        Me.lblSanksi.Size = New System.Drawing.Size(46, 15)
        Me.lblSanksi.TabIndex = 67
        Me.lblSanksi.Text = "Sanksi :"
        '
        'rtbKeterangan
        '
        Me.rtbKeterangan.Location = New System.Drawing.Point(99, 155)
        Me.rtbKeterangan.Name = "rtbKeterangan"
        Me.rtbKeterangan.Size = New System.Drawing.Size(693, 40)
        Me.rtbKeterangan.TabIndex = 5
        Me.rtbKeterangan.Text = ""
        '
        'lblKeterangan
        '
        Me.lblKeterangan.AutoSize = True
        Me.lblKeterangan.Location = New System.Drawing.Point(20, 158)
        Me.lblKeterangan.Name = "lblKeterangan"
        Me.lblKeterangan.Size = New System.Drawing.Size(73, 15)
        Me.lblKeterangan.TabIndex = 65
        Me.lblKeterangan.Text = "Keterangan :"
        '
        'tbKesalahan
        '
        Me.tbKesalahan.Location = New System.Drawing.Point(99, 131)
        Me.tbKesalahan.Name = "tbKesalahan"
        Me.tbKesalahan.Size = New System.Drawing.Size(578, 23)
        Me.tbKesalahan.TabIndex = 4
        '
        'lblKesalahan
        '
        Me.lblKesalahan.AutoSize = True
        Me.lblKesalahan.Location = New System.Drawing.Point(27, 134)
        Me.lblKesalahan.Name = "lblKesalahan"
        Me.lblKesalahan.Size = New System.Drawing.Size(66, 15)
        Me.lblKesalahan.TabIndex = 63
        Me.lblKesalahan.Text = "Kesalahan :"
        '
        'lblJenisSP
        '
        Me.lblJenisSP.AutoSize = True
        Me.lblJenisSP.Location = New System.Drawing.Point(39, 105)
        Me.lblJenisSP.Name = "lblJenisSP"
        Me.lblJenisSP.Size = New System.Drawing.Size(54, 15)
        Me.lblJenisSP.TabIndex = 61
        Me.lblJenisSP.Text = "Jenis SP :"
        '
        'pnlJenisSP
        '
        Me.pnlJenisSP.Controls.Add(Me.rbTertulis)
        Me.pnlJenisSP.Controls.Add(Me.rbLisan)
        Me.pnlJenisSP.Location = New System.Drawing.Point(99, 100)
        Me.pnlJenisSP.Name = "pnlJenisSP"
        Me.pnlJenisSP.Size = New System.Drawing.Size(152, 25)
        Me.pnlJenisSP.TabIndex = 60
        '
        'rbTertulis
        '
        Me.rbTertulis.AutoSize = True
        Me.rbTertulis.Location = New System.Drawing.Point(61, 3)
        Me.rbTertulis.Name = "rbTertulis"
        Me.rbTertulis.Size = New System.Drawing.Size(62, 19)
        Me.rbTertulis.TabIndex = 1
        Me.rbTertulis.Text = "Tertulis"
        Me.rbTertulis.UseVisualStyleBackColor = True
        '
        'rbLisan
        '
        Me.rbLisan.AutoSize = True
        Me.rbLisan.Checked = True
        Me.rbLisan.Location = New System.Drawing.Point(3, 3)
        Me.rbLisan.Name = "rbLisan"
        Me.rbLisan.Size = New System.Drawing.Size(52, 19)
        Me.rbLisan.TabIndex = 0
        Me.rbLisan.TabStop = True
        Me.rbLisan.Text = "Lisan"
        Me.rbLisan.UseVisualStyleBackColor = True
        '
        'cboKepala
        '
        Me.cboKepala.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKepala.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKepala.FormattingEnabled = True
        Me.cboKepala.IntegralHeight = False
        Me.cboKepala.Location = New System.Drawing.Point(99, 71)
        Me.cboKepala.Name = "cboKepala"
        Me.cboKepala.Size = New System.Drawing.Size(338, 23)
        Me.cboKepala.TabIndex = 3
        '
        'lblKepala
        '
        Me.lblKepala.AutoSize = True
        Me.lblKepala.Location = New System.Drawing.Point(45, 74)
        Me.lblKepala.Name = "lblKepala"
        Me.lblKepala.Size = New System.Drawing.Size(48, 15)
        Me.lblKepala.TabIndex = 59
        Me.lblKepala.Text = "Kepala :"
        '
        'lblTanggal
        '
        Me.lblTanggal.AutoSize = True
        Me.lblTanggal.Location = New System.Drawing.Point(491, 28)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(54, 15)
        Me.lblTanggal.TabIndex = 57
        Me.lblTanggal.Text = "Tanggal :"
        '
        'dtpTanggal
        '
        Me.dtpTanggal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggal.Location = New System.Drawing.Point(551, 22)
        Me.dtpTanggal.Name = "dtpTanggal"
        Me.dtpTanggal.Size = New System.Drawing.Size(119, 23)
        Me.dtpTanggal.TabIndex = 2
        '
        'ofd1
        '
        '
        'FormSuratPeringatan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1084, 706)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSuratPeringatan"
        Me.Text = "FORM SURAT PERINGATAN"
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlPilihanData.ResumeLayout(False)
        Me.pnlPilihanData.PerformLayout()
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.pnlAttachmentLama.ResumeLayout(False)
        Me.pnlAttachmentLama.PerformLayout()
        Me.pnlJenisSP.ResumeLayout(False)
        Me.pnlJenisSP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblKriteria As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnFFBack As Button
    Friend WithEvents lblRecord As Label
    Friend WithEvents tbCari As TextBox
    Friend WithEvents btnForward As Button
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents btnSimpan As Button
    Friend WithEvents lblOfPages As Label
    Friend WithEvents btnAddNew As Button
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents btnFFForward As Button
    Friend WithEvents gbView As GroupBox
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents lblTanggal As Label
    Friend WithEvents dtpTanggal As DateTimePicker
    Friend WithEvents cboKepala As ComboBox
    Friend WithEvents lblKepala As Label
    Friend WithEvents pnlJenisSP As Panel
    Friend WithEvents rbTertulis As RadioButton
    Friend WithEvents rbLisan As RadioButton
    Friend WithEvents lblJenisSP As Label
    Friend WithEvents tbKesalahan As TextBox
    Friend WithEvents lblKesalahan As Label
    Friend WithEvents rtbKeterangan As RichTextBox
    Friend WithEvents lblKeterangan As Label
    Friend WithEvents lblSanksi As Label
    Friend WithEvents rtbSanksi As RichTextBox
    Friend WithEvents tbSPKe As TextBox
    Friend WithEvents lblSPKeBerapa As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblAttachment As Label
    Friend WithEvents tbNamaFile As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents lnklblAttachment As LinkLabel
    Friend WithEvents ofd1 As OpenFileDialog
    Friend WithEvents pnlPilihanData As Panel
    Friend WithEvents rbHistory As RadioButton
    Friend WithEvents rbAktif As RadioButton
    Friend WithEvents btnBackupDataLama As Button
    Friend WithEvents lblPilihanData As Label
    Friend WithEvents pnlAttachmentLama As Panel
    Friend WithEvents tbPerusahaan As TextBox
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents lblDepartemen As Label
    Friend WithEvents tbDepartemen As TextBox
    Friend WithEvents lblDivisi As Label
    Friend WithEvents tbDivisi As TextBox
    Friend WithEvents lblBagian As Label
    Friend WithEvents tbBagian As TextBox
End Class
