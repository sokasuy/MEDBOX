<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormIjinAbsen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormIjinAbsen))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.cboJabatan = New System.Windows.Forms.ComboBox()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.lblJabatan = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbSampaiJam = New System.Windows.Forms.TextBox()
        Me.tbDariJam = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblJam = New System.Windows.Forms.Label()
        Me.dtpTanggalSelesai = New System.Windows.Forms.DateTimePicker()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.dtpTanggalMulai = New System.Windows.Forms.DateTimePicker()
        Me.lblImportantAbsen = New System.Windows.Forms.Label()
        Me.cboMohonIjin = New System.Windows.Forms.ComboBox()
        Me.lblMohonIjin = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCatatan = New System.Windows.Forms.Label()
        Me.rtbCatatan = New System.Windows.Forms.RichTextBox()
        Me.cboAbsen = New System.Windows.Forms.ComboBox()
        Me.lblAbsen = New System.Windows.Forms.Label()
        Me.lblBagian = New System.Windows.Forms.Label()
        Me.tbBagian = New System.Windows.Forms.TextBox()
        Me.lblDivisi = New System.Windows.Forms.Label()
        Me.tbDivisi = New System.Windows.Forms.TextBox()
        Me.lblDepartemen = New System.Windows.Forms.Label()
        Me.tbDepartemen = New System.Windows.Forms.TextBox()
        Me.lblTanggalPengajuan = New System.Windows.Forms.Label()
        Me.dtpTanggalPengajuan = New System.Windows.Forms.DateTimePicker()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.tbPerusahaan = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.lblCari = New System.Windows.Forms.Label()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.pnlCetak = New System.Windows.Forms.Panel()
        Me.dtpTanggalSelesaiCetak = New System.Windows.Forms.DateTimePicker()
        Me.dtpTanggalMulaiCetak = New System.Windows.Forms.DateTimePicker()
        Me.btnCetak = New System.Windows.Forms.Button()
        Me.pnlTanggal = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpAkhir = New System.Windows.Forms.DateTimePicker()
        Me.dtpAwal = New System.Windows.Forms.DateTimePicker()
        Me.gbDataEntry.SuspendLayout()
        Me.gbView.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCetak.SuspendLayout()
        Me.pnlTanggal.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(1084, 25)
        Me.lblTitle.TabIndex = 175
        Me.lblTitle.Text = "IJIN ABSEN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.cboJabatan)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.lblJabatan)
        Me.gbDataEntry.Controls.Add(Me.Label7)
        Me.gbDataEntry.Controls.Add(Me.Label6)
        Me.gbDataEntry.Controls.Add(Me.tbSampaiJam)
        Me.gbDataEntry.Controls.Add(Me.tbDariJam)
        Me.gbDataEntry.Controls.Add(Me.Label5)
        Me.gbDataEntry.Controls.Add(Me.lblJam)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggalSelesai)
        Me.gbDataEntry.Controls.Add(Me.lblSD)
        Me.gbDataEntry.Controls.Add(Me.lblTanggal)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggalMulai)
        Me.gbDataEntry.Controls.Add(Me.lblImportantAbsen)
        Me.gbDataEntry.Controls.Add(Me.cboMohonIjin)
        Me.gbDataEntry.Controls.Add(Me.lblMohonIjin)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.lblCatatan)
        Me.gbDataEntry.Controls.Add(Me.rtbCatatan)
        Me.gbDataEntry.Controls.Add(Me.cboAbsen)
        Me.gbDataEntry.Controls.Add(Me.lblAbsen)
        Me.gbDataEntry.Controls.Add(Me.lblBagian)
        Me.gbDataEntry.Controls.Add(Me.tbBagian)
        Me.gbDataEntry.Controls.Add(Me.lblDivisi)
        Me.gbDataEntry.Controls.Add(Me.tbDivisi)
        Me.gbDataEntry.Controls.Add(Me.lblDepartemen)
        Me.gbDataEntry.Controls.Add(Me.tbDepartemen)
        Me.gbDataEntry.Controls.Add(Me.lblTanggalPengajuan)
        Me.gbDataEntry.Controls.Add(Me.dtpTanggalPengajuan)
        Me.gbDataEntry.Controls.Add(Me.cboKaryawan)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.lblPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.tbPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.lblKaryawan)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(800, 245)
        Me.gbDataEntry.TabIndex = 176
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'cboJabatan
        '
        Me.cboJabatan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboJabatan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboJabatan.FormattingEnabled = True
        Me.cboJabatan.IntegralHeight = False
        Me.cboJabatan.Location = New System.Drawing.Point(93, 42)
        Me.cboJabatan.Name = "cboJabatan"
        Me.cboJabatan.Size = New System.Drawing.Size(254, 23)
        Me.cboJabatan.TabIndex = 3
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(548, 185)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 16
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'lblJabatan
        '
        Me.lblJabatan.AutoSize = True
        Me.lblJabatan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJabatan.Location = New System.Drawing.Point(34, 45)
        Me.lblJabatan.Name = "lblJabatan"
        Me.lblJabatan.Size = New System.Drawing.Size(53, 15)
        Me.lblJabatan.TabIndex = 206
        Me.lblJabatan.Text = "Jabatan :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(353, 189)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 15)
        Me.Label7.TabIndex = 204
        Me.Label7.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(199, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 15)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "*"
        '
        'tbSampaiJam
        '
        Me.tbSampaiJam.Location = New System.Drawing.Point(247, 186)
        Me.tbSampaiJam.Name = "tbSampaiJam"
        Me.tbSampaiJam.Size = New System.Drawing.Size(100, 23)
        Me.tbSampaiJam.TabIndex = 10
        Me.tbSampaiJam.Text = "17:00"
        '
        'tbDariJam
        '
        Me.tbDariJam.Location = New System.Drawing.Point(93, 186)
        Me.tbDariJam.Name = "tbDariJam"
        Me.tbDariJam.Size = New System.Drawing.Size(100, 23)
        Me.tbDariJam.TabIndex = 9
        Me.tbDariJam.Text = "08:00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(219, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 15)
        Me.Label5.TabIndex = 201
        Me.Label5.Text = "s.d"
        '
        'lblJam
        '
        Me.lblJam.AutoSize = True
        Me.lblJam.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJam.Location = New System.Drawing.Point(53, 192)
        Me.lblJam.Name = "lblJam"
        Me.lblJam.Size = New System.Drawing.Size(34, 15)
        Me.lblJam.TabIndex = 200
        Me.lblJam.Text = "Jam :"
        '
        'dtpTanggalSelesai
        '
        Me.dtpTanggalSelesai.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalSelesai.Location = New System.Drawing.Point(247, 162)
        Me.dtpTanggalSelesai.Name = "dtpTanggalSelesai"
        Me.dtpTanggalSelesai.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggalSelesai.TabIndex = 8
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(219, 168)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(22, 15)
        Me.lblSD.TabIndex = 197
        Me.lblSD.Text = "s.d"
        '
        'lblTanggal
        '
        Me.lblTanggal.AutoSize = True
        Me.lblTanggal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTanggal.Location = New System.Drawing.Point(4, 168)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(83, 15)
        Me.lblTanggal.TabIndex = 196
        Me.lblTanggal.Text = "Pada Tanggal :"
        '
        'dtpTanggalMulai
        '
        Me.dtpTanggalMulai.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalMulai.Location = New System.Drawing.Point(93, 162)
        Me.dtpTanggalMulai.Name = "dtpTanggalMulai"
        Me.dtpTanggalMulai.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggalMulai.TabIndex = 7
        '
        'lblImportantAbsen
        '
        Me.lblImportantAbsen.AutoSize = True
        Me.lblImportantAbsen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblImportantAbsen.ForeColor = System.Drawing.Color.Red
        Me.lblImportantAbsen.Location = New System.Drawing.Point(782, 95)
        Me.lblImportantAbsen.Name = "lblImportantAbsen"
        Me.lblImportantAbsen.Size = New System.Drawing.Size(12, 15)
        Me.lblImportantAbsen.TabIndex = 194
        Me.lblImportantAbsen.Text = "*"
        '
        'cboMohonIjin
        '
        Me.cboMohonIjin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMohonIjin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMohonIjin.FormattingEnabled = True
        Me.cboMohonIjin.IntegralHeight = False
        Me.cboMohonIjin.Location = New System.Drawing.Point(93, 92)
        Me.cboMohonIjin.Name = "cboMohonIjin"
        Me.cboMohonIjin.Size = New System.Drawing.Size(252, 23)
        Me.cboMohonIjin.TabIndex = 4
        '
        'lblMohonIjin
        '
        Me.lblMohonIjin.AutoSize = True
        Me.lblMohonIjin.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMohonIjin.Location = New System.Drawing.Point(9, 95)
        Me.lblMohonIjin.Name = "lblMohonIjin"
        Me.lblMohonIjin.Size = New System.Drawing.Size(71, 15)
        Me.lblMohonIjin.TabIndex = 193
        Me.lblMohonIjin.Text = "Mohon Ijin :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(782, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 191
        Me.Label3.Text = "*"
        '
        'lblCatatan
        '
        Me.lblCatatan.AutoSize = True
        Me.lblCatatan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCatatan.Location = New System.Drawing.Point(26, 119)
        Me.lblCatatan.Name = "lblCatatan"
        Me.lblCatatan.Size = New System.Drawing.Size(54, 15)
        Me.lblCatatan.TabIndex = 190
        Me.lblCatatan.Text = "Catatan :"
        '
        'rtbCatatan
        '
        Me.rtbCatatan.Location = New System.Drawing.Point(93, 116)
        Me.rtbCatatan.Name = "rtbCatatan"
        Me.rtbCatatan.Size = New System.Drawing.Size(683, 45)
        Me.rtbCatatan.TabIndex = 6
        Me.rtbCatatan.Text = ""
        '
        'cboAbsen
        '
        Me.cboAbsen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAbsen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAbsen.FormattingEnabled = True
        Me.cboAbsen.IntegralHeight = False
        Me.cboAbsen.Location = New System.Drawing.Point(517, 92)
        Me.cboAbsen.Name = "cboAbsen"
        Me.cboAbsen.Size = New System.Drawing.Size(259, 23)
        Me.cboAbsen.TabIndex = 5
        '
        'lblAbsen
        '
        Me.lblAbsen.AutoSize = True
        Me.lblAbsen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAbsen.Location = New System.Drawing.Point(465, 95)
        Me.lblAbsen.Name = "lblAbsen"
        Me.lblAbsen.Size = New System.Drawing.Size(46, 15)
        Me.lblAbsen.TabIndex = 187
        Me.lblAbsen.Text = "Absen :"
        '
        'lblBagian
        '
        Me.lblBagian.AutoSize = True
        Me.lblBagian.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBagian.Location = New System.Drawing.Point(537, 71)
        Me.lblBagian.Name = "lblBagian"
        Me.lblBagian.Size = New System.Drawing.Size(49, 15)
        Me.lblBagian.TabIndex = 186
        Me.lblBagian.Text = "Bagian :"
        '
        'tbBagian
        '
        Me.tbBagian.Location = New System.Drawing.Point(592, 68)
        Me.tbBagian.Name = "tbBagian"
        Me.tbBagian.ReadOnly = True
        Me.tbBagian.Size = New System.Drawing.Size(184, 23)
        Me.tbBagian.TabIndex = 6
        Me.tbBagian.TabStop = False
        '
        'lblDivisi
        '
        Me.lblDivisi.AutoSize = True
        Me.lblDivisi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDivisi.Location = New System.Drawing.Point(307, 71)
        Me.lblDivisi.Name = "lblDivisi"
        Me.lblDivisi.Size = New System.Drawing.Size(41, 15)
        Me.lblDivisi.TabIndex = 184
        Me.lblDivisi.Text = "Divisi :"
        '
        'tbDivisi
        '
        Me.tbDivisi.Location = New System.Drawing.Point(354, 68)
        Me.tbDivisi.Name = "tbDivisi"
        Me.tbDivisi.ReadOnly = True
        Me.tbDivisi.Size = New System.Drawing.Size(157, 23)
        Me.tbDivisi.TabIndex = 5
        Me.tbDivisi.TabStop = False
        '
        'lblDepartemen
        '
        Me.lblDepartemen.AutoSize = True
        Me.lblDepartemen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartemen.Location = New System.Drawing.Point(9, 71)
        Me.lblDepartemen.Name = "lblDepartemen"
        Me.lblDepartemen.Size = New System.Drawing.Size(78, 15)
        Me.lblDepartemen.TabIndex = 182
        Me.lblDepartemen.Text = "Departemen :"
        '
        'tbDepartemen
        '
        Me.tbDepartemen.Location = New System.Drawing.Point(93, 68)
        Me.tbDepartemen.Name = "tbDepartemen"
        Me.tbDepartemen.ReadOnly = True
        Me.tbDepartemen.Size = New System.Drawing.Size(168, 23)
        Me.tbDepartemen.TabIndex = 4
        Me.tbDepartemen.TabStop = False
        '
        'lblTanggalPengajuan
        '
        Me.lblTanggalPengajuan.AutoSize = True
        Me.lblTanggalPengajuan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTanggalPengajuan.Location = New System.Drawing.Point(537, 18)
        Me.lblTanggalPengajuan.Name = "lblTanggalPengajuan"
        Me.lblTanggalPengajuan.Size = New System.Drawing.Size(113, 15)
        Me.lblTanggalPengajuan.TabIndex = 180
        Me.lblTanggalPengajuan.Text = "Tanggal Pengajuan :"
        '
        'dtpTanggalPengajuan
        '
        Me.dtpTanggalPengajuan.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalPengajuan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalPengajuan.Location = New System.Drawing.Point(656, 15)
        Me.dtpTanggalPengajuan.Name = "dtpTanggalPengajuan"
        Me.dtpTanggalPengajuan.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggalPengajuan.TabIndex = 2
        '
        'cboKaryawan
        '
        Me.cboKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.IntegralHeight = False
        Me.cboKaryawan.Location = New System.Drawing.Point(93, 18)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(319, 23)
        Me.cboKaryawan.TabIndex = 1
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(674, 185)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 11
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(351, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "*"
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPerusahaan.Location = New System.Drawing.Point(410, 45)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaan.TabIndex = 5
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'tbPerusahaan
        '
        Me.tbPerusahaan.Location = New System.Drawing.Point(497, 42)
        Me.tbPerusahaan.Name = "tbPerusahaan"
        Me.tbPerusahaan.ReadOnly = True
        Me.tbPerusahaan.Size = New System.Drawing.Size(279, 23)
        Me.tbPerusahaan.TabIndex = 4
        Me.tbPerusahaan.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(417, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "*"
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKaryawan.Location = New System.Drawing.Point(16, 21)
        Me.lblKaryawan.Name = "lblKaryawan"
        Me.lblKaryawan.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawan.TabIndex = 2
        Me.lblKaryawan.Text = "Karyawan :"
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(955, 220)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 12
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.pnlTanggal)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 279)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(1063, 370)
        Me.gbView.TabIndex = 181
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
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
        Me.pnlNavigasi.Location = New System.Drawing.Point(6, 333)
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
        Me.lblRecord.Size = New System.Drawing.Size(39, 15)
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
        Me.lblOfPages.Size = New System.Drawing.Size(69, 15)
        Me.lblOfPages.TabIndex = 170
        Me.lblOfPages.Text = "Of : x Pages"
        '
        'tbRecordPage
        '
        Me.tbRecordPage.Location = New System.Drawing.Point(130, 5)
        Me.tbRecordPage.Name = "tbRecordPage"
        Me.tbRecordPage.Size = New System.Drawing.Size(70, 23)
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
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(184, 29)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(380, 23)
        Me.tbCari.TabIndex = 14
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(570, 12)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 15
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Location = New System.Drawing.Point(11, 32)
        Me.lblCari.Name = "lblCari"
        Me.lblCari.Size = New System.Drawing.Size(50, 15)
        Me.lblCari.TabIndex = 132
        Me.lblCari.Text = "Kriteria :"
        '
        'cboKriteria
        '
        Me.cboKriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKriteria.FormattingEnabled = True
        Me.cboKriteria.Location = New System.Drawing.Point(62, 29)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(116, 23)
        Me.cboKriteria.TabIndex = 13
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Location = New System.Drawing.Point(6, 67)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.Size = New System.Drawing.Size(1051, 263)
        Me.dgvView.TabIndex = 130
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(818, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 184
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(975, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 183
        '
        'pnlCetak
        '
        Me.pnlCetak.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCetak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCetak.Controls.Add(Me.dtpTanggalSelesaiCetak)
        Me.pnlCetak.Controls.Add(Me.dtpTanggalMulaiCetak)
        Me.pnlCetak.Controls.Add(Me.btnCetak)
        Me.pnlCetak.Location = New System.Drawing.Point(818, 98)
        Me.pnlCetak.Name = "pnlCetak"
        Me.pnlCetak.Size = New System.Drawing.Size(257, 90)
        Me.pnlCetak.TabIndex = 191
        '
        'dtpTanggalSelesaiCetak
        '
        Me.dtpTanggalSelesaiCetak.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalSelesaiCetak.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalSelesaiCetak.Location = New System.Drawing.Point(129, 3)
        Me.dtpTanggalSelesaiCetak.Name = "dtpTanggalSelesaiCetak"
        Me.dtpTanggalSelesaiCetak.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggalSelesaiCetak.TabIndex = 208
        '
        'dtpTanggalMulaiCetak
        '
        Me.dtpTanggalMulaiCetak.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTanggalMulaiCetak.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalMulaiCetak.Location = New System.Drawing.Point(3, 3)
        Me.dtpTanggalMulaiCetak.Name = "dtpTanggalMulaiCetak"
        Me.dtpTanggalMulaiCetak.Size = New System.Drawing.Size(120, 23)
        Me.dtpTanggalMulaiCetak.TabIndex = 11
        '
        'btnCetak
        '
        Me.btnCetak.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCetak.Image = CType(resources.GetObject("btnCetak.Image"), System.Drawing.Image)
        Me.btnCetak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetak.Location = New System.Drawing.Point(67, 32)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(120, 54)
        Me.btnCetak.TabIndex = 10
        Me.btnCetak.Text = "CETAK"
        Me.btnCetak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetak.UseVisualStyleBackColor = True
        '
        'pnlTanggal
        '
        Me.pnlTanggal.Controls.Add(Me.Label4)
        Me.pnlTanggal.Controls.Add(Me.dtpAkhir)
        Me.pnlTanggal.Controls.Add(Me.dtpAwal)
        Me.pnlTanggal.Location = New System.Drawing.Point(184, 22)
        Me.pnlTanggal.Name = "pnlTanggal"
        Me.pnlTanggal.Size = New System.Drawing.Size(285, 30)
        Me.pnlTanggal.TabIndex = 208
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(129, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "s.d"
        '
        'dtpAkhir
        '
        Me.dtpAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAkhir.Location = New System.Drawing.Point(156, 6)
        Me.dtpAkhir.Name = "dtpAkhir"
        Me.dtpAkhir.Size = New System.Drawing.Size(120, 23)
        Me.dtpAkhir.TabIndex = 3
        '
        'dtpAwal
        '
        Me.dtpAwal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAwal.Location = New System.Drawing.Point(3, 6)
        Me.dtpAwal.Name = "dtpAwal"
        Me.dtpAwal.Size = New System.Drawing.Size(120, 23)
        Me.dtpAwal.TabIndex = 2
        '
        'FormIjinAbsen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1084, 651)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.pnlCetak)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnKeluar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormIjinAbsen"
        Me.Text = "FORM IJIN ABSEN"
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCetak.ResumeLayout(False)
        Me.pnlTanggal.ResumeLayout(False)
        Me.pnlTanggal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents tbPerusahaan As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents dtpTanggalPengajuan As DateTimePicker
    Friend WithEvents lblTanggalPengajuan As Label
    Friend WithEvents lblDepartemen As Label
    Friend WithEvents tbDepartemen As TextBox
    Friend WithEvents lblDivisi As Label
    Friend WithEvents tbDivisi As TextBox
    Friend WithEvents lblBagian As Label
    Friend WithEvents tbBagian As TextBox
    Friend WithEvents cboAbsen As ComboBox
    Friend WithEvents lblAbsen As Label
    Friend WithEvents lblCatatan As Label
    Friend WithEvents rtbCatatan As RichTextBox
    Friend WithEvents gbView As GroupBox
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnFFBack As Button
    Friend WithEvents lblRecord As Label
    Friend WithEvents btnForward As Button
    Friend WithEvents lblOfPages As Label
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnFFForward As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents tbCari As TextBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lblCari As Label
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents lblEntryType As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboMohonIjin As ComboBox
    Friend WithEvents lblMohonIjin As Label
    Friend WithEvents lblImportantAbsen As Label
    Friend WithEvents lblTanggal As Label
    Friend WithEvents dtpTanggalMulai As DateTimePicker
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpTanggalSelesai As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents lblJam As Label
    Friend WithEvents tbDariJam As TextBox
    Friend WithEvents tbSampaiJam As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cboJabatan As ComboBox
    Friend WithEvents lblJabatan As Label
    Friend WithEvents pnlCetak As Panel
    Friend WithEvents btnCetak As Button
    Friend WithEvents dtpTanggalMulaiCetak As DateTimePicker
    Friend WithEvents dtpTanggalSelesaiCetak As DateTimePicker
    Friend WithEvents pnlTanggal As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpAkhir As DateTimePicker
    Friend WithEvents dtpAwal As DateTimePicker
End Class
