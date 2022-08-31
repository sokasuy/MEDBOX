Module ModExtension

    Public myCDBConnection As New CDBConnection.CDBConnection
    Public myCDBOperation As New CDBOperation.CDBOperation
    'Public myCFileIO As New CFileIO.CFileIO
    Public myCFormManipulation As New CFormManipulation.CFormManipulation
    'Public myCMiscFunction As New CMiscFunction.CMiscFunction
    Public myCShowMessage As New CShowMessage.CShowMessage
    'Public myCStartup As New CStartup.CStartup
    Public myCStringManipulation As New CStringManipulation.CStringManipulation
    'Public myCNetworkOperation As New CNetworkOperation
    'Public myCDataGridViewManipulation As New CDataGridViewManipulation.CDataGridViewManipulation
    'Public myCManagementSystem As New CManagementSystem.CManagementSystem

    Public Structure DBConn
        Public dbMain As Object
        Public dbLokal As Object

        Public dbType As String
        Public schemaTmp As String
        Public schemaHRD As String

        Public comm As Object
        Public adapter As Object
        Public reader As Object
        Public transaction As Object
    End Structure

    Public Structure UserInfo
        Dim username As String
        Dim name As String
        Dim kodePegawai As String
        Dim isLogin As Boolean
        Dim isFirstAccount As Boolean
        Dim isSuperuser As Boolean
        Dim T_USER_RIGHT As DataTable
    End Structure

    Public Structure ProgramInfo
        Dim name As String
        Dim type As String
        Dim isActivated As Boolean
    End Structure

    Public Structure AddInfo
        Dim newValues As String
        Dim newFields As String
        Dim updateString As String
    End Structure

    Public Structure CompanyInfo
        Dim name As String
        Dim owner As String
    End Structure

    Public CONN_ As DBConn
    Public USER_ As UserInfo
    Public PROGRAM_ As ProgramInfo
    Public ADD_INFO_ As AddInfo
    Public COMPANY_ As CompanyInfo
End Module
