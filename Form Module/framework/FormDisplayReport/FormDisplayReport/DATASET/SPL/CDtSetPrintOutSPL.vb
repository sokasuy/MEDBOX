Public Class CDtSetPrintOutSPL
    Inherits DataSet
    Private dt As DataTable

    Public Sub New()
        dt = New DataTable("dtSetPrintOutSPL")
        dt.Columns.Add("perusahaan", GetType(String))
        dt.Columns.Add("lokasi", GetType(String))
        dt.Columns.Add("deptspl", GetType(String))
        dt.Columns.Add("periodemulai", GetType(Date))
        dt.Columns.Add("periodeselesai", GetType(Date))
        dt.Columns.Add("nospl", GetType(String))
        dt.Columns.Add("tanggalpengajuan", GetType(Date))
        dt.Columns.Add("nipkepala", GetType(String))
        dt.Columns.Add("namakepala", GetType(String))
        dt.Columns.Add("jumlahpersonil", GetType(Integer))
        dt.Columns.Add("catheader", GetType(String))
        dt.Columns.Add("nip", GetType(String))
        dt.Columns.Add("nama", GetType(String))
        dt.Columns.Add("departemen", GetType(String))
        dt.Columns.Add("divisi", GetType(String))
        dt.Columns.Add("bagian", GetType(String))
        dt.Columns.Add("pekerjaan", GetType(String))
        dt.Columns.Add("rencanajamlembur", GetType(TimeSpan))
        dt.Columns.Add("rencanamulai", GetType(Date))
        dt.Columns.Add("rencanaselesai", GetType(Date))
        dt.Columns.Add("realisasijamlembur", GetType(TimeSpan))
        dt.Columns.Add("realisasimulai", GetType(Date))
        dt.Columns.Add("realisasiselesai", GetType(Date))
        dt.Columns.Add("catdetail", GetType(String))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
