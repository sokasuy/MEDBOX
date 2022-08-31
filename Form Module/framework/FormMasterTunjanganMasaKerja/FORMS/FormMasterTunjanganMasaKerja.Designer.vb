<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterTunjanganMasaKerja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterTunjanganMasaKerja))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.lblTahun = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTunjangan = New System.Windows.Forms.Label()
        Me.tbTunjangan = New System.Windows.Forms.TextBox()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.numSampaiMasaKerja = New System.Windows.Forms.NumericUpDown()
        Me.numMulaiMasaKerja = New System.Windows.Forms.NumericUpDown()
        Me.lblMasaKerja = New System.Windows.Forms.Label()
        Me.pnlKelompok = New System.Windows.Forms.Panel()
        Me.rbOutsource = New System.Windows.Forms.RadioButton()
        Me.rbNonStaff = New System.Windows.Forms.RadioButton()
        Me.rbStaff = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPerusahaan = New System.Windows.Forms.ComboBox()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.btnKeluar = New System.Windows.Forms.Button()
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
        Me.gbDataEntry.SuspendLayout()
        CType(Me.numSampaiMasaKerja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMulaiMasaKerja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlKelompok.SuspendLayout()
        Me.gbView.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(869, 25)
        Me.lblTitle.TabIndex = 180
        Me.lblTitle.Text = "MASTER TUNJANGAN MASA KERJA"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.lblTahun)
        Me.gbDataEntry.Controls.Add(Me.Label4)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.lblTunjangan)
        Me.gbDataEntry.Controls.Add(Me.tbTunjangan)
        Me.gbDataEntry.Controls.Add(Me.lblSD)
        Me.gbDataEntry.Controls.Add(Me.numSampaiMasaKerja)
        Me.gbDataEntry.Controls.Add(Me.numMulaiMasaKerja)
        Me.gbDataEntry.Controls.Add(Me.lblMasaKerja)
        Me.gbDataEntry.Controls.Add(Me.pnlKelompok)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.cboPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.lblPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(589, 186)
        Me.gbDataEntry.TabIndex = 193
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'lblTahun
        '
        Me.lblTahun.AutoSize = True
        Me.lblTahun.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTahun.Location = New System.Drawing.Point(305, 76)
        Me.lblTahun.Name = "lblTahun"
        Me.lblTahun.Size = New System.Drawing.Size(39, 15)
        Me.lblTahun.TabIndex = 239
        Me.lblTahun.Text = "Tahun"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(287, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 238
        Me.Label4.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(253, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 237
        Me.Label3.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(311, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = "*"
        '
        'lblTunjangan
        '
        Me.lblTunjangan.AutoSize = True
        Me.lblTunjangan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTunjangan.Location = New System.Drawing.Point(12, 102)
        Me.lblTunjangan.Name = "lblTunjangan"
        Me.lblTunjangan.Size = New System.Drawing.Size(69, 15)
        Me.lblTunjangan.TabIndex = 236
        Me.lblTunjangan.Text = "Tunjangan :"
        '
        'tbTunjangan
        '
        Me.tbTunjangan.Location = New System.Drawing.Point(87, 99)
        Me.tbTunjangan.Name = "tbTunjangan"
        Me.tbTunjangan.Size = New System.Drawing.Size(160, 23)
        Me.tbTunjangan.TabIndex = 7
        Me.tbTunjangan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(173, 76)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(22, 15)
        Me.lblSD.TabIndex = 234
        Me.lblSD.Text = "s.d"
        '
        'numSampaiMasaKerja
        '
        Me.numSampaiMasaKerja.Location = New System.Drawing.Point(201, 74)
        Me.numSampaiMasaKerja.Name = "numSampaiMasaKerja"
        Me.numSampaiMasaKerja.Size = New System.Drawing.Size(80, 23)
        Me.numSampaiMasaKerja.TabIndex = 6
        '
        'numMulaiMasaKerja
        '
        Me.numMulaiMasaKerja.Location = New System.Drawing.Point(87, 74)
        Me.numMulaiMasaKerja.Name = "numMulaiMasaKerja"
        Me.numMulaiMasaKerja.Size = New System.Drawing.Size(80, 23)
        Me.numMulaiMasaKerja.TabIndex = 5
        '
        'lblMasaKerja
        '
        Me.lblMasaKerja.AutoSize = True
        Me.lblMasaKerja.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMasaKerja.Location = New System.Drawing.Point(11, 76)
        Me.lblMasaKerja.Name = "lblMasaKerja"
        Me.lblMasaKerja.Size = New System.Drawing.Size(70, 15)
        Me.lblMasaKerja.TabIndex = 233
        Me.lblMasaKerja.Text = "Masa Kerja :"
        '
        'pnlKelompok
        '
        Me.pnlKelompok.Controls.Add(Me.rbOutsource)
        Me.pnlKelompok.Controls.Add(Me.rbNonStaff)
        Me.pnlKelompok.Controls.Add(Me.rbStaff)
        Me.pnlKelompok.Location = New System.Drawing.Point(87, 47)
        Me.pnlKelompok.Name = "pnlKelompok"
        Me.pnlKelompok.Size = New System.Drawing.Size(277, 25)
        Me.pnlKelompok.TabIndex = 228
        '
        'rbOutsource
        '
        Me.rbOutsource.AutoSize = True
        Me.rbOutsource.Location = New System.Drawing.Point(184, 3)
        Me.rbOutsource.Name = "rbOutsource"
        Me.rbOutsource.Size = New System.Drawing.Size(92, 19)
        Me.rbOutsource.TabIndex = 4
        Me.rbOutsource.Text = "OUTSOURCE"
        Me.rbOutsource.UseVisualStyleBackColor = True
        '
        'rbNonStaff
        '
        Me.rbNonStaff.AutoSize = True
        Me.rbNonStaff.Location = New System.Drawing.Point(85, 3)
        Me.rbNonStaff.Name = "rbNonStaff"
        Me.rbNonStaff.Size = New System.Drawing.Size(86, 19)
        Me.rbNonStaff.TabIndex = 3
        Me.rbNonStaff.Text = "NON STAFF"
        Me.rbNonStaff.UseVisualStyleBackColor = True
        '
        'rbStaff
        '
        Me.rbStaff.AutoSize = True
        Me.rbStaff.Location = New System.Drawing.Point(3, 3)
        Me.rbStaff.Name = "rbStaff"
        Me.rbStaff.Size = New System.Drawing.Size(56, 19)
        Me.rbStaff.TabIndex = 2
        Me.rbStaff.Text = "STAFF"
        Me.rbStaff.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(14, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 202
        Me.Label1.Text = "Kelompok :"
        '
        'cboPerusahaan
        '
        Me.cboPerusahaan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPerusahaan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPerusahaan.FormattingEnabled = True
        Me.cboPerusahaan.IntegralHeight = False
        Me.cboPerusahaan.Location = New System.Drawing.Point(87, 22)
        Me.cboPerusahaan.Name = "cboPerusahaan"
        Me.cboPerusahaan.Size = New System.Drawing.Size(218, 23)
        Me.cboPerusahaan.TabIndex = 1
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPerusahaan.Location = New System.Drawing.Point(7, 25)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaan.TabIndex = 200
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(337, 128)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 8
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(463, 128)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 9
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(607, 28)
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
        Me.clbUserRight.Location = New System.Drawing.Point(760, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 199
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(740, 160)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 13
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'gbView
        '
        Me.gbView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 220)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(848, 367)
        Me.gbView.TabIndex = 201
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
        Me.tbCari.TabIndex = 11
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(570, 11)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 12
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
        Me.cboKriteria.TabIndex = 10
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
        Me.dgvView.Size = New System.Drawing.Size(836, 263)
        Me.dgvView.TabIndex = 130
        '
        'FormMasterTunjanganMasaKerja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(869, 591)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMasterTunjanganMasaKerja"
        Me.Text = "FORM MASTER TUNJANGAN MASA KERJA"
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        CType(Me.numSampaiMasaKerja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMulaiMasaKerja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlKelompok.ResumeLayout(False)
        Me.pnlKelompok.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents cboPerusahaan As ComboBox
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlKelompok As Panel
    Friend WithEvents rbOutsource As RadioButton
    Friend WithEvents rbNonStaff As RadioButton
    Friend WithEvents rbStaff As RadioButton
    Friend WithEvents lblEntryType As Label
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents lblSD As Label
    Friend WithEvents numSampaiMasaKerja As NumericUpDown
    Friend WithEvents numMulaiMasaKerja As NumericUpDown
    Friend WithEvents lblMasaKerja As Label
    Friend WithEvents lblTunjangan As Label
    Friend WithEvents tbTunjangan As TextBox
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
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTahun As Label
End Class
