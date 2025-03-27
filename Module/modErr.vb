Imports System.IO
Imports System.Text
Module modErr
    Friend m_Log As String 'Logs
    Friend IndentLevel As Integer
    Private Sub WriteToErrorLog(ByVal msg As String, ByVal stkTrace As String, ByVal title As String)

        'check and make the directory if necessary; this is set to look in the application
        'folder, you may wish to place the error log in another location depending upon the
        'the user's role and write access to different areas of the file system
        'If Not System.IO.Directory.Exists(strCurPath & "\Errors\") Then
        'System.IO.Directory.CreateDirectory(strCurPath & "\Errors\")
        'End If

        ' check File size and delete if BIG

        'check the file
        Dim fs As FileStream = New FileStream(strCurPath & "\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim s As StreamWriter = New StreamWriter(fs)
        s.Close()
        fs.Close()

        'log it
        Dim fs1 As FileStream = New FileStream(strCurPath & "\errlog.txt", FileMode.Append, FileAccess.Write)
        Dim s1 As StreamWriter = New StreamWriter(fs1)
        s1.Write("Title: " & title & vbCrLf)
        s1.Write("Message: " & msg & vbCrLf)
        s1.Write("StackTrace: " & stkTrace & vbCrLf)
        s1.Write(DateTime.Now.ToString() & vbCrLf)
        s1.Write("===========================================================================================" & vbCrLf)
        s1.Close()
        fs1.Close()

        Dim MyFile As New FileInfo(strCurPath & "\errlog.txt")
        Dim FileSize As Long = MyFile.Length
        If FileSize > 1048576 Then File.Delete(strCurPath & "\errlog.txt")
        MyFile = Nothing

    End Sub
    Public Sub WriteToEventsLog(ByVal FlCode As String, ByVal msg As String)

        'check and make the directory if necessary; this is set to look in the application
        'folder, you may wish to place the error log in another location depending upon the
        'the user's role and write access to different areas of the file system
        'If Not System.IO.Directory.Exists(strCurPath & "\Errors\") Then
        'System.IO.Directory.CreateDirectory(strCurPath & "\Errors\")
        'End If

        ' check File size and delete if BIG

        Dim strLogFileName As String = strCurPath + "\Data\FLSet" + FlCode + "log.txt"
        'check the file
        Dim fs As FileStream = New FileStream(strLogFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim s As StreamWriter = New StreamWriter(fs)
        s.Close()
        fs.Close()

        'log it
        Dim fs1 As FileStream = New FileStream(strLogFileName, FileMode.Append, FileAccess.Write)
        Dim s1 As StreamWriter = New StreamWriter(fs1)
        's1.Write(msg & vbCrLf)
        's1.Write("Date/Time: " & DateTime.Now.ToString() + " " + msg + vbCrLf)
        s1.Write(DateTime.Now.ToString() + Space(5) + msg + vbCrLf)
        's1.Write("====================================================================================" & vbCrLf)
        s1.Close()
        fs1.Close()

        Dim MyFile As New FileInfo(strLogFileName)
        Dim FileSize As Long = MyFile.Length
        If FileSize > 1048576 Then File.Delete(strLogFileName)
        MyFile = Nothing
    End Sub
    Public Enum LogType As Integer
        StartApplication = 1
        EndApplication = 2
        EnterSub = 3
        LeaveSub = 4
        Message = 5
        ErrorMessage = 6
    End Enum
    Friend Function GetTimeStampForLogs() As String

        Return Now.ToString("dd/MMM/yyyy hh:mm:ss") 'with hour, minutes and seconds
    End Function
    Friend Function GetTimeStamp() As String
        '---------------Examples of formats --------------
        '  "ddd, dd MMM yyyy"  --> Fri, 15 Dec 2006
        '  "dd_MMM_yyyy"       --> 15_Dec_2006
        '  "ddMMMyyyy"         --> 15Dec2006
        '-------------------------------------------------

        Return Now.ToString("ddMMMyyyy")

    End Function
    Public Sub AddLog(ByVal LogMessage As String, Optional ByVal Type As LogType = LogType.Message)

        'Check if logging needs to be done

        Dim iIndent As Integer = 0

        If (LogMessage Is Nothing) Or (LogMessage.Length < 1) Then
            Exit Sub
        End If

        Select Case Type
            Case LogType.EndApplication
                IndentLevel -= 2
                LogMessage = LogMessage & vbCrLf 'additional break

            Case LogType.EnterSub
                LogMessage = "> Entering " & LogMessage

            Case LogType.LeaveSub
                LogMessage = "< Leaving " & LogMessage
                IndentLevel -= 2

            Case LogType.Message
                'iIndent = 2

            Case LogType.ErrorMessage
                'Modify the message to include error tags
                LogMessage = "ERROR! " & vbCrLf & _
                            "=".PadRight(80, CChar("=")) & vbCrLf & _
                            LogMessage & vbCrLf & _
                            "=".PadRight(80, CChar("=")) & vbCrLf
        End Select

        Dim iPad As Integer = 23 + IndentLevel + iIndent

        m_Log = m_Log & GetTimeStampForLogs().PadRight(iPad) & LogMessage & vbCrLf

        If Type = LogType.StartApplication Or Type = LogType.EnterSub Then
            IndentLevel += 2
        End If

    End Sub
    Public Sub WriteLog()

        'Dim sPath As String = Path.Combine(strCurPath, "\logs\SystemLog_" & GetTimeStamp() & ".log")

        Dim sPath As String = strCurPath + "\Logs\SystemLog_" + GetTimeStamp() + ".log"

        Try
            File.AppendAllText(sPath, m_Log)
            'Flush the logs
            m_Log = vbNullString
        Catch ex As Exception
            ' SetStatusLabel("Failed to write log file")
        End Try

    End Sub
End Module
