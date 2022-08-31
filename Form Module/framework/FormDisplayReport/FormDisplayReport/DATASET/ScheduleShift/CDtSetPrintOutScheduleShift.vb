Public Class CDtSetPrintOutScheduleShift
    Inherits DataSet
    Private dt As DataTable

    Public Sub New()
        dt = New DataTable("dtSetPrintOutScheduleShift")
        dt.Columns.Add("perusahaan", GetType(String))
        dt.Columns.Add("noscheduleshift", GetType(String))
        dt.Columns.Add("lokasi", GetType(String))
        dt.Columns.Add("departemen", GetType(String))
        dt.Columns.Add("grup", GetType(String))
        dt.Columns.Add("ketgrup", GetType(String))
        dt.Columns.Add("tanggalawal", GetType(Date))
        dt.Columns.Add("tanggalakhir", GetType(Date))
        dt.Columns.Add("catatan", GetType(String))
        dt.Columns.Add("tanggal", GetType(Date))
        dt.Columns.Add("nip", GetType(String))
        dt.Columns.Add("nama", GetType(String))
        dt.Columns.Add("posisi", GetType(String))
        dt.Columns.Add("linenr", GetType(String))
        dt.Columns.Add("waktushift", GetType(String))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
