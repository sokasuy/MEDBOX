<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMasterKaryawanAktif
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterKaryawanAktif))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.lblSorting = New System.Windows.Forms.Label()
        Me.cboSortingType = New System.Windows.Forms.ComboBox()
        Me.cboSortingCriteria = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboFilterDepartemen = New System.Windows.Forms.ComboBox()
        Me.cboKelompok = New System.Windows.Forms.ComboBox()
        Me.cboFilterPerusahaan = New System.Windows.Forms.ComboBox()
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlTanggalMulaiKerjaTetap = New System.Windows.Forms.Panel()
        Me.lblTanggalMulaiKerjaTetap = New System.Windows.Forms.Label()
        Me.dtpTanggalMulaiKerjaTetap = New System.Windows.Forms.DateTimePicker()
        Me.lblKelompok = New System.Windows.Forms.Label()
        Me.pnlKelompok = New System.Windows.Forms.Panel()
        Me.rbOutsource = New System.Windows.Forms.RadioButton()
        Me.rbNonStaff = New System.Windows.Forms.RadioButton()
        Me.rbStaff = New System.Windows.Forms.RadioButton()
        Me.cboLokasi = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.lblFPID = New System.Windows.Forms.Label()
        Me.tbFPID = New System.Windows.Forms.TextBox()
        Me.lblHari = New System.Windows.Forms.Label()
        Me.lblResetSP = New System.Windows.Forms.Label()
        Me.tbResetSP = New System.Windows.Forms.TextBox()
        Me.lblKatGaji = New System.Windows.Forms.Label()
        Me.pnlKatGaji = New System.Windows.Forms.Panel()
        Me.rbBulanan = New System.Windows.Forms.RadioButton()
        Me.rbMingguan = New System.Windows.Forms.RadioButton()
        Me.lblInfoNIPKosong = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNIP = New System.Windows.Forms.Label()
        Me.tbNIP = New System.Windows.Forms.TextBox()
        Me.pnlPeriodeKontrak = New System.Windows.Forms.Panel()
        Me.dtpTanggalSelesaiKontrak = New System.Windows.Forms.DateTimePicker()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.lblDari = New System.Windows.Forms.Label()
        Me.dtpTanggalMulaiKontrak = New System.Windows.Forms.DateTimePicker()
        Me.lblKontrakKe = New System.Windows.Forms.Label()
        Me.tbKontrakKe = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboStatusPegawai = New System.Windows.Forms.ComboBox()
        Me.lblStatusPegawai = New System.Windows.Forms.Label()
        Me.cboBagian = New System.Windows.Forms.ComboBox()
        Me.lblBagian = New System.Windows.Forms.Label()
        Me.cboDivisi = New System.Windows.Forms.ComboBox()
        Me.lblDivisi = New System.Windows.Forms.Label()
        Me.cboDepartemen = New System.Windows.Forms.ComboBox()
        Me.lblDepartemen = New System.Windows.Forms.Label()
        Me.cboPerusahaan = New System.Windows.Forms.ComboBox()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.lblEditingWarning = New System.Windows.Forms.Label()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.btnProsesImport = New System.Windows.Forms.Button()
        Me.gbImportExcel = New System.Windows.Forms.GroupBox()
        Me.tbNamaFile = New System.Windows.Forms.TextBox()
        Me.lblNamaFile = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblNamaSheet = New System.Windows.Forms.Label()
        Me.tbNamaSheet = New System.Windows.Forms.TextBox()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.pnlCetak = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.tbNamaSimpan = New System.Windows.Forms.TextBox()
        Me.tbPathSimpan = New System.Windows.Forms.TextBox()
        Me.lblNamaSimpan = New System.Windows.Forms.Label()
        Me.lblSimpanKeDrive = New System.Windows.Forms.Label()
        Me.fbdExport = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gbView.SuspendLayout()
        Me.pnlPilihanData.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDataEntry.SuspendLayout()
        Me.pnlTanggalMulaiKerjaTetap.SuspendLayout()
        Me.pnlKelompok.SuspendLayout()
        Me.pnlKatGaji.SuspendLayout()
        Me.pnlPeriodeKontrak.SuspendLayout()
        Me.gbImportExcel.SuspendLayout()
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
        Me.lblTitle.TabIndex = 177
        Me.lblTitle.Text = "MASTER KARYAWAN AKTIF"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.lblSorting)
        Me.gbView.Controls.Add(Me.cboSortingType)
        Me.gbView.Controls.Add(Me.cboSortingCriteria)
        Me.gbView.Controls.Add(Me.Label6)
        Me.gbView.Controls.Add(Me.Label7)
        Me.gbView.Controls.Add(Me.Label8)
        Me.gbView.Controls.Add(Me.cboFilterDepartemen)
        Me.gbView.Controls.Add(Me.cboKelompok)
        Me.gbView.Controls.Add(Me.cboFilterPerusahaan)
        Me.gbView.Controls.Add(Me.lblPilihanData)
        Me.gbView.Controls.Add(Me.pnlPilihanData)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 243)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(1250, 370)
        Me.gbView.TabIndex = 189
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'lblSorting
        '
        Me.lblSorting.AutoSize = True
        Me.lblSorting.Location = New System.Drawing.Point(772, 22)
        Me.lblSorting.Name = "lblSorting"
        Me.lblSorting.Size = New System.Drawing.Size(46, 13)
        Me.lblSorting.TabIndex = 207
        Me.lblSorting.Text = "Sorting :"
        '
        'cboSortingType
        '
        Me.cboSortingType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSortingType.FormattingEnabled = True
        Me.cboSortingType.Location = New System.Drawing.Point(897, 40)
        Me.cboSortingType.Name = "cboSortingType"
        Me.cboSortingType.Size = New System.Drawing.Size(91, 21)
        Me.cboSortingType.TabIndex = 206
        '
        'cboSortingCriteria
        '
        Me.cboSortingCriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingCriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingCriteria.FormattingEnabled = True
        Me.cboSortingCriteria.IntegralHeight = False
        Me.cboSortingCriteria.Location = New System.Drawing.Point(775, 40)
        Me.cboSortingCriteria.Name = "cboSortingCriteria"
        Me.cboSortingCriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboSortingCriteria.TabIndex = 205
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(190, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 204
        Me.Label6.Text = "Kelompok :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 203
        Me.Label7.Text = "Perusahaan :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(305, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 202
        Me.Label8.Text = "Departemen :"
        '
        'cboFilterDepartemen
        '
        Me.cboFilterDepartemen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFilterDepartemen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFilterDepartemen.FormattingEnabled = True
        Me.cboFilterDepartemen.IntegralHeight = False
        Me.cboFilterDepartemen.Location = New System.Drawing.Point(308, 40)
        Me.cboFilterDepartemen.Name = "cboFilterDepartemen"
        Me.cboFilterDepartemen.Size = New System.Drawing.Size(137, 21)
        Me.cboFilterDepartemen.TabIndex = 201
        '
        'cboKelompok
        '
        Me.cboKelompok.FormattingEnabled = True
        Me.cboKelompok.IntegralHeight = False
        Me.cboKelompok.Location = New System.Drawing.Point(193, 40)
        Me.cboKelompok.Name = "cboKelompok"
        Me.cboKelompok.Size = New System.Drawing.Size(109, 21)
        Me.cboKelompok.TabIndex = 200
        '
        'cboFilterPerusahaan
        '
        Me.cboFilterPerusahaan.FormattingEnabled = True
        Me.cboFilterPerusahaan.IntegralHeight = False
        Me.cboFilterPerusahaan.Location = New System.Drawing.Point(6, 40)
        Me.cboFilterPerusahaan.Name = "cboFilterPerusahaan"
        Me.cboFilterPerusahaan.Size = New System.Drawing.Size(181, 21)
        Me.cboFilterPerusahaan.TabIndex = 199
        '
        'lblPilihanData
        '
        Me.lblPilihanData.AutoSize = True
        Me.lblPilihanData.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPilihanData.ForeColor = System.Drawing.Color.Blue
        Me.lblPilihanData.Location = New System.Drawing.Point(46, -4)
        Me.lblPilihanData.Name = "lblPilihanData"
        Me.lblPilihanData.Size = New System.Drawing.Size(98, 21)
        Me.lblPilihanData.TabIndex = 190
        Me.lblPilihanData.Text = "DATA AKTIF"
        '
        'pnlPilihanData
        '
        Me.pnlPilihanData.Controls.Add(Me.rbHistory)
        Me.pnlPilihanData.Controls.Add(Me.rbAktif)
        Me.pnlPilihanData.Location = New System.Drawing.Point(994, 36)
        Me.pnlPilihanData.Name = "pnlPilihanData"
        Me.pnlPilihanData.Size = New System.Drawing.Size(131, 25)
        Me.pnlPilihanData.TabIndex = 198
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
        Me.tbCari.Location = New System.Drawing.Point(573, 40)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(196, 20)
        Me.tbCari.TabIndex = 15
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(1127, 10)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 16
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Location = New System.Drawing.Point(451, 24)
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
        Me.cboKriteria.Location = New System.Drawing.Point(451, 40)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboKriteria.TabIndex = 14
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
        Me.dgvView.Size = New System.Drawing.Size(1238, 263)
        Me.dgvView.TabIndex = 130
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.Label11)
        Me.gbDataEntry.Controls.Add(Me.Label10)
        Me.gbDataEntry.Controls.Add(Me.Label9)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.pnlTanggalMulaiKerjaTetap)
        Me.gbDataEntry.Controls.Add(Me.lblKelompok)
        Me.gbDataEntry.Controls.Add(Me.pnlKelompok)
        Me.gbDataEntry.Controls.Add(Me.cboLokasi)
        Me.gbDataEntry.Controls.Add(Me.Label5)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.lblLokasi)
        Me.gbDataEntry.Controls.Add(Me.lblFPID)
        Me.gbDataEntry.Controls.Add(Me.tbFPID)
        Me.gbDataEntry.Controls.Add(Me.lblHari)
        Me.gbDataEntry.Controls.Add(Me.lblResetSP)
        Me.gbDataEntry.Controls.Add(Me.tbResetSP)
        Me.gbDataEntry.Controls.Add(Me.lblKatGaji)
        Me.gbDataEntry.Controls.Add(Me.pnlKatGaji)
        Me.gbDataEntry.Controls.Add(Me.lblInfoNIPKosong)
        Me.gbDataEntry.Controls.Add(Me.Label4)
        Me.gbDataEntry.Controls.Add(Me.lblNIP)
        Me.gbDataEntry.Controls.Add(Me.tbNIP)
        Me.gbDataEntry.Controls.Add(Me.pnlPeriodeKontrak)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.cboStatusPegawai)
        Me.gbDataEntry.Controls.Add(Me.lblStatusPegawai)
        Me.gbDataEntry.Controls.Add(Me.cboBagian)
        Me.gbDataEntry.Controls.Add(Me.lblBagian)
        Me.gbDataEntry.Controls.Add(Me.cboDivisi)
        Me.gbDataEntry.Controls.Add(Me.lblDivisi)
        Me.gbDataEntry.Controls.Add(Me.cboDepartemen)
        Me.gbDataEntry.Controls.Add(Me.lblDepartemen)
        Me.gbDataEntry.Controls.Add(Me.cboPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.lblPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.cboKaryawan)
        Me.gbDataEntry.Controls.Add(Me.lblEditingWarning)
        Me.gbDataEntry.Controls.Add(Me.lblKaryawan)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(887, 212)
        Me.gbDataEntry.TabIndex = 190
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(240, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 229
        Me.Label3.Text = "*"
        '
        'pnlTanggalMulaiKerjaTetap
        '
        Me.pnlTanggalMulaiKerjaTetap.Controls.Add(Me.lblTanggalMulaiKerjaTetap)
        Me.pnlTanggalMulaiKerjaTetap.Controls.Add(Me.dtpTanggalMulaiKerjaTetap)
        Me.pnlTanggalMulaiKerjaTetap.Location = New System.Drawing.Point(216, 90)
        Me.pnlTanggalMulaiKerjaTetap.Name = "pnlTanggalMulaiKerjaTetap"
        Me.pnlTanggalMulaiKerjaTetap.Size = New System.Drawing.Size(215, 30)
        Me.pnlTanggalMulaiKerjaTetap.TabIndex = 195
        '
        'lblTanggalMulaiKerjaTetap
        '
        Me.lblTanggalMulaiKerjaTetap.AutoSize = True
        Me.lblTanggalMulaiKerjaTetap.Location = New System.Drawing.Point(3, 10)
        Me.lblTanggalMulaiKerjaTetap.Name = "lblTanggalMulaiKerjaTetap"
        Me.lblTanggalMulaiKerjaTetap.Size = New System.Drawing.Size(83, 15)
        Me.lblTanggalMulaiKerjaTetap.TabIndex = 11
        Me.lblTanggalMulaiKerjaTetap.Text = "Tanggal Kerja :"
        '
        'dtpTanggalMulaiKerjaTetap
        '
        Me.dtpTanggalMulaiKerjaTetap.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalMulaiKerjaTetap.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalMulaiKerjaTetap.Location = New System.Drawing.Point(88, 4)
        Me.dtpTanggalMulaiKerjaTetap.Name = "dtpTanggalMulaiKerjaTetap"
        Me.dtpTanggalMulaiKerjaTetap.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggalMulaiKerjaTetap.TabIndex = 10
        '
        'lblKelompok
        '
        Me.lblKelompok.AutoSize = True
        Me.lblKelompok.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKelompok.Location = New System.Drawing.Point(17, 178)
        Me.lblKelompok.Name = "lblKelompok"
        Me.lblKelompok.Size = New System.Drawing.Size(67, 15)
        Me.lblKelompok.TabIndex = 228
        Me.lblKelompok.Text = "Kelompok :"
        '
        'pnlKelompok
        '
        Me.pnlKelompok.Controls.Add(Me.rbOutsource)
        Me.pnlKelompok.Controls.Add(Me.rbNonStaff)
        Me.pnlKelompok.Controls.Add(Me.rbStaff)
        Me.pnlKelompok.Location = New System.Drawing.Point(90, 175)
        Me.pnlKelompok.Name = "pnlKelompok"
        Me.pnlKelompok.Size = New System.Drawing.Size(277, 25)
        Me.pnlKelompok.TabIndex = 227
        '
        'rbOutsource
        '
        Me.rbOutsource.AutoSize = True
        Me.rbOutsource.Location = New System.Drawing.Point(184, 3)
        Me.rbOutsource.Name = "rbOutsource"
        Me.rbOutsource.Size = New System.Drawing.Size(92, 19)
        Me.rbOutsource.TabIndex = 2
        Me.rbOutsource.Text = "OUTSOURCE"
        Me.rbOutsource.UseVisualStyleBackColor = True
        '
        'rbNonStaff
        '
        Me.rbNonStaff.AutoSize = True
        Me.rbNonStaff.Location = New System.Drawing.Point(85, 3)
        Me.rbNonStaff.Name = "rbNonStaff"
        Me.rbNonStaff.Size = New System.Drawing.Size(86, 19)
        Me.rbNonStaff.TabIndex = 1
        Me.rbNonStaff.Text = "NON STAFF"
        Me.rbNonStaff.UseVisualStyleBackColor = True
        '
        'rbStaff
        '
        Me.rbStaff.AutoSize = True
        Me.rbStaff.Location = New System.Drawing.Point(3, 3)
        Me.rbStaff.Name = "rbStaff"
        Me.rbStaff.Size = New System.Drawing.Size(56, 19)
        Me.rbStaff.TabIndex = 0
        Me.rbStaff.Text = "STAFF"
        Me.rbStaff.UseVisualStyleBackColor = True
        '
        'cboLokasi
        '
        Me.cboLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasi.FormattingEnabled = True
        Me.cboLokasi.IntegralHeight = False
        Me.cboLokasi.Location = New System.Drawing.Point(393, 42)
        Me.cboLokasi.Name = "cboLokasi"
        Me.cboLokasi.Size = New System.Drawing.Size(155, 23)
        Me.cboLokasi.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(479, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 15)
        Me.Label5.TabIndex = 226
        Me.Label5.Text = "*"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(635, 152)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 17
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Location = New System.Drawing.Point(341, 45)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(46, 15)
        Me.lblLokasi.TabIndex = 225
        Me.lblLokasi.Text = "Lokasi :"
        '
        'lblFPID
        '
        Me.lblFPID.AutoSize = True
        Me.lblFPID.Location = New System.Drawing.Point(571, 21)
        Me.lblFPID.Name = "lblFPID"
        Me.lblFPID.Size = New System.Drawing.Size(37, 15)
        Me.lblFPID.TabIndex = 223
        Me.lblFPID.Text = "FPID :"
        '
        'tbFPID
        '
        Me.tbFPID.Location = New System.Drawing.Point(614, 18)
        Me.tbFPID.Name = "tbFPID"
        Me.tbFPID.Size = New System.Drawing.Size(80, 23)
        Me.tbFPID.TabIndex = 2
        Me.tbFPID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHari
        '
        Me.lblHari.AutoSize = True
        Me.lblHari.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHari.Location = New System.Drawing.Point(394, 150)
        Me.lblHari.Name = "lblHari"
        Me.lblHari.Size = New System.Drawing.Size(29, 15)
        Me.lblHari.TabIndex = 221
        Me.lblHari.Text = "Hari"
        '
        'lblResetSP
        '
        Me.lblResetSP.AutoSize = True
        Me.lblResetSP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblResetSP.Location = New System.Drawing.Point(275, 150)
        Me.lblResetSP.Name = "lblResetSP"
        Me.lblResetSP.Size = New System.Drawing.Size(57, 15)
        Me.lblResetSP.TabIndex = 220
        Me.lblResetSP.Text = "Reset SP :"
        '
        'tbResetSP
        '
        Me.tbResetSP.Location = New System.Drawing.Point(338, 147)
        Me.tbResetSP.Name = "tbResetSP"
        Me.tbResetSP.Size = New System.Drawing.Size(50, 23)
        Me.tbResetSP.TabIndex = 11
        Me.tbResetSP.Text = "180"
        Me.tbResetSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblKatGaji
        '
        Me.lblKatGaji.AutoSize = True
        Me.lblKatGaji.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKatGaji.Location = New System.Drawing.Point(31, 152)
        Me.lblKatGaji.Name = "lblKatGaji"
        Me.lblKatGaji.Size = New System.Drawing.Size(53, 15)
        Me.lblKatGaji.TabIndex = 218
        Me.lblKatGaji.Text = "Kat Gaji :"
        '
        'pnlKatGaji
        '
        Me.pnlKatGaji.Controls.Add(Me.rbBulanan)
        Me.pnlKatGaji.Controls.Add(Me.rbMingguan)
        Me.pnlKatGaji.Location = New System.Drawing.Point(90, 147)
        Me.pnlKatGaji.Name = "pnlKatGaji"
        Me.pnlKatGaji.Size = New System.Drawing.Size(179, 25)
        Me.pnlKatGaji.TabIndex = 217
        '
        'rbBulanan
        '
        Me.rbBulanan.AutoSize = True
        Me.rbBulanan.Location = New System.Drawing.Point(98, 3)
        Me.rbBulanan.Name = "rbBulanan"
        Me.rbBulanan.Size = New System.Drawing.Size(80, 19)
        Me.rbBulanan.TabIndex = 1
        Me.rbBulanan.Text = "BULANAN"
        Me.rbBulanan.UseVisualStyleBackColor = True
        '
        'rbMingguan
        '
        Me.rbMingguan.AutoSize = True
        Me.rbMingguan.Location = New System.Drawing.Point(3, 3)
        Me.rbMingguan.Name = "rbMingguan"
        Me.rbMingguan.Size = New System.Drawing.Size(89, 19)
        Me.rbMingguan.TabIndex = 0
        Me.rbMingguan.Text = "MINGGUAN"
        Me.rbMingguan.UseVisualStyleBackColor = True
        '
        'lblInfoNIPKosong
        '
        Me.lblInfoNIPKosong.AutoSize = True
        Me.lblInfoNIPKosong.ForeColor = System.Drawing.Color.Red
        Me.lblInfoNIPKosong.Location = New System.Drawing.Point(335, 125)
        Me.lblInfoNIPKosong.Name = "lblInfoNIPKosong"
        Me.lblInfoNIPKosong.Size = New System.Drawing.Size(214, 15)
        Me.lblInfoNIPKosong.TabIndex = 216
        Me.lblInfoNIPKosong.Text = "NIP auto generate berdasar perusahaan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(317, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 215
        Me.Label4.Text = "*"
        '
        'lblNIP
        '
        Me.lblNIP.AutoSize = True
        Me.lblNIP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNIP.Location = New System.Drawing.Point(52, 125)
        Me.lblNIP.Name = "lblNIP"
        Me.lblNIP.Size = New System.Drawing.Size(32, 15)
        Me.lblNIP.TabIndex = 214
        Me.lblNIP.Text = "NIP :"
        '
        'tbNIP
        '
        Me.tbNIP.Location = New System.Drawing.Point(90, 122)
        Me.tbNIP.Name = "tbNIP"
        Me.tbNIP.ReadOnly = True
        Me.tbNIP.Size = New System.Drawing.Size(221, 23)
        Me.tbNIP.TabIndex = 213
        '
        'pnlPeriodeKontrak
        '
        Me.pnlPeriodeKontrak.Controls.Add(Me.dtpTanggalSelesaiKontrak)
        Me.pnlPeriodeKontrak.Controls.Add(Me.lblSD)
        Me.pnlPeriodeKontrak.Controls.Add(Me.lblDari)
        Me.pnlPeriodeKontrak.Controls.Add(Me.dtpTanggalMulaiKontrak)
        Me.pnlPeriodeKontrak.Controls.Add(Me.lblKontrakKe)
        Me.pnlPeriodeKontrak.Controls.Add(Me.tbKontrakKe)
        Me.pnlPeriodeKontrak.Location = New System.Drawing.Point(221, 90)
        Me.pnlPeriodeKontrak.Name = "pnlPeriodeKontrak"
        Me.pnlPeriodeKontrak.Size = New System.Drawing.Size(473, 30)
        Me.pnlPeriodeKontrak.TabIndex = 210
        '
        'dtpTanggalSelesaiKontrak
        '
        Me.dtpTanggalSelesaiKontrak.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalSelesaiKontrak.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalSelesaiKontrak.Location = New System.Drawing.Point(349, 4)
        Me.dtpTanggalSelesaiKontrak.Name = "dtpTanggalSelesaiKontrak"
        Me.dtpTanggalSelesaiKontrak.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggalSelesaiKontrak.TabIndex = 10
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSD.Location = New System.Drawing.Point(321, 8)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(22, 15)
        Me.lblSD.TabIndex = 215
        Me.lblSD.Text = "s.d"
        '
        'lblDari
        '
        Me.lblDari.AutoSize = True
        Me.lblDari.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDari.Location = New System.Drawing.Point(155, 10)
        Me.lblDari.Name = "lblDari"
        Me.lblDari.Size = New System.Drawing.Size(34, 15)
        Me.lblDari.TabIndex = 214
        Me.lblDari.Text = "Dari :"
        '
        'dtpTanggalMulaiKontrak
        '
        Me.dtpTanggalMulaiKontrak.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalMulaiKontrak.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalMulaiKontrak.Location = New System.Drawing.Point(195, 4)
        Me.dtpTanggalMulaiKontrak.Name = "dtpTanggalMulaiKontrak"
        Me.dtpTanggalMulaiKontrak.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggalMulaiKontrak.TabIndex = 9
        '
        'lblKontrakKe
        '
        Me.lblKontrakKe.AutoSize = True
        Me.lblKontrakKe.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKontrakKe.Location = New System.Drawing.Point(3, 8)
        Me.lblKontrakKe.Name = "lblKontrakKe"
        Me.lblKontrakKe.Size = New System.Drawing.Size(70, 15)
        Me.lblKontrakKe.TabIndex = 212
        Me.lblKontrakKe.Text = "Kontrak Ke :"
        '
        'tbKontrakKe
        '
        Me.tbKontrakKe.Location = New System.Drawing.Point(79, 4)
        Me.tbKontrakKe.Name = "tbKontrakKe"
        Me.tbKontrakKe.ReadOnly = True
        Me.tbKontrakKe.Size = New System.Drawing.Size(67, 23)
        Me.tbKontrakKe.TabIndex = 211
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(526, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 208
        Me.Label2.Text = "*"
        '
        'cboStatusPegawai
        '
        Me.cboStatusPegawai.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatusPegawai.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatusPegawai.FormattingEnabled = True
        Me.cboStatusPegawai.IntegralHeight = False
        Me.cboStatusPegawai.Location = New System.Drawing.Point(90, 90)
        Me.cboStatusPegawai.Name = "cboStatusPegawai"
        Me.cboStatusPegawai.Size = New System.Drawing.Size(107, 23)
        Me.cboStatusPegawai.TabIndex = 8
        '
        'lblStatusPegawai
        '
        Me.lblStatusPegawai.AutoSize = True
        Me.lblStatusPegawai.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatusPegawai.Location = New System.Drawing.Point(39, 93)
        Me.lblStatusPegawai.Name = "lblStatusPegawai"
        Me.lblStatusPegawai.Size = New System.Drawing.Size(45, 15)
        Me.lblStatusPegawai.TabIndex = 206
        Me.lblStatusPegawai.Text = "Status :"
        '
        'cboBagian
        '
        Me.cboBagian.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBagian.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBagian.FormattingEnabled = True
        Me.cboBagian.IntegralHeight = False
        Me.cboBagian.Location = New System.Drawing.Point(522, 66)
        Me.cboBagian.Name = "cboBagian"
        Me.cboBagian.Size = New System.Drawing.Size(341, 23)
        Me.cboBagian.TabIndex = 7
        '
        'lblBagian
        '
        Me.lblBagian.AutoSize = True
        Me.lblBagian.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBagian.Location = New System.Drawing.Point(467, 69)
        Me.lblBagian.Name = "lblBagian"
        Me.lblBagian.Size = New System.Drawing.Size(49, 15)
        Me.lblBagian.TabIndex = 204
        Me.lblBagian.Text = "Bagian :"
        '
        'cboDivisi
        '
        Me.cboDivisi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisi.FormattingEnabled = True
        Me.cboDivisi.IntegralHeight = False
        Me.cboDivisi.Location = New System.Drawing.Point(299, 66)
        Me.cboDivisi.Name = "cboDivisi"
        Me.cboDivisi.Size = New System.Drawing.Size(144, 23)
        Me.cboDivisi.TabIndex = 6
        '
        'lblDivisi
        '
        Me.lblDivisi.AutoSize = True
        Me.lblDivisi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDivisi.Location = New System.Drawing.Point(252, 69)
        Me.lblDivisi.Name = "lblDivisi"
        Me.lblDivisi.Size = New System.Drawing.Size(41, 15)
        Me.lblDivisi.TabIndex = 202
        Me.lblDivisi.Text = "Divisi :"
        '
        'cboDepartemen
        '
        Me.cboDepartemen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDepartemen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDepartemen.FormattingEnabled = True
        Me.cboDepartemen.IntegralHeight = False
        Me.cboDepartemen.Location = New System.Drawing.Point(90, 66)
        Me.cboDepartemen.Name = "cboDepartemen"
        Me.cboDepartemen.Size = New System.Drawing.Size(144, 23)
        Me.cboDepartemen.TabIndex = 5
        '
        'lblDepartemen
        '
        Me.lblDepartemen.AutoSize = True
        Me.lblDepartemen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartemen.Location = New System.Drawing.Point(6, 69)
        Me.lblDepartemen.Name = "lblDepartemen"
        Me.lblDepartemen.Size = New System.Drawing.Size(78, 15)
        Me.lblDepartemen.TabIndex = 200
        Me.lblDepartemen.Text = "Departemen :"
        '
        'cboPerusahaan
        '
        Me.cboPerusahaan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPerusahaan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPerusahaan.FormattingEnabled = True
        Me.cboPerusahaan.IntegralHeight = False
        Me.cboPerusahaan.Location = New System.Drawing.Point(90, 42)
        Me.cboPerusahaan.Name = "cboPerusahaan"
        Me.cboPerusahaan.Size = New System.Drawing.Size(218, 23)
        Me.cboPerusahaan.TabIndex = 3
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPerusahaan.Location = New System.Drawing.Point(10, 45)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaan.TabIndex = 198
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(323, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 197
        Me.Label1.Text = "*"
        '
        'cboKaryawan
        '
        Me.cboKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.IntegralHeight = False
        Me.cboKaryawan.Location = New System.Drawing.Point(90, 18)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(421, 23)
        Me.cboKaryawan.TabIndex = 1
        '
        'lblEditingWarning
        '
        Me.lblEditingWarning.AutoSize = True
        Me.lblEditingWarning.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblEditingWarning.ForeColor = System.Drawing.Color.Red
        Me.lblEditingWarning.Location = New System.Drawing.Point(87, 0)
        Me.lblEditingWarning.Name = "lblEditingWarning"
        Me.lblEditingWarning.Size = New System.Drawing.Size(415, 15)
        Me.lblEditingWarning.TabIndex = 12
        Me.lblEditingWarning.Text = "WARNING!! EDITING DATA TIDAK MENYIMPAN DATA LAMA KE HISTORY!"
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKaryawan.Location = New System.Drawing.Point(20, 21)
        Me.lblKaryawan.Name = "lblKaryawan"
        Me.lblKaryawan.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawan.TabIndex = 11
        Me.lblKaryawan.Text = "Karyawan :"
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(761, 152)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 12
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(1142, 183)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 13
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(905, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 193
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(1162, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 192
        '
        'btnProsesImport
        '
        Me.btnProsesImport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnProsesImport.Image = CType(resources.GetObject("btnProsesImport.Image"), System.Drawing.Image)
        Me.btnProsesImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProsesImport.Location = New System.Drawing.Point(104, 65)
        Me.btnProsesImport.Name = "btnProsesImport"
        Me.btnProsesImport.Size = New System.Drawing.Size(120, 54)
        Me.btnProsesImport.TabIndex = 15
        Me.btnProsesImport.Text = "IMPORT"
        Me.btnProsesImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesImport.UseVisualStyleBackColor = True
        '
        'gbImportExcel
        '
        Me.gbImportExcel.Controls.Add(Me.tbNamaFile)
        Me.gbImportExcel.Controls.Add(Me.btnProsesImport)
        Me.gbImportExcel.Controls.Add(Me.lblNamaFile)
        Me.gbImportExcel.Controls.Add(Me.btnBrowse)
        Me.gbImportExcel.Controls.Add(Me.lblNamaSheet)
        Me.gbImportExcel.Controls.Add(Me.tbNamaSheet)
        Me.gbImportExcel.Location = New System.Drawing.Point(1019, 57)
        Me.gbImportExcel.Name = "gbImportExcel"
        Me.gbImportExcel.Size = New System.Drawing.Size(134, 36)
        Me.gbImportExcel.TabIndex = 194
        Me.gbImportExcel.TabStop = False
        Me.gbImportExcel.Text = "IMPORT EXCEL"
        Me.gbImportExcel.Visible = False
        '
        'tbNamaFile
        '
        Me.tbNamaFile.Location = New System.Drawing.Point(104, 13)
        Me.tbNamaFile.Name = "tbNamaFile"
        Me.tbNamaFile.Size = New System.Drawing.Size(205, 20)
        Me.tbNamaFile.TabIndex = 104
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
        Me.btnBrowse.Location = New System.Drawing.Point(312, 11)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 23)
        Me.btnBrowse.TabIndex = 105
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
        Me.tbNamaSheet.Size = New System.Drawing.Size(137, 20)
        Me.tbNamaSheet.TabIndex = 106
        Me.tbNamaSheet.Text = "Sheet1"
        '
        'pnlCetak
        '
        Me.pnlCetak.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCetak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCetak.Controls.Add(Me.Button1)
        Me.pnlCetak.Controls.Add(Me.btnExportExcel)
        Me.pnlCetak.Controls.Add(Me.tbNamaSimpan)
        Me.pnlCetak.Controls.Add(Me.tbPathSimpan)
        Me.pnlCetak.Controls.Add(Me.lblNamaSimpan)
        Me.pnlCetak.Controls.Add(Me.lblSimpanKeDrive)
        Me.pnlCetak.Location = New System.Drawing.Point(12, 619)
        Me.pnlCetak.Name = "pnlCetak"
        Me.pnlCetak.Size = New System.Drawing.Size(1250, 62)
        Me.pnlCetak.TabIndex = 196
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(444, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 16
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.tbNamaSimpan.Size = New System.Drawing.Size(360, 20)
        Me.tbNamaSimpan.TabIndex = 17
        '
        'tbPathSimpan
        '
        Me.tbPathSimpan.Location = New System.Drawing.Point(107, 3)
        Me.tbPathSimpan.Name = "tbPathSimpan"
        Me.tbPathSimpan.Size = New System.Drawing.Size(333, 20)
        Me.tbPathSimpan.TabIndex = 15
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(198, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 15)
        Me.Label9.TabIndex = 230
        Me.Label9.Text = "*"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(449, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 15)
        Me.Label10.TabIndex = 231
        Me.Label10.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(869, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 15)
        Me.Label11.TabIndex = 232
        Me.Label11.Text = "*"
        '
        'FormMasterKaryawanAktif
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1274, 686)
        Me.Controls.Add(Me.pnlCetak)
        Me.Controls.Add(Me.gbImportExcel)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnKeluar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMasterKaryawanAktif"
        Me.Text = "FORM MASTER KARYAWAN AKTIF"
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlPilihanData.ResumeLayout(False)
        Me.pnlPilihanData.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.pnlTanggalMulaiKerjaTetap.ResumeLayout(False)
        Me.pnlTanggalMulaiKerjaTetap.PerformLayout()
        Me.pnlKelompok.ResumeLayout(False)
        Me.pnlKelompok.PerformLayout()
        Me.pnlKatGaji.ResumeLayout(False)
        Me.pnlKatGaji.PerformLayout()
        Me.pnlPeriodeKontrak.ResumeLayout(False)
        Me.pnlPeriodeKontrak.PerformLayout()
        Me.gbImportExcel.ResumeLayout(False)
        Me.gbImportExcel.PerformLayout()
        Me.pnlCetak.ResumeLayout(False)
        Me.pnlCetak.PerformLayout()
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
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents lblEditingWarning As Label
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboPerusahaan As ComboBox
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents cboDepartemen As ComboBox
    Friend WithEvents lblDepartemen As Label
    Friend WithEvents cboDivisi As ComboBox
    Friend WithEvents lblDivisi As Label
    Friend WithEvents cboBagian As ComboBox
    Friend WithEvents lblBagian As Label
    Friend WithEvents cboStatusPegawai As ComboBox
    Friend WithEvents lblStatusPegawai As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlPeriodeKontrak As Panel
    Friend WithEvents lblKontrakKe As Label
    Friend WithEvents tbKontrakKe As TextBox
    Friend WithEvents lblDari As Label
    Friend WithEvents dtpTanggalMulaiKontrak As DateTimePicker
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpTanggalSelesaiKontrak As DateTimePicker
    Friend WithEvents lblNIP As Label
    Friend WithEvents tbNIP As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblInfoNIPKosong As Label
    Friend WithEvents pnlKatGaji As Panel
    Friend WithEvents rbBulanan As RadioButton
    Friend WithEvents rbMingguan As RadioButton
    Friend WithEvents lblKatGaji As Label
    Friend WithEvents lblResetSP As Label
    Friend WithEvents tbResetSP As TextBox
    Friend WithEvents lblHari As Label
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents btnProsesImport As Button
    Friend WithEvents gbImportExcel As GroupBox
    Friend WithEvents tbNamaFile As TextBox
    Friend WithEvents lblNamaFile As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents lblNamaSheet As Label
    Friend WithEvents tbNamaSheet As TextBox
    Friend WithEvents ofd1 As OpenFileDialog
    Friend WithEvents lblFPID As Label
    Friend WithEvents tbFPID As TextBox
    Friend WithEvents lblLokasi As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboLokasi As ComboBox
    Friend WithEvents lblKelompok As Label
    Friend WithEvents pnlKelompok As Panel
    Friend WithEvents rbNonStaff As RadioButton
    Friend WithEvents rbStaff As RadioButton
    Friend WithEvents rbOutsource As RadioButton
    Friend WithEvents pnlTanggalMulaiKerjaTetap As Panel
    Friend WithEvents dtpTanggalMulaiKerjaTetap As DateTimePicker
    Friend WithEvents lblTanggalMulaiKerjaTetap As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cboFilterDepartemen As ComboBox
    Friend WithEvents cboKelompok As ComboBox
    Friend WithEvents cboFilterPerusahaan As ComboBox
    Friend WithEvents lblSorting As Label
    Friend WithEvents cboSortingType As ComboBox
    Friend WithEvents cboSortingCriteria As ComboBox
    Friend WithEvents pnlCetak As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents tbNamaSimpan As TextBox
    Friend WithEvents tbPathSimpan As TextBox
    Friend WithEvents lblNamaSimpan As Label
    Friend WithEvents lblSimpanKeDrive As Label
    Friend WithEvents fbdExport As FolderBrowserDialog
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
End Class
