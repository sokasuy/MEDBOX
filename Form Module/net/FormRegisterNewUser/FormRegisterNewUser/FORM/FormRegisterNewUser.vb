Public Class FormRegisterNewUser

    Private newValues As String
    Private newFields As String
    Private stSQL As String
    Private myDataTableCboLokasi As New DataTable
    Private myBindingLokasi As New BindingSource
    Private isCboPrepared As Boolean

    Public Sub New(_dbType As String, _connMain As Object, _addNewValues As String, _addNewFields As String, _schemaTmp As String, _schemaHRD As String)
        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            With CONN_
                .dbType = _dbType
                .dbMain = _connMain
                .schemaTmp = _schemaTmp
                .schemaHRD = _schemaHRD
            End With

            With ADD_INFO_
                .newValues = _addNewValues
                .newFields = _addNewFields
            End With
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormRegisterNewUser Error")
        End Try
    End Sub

    Private Sub FormRegisterNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormRegisterNewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT keterangan FROM " & CONN_.schemaHRD & ".msgeneral where kategori='lokasi' order by keterangan;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboLokasi, myBindingLokasi, cboLokasi, "T_" & cboLokasi.Name, "keterangan", "keterangan", isCboPrepared)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormRegisterNewUser_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormRegisterNewUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbUserID.KeyDown, tbPassword.KeyDown, cboLokasi.KeyDown, cbSuperuser.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is cboLokasi) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormRegisterNewUser_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    Private Sub ClearForm()
        Try
            tbUserID.Clear()
            tbPassword.Clear()
            cbSuperuser.Checked = False
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ClearForm Error")
        End Try
    End Sub
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If (Trim(tbUserID.Text).Length > 0 And Trim(tbPassword.Text).Length > 0 And (cboLokasi.SelectedIndex <> -1 Or cbSemuaLokasi.Checked)) Then
                Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim isExist As Boolean
                isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaHRD & ".msuser", "userid='" & myCStringManipulation.SafeSqlLiteral(tbUserID.Text) & "'")

                If Not isExist Then
                    newValues = "'" & myCStringManipulation.SafeSqlLiteral(tbUserID.Text) & "','" & myCStringManipulation.GetSHA1Hash(tbPassword.Text) & "','" & cbSuperuser.Checked & "','" & IIf(cbSemuaLokasi.Checked, "All", myCStringManipulation.SafeSqlLiteral(cboLokasi.SelectedValue)) & "'," & ADD_INFO_.newValues
                    newFields = "userid,passwd,superuser,lokasi," & ADD_INFO_.newFields
                    Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, CONN_.schemaHRD & ".msuser", newValues, newFields)
                Else
                    Call myCShowMessage.ShowWarning("User ID " & Trim(tbUserID.Text) & " sudah ada!")
                End If
                Call myCShowMessage.ShowInfo("Penambahan user " & Trim(tbUserID.Text) & " berhasil")

                Call ClearForm()
            Else
                Call myCShowMessage.ShowWarning("Semua data harus dilengkapi terlebih dahulu!!")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cbSemuaLokasi_CheckedChanged(sender As Object, e As EventArgs) Handles cbSemuaLokasi.CheckedChanged
        Try
            If (cbSemuaLokasi.Checked) Then
                cboLokasi.Enabled = False
            Else
                cboLokasi.Enabled = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cbSemuaLokasi_CheckedChanged Error")
        End Try
    End Sub
End Class
