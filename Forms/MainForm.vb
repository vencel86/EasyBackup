Imports System.Windows.Forms
Imports Ionic.Zip
Imports System.Threading
Imports System.ComponentModel
Imports System.Globalization
Imports System.Net
Imports ICSharpCode.SharpZipLib
Imports RemoteZip
'////////////////
'EC=Error Code, ET= Error Text, 
'/////////
Public Class MainForm
    Dim strHelpPath As String = System.IO.Path.Combine(Application.StartupPath, "EasyBackup.chm")
    'Private Shared fLog As New FileLog(My.Application.Info.Title, strCurPath + "\Logs\")
    'for zip
    Private _backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private _saveCancelled As Boolean
    Private _totalBytesAfterCompress As Long
    Private _totalBytesBeforeCompress As Long
    Private _nFilesCompleted As Integer
    Private _progress2MaxFactor As Integer
    Private _entriesToZip As Integer
    Private rvn_ZipFile As String = "zipfile"
    Private rvn_DirToZip As String = "dirToZip"

    Private boolEventInProgress As Boolean = False

    Dim intActiveTask As Integer = 0

    ' for file copy


    ' file copy ends here

    'for FTP Upload
    Private WithEvents myFtpUploadWebClient As New System.Net.WebClient
    Public Const strFTPDirNm As String = "/easybackup/"
    'for FTP Upload

    ' Delegates for invocation of UI from other threads
    Private Delegate Sub SaveEntryProgress(ByVal e As SaveProgressEventArgs)
    Private Delegate Sub ButtonClick(ByVal sender As Object, ByVal e As EventArgs)
    'for zip ends here
    'settings
    Public boolEnableSND As Boolean = False
    Public boolSkipFiles As Boolean = False
    Public boolUpdates As Boolean = True
    'settings ends here

    '    Public strUNm As String = "/easybackup/"

    Dim strCurCode As String = ""
    Dim boolClose As Boolean = False
    'file counter total files
    Dim totalFileCount As Integer = 0
    Dim ChangedFileCount As Integer = 0
    'Incremental Backup Flag
    Dim strBakupMode As String = "DB"


    'Public Shared ReadOnly Property Log() As FileLog
    '   Get
    '      Return fLog
    ' End Get
    'End Property
    Private Sub mnuTaskNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTaskNew.Click
        Dim TaskForm As New frmTask
        If TaskForm.ShowDialog() = DialogResult.OK Then
            Call LoadData()
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        mnuTaskNew_Click(sender, e)
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If boolClose = False And e.CloseReason <> CloseReason.WindowsShutDown Then

            Me.WindowState = FormWindowState.Minimized
            'Me.Hide()
            e.Cancel = True
            'nfy.Dispose()
        End If
    End Sub
    Private Sub CheckPath()
        'If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Easy Backup") Then
        If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\" + txtAppName.Text) Then
            IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\" + txtAppName.Text)
            IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\" + txtAppName.Text + "\Data")
        ElseIf Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\" + txtAppName.Text + "\" + "Logs") Then
            IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\" + txtAppName.Text + "\" + "Logs")
        End If
    End Sub
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  Try
        If CheckForExistingInstance() = True Then End
        Me.SuspendLayout()
        If Environment.GetCommandLineArgs.Count <> 1 Then
            If Environment.GetCommandLineArgs(1) = "/s" Then
                Me.Hide()
                Me.WindowState = FormWindowState.Minimized
            End If
        Else
            Me.WindowState = FormWindowState.Normal
        End If
        HelpProvider1.HelpNamespace = strHelpPath
        If ModGlobal.intOEM = 0 Then
            txtAppName.Text = "Easy Backup"
        ElseIf ModGlobal.intOEM = 1 Then
            txtAppName.Text = "Cobono Backup"
        End If
        lblHeading1.Text = txtAppName.Text

        Call CheckPath()
        'Me.Text = Application.ProductName + " " + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString
        Me.Text = txtAppName.Text + " " + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString
        nfy.Icon = Me.Icon

        'ChangeLanguage("en")

        'tsTotalTask.Text = +tsTotalTask.Text + +"0"
        tsTotalTask.Text = Space(5) + "Total active task :" + Space(2) + "0"
        tsDate.Text = tsDate.Text + Space(3) + Date.Today.ToString("dd-MM-yyyy")
        'tsDate.Text = "Date : " + Date.Today.ToString("dd-MM-yyyy")
        TSlblTime.Text = TSlblTime.Text + Space(3) + Now.ToString("hh:mm tt")
        'TSlblTime.Text = "Time : " + Now.ToString("hh:mm tt")

        'hide at startup
        'Me.Hide()
        Call LoadSettings() ' load all program settings

        Call LoadData()
        If Event_Done() = False Then ' checking for registration
            dtEventDate = False ' global variable to hold the value of registration (done or not true/false)
            'Me.Text = My.Application.Info.Title.ToString & " V " & My.Application.Info.Version.ToString.Substring(0, 4) & " - Evaluation Version"
            Me.Text = txtAppName.Text & " V " & My.Application.Info.Version.ToString.Substring(0, 4) & " - Evaluation Version"
            'If DateTime.Today.Year > 2015 And DateTime.Today.Month > 10 Then boolClose = True : Me.Close()
        Else
            dtEventDate = True 'regi
        End If

        Call PCFirstStart() ' run event marked with computer starts
        'for Demo mode
        If DateTime.Today.Month > 6 And DateTime.Today.Year = 2019 Then boolClose = True : Me.Close()
        'for few months
        'If DateTime.Today.Month > 9 Then boolClose = True : Me.Close()
        Me.ResumeLayout()
        'Catch ex As Exception
        '  Log.WriteException(ex, TraceEventType.Error)
        'End Try
    End Sub

    Private Sub LoadSettings()
        Try
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" + Application.ProductName, "EnableSnd", Nothing) Is Nothing Then
                boolEnableSND = False
            Else
                boolEnableSND = True
            End If
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" + Application.ProductName, "SkipFiles", Nothing) Is Nothing Then
                boolSkipFiles = False
            Else
                boolSkipFiles = True
            End If
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" + Application.ProductName, "Updates", Nothing) Is Nothing Then
                boolUpdates = True
            Else
                boolUpdates = False
            End If
        Catch ex As Exception
            Call errHandlerForm(ex)
        End Try
    End Sub
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        If MsgBox("This will shutdown the application and stop monitoring backup task." & vbLf & vbLf & "Are you sure, you want to exit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = vbYes Then
            'Me.WindowState = FormWindowState.Minimized
            boolClose = True
            nfy.Icon.Dispose()
            tmrEvents.Stop()
            Application.DoEvents()
            Me.Close()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        mnuExit_Click(sender, e)
    End Sub
    Private Function CheckForExistingInstance() As Boolean
        'Get number of processes of you program
        If Process.GetProcessesByName _
          (Process.GetCurrentProcess.ProcessName).Length > 1 Then

            MessageBox.Show _
             ("Another Instance of this process is already running", "Multiple Instances Forbidden", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
            'Application.Exit()
        End If
        Return False
    End Function

    Private Sub MainForm_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    Private Sub nfy_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nfy.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left Then
            CMnuOpen_Click(sender, e)
        End If
    End Sub

    Private Sub nfy_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nfy.MouseDoubleClick
        CMnuOpen_Click(sender, e)
    End Sub

    Private Sub CMnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMnuOpen.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        'Me.ShowInTaskbar = True
        Me.Activate()
        Me.Focus()
    End Sub

    Private Sub CMnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMnuExit.Click
        mnuExit_Click(sender, e)
    End Sub

    Private Sub LoadData()
        Try

            BackupData.Instance.ReadTMSettings()
            Dim i As Integer = 0
            intActiveTask = 0
            Dim CurTask As Integer = 0
            If lvwPics.Items.Count <> 0 Then CurTask = lvwPics.SelectedIndices(0)
            lvwPics.Items.Clear()
            lbFilterE.Items.Clear()
            lbFilterI.Items.Clear()
            If IO.Directory.Exists(strCurPath + "\Data") = False Then Exit Sub
            Call FillLVNew()
            i = lvwPics.Items.Count
            tsTotalTask.Text = Space(5) + "Total active task :" + Space(2) + intActiveTask.ToString
            'If lvwPics.Items.Count <> 0 Then lvwPics.Items(0).Selected = True
            Try
                If lvwPics.Items.Count <> 0 Then
                    lvwPics.Items(CurTask).Selected = True
                End If
            Catch ex As Exception
                lvwPics.Items(0).Selected = True
            End Try
        Catch ex As Exception
            Call errHandlerForm(ex)
        End Try
    End Sub
    Private Sub mnuTaskEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTaskEdit.Click
        If lvwPics.SelectedItems.Count = 0 Then Exit Sub
        Dim TForm As New frmTask
        TForm.lblCode.Text = lvwPics.SelectedItems(0).Text
        If TForm.ShowDialog() = DialogResult.OK Then
            System.Threading.Thread.Sleep(200)
            Call LoadData()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Call mnuTaskEdit_Click(sender, e)
    End Sub

    Private Sub mnuTaskDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTaskDelete.Click
        Try
            If lvwPics.SelectedItems.Count = 0 Then Exit Sub
            If MsgBox("Are you sure to remove selected backup task?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then Exit Sub

            For Each drRow As System.Data.DataRow In BackupData.Instance.BackupTable.Rows
                If drRow.Item("TID") = lvwPics.SelectedItems(0).Text Then drRow.Delete()
                Exit For
            Next
            BackupData.Instance.WriteTMSettings()
            'IO.File.Delete(strCurPath + "\Data\FLSet" + lvwPics.SelectedItems(0).Text + ".db")
            IO.File.Delete(strCurPath + "\Data\FLSet" + lvwPics.SelectedItems(0).Text + "log.txt")
            Call LoadData()
        Catch ex As Exception
            Call errHandlerForm(ex)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Call mnuTaskDelete_Click(sender, e)
    End Sub

    Private Sub lvwPics_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwPics.DoubleClick
        mnuTaskEdit_Click(sender, e)
    End Sub

    Private Sub lvwPics_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwPics.MouseDown
        Try
            If e.Button = MouseButtons.Right Then
                If lvwPics.SelectedItems.Count = 0 Then Exit Sub
                If lvwPics.SelectedItems(0).SubItems(3).Text.Substring(0, 1) = "M" Then
                    cMnuPause.Text = "Pause"
                Else
                    cMnuPause.Text = "Monitor"
                End If
                cmnuRightClick.Show(Cursor.Position)
            End If
        Catch ex As Exception
            Call errHandlerForm(ex)
        End Try
    End Sub

    Private Sub CMnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMnuEdit.Click
        mnuTaskEdit_Click(sender, e)
    End Sub

    Private Sub cMnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cMnuDelete.Click
        mnuTaskDelete_Click(sender, e)
    End Sub

    Private Sub lvwPics_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwPics.SelectedIndexChanged
        If lvwPics.SelectedItems.Count = 0 Then
            txtLogWindow.Clear()
            Exit Sub
        End If

        If lvwPics.SelectedItems(0).SubItems(3).Text.Substring(0, 1) = "M" Then
            mnuTaskPause.Text = "Pause"
            mnuTaskPause.Tag = "1"
        Else
            mnuTaskPause.Text = "Monitor"
            mnuTaskPause.Tag = "0"
        End If
        If lvwPics.Items.Count = 0 Then Exit Sub
        If lvwPics.SelectedItems.Count = 0 Then Exit Sub
        Call ShowLog(lvwPics.SelectedItems(0).Text)
    End Sub
    Private Sub ShowLog(ByVal strCode As String)
        Try
            'shows log from the file
            txtLogWindow.Clear()
            If IO.File.Exists(strCurPath + "\Data\FLSet" + strCode + "log.txt") = False Then Exit Sub
            Dim fl As New System.IO.StreamReader(strCurPath + "\Data\FLSet" + strCode + "log.txt")
            Dim str = fl.ReadToEnd
            txtLogWindow.Text = str
            fl.Dispose()
            txtLogWindow.Select(txtLogWindow.TextLength - 1, 0)
            txtLogWindow.ScrollToCaret()
        Catch ex As Exception
            Call errHandlerForm(ex)
        End Try
    End Sub
    Private Sub mnuTaskPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTaskPause.Click
        Try

            If lvwPics.SelectedItems.Count = 0 Then Exit Sub
            Dim iniData As New IniFile(strCurPath + "\Data\FLSet" + lvwPics.SelectedItems(0).Text + ".db")
            If mnuTaskPause.Tag = "0" Then
                iniData.WriteValue("Value" + lvwPics.SelectedItems(0).Text, "TStart", True)
                iniData = Nothing

            Else
                iniData.WriteValue("Value" + lvwPics.SelectedItems(0).Text, "TStart", False)
                iniData = Nothing
            End If
            LoadData()
        Catch ex As Exception
            Call errHandlerForm(ex)
        End Try
    End Sub

    Private Sub cMnuPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cMnuPause.Click
        mnuTaskPause_Click(sender, e)
    End Sub


    Private Sub tmrEvents_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEvents.Tick
        Try
            If lvwPics.Items.Count = 0 Then Exit Sub
            Dim strTime() As String
            Dim strDT As DateTime
            TSlblTime.Text = "Time : " + Now.ToString("hh:mm tt")


            For i = 0 To lvwPics.Items.Count - 1
                If lvwPics.Items(i).SubItems(3).Text.Substring(0, 1) <> "M" Or lvwPics.Items(i).SubItems(4).Text.Substring(0, 1) = "C" Then Continue For ' currentstate is monitoring
                If lvwPics.Items(i).SubItems(4).Text.Substring(0, 1) = "D" Then ' daily events
                    If lvwPics.Items(i).SubItems(6).Text.Substring(0, 1) = 6 Then ' exclude sunday
                        If Today.DayOfWeek = 7 Then Continue For
                    ElseIf lvwPics.Items(i).SubItems(6).Text.Substring(0, 1) = 5 Then ' exclude saturday and sunday
                        If Today.DayOfWeek = 7 Or Today.DayOfWeek = 6 Then Continue For
                    End If

                ElseIf lvwPics.Items(i).SubItems(4).Text.Substring(0, 1) = "W" Then
                    Dim strWeekDays As String = ""
                    Dim boolWeekOn As Boolean = False
                    strWeekDays = lvwPics.Items(i).SubItems(6).Text
                    For j = 0 To 6
                        If strWeekDays.Substring(j, 1) = 1 And Today.DayOfWeek = j + 1 Then
                            boolWeekOn = True
                            Exit For
                        End If
                    Next
                    If boolWeekOn = False Then Continue For

                ElseIf lvwPics.Items(i).SubItems(4).Text.Substring(0, 1) = "O" Then
                    If Convert.ToDateTime(lvwPics.Items(i).SubItems(5).Text).ToString("dd/MM/yyyy") <> Date.Today.ToString("dd/MM/yyyy") Then Continue For
                End If

                'time checking

                If lvwPics.Items(i).SubItems(5).Tag Is Nothing Or lvwPics.Items(i).SubItems(5).Tag.Contains("R") Then
                    strTime = lvwPics.Items(i).SubItems(5).Text.Split(","c)
                    For j = 0 To UBound(strTime)
                        strDT = Convert.ToDateTime(strTime(0).Trim).ToString("hh:mm tt")
                        If strDT = Now.ToString("hh:mm tt") Then
                            Call TriggerEvent(lvwPics.Items(i).Text, Convert.ToBoolean(lvwPics.Items(i).SubItems(7).Text))
                            'Actual Event Occurs
                            Exit Sub
                        End If
                    Next j
                Else
                    If lvwPics.Items(i).SubItems(5).Tag.Contains("M") Or lvwPics.Items(i).SubItems(5).Tag.Contains("H") Then
                        strDT = Convert.ToDateTime(dtpLastRun.Value.ToString("hh:mm tt"))
                        If strDT.ToString("hh:mm tt") = Now.ToString("hh:mm tt") Then
                            Call TriggerEvent(lvwPics.Items(i).Text, Convert.ToBoolean(lvwPics.Items(i).SubItems(7).Text))
                            'Actual Event Occurs
                            Exit Sub
                        End If
                        'hour
                        '                ElseIf lvwPics.Items(i).SubItems(5).Tag.Contains("R") Then
                    End If


                End If

                'time checking ends here

            Next
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub
    Public Sub TriggerEvent(ByVal strFLCode As String, ByVal intIfZip As Boolean)

        PlayBackgroundSoundResource("start")
        boolEventInProgress = True
        If IO.File.Exists(strCurPath & "\Data\BackupData.db") = False Then Exit Sub
        'If DateTime.Today.Year = 2016 And dtEventDate = False Then
        'MsgBox("Your evaluation period expired, now you must purchase Easy Backup Scheduler!", MsgBoxStyle.Information, "Expired")
        'Exit Sub
        'End If

        Dim strTmpPath As String = ""
        strCurCode = strFLCode
        Dim strORiginalFol As String = ""
        Dim strTaskNm As String = ""
        Dim strDTTMCreation As String = ""
        Dim strBMode As String = ""
        Dim strTmp As String = ""
        '-----------------------------------
        ' for zip encryption
        Dim DoEncryption As Boolean = False
        Dim strEncryptionMethod As String = ""
        Dim strEncryptionPass As String = ""
        '-----------------------------------

        Dim isFTPBackup As Boolean = False ' for pass variable to kickoffzip function for if FTP Backup is on
        Dim isWebDAVBackup As Boolean = False ' for pass variable to kickoffzip function for if WebDavBackup is on

        Dim strFTPS As String = ""
        Dim strFTPU As String = ""
        Dim strFTPP As String = ""
        Dim strFTPPort As String = ""
        '-------------------------------------FTP ENDS-----------



        Try
            'need to comment below at last
            Dim ini As New IniFile(strCurPath + "\Data\BackupData.db")
            'fetch current record from list
            Dim predicate As Func(Of BackupRecord, Boolean) = Nothing
            If (predicate Is Nothing) Then
                predicate = Function(st As BackupRecord)
                                Return (st.TID = strFLCode)
                            End Function
            End If
            Dim parameter As BackupRecord = Enumerable.First(Of BackupRecord)(Enumerable.Where(Of BackupRecord)(BackupData.Instance.BackupList, predicate))
            ini.WriteValue("Value" + parameter.TID, "TStart", True)
            ini.WriteValue("Value" + parameter.TID, "TZip", True)

            strTaskNm = parameter.TName
            WriteToEventsLog(strFLCode, strTaskNm + " Backup event started")
            '--------getting encryption method if any-------------
            If IsNothing(parameter.ZipEnc) Or parameter.ZipEnc = String.Empty Then
                strTmp = 0
            Else
                strTmp = parameter.ZipEnc
            End If

            If strTmp <> 0 Then
                DoEncryption = True
                strEncryptionMethod = strTmp
                strTmp = parameter.ZipEncP
                strEncryptionPass = AES_Decrypt(strTmp, "k5*e#d4o%p@%568")
            End If

            '--------Done encryption method if any-------------

            totalFileCount = 0 ' total file counter
            ChangedFileCount = 0 ' Changed file counter

            strBMode = parameter.BMode
            If strBMode <> String.Empty Then
                strBakupMode = strBMode
            Else
                strBakupMode = "DB"
            End If

            lbFilterE.Items.Clear()
            strTmp = parameter.DirFilterT
            If strTmp <> String.Empty And strTmp <> "0" Then
                If parameter.DirFilter.ToString.Contains("%") = True Then
                    Dim strFilter As String() = parameter.DirFilter.ToString.Split(New Char() {"%"c})
                    For i = 0 To UBound(strFilter)
                        Dim strFilter1 As String() = parameter.DirFilter.ToString.Split(New Char() {"|"c})
                        If strFilter1(0) = "E" Then
                            lbFilterE.Items.Add(strFilter1(1))
                        Else
                            lbFilterI.Items.Add(strFilter1(1))
                        End If
                    Next
                Else
                    Dim FilterValues As String() = parameter.DirFilter.ToString.Split(New Char() {"|"c})
                    If FilterValues(0) = "E" Then lbFilterE.Items.Add(FilterValues(1)) Else lbFilterI.Items.Add(FilterValues(1))
                End If
            End If



            If intIfZip = True Then 'backup as zip
                nfy.ShowBalloonTip(3000, txtAppName.Text, strTaskNm + " Backup event started, double click to see options.", ToolTipIcon.Info)
                'Show Balloon and Write LOG ends here
                Dim strCurrentSize As Long = 0
                lbDir.Items.Clear()
                lbFiles.Items.Clear()
                strTmp = parameter.SourceDirT
                If strTmp <> String.Empty Then
                    Dim SoureceEventPathList() As String
                    If parameter.SourceDirPath.ToString.Contains("%") = True Then
                        Dim DirWords As String() = parameter.SourceDirPath.ToString.Split(New Char() {"%"c})
                        SoureceEventPathList = DirWords
                    Else
                        Dim tmpArr(0) As String
                        tmpArr(0) = parameter.SourceDirPath.ToString
                        SoureceEventPathList = tmpArr
                    End If

                    For i = 0 To UBound(SoureceEventPathList)
                        strTmp = SoureceEventPathList(i)
                        Dim words As String() = strTmp.Split(New Char() {"|"c})
                        If IO.Directory.Exists(words(0)) Then
                            Dim dInfo As New System.IO.DirectoryInfo(words(0)) ' to check current size
                            strCurrentSize = strCurrentSize + DirectorySize(dInfo, True)
                            If words(2) <> strCurrentSize Then
                                'ini.WriteValue("Source", "DirPath" + i.ToString, words(0) + "|" + SizeToMBStr(strCurrentSize) + "|" + strCurrentSize.ToString)
                                SoureceEventPathList(i) = words(0) + "|" + SizeToMBStr(strCurrentSize) + "|" + strCurrentSize.ToString
                            End If
                            Dim split As String() = words(0).Split("\")
                            strTmpPath = words(0)
                            lbDir.Items.Add(words(0))
                            Dim parentFolder As String = split(split.Length - 1)
                            strORiginalFol = parentFolder
                            strTmpPath = words(0).Replace(parentFolder, "")
                        ElseIf IO.File.Exists(words(0)) Then
                            Dim info2 As New System.IO.FileInfo(words(0))
                            strCurrentSize = strCurrentSize + info2.Length
                            If words(2) <> strCurrentSize Then
                                SoureceEventPathList(i) = words(0) + "|" + SizeToMBStr(strCurrentSize) + "|" + strCurrentSize.ToString
                                'ini.WriteValue("Source", "DirPath" + i.ToString, words(0) + "|" + SizeToMBStr(strCurrentSize) + "|" + strCurrentSize.ToString)
                            End If
                            lbFiles.Items.Add(words(0).Trim)
                        Else ' Source Directory does not exist.
                            MsgBox("Source ' " + words(0) + " either deleted or moved, error will be logged. " + strTaskNm, MsgBoxStyle.Information, "Error")
                            ini.WriteValue("Value" + parameter.TID, "EC", True)
                            ini.WriteValue("Value" + parameter.TID, "ET", words(0)) 'source desition revert back remains

                            'ini.WriteValue("CE", "EC", "1")
                            'ini.WriteValue("CE", "ET", words(0))
                            Throw New System.Exception("Source path does not exist")
                        End If
                    Next
                    ini.WriteValue("Value" + parameter.TID, "DSize", strCurrentSize)
                    Dim strTmpFTPPath As String = ""
                    strTmp = parameter.Other
                    If strTmp <> 0 Then
                        If strTmp.ToLower = "FTP".ToLower Then ' destination is directly FTP and not the local
                            strFTPS = parameter.FTPinfo.FTPS
                            strFTPU = parameter.FTPinfo.FTPU
                            strFTPP = parameter.FTPinfo.FTPP
                            strFTPP = AES_Decrypt(strFTPP, "k5*e#d4o%p@%568")
                            strTmpFTPPath = System.IO.Path.GetTempPath 'FTP_1 creating zip file at local user temporary folder
                            strTmp = strFTPS + strFTPDirNm
                            isFTPBackup = True
                        ElseIf strTmp.ToLower = "WebDav".ToLower Then ' destination is WebDAV and not the local
                            strFTPS = parameter.WebDavinfo.WDS
                            strFTPU = parameter.WebDavinfo.WDU
                            strFTPP = parameter.WebDavinfo.WDP
                            strFTPP = AES_Decrypt(strFTPP, "k5*e#d4o%p@%568")
                            strFTPPort = parameter.WebDavinfo.WDSPort
                            strTmpFTPPath = System.IO.Path.GetTempPath 'FTP_1 creating zip file at local user temporary folder
                            strTmp = strFTPS + strFTPDirNm
                            isWebDAVBackup = True
                        Else
                        End If
                    Else 'Local PC Backup as zip
                        strTmp = parameter.DestDirT
                        Dim DestEventPathList() As String
                        If parameter.DestDirPath.ToString.Contains("%") = True Then
                            Dim DirWords1 As String() = parameter.DestDirPath.ToString.Split(New Char() {"%"c})
                            DestEventPathList = DirWords1
                        Else
                            Dim tmpArr() As String = {parameter.DestDirPath.ToString}
                            DestEventPathList = tmpArr
                        End If

                        For i = 0 To UBound(DestEventPathList)
                            strTmp = DestEventPathList(i)
                            If strTmp.Substring(strTmp.Length - 1, 1) <> "\" Then
                                strTmp = strTmp + "\"
                            End If
                            If IO.Directory.Exists(strTmp) = False Then
                                MsgBox("Destination path' " + strTmp + " does not exist, please check back up setting for Backup item named " + strTaskNm, MsgBoxStyle.Information, "Error")
                                ini.WriteValue("Value" + parameter.TID, "EC", True)
                                ini.WriteValue("Value" + parameter.TID, "ET", strTmp)
                                Throw New System.Exception("Directory does not exist")
                            End If
                        Next
                    End If
                    strDTTMCreation = "backup" ' Now.ToString("dd-MM-yyyy ") + Now.ToString("hh mm")

                    ini.WriteValue("Value" + parameter.TID, "EC", parameter.EC)



                    Call KickoffZipup(strTmp + strTaskNm + " " + strDTTMCreation + ".zip", strFLCode, DoEncryption, strEncryptionMethod, strEncryptionPass, isFTPBackup, isWebDAVBackup, strFTPS, strFTPPort, strFTPU, strFTPP, strTmpFTPPath + strTaskNm + " " + strDTTMCreation + ".zip")

                End If
                ini.WriteValue("Value" + parameter.TID, "TZip", False)
                ini.WriteValue("Value" + parameter.TID, "TStart", False)
                ini.WriteValue("Value" + parameter.TID, "TDone", Now.ToString)



            Else 'DIRBACKUP

                strTmp = parameter.SourceDirT
                strDTTMCreation = " backup" 'Now.ToString("dd-MM-yyyy") + Now.ToString("hh mm")
                If strTmp <> String.Empty Then
                    Dim SoureceEventPathList() As String
                    If parameter.SourceDirPath.ToString.Contains("%") = True Then
                        Dim DirWords As String() = parameter.SourceDirPath.ToString.Split(New Char() {"%"c})
                        SoureceEventPathList = DirWords
                    Else
                        Dim tmpArr(0) As String
                        tmpArr(0) = parameter.SourceDirPath.ToString
                        SoureceEventPathList = tmpArr
                    End If

                    For i = 0 To UBound(SoureceEventPathList)
                        strTmp = SoureceEventPathList(i)
                        Dim words As String() = strTmp.Split(New Char() {"|"c})
                        'create and copy directory
                        If IO.Directory.Exists(words(0).Trim) Or IO.File.Exists(words(0).Trim) Then
                            Dim split As String() = words(0).Split("\")
                            strTmpPath = words(0)
                            Dim parentFolder As String = split(split.Length - 1)
                            strORiginalFol = parentFolder
                            strTmpPath = words(0).Replace(parentFolder, "")
                            WriteToEventsLog(strFLCode, " Mirror copy started.")
                            If SrcToDestDirCopy(words(0), strORiginalFol, strFLCode, strDTTMCreation, i) = True Then
                            Else
                                'DIrectory Ballon Show
                                WriteToEventsLog(strFLCode, strTaskNm + " Mirror copy failed.")
                                nfy.ShowBalloonTip(3000, txtAppName.Text, "Error occured while backing up the directory backup of task " + strTaskNm, ToolTipIcon.Info)
                                'directory ballon ends here
                            End If
                        Else
                            MsgBox("Source directory' " + words(0) + " does not exist, please check back up setting for Backup item named " + strTaskNm, MsgBoxStyle.Information, "Error")
                            WriteToEventsLog(strFLCode, strTaskNm + " - Directory backup  Failed, Source Directory " + words(0) + " does not exist.")
                            ini.WriteValue("Value" + parameter.TID, "EC", True)
                            ini.WriteValue("Value" + parameter.TID, "ET", "Source Directory " + words(0) + " Doesn't exist.")
                            Throw New System.Exception("Directory does not exist.")
                        End If
                    Next i

                    WriteToEventsLog(strFLCode, "Mirror copy finished.")
                    nfy.ShowBalloonTip(3000, txtAppName.Text, "Directory Backup Finished Successfully.", ToolTipIcon.Info)
                    PlayBackgroundSoundResource("end")
                End If
                ini.WriteValue("Value" + parameter.TID, "TStart", False)
                ini.WriteValue("Value" + parameter.TID, "TDir", False)
                ini.WriteValue("Value" + parameter.TID, "TDone", Now.ToString)
                ini = Nothing

            End If

            LoadData()
        Catch ex As Exception
            LoadData()
            Call errHandlerForm(ex)
        End Try
    End Sub
    Private Function SrcToDestDirCopy(ByVal strSrcDir As String, ByVal strDirNmOnly As String, ByVal strCCode As String, ByVal strTimeCreation As String, ByVal intFirstPass As Integer) As Boolean
        Try
            'For backup at all locations
            'Dim ini As New IniFile(strCurPath & "\Data\FLSet" + strCCode + ".db")
            Dim ini As New IniFile(strCurPath & "\Data\BackupData.db")
            Dim strTmp As String = ""
            Dim strLPath() As String = Nothing
            Dim intFlCnt As Integer = 0
            Dim strTaskName As String = ""

            'Dim Customrow() As Data.DataRow = BackupData.Instance.BackupTable.Select("TID =" & strCCode)

            'fetch current record from list
            Dim predicate As Func(Of BackupRecord, Boolean) = Nothing
            If (predicate Is Nothing) Then
                predicate = Function(st As BackupRecord)
                                Return (st.TID = strCCode)
                            End Function
            End If
            Dim paramSRC As BackupRecord = Enumerable.First(Of BackupRecord)(Enumerable.Where(Of BackupRecord)(BackupData.Instance.BackupList, predicate))

            'fill array with all destination Path
            strTmp = paramSRC.DestDirT
            strTaskName = paramSRC.TName
            If strTmp <> String.Empty Then
                intFlCnt = CDbl(strTmp)
                Dim DestEventPathList() As String
                If paramSRC.DestDirPath.ToString.Contains("%") = True Then
                    Dim DirWords1 As String() = paramSRC.DestDirPath.ToString.Split(New Char() {"%"c})
                    DestEventPathList = DirWords1
                Else
                    Dim tmpArr() As String = {paramSRC.DestDirPath.ToString}
                    DestEventPathList = tmpArr
                End If


                For i = 0 To UBound(DestEventPathList)
                    strTmp = DestEventPathList(i)
                    If strTmp <> String.Empty Then
                        ReDim Preserve strLPath(i)
                        strLPath(i) = strTmp
                    Else
                        Exit For
                    End If
                Next
            End If
            'fill array with all destination Path ends here

            'original copy starts here
            For i = 0 To strLPath.GetUpperBound(0)
                ToolStripProgressBar1.Style = ProgressBarStyle.Marquee
                ToolStripProgressBar1.Visible = True

                strTmp = strLPath(i) + "\" + strTaskName + " " + strTimeCreation
                Dim strIBOld As String = strTmp
                Dim strIBNew As String = strIBOld
                Dim strLastDir As String = strIBOld
                Dim Cnt As Integer = 0

                If strBakupMode = "IB" And intFirstPass = 0 Then
                    WriteToEventsLog(strCCode, "Incremental backup started (without zip)")
                    While IO.Directory.Exists(strIBNew)
                        Cnt = Cnt + 1
                        strIBNew = String.Format("{0}({1}", strTmp, Cnt.ToString()) + ")"
                        strLastDir = strIBNew
                        If Cnt - 1 <> 0 Then
                            strIBOld = String.Format("{0}({1}", strTmp, Cnt - 1.ToString()) + ")"
                        End If
                    End While
                    strLastDir = strLastDir
                ElseIf strBakupMode = "DB" Then
                    WriteToEventsLog(strCCode, "Differential backup started (without zip)")
                    If IO.Directory.Exists(strTmp) Then strLastDir = strTmp + "(1)" Else strLastDir = strTmp
                End If

                If Not IO.Directory.Exists(strLastDir) Then IO.Directory.CreateDirectory(strLastDir)
                For j = 0 To 100
                    Application.DoEvents()
                Next

                If IO.Directory.Exists(strSrcDir) Then
                    If IO.Directory.Exists(strIBOld + "\" + strDirNmOnly) Then
                        Dim IBDiInfo As New System.IO.DirectoryInfo(strIBOld + "\" + strDirNmOnly)
                        If IsNothing(IBDiInfo) = False Then
                            dtpDirInfo.Value = IBDiInfo.CreationTime
                        End If
                    Else

                        dtpDirInfo.Value = dtpDirInfo.Value.AddYears(-100)
                    End If

                    CopyDirectoryRecursive(strSrcDir, strLastDir + "\" + strDirNmOnly, strIBOld + "\" + strDirNmOnly)

                    DeleteEmptyDirs(strLastDir)
                    Threading.Thread.Sleep(500)
                    dtpDirInfo.Value = Now
                Else

                    Dim file = New System.IO.FileInfo(strSrcDir.Trim)
                    Dim DestFileInfo As New System.IO.FileInfo(IO.Path.Combine(strTmp, file.Name))

                    If strBakupMode = "IB" Or strBakupMode = "DB" Then
                        If file.LastWriteTime > DestFileInfo.LastWriteTime Then
                            file.CopyTo(IO.Path.Combine(strLastDir, file.Name), True)
                            ChangedFileCount = ChangedFileCount + 1
                        End If
                    ElseIf strBakupMode = "FB" Then
                        file.CopyTo(IO.Path.Combine(strLastDir, file.Name), True)
                    End If

                    totalFileCount = totalFileCount + 1
                End If
                ToolStripProgressBar1.Style = ProgressBarStyle.Blocks
                ToolStripProgressBar1.Visible = False
                '-------------------------------------------------------
                'Create log file at copied directoy
                '-------------------------------------------------------

                If IO.Directory.Exists(strLastDir) = True Then
                    DeleteEmptyDirs(strLastDir)

                    If IO.Directory.Exists(strLastDir) Then
                        If IO.File.Exists(strLastDir + "\backuplog.txt") Then IO.File.Delete(strLastDir + "\backuplog.txt")
                        Dim objWriter As New System.IO.StreamWriter(strLastDir + "\backuplog.txt", False)
                        objWriter.WriteLine("Last Backup made at : " + Now)
                        objWriter.WriteLine("Total file(s) : " + totalFileCount.ToString)
                        objWriter.WriteLine("Changed file(s) : " + ChangedFileCount.ToString)
                        objWriter.Close()
                        '-------------------------------------------------------
                        'end here create log
                        '-------------------------------------------------------
                    End If


                End If

            Next
            WriteToEventsLog(strCCode, "Total file(s): " + totalFileCount.ToString)
            WriteToEventsLog(strCCode, "Changed file(s) : " + ChangedFileCount.ToString)
            'original copy ends here
            'nfy.ShowBalloonTip(3000, "K Backup", "Backup Finished Successfully.", ToolTipIcon.Info)
            ini = Nothing
            Return True
            'Me.Visible = False
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
            ToolStripProgressBar1.Value = 0
            ToolStripProgressBar1.Visible = False
            Return False
        End Try
    End Function
    Private Sub mnuTaskRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTaskRun.Click

        If lvwPics.SelectedItems.Count = 0 Then Exit Sub
        Call TriggerEvent(lvwPics.SelectedItems(0).Text, lvwPics.SelectedItems(0).SubItems(7).Text)

    End Sub

    '//below is new code for zip
    Private Sub SetProgressBars()
        If Me.ProgressBar1.InvokeRequired Then
            Me.ProgressBar1.Invoke(New MethodInvoker(AddressOf SetProgressBars))
        Else
            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Maximum = Me._entriesToZip
            Me.ProgressBar1.Minimum = 0
            Me.ProgressBar1.Step = 1
            Me.ProgressBar2.Value = 0
            Me.ProgressBar2.Minimum = 0
            Me.ProgressBar2.Maximum = 1
            Me.ProgressBar2.Step = 2
        End If

    End Sub
    Private Sub StepEntryProgress(ByVal e As SaveProgressEventArgs)

        If Me.ProgressBar2.InvokeRequired Then
            Me.ProgressBar2.Invoke(New SaveEntryProgress(AddressOf Me.StepEntryProgress), New Object() {e})
        ElseIf Not Me._saveCancelled Then
            If (Me.ProgressBar2.Maximum = 1) Then
                Dim entryMax As Long = e.TotalBytesToTransfer
                Dim absoluteMax As Long = &H7FFFFFFF
                Me._progress2MaxFactor = 0
                Do While (entryMax > absoluteMax)
                    entryMax = (entryMax / 2)
                    Me._progress2MaxFactor += 1
                Loop
                If (CInt(entryMax) < 0) Then
                    entryMax = (entryMax * -1)
                End If
                Me.ProgressBar2.Maximum = CInt(entryMax)
            End If
            Dim xferred As Integer = CInt((e.BytesTransferred >> Me._progress2MaxFactor))
            Me.ProgressBar2.Value = IIf((xferred >= Me.ProgressBar2.Maximum), Me.ProgressBar2.Maximum, xferred)
            MyBase.Update()
        End If

    End Sub
    Private Sub SaveCompleted()

        If Me.lblStatus.InvokeRequired Then
            Me.lblStatus.Invoke(New MethodInvoker(AddressOf SaveCompleted))
            'Me.lblStatus.Invoke(New MethodInvoker(Me, DirectCast(Me.SaveCompleted, IntPtr)))
        Else
            Me.lblStatus.Text = String.Format("Done: Compressed {0} files, {1:N0}% of original", Me._nFilesCompleted, _
                                              ((100 * Me._totalBytesAfterCompress) / CDbl(Me._totalBytesBeforeCompress)))
            ResetState()
            'nfy.ShowBalloonTip(3000, "K Backup", "Backup file created.", ToolTipIcon.Info)

            nfy.ShowBalloonTip(3000, txtAppName.Text, lblZipFileNM.Text + " Backup file created successfully", ToolTipIcon.Info)
            WriteToEventsLog(lblStrCode.Text, "Backup event completed successfully")
            'WriteToEventsLog(lblStrCode.Text, "====================================================================================")
            PlayBackgroundSoundResource("end")
            'For backup at all locations
            Dim ini As New IniFile(strCurPath & "\Data\BackupData.db")
            Dim strTmp As String = String.Empty
            Dim strLPath() As String = Nothing
            Dim intFlCnt As Integer = 0

            Dim predicate As Func(Of BackupRecord, Boolean) = Nothing
            If (predicate Is Nothing) Then
                predicate = Function(st As BackupRecord)
                                Return (st.TID = lblStrCode.Text)
                            End Function
            End If
            Dim parameter As BackupRecord = Enumerable.First(Of BackupRecord)(Enumerable.Where(Of BackupRecord)(BackupData.Instance.BackupList, predicate))

            strTmp = parameter.DestDirT
            Dim DestEventPathList() As String
            If parameter.DestDirPath.ToString.Contains("%") = True Then
                Dim DirWords1 As String() = parameter.DestDirPath.ToString.Split(New Char() {"%"c})
                DestEventPathList = DirWords1
            Else
                Dim tmpArr() As String = {parameter.DestDirPath.ToString}
                DestEventPathList = tmpArr
            End If

            For i = 1 To UBound(DestEventPathList)
                strTmp = DestEventPathList(i)
                If strTmp <> String.Empty Then
                    ReDim Preserve strLPath(i)
                    strLPath(i) = strTmp
                End If
            Next


            Dim strFTPS As String = ""
            Dim strFTPU As String = ""
            Dim strFTPP As String = ""
            Dim strFTPPort As String = ""

            Dim boolFTPUpload As Boolean = False
            Dim boolWebDavUpload As Boolean = False
            strTmp = parameter.Other
            If strTmp <> String.Empty And strTmp <> "0" Then
                If strTmp = "FTP" Then
                    boolFTPUpload = True
                    strFTPS = parameter.FTPinfo.FTPS
                    strFTPU = parameter.FTPinfo.FTPU
                    strFTPP = parameter.FTPinfo.FTPP
                    strFTPP = AES_Decrypt(strFTPP, "k5*e#d4o%p@%568")
                ElseIf strTmp = "WebDav" Then
                    boolFTPUpload = True
                    strFTPS = parameter.WebDavinfo.WDS
                    strFTPU = parameter.WebDavinfo.WDU
                    strFTPP = parameter.WebDavinfo.WDP
                    strFTPP = AES_Decrypt(strFTPP, "k5*e#d4o%p@%568")
                    strFTPPort = parameter.WebDavinfo.WDSPort
                End If
            End If

            Try
                If IsNothing(strLPath) <> True Then

                    For i = 0 To UBound(strLPath)
                        Dim file = New System.IO.FileInfo(lblZipFileNM.Text)
                        file.CopyTo(IO.Path.Combine(strLPath(i), file.Name), True)
                    Next
                End If
            Catch ex As Exception
                MsgBox("Error while taking backup to all selected location. You might have sufficient rights or specified destination not accesible", MsgBoxStyle.Information, "Information")
                Log.WriteException(ex, TraceEventType.Error)
            End Try


            strTmp = parameter.Other
            If strTmp <> String.Empty And strTmp <> "0" Then
                If strTmp = "FTP" Then
                    boolFTPUpload = True
                ElseIf strTmp = "WebDAV" Then
                    boolWebDavUpload = True
                End If
            End If

            If boolFTPUpload = True Then
                If CheckForInternetConnection() = True Then
                    WriteToEventsLog(lblStrCode.Text, "FTP Backup event started")
                    nfy.ShowBalloonTip(3000, txtAppName.Text, "FTP Uploading event started.", ToolTipIcon.Info)
                    'Dim file = New System.IO.FileInfo(lblZipFileNM.Text)
                    Dim file = New System.IO.FileInfo(lblToFTPTempFile.Text)

                    Call FTPUpload(lblToFTPTempFile.Text, file.Name, strFTPS, strFTPU, strFTPP)

                Else
                    MsgBox("No internet connectivity, unable to upload backup at Server, Please run this task manually again later.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Error")
                    ini.WriteValue("Value" + parameter.TID, "EC", True)
                    ini.WriteValue("Value" + parameter.TID, "ET", "FTP Failed - No internet connectivity.")
                    WriteToEventsLog(lblStrCode.Text, "FTP upload failed due to internet connectivity.")
                End If
            ElseIf boolWebDavUpload = True Then
                If CheckForInternetConnection() = True Then
                    WriteToEventsLog(lblStrCode.Text, "WebDAV Backup event started")
                    nfy.ShowBalloonTip(3000, txtAppName.Text, "WebDAV Uploading event started.", ToolTipIcon.Info)
                    'Dim file = New System.IO.FileInfo(lblZipFileNM.Text)
                    Dim file = New System.IO.FileInfo(lblToFTPTempFile.Text)

                    'Call FTPUpload(lblToFTPTempFile.Text, file.Name, strFTPS, strFTPU, strFTPP)
                    'here main webDAV UPload starts

                Else
                    MsgBox("No internet connectivity, unable to upload backup at Server, Please run this task manually again later.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Error")
                    ini.WriteValue("Value" + parameter.TID, "EC", True)
                    ini.WriteValue("Value" + parameter.TID, "ET", "WebDAV Connection Failed - No internet connectivity.")
                    WriteToEventsLog(lblStrCode.Text, "WebDAV upload failed due to internet connectivity.")
                End If
            End If

            For i = 0 To 2000
                Application.DoEvents()
            Next
            strTmp = parameter.LocalBack  ' if no backup at local pc than remove zip file
            If strTmp = "0" Then lblDelZipFile.Text = "1" Else lblDelZipFile.Text = "0" ' only ftp upload so delete temp zip file
            ini = Nothing
            'Me.Visible = False
        End If

    End Sub
    Private Function FTPUpload(ByVal strFullPath As String, ByVal strOnlyFileName As String, ByVal sS As String, ByVal SU As String, ByVal SP As String) As Boolean
        Dim strFTPServer As String = sS '"sdddd.ftp.com"
        Dim strFTPU As String = SU
        Dim strFTPP As String = SP
        Dim remoteFolder As String = strFTPDirNm
        Dim remoteFolderAndFile As String = remoteFolder + strOnlyFileName

        'ToolStripProgressBar1.Visible = True
        paFTP.Visible = True
        Dim fwrRequest As System.Net.FtpWebRequest
        Dim fwrResponse As System.Net.WebResponse
        Try
            fwrRequest = DirectCast(System.Net.WebRequest.Create(strFTPServer + remoteFolder), System.Net.FtpWebRequest)
            fwrRequest.Credentials = New System.Net.NetworkCredential(strFTPU, strFTPP)
            fwrRequest.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory
            fwrResponse = fwrRequest.GetResponse
            fwrResponse.Close()
            fwrResponse = Nothing
            fwrRequest = Nothing
        Catch ex As Exception
            'directory already exist
            'WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            'MsgBox("Error logged while uploading backup to FTP server.", MsgBoxStyle.Information, "Error")
            'Log.WriteException(ex, TraceEventType.Error)
        End Try

        Try
            Dim myUri As New Uri(strFTPServer + remoteFolderAndFile)
            myFtpUploadWebClient.Credentials = New System.Net.NetworkCredential(strFTPU, strFTPP)
            myFtpUploadWebClient.UploadFileAsync(myUri, strFullPath)
        Catch ex As Exception
            'ToolStripProgressBar1.Visible = False
            paFTP.Visible = False
            Return False
        End Try
        ' this is working
        Return True
    End Function

    Private Sub myFtpUploadWebClient_UploadProgressChanged(ByVal sender As Object, ByVal e As System.Net.UploadProgressChangedEventArgs) Handles myFtpUploadWebClient.UploadProgressChanged
        PBFTP.Value = e.ProgressPercentage
        'ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub myFtpUploadWebClient_UploadFileCompleted(ByVal sender As Object, ByVal e As System.Net.UploadFileCompletedEventArgs) Handles myFtpUploadWebClient.UploadFileCompleted

        If e.Error IsNot Nothing Then
            MessageBox.Show(e.Error.Message)
            'ToolStripProgressBar1.Visible = False

            paFTP.Visible = False
            PBFTP.Value = 0
            WriteToEventsLog(lblStrCode.Text, "FTP Backup upload error, " + e.Error.Message)
            nfy.ShowBalloonTip(3000, txtAppName.Text, "Upload to FTP server failed.", ToolTipIcon.Info)
        Else
            Me.Cursor = Cursors.Default
            'ToolStripProgressBar1.Visible = False
            paFTP.Visible = False
            WriteToEventsLog(lblStrCode.Text, "FTP Backup uploaded sucessfully.")
            'MsgBox("Error occured while backing up data at FTP Server!", MsgBoxStyle.Information, "Error")
            nfy.ShowBalloonTip(3000, txtAppName.Text, "Upload to FTP server sucessfull.", ToolTipIcon.Info)
            PlayBackgroundSoundResource("end")
            boolEventInProgress = False
            Try
                If lblDelZipFile.Text = "1" Then IO.File.Delete(lblToFTPTempFile.Text)
            Catch ex As Exception
                'Log.WriteException(ex, TraceEventType.Error)
                Call errHandlerForm(ex)
            End Try

        End If
    End Sub
    Private Sub StepArchiveProgress(ByVal e As SaveProgressEventArgs)
        On Error Resume Next
        If Me.ProgressBar1.InvokeRequired Then
            Me.ProgressBar1.Invoke(New SaveEntryProgress(AddressOf Me.StepArchiveProgress), New Object() {e})
        ElseIf Not Me._saveCancelled Then
            Me._nFilesCompleted += 1
            Me.ProgressBar1.PerformStep()
            Me._totalBytesAfterCompress = (Me._totalBytesAfterCompress + e.CurrentEntry.CompressedSize)
            Me._totalBytesBeforeCompress = (Me._totalBytesBeforeCompress + e.CurrentEntry.UncompressedSize)
            ' progressBar2 is the one dealing with the item being added to the archive
            ' if we got this event, then the add of that item (or file) is complete, so we 
            ' update the progressBar2 appropriately.
            Me.ProgressBar2.Value = Me.ProgressBar2.Maximum = 1 '- 1
            Me.lblStatus.Text = String.Format("{0} of {1} files...({2})", (Me._nFilesCompleted + 1), Me._entriesToZip, e.CurrentEntry.FileName)
            MyBase.Update()
        End If

    End Sub
    Private Sub zip1_SaveProgress(ByVal sender As Object, ByVal e As SaveProgressEventArgs)

        If Me._saveCancelled Then
            e.Cancel = True
            Return
        End If

        Select Case e.EventType
            Case ZipProgressEventType.Saving_AfterWriteEntry
                Me.StepArchiveProgress(e)
                Exit Select
            Case ZipProgressEventType.Saving_Completed
                Me.SaveCompleted()
                Exit Select
            Case ZipProgressEventType.Saving_EntryBytesRead
                Me.StepEntryProgress(e)
                Exit Select
        End Select

    End Sub

    Private Sub DoSave(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim Sourcelist As List(Of String)
        Dim Cnt As Integer = 0
        Dim options As WorkerOptions = e.Argument
        Dim strLastZip As String = ""
        Try
            If options.oldZip <> "" Then

                '///for directory////

                Dim strIBModeOld As String = options.ZipName.ToString.Substring(0, options.ZipName.Length - 4)
                Dim strIBModeNew As String = options.ZipName.ToString.Substring(0, options.ZipName.Length - 4)
                Dim strLastFile As String = strIBModeOld

                Dim b As Boolean = False ' for ftp zip access

                Dim oldZip As ZipFile

                'WebDAV from here

                If options.isFTPDo = True Then
                    '-----------' FTP with incremental & differential support------------------
                    Dim MyRemoteZip As New RemoteZip.RemoteZipFile

                    If strBakupMode = "IB" Then
                        While CheckIfFtpFileExists(strIBModeNew + ".zip", options.ftpUser, options.ftpPass) = True
                            Cnt = Cnt + 1
                            strIBModeNew = String.Format("{0}({1}", strIBModeOld, Cnt.ToString()) + ")"
                            If Cnt - 1 <> 0 Then
                                strLastFile = String.Format("{0}({1}", strIBModeOld, Cnt - 1.ToString()) + ")"
                            End If
                        End While
                        WriteToEventsLog(lblStrCode.Text, "Incremental backup - creating zip file - " + options.ZipName)
                        strLastZip = strLastFile + ".zip"
                        Try
                            b = MyRemoteZip.Load(options.oldZip.Replace("ftp://", "http://"))
                            'b = MyRemoteZip.Load("http://127.0.0.1/rr/easybackup/test backup.zip")


                        Catch ee As Exception
                            'MsgBox("Exception during transfer " + ee.ToString)
                            'Log.WriteException(ee, TraceEventType.Error)
                            'Throw ee
                            Call errHandlerForm(ee)
                            Me.btnCancel_Click(Nothing, Nothing)
                        End Try
                    ElseIf strBakupMode = "DB" Then
                        If CheckIfFtpFileExists(options.oldZip.ToString.Replace(".zip", "(1).zip"), options.ftpUser, options.ftpPass) = True Then
                            'If IO.File.Exists(options.oldZip.ToString.Replace(".zip", "(1).zip")) Then
                            'IO.File.Delete(options.oldZip.ToString.Replace(".zip", "(1).zip"))

                            '    oldZip = ZipFile.Read(options.oldZip)
                            '   strLastZip = options.oldZip
                            '  Threading.Thread.Sleep(2000)
                        Else
                            Try
                                b = MyRemoteZip.Load(options.oldZip.Replace("ftp://", "http://"))

                            Catch ee As Exception
                                'MsgBox("Exception during transfer " + ee.ToString, "FTP Backup Failed")
                                'Log.WriteException(ee, TraceEventType.Error)
                                Call errHandlerForm(ee)
                                Me.btnCancel_Click(Nothing, Nothing)
                                Exit Sub
                            End Try
                            'oldZip = ZipFile.Read(options.oldZip)
                            strLastZip = options.oldZip.ToString.Replace(".zip", "(1).zip")
                            Threading.Thread.Sleep(2000)
                        End If
                        WriteToEventsLog(lblStrCode.Text, "Differential backup - creating zip file - " + options.oldZip.ToString.Replace(".zip", "(1).zip"))
                    End If

                    Try


                        Dim NewZip As New ZipFile
                        NewZip.UseUnicodeAsNecessary = True
                        NewZip.UseZip64WhenSaving = Zip64Option.AsNecessary
                        If options.DoEnc = True Then
                            NewZip.Password = options.EncPass
                            NewZip.Encryption = IIf(options.EncMethod = "AES128", EncryptionAlgorithm.WinZipAes128, EncryptionAlgorithm.WinZipAes256)
                        End If
                        'get FTP ZIP file date and time
                        Dim strFTPLastTime As String = FTPGetCreationTime(options.oldZip, options.ftpUser, options.ftpPass)
                        '---------Continuation FTP---------
                        For i = 0 To UBound(options.Folder)
                            Dim dirInfo As New IO.DirectoryInfo(options.Folder(i))
                            Dim split As String() = options.Folder(i).Split("\")
                            Dim parentFolder As String = split(split.Length - 1)

                            Dim existInFTP As Boolean = False
                            If b Then
                                For Each zipe As ICSharpCode.SharpZipLib.Zip.ZipEntry In MyRemoteZip
                                    If zipe.ToString = parentFolder + "/" Then
                                        existInFTP = True
                                    End If
                                Next
                            End If
                            If existInFTP = False And strBakupMode <> "DB" Then
                                NewZip.AddDirectory(options.Folder(i), parentFolder)

                            End If

                            'Dim candidZipEntry As ZipEntry = oldZip(parentFolder + "/") ' todelete

                            Sourcelist = GetFilesRecursive(options.Folder(i))

                            'filtercheck1
                            Dim intFilter As Integer = 0
                            For intfil = 0 To Sourcelist.Count - 1

                            Next
                            Dim strZipVal As String = ""
                            Dim strFileVal As String = ""
                            Dim strFullFilePath As String = ""
                            Dim boolExistinZip As Boolean = False
                            For j = 0 To Sourcelist.Count - 1 ' total Files on Source directory

                                For Each candidZEntry As ICSharpCode.SharpZipLib.Zip.ZipEntry In MyRemoteZip

                                    'Next
                                    'For Each candidZipEntry In oldZip ' total files in zip directory
                                    strZipVal = candidZEntry.ToString.Replace("/", "\")
                                    strFileVal = Sourcelist.Item(j).Substring(0, Sourcelist.Item(j).IndexOf(parentFolder))
                                    strFullFilePath = strFileVal + strZipVal

                                    If (strFullFilePath).IndexOf(".") > 0 Then

                                        If Sourcelist.Item(j) = strFullFilePath Then
                                            If IO.File.Exists(strFullFilePath) Then
                                                Dim flInfo As IO.FileInfo = New IO.FileInfo(strFullFilePath)
                                                If flInfo.LastWriteTime > candidZEntry.DateTime.AddSeconds(30) Then
                                                    If strBakupMode = "IB" Then
                                                        Dim strFTPTime As String = FTPGetCreationTime(strLastZip, options.ftpUser, options.ftpPass)
                                                        'Dim LastZip As New IO.FileInfo(strLastZip)

                                                        If flInfo.LastWriteTime > strFTPTime Then
                                                            NewZip.AddFile(flInfo.FullName, flInfo.Directory.Name)
                                                        End If
                                                        'LastZip = Nothing
                                                    Else
                                                        NewZip.AddFile(flInfo.FullName, flInfo.Directory.Name)

                                                    End If
                                                End If

                                            End If
                                            boolExistinZip = True

                                            Exit For
                                        Else
                                            boolExistinZip = False
                                        End If
                                    End If
                                Next

                                If boolExistinZip = False And (Sourcelist(j).IndexOf(".")) > 0 Then
                                    Dim NewFlInfo As IO.FileInfo = New IO.FileInfo(Sourcelist.Item(j))
                                    'Dim strFTPLastTime As String = FTPGetCreationTime(strIBModeNew + ".zip", options.ftpUser, options.ftpPass)

                                    If strBakupMode = "IB" Then
                                        Dim strFTPTime As String = FTPGetCreationTime(strLastZip, options.ftpUser, options.ftpPass)
                                        'Dim FlInfoTmp As New System.IO.FileInfo(strLastZip)
                                        If strFTPTime = "0" Then
                                            NewZip.AddFile(Sourcelist(j).ToString, NewFlInfo.Directory.Name)
                                        ElseIf NewFlInfo.LastWriteTime > strFTPTime Or NewFlInfo.CreationTime > strFTPTime Then
                                            NewZip.AddFile(Sourcelist(j).ToString, NewFlInfo.Directory.Name)
                                        End If

                                    ElseIf strBakupMode = "DB" Then
                                        NewZip.AddFile(Sourcelist(j).ToString, NewFlInfo.Directory.Name)
                                    End If
                                    NewFlInfo = Nothing
                                End If
                            Next
                            'candidZipEntry = Nothing
                        Next
                        'Next

                        '///for directory////
                        For i = 0 To UBound(options.Files)
                            'Dim dirInfo1 As New IO.DirectoryInfo(options.Folder(i))
                            'For Each CurrentfileOnDisk In dirInfo.
                            Dim CurrentFL As New IO.FileInfo(options.Files(i))
                            Dim candidZipEntry As ZipEntry = oldZip(CurrentFL.Name.ToString)    'oldZip(options.Folder(i))
                            Dim zipInfo As New IO.FileInfo(strLastZip)

                            If (Not IsNothing(candidZipEntry)) And (CurrentFL.LastWriteTime > zipInfo.LastWriteTime) Then
                                NewZip.AddFile(options.Files(i), "")
                            ElseIf IsNothing(candidZipEntry) Then
                                NewZip.AddFile(options.Files(i) < "")
                            End If
                        Next


                        lbDir.Items.Clear()
                        lbFiles.Items.Clear()
                        'zip1.AddDirectory(options.Folder, options.Folder) ' to not replicate the path, use the overloads to add to root of zip AddDirectory(options.Folder,"")
                        If NewZip.Count <> 0 Then

                            Me._entriesToZip = NewZip.EntryFileNames.Count
                            Me.SetProgressBars()
                            AddHandler NewZip.SaveProgress, New EventHandler(Of SaveProgressEventArgs)(AddressOf Me.zip1_SaveProgress)
                            Thread.Sleep(1000)
                            NewZip.Comment = "This zip was created at: " & System.DateTime.Now.ToString("G")
                            'NewZip.Save(options.ZipName)
                            Cnt = 0
                            Dim oldFileName As String = options.ZipName.ToString.Substring(0, options.ZipName.Length - 4)
                            Dim tt As Integer = options.ftpFileName.LastIndexOf("\") + 1
                            Dim sss As String = options.ftpFileName.ToString.Substring(tt, (options.ftpFileName.ToString.Length) - tt - 4)
                            Dim newFileName As String = sss
                            oldFileName = oldFileName.Replace(sss, "")
                            If strBakupMode = "IB" Then

                                While CheckIfFtpFileExists(oldFileName + newFileName + ".zip", options.ftpUser, options.ftpPass) = True
                                    Cnt = Cnt + 1
                                    'oldFileName = String.Format("{0}({1}", oldFileName, Cnt.ToString()) + ")"
                                    newFileName = String.Format("{0}({1}", sss, Cnt.ToString()) + ")"
                                    'Exit While
                                End While

                                'oldZip.Dispose()
                                oldZip = Nothing
                                lblToFTPTempFile.Text = System.IO.Path.GetTempPath + newFileName + ".zip"

                                NewZip.Save(lblToFTPTempFile.Text)

                                WriteToEventsLog(lblStrCode.Text, NewZip.Count.ToString + " item updated/created new backup file " + newFileName + ".zip")
                                WriteToEventsLog(lblStrCode.Text, "====================================================================================")
                            ElseIf strBakupMode = "DB" Then ' differential backup
                                'oldZip.Dispose()
                                oldZip = Nothing
                                lblToFTPTempFile.Text = System.IO.Path.GetTempPath + newFileName + "(1).zip"
                                NewZip.Save(lblToFTPTempFile.Text)
                                WriteToEventsLog(lblStrCode.Text, NewZip.Count.ToString + " item updated/created new backup file " + newFileName + ".zip")
                                WriteToEventsLog(lblStrCode.Text, "====================================================================================")
                                lblToFTPTempFile.Text = System.IO.Path.GetTempPath + newFileName + ".zip"
                            End If
                        Else
                            WriteToEventsLog(lblStrCode.Text, "No changes found.")
                            btnCancel_Click(sender, e)
                            WriteToEventsLog(lblStrCode.Text, "Backup event completed successfully.")
                            'WriteToEventsLog(lblStrCode.Text, "====================================================================================")
                        End If
                    Catch ex As Exception
                        'Log.WriteException(ex, TraceEventType.Error)
                        Call errHandlerForm(ex)
                    End Try
                    '-----------' Above part is for FTP incremental & differential support------------------
                Else
                    '-----------' Local with incremental & differential support------------------



                    If strBakupMode = "IB" Then
                        While IO.File.Exists(strIBModeNew + ".zip")
                            Cnt = Cnt + 1
                            strIBModeNew = String.Format("{0}({1}", strIBModeOld, Cnt.ToString()) + ")"
                            If Cnt - 1 <> 0 Then
                                strLastFile = String.Format("{0}({1}", strIBModeOld, Cnt - 1.ToString()) + ")"
                            End If
                        End While
                        WriteToEventsLog(lblStrCode.Text, "Incremental backup - creating zip file - " + options.ZipName)
                        strLastZip = strLastFile + ".zip"
                        oldZip = ZipFile.Read(options.oldZip)
                    ElseIf strBakupMode = "DB" Then
                        If IO.File.Exists(options.oldZip.ToString.Replace(".zip", "(1).zip")) Then
                            'IO.File.Delete(options.oldZip.ToString.Replace(".zip", "(1).zip"))
                            oldZip = ZipFile.Read(options.oldZip)
                            strLastZip = options.oldZip
                            Threading.Thread.Sleep(2000)
                        Else
                            oldZip = ZipFile.Read(options.oldZip)
                            strLastZip = options.oldZip
                        End If
                        WriteToEventsLog(lblStrCode.Text, "Differential backup - creating zip file - " + options.oldZip.ToString.Replace(".zip", "(1).zip"))
                    End If


                    Dim NewZip As New ZipFile
                    NewZip.UseUnicodeAsNecessary = True
                    NewZip.UseZip64WhenSaving = Zip64Option.AsNecessary
                    If options.DoEnc = True Then
                        NewZip.Password = options.EncPass
                        NewZip.Encryption = IIf(options.EncMethod = "AES128", EncryptionAlgorithm.WinZipAes128, EncryptionAlgorithm.WinZipAes256)
                    End If

                    For i = 0 To UBound(options.Folder)
                        Dim dirInfo As New IO.DirectoryInfo(options.Folder(i))
                        Dim split As String() = options.Folder(i).Split("\")
                        Dim parentFolder As String = split(split.Length - 1)


                        Dim candidZipEntry As ZipEntry = oldZip(parentFolder + "/")


                        If IsNothing(candidZipEntry) And strBakupMode <> "DB" Then
                            NewZip.AddDirectory(options.Folder(i), parentFolder)
                        End If

                        Sourcelist = GetFilesRecursive(options.Folder(i))


                        Dim strZipVal As String = ""
                        Dim strFileVal As String = ""
                        Dim strFullFilePath As String = ""
                        Dim boolExistinZip As Boolean = False
                        For j = 0 To Sourcelist.Count - 1 ' total Files on Source directory

                            For Each candidZipEntry In oldZip ' total files in zip directory
                                strZipVal = candidZipEntry.FileName.Replace("/", "\")
                                strFileVal = Sourcelist.Item(j).Substring(0, Sourcelist.Item(j).IndexOf(parentFolder))
                                strFullFilePath = strFileVal + strZipVal

                                If (strFullFilePath).IndexOf(".") > 0 Then

                                    If Sourcelist.Item(j) = strFullFilePath Then
                                        If IO.File.Exists(strFullFilePath) Then

                                            Dim flInfo As IO.FileInfo = New IO.FileInfo(strFullFilePath)
                                            If flInfo.LastWriteTime > candidZipEntry.LastModified.AddSeconds(30) Then
                                                If strBakupMode = "IB" Then
                                                    Dim LastZip As New IO.FileInfo(strLastZip)
                                                    'If flInfo.FullName.Contains("SaleX1_10 - Copy.rpt") Then
                                                    'MsgBox("HI")
                                                    'End If
                                                    'Dim LastZipEntry As ZipEntry = LastZip(candidZipEntry.FileName)
                                                    If flInfo.LastWriteTime > LastZip.LastWriteTime Then
                                                        NewZip.AddFile(flInfo.FullName, flInfo.Directory.Name)

                                                    End If
                                                    LastZip = Nothing
                                                Else
                                                    NewZip.AddFile(flInfo.FullName, flInfo.Directory.Name)
                                                End If
                                            End If

                                        End If
                                        boolExistinZip = True

                                        Exit For
                                    Else
                                        boolExistinZip = False

                                    End If
                                End If
                            Next

                            If boolExistinZip = False And (Sourcelist(j).IndexOf(".")) > 0 Then
                                Dim NewFlInfo As IO.FileInfo = New IO.FileInfo(Sourcelist.Item(j))
                                If strBakupMode = "IB" Then
                                    Dim FlInfoTmp As New System.IO.FileInfo(strLastZip)
                                    If FlInfoTmp Is Nothing Then
                                        NewZip.AddFile(Sourcelist(j).ToString, NewFlInfo.Directory.Name)
                                    ElseIf NewFlInfo.LastWriteTime > FlInfoTmp.CreationTime Or NewFlInfo.CreationTime > FlInfoTmp.CreationTime Then
                                        NewZip.AddFile(Sourcelist(j).ToString, NewFlInfo.Directory.Name)
                                    End If
                                    FlInfoTmp = Nothing
                                ElseIf strBakupMode = "DB" Then
                                    NewZip.AddFile(Sourcelist(j).ToString, NewFlInfo.Directory.Name)
                                End If
                                NewFlInfo = Nothing
                            End If
                        Next
                        'candidZipEntry = Nothing
                    Next
                    'Next

                    '///for directory////
                    For i = 0 To UBound(options.Files)
                        'Dim dirInfo1 As New IO.DirectoryInfo(options.Folder(i))
                        'For Each CurrentfileOnDisk In dirInfo.
                        Dim CurrentFL As New IO.FileInfo(options.Files(i))
                        Dim candidZipEntry As ZipEntry = oldZip(CurrentFL.Name.ToString)    'oldZip(options.Folder(i))
                        Dim zipInfo As New IO.FileInfo(strLastZip)

                        If (Not IsNothing(candidZipEntry)) And (CurrentFL.LastWriteTime > zipInfo.LastWriteTime) Then
                            NewZip.AddFile(options.Files(i), "")
                        ElseIf IsNothing(candidZipEntry) Then
                            NewZip.AddFile(options.Files(i) < "")
                        End If
                    Next


                    lbDir.Items.Clear()
                    lbFiles.Items.Clear()
                    'zip1.AddDirectory(options.Folder, options.Folder) ' to not replicate the path, use the overloads to add to root of zip AddDirectory(options.Folder,"")
                    If NewZip.Count <> 0 Then

                        Me._entriesToZip = NewZip.EntryFileNames.Count
                        Me.SetProgressBars()
                        AddHandler NewZip.SaveProgress, New EventHandler(Of SaveProgressEventArgs)(AddressOf Me.zip1_SaveProgress)
                        Thread.Sleep(1000)
                        NewZip.Comment = "This zip was created at: " & System.DateTime.Now.ToString("G")
                        'NewZip.Save(options.ZipName)
                        Cnt = 0
                        Dim oldFileName As String = options.ZipName.ToString.Substring(0, options.ZipName.Length - 4)
                        Dim newFileName As String = options.ZipName.ToString.Substring(0, options.ZipName.Length - 4)
                        If strBakupMode = "IB" Then
                            While IO.File.Exists(newFileName + ".zip")
                                Cnt = Cnt + 1
                                newFileName = String.Format("{0}({1}", oldFileName, Cnt.ToString()) + ")"
                                'Exit While
                            End While

                            oldZip.Dispose()
                            oldZip = Nothing
                            NewZip.Save(newFileName + ".zip")
                            WriteToEventsLog(lblStrCode.Text, NewZip.Count.ToString + " item updated/created new backup file " + newFileName + ".zip")
                            WriteToEventsLog(lblStrCode.Text, "====================================================================================")
                        ElseIf strBakupMode = "DB" Then ' differential backup
                            oldZip.Dispose()
                            oldZip = Nothing
                            NewZip.Save(oldFileName + "(1).zip")
                            WriteToEventsLog(lblStrCode.Text, NewZip.Count.ToString + " item updated/created new backup file " + newFileName + ".zip")
                            WriteToEventsLog(lblStrCode.Text, "====================================================================================")
                        End If
                    Else
                        WriteToEventsLog(lblStrCode.Text, "No changes found.")
                        btnCancel_Click(sender, e)
                        WriteToEventsLog(lblStrCode.Text, "Backup event completed successfully.")
                        'WriteToEventsLog(lblStrCode.Text, "====================================================================================")
                    End If
                    '-----------' Above part is for Local incremental & differential support------------------
                    '-----------' FTP & Local with incremental & differential support ends here------------------
                End If


            Else ' Createing New ZIP FILE- Full Backup

                Using zip1 As New ZipFile
                    'zip1.UseUnicodeAsNecessary = True
                    zip1.AlternateEncodingUsage = Ionic.Zip.ZipOption.Always
                    zip1.AlternateEncoding = System.Text.Encoding.UTF8
                    If options.DoEnc = True Then
                        zip1.Password = options.EncPass
                        zip1.Encryption = IIf(options.EncMethod = "AES128", EncryptionAlgorithm.WinZipAes128, EncryptionAlgorithm.WinZipAes256)
                    End If
                    zip1.UseZip64WhenSaving = Zip64Option.AsNecessary

                    For i = 0 To UBound(options.Folder)
                        '////////////////////////////////////////
                        Dim split As String() = options.Folder(i).Split("\")
                        Dim parentFolder As String = split(split.Length - 1)
                        If options.oldZip <> "" Then

                        Else
                            zip1.AddDirectory(options.Folder(i), parentFolder)
                        End If
                        '///////////////////////////////////////

                        ' 'zip1.AddDirectory(options.Folder(i), options.Folder(i)) 'to not replicate the path, use the overloads to add to root of zip AddDirectory(options.Folder,"")
                    Next

                    For i = 0 To UBound(options.Files)
                        'If lbFilterE.Items.Count > 0 Then
                        'If boolFilterCompareExclude(options.Files(i).ToString) = True Then Continue For
                        'End If
                        'If lbFilterI.Items.Count > 0 Then
                        'If boolFilterCompareInclude(options.Files(i).ToString) = True Then Continue For
                        'End If
                        zip1.AddFile(options.Files(i), "")
                    Next
                    'exclude list here
                    Dim MarkedEntries As New System.Collections.Generic.List(Of ZipEntry)
                    Dim e1 As ZipEntry
                    If lbFilterE.Items.Count > 0 Then ' exlusion list
                        For i = 0 To lbFilterE.Items.Count - 1
                            For Each e1 In zip1
                                ' here, we apply the criterion to remove the entry.  It is a time-based criterion, but you could 
                                ' use anything you like.  Extension of the file, size of the entry, etc etc. 
                                If e1.FileName.Contains(lbFilterE.Items.Item(0)) Then
                                    MarkedEntries.Add(e1)
                                End If
                            Next
                        Next
                        ' pass 2: actually remove the entry. 
                        Dim zombie As ZipEntry
                        For Each zombie In MarkedEntries
                            zip1.RemoveEntry(zombie)
                        Next

                    End If
                    'exclude list ends here
                    'Include list here

                    If lbFilterI.Items.Count > 0 Then
                        Dim MarkedEntries2 As New System.Collections.Generic.List(Of ZipEntry)
                        Dim e2 As ZipEntry
                        If lbFilterI.Items.Count > 0 Then ' exlusion list
                            For i = 0 To lbFilterI.Items.Count - 1
                                For Each e2 In zip1
                                    ' here, we apply the criterion to remove the entry.  It is a time-based criterion, but you could 
                                    ' use anything you like.  Extension of the file, size of the entry, etc etc. 
                                    If e2.FileName.Contains(lbFilterI.Items.Item(0)) = False Then
                                        MarkedEntries2.Add(e2)
                                    End If
                                Next
                            Next
                            ' pass 2: actually remove the entry. 
                            Dim zombie As ZipEntry
                            For Each zombie In MarkedEntries2
                                zip1.RemoveEntry(zombie)
                            Next
                        End If
                    End If

                    'Include list ends here
                    If (zip1.Entries.Count) = 0 Then
                        MsgBox("No file matching your criteria selection", MsgBoxStyle.Information, "Information")
                        btnCancel_Click(sender, e)
                        Exit Sub
                    End If
                    lbDir.Items.Clear()
                    lbFiles.Items.Clear()
                    'zip1.AddDirectory(options.Folder, options.Folder) ' to not replicate the path, use the overloads to add to root of zip AddDirectory(options.Folder,"")
                    Me._entriesToZip = zip1.EntryFileNames.Count
                    Me.SetProgressBars()
                    AddHandler zip1.SaveProgress, New EventHandler(Of SaveProgressEventArgs)(AddressOf Me.zip1_SaveProgress)
                    Thread.Sleep(1000)
                    zip1.Comment = "This zip was created at: " & System.DateTime.Now.ToString("G")
                    If options.isFTPDo = True Then
                        zip1.Save(options.ftpFileName)
                    Else
                        zip1.Save(options.ZipName)
                    End If


                End Using

            End If
        Catch ex As Exception
            MessageBox.Show(String.Format("Error occured while zipping: {0}", ex.Message))
            'Log.WriteException(ex, TraceEventType.Error)
            Call errHandlerForm(ex)
            Me.btnCancel_Click(Nothing, Nothing)
        End Try
    End Sub
    Private Sub KickoffZipup(ByVal strZIPNM As String, ByVal strColCode As String, ByVal doEncryption As Boolean, Optional ByVal EncMethod As String = "0", Optional ByVal EncPass As String = "0", Optional ByVal isFTP As Boolean = False, Optional ByVal isWebDAV As Boolean = False, Optional ByVal FTPS As String = "", Optional ByVal FTPSPort As String = "", Optional ByVal ftpU As String = "", Optional ByVal ftpP As String = "", Optional ByVal strFTPTMPFile As String = "")
        'private Sub KickoffZipup(ByVal strDirNM() As String, ByVal strZIPNM As String, ByVal strColCode As String)

        'Dim folderName() As String = strDirNM
        Try


            Dim foldername(lbDir.Items.Count - 1) As String

            For i = 0 To lbDir.Items.Count - 1
                foldername(i) = lbDir.Items.Item(i).ToString
            Next

            Dim filename(lbFiles.Items.Count - 1) As String

            For i = 0 To lbFiles.Items.Count - 1
                filename(i) = lbFiles.Items.Item(i).ToString
            Next
            Dim StrOldFile As String = ""
            'FTpCheck1
            If isFTP = True Then
                'check file exist at FTP Server
                If strBakupMode = "IB" Or strBakupMode = "DB" Then
                    If CheckIfFtpFileExists(strZIPNM, ftpU, ftpP) Then StrOldFile = strZIPNM
                End If
            ElseIf isWebDAV = True Then
                If strBakupMode = "IB" Or strBakupMode = "DB" Then
                    If CheckIfFtpFileExists(strZIPNM, ftpU, ftpP) Then StrOldFile = strZIPNM
                End If
            Else
                'check if file exist at local folder
                If IO.File.Exists(strZIPNM) And (strBakupMode = "IB" Or strBakupMode = "DB") Then StrOldFile = strZIPNM
            End If


            paZip.Visible = True

            lblStrCode.Text = strColCode
            lblZipFileNM.Text = strZIPNM
            If strBakupMode = "FB" Then
                If isFTP = True Then

                    'If DeleteFTPFIle(strZIPNM, ftpU, ftpP) = False Then
                    'End If
                    WriteToEventsLog(strColCode, "Full backup at FTP - creating zip file - " + strZIPNM)
                ElseIf isWebDAV = True Then
                    If DeleteFTPFIle(strZIPNM, ftpU, ftpP) = False Then
                    End If
                    WriteToEventsLog(strColCode, "Full backup at FTP - creating zip file - " + strZIPNM)

                Else 'Local backup
                    If IO.File.Exists(strZIPNM) Then
                        Thread.Sleep(2000)
                        WriteToEventsLog(strColCode, "Full backup - creating zip file - " + strZIPNM)
                        IO.File.Delete(strZIPNM) ' This deletes any existing/incomplete zip files with the same name
                        Thread.Sleep(2000)
                    End If
                End If

            End If

            Me._saveCancelled = False
            Me._nFilesCompleted = 0
            Me._totalBytesAfterCompress = 0
            Me._totalBytesBeforeCompress = 0

            Me.btnCancel.Enabled = True
            Me.lblStatus.Text = "Zipping..."
            Dim options As New WorkerOptions
            'need to check here FTP3
            If isFTP = True Then
                'options.ZipName = strFTPTMPFile
                options.ZipName = strZIPNM
                options.ftpFileName = strFTPTMPFile
                lblToFTPTempFile.Text = strFTPTMPFile
            ElseIf isWebDAV = True Then
                options.ZipName = strZIPNM
                options.ftpFileName = strFTPTMPFile
                lblToFTPTempFile.Text = strFTPTMPFile

            Else 'local backup
                options.ZipName = strZIPNM
            End If


            options.Folder = foldername
            options.Files = filename
            options.DoEnc = doEncryption
            options.EncMethod = EncMethod
            options.EncPass = EncPass
            '-----------FTP---------------
            options.isFTPDo = isFTP
            options.isWebDavDo = isWebDAV
            options.ftpServer = FTPS
            options.ftpServerPort = 21
            options.ftpUser = ftpU
            options.ftpPass = ftpP
            options.ftpServerPort = FTPSPort
            '-----------FTP Ends---------------

            If StrOldFile.Length <> 0 Then
                If (strBakupMode = "IB" Or strBakupMode = "DB") Then options.oldZip = StrOldFile
            End If

            _backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
            _backgroundWorker1.WorkerSupportsCancellation = False
            _backgroundWorker1.WorkerReportsProgress = False
            AddHandler Me._backgroundWorker1.DoWork, New DoWorkEventHandler(AddressOf Me.DoSave)
            _backgroundWorker1.RunWorkerAsync(options)

            While _backgroundWorker1.IsBusy
                Application.DoEvents()
            End While
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            Call errHandlerForm(ex)
        End Try
    End Sub
    Private Sub ResetState()
        Me.btnCancel.Enabled = False
        Me.ProgressBar1.Value = 0
        Me.ProgressBar2.Value = 0
        Me.Cursor = Cursors.Default
        paZip.Visible = False
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.lblStatus.InvokeRequired Then
            Me.lblStatus.Invoke(New ButtonClick(AddressOf Me.btnCancel_Click), New Object() {sender, e})
        Else
            Me._saveCancelled = True
            Me.lblStatus.Text = "Cancelled..."
            Me.ResetState()
        End If
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        mnuTaskRun_Click(sender, e)
    End Sub

    Private Sub cMnuRunNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cMnuRunNow.Click
        mnuTaskRun_Click(sender, e)
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        With New AboutBox
            '.AppTitle = Me. .AppTitle
            '.AppDescription = txtDescription.Text
            '.AppVersion = txtVersion.Text
            '.AppCopyright = txtCopyright.Text
            '.AppMoreInfo = txtMoreInfo.Text
            '.AppDetailsButton = chkDetails.Checked
            .ShowDialog(Me)
        End With
    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        mnuAbout_Click(sender, e)
    End Sub

    Private Sub ShowLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsWarnings.Click
        Dim TaskFailed As New frmFailedTask
        TaskFailed.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnFailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFailed.Click
        Call ShowLogToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click
        mnuToolsRestore_Click(sender, e)
    End Sub

    Private Sub mnuToolsRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsRestore.Click
        Dim TaskRestore As New frmRestore
        TaskRestore.ShowDialog()
    End Sub

    Private Sub ShowLogToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsLog.Click
        'If IO.File.Exists(strCurPath + "\eventlog.txt") Then
        'Dim myProcess As Process = System.Diagnostics.Process.Start(strCurPath & "\eventlog.txt")
        'End If
        If mnuToolsLog.Tag = 0 Then
            txtLogWindow.Visible = False
            lblBackupLog.Visible = False
            lvwPics.Height = 333
            mnuToolsLog.Tag = 1
        Else
            txtLogWindow.Visible = True
            lblBackupLog.Visible = True
            lvwPics.Height = 267
            mnuToolsLog.Tag = 0
        End If
    End Sub

    Private Sub mnuToolSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolSettings.Click
        Settings.ShowDialog()
    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        mnuToolSettings_Click(sender, e)
    End Sub
    Private Sub lvwPics_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwPics.KeyDown
        If e.KeyCode = Keys.Delete Then
            Call mnuTaskDelete_Click(sender, e)
        End If
    End Sub

    Private Sub lvwPics_ColumnWidthChanging(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles lvwPics.ColumnWidthChanging
        If Me.lvwPics.Columns(e.ColumnIndex).Width = 0 Then
            e.Cancel = True
            e.NewWidth = Me.lvwPics.Columns(e.ColumnIndex).Width
        End If
    End Sub

    Sub PlayBackgroundSoundResource(ByVal strEvent As String)
        If boolEnableSND = False Then Exit Sub
        If strEvent = "start" Then
            My.Computer.Audio.Play(My.Resources.Alarm, AudioPlayMode.Background)
        ElseIf strEvent = "end" Then
            My.Computer.Audio.Play(My.Resources.endsnd, AudioPlayMode.Background)
        End If
    End Sub

    Private Sub PCFirstStart()
        Try
            If lvwPics.Items.Count = 0 Then Exit Sub
            For i = 0 To lvwPics.Items.Count - 1
                If lvwPics.Items(i).SubItems(3).Text.Substring(0, 1) <> "M" Then Continue For ' currentstate is monitoring
                If lvwPics.Items(i).SubItems(4).Text.Substring(0, 1) = "C" Then ' Computer Starts
                    Call TriggerEvent(lvwPics.Items(i).Text, Convert.ToInt32(lvwPics.Items(i).SubItems(7).Text))
                End If
            Next
            'time checking ends here

        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")

            Call errHandlerForm(ex)
        End Try
    End Sub

    Private Sub mnuContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContent.Click
        'If IO.File.Exists(strCurPath & "\Readme.pdf") Then
        'System.Diagnostics.Process.Start(strCurPath + "\Readme.pdf")
        'Else
        'MsgBox("Readme file does not exist", MsgBoxStyle.OkOnly, "Error")
        'End If
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpNavigator.TableOfContents)

    End Sub

    Public Sub CopyDirectoryRecursive(ByVal sourcePath As String, ByVal destinationPath As String, ByVal OldBackupPath As String)
        Try
            Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)
            ' If the destination folder don't exist then create it
            If Not System.IO.Directory.Exists(destinationPath) Then
                System.IO.Directory.CreateDirectory(destinationPath)
            End If

            Dim fileSystemInfo As System.IO.FileSystemInfo
            For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
                'Dim destinationFileName As String = System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)
                Dim destinationFileName As String = System.IO.Path.Combine(OldBackupPath, fileSystemInfo.Name)
                Dim OldBackup As String = destinationFileName
                Dim ToCopyPath As String = System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)

                Dim DestFileInfo As New System.IO.FileInfo(destinationFileName)

                ' Now check whether its a file or a folder and take action accordingly
                If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                    If strBakupMode = "IB" Then 'change here
                        'If fileSystemInfo.FullName.Contains("SaleX1_10 - Copy.rep") Then
                        'MsgBox("Hi")
                        'End If
                        If fileSystemInfo.LastWriteTime > DestFileInfo.LastWriteTime Then
                            '   If fileSystemInfo.FullName.Contains("SaleX1_10 - Copy.rep") Then
                            'MsgBox("Hi")
                            'End If
                            If fileSystemInfo.LastWriteTime > dtpDirInfo.Value Or fileSystemInfo.CreationTime > dtpDirInfo.Value Then

                                '-----Include List Exclude List-------------'
                                If lbFilterE.Items.Count > 0 Then
                                    If boolFilterCompareExclude(fileSystemInfo.Name) = True Then Continue For
                                End If
                                If lbFilterI.Items.Count > 0 Then
                                    If boolFilterCompareInclude(fileSystemInfo.Name) = True Then Continue For
                                End If


                                FileStatusTextbox.Text = "Copying file " + fileSystemInfo.FullName
                                System.IO.File.Copy(fileSystemInfo.FullName, ToCopyPath, True)
                                'CpyFile(fileSystemInfo.FullName, ToCopyPath)
                                ChangedFileCount = ChangedFileCount + 1
                            End If

                        End If
                    Else
                        'If fileSystemInfo.FullName.Contains("Firm1001.mdb") Then
                        'MsgBox("Found")
                        'End If
                        If fileSystemInfo.LastWriteTime > DestFileInfo.LastAccessTime Then
                            '-----Include List Exclude List-------------'
                            If lbFilterE.Items.Count > 0 Then
                                If boolFilterCompareExclude(fileSystemInfo.Name) = True Then Continue For
                            End If
                            If lbFilterI.Items.Count > 0 Then
                                If boolFilterCompareInclude(fileSystemInfo.Name) = False Then Continue For
                            End If
                            FileStatusTextbox.Text = "Copying file " + fileSystemInfo.FullName
                            System.IO.File.Copy(fileSystemInfo.FullName, ToCopyPath, True)
                            ChangedFileCount = ChangedFileCount + 1
                        End If

                    End If
                    totalFileCount = totalFileCount + 1
                Else
                    ' Recursively call the mothod to copy all the neste folders
                    CopyDirectoryRecursive(fileSystemInfo.FullName, ToCopyPath, OldBackup)
                End If
            Next
        Catch ex As Exception
            Log.WriteException(ex, TraceEventType.Error)

        End Try
    End Sub

    Private Function GetFilesRecursive(ByVal initial As String) As List(Of String)
        ' This list stores the results.
        Dim result As New List(Of String)

        ' This stack stores the directories to process.
        Dim stack As New Stack(Of String)

        ' Add the initial directory
        stack.Push(initial)

        ' Continue processing for each stacked directory
        Do While (stack.Count > 0)
            ' Get top directory string
            Dim dir As String = stack.Pop
            Try
                ' Add all immediate file paths
                result.AddRange(IO.Directory.GetFiles(dir, "*.*"))

                ' Loop through all subdirectories and add them to the stack.
                Dim directoryName As String
                For Each directoryName In IO.Directory.GetDirectories(dir)
                    stack.Push(directoryName)
                Next

            Catch ex As Exception
            End Try
        Loop
        ' Return the list
        Return result
    End Function

    Private Sub CpyFile(ByVal strSource As String, ByVal strDestin As String)

        Dim sr As New IO.FileStream(strSource, IO.FileMode.Open) 'source file
        Dim sw As New IO.FileStream(strDestin, IO.FileMode.Create) ' destina
        Dim len As Long = sr.Length - 1
        Dim buffer(1024) As Byte
        Dim bytesread As Integer

        While sr.Position < len
            bytesread = (sr.Read(buffer, 0, 1024))
            sw.Write(buffer, 0, bytesread)
            ProgressBar3.Value = CInt(sr.Position / len * 100)
            Application.DoEvents()
        End While
        sw.Flush()
        sw.Close()
        sr.Close()

    End Sub

    Private Sub DeleteEmptyDirs(ByVal dir As String)
        If [String].IsNullOrEmpty(dir) Then
            Throw New ArgumentException("Starting directory is a null reference or an empty string", "dir")
        End If
        Try
            For Each d In IO.Directory.EnumerateDirectories(dir)
                DeleteEmptyDirs(d)
            Next

            Dim entries = IO.Directory.EnumerateFileSystemEntries(dir)

            If Not entries.Any() Then
                Try
                    IO.Directory.Delete(dir)
                Catch generatedExceptionName As UnauthorizedAccessException
                Catch generatedExceptionName As IO.DirectoryNotFoundException
                End Try
            End If
        Catch generatedExceptionName As UnauthorizedAccessException
        End Try
    End Sub

    Private Sub mnuHelpActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(New System.Uri("http://siraj.ueuo.com/mystuff/easybackup.php?cdcanyon=12345"))
        request.Method = System.Net.WebRequestMethods.Http.Get
        Dim response As System.Net.HttpWebResponse = request.GetResponse()
        Dim s As IO.StreamReader = New IO.StreamReader(response.GetResponseStream())
        Dim responseContent As String = s.ReadToEnd()
        MsgBox(responseContent)
        s.Close()
        s.Dispose()
        response.Close()

    End Sub


    Private Sub mnuSpanish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ChangeLanguage("DE")
    End Sub
    Private Sub ChangeLanguage(ByVal Language As String)
        Dim culture As CultureInfo
        culture = CultureInfo.CreateSpecificCulture(Language)
        Dim rm As New Resources.ResourceManager("EasyBackup.Resources", GetType(MainForm).Assembly)
        'main Heading
        lblHeading1.Text = rm.GetString("lblHeading1", culture)
        lblHeading2.Text = rm.GetString("lblHeading2", culture)
        'Main Menus
        mnuTask.Text = rm.GetString("mnuTask", culture)
        mnuTools.Text = rm.GetString("mnuTools", culture)
        mnuHelp.Text = rm.GetString("mnuHelp", culture)
        mnuTaskNew.Text = rm.GetString("mnuTaskNew", culture)
        mnuTaskEdit.Text = rm.GetString("mnuTaskEdit", culture)
        mnuTaskDelete.Text = rm.GetString("mnuTaskDelete", culture)
        mnuTaskRun.Text = rm.GetString("mnuTaskRun", culture)
        mnuTaskPause.Text = rm.GetString("mnuTaskPause", culture)
        mnuExit.Text = rm.GetString("mnuTaskExit", culture)

        mnuToolsRestore.Text = rm.GetString("mnuToolsRestore", culture)
        mnuToolsWarnings.Text = rm.GetString("mnuToolsSettings", culture)

        'mnuLang.Text = rm.GetString("mnuLang", culture)
        'mnuChinese.Text = rm.GetString("mnuChinese", culture)
        'mnuDutch.Text = rm.GetString("mnuDutch", culture)
        'mnuEnglish.Text = rm.GetString("mnuEnglish", culture)
        'mnuFrench.Text = rm.GetString("mnuFrench", culture)
        'mnuGerman.Text = rm.GetString("mnuGerman", culture)
        'mnuItalian.Text = rm.GetString("mnuItalian", culture)
        'mnuJapanese.Text = rm.GetString("mnuJapanese", culture)
        'mnuKorean.Text = rm.GetString("mnuKorean", culture)
        'mnuPolish.Text = rm.GetString("mnuPolish", culture)
        'mnuRussian.Text = rm.GetString("mnuRussian", culture)
        'mnuSpanish.Text = rm.GetString("mnuSpanish", culture)
        'mnuToolsLog.Text = rm.GetString("mnuToolsLog", culture)
        mnuToolSettings.Text = rm.GetString("mnuToolsSettings", culture)

        mnuContent.Text = rm.GetString("mnuHelpContents", culture)
        mnuUpdate.Text = rm.GetString("mnuHelpUpdate", culture)
        mnuAbout.Text = rm.GetString("mnuHelpAbout", culture)

        'Toolbards
        btnNew.Text = rm.GetString("tNew", culture)
        btnEdit.Text = rm.GetString("tEdit", culture)
        btnDelete.Text = rm.GetString("tDelete", culture)

        btnRun.Text = rm.GetString("tRun", culture)
        btnPause.Text = rm.GetString("tPause", culture)
        btnFailed.Text = rm.GetString("tWarning", culture)

        btnRestore.Text = rm.GetString("tRestore", culture)
        btnSettings.Text = rm.GetString("tSettings", culture)
        btnAbout.Text = rm.GetString("tAbout", culture)
        btnExit.Text = rm.GetString("tExit", culture)

        lvwPics.Columns(1).Text = rm.GetString("lvName", culture)
        lvwPics.Columns(2).Text = rm.GetString("lvSource", culture)
        lvwPics.Columns(3).Text = rm.GetString("lvStatus", culture)
        lvwPics.Columns(4).Text = rm.GetString("lvFreq", culture)
        lvwPics.Columns(5).Text = rm.GetString("lvWhen", culture)

        'Status Bar
        tsTotalTask.Text = rm.GetString("sbTotalTask", culture)
        tsTotalTask.Tag = rm.GetString("sbTotalTask", culture)
        tsDate.Text = rm.GetString("sbDate", culture)
        TSlblTime.Text = rm.GetString("sbTime", culture)
    End Sub

    Private Sub mnuUpdate_Click(sender As Object, e As EventArgs) Handles mnuUpdate.Click
        MsgBox("Sorry! no update available at the moment", MsgBoxStyle.Information, "Update")
    End Sub

    Private Sub cMnuSettings_Click(sender As Object, e As EventArgs) Handles cMnuSettings.Click
        Call mnuToolSettings_Click(sender, e)
    End Sub

    Private Sub cMnuAbout_Click(sender As Object, e As EventArgs) Handles cMnuAbout.Click
        Call mnuAbout_Click(sender, e)
    End Sub

    Private Sub StopCopy_Click(sender As Object, e As EventArgs) Handles StopCopy.Click

    End Sub

    Private Sub stopFTP_Click(sender As Object, e As EventArgs) Handles stopFTP.Click
        myFtpUploadWebClient.CancelAsync()
        paFTP.Visible = False
        PBFTP.Value = 0
        WriteToEventsLog(lblStrCode.Text, "FTP Upload cancelled")
    End Sub
    Private Sub FillLVNew()
        Try
            Dim strTmp As String = ""
            Dim strCode As String = ""
            'Dim ini As New IniFile(strFLNM)
            Dim strTimeVar As String = ""


            'strCode = (System.IO.Path.GetFileNameWithoutExtension(strFLNM))

            'BackupData.Instance.ReadTMSettings()
            For i = 0 To BackupData.Instance.BackupTable.Rows.Count - 1
                strCode = i + 1
                'strCode = strCode.Replace("FLSet", "")

                strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("EC").ToString
                If strTmp.Length <> 0 Then
                    'If strTmp = "1" Then Exit Sub
                End If

                strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("TName").ToString
                If strTmp.Length = 0 Then Exit Sub
                strCode = BackupData.Instance.BackupTable.Rows.Item(i).Item("TID").ToString

                Dim LVWitem As ListViewItem = lvwPics.Items.Add(strCode)
                LVWitem.SubItems.Add(strTmp)
                strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("DSize").ToString
                strTmp = SizeToMBStr(CDbl(strTmp))
                LVWitem.SubItems.Add(strTmp)

                strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("TStatus").ToString

                If strTmp <> String.Empty Then
                    If BackupData.Instance.BackupTable.Rows.Item(i).Item("TStatus").ToString = True Then
                        LVWitem.SubItems.Add("Monitoring")
                        intActiveTask = intActiveTask + 1
                    Else
                        LVWitem.SubItems.Add("Paused")
                    End If
                Else
                    LVWitem.SubItems.Add("Monitoring")
                    intActiveTask = intActiveTask + 1
                End If

                Dim strDailyWeeklyDays As String = ""

                strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("TType").ToString

                If strTmp <> String.Empty Then
                    If strTmp = "D" Then
                        LVWitem.SubItems.Add("Daily")
                        strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("TAtEach").ToString
                        If strTmp <> String.Empty Then
                            strDailyWeeklyDays = strTmp
                        End If

                    End If
                    If strTmp = "W" Then
                        LVWitem.SubItems.Add("Weekly")
                        strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("WeekDays").ToString
                        If strTmp <> String.Empty Then
                            strDailyWeeklyDays = strTmp
                        End If
                    End If
                    If strTmp = "C" Then
                        LVWitem.SubItems.Add("Computer Starts")
                        strDailyWeeklyDays = "-"
                    End If
                    If strTmp = "O" Then
                        LVWitem.SubItems.Add("One time only")
                        strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("TDate").ToString
                        If strTmp <> String.Empty Then
                            strDailyWeeklyDays = strTmp
                        End If
                    End If
                    If strTmp = "M" Then
                        LVWitem.SubItems.Add("Manually Start")
                        strDailyWeeklyDays = "-"
                    End If
                End If

                strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("T0").ToString
                If strTmp <> String.Empty Then
                    Dim newDate As DateTime = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)
                    strTmp = newDate.ToString("hh:mm tt")
                    LVWitem.SubItems.Add(strTmp).Tag = "-R" '-Regular
                Else
                    strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("TElement").ToString
                    If strTmp <> String.Empty Then ' CUstom time At every done. not the different time.
                        Dim strHourMinute As String = BackupData.Instance.BackupTable.Rows.Item(i).Item("TEvery").ToString
                        dtpLastRun.Value = Now
                        If strTmp = "M" Then
                            strTmp = "Every " + strHourMinute + " Minutes"
                            LVWitem.SubItems.Add(strTmp).Tag = strHourMinute + "-M"

                            dtpLastRun.Value = dtpLastRun.Value.AddMinutes(strHourMinute)
                        ElseIf strTmp = "H" Then
                            strTmp = "Every " + strHourMinute + " Hours"
                            LVWitem.SubItems.Add(strTmp).Tag = strHourMinute + "-H"
                            dtpLastRun.Value = dtpLastRun.Value.AddHours(strHourMinute)
                        End If
                    Else
                        strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("T1").ToString
                        If strTmp <> String.Empty Then
                            Dim newDate As DateTime = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)
                            strTmp = newDate.ToString("hh:mm tt")
                            strTimeVar = strTmp
                        End If

                        strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("T2").ToString
                        If strTmp <> String.Empty Then
                            Dim newDate As DateTime = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)
                            strTmp = newDate.ToString("hh:mm tt")
                            If strTimeVar.Length <> 0 Then
                                strTimeVar = strTimeVar + " , " + strTmp
                            Else
                                strTimeVar = strTmp
                            End If
                        End If

                        strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("T3").ToString
                        If strTmp <> String.Empty Then
                            Dim newDate As DateTime = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)
                            strTmp = newDate.ToString("hh:mm tt")

                            If strTimeVar.Length <> 0 Then
                                strTimeVar = strTimeVar + " , " + strTmp
                            Else
                                strTimeVar = strTmp
                            End If
                        End If

                        strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("T4").ToString
                        If strTmp <> String.Empty Then
                            Dim newDate As DateTime = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)
                            strTmp = newDate.ToString("hh:mm tt")

                            If strTimeVar.Length <> 0 Then
                                strTimeVar = strTimeVar + " , " + strTmp
                            Else
                                strTimeVar = strTmp
                            End If
                        End If
                        If strTimeVar <> String.Empty Then LVWitem.SubItems.Add(strTimeVar) Else LVWitem.SubItems.Add("-")
                    End If
                End If
                LVWitem.SubItems.Add(strDailyWeeklyDays)

                strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("Zip").ToString

                If strTmp <> String.Empty Then
                    If strTmp = True Then
                        LVWitem.SubItems.Add(True)
                    Else
                        LVWitem.SubItems.Add(False)
                    End If
                Else
                    LVWitem.SubItems.Add(True)
                End If

                strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("Other").ToString

                If strTmp <> String.Empty Then
                    If strTmp = "FTP" Then
                        LVWitem.SubItems.Add("F")
                    ElseIf strTmp = "WebDAV" Then
                        LVWitem.SubItems.Add("W")
                    Else
                        LVWitem.SubItems.Add("0")
                    End If
                Else
                    LVWitem.SubItems.Add("0")
                End If

                strTmp = BackupData.Instance.BackupTable.Rows.Item(i).Item("BMode").ToString
                If strTmp <> String.Empty Then
                    LVWitem.SubItems.Add(strTmp)
                Else
                    LVWitem.SubItems.Add("DB")
                End If
            Next
        Catch ex As Exception
            Call errHandlerForm(ex)
        End Try
    End Sub
End Class
Public Class WorkerOptions

    ' Fields
    'Public Comment As String
    'Public CompressionLevel As CompressionLevel
    'Public Encoding As String
    '    Public Encryption As EncryptionAlgorithm
    'Public Password As String
    'Public Zip64 As Zip64Option
    'Public ZipFlavor As Integer
    Public Folder() As String
    Public Files() As String
    Public ZipName As String
    Public oldZip As String
    Public DoEnc As Boolean
    Public EncMethod As String
    Public EncPass As String
    Public isFTPDo As Boolean
    Public isWebDavDo As Boolean
    Public ftpServer As String
    Public ftpServerPort As String
    Public ftpUser As String
    Public ftpPass As String
    Public ftpFileName As String
End Class

