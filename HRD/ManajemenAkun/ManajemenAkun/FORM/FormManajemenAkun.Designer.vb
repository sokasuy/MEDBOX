<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormManajemenAkun
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormManajemenAkun))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnRegisterNewUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnReviewUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnReviewUserRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnUser})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnUser
        '
        Me.mnUser.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnRegisterNewUser, Me.mnReviewUser, Me.mnReviewUserRight})
        Me.mnUser.Name = "mnUser"
        Me.mnUser.Size = New System.Drawing.Size(46, 20)
        Me.mnUser.Text = "USER"
        '
        'mnRegisterNewUser
        '
        Me.mnRegisterNewUser.Name = "mnRegisterNewUser"
        Me.mnRegisterNewUser.Size = New System.Drawing.Size(180, 22)
        Me.mnRegisterNewUser.Text = "Register New User"
        '
        'mnReviewUser
        '
        Me.mnReviewUser.Name = "mnReviewUser"
        Me.mnReviewUser.Size = New System.Drawing.Size(180, 22)
        Me.mnReviewUser.Text = "Review User"
        '
        'mnReviewUserRight
        '
        Me.mnReviewUserRight.Name = "mnReviewUserRight"
        Me.mnReviewUserRight.Size = New System.Drawing.Size(180, 22)
        Me.mnReviewUserRight.Text = "Review User Right"
        '
        'FormManajemenAkun
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormManajemenAkun"
        Me.Text = "MANAJEMEN AKUN"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnUser As ToolStripMenuItem
    Friend WithEvents mnRegisterNewUser As ToolStripMenuItem
    Friend WithEvents mnReviewUser As ToolStripMenuItem
    Friend WithEvents mnReviewUserRight As ToolStripMenuItem
End Class
