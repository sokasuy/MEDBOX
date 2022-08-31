'Imports Microsoft.Reporting.WinForms

Public Class FormDisplayReport
    Private stSQL As String
    Private docType As String
    Private ukuranKertas As String
    Private companyName As String
    Private reportCriteria As String
    Private reportType As String
    Private myDataTable As New DataTable
    Private dlgPageSetup As New PageSetupDialog

    Public Sub New(_dbType As String, _connMain As Object, _stSQL As String, _docType As String, Optional _ukuranKertas As String = "A4", Optional _companyName As String = "PT. PIM Pharmaceuticals", Optional _reportCriteria As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory)
        Try
            CONN_.dbMain = _connMain
            stSQL = _stSQL
            docType = _docType
            ukuranKertas = _ukuranKertas
            companyName = _companyName
            reportCriteria = _reportCriteria
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormDisplayReport Error")
        End Try
    End Sub

    Private Sub FormDisplayReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormDisplayReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Dim rdlcRptSource As New Microsoft.Reporting.WinForms.ReportDataSource
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDisplayReport_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class
