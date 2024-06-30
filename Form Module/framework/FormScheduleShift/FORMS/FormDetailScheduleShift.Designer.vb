<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDetailScheduleShift
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDetailScheduleShift))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDepartemen = New System.Windows.Forms.Label()
        Me.cboGrup = New System.Windows.Forms.ComboBox()
        Me.cboDepartemen = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.dtpAkhir = New System.Windows.Forms.DateTimePicker()
        Me.lblNoScheduleShift = New System.Windows.Forms.Label()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.lblPeriode = New System.Windows.Forms.Label()
        Me.tbNoScheduleShift = New System.Windows.Forms.TextBox()
        Me.dtpAwal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPerusahaan = New System.Windows.Forms.ComboBox()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.cboLokasi = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboKetGrup = New System.Windows.Forms.ComboBox()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.lblKaryawan = New System.Windows.Forms.Label()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.btnTambahkan = New System.Windows.Forms.Button()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.lblCaraMenggantiShift = New System.Windows.Forms.Label()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblWaktuShift = New System.Windows.Forms.Label()
        Me.pnlWaktuShift = New System.Windows.Forms.Panel()
        Me.rbKosong = New System.Windows.Forms.RadioButton()
        Me.rbLibur = New System.Windows.Forms.RadioButton()
        Me.rbMalam = New System.Windows.Forms.RadioButton()
        Me.rbSiang = New System.Windows.Forms.RadioButton()
        Me.rbPagi = New System.Windows.Forms.RadioButton()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.pnlCetak = New System.Windows.Forms.Panel()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblSimpanKeDrive = New System.Windows.Forms.Label()
        Me.tbNamaSimpan = New System.Windows.Forms.TextBox()
        Me.lblNamaSimpan = New System.Windows.Forms.Label()
        Me.tbPathSimpan = New System.Windows.Forms.TextBox()
        Me.btnCetak = New System.Windows.Forms.Button()
        Me.gbDataEntry.SuspendLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetail.SuspendLayout()
        Me.pnlWaktuShift.SuspendLayout()
        Me.pnlCetak.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(1199, 25)
        Me.lblTitle.TabIndex = 183
        Me.lblTitle.Text = "SCHEDULE SHIFT"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.Label6)
        Me.gbDataEntry.Controls.Add(Me.lblDepartemen)
        Me.gbDataEntry.Controls.Add(Me.cboGrup)
        Me.gbDataEntry.Controls.Add(Me.cboDepartemen)
        Me.gbDataEntry.Controls.Add(Me.Label5)
        Me.gbDataEntry.Controls.Add(Me.btnGenerate)
        Me.gbDataEntry.Controls.Add(Me.dtpAkhir)
        Me.gbDataEntry.Controls.Add(Me.lblNoScheduleShift)
        Me.gbDataEntry.Controls.Add(Me.lblSD)
        Me.gbDataEntry.Controls.Add(Me.lblPeriode)
        Me.gbDataEntry.Controls.Add(Me.tbNoScheduleShift)
        Me.gbDataEntry.Controls.Add(Me.dtpAwal)
        Me.gbDataEntry.Controls.Add(Me.Label4)
        Me.gbDataEntry.Controls.Add(Me.cboPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.lblPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.cboLokasi)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.cboKetGrup)
        Me.gbDataEntry.Controls.Add(Me.lblLokasi)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(1175, 65)
        Me.gbDataEntry.TabIndex = 194
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(695, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 15)
        Me.Label6.TabIndex = 265
        Me.Label6.Text = "*"
        '
        'lblDepartemen
        '
        Me.lblDepartemen.AutoSize = True
        Me.lblDepartemen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartemen.Location = New System.Drawing.Point(493, 15)
        Me.lblDepartemen.Name = "lblDepartemen"
        Me.lblDepartemen.Size = New System.Drawing.Size(78, 15)
        Me.lblDepartemen.TabIndex = 263
        Me.lblDepartemen.Text = "Departemen :"
        '
        'cboGrup
        '
        Me.cboGrup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGrup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGrup.FormattingEnabled = True
        Me.cboGrup.IntegralHeight = False
        Me.cboGrup.Location = New System.Drawing.Point(365, 36)
        Me.cboGrup.Name = "cboGrup"
        Me.cboGrup.Size = New System.Drawing.Size(105, 23)
        Me.cboGrup.TabIndex = 233
        '
        'cboDepartemen
        '
        Me.cboDepartemen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDepartemen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDepartemen.FormattingEnabled = True
        Me.cboDepartemen.IntegralHeight = False
        Me.cboDepartemen.Location = New System.Drawing.Point(577, 12)
        Me.cboDepartemen.Name = "cboDepartemen"
        Me.cboDepartemen.Size = New System.Drawing.Size(112, 23)
        Me.cboDepartemen.TabIndex = 264
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(290, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 15)
        Me.Label5.TabIndex = 232
        Me.Label5.Text = "*"
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnGenerate.Image = CType(resources.GetObject("btnGenerate.Image"), System.Drawing.Image)
        Me.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerate.Location = New System.Drawing.Point(898, 9)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(120, 54)
        Me.btnGenerate.TabIndex = 7
        Me.btnGenerate.Text = "GENERATE"
        Me.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'dtpAkhir
        '
        Me.dtpAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAkhir.Location = New System.Drawing.Point(772, 38)
        Me.dtpAkhir.Name = "dtpAkhir"
        Me.dtpAkhir.Size = New System.Drawing.Size(120, 23)
        Me.dtpAkhir.TabIndex = 6
        '
        'lblNoScheduleShift
        '
        Me.lblNoScheduleShift.AutoSize = True
        Me.lblNoScheduleShift.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNoScheduleShift.Location = New System.Drawing.Point(7, 39)
        Me.lblNoScheduleShift.Name = "lblNoScheduleShift"
        Me.lblNoScheduleShift.Size = New System.Drawing.Size(81, 15)
        Me.lblNoScheduleShift.TabIndex = 231
        Me.lblNoScheduleShift.Text = "No Sch. Shift :"
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSD.Location = New System.Drawing.Point(744, 39)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(22, 15)
        Me.lblSD.TabIndex = 228
        Me.lblSD.Text = "s.d"
        '
        'lblPeriode
        '
        Me.lblPeriode.AutoSize = True
        Me.lblPeriode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPeriode.Location = New System.Drawing.Point(713, 15)
        Me.lblPeriode.Name = "lblPeriode"
        Me.lblPeriode.Size = New System.Drawing.Size(53, 15)
        Me.lblPeriode.TabIndex = 227
        Me.lblPeriode.Text = "Periode :"
        '
        'tbNoScheduleShift
        '
        Me.tbNoScheduleShift.Location = New System.Drawing.Point(94, 39)
        Me.tbNoScheduleShift.Name = "tbNoScheduleShift"
        Me.tbNoScheduleShift.ReadOnly = True
        Me.tbNoScheduleShift.Size = New System.Drawing.Size(190, 23)
        Me.tbNoScheduleShift.TabIndex = 2
        '
        'dtpAwal
        '
        Me.dtpAwal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAwal.Location = New System.Drawing.Point(772, 12)
        Me.dtpAwal.Name = "dtpAwal"
        Me.dtpAwal.Size = New System.Drawing.Size(120, 23)
        Me.dtpAwal.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(695, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 224
        Me.Label4.Text = "*"
        '
        'cboPerusahaan
        '
        Me.cboPerusahaan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPerusahaan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPerusahaan.FormattingEnabled = True
        Me.cboPerusahaan.IntegralHeight = False
        Me.cboPerusahaan.Location = New System.Drawing.Point(94, 12)
        Me.cboPerusahaan.Name = "cboPerusahaan"
        Me.cboPerusahaan.Size = New System.Drawing.Size(190, 23)
        Me.cboPerusahaan.TabIndex = 1
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPerusahaan.Location = New System.Drawing.Point(14, 15)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(74, 15)
        Me.lblPerusahaan.TabIndex = 223
        Me.lblPerusahaan.Text = "Perusahaan :"
        '
        'cboLokasi
        '
        Me.cboLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLokasi.FormattingEnabled = True
        Me.cboLokasi.IntegralHeight = False
        Me.cboLokasi.Location = New System.Drawing.Point(365, 12)
        Me.cboLokasi.Name = "cboLokasi"
        Me.cboLokasi.Size = New System.Drawing.Size(105, 23)
        Me.cboLokasi.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(476, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 217
        Me.Label2.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(290, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 211
        Me.Label1.Text = "*"
        '
        'cboKetGrup
        '
        Me.cboKetGrup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKetGrup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKetGrup.FormattingEnabled = True
        Me.cboKetGrup.IntegralHeight = False
        Me.cboKetGrup.Location = New System.Drawing.Point(476, 36)
        Me.cboKetGrup.Name = "cboKetGrup"
        Me.cboKetGrup.Size = New System.Drawing.Size(213, 23)
        Me.cboKetGrup.TabIndex = 4
        '
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLokasi.Location = New System.Drawing.Point(313, 15)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(46, 15)
        Me.lblLokasi.TabIndex = 11
        Me.lblLokasi.Text = "Lokasi :"
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(921, 3)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 17
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(669, 3)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 15
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Location = New System.Drawing.Point(6, 100)
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.Size = New System.Drawing.Size(1163, 404)
        Me.dgvDetail.TabIndex = 195
        '
        'lblKaryawan
        '
        Me.lblKaryawan.AutoSize = True
        Me.lblKaryawan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKaryawan.Location = New System.Drawing.Point(7, 22)
        Me.lblKaryawan.Name = "lblKaryawan"
        Me.lblKaryawan.Size = New System.Drawing.Size(64, 15)
        Me.lblKaryawan.TabIndex = 229
        Me.lblKaryawan.Text = "Karyawan :"
        '
        'cboKaryawan
        '
        Me.cboKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.IntegralHeight = False
        Me.cboKaryawan.Location = New System.Drawing.Point(77, 19)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(264, 21)
        Me.cboKaryawan.TabIndex = 8
        '
        'btnTambahkan
        '
        Me.btnTambahkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTambahkan.Image = CType(resources.GetObject("btnTambahkan.Image"), System.Drawing.Image)
        Me.btnTambahkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTambahkan.Location = New System.Drawing.Point(397, 19)
        Me.btnTambahkan.Name = "btnTambahkan"
        Me.btnTambahkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTambahkan.TabIndex = 9
        Me.btnTambahkan.Text = "TAMBAH"
        Me.btnTambahkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTambahkan.UseVisualStyleBackColor = True
        '
        'gbDetail
        '
        Me.gbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetail.Controls.Add(Me.lblCaraMenggantiShift)
        Me.gbDetail.Controls.Add(Me.btnReload)
        Me.gbDetail.Controls.Add(Me.btnCreateNew)
        Me.gbDetail.Controls.Add(Me.Label3)
        Me.gbDetail.Controls.Add(Me.lblWaktuShift)
        Me.gbDetail.Controls.Add(Me.pnlWaktuShift)
        Me.gbDetail.Controls.Add(Me.clbUserRight)
        Me.gbDetail.Controls.Add(Me.dgvDetail)
        Me.gbDetail.Controls.Add(Me.btnTambahkan)
        Me.gbDetail.Controls.Add(Me.cboKaryawan)
        Me.gbDetail.Controls.Add(Me.lblKaryawan)
        Me.gbDetail.Location = New System.Drawing.Point(12, 99)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(1175, 510)
        Me.gbDetail.TabIndex = 231
        Me.gbDetail.TabStop = False
        Me.gbDetail.Text = "DETAIL"
        '
        'lblCaraMenggantiShift
        '
        Me.lblCaraMenggantiShift.AutoSize = True
        Me.lblCaraMenggantiShift.Location = New System.Drawing.Point(170, 80)
        Me.lblCaraMenggantiShift.Name = "lblCaraMenggantiShift"
        Me.lblCaraMenggantiShift.Size = New System.Drawing.Size(306, 13)
        Me.lblCaraMenggantiShift.TabIndex = 238
        Me.lblCaraMenggantiShift.Text = "Gunakan klik kanan mouse untuk mengganti waktu shift di Grid"
        '
        'btnReload
        '
        Me.btnReload.Image = CType(resources.GetObject("btnReload.Image"), System.Drawing.Image)
        Me.btnReload.Location = New System.Drawing.Point(365, 18)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(23, 23)
        Me.btnReload.TabIndex = 236
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(792, 9)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 10
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(347, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 230
        Me.Label3.Text = "*"
        '
        'lblWaktuShift
        '
        Me.lblWaktuShift.AutoSize = True
        Me.lblWaktuShift.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblWaktuShift.Location = New System.Drawing.Point(6, 67)
        Me.lblWaktuShift.Name = "lblWaktuShift"
        Me.lblWaktuShift.Size = New System.Drawing.Size(158, 30)
        Me.lblWaktuShift.TabIndex = 233
        Me.lblWaktuShift.Text = "WAKTU SHIFT"
        '
        'pnlWaktuShift
        '
        Me.pnlWaktuShift.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlWaktuShift.Controls.Add(Me.rbKosong)
        Me.pnlWaktuShift.Controls.Add(Me.rbLibur)
        Me.pnlWaktuShift.Controls.Add(Me.rbMalam)
        Me.pnlWaktuShift.Controls.Add(Me.rbSiang)
        Me.pnlWaktuShift.Controls.Add(Me.rbPagi)
        Me.pnlWaktuShift.Location = New System.Drawing.Point(523, 9)
        Me.pnlWaktuShift.Name = "pnlWaktuShift"
        Me.pnlWaktuShift.Size = New System.Drawing.Size(246, 64)
        Me.pnlWaktuShift.TabIndex = 232
        '
        'rbKosong
        '
        Me.rbKosong.AutoSize = True
        Me.rbKosong.BackColor = System.Drawing.Color.Silver
        Me.rbKosong.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbKosong.Location = New System.Drawing.Point(173, 7)
        Me.rbKosong.Name = "rbKosong"
        Me.rbKosong.Size = New System.Drawing.Size(65, 19)
        Me.rbKosong.TabIndex = 4
        Me.rbKosong.Text = "Kosong"
        Me.rbKosong.UseVisualStyleBackColor = False
        '
        'rbLibur
        '
        Me.rbLibur.AutoSize = True
        Me.rbLibur.BackColor = System.Drawing.Color.LightSalmon
        Me.rbLibur.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbLibur.Location = New System.Drawing.Point(83, 33)
        Me.rbLibur.Name = "rbLibur"
        Me.rbLibur.Size = New System.Drawing.Size(52, 19)
        Me.rbLibur.TabIndex = 3
        Me.rbLibur.Text = "Libur"
        Me.rbLibur.UseVisualStyleBackColor = False
        '
        'rbMalam
        '
        Me.rbMalam.AutoSize = True
        Me.rbMalam.BackColor = System.Drawing.Color.Lime
        Me.rbMalam.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbMalam.Location = New System.Drawing.Point(83, 8)
        Me.rbMalam.Name = "rbMalam"
        Me.rbMalam.Size = New System.Drawing.Size(62, 19)
        Me.rbMalam.TabIndex = 2
        Me.rbMalam.Text = "Malam"
        Me.rbMalam.UseVisualStyleBackColor = False
        '
        'rbSiang
        '
        Me.rbSiang.AutoSize = True
        Me.rbSiang.BackColor = System.Drawing.Color.Aqua
        Me.rbSiang.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbSiang.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbSiang.Location = New System.Drawing.Point(3, 33)
        Me.rbSiang.Name = "rbSiang"
        Me.rbSiang.Size = New System.Drawing.Size(54, 19)
        Me.rbSiang.TabIndex = 1
        Me.rbSiang.Text = "Siang"
        Me.rbSiang.UseVisualStyleBackColor = False
        '
        'rbPagi
        '
        Me.rbPagi.AutoSize = True
        Me.rbPagi.BackColor = System.Drawing.Color.Yellow
        Me.rbPagi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbPagi.Location = New System.Drawing.Point(3, 8)
        Me.rbPagi.Name = "rbPagi"
        Me.rbPagi.Size = New System.Drawing.Size(48, 19)
        Me.rbPagi.TabIndex = 0
        Me.rbPagi.Text = "Pagi"
        Me.rbPagi.UseVisualStyleBackColor = False
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(1069, 9)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 231
        '
        'pnlCetak
        '
        Me.pnlCetak.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCetak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCetak.Controls.Add(Me.btnHapus)
        Me.pnlCetak.Controls.Add(Me.btnExportExcel)
        Me.pnlCetak.Controls.Add(Me.btnSimpan)
        Me.pnlCetak.Controls.Add(Me.btnBrowse)
        Me.pnlCetak.Controls.Add(Me.btnKeluar)
        Me.pnlCetak.Controls.Add(Me.lblSimpanKeDrive)
        Me.pnlCetak.Controls.Add(Me.tbNamaSimpan)
        Me.pnlCetak.Controls.Add(Me.lblNamaSimpan)
        Me.pnlCetak.Controls.Add(Me.tbPathSimpan)
        Me.pnlCetak.Controls.Add(Me.btnCetak)
        Me.pnlCetak.Location = New System.Drawing.Point(12, 615)
        Me.pnlCetak.Name = "pnlCetak"
        Me.pnlCetak.Size = New System.Drawing.Size(1175, 62)
        Me.pnlCetak.TabIndex = 232
        '
        'btnHapus
        '
        Me.btnHapus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnHapus.Image = CType(resources.GetObject("btnHapus.Image"), System.Drawing.Image)
        Me.btnHapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHapus.Location = New System.Drawing.Point(1047, 3)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(120, 54)
        Me.btnHapus.TabIndex = 18
        Me.btnHapus.Text = "HAPUS"
        Me.btnHapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportExcel.Image = CType(resources.GetObject("btnExportExcel.Image"), System.Drawing.Image)
        Me.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportExcel.Location = New System.Drawing.Point(470, 3)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(120, 54)
        Me.btnExportExcel.TabIndex = 14
        Me.btnExportExcel.Text = "EXCEL"
        Me.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(441, 1)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 24)
        Me.btnBrowse.TabIndex = 12
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblSimpanKeDrive
        '
        Me.lblSimpanKeDrive.AutoSize = True
        Me.lblSimpanKeDrive.Location = New System.Drawing.Point(7, 6)
        Me.lblSimpanKeDrive.Name = "lblSimpanKeDrive"
        Me.lblSimpanKeDrive.Size = New System.Drawing.Size(91, 13)
        Me.lblSimpanKeDrive.TabIndex = 86
        Me.lblSimpanKeDrive.Text = "Simpan ke Drive :"
        '
        'tbNamaSimpan
        '
        Me.tbNamaSimpan.Location = New System.Drawing.Point(104, 31)
        Me.tbNamaSimpan.Name = "tbNamaSimpan"
        Me.tbNamaSimpan.Size = New System.Drawing.Size(360, 20)
        Me.tbNamaSimpan.TabIndex = 13
        '
        'lblNamaSimpan
        '
        Me.lblNamaSimpan.AutoSize = True
        Me.lblNamaSimpan.Location = New System.Drawing.Point(19, 34)
        Me.lblNamaSimpan.Name = "lblNamaSimpan"
        Me.lblNamaSimpan.Size = New System.Drawing.Size(79, 13)
        Me.lblNamaSimpan.TabIndex = 87
        Me.lblNamaSimpan.Text = "Nama Simpan :"
        '
        'tbPathSimpan
        '
        Me.tbPathSimpan.Location = New System.Drawing.Point(104, 3)
        Me.tbPathSimpan.Name = "tbPathSimpan"
        Me.tbPathSimpan.Size = New System.Drawing.Size(333, 20)
        Me.tbPathSimpan.TabIndex = 11
        '
        'btnCetak
        '
        Me.btnCetak.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCetak.Image = CType(resources.GetObject("btnCetak.Image"), System.Drawing.Image)
        Me.btnCetak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetak.Location = New System.Drawing.Point(795, 3)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(120, 54)
        Me.btnCetak.TabIndex = 16
        Me.btnCetak.Text = "CETAK"
        Me.btnCetak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetak.UseVisualStyleBackColor = True
        '
        'FormDetailScheduleShift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1199, 681)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.pnlCetak)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormDetailScheduleShift"
        Me.Text = "FORM SCHEDULE SHIFT"
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        Me.pnlWaktuShift.ResumeLayout(False)
        Me.pnlWaktuShift.PerformLayout()
        Me.pnlCetak.ResumeLayout(False)
        Me.pnlCetak.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboPerusahaan As ComboBox
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents cboLokasi As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboKetGrup As ComboBox
    Friend WithEvents lblLokasi As Label
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents dtpAkhir As DateTimePicker
    Friend WithEvents lblSD As Label
    Friend WithEvents lblPeriode As Label
    Friend WithEvents dtpAwal As DateTimePicker
    Friend WithEvents btnGenerate As Button
    Friend WithEvents dgvDetail As DataGridView
    Friend WithEvents lblKaryawan As Label
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents btnTambahkan As Button
    Friend WithEvents gbDetail As GroupBox
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents pnlCetak As Panel
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents btnCetak As Button
    Friend WithEvents tbNamaSimpan As TextBox
    Friend WithEvents tbPathSimpan As TextBox
    Friend WithEvents lblNamaSimpan As Label
    Friend WithEvents lblSimpanKeDrive As Label
    Friend WithEvents pnlWaktuShift As Panel
    Friend WithEvents rbPagi As RadioButton
    Friend WithEvents rbSiang As RadioButton
    Friend WithEvents rbMalam As RadioButton
    Friend WithEvents rbLibur As RadioButton
    Friend WithEvents lblWaktuShift As Label
    Friend WithEvents btnHapus As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents lblNoScheduleShift As Label
    Friend WithEvents tbNoScheduleShift As TextBox
    Friend WithEvents btnReload As Button
    Friend WithEvents rbKosong As RadioButton
    Friend WithEvents cboGrup As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblDepartemen As Label
    Friend WithEvents cboDepartemen As ComboBox
    Friend WithEvents lblCaraMenggantiShift As Label
End Class
