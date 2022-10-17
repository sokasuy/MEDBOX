Public Class FormLogin
    'Private isClose As Boolean

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            Call myCStartup.StartUp("MAIN", COMPANY_.name, PROGRAM_.name, PROGRAM_.type, CONN_.dbMain, CONN_.dbLokal, CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbFinger, CONN_.dbMySql)

            CONN_.dbType = CONN_.dbType.ToLower

            If (CONN_.dbType = "sqlsrv") Then
                CONN_.dbType = "sql"
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "PROGRAM GAGAL DIJALANKAN!!")
        End Try
    End Sub

    Private Sub FormLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            'If Not isClose Then
            '    Dim isKeluar As Integer
            '    isKeluar = myCShowMessage.GetUserResponse("Apakah anda yakin ingin keluar??", "KONFIRMASI")
            '    If (isKeluar = 6) Then
            '        Application.Exit()
            '    End If
            'End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormLogin_FormClosed Error")
        End Try
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormLogin_Load Error")
        End Try
    End Sub

    Private Sub FormLogin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            Cursor = Cursors.Default
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormLogin_Activated Error")
        End Try
    End Sub

    Private Sub FormLogin_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tbUserID.KeyDown, tbPassword.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbPassword) Then
                    btnMasuk_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormLogin_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Try
            Dim isConfirm = myCShowMessage.GetUserResponse("Apakah anda yakin ingin keluar??", "KONFIRMASI")
            If (isConfirm = DialogResult.Yes) Then
                Application.Exit()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnKeluar_Click Error")
        End Try
    End Sub

    Private Sub btnMasuk_Click(sender As Object, e As EventArgs) Handles btnMasuk.Click
        Try
            If (Trim(tbUserID.Text).Length > 0 And Trim(tbPassword.Text).Length > 0) Then
                Dim stSQL As String
                Dim isExist As Boolean
                Dim myUserInformation As New DataTable
                Dim mProgramName As String
                Dim mCompanyName As String

                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "userid", CONN_.schemaHRD & ".msuser", "userid='" & myCStringManipulation.SafeSqlLiteral(tbUserID.Text) & "'and passwd='" & myCStringManipulation.GetSHA1Hash(tbPassword.Text) & "' and block='False'")

                If (isExist) Then
                    USER_.username = Trim(tbUserID.Text)
                    stSQL = "SELECT superuser,lokasi FROM " & CONN_.schemaHRD & ".msuser WHERE userid='" & myCStringManipulation.SafeSqlLiteral(tbUserID.Text) & "'and passwd='" & myCStringManipulation.GetSHA1Hash(tbPassword.Text) & "'"
                    myUserInformation = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_UserInformation")

                    USER_.isSuperuser = myUserInformation.Rows(0).Item("superuser")
                    USER_.lokasi = myUserInformation.Rows(0).Item("lokasi")

                    Call myCShowMessage.ShowInfo("SELAMAT DATANG " & USER_.username.ToUpper, "WELCOME")

                    ADD_INFO_.newValues = "'" & USER_.username & "'"
                    ADD_INFO_.newFields = "userid"

                    ADD_INFO_.updateString = "userid='" & USER_.username & "',updated_at=clock_timestamp()"

                    mProgramName = PROGRAM_.name
                    mCompanyName = COMPANY_.name

                    USER_.isLogin = True

                    Dim frmUtama As New FormUtama

                    If (USER_.isSuperuser) Then
                        frmUtama.Text = "[" & mCompanyName.ToUpper & "] - [" & mProgramName.ToUpper & "] - [" & USER_.username.ToUpper & " - SUPERUSER]"
                    Else
                        frmUtama.Text = "[" & mCompanyName.ToUpper & "] - [" & mProgramName.ToUpper & "] - [" & USER_.username.ToUpper & "]"
                    End If

                    frmUtama.Show()
                    Me.Owner = frmUtama
                    Me.Hide()
                    'Me.Close()
                    'Me.Dispose()
                Else
                    'kalau tidak terdaftar userid nya atau passwordnya salah berarti tampilkan pesan login gagal
                    Call myCShowMessage.ShowWarning("Nama pengguna atau sandi tidak cocok", "LOGIN GAGAL")
                    tbPassword.Clear()
                    tbPassword.Focus()
                End If
            Else
                Call myCShowMessage.ShowWarning("Username dan password tidak lengkap!!", "Perhatian")
                tbPassword.Clear()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnMasuk_Click Error")
        End Try
    End Sub

    Private Sub tbPassword_Enter(sender As Object, e As EventArgs) Handles tbPassword.Enter
        Try
            tbPassword.SelectAll()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbPassword_Enter Error")
        End Try
    End Sub
End Class