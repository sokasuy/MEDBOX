Public Class CDtSetPrintOutRekapIjinAbsen
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("dtSetPrintOutRekapIjinAbsen")
        dt.Columns.Add("nip", GetType(String))
        dt.Columns.Add("nama", GetType(String))
        dt.Columns.Add("posisi", GetType(String))
        dt.Columns.Add("tanggalpengajuan", GetType(Date))
        dt.Columns.Add("perusahaan", GetType(String))
        dt.Columns.Add("departemen", GetType(String))
        dt.Columns.Add("divisi", GetType(String))
        dt.Columns.Add("bagian", GetType(String))
        dt.Columns.Add("tanggalmulai", GetType(Date))
        dt.Columns.Add("tanggalselesai", GetType(Date))
        dt.Columns.Add("darijam", GetType(Object))
        dt.Columns.Add("sampaijam", GetType(Object))
        dt.Columns.Add("kodeijin", GetType(String))
        dt.Columns.Add("ketijin", GetType(String))
        dt.Columns.Add("kodeabsen", GetType(String))
        dt.Columns.Add("ketabsen", GetType(String))
        dt.Columns.Add("catatan", GetType(String))
        dt.Columns.Add("pathtofile", GetType(String))
        dt.Columns.Add("keterangan", GetType(String))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
