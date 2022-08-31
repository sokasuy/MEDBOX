Public Class FormGantiGambarBG
    Private stSQL As String
    Private myDataTableListGambar As New DataTable
    'Private myBindingListGambar As New BindingSource
    Private mulai As Boolean
    Private pathToPic As String = Nothing
    Private newValues As String
    Private newFields As String
    Private isExist As Boolean
    Const STR_MYCOMPUTER_CLSID As String = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"
    Private FormUtama As Form
    Private isDataPrepared As Boolean

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaHRD As String, _connMain As Object, _connLokal As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String, ByRef _formUtama As Form)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            isDataPrepared = False
            With CONN_
                .dbType = _dbType
                .dbMain = _connMain
                .dbLokal = _connLokal
                .schemaTmp = _schemaTmp
                .schemaHRD = _schemaHRD
            End With
            With USER_
                .username = _username
                .isSuperuser = _superuser
                .T_USER_RIGHT = _dtTableUserRights
            End With
            With ADD_INFO_
                .newValues = _addNewValues
                .newFields = _addNewFields
                .updateString = _addUpdateString
            End With
            FormUtama = _formUtama
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormGantiGambarBG Error")
        End Try
    End Sub

    Private Sub FormGantiGambarBG_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub SetListBG(_conn As Object, _comm As Object, _reader As Object)
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(_conn)

            stSQL = "SELECT file_name, (file_name & '.' & extension) as gambar, dipakai " &
                    "FROM (T_ImgRes) " &
                    "GROUP BY file_name, extension, file_name & '.' & extension, dipakai, nomer " &
                    "ORDER BY nomer;"
            myDataTableListGambar = myCDBOperation.GetDataTableUsingReader(_conn, _comm, _reader, stSQL, "T_ImgRes")
            'myBindingListGambar.DataSource = myDataTableListGambar
            With lstBG
                .DataSource = myDataTableListGambar
                .DisplayMember = "file_name"
                .ValueMember = "gambar"
            End With

            Dim foundRows() As DataRow
            foundRows = myDataTableListGambar.Select("dipakai=True")

            mulai = True

            If (foundRows.Length > 0) Then
                lstBG.SelectedIndex = myDataTableListGambar.Rows.IndexOf(foundRows(0))
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetListBG Error")
        Finally
            Call myCDBConnection.CloseConn(_conn, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormGantiGambarBG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With ofdPic
                .InitialDirectory = STR_MYCOMPUTER_CLSID
                .Title = "Pilih File Gambar"
                .Multiselect = False
                .Filter = "Image Files (*.gif;*.jpg;*.jpeg;*.bmp;*.wnf;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wnf;*.png"
                .FilterIndex = 1
            End With

            Call SetListBG(CONN_.dbLokal, CONN_.comm, CONN_.reader)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormGantiGambarBG_Load Error")
        End Try
    End Sub

    Private Sub lstBG_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBG.SelectedIndexChanged
        Try
            If (mulai) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbLokal)

                pbBG.BackgroundImage = Image.FromFile("ImgRes/" & lstBG.SelectedValue)
                pbBG.BackgroundImageLayout = ImageLayout.Stretch
                FormUtama.BackgroundImage = Image.FromFile("ImgRes/" & lstBG.SelectedValue)
                FormUtama.BackgroundImageLayout = ImageLayout.Stretch

                Call myCDBOperation.UpdateData(CONN_.dbLokal, CONN_.comm, "T_ImgRes", "dipakai=False")
                Call myCDBOperation.UpdateData(CONN_.dbLokal, CONN_.comm, "T_ImgRes", "dipakai=True", "[file_name]='" & DirectCast(lstBG.SelectedItem, DataRowView).Item("file_name") & "' and [extension]='" & lstBG.SelectedValue.ToString.Substring(lstBG.SelectedValue.ToString.LastIndexOf(".") + 1, lstBG.SelectedValue.ToString.Length - lstBG.SelectedValue.ToString.LastIndexOf(".") - 1) & "'")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "lstBG_SelectedIndexChanged Error")
        Finally
            If (mulai) Then
                Call myCDBConnection.CloseConn(CONN_.dbLokal, -1)
                Me.Cursor = Cursors.Default
            End If
        End Try
    End Sub

    Private Sub tbBrowseGambar_Click(sender As Object, e As EventArgs) Handles tbBrowseGambar.Click
        'OK
        Try
            'ofd1.InitialDirectory = Application.StartupPath
            ofdPic.ShowDialog()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbBrowseGambar_Click Error")
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'OK
        Try
            'ofd1.InitialDirectory = Application.StartupPath
            ofdPic.ShowDialog()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBrowse_Click Error")
        End Try
    End Sub

    Private Sub ofdPic_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdPic.FileOk
        Try
            Dim namaGbr As String
            Dim namaGbrSaja As String
            Dim extGbr As String

            namaGbr = ofdPic.SafeFileName
            pathToPic = ofdPic.FileName
            If (pathToPic.Length < 240) Then
                Me.tbBrowseGambar.Text = namaGbr
                myCFileIO.CopyFile(pathToPic, Application.StartupPath & "\ImgRes\" & namaGbr)

                Dim foundRows() As DataRow
                foundRows = myDataTableListGambar.Select("dipakai=True")
                If (foundRows.Length > 0) Then
                    myDataTableListGambar.Rows(myDataTableListGambar.Rows.IndexOf(foundRows(0))).Item("dipakai") = False
                    lstBG.SelectedIndex = myDataTableListGambar.Rows.IndexOf(foundRows(0))
                End If

                Dim newListGambar As DataRow = myDataTableListGambar.NewRow()
                newListGambar("file_name") = namaGbr.Substring(0, namaGbr.LastIndexOf("."))
                newListGambar("gambar") = namaGbr
                newListGambar("dipakai") = True

                'memasukkan row baru tersebut ke data table gambar
                myDataTableListGambar.Rows.Add(newListGambar)
                myDataTableListGambar.AcceptChanges()

                Call myCDBConnection.OpenConn(CONN_.dbLokal)
                namaGbrSaja = namaGbr.Substring(0, namaGbr.LastIndexOf("."))
                extGbr = namaGbr.Substring(namaGbr.LastIndexOf(".") + 1, namaGbr.Length - namaGbr.LastIndexOf(".") - 1)
                isExist = myCDBOperation.IsExistRecords(CONN_.dbLokal, CONN_.comm, CONN_.reader, "file_name", "T_ImgRes", "[file_name]='" & myCStringManipulation.SafeSqlLiteral(namaGbrSaja, 1) & "' and [extension]='" & Trim(extGbr) & "'")
                If Not (isExist) Then
                    newValues = "'" & myCStringManipulation.SafeSqlLiteral(namaGbrSaja, 1) & "','" & Trim(extGbr) & "',True"
                    newFields = "[file_name],[extension],dipakai"
                    Call myCDBOperation.InsertData(CONN_.dbLokal, CONN_.comm, "T_ImgRes", newValues, newFields)
                    If (foundRows.Length > 0) Then
                        Call myCDBOperation.UpdateData(CONN_.dbLokal, CONN_.comm, "T_ImgRes", "dipakai=False", "[file_name]='" & myCStringManipulation.SafeSqlLiteral(DirectCast(lstBG.SelectedItem, DataRowView).Item("file_name"), 1) & "' and [extension]='" & lstBG.SelectedValue.ToString.Substring(lstBG.SelectedValue.ToString.LastIndexOf(".") + 1, lstBG.SelectedValue.ToString.Length - lstBG.SelectedValue.ToString.LastIndexOf(".") - 1) & "'")
                    End If
                End If

                With lstBG
                    .DataSource = myDataTableListGambar
                    .DisplayMember = "file_name"
                    .ValueMember = "gambar"
                    .Update()
                    .Refresh()
                    foundRows = myDataTableListGambar.Select("dipakai=True")
                    .SelectedIndex = myDataTableListGambar.Rows.IndexOf(foundRows(0))
                End With
            Else
                Call myCShowMessage.ShowWarning("Nama file gambar terlalu panjang" & ControlChars.NewLine & "Ubah dulu nama file gambarnya!", "PERHATIAN")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ofdPic_FileOk Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbLokal, -1)
        End Try
    End Sub
End Class