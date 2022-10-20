Public Class FormUtama
    Private stSQL As String
    Private isStarted As Boolean

    Private Sub FormUtama_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            'Dim isKeluar As Integer
            'isKeluar = myCShowMessage.GetUserResponse("Apakah anda yakin ingin keluar??", "KONFIRMASI")

            'If (isKeluar = 6) Then
            '    Application.Exit()
            'End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormUtama_FormClosed Error")
        End Try
    End Sub

    Private Sub FormUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Note: You shouldn't change the system-wide settings through your application. This one below to change the settings only in your application.
            Application.CurrentCulture = New Globalization.CultureInfo("en-US")

            Call GetUserRight()

            'Dim myDataTablePic As New DataTable
            'Call myCDBConnection.OpenConn(CONN_.dbLokal)
            'stSQL = "SELECT file_name, extension " &
            '       "FROM (T_ImgRes) " &
            '       "WHERE (dipakai = True);"
            'myDataTablePic = myCDBOperation.GetDataTableUsingReader(CONN_.dbLokal, CONN_.comm, CONN_.reader, stSQL, "T_ImgRes")
            'Call myCDBConnection.CloseConn(CONN_.dbLokal)
            'If (myDataTablePic.Rows.Count > 0) Then
            '    Me.BackgroundImage = Image.FromFile("ImgRes/" & myDataTablePic.Rows(0).Item("file_name") & "." & myDataTablePic.Rows(0).Item("extension"))
            '    Me.BackgroundImageLayout = ImageLayout.Stretch
            'End If
            mnGroupPengaturan.Visible = False
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormUtama_Load Error")
        End Try
    End Sub

    Private Sub FormUtama_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            If Not (isStarted) Then
                USER_.T_USER_RIGHT = New DataTable
                isStarted = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormUtama_Activated Error")
        End Try
    End Sub

    Private Sub GetUserRight()
        Try
            'Dim myDataTableMenuAvailable As New DataTable
            Dim foundRows As DataRow()

            If (USER_.isSuperuser) Then
                'Kalau superuser bisa akses semua
            Else
                'Kalau bukan superuser
                stSQL = "SELECT u.formname,f.menucode, f.groupmenucode, u.melihat, u.menambah, u.memperbaharui, u.menghapus
                        FROM " & CONN_.schemaHRD & ".msformlist as f INNER JOIN " & CONN_.schemaHRD & ".msuserright as u ON f.formname = u.formname
                        WHERE (((u.userid)='" & myCStringManipulation.SafeSqlLiteral(USER_.username) & "') AND ((f.block)='False'))
                        ORDER BY f.groupmenucode ASC;"
                USER_.T_USER_RIGHT = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_UserRights")

                For i As Integer = 0 To mnStripUtama.Items.Count - 1
                    foundRows = USER_.T_USER_RIGHT.Select("groupmenucode='" & mnStripUtama.Items(i).Name & "'")
                    If (foundRows.Length = 0) Then
                        mnStripUtama.Items(i).Visible = False
                    Else
                        mnStripUtama.Items(i).Visible = True
                    End If
                    Dim toolScriptItem As ToolStripItemCollection = (CType(mnStripUtama.Items(i), ToolStripMenuItem)).DropDownItems
                    For Each menuItem As ToolStripItem In toolScriptItem
                        foundRows = USER_.T_USER_RIGHT.Select("menucode='" & menuItem.Name & "'")
                        If (foundRows.Length = 0) Then
                            menuItem.Visible = False
                        Else
                            menuItem.Visible = True
                        End If
                    Next
                Next

                mnExit.Visible = True
                mnLogout.Visible = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetUserRight Error")
        End Try
    End Sub

    Private Sub mnLogout_Click(sender As Object, e As EventArgs) Handles mnLogout.Click
        Try
            'Dim frmLogin As New FormLogin()
            Me.Hide()
            'Me.Dispose()
            FormLogin.Activate()
            FormLogin.Show()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "mnLogout_Click Error")
        End Try
    End Sub

    Private Sub mnExit_Click(sender As Object, e As EventArgs) Handles mnExit.Click
        Try
            Dim isKeluar As Integer
            isKeluar = myCShowMessage.GetUserResponse("Apakah anda yakin ingin keluar??", "KONFIRMASI")

            If (isKeluar = 6) Then
                Application.Exit()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "mnExit_click Error")
        End Try
    End Sub

    Private Sub mnMasterDataKaryawan_Click(sender As Object, e As EventArgs) Handles mnMasterDataKaryawan.Click
        Dim frmMasterKaryawan As New FormMasterKaryawan.FormMasterKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmMasterKaryawan)
    End Sub

    Private Sub mnMasterKaryawanAktif_Click(sender As Object, e As EventArgs) Handles mnMasterKaryawanAktif.Click
        Dim frmMasterKaryawanAktif As New FormMasterKaryawanAktif.FormMasterKaryawanAktif(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmMasterKaryawanAktif)
    End Sub

    Private Sub mnMasterRekeningKaryawan_Click(sender As Object, e As EventArgs) Handles mnMasterRekeningKaryawan.Click
        Dim frmMasterRekeningKaryawan As New FormMasterRekeningKaryawan.FormMasterRekeningKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmMasterRekeningKaryawan)
    End Sub

    Private Sub mnPengalamanKerjaKaryawan_Click(sender As Object, e As EventArgs) Handles mnPengalamanKerjaKaryawan.Click
        Dim frmPengalamanKerjaKaryawan As New FormPengalamanKerjaKaryawan.FormPengalamanKerjaKaryawan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmPengalamanKerjaKaryawan)
    End Sub

    Private Sub mnSuratPeringatan_Click(sender As Object, e As EventArgs) Handles mnSuratPeringatan.Click
        Dim frmSuratPeringatan As New FormSuratPeringatan.FormSuratPeringatan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmSuratPeringatan)
    End Sub

    Private Sub mnSuratIjinAbsen_Click(sender As Object, e As EventArgs) Handles mnSuratIjinAbsen.Click
        Dim frmIjinAbsen As New FormIjinAbsen.FormIjinAbsen(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmIjinAbsen)
    End Sub

    Private Sub mnSuratPerintahLembur_Click(sender As Object, e As EventArgs) Handles mnSuratPerintahLembur.Click
        Dim frmSuratPerintahLembur As New FormSuratPerintahLembur.FormMasterSuratPerintahLembur(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmSuratPerintahLembur)
    End Sub

    Private Sub mnSuratPerintahKerja_Click(sender As Object, e As EventArgs) Handles mnSuratPerintahKerja.Click
        Dim frmSuratPerintahKerja As New FormSuratPerintahKerja.FormMasterSuratPerintahKerja(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmSuratPerintahKerja)
    End Sub

    Private Sub mnKalenderPerusahaan_Click(sender As Object, e As EventArgs) Handles mnKalenderPerusahaan.Click
        Dim frmKalenderPerusahaan As New FormKalenderPerusahaan.FormKalenderPerusahaan(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmKalenderPerusahaan)
    End Sub

    Private Sub mnImportData_Click(sender As Object, e As EventArgs) Handles mnImportData.Click
        Dim frmImportData As New FormImportData.FormImportData(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString)
        Call myCFormManipulation.GoToForm(Me, frmImportData)
    End Sub

    Private Sub mnProsesPresensi_Click(sender As Object, e As EventArgs) Handles mnProsesPresensi.Click
        Dim frmProsesPresensi As New FormProsesPresensi.FormProsesPresensi(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, CONN_.dbFinger, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmProsesPresensi)
    End Sub

    Private Sub mnViewDataPresensi_Click(sender As Object, e As EventArgs) Handles mnViewPresensi.Click
        Dim frmView As New FormView.FormView(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, "Presensi", USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmView)
    End Sub

    Private Sub mnMasterSkemaPresensi_Click(sender As Object, e As EventArgs) Handles mnMasterSkemaPresensi.Click
        Dim frmMasterSkemaPresensi As New FormMasterSkemaPresensi.FormMasterSkemaPresensi(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmMasterSkemaPresensi)
    End Sub

    Private Sub mnScheduleShift_Click(sender As Object, e As EventArgs) Handles mnScheduleShift.Click
        Dim frmScheduleShift As New FormScheduleShift.FormMasterScheduleShift(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmScheduleShift)
    End Sub

    Private Sub mnMasterGeneral_Click(sender As Object, e As EventArgs) Handles mnMasterGeneral.Click
        Dim frmMasterGeneral As New FormMasterGeneral.FormMasterGeneral(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString)
        Call myCFormManipulation.GoToForm(Me, frmMasterGeneral)
    End Sub

    Private Sub mnGantiGambarBG_Click(sender As Object, e As EventArgs) Handles mnGantiGambarBG.Click
        Dim frmGantiGambarBG As New FormGantiGambarBG.FormGantiGambarBG(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, CONN_.dbLokal, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me)
        Call myCFormManipulation.GoToForm(Me, frmGantiGambarBG)
    End Sub

    Private Sub mnProsesPayroll_Click(sender As Object, e As EventArgs) Handles mnProsesPayroll.Click
        Dim frmProsesPayroll As New FormProsesPayroll.FormProsesPayroll(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi, CONN_.dbMySql)
        Call myCFormManipulation.GoToForm(Me, frmProsesPayroll)
    End Sub

    Private Sub mnTunjanganMasaKerja_Click(sender As Object, e As EventArgs) Handles mnTunjanganMasaKerja.Click
        Dim frmMasterTunjanganMasaKerja As New FormMasterTunjanganMasaKerja.FormMasterTunjanganMasaKerja(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmMasterTunjanganMasaKerja)
    End Sub

    Private Sub mnViewFingerprint_Click(sender As Object, e As EventArgs) Handles mnViewFingerprint.Click
        Dim frmView As New FormView.FormView(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaHRD, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, "Fingerprint", USER_.lokasi)
        Call myCFormManipulation.GoToForm(Me, frmView)
    End Sub
End Class
