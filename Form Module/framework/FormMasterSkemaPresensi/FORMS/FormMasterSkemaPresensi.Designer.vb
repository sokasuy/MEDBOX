<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMasterSkemaPresensi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterSkemaPresensi))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbView = New System.Windows.Forms.GroupBox()
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
        Me.rbSpesifik = New System.Windows.Forms.RadioButton()
        Me.pnlUmum = New System.Windows.Forms.Panel()
        Me.lblDepartemen = New System.Windows.Forms.Label()
        Me.cboDepartemen = New System.Windows.Forms.ComboBox()
        Me.cboGrup = New System.Windows.Forms.ComboBox()
        Me.cboJabatan = New System.Windows.Forms.ComboBox()
        Me.lblJabatan = New System.Windows.Forms.Label()
        Me.cboKetGrup = New System.Windows.Forms.ComboBox()
        Me.pnlSpesifik = New System.Windows.Forms.Panel()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.rbUmum = New System.Windows.Forms.RadioButton()
        Me.pnlWaktuHari = New System.Windows.Forms.Panel()
        Me.rbMalam = New System.Windows.Forms.RadioButton()
        Me.rbSiang = New System.Windows.Forms.RadioButton()
        Me.rbPagi = New System.Windows.Forms.RadioButton()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.lblWaktuShift = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbJamKeluar = New System.Windows.Forms.TextBox()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblKetJamLembur = New System.Windows.Forms.Label()
        Me.tbJamMasuk = New System.Windows.Forms.TextBox()
        Me.lblJam = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblHari = New System.Windows.Forms.Label()
        Me.cboHari = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPerusahaan = New System.Windows.Forms.ComboBox()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.cboLokasi = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbKelompok = New System.Windows.Forms.GroupBox()
        Me.gbView.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDataEntry.SuspendLayout()
        Me.pnlUmum.SuspendLayout()
        Me.pnlSpesifik.SuspendLayout()
        Me.pnlWaktuHari.SuspendLayout()
        Me.gbKelompok.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(979, 25)
        Me.lblTitle.TabIndex = 180
        Me.lblTitle.Text = "MASTER SKEMA PRESENSI"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.gbView.Location = New System.Drawing.Point(12, 295)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(955, 370)
        Me.gbView.TabIndex = 192
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
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
        Me.tbCari.TabIndex = 12
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(570, 11)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 13
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
        Me.dgvView.Size = New System.Drawing.Size(943, 263)
        Me.dgvView.TabIndex = 130
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.gbKelompok)
        Me.gbDataEntry.Controls.Add(Me.pnlWaktuHari)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.lblWaktuShift)
        Me.gbDataEntry.Controls.Add(Me.Label5)
        Me.gbDataEntry.Controls.Add(Me.tbJamKeluar)
        Me.gbDataEntry.Controls.Add(Me.lblSD)
        Me.gbDataEntry.Controls.Add(Me.Label6)
        Me.gbDataEntry.Controls.Add(Me.lblKetJamLembur)
        Me.gbDataEntry.Controls.Add(Me.tbJamMasuk)
        Me.gbDataEntry.Controls.Add(Me.lblJam)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.lblHari)
        Me.gbDataEntry.Controls.Add(Me.cboHari)
        Me.gbDataEntry.Controls.Add(Me.Label4)
        Me.gbDataEntry.Controls.Add(Me.cboPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.lblPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.cboLokasi)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.lblLokasi)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(700, 261)
        Me.gbDataEntry.TabIndex = 193
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'rbSpesifik
        '
        Me.rbSpesifik.AutoSize = True
        Me.rbSpesifik.Location = New System.Drawing.Point(3, 79)
        Me.rbSpesifik.Name = "rbSpesifik"
        Me.rbSpesifik.Size = New System.Drawing.Size(71, 19)
        Me.rbSpesifik.TabIndex = 202
        Me.rbSpesifik.TabStop = True
        Me.rbSpesifik.Text = "Spesifik :"
        Me.rbSpesifik.UseVisualStyleBackColor = True
        '
        'pnlUmum
        '
        Me.pnlUmum.Controls.Add(Me.lblDepartemen)
        Me.pnlUmum.Controls.Add(Me.cboDepartemen)
        Me.pnlUmum.Controls.Add(Me.cboGrup)
        Me.pnlUmum.Controls.Add(Me.cboJabatan)
        Me.pnlUmum.Controls.Add(Me.lblJabatan)
        Me.pnlUmum.Controls.Add(Me.cboKetGrup)
        Me.pnlUmum.Location = New System.Drawing.Point(80, 19)
        Me.pnlUmum.Name = "pnlUmum"
        Me.pnlUmum.Size = New System.Drawing.Size(562, 55)
        Me.pnlUmum.TabIndex = 201
        '
        'lblDepartemen
        '
        Me.lblDepartemen.AutoSize = True
        Me.lblDepartemen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartemen.Location = New System.Drawing.Point(3, 5)
        Me.lblDepartemen.Name = "lblDepartemen"
        Me.lblDepartemen.Size = New System.Drawing.Size(78, 15)
        Me.lblDepartemen.TabIndex = 260
        Me.lblDepartemen.Text = "Departemen :"
        '
        'cboDepartemen
        '
        Me.cboDepartemen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDepartemen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDepartemen.FormattingEnabled = True
        Me.cboDepartemen.IntegralHeight = False
        Me.cboDepartemen.Location = New System.Drawing.Point(87, 2)
        Me.cboDepartemen.Name = "cboDepartemen"
        Me.cboDepartemen.Size = New System.Drawing.Size(198, 23)
        Me.cboDepartemen.TabIndex = 262
        '
        'cboGrup
        '
        Me.cboGrup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGrup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGrup.FormattingEnabled = True
        Me.cboGrup.IntegralHeight = False
        Me.cboGrup.Location = New System.Drawing.Point(3, 29)
        Me.cboGrup.Name = "cboGrup"
        Me.cboGrup.Size = New System.Drawing.Size(78, 23)
        Me.cboGrup.TabIndex = 3
        '
        'cboJabatan
        '
        Me.cboJabatan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboJabatan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboJabatan.FormattingEnabled = True
        Me.cboJabatan.IntegralHeight = False
        Me.cboJabatan.Location = New System.Drawing.Point(371, 29)
        Me.cboJabatan.Name = "cboJabatan"
        Me.cboJabatan.Size = New System.Drawing.Size(155, 23)
        Me.cboJabatan.TabIndex = 5
        '
        'lblJabatan
        '
        Me.lblJabatan.AutoSize = True
        Me.lblJabatan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJabatan.Location = New System.Drawing.Point(312, 32)
        Me.lblJabatan.Name = "lblJabatan"
        Me.lblJabatan.Size = New System.Drawing.Size(53, 15)
        Me.lblJabatan.TabIndex = 261
        Me.lblJabatan.Text = "Jabatan :"
        '
        'cboKetGrup
        '
        Me.cboKetGrup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKetGrup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKetGrup.FormattingEnabled = True
        Me.cboKetGrup.IntegralHeight = False
        Me.cboKetGrup.Location = New System.Drawing.Point(87, 29)
        Me.cboKetGrup.Name = "cboKetGrup"
        Me.cboKetGrup.Size = New System.Drawing.Size(198, 23)
        Me.cboKetGrup.TabIndex = 4
        '
        'pnlSpesifik
        '
        Me.pnlSpesifik.Controls.Add(Me.cboKaryawan)
        Me.pnlSpesifik.Controls.Add(Me.lblKaryawan)
        Me.pnlSpesifik.Location = New System.Drawing.Point(80, 76)
        Me.pnlSpesifik.Name = "pnlSpesifik"
        Me.pnlSpesifik.Size = New System.Drawing.Size(366, 26)
        Me.pnlSpesifik.TabIndex = 201
        '
        'cboKaryawan
        '
        Me.cboKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.IntegralHeight = False
        Me.cboKaryawan.Location = New System.Drawing.Point(75, 2)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(288, 23)
        Me.cboKaryawan.TabIndex = 6
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKaryawan.Location = New System.Drawing.Point(5, 5)
        Me.lblKaryawan.Name = "lblKaryawan"
        Me.lblKaryawan.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawan.TabIndex = 227
        Me.lblKaryawan.Text = "Karyawan :"
        '
        'rbUmum
        '
        Me.rbUmum.AutoSize = True
        Me.rbUmum.Location = New System.Drawing.Point(6, 22)
        Me.rbUmum.Name = "rbUmum"
        Me.rbUmum.Size = New System.Drawing.Size(68, 19)
        Me.rbUmum.TabIndex = 201
        Me.rbUmum.TabStop = True
        Me.rbUmum.Text = "Umum :"
        Me.rbUmum.UseVisualStyleBackColor = True
        '
        'pnlWaktuHari
        '
        Me.pnlWaktuHari.Controls.Add(Me.rbMalam)
        Me.pnlWaktuHari.Controls.Add(Me.rbSiang)
        Me.pnlWaktuHari.Controls.Add(Me.rbPagi)
        Me.pnlWaktuHari.Location = New System.Drawing.Point(86, 201)
        Me.pnlWaktuHari.Name = "pnlWaktuHari"
        Me.pnlWaktuHari.Size = New System.Drawing.Size(202, 25)
        Me.pnlWaktuHari.TabIndex = 259
        '
        'rbMalam
        '
        Me.rbMalam.AutoSize = True
        Me.rbMalam.Location = New System.Drawing.Point(125, 4)
        Me.rbMalam.Name = "rbMalam"
        Me.rbMalam.Size = New System.Drawing.Size(69, 19)
        Me.rbMalam.TabIndex = 2
        Me.rbMalam.Text = "MALAM"
        Me.rbMalam.UseVisualStyleBackColor = True
        '
        'rbSiang
        '
        Me.rbSiang.AutoSize = True
        Me.rbSiang.Location = New System.Drawing.Point(59, 4)
        Me.rbSiang.Name = "rbSiang"
        Me.rbSiang.Size = New System.Drawing.Size(59, 19)
        Me.rbSiang.TabIndex = 1
        Me.rbSiang.Text = "SIANG"
        Me.rbSiang.UseVisualStyleBackColor = True
        '
        'rbPagi
        '
        Me.rbPagi.AutoSize = True
        Me.rbPagi.Location = New System.Drawing.Point(3, 4)
        Me.rbPagi.Name = "rbPagi"
        Me.rbPagi.Size = New System.Drawing.Size(50, 19)
        Me.rbPagi.TabIndex = 0
        Me.rbPagi.Text = "PAGI"
        Me.rbPagi.UseVisualStyleBackColor = True
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(431, 201)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 14
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'lblWaktuShift
        '
        Me.lblWaktuShift.AutoSize = True
        Me.lblWaktuShift.Location = New System.Drawing.Point(6, 207)
        Me.lblWaktuShift.Name = "lblWaktuShift"
        Me.lblWaktuShift.Size = New System.Drawing.Size(74, 15)
        Me.lblWaktuShift.TabIndex = 258
        Me.lblWaktuShift.Text = "Waktu Shift :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(506, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 15)
        Me.Label5.TabIndex = 257
        Me.Label5.Text = "*"
        '
        'tbJamKeluar
        '
        Me.tbJamKeluar.Location = New System.Drawing.Point(409, 177)
        Me.tbJamKeluar.Name = "tbJamKeluar"
        Me.tbJamKeluar.Size = New System.Drawing.Size(91, 23)
        Me.tbJamKeluar.TabIndex = 9
        Me.tbJamKeluar.Text = "17:00"
        Me.tbJamKeluar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSD.Location = New System.Drawing.Point(381, 180)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(22, 15)
        Me.lblSD.TabIndex = 255
        Me.lblSD.Text = "s.d"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(363, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 15)
        Me.Label6.TabIndex = 254
        Me.Label6.Text = "*"
        '
        'lblKetJamLembur
        '
        Me.lblKetJamLembur.AutoSize = True
        Me.lblKetJamLembur.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKetJamLembur.Location = New System.Drawing.Point(524, 180)
        Me.lblKetJamLembur.Name = "lblKetJamLembur"
        Me.lblKetJamLembur.Size = New System.Drawing.Size(84, 15)
        Me.lblKetJamLembur.TabIndex = 253
        Me.lblKetJamLembur.Text = "Format 24 Jam"
        '
        'tbJamMasuk
        '
        Me.tbJamMasuk.Location = New System.Drawing.Point(266, 177)
        Me.tbJamMasuk.Name = "tbJamMasuk"
        Me.tbJamMasuk.Size = New System.Drawing.Size(91, 23)
        Me.tbJamMasuk.TabIndex = 8
        Me.tbJamMasuk.Text = "08:00"
        Me.tbJamMasuk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblJam
        '
        Me.lblJam.AutoSize = True
        Me.lblJam.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJam.Location = New System.Drawing.Point(226, 180)
        Me.lblJam.Name = "lblJam"
        Me.lblJam.Size = New System.Drawing.Size(34, 15)
        Me.lblJam.TabIndex = 252
        Me.lblJam.Text = "Jam :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(199, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 230
        Me.Label3.Text = "*"
        '
        'lblHari
        '
        Me.lblHari.AutoSize = True
        Me.lblHari.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHari.Location = New System.Drawing.Point(45, 179)
        Me.lblHari.Name = "lblHari"
        Me.lblHari.Size = New System.Drawing.Size(35, 15)
        Me.lblHari.TabIndex = 229
        Me.lblHari.Text = "Hari :"
        '
        'cboHari
        '
        Me.cboHari.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHari.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHari.FormattingEnabled = True
        Me.cboHari.IntegralHeight = False
        Me.cboHari.Location = New System.Drawing.Point(86, 176)
        Me.cboHari.Name = "cboHari"
        Me.cboHari.Size = New System.Drawing.Size(107, 23)
        Me.cboHari.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(341, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 224
        Me.Label4.Text = "*"
        '
        'cboPerusahaan
        '
        Me.cboPerusahaan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPerusahaan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPerusahaan.FormattingEnabled = True
        Me.cboPerusahaan.IntegralHeight = False
        Me.cboPerusahaan.Location = New System.Drawing.Point(99, 40)
        Me.cboPerusahaan.Name = "cboPerusahaan"
        Me.cboPerusahaan.Size = New System.Drawing.Size(236, 23)
        Me.cboPerusahaan.TabIndex = 2
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPerusahaan.Location = New System.Drawing.Point(19, 43)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaan.TabIndex = 223
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'cboLokasi
        '
        Me.cboLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasi.FormattingEnabled = True
        Me.cboLokasi.IntegralHeight = False
        Me.cboLokasi.Location = New System.Drawing.Point(99, 16)
        Me.cboLokasi.Name = "cboLokasi"
        Me.cboLokasi.Size = New System.Drawing.Size(155, 23)
        Me.cboLokasi.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(260, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 217
        Me.Label2.Text = "*"
        '
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLokasi.Location = New System.Drawing.Point(47, 19)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(46, 15)
        Me.lblLokasi.TabIndex = 11
        Me.lblLokasi.Text = "Lokasi :"
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(561, 201)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 10
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(852, 229)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 15
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(718, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 200
        Me.lblEntryType.Text = "INSERT NEW"
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
        Me.clbUserRight.TabIndex = 199
        '
        'gbKelompok
        '
        Me.gbKelompok.Controls.Add(Me.rbSpesifik)
        Me.gbKelompok.Controls.Add(Me.pnlUmum)
        Me.gbKelompok.Controls.Add(Me.rbUmum)
        Me.gbKelompok.Controls.Add(Me.pnlSpesifik)
        Me.gbKelompok.Location = New System.Drawing.Point(6, 66)
        Me.gbKelompok.Name = "gbKelompok"
        Me.gbKelompok.Size = New System.Drawing.Size(648, 108)
        Me.gbKelompok.TabIndex = 201
        Me.gbKelompok.TabStop = False
        Me.gbKelompok.Text = "Kelompok"
        '
        'FormMasterSkemaPresensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(979, 671)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnKeluar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMasterSkemaPresensi"
        Me.Text = "FORM MASTER SKEMA PRESENSI"
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.pnlUmum.ResumeLayout(False)
        Me.pnlUmum.PerformLayout()
        Me.pnlSpesifik.ResumeLayout(False)
        Me.pnlSpesifik.PerformLayout()
        Me.pnlWaktuHari.ResumeLayout(False)
        Me.pnlWaktuHari.PerformLayout()
        Me.gbKelompok.ResumeLayout(False)
        Me.gbKelompok.PerformLayout()
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
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboKetGrup As ComboBox
    Friend WithEvents lblLokasi As Label
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents cboLokasi As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboPerusahaan As ComboBox
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents lblHari As Label
    Friend WithEvents cboHari As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblKetJamLembur As Label
    Friend WithEvents tbJamMasuk As TextBox
    Friend WithEvents lblJam As Label
    Friend WithEvents lblSD As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tbJamKeluar As TextBox
    Friend WithEvents lblWaktuShift As Label
    Friend WithEvents pnlWaktuHari As Panel
    Friend WithEvents rbMalam As RadioButton
    Friend WithEvents rbSiang As RadioButton
    Friend WithEvents rbPagi As RadioButton
    Friend WithEvents cboJabatan As ComboBox
    Friend WithEvents lblJabatan As Label
    Friend WithEvents cboGrup As ComboBox
    Friend WithEvents rbUmum As RadioButton
    Friend WithEvents rbSpesifik As RadioButton
    Friend WithEvents pnlSpesifik As Panel
    Friend WithEvents pnlUmum As Panel
    Friend WithEvents lblDepartemen As Label
    Friend WithEvents cboDepartemen As ComboBox
    Friend WithEvents gbKelompok As GroupBox
End Class
