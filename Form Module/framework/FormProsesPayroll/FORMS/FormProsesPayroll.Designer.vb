<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProsesPayroll
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProsesPayroll))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPerusahaan = New System.Windows.Forms.ComboBox()
        Me.lblPerusahaanGlobal = New System.Windows.Forms.Label()
        Me.pnlKelompok = New System.Windows.Forms.Panel()
        Me.rbOutsource = New System.Windows.Forms.RadioButton()
        Me.rbNonStaff = New System.Windows.Forms.RadioButton()
        Me.rbStaff = New System.Windows.Forms.RadioButton()
        Me.btnProsesSemua = New System.Windows.Forms.Button()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.lblCatatanHRD = New System.Windows.Forms.Label()
        Me.rtbCatatanHRD = New System.Windows.Forms.RichTextBox()
        Me.lblFaktorQty = New System.Windows.Forms.Label()
        Me.cboFaktorQty = New System.Windows.Forms.ComboBox()
        Me.lblKeterangan = New System.Windows.Forms.Label()
        Me.rtbLain2 = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbLain2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbBagianIndividu = New System.Windows.Forms.TextBox()
        Me.lblBagianIndividu = New System.Windows.Forms.Label()
        Me.tbDivisiIndividu = New System.Windows.Forms.TextBox()
        Me.lblDivisiIndividu = New System.Windows.Forms.Label()
        Me.lblPerusahaanIndividu = New System.Windows.Forms.Label()
        Me.rptViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tbDepartemenIndividu = New System.Windows.Forms.TextBox()
        Me.btnProsesIndividu = New System.Windows.Forms.Button()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.cboKaryawanIndividu = New System.Windows.Forms.ComboBox()
        Me.lblKaryawanIndividu = New System.Windows.Forms.Label()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.cboLokasi = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.dtpPeriodeSelesai = New System.Windows.Forms.DateTimePicker()
        Me.lblPeriode = New System.Windows.Forms.Label()
        Me.dtpPeriodeMulai = New System.Windows.Forms.DateTimePicker()
        Me.btnCetakRekap = New System.Windows.Forms.Button()
        Me.cboKuartal = New System.Windows.Forms.ComboBox()
        Me.cboPeriode = New System.Windows.Forms.ComboBox()
        Me.pnlKelompok.SuspendLayout()
        Me.gbView.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
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
        Me.lblTitle.TabIndex = 180
        Me.lblTitle.Text = "PROSES PAYROLL"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(335, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 215
        Me.Label2.Text = "*"
        '
        'cboPerusahaan
        '
        Me.cboPerusahaan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPerusahaan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPerusahaan.FormattingEnabled = True
        Me.cboPerusahaan.IntegralHeight = False
        Me.cboPerusahaan.Location = New System.Drawing.Point(111, 49)
        Me.cboPerusahaan.Name = "cboPerusahaan"
        Me.cboPerusahaan.Size = New System.Drawing.Size(218, 21)
        Me.cboPerusahaan.TabIndex = 3
        '
        'lblPerusahaanGlobal
        '
        Me.lblPerusahaanGlobal.AutoSize = True
        Me.lblPerusahaanGlobal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPerusahaanGlobal.Location = New System.Drawing.Point(31, 52)
        Me.lblPerusahaanGlobal.Name = "lblPerusahaanGlobal"
        Me.lblPerusahaanGlobal.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaanGlobal.TabIndex = 214
        Me.lblPerusahaanGlobal.Text = "Perusahaan :"
        '
        'pnlKelompok
        '
        Me.pnlKelompok.Controls.Add(Me.rbOutsource)
        Me.pnlKelompok.Controls.Add(Me.rbNonStaff)
        Me.pnlKelompok.Controls.Add(Me.rbStaff)
        Me.pnlKelompok.Location = New System.Drawing.Point(111, 71)
        Me.pnlKelompok.Name = "pnlKelompok"
        Me.pnlKelompok.Size = New System.Drawing.Size(277, 25)
        Me.pnlKelompok.TabIndex = 230
        '
        'rbOutsource
        '
        Me.rbOutsource.AutoSize = True
        Me.rbOutsource.Enabled = False
        Me.rbOutsource.Location = New System.Drawing.Point(183, 3)
        Me.rbOutsource.Name = "rbOutsource"
        Me.rbOutsource.Size = New System.Drawing.Size(93, 17)
        Me.rbOutsource.TabIndex = 4
        Me.rbOutsource.Text = "OUTSOURCE"
        Me.rbOutsource.UseVisualStyleBackColor = True
        '
        'rbNonStaff
        '
        Me.rbNonStaff.AutoSize = True
        Me.rbNonStaff.Location = New System.Drawing.Point(84, 3)
        Me.rbNonStaff.Name = "rbNonStaff"
        Me.rbNonStaff.Size = New System.Drawing.Size(85, 17)
        Me.rbNonStaff.TabIndex = 3
        Me.rbNonStaff.Text = "NON STAFF"
        Me.rbNonStaff.UseVisualStyleBackColor = True
        '
        'rbStaff
        '
        Me.rbStaff.AutoSize = True
        Me.rbStaff.Enabled = False
        Me.rbStaff.Location = New System.Drawing.Point(3, 3)
        Me.rbStaff.Name = "rbStaff"
        Me.rbStaff.Size = New System.Drawing.Size(58, 17)
        Me.rbStaff.TabIndex = 2
        Me.rbStaff.Text = "STAFF"
        Me.rbStaff.UseVisualStyleBackColor = True
        '
        'btnProsesSemua
        '
        Me.btnProsesSemua.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnProsesSemua.Image = CType(resources.GetObject("btnProsesSemua.Image"), System.Drawing.Image)
        Me.btnProsesSemua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProsesSemua.Location = New System.Drawing.Point(673, 28)
        Me.btnProsesSemua.Name = "btnProsesSemua"
        Me.btnProsesSemua.Size = New System.Drawing.Size(145, 54)
        Me.btnProsesSemua.TabIndex = 11
        Me.btnProsesSemua.Text = "PROSES SEMUA"
        Me.btnProsesSemua.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesSemua.UseVisualStyleBackColor = True
        '
        'gbView
        '
        Me.gbView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.lblCatatanHRD)
        Me.gbView.Controls.Add(Me.rtbCatatanHRD)
        Me.gbView.Controls.Add(Me.lblFaktorQty)
        Me.gbView.Controls.Add(Me.cboFaktorQty)
        Me.gbView.Controls.Add(Me.lblKeterangan)
        Me.gbView.Controls.Add(Me.rtbLain2)
        Me.gbView.Controls.Add(Me.Label6)
        Me.gbView.Controls.Add(Me.Label4)
        Me.gbView.Controls.Add(Me.Label1)
        Me.gbView.Controls.Add(Me.tbLain2)
        Me.gbView.Controls.Add(Me.Label5)
        Me.gbView.Controls.Add(Me.tbBagianIndividu)
        Me.gbView.Controls.Add(Me.lblBagianIndividu)
        Me.gbView.Controls.Add(Me.tbDivisiIndividu)
        Me.gbView.Controls.Add(Me.lblDivisiIndividu)
        Me.gbView.Controls.Add(Me.lblPerusahaanIndividu)
        Me.gbView.Controls.Add(Me.rptViewer)
        Me.gbView.Controls.Add(Me.tbDepartemenIndividu)
        Me.gbView.Controls.Add(Me.btnProsesIndividu)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.cboKaryawanIndividu)
        Me.gbView.Controls.Add(Me.lblKaryawanIndividu)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Location = New System.Drawing.Point(12, 98)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(960, 540)
        Me.gbView.TabIndex = 232
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'lblCatatanHRD
        '
        Me.lblCatatanHRD.AutoSize = True
        Me.lblCatatanHRD.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCatatanHRD.Location = New System.Drawing.Point(12, 118)
        Me.lblCatatanHRD.Name = "lblCatatanHRD"
        Me.lblCatatanHRD.Size = New System.Drawing.Size(81, 15)
        Me.lblCatatanHRD.TabIndex = 256
        Me.lblCatatanHRD.Text = "Catatan HRD :"
        '
        'rtbCatatanHRD
        '
        Me.rtbCatatanHRD.Location = New System.Drawing.Point(99, 116)
        Me.rtbCatatanHRD.Name = "rtbCatatanHRD"
        Me.rtbCatatanHRD.Size = New System.Drawing.Size(472, 56)
        Me.rtbCatatanHRD.TabIndex = 255
        Me.rtbCatatanHRD.Text = ""
        '
        'lblFaktorQty
        '
        Me.lblFaktorQty.AutoSize = True
        Me.lblFaktorQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFaktorQty.Location = New System.Drawing.Point(307, 61)
        Me.lblFaktorQty.Name = "lblFaktorQty"
        Me.lblFaktorQty.Size = New System.Drawing.Size(68, 15)
        Me.lblFaktorQty.TabIndex = 251
        Me.lblFaktorQty.Text = "Faktor Qty :"
        '
        'cboFaktorQty
        '
        Me.cboFaktorQty.FormattingEnabled = True
        Me.cboFaktorQty.Location = New System.Drawing.Point(381, 58)
        Me.cboFaktorQty.Name = "cboFaktorQty"
        Me.cboFaktorQty.Size = New System.Drawing.Size(121, 21)
        Me.cboFaktorQty.TabIndex = 7
        '
        'lblKeterangan
        '
        Me.lblKeterangan.AutoSize = True
        Me.lblKeterangan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKeterangan.Location = New System.Drawing.Point(20, 83)
        Me.lblKeterangan.Name = "lblKeterangan"
        Me.lblKeterangan.Size = New System.Drawing.Size(73, 15)
        Me.lblKeterangan.TabIndex = 249
        Me.lblKeterangan.Text = "Keterangan :"
        '
        'rtbLain2
        '
        Me.rtbLain2.Location = New System.Drawing.Point(99, 81)
        Me.rtbLain2.Name = "rtbLain2"
        Me.rtbLain2.Size = New System.Drawing.Size(472, 32)
        Me.rtbLain2.TabIndex = 8
        Me.rtbLain2.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(83, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 15)
        Me.Label6.TabIndex = 247
        Me.Label6.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(29, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 15)
        Me.Label4.TabIndex = 246
        Me.Label4.Text = "Lain2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(15, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 245
        Me.Label1.Text = "Tambahkan"
        '
        'tbLain2
        '
        Me.tbLain2.Location = New System.Drawing.Point(99, 59)
        Me.tbLain2.Name = "tbLain2"
        Me.tbLain2.Size = New System.Drawing.Size(164, 20)
        Me.tbLain2.TabIndex = 6
        Me.tbLain2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(548, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 15)
        Me.Label5.TabIndex = 236
        Me.Label5.Text = "*"
        '
        'tbBagianIndividu
        '
        Me.tbBagianIndividu.Location = New System.Drawing.Point(414, 37)
        Me.tbBagianIndividu.Name = "tbBagianIndividu"
        Me.tbBagianIndividu.ReadOnly = True
        Me.tbBagianIndividu.Size = New System.Drawing.Size(157, 20)
        Me.tbBagianIndividu.TabIndex = 243
        '
        'lblBagianIndividu
        '
        Me.lblBagianIndividu.AutoSize = True
        Me.lblBagianIndividu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBagianIndividu.Location = New System.Drawing.Point(359, 39)
        Me.lblBagianIndividu.Name = "lblBagianIndividu"
        Me.lblBagianIndividu.Size = New System.Drawing.Size(49, 15)
        Me.lblBagianIndividu.TabIndex = 242
        Me.lblBagianIndividu.Text = "Bagian :"
        '
        'tbDivisiIndividu
        '
        Me.tbDivisiIndividu.Location = New System.Drawing.Point(255, 37)
        Me.tbDivisiIndividu.Name = "tbDivisiIndividu"
        Me.tbDivisiIndividu.ReadOnly = True
        Me.tbDivisiIndividu.Size = New System.Drawing.Size(99, 20)
        Me.tbDivisiIndividu.TabIndex = 241
        '
        'lblDivisiIndividu
        '
        Me.lblDivisiIndividu.AutoSize = True
        Me.lblDivisiIndividu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDivisiIndividu.Location = New System.Drawing.Point(208, 39)
        Me.lblDivisiIndividu.Name = "lblDivisiIndividu"
        Me.lblDivisiIndividu.Size = New System.Drawing.Size(41, 15)
        Me.lblDivisiIndividu.TabIndex = 240
        Me.lblDivisiIndividu.Text = "Divisi :"
        '
        'lblPerusahaanIndividu
        '
        Me.lblPerusahaanIndividu.AutoSize = True
        Me.lblPerusahaanIndividu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPerusahaanIndividu.Location = New System.Drawing.Point(15, 39)
        Me.lblPerusahaanIndividu.Name = "lblPerusahaanIndividu"
        Me.lblPerusahaanIndividu.Size = New System.Drawing.Size(78, 15)
        Me.lblPerusahaanIndividu.TabIndex = 235
        Me.lblPerusahaanIndividu.Text = "Departemen :"
        '
        'rptViewer
        '
        Me.rptViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rptViewer.Location = New System.Drawing.Point(6, 176)
        Me.rptViewer.Name = "rptViewer"
        Me.rptViewer.ServerReport.BearerToken = Nothing
        Me.rptViewer.Size = New System.Drawing.Size(948, 323)
        Me.rptViewer.TabIndex = 234
        '
        'tbDepartemenIndividu
        '
        Me.tbDepartemenIndividu.Location = New System.Drawing.Point(99, 37)
        Me.tbDepartemenIndividu.Name = "tbDepartemenIndividu"
        Me.tbDepartemenIndividu.ReadOnly = True
        Me.tbDepartemenIndividu.Size = New System.Drawing.Size(107, 20)
        Me.tbDepartemenIndividu.TabIndex = 233
        '
        'btnProsesIndividu
        '
        Me.btnProsesIndividu.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnProsesIndividu.Image = CType(resources.GetObject("btnProsesIndividu.Image"), System.Drawing.Image)
        Me.btnProsesIndividu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProsesIndividu.Location = New System.Drawing.Point(719, 15)
        Me.btnProsesIndividu.Name = "btnProsesIndividu"
        Me.btnProsesIndividu.Size = New System.Drawing.Size(200, 54)
        Me.btnProsesIndividu.TabIndex = 10
        Me.btnProsesIndividu.Text = "PROSES PER KARYAWAN"
        Me.btnProsesIndividu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesIndividu.UseVisualStyleBackColor = True
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(593, 15)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 9
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'cboKaryawanIndividu
        '
        Me.cboKaryawanIndividu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawanIndividu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawanIndividu.FormattingEnabled = True
        Me.cboKaryawanIndividu.IntegralHeight = False
        Me.cboKaryawanIndividu.Location = New System.Drawing.Point(99, 15)
        Me.cboKaryawanIndividu.Name = "cboKaryawanIndividu"
        Me.cboKaryawanIndividu.Size = New System.Drawing.Size(443, 21)
        Me.cboKaryawanIndividu.TabIndex = 5
        '
        'lblKaryawanIndividu
        '
        Me.lblKaryawanIndividu.AutoSize = True
        Me.lblKaryawanIndividu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKaryawanIndividu.Location = New System.Drawing.Point(29, 17)
        Me.lblKaryawanIndividu.Name = "lblKaryawanIndividu"
        Me.lblKaryawanIndividu.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawanIndividu.TabIndex = 174
        Me.lblKaryawanIndividu.Text = "Karyawan :"
        '
        'pnlNavigasi
        '
        Me.pnlNavigasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlNavigasi.Controls.Add(Me.btnAddNew)
        Me.pnlNavigasi.Controls.Add(Me.btnFFBack)
        Me.pnlNavigasi.Controls.Add(Me.lblRecord)
        Me.pnlNavigasi.Controls.Add(Me.btnForward)
        Me.pnlNavigasi.Controls.Add(Me.lblOfPages)
        Me.pnlNavigasi.Controls.Add(Me.tbRecordPage)
        Me.pnlNavigasi.Controls.Add(Me.btnFFForward)
        Me.pnlNavigasi.Controls.Add(Me.btnBack)
        Me.pnlNavigasi.Location = New System.Drawing.Point(6, 505)
        Me.pnlNavigasi.Name = "pnlNavigasi"
        Me.pnlNavigasi.Size = New System.Drawing.Size(425, 29)
        Me.pnlNavigasi.TabIndex = 172
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
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Location = New System.Drawing.Point(358, 52)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(44, 13)
        Me.lblLokasi.TabIndex = 234
        Me.lblLokasi.Text = "Lokasi :"
        '
        'cboLokasi
        '
        Me.cboLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasi.FormattingEnabled = True
        Me.cboLokasi.IntegralHeight = False
        Me.cboLokasi.Location = New System.Drawing.Point(408, 49)
        Me.cboLokasi.Name = "cboLokasi"
        Me.cboLokasi.Size = New System.Drawing.Size(146, 21)
        Me.cboLokasi.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(560, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 235
        Me.Label3.Text = "*"
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(407, 34)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(21, 13)
        Me.lblSD.TabIndex = 239
        Me.lblSD.Text = "s.d"
        '
        'dtpPeriodeSelesai
        '
        Me.dtpPeriodeSelesai.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPeriodeSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodeSelesai.Location = New System.Drawing.Point(434, 28)
        Me.dtpPeriodeSelesai.Name = "dtpPeriodeSelesai"
        Me.dtpPeriodeSelesai.Size = New System.Drawing.Size(120, 20)
        Me.dtpPeriodeSelesai.TabIndex = 2
        '
        'lblPeriode
        '
        Me.lblPeriode.AutoSize = True
        Me.lblPeriode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPeriode.Location = New System.Drawing.Point(52, 33)
        Me.lblPeriode.Name = "lblPeriode"
        Me.lblPeriode.Size = New System.Drawing.Size(53, 15)
        Me.lblPeriode.TabIndex = 238
        Me.lblPeriode.Text = "Periode :"
        '
        'dtpPeriodeMulai
        '
        Me.dtpPeriodeMulai.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPeriodeMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodeMulai.Location = New System.Drawing.Point(281, 28)
        Me.dtpPeriodeMulai.Name = "dtpPeriodeMulai"
        Me.dtpPeriodeMulai.Size = New System.Drawing.Size(120, 20)
        Me.dtpPeriodeMulai.TabIndex = 1
        '
        'btnCetakRekap
        '
        Me.btnCetakRekap.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCetakRekap.Image = CType(resources.GetObject("btnCetakRekap.Image"), System.Drawing.Image)
        Me.btnCetakRekap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetakRekap.Location = New System.Drawing.Point(824, 28)
        Me.btnCetakRekap.Name = "btnCetakRekap"
        Me.btnCetakRekap.Size = New System.Drawing.Size(145, 54)
        Me.btnCetakRekap.TabIndex = 240
        Me.btnCetakRekap.Text = "CETAK REKAP"
        Me.btnCetakRekap.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetakRekap.UseVisualStyleBackColor = True
        '
        'cboKuartal
        '
        Me.cboKuartal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKuartal.FormattingEnabled = True
        Me.cboKuartal.Location = New System.Drawing.Point(227, 27)
        Me.cboKuartal.Name = "cboKuartal"
        Me.cboKuartal.Size = New System.Drawing.Size(48, 21)
        Me.cboKuartal.TabIndex = 242
        '
        'cboPeriode
        '
        Me.cboPeriode.FormattingEnabled = True
        Me.cboPeriode.IntegralHeight = False
        Me.cboPeriode.Location = New System.Drawing.Point(111, 27)
        Me.cboPeriode.Name = "cboPeriode"
        Me.cboPeriode.Size = New System.Drawing.Size(115, 21)
        Me.cboPeriode.TabIndex = 241
        '
        'FormProsesPayroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 641)
        Me.Controls.Add(Me.cboKuartal)
        Me.Controls.Add(Me.cboPeriode)
        Me.Controls.Add(Me.btnCetakRekap)
        Me.Controls.Add(Me.lblSD)
        Me.Controls.Add(Me.dtpPeriodeSelesai)
        Me.Controls.Add(Me.lblPeriode)
        Me.Controls.Add(Me.dtpPeriodeMulai)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblLokasi)
        Me.Controls.Add(Me.cboLokasi)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.btnProsesSemua)
        Me.Controls.Add(Me.pnlKelompok)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboPerusahaan)
        Me.Controls.Add(Me.lblPerusahaanGlobal)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormProsesPayroll"
        Me.Text = "FORM PROSES PAYROLL"
        Me.pnlKelompok.ResumeLayout(False)
        Me.pnlKelompok.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboPerusahaan As ComboBox
    Friend WithEvents lblPerusahaanGlobal As Label
    Friend WithEvents pnlKelompok As Panel
    Friend WithEvents rbOutsource As RadioButton
    Friend WithEvents rbNonStaff As RadioButton
    Friend WithEvents rbStaff As RadioButton
    Friend WithEvents btnProsesSemua As Button
    Friend WithEvents gbView As GroupBox
    Friend WithEvents cboKaryawanIndividu As ComboBox
    Friend WithEvents lblKaryawanIndividu As Label
    Friend WithEvents btnProsesIndividu As Button
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lblLokasi As Label
    Friend WithEvents cboLokasi As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbDepartemenIndividu As TextBox
    Friend WithEvents rptViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnFFBack As Button
    Friend WithEvents lblRecord As Label
    Friend WithEvents btnForward As Button
    Friend WithEvents lblOfPages As Label
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnFFForward As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents lblPerusahaanIndividu As Label
    Friend WithEvents tbDivisiIndividu As TextBox
    Friend WithEvents lblDivisiIndividu As Label
    Friend WithEvents tbBagianIndividu As TextBox
    Friend WithEvents lblBagianIndividu As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpPeriodeSelesai As DateTimePicker
    Friend WithEvents lblPeriode As Label
    Friend WithEvents dtpPeriodeMulai As DateTimePicker
    Friend WithEvents tbLain2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents rtbLain2 As RichTextBox
    Friend WithEvents lblKeterangan As Label
    Friend WithEvents cboFaktorQty As ComboBox
    Friend WithEvents lblFaktorQty As Label
    Friend WithEvents btnCetakRekap As Button
    Friend WithEvents lblCatatanHRD As Label
    Friend WithEvents rtbCatatanHRD As RichTextBox
    Friend WithEvents cboKuartal As ComboBox
    Friend WithEvents cboPeriode As ComboBox
End Class
