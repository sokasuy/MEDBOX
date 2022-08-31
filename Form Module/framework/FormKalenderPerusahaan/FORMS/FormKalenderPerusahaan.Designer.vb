<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKalenderPerusahaan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKalenderPerusahaan))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.pnlKategoriLibur = New System.Windows.Forms.Panel()
        Me.rbCutiBersama = New System.Windows.Forms.RadioButton()
        Me.rbLiburNasional = New System.Windows.Forms.RadioButton()
        Me.cboLokasi = New System.Windows.Forms.ComboBox()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.lblKeterangan = New System.Windows.Forms.Label()
        Me.rtbKeterangan = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbLibur = New System.Windows.Forms.CheckBox()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.pnlTanggal = New System.Windows.Forms.Panel()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.dtpAkhir = New System.Windows.Forms.DateTimePicker()
        Me.dtpAwal = New System.Windows.Forms.DateTimePicker()
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
        Me.lblSorting = New System.Windows.Forms.Label()
        Me.cboSortingType = New System.Windows.Forms.ComboBox()
        Me.cboSortingCriteria = New System.Windows.Forms.ComboBox()
        Me.gbDataEntry.SuspendLayout()
        Me.pnlKategoriLibur.SuspendLayout()
        Me.gbView.SuspendLayout()
        Me.pnlTanggal.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(884, 29)
        Me.lblTitle.TabIndex = 177
        Me.lblTitle.Text = "KALENDER PERUSAHAAN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.pnlKategoriLibur)
        Me.gbDataEntry.Controls.Add(Me.cboLokasi)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.lblLokasi)
        Me.gbDataEntry.Controls.Add(Me.lblKeterangan)
        Me.gbDataEntry.Controls.Add(Me.rtbKeterangan)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.cbLibur)
        Me.gbDataEntry.Controls.Add(Me.lblTanggal)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggal)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 32)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(600, 226)
        Me.gbDataEntry.TabIndex = 193
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'pnlKategoriLibur
        '
        Me.pnlKategoriLibur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlKategoriLibur.Controls.Add(Me.rbCutiBersama)
        Me.pnlKategoriLibur.Controls.Add(Me.rbLiburNasional)
        Me.pnlKategoriLibur.Location = New System.Drawing.Point(301, 20)
        Me.pnlKategoriLibur.Name = "pnlKategoriLibur"
        Me.pnlKategoriLibur.Size = New System.Drawing.Size(250, 26)
        Me.pnlKategoriLibur.TabIndex = 232
        '
        'rbCutiBersama
        '
        Me.rbCutiBersama.AutoSize = True
        Me.rbCutiBersama.Location = New System.Drawing.Point(137, 2)
        Me.rbCutiBersama.Name = "rbCutiBersama"
        Me.rbCutiBersama.Size = New System.Drawing.Size(106, 19)
        Me.rbCutiBersama.TabIndex = 1
        Me.rbCutiBersama.TabStop = True
        Me.rbCutiBersama.Text = "CUTI BERSAMA"
        Me.rbCutiBersama.UseVisualStyleBackColor = True
        '
        'rbLiburNasional
        '
        Me.rbLiburNasional.AutoSize = True
        Me.rbLiburNasional.Location = New System.Drawing.Point(3, 2)
        Me.rbLiburNasional.Name = "rbLiburNasional"
        Me.rbLiburNasional.Size = New System.Drawing.Size(117, 19)
        Me.rbLiburNasional.TabIndex = 0
        Me.rbLiburNasional.TabStop = True
        Me.rbLiburNasional.Text = "LIBUR NASIONAL"
        Me.rbLiburNasional.UseVisualStyleBackColor = True
        '
        'cboLokasi
        '
        Me.cboLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasi.FormattingEnabled = True
        Me.cboLokasi.IntegralHeight = False
        Me.cboLokasi.Location = New System.Drawing.Point(94, 46)
        Me.cboLokasi.Name = "cboLokasi"
        Me.cboLokasi.Size = New System.Drawing.Size(155, 23)
        Me.cboLokasi.TabIndex = 2
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(348, 166)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 8
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(255, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 231
        Me.Label2.Text = "*"
        '
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLokasi.Location = New System.Drawing.Point(42, 49)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(46, 15)
        Me.lblLokasi.TabIndex = 230
        Me.lblLokasi.Text = "Lokasi :"
        '
        'lblKeterangan
        '
        Me.lblKeterangan.AutoSize = True
        Me.lblKeterangan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKeterangan.Location = New System.Drawing.Point(15, 73)
        Me.lblKeterangan.Name = "lblKeterangan"
        Me.lblKeterangan.Size = New System.Drawing.Size(73, 15)
        Me.lblKeterangan.TabIndex = 228
        Me.lblKeterangan.Text = "Keterangan :"
        '
        'rtbKeterangan
        '
        Me.rtbKeterangan.Location = New System.Drawing.Point(94, 70)
        Me.rtbKeterangan.Name = "rtbKeterangan"
        Me.rtbKeterangan.Size = New System.Drawing.Size(500, 88)
        Me.rtbKeterangan.TabIndex = 3
        Me.rtbKeterangan.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(220, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 226
        Me.Label1.Text = "*"
        '
        'cbLibur
        '
        Me.cbLibur.AutoSize = True
        Me.cbLibur.Checked = True
        Me.cbLibur.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbLibur.Location = New System.Drawing.Point(238, 27)
        Me.cbLibur.Name = "cbLibur"
        Me.cbLibur.Size = New System.Drawing.Size(57, 19)
        Me.cbLibur.TabIndex = 2
        Me.cbLibur.TabStop = False
        Me.cbLibur.Text = "LIBUR"
        Me.cbLibur.UseVisualStyleBackColor = True
        '
        'lblTanggal
        '
        Me.lblTanggal.AutoSize = True
        Me.lblTanggal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTanggal.Location = New System.Drawing.Point(34, 28)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(54, 15)
        Me.lblTanggal.TabIndex = 214
        Me.lblTanggal.Text = "Tanggal :"
        '
        'dtpTanggal
        '
        Me.dtpTanggal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggal.Location = New System.Drawing.Point(94, 22)
        Me.dtpTanggal.Name = "dtpTanggal"
        Me.dtpTanggal.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggal.TabIndex = 1
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(474, 166)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 4
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(752, 204)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 5
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(618, 32)
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
        Me.clbUserRight.Location = New System.Drawing.Point(772, 32)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 199
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.lblSorting)
        Me.gbView.Controls.Add(Me.cboSortingType)
        Me.gbView.Controls.Add(Me.cboSortingCriteria)
        Me.gbView.Controls.Add(Me.pnlTanggal)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 264)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(860, 368)
        Me.gbView.TabIndex = 201
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'pnlTanggal
        '
        Me.pnlTanggal.Controls.Add(Me.lblSD)
        Me.pnlTanggal.Controls.Add(Me.dtpAkhir)
        Me.pnlTanggal.Controls.Add(Me.dtpAwal)
        Me.pnlTanggal.Location = New System.Drawing.Point(184, 25)
        Me.pnlTanggal.Name = "pnlTanggal"
        Me.pnlTanggal.Size = New System.Drawing.Size(285, 30)
        Me.pnlTanggal.TabIndex = 202
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(129, 12)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(22, 15)
        Me.lblSD.TabIndex = 5
        Me.lblSD.Text = "s.d"
        '
        'dtpAkhir
        '
        Me.dtpAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAkhir.Location = New System.Drawing.Point(156, 6)
        Me.dtpAkhir.Name = "dtpAkhir"
        Me.dtpAkhir.Size = New System.Drawing.Size(120, 23)
        Me.dtpAkhir.TabIndex = 3
        '
        'dtpAwal
        '
        Me.dtpAwal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAwal.Location = New System.Drawing.Point(3, 6)
        Me.dtpAwal.Name = "dtpAwal"
        Me.dtpAwal.Size = New System.Drawing.Size(120, 23)
        Me.dtpAwal.TabIndex = 2
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
        Me.tbCari.Location = New System.Drawing.Point(184, 29)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(300, 23)
        Me.tbCari.TabIndex = 6
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(734, 12)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 7
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
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
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Location = New System.Drawing.Point(6, 67)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.Size = New System.Drawing.Size(848, 263)
        Me.dgvView.TabIndex = 130
        '
        'lblSorting
        '
        Me.lblSorting.AutoSize = True
        Me.lblSorting.Location = New System.Drawing.Point(487, 13)
        Me.lblSorting.Name = "lblSorting"
        Me.lblSorting.Size = New System.Drawing.Size(51, 15)
        Me.lblSorting.TabIndex = 208
        Me.lblSorting.Text = "Sorting :"
        '
        'cboSortingType
        '
        Me.cboSortingType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSortingType.FormattingEnabled = True
        Me.cboSortingType.Location = New System.Drawing.Point(612, 31)
        Me.cboSortingType.Name = "cboSortingType"
        Me.cboSortingType.Size = New System.Drawing.Size(91, 23)
        Me.cboSortingType.TabIndex = 207
        '
        'cboSortingCriteria
        '
        Me.cboSortingCriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingCriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingCriteria.FormattingEnabled = True
        Me.cboSortingCriteria.IntegralHeight = False
        Me.cboSortingCriteria.Location = New System.Drawing.Point(490, 31)
        Me.cboSortingCriteria.Name = "cboSortingCriteria"
        Me.cboSortingCriteria.Size = New System.Drawing.Size(116, 23)
        Me.cboSortingCriteria.TabIndex = 206
        '
        'FormKalenderPerusahaan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(884, 636)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnKeluar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormKalenderPerusahaan"
        Me.Text = "FORM KALENDER PERUSAHAAN"
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.pnlKategoriLibur.ResumeLayout(False)
        Me.pnlKategoriLibur.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlTanggal.ResumeLayout(False)
        Me.pnlTanggal.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents lblTanggal As Label
    Friend WithEvents dtpTanggal As DateTimePicker
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents cbLibur As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblKeterangan As Label
    Friend WithEvents rtbKeterangan As RichTextBox
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
    Friend WithEvents pnlTanggal As Panel
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpAkhir As DateTimePicker
    Friend WithEvents dtpAwal As DateTimePicker
    Friend WithEvents cboLokasi As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblLokasi As Label
    Friend WithEvents pnlKategoriLibur As Panel
    Friend WithEvents rbLiburNasional As RadioButton
    Friend WithEvents rbCutiBersama As RadioButton
    Friend WithEvents lblSorting As Label
    Friend WithEvents cboSortingType As ComboBox
    Friend WithEvents cboSortingCriteria As ComboBox
End Class
