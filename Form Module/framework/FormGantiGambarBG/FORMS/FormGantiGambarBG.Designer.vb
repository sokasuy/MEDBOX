<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGantiGambarBG
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGantiGambarBG))
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.tbBrowseGambar = New System.Windows.Forms.TextBox()
        Me.lblBrowse = New System.Windows.Forms.Label()
        Me.pbBG = New System.Windows.Forms.PictureBox()
        Me.lstBG = New System.Windows.Forms.ListBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.ofdPic = New System.Windows.Forms.OpenFileDialog()
        Me.lblGbrBG = New System.Windows.Forms.Label()
        CType(Me.pbBG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(321, 454)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 95
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'tbBrowseGambar
        '
        Me.tbBrowseGambar.Location = New System.Drawing.Point(70, 456)
        Me.tbBrowseGambar.Name = "tbBrowseGambar"
        Me.tbBrowseGambar.Size = New System.Drawing.Size(253, 20)
        Me.tbBrowseGambar.TabIndex = 94
        '
        'lblBrowse
        '
        Me.lblBrowse.AutoSize = True
        Me.lblBrowse.Location = New System.Drawing.Point(16, 459)
        Me.lblBrowse.Name = "lblBrowse"
        Me.lblBrowse.Size = New System.Drawing.Size(48, 13)
        Me.lblBrowse.TabIndex = 93
        Me.lblBrowse.Text = "Browse :"
        '
        'pbBG
        '
        Me.pbBG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbBG.Location = New System.Drawing.Point(398, 43)
        Me.pbBG.Name = "pbBG"
        Me.pbBG.Size = New System.Drawing.Size(630, 407)
        Me.pbBG.TabIndex = 92
        Me.pbBG.TabStop = False
        '
        'lstBG
        '
        Me.lstBG.FormattingEnabled = True
        Me.lstBG.Location = New System.Drawing.Point(15, 43)
        Me.lstBG.Name = "lstBG"
        Me.lstBG.Size = New System.Drawing.Size(377, 407)
        Me.lstBG.TabIndex = 91
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.PowderBlue
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1034, 23)
        Me.lblTitle.TabIndex = 89
        Me.lblTitle.Text = "GANTI GAMBAR BACKGROUND"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ofdPic
        '
        '
        'lblGbrBG
        '
        Me.lblGbrBG.AutoSize = True
        Me.lblGbrBG.Location = New System.Drawing.Point(12, 27)
        Me.lblGbrBG.Name = "lblGbrBG"
        Me.lblGbrBG.Size = New System.Drawing.Size(105, 13)
        Me.lblGbrBG.TabIndex = 90
        Me.lblGbrBG.Text = "Gambar Background"
        '
        'FormGantiGambarBG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1034, 481)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.tbBrowseGambar)
        Me.Controls.Add(Me.lblBrowse)
        Me.Controls.Add(Me.pbBG)
        Me.Controls.Add(Me.lstBG)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblGbrBG)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormGantiGambarBG"
        Me.Text = "FORM GANTI GAMBAR BACKGROUND"
        CType(Me.pbBG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBrowse As Button
    Friend WithEvents tbBrowseGambar As TextBox
    Friend WithEvents lblBrowse As Label
    Friend WithEvents pbBG As PictureBox
    Friend WithEvents lstBG As ListBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents ofdPic As OpenFileDialog
    Friend WithEvents lblGbrBG As Label
End Class
