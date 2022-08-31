<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReviewUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReviewUser))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.tbUsername = New System.Windows.Forms.TextBox()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
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
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbSemuaLokasi = New System.Windows.Forms.CheckBox()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.cboLokasi = New System.Windows.Forms.ComboBox()
        Me.gbDataEntry.SuspendLayout()
        Me.gbView.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(614, 25)
        Me.lblTitle.TabIndex = 9
        Me.lblTitle.Text = "REVIEW USER"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.Label4)
        Me.gbDataEntry.Controls.Add(Me.cbSemuaLokasi)
        Me.gbDataEntry.Controls.Add(Me.lblLokasi)
        Me.gbDataEntry.Controls.Add(Me.cboLokasi)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.btnKeluar)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.tbPassword)
        Me.gbDataEntry.Controls.Add(Me.lblUsername)
        Me.gbDataEntry.Controls.Add(Me.tbUsername)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(420, 170)
        Me.gbDataEntry.TabIndex = 10
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(302, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(393, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "*"
        '
        'btnKeluar
        '
        Me.btnKeluar.Location = New System.Drawing.Point(214, 109)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(100, 54)
        Me.btnKeluar.TabIndex = 4
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(108, 109)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(100, 54)
        Me.btnSimpan.TabIndex = 3
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Password :"
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(108, 51)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPassword.Size = New System.Drawing.Size(279, 23)
        Me.tbPassword.TabIndex = 2
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(36, 25)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(66, 15)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username :"
        '
        'tbUsername
        '
        Me.tbUsername.Location = New System.Drawing.Point(108, 22)
        Me.tbUsername.Name = "tbUsername"
        Me.tbUsername.ReadOnly = True
        Me.tbUsername.Size = New System.Drawing.Size(188, 23)
        Me.tbUsername.TabIndex = 1
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.Panel1)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.lblKriteria)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 204)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(587, 386)
        Me.gbView.TabIndex = 11
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblOfPages)
        Me.Panel1.Controls.Add(Me.btnAddNew)
        Me.Panel1.Controls.Add(Me.btnFFForward)
        Me.Panel1.Controls.Add(Me.btnForward)
        Me.Panel1.Controls.Add(Me.tbRecordPage)
        Me.Panel1.Controls.Add(Me.btnBack)
        Me.Panel1.Controls.Add(Me.btnFFBack)
        Me.Panel1.Controls.Add(Me.lblRecord)
        Me.Panel1.Location = New System.Drawing.Point(7, 349)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(415, 30)
        Me.Panel1.TabIndex = 7
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
        Me.btnTampilkan.Location = New System.Drawing.Point(384, 22)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(75, 23)
        Me.btnTampilkan.TabIndex = 7
        Me.btnTampilkan.Text = "Tampilkan"
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(190, 22)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(188, 23)
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
        Me.cboKriteria.TabIndex = 5
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
        Me.dgvView.Size = New System.Drawing.Size(579, 292)
        Me.dgvView.TabIndex = 0
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Location = New System.Drawing.Point(438, 50)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(100, 54)
        Me.btnCreateNew.TabIndex = 12
        Me.btnCreateNew.Text = "TAMBAH"
        Me.btnCreateNew.UseVisualStyleBackColor = True
        Me.btnCreateNew.Visible = False
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(438, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 13
        Me.lblEntryType.Text = "INSERT NEW"
        Me.lblEntryType.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(281, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "*"
        '
        'cbSemuaLokasi
        '
        Me.cbSemuaLokasi.AutoSize = True
        Me.cbSemuaLokasi.Location = New System.Drawing.Point(235, 82)
        Me.cbSemuaLokasi.Name = "cbSemuaLokasi"
        Me.cbSemuaLokasi.Size = New System.Drawing.Size(40, 19)
        Me.cbSemuaLokasi.TabIndex = 15
        Me.cbSemuaLokasi.Text = "All"
        Me.cbSemuaLokasi.UseVisualStyleBackColor = True
        '
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Location = New System.Drawing.Point(56, 83)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(46, 15)
        Me.lblLokasi.TabIndex = 14
        Me.lblLokasi.Text = "Lokasi :"
        '
        'cboLokasi
        '
        Me.cboLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasi.FormattingEnabled = True
        Me.cboLokasi.IntegralHeight = False
        Me.cboLokasi.Location = New System.Drawing.Point(108, 80)
        Me.cboLokasi.Name = "cboLokasi"
        Me.cboLokasi.Size = New System.Drawing.Size(121, 23)
        Me.cboLokasi.TabIndex = 13
        '
        'FormReviewUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(614, 601)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormReviewUser"
        Me.Text = "FORM REVIEW USER"
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents tbUsername As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents gbView As GroupBox
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents lblKriteria As Label
    Friend WithEvents tbCari As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lblRecord As Label
    Friend WithEvents btnFFBack As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnForward As Button
    Friend WithEvents btnFFForward As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents lblOfPages As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents lblEntryType As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbSemuaLokasi As CheckBox
    Friend WithEvents lblLokasi As Label
    Friend WithEvents cboLokasi As ComboBox
End Class
