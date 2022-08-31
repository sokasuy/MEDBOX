<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterPosisiKaryawan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterPosisiKaryawan))
        Me.lblTitle = New System.Windows.Forms.Label()
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDari = New System.Windows.Forms.Label()
        Me.cbAktif = New System.Windows.Forms.CheckBox()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.dtpTanggalSelesaiMenjabat = New System.Windows.Forms.DateTimePicker()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.dtpTanggalMulaiMenjabat = New System.Windows.Forms.DateTimePicker()
        Me.cboPosisi = New System.Windows.Forms.ComboBox()
        Me.lblPosisi = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.tbNamaKaryawan = New System.Windows.Forms.TextBox()
        Me.tbNIP = New System.Windows.Forms.TextBox()
        Me.lblIDK = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.gbView.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDataEntry.SuspendLayout()
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
        Me.lblTitle.TabIndex = 15
        Me.lblTitle.Text = "MASTER POSISI KARYAWAN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.gbView.Location = New System.Drawing.Point(12, 179)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(960, 367)
        Me.gbView.TabIndex = 31
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
        Me.btnTampilkan.Location = New System.Drawing.Point(538, 10)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 7
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(190, 22)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(339, 23)
        Me.tbCari.TabIndex = 6
        '
        'lblKriteria
        '
        Me.lblKriteria.AutoSize = True
        Me.lblKriteria.Location = New System.Drawing.Point(7, 25)
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
        Me.cboKriteria.Location = New System.Drawing.Point(63, 22)
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
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.lblDari)
        Me.gbDataEntry.Controls.Add(Me.cbAktif)
        Me.gbDataEntry.Controls.Add(Me.lblSD)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggalSelesaiMenjabat)
        Me.gbDataEntry.Controls.Add(Me.btnKeluar)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggalMulaiMenjabat)
        Me.gbDataEntry.Controls.Add(Me.cboPosisi)
        Me.gbDataEntry.Controls.Add(Me.lblPosisi)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Controls.Add(Me.tbNamaKaryawan)
        Me.gbDataEntry.Controls.Add(Me.tbNIP)
        Me.gbDataEntry.Controls.Add(Me.lblIDK)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(700, 145)
        Me.gbDataEntry.TabIndex = 32
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(386, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "*"
        '
        'lblDari
        '
        Me.lblDari.AutoSize = True
        Me.lblDari.Location = New System.Drawing.Point(59, 70)
        Me.lblDari.Name = "lblDari"
        Me.lblDari.Size = New System.Drawing.Size(34, 15)
        Me.lblDari.TabIndex = 43
        Me.lblDari.Text = "Dari :"
        '
        'cbAktif
        '
        Me.cbAktif.AutoSize = True
        Me.cbAktif.Checked = True
        Me.cbAktif.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAktif.Location = New System.Drawing.Point(425, 42)
        Me.cbAktif.Name = "cbAktif"
        Me.cbAktif.Size = New System.Drawing.Size(51, 19)
        Me.cbAktif.TabIndex = 50
        Me.cbAktif.Text = "Aktif"
        Me.cbAktif.UseVisualStyleBackColor = True
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(224, 70)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(22, 15)
        Me.lblSD.TabIndex = 41
        Me.lblSD.Text = "s.d"
        '
        'dtpTanggalSelesaiMenjabat
        '
        Me.dtpTanggalSelesaiMenjabat.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalSelesaiMenjabat.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalSelesaiMenjabat.Location = New System.Drawing.Point(252, 64)
        Me.dtpTanggalSelesaiMenjabat.Name = "dtpTanggalSelesaiMenjabat"
        Me.dtpTanggalSelesaiMenjabat.Size = New System.Drawing.Size(119, 23)
        Me.dtpTanggalSelesaiMenjabat.TabIndex = 3
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(574, 85)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 5
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'dtpTanggalMulaiMenjabat
        '
        Me.dtpTanggalMulaiMenjabat.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalMulaiMenjabat.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalMulaiMenjabat.Location = New System.Drawing.Point(99, 64)
        Me.dtpTanggalMulaiMenjabat.Name = "dtpTanggalMulaiMenjabat"
        Me.dtpTanggalMulaiMenjabat.Size = New System.Drawing.Size(119, 23)
        Me.dtpTanggalMulaiMenjabat.TabIndex = 2
        '
        'cboPosisi
        '
        Me.cboPosisi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPosisi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPosisi.FormattingEnabled = True
        Me.cboPosisi.IntegralHeight = False
        Me.cboPosisi.Location = New System.Drawing.Point(99, 40)
        Me.cboPosisi.Name = "cboPosisi"
        Me.cboPosisi.Size = New System.Drawing.Size(281, 23)
        Me.cboPosisi.TabIndex = 1
        '
        'lblPosisi
        '
        Me.lblPosisi.AutoSize = True
        Me.lblPosisi.Location = New System.Drawing.Point(50, 43)
        Me.lblPosisi.Name = "lblPosisi"
        Me.lblPosisi.Size = New System.Drawing.Size(43, 15)
        Me.lblPosisi.TabIndex = 33
        Me.lblPosisi.Text = "Posisi :"
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(448, 85)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 4
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'tbNamaKaryawan
        '
        Me.tbNamaKaryawan.Location = New System.Drawing.Point(255, 16)
        Me.tbNamaKaryawan.Name = "tbNamaKaryawan"
        Me.tbNamaKaryawan.ReadOnly = True
        Me.tbNamaKaryawan.Size = New System.Drawing.Size(439, 23)
        Me.tbNamaKaryawan.TabIndex = 29
        '
        'tbNIP
        '
        Me.tbNIP.Location = New System.Drawing.Point(99, 16)
        Me.tbNIP.Name = "tbNIP"
        Me.tbNIP.ReadOnly = True
        Me.tbNIP.Size = New System.Drawing.Size(150, 23)
        Me.tbNIP.TabIndex = 1
        '
        'lblIDK
        '
        Me.lblIDK.AutoSize = True
        Me.lblIDK.Location = New System.Drawing.Point(29, 19)
        Me.lblIDK.Name = "lblIDK"
        Me.lblIDK.Size = New System.Drawing.Size(64, 15)
        Me.lblIDK.TabIndex = 1
        Me.lblIDK.Text = "Karyawan :"
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
        Me.clbUserRight.TabIndex = 37
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(718, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 36
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
        Me.btnCreateNew.TabIndex = 8
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'FormMasterPosisiKaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 551)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMasterPosisiKaryawan"
        Me.Text = "FORM MASTER POSISI KARYAWAN"
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
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
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents cboPosisi As ComboBox
    Friend WithEvents lblPosisi As Label
    Friend WithEvents btnSimpan As Button
    Friend WithEvents tbNamaKaryawan As TextBox
    Friend WithEvents tbNIP As TextBox
    Friend WithEvents lblIDK As Label
    Friend WithEvents lblDari As Label
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpTanggalSelesaiMenjabat As DateTimePicker
    Friend WithEvents dtpTanggalMulaiMenjabat As DateTimePicker
    Friend WithEvents cbAktif As CheckBox
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents Label2 As Label
End Class
