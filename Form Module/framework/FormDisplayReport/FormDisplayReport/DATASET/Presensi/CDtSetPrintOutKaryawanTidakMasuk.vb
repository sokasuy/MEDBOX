Public Class CDtSetPrintOutKaryawanTidakMasuk
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("dtSetPrintOutKaryawanTidakMasuk")
        dt.Columns.Add("tanggal", GetType(Date))
        dt.Columns.Add("fpid", GetType(Integer))
        dt.Columns.Add("nip", GetType(String))
        dt.Columns.Add("nama", GetType(String))
        dt.Columns.Add("perusahaan", GetType(String))
        dt.Columns.Add("departemen", GetType(String))
        dt.Columns.Add("divisi", GetType(String))
        dt.Columns.Add("bagian", GetType(String))
        dt.Columns.Add("kelompok", GetType(String))
        dt.Columns.Add("katpenggajian", GetType(String))
        dt.Columns.Add("ijin", GetType(String))
        dt.Columns.Add("absen", GetType(String))
        dt.Columns.Add("keterangan", GetType(String))
        dt.Columns.Add("tglmulaitidakmasuk", GetType(Date))
        dt.Columns.Add("ketabsen", GetType(String))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
