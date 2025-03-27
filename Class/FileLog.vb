Imports System.Text
Imports System.Globalization

<CLSCompliant(True)> _
Public Class FileLog

    Private _append As Boolean
    Private _title As String
    Private _location As String
    Private _fileName As String
    Private _indentSize As Integer

#Region " Properties "

    ''' <summary>
    ''' Gets the title of the log file that leads the message(s).
    ''' </summary>
    Public ReadOnly Property Title() As String
        Get
            Return Me._title
        End Get
    End Property

    ''' <summary>
    ''' Gets the location (directory) for the log file.
    ''' </summary>
    Public ReadOnly Property Location() As String
        Get
            Return Me._location
        End Get
    End Property

    ''' <summary>
    ''' Gets the log file's full name.
    ''' </summary>
    Public ReadOnly Property FileName() As String
        Get
            Return Me._fileName
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the number of spaces in an indent for InnerException.
    ''' </summary>
    Public Property IndentSize() As Integer
        Get
            Return Me._indentSize
        End Get
        Set(ByVal value As Integer)
            Me._indentSize = value
        End Set
    End Property

#End Region

#Region " Methods "

    ''' <param name="title">The title of the log file that leads the message(s).</param>
    ''' <param name="location">The location (directory) for the log file.</param>
    <DebuggerHidden()> _
    Sub New(ByVal title As String, ByVal location As String)
        If location Is Nothing AndAlso location = String.Empty Then
            Throw New ArgumentNullException("location")
        Else
            Me._title = title
        End If
        If title Is Nothing AndAlso title = String.Empty Then
            Throw New ArgumentNullException("title")
        Else
            Me._location = location
            Me._fileName = Me._location & "\" & Me._title.Replace(" ", String.Empty) & ".log"
        End If
        Me._indentSize = 3
    End Sub

    ''' <summary>
    ''' Writes an exception information to the application’s log file.
    ''' </summary>
    ''' <param name="ex">The exception to log.</param>
    ''' <param name="severity">The type of message. By default, System.Diagnostics.TraceEventType.Error.</param>
    <DebuggerHidden()> _
    Public Sub WriteException(ByVal ex As Exception, ByVal severity As TraceEventType)
        If ex IsNot Nothing Then
            On Error Resume Next
            Dim sb As New StringBuilder
            sb.AppendLine(FileLog.GetSystemInfoText)
            sb.AppendLine(Me.GetExText(ex, 0))
            If Not [Enum].IsDefined(GetType(TraceEventType), severity) Then
                severity = TraceEventType.Error
            End If
            Me.WriteEntry(sb.ToString, severity)
        End If
    End Sub

    ''' <summary>
    ''' Writes a message to the applications log file.
    ''' </summary>
    ''' <param name="message">The message to log. If message is Nothing, an empty string is used.</param>
    ''' <param name="severity">The type of message. By default, System.Diagnostics.TraceEventType.Information.</param>
    <DebuggerHidden()> _
    Public Sub WriteEntry(ByVal message As String, ByVal severity As TraceEventType)
        If message Is Nothing Then
            message = String.Empty
        End If
        If Not [Enum].IsDefined(GetType(TraceEventType), severity) Then
            severity = TraceEventType.Information
        End If
        Using sw As New IO.StreamWriter(Me._fileName, Me._append, System.Text.Encoding.UTF8)
            Dim str As String = Me._title & "   " & severity.ToString ' & "   " & severity
            sw.WriteLine(str)
            sw.WriteLine(New String("="c, str.Length))
            sw.WriteLine(message)
            Me._append = True
        End Using
    End Sub

    <DebuggerHidden()> _
    Private Shared Function GetSystemInfoText() As String
        Dim sb As New StringBuilder
        'sb.AppendLine()
        sb.AppendLine("System")
        sb.AppendLine("---------")
        sb.AppendFormat("{0,-12}", "Utc Date:")
        sb.AppendLine(Now.ToString)
        sb.AppendFormat("{0,-12}", "Culture:")
        sb.Append(My.Computer.Info.InstalledUICulture.EnglishName)
        sb.AppendLine("; " & My.Computer.Info.InstalledUICulture.Name)
        'sb.AppendFormat("{0,-12}", "OS:")
        'sb.Append(My.Computer.Info.OSFullName)
        'sb.Append("; " & My.Computer.Info.OSPlatform)
        'sb.Append("; " & My.Computer.Info.OSVersion)
        'sb.Append("; " & Environment.OSVersion.ServicePack)
        Return sb.ToString
    End Function

    <DebuggerHidden()> _
    Private Function GetExText(ByVal ex As Exception, ByVal iSize As Integer) As String
        Dim indent As String = String.Empty
        If iSize > 0 Then
            indent = New String(" "c, iSize)
        End If
        Dim sb As New StringBuilder
        'sb.AppendLine()
        sb.Append(indent)
        sb.AppendLine("Exception")
        sb.Append(indent)
        sb.AppendLine("---------")
        sb.Append(indent)
        sb.AppendLine(FileLog.GetFormattedText("Type:", ex.GetType.ToString, iSize + 12))
        sb.Append(indent)
        sb.AppendLine(FileLog.GetFormattedText("Source:", ex.Source, iSize + 12))
        sb.Append(indent)
        sb.AppendLine(FileLog.GetFormattedText("Assembly:", ex.TargetSite.DeclaringType.Assembly.FullName, iSize + 12))
        sb.Append(indent)
        sb.AppendLine(FileLog.GetFormattedText("Message:", ex.Message, iSize + 12))
        sb.AppendLine()
        sb.Append(indent)
        sb.AppendLine(FileLog.GetFormattedText("Trace:", ex.StackTrace, iSize + 12))
        If Not ex.InnerException Is Nothing Then
            sb.Append(Me.GetExText(ex.InnerException, iSize + Me._indentSize))
        End If
        Return sb.ToString
    End Function

    <DebuggerHidden()> _
    Private Shared Function GetFormattedText(ByVal leadingStr As String, ByVal str As String, ByVal iSize As Integer) As String
        Dim indent As String = String.Empty
        If iSize > 0 Then
            indent = New String(" "c, iSize)
        End If
        Dim sb As New StringBuilder
        Dim lines() As String = str.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
        If lines.Length > 0 Then
            If leadingStr <> String.Empty Then
                sb.AppendFormat("{0,-12}", leadingStr)
                sb.Append(lines(0).Trim())
            Else
                sb.Append(indent & lines(0).Trim)
            End If
            For i As Integer = 1 To lines.Length - 1
                sb.Append(Environment.NewLine & indent & lines(i).Trim)
            Next
        End If
        Return sb.ToString
    End Function

#End Region

End Class