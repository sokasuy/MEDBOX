Public Class CDtSetPrintOutDataPresensi
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("dtSetPrintOutDataPresensi")
        dt.Columns.Add("lokasi", GetType(String))
        dt.Columns.Add("tanggalawal", GetType(Date))
        dt.Columns.Add("tanggalakhir", GetType(Date))
        dt.Columns.Add("tanggal", GetType(Date))
        dt.Columns.Add("nip", GetType(String))
        dt.Columns.Add("fpid", GetType(Integer))
        dt.Columns.Add("nama", GetType(String))
        dt.Columns.Add("perusahaan", GetType(String))
        dt.Columns.Add("fpmasuk", GetType(TimeSpan))
        dt.Columns.Add("fpkeluar", GetType(TimeSpan))
        dt.Columns.Add("terlambat", GetType(TimeSpan))
        dt.Columns.Add("pulangcepat", GetType(TimeSpan))
        dt.Columns.Add("mesin", GetType(String))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
