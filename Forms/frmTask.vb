Imports System.Data
Public Class frmTask
    Dim TimeAlwaysAt, TimeEachInterval, TimeLastBackup As DateTime
    Dim AutoSave As Boolean = False
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Object, ByVal lpString As String, ByVal lpFileName As String)
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String)
    Private Shared fLog As New FileLog(My.Application.Info.Title, strCurPath + "\Logs\")
    Public Shared ReadOnly Property Log() As FileLog
        Get
            Return fLog
        End Get
    End Property

    Private Sub frmTask_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtBackupName.Focus()
    End Sub
    Private Sub frmTask_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub frmTask_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabControl1.SuspendLayout()
        If lblCode.Text <> "0" Then
            ReadDataNew()
        Else
            cboBackupType.SelectedIndex = 0
            cboStatus.SelectedIndex = 0
            cboZipEncryption.SelectedIndex = 0
        End If
        TabControl1.SuspendLayout()
    End Sub
    Private Sub BrowseFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseFrom.Click
        Try
            If FolderBrowserDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
            'FromPathTextbox.Text = FolderBrowserDialog1.SelectedPath
            ' If HaveWritePermission(FolderBrowserDialog1.SelectedPath) = False Then Exit Sub

            Dim LiTmp As ListViewItem = lvwPics.Items.Add(FolderBrowserDialog1.SelectedPath)
            Dim dInfo As New System.IO.DirectoryInfo(FolderBrowserDialog1.SelectedPath)
            Dim sizeOfDir As Long = DirectorySize(dInfo, True)
            txtTotalSize.Text = CDbl(txtTotalSize.Text) + sizeOfDir
            LiTmp.SubItems.Add(SizeToMBStr(sizeOfDir))
            LiTmp.SubItems.Add(sizeOfDir)
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub

    Private Sub nfy_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        Me.Focus()
    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub lvwPics_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwPics.DragDrop
        Try
            'GET AN ARRAY OF THE FILES SELECTED THAT ARE BEING DRAGGED IN
            Dim Files As Array
            Dim LVI As ListViewItem

            Files = CType(e.Data.GetData(DataFormats.FileDrop), Array)
            'LOOP THE ARRAY, ADDING THE IMAGE FILES
            For i As Integer = 0 To Files.Length - 1

                If System.IO.File.Exists(Files.GetValue(i).ToString) Then
                    LVI = New ListViewItem(Files.GetValue(i).ToString)
                    Dim info2 As New System.IO.FileInfo(Files.GetValue(i).ToString)
                    Dim length2 As Long = info2.Length
                    txtTotalSize.Text = CDbl(txtTotalSize.Text) + length2
                    LVI.SubItems.Add(SizeToMBStr(length2))
                    LVI.SubItems.Add(length2)
                    lvwPics.Items.Add(LVI)
                ElseIf System.IO.Directory.Exists(Files.GetValue(i).ToString) Then
                    LVI = New ListViewItem(Files.GetValue(i).ToString)

                    Dim dInfo As New System.IO.DirectoryInfo(Files.GetValue(i).ToString)
                    Dim sizeOfDir As Long = DirectorySize(dInfo, True)
                    txtTotalSize.Text = CDbl(txtTotalSize.Text) + sizeOfDir

                    LVI.SubItems.Add(SizeToMBStr(sizeOfDir))
                    LVI.SubItems.Add(sizeOfDir)
                    lvwPics.Items.Add(LVI)
                End If
            Next

        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub

    Private Sub lvwPics_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwPics.DragEnter
        'WHEN EXTERNAL FILE IS DRAGGED OVER THE LISTVIEW, 
        'CHANGE THE MOUSE CURSOR TO SHOW ITS A DROP TARGET
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub txtTotalSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalSize.TextChanged
        lblTotalSize.Text = "Total Size: " + SizeToMBStr(CDbl(txtTotalSize.Text))
    End Sub
    Private Sub btnAddFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFiles.Click
        OpenFileDialog1.DefaultExt = "*.*"
        OpenFileDialog1.Title = "Select file(s) for backup"
        OpenFileDialog1.Filter = "All Files (*.*)|*.*"
        OpenFileDialog1.FileName = "*.*"

        Dim LVI As ListViewItem

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            For Each File As String In OpenFileDialog1.FileNames
                'lvwPics.Items.Add(File)
                LVI = New ListViewItem(File.ToString)
                Dim info2 As New System.IO.FileInfo(File.ToString)
                Dim length2 As Long = info2.Length
                txtTotalSize.Text = CDbl(txtTotalSize.Text) + length2
                LVI.SubItems.Add(SizeToMBStr(length2))
                LVI.SubItems.Add(length2)
                lvwPics.Items.Add(LVI)
            Next
        End If
    End Sub

    Private Sub btnExclude_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExclude.Click
        For Each i As ListViewItem In lvwPics.SelectedItems
            txtTotalSize.Text = CDbl(txtTotalSize.Text) - CDbl(i.SubItems(2).Text)
            lvwPics.Items.Remove(i)
        Next
    End Sub

    Private Function ValidateSave() As Boolean
        Try
            ErrTask.Clear()
            If txtBackupName.Text.Length = 0 Then
                'MsgBox("Please enter the name for the backup!", MsgBoxStyle.Information, "Information")
                ErrTask.SetError(txtBackupName, "Please enter the name for the backup!")
                TabControl1.SelectedTab = TabPage1
                txtBackupName.Focus()
                Return False
            End If

            If txtBackupName.Text.Contains("%") Or txtBackupName.Text.Contains("/") Or txtBackupName.Text.Contains("\") Then
                'MsgBox("Backup name can't contain special characters. it will be used as backup file name.", MsgBoxStyle.Information, "Information")
                ErrTask.SetError(txtBackupName, "Backup name can't contain special characters")
                txtBackupName.Focus()
                Return False
            End If

            If cboBackupType.Text = "Daily" Then
                If dtpAlwaysTime.Checked = False Then
                    If rbAtEvery.Checked = True Then
                        If txtAtEvery.Text.Length = 0 Then
                            MsgBox("Please select the time of Daily Backup!", MsgBoxStyle.Information, "Information")
                            Return False
                        End If
                    ElseIf rbCustomTime.Checked = True Then
                        If dtpC1.Checked = False And dtpC2.Checked = False And dtpC3.Checked = False And dtpC4.Checked = False Then
                            MsgBox("Please select the time of Daily Backup!", MsgBoxStyle.Information, "Information")
                            Return False
                        End If
                    End If
                    'MsgBox("Please select the time of Daily Backup!", MsgBoxStyle.Information, "Information")
                    'If chkCustomTime.Checked = False Then dtpAlwaysTime.Focus() Else dtpC1.Focus()
                    ' Return False
                End If
            ElseIf cboBackupType.Text = "Weekly" Then
                If chkMon.Checked = False And chkTue.Checked = False And chkWen.Checked = False And chkThu.Checked = False And chkFri.Checked = False And chkSat.Checked = False And chkSun.Checked = False Then
                    MsgBox("Please select at-least single day for Weekly Backup!", MsgBoxStyle.Information, "Information")
                    chkMon.Focus()
                    Return False
                End If
                If dtpAlwaysTime.Checked = False And dtpC1.Checked = False And dtpC2.Checked = False And dtpC3.Checked = False And dtpC4.Checked = False Then
                    MsgBox("Please select the time of Weekly Backup!", MsgBoxStyle.Information, "Information")
                    If chkCustomTime.Checked = False Then dtpAlwaysTime.Focus() Else dtpC1.Focus()
                    Return False
                End If
            ElseIf cboBackupType.Text = "One time only" Then
                If dtpAlwaysTime.Checked = False And dtpC1.Checked = False And dtpC2.Checked = False And dtpC3.Checked = False And dtpC4.Checked = False Then
                    MsgBox("Please select the time of One Time Backup!", MsgBoxStyle.Information, "Information")
                    If chkCustomTime.Checked = False Then dtpAlwaysTime.Focus() Else dtpC1.Focus()
                    Return False
                End If
                If dtpBDate.Value < Date.Today Then
                    MsgBox("Please select date greater than or equal to today's date for one time Backup!", MsgBoxStyle.Information, "Information")
                    Return False
                End If

            End If

            If lvwPics.Items.Count = 0 Then
                MsgBox("Please select data for backup!", MsgBoxStyle.Information, "Information")
                TabControl1.SelectedTab = TabPage2
                Return False
            End If


            If rbDestLocal.Checked = True And lbLocal.Items.Count = 0 Then
                MsgBox("Please specify destination folder for storing backup!", MsgBoxStyle.Information, "Information")
                TabControl1.SelectedTab = TabPage4
                Return False
            End If

            If rbDestLocal.Checked = False And rbDestFTP.Checked = False And rbDestWEBDAV.Checked = False Then
                MsgBox("You must select destination for the backup!", MsgBoxStyle.Information, "Information")
                TabControl1.SelectedTab = TabPage4
                Return False
            End If

            If txtTotalSize.Text = "0" Then
                MsgBox("Backup size can't be Zero size!", MsgBoxStyle.Information, "Information")
                TabControl1.SelectedTab = TabPage2
                Return False
            End If

            If rbFullBackup.Checked = True Then
                If CDbl(txtTotalSize.Text) > 104857600 Then
                    If MsgBox("Backup size is more than 100 MB,  sometimes system may be unstable during backup, are you sure to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Warning") = MsgBoxResult.No Then
                        TabControl1.SelectedTab = TabPage2
                        Return False
                    End If
                End If
            End If

            If rbDestFTP.Checked = True And txtFTPServerName.Text.Length = 0 Then
                'MsgBox("Please add settings for FTP Backup!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                ErrTask.SetError(txtFTPServerName, "Please add settings for FTP Backup!")
                TabControl1.SelectedTab = TabPage4
                gbDFTP.Visible = True
                txtFTPServerName.Focus()
                Return False
            End If

            If rbDestWEBDAV.Checked = True And txtWebDAVServer.Text.Length = 0 Then
                'MsgBox("Please add settings for FTP Backup!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                ErrTask.SetError(txtWebDAVServer, "Please add settings for WebDAV Backup!")
                TabControl1.SelectedTab = TabPage4
                gbWEBDAV.Visible = True
                txtWebDAVServer.Focus()
                Return False
            End If

            If rbNoZip.Checked = True And rbDestFTP.Checked = True Then
                MsgBox("For backup location as FTP server data should have in ZIP format, Can't backup directoy directly!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                TabControl1.SelectedTab = TabPage4
                rbNoZip.Focus()
                Return False
            End If

            If rbZip.Checked = True And cboZipEncryption.SelectedIndex <> 0 Then 'zip password matching
                If txtZipPass.Text.Length < 6 Or txtZipPass.Text.Length > 30 Then
                    'MsgBox("Zip encryption password length must be 6 to 30 character long!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                    ErrTask.SetError(txtZipPass, "Zip encryption password length must be 6 to 30 character long!")
                    '   TabControl1.SelectedTab = TabPage4
                    txtZipPass.Focus()
                    Return False
                End If

                If txtZipPass.Text.Length <> 0 Then
                    If txtZipPass.Text <> txtZipPassConfirm.Text Then
                        'MsgBox("Encryption password doesn't match!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                        ErrTask.SetError(txtZipPass, "Encryption password doesn't match!")
                        '   TabControl1.SelectedTab = TabPage4
                        txtZipPass.Focus()
                        Return False
                    End If
                End If
            End If
            If lblCode.Text <> "0" Then
                If txtZipPass.Tag <> txtZipPass.Text Then
                    If MsgBox("You have changed the encryption password, Restoration will fail of all previous backup, Are you sure you want to change password", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Question") = MsgBoxResult.No Then
                        Return False
                    End If
                End If
            End If


            If rbZip.Checked = True Then 'Other than None password should be entered
                If cboZipEncryption.SelectedIndex <> 0 And txtZipPass.Text.Length = 0 Then
                    'MsgBox("Please provide a password for selected encryption method!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                    ErrTask.SetError(txtZipPass, "Please provide a password for selected encryption method!")
                    'TabControl1.SelectedTab = TabPage4
                    txtZipPass.Focus()
                    Return False
                End If
            End If



            Return True
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            '            MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
            Return False
        End Try
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim i As Integer = 0
            'Dim lvi As ListViewItem
            Dim strTmp As String = ""
            Dim strDays As String = ""

            If ValidateSave() = False Then
                Me.DialogResult = DialogResult.None
                Exit Sub
            End If
            TestingSave()
            'If AutoSave <> True Then
            'MsgBox("Saved successfully", MsgBoxStyle.Information, "Save")
            'End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub

    Private Sub rbDaily_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If rbDaily.Checked = True Then
        chkMon.Checked = False
        chkTue.Checked = False
        chkWen.Checked = False
        chkThu.Checked = False
        chkFri.Checked = False
        chkSat.Checked = False
        chkSun.Checked = False
        'End If
    End Sub

    Private Sub CMnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cboBackupType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBackupType.SelectedIndexChanged
        Try
            gbSelectedDays.Enabled = False
            gbDaily.Enabled = False
            gbWhenDT.Enabled = False

            If cboBackupType.Text = "Daily" Then
                gbDaily.Enabled = True
                rbDEveryDay.Checked = True
                gbWhenDT.Enabled = True
                dtpBDate.Enabled = False

            ElseIf cboBackupType.Text = "Weekly" Then
                gbSelectedDays.Enabled = True
                gbWhenDT.Enabled = True
                dtpBDate.Enabled = False
            ElseIf cboBackupType.Text = "One time only" Then
                gbWhenDT.Enabled = True
                dtpBDate.Enabled = True
            ElseIf cboBackupType.Text = "Computer starts" Then
                dtpBDate.Enabled = False
            End If
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try

    End Sub

    Private Sub chkCustomTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustomTime.CheckedChanged
        If chkCustomTime.Checked = True Then
            If cboBackupType.Text <> "One time only" Then
                dtpAlwaysTime.Checked = False
                gbCustom.Enabled = True
                rbCustomTime.Checked = True
            Else
                MsgBox("Customize time option not available in 'One time only' backup type", MsgBoxStyle.Information, "Information")
                chkCustomTime.Checked = False
            End If
        Else
            dtpAlwaysTime.Checked = True
            gbCustom.Enabled = False
        End If
    End Sub


    'Private Sub chkDLocal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDLocal.CheckedChanged
    '   If chkDLocal.Checked = True Then
    '      lbLocal.Enabled = True
    '     btnDFolder.Enabled = True
    '    btnDRemove.Enabled = True
    '   btnLocal.Enabled = True
    'Else
    '   lbLocal.Enabled = False
    '  btnDFolder.Enabled = False
    ' btnDRemove.Enabled = False
    'btnLocal.Enabled = False
    'End If
    'End Sub

    Private Sub btnDFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDFolder.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        If HaveWritePermission(FolderBrowserDialog1.SelectedPath) = False Then Exit Sub
        Dim i As Integer = 0
        For i = 0 To lbLocal.Items.Count - 1
            If lbLocal.Items.Item(i).ToString = FolderBrowserDialog1.SelectedPath Then Exit Sub
        Next
        lbLocal.Items.Add(FolderBrowserDialog1.SelectedPath)
    End Sub

    Private Sub btnDRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDRemove.Click
        If lbLocal.SelectedItems.Count = 0 Then Exit Sub
        lbLocal.Items.Remove(lbLocal.SelectedItem)
    End Sub

    'Private Sub chkDFTP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDFTP.CheckedChanged
    '   If chkDFTP.Checked = True Then
    '      btnFTP.Enabled = True
    ' Else
    '    btnFTP.Enabled = False
    'End If
    'End Sub

    Private Sub btnFTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'paFTP.Left = btnFTP.Left
        'paFTP.Top = rbFTP.Top

        gbDFTP.BringToFront()
        gbDFTP.Visible = True


        txtFTPServerName.Focus()
    End Sub

    Private Sub btnFTPOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    'Private Sub chkDFTP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDFTP.CheckedChanged
    '   If rbNoZip.Checked = True Then
    '      If chkDFTP.Checked = True Then
    '         MsgBox("FTP backup only possible for zip file", MsgBoxStyle.Information, "Information")
    '        chkDFTP.Checked = False
    '       chkDLocal.Checked = True
    '  End If

    '    ElseIf chkDFTP.Checked = True Then
    '       btnFTP.Enabled = True
    '  ElseIf chkDFTP.Checked = False Then
    '     btnFTP.Enabled = False
    '        End If

    'End Sub

    Private Sub rbNoZip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoZip.CheckedChanged
        If rbNoZip.Checked = False Then Exit Sub

        If rbDestFTP.Checked = True Then
            MsgBox("FTP backup only possible for zip file", MsgBoxStyle.Information, "Information")
            rbNoZip.Checked = False
            rbZip.Checked = True
        End If
    End Sub

    Private Sub lvwPics_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwPics.KeyDown
        If e.KeyCode = Keys.Delete Then
            Call btnExclude_Click(sender, e)
        End If
    End Sub

    Private Sub lbLocal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbLocal.KeyDown
        If e.KeyCode = Keys.Delete Then
            Call btnDFolder_Click(sender, e)
        End If
    End Sub

    Private Sub lvwPics_ColumnWidthChanging(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles lvwPics.ColumnWidthChanging
        If Me.lvwPics.Columns(e.ColumnIndex).Width = 0 Then
            e.Cancel = True
            e.NewWidth = Me.lvwPics.Columns(e.ColumnIndex).Width
        End If
    End Sub
    Private Function HaveWritePermission(ByVal strPath As String) As Boolean
        'Dim boolTest As Boolean = False
        'Dim info As New IO.DirectoryInfo(strPath)
        'boolTest = IO.FileAttributes.ReadOnly
        'If boolTest = False Then MsgBox(strPath + " is not accessible or you may not have write permission, please select different path", MsgBoxStyle.Information, "Information")
        'Return (boolTest)
        'Return (info.Attributes And IO.FileAttributes.ReadOnly) <> IO.FileAttributes.ReadOnly
        HaveWritePermission = True


        Try
            Dim fs As IO.FileStream = IO.File.Create(strPath & "\log.txt")
            fs.Close()
        Catch ex As Exception
            HaveWritePermission = False
            MsgBox(strPath + " is not accessible or you may not have write permission, please select different path", MsgBoxStyle.Information, "Information")
        Finally
            If IO.File.Exists(strPath & "\log.txt") And HaveWritePermission Then IO.File.Delete(strPath & "\log.txt")
        End Try
    End Function
    Private Sub btnLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gbDLocal.BringToFront()
        gbDLocal.Visible = True
    End Sub
    Private Function validateURL(ByVal textval) As Boolean
        Dim urlregex As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^(ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|club|museum|[a-zA-Z]{2}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&amp;%\$#\=~_\-]+))*$")
        'Return urlregex.test(textval)
        Return urlregex.IsMatch(textval)
    End Function
    Private Function validateWebDAVURL(ByVal textval) As Boolean
        Dim urlregex As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^(http)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|club|museum|[a-zA-Z]{2}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&amp;%\$#\=~_\-]+))*$")
        'Return urlregex.test(textval)
        Return urlregex.IsMatch(textval)
    End Function

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try

            Select Case TabControl1.SelectedIndex
                Case 0
                    ErrTask.Clear()
                    'validate backup name
                    If txtBackupName.Text.Length = 0 Then
                        'MsgBox("Please enter the name for the backup!", MsgBoxStyle.Information, "Information")
                        ErrTask.SetError(txtBackupName, "Please enter the name for the backup")
                        txtBackupName.Focus()
                        Exit Sub
                    End If

                    If txtBackupName.Text.Contains("%") Or txtBackupName.Text.Contains("/") Or txtBackupName.Text.Contains("\") Then
                        'MsgBox("Backup name can't contain special characters. it will be used as backup file name.", MsgBoxStyle.Information, "Information")
                        ErrTask.SetError(txtBackupName, "Backup name can't contain special characters")
                        txtBackupName.Focus()
                        Exit Sub
                    End If
                    'ends here
                    'time 
                    If cboBackupType.Text = "Daily" Then
                        If dtpAlwaysTime.Checked = False Then
                            If rbAtEvery.Checked = True Then
                                If cmbAtEvery.Text = "" Then
                                    MsgBox("Please select the time frequency for Daily Backup!", MsgBoxStyle.Information, "Information")
                                    Exit Sub
                                End If
                                If txtAtEvery.Text.Length = 0 Then
                                    MsgBox("Please select the time of Daily Backup!", MsgBoxStyle.Information, "Information")
                                    Exit Sub
                                End If
                            ElseIf rbCustomTime.Checked = True Then
                                If dtpC1.Checked = False And dtpC2.Checked = False And dtpC3.Checked = False And dtpC4.Checked = False Then
                                    MsgBox("Please select the time of Daily Backup!", MsgBoxStyle.Information, "Information")
                                    Exit Sub
                                End If
                            End If
                            ' MsgBox("Please select the time of Daily Backup!", MsgBoxStyle.Information, "Information")
                            ' If chkCustomTime.Checked = False Then dtpAlwaysTime.Focus() Else dtpC1.Focus()
                            '  Exit Sub
                        End If
                    ElseIf cboBackupType.Text = "Weekly" Then
                        If chkMon.Checked = False And chkTue.Checked = False And chkWen.Checked = False And chkThu.Checked = False And chkFri.Checked = False And chkSat.Checked = False And chkSun.Checked = False Then
                            MsgBox("Please select at-least single day for Weekly Backup!", MsgBoxStyle.Information, "Information")
                            chkMon.Focus()
                            Exit Sub
                        End If
                        If dtpAlwaysTime.Checked = False And dtpC1.Checked = False And dtpC2.Checked = False And dtpC3.Checked = False And dtpC4.Checked = False Then
                            MsgBox("Please select the time of Weekly Backup!", MsgBoxStyle.Information, "Information")
                            If chkCustomTime.Checked = False Then dtpAlwaysTime.Focus() Else dtpC1.Focus()
                            Exit Sub
                        End If
                    ElseIf cboBackupType.Text = "One time only" Then
                        If dtpAlwaysTime.Checked = False And dtpC1.Checked = False And dtpC2.Checked = False And dtpC3.Checked = False And dtpC4.Checked = False Then
                            MsgBox("Please select the time of One Time Backup!", MsgBoxStyle.Information, "Information")
                            If chkCustomTime.Checked = False Then dtpAlwaysTime.Focus() Else dtpC1.Focus()
                            Exit Sub
                        End If
                        If dtpBDate.Value < Date.Today Then
                            MsgBox("Please select date greater than or equal to today's date for one time Backup!", MsgBoxStyle.Information, "Information")
                            Exit Sub
                        End If

                    End If
                    'time ends


                    'lblHeading.Text = "Backup Task Wizard"
                    'lblHeadingDesc.Text = "Schedule the task, select frequency and time"
                    btnBack.Enabled = True
                    lblHeading.Text = "Select Backup Data Source"
                    lblHeadingDesc.Text = "Select source files and folders for backup"
                    TabControl1.SelectedIndex = 1
                Case 1
                    If lvwPics.Items.Count = 0 Then
                        MsgBox("Please select data for backup!", MsgBoxStyle.Information, "Information")
                        'TabControl1.SelectedTab = TabPage2
                        Exit Sub
                    End If

                    If txtTotalSize.Text = "0" Then
                        MsgBox("Backup size can't be Zero!", MsgBoxStyle.Information, "Information")
                        'TabControl1.SelectedTab = TabPage2
                        Exit Sub
                    End If

                    lblHeading.Text = "Select Destination"
                    lblHeadingDesc.Text = "Set where you want to put backup"

                    TabControl1.SelectedIndex = 2
                Case 2

                    If rbDestLocal.Checked = True And lbLocal.Items.Count = 0 Then
                        MsgBox("Please specify destination folder for storing backup!", MsgBoxStyle.Information, "Information")
                        'TabControl1.SelectedTab = TabPage4
                        Exit Sub
                    End If

                    If rbDestLocal.Checked = False And rbDestFTP.Checked = False And rbDestWEBDAV.Checked = False Then
                        MsgBox("You must select destination for the backup!", MsgBoxStyle.Information, "Information")
                        'TabControl1.SelectedTab = TabPage4
                        Exit Sub
                    End If

                    If rbDestFTP.Checked = True Then
                        ErrTask.Clear()
                        If txtFTPServerName.Text.Length = 0 Then
                            'MsgBox("Please enter valid FTP server address", MsgBoxStyle.Information, "Information")
                            ErrTask.SetError(txtFTPServerName, "Please enter valid FTP server address")
                            txtFTPServerName.Focus()
                            Exit Sub
                        End If
                        'If txtFTPServerName.Text.Contains(".") = False Or txtFTPServerName.Text.ToLower.Substring(0, 3) <> "ftp" Then
                        If validateURL(txtFTPServerName.Text) = False Then
                            'MsgBox("Please provide valid FTP server address", MsgBoxStyle.Information, "Information")
                            ErrTask.SetError(txtFTPServerName, "Please provide valid FTP server address")
                            txtFTPServerName.Focus()
                            Exit Sub
                        End If
                        If txtFTPU.Text.Length = 0 Or txtFTPP.Text.Length = 0 Then
                            'MsgBox("Please enter valid FTP username and password", MsgBoxStyle.Information, "Information")
                            ErrTask.SetError(txtFTPU, "Please enter valid FTP username and password")
                            txtFTPU.Focus()
                            Exit Sub
                        End If
                    End If

                    lblHeading.Text = "Backup Task Options"
                    lblHeadingDesc.Text = "Set backup option"
                    btnNext.Text = "Finish"
                    TabControl1.SelectedIndex = 3
                Case 3

                    If rbFullBackup.Checked = True Then
                        If CDbl(txtTotalSize.Text) > 104857600 Then
                            If MsgBox("Backup size is more than 100 MB,  sometimes system may be unresponsive during backup, are you sure to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Information") = MsgBoxResult.No Then
                                '      TabControl1.SelectedTab = TabPage2
                                Exit Sub
                            End If
                        End If
                    End If

                    If rbNoZip.Checked = True And rbDestFTP.Checked = True Then
                        MsgBox("For remote FTP backup, data should br in ZIP format, Can't backup directly at present!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                        'TabControl1.SelectedTab = TabPage4
                        rbNoZip.Focus()
                        Exit Sub
                    End If
                    Call btnSave_Click(sender, e)

            End Select
        Catch ex As Exception
            Log.WriteException(ex, TraceEventType.Error)
        End Try
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Select Case TabControl1.SelectedIndex
            'Case 0
            'lblHeading.Text = "Select Data Source"
            'lblHeadingDesc.Text = "Select source files and folders for backup"
            'TabControl1.SelectedIndex = 1
            Case 1

                lblHeading.Text = "Backup Task Wizard"
                lblHeadingDesc.Text = "Schedule the task, select frequency and time"
                TabControl1.SelectedIndex = 0
                btnBack.Enabled = False

            Case 2
                lblHeading.Text = "Select Backup Data Source"
                lblHeadingDesc.Text = "Select source files and folders for backup"
                TabControl1.SelectedIndex = 1
            Case 3
                lblHeading.Text = "Select Destination"
                lblHeadingDesc.Text = "Set where you want to put backup"
                TabControl1.SelectedIndex = 2
                btnNext.Text = "Next >"
        End Select
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        btnNext.Text = "Next >"
        btnBack.Enabled = True
        Select Case TabControl1.SelectedIndex
            Case 0
                lblHeading.Text = "Backup Task Wizard"
                lblHeadingDesc.Text = "Schedule the task, select frequency and time"
                btnBack.Enabled = False
            Case 1
                lblHeading.Text = "Select Backup Data Source"
                lblHeadingDesc.Text = "Select source files and folders for backup"
            Case 2
                lblHeading.Text = "Select Destination"
                lblHeadingDesc.Text = "Set where you want to put backup"
            Case 3
                lblHeading.Text = "Backup Task Options"
                lblHeadingDesc.Text = "Set backup option"
                btnNext.Text = "Finish"
                'TabControl1.SelectedIndex = 2
                'btnNext.Text = "Next >"
        End Select
    End Sub

    Private Sub rbZip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbZip.CheckedChanged
        If rbZip.Checked = True Then
            gbZipOptions.Enabled = True
            cboZipEncryption.SelectedIndex = 0
        Else
            gbZipOptions.Enabled = False
        End If
    End Sub

    Private Sub cboZipEncryption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZipEncryption.SelectedIndexChanged
        If cboZipEncryption.SelectedIndex = 0 Then
            txtZipPass.Clear()
            txtZipPass.Enabled = False
            txtZipPassConfirm.Clear()
            txtZipPassConfirm.Enabled = False
        Else
            txtZipPass.Enabled = True
            txtZipPassConfirm.Enabled = True
        End If

    End Sub

    Private Sub rbDestLocal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDestLocal.CheckedChanged
        HideAllPanels()
        If rbDestLocal.Checked = True Then
            gbDLocal.Visible = True
        End If
    End Sub
    Private Sub HideAllPanels()
        gbDLocal.Visible = False
        gbDFTP.Visible = False
        gbWEBDAV.Visible = False
    End Sub
    Private Sub rbDestFTP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDestFTP.CheckedChanged

        If rbNoZip.Checked = True And rbDestFTP.Checked = True Then

            MsgBox("Remote FTP backup only possible for zip file currently", MsgBoxStyle.Information, "Information")
            rbDestFTP.Checked = False
            rbDestLocal.Checked = True
            Exit Sub
        End If
        If rbDestFTP.Checked = True Then
            HideAllPanels()
            gbDFTP.Visible = True
            txtFTPServerName.Focus()
        End If

    End Sub

    Private Sub rbDestWEBDAV_CheckedChanged(sender As Object, e As EventArgs) Handles rbDestWEBDAV.CheckedChanged
        'If rbNoZip.Checked = True And rbDestFTP.Checked = True Then
        'MsgBox("Remote FTP backup only possible for zip file currently", MsgBoxStyle.Information, "Information")
        'rbDestFTP.Checked = False
        'rbDestLocal.Checked = True
        'Exit Sub
        'End If
        If rbDestWEBDAV.Checked = True Then
            HideAllPanels()
            gbWEBDAV.Visible = True
            txtWebDAVServer.Focus()
        End If
    End Sub

    Private Sub btnWebDAVOk_Click(sender As Object, e As EventArgs) Handles btnWebDAVOk.Click
        ErrTask.Clear()
        If txtWebDAVServer.Text.Length = 0 Then
            'MsgBox("Please enter valid FTP server address", MsgBoxStyle.Information, "Information")
            ErrTask.SetError(txtWebDAVServer, "Please enter valid WebDAV server address")
            txtWebDAVServer.Focus()
            Exit Sub
        End If
        'If txtFTPServerName.Text.Contains(".") = False Or txtFTPServerName.Text.ToLower.Substring(0, 3) <> "ftp" Then
        If validateWebDAVURL(txtWebDAVServer.Text) = False Then
            'MsgBox("Please provide valid FTP server address", MsgBoxStyle.Information, "Information")
            ErrTask.SetError(txtWebDAVServer, "Please provide valid WebDAV server address")
            txtWebDAVServer.Focus()
            Exit Sub
        End If
        If txtWebDAVUser.Text.Length = 0 Or txtWebDAVPassword.Text.Length = 0 Then
            'MsgBox("Please enter valid FTP username and password", MsgBoxStyle.Information, "Information")
            ErrTask.SetError(txtWebDAVUser, "Please enter valid WebDAV username and password")
            txtWebDAVUser.Focus()
            Exit Sub
        End If
        gbWEBDAV.Visible = False
    End Sub
    Private Sub btnWebDAVCancel_Click(sender As Object, e As EventArgs) Handles btnWebDAVCancel.Click
        gbWEBDAV.Visible = False
        UncheckDest()
    End Sub
    Private Sub UncheckDest()
        rbDestLocal.Checked = False
        rbDestFTP.Checked = False
        rbDestSFTP.Checked = False
        rbDestWEBDAV.Checked = False
    End Sub


    Private Sub rbAtEvery_CheckedChanged(sender As Object, e As EventArgs) Handles rbAtEvery.CheckedChanged
        If rbAtEvery.Checked = True Then
            txtAtEvery.Enabled = True
            cmbAtEvery.Enabled = True
        Else
            txtAtEvery.Enabled = False
            cmbAtEvery.Enabled = False
        End If
    End Sub

    Private Sub rbCustomTime_CheckedChanged(sender As Object, e As EventArgs) Handles rbCustomTime.CheckedChanged
        If rbCustomTime.Checked = True Then
            dtpC1.Enabled = True
            dtpC2.Enabled = True
            dtpC3.Enabled = True
            dtpC4.Enabled = True
        Else
            dtpC1.Enabled = False
            dtpC2.Enabled = False
            dtpC3.Enabled = False
            dtpC4.Enabled = False
        End If
    End Sub


    Private Sub btnAddFilter_Click(sender As Object, e As EventArgs) Handles btnAddFilter.Click
        Dim Filter1 As New Filterform
        If Filter1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim strTmp() As String
            strTmp = Filter1.MyValue.Split(New Char() {"|"c})
            If strTmp(0) = "I" Then lvFilter.Items.Add("Include") Else lvFilter.Items.Add("Exclude")
            lvFilter.Items(lvFilter.Items.Count - 1).SubItems.Add(strTmp(1))
        End If
    End Sub

    Private Sub btnAddRemove_Click(sender As Object, e As EventArgs) Handles btnAddRemove.Click
        If lvFilter.Items.Count = 0 Then Exit Sub
        If lvFilter.SelectedItems.Count = 0 Then Exit Sub
        lvFilter.Items(lvFilter.SelectedItems(0).Index).Remove()
    End Sub

    Private Sub TestingSave()
        Try

            Dim i As Integer = 0
            'Dim lvi As ListViewItem
            Dim strTmp As String = ""
            Dim strDays As String = ""

            If ValidateSave() = False Then
                Me.DialogResult = DialogResult.None
                Exit Sub
            End If

            'strTmp = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" + Application.ProductName, "LFile", Nothing)
            'BackupData.Instance.BackupTable.Rows.Clear()

            If lblCode.Text = "0" Then
                If strTmp = Nothing Then
                    strTmp = 1
                Else
                    strTmp = CDbl(strTmp) + 1
                End If
            Else
                strTmp = CDbl(lblCode.Text) ' for update the Save file
                BackupData.Instance.BackupTable.Rows.RemoveAt(strTmp - 1)
            End If

            'ini = Nothing

            If IO.Directory.Exists(strCurPath & "\Data") = False Then IO.Directory.CreateDirectory(strCurPath & "\Data")

            'If IO.File.Exists(strCurPath + "\Data\FLSet" + strTmp + ".dat") Then IO.File.Delete(strCurPath + "\Data\FLSet" + strTmp + ".dat")
            If IO.File.Exists(strCurPath + "\Data\FLSet" + strTmp + ".db") Then IO.File.Delete(strCurPath + "\Data\FLSet" + strTmp + ".db")

            Dim row2 As DataRow = BackupData.Instance.BackupTable.NewRow
            row2.Item("TName") = txtBackupName.Text
            row2.Item("DSize") = txtTotalSize.Text
            row2.Item("TStatus") = 1
            strTmp = cboBackupType.Text.Substring(0, 1)
            row2.Item("TType") = strTmp

            If cboStatus.Text.Substring(0, 1) = "M" Then row2.Item("TStatus") = 1 Else row2.Item("TStatus") = 0

            If strTmp = "D" Then 'Daily
                If rbDEveryDay.Checked = True Then
                    row2.Item("TAtEach") = 7
                ElseIf rbDWeekDays.Checked = True Then
                    row2.Item("TAtEach") = 5
                ElseIf rbDExcludeSunday.Checked = True Then
                    row2.Item("TAtEach") = 6
                End If
                'for time
                If chkCustomTime.Checked = False Then
                    dtpAlwaysTime.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"
                    row2.Item("T0") = dtpAlwaysTime.Value.ToString("MM/dd/yyyy hh:mm:ss tt")
                Else
                    If rbAtEvery.Checked = True Then
                        row2.Item("TEvery") = txtAtEvery.Text
                        row2.Item("TElement") = cmbAtEvery.Text.ToString.Substring(0, 1)
                        'iniData.WriteValue("TEvent", "TDone", Now)
                    ElseIf rbCustomTime.Checked = True Then
                        If dtpC1.Checked = True Then
                            dtpC1.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"
                            row2.Item("T1") = dtpC1.Value.ToString("MM/dd/yyyy hh:mm:ss tt")
                        End If
                        If dtpC2.Checked = True Then
                            dtpC2.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"
                            row2.Item("T2") = row2.Item("T1") + " | " + dtpC2.Value.ToString("MM/dd/yyyy hh:mm:ss tt")
                        End If
                        If dtpC3.Checked = True Then
                            dtpC3.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"
                            row2.Item("T3") = row2.Item("T2") + " | " + dtpC3.Value.ToString("MM/dd/yyyy hh:mm:ss tt")
                        End If
                        If dtpC4.Checked = True Then
                            dtpC4.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"
                            row2.Item("T4") = row2.Item("T3") + " | " + dtpC4.Value.ToString("MM/dd/yyyy hh:mm:ss tt")
                        End If
                    End If
                End If
                'end for time

            ElseIf strTmp = "W" Then 'Weekly
                If chkMon.Checked = True Then
                    strDays = "1"
                Else
                    strDays = "0"
                End If
                If chkTue.Checked = True Then
                    strDays = strDays + "1"
                Else
                    strDays = strDays + "0"
                End If
                If chkWen.Checked = True Then
                    strDays = strDays + "1"
                Else
                    strDays = strDays + "0"
                End If
                If chkThu.Checked = True Then
                    strDays = strDays + "1"
                Else
                    strDays = strDays + "0"
                End If
                If chkFri.Checked = True Then
                    strDays = strDays + "1"
                Else
                    strDays = strDays + "0"
                End If
                If chkSat.Checked = True Then
                    strDays = strDays + "1"
                Else
                    strDays = strDays + "0"
                End If
                If chkSun.Checked = True Then
                    strDays = strDays + "1"
                Else
                    strDays = strDays + "0"
                End If
                row2.Item("WeekDays") = strDays.ToString

                'for time


                If rbAtEvery.Checked = True Then
                    row2.Item("T1") = dtpC1.Value.ToString
                ElseIf rbCustomTime.Checked = True Then
                    If dtpC1.Checked = True Then
                        row2.Item("T1") = dtpC1.Value.ToString
                    End If
                    If dtpC2.Checked = True Then
                        row2.Item("T2") = dtpC2.Value.ToString
                    End If
                    If dtpC3.Checked = True Then
                        row2.Item("T2") = dtpC3.Value.ToString
                    End If
                    If dtpC4.Checked = True Then
                        row2.Item("T4") = dtpC4.Value.ToString
                    End If
                End If

                'end for time
            ElseIf strTmp = "O" Then 'One Time Only
                row2.Item("TDate") = dtpBDate.Value.ToString
                'for time
                If chkCustomTime.Checked = False Then
                    row2.Item("T0") = dtpAlwaysTime.Value.ToString
                Else
                    If dtpC1.Checked = True Then
                        row2.Item("T1") = dtpC1.Value.ToString
                    End If
                    If dtpC2.Checked = True Then
                        row2.Item("T2") = dtpC2.Value.ToString
                    End If
                    If dtpC3.Checked = True Then
                        row2.Item("T3") = dtpC3.Value.ToString
                    End If
                    If dtpC4.Checked = True Then
                        row2.Item("T4") = dtpC4.Value.ToString
                    End If
                End If
            End If


            If rbZip.Checked = True Then
                row2.Item("Zip") = True ' "1"
                Select Case cboZipEncryption.SelectedIndex
                    Case 0 ' NONE
                        row2.Item("ZipEnc") = "0"
                    Case 1 ' AES-128
                        row2.Item("ZipEnc") = "AES128"
                    Case 2 ' AES-256
                        row2.Item("ZipEnc") = "AES256"
                End Select
                If txtZipPass.Text.Length <> 0 Then
                    row2.Item("ZipEncP") = AES_Encrypt(txtZipPass.Text, "k5*e#d4o%p@%568")
                End If
            Else
                row2.Item("Zip") = False '"0"
            End If
            'destination

            If rbDestLocal.Checked = True Then
                row2.Item("LocalBack") = True '"1"
                row2.Item("DestDirPath") = String.Empty
                Do While i <= lbLocal.Items.Count - 1
                    If i = 0 Then
                        row2.Item("DestDirPath") = lbLocal.Items.Item(i)
                    Else
                        row2.Item("DestDirPath") = row2.Item("DestDirPath") + "%" + lbLocal.Items.Item(i)
                    End If
                    i = i + 1
                Loop
                row2.Item("DestDirT") = i.ToString
            Else
                row2.Item("LocalBack") = False ' "0"
            End If
            'BackupData.Instance.BackupList.Item().
            'row2.Item("DestDirPath") = list2
            'destination ends
            If rbDestFTP.Checked = True Then
                row2.Item("Other") = "FTP"
                row2.Item("FTPS") = txtFTPServerName.Text
                row2.Item("FTPSPort") = txtFTPPort.Text
                row2.Item("FTPU") = txtFTPU.Text
                row2.Item("FTPP") = AES_Encrypt(txtFTPP.Text, "k5*e#d4o%p@%568")
            Else
                row2.Item("Other") = 0
            End If
            If rbDestWEBDAV.Checked = True Then
                row2.Item("Other") = "WebDAV"
                row2.Item("WDS") = txtWebDAVServer.Text
                row2.Item("WDSPort") = txtWebDAVPort.Text
                row2.Item("WDU") = txtWebDAVUser.Text
                row2.Item("WDP") = AES_Encrypt(txtWebDAVPassword.Text, "k5*e#d4o%p@%568")
                row2.Item("Other") = 0
            End If

            'source files and folders
            row2.Item("SourceDirPath") = String.Empty
            Dim list1 As New List(Of SourceDirInfo)
            If lvwPics.Items.Count <> 0 Then
                For i = 0 To lvwPics.Items.Count - 1
                    If i = 0 Then
                        row2.Item("SourceDirPath") = lvwPics.Items(i).SubItems(0).Text + "|" + lvwPics.Items(i).SubItems(1).Text + "|" + lvwPics.Items(i).SubItems(2).Text
                    Else
                        row2.Item("SourceDirPath") = row2.Item("SourceDirPath") + "%" + lvwPics.Items(i).SubItems(0).Text + "|" + lvwPics.Items(i).SubItems(1).Text + "|" + lvwPics.Items(i).SubItems(2).Text
                    End If
                Next
                row2.Item("SourceDirT") = i.ToString
            Else
                row2.Item("SourceDirT") = "0"
            End If
            'row2.Item("SourceDirInfo") = list1
            'source files and folders ends here

            'Filter save
            If lvFilter.Items.Count <> 0 Then
                For i = 0 To lvFilter.Items.Count - 1
                    If i = 0 Then
                        row2.Item("DirFilter") = lvFilter.Items(i).Text.ToString.Substring(0, 1) + "|" + lvFilter.Items(i).SubItems(1).Text.ToString
                    Else
                        row2.Item("DirFilter") = row2.Item("DirFilter") + "%" + lvFilter.Items(i).Text.ToString.Substring(0, 1) + "|" + lvFilter.Items(i).SubItems(1).Text.ToString
                    End If
                Next
                'Else
                'iniData.WriteValue("Source", "DirF", "0")
                row2.Item("DirFilterT") = i.ToString
            End If

            'filter save ends here
            If rbIncremental.Checked = True Then
                row2.Item("BMode") = "IB"
            ElseIf rbDifferential.Checked = True Then
                row2.Item("BMode") = "DB"
            ElseIf rbFullBackup.Checked = True Then
                row2.Item("BMode") = "FB"
            End If

            row2.Item("EC") = "0"

            BackupData.Instance.BackupTable.Rows.Add(row2)
            BackupData.Instance.WriteTMSettings()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub
    Private Sub ReadDataNew()
        Try
            Dim strTmp As String = ""
            If System.IO.File.Exists(strCurPath + "\Data\BackupData.db") = False Then Exit Sub
            If BackupData.Instance.BackupTable.Rows.Count = 0 Then Exit Sub

            Dim predicate As Func(Of BackupRecord, Boolean) = Nothing
            If (predicate Is Nothing) Then
                predicate = Function(st As BackupRecord)
                                Return (st.TID = lblCode.Text)
                            End Function
            End If
            Dim parameter As BackupRecord = Enumerable.First(Of BackupRecord)(Enumerable.Where(Of BackupRecord)(BackupData.Instance.BackupList, predicate))


            'Dim ini As New IniFile(strCurPath + "\Data\FLSet" + lblCode.Text + ".db")
            Dim ini As New IniFile(strCurPath + "\Data\BackupData.db")
            strTmp = parameter.TName

            If strTmp <> String.Empty Then
                txtBackupName.Text = strTmp
            End If

            'strTmp = ini.ReadValue("TName", "DSize")

            'If strTmp <> String.Empty Then

            'txtTotalSize.Text = strTmp
            'End If

            strTmp = parameter.TStatus

            If strTmp <> String.Empty Then
                If strTmp = True Then cboStatus.Text = "Monitoring" Else cboStatus.Text = "Paused"
            Else
                cboStatus.Text = "Monitoring"
            End If

            strTmp = parameter.TType

            If strTmp <> String.Empty Then
                If strTmp = "D" Then
                    cboBackupType.Text = "Daily"
                    strTmp = parameter.TAtEach
                    If strTmp = "7" Then
                        rbDEveryDay.Checked = True
                    ElseIf strTmp = "6" Then
                        rbDExcludeSunday.Checked = True
                    ElseIf strTmp = "5" Then
                        rbDWeekDays.Checked = True
                    End If
                    strTmp = parameter.T0
                    If strTmp <> String.Empty Then
                        'Dim check1Time As DateTime = strTmp '.Substring(11, 10)
                        'strTmp = check1Time.ToString("hh:mm tt")

                        dtpAlwaysTime.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                        dtpAlwaysTime.Checked = True
                        chkCustomTime.Checked = False
                    Else
                        strTmp = parameter.TElement

                        If strTmp = String.Empty Then
                            chkCustomTime.Checked = True
                            rbCustomTime.Checked = True
                            strTmp = parameter.T1
                            If strTmp <> String.Empty Then
                                'Dim newDate As DateTime = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)
                                'strTmp = newDate.ToString("hh:mm tt")
                                dtpC1.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                                dtpC1.Checked = True
                            End If
                            strTmp = parameter.T2
                            If strTmp <> String.Empty Then
                                dtpC2.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                                dtpC2.Checked = True
                            End If
                            strTmp = parameter.T3
                            If strTmp <> String.Empty Then
                                dtpC3.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                                dtpC3.Checked = True
                            End If
                            strTmp = parameter.T4
                            If strTmp <> String.Empty Then
                                dtpC4.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                                dtpC4.Checked = True
                            End If
                        Else
                            strTmp = parameter.TElement
                            If strTmp.ToString.Substring(0, 1) = "M" Then
                                cmbAtEvery.Text = "Minutes"
                            Else
                                cmbAtEvery.Text = "Hours"
                            End If
                            txtAtEvery.Text = parameter.TEvery
                            rbAtEvery.Checked = True
                            chkCustomTime.Checked = True
                        End If
                    End If
                ElseIf strTmp = "W" Then
                    cboBackupType.Text = "Weekly"
                    strTmp = parameter.WeekDays
                    If strTmp <> String.Empty Then

                        If strTmp.Substring(0, 1) = "1" Then chkMon.Checked = True Else chkMon.Checked = False
                        If strTmp.Substring(1, 1) = "1" Then chkTue.Checked = True Else chkTue.Checked = False
                        If strTmp.Substring(2, 1) = "1" Then chkWen.Checked = True Else chkWen.Checked = False
                        If strTmp.Substring(3, 1) = "1" Then chkThu.Checked = True Else chkThu.Checked = False
                        If strTmp.Substring(4, 1) = "1" Then chkFri.Checked = True Else chkFri.Checked = False
                        If strTmp.Substring(5, 1) = "1" Then chkSat.Checked = True Else chkSat.Checked = False
                        If strTmp.Substring(6, 1) = "1" Then chkSun.Checked = True Else chkSun.Checked = False
                    End If
                    strTmp = parameter.T0
                    If strTmp <> String.Empty Then
                        dtpAlwaysTime.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                        dtpAlwaysTime.Checked = True
                        chkCustomTime.Checked = False
                    Else
                        chkCustomTime.Checked = True
                        strTmp = parameter.T1
                        If strTmp <> String.Empty Then
                            dtpC1.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                            dtpC1.Checked = True
                        End If
                        strTmp = parameter.T2
                        If strTmp <> String.Empty Then
                            dtpC2.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                            dtpC2.Checked = True
                        End If
                        strTmp = parameter.T3
                        If strTmp <> String.Empty Then
                            dtpC3.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                            dtpC3.Checked = True
                        End If
                        strTmp = parameter.T4
                        If strTmp <> String.Empty Then
                            dtpC4.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                            dtpC4.Checked = True
                        End If
                    End If

                ElseIf strTmp = "C" Then
                    cboBackupType.Text = "Computer starts"

                ElseIf strTmp = "O" Then
                    cboBackupType.Text = "One time only"
                    strTmp = parameter.TDate
                    If strTmp <> String.Empty Then
                        dtpBDate.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                    End If
                    strTmp = parameter.T0
                    If strTmp <> String.Empty Then
                        dtpAlwaysTime.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                        dtpAlwaysTime.Checked = True
                        chkCustomTime.Checked = False
                    Else
                        chkCustomTime.Checked = True
                        strTmp = parameter.T1
                        If strTmp <> String.Empty Then
                            dtpC1.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                            dtpC1.Checked = True
                        End If
                        strTmp = parameter.T2
                        If strTmp <> String.Empty Then
                            dtpC2.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                            dtpC2.Checked = True
                        End If
                        strTmp = parameter.T3
                        If strTmp <> String.Empty Then
                            dtpC3.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                            dtpC3.Checked = True
                        End If
                        strTmp = parameter.T4
                        If strTmp <> String.Empty Then
                            dtpC4.Value = Convert.ToDateTime(strTmp, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) 'Convert.ToDateTime(strTmp)
                            dtpC4.Checked = True
                        End If
                    End If
                ElseIf strTmp = "M" Then 'Manual Start
                    cboBackupType.Text = "Manual Start"
                End If
                strTmp = parameter.Zip
                If strTmp <> String.Empty Then
                    If strTmp = True Then
                        rbZip.Checked = True
                        strTmp = parameter.ZipEnc
                        Select Case strTmp
                            Case "0"
                                cboZipEncryption.SelectedIndex = 0 'NONE
                            Case "AES128"
                                cboZipEncryption.SelectedIndex = 1 'AES128
                            Case "AES256"
                                cboZipEncryption.SelectedIndex = 2 'AES256
                            Case Else
                                cboZipEncryption.SelectedIndex = 0
                        End Select
                        strTmp = parameter.ZipEncP
                        If strTmp <> String.Empty Then
                            strTmp = AES_Decrypt(strTmp, "k5*e#d4o%p@%568")
                            txtZipPass.Text = strTmp
                            txtZipPass.Tag = strTmp
                            txtZipPassConfirm.Text = txtZipPass.Text
                        End If
                    Else
                        rbNoZip.Checked = True
                    End If
                End If
                strTmp = parameter.LocalBack
                If strTmp = True Then
                    If strTmp = True Then
                        rbDestLocal.Checked = True
                    Else
                        rbDestFTP.Checked = False
                        rbDestWEBDAV.Checked = False
                    End If

                End If
                strTmp = parameter.BMode

                If strTmp <> String.Empty Then
                    If strTmp = "IB" Then
                        rbIncremental.Checked = True
                    ElseIf strTmp = "DB" Then
                        rbDifferential.Checked = True
                    ElseIf strTmp = "FB" Then
                        rbFullBackup.Checked = True
                    End If
                Else
                    rbDifferential.Checked = True
                End If
                strTmp = parameter.Other
                If strTmp <> String.Empty Then
                    If strTmp = "FTP" Then
                        rbDestFTP.Checked = True
                        'chkDFTP.Checked = True
                        'btnFTP.Enabled = True
                        strTmp = parameter.FTPinfo.FTPS
                        txtFTPServerName.Text = strTmp
                        strTmp = parameter.FTPinfo.FTPSPort
                        txtFTPPort.Text = strTmp
                        strTmp = parameter.FTPinfo.FTPU
                        txtFTPU.Text = strTmp
                        strTmp = parameter.FTPinfo.FTPP
                        strTmp = AES_Decrypt(strTmp, "k5*e#d4o%p@%568")
                        txtFTPP.Text = strTmp
                    ElseIf strTmp = "WebDAV" Then
                        rbDestWEBDAV.Checked = True
                        'strTmp = ini.ReadValue("Dest", "WDS")
                        txtWebDAVServer.Text = strTmp
                        'strTmp = ini.ReadValue("Dest", "WDSPort")
                        txtWebDAVPort.Text = strTmp
                        'strTmp = ini.ReadValue("Dest", "WDU")
                        txtWebDAVUser.Text = strTmp
                        'strTmp = ini.ReadValue("Dest", "WDP")
                        'strTmp = AES_Decrypt(strTmp, "k5*e#d4o%p@%568")
                        txtWebDAVPassword.Text = strTmp
                    Else
                        rbDestFTP.Checked = False
                        rbDestWEBDAV.Checked = False
                    End If
                End If
                'Destination folder
                Dim DestDirCount As Integer = 0
                DestDirCount = parameter.DestDirT
                If DestDirCount <> 0 Then
                    If parameter.DestDirPath.ToString.Contains("%") = True Then
                        Dim words As String() = parameter.DestDirPath.ToString.Split(New Char() {"%"c})
                        For i = 0 To UBound(words) - 1
                            lbLocal.Items.Add(words(0))
                        Next
                    Else
                        lbLocal.Items.Add(parameter.DestDirPath.ToString)
                    End If
                End If
                'Source file folders
                Dim SourceDirCount As Integer = 0
                SourceDirCount = parameter.SourceDirT
                If SourceDirCount <> 0 Then
                    If parameter.SourceDirPath.ToString.Contains("%") = True Then
                        Dim words As String() = parameter.SourceDirPath.ToString.Split(New Char() {"%"c})
                        For i = 0 To UBound(words)
                            Dim words2 As String() = words(i).Split(New Char() {"|"c})
                            lvwPics.Items.Add(words2(0))
                            lvwPics.Items(i).SubItems.Add(words2(1))
                            lvwPics.Items(i).SubItems.Add(words2(2))
                            txtTotalSize.Text = CDbl(txtTotalSize.Text) + CDbl(words2(2))
                        Next
                    Else
                        Dim words3 As String() = parameter.SourceDirPath.ToString.Split(New Char() {"|"c})
                        lvwPics.Items.Add(words3(0))
                        lvwPics.Items(0).SubItems.Add(words3(1))
                        lvwPics.Items(0).SubItems.Add(words3(2))
                        txtTotalSize.Text = CDbl(txtTotalSize.Text) + CDbl(words3(2))
                    End If
                End If
                'Filter

                strTmp = parameter.DirFilterT  ' ini.ReadValue("Source", "DirFT")
                If strTmp <> String.Empty And strTmp <> 0 Then
                    If parameter.DirFilter.ToString.Contains("%") = True Then
                        Dim FilterWords As String() = parameter.DirFilter.ToString.Split(New Char() {"%"c})
                        For i = 0 To UBound(FilterWords)
                            Dim FilterWords2 As String() = FilterWords(i).Split(New Char() {"|"c})
                            If FilterWords2(0) = "E" Then lvFilter.Items.Add("Exclude") Else lvFilter.Items.Add("Include")
                            lvFilter.Items(i).SubItems.Add(FilterWords2(1))
                        Next
                    Else
                        strTmp = parameter.DirFilter.ToString
                        Dim FilterValues As String() = strTmp.Split(New Char() {"|"c})
                        If FilterValues(0) = "E" Then lvFilter.Items.Add("Exclude") Else lvFilter.Items.Add("Include")
                        lvFilter.Items(0).SubItems.Add(FilterValues(1))
                    End If

                End If
                'filter till here
            End If
            'TODO

        Catch ex As Exception
            Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub
End Class