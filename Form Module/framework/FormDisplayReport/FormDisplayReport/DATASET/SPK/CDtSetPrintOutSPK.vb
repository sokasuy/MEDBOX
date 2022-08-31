Public Class CDtSetPrintOutSPK
    Inherits DataSet
    Private dt As DataTable

    Public Sub New()
        dt = New DataTable("dtSetPrintOutSPK")
        dt.Columns.Add("perusahaan", GetType(String))
        dt.Columns.Add("lokasi", GetType(String))
        dt.Columns.Add("deptspk", GetType(String))
        dt.Columns.Add("periodemulai", GetType(Date))
        dt.Columns.Add("periodeselesai", GetType(Date))
        dt.Columns.Add("nospk", GetType(String))
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
        dt.Columns.Add("shift", GetType(Integer))
        dt.Columns.Add("mulai", GetType(Date))
        dt.Columns.Add("selesai", GetType(Date))
        dt.Columns.Add("pekerjaan", GetType(String))
        dt.Columns.Add("jammulai", GetType(TimeSpan))
        dt.Columns.Add("jamselesai", GetType(TimeSpan))
        dt.Columns.Add("jamspk", GetType(String))
        dt.Columns.Add("tanggalshift", GetType(Date))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
