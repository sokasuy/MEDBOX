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
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.cbShowCommandColumns = New System.Windows.Forms.CheckBox()
        Me.lblPilihanData = New System.Windows.Forms.Label()
        Me.pnlPilihanData = New System.Windows.Forms.Panel()
        Me.rbFilterHistory = New System.Windows.Forms.RadioButton()
        Me.rbFilterAktif = New System.Windows.Forms.RadioButton()
        Me.lblSorting = New System.Windows.Forms.Label()
        Me.cboSortingType = New System.Windows.Forms.ComboBox()
        Me.cboSortingCriteria = New System.Windows.Forms.ComboBox()
        Me.lblKelompok = New System.Windows.Forms.Label()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.lblDepartemen = New System.Windows.Forms.Label()
        Me.cboDepartemen = New System.Windows.Forms.ComboBox()
        Me.cboKelompok = New System.Windows.Forms.ComboBox()
        Me.cboPerusahaan = New System.Windows.Forms.ComboBox()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboLokasi = New System.Windows.Forms.ComboBox()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.gbBPJS = New System.Windows.Forms.GroupBox()
        Me.tbNomerBPJSTenagaKerja = New System.Windows.Forms.TextBox()
        Me.tbNomerBPJSKesehatan = New System.Windows.Forms.TextBox()
        Me.cbBPJSKesehatan = New System.Windows.Forms.CheckBox()
        Me.clbBPJSTK = New System.Windows.Forms.CheckedListBox()
        Me.lblBPJSTK = New System.Windows.Forms.Label()
        Me.gbPendidikan = New System.Windows.Forms.GroupBox()
        Me.tbPendidikan = New System.Windows.Forms.TextBox()
        Me.lblTahunLulus = New System.Windows.Forms.Label()
        Me.lblPendidikanAkhir = New System.Windows.Forms.Label()
        Me.tbTahunLulus = New System.Windows.Forms.TextBox()
        Me.tbLulusanDari = New System.Windows.Forms.TextBox()
        Me.lblLulusanDari = New System.Windows.Forms.Label()
        Me.gbNPWP = New System.Windows.Forms.GroupBox()
        Me.mtbNPWP = New System.Windows.Forms.MaskedTextBox()
        Me.lblAlamatBerdasarNPWP = New System.Windows.Forms.Label()
        Me.tbAlamatBerdasarNPWP = New System.Windows.Forms.TextBox()
        Me.lblNamaBerdasarNPWP = New System.Windows.Forms.Label()
        Me.tbNamaBerdasarNPWP = New System.Windows.Forms.TextBox()
        Me.lblNPWP = New System.Windows.Forms.Label()
        Me.gbIdentitas = New System.Windows.Forms.GroupBox()
        Me.lblDigitKK = New System.Windows.Forms.Label()
        Me.lblDigitNIK = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.tbJumlahAnak = New System.Windows.Forms.TextBox()
        Me.lblJumlahAnak = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAlamat = New System.Windows.Forms.Label()
        Me.cboGolDarah = New System.Windows.Forms.ComboBox()
        Me.lblGolDarah = New System.Windows.Forms.Label()
        Me.tbAlamat = New System.Windows.Forms.TextBox()
        Me.lblTanggalLahir = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.cboAgama = New System.Windows.Forms.ComboBox()
        Me.tbEmail = New System.Windows.Forms.TextBox()
        Me.lblAgama = New System.Windows.Forms.Label()
        Me.tbNoHP = New System.Windows.Forms.TextBox()
        Me.lblNoHP = New System.Windows.Forms.Label()
        Me.dtpTanggalLahir = New System.Windows.Forms.DateTimePicker()
        Me.lblTempatLahir = New System.Windows.Forms.Label()
        Me.tbTempatLahir = New System.Windows.Forms.TextBox()
        Me.pnlJenisKelamin = New System.Windows.Forms.Panel()
        Me.rbWanita = New System.Windows.Forms.RadioButton()
        Me.rbPria = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbNoKK = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNama = New System.Windows.Forms.Label()
        Me.lblNoKK = New System.Windows.Forms.Label()
        Me.tbNama = New System.Windows.Forms.TextBox()
        Me.lblNIK = New System.Windows.Forms.Label()
        Me.tbNIK = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblJaminan = New System.Windows.Forms.Label()
        Me.lblTanggalTerakhirKerja = New System.Windows.Forms.Label()
        Me.tbJaminan = New System.Windows.Forms.TextBox()
        Me.dtpTerakhirKerja = New System.Windows.Forms.DateTimePicker()
        Me.pnlStatusBekerja = New System.Windows.Forms.Panel()
        Me.rbPensiun = New System.Windows.Forms.RadioButton()
        Me.rbResign = New System.Windows.Forms.RadioButton()
        Me.rbAktif = New System.Windows.Forms.RadioButton()
        Me.lblStatusBekerja = New System.Windows.Forms.Label()
        Me.lblTanggalMasuk = New System.Windows.Forms.Label()
        Me.dtpTanggalMasuk = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblIDK = New System.Windows.Forms.Label()
        Me.tbIDK = New System.Windows.Forms.TextBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnIsiCepat = New System.Windows.Forms.Button()
        Me.pnlCetak = New System.Windows.Forms.Panel()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.tbNamaSimpan = New System.Windows.Forms.TextBox()
        Me.tbPathSimpan = New System.Windows.Forms.TextBox()
        Me.lblNamaSimpan = New System.Windows.Forms.Label()
        Me.lblSimpanKeDrive = New System.Windows.Forms.Label()
        Me.fbdExport = New System.Windows.Forms.FolderBrowserDialog()
        Me.cbSertifikat = New System.Windows.Forms.CheckBox()
        Me.dtpSertifikat = New System.Windows.Forms.DateTimePicker()
        Me.gbView.SuspendLayout()
        Me.pnlPilihanData.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDataEntry.SuspendLayout()
        Me.gbBPJS.SuspendLayout()
        Me.gbPendidikan.SuspendLayout()
        Me.gbNPWP.SuspendLayout()
        Me.gbIdentitas.SuspendLayout()
        Me.pnlJenisKelamin.SuspendLayout()
        Me.pnlStatusBekerja.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(1274, 25)
        Me.lblTitle.TabIndex = 176
        Me.lblTitle.Text = "MASTER KARYAWAN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(1030, 27)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 187
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(760, 292)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 27
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
        Me.clbUserRight.Location = New System.Drawing.Point(1166, 27)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 186
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.cbShowCommandColumns)
        Me.gbView.Controls.Add(Me.lblPilihanData)
        Me.gbView.Controls.Add(Me.pnlPilihanData)
        Me.gbView.Controls.Add(Me.lblSorting)
        Me.gbView.Controls.Add(Me.cboSortingType)
        Me.gbView.Controls.Add(Me.cboSortingCriteria)
        Me.gbView.Controls.Add(Me.lblKelompok)
        Me.gbView.Controls.Add(Me.lblPerusahaan)
        Me.gbView.Controls.Add(Me.lblDepartemen)
        Me.gbView.Controls.Add(Me.cboDepartemen)
        Me.gbView.Controls.Add(Me.cboKelompok)
        Me.gbView.Controls.Add(Me.cboPerusahaan)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 384)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(1254, 370)
        Me.gbView.TabIndex = 188
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'cbShowCommandColumns
        '
        Me.cbShowCommandColumns.AutoSize = True
        Me.cbShowCommandColumns.Location = New System.Drawing.Point(1082, 336)
        Me.cbShowCommandColumns.Name = "cbShowCommandColumns"
        Me.cbShowCommandColumns.Size = New System.Drawing.Size(166, 19)
        Me.cbShowCommandColumns.TabIndex = 200
        Me.cbShowCommandColumns.Text = "Show Command Columns"
        Me.cbShowCommandColumns.UseVisualStyleBackColor = True
        Me.cbShowCommandColumns.Visible = False
        '
        'lblPilihanData
        '
        Me.lblPilihanData.AutoSize = True
        Me.lblPilihanData.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPilihanData.ForeColor = System.Drawing.Color.Blue
        Me.lblPilihanData.Location = New System.Drawing.Point(45, -2)
        Me.lblPilihanData.Name = "lblPilihanData"
        Me.lblPilihanData.Size = New System.Drawing.Size(98, 21)
        Me.lblPilihanData.TabIndex = 191
        Me.lblPilihanData.Text = "DATA AKTIF"
        '
        'pnlPilihanData
        '
        Me.pnlPilihanData.Controls.Add(Me.rbFilterHistory)
        Me.pnlPilihanData.Controls.Add(Me.rbFilterAktif)
        Me.pnlPilihanData.Location = New System.Drawing.Point(991, 36)
        Me.pnlPilihanData.Name = "pnlPilihanData"
        Me.pnlPilihanData.Size = New System.Drawing.Size(131, 25)
        Me.pnlPilihanData.TabIndex = 199
        '
        'rbFilterHistory
        '
        Me.rbFilterHistory.AutoSize = True
        Me.rbFilterHistory.Location = New System.Drawing.Point(59, 4)
        Me.rbFilterHistory.Name = "rbFilterHistory"
        Me.rbFilterHistory.Size = New System.Drawing.Size(63, 19)
        Me.rbFilterHistory.TabIndex = 1
        Me.rbFilterHistory.Text = "History"
        Me.rbFilterHistory.UseVisualStyleBackColor = True
        '
        'rbFilterAktif
        '
        Me.rbFilterAktif.AutoSize = True
        Me.rbFilterAktif.Checked = True
        Me.rbFilterAktif.Location = New System.Drawing.Point(3, 4)
        Me.rbFilterAktif.Name = "rbFilterAktif"
        Me.rbFilterAktif.Size = New System.Drawing.Size(50, 19)
        Me.rbFilterAktif.TabIndex = 0
        Me.rbFilterAktif.TabStop = True
        Me.rbFilterAktif.Text = "Aktif"
        Me.rbFilterAktif.UseVisualStyleBackColor = True
        '
        'lblSorting
        '
        Me.lblSorting.AutoSize = True
        Me.lblSorting.Location = New System.Drawing.Point(772, 20)
        Me.lblSorting.Name = "lblSorting"
        Me.lblSorting.Size = New System.Drawing.Size(51, 15)
        Me.lblSorting.TabIndex = 181
        Me.lblSorting.Text = "Sorting :"
        '
        'cboSortingType
        '
        Me.cboSortingType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSortingType.FormattingEnabled = True
        Me.cboSortingType.Location = New System.Drawing.Point(897, 38)
        Me.cboSortingType.Name = "cboSortingType"
        Me.cboSortingType.Size = New System.Drawing.Size(91, 23)
        Me.cboSortingType.TabIndex = 180
        '
        'cboSortingCriteria
        '
        Me.cboSortingCriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingCriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingCriteria.FormattingEnabled = True
        Me.cboSortingCriteria.IntegralHeight = False
        Me.cboSortingCriteria.Location = New System.Drawing.Point(775, 38)
        Me.cboSortingCriteria.Name = "cboSortingCriteria"
        Me.cboSortingCriteria.Size = New System.Drawing.Size(116, 23)
        Me.cboSortingCriteria.TabIndex = 179
        '
        'lblKelompok
        '
        Me.lblKelompok.AutoSize = True
        Me.lblKelompok.Location = New System.Drawing.Point(190, 20)
        Me.lblKelompok.Name = "lblKelompok"
        Me.lblKelompok.Size = New System.Drawing.Size(67, 15)
        Me.lblKelompok.TabIndex = 178
        Me.lblKelompok.Text = "Kelompok :"
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Location = New System.Drawing.Point(6, 20)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaan.TabIndex = 177
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'lblDepartemen
        '
        Me.lblDepartemen.AutoSize = True
        Me.lblDepartemen.Location = New System.Drawing.Point(305, 20)
        Me.lblDepartemen.Name = "lblDepartemen"
        Me.lblDepartemen.Size = New System.Drawing.Size(78, 15)
        Me.lblDepartemen.TabIndex = 176
        Me.lblDepartemen.Text = "Departemen :"
        '
        'cboDepartemen
        '
        Me.cboDepartemen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDepartemen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDepartemen.FormattingEnabled = True
        Me.cboDepartemen.IntegralHeight = False
        Me.cboDepartemen.Location = New System.Drawing.Point(308, 38)
        Me.cboDepartemen.Name = "cboDepartemen"
        Me.cboDepartemen.Size = New System.Drawing.Size(137, 23)
        Me.cboDepartemen.TabIndex = 175
        '
        'cboKelompok
        '
        Me.cboKelompok.FormattingEnabled = True
        Me.cboKelompok.IntegralHeight = False
        Me.cboKelompok.Location = New System.Drawing.Point(193, 38)
        Me.cboKelompok.Name = "cboKelompok"
        Me.cboKelompok.Size = New System.Drawing.Size(109, 23)
        Me.cboKelompok.TabIndex = 174
        '
        'cboPerusahaan
        '
        Me.cboPerusahaan.FormattingEnabled = True
        Me.cboPerusahaan.IntegralHeight = False
        Me.cboPerusahaan.Location = New System.Drawing.Point(6, 38)
        Me.cboPerusahaan.Name = "cboPerusahaan"
        Me.cboPerusahaan.Size = New System.Drawing.Size(181, 23)
        Me.cboPerusahaan.TabIndex = 173
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
        Me.lblRecord.Size = New System.Drawing.Size(39, 15)
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
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(573, 38)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(196, 23)
        Me.tbCari.TabIndex = 29
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(1128, 10)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 30
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Location = New System.Drawing.Point(451, 20)
        Me.lblCari.Name = "lblCari"
        Me.lblCari.Size = New System.Drawing.Size(50, 15)
        Me.lblCari.TabIndex = 132
        Me.lblCari.Text = "Kriteria :"
        '
        'cboKriteria
        '
        Me.cboKriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKriteria.FormattingEnabled = True
        Me.cboKriteria.IntegralHeight = False
        Me.cboKriteria.Location = New System.Drawing.Point(451, 38)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(116, 23)
        Me.cboKriteria.TabIndex = 28
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
        Me.dgvView.Size = New System.Drawing.Size(1242, 263)
        Me.dgvView.TabIndex = 130
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.Label7)
        Me.gbDataEntry.Controls.Add(Me.cboLokasi)
        Me.gbDataEntry.Controls.Add(Me.lblLokasi)
        Me.gbDataEntry.Controls.Add(Me.gbBPJS)
        Me.gbDataEntry.Controls.Add(Me.gbPendidikan)
        Me.gbDataEntry.Controls.Add(Me.gbNPWP)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.gbIdentitas)
        Me.gbDataEntry.Controls.Add(Me.lblJaminan)
        Me.gbDataEntry.Controls.Add(Me.lblTanggalTerakhirKerja)
        Me.gbDataEntry.Controls.Add(Me.tbJaminan)
        Me.gbDataEntry.Controls.Add(Me.dtpTerakhirKerja)
        Me.gbDataEntry.Controls.Add(Me.pnlStatusBekerja)
        Me.gbDataEntry.Controls.Add(Me.lblStatusBekerja)
        Me.gbDataEntry.Controls.Add(Me.lblTanggalMasuk)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggalMasuk)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.lblIDK)
        Me.gbDataEntry.Controls.Add(Me.tbIDK)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 27)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(1012, 358)
        Me.gbDataEntry.TabIndex = 189
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(987, 266)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 15)
        Me.Label7.TabIndex = 230
        Me.Label7.Text = "*"
        '
        'cboLokasi
        '
        Me.cboLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasi.FormattingEnabled = True
        Me.cboLokasi.IntegralHeight = False
        Me.cboLokasi.Location = New System.Drawing.Point(826, 263)
        Me.cboLokasi.Name = "cboLokasi"
        Me.cboLokasi.Size = New System.Drawing.Size(155, 23)
        Me.cboLokasi.TabIndex = 25
        '
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Location = New System.Drawing.Point(774, 266)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(46, 15)
        Me.lblLokasi.TabIndex = 227
        Me.lblLokasi.Text = "Lokasi :"
        '
        'gbBPJS
        '
        Me.gbBPJS.Controls.Add(Me.tbNomerBPJSTenagaKerja)
        Me.gbBPJS.Controls.Add(Me.tbNomerBPJSKesehatan)
        Me.gbBPJS.Controls.Add(Me.cbBPJSKesehatan)
        Me.gbBPJS.Controls.Add(Me.clbBPJSTK)
        Me.gbBPJS.Controls.Add(Me.lblBPJSTK)
        Me.gbBPJS.Location = New System.Drawing.Point(6, 234)
        Me.gbBPJS.Name = "gbBPJS"
        Me.gbBPJS.Size = New System.Drawing.Size(748, 112)
        Me.gbBPJS.TabIndex = 202
        Me.gbBPJS.TabStop = False
        Me.gbBPJS.Text = "BPJS"
        '
        'tbNomerBPJSTenagaKerja
        '
        Me.tbNomerBPJSTenagaKerja.Location = New System.Drawing.Point(61, 15)
        Me.tbNomerBPJSTenagaKerja.Name = "tbNomerBPJSTenagaKerja"
        Me.tbNomerBPJSTenagaKerja.Size = New System.Drawing.Size(268, 23)
        Me.tbNomerBPJSTenagaKerja.TabIndex = 22
        '
        'tbNomerBPJSKesehatan
        '
        Me.tbNomerBPJSKesehatan.Location = New System.Drawing.Point(466, 15)
        Me.tbNomerBPJSKesehatan.Name = "tbNomerBPJSKesehatan"
        Me.tbNomerBPJSKesehatan.Size = New System.Drawing.Size(276, 23)
        Me.tbNomerBPJSKesehatan.TabIndex = 23
        '
        'cbBPJSKesehatan
        '
        Me.cbBPJSKesehatan.AutoSize = True
        Me.cbBPJSKesehatan.Location = New System.Drawing.Point(348, 17)
        Me.cbBPJSKesehatan.Name = "cbBPJSKesehatan"
        Me.cbBPJSKesehatan.Size = New System.Drawing.Size(112, 19)
        Me.cbBPJSKesehatan.TabIndex = 21
        Me.cbBPJSKesehatan.Text = "BPJS Kesehatan :"
        Me.cbBPJSKesehatan.UseVisualStyleBackColor = True
        '
        'clbBPJSTK
        '
        Me.clbBPJSTK.FormattingEnabled = True
        Me.clbBPJSTK.Items.AddRange(New Object() {"JKK", "JKM", "JHT", "JP"})
        Me.clbBPJSTK.Location = New System.Drawing.Point(61, 40)
        Me.clbBPJSTK.MultiColumn = True
        Me.clbBPJSTK.Name = "clbBPJSTK"
        Me.clbBPJSTK.Size = New System.Drawing.Size(268, 40)
        Me.clbBPJSTK.TabIndex = 213
        '
        'lblBPJSTK
        '
        Me.lblBPJSTK.AutoSize = True
        Me.lblBPJSTK.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBPJSTK.Location = New System.Drawing.Point(3, 18)
        Me.lblBPJSTK.Name = "lblBPJSTK"
        Me.lblBPJSTK.Size = New System.Drawing.Size(52, 15)
        Me.lblBPJSTK.TabIndex = 214
        Me.lblBPJSTK.Text = "BPJS TK :"
        '
        'gbPendidikan
        '
        Me.gbPendidikan.Controls.Add(Me.dtpSertifikat)
        Me.gbPendidikan.Controls.Add(Me.cbSertifikat)
        Me.gbPendidikan.Controls.Add(Me.tbPendidikan)
        Me.gbPendidikan.Controls.Add(Me.lblTahunLulus)
        Me.gbPendidikan.Controls.Add(Me.lblPendidikanAkhir)
        Me.gbPendidikan.Controls.Add(Me.tbTahunLulus)
        Me.gbPendidikan.Controls.Add(Me.tbLulusanDari)
        Me.gbPendidikan.Controls.Add(Me.lblLulusanDari)
        Me.gbPendidikan.Location = New System.Drawing.Point(6, 186)
        Me.gbPendidikan.Name = "gbPendidikan"
        Me.gbPendidikan.Size = New System.Drawing.Size(1000, 45)
        Me.gbPendidikan.TabIndex = 201
        Me.gbPendidikan.TabStop = False
        Me.gbPendidikan.Text = "Pendidikan"
        '
        'tbPendidikan
        '
        Me.tbPendidikan.Location = New System.Drawing.Point(85, 16)
        Me.tbPendidikan.Name = "tbPendidikan"
        Me.tbPendidikan.Size = New System.Drawing.Size(115, 23)
        Me.tbPendidikan.TabIndex = 19
        '
        'lblTahunLulus
        '
        Me.lblTahunLulus.AutoSize = True
        Me.lblTahunLulus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTahunLulus.Location = New System.Drawing.Point(501, 19)
        Me.lblTahunLulus.Name = "lblTahunLulus"
        Me.lblTahunLulus.Size = New System.Drawing.Size(76, 15)
        Me.lblTahunLulus.TabIndex = 224
        Me.lblTahunLulus.Text = "Tahun Lulus :"
        '
        'lblPendidikanAkhir
        '
        Me.lblPendidikanAkhir.AutoSize = True
        Me.lblPendidikanAkhir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPendidikanAkhir.Location = New System.Drawing.Point(7, 19)
        Me.lblPendidikanAkhir.Name = "lblPendidikanAkhir"
        Me.lblPendidikanAkhir.Size = New System.Drawing.Size(72, 15)
        Me.lblPendidikanAkhir.TabIndex = 206
        Me.lblPendidikanAkhir.Text = "Pendidikan :"
        '
        'tbTahunLulus
        '
        Me.tbTahunLulus.Location = New System.Drawing.Point(583, 16)
        Me.tbTahunLulus.Name = "tbTahunLulus"
        Me.tbTahunLulus.Size = New System.Drawing.Size(109, 23)
        Me.tbTahunLulus.TabIndex = 21
        '
        'tbLulusanDari
        '
        Me.tbLulusanDari.Location = New System.Drawing.Point(289, 16)
        Me.tbLulusanDari.Name = "tbLulusanDari"
        Me.tbLulusanDari.Size = New System.Drawing.Size(206, 23)
        Me.tbLulusanDari.TabIndex = 20
        '
        'lblLulusanDari
        '
        Me.lblLulusanDari.AutoSize = True
        Me.lblLulusanDari.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLulusanDari.Location = New System.Drawing.Point(205, 19)
        Me.lblLulusanDari.Name = "lblLulusanDari"
        Me.lblLulusanDari.Size = New System.Drawing.Size(78, 15)
        Me.lblLulusanDari.TabIndex = 218
        Me.lblLulusanDari.Text = "Lulusan Dari :"
        '
        'gbNPWP
        '
        Me.gbNPWP.Controls.Add(Me.mtbNPWP)
        Me.gbNPWP.Controls.Add(Me.lblAlamatBerdasarNPWP)
        Me.gbNPWP.Controls.Add(Me.tbAlamatBerdasarNPWP)
        Me.gbNPWP.Controls.Add(Me.lblNamaBerdasarNPWP)
        Me.gbNPWP.Controls.Add(Me.tbNamaBerdasarNPWP)
        Me.gbNPWP.Controls.Add(Me.lblNPWP)
        Me.gbNPWP.Location = New System.Drawing.Point(6, 138)
        Me.gbNPWP.Name = "gbNPWP"
        Me.gbNPWP.Size = New System.Drawing.Size(1000, 45)
        Me.gbNPWP.TabIndex = 200
        Me.gbNPWP.TabStop = False
        Me.gbNPWP.Text = "NPWP"
        '
        'mtbNPWP
        '
        Me.mtbNPWP.Location = New System.Drawing.Point(61, 16)
        Me.mtbNPWP.Mask = "00.000.000.0-000.000"
        Me.mtbNPWP.Name = "mtbNPWP"
        Me.mtbNPWP.Size = New System.Drawing.Size(145, 23)
        Me.mtbNPWP.TabIndex = 16
        '
        'lblAlamatBerdasarNPWP
        '
        Me.lblAlamatBerdasarNPWP.AutoSize = True
        Me.lblAlamatBerdasarNPWP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAlamatBerdasarNPWP.Location = New System.Drawing.Point(603, 19)
        Me.lblAlamatBerdasarNPWP.Name = "lblAlamatBerdasarNPWP"
        Me.lblAlamatBerdasarNPWP.Size = New System.Drawing.Size(51, 15)
        Me.lblAlamatBerdasarNPWP.TabIndex = 196
        Me.lblAlamatBerdasarNPWP.Text = "Alamat :"
        '
        'tbAlamatBerdasarNPWP
        '
        Me.tbAlamatBerdasarNPWP.Location = New System.Drawing.Point(660, 16)
        Me.tbAlamatBerdasarNPWP.Name = "tbAlamatBerdasarNPWP"
        Me.tbAlamatBerdasarNPWP.Size = New System.Drawing.Size(334, 23)
        Me.tbAlamatBerdasarNPWP.TabIndex = 18
        '
        'lblNamaBerdasarNPWP
        '
        Me.lblNamaBerdasarNPWP.AutoSize = True
        Me.lblNamaBerdasarNPWP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNamaBerdasarNPWP.Location = New System.Drawing.Point(252, 19)
        Me.lblNamaBerdasarNPWP.Name = "lblNamaBerdasarNPWP"
        Me.lblNamaBerdasarNPWP.Size = New System.Drawing.Size(45, 15)
        Me.lblNamaBerdasarNPWP.TabIndex = 28
        Me.lblNamaBerdasarNPWP.Text = "Nama :"
        '
        'tbNamaBerdasarNPWP
        '
        Me.tbNamaBerdasarNPWP.Location = New System.Drawing.Point(303, 16)
        Me.tbNamaBerdasarNPWP.Name = "tbNamaBerdasarNPWP"
        Me.tbNamaBerdasarNPWP.Size = New System.Drawing.Size(294, 23)
        Me.tbNamaBerdasarNPWP.TabIndex = 17
        '
        'lblNPWP
        '
        Me.lblNPWP.AutoSize = True
        Me.lblNPWP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNPWP.Location = New System.Drawing.Point(8, 19)
        Me.lblNPWP.Name = "lblNPWP"
        Me.lblNPWP.Size = New System.Drawing.Size(47, 15)
        Me.lblNPWP.TabIndex = 26
        Me.lblNPWP.Text = "NPWP :"
        '
        'gbIdentitas
        '
        Me.gbIdentitas.Controls.Add(Me.lblDigitKK)
        Me.gbIdentitas.Controls.Add(Me.lblDigitNIK)
        Me.gbIdentitas.Controls.Add(Me.Label6)
        Me.gbIdentitas.Controls.Add(Me.cboStatus)
        Me.gbIdentitas.Controls.Add(Me.tbJumlahAnak)
        Me.gbIdentitas.Controls.Add(Me.lblJumlahAnak)
        Me.gbIdentitas.Controls.Add(Me.Label5)
        Me.gbIdentitas.Controls.Add(Me.lblAlamat)
        Me.gbIdentitas.Controls.Add(Me.cboGolDarah)
        Me.gbIdentitas.Controls.Add(Me.lblGolDarah)
        Me.gbIdentitas.Controls.Add(Me.tbAlamat)
        Me.gbIdentitas.Controls.Add(Me.lblTanggalLahir)
        Me.gbIdentitas.Controls.Add(Me.lblEmail)
        Me.gbIdentitas.Controls.Add(Me.cboAgama)
        Me.gbIdentitas.Controls.Add(Me.tbEmail)
        Me.gbIdentitas.Controls.Add(Me.lblAgama)
        Me.gbIdentitas.Controls.Add(Me.tbNoHP)
        Me.gbIdentitas.Controls.Add(Me.lblNoHP)
        Me.gbIdentitas.Controls.Add(Me.dtpTanggalLahir)
        Me.gbIdentitas.Controls.Add(Me.lblTempatLahir)
        Me.gbIdentitas.Controls.Add(Me.tbTempatLahir)
        Me.gbIdentitas.Controls.Add(Me.pnlJenisKelamin)
        Me.gbIdentitas.Controls.Add(Me.Label2)
        Me.gbIdentitas.Controls.Add(Me.tbNoKK)
        Me.gbIdentitas.Controls.Add(Me.Label1)
        Me.gbIdentitas.Controls.Add(Me.lblNama)
        Me.gbIdentitas.Controls.Add(Me.lblNoKK)
        Me.gbIdentitas.Controls.Add(Me.tbNama)
        Me.gbIdentitas.Controls.Add(Me.lblNIK)
        Me.gbIdentitas.Controls.Add(Me.tbNIK)
        Me.gbIdentitas.Controls.Add(Me.lblStatus)
        Me.gbIdentitas.Location = New System.Drawing.Point(6, 40)
        Me.gbIdentitas.Name = "gbIdentitas"
        Me.gbIdentitas.Size = New System.Drawing.Size(1000, 95)
        Me.gbIdentitas.TabIndex = 199
        Me.gbIdentitas.TabStop = False
        Me.gbIdentitas.Text = "IDENTITAS"
        '
        'lblDigitKK
        '
        Me.lblDigitKK.AutoSize = True
        Me.lblDigitKK.ForeColor = System.Drawing.Color.Red
        Me.lblDigitKK.Location = New System.Drawing.Point(477, 19)
        Me.lblDigitKK.Name = "lblDigitKK"
        Me.lblDigitKK.Size = New System.Drawing.Size(13, 15)
        Me.lblDigitKK.TabIndex = 229
        Me.lblDigitKK.Text = "0"
        '
        'lblDigitNIK
        '
        Me.lblDigitNIK.AutoSize = True
        Me.lblDigitNIK.ForeColor = System.Drawing.Color.Red
        Me.lblDigitNIK.Location = New System.Drawing.Point(224, 22)
        Me.lblDigitNIK.Name = "lblDigitNIK"
        Me.lblDigitNIK.Size = New System.Drawing.Size(13, 15)
        Me.lblDigitNIK.TabIndex = 228
        Me.lblDigitNIK.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(696, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 15)
        Me.Label6.TabIndex = 227
        Me.Label6.Text = "*"
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.IntegralHeight = False
        Me.cboStatus.Location = New System.Drawing.Point(569, 43)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(121, 23)
        Me.cboStatus.TabIndex = 9
        '
        'tbJumlahAnak
        '
        Me.tbJumlahAnak.Location = New System.Drawing.Point(801, 41)
        Me.tbJumlahAnak.Name = "tbJumlahAnak"
        Me.tbJumlahAnak.Size = New System.Drawing.Size(41, 23)
        Me.tbJumlahAnak.TabIndex = 10
        Me.tbJumlahAnak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblJumlahAnak
        '
        Me.lblJumlahAnak.AutoSize = True
        Me.lblJumlahAnak.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJumlahAnak.Location = New System.Drawing.Point(714, 44)
        Me.lblJumlahAnak.Name = "lblJumlahAnak"
        Me.lblJumlahAnak.Size = New System.Drawing.Size(81, 15)
        Me.lblJumlahAnak.TabIndex = 225
        Me.lblJumlahAnak.Text = "Jumlah Anak :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(280, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 15)
        Me.Label5.TabIndex = 204
        Me.Label5.Text = "*"
        '
        'lblAlamat
        '
        Me.lblAlamat.AutoSize = True
        Me.lblAlamat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAlamat.Location = New System.Drawing.Point(4, 70)
        Me.lblAlamat.Name = "lblAlamat"
        Me.lblAlamat.Size = New System.Drawing.Size(51, 15)
        Me.lblAlamat.TabIndex = 203
        Me.lblAlamat.Text = "Alamat :"
        '
        'cboGolDarah
        '
        Me.cboGolDarah.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGolDarah.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGolDarah.FormattingEnabled = True
        Me.cboGolDarah.IntegralHeight = False
        Me.cboGolDarah.Location = New System.Drawing.Point(919, 41)
        Me.cboGolDarah.Name = "cboGolDarah"
        Me.cboGolDarah.Size = New System.Drawing.Size(75, 23)
        Me.cboGolDarah.TabIndex = 11
        '
        'lblGolDarah
        '
        Me.lblGolDarah.AutoSize = True
        Me.lblGolDarah.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblGolDarah.Location = New System.Drawing.Point(848, 44)
        Me.lblGolDarah.Name = "lblGolDarah"
        Me.lblGolDarah.Size = New System.Drawing.Size(65, 15)
        Me.lblGolDarah.TabIndex = 212
        Me.lblGolDarah.Text = "Gol Darah :"
        '
        'tbAlamat
        '
        Me.tbAlamat.Location = New System.Drawing.Point(61, 67)
        Me.tbAlamat.Name = "tbAlamat"
        Me.tbAlamat.Size = New System.Drawing.Size(213, 23)
        Me.tbAlamat.TabIndex = 12
        '
        'lblTanggalLahir
        '
        Me.lblTanggalLahir.AutoSize = True
        Me.lblTanggalLahir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTanggalLahir.Location = New System.Drawing.Point(514, 20)
        Me.lblTanggalLahir.Name = "lblTanggalLahir"
        Me.lblTanggalLahir.Size = New System.Drawing.Size(83, 15)
        Me.lblTanggalLahir.TabIndex = 201
        Me.lblTanggalLahir.Text = "Tanggal Lahir :"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmail.Location = New System.Drawing.Point(774, 70)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(42, 15)
        Me.lblEmail.TabIndex = 216
        Me.lblEmail.Text = "Email :"
        '
        'cboAgama
        '
        Me.cboAgama.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAgama.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAgama.FormattingEnabled = True
        Me.cboAgama.IntegralHeight = False
        Me.cboAgama.Location = New System.Drawing.Point(874, 16)
        Me.cboAgama.Name = "cboAgama"
        Me.cboAgama.Size = New System.Drawing.Size(120, 23)
        Me.cboAgama.TabIndex = 7
        '
        'tbEmail
        '
        Me.tbEmail.Location = New System.Drawing.Point(822, 67)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(172, 23)
        Me.tbEmail.TabIndex = 15
        '
        'lblAgama
        '
        Me.lblAgama.AutoSize = True
        Me.lblAgama.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAgama.Location = New System.Drawing.Point(817, 19)
        Me.lblAgama.Name = "lblAgama"
        Me.lblAgama.Size = New System.Drawing.Size(51, 15)
        Me.lblAgama.TabIndex = 210
        Me.lblAgama.Text = "Agama :"
        '
        'tbNoHP
        '
        Me.tbNoHP.Location = New System.Drawing.Point(604, 67)
        Me.tbNoHP.Name = "tbNoHP"
        Me.tbNoHP.Size = New System.Drawing.Size(164, 23)
        Me.tbNoHP.TabIndex = 14
        '
        'lblNoHP
        '
        Me.lblNoHP.AutoSize = True
        Me.lblNoHP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNoHP.Location = New System.Drawing.Point(550, 70)
        Me.lblNoHP.Name = "lblNoHP"
        Me.lblNoHP.Size = New System.Drawing.Size(48, 15)
        Me.lblNoHP.TabIndex = 204
        Me.lblNoHP.Text = "No HP :"
        '
        'dtpTanggalLahir
        '
        Me.dtpTanggalLahir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalLahir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalLahir.Location = New System.Drawing.Point(603, 14)
        Me.dtpTanggalLahir.Name = "dtpTanggalLahir"
        Me.dtpTanggalLahir.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggalLahir.TabIndex = 6
        '
        'lblTempatLahir
        '
        Me.lblTempatLahir.AutoSize = True
        Me.lblTempatLahir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTempatLahir.Location = New System.Drawing.Point(295, 70)
        Me.lblTempatLahir.Name = "lblTempatLahir"
        Me.lblTempatLahir.Size = New System.Drawing.Size(81, 15)
        Me.lblTempatLahir.TabIndex = 199
        Me.lblTempatLahir.Text = "Tempat Lahir :"
        '
        'tbTempatLahir
        '
        Me.tbTempatLahir.Location = New System.Drawing.Point(382, 67)
        Me.tbTempatLahir.Name = "tbTempatLahir"
        Me.tbTempatLahir.Size = New System.Drawing.Size(162, 23)
        Me.tbTempatLahir.TabIndex = 13
        '
        'pnlJenisKelamin
        '
        Me.pnlJenisKelamin.Controls.Add(Me.rbWanita)
        Me.pnlJenisKelamin.Controls.Add(Me.rbPria)
        Me.pnlJenisKelamin.Location = New System.Drawing.Point(382, 41)
        Me.pnlJenisKelamin.Name = "pnlJenisKelamin"
        Me.pnlJenisKelamin.Size = New System.Drawing.Size(131, 25)
        Me.pnlJenisKelamin.TabIndex = 197
        '
        'rbWanita
        '
        Me.rbWanita.AutoSize = True
        Me.rbWanita.Location = New System.Drawing.Point(59, 4)
        Me.rbWanita.Name = "rbWanita"
        Me.rbWanita.Size = New System.Drawing.Size(69, 19)
        Me.rbWanita.TabIndex = 1
        Me.rbWanita.Text = "WANITA"
        Me.rbWanita.UseVisualStyleBackColor = True
        '
        'rbPria
        '
        Me.rbPria.AutoSize = True
        Me.rbPria.Location = New System.Drawing.Point(3, 4)
        Me.rbPria.Name = "rbPria"
        Me.rbPria.Size = New System.Drawing.Size(50, 19)
        Me.rbPria.TabIndex = 0
        Me.rbPria.Text = "PRIA"
        Me.rbPria.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(344, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 194
        Me.Label2.Text = "*"
        '
        'tbNoKK
        '
        Me.tbNoKK.Location = New System.Drawing.Point(320, 16)
        Me.tbNoKK.Name = "tbNoKK"
        Me.tbNoKK.Size = New System.Drawing.Size(151, 23)
        Me.tbNoKK.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(206, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "*"
        '
        'lblNama
        '
        Me.lblNama.AutoSize = True
        Me.lblNama.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNama.Location = New System.Drawing.Point(10, 46)
        Me.lblNama.Name = "lblNama"
        Me.lblNama.Size = New System.Drawing.Size(45, 15)
        Me.lblNama.TabIndex = 28
        Me.lblNama.Text = "Nama :"
        '
        'lblNoKK
        '
        Me.lblNoKK.AutoSize = True
        Me.lblNoKK.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNoKK.Location = New System.Drawing.Point(268, 19)
        Me.lblNoKK.Name = "lblNoKK"
        Me.lblNoKK.Size = New System.Drawing.Size(46, 15)
        Me.lblNoKK.TabIndex = 202
        Me.lblNoKK.Text = "No KK :"
        '
        'tbNama
        '
        Me.tbNama.Location = New System.Drawing.Point(61, 43)
        Me.tbNama.Name = "tbNama"
        Me.tbNama.Size = New System.Drawing.Size(277, 23)
        Me.tbNama.TabIndex = 8
        '
        'lblNIK
        '
        Me.lblNIK.AutoSize = True
        Me.lblNIK.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNIK.Location = New System.Drawing.Point(23, 22)
        Me.lblNIK.Name = "lblNIK"
        Me.lblNIK.Size = New System.Drawing.Size(32, 15)
        Me.lblNIK.TabIndex = 26
        Me.lblNIK.Text = "NIK :"
        '
        'tbNIK
        '
        Me.tbNIK.Location = New System.Drawing.Point(61, 19)
        Me.tbNIK.Name = "tbNIK"
        Me.tbNIK.Size = New System.Drawing.Size(139, 23)
        Me.tbNIK.TabIndex = 4
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus.Location = New System.Drawing.Point(518, 47)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(45, 15)
        Me.lblStatus.TabIndex = 208
        Me.lblStatus.Text = "Status :"
        '
        'lblJaminan
        '
        Me.lblJaminan.AutoSize = True
        Me.lblJaminan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJaminan.Location = New System.Drawing.Point(763, 240)
        Me.lblJaminan.Name = "lblJaminan"
        Me.lblJaminan.Size = New System.Drawing.Size(57, 15)
        Me.lblJaminan.TabIndex = 222
        Me.lblJaminan.Text = "Jaminan :"
        '
        'lblTanggalTerakhirKerja
        '
        Me.lblTanggalTerakhirKerja.AutoSize = True
        Me.lblTanggalTerakhirKerja.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTanggalTerakhirKerja.Location = New System.Drawing.Point(788, 18)
        Me.lblTanggalTerakhirKerja.Name = "lblTanggalTerakhirKerja"
        Me.lblTanggalTerakhirKerja.Size = New System.Drawing.Size(83, 15)
        Me.lblTanggalTerakhirKerja.TabIndex = 198
        Me.lblTanggalTerakhirKerja.Text = "Terakhir Kerja :"
        '
        'tbJaminan
        '
        Me.tbJaminan.Location = New System.Drawing.Point(826, 237)
        Me.tbJaminan.Name = "tbJaminan"
        Me.tbJaminan.Size = New System.Drawing.Size(180, 23)
        Me.tbJaminan.TabIndex = 24
        '
        'dtpTerakhirKerja
        '
        Me.dtpTerakhirKerja.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTerakhirKerja.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTerakhirKerja.Location = New System.Drawing.Point(880, 12)
        Me.dtpTerakhirKerja.Name = "dtpTerakhirKerja"
        Me.dtpTerakhirKerja.Size = New System.Drawing.Size(120, 23)
        Me.dtpTerakhirKerja.TabIndex = 3
        '
        'pnlStatusBekerja
        '
        Me.pnlStatusBekerja.Controls.Add(Me.rbPensiun)
        Me.pnlStatusBekerja.Controls.Add(Me.rbResign)
        Me.pnlStatusBekerja.Controls.Add(Me.rbAktif)
        Me.pnlStatusBekerja.Location = New System.Drawing.Point(570, 12)
        Me.pnlStatusBekerja.Name = "pnlStatusBekerja"
        Me.pnlStatusBekerja.Size = New System.Drawing.Size(202, 25)
        Me.pnlStatusBekerja.TabIndex = 196
        '
        'rbPensiun
        '
        Me.rbPensiun.AutoSize = True
        Me.rbPensiun.Location = New System.Drawing.Point(125, 4)
        Me.rbPensiun.Name = "rbPensiun"
        Me.rbPensiun.Size = New System.Drawing.Size(73, 19)
        Me.rbPensiun.TabIndex = 2
        Me.rbPensiun.Text = "PENSIUN"
        Me.rbPensiun.UseVisualStyleBackColor = True
        '
        'rbResign
        '
        Me.rbResign.AutoSize = True
        Me.rbResign.Location = New System.Drawing.Point(59, 4)
        Me.rbResign.Name = "rbResign"
        Me.rbResign.Size = New System.Drawing.Size(64, 19)
        Me.rbResign.TabIndex = 1
        Me.rbResign.Text = "RESIGN"
        Me.rbResign.UseVisualStyleBackColor = True
        '
        'rbAktif
        '
        Me.rbAktif.AutoSize = True
        Me.rbAktif.Location = New System.Drawing.Point(3, 4)
        Me.rbAktif.Name = "rbAktif"
        Me.rbAktif.Size = New System.Drawing.Size(55, 19)
        Me.rbAktif.TabIndex = 0
        Me.rbAktif.Text = "AKTIF"
        Me.rbAktif.UseVisualStyleBackColor = True
        '
        'lblStatusBekerja
        '
        Me.lblStatusBekerja.AutoSize = True
        Me.lblStatusBekerja.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatusBekerja.Location = New System.Drawing.Point(478, 18)
        Me.lblStatusBekerja.Name = "lblStatusBekerja"
        Me.lblStatusBekerja.Size = New System.Drawing.Size(86, 15)
        Me.lblStatusBekerja.TabIndex = 195
        Me.lblStatusBekerja.Text = "Status Bekerja :"
        '
        'lblTanggalMasuk
        '
        Me.lblTanggalMasuk.AutoSize = True
        Me.lblTanggalMasuk.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTanggalMasuk.Location = New System.Drawing.Point(248, 18)
        Me.lblTanggalMasuk.Name = "lblTanggalMasuk"
        Me.lblTanggalMasuk.Size = New System.Drawing.Size(92, 15)
        Me.lblTanggalMasuk.TabIndex = 194
        Me.lblTanggalMasuk.Text = "Tanggal Masuk :"
        '
        'dtpTanggalMasuk
        '
        Me.dtpTanggalMasuk.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalMasuk.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalMasuk.Location = New System.Drawing.Point(346, 12)
        Me.dtpTanggalMasuk.Name = "dtpTanggalMasuk"
        Me.dtpTanggalMasuk.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggalMasuk.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(221, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 192
        Me.Label3.Text = "*"
        '
        'lblIDK
        '
        Me.lblIDK.AutoSize = True
        Me.lblIDK.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIDK.Location = New System.Drawing.Point(8, 18)
        Me.lblIDK.Name = "lblIDK"
        Me.lblIDK.Size = New System.Drawing.Size(78, 15)
        Me.lblIDK.TabIndex = 24
        Me.lblIDK.Text = "ID Karyawan :"
        '
        'tbIDK
        '
        Me.tbIDK.Location = New System.Drawing.Point(92, 15)
        Me.tbIDK.Name = "tbIDK"
        Me.tbIDK.ReadOnly = True
        Me.tbIDK.Size = New System.Drawing.Size(123, 23)
        Me.tbIDK.TabIndex = 1
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(886, 292)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 26
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(1146, 293)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 31
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnIsiCepat
        '
        Me.btnIsiCepat.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnIsiCepat.Image = Global.FormMasterKaryawan.My.Resources.Resources.isi_cepat
        Me.btnIsiCepat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIsiCepat.Location = New System.Drawing.Point(1034, 51)
        Me.btnIsiCepat.Name = "btnIsiCepat"
        Me.btnIsiCepat.Size = New System.Drawing.Size(120, 54)
        Me.btnIsiCepat.TabIndex = 32
        Me.btnIsiCepat.Text = "ISI CEPAT"
        Me.btnIsiCepat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIsiCepat.UseVisualStyleBackColor = True
        '
        'pnlCetak
        '
        Me.pnlCetak.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCetak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCetak.Controls.Add(Me.btnBrowse)
        Me.pnlCetak.Controls.Add(Me.btnExportExcel)
        Me.pnlCetak.Controls.Add(Me.tbNamaSimpan)
        Me.pnlCetak.Controls.Add(Me.tbPathSimpan)
        Me.pnlCetak.Controls.Add(Me.lblNamaSimpan)
        Me.pnlCetak.Controls.Add(Me.lblSimpanKeDrive)
        Me.pnlCetak.Location = New System.Drawing.Point(12, 760)
        Me.pnlCetak.Name = "pnlCetak"
        Me.pnlCetak.Size = New System.Drawing.Size(1254, 62)
        Me.pnlCetak.TabIndex = 197
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(444, 1)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 24)
        Me.btnBrowse.TabIndex = 16
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
        Me.btnExportExcel.TabIndex = 18
        Me.btnExportExcel.Text = "EXCEL"
        Me.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'tbNamaSimpan
        '
        Me.tbNamaSimpan.Location = New System.Drawing.Point(107, 31)
        Me.tbNamaSimpan.Name = "tbNamaSimpan"
        Me.tbNamaSimpan.Size = New System.Drawing.Size(360, 23)
        Me.tbNamaSimpan.TabIndex = 17
        '
        'tbPathSimpan
        '
        Me.tbPathSimpan.Location = New System.Drawing.Point(107, 3)
        Me.tbPathSimpan.Name = "tbPathSimpan"
        Me.tbPathSimpan.Size = New System.Drawing.Size(333, 23)
        Me.tbPathSimpan.TabIndex = 15
        '
        'lblNamaSimpan
        '
        Me.lblNamaSimpan.AutoSize = True
        Me.lblNamaSimpan.Location = New System.Drawing.Point(22, 34)
        Me.lblNamaSimpan.Name = "lblNamaSimpan"
        Me.lblNamaSimpan.Size = New System.Drawing.Size(88, 15)
        Me.lblNamaSimpan.TabIndex = 87
        Me.lblNamaSimpan.Text = "Nama Simpan :"
        '
        'lblSimpanKeDrive
        '
        Me.lblSimpanKeDrive.AutoSize = True
        Me.lblSimpanKeDrive.Location = New System.Drawing.Point(10, 6)
        Me.lblSimpanKeDrive.Name = "lblSimpanKeDrive"
        Me.lblSimpanKeDrive.Size = New System.Drawing.Size(98, 15)
        Me.lblSimpanKeDrive.TabIndex = 86
        Me.lblSimpanKeDrive.Text = "Simpan ke Drive :"
        '
        'cbSertifikat
        '
        Me.cbSertifikat.AutoSize = True
        Me.cbSertifikat.Location = New System.Drawing.Point(698, 20)
        Me.cbSertifikat.Name = "cbSertifikat"
        Me.cbSertifikat.Size = New System.Drawing.Size(72, 19)
        Me.cbSertifikat.TabIndex = 225
        Me.cbSertifikat.Text = "Sertifikat"
        Me.cbSertifikat.UseVisualStyleBackColor = True
        '
        'dtpSertifikat
        '
        Me.dtpSertifikat.CustomFormat = "dd-MMM-yyyy"
        Me.dtpSertifikat.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSertifikat.Location = New System.Drawing.Point(776, 16)
        Me.dtpSertifikat.Name = "dtpSertifikat"
        Me.dtpSertifikat.Size = New System.Drawing.Size(120, 23)
        Me.dtpSertifikat.TabIndex = 226
        '
        'FormMasterKaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1274, 826)
        Me.Controls.Add(Me.pnlCetak)
        Me.Controls.Add(Me.btnIsiCepat)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnKeluar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMasterKaryawan"
        Me.Text = "FORM MASTER KARYAWAN"
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlPilihanData.ResumeLayout(False)
        Me.pnlPilihanData.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.gbBPJS.ResumeLayout(False)
        Me.gbBPJS.PerformLayout()
        Me.gbPendidikan.ResumeLayout(False)
        Me.gbPendidikan.PerformLayout()
        Me.gbNPWP.ResumeLayout(False)
        Me.gbNPWP.PerformLayout()
        Me.gbIdentitas.ResumeLayout(False)
        Me.gbIdentitas.PerformLayout()
        Me.pnlJenisKelamin.ResumeLayout(False)
        Me.pnlJenisKelamin.PerformLayout()
        Me.pnlStatusBekerja.ResumeLayout(False)
        Me.pnlStatusBekerja.PerformLayout()
        Me.pnlCetak.ResumeLayout(False)
        Me.pnlCetak.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents clbUserRight As CheckedListBox
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
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents lblIDK As Label
    Friend WithEvents tbIDK As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTanggalMasuk As Label
    Friend WithEvents dtpTanggalMasuk As DateTimePicker
    Friend WithEvents lblStatusBekerja As Label
    Friend WithEvents pnlStatusBekerja As Panel
    Friend WithEvents rbAktif As RadioButton
    Friend WithEvents rbResign As RadioButton
    Friend WithEvents rbPensiun As RadioButton
    Friend WithEvents lblTanggalTerakhirKerja As Label
    Friend WithEvents dtpTerakhirKerja As DateTimePicker
    Friend WithEvents gbIdentitas As GroupBox
    Friend WithEvents lblNIK As Label
    Friend WithEvents tbNIK As TextBox
    Friend WithEvents lblNama As Label
    Friend WithEvents tbNama As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlJenisKelamin As Panel
    Friend WithEvents rbWanita As RadioButton
    Friend WithEvents rbPria As RadioButton
    Friend WithEvents lblTempatLahir As Label
    Friend WithEvents tbTempatLahir As TextBox
    Friend WithEvents lblTanggalLahir As Label
    Friend WithEvents dtpTanggalLahir As DateTimePicker
    Friend WithEvents lblAlamat As Label
    Friend WithEvents tbAlamat As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents gbNPWP As GroupBox
    Friend WithEvents lblNamaBerdasarNPWP As Label
    Friend WithEvents tbNamaBerdasarNPWP As TextBox
    Friend WithEvents lblNPWP As Label
    Friend WithEvents lblAlamatBerdasarNPWP As Label
    Friend WithEvents tbAlamatBerdasarNPWP As TextBox
    Friend WithEvents lblNoKK As Label
    Friend WithEvents tbNoKK As TextBox
    Friend WithEvents lblNoHP As Label
    Friend WithEvents tbNoHP As TextBox
    Friend WithEvents lblPendidikanAkhir As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents cboAgama As ComboBox
    Friend WithEvents lblAgama As Label
    Friend WithEvents cboGolDarah As ComboBox
    Friend WithEvents lblGolDarah As Label
    Friend WithEvents clbBPJSTK As CheckedListBox
    Friend WithEvents lblBPJSTK As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents tbEmail As TextBox
    Friend WithEvents lblLulusanDari As Label
    Friend WithEvents tbLulusanDari As TextBox
    Friend WithEvents lblJaminan As Label
    Friend WithEvents tbJaminan As TextBox
    Friend WithEvents lblTahunLulus As Label
    Friend WithEvents tbTahunLulus As TextBox
    Friend WithEvents gbPendidikan As GroupBox
    Friend WithEvents gbBPJS As GroupBox
    Friend WithEvents lblJumlahAnak As Label
    Friend WithEvents tbJumlahAnak As TextBox
    Friend WithEvents tbNomerBPJSKesehatan As TextBox
    Friend WithEvents tbNomerBPJSTenagaKerja As TextBox
    Friend WithEvents cbBPJSKesehatan As CheckBox
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbPendidikan As TextBox
    Friend WithEvents lblDigitNIK As Label
    Friend WithEvents lblDigitKK As Label
    Friend WithEvents mtbNPWP As MaskedTextBox
    Friend WithEvents btnIsiCepat As Button
    Friend WithEvents cboLokasi As ComboBox
    Friend WithEvents lblLokasi As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cboPerusahaan As ComboBox
    Friend WithEvents cboKelompok As ComboBox
    Friend WithEvents cboDepartemen As ComboBox
    Friend WithEvents lblDepartemen As Label
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents lblKelompok As Label
    Friend WithEvents cboSortingCriteria As ComboBox
    Friend WithEvents cboSortingType As ComboBox
    Friend WithEvents lblSorting As Label
    Friend WithEvents pnlPilihanData As Panel
    Friend WithEvents rbFilterHistory As RadioButton
    Friend WithEvents rbFilterAktif As RadioButton
    Friend WithEvents lblPilihanData As Label
    Friend WithEvents cbShowCommandColumns As CheckBox
    Friend WithEvents pnlCetak As Panel
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents tbNamaSimpan As TextBox
    Friend WithEvents tbPathSimpan As TextBox
    Friend WithEvents lblNamaSimpan As Label
    Friend WithEvents lblSimpanKeDrive As Label
    Friend WithEvents fbdExport As FolderBrowserDialog
    Friend WithEvents cbSertifikat As CheckBox
    Friend WithEvents dtpSertifikat As DateTimePicker
End Class
