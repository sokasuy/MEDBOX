Public Class CStartup
    Private pathFileSetting As String

    Public Sub StartUp(ByVal _segmen As String, ByRef _companyName As String, ByRef _programName As String, ByRef _programType As String, ByRef _connMain As Object, ByRef _connLokal As Object, ByRef _dbType As String, ByRef _schemaTmp As String, ByRef _schemaHRD As String, ByRef _connFinger As Object)
        Try
            If (_segmen = "MAIN") Then
                'SEKARANG PAKAI INI DULU
                pathFileSetting = Application.StartupPath & "\SETTING.ini"

                'Ambil Company Info
                _companyName = myCFileIO.ReadIniFile("COMPANY_INFO", "COMPANY_NAME", pathFileSetting)

                'Ambil Program Info
                _programName = myCFileIO.ReadIniFile("PROGRAM_INFO", "P_NAME", pathFileSetting)
                _programType = myCFileIO.ReadIniFile("PROGRAM_INFO", "P_TYPE", pathFileSetting)
                'backupType = myCFileIO.ReadIniFile("BACKUP", "B_TIPE", FilePathFileName)

                'Untuk ambil tipe databasenya
                _dbType = myCFileIO.ReadIniFile("DATABASE", "DBTYPE", pathFileSetting)
                'Untuk ambil schema nya, jika diperlukan
                _schemaTmp = myCFileIO.ReadIniFile(_dbType, "SCHEMA_TMP", pathFileSetting)
                _schemaHRD = myCFileIO.ReadIniFile(_dbType, "SCHEMA_HRD", pathFileSetting)
                'UNTUK DATABASE UTAMA POSTGRESQL
                Call myCDBConnection.SetDBParameter(_connMain, _dbType, "SERVER_NAME", "DB_NAME", "", pathFileSetting, "PORT", "postgres", "1234567", "")

                'UNTUK DATABASE ACCESS FINGERPRINT
                Call myCDBConnection.SetDBParameter(_connFinger, "ACCESS", "", "PATHDB_Finger", "PRVDRTYPE", pathFileSetting, "")

                'UNTUK ACCESS, DATABASE PEMBANTU
                '10 Maret 2022 Ditutup dulu, tidak dipakai untuk sekarang
                'Call myCDBConnection.SetDBParameter(_connLokal, "ACCESS", "", "PATHDB_Lokal", "PRVDRTYPE", pathFileSetting, "")
            Else
                'INI GAK DIPAKAI
                'Ini hanya dipakai kalau ada 2 atau lebih perusahaan yang menggunakan 1 program, dan menggunakan database atau server yang berbeda
                'Ditaruh di sini agar SETTING.ini nya bisa berdiri sendiri2
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "StartUp Error")
        End Try
    End Sub

End Class
