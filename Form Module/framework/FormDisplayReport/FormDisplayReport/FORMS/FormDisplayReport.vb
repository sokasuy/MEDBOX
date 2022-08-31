Imports Microsoft.Reporting.WinForms

Public Class FormDisplayReport
    Private stSQL As String
    Private docType As String
    Private ukuranKertas As String
    'Private companyName As String
    Private reportCriteria As String
    Private reportType As String
    Private myDataTable As New DataTable
    Private dlgPageSetup As New PageSetupDialog

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaHRD As String, _connMain As Object, _stSQL As String, _docType As String, Optional _ukuranKertas As String = "A4", Optional _reportCriteria As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory)
        Try
            With CONN_
                .dbType = _dbType
                .dbMain = _connMain
                .schemaTmp = _schemaTmp
                .schemaHRD = _schemaHRD
            End With

            stSQL = _stSQL
            docType = _docType
            ukuranKertas = _ukuranKertas
            'companyName = _companyName
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

            Dim rdlcRptSource As New ReportDataSource
            Me.rptViewer.Reset()

            'Select Case docType
            '    Case "RptSPL"
            '        myDataTable = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, docType)
            '        reportType = "rptPrintOut" & docType
            '        rdlcRptSource.Name = "dtSetPrintOut" & docType
            'End Select

            myDataTable = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, docType)
            reportType = "rptPrintOut" & docType & IIf(reportCriteria.Length > 0, reportCriteria, "")
            rdlcRptSource.Name = "dtSetPrintOut" & docType

            Me.rptViewer.LocalReport.DataSources.Clear()
            rdlcRptSource.Value = myDataTable
            Me.rptViewer.LocalReport.DataSources.Add(rdlcRptSource)
            'AddHandler Me.rptViewer.LocalReport.SubreportProcessing, AddressOf MySubreportCompanyProfile
            Me.rptViewer.LocalReport.EnableExternalImages = True
            Me.rptViewer.LocalReport.ReportEmbeddedResource = "FormDisplayReport." & reportType & ".rdlc"
            Me.Text = docType.ToUpper
            Me.rptViewer.RefreshReport()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormDisplayReport_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class
