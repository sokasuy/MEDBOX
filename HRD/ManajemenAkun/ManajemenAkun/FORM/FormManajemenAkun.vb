Public Class FormManajemenAkun
    Private newValues As String
    Private newFields As String

    Private Sub FormManajemenAkun_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Call myCStartup.StartUp("MAIN", PROGRAM_.name, PROGRAM_.type, CONN_.dbMain, CONN_.dbLokal, CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD)

            ADD_INFO_.newValues = "'Yusak'"
            ADD_INFO_.newFields = "superid"

            ADD_INFO_.updateString = "superid='Yusak',updated_at=clock_timestamp()"

            CONN_.dbType = CONN_.dbType.ToLower

            If (CONN_.dbType = "sqlsrv") Then
                CONN_.dbType = "sql"
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormManajemenAkun_Load Error")
        End Try
    End Sub

    Private Sub mnRegisterNewUser_Click(sender As Object, e As EventArgs) Handles mnRegisterNewUser.Click
        Dim frmRegisterNewUser As New FormRegisterNewUser.FormRegisterNewUser(CONN_.dbType, CONN_.dbMain, ADD_INFO_.newValues, ADD_INFO_.newFields, CONN_.schemaTmp, CONN_.schemaHRD)
        Call myCFormManipulation.GoToForm(Me, frmRegisterNewUser)
    End Sub

    Private Sub mnReviewUser_Click(sender As Object, e As EventArgs) Handles mnReviewUser.Click
        Dim frmReviewUser As New FormReviewUser.FormReviewUser(CONN_.dbType, CONN_.dbMain, CONN_.schemaTmp, CONN_.schemaHRD, ADD_INFO_.updateString)
        Call myCFormManipulation.GoToForm(Me, frmReviewUser)
    End Sub

    Private Sub mnReviewUserRight_Click(sender As Object, e As EventArgs) Handles mnReviewUserRight.Click
        Dim frmReviewUserRight As New FormReviewUserRight.FormReviewUserRight(CONN_.dbType, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, CONN_.schemaTmp, CONN_.schemaHRD)
        Call myCFormManipulation.GoToForm(Me, frmReviewUserRight)
    End Sub
End Class
