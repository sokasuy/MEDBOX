<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAttachmentDokumen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAttachmentDokumen))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.tbLokasiTujuanFile = New System.Windows.Forms.TextBox()
        Me.lblLokasiTujuanFile = New System.Windows.Forms.Label()
        Me.tbExtensionFile = New System.Windows.Forms.TextBox()
        Me.tbNamaFile = New System.Windows.Forms.TextBox()
        Me.lblPerhatian = New System.Windows.Forms.Label()
        Me.tbJenisDokumen = New System.Windows.Forms.TextBox()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.rtbKeterangan = New System.Windows.Forms.RichTextBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.lblNamaFile = New System.Windows.Forms.Label()
        Me.tbNoDokumen = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblKeterangan = New System.Windows.Forms.Label()
        Me.lblLokasiAsalFile = New System.Windows.Forms.Label()
        Me.lblDokumen = New System.Windows.Forms.Label()
        Me.lblGroupData = New System.Windows.Forms.Label()
        Me.tbLokasiAsalFile = New System.Windows.Forms.TextBox()
        Me.tbGroupData = New System.Windows.Forms.TextBox()
        Me.cbIsPublic = New System.Windows.Forms.CheckBox()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.lblKriteria = New System.Windows.Forms.Label()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.pnlPublik = New System.Windows.Forms.Panel()
        Me.gbDataEntry.SuspendLayout()
        Me.gbView.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPublik.SuspendLayout()
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
        Me.lblTitle.Text = "ATTACHMENT DOKUMEN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(696, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 15)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(388, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(616, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(358, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "*"
        '
        'btnPreview
        '
        Me.btnPreview.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.Location = New System.Drawing.Point(559, 69)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnPreview.TabIndex = 6
        Me.btnPreview.Text = "LIHAT"
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'tbLokasiTujuanFile
        '
        Me.tbLokasiTujuanFile.Location = New System.Drawing.Point(119, 94)
        Me.tbLokasiTujuanFile.Name = "tbLokasiTujuanFile"
        Me.tbLokasiTujuanFile.ReadOnly = True
        Me.tbLokasiTujuanFile.Size = New System.Drawing.Size(491, 23)
        Me.tbLokasiTujuanFile.TabIndex = 7
        '
        'lblLokasiTujuanFile
        '
        Me.lblLokasiTujuanFile.AutoSize = True
        Me.lblLokasiTujuanFile.Location = New System.Drawing.Point(7, 97)
        Me.lblLokasiTujuanFile.Name = "lblLokasiTujuanFile"
        Me.lblLokasiTujuanFile.Size = New System.Drawing.Size(106, 15)
        Me.lblLokasiTujuanFile.TabIndex = 88
        Me.lblLokasiTujuanFile.Text = "Lokasi Tujuan File :"
        '
        'tbExtensionFile
        '
        Me.tbExtensionFile.Location = New System.Drawing.Point(372, 118)
        Me.tbExtensionFile.Name = "tbExtensionFile"
        Me.tbExtensionFile.ReadOnly = True
        Me.tbExtensionFile.Size = New System.Drawing.Size(50, 23)
        Me.tbExtensionFile.TabIndex = 9
        Me.tbExtensionFile.Visible = False
        '
        'tbNamaFile
        '
        Me.tbNamaFile.Location = New System.Drawing.Point(119, 118)
        Me.tbNamaFile.Name = "tbNamaFile"
        Me.tbNamaFile.Size = New System.Drawing.Size(233, 23)
        Me.tbNamaFile.TabIndex = 8
        '
        'lblPerhatian
        '
        Me.lblPerhatian.AutoSize = True
        Me.lblPerhatian.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblPerhatian.ForeColor = System.Drawing.Color.Red
        Me.lblPerhatian.Location = New System.Drawing.Point(68, 4)
        Me.lblPerhatian.Name = "lblPerhatian"
        Me.lblPerhatian.Size = New System.Drawing.Size(515, 15)
        Me.lblPerhatian.TabIndex = 84
        Me.lblPerhatian.Text = "KALAU PUBLIK DICENTANG BERARTI ATTACHMENT DAPAT DILIHAT DARI FORM MANAPUN"
        Me.lblPerhatian.Visible = False
        '
        'tbJenisDokumen
        '
        Me.tbJenisDokumen.Location = New System.Drawing.Point(119, 22)
        Me.tbJenisDokumen.Name = "tbJenisDokumen"
        Me.tbJenisDokumen.ReadOnly = True
        Me.tbJenisDokumen.Size = New System.Drawing.Size(360, 23)
        Me.tbJenisDokumen.TabIndex = 1
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(588, 194)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 12
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'rtbKeterangan
        '
        Me.rtbKeterangan.Location = New System.Drawing.Point(119, 142)
        Me.rtbKeterangan.Name = "rtbKeterangan"
        Me.rtbKeterangan.Size = New System.Drawing.Size(589, 46)
        Me.rtbKeterangan.TabIndex = 10
        Me.rtbKeterangan.Text = ""
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(462, 194)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 11
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.Label5)
        Me.gbDataEntry.Controls.Add(Me.Label4)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.btnPreview)
        Me.gbDataEntry.Controls.Add(Me.tbLokasiTujuanFile)
        Me.gbDataEntry.Controls.Add(Me.lblLokasiTujuanFile)
        Me.gbDataEntry.Controls.Add(Me.tbExtensionFile)
        Me.gbDataEntry.Controls.Add(Me.tbNamaFile)
        Me.gbDataEntry.Controls.Add(Me.lblNamaFile)
        Me.gbDataEntry.Controls.Add(Me.tbNoDokumen)
        Me.gbDataEntry.Controls.Add(Me.tbJenisDokumen)
        Me.gbDataEntry.Controls.Add(Me.btnKeluar)
        Me.gbDataEntry.Controls.Add(Me.btnBrowse)
        Me.gbDataEntry.Controls.Add(Me.rtbKeterangan)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Controls.Add(Me.lblKeterangan)
        Me.gbDataEntry.Controls.Add(Me.lblLokasiAsalFile)
        Me.gbDataEntry.Controls.Add(Me.lblDokumen)
        Me.gbDataEntry.Controls.Add(Me.lblGroupData)
        Me.gbDataEntry.Controls.Add(Me.tbLokasiAsalFile)
        Me.gbDataEntry.Controls.Add(Me.tbGroupData)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(715, 255)
        Me.gbDataEntry.TabIndex = 89
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'lblNamaFile
        '
        Me.lblNamaFile.AutoSize = True
        Me.lblNamaFile.Location = New System.Drawing.Point(47, 121)
        Me.lblNamaFile.Name = "lblNamaFile"
        Me.lblNamaFile.Size = New System.Drawing.Size(66, 15)
        Me.lblNamaFile.TabIndex = 86
        Me.lblNamaFile.Text = "Nama File :"
        '
        'tbNoDokumen
        '
        Me.tbNoDokumen.Location = New System.Drawing.Point(485, 22)
        Me.tbNoDokumen.Name = "tbNoDokumen"
        Me.tbNoDokumen.ReadOnly = True
        Me.tbNoDokumen.Size = New System.Drawing.Size(205, 23)
        Me.tbNoDokumen.TabIndex = 2
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(529, 69)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 24)
        Me.btnBrowse.TabIndex = 5
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblKeterangan
        '
        Me.lblKeterangan.AutoSize = True
        Me.lblKeterangan.Location = New System.Drawing.Point(40, 145)
        Me.lblKeterangan.Name = "lblKeterangan"
        Me.lblKeterangan.Size = New System.Drawing.Size(73, 15)
        Me.lblKeterangan.TabIndex = 81
        Me.lblKeterangan.Text = "Keterangan :"
        '
        'lblLokasiAsalFile
        '
        Me.lblLokasiAsalFile.AutoSize = True
        Me.lblLokasiAsalFile.Location = New System.Drawing.Point(21, 73)
        Me.lblLokasiAsalFile.Name = "lblLokasiAsalFile"
        Me.lblLokasiAsalFile.Size = New System.Drawing.Size(92, 15)
        Me.lblLokasiAsalFile.TabIndex = 79
        Me.lblLokasiAsalFile.Text = "Lokasi Asal File :"
        '
        'lblDokumen
        '
        Me.lblDokumen.AutoSize = True
        Me.lblDokumen.Location = New System.Drawing.Point(48, 25)
        Me.lblDokumen.Name = "lblDokumen"
        Me.lblDokumen.Size = New System.Drawing.Size(65, 15)
        Me.lblDokumen.TabIndex = 48
        Me.lblDokumen.Text = "Dokumen :"
        '
        'lblGroupData
        '
        Me.lblGroupData.AutoSize = True
        Me.lblGroupData.Location = New System.Drawing.Point(40, 49)
        Me.lblGroupData.Name = "lblGroupData"
        Me.lblGroupData.Size = New System.Drawing.Size(73, 15)
        Me.lblGroupData.TabIndex = 65
        Me.lblGroupData.Text = "Group Data :"
        '
        'tbLokasiAsalFile
        '
        Me.tbLokasiAsalFile.Location = New System.Drawing.Point(119, 70)
        Me.tbLokasiAsalFile.Name = "tbLokasiAsalFile"
        Me.tbLokasiAsalFile.ReadOnly = True
        Me.tbLokasiAsalFile.Size = New System.Drawing.Size(410, 23)
        Me.tbLokasiAsalFile.TabIndex = 4
        '
        'tbGroupData
        '
        Me.tbGroupData.Location = New System.Drawing.Point(119, 46)
        Me.tbGroupData.Name = "tbGroupData"
        Me.tbGroupData.ReadOnly = True
        Me.tbGroupData.Size = New System.Drawing.Size(263, 23)
        Me.tbGroupData.TabIndex = 3
        '
        'cbIsPublic
        '
        Me.cbIsPublic.AutoSize = True
        Me.cbIsPublic.Location = New System.Drawing.Point(3, 3)
        Me.cbIsPublic.Name = "cbIsPublic"
        Me.cbIsPublic.Size = New System.Drawing.Size(59, 19)
        Me.cbIsPublic.TabIndex = 66
        Me.cbIsPublic.Text = "Publik"
        Me.cbIsPublic.UseVisualStyleBackColor = True
        Me.cbIsPublic.Visible = False
        '
        'ofd1
        '
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(872, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 91
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(733, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 90
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.lblKriteria)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 289)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(960, 367)
        Me.gbView.TabIndex = 88
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
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
        Me.pnlNavigasi.Location = New System.Drawing.Point(7, 330)
        Me.pnlNavigasi.Name = "pnlNavigasi"
        Me.pnlNavigasi.Size = New System.Drawing.Size(415, 30)
        Me.pnlNavigasi.TabIndex = 7
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
        'btnFFForward
        '
        Me.btnFFForward.Location = New System.Drawing.Point(250, 4)
        Me.btnFFForward.Name = "btnFFForward"
        Me.btnFFForward.Size = New System.Drawing.Size(31, 23)
        Me.btnFFForward.TabIndex = 168
        Me.btnFFForward.Text = ">>"
        Me.btnFFForward.UseVisualStyleBackColor = True
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
        'tbRecordPage
        '
        Me.tbRecordPage.Location = New System.Drawing.Point(137, 4)
        Me.tbRecordPage.Name = "tbRecordPage"
        Me.tbRecordPage.Size = New System.Drawing.Size(70, 23)
        Me.tbRecordPage.TabIndex = 166
        Me.tbRecordPage.Text = "1"
        Me.tbRecordPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(535, 9)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 14
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(190, 26)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(339, 23)
        Me.tbCari.TabIndex = 13
        '
        'lblKriteria
        '
        Me.lblKriteria.AutoSize = True
        Me.lblKriteria.Location = New System.Drawing.Point(7, 29)
        Me.lblKriteria.Name = "lblKriteria"
        Me.lblKriteria.Size = New System.Drawing.Size(50, 15)
        Me.lblKriteria.TabIndex = 2
        Me.lblKriteria.Text = "Kriteria :"
        '
        'cboKriteria
        '
        Me.cboKriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKriteria.FormattingEnabled = True
        Me.cboKriteria.Location = New System.Drawing.Point(63, 26)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(121, 23)
        Me.cboKriteria.TabIndex = 6
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Location = New System.Drawing.Point(6, 69)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.RowTemplate.Height = 25
        Me.dgvView.Size = New System.Drawing.Size(948, 255)
        Me.dgvView.TabIndex = 0
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(733, 50)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 87
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'pnlPublik
        '
        Me.pnlPublik.Controls.Add(Me.cbIsPublic)
        Me.pnlPublik.Controls.Add(Me.lblPerhatian)
        Me.pnlPublik.Location = New System.Drawing.Point(733, 259)
        Me.pnlPublik.Name = "pnlPublik"
        Me.pnlPublik.Size = New System.Drawing.Size(99, 24)
        Me.pnlPublik.TabIndex = 93
        Me.pnlPublik.Visible = False
        '
        'FormAttachmentDokumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.pnlPublik)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAttachmentDokumen"
        Me.Text = "FORM ATTACHMENT DOKUMEN"
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPublik.ResumeLayout(False)
        Me.pnlPublik.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPreview As Button
    Friend WithEvents tbLokasiTujuanFile As TextBox
    Friend WithEvents lblLokasiTujuanFile As Label
    Friend WithEvents tbExtensionFile As TextBox
    Friend WithEvents tbNamaFile As TextBox
    Friend WithEvents lblPerhatian As Label
    Friend WithEvents tbJenisDokumen As TextBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents rtbKeterangan As RichTextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents lblNamaFile As Label
    Friend WithEvents tbNoDokumen As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents lblKeterangan As Label
    Friend WithEvents lblLokasiAsalFile As Label
    Friend WithEvents lblDokumen As Label
    Friend WithEvents lblGroupData As Label
    Friend WithEvents tbLokasiAsalFile As TextBox
    Friend WithEvents tbGroupData As TextBox
    Friend WithEvents cbIsPublic As CheckBox
    Friend WithEvents ofd1 As OpenFileDialog
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents lblEntryType As Label
    Friend WithEvents gbView As GroupBox
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents lblOfPages As Label
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnFFForward As Button
    Friend WithEvents btnForward As Button
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnBack As Button
    Friend WithEvents btnFFBack As Button
    Friend WithEvents lblRecord As Label
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents tbCari As TextBox
    Friend WithEvents lblKriteria As Label
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents pnlPublik As Panel
End Class
