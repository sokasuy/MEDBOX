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
        Me.lblPilihanData = New System.Windows.Forms.Label()
        Me.pnlPilihanData = New System.Windows.Forms.Panel()
        Me.rbHistory = New System.Windows.Forms.RadioButton()
        Me.rbAktif = New System.Windows.Forms.RadioButton()
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
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.lblHariResetSP = New System.Windows.Forms.Label()
        Me.tbResetSP = New System.Windows.Forms.TextBox()
        Me.lblResetSP = New System.Windows.Forms.Label()
        Me.lblEditingWarning = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblInfoNIPKosong = New System.Windows.Forms.Label()
        Me.pnlKatGaji = New System.Windows.Forms.Panel()
        Me.rbHarian = New System.Windows.Forms.RadioButton()
        Me.rbBulanan = New System.Windows.Forms.RadioButton()
        Me.pnlPeriodeKontrak = New System.Windows.Forms.Panel()
        Me.lblDari = New System.Windows.Forms.Label()
        Me.tbKontrakKe = New System.Windows.Forms.TextBox()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.dtpTanggalSelesaiKontrak = New System.Windows.Forms.DateTimePicker()
        Me.dtpTanggalMulaiKontrak = New System.Windows.Forms.DateTimePicker()
        Me.lblKontrak = New System.Windows.Forms.Label()
        Me.lblKatPenggajian = New System.Windows.Forms.Label()
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
        Me.tbNIP = New System.Windows.Forms.TextBox()
        Me.lblNIP = New System.Windows.Forms.Label()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.gbView.SuspendLayout()
        Me.pnlPilihanData.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDataEntry.SuspendLayout()
        Me.pnlKatGaji.SuspendLayout()
        Me.pnlPeriodeKontrak.SuspendLayout()
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
        Me.lblTitle.TabIndex = 14
        Me.lblTitle.Text = "MASTER KARYAWAN AKTIF"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.lblPilihanData)
        Me.gbView.Controls.Add(Me.pnlPilihanData)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.lblKriteria)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 246)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(960, 367)
        Me.gbView.TabIndex = 35
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'lblPilihanData
        '
        Me.lblPilihanData.AutoSize = True
        Me.lblPilihanData.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblPilihanData.ForeColor = System.Drawing.Color.Blue
        Me.lblPilihanData.Location = New System.Drawing.Point(43, -3)
        Me.lblPilihanData.Name = "lblPilihanData"
        Me.lblPilihanData.Size = New System.Drawing.Size(98, 21)
        Me.lblPilihanData.TabIndex = 54
        Me.lblPilihanData.Text = "DATA AKTIF"
        '
        'pnlPilihanData
        '
        Me.pnlPilihanData.Controls.Add(Me.rbHistory)
        Me.pnlPilihanData.Controls.Add(Me.rbAktif)
        Me.pnlPilihanData.Location = New System.Drawing.Point(535, 25)
        Me.pnlPilihanData.Name = "pnlPilihanData"
        Me.pnlPilihanData.Size = New System.Drawing.Size(141, 25)
        Me.pnlPilihanData.TabIndex = 53
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
        Me.btnTampilkan.Location = New System.Drawing.Point(682, 10)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 14
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(190, 27)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(339, 23)
        Me.tbCari.TabIndex = 13
        '
        'lblKriteria
        '
        Me.lblKriteria.AutoSize = True
        Me.lblKriteria.Location = New System.Drawing.Point(7, 30)
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
        Me.cboKriteria.Location = New System.Drawing.Point(63, 27)
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
        Me.dgvView.Location = New System.Drawing.Point(6, 70)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.RowTemplate.Height = 25
        Me.dgvView.Size = New System.Drawing.Size(948, 255)
        Me.dgvView.TabIndex = 0
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
        Me.clbUserRight.TabIndex = 34
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(718, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 33
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(718, 52)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 15
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.lblHariResetSP)
        Me.gbDataEntry.Controls.Add(Me.tbResetSP)
        Me.gbDataEntry.Controls.Add(Me.lblResetSP)
        Me.gbDataEntry.Controls.Add(Me.lblEditingWarning)
        Me.gbDataEntry.Controls.Add(Me.Label7)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.lblInfoNIPKosong)
        Me.gbDataEntry.Controls.Add(Me.pnlKatGaji)
        Me.gbDataEntry.Controls.Add(Me.pnlPeriodeKontrak)
        Me.gbDataEntry.Controls.Add(Me.lblKatPenggajian)
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
        Me.gbDataEntry.Controls.Add(Me.tbNIP)
        Me.gbDataEntry.Controls.Add(Me.lblNIP)
        Me.gbDataEntry.Controls.Add(Me.cboKaryawan)
        Me.gbDataEntry.Controls.Add(Me.lblKaryawan)
        Me.gbDataEntry.Controls.Add(Me.btnKeluar)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(700, 212)
        Me.gbDataEntry.TabIndex = 32
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'lblHariResetSP
        '
        Me.lblHariResetSP.AutoSize = True
        Me.lblHariResetSP.Location = New System.Drawing.Point(405, 151)
        Me.lblHariResetSP.Name = "lblHariResetSP"
        Me.lblHariResetSP.Size = New System.Drawing.Size(29, 15)
        Me.lblHariResetSP.TabIndex = 61
        Me.lblHariResetSP.Text = "Hari"
        '
        'tbResetSP
        '
        Me.tbResetSP.Location = New System.Drawing.Point(351, 148)
        Me.tbResetSP.Name = "tbResetSP"
        Me.tbResetSP.Size = New System.Drawing.Size(48, 23)
        Me.tbResetSP.TabIndex = 10
        Me.tbResetSP.Text = "180"
        Me.tbResetSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblResetSP
        '
        Me.lblResetSP.AutoSize = True
        Me.lblResetSP.Location = New System.Drawing.Point(288, 151)
        Me.lblResetSP.Name = "lblResetSP"
        Me.lblResetSP.Size = New System.Drawing.Size(57, 15)
        Me.lblResetSP.TabIndex = 59
        Me.lblResetSP.Text = "Reset SP :"
        '
        'lblEditingWarning
        '
        Me.lblEditingWarning.AutoSize = True
        Me.lblEditingWarning.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblEditingWarning.ForeColor = System.Drawing.Color.Red
        Me.lblEditingWarning.Location = New System.Drawing.Point(85, 0)
        Me.lblEditingWarning.Name = "lblEditingWarning"
        Me.lblEditingWarning.Size = New System.Drawing.Size(415, 15)
        Me.lblEditingWarning.TabIndex = 58
        Me.lblEditingWarning.Text = "WARNING!! EDITING DATA TIDAK MENYIMPAN DATA LAMA KE HISTORY!"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(321, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 15)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(219, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(351, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(550, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "*"
        '
        'lblInfoNIPKosong
        '
        Me.lblInfoNIPKosong.AutoSize = True
        Me.lblInfoNIPKosong.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblInfoNIPKosong.ForeColor = System.Drawing.Color.Red
        Me.lblInfoNIPKosong.Location = New System.Drawing.Point(339, 130)
        Me.lblInfoNIPKosong.Name = "lblInfoNIPKosong"
        Me.lblInfoNIPKosong.Size = New System.Drawing.Size(271, 15)
        Me.lblInfoNIPKosong.TabIndex = 52
        Me.lblInfoNIPKosong.Text = "NIP auto generate berdasar perusahaan dan status"
        '
        'pnlKatGaji
        '
        Me.pnlKatGaji.Controls.Add(Me.rbHarian)
        Me.pnlKatGaji.Controls.Add(Me.rbBulanan)
        Me.pnlKatGaji.Location = New System.Drawing.Point(94, 149)
        Me.pnlKatGaji.Name = "pnlKatGaji"
        Me.pnlKatGaji.Size = New System.Drawing.Size(145, 25)
        Me.pnlKatGaji.TabIndex = 51
        '
        'rbHarian
        '
        Me.rbHarian.AutoSize = True
        Me.rbHarian.Checked = True
        Me.rbHarian.Location = New System.Drawing.Point(3, 3)
        Me.rbHarian.Name = "rbHarian"
        Me.rbHarian.Size = New System.Drawing.Size(60, 19)
        Me.rbHarian.TabIndex = 49
        Me.rbHarian.TabStop = True
        Me.rbHarian.Text = "Harian"
        Me.rbHarian.UseVisualStyleBackColor = True
        '
        'rbBulanan
        '
        Me.rbBulanan.AutoSize = True
        Me.rbBulanan.Location = New System.Drawing.Point(69, 3)
        Me.rbBulanan.Name = "rbBulanan"
        Me.rbBulanan.Size = New System.Drawing.Size(68, 19)
        Me.rbBulanan.TabIndex = 50
        Me.rbBulanan.Text = "Bulanan"
        Me.rbBulanan.UseVisualStyleBackColor = True
        '
        'pnlPeriodeKontrak
        '
        Me.pnlPeriodeKontrak.Controls.Add(Me.lblDari)
        Me.pnlPeriodeKontrak.Controls.Add(Me.tbKontrakKe)
        Me.pnlPeriodeKontrak.Controls.Add(Me.lblSD)
        Me.pnlPeriodeKontrak.Controls.Add(Me.dtpTanggalSelesaiKontrak)
        Me.pnlPeriodeKontrak.Controls.Add(Me.dtpTanggalMulaiKontrak)
        Me.pnlPeriodeKontrak.Controls.Add(Me.lblKontrak)
        Me.pnlPeriodeKontrak.Location = New System.Drawing.Point(247, 94)
        Me.pnlPeriodeKontrak.Name = "pnlPeriodeKontrak"
        Me.pnlPeriodeKontrak.Size = New System.Drawing.Size(447, 30)
        Me.pnlPeriodeKontrak.TabIndex = 48
        '
        'lblDari
        '
        Me.lblDari.AutoSize = True
        Me.lblDari.Location = New System.Drawing.Point(132, 9)
        Me.lblDari.Name = "lblDari"
        Me.lblDari.Size = New System.Drawing.Size(34, 15)
        Me.lblDari.TabIndex = 43
        Me.lblDari.Text = "Dari :"
        '
        'tbKontrakKe
        '
        Me.tbKontrakKe.Location = New System.Drawing.Point(79, 3)
        Me.tbKontrakKe.Name = "tbKontrakKe"
        Me.tbKontrakKe.ReadOnly = True
        Me.tbKontrakKe.Size = New System.Drawing.Size(48, 23)
        Me.tbKontrakKe.TabIndex = 42
        Me.tbKontrakKe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(297, 9)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(22, 15)
        Me.lblSD.TabIndex = 41
        Me.lblSD.Text = "s.d"
        '
        'dtpTanggalSelesaiKontrak
        '
        Me.dtpTanggalSelesaiKontrak.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalSelesaiKontrak.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalSelesaiKontrak.Location = New System.Drawing.Point(325, 3)
        Me.dtpTanggalSelesaiKontrak.Name = "dtpTanggalSelesaiKontrak"
        Me.dtpTanggalSelesaiKontrak.Size = New System.Drawing.Size(119, 23)
        Me.dtpTanggalSelesaiKontrak.TabIndex = 8
        '
        'dtpTanggalMulaiKontrak
        '
        Me.dtpTanggalMulaiKontrak.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalMulaiKontrak.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalMulaiKontrak.Location = New System.Drawing.Point(172, 3)
        Me.dtpTanggalMulaiKontrak.Name = "dtpTanggalMulaiKontrak"
        Me.dtpTanggalMulaiKontrak.Size = New System.Drawing.Size(119, 23)
        Me.dtpTanggalMulaiKontrak.TabIndex = 7
        '
        'lblKontrak
        '
        Me.lblKontrak.AutoSize = True
        Me.lblKontrak.Location = New System.Drawing.Point(3, 9)
        Me.lblKontrak.Name = "lblKontrak"
        Me.lblKontrak.Size = New System.Drawing.Size(70, 15)
        Me.lblKontrak.TabIndex = 39
        Me.lblKontrak.Text = "Kontrak Ke :"
        '
        'lblKatPenggajian
        '
        Me.lblKatPenggajian.AutoSize = True
        Me.lblKatPenggajian.Location = New System.Drawing.Point(35, 154)
        Me.lblKatPenggajian.Name = "lblKatPenggajian"
        Me.lblKatPenggajian.Size = New System.Drawing.Size(53, 15)
        Me.lblKatPenggajian.TabIndex = 46
        Me.lblKatPenggajian.Text = "Kat Gaji :"
        '
        'cboStatusPegawai
        '
        Me.cboStatusPegawai.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatusPegawai.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatusPegawai.FormattingEnabled = True
        Me.cboStatusPegawai.IntegralHeight = False
        Me.cboStatusPegawai.Location = New System.Drawing.Point(94, 97)
        Me.cboStatusPegawai.Name = "cboStatusPegawai"
        Me.cboStatusPegawai.Size = New System.Drawing.Size(120, 23)
        Me.cboStatusPegawai.TabIndex = 6
        '
        'lblStatusPegawai
        '
        Me.lblStatusPegawai.AutoSize = True
        Me.lblStatusPegawai.Location = New System.Drawing.Point(43, 100)
        Me.lblStatusPegawai.Name = "lblStatusPegawai"
        Me.lblStatusPegawai.Size = New System.Drawing.Size(45, 15)
        Me.lblStatusPegawai.TabIndex = 44
        Me.lblStatusPegawai.Text = "Status :"
        '
        'cboBagian
        '
        Me.cboBagian.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBagian.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBagian.FormattingEnabled = True
        Me.cboBagian.IntegralHeight = False
        Me.cboBagian.Location = New System.Drawing.Point(508, 70)
        Me.cboBagian.Name = "cboBagian"
        Me.cboBagian.Size = New System.Drawing.Size(186, 23)
        Me.cboBagian.TabIndex = 5
        '
        'lblBagian
        '
        Me.lblBagian.AutoSize = True
        Me.lblBagian.Location = New System.Drawing.Point(453, 73)
        Me.lblBagian.Name = "lblBagian"
        Me.lblBagian.Size = New System.Drawing.Size(49, 15)
        Me.lblBagian.TabIndex = 42
        Me.lblBagian.Text = "Bagian :"
        '
        'cboDivisi
        '
        Me.cboDivisi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisi.FormattingEnabled = True
        Me.cboDivisi.IntegralHeight = False
        Me.cboDivisi.Location = New System.Drawing.Point(315, 70)
        Me.cboDivisi.Name = "cboDivisi"
        Me.cboDivisi.Size = New System.Drawing.Size(132, 23)
        Me.cboDivisi.TabIndex = 4
        '
        'lblDivisi
        '
        Me.lblDivisi.AutoSize = True
        Me.lblDivisi.Location = New System.Drawing.Point(268, 73)
        Me.lblDivisi.Name = "lblDivisi"
        Me.lblDivisi.Size = New System.Drawing.Size(41, 15)
        Me.lblDivisi.TabIndex = 40
        Me.lblDivisi.Text = "Divisi :"
        '
        'cboDepartemen
        '
        Me.cboDepartemen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDepartemen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDepartemen.FormattingEnabled = True
        Me.cboDepartemen.IntegralHeight = False
        Me.cboDepartemen.Location = New System.Drawing.Point(94, 70)
        Me.cboDepartemen.Name = "cboDepartemen"
        Me.cboDepartemen.Size = New System.Drawing.Size(168, 23)
        Me.cboDepartemen.TabIndex = 3
        '
        'lblDepartemen
        '
        Me.lblDepartemen.AutoSize = True
        Me.lblDepartemen.Location = New System.Drawing.Point(10, 73)
        Me.lblDepartemen.Name = "lblDepartemen"
        Me.lblDepartemen.Size = New System.Drawing.Size(78, 15)
        Me.lblDepartemen.TabIndex = 38
        Me.lblDepartemen.Text = "Departemen :"
        '
        'cboPerusahaan
        '
        Me.cboPerusahaan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPerusahaan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPerusahaan.FormattingEnabled = True
        Me.cboPerusahaan.IntegralHeight = False
        Me.cboPerusahaan.Location = New System.Drawing.Point(94, 46)
        Me.cboPerusahaan.Name = "cboPerusahaan"
        Me.cboPerusahaan.Size = New System.Drawing.Size(251, 23)
        Me.cboPerusahaan.TabIndex = 2
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Location = New System.Drawing.Point(14, 49)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaan.TabIndex = 36
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'tbNIP
        '
        Me.tbNIP.Location = New System.Drawing.Point(94, 125)
        Me.tbNIP.Name = "tbNIP"
        Me.tbNIP.ReadOnly = True
        Me.tbNIP.Size = New System.Drawing.Size(221, 23)
        Me.tbNIP.TabIndex = 9
        '
        'lblNIP
        '
        Me.lblNIP.AutoSize = True
        Me.lblNIP.Location = New System.Drawing.Point(56, 130)
        Me.lblNIP.Name = "lblNIP"
        Me.lblNIP.Size = New System.Drawing.Size(32, 15)
        Me.lblNIP.TabIndex = 34
        Me.lblNIP.Text = "NIP :"
        '
        'cboKaryawan
        '
        Me.cboKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.IntegralHeight = False
        Me.cboKaryawan.Location = New System.Drawing.Point(94, 22)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(450, 23)
        Me.cboKaryawan.TabIndex = 1
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Location = New System.Drawing.Point(24, 25)
        Me.lblKaryawan.Name = "lblKaryawan"
        Me.lblKaryawan.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawan.TabIndex = 31
        Me.lblKaryawan.Text = "Karyawan :"
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(574, 154)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 12
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(448, 154)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 11
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'FormMasterKaryawanAktif
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 616)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
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
        Me.pnlKatGaji.ResumeLayout(False)
        Me.pnlKatGaji.PerformLayout()
        Me.pnlPeriodeKontrak.ResumeLayout(False)
        Me.pnlPeriodeKontrak.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
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
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents tbNIP As TextBox
    Friend WithEvents lblNIP As Label
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents cboPerusahaan As ComboBox
    Friend WithEvents cboDepartemen As ComboBox
    Friend WithEvents lblDepartemen As Label
    Friend WithEvents cboDivisi As ComboBox
    Friend WithEvents lblDivisi As Label
    Friend WithEvents cboBagian As ComboBox
    Friend WithEvents lblBagian As Label
    Friend WithEvents cboStatusPegawai As ComboBox
    Friend WithEvents lblStatusPegawai As Label
    Friend WithEvents lblKatPenggajian As Label
    Friend WithEvents pnlPeriodeKontrak As Panel
    Friend WithEvents dtpTanggalMulaiKontrak As DateTimePicker
    Friend WithEvents lblKontrak As Label
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpTanggalSelesaiKontrak As DateTimePicker
    Friend WithEvents rbHarian As RadioButton
    Friend WithEvents rbBulanan As RadioButton
    Friend WithEvents rbHistory As RadioButton
    Friend WithEvents rbAktif As RadioButton
    Friend WithEvents pnlKatGaji As Panel
    Friend WithEvents pnlPilihanData As Panel
    Friend WithEvents lblInfoNIPKosong As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblPilihanData As Label
    Friend WithEvents tbKontrakKe As TextBox
    Friend WithEvents lblDari As Label
    Friend WithEvents lblEditingWarning As Label
    Friend WithEvents tbResetSP As TextBox
    Friend WithEvents lblResetSP As Label
    Friend WithEvents lblHariResetSP As Label
End Class
