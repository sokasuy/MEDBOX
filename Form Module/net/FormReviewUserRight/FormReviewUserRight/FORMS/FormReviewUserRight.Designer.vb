<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReviewUserRight
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReviewUserRight))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
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
        Me.cbPrint = New System.Windows.Forms.CheckBox()
        Me.cbDelete = New System.Windows.Forms.CheckBox()
        Me.cbUpdate = New System.Windows.Forms.CheckBox()
        Me.cbRead = New System.Windows.Forms.CheckBox()
        Me.cbCreate = New System.Windows.Forms.CheckBox()
        Me.cboFormName = New System.Windows.Forms.ComboBox()
        Me.cboUserID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.lblFormName = New System.Windows.Forms.Label()
        Me.lblUserID = New System.Windows.Forms.Label()
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
        Me.lblTitle.Size = New System.Drawing.Size(864, 25)
        Me.lblTitle.TabIndex = 10
        Me.lblTitle.Text = "REVIEW USER RIGHT"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(753, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 17
        Me.lblEntryType.Text = "INSERT NEW"
        Me.lblEntryType.Visible = False
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Location = New System.Drawing.Point(753, 50)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(100, 54)
        Me.btnCreateNew.TabIndex = 5
        Me.btnCreateNew.Text = "TAMBAH"
        Me.btnCreateNew.UseVisualStyleBackColor = True
        Me.btnCreateNew.Visible = False
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
        Me.gbView.Location = New System.Drawing.Point(12, 191)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(840, 388)
        Me.gbView.TabIndex = 15
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
        Me.pnlNavigasi.Location = New System.Drawing.Point(6, 349)
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
        Me.btnTampilkan.Location = New System.Drawing.Point(467, 22)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(75, 23)
        Me.btnTampilkan.TabIndex = 8
        Me.btnTampilkan.Text = "Tampilkan"
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(190, 22)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(271, 23)
        Me.tbCari.TabIndex = 7
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
        Me.dgvView.Location = New System.Drawing.Point(6, 51)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.RowTemplate.Height = 25
        Me.dgvView.Size = New System.Drawing.Size(828, 292)
        Me.dgvView.TabIndex = 0
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.cbPrint)
        Me.gbDataEntry.Controls.Add(Me.cbDelete)
        Me.gbDataEntry.Controls.Add(Me.cbUpdate)
        Me.gbDataEntry.Controls.Add(Me.cbRead)
        Me.gbDataEntry.Controls.Add(Me.cbCreate)
        Me.gbDataEntry.Controls.Add(Me.cboFormName)
        Me.gbDataEntry.Controls.Add(Me.cboUserID)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.btnKeluar)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Controls.Add(Me.lblFormName)
        Me.gbDataEntry.Controls.Add(Me.lblUserID)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(735, 157)
        Me.gbDataEntry.TabIndex = 14
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'cbPrint
        '
        Me.cbPrint.AutoSize = True
        Me.cbPrint.Location = New System.Drawing.Point(628, 75)
        Me.cbPrint.Name = "cbPrint"
        Me.cbPrint.Size = New System.Drawing.Size(105, 19)
        Me.cbPrint.TabIndex = 16
        Me.cbPrint.Text = "Mencetak Data"
        Me.cbPrint.UseVisualStyleBackColor = True
        '
        'cbDelete
        '
        Me.cbDelete.AutoSize = True
        Me.cbDelete.Location = New System.Drawing.Point(506, 75)
        Me.cbDelete.Name = "cbDelete"
        Me.cbDelete.Size = New System.Drawing.Size(116, 19)
        Me.cbDelete.TabIndex = 15
        Me.cbDelete.Text = "Menghapus Data"
        Me.cbDelete.UseVisualStyleBackColor = True
        '
        'cbUpdate
        '
        Me.cbUpdate.AutoSize = True
        Me.cbUpdate.Location = New System.Drawing.Point(362, 75)
        Me.cbUpdate.Name = "cbUpdate"
        Me.cbUpdate.Size = New System.Drawing.Size(138, 19)
        Me.cbUpdate.TabIndex = 14
        Me.cbUpdate.Text = "Memperbaharui Data"
        Me.cbUpdate.UseVisualStyleBackColor = True
        '
        'cbRead
        '
        Me.cbRead.AutoSize = True
        Me.cbRead.Location = New System.Drawing.Point(97, 75)
        Me.cbRead.Name = "cbRead"
        Me.cbRead.Size = New System.Drawing.Size(93, 19)
        Me.cbRead.TabIndex = 13
        Me.cbRead.Text = "Melihat Data"
        Me.cbRead.UseVisualStyleBackColor = True
        '
        'cbCreate
        '
        Me.cbCreate.AutoSize = True
        Me.cbCreate.Location = New System.Drawing.Point(196, 75)
        Me.cbCreate.Name = "cbCreate"
        Me.cbCreate.Size = New System.Drawing.Size(160, 19)
        Me.cbCreate.TabIndex = 12
        Me.cbCreate.Text = "Menambahkan Data Baru"
        Me.cbCreate.UseVisualStyleBackColor = True
        '
        'cboFormName
        '
        Me.cboFormName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFormName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFormName.FormattingEnabled = True
        Me.cboFormName.IntegralHeight = False
        Me.cboFormName.Location = New System.Drawing.Point(97, 46)
        Me.cboFormName.Name = "cboFormName"
        Me.cboFormName.Size = New System.Drawing.Size(445, 23)
        Me.cboFormName.TabIndex = 2
        '
        'cboUserID
        '
        Me.cboUserID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboUserID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboUserID.FormattingEnabled = True
        Me.cboUserID.IntegralHeight = False
        Me.cboUserID.Location = New System.Drawing.Point(97, 17)
        Me.cboUserID.Name = "cboUserID"
        Me.cboUserID.Size = New System.Drawing.Size(217, 23)
        Me.cboUserID.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(320, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(548, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "*"
        '
        'btnKeluar
        '
        Me.btnKeluar.Location = New System.Drawing.Point(203, 100)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(100, 54)
        Me.btnKeluar.TabIndex = 4
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(97, 100)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(100, 54)
        Me.btnSimpan.TabIndex = 3
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'lblFormName
        '
        Me.lblFormName.AutoSize = True
        Me.lblFormName.Location = New System.Drawing.Point(15, 49)
        Me.lblFormName.Name = "lblFormName"
        Me.lblFormName.Size = New System.Drawing.Size(76, 15)
        Me.lblFormName.TabIndex = 3
        Me.lblFormName.Text = "Form Name :"
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Location = New System.Drawing.Point(25, 20)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(50, 15)
        Me.lblUserID.TabIndex = 1
        Me.lblUserID.Text = "User ID :"
        '
        'FormReviewUserRight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(864, 581)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormReviewUserRight"
        Me.Text = "FORM REVIEW USER RIGHT"
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
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
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
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents lblFormName As Label
    Friend WithEvents lblUserID As Label
    Friend WithEvents cboUserID As ComboBox
    Friend WithEvents cboFormName As ComboBox
    Friend WithEvents cbCreate As CheckBox
    Friend WithEvents cbRead As CheckBox
    Friend WithEvents cbUpdate As CheckBox
    Friend WithEvents cbDelete As CheckBox
    Friend WithEvents cbPrint As CheckBox
End Class
