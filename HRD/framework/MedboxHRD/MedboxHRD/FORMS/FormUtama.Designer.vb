<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtama
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUtama))
        Me.mnStripUtama = New System.Windows.Forms.MenuStrip()
        Me.mnGroupMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnMasterDataKaryawan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnMasterKaryawanAktif = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnMasterRekeningKaryawan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnPengalamanKerjaKaryawan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnKalenderPerusahaan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnMasterSkemaPresensi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnMasterGeneral = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGroupPeringatan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSuratPeringatan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGroupSPK = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSuratPerintahKerja = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGroupLembur = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSuratPerintahLembur = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGroupIjinAbsen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSuratIjinAbsen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGroupScheduleShift = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnScheduleShift = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGroupPresensi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnProsesPresensi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnViewPresensi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGroupImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnImportData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGroupPengaturan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGantiGambarBG = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGroupPayroll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnProsesPayroll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnTunjanganMasaKerja = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnViewFingerprint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnStripUtama.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnStripUtama
        '
        Me.mnStripUtama.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnGroupMaster, Me.mnGroupPeringatan, Me.mnGroupSPK, Me.mnGroupLembur, Me.mnGroupIjinAbsen, Me.mnGroupScheduleShift, Me.mnGroupPresensi, Me.mnGroupImport, Me.mnGroupPengaturan, Me.mnGroupPayroll, Me.mnLogout, Me.mnExit})
        Me.mnStripUtama.Location = New System.Drawing.Point(0, 0)
        Me.mnStripUtama.Name = "mnStripUtama"
        Me.mnStripUtama.Size = New System.Drawing.Size(902, 24)
        Me.mnStripUtama.TabIndex = 1
        Me.mnStripUtama.Text = "MenuStrip1"
        '
        'mnGroupMaster
        '
        Me.mnGroupMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnMasterDataKaryawan, Me.mnMasterKaryawanAktif, Me.mnMasterRekeningKaryawan, Me.mnPengalamanKerjaKaryawan, Me.mnKalenderPerusahaan, Me.mnMasterSkemaPresensi, Me.mnMasterGeneral})
        Me.mnGroupMaster.Name = "mnGroupMaster"
        Me.mnGroupMaster.Size = New System.Drawing.Size(63, 20)
        Me.mnGroupMaster.Text = "MASTER"
        '
        'mnMasterDataKaryawan
        '
        Me.mnMasterDataKaryawan.Name = "mnMasterDataKaryawan"
        Me.mnMasterDataKaryawan.Size = New System.Drawing.Size(223, 22)
        Me.mnMasterDataKaryawan.Text = "Master Data Karyawan"
        '
        'mnMasterKaryawanAktif
        '
        Me.mnMasterKaryawanAktif.Name = "mnMasterKaryawanAktif"
        Me.mnMasterKaryawanAktif.Size = New System.Drawing.Size(223, 22)
        Me.mnMasterKaryawanAktif.Text = "Master Karyawan Aktif"
        '
        'mnMasterRekeningKaryawan
        '
        Me.mnMasterRekeningKaryawan.Name = "mnMasterRekeningKaryawan"
        Me.mnMasterRekeningKaryawan.Size = New System.Drawing.Size(223, 22)
        Me.mnMasterRekeningKaryawan.Text = "Master Rekening Karyawan"
        '
        'mnPengalamanKerjaKaryawan
        '
        Me.mnPengalamanKerjaKaryawan.Name = "mnPengalamanKerjaKaryawan"
        Me.mnPengalamanKerjaKaryawan.Size = New System.Drawing.Size(223, 22)
        Me.mnPengalamanKerjaKaryawan.Text = "Pengalaman Kerja Karyawan"
        '
        'mnKalenderPerusahaan
        '
        Me.mnKalenderPerusahaan.Name = "mnKalenderPerusahaan"
        Me.mnKalenderPerusahaan.Size = New System.Drawing.Size(223, 22)
        Me.mnKalenderPerusahaan.Text = "Kalender Perusahaan"
        '
        'mnMasterSkemaPresensi
        '
        Me.mnMasterSkemaPresensi.Name = "mnMasterSkemaPresensi"
        Me.mnMasterSkemaPresensi.Size = New System.Drawing.Size(223, 22)
        Me.mnMasterSkemaPresensi.Text = "Master Skema Presensi"
        '
        'mnMasterGeneral
        '
        Me.mnMasterGeneral.Name = "mnMasterGeneral"
        Me.mnMasterGeneral.Size = New System.Drawing.Size(223, 22)
        Me.mnMasterGeneral.Text = "Master General"
        '
        'mnGroupPeringatan
        '
        Me.mnGroupPeringatan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnSuratPeringatan})
        Me.mnGroupPeringatan.Name = "mnGroupPeringatan"
        Me.mnGroupPeringatan.Size = New System.Drawing.Size(88, 20)
        Me.mnGroupPeringatan.Text = "PERINGATAN"
        '
        'mnSuratPeringatan
        '
        Me.mnSuratPeringatan.Name = "mnSuratPeringatan"
        Me.mnSuratPeringatan.Size = New System.Drawing.Size(161, 22)
        Me.mnSuratPeringatan.Text = "Surat Peringatan"
        '
        'mnGroupSPK
        '
        Me.mnGroupSPK.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnSuratPerintahKerja})
        Me.mnGroupSPK.Name = "mnGroupSPK"
        Me.mnGroupSPK.Size = New System.Drawing.Size(39, 20)
        Me.mnGroupSPK.Text = "SPK"
        '
        'mnSuratPerintahKerja
        '
        Me.mnSuratPerintahKerja.Name = "mnSuratPerintahKerja"
        Me.mnSuratPerintahKerja.Size = New System.Drawing.Size(177, 22)
        Me.mnSuratPerintahKerja.Text = "Surat Perintah Kerja"
        '
        'mnGroupLembur
        '
        Me.mnGroupLembur.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnSuratPerintahLembur})
        Me.mnGroupLembur.Name = "mnGroupLembur"
        Me.mnGroupLembur.Size = New System.Drawing.Size(64, 20)
        Me.mnGroupLembur.Text = "LEMBUR"
        '
        'mnSuratPerintahLembur
        '
        Me.mnSuratPerintahLembur.Name = "mnSuratPerintahLembur"
        Me.mnSuratPerintahLembur.Size = New System.Drawing.Size(192, 22)
        Me.mnSuratPerintahLembur.Text = "Surat Perintah Lembur"
        '
        'mnGroupIjinAbsen
        '
        Me.mnGroupIjinAbsen.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnSuratIjinAbsen})
        Me.mnGroupIjinAbsen.Name = "mnGroupIjinAbsen"
        Me.mnGroupIjinAbsen.Size = New System.Drawing.Size(77, 20)
        Me.mnGroupIjinAbsen.Text = "IJIN ABSEN"
        '
        'mnSuratIjinAbsen
        '
        Me.mnSuratIjinAbsen.Name = "mnSuratIjinAbsen"
        Me.mnSuratIjinAbsen.Size = New System.Drawing.Size(156, 22)
        Me.mnSuratIjinAbsen.Text = "Surat Ijin Absen"
        '
        'mnGroupScheduleShift
        '
        Me.mnGroupScheduleShift.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnScheduleShift})
        Me.mnGroupScheduleShift.Name = "mnGroupScheduleShift"
        Me.mnGroupScheduleShift.Size = New System.Drawing.Size(109, 20)
        Me.mnGroupScheduleShift.Text = "SCHEDULE SHIFT"
        '
        'mnScheduleShift
        '
        Me.mnScheduleShift.Name = "mnScheduleShift"
        Me.mnScheduleShift.Size = New System.Drawing.Size(149, 22)
        Me.mnScheduleShift.Text = "Schedule Shift"
        '
        'mnGroupPresensi
        '
        Me.mnGroupPresensi.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnProsesPresensi, Me.mnViewPresensi, Me.mnViewFingerprint})
        Me.mnGroupPresensi.Name = "mnGroupPresensi"
        Me.mnGroupPresensi.Size = New System.Drawing.Size(69, 20)
        Me.mnGroupPresensi.Text = "PRESENSI"
        '
        'mnProsesPresensi
        '
        Me.mnProsesPresensi.Name = "mnProsesPresensi"
        Me.mnProsesPresensi.Size = New System.Drawing.Size(180, 22)
        Me.mnProsesPresensi.Text = "Proses Presensi"
        '
        'mnViewPresensi
        '
        Me.mnViewPresensi.Name = "mnViewPresensi"
        Me.mnViewPresensi.Size = New System.Drawing.Size(180, 22)
        Me.mnViewPresensi.Text = "View Presensi"
        '
        'mnGroupImport
        '
        Me.mnGroupImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnImportData})
        Me.mnGroupImport.Name = "mnGroupImport"
        Me.mnGroupImport.Size = New System.Drawing.Size(61, 20)
        Me.mnGroupImport.Text = "IMPORT"
        '
        'mnImportData
        '
        Me.mnImportData.Name = "mnImportData"
        Me.mnImportData.Size = New System.Drawing.Size(137, 22)
        Me.mnImportData.Text = "Import Data"
        '
        'mnGroupPengaturan
        '
        Me.mnGroupPengaturan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnGantiGambarBG})
        Me.mnGroupPengaturan.Name = "mnGroupPengaturan"
        Me.mnGroupPengaturan.Size = New System.Drawing.Size(94, 20)
        Me.mnGroupPengaturan.Text = "PENGATURAN"
        '
        'mnGantiGambarBG
        '
        Me.mnGantiGambarBG.Name = "mnGantiGambarBG"
        Me.mnGantiGambarBG.Size = New System.Drawing.Size(165, 22)
        Me.mnGantiGambarBG.Text = "Ganti Gambar BG"
        '
        'mnGroupPayroll
        '
        Me.mnGroupPayroll.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnProsesPayroll, Me.mnTunjanganMasaKerja})
        Me.mnGroupPayroll.Name = "mnGroupPayroll"
        Me.mnGroupPayroll.Size = New System.Drawing.Size(67, 20)
        Me.mnGroupPayroll.Text = "PAYROLL"
        '
        'mnProsesPayroll
        '
        Me.mnProsesPayroll.Name = "mnProsesPayroll"
        Me.mnProsesPayroll.Size = New System.Drawing.Size(190, 22)
        Me.mnProsesPayroll.Text = "Proses Payroll"
        '
        'mnTunjanganMasaKerja
        '
        Me.mnTunjanganMasaKerja.Name = "mnTunjanganMasaKerja"
        Me.mnTunjanganMasaKerja.Size = New System.Drawing.Size(190, 22)
        Me.mnTunjanganMasaKerja.Text = "Tunjangan Masa Kerja"
        '
        'mnLogout
        '
        Me.mnLogout.Name = "mnLogout"
        Me.mnLogout.Size = New System.Drawing.Size(68, 20)
        Me.mnLogout.Text = "LOG OUT"
        '
        'mnExit
        '
        Me.mnExit.Name = "mnExit"
        Me.mnExit.Size = New System.Drawing.Size(41, 20)
        Me.mnExit.Text = "EXIT"
        '
        'mnViewFingerprint
        '
        Me.mnViewFingerprint.Name = "mnViewFingerprint"
        Me.mnViewFingerprint.Size = New System.Drawing.Size(180, 22)
        Me.mnViewFingerprint.Text = "View Fingerprint"
        '
        'FormUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 450)
        Me.Controls.Add(Me.mnStripUtama)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnStripUtama
        Me.Name = "FormUtama"
        Me.Text = "FORM UTAMA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnStripUtama.ResumeLayout(False)
        Me.mnStripUtama.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnStripUtama As MenuStrip
    Friend WithEvents mnGroupMaster As ToolStripMenuItem
    Friend WithEvents mnGroupPeringatan As ToolStripMenuItem
    Friend WithEvents mnGroupLembur As ToolStripMenuItem
    Friend WithEvents mnGroupPresensi As ToolStripMenuItem
    Friend WithEvents mnExit As ToolStripMenuItem
    Friend WithEvents mnMasterDataKaryawan As ToolStripMenuItem
    Friend WithEvents mnMasterKaryawanAktif As ToolStripMenuItem
    Friend WithEvents mnMasterRekeningKaryawan As ToolStripMenuItem
    Friend WithEvents mnPengalamanKerjaKaryawan As ToolStripMenuItem
    Friend WithEvents mnSuratPeringatan As ToolStripMenuItem
    Friend WithEvents mnSuratPerintahLembur As ToolStripMenuItem
    Friend WithEvents mnGroupSPK As ToolStripMenuItem
    Friend WithEvents mnSuratPerintahKerja As ToolStripMenuItem
    Friend WithEvents mnKalenderPerusahaan As ToolStripMenuItem
    Friend WithEvents mnGroupImport As ToolStripMenuItem
    Friend WithEvents mnImportData As ToolStripMenuItem
    Friend WithEvents mnProsesPresensi As ToolStripMenuItem
    Friend WithEvents mnLogout As ToolStripMenuItem
    Friend WithEvents mnViewPresensi As ToolStripMenuItem
    Friend WithEvents mnMasterSkemaPresensi As ToolStripMenuItem
    Friend WithEvents mnMasterGeneral As ToolStripMenuItem
    Friend WithEvents mnGroupPengaturan As ToolStripMenuItem
    Friend WithEvents mnGantiGambarBG As ToolStripMenuItem
    Friend WithEvents mnGroupPayroll As ToolStripMenuItem
    Friend WithEvents mnProsesPayroll As ToolStripMenuItem
    Friend WithEvents mnTunjanganMasaKerja As ToolStripMenuItem
    Friend WithEvents mnGroupIjinAbsen As ToolStripMenuItem
    Friend WithEvents mnSuratIjinAbsen As ToolStripMenuItem
    Friend WithEvents mnGroupScheduleShift As ToolStripMenuItem
    Friend WithEvents mnScheduleShift As ToolStripMenuItem
    Friend WithEvents mnViewFingerprint As ToolStripMenuItem
End Class
