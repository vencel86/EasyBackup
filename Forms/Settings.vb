Imports System.Windows.Forms

Public Class Settings
    Private Shared fLog As New FileLog(My.Application.Info.Title, strCurPath + "\Logs\")
    Public Shared ReadOnly Property Log() As FileLog
        Get
            Return fLog
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            If chkAuto.Checked = True Then
                Dim CU As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run")
                CU.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                CU.SetValue(Application.ProductName, Application.ExecutablePath + " /s")
                CU.Close()
                CU = Nothing
            Else
                Dim CU As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run")
                CU.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                CU.DeleteValue(Application.ProductName, False)
                CU.Close()
                CU = Nothing
            End If

        'sound
        Dim regVersion = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\" + Application.ProductName, True)
        If regVersion Is Nothing Then
            ' Key doesn't exist; create it.
            regVersion = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\" + Application.ProductName)
        End If
        If chkEnableSound.Checked = True Then
            regVersion.SetValue("EnableSND", "1")
        Else
            regVersion.DeleteValue("EnableSND", "0")
        End If
        regVersion.Close()
        regVersion = Nothing

        'skip files
        Dim regVersion1 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\" + Application.ProductName, True)
        If chkSkip.Checked = True Then
            regVersion1.SetValue("SkipFiles", "1")
        Else
            regVersion1.DeleteValue("SkipFiles", "0")
        End If
        regVersion1.Close()
        regVersion1 = Nothing

        'Updates
        Dim regVersion2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\" + Application.ProductName, True)
        If rbUpdate.Checked = True Then
            regVersion2.SetValue("Updates", "1")
        Else
            regVersion2.SetValue("Updates", "0")
        End If
        regVersion2.Close()
        regVersion2 = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            Log.WriteException(ex, TraceEventType.Error)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, Nothing) Is Nothing Then
                chkAuto.Checked = False
            Else
                chkAuto.Checked = True
            End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" + Application.ProductName, "EnableSnd", Nothing) Is Nothing Then
            '            MsgBox("Value does not exist.")
            chkEnableSound.Checked = False : MainForm.boolEnableSND = False
        Else
            chkEnableSound.Checked = True : MainForm.boolEnableSND = False
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" + Application.ProductName, "SkipFiles", Nothing) Is Nothing Then
            chkSkip.Checked = False : MainForm.boolSkipFiles = False
        Else
            chkSkip.Checked = True : MainForm.boolSkipFiles = False
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" + Application.ProductName, "Updates", Nothing) Is Nothing Then
            rbUpdate.Checked = True : MainForm.boolUpdates = True
        Else
            rbNoUpdate.Checked = True : MainForm.boolUpdates = False
        End If

        Catch ex As Exception
            Log.WriteException(ex, TraceEventType.Error)
        End Try

    End Sub
End Class
