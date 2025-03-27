Imports System.Windows.Forms
Imports Ionic.Zip
Imports System.ComponentModel
Imports System.Net


Public Class frmRestore
    Private _backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private _operationCancelled As Boolean
    Private nFilesCompleted As Integer
    Private totalEntriesToProcess As Integer

    Private Delegate Sub ZipProgress(ByVal e As ExtractProgressEventArgs)
    Private ftpServer As String = ""
    Private ftpU As String = ""
    Private ftpP As String = ""

    'for FTP Download
    Private WithEvents myFtpDownloadWebClient As New System.Net.WebClient
    'for FTP Download

Dim WithEvents CopyFiles As FileCopy

    ' Declare delegate handlers for the copy, count, mirror and backup events
    Public Delegate Sub CopyHandler(ByVal FilePath As String, ByVal FileSize As Long, ByVal FileCount As Long)
    Public Delegate Sub CountHandler(ByVal FileCount As Long, ByVal FolderCount As Long)
    Public Delegate Sub MirrorHandler(ByVal FilePath As String, ByVal FileCount As Long, ByVal FolderCount As Long)
    Public Delegate Sub MirrorStartedHandler()
    Public Delegate Sub BackupHandler()
    Public Delegate Sub WorkingHandler()

    ' Private variables
    Private _totalFiles As Long = 0
    Private _totalFolders As Long = 0
    Private _copiedFiles As Long = 0
    Private _rootDir As String = ""
    Private _logFile As String
    Private _stopped As Boolean = False
    Private _copyStatus As String = "Status: Copying and Counting. "
    Private _deletedCount As Long = 0
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmRestore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lvBackupName.Items.Clear()
            If IO.Directory.Exists(strCurPath + "\Data") = False Then Exit Sub
            Dim files() As String = System.IO.Directory.GetFiles(strCurPath + "\Data", "*.db")
            For Each file As String In files
                'Dim text As String = IO.File.ReadAllText(file)
                Call FillTaskName(file)
            Next
            If LVTaskName.Items.Count <> 0 Then LVTaskName.Items(0).Selected = True : LVTaskName.Select()


        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error occured while loading backup items, Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub
    Private Sub FillFTPSetting(ByVal tName As String)
        Try
            Dim strDir As String = MainForm.strFTPDirNm

            'lblMessage.Visible = True
            Dim ftpreq As FtpWebRequest = DirectCast(WebRequest.Create(ftpServer + strDir), FtpWebRequest)
            ftpreq.Credentials = New NetworkCredential(ftpU, ftpP)
            ftpreq.Method = WebRequestMethods.Ftp.ListDirectory

            Dim ftpres As FtpWebResponse = DirectCast(ftpreq.GetResponse(), FtpWebResponse)
            Dim resst As New System.IO.StreamReader(ftpres.GetResponseStream())
            Dim dir As New List(Of String)
            Dim line As String = resst.ReadLine

            While Not String.IsNullOrEmpty(line)
                dir.Add(line)
                line = resst.ReadLine
            End While
            resst.Close()
            ftpres.Close()
            Dim result As String = "0"
            Dim count As Integer = 0
            Dim endof As Integer = dir.Count - 1
            Dim strFileSize As String = ""
            For c As Integer = 0 To endof
                If dir.Item(count).ToString.Contains(tName) Then
                    result = dir.Item(count).ToString
                    'test

                    'test

                    Dim li As ListViewItem = lvBackupName.Items.Add(result)
                    li.SubItems.Add("Zip File")
                    li.SubItems.Add("-")
                    li.SubItems.Add("FTP") 'Server Name
                    li.SubItems.Add("-") 'Date
                    li.SubItems.Add("-") 'Time
                Else
                End If

                count = count + 1
            Next
            'If result = "" Then
            'result = "0.0.0.0"
            'lbl_upstat.Text = "Oops, cant find the new file, try again later."
            'Exit S6ub
            'End If
            'lblMessage.Visible = False
            '           result = result.TrimEnd("r", "e", "v", ".")
            '            MsgBox(result)

            'avver = result
            'lbl_avver.Text = "The newest version is " & result

        Catch webex As WebException
            MessageBox.Show("FTP server is not responding, please check your ftp settings.")
            'lbl_upstat.Text = "Oops, the server is acting up, try again later."
        Catch e As Exception
            MessageBox.Show("Oops, FTP Server not responding, check your internet connectivity")
        End Try

    End Sub


    Private Sub FillTaskName(ByVal strFLNM As String)
        Try
            Dim strTmp As String = ""
            Dim strCode As String = ""
            Dim ini As New IniFile(strFLNM)
            Dim strTimeVar As String = ""


            strCode = (System.IO.Path.GetFileNameWithoutExtension(strFLNM))
            strCode = strCode.Replace("FLSet", "")

            strTimeVar = ini.ReadValue("TEvent", "TDone")
            ' if last done TIme is not present, need to investingate for task edit.
            ' If strTimeVar.Length = 0 Then Exit Sub


            Dim LVWitem As ListViewItem = LVTaskName.Items.Add(strCode)
            strTmp = ini.ReadValue("Sch", "TName")
            LVWitem.SubItems.Add(strTmp)

            ini = Nothing
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub
    Private Sub FillLVBackup(ByVal strCode As String, ByVal showFTP As Boolean)
        Try
            Dim strTmp As String = ""
            Dim strPath As String = ""
            Dim strBackupType As String = ""

            'MsgBox(LVTaskName.SelectedItems(0).SubItems(1).Text)
            lvBackupName.Items.Clear()
            Dim ini As New IniFile(strCurPath & "\Data\FLSet" + strCode + ".db")
            Dim j As Integer = 0
            'strTmp = ini.ReadValue("Dest", "Zip")


            'If strTmp = 1 Then 'zip file
            strBackupType = ini.ReadValue("Dest", "BMode")
            If strBackupType = "IB" Then
                strBackupType = "Incremental"
            ElseIf strBackupType = "DB" Then
                strBackupType = "Decremental"
            Else
                strBackupType = "Full Backup"
            End If
            strTmp = ini.ReadValue("Dest", "DirT")
            If strTmp.Length <> 0 Then
                For i = 0 To CDbl(strTmp) - 1
                    strPath = ini.ReadValue("Dest", "DirPath" + i.ToString)
                    If IO.Directory.Exists(strPath) = False Then Continue For
                    Dim files() As String = System.IO.Directory.GetFiles(strPath, LVTaskName.SelectedItems(0).SubItems(1).Text + "*.zip")
                    For Each file As String In files
                        lvBackupName.Items.Add(file)
                        Dim file1 = New System.IO.FileInfo(file)
                        lvBackupName.Items(j).SubItems.Add(strBackupType)
                        'lvBackupName.Items(j).SubItems.Add("Zip File")
                        lvBackupName.Items(j).SubItems.Add(SizeToMBStr(file1.Length))
                        lvBackupName.Items(j).SubItems.Add("Local")
                        lvBackupName.Items(j).SubItems.Add(file1.CreationTime.ToString("dd/MM/yyyy"))
                        lvBackupName.Items(j).SubItems.Add(file1.CreationTime.ToString("hh:mm:tt"))
                        lvBackupName.Items(j).SubItems.Add("Z")

                        j = j + 1
                    Next
                Next
            End If
            'Else ' as it is
            If strTmp.Length <> 0 Then
                strTmp = ini.ReadValue("Dest", "DirT")
                For i = 0 To CDbl(strTmp) - 1
                    strPath = ini.ReadValue("Dest", "DirPath" + i.ToString)
                    If IO.Directory.Exists(strPath) = False Then Continue For
                    Dim files() As String = System.IO.Directory.GetDirectories(strPath, LVTaskName.SelectedItems(0).SubItems(1).Text + "*.")
                    For Each file As String In files
                        lvBackupName.Items.Add(file)
                        Dim file1 = New System.IO.DirectoryInfo(file)

                        Dim dInfo As New System.IO.DirectoryInfo(file)
                        Dim sizeOfDir As Long = DirectorySize(dInfo, True)
                        lvBackupName.Items(j).SubItems.Add(strBackupType)
                        'lvBackupName.Items(j).SubItems.Add("Directory")
                        lvBackupName.Items(j).SubItems.Add(SizeToMBStr(sizeOfDir))
                        lvBackupName.Items(j).SubItems.Add("Local")
                        lvBackupName.Items(j).SubItems.Add(file1.CreationTime.ToString("dd/MM/yyyy"))
                        lvBackupName.Items(j).SubItems.Add(file1.CreationTime.ToString("hh:mm:tt"))
                        lvBackupName.Items(j).SubItems.Add("D")
                        j = j + 1
                    Next

                Next
            End If
            If showFTP = True Then
                strTmp = ini.ReadValue("Dest", "FTP")
                If strTmp = "0" Then Exit Sub
                strTmp = ini.ReadValue("Dest", "FTPS")
                If strTmp = String.Empty Then Exit Sub
                ftpServer = strTmp
                strTmp = ini.ReadValue("Dest", "FTPU")
                If strTmp = String.Empty Then Exit Sub
                ftpU = strTmp
                strTmp = ini.ReadValue("Dest", "FTPP")
                If strTmp = String.Empty Then Exit Sub
                ftpP = AES_Decrypt(strTmp, "k5*e#d4o%p@%568")
                strTmp = ini.ReadValue("Sch", "TName")

                paMessage.Visible = True
                Application.DoEvents()
                If CheckForInternetConnection() = True Then
                    Call FillFTPSetting(strTmp)
                    paMessage.Visible = False
                Else
                    chkwShowFTP.Checked = False
                    paMessage.Visible = False
                    MsgBox("No internet connectivity, unable to get list of backup item from FTP Server, Please try again later.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Error")

                End If
            End If

            ini = Nothing
            'End If
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub
    'Private Sub lvwPics_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvBackupName.MouseDown, lvBackup.MouseDown
    '   Try
    '      If e.Button = MouseButtons.Right Then
    '         If lvBackupName.SelectedItems.Count = 0 Then Exit Sub
    '        cmnuRightClick.Show(Cursor.Position)
    '   End If
    'Catch ex As Exception
    '   WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
    '  MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
    'End Try
    'End Sub

    Private Sub cMnuRunNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvBackupName.SelectedItems.Count = 0 Then Exit Sub
        Me.Close()
        Call MainForm.TriggerEvent(lvBackupName.SelectedItems(0).Text, lvBackupName.SelectedItems(0).SubItems(4).Text)
    End Sub

    Private Sub cMnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If lvBackupName.SelectedItems.Count = 0 Then Exit Sub
            Dim iniData As New IniFile(strCurPath + "\Data\FLSet" + lvBackupName.SelectedItems(0).Text + ".db")
            iniData.WriteValue("TEvent", "TStart", "0")
            iniData.WriteValue("TEvent", "TZip", "0")
            iniData.WriteValue("TEvent", "TDir", "0")
            iniData.WriteValue("TEvent", "TDir", Now)
            iniData = Nothing
            frmRestore_Load(sender, e)
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try

    End Sub

    Private Sub LVTaskName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVTaskName.SelectedIndexChanged
        'LVTaskName_Click(sender, e)
        If LVTaskName.Items.Count = 0 Then Exit Sub
        If LVTaskName.SelectedItems.Count = 0 Then Exit Sub

        Call FillLVBackup(LVTaskName.SelectedItems(0).Text, False)

    End Sub

    Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click
        Dim RestorePath As String = ""
        Me.DialogResult = DialogResult.None
        If lvBackupName.Items.Count = 0 Then Exit Sub
        If lvBackupName.SelectedItems.Count = 0 Then Exit Sub
        Dim strSource As String = lvBackupName.SelectedItems(0).Text
        Try
            If lvBackupName.SelectedItems(0).SubItems(3).Text.Substring(0, 1) = "L" Then
                RestoreSelected(LVTaskName.SelectedItems(0).Text)
            Else
                paFTP.Visible = True
                RestorePath = fbdRestore.SelectedPath
                Try

                    Dim myUri As New Uri(ftpServer & MainForm.strFTPDirNm & lvBackupName.SelectedItems(0).Text)
                    myFtpDownloadWebClient.Credentials = New System.Net.NetworkCredential(ftpU, ftpP)
                    myFtpDownloadWebClient.DownloadFileAsync(myUri, RestorePath + "\" + lvBackupName.SelectedItems(0).Text)

                Catch ex As Exception
                    MsgBox(Err.Description)
                End Try
            End If
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try

    End Sub
    Private Sub OriginCopyHere(ByVal strCode As String, ByVal strEntityFullName As String, ByVal strEntityName As String, ByVal strEntityType As String)
        Try
            Dim iTotalSource As Integer = 0
            Dim strSource As String = String.Empty

            Dim ini As New IniFile(strCurPath & "\Data\FLSet" + strCode + ".db")
            iTotalSource = ini.ReadValue("Source", "DirT")

            For i = 0 To iTotalSource - 1
                strSource = ini.ReadValue("Source", "DirPath" + i.ToString)
                Dim words As String() = strSource.Split(New Char() {"|"c})
                Dim split As String() = words(0).Split("\") ' lvBackupName.SelectedItems(0).Text.Split("\")
                Dim parentFolder As String = split(split.Length - 1)

                If parentFolder = strEntityName Then
                    If strEntityType = "F" Then
                        System.IO.File.Copy(strEntityFullName, words(0), True)
                        Exit For
                    Else
                        'My.Computer.FileSystem.CopyDirectory(strEntityFullName, words(0), True)
                        Call DirCopy(strEntityFullName, words(0))
                    End If

                End If

            Next
            ini = Nothing
        Catch ex As Exception
            '  MessageBox.Show(ex.Message)
            Call errHandlerForm(ex)
            'Log.WriteException(ex, TraceEventType.Error)
        End Try
    End Sub

    Private Sub RestoreSelected(ByVal strCode As String)
        Try

            If strCode = String.Empty Then Exit Sub
            Dim strTmp As String = ""
            Dim strFromBackup As String = String.Empty
            Dim iTotalSource As Integer = 0
            Dim i As Integer = 0
            WriteToEventsLog(strCode, LVTaskName.SelectedItems(0).Text + " Restore started")
            If lvBackupName.SelectedItems(0).SubItems(6).Text = "Z" Then ''zip file

                nFilesCompleted = 0
                _operationCancelled = False

                'paUnzip.Visible = True
                Dim strSource As String = String.Empty

                Dim ini As New IniFile(strCurPath & "\Data\FLSet" + strCode + ".db")
                iTotalSource = ini.ReadValue("Source", "DirT")
                WriteToEventsLog(strCode, LVTaskName.SelectedItems(0).Text + " Restore started.")



                For i = 0 To iTotalSource - 1
                    strSource = ini.ReadValue("Source", "DirPath" + i.ToString)
                    Dim words As String() = strSource.Split(New Char() {"|"c})
                    Dim split As String() = words(0).Split("\") ' lvBackupName.SelectedItems(0).Text.Split("\")
                    Dim parentFolder As String = split(split.Length - 1)

                    Using zip1 As ZipFile = ZipFile.Read(lvBackupName.SelectedItems(0).Text)
                        'If IO.Directory.Exists(words(0)) Then
                        strTmp = ini.ReadValue("Dest", "ZipEnc")

                        If strTmp <> "0" Then
                            zip1.Encryption = IIf(strTmp = "AES128", EncryptionAlgorithm.WinZipAes128, EncryptionAlgorithm.WinZipAes256)
                            strTmp = AES_Decrypt(ini.ReadValue("Dest", "ZipEncP"), "k5*e#d4o%p@%568")
                            zip1.Password = strTmp
                        End If
                        'zip1.Password = "1234"
                        'zip1.Encryption = EncryptionAlgorithm.WinZipAes128
                        If words(0).Substring(words(0).Length - 4, 4).StartsWith(".") Or words(0).Substring(words(0).Length - 3, 3).StartsWith(".") Then

                            zip1(parentFolder).Extract(words(0).Replace(parentFolder, ""), ExtractExistingFileAction.OverwriteSilently)
                        Else
                            zip1(parentFolder + "/").Extract(words(0).Replace(parentFolder, ""), ExtractExistingFileAction.OverwriteSilently)
                            Try
                                Dim selection = (From e In zip1.Entries Where (e.FileName).StartsWith(parentFolder))
                                For Each e In selection
                                    e.Extract(words(0).Replace(parentFolder, ""), ExtractExistingFileAction.OverwriteSilently)
                                    Application.DoEvents()
                                Next
                            Catch ex As Exception
                                MsgBox("Password incorrect! you might have changed the encryption password! aborting restore", MsgBoxStyle.Information, "Error")
                            End Try
                        End If
                    End Using
                Next


            Else

                strFromBackup = lvBackupName.SelectedItems(0).Text
                Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(strFromBackup)


                Dim fileSystemInfo As System.IO.FileSystemInfo



                Dim ini As New IniFile(strCurPath & "\Data\FLSet" + strCode + ".db")
                iTotalSource = ini.ReadValue("Source", "DirT")


                For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
                    If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                        If fileSystemInfo.Name = "backuplog.txt" Then Continue For
                        OriginCopyHere(strCode, fileSystemInfo.FullName, fileSystemInfo.Name, "F")
                    Else
                        OriginCopyHere(strCode, fileSystemInfo.FullName, fileSystemInfo.Name, "D")
                    End If
                Next
            End If
            WriteToEventsLog(strCode, LVTaskName.SelectedItems(0).Text + " Restore Finished sucessfully.")
            MsgBox("Restore finished successfully", MsgBoxStyle.Information, "Information")

        Catch ex As Exception
            Call errHandlerForm(ex)
            'MessageBox.Show(ex.Message)
            'Log.WriteException(ex, TraceEventType.Error)
        End Try
    End Sub
    Private Sub myFtpDownloadWebClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles myFtpDownloadWebClient.DownloadProgressChanged
        ProgressBar2.Value = e.ProgressPercentage
    End Sub

    Private Sub myFtpdownloaddWebClient_downloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles myFtpDownloadWebClient.DownloadFileCompleted
        If e.Error IsNot Nothing Then
            MessageBox.Show(e.Error.Message)
            paFTP.Visible = False
        Else
            Me.Cursor = Cursors.Default
            paFTP.Visible = False
            MsgBox("Download Completed!", MsgBoxStyle.Information, "Error")
            'nfy.ShowBalloonTip(3000, "K Backup", "Upload to FTP server sucessfull.", ToolTipIcon.Info)
        End If
    End Sub
    Private Sub KickoffExtract(ByVal strZipNM As String, ByVal strAtDir As String)
        lblStatus.Text = "Extracting..."
        Dim args(2) As String
        args(0) = strZipNM
        args(1) = strAtDir
        _backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        _backgroundWorker1.WorkerSupportsCancellation = False
        _backgroundWorker1.WorkerReportsProgress = False
        AddHandler Me._backgroundWorker1.DoWork, New DoWorkEventHandler(AddressOf Me.UnzipFile)
        _backgroundWorker1.RunWorkerAsync(args)
    End Sub
    Private Sub UnzipFile(ByVal sender As Object, ByVal e As DoWorkEventArgs)

        Dim extractCancelled As Boolean = False
        Dim args() As String = e.Argument
        Dim zipToRead As String = args(0) ' Source ZIP File
        Dim extractDir As String = args(1) 'at resstore directory

        Try
            Using zip As ZipFile = ZipFile.Read(zipToRead)
                totalEntriesToProcess = zip.Entries.Count
                SetProgressBarMax(zip.Entries.Count)
                AddHandler zip.ExtractProgress, New EventHandler(Of ExtractProgressEventArgs)(AddressOf Me.zip_ExtractProgress)
                zip.ExtractAll(extractDir, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)
            End Using
        Catch ex As Exception
            MessageBox.Show(String.Format("There's been a problem extracting that zip file.  {0}", ex.Message), "Error Extracting", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            'todoWriteToEventsLog( "Zip Restore failed")
            Log.WriteException(ex, TraceEventType.Error)
        End Try

        ResetUI()

    End Sub
    Private Sub ResetUI()
        If btnCancel.InvokeRequired Then
            btnCancel.Invoke(New Action(AddressOf ResetUI), New Object() {})
        Else
            btnCancel.Enabled = False
            ProgressBar1.Maximum = 1
            ProgressBar1.Value = 0
            MsgBox("Restore completed successfuly", MsgBoxStyle.Information, "Information")
            paUnzip.Visible = False
        End If
    End Sub
    Private Sub SetProgressBarMax(ByVal n As Integer)
        If ProgressBar1.InvokeRequired Then
            ProgressBar1.Invoke(New Action(Of Integer)(AddressOf SetProgressBarMax), New Object() {n})
        Else
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = n
            ProgressBar1.Step = 1
        End If
    End Sub
    Private Sub zip_ExtractProgress(ByVal sender As Object, ByVal e As ExtractProgressEventArgs)
        If _operationCancelled Then
            e.Cancel = True
            Return
        End If

        If (e.EventType = Ionic.Zip.ZipProgressEventType.Extracting_AfterExtractEntry) Then
            StepEntryProgress(e)
        ElseIf (e.EventType = ZipProgressEventType.Extracting_BeforeExtractAll) Then
            '' do nothing
        End If
    End Sub
    Private Sub StepEntryProgress(ByVal e As ExtractProgressEventArgs)
        If ProgressBar1.InvokeRequired Then
            ProgressBar1.Invoke(New ZipProgress(AddressOf StepEntryProgress), New Object() {e})
        Else
            ProgressBar1.PerformStep()
            System.Threading.Thread.Sleep(100)
            'set a label with status information
            nFilesCompleted = nFilesCompleted + 1
            lblStatus.Text = String.Format("{0} of {1} files...({2})", nFilesCompleted, totalEntriesToProcess, e.CurrentEntry.FileName)
            Me.Update()


        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If lvBackupName.Items.Count = 0 Then Exit Sub
        If lvBackupName.SelectedItems.Count = 0 Then Exit Sub
        Try
            If MsgBox("Are you sure to remove selected backupk?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then Exit Sub
            If lvBackupName.SelectedItems(0).SubItems(3).Text.Substring(0, 1) <> "F" Then 'Not FTP
                If lvBackupName.SelectedItems(0).SubItems(6).Text.Substring(0, 1) = "Z" Then

                    IO.File.Delete(lvBackupName.SelectedItems(0).Text)
                    lvBackupName.SelectedItems(0).Remove()
                Else
                    IO.Directory.Delete(lvBackupName.SelectedItems(0).Text)
                    lvBackupName.SelectedItems(0).Remove()

                End If
            Else
                'Dim ftp As FtpWebRequest = DirectCast(WebRequest.Create(ftpServer + MainForm.strFTPDirNm + lvBackupName.SelectedItems(0).Text), FtpWebRequest)

                'Try
                'ftp.Credentials = New System.Net.NetworkCredential(ftpU, ftpP)
                'ftp.Method = WebRequestMethods.Ftp.DeleteFile
                'Dim ftpResponse As FtpWebResponse = CType(ftp.GetResponse(), FtpWebResponse)
                'ftpResponse = ftp.GetResponse()
                'ftpResponse.Close()
                If DeleteFTPFIle(ftpServer + MainForm.strFTPDirNm + lvBackupName.SelectedItems(0).Text, ftpU, ftpP) = False Then Exit Sub
                lvBackupName.SelectedItems(0).Remove()
                'Catch ex As Exception
                'MsgBox(Err.Description)
                'End Try

            End If
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        _operationCancelled = True
        ProgressBar1.Maximum = 1
        ProgressBar1.Value = 0
        lblStatus.Text = "Cancelled..."
        paUnzip.Visible = False
    End Sub


    Private Sub chkwShowFTP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkwShowFTP.CheckedChanged
        If LVTaskName.Items.Count = 0 Then Exit Sub
        If LVTaskName.SelectedItems.Count = 0 Then Exit Sub
        If chkwShowFTP.Checked = True Then FillLVBackup(LVTaskName.SelectedItems(0).Text, True) Else FillLVBackup(LVTaskName.SelectedItems(0).Text, False)
    End Sub
    Private Sub DirCopy(ByVal strSource As String, ByVal strTarget As String)
        Try
            ' Reset variables
            _stopped = False

            ' Create the FileCopy class which will initiate the threads
            CopyFiles = New FileCopy

            ' Set parameter properties
            CopyFiles.FromPath = strSource
            CopyFiles.ToPath = strTarget
            CopyFiles.InitialMessage = "*** MODE IS WINFORMS ***"

            ' Initiate the copy, count and mirror threads from the FileCopy class
            CopyFiles.StartCopy()

            WorkingBar.Minimum = 0
            WorkingBar.Maximum = 100
            WorkingLabel.Visible = True
            WorkingBar.Visible = True

            ' Reset form controls
            '        StartCopy.Enabled = False
            paDirCopy.Visible = True
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            'Log.WriteException(ex, TraceEventType.Error)
            Call errHandlerForm(ex)
        End Try

    End Sub

    Private Sub btnDirCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirCancel.Click
        Try
            CopyFiles.StopThreads()
            CopyFiles = Nothing

            ProgressBar1.Maximum = 0
            ProgressBar1.Value = 0

            FileStatusTextbox.Text = ""
            CopyStatusLabel.Text = "Status: Not Started"


            paDirCopy.Visible = False


            WorkingLabel.Visible = False
            WorkingBar.Visible = False
            WorkingBar.Value = 0

            _copyStatus = "Status: Copying and Counting. "
            _deletedCount = 0

            ' Stopping threads (using abort) is, on occasion, prone to a time delay so use a flag to ensure
            ' any "leftover" events raised by child threads are ignored by this form (parent thread).
            _stopped = True
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            'Log.WriteException(ex, TraceEventType.Error)
            Call errHandlerForm(ex)
        End Try
    End Sub
    Private Sub CopyStatus(ByVal FilePath As String, ByVal FileSize As Long, ByVal FileCount As Long)

        ' Exit if the copy has been stopped (cancelled) as a child thread may still raise one last event
        ' due to a delay that sometimes occurs when the abort method to stop a child thread is used.
        If _stopped Then Exit Sub

        ' Show current file
        FileStatusTextbox.Text = "Copying: " & FilePath & ". Filesize is " & FileSize.ToString & " megabytes."


        ' Update progressbar
        If ProgressBar3.Maximum <> 0 Then ProgressBar3.Value = _totalFiles - (_totalFiles - FileCount)

    End Sub
    Private Sub CopyCompleted(ByVal FilePath As String, ByVal FileSize As Long, ByVal FileCount As Long)

        CopyStatusLabel.Text = "Status: Copy Finsihed. Copied " + _totalFiles.ToString + " files in " + _totalFolders.ToString + " folders."
        FileStatusTextbox.Text = "Copy completed successfully."
        ProgressBar3.Value = ProgressBar3.Maximum

    End Sub
    Private Sub CountStatus(ByVal FileCount As Long, ByVal FolderCount As Long)
        ' Exit if the copy has been stopped (cancelled) as a child thread may still raise one last event
        ' due to a delay that sometimes occurs when the abort method to stop a child thread is used.
        If _stopped Then Exit Sub

        ' Display current count
        CopyStatusLabel.Text = _copyStatus & "So far there are " + FileCount.ToString + " files in " + FolderCount.ToString + " folders."

    End Sub
    Private Sub CountCompleted(ByVal FileCount As Long, ByVal FolderCount As Long)

        ' Display current count
        _copyStatus = "Status: Copying. "
        CopyStatusLabel.Text = _copyStatus & "There are " + FileCount.ToString + " files in " + FolderCount.ToString + " folders."

        ' Save totals when finished counting for CopyStatus()
        _totalFiles = FileCount
        _totalFolders = FolderCount

        ProgressBar3.Maximum = _totalFiles
        ProgressBar3.Value = 0

    End Sub
    Private Sub BackupCompleted()

        CopyStatusLabel.Text = "Backup copy completed."

        CopyFiles.StopThreads()
        CopyFiles = Nothing

        WorkingLabel.Visible = False
        WorkingBar.Visible = False
        WorkingBar.Value = 0

        paDirCopy.Visible = False
    End Sub
    Private Sub CopyFiles_CopyStatus(ByVal sender As Object, ByVal e As BackupEventArgs) Handles CopyFiles.CopyStatus
        ' BeginInvoke causes asynchronous execution to begin at the address
        ' specified by the delegate. Simply put, it transfers execution of 
        ' this method back to the main thread. Any parameters required by 
        ' the method contained at the delegate are wrapped in an object and 
        ' passed.

        Me.BeginInvoke(New CopyHandler(AddressOf CopyStatus), New Object() {e.FilePath, e.FileSize, e.FileCount})

    End Sub
    Private Sub CopyFiles_CopyCompleted(ByVal sender As Object, ByVal e As BackupEventArgs) Handles CopyFiles.CopyCompleted
        ' BeginInvoke causes asynchronous execution to begin at the address
        ' specified by the delegate. Simply put, it transfers execution of 
        ' this method back to the main thread. Any parameters required by 
        ' the method contained at the delegate are wrapped in an object and 
        ' passed.

        Me.BeginInvoke(New CopyHandler(AddressOf CopyCompleted), New Object() {e.FilePath, e.FileSize, e.FileCount})

    End Sub

    Private Sub CopyFiles_CountStatus(ByVal sender As Object, ByVal e As BackupEventArgs) Handles CopyFiles.CountStatus
        ' BeginInvoke causes asynchronous execution to begin at the address
        ' specified by the delegate. Simply put, it transfers execution of 
        ' this method back to the main thread. Any parameters required by 
        ' the method contained at the delegate are wrapped in an object and 
        ' passed.

        Me.BeginInvoke(New CountHandler(AddressOf CountStatus), New Object() {e.FileCount, e.FolderCount})

    End Sub
    Private Sub CopyFiles_CountCompleted(ByVal sender As Object, ByVal e As BackupEventArgs) Handles CopyFiles.CountCompleted
        ' BeginInvoke causes asynchronous execution to begin at the address
        ' specified by the delegate. Simply put, it transfers execution of 
        ' this method back to the main thread. Any parameters required by 
        ' the method contained at the delegate are wrapped in an object and 
        ' passed.

        Me.BeginInvoke(New CountHandler(AddressOf CountCompleted), New Object() {e.FileCount, e.FolderCount})

    End Sub
    Private Sub CopyFiles_BackupCompleted(ByVal sender As Object, ByVal e As BackupEventArgs) Handles CopyFiles.BackupCompleted
        ' BeginInvoke causes asynchronous execution to begin at the address
        ' specified by the delegate. Simply put, it transfers execution of 
        ' this method back to the main thread. Any parameters required by 
        ' the method contained at the delegate are wrapped in an object and 
        ' passed.

        Me.BeginInvoke(New BackupHandler(AddressOf BackupCompleted))
    End Sub
End Class
