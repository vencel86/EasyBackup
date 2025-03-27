Imports System.Windows.Forms

Public Class frmFailedTask
    Private Shared fLog As New FileLog(My.Application.Info.Title, strCurPath + "\Logs\")
    Public Shared ReadOnly Property Log() As FileLog
        Get
            Return fLog
        End Get
    End Property
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmRestore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ReadData()
    End Sub
    Private Sub ReadData()
        lvwPics.Items.Clear()
        If IO.Directory.Exists(strCurPath + "\Data") = False Then Exit Sub
        Dim files() As String = System.IO.Directory.GetFiles(strCurPath + "\Data", "*.db")
        For Each file As String In files
            'Dim text As String = IO.File.ReadAllText(file)
            Call FillLV(file)
        Next
    End Sub
    Private Sub FillLV(ByVal strFLNM As String)
        Try
            Dim strTmp As String = ""
            Dim strCode As String = ""
            Dim ini As New IniFile(strFLNM)
            Dim strTimeVar As String = ""


            strCode = (System.IO.Path.GetFileNameWithoutExtension(strFLNM))
            strCode = strCode.Replace("FLSet", "")

            strTmp = ini.ReadValue("CE", "EC")
            If strTmp <> String.Empty Then
                If strTmp = "0" Then Exit Sub
            Else : Exit Sub
            End If

            'strTmp = ini.ReadValue("TEvent", "TStart")
            'If strTmp.Length = 0 Then Exit Sub
            'If strTmp = "0" Then Exit Sub

            Dim LVWitem As ListViewItem = lvwPics.Items.Add(strCode)

            strTmp = ini.ReadValue("Sch", "TName")
            LVWitem.SubItems.Add(strTmp)

            strTmp = ini.ReadValue("Sch", "TType")
            If strTmp = "D" Then
                LVWitem.SubItems.Add("Daily")
            ElseIf strTmp = "W" Then
                LVWitem.SubItems.Add("Weekly")
            ElseIf strTmp = "C" Then
                LVWitem.SubItems.Add("Computer Starts")
            ElseIf strTmp = "O" Then
                LVWitem.SubItems.Add("One time only")
            End If

            strTmp = ini.ReadValue("CE", "ET")
            If strTmp <> String.Empty Then
                LVWitem.SubItems.Add(strTmp)
            Else
                LVWitem.SubItems.Add("File/Folder may be in use or not accesible")
            End If

            If lvwPics.Items.Count <> 0 Then lvwPics.Items(0).Selected = True
            ini = Nothing
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub

    Private Sub cMnuRunNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvwPics.SelectedItems.Count = 0 Then Exit Sub
        Me.Close()
        Call MainForm.TriggerEvent(lvwPics.SelectedItems(0).Text, lvwPics.SelectedItems(0).SubItems(4).Text)

    End Sub

    Private Sub cMnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If lvwPics.SelectedItems.Count = 0 Then Exit Sub
            Dim iniData As New IniFile(strCurPath + "\Data\FLSet" + lvwPics.SelectedItems(0).Text + ".db")
            iniData.WriteValue("TEvent", "TStart", "0")
            iniData.WriteValue("TEvent", "TZip", "0")
            iniData.WriteValue("TEvent", "TDir", "0")
            iniData.WriteValue("TEvent", "TDir", Now)
            iniData = Nothing
            frmRestore_Load(sender, e)
        Catch ex As Exception
            Log.WriteException(ex, TraceEventType.Error)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lvwPics.SelectedItems.Count = 0 Then Exit Sub
        Dim TForm As New frmTask
        TForm.lblCode.Text = lvwPics.SelectedItems(0).Text
        Me.Close()
        TForm.ShowDialog()
        'If TForm.ShowDialog() = DialogResult.OK Then
        'Call LoadData()
        'End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            If lvwPics.SelectedItems.Count = 0 Then Exit Sub
            If MsgBox("Are you sure to remove selected backup task?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then Exit Sub
            IO.File.Delete(strCurPath + "\Data\FLSet" + lvwPics.SelectedItems(0).Text + ".db")
            Call ReadData()
            Me.DialogResult = DialogResult.None
        Catch ex As Exception
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("There was a problem while deleting selected task, Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
        End Try
    End Sub
End Class
