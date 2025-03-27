Imports IntelliLock.Licensing
Imports System.Windows.Forms
Public Class GerForm
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.DialogResult = DialogResult.None
        Me.Close()
    End Sub

    Private Sub cmdReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReg.Click
        Try

        
        If txtGer.Text.Length = 0 Then Exit Sub
        If IO.File.Exists(txtGer.Text) = False Then Exit Sub
        If IO.File.Exists(Application.StartupPath & "\easybackup.license") Then IO.File.Delete(Application.StartupPath & "\easybackup.license")
        IO.File.Copy(txtGer.Text, Application.StartupPath & "\easybackup.license")
        System.Threading.Thread.Sleep(700)
            MsgBox("Please restart application to verify your registration", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            Log.WriteException(ex, TraceEventType.Error)
        End Try
    End Sub

    Private Sub GerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.txtUserKey.Text = IntelliLock.Licensing.HardwareID.GetHardwareID(True, True, True, True, True, False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        OpenFileDialog1.Filter = "License File (*.license)|*.license"
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            txtGer.Text = OpenFileDialog1.FileName
            Me.DialogResult = Windows.Forms.DialogResult.None
        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
        End If
    End Sub
End Class
