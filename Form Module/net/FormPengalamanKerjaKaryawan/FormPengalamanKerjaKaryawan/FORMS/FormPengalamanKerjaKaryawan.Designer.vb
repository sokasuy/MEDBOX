<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPengalamanKerjaKaryawan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPengalamanKerjaKaryawan))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.lblKriteria = New System.Windows.Forms.Label()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.numTahunKeluarKerja = New System.Windows.Forms.NumericUpDown()
        Me.numTahunMasukKerja = New System.Windows.Forms.NumericUpDown()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.lblTahunBekerja = New System.Windows.Forms.Label()
        Me.lblContohLamaBekerja = New System.Windows.Forms.Label()
        Me.tbLamaBekerja = New System.Windows.Forms.TextBox()
        Me.lblLamaBekerja = New System.Windows.Forms.Label()
        Me.tbPosisiTerakhir = New System.Windows.Forms.TextBox()
        Me.lblPosisiTerakhir = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbNamaTempatKerja = New System.Windows.Forms.TextBox()
        Me.lblNamaTempatKerja = New System.Windows.Forms.Label()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigasi.SuspendLayout()
        Me.gbView.SuspendLayout()
        Me.gbDataEntry.SuspendLayout()
        CType(Me.numTahunKeluarKerja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTahunMasukKerja, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.TabIndex = 17
        Me.lblTitle.Text = "PENGALAMAN KERJA KARYAWAN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(190, 27)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(339, 23)
        Me.tbCari.TabIndex = 9
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(590, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "*"
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
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(535, 10)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 10
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
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
        'btnFFForward
        '
        Me.btnFFForward.Location = New System.Drawing.Point(250, 4)
        Me.btnFFForward.Name = "btnFFForward"
        Me.btnFFForward.Size = New System.Drawing.Size(31, 23)
        Me.btnFFForward.TabIndex = 168
        Me.btnFFForward.Text = ">>"
        Me.btnFFForward.UseVisualStyleBackColor = True
        '
        'cboKaryawan
        '
        Me.cboKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.IntegralHeight = False
        Me.cboKaryawan.Location = New System.Drawing.Point(134, 22)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(450, 23)
        Me.cboKaryawan.TabIndex = 1
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
        'lblKriteria
        '
        Me.lblKriteria.AutoSize = True
        Me.lblKriteria.Location = New System.Drawing.Point(7, 30)
        Me.lblKriteria.Name = "lblKriteria"
        Me.lblKriteria.Size = New System.Drawing.Size(50, 15)
        Me.lblKriteria.TabIndex = 2
        Me.lblKriteria.Text = "Kriteria :"
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Location = New System.Drawing.Point(64, 25)
        Me.lblKaryawan.Name = "lblKaryawan"
        Me.lblKaryawan.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawan.TabIndex = 33
        Me.lblKaryawan.Text = "Karyawan :"
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
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(575, 120)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 8
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
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
        Me.gbView.Location = New System.Drawing.Point(12, 216)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(960, 367)
        Me.gbView.TabIndex = 47
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
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
        Me.clbUserRight.TabIndex = 46
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(719, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 45
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(719, 52)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 11
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(449, 120)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 7
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.numTahunKeluarKerja)
        Me.gbDataEntry.Controls.Add(Me.numTahunMasukKerja)
        Me.gbDataEntry.Controls.Add(Me.lblSD)
        Me.gbDataEntry.Controls.Add(Me.lblTahunBekerja)
        Me.gbDataEntry.Controls.Add(Me.lblContohLamaBekerja)
        Me.gbDataEntry.Controls.Add(Me.tbLamaBekerja)
        Me.gbDataEntry.Controls.Add(Me.lblLamaBekerja)
        Me.gbDataEntry.Controls.Add(Me.tbPosisiTerakhir)
        Me.gbDataEntry.Controls.Add(Me.lblPosisiTerakhir)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.tbNamaTempatKerja)
        Me.gbDataEntry.Controls.Add(Me.lblNamaTempatKerja)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.cboKaryawan)
        Me.gbDataEntry.Controls.Add(Me.lblKaryawan)
        Me.gbDataEntry.Controls.Add(Me.btnKeluar)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(701, 180)
        Me.gbDataEntry.TabIndex = 44
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'numTahunKeluarKerja
        '
        Me.numTahunKeluarKerja.Location = New System.Drawing.Point(248, 119)
        Me.numTahunKeluarKerja.Name = "numTahunKeluarKerja"
        Me.numTahunKeluarKerja.Size = New System.Drawing.Size(80, 23)
        Me.numTahunKeluarKerja.TabIndex = 6
        '
        'numTahunMasukKerja
        '
        Me.numTahunMasukKerja.Location = New System.Drawing.Point(134, 119)
        Me.numTahunMasukKerja.Name = "numTahunMasukKerja"
        Me.numTahunMasukKerja.Size = New System.Drawing.Size(80, 23)
        Me.numTahunMasukKerja.TabIndex = 5
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(220, 121)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(22, 15)
        Me.lblSD.TabIndex = 68
        Me.lblSD.Text = "s.d"
        '
        'lblTahunBekerja
        '
        Me.lblTahunBekerja.AutoSize = True
        Me.lblTahunBekerja.Location = New System.Drawing.Point(42, 121)
        Me.lblTahunBekerja.Name = "lblTahunBekerja"
        Me.lblTahunBekerja.Size = New System.Drawing.Size(86, 15)
        Me.lblTahunBekerja.TabIndex = 67
        Me.lblTahunBekerja.Text = "Tahun Bekerja :"
        '
        'lblContohLamaBekerja
        '
        Me.lblContohLamaBekerja.AutoSize = True
        Me.lblContohLamaBekerja.Location = New System.Drawing.Point(310, 97)
        Me.lblContohLamaBekerja.Name = "lblContohLamaBekerja"
        Me.lblContohLamaBekerja.Size = New System.Drawing.Size(139, 15)
        Me.lblContohLamaBekerja.TabIndex = 65
        Me.lblContohLamaBekerja.Text = "Contoh : 2 Tahun 3 Bulan"
        '
        'tbLamaBekerja
        '
        Me.tbLamaBekerja.Location = New System.Drawing.Point(134, 94)
        Me.tbLamaBekerja.Name = "tbLamaBekerja"
        Me.tbLamaBekerja.Size = New System.Drawing.Size(170, 23)
        Me.tbLamaBekerja.TabIndex = 4
        '
        'lblLamaBekerja
        '
        Me.lblLamaBekerja.AutoSize = True
        Me.lblLamaBekerja.Location = New System.Drawing.Point(45, 97)
        Me.lblLamaBekerja.Name = "lblLamaBekerja"
        Me.lblLamaBekerja.Size = New System.Drawing.Size(83, 15)
        Me.lblLamaBekerja.TabIndex = 64
        Me.lblLamaBekerja.Text = "Lama Bekerja :"
        '
        'tbPosisiTerakhir
        '
        Me.tbPosisiTerakhir.Location = New System.Drawing.Point(134, 70)
        Me.tbPosisiTerakhir.Name = "tbPosisiTerakhir"
        Me.tbPosisiTerakhir.Size = New System.Drawing.Size(212, 23)
        Me.tbPosisiTerakhir.TabIndex = 3
        '
        'lblPosisiTerakhir
        '
        Me.lblPosisiTerakhir.AutoSize = True
        Me.lblPosisiTerakhir.Location = New System.Drawing.Point(41, 73)
        Me.lblPosisiTerakhir.Name = "lblPosisiTerakhir"
        Me.lblPosisiTerakhir.Size = New System.Drawing.Size(87, 15)
        Me.lblPosisiTerakhir.TabIndex = 62
        Me.lblPosisiTerakhir.Text = "Posisi Terakhir :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(457, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "*"
        '
        'tbNamaTempatKerja
        '
        Me.tbNamaTempatKerja.Location = New System.Drawing.Point(134, 46)
        Me.tbNamaTempatKerja.Name = "tbNamaTempatKerja"
        Me.tbNamaTempatKerja.Size = New System.Drawing.Size(317, 23)
        Me.tbNamaTempatKerja.TabIndex = 2
        '
        'lblNamaTempatKerja
        '
        Me.lblNamaTempatKerja.AutoSize = True
        Me.lblNamaTempatKerja.Location = New System.Drawing.Point(12, 49)
        Me.lblNamaTempatKerja.Name = "lblNamaTempatKerja"
        Me.lblNamaTempatKerja.Size = New System.Drawing.Size(116, 15)
        Me.lblNamaTempatKerja.TabIndex = 59
        Me.lblNamaTempatKerja.Text = "Nama Tempat Kerja :"
        '
        'FormPengalamanKerjaKaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 586)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormPengalamanKerjaKaryawan"
        Me.Text = "FORM PENGALAMAN KERJA KARYAWAN"
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        CType(Me.numTahunKeluarKerja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTahunMasukKerja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents tbCari As TextBox
    Friend WithEvents lblRecord As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnFFBack As Button
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnFFForward As Button
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents btnForward As Button
    Friend WithEvents lblKriteria As Label
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents btnKeluar As Button
    Friend WithEvents lblOfPages As Label
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents btnAddNew As Button
    Friend WithEvents gbView As GroupBox
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbNamaTempatKerja As TextBox
    Friend WithEvents lblNamaTempatKerja As Label
    Friend WithEvents tbPosisiTerakhir As TextBox
    Friend WithEvents lblPosisiTerakhir As Label
    Friend WithEvents tbLamaBekerja As TextBox
    Friend WithEvents lblLamaBekerja As Label
    Friend WithEvents lblContohLamaBekerja As Label
    Friend WithEvents lblTahunBekerja As Label
    Friend WithEvents lblSD As Label
    Friend WithEvents numTahunKeluarKerja As NumericUpDown
    Friend WithEvents numTahunMasukKerja As NumericUpDown
End Class
