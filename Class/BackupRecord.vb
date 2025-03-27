Public Class BackupRecord
    '[Sch]
    Public Property TID As String
    Public Property TName As String
    Public Property DSize As Double
    Public Property TStatus As Boolean
    Public Property TType As String
    Public Property TDate As String
    Public Property TAtEach As Integer
    Public Property TEvery As Integer
    Public Property TElement As Integer

    Public Property T0 As String
    Public Property T1 As String
    Public Property T2 As String
    Public Property T3 As String
    Public Property T4 As String

    Public Property WeekDays As String
    '[Dest]
    Public Property Zip As Boolean
    Public Property ZipEnc As String
    Public Property ZipEncP As String
    Public Property LocalBack As Boolean
    Public Property DestDirT As Integer
    Public Property DestDirPath() As String
    Public Property Other As String
    Public Property FTPinfo As FTPInfo = New FTPInfo
    Public Property WebDavinfo As WebDavInfo = New WebDavInfo

    '[Source]
    Public Property SourceDirPath() As String
    Public Property SourceDirT As Integer
    Public Property DirFilter As String
    Public Property DirFilterT As Integer
    Public Property BMode As String
    '[CE]
    Public Property EC As Integer
    Public Property ET As String
    '[TEvent]
    Public Property TStart As Boolean
    Public Property TZip As Boolean
    Public Property TDir As Boolean
    Public Property TDone As String

End Class
