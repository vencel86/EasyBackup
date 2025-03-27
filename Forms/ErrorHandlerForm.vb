Imports System.Text
Imports System.Threading
Public Class ErrorHandlerForm
    Private strLog As String
    Private Shared fLog As New FileLog(My.Application.Info.Title, strCurPath + "\Logs\")
    Public Shared ReadOnly Property Log() As FileLog
        Get
            Return fLog
        End Get
    End Property
    Public Sub ErrorText(Err As Exception)
        strLog = Err.ToString
        Dim sb As New StringBuilder()

        ' Set picturebox to error
        'Me.pictureBoxErr.Image = SystemIcons.[Error].ToBitmap()
        Log.WriteException(Err, TraceEventType.Error)
        Dim proc As Process = Process.GetCurrentProcess()

        ' dates and time
        sb.AppendLine(String.Format("Current Date/Time: {0}", DateTime.Now.ToString()))
        'sb.AppendLine(String.Format("Exec. Date/Time: {0}", proc.StartTime.ToString()))
        'sb.AppendLine(String.Format("Build Date: {0}", Properties.Settings.[Default].strBuildTime))
        ' os info
        'sb.AppendLine(String.Format("OS: {0}", Environment.OSVersion.VersionString))
        sb.AppendLine(String.Format("Language: {0}", Application.CurrentCulture.ToString()))
        ' uptime stats
        sb.AppendLine(String.Format("System Uptime: {0} Days {1} Hours {2} Mins {3} Secs", Math.Round(CDec(Environment.TickCount) / 86400000), Math.Round(CDec(Environment.TickCount) / 3600000 Mod 24), Math.Round(CDec(Environment.TickCount) / 120000 Mod 60), Math.Round(CDec(Environment.TickCount) / 1000 Mod 60)))
        sb.AppendLine(String.Format("Program Uptime: {0}", proc.TotalProcessorTime.ToString()))
        ' process id
        'sb.AppendLine(String.Format("PID: {0}", proc.Id))
        ' exe name
        sb.AppendLine(String.Format("Executable: {0}", Application.ExecutablePath))
        sb.AppendLine(String.Format("Process Name: {0}", proc.ToString()))
        'sb.AppendLine(String.Format("Main Module Name: {0}", proc.MainModule.ModuleName))
        ' exe stats
        'sb.AppendLine(String.Format("Module Count: {0}", proc.Modules.Count))
        'sb.AppendLine(String.Format("Thread Count: {0}", proc.Threads.Count))
        'sb.AppendLine(String.Format("Thread ID: {0}", Thread.CurrentThread.ManagedThreadId))
        'sb.AppendLine(String.Format("Is Admin: {0}", Permissions.IsUserAdministrator))
        sb.AppendLine(String.Format("Is Debugged: {0}", Debugger.IsAttached))
        ' versions
        sb.AppendLine(String.Format("Version: {0}", Application.ProductVersion))
        'sb.AppendLine(String.Format("CLR Version: {0}", Environment.Version.ToString()))


        Dim ex As Exception = Err
        Dim i As Integer = 0
        While ex IsNot Nothing
            sb.AppendLine()
            sb.AppendLine(String.Format("Type #{0} {1}", i, ex.[GetType]().ToString()))

            For Each propInfo As System.Reflection.PropertyInfo In ex.[GetType]().GetProperties()
                Dim fieldName As String = String.Format("{0} #{1}", propInfo.Name, i)
                Dim fieldValue As String = String.Format("{0}", propInfo.GetValue(ex, Nothing))

                ' Ignore stack trace + data
                If propInfo.Name = "StackTrace" OrElse propInfo.Name = "Data" OrElse String.IsNullOrEmpty(propInfo.Name) OrElse String.IsNullOrEmpty(fieldValue) Then
                    Continue For
                End If

                sb.AppendLine(String.Format("{0}: {1}", fieldName, fieldValue))
            Next

            If ex.Data IsNot Nothing Then
                For Each de As DictionaryEntry In ex.Data
                    sb.AppendLine(String.Format("Dictionary Entry #{0}: Key: {1} Value: {2}", i, de.Key, de.Value))
                Next
            End If
            ex = ex.InnerException
            i += 1
        End While

        sb.AppendLine()
        sb.AppendLine("StackTrace:")
        sb.AppendLine(Err.StackTrace)

        Me.richTextBox1.Text = sb.ToString()

        ' Dim b As Byte() = Encoding.ASCII.GetBytes(sb.ToString())
        'memoryStream.Write(b, 0, b.Length)
    End Sub

    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        End
        Me.DialogResult = Windows.Forms.DialogResult.Abort
    End Sub

    Private Sub btnRetry_Click(sender As Object, e As EventArgs) Handles btnRetry.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
    End Sub

    Private Sub btnIgnore_Click(sender As Object, e As EventArgs) Handles btnIgnore.Click
        Me.DialogResult = Windows.Forms.DialogResult.Ignore
    End Sub

    Private Sub btnOpenFolder_Click(sender As Object, e As EventArgs) Handles btnOpenFolder.Click
        Process.Start(strCurPath + "\Logs\")
        'MsgBox(strLog)
    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click

    End Sub
End Class