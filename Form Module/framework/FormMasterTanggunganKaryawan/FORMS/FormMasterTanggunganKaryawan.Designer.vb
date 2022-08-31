<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterTanggunganKaryawan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterTanggunganKaryawan))
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
        Me.gbTanggungan = New System.Windows.Forms.GroupBox()
        Me.lblDigitNIK = New System.Windows.Forms.Label()
        Me.tbHubungan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTanggalLahir = New System.Windows.Forms.Label()
        Me.dtpTanggalLahir = New System.Windows.Forms.DateTimePicker()
        Me.lblTempatLahir = New System.Windows.Forms.Label()
        Me.tbTempatLahir = New System.Windows.Forms.TextBox()
        Me.lblHubungan = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNIK = New System.Windows.Forms.Label()
        Me.tbNIKTanggungan = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNama = New System.Windows.Forms.Label()
        Me.tbNamaTanggungan = New System.Windows.Forms.TextBox()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.tbNamaKaryawan = New System.Windows.Forms.TextBox()
        Me.tbIDK = New System.Windows.Forms.TextBox()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbView.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDataEntry.SuspendLayout()
        Me.gbTanggungan.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(984, 25)
        Me.lblTitle.TabIndex = 177
        Me.lblTitle.Text = "MASTER TANGGUNGAN KARYAWAN"
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
        Me.gbView.Location = New System.Drawing.Point(12, 265)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(960, 370)
        Me.gbView.TabIndex = 182
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
        Me.pnlNavigasi.Location = New System.Drawing.Point(6, 333)
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
        Me.tbCari.TabIndex = 10
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(570, 12)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 11
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
        Me.dgvView.Size = New System.Drawing.Size(948, 263)
        Me.dgvView.TabIndex = 130
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.gbTanggungan)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.tbNamaKaryawan)
        Me.gbDataEntry.Controls.Add(Me.tbIDK)
        Me.gbDataEntry.Controls.Add(Me.lblKaryawan)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(625, 235)
        Me.gbDataEntry.TabIndex = 183
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'gbTanggungan
        '
        Me.gbTanggungan.Controls.Add(Me.lblDigitNIK)
        Me.gbTanggungan.Controls.Add(Me.tbHubungan)
        Me.gbTanggungan.Controls.Add(Me.Label2)
        Me.gbTanggungan.Controls.Add(Me.lblTanggalLahir)
        Me.gbTanggungan.Controls.Add(Me.dtpTanggalLahir)
        Me.gbTanggungan.Controls.Add(Me.lblTempatLahir)
        Me.gbTanggungan.Controls.Add(Me.tbTempatLahir)
        Me.gbTanggungan.Controls.Add(Me.lblHubungan)
        Me.gbTanggungan.Controls.Add(Me.Label1)
        Me.gbTanggungan.Controls.Add(Me.lblNIK)
        Me.gbTanggungan.Controls.Add(Me.tbNIKTanggungan)
        Me.gbTanggungan.Controls.Add(Me.Label3)
        Me.gbTanggungan.Controls.Add(Me.lblNama)
        Me.gbTanggungan.Controls.Add(Me.tbNamaTanggungan)
        Me.gbTanggungan.Location = New System.Drawing.Point(6, 45)
        Me.gbTanggungan.Name = "gbTanggungan"
        Me.gbTanggungan.Size = New System.Drawing.Size(613, 124)
        Me.gbTanggungan.TabIndex = 14
        Me.gbTanggungan.TabStop = False
        Me.gbTanggungan.Text = "TANGGUNGAN"
        '
        'lblDigitNIK
        '
        Me.lblDigitNIK.AutoSize = True
        Me.lblDigitNIK.ForeColor = System.Drawing.Color.Red
        Me.lblDigitNIK.Location = New System.Drawing.Point(313, 49)
        Me.lblDigitNIK.Name = "lblDigitNIK"
        Me.lblDigitNIK.Size = New System.Drawing.Size(13, 15)
        Me.lblDigitNIK.TabIndex = 229
        Me.lblDigitNIK.Text = "0"
        '
        'tbHubungan
        '
        Me.tbHubungan.Location = New System.Drawing.Point(93, 70)
        Me.tbHubungan.Name = "tbHubungan"
        Me.tbHubungan.Size = New System.Drawing.Size(144, 23)
        Me.tbHubungan.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(231, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 213
        Me.Label2.Text = "*"
        '
        'lblTanggalLahir
        '
        Me.lblTanggalLahir.AutoSize = True
        Me.lblTanggalLahir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTanggalLahir.Location = New System.Drawing.Point(349, 100)
        Me.lblTanggalLahir.Name = "lblTanggalLahir"
        Me.lblTanggalLahir.Size = New System.Drawing.Size(83, 15)
        Me.lblTanggalLahir.TabIndex = 212
        Me.lblTanggalLahir.Text = "Tanggal Lahir :"
        '
        'dtpTanggalLahir
        '
        Me.dtpTanggalLahir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalLahir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalLahir.Location = New System.Drawing.Point(438, 94)
        Me.dtpTanggalLahir.Name = "dtpTanggalLahir"
        Me.dtpTanggalLahir.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggalLahir.TabIndex = 7
        '
        'lblTempatLahir
        '
        Me.lblTempatLahir.AutoSize = True
        Me.lblTempatLahir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTempatLahir.Location = New System.Drawing.Point(6, 97)
        Me.lblTempatLahir.Name = "lblTempatLahir"
        Me.lblTempatLahir.Size = New System.Drawing.Size(81, 15)
        Me.lblTempatLahir.TabIndex = 210
        Me.lblTempatLahir.Text = "Tempat Lahir :"
        '
        'tbTempatLahir
        '
        Me.tbTempatLahir.Location = New System.Drawing.Point(93, 94)
        Me.tbTempatLahir.Name = "tbTempatLahir"
        Me.tbTempatLahir.Size = New System.Drawing.Size(231, 23)
        Me.tbTempatLahir.TabIndex = 6
        '
        'lblHubungan
        '
        Me.lblHubungan.AutoSize = True
        Me.lblHubungan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHubungan.Location = New System.Drawing.Point(17, 73)
        Me.lblHubungan.Name = "lblHubungan"
        Me.lblHubungan.Size = New System.Drawing.Size(70, 15)
        Me.lblHubungan.TabIndex = 208
        Me.lblHubungan.Text = "Hubungan :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(295, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 196
        Me.Label1.Text = "*"
        '
        'lblNIK
        '
        Me.lblNIK.AutoSize = True
        Me.lblNIK.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNIK.Location = New System.Drawing.Point(55, 49)
        Me.lblNIK.Name = "lblNIK"
        Me.lblNIK.Size = New System.Drawing.Size(32, 15)
        Me.lblNIK.TabIndex = 195
        Me.lblNIK.Text = "NIK :"
        '
        'tbNIKTanggungan
        '
        Me.tbNIKTanggungan.Location = New System.Drawing.Point(93, 46)
        Me.tbNIKTanggungan.Name = "tbNIKTanggungan"
        Me.tbNIKTanggungan.Size = New System.Drawing.Size(196, 23)
        Me.tbNIKTanggungan.TabIndex = 4
        Me.tbNIKTanggungan.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(414, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 193
        Me.Label3.Text = "*"
        '
        'lblNama
        '
        Me.lblNama.AutoSize = True
        Me.lblNama.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNama.Location = New System.Drawing.Point(42, 25)
        Me.lblNama.Name = "lblNama"
        Me.lblNama.Size = New System.Drawing.Size(45, 15)
        Me.lblNama.TabIndex = 12
        Me.lblNama.Text = "Nama :"
        '
        'tbNamaTanggungan
        '
        Me.tbNamaTanggungan.Location = New System.Drawing.Point(93, 22)
        Me.tbNamaTanggungan.Name = "tbNamaTanggungan"
        Me.tbNamaTanggungan.Size = New System.Drawing.Size(315, 23)
        Me.tbNamaTanggungan.TabIndex = 3
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(373, 175)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 12
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'tbNamaKaryawan
        '
        Me.tbNamaKaryawan.Location = New System.Drawing.Point(255, 16)
        Me.tbNamaKaryawan.Name = "tbNamaKaryawan"
        Me.tbNamaKaryawan.ReadOnly = True
        Me.tbNamaKaryawan.Size = New System.Drawing.Size(364, 23)
        Me.tbNamaKaryawan.TabIndex = 2
        '
        'tbIDK
        '
        Me.tbIDK.Location = New System.Drawing.Point(99, 16)
        Me.tbIDK.Name = "tbIDK"
        Me.tbIDK.ReadOnly = True
        Me.tbIDK.Size = New System.Drawing.Size(150, 23)
        Me.tbIDK.TabIndex = 1
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKaryawan.Location = New System.Drawing.Point(29, 19)
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
        Me.btnSimpan.Location = New System.Drawing.Point(499, 175)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 8
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(852, 209)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 9
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(643, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 190
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
        Me.clbUserRight.TabIndex = 189
        '
        'FormMasterTanggunganKaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 636)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMasterTanggunganKaryawan"
        Me.Text = "FORM MASTER TANGGUNGAN KARYAWAN"
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.gbTanggungan.ResumeLayout(False)
        Me.gbTanggungan.PerformLayout()
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
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents tbIDK As TextBox
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents tbNamaKaryawan As TextBox
    Friend WithEvents gbTanggungan As GroupBox
    Friend WithEvents tbNamaTanggungan As TextBox
    Friend WithEvents lblNama As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNIK As Label
    Friend WithEvents tbNIKTanggungan As TextBox
    Friend WithEvents lblHubungan As Label
    Friend WithEvents lblTempatLahir As Label
    Friend WithEvents tbTempatLahir As TextBox
    Friend WithEvents lblTanggalLahir As Label
    Friend WithEvents dtpTanggalLahir As DateTimePicker
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbHubungan As TextBox
    Friend WithEvents lblDigitNIK As Label
End Class
