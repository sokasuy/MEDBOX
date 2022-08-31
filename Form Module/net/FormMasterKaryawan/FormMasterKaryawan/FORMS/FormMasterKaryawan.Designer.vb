<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMasterKaryawan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterKaryawan))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
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
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpBerhentiKerja = New System.Windows.Forms.DateTimePicker()
        Me.lblTanggalBerhentiKerja = New System.Windows.Forms.Label()
        Me.pnlStatusBekerja = New System.Windows.Forms.Panel()
        Me.rbPensiun = New System.Windows.Forms.RadioButton()
        Me.rbResign = New System.Windows.Forms.RadioButton()
        Me.rbAktif = New System.Windows.Forms.RadioButton()
        Me.lblStatusBekerja = New System.Windows.Forms.Label()
        Me.tbJaminan = New System.Windows.Forms.TextBox()
        Me.lblJaminan = New System.Windows.Forms.Label()
        Me.tbBPJSKesehatan = New System.Windows.Forms.TextBox()
        Me.lblBPJSKesehatan = New System.Windows.Forms.Label()
        Me.clbBPJSTK = New System.Windows.Forms.CheckedListBox()
        Me.lblBPJSTK = New System.Windows.Forms.Label()
        Me.tbTahunLulus = New System.Windows.Forms.TextBox()
        Me.lblTahunKelulusan = New System.Windows.Forms.Label()
        Me.tbLulusanDari = New System.Windows.Forms.TextBox()
        Me.lblLulusanDari = New System.Windows.Forms.Label()
        Me.cboPendidikan = New System.Windows.Forms.ComboBox()
        Me.lblPendidikanAkhir = New System.Windows.Forms.Label()
        Me.cboGolDarah = New System.Windows.Forms.ComboBox()
        Me.lblGolDarah = New System.Windows.Forms.Label()
        Me.cboAgama = New System.Windows.Forms.ComboBox()
        Me.lblAgama = New System.Windows.Forms.Label()
        Me.tbEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.tbNoHP = New System.Windows.Forms.TextBox()
        Me.lblNoHP = New System.Windows.Forms.Label()
        Me.pnlStatus = New System.Windows.Forms.Panel()
        Me.rbMenikah = New System.Windows.Forms.RadioButton()
        Me.rbSingle = New System.Windows.Forms.RadioButton()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.tbNoKK = New System.Windows.Forms.TextBox()
        Me.lblNoKK = New System.Windows.Forms.Label()
        Me.gbNPWP = New System.Windows.Forms.GroupBox()
        Me.tbAlamatBerdasarNPWP = New System.Windows.Forms.TextBox()
        Me.lblAlamatBerdasarNPWP = New System.Windows.Forms.Label()
        Me.tbNPWP = New System.Windows.Forms.TextBox()
        Me.lblNPWP = New System.Windows.Forms.Label()
        Me.tbNamaBerdasarNPWP = New System.Windows.Forms.TextBox()
        Me.lblNamaBerdasarNPWP = New System.Windows.Forms.Label()
        Me.gbIdentitas = New System.Windows.Forms.GroupBox()
        Me.pnlJenisKelamin = New System.Windows.Forms.Panel()
        Me.rbWanita = New System.Windows.Forms.RadioButton()
        Me.rbPria = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbNIK = New System.Windows.Forms.TextBox()
        Me.lblNIK = New System.Windows.Forms.Label()
        Me.lblNama = New System.Windows.Forms.Label()
        Me.tbNama = New System.Windows.Forms.TextBox()
        Me.lblAlamat = New System.Windows.Forms.Label()
        Me.tbAlamat = New System.Windows.Forms.TextBox()
        Me.tbTempatLahir = New System.Windows.Forms.TextBox()
        Me.dtpTanggalLahir = New System.Windows.Forms.DateTimePicker()
        Me.lblTempatLahir = New System.Windows.Forms.Label()
        Me.lblTanggalLahir = New System.Windows.Forms.Label()
        Me.dtpTanggalMasuk = New System.Windows.Forms.DateTimePicker()
        Me.lblTanggalMasuk = New System.Windows.Forms.Label()
        Me.tbIDK = New System.Windows.Forms.TextBox()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.lblIDK = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbView.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDataEntry.SuspendLayout()
        Me.pnlStatusBekerja.SuspendLayout()
        Me.pnlStatus.SuspendLayout()
        Me.gbNPWP.SuspendLayout()
        Me.gbIdentitas.SuspendLayout()
        Me.pnlJenisKelamin.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(1284, 25)
        Me.lblTitle.TabIndex = 12
        Me.lblTitle.Text = "MASTER KARYAWAN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(1030, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 21
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(1030, 50)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 26
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
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
        Me.gbView.Location = New System.Drawing.Point(12, 338)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(1260, 360)
        Me.gbView.TabIndex = 20
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
        Me.pnlNavigasi.Location = New System.Drawing.Point(5, 328)
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
        Me.btnTampilkan.Location = New System.Drawing.Point(535, 11)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 25
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(190, 28)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(339, 23)
        Me.tbCari.TabIndex = 24
        '
        'lblKriteria
        '
        Me.lblKriteria.AutoSize = True
        Me.lblKriteria.Location = New System.Drawing.Point(7, 31)
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
        Me.cboKriteria.Location = New System.Drawing.Point(63, 28)
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
        Me.dgvView.Location = New System.Drawing.Point(5, 71)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.RowTemplate.Height = 25
        Me.dgvView.Size = New System.Drawing.Size(1249, 255)
        Me.dgvView.TabIndex = 0
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.Label4)
        Me.gbDataEntry.Controls.Add(Me.dtpBerhentiKerja)
        Me.gbDataEntry.Controls.Add(Me.lblTanggalBerhentiKerja)
        Me.gbDataEntry.Controls.Add(Me.pnlStatusBekerja)
        Me.gbDataEntry.Controls.Add(Me.lblStatusBekerja)
        Me.gbDataEntry.Controls.Add(Me.tbJaminan)
        Me.gbDataEntry.Controls.Add(Me.lblJaminan)
        Me.gbDataEntry.Controls.Add(Me.tbBPJSKesehatan)
        Me.gbDataEntry.Controls.Add(Me.lblBPJSKesehatan)
        Me.gbDataEntry.Controls.Add(Me.clbBPJSTK)
        Me.gbDataEntry.Controls.Add(Me.lblBPJSTK)
        Me.gbDataEntry.Controls.Add(Me.tbTahunLulus)
        Me.gbDataEntry.Controls.Add(Me.lblTahunKelulusan)
        Me.gbDataEntry.Controls.Add(Me.tbLulusanDari)
        Me.gbDataEntry.Controls.Add(Me.lblLulusanDari)
        Me.gbDataEntry.Controls.Add(Me.cboPendidikan)
        Me.gbDataEntry.Controls.Add(Me.lblPendidikanAkhir)
        Me.gbDataEntry.Controls.Add(Me.cboGolDarah)
        Me.gbDataEntry.Controls.Add(Me.lblGolDarah)
        Me.gbDataEntry.Controls.Add(Me.cboAgama)
        Me.gbDataEntry.Controls.Add(Me.lblAgama)
        Me.gbDataEntry.Controls.Add(Me.tbEmail)
        Me.gbDataEntry.Controls.Add(Me.lblEmail)
        Me.gbDataEntry.Controls.Add(Me.tbNoHP)
        Me.gbDataEntry.Controls.Add(Me.lblNoHP)
        Me.gbDataEntry.Controls.Add(Me.pnlStatus)
        Me.gbDataEntry.Controls.Add(Me.lblStatus)
        Me.gbDataEntry.Controls.Add(Me.tbNoKK)
        Me.gbDataEntry.Controls.Add(Me.lblNoKK)
        Me.gbDataEntry.Controls.Add(Me.gbNPWP)
        Me.gbDataEntry.Controls.Add(Me.gbIdentitas)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggalMasuk)
        Me.gbDataEntry.Controls.Add(Me.lblTanggalMasuk)
        Me.gbDataEntry.Controls.Add(Me.tbIDK)
        Me.gbDataEntry.Controls.Add(Me.btnKeluar)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Controls.Add(Me.lblIDK)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(1012, 309)
        Me.gbDataEntry.TabIndex = 19
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(236, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "*"
        '
        'dtpBerhentiKerja
        '
        Me.dtpBerhentiKerja.CustomFormat = "dd-MMM-yyyy"
        Me.dtpBerhentiKerja.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBerhentiKerja.Location = New System.Drawing.Point(888, 13)
        Me.dtpBerhentiKerja.Name = "dtpBerhentiKerja"
        Me.dtpBerhentiKerja.Size = New System.Drawing.Size(119, 23)
        Me.dtpBerhentiKerja.TabIndex = 3
        '
        'lblTanggalBerhentiKerja
        '
        Me.lblTanggalBerhentiKerja.AutoSize = True
        Me.lblTanggalBerhentiKerja.Location = New System.Drawing.Point(796, 17)
        Me.lblTanggalBerhentiKerja.Name = "lblTanggalBerhentiKerja"
        Me.lblTanggalBerhentiKerja.Size = New System.Drawing.Size(86, 15)
        Me.lblTanggalBerhentiKerja.TabIndex = 49
        Me.lblTanggalBerhentiKerja.Text = "Berhenti Kerja :"
        '
        'pnlStatusBekerja
        '
        Me.pnlStatusBekerja.Controls.Add(Me.rbPensiun)
        Me.pnlStatusBekerja.Controls.Add(Me.rbResign)
        Me.pnlStatusBekerja.Controls.Add(Me.rbAktif)
        Me.pnlStatusBekerja.Location = New System.Drawing.Point(588, 11)
        Me.pnlStatusBekerja.Name = "pnlStatusBekerja"
        Me.pnlStatusBekerja.Size = New System.Drawing.Size(202, 25)
        Me.pnlStatusBekerja.TabIndex = 27
        '
        'rbPensiun
        '
        Me.rbPensiun.AutoSize = True
        Me.rbPensiun.Location = New System.Drawing.Point(125, 4)
        Me.rbPensiun.Name = "rbPensiun"
        Me.rbPensiun.Size = New System.Drawing.Size(67, 19)
        Me.rbPensiun.TabIndex = 2
        Me.rbPensiun.Text = "Pensiun"
        Me.rbPensiun.UseVisualStyleBackColor = True
        '
        'rbResign
        '
        Me.rbResign.AutoSize = True
        Me.rbResign.Location = New System.Drawing.Point(59, 4)
        Me.rbResign.Name = "rbResign"
        Me.rbResign.Size = New System.Drawing.Size(60, 19)
        Me.rbResign.TabIndex = 1
        Me.rbResign.Text = "Resign"
        Me.rbResign.UseVisualStyleBackColor = True
        '
        'rbAktif
        '
        Me.rbAktif.AutoSize = True
        Me.rbAktif.Checked = True
        Me.rbAktif.Location = New System.Drawing.Point(3, 4)
        Me.rbAktif.Name = "rbAktif"
        Me.rbAktif.Size = New System.Drawing.Size(50, 19)
        Me.rbAktif.TabIndex = 0
        Me.rbAktif.TabStop = True
        Me.rbAktif.Text = "Aktif"
        Me.rbAktif.UseVisualStyleBackColor = True
        '
        'lblStatusBekerja
        '
        Me.lblStatusBekerja.AutoSize = True
        Me.lblStatusBekerja.Location = New System.Drawing.Point(496, 16)
        Me.lblStatusBekerja.Name = "lblStatusBekerja"
        Me.lblStatusBekerja.Size = New System.Drawing.Size(86, 15)
        Me.lblStatusBekerja.TabIndex = 48
        Me.lblStatusBekerja.Text = "Status Bekerja :"
        '
        'tbJaminan
        '
        Me.tbJaminan.Location = New System.Drawing.Point(451, 271)
        Me.tbJaminan.Name = "tbJaminan"
        Me.tbJaminan.Size = New System.Drawing.Size(246, 23)
        Me.tbJaminan.TabIndex = 21
        '
        'lblJaminan
        '
        Me.lblJaminan.AutoSize = True
        Me.lblJaminan.Location = New System.Drawing.Point(388, 274)
        Me.lblJaminan.Name = "lblJaminan"
        Me.lblJaminan.Size = New System.Drawing.Size(57, 15)
        Me.lblJaminan.TabIndex = 46
        Me.lblJaminan.Text = "Jaminan :"
        '
        'tbBPJSKesehatan
        '
        Me.tbBPJSKesehatan.Location = New System.Drawing.Point(451, 247)
        Me.tbBPJSKesehatan.Name = "tbBPJSKesehatan"
        Me.tbBPJSKesehatan.Size = New System.Drawing.Size(246, 23)
        Me.tbBPJSKesehatan.TabIndex = 20
        '
        'lblBPJSKesehatan
        '
        Me.lblBPJSKesehatan.AutoSize = True
        Me.lblBPJSKesehatan.Location = New System.Drawing.Point(352, 250)
        Me.lblBPJSKesehatan.Name = "lblBPJSKesehatan"
        Me.lblBPJSKesehatan.Size = New System.Drawing.Size(93, 15)
        Me.lblBPJSKesehatan.TabIndex = 44
        Me.lblBPJSKesehatan.Text = "BPJS Kesehatan :"
        '
        'clbBPJSTK
        '
        Me.clbBPJSTK.FormattingEnabled = True
        Me.clbBPJSTK.Items.AddRange(New Object() {"JKK", "JKM", "JHT", "JP"})
        Me.clbBPJSTK.Location = New System.Drawing.Point(66, 247)
        Me.clbBPJSTK.MultiColumn = True
        Me.clbBPJSTK.Name = "clbBPJSTK"
        Me.clbBPJSTK.Size = New System.Drawing.Size(268, 40)
        Me.clbBPJSTK.TabIndex = 43
        '
        'lblBPJSTK
        '
        Me.lblBPJSTK.AutoSize = True
        Me.lblBPJSTK.Location = New System.Drawing.Point(8, 256)
        Me.lblBPJSTK.Name = "lblBPJSTK"
        Me.lblBPJSTK.Size = New System.Drawing.Size(52, 15)
        Me.lblBPJSTK.TabIndex = 41
        Me.lblBPJSTK.Text = "BPJS TK :"
        '
        'tbTahunLulus
        '
        Me.tbTahunLulus.Location = New System.Drawing.Point(840, 223)
        Me.tbTahunLulus.Name = "tbTahunLulus"
        Me.tbTahunLulus.Size = New System.Drawing.Size(86, 23)
        Me.tbTahunLulus.TabIndex = 19
        '
        'lblTahunKelulusan
        '
        Me.lblTahunKelulusan.AutoSize = True
        Me.lblTahunKelulusan.Location = New System.Drawing.Point(758, 226)
        Me.lblTahunKelulusan.Name = "lblTahunKelulusan"
        Me.lblTahunKelulusan.Size = New System.Drawing.Size(76, 15)
        Me.lblTahunKelulusan.TabIndex = 39
        Me.lblTahunKelulusan.Text = "Tahun Lulus :"
        '
        'tbLulusanDari
        '
        Me.tbLulusanDari.Location = New System.Drawing.Point(410, 223)
        Me.tbLulusanDari.Name = "tbLulusanDari"
        Me.tbLulusanDari.Size = New System.Drawing.Size(342, 23)
        Me.tbLulusanDari.TabIndex = 18
        '
        'lblLulusanDari
        '
        Me.lblLulusanDari.AutoSize = True
        Me.lblLulusanDari.Location = New System.Drawing.Point(326, 226)
        Me.lblLulusanDari.Name = "lblLulusanDari"
        Me.lblLulusanDari.Size = New System.Drawing.Size(78, 15)
        Me.lblLulusanDari.TabIndex = 37
        Me.lblLulusanDari.Text = "Lulusan Dari :"
        '
        'cboPendidikan
        '
        Me.cboPendidikan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPendidikan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPendidikan.FormattingEnabled = True
        Me.cboPendidikan.IntegralHeight = False
        Me.cboPendidikan.Location = New System.Drawing.Point(87, 223)
        Me.cboPendidikan.Name = "cboPendidikan"
        Me.cboPendidikan.Size = New System.Drawing.Size(189, 23)
        Me.cboPendidikan.TabIndex = 17
        '
        'lblPendidikanAkhir
        '
        Me.lblPendidikanAkhir.AutoSize = True
        Me.lblPendidikanAkhir.Location = New System.Drawing.Point(9, 226)
        Me.lblPendidikanAkhir.Name = "lblPendidikanAkhir"
        Me.lblPendidikanAkhir.Size = New System.Drawing.Size(72, 15)
        Me.lblPendidikanAkhir.TabIndex = 35
        Me.lblPendidikanAkhir.Text = "Pendidikan :"
        '
        'cboGolDarah
        '
        Me.cboGolDarah.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGolDarah.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGolDarah.FormattingEnabled = True
        Me.cboGolDarah.IntegralHeight = False
        Me.cboGolDarah.Location = New System.Drawing.Point(904, 173)
        Me.cboGolDarah.Name = "cboGolDarah"
        Me.cboGolDarah.Size = New System.Drawing.Size(70, 23)
        Me.cboGolDarah.TabIndex = 14
        '
        'lblGolDarah
        '
        Me.lblGolDarah.AutoSize = True
        Me.lblGolDarah.Location = New System.Drawing.Point(833, 176)
        Me.lblGolDarah.Name = "lblGolDarah"
        Me.lblGolDarah.Size = New System.Drawing.Size(65, 15)
        Me.lblGolDarah.TabIndex = 33
        Me.lblGolDarah.Text = "Gol Darah :"
        '
        'cboAgama
        '
        Me.cboAgama.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAgama.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAgama.FormattingEnabled = True
        Me.cboAgama.IntegralHeight = False
        Me.cboAgama.Location = New System.Drawing.Point(714, 173)
        Me.cboAgama.Name = "cboAgama"
        Me.cboAgama.Size = New System.Drawing.Size(113, 23)
        Me.cboAgama.TabIndex = 13
        '
        'lblAgama
        '
        Me.lblAgama.AutoSize = True
        Me.lblAgama.Location = New System.Drawing.Point(657, 176)
        Me.lblAgama.Name = "lblAgama"
        Me.lblAgama.Size = New System.Drawing.Size(51, 15)
        Me.lblAgama.TabIndex = 31
        Me.lblAgama.Text = "Agama :"
        '
        'tbEmail
        '
        Me.tbEmail.Location = New System.Drawing.Point(410, 199)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(208, 23)
        Me.tbEmail.TabIndex = 16
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(362, 202)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(42, 15)
        Me.lblEmail.TabIndex = 29
        Me.lblEmail.Text = "Email :"
        '
        'tbNoHP
        '
        Me.tbNoHP.Location = New System.Drawing.Point(63, 199)
        Me.tbNoHP.Name = "tbNoHP"
        Me.tbNoHP.Size = New System.Drawing.Size(271, 23)
        Me.tbNoHP.TabIndex = 15
        '
        'lblNoHP
        '
        Me.lblNoHP.AutoSize = True
        Me.lblNoHP.Location = New System.Drawing.Point(9, 202)
        Me.lblNoHP.Name = "lblNoHP"
        Me.lblNoHP.Size = New System.Drawing.Size(48, 15)
        Me.lblNoHP.TabIndex = 27
        Me.lblNoHP.Text = "No HP :"
        '
        'pnlStatus
        '
        Me.pnlStatus.Controls.Add(Me.rbMenikah)
        Me.pnlStatus.Controls.Add(Me.rbSingle)
        Me.pnlStatus.Location = New System.Drawing.Point(410, 173)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(177, 25)
        Me.pnlStatus.TabIndex = 26
        '
        'rbMenikah
        '
        Me.rbMenikah.AutoSize = True
        Me.rbMenikah.Location = New System.Drawing.Point(66, 4)
        Me.rbMenikah.Name = "rbMenikah"
        Me.rbMenikah.Size = New System.Drawing.Size(71, 19)
        Me.rbMenikah.TabIndex = 1
        Me.rbMenikah.Text = "Menikah"
        Me.rbMenikah.UseVisualStyleBackColor = True
        '
        'rbSingle
        '
        Me.rbSingle.AutoSize = True
        Me.rbSingle.Checked = True
        Me.rbSingle.Location = New System.Drawing.Point(3, 4)
        Me.rbSingle.Name = "rbSingle"
        Me.rbSingle.Size = New System.Drawing.Size(57, 19)
        Me.rbSingle.TabIndex = 0
        Me.rbSingle.TabStop = True
        Me.rbSingle.Text = "Single"
        Me.rbSingle.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(359, 179)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(45, 15)
        Me.lblStatus.TabIndex = 25
        Me.lblStatus.Text = "Status :"
        '
        'tbNoKK
        '
        Me.tbNoKK.Location = New System.Drawing.Point(63, 173)
        Me.tbNoKK.Name = "tbNoKK"
        Me.tbNoKK.Size = New System.Drawing.Size(271, 23)
        Me.tbNoKK.TabIndex = 12
        '
        'lblNoKK
        '
        Me.lblNoKK.AutoSize = True
        Me.lblNoKK.Location = New System.Drawing.Point(11, 176)
        Me.lblNoKK.Name = "lblNoKK"
        Me.lblNoKK.Size = New System.Drawing.Size(46, 15)
        Me.lblNoKK.TabIndex = 23
        Me.lblNoKK.Text = "No KK :"
        '
        'gbNPWP
        '
        Me.gbNPWP.Controls.Add(Me.tbAlamatBerdasarNPWP)
        Me.gbNPWP.Controls.Add(Me.lblAlamatBerdasarNPWP)
        Me.gbNPWP.Controls.Add(Me.tbNPWP)
        Me.gbNPWP.Controls.Add(Me.lblNPWP)
        Me.gbNPWP.Controls.Add(Me.tbNamaBerdasarNPWP)
        Me.gbNPWP.Controls.Add(Me.lblNamaBerdasarNPWP)
        Me.gbNPWP.Location = New System.Drawing.Point(6, 118)
        Me.gbNPWP.Name = "gbNPWP"
        Me.gbNPWP.Size = New System.Drawing.Size(1001, 55)
        Me.gbNPWP.TabIndex = 22
        Me.gbNPWP.TabStop = False
        Me.gbNPWP.Text = "NPWP"
        '
        'tbAlamatBerdasarNPWP
        '
        Me.tbAlamatBerdasarNPWP.Location = New System.Drawing.Point(631, 22)
        Me.tbAlamatBerdasarNPWP.Name = "tbAlamatBerdasarNPWP"
        Me.tbAlamatBerdasarNPWP.Size = New System.Drawing.Size(289, 23)
        Me.tbAlamatBerdasarNPWP.TabIndex = 11
        '
        'lblAlamatBerdasarNPWP
        '
        Me.lblAlamatBerdasarNPWP.AutoSize = True
        Me.lblAlamatBerdasarNPWP.Location = New System.Drawing.Point(574, 25)
        Me.lblAlamatBerdasarNPWP.Name = "lblAlamatBerdasarNPWP"
        Me.lblAlamatBerdasarNPWP.Size = New System.Drawing.Size(51, 15)
        Me.lblAlamatBerdasarNPWP.TabIndex = 23
        Me.lblAlamatBerdasarNPWP.Text = "Alamat :"
        '
        'tbNPWP
        '
        Me.tbNPWP.Location = New System.Drawing.Point(60, 22)
        Me.tbNPWP.Name = "tbNPWP"
        Me.tbNPWP.Size = New System.Drawing.Size(164, 23)
        Me.tbNPWP.TabIndex = 9
        '
        'lblNPWP
        '
        Me.lblNPWP.AutoSize = True
        Me.lblNPWP.Location = New System.Drawing.Point(7, 25)
        Me.lblNPWP.Name = "lblNPWP"
        Me.lblNPWP.Size = New System.Drawing.Size(47, 15)
        Me.lblNPWP.TabIndex = 17
        Me.lblNPWP.Text = "NPWP :"
        '
        'tbNamaBerdasarNPWP
        '
        Me.tbNamaBerdasarNPWP.Location = New System.Drawing.Point(288, 22)
        Me.tbNamaBerdasarNPWP.Name = "tbNamaBerdasarNPWP"
        Me.tbNamaBerdasarNPWP.Size = New System.Drawing.Size(271, 23)
        Me.tbNamaBerdasarNPWP.TabIndex = 10
        '
        'lblNamaBerdasarNPWP
        '
        Me.lblNamaBerdasarNPWP.AutoSize = True
        Me.lblNamaBerdasarNPWP.Location = New System.Drawing.Point(235, 25)
        Me.lblNamaBerdasarNPWP.Name = "lblNamaBerdasarNPWP"
        Me.lblNamaBerdasarNPWP.Size = New System.Drawing.Size(45, 15)
        Me.lblNamaBerdasarNPWP.TabIndex = 19
        Me.lblNamaBerdasarNPWP.Text = "Nama :"
        '
        'gbIdentitas
        '
        Me.gbIdentitas.Controls.Add(Me.pnlJenisKelamin)
        Me.gbIdentitas.Controls.Add(Me.Label3)
        Me.gbIdentitas.Controls.Add(Me.Label2)
        Me.gbIdentitas.Controls.Add(Me.Label1)
        Me.gbIdentitas.Controls.Add(Me.tbNIK)
        Me.gbIdentitas.Controls.Add(Me.lblNIK)
        Me.gbIdentitas.Controls.Add(Me.lblNama)
        Me.gbIdentitas.Controls.Add(Me.tbNama)
        Me.gbIdentitas.Controls.Add(Me.lblAlamat)
        Me.gbIdentitas.Controls.Add(Me.tbAlamat)
        Me.gbIdentitas.Controls.Add(Me.tbTempatLahir)
        Me.gbIdentitas.Controls.Add(Me.dtpTanggalLahir)
        Me.gbIdentitas.Controls.Add(Me.lblTempatLahir)
        Me.gbIdentitas.Controls.Add(Me.lblTanggalLahir)
        Me.gbIdentitas.Location = New System.Drawing.Point(6, 42)
        Me.gbIdentitas.Name = "gbIdentitas"
        Me.gbIdentitas.Size = New System.Drawing.Size(1001, 74)
        Me.gbIdentitas.TabIndex = 21
        Me.gbIdentitas.TabStop = False
        Me.gbIdentitas.Text = "IDENTITAS KTP"
        '
        'pnlJenisKelamin
        '
        Me.pnlJenisKelamin.Controls.Add(Me.rbWanita)
        Me.pnlJenisKelamin.Controls.Add(Me.rbPria)
        Me.pnlJenisKelamin.Location = New System.Drawing.Point(343, 44)
        Me.pnlJenisKelamin.Name = "pnlJenisKelamin"
        Me.pnlJenisKelamin.Size = New System.Drawing.Size(146, 25)
        Me.pnlJenisKelamin.TabIndex = 27
        '
        'rbWanita
        '
        Me.rbWanita.AutoSize = True
        Me.rbWanita.Location = New System.Drawing.Point(61, 4)
        Me.rbWanita.Name = "rbWanita"
        Me.rbWanita.Size = New System.Drawing.Size(62, 19)
        Me.rbWanita.TabIndex = 1
        Me.rbWanita.Text = "Wanita"
        Me.rbWanita.UseVisualStyleBackColor = True
        '
        'rbPria
        '
        Me.rbPria.AutoSize = True
        Me.rbPria.Checked = True
        Me.rbPria.Location = New System.Drawing.Point(3, 4)
        Me.rbPria.Name = "rbPria"
        Me.rbPria.Size = New System.Drawing.Size(45, 19)
        Me.rbPria.TabIndex = 0
        Me.rbPria.TabStop = True
        Me.rbPria.Text = "Pria"
        Me.rbPria.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(980, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(325, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(258, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "*"
        '
        'tbNIK
        '
        Me.tbNIK.Location = New System.Drawing.Point(60, 22)
        Me.tbNIK.Name = "tbNIK"
        Me.tbNIK.Size = New System.Drawing.Size(195, 23)
        Me.tbNIK.TabIndex = 4
        '
        'lblNIK
        '
        Me.lblNIK.AutoSize = True
        Me.lblNIK.Location = New System.Drawing.Point(22, 26)
        Me.lblNIK.Name = "lblNIK"
        Me.lblNIK.Size = New System.Drawing.Size(32, 15)
        Me.lblNIK.TabIndex = 3
        Me.lblNIK.Text = "NIK :"
        '
        'lblNama
        '
        Me.lblNama.AutoSize = True
        Me.lblNama.Location = New System.Drawing.Point(9, 49)
        Me.lblNama.Name = "lblNama"
        Me.lblNama.Size = New System.Drawing.Size(45, 15)
        Me.lblNama.TabIndex = 7
        Me.lblNama.Text = "Nama :"
        '
        'tbNama
        '
        Me.tbNama.Location = New System.Drawing.Point(60, 46)
        Me.tbNama.Name = "tbNama"
        Me.tbNama.Size = New System.Drawing.Size(259, 23)
        Me.tbNama.TabIndex = 5
        '
        'lblAlamat
        '
        Me.lblAlamat.AutoSize = True
        Me.lblAlamat.Location = New System.Drawing.Point(517, 49)
        Me.lblAlamat.Name = "lblAlamat"
        Me.lblAlamat.Size = New System.Drawing.Size(51, 15)
        Me.lblAlamat.TabIndex = 9
        Me.lblAlamat.Text = "Alamat :"
        '
        'tbAlamat
        '
        Me.tbAlamat.Location = New System.Drawing.Point(574, 46)
        Me.tbAlamat.Name = "tbAlamat"
        Me.tbAlamat.Size = New System.Drawing.Size(400, 23)
        Me.tbAlamat.TabIndex = 7
        '
        'tbTempatLahir
        '
        Me.tbTempatLahir.Location = New System.Drawing.Point(407, 17)
        Me.tbTempatLahir.Name = "tbTempatLahir"
        Me.tbTempatLahir.Size = New System.Drawing.Size(181, 23)
        Me.tbTempatLahir.TabIndex = 6
        '
        'dtpTanggalLahir
        '
        Me.dtpTanggalLahir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalLahir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalLahir.Location = New System.Drawing.Point(688, 17)
        Me.dtpTanggalLahir.Name = "dtpTanggalLahir"
        Me.dtpTanggalLahir.Size = New System.Drawing.Size(119, 23)
        Me.dtpTanggalLahir.TabIndex = 8
        '
        'lblTempatLahir
        '
        Me.lblTempatLahir.AutoSize = True
        Me.lblTempatLahir.Location = New System.Drawing.Point(320, 20)
        Me.lblTempatLahir.Name = "lblTempatLahir"
        Me.lblTempatLahir.Size = New System.Drawing.Size(81, 15)
        Me.lblTempatLahir.TabIndex = 11
        Me.lblTempatLahir.Text = "Tempat Lahir :"
        '
        'lblTanggalLahir
        '
        Me.lblTanggalLahir.AutoSize = True
        Me.lblTanggalLahir.Location = New System.Drawing.Point(599, 23)
        Me.lblTanggalLahir.Name = "lblTanggalLahir"
        Me.lblTanggalLahir.Size = New System.Drawing.Size(83, 15)
        Me.lblTanggalLahir.TabIndex = 13
        Me.lblTanggalLahir.Text = "Tanggal Lahir :"
        '
        'dtpTanggalMasuk
        '
        Me.dtpTanggalMasuk.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalMasuk.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalMasuk.Location = New System.Drawing.Point(371, 13)
        Me.dtpTanggalMasuk.Name = "dtpTanggalMasuk"
        Me.dtpTanggalMasuk.Size = New System.Drawing.Size(119, 23)
        Me.dtpTanggalMasuk.TabIndex = 2
        '
        'lblTanggalMasuk
        '
        Me.lblTanggalMasuk.AutoSize = True
        Me.lblTanggalMasuk.Location = New System.Drawing.Point(273, 19)
        Me.lblTanggalMasuk.Name = "lblTanggalMasuk"
        Me.lblTanggalMasuk.Size = New System.Drawing.Size(92, 15)
        Me.lblTanggalMasuk.TabIndex = 15
        Me.lblTanggalMasuk.Text = "Tanggal Masuk :"
        '
        'tbIDK
        '
        Me.tbIDK.Location = New System.Drawing.Point(107, 16)
        Me.tbIDK.Name = "tbIDK"
        Me.tbIDK.ReadOnly = True
        Me.tbIDK.Size = New System.Drawing.Size(123, 23)
        Me.tbIDK.TabIndex = 1
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(884, 250)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 23
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(758, 250)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 22
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'lblIDK
        '
        Me.lblIDK.AutoSize = True
        Me.lblIDK.Location = New System.Drawing.Point(23, 19)
        Me.lblIDK.Name = "lblIDK"
        Me.lblIDK.Size = New System.Drawing.Size(78, 15)
        Me.lblIDK.TabIndex = 1
        Me.lblIDK.Text = "ID Karyawan :"
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(1172, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 22
        '
        'FormMasterKaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1284, 701)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMasterKaryawan"
        Me.Text = "FORM MASTER KARYAWAN"
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.pnlStatusBekerja.ResumeLayout(False)
        Me.pnlStatusBekerja.PerformLayout()
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlStatus.PerformLayout()
        Me.gbNPWP.ResumeLayout(False)
        Me.gbNPWP.PerformLayout()
        Me.gbIdentitas.ResumeLayout(False)
        Me.gbIdentitas.PerformLayout()
        Me.pnlJenisKelamin.ResumeLayout(False)
        Me.pnlJenisKelamin.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
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
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents lblNIK As Label
    Friend WithEvents lblIDK As Label
    Friend WithEvents tbIDK As TextBox
    Friend WithEvents tbNIK As TextBox
    Friend WithEvents tbNama As TextBox
    Friend WithEvents lblNama As Label
    Friend WithEvents tbAlamat As TextBox
    Friend WithEvents lblAlamat As Label
    Friend WithEvents tbTempatLahir As TextBox
    Friend WithEvents lblTempatLahir As Label
    Friend WithEvents lblTanggalLahir As Label
    Friend WithEvents dtpTanggalLahir As DateTimePicker
    Friend WithEvents dtpTanggalMasuk As DateTimePicker
    Friend WithEvents lblTanggalMasuk As Label
    Friend WithEvents tbNPWP As TextBox
    Friend WithEvents lblNPWP As Label
    Friend WithEvents tbNamaBerdasarNPWP As TextBox
    Friend WithEvents lblNamaBerdasarNPWP As Label
    Friend WithEvents gbIdentitas As GroupBox
    Friend WithEvents gbNPWP As GroupBox
    Friend WithEvents tbAlamatBerdasarNPWP As TextBox
    Friend WithEvents lblAlamatBerdasarNPWP As Label
    Friend WithEvents tbNoKK As TextBox
    Friend WithEvents lblNoKK As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents pnlStatus As Panel
    Friend WithEvents rbSingle As RadioButton
    Friend WithEvents rbMenikah As RadioButton
    Friend WithEvents tbNoHP As TextBox
    Friend WithEvents lblNoHP As Label
    Friend WithEvents tbEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblAgama As Label
    Friend WithEvents cboAgama As ComboBox
    Friend WithEvents cboGolDarah As ComboBox
    Friend WithEvents lblGolDarah As Label
    Friend WithEvents lblPendidikanAkhir As Label
    Friend WithEvents lblLulusanDari As Label
    Friend WithEvents cboPendidikan As ComboBox
    Friend WithEvents tbLulusanDari As TextBox
    Friend WithEvents lblTahunKelulusan As Label
    Friend WithEvents tbTahunLulus As TextBox
    Friend WithEvents lblBPJSTK As Label
    Friend WithEvents clbBPJSTK As CheckedListBox
    Friend WithEvents tbBPJSKesehatan As TextBox
    Friend WithEvents lblBPJSKesehatan As Label
    Friend WithEvents tbJaminan As TextBox
    Friend WithEvents lblJaminan As Label
    Friend WithEvents lblStatusBekerja As Label
    Friend WithEvents pnlStatusBekerja As Panel
    Friend WithEvents rbResign As RadioButton
    Friend WithEvents rbAktif As RadioButton
    Friend WithEvents rbPensiun As RadioButton
    Friend WithEvents lblTanggalBerhentiKerja As Label
    Friend WithEvents dtpBerhentiKerja As DateTimePicker
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlJenisKelamin As Panel
    Friend WithEvents rbWanita As RadioButton
    Friend WithEvents rbPria As RadioButton
    Friend WithEvents Label4 As Label
End Class
