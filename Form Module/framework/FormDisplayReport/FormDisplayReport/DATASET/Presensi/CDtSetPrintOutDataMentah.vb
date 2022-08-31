Public Class CDtSetPrintOutDataMentah
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("dtSetPrintOutDataMentah")
        dt.Columns.Add("tanggal", GetType(Date))
        dt.Columns.Add("fpid", GetType(Integer))
        dt.Columns.Add("idk", GetType(String))
        dt.Columns.Add("mesin", GetType(String))
        dt.Columns.Add("nip", GetType(String))
        dt.Columns.Add("nama", GetType(String))
        dt.Columns.Add("masuk", GetType(TimeSpan))
        dt.Columns.Add("keluar", GetType(TimeSpan))
        dt.Columns.Add("fpmasuk", GetType(TimeSpan))
        dt.Columns.Add("fpkeluar", GetType(TimeSpan))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
