<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormImportData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormImportData))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.gbImportExcel = New System.Windows.Forms.GroupBox()
        Me.lblJumlahTanggungan = New System.Windows.Forms.Label()
        Me.tbJumlahTanggungan = New System.Windows.Forms.TextBox()
        Me.btnUpdateData = New System.Windows.Forms.Button()
        Me.pnlPilihanImport = New System.Windows.Forms.Panel()
        Me.rbNomerBPJSKesehatan = New System.Windows.Forms.RadioButton()
        Me.rbKomponenPayroll = New System.Windows.Forms.RadioButton()
        Me.rbKaryawan = New System.Windows.Forms.RadioButton()
        Me.tbNamaFile = New System.Windows.Forms.TextBox()
        Me.btnProsesImport = New System.Windows.Forms.Button()
        Me.lblNamaFile = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblNamaSheet = New System.Windows.Forms.Label()
        Me.tbNamaSheet = New System.Windows.Forms.TextBox()
        Me.rbStatusKepegawaian = New System.Windows.Forms.RadioButton()
        Me.gbImportExcel.SuspendLayout()
        Me.pnlPilihanImport.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(616, 25)
        Me.lblTitle.TabIndex = 178
        Me.lblTitle.Text = "IMPORT DATA"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ofd1
        '
        '
        'gbImportExcel
        '
        Me.gbImportExcel.Controls.Add(Me.lblJumlahTanggungan)
        Me.gbImportExcel.Controls.Add(Me.tbJumlahTanggungan)
        Me.gbImportExcel.Controls.Add(Me.btnUpdateData)
        Me.gbImportExcel.Controls.Add(Me.pnlPilihanImport)
        Me.gbImportExcel.Controls.Add(Me.tbNamaFile)
        Me.gbImportExcel.Controls.Add(Me.btnProsesImport)
        Me.gbImportExcel.Controls.Add(Me.lblNamaFile)
        Me.gbImportExcel.Controls.Add(Me.btnBrowse)
        Me.gbImportExcel.Controls.Add(Me.lblNamaSheet)
        Me.gbImportExcel.Controls.Add(Me.tbNamaSheet)
        Me.gbImportExcel.Location = New System.Drawing.Point(12, 28)
        Me.gbImportExcel.Name = "gbImportExcel"
        Me.gbImportExcel.Size = New System.Drawing.Size(599, 161)
        Me.gbImportExcel.TabIndex = 195
        Me.gbImportExcel.TabStop = False
        Me.gbImportExcel.Text = "IMPORT EXCEL"
        '
        'lblJumlahTanggungan
        '
        Me.lblJumlahTanggungan.AutoSize = True
        Me.lblJumlahTanggungan.Location = New System.Drawing.Point(341, 42)
        Me.lblJumlahTanggungan.Name = "lblJumlahTanggungan"
        Me.lblJumlahTanggungan.Size = New System.Drawing.Size(110, 13)
        Me.lblJumlahTanggungan.TabIndex = 114
        Me.lblJumlahTanggungan.Text = "Jumlah Tanggungan :"
        '
        'tbJumlahTanggungan
        '
        Me.tbJumlahTanggungan.Location = New System.Drawing.Point(457, 39)
        Me.tbJumlahTanggungan.Name = "tbJumlahTanggungan"
        Me.tbJumlahTanggungan.Size = New System.Drawing.Size(58, 20)
        Me.tbJumlahTanggungan.TabIndex = 3
        Me.tbJumlahTanggungan.Text = "5"
        Me.tbJumlahTanggungan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnUpdateData
        '
        Me.btnUpdateData.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdateData.Image = CType(resources.GetObject("btnUpdateData.Image"), System.Drawing.Image)
        Me.btnUpdateData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateData.Location = New System.Drawing.Point(407, 97)
        Me.btnUpdateData.Name = "btnUpdateData"
        Me.btnUpdateData.Size = New System.Drawing.Size(138, 54)
        Me.btnUpdateData.TabIndex = 112
        Me.btnUpdateData.Text = "Update Data"
        Me.btnUpdateData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdateData.UseVisualStyleBackColor = True
        Me.btnUpdateData.Visible = False
        '
        'pnlPilihanImport
        '
        Me.pnlPilihanImport.Controls.Add(Me.rbStatusKepegawaian)
        Me.pnlPilihanImport.Controls.Add(Me.rbNomerBPJSKesehatan)
        Me.pnlPilihanImport.Controls.Add(Me.rbKomponenPayroll)
        Me.pnlPilihanImport.Controls.Add(Me.rbKaryawan)
        Me.pnlPilihanImport.Location = New System.Drawing.Point(104, 65)
        Me.pnlPilihanImport.Name = "pnlPilihanImport"
        Me.pnlPilihanImport.Size = New System.Drawing.Size(491, 26)
        Me.pnlPilihanImport.TabIndex = 111
        '
        'rbNomerBPJSKesehatan
        '
        Me.rbNomerBPJSKesehatan.AutoSize = True
        Me.rbNomerBPJSKesehatan.Location = New System.Drawing.Point(232, 4)
        Me.rbNomerBPJSKesehatan.Name = "rbNomerBPJSKesehatan"
        Me.rbNomerBPJSKesehatan.Size = New System.Drawing.Size(139, 17)
        Me.rbNomerBPJSKesehatan.TabIndex = 7
        Me.rbNomerBPJSKesehatan.Text = "Nomer BPJS Kesehatan"
        Me.rbNomerBPJSKesehatan.UseVisualStyleBackColor = True
        '
        'rbKomponenPayroll
        '
        Me.rbKomponenPayroll.AutoSize = True
        Me.rbKomponenPayroll.Location = New System.Drawing.Point(116, 4)
        Me.rbKomponenPayroll.Name = "rbKomponenPayroll"
        Me.rbKomponenPayroll.Size = New System.Drawing.Size(110, 17)
        Me.rbKomponenPayroll.TabIndex = 5
        Me.rbKomponenPayroll.Text = "Komponen Payroll"
        Me.rbKomponenPayroll.UseVisualStyleBackColor = True
        '
        'rbKaryawan
        '
        Me.rbKaryawan.AutoSize = True
        Me.rbKaryawan.Location = New System.Drawing.Point(3, 4)
        Me.rbKaryawan.Name = "rbKaryawan"
        Me.rbKaryawan.Size = New System.Drawing.Size(107, 17)
        Me.rbKaryawan.TabIndex = 4
        Me.rbKaryawan.Text = "Master Karyawan"
        Me.rbKaryawan.UseVisualStyleBackColor = True
        '
        'tbNamaFile
        '
        Me.tbNamaFile.Location = New System.Drawing.Point(104, 13)
        Me.tbNamaFile.Name = "tbNamaFile"
        Me.tbNamaFile.Size = New System.Drawing.Size(411, 20)
        Me.tbNamaFile.TabIndex = 1
        '
        'btnProsesImport
        '
        Me.btnProsesImport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnProsesImport.Image = CType(resources.GetObject("btnProsesImport.Image"), System.Drawing.Image)
        Me.btnProsesImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProsesImport.Location = New System.Drawing.Point(104, 97)
        Me.btnProsesImport.Name = "btnProsesImport"
        Me.btnProsesImport.Size = New System.Drawing.Size(120, 54)
        Me.btnProsesImport.TabIndex = 5
        Me.btnProsesImport.Text = "IMPORT"
        Me.btnProsesImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesImport.UseVisualStyleBackColor = True
        '
        'lblNamaFile
        '
        Me.lblNamaFile.AutoSize = True
        Me.lblNamaFile.Location = New System.Drawing.Point(9, 16)
        Me.lblNamaFile.Name = "lblNamaFile"
        Me.lblNamaFile.Size = New System.Drawing.Size(89, 13)
        Me.lblNamaFile.TabIndex = 108
        Me.lblNamaFile.Text = "Nama File Excel :"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(521, 11)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblNamaSheet
        '
        Me.lblNamaSheet.AutoSize = True
        Me.lblNamaSheet.Location = New System.Drawing.Point(26, 42)
        Me.lblNamaSheet.Name = "lblNamaSheet"
        Me.lblNamaSheet.Size = New System.Drawing.Size(72, 13)
        Me.lblNamaSheet.TabIndex = 109
        Me.lblNamaSheet.Text = "Nama Sheet :"
        '
        'tbNamaSheet
        '
        Me.tbNamaSheet.Location = New System.Drawing.Point(104, 39)
        Me.tbNamaSheet.Name = "tbNamaSheet"
        Me.tbNamaSheet.Size = New System.Drawing.Size(183, 20)
        Me.tbNamaSheet.TabIndex = 2
        Me.tbNamaSheet.Text = "Sheet1"
        '
        'rbStatusKepegawaian
        '
        Me.rbStatusKepegawaian.AutoSize = True
        Me.rbStatusKepegawaian.Location = New System.Drawing.Point(377, 4)
        Me.rbStatusKepegawaian.Name = "rbStatusKepegawaian"
        Me.rbStatusKepegawaian.Size = New System.Drawing.Size(101, 17)
        Me.rbStatusKepegawaian.TabIndex = 8
        Me.rbStatusKepegawaian.Text = "Kontrak / Tetap"
        Me.rbStatusKepegawaian.UseVisualStyleBackColor = True
        '
        'FormImportData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(616, 199)
        Me.Controls.Add(Me.gbImportExcel)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormImportData"
        Me.Text = "FORM IMPORT DATA"
        Me.gbImportExcel.ResumeLayout(False)
        Me.gbImportExcel.PerformLayout()
        Me.pnlPilihanImport.ResumeLayout(False)
        Me.pnlPilihanImport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents ofd1 As OpenFileDialog
    Friend WithEvents gbImportExcel As GroupBox
    Friend WithEvents tbNamaFile As TextBox
    Friend WithEvents btnProsesImport As Button
    Friend WithEvents lblNamaFile As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents lblNamaSheet As Label
    Friend WithEvents tbNamaSheet As TextBox
    Friend WithEvents rbKaryawan As RadioButton
    Friend WithEvents pnlPilihanImport As Panel
    Friend WithEvents btnUpdateData As Button
    Friend WithEvents lblJumlahTanggungan As Label
    Friend WithEvents tbJumlahTanggungan As TextBox
    Friend WithEvents rbKomponenPayroll As RadioButton
    Friend WithEvents rbNomerBPJSKesehatan As RadioButton
    Friend WithEvents rbStatusKepegawaian As RadioButton
End Class
