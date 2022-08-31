<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAttachmentKaryawan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAttachmentKaryawan))
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.lblCari = New System.Windows.Forms.Label()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.lblKeterangan = New System.Windows.Forms.Label()
        Me.rtbKeterangan = New System.Windows.Forms.RichTextBox()
        Me.tbExtensionFile = New System.Windows.Forms.TextBox()
        Me.lblNamaFile = New System.Windows.Forms.Label()
        Me.tbNamaFile = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblLokasiTujuanFile = New System.Windows.Forms.Label()
        Me.tbLokasiTujuanFile = New System.Windows.Forms.TextBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.lblLokasiAsalFile = New System.Windows.Forms.Label()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.tbLokasiAsalFile = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblGroupData = New System.Windows.Forms.Label()
        Me.tbGroupData = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.tbNama = New System.Windows.Forms.TextBox()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.tbIDK = New System.Windows.Forms.TextBox()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.lblPerhatian = New System.Windows.Forms.Label()
        Me.cbIsPublic = New System.Windows.Forms.CheckBox()
        Me.pnlPublik = New System.Windows.Forms.Panel()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlNavigasi.SuspendLayout()
        Me.gbView.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPublik.SuspendLayout()
        Me.gbDataEntry.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(184, 29)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(380, 23)
        Me.tbCari.TabIndex = 15
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Location = New System.Drawing.Point(11, 32)
        Me.lblCari.Name = "lblCari"
        Me.lblCari.Size = New System.Drawing.Size(50, 15)
        Me.lblCari.TabIndex = 132
        Me.lblCari.Text = "Kriteria :"
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(852, 253)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 13
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(589, 219)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 12
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'lblKeterangan
        '
        Me.lblKeterangan.AutoSize = True
        Me.lblKeterangan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKeterangan.Location = New System.Drawing.Point(41, 168)
        Me.lblKeterangan.Name = "lblKeterangan"
        Me.lblKeterangan.Size = New System.Drawing.Size(73, 15)
        Me.lblKeterangan.TabIndex = 18
        Me.lblKeterangan.Text = "Keterangan :"
        '
        'rtbKeterangan
        '
        Me.rtbKeterangan.Location = New System.Drawing.Point(120, 165)
        Me.rtbKeterangan.Name = "rtbKeterangan"
        Me.rtbKeterangan.Size = New System.Drawing.Size(589, 51)
        Me.rtbKeterangan.TabIndex = 11
        Me.rtbKeterangan.Text = ""
        '
        'tbExtensionFile
        '
        Me.tbExtensionFile.Location = New System.Drawing.Point(339, 141)
        Me.tbExtensionFile.Name = "tbExtensionFile"
        Me.tbExtensionFile.ReadOnly = True
        Me.tbExtensionFile.Size = New System.Drawing.Size(50, 23)
        Me.tbExtensionFile.TabIndex = 10
        Me.tbExtensionFile.Visible = False
        '
        'lblNamaFile
        '
        Me.lblNamaFile.AutoSize = True
        Me.lblNamaFile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNamaFile.Location = New System.Drawing.Point(48, 144)
        Me.lblNamaFile.Name = "lblNamaFile"
        Me.lblNamaFile.Size = New System.Drawing.Size(66, 15)
        Me.lblNamaFile.TabIndex = 15
        Me.lblNamaFile.Text = "Nama File :"
        '
        'tbNamaFile
        '
        Me.tbNamaFile.Location = New System.Drawing.Point(120, 141)
        Me.tbNamaFile.Name = "tbNamaFile"
        Me.tbNamaFile.Size = New System.Drawing.Size(195, 23)
        Me.tbNamaFile.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(321, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "*"
        '
        'lblOfPages
        '
        Me.lblOfPages.AutoSize = True
        Me.lblOfPages.Location = New System.Drawing.Point(317, 8)
        Me.lblOfPages.Name = "lblOfPages"
        Me.lblOfPages.Size = New System.Drawing.Size(69, 15)
        Me.lblOfPages.TabIndex = 170
        Me.lblOfPages.Text = "Of : x Pages"
        '
        'tbRecordPage
        '
        Me.tbRecordPage.Location = New System.Drawing.Point(130, 5)
        Me.tbRecordPage.Name = "tbRecordPage"
        Me.tbRecordPage.Size = New System.Drawing.Size(70, 23)
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
        'lblLokasiTujuanFile
        '
        Me.lblLokasiTujuanFile.AutoSize = True
        Me.lblLokasiTujuanFile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLokasiTujuanFile.Location = New System.Drawing.Point(8, 120)
        Me.lblLokasiTujuanFile.Name = "lblLokasiTujuanFile"
        Me.lblLokasiTujuanFile.Size = New System.Drawing.Size(106, 15)
        Me.lblLokasiTujuanFile.TabIndex = 12
        Me.lblLokasiTujuanFile.Text = "Lokasi Tujuan File :"
        '
        'tbLokasiTujuanFile
        '
        Me.tbLokasiTujuanFile.Location = New System.Drawing.Point(120, 117)
        Me.tbLokasiTujuanFile.Name = "tbLokasiTujuanFile"
        Me.tbLokasiTujuanFile.ReadOnly = True
        Me.tbLokasiTujuanFile.Size = New System.Drawing.Size(484, 23)
        Me.tbLokasiTujuanFile.TabIndex = 8
        '
        'btnPreview
        '
        Me.btnPreview.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.Location = New System.Drawing.Point(547, 93)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnPreview.TabIndex = 7
        Me.btnPreview.Text = "LIHAT"
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(517, 93)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 24)
        Me.btnBrowse.TabIndex = 6
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(570, 12)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 16
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
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
        'lblLokasiAsalFile
        '
        Me.lblLokasiAsalFile.AutoSize = True
        Me.lblLokasiAsalFile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLokasiAsalFile.Location = New System.Drawing.Point(22, 96)
        Me.lblLokasiAsalFile.Name = "lblLokasiAsalFile"
        Me.lblLokasiAsalFile.Size = New System.Drawing.Size(92, 15)
        Me.lblLokasiAsalFile.TabIndex = 8
        Me.lblLokasiAsalFile.Text = "Lokasi Asal File :"
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
        'tbLokasiAsalFile
        '
        Me.tbLokasiAsalFile.Location = New System.Drawing.Point(120, 93)
        Me.tbLokasiAsalFile.Name = "tbLokasiAsalFile"
        Me.tbLokasiAsalFile.ReadOnly = True
        Me.tbLokasiAsalFile.Size = New System.Drawing.Size(396, 23)
        Me.tbLokasiAsalFile.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(370, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "*"
        '
        'lblGroupData
        '
        Me.lblGroupData.AutoSize = True
        Me.lblGroupData.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblGroupData.Location = New System.Drawing.Point(41, 44)
        Me.lblGroupData.Name = "lblGroupData"
        Me.lblGroupData.Size = New System.Drawing.Size(73, 15)
        Me.lblGroupData.TabIndex = 5
        Me.lblGroupData.Text = "Group Data :"
        '
        'tbGroupData
        '
        Me.tbGroupData.Location = New System.Drawing.Point(120, 41)
        Me.tbGroupData.Name = "tbGroupData"
        Me.tbGroupData.ReadOnly = True
        Me.tbGroupData.Size = New System.Drawing.Size(244, 23)
        Me.tbGroupData.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(678, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "*"
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKaryawan.Location = New System.Drawing.Point(49, 20)
        Me.lblKaryawan.Name = "lblKaryawan"
        Me.lblKaryawan.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawan.TabIndex = 2
        Me.lblKaryawan.Text = "Karyawan :"
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.Location = New System.Drawing.Point(2, 8)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(39, 15)
        Me.lblRecord.TabIndex = 163
        Me.lblRecord.Text = "Page :"
        '
        'cboKriteria
        '
        Me.cboKriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKriteria.FormattingEnabled = True
        Me.cboKriteria.Location = New System.Drawing.Point(62, 29)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(116, 23)
        Me.cboKriteria.TabIndex = 11
        '
        'tbNama
        '
        Me.tbNama.Location = New System.Drawing.Point(276, 17)
        Me.tbNama.Name = "tbNama"
        Me.tbNama.ReadOnly = True
        Me.tbNama.Size = New System.Drawing.Size(396, 23)
        Me.tbNama.TabIndex = 2
        '
        'ofd1
        '
        '
        'tbIDK
        '
        Me.tbIDK.Location = New System.Drawing.Point(120, 17)
        Me.tbIDK.Name = "tbIDK"
        Me.tbIDK.ReadOnly = True
        Me.tbIDK.Size = New System.Drawing.Size(150, 23)
        Me.tbIDK.TabIndex = 1
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
        Me.pnlNavigasi.Location = New System.Drawing.Point(6, 332)
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
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(14, 313)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(958, 366)
        Me.gbView.TabIndex = 180
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
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
        Me.dgvView.Size = New System.Drawing.Size(946, 263)
        Me.dgvView.TabIndex = 130
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(735, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 179
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(463, 219)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 14
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'lblPerhatian
        '
        Me.lblPerhatian.AutoSize = True
        Me.lblPerhatian.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerhatian.ForeColor = System.Drawing.Color.Red
        Me.lblPerhatian.Location = New System.Drawing.Point(68, 3)
        Me.lblPerhatian.Name = "lblPerhatian"
        Me.lblPerhatian.Size = New System.Drawing.Size(515, 15)
        Me.lblPerhatian.TabIndex = 1
        Me.lblPerhatian.Text = "KALAU PUBLIK DICENTANG BERARTI ATTACHMENT DAPAT DILIHAT DARI FORM MANAPUN"
        '
        'cbIsPublic
        '
        Me.cbIsPublic.AutoSize = True
        Me.cbIsPublic.Location = New System.Drawing.Point(3, 3)
        Me.cbIsPublic.Name = "cbIsPublic"
        Me.cbIsPublic.Size = New System.Drawing.Size(59, 19)
        Me.cbIsPublic.TabIndex = 4
        Me.cbIsPublic.Text = "Publik"
        Me.cbIsPublic.UseVisualStyleBackColor = True
        '
        'pnlPublik
        '
        Me.pnlPublik.Controls.Add(Me.lblPerhatian)
        Me.pnlPublik.Controls.Add(Me.cbIsPublic)
        Me.pnlPublik.Location = New System.Drawing.Point(120, 65)
        Me.pnlPublik.Name = "pnlPublik"
        Me.pnlPublik.Size = New System.Drawing.Size(589, 24)
        Me.pnlPublik.TabIndex = 177
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(872, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 176
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Controls.Add(Me.lblKeterangan)
        Me.gbDataEntry.Controls.Add(Me.pnlPublik)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.rtbKeterangan)
        Me.gbDataEntry.Controls.Add(Me.tbExtensionFile)
        Me.gbDataEntry.Controls.Add(Me.lblNamaFile)
        Me.gbDataEntry.Controls.Add(Me.tbNamaFile)
        Me.gbDataEntry.Controls.Add(Me.Label4)
        Me.gbDataEntry.Controls.Add(Me.lblLokasiTujuanFile)
        Me.gbDataEntry.Controls.Add(Me.tbLokasiTujuanFile)
        Me.gbDataEntry.Controls.Add(Me.btnPreview)
        Me.gbDataEntry.Controls.Add(Me.btnBrowse)
        Me.gbDataEntry.Controls.Add(Me.lblLokasiAsalFile)
        Me.gbDataEntry.Controls.Add(Me.tbLokasiAsalFile)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.lblGroupData)
        Me.gbDataEntry.Controls.Add(Me.tbGroupData)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.lblKaryawan)
        Me.gbDataEntry.Controls.Add(Me.tbNama)
        Me.gbDataEntry.Controls.Add(Me.tbIDK)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(14, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(715, 279)
        Me.gbDataEntry.TabIndex = 175
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
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
        Me.lblTitle.TabIndex = 174
        Me.lblTitle.Text = "ATTACHMENT KARYAWAN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormAttachmentKaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 686)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAttachmentKaryawan"
        Me.Text = "FORM ATTACHMENT KARYAWAN"
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPublik.ResumeLayout(False)
        Me.pnlPublik.PerformLayout()
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbCari As TextBox
    Friend WithEvents lblCari As Label
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents lblKeterangan As Label
    Friend WithEvents rtbKeterangan As RichTextBox
    Friend WithEvents tbExtensionFile As TextBox
    Friend WithEvents lblNamaFile As Label
    Friend WithEvents tbNamaFile As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblOfPages As Label
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnFFForward As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents lblLokasiTujuanFile As Label
    Friend WithEvents tbLokasiTujuanFile As TextBox
    Friend WithEvents btnPreview As Button
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents btnForward As Button
    Friend WithEvents lblLokasiAsalFile As Label
    Friend WithEvents btnFFBack As Button
    Friend WithEvents tbLokasiAsalFile As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblGroupData As Label
    Friend WithEvents tbGroupData As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents lblRecord As Label
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents tbNama As TextBox
    Friend WithEvents ofd1 As OpenFileDialog
    Friend WithEvents tbIDK As TextBox
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents btnAddNew As Button
    Friend WithEvents gbView As GroupBox
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents lblPerhatian As Label
    Friend WithEvents cbIsPublic As CheckBox
    Friend WithEvents pnlPublik As Panel
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents lblTitle As Label
End Class
