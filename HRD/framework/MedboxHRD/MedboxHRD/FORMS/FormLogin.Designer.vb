<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogin))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlLogin = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnMasuk = New System.Windows.Forms.Button()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.tbUserID = New System.Windows.Forms.TextBox()
        Me.pnlLogin.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(484, 22)
        Me.lblTitle.TabIndex = 118
        Me.lblTitle.Text = "LOGIN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlLogin
        '
        Me.pnlLogin.Controls.Add(Me.PictureBox1)
        Me.pnlLogin.Controls.Add(Me.btnKeluar)
        Me.pnlLogin.Controls.Add(Me.btnMasuk)
        Me.pnlLogin.Controls.Add(Me.lblPassword)
        Me.pnlLogin.Controls.Add(Me.tbPassword)
        Me.pnlLogin.Controls.Add(Me.lblUserID)
        Me.pnlLogin.Controls.Add(Me.tbUserID)
        Me.pnlLogin.Location = New System.Drawing.Point(12, 28)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(460, 160)
        Me.pnlLogin.TabIndex = 119
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(325, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(135, 154)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'btnKeluar
        '
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(216, 94)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(100, 54)
        Me.btnKeluar.TabIndex = 4
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnMasuk
        '
        Me.btnMasuk.Image = CType(resources.GetObject("btnMasuk.Image"), System.Drawing.Image)
        Me.btnMasuk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMasuk.Location = New System.Drawing.Point(110, 94)
        Me.btnMasuk.Name = "btnMasuk"
        Me.btnMasuk.Size = New System.Drawing.Size(100, 54)
        Me.btnMasuk.TabIndex = 3
        Me.btnMasuk.Text = "MASUK"
        Me.btnMasuk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMasuk.UseVisualStyleBackColor = True
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(34, 57)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(76, 13)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "PASSWORD :"
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(116, 54)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPassword.Size = New System.Drawing.Size(200, 20)
        Me.tbPassword.TabIndex = 2
        Me.tbPassword.Text = "YusakOS"
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Location = New System.Drawing.Point(53, 19)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(57, 13)
        Me.lblUserID.TabIndex = 1
        Me.lblUserID.Text = "USER ID :"
        '
        'tbUserID
        '
        Me.tbUserID.Location = New System.Drawing.Point(116, 16)
        Me.tbUserID.Name = "tbUserID"
        Me.tbUserID.Size = New System.Drawing.Size(200, 20)
        Me.tbUserID.TabIndex = 1
        Me.tbUserID.Text = "Yusak"
        '
        'FormLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(484, 201)
        Me.Controls.Add(Me.pnlLogin)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FORM LOGIN"
        Me.pnlLogin.ResumeLayout(False)
        Me.pnlLogin.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlLogin As Panel
    Friend WithEvents tbUserID As TextBox
    Friend WithEvents lblUserID As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents btnMasuk As Button
    Friend WithEvents btnKeluar As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
