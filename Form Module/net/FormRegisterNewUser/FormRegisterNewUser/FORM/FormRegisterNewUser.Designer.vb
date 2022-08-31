<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRegisterNewUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRegisterNewUser))
        Me.tbUserID = New System.Windows.Forms.TextBox()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.cbSuperuser = New System.Windows.Forms.CheckBox()
        Me.cboLokasi = New System.Windows.Forms.ComboBox()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.cbSemuaLokasi = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbUserID
        '
        Me.tbUserID.Location = New System.Drawing.Point(90, 28)
        Me.tbUserID.Name = "tbUserID"
        Me.tbUserID.Size = New System.Drawing.Size(151, 23)
        Me.tbUserID.TabIndex = 1
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Location = New System.Drawing.Point(34, 31)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(50, 15)
        Me.lblUserID.TabIndex = 1
        Me.lblUserID.Text = "User ID :"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(21, 60)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(63, 15)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Password :"
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(90, 57)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPassword.Size = New System.Drawing.Size(212, 23)
        Me.tbPassword.TabIndex = 2
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(90, 143)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(100, 54)
        Me.btnSimpan.TabIndex = 5
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnKeluar
        '
        Me.btnKeluar.Location = New System.Drawing.Point(196, 143)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(100, 54)
        Me.btnKeluar.TabIndex = 6
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(247, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(308, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "*"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.PowderBlue
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(354, 25)
        Me.lblTitle.TabIndex = 8
        Me.lblTitle.Text = "REGISTER NEW USER"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbSuperuser
        '
        Me.cbSuperuser.AutoSize = True
        Me.cbSuperuser.Location = New System.Drawing.Point(90, 118)
        Me.cbSuperuser.Name = "cbSuperuser"
        Me.cbSuperuser.Size = New System.Drawing.Size(78, 19)
        Me.cbSuperuser.TabIndex = 4
        Me.cbSuperuser.Text = "Superuser"
        Me.cbSuperuser.UseVisualStyleBackColor = True
        '
        'cboLokasi
        '
        Me.cboLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasi.FormattingEnabled = True
        Me.cboLokasi.IntegralHeight = False
        Me.cboLokasi.Location = New System.Drawing.Point(90, 86)
        Me.cboLokasi.Name = "cboLokasi"
        Me.cboLokasi.Size = New System.Drawing.Size(121, 23)
        Me.cboLokasi.TabIndex = 3
        '
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Location = New System.Drawing.Point(38, 89)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(46, 15)
        Me.lblLokasi.TabIndex = 10
        Me.lblLokasi.Text = "Lokasi :"
        '
        'cbSemuaLokasi
        '
        Me.cbSemuaLokasi.AutoSize = True
        Me.cbSemuaLokasi.Location = New System.Drawing.Point(217, 88)
        Me.cbSemuaLokasi.Name = "cbSemuaLokasi"
        Me.cbSemuaLokasi.Size = New System.Drawing.Size(40, 19)
        Me.cbSemuaLokasi.TabIndex = 11
        Me.cbSemuaLokasi.Text = "All"
        Me.cbSemuaLokasi.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(263, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "*"
        '
        'FormRegisterNewUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(354, 201)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbSemuaLokasi)
        Me.Controls.Add(Me.lblLokasi)
        Me.Controls.Add(Me.cboLokasi)
        Me.Controls.Add(Me.cbSuperuser)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.tbPassword)
        Me.Controls.Add(Me.lblUserID)
        Me.Controls.Add(Me.tbUserID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormRegisterNewUser"
        Me.Text = "FORM REGISTER NEW USER"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbUserID As TextBox
    Friend WithEvents lblUserID As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnKeluar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents cbSuperuser As CheckBox
    Friend WithEvents cboLokasi As ComboBox
    Friend WithEvents lblLokasi As Label
    Friend WithEvents cbSemuaLokasi As CheckBox
    Friend WithEvents Label3 As Label
End Class
