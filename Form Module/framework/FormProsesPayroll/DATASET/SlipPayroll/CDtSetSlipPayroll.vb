﻿Public Class CDtSetSlipPayroll
    Inherits DataSet
    Private dt As DataTable

    Public Sub New()
        dt = New DataTable("dtSetSlipPayroll")
        dt.Columns.Add("nopayroll", GetType(String))
        dt.Columns.Add("idk", GetType(String))
        dt.Columns.Add("nip", GetType(String))
        dt.Columns.Add("nama", GetType(String))
        dt.Columns.Add("lokasi", GetType(String))
        dt.Columns.Add("perusahaan", GetType(String))
        dt.Columns.Add("departemen", GetType(String))
        dt.Columns.Add("divisi", GetType(String))
        dt.Columns.Add("bagian", GetType(String))
        dt.Columns.Add("kelompok", GetType(String))
        dt.Columns.Add("katpenggajian", GetType(String))
        dt.Columns.Add("tanggalpenggajian", GetType(Date))
        dt.Columns.Add("periode", GetType(String))
        dt.Columns.Add("periodemulai", GetType(Date))
        dt.Columns.Add("periodeselesai", GetType(Date))
        dt.Columns.Add("upahpokok", GetType(Double))
        dt.Columns.Add("totaltunjangan", GetType(Double))
        dt.Columns.Add("totalpotongan", GetType(Double))
        dt.Columns.Add("upahbersih", GetType(Double))
        dt.Columns.Add("upahyangdibayar", GetType(Double))
        dt.Columns.Add("linenr", GetType(Byte))
        dt.Columns.Add("komponengaji", GetType(String))
        dt.Columns.Add("keterangan", GetType(String))
        dt.Columns.Add("persen", GetType(Double))
        dt.Columns.Add("rupiah", GetType(Double))
        dt.Columns.Add("faktorqty", GetType(SByte))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
