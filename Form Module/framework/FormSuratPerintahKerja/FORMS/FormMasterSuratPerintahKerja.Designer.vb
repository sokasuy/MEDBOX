<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterSuratPerintahKerja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterSuratPerintahKerja))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.dtpAkhir = New System.Windows.Forms.DateTimePicker()
        Me.dtpAwal = New System.Windows.Forms.DateTimePicker()
        Me.pnlTanggal = New System.Windows.Forms.Panel()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.lblCari = New System.Windows.Forms.Label()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.gbHeader = New System.Windows.Forms.GroupBox()
        Me.dgvHeader = New System.Windows.Forms.DataGridView()
        Me.pnlTanggal.SuspendLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetail.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        Me.gbHeader.SuspendLayout()
        CType(Me.dgvHeader, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.TabIndex = 181
        Me.lblTitle.Text = "MASTER SURAT PERINTAH KERJA"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.clbUserRight.TabIndex = 208
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(617, 38)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 200
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(491, 38)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 199
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(129, 12)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(21, 13)
        Me.lblSD.TabIndex = 5
        Me.lblSD.Text = "s.d"
        '
        'dtpAkhir
        '
        Me.dtpAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAkhir.Location = New System.Drawing.Point(156, 6)
        Me.dtpAkhir.Name = "dtpAkhir"
        Me.dtpAkhir.Size = New System.Drawing.Size(120, 20)
        Me.dtpAkhir.TabIndex = 3
        '
        'dtpAwal
        '
        Me.dtpAwal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAwal.Location = New System.Drawing.Point(3, 6)
        Me.dtpAwal.Name = "dtpAwal"
        Me.dtpAwal.Size = New System.Drawing.Size(120, 20)
        Me.dtpAwal.TabIndex = 2
        '
        'pnlTanggal
        '
        Me.pnlTanggal.Controls.Add(Me.lblSD)
        Me.pnlTanggal.Controls.Add(Me.dtpAkhir)
        Me.pnlTanggal.Controls.Add(Me.dtpAwal)
        Me.pnlTanggal.Location = New System.Drawing.Point(188, 45)
        Me.pnlTanggal.Name = "pnlTanggal"
        Me.pnlTanggal.Size = New System.Drawing.Size(285, 30)
        Me.pnlTanggal.TabIndex = 207
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(188, 50)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(297, 20)
        Me.tbCari.TabIndex = 198
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Location = New System.Drawing.Point(15, 52)
        Me.lblCari.Name = "lblCari"
        Me.lblCari.Size = New System.Drawing.Size(45, 13)
        Me.lblCari.TabIndex = 206
        Me.lblCari.Text = "Kriteria :"
        '
        'cboKriteria
        '
        Me.cboKriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKriteria.FormattingEnabled = True
        Me.cboKriteria.Location = New System.Drawing.Point(66, 49)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboKriteria.TabIndex = 205
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Location = New System.Drawing.Point(6, 19)
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.Size = New System.Drawing.Size(948, 158)
        Me.dgvDetail.TabIndex = 0
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(743, 38)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 201
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'gbDetail
        '
        Me.gbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetail.Controls.Add(Me.dgvDetail)
        Me.gbDetail.Location = New System.Drawing.Point(12, 426)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(960, 183)
        Me.gbDetail.TabIndex = 204
        Me.gbDetail.TabStop = False
        Me.gbDetail.Text = "DETAIL"
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
        Me.pnlNavigasi.Location = New System.Drawing.Point(6, 286)
        Me.pnlNavigasi.Name = "pnlNavigasi"
        Me.pnlNavigasi.Size = New System.Drawing.Size(425, 29)
        Me.pnlNavigasi.TabIndex = 173
        '
        'gbHeader
        '
        Me.gbHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbHeader.Controls.Add(Me.pnlNavigasi)
        Me.gbHeader.Controls.Add(Me.dgvHeader)
        Me.gbHeader.Location = New System.Drawing.Point(12, 98)
        Me.gbHeader.Name = "gbHeader"
        Me.gbHeader.Size = New System.Drawing.Size(960, 322)
        Me.gbHeader.TabIndex = 203
        Me.gbHeader.TabStop = False
        Me.gbHeader.Text = "HEADER"
        '
        'dgvHeader
        '
        Me.dgvHeader.AllowUserToAddRows = False
        Me.dgvHeader.AllowUserToDeleteRows = False
        Me.dgvHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHeader.Location = New System.Drawing.Point(6, 19)
        Me.dgvHeader.Name = "dgvHeader"
        Me.dgvHeader.Size = New System.Drawing.Size(948, 263)
        Me.dgvHeader.TabIndex = 0
        '
        'FormMasterSuratPerintahKerja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 621)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Controls.Add(Me.btnTampilkan)
        Me.Controls.Add(Me.pnlTanggal)
        Me.Controls.Add(Me.tbCari)
        Me.Controls.Add(Me.lblCari)
        Me.Controls.Add(Me.cboKriteria)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.gbHeader)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMasterSuratPerintahKerja"
        Me.Text = "FORM MASTER SURAT PERINTAH KERJA"
        Me.pnlTanggal.ResumeLayout(False)
        Me.pnlTanggal.PerformLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetail.ResumeLayout(False)
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        Me.gbHeader.ResumeLayout(False)
        CType(Me.dgvHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpAkhir As DateTimePicker
    Friend WithEvents dtpAwal As DateTimePicker
    Friend WithEvents pnlTanggal As Panel
    Friend WithEvents tbCari As TextBox
    Friend WithEvents lblCari As Label
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents dgvDetail As DataGridView
    Friend WithEvents btnKeluar As Button
    Friend WithEvents gbDetail As GroupBox
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnFFBack As Button
    Friend WithEvents lblRecord As Label
    Friend WithEvents btnForward As Button
    Friend WithEvents lblOfPages As Label
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnFFForward As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents gbHeader As GroupBox
    Friend WithEvents dgvHeader As DataGridView
End Class
