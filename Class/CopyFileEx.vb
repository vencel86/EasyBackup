Imports System.IO

Public Class FileCopy

    ' Declare the events that will be rasied by each thread
    Public Event CopyStatus(ByVal sender As Object, ByVal e As BackupEventArgs)
    Public Event CountStatus(ByVal sender As Object, ByVal e As BackupEventArgs)
    Public Event MirrorStatus(ByVal sender As Object, ByVal e As BackupEventArgs)

    Public Event CopyCompleted(ByVal sender As Object, ByVal e As BackupEventArgs)
    Public Event CountCompleted(ByVal sender As Object, ByVal e As BackupEventArgs)
    Public Event MirrorCompleted(ByVal sender As Object, ByVal e As BackupEventArgs)

    Public Event BackupCompleted(ByVal sender As Object, ByVal e As BackupEventArgs)
    Public Event MirrorStarted()

    Public Event LogFileCreated(ByVal sender As Object, ByVal LogFileName As String)

    ' Declares the variables you will use to hold your thread objects.
    Public CopyThread As System.Threading.Thread
    Public CountThread As System.Threading.Thread
    Public MirrorThread As System.Threading.Thread


    ' Class variables for properties
    Private _fromPath As String
    Private _toPath As String
    Private _mirrorCopy As Boolean
    Private _initMsg As String
    Private _quietLog As Boolean
    Private _batchCopy As Boolean

    ' Class variables
    Private _filePath As String
    Private _fileSize As String
    Private _copiedFolders As Long
    Private _copiedFiles As Long
    Private _countedFolders As Long
    Private _countedFiles As Long
    Private _mirroredFolders As Long
    Private _mirroredFiles As Long
    Private _stopNow As Boolean
    Private _lastFolder As String
    Private _lastTypeIsFile As Boolean

#Region "Properties"
    Public Property FromPath() As String

        Get
            Return _fromPath
        End Get
        Set(ByVal value As String)
            _fromPath = value
        End Set

    End Property
    Public Property ToPath() As String

        Get
            Return _toPath
        End Get
        Set(ByVal value As String)
            _toPath = value
        End Set

    End Property
    Public Property MirrorCopy() As Boolean

        Get
            Return _mirrorCopy
        End Get
        Set(ByVal value As Boolean)
            _mirrorCopy = value
        End Set

    End Property
    Public Property QuietLog() As Boolean

        Get
            Return _quietLog
        End Get
        Set(ByVal value As Boolean)
            _quietLog = value
        End Set

    End Property
    Public Property BatchCopy() As Boolean

        Get
            Return _batchCopy
        End Get
        Set(ByVal value As Boolean)
            _batchCopy = value
        End Set

    End Property
    Public Property InitialMessage() As String

        Get
            Return _initMsg
        End Get
        Set(ByVal value As String)
            _initMsg = value
        End Set

    End Property
#End Region
    Public Sub StartCopy()


        ' Exit here if parameters are incorrect
        If Not ValidCopyPaths() Then Exit Sub

        ' Sets the copy and count threads using the AddressOf the subroutine where
        ' the thread will start.
        CopyThread = New System.Threading.Thread(AddressOf Copy)
        CopyThread.IsBackground = True
        CopyThread.Name = "Copy"
        CopyThread.Start()

        ' When started in batch mode there is no need to count
        If Not BatchCopy Then
            CountThread = New System.Threading.Thread(AddressOf Count)
            CountThread.IsBackground = True
            CountThread.Name = "Count"
            CountThread.Start()
        End If

    End Sub
    Private Sub StartMirror()

        ' Start the mirror thread
        MirrorThread = New System.Threading.Thread(AddressOf Mirror)
        MirrorThread.IsBackground = True
        MirrorThread.Name = "Mirror"
        MirrorThread.Start()

    End Sub
    Private Sub Copy()

        ' Create a new DirectoryInfo object for from path.
        Dim dir As New DirectoryInfo(_fromPath)

        ' Call the GetFileSystemInfos method.
        Dim FSinfo As FileSystemInfo() = dir.GetFileSystemInfos

        ' Start copying
        If Not CopyFiles(FSinfo) Then
            ' Something seriously wrong as copy could not ignore the error.
            'Log.Message = "Copy was unable to complete!"
            'Log.WriteLog()
            Exit Sub
        End If

        ' Copy finished okay (but note some files may have failed to copy).
        'Log.Message = "Copy completed. See above for any errors."
        'Log.WriteLog()

        ' Notify client that the copy has finished
        RaiseEvent CopyCompleted(Me, New BackupEventArgs(_filePath, _fileSize, _copiedFiles, _copiedFolders))
        Threading.Thread.Sleep(1)

        ' If mirror copy then start mirroring
        If MirrorCopy Then
            StartMirror()
        Else
            ' Cause this CopyThread to wait until CounThread has finished
            If Not CountThread Is Nothing Then
                If CountThread.IsAlive Then CountThread.Join()
            End If

            ' Raise the completed event
            RaiseEvent BackupCompleted(Me, New BackupEventArgs("", 0, _copiedFiles, _copiedFolders))
            Threading.Thread.Sleep(1)
        End If

    End Sub
    Private Function CopyFiles(ByVal FSInfo As FileSystemInfo()) As Boolean

        If _stopNow Then
            Return True
        End If

        ' Check the FSInfo parameter.
        If FSInfo Is Nothing Then
            'Log.Message = "CopyFiles() FSInfo object invalid. Check source path parameter."
            'Log.WriteLog()
            'Log.Message = "Copy failed."
            'Log.WriteLog()
            Return False
        End If

        ' Iterate through each item.
        Dim i As FileSystemInfo
        For Each i In FSInfo

            Try
                ' Check to see if this is a DirectoryInfo object.
                If TypeOf i Is DirectoryInfo Then
                    ' Cast the object to a DirectoryInfo object.
                    Dim dInfo As DirectoryInfo = CType(i, DirectoryInfo)

                    _copiedFolders = _copiedFolders + 1

                    ' Iterate (recurse) through all sub-directories.
                    CopyFiles(dInfo.GetFileSystemInfos())

                    ' Check to see if this is a FileInfo object.
                ElseIf TypeOf i Is FileInfo Then
                    'save the full path and file name
                    _filePath = i.FullName

                    'Get the copy path name only
                    Dim CopyPath As String = _toPath & Mid(_filePath, Len(_fromPath) + 1, Len(_filePath) - Len(_fromPath) - Len(i.Name))

                    'Create copy path if it does not exist
                    If Not Directory.Exists(CopyPath) Then

                        IO.Directory.CreateDirectory(CopyPath)
                    End If

                    ' Get the to path and _filePath
                    Dim ToFile As String = _toPath & Mid(_filePath, Len(_fromPath) + 1)

                    ' if file exists check if file has been updated since last copy
                    Dim OkayToCopy As Boolean = True
                    If File.Exists(ToFile) Then
                        If File.GetLastWriteTime(_filePath) = File.GetLastWriteTime(ToFile) Then
                            OkayToCopy = False
                        End If
                    End If

                    ' Check flag 
                    If OkayToCopy Then

                        ' Update status info on client
                        Dim fi As New FileInfo(_filePath)
                        _fileSize = Decimal.Round(CDec(fi.Length / 1048576), 2)

                        RaiseEvent CopyStatus(Me, New BackupEventArgs(_filePath, _fileSize, _copiedFiles, _copiedFolders))
                        Threading.Thread.Sleep(1)

                        ' Copy file with overwrite
                        File.Copy(_filePath, ToFile, True)

                        If Not QuietLog Then
                            '    Log.Message = _filePath & ".   Copied."
                            '   Log.WriteLog()
                        End If

                    End If

                    ' Increment copied file count
                    _copiedFiles += 1

                End If
            Catch ex As Exception
                ' Report error but continue processing
                'Log.Message = "Error copying file: " & i.FullName & vbCrLf & vbCrLf & ex.Message.ToString
                'Log.WriteLog()
            End Try

        Next i

        Return True

    End Function
    Private Sub Count()
        Try
            ' Create a new DirectoryInfo object for path.
            Dim dir As New DirectoryInfo(_fromPath)

            ' Call the GetFileSystemInfos method.
            Dim FSinfo As FileSystemInfo() = dir.GetFileSystemInfos

            ' Count folder and files
            If Not CountFiles(FSinfo) Then
                ' Something seriously wrong as copy could not ignore the error.
                'Log.Message = "Count was unable to complete!"
                'Log.WriteLog()
                Exit Sub
            End If

            RaiseEvent CountCompleted(Me, New BackupEventArgs(_filePath, _fileSize, _countedFiles, _countedFolders))
            Threading.Thread.Sleep(1)
        Catch ex As Exception
            'Log.Message = "Error for Count(): " & ex.Message
            'Log.WriteLog()
        End Try
    End Sub
    Private Function CountFiles(ByVal FSInfo As FileSystemInfo()) As Boolean

        If _stopNow Then
            Return True
        End If

        ' Check the FSInfo parameter.
        If FSInfo Is Nothing Then
            'Log.Message = "CountFiles() FSInfo object invalid. Check source path parameter."
            'Log.WriteLog()
            'Log.Message = "Copy failed."
            'Log.WriteLog()
            Return False
        End If

        ' Iterate through each item.
        Dim i As FileSystemInfo
        For Each i In FSInfo

            Try
                ' Check to see if this is a DirectoryInfo object.
                If TypeOf i Is DirectoryInfo Then
                    ' Add one to the directory count.
                    _countedFolders += 1

                    ' Cast the object to a DirectoryInfo object.
                    Dim dInfo As DirectoryInfo = CType(i, DirectoryInfo)

                    ' Iterate (recurse) through all sub-directories.
                    CountFiles(dInfo.GetFileSystemInfos())
                    ' Check to see if this is a FileInfo object.
                ElseIf TypeOf i Is FileInfo Then
                    ' Add one to the file count.
                    _countedFiles += 1

                    'display count for first file in every folder then every 200 - for faster performance
                    RaiseEvent CountStatus(Me, New BackupEventArgs("", 0, _countedFiles, _countedFolders))
                    Threading.Thread.Sleep(1)

                End If
            Catch ex As Exception
                ' Report error but continue processing
                'Log.Message = "Error counting file: " & i.FullName & vbCrLf & vbCrLf & ex.Message.ToString
                'Log.WriteLog()
            End Try

        Next i

        Return True

    End Function
    Private Sub Mirror()

        ' Let the client know the mirror is starting (which also means the copy has finished) 
        RaiseEvent MirrorStarted()

        'Count file and folders in destination path
        If Not BatchCopy Then MirrorCount()

        ' Delete files in destination path if they are not found in the source path
        MirrorDeleteFolders(_toPath)

        ' Copy finished okay (but note some files may have failed to copy).
        'Log.Message = "Mirror copy completed. See above for any errors."
        'Log.WriteLog()

        ' Notify client that the copy has finished
        RaiseEvent MirrorCompleted(Me, New BackupEventArgs("", 0, _mirroredFiles, _mirroredFolders))
        Threading.Thread.Sleep(1)

        ' Raise the completed event
        RaiseEvent BackupCompleted(Me, New BackupEventArgs("", 0, _mirroredFiles, _mirroredFolders))
        Threading.Thread.Sleep(1)

    End Sub
    Private Function MirrorCount() As Boolean

        Try
            ' Create a new DirectoryInfo object for path.
            Dim dir As New DirectoryInfo(_toPath)

            ' Call the GetFileSystemInfos method.
            Dim FSinfo As FileSystemInfo() = dir.GetFileSystemInfos

            ' Count folder and files
            If Not CountFiles(FSinfo) Then
                ' Something seriously wrong as copy could not ignore the error.
                'Log.Message = "MirrorCount was unable to complete!"
                'Log.WriteLog()
                Exit Function
            End If

            RaiseEvent CountCompleted(Me, New BackupEventArgs(_filePath, _fileSize, _countedFiles, _countedFolders))
            Threading.Thread.Sleep(1)
        Catch ex As Exception
            'Log.Message = "Error for MirrorCount(): " & ex.Message
            'Log.WriteLog()

        End Try

    End Function
    Private Sub MirrorDeleteFolders(ByVal StartFolder As String)

        If _stopNow Then
            Exit Sub
        End If

        ' This subroutine will recursively delete all folders and files for the StartFolder path.
        Dim Folder As DirectoryInfo = New DirectoryInfo(StartFolder)
        Dim SubFolders() As DirectoryInfo = Folder.GetDirectories()
        Dim Files() As FileInfo = Folder.GetFiles()

        Try
            ' Recurse to DeleteFolders for every sub folder, and their sub folders, and their sub folders, and so on... 
            For Each SubFolder As DirectoryInfo In SubFolders

                MirrorDeleteFolders(SubFolder.FullName)

            Next

            ' When no more sub folders in the node then delete read the files in the current folder 
            For Each FileItem As FileInfo In Files

                'Get the source path full path name
                Dim CurrentFile As String = _fromPath & Mid(FileItem.FullName, Len(_toPath) + 1, Len(FileItem.FullName) - Len(_toPath))

                ' If the current file does not exist in the source path then delete it from the destination path 
                ' to make the source and destination path match (mirror).
                If Not File.Exists(CurrentFile) Then
                    FileItem.Attributes = FileAttributes.Normal
                    FileItem.Delete()

                    If Not QuietLog Then
                        '    Log.Message = FileItem.FullName & ".   File deleted by mirror copy."
                        '   Log.WriteLog()
                    End If
                End If

                ' Notify client of current filecount
                RaiseEvent MirrorStatus(Me, New BackupEventArgs(_filePath, 0, _mirroredFiles, _mirroredFolders))

                ' Increment copied file count
                _mirroredFiles += 1

            Next

            ' Check that the current folder is not the root folder. 
            If Folder.FullName <> _toPath Then

                ' Set the current folder to the source path
                Dim CurrentFolder As String = _fromPath & Mid(Folder.FullName, Len(_toPath) + 1, Len(Folder.FullName) - Len(_toPath))

                ' If CurrentFolder does not exist in the source path then delete it.
                If Not Directory.Exists(CurrentFolder) Then
                    Folder.Attributes = FileAttributes.Normal
                    Folder.Delete()

                    If Not QuietLog Then
                        'Log.Message = Folder.FullName & ".    Folder deleted by mirror copy."
                        'Log.WriteLog()
                    End If
                End If

            End If

            _mirroredFolders += 1

        Catch ex As Exception
            'Log.Message = "DeleteDir failed. Path is " & StartFolder & ". Error is: " & ex.Message
            'Log.WriteLog()
        End Try

    End Sub
    Public Sub DeleteFolders(ByVal StartFolder As String)
        ' DeleteFolders is not in use but is left here as a generic sub that will delete ALL folders and 
        ' files for a specified path.

        ' This subroutine will recursively delete all folders and files for the StartFolder path.
        Dim Folder As DirectoryInfo = New DirectoryInfo(StartFolder)
        Dim SubFolders() As DirectoryInfo = Folder.GetDirectories()
        Dim Files() As FileInfo = Folder.GetFiles()

        Try
            ' Recurse to DeleteFolders for every sub folder, and their sub folders, and their sub folders, and so on... 
            For Each SubFolder As DirectoryInfo In SubFolders
                DeleteFolders(SubFolder.FullName)
            Next

            ' When no more sub folders in the node then delete all files in the current folder 
            For Each File As FileInfo In Files
                File.Delete()
            Next

            ' Delete the current folder
            Folder.Delete()

        Catch ex As Exception
            'Log.Message = "DeleteFolders failed. Path is " & StartFolder & ". Error is: " & ex.Message
            'Log.WriteLog()
        End Try

    End Sub
    Public Sub StopThreads()

        _stopNow = True

    End Sub
    Private Function ValidCopyPaths() As Boolean

        ' Test "from" path
        If Not CheckPath(FromPath) Then
            Return False
        End If

        ' Test "to" path
        If Not CheckPath(ToPath) Then
            If Not CreatePath(ToPath) Then
                Return False
            End If
        End If

        Return (True)

    End Function
    Private Function CheckPath(ByVal Path As String) As Boolean

        Try
            ' If this directory does not exist, a DirectoryNotFoundException is thrown.
            Directory.GetDirectories(Path)
        Catch ex As System.IO.DirectoryNotFoundException

            ' Let the user know that the directory did not exist.
            'Log.Message = "Directory not found: " + ex.Message
            Return False
        Catch ex As Exception
            'Log.Message = ex.Message
            'Log.WriteLog()
            Return False
        End Try

        Return True

    End Function
    Private Function CreatePath(ByVal Path As String) As Boolean

        Try
            Directory.CreateDirectory(Path)
        Catch ex As Exception
            'Log.Message = ex.Message
            'Log.WriteLog()
            Return False
        End Try

        Return True

    End Function
    Public Sub WaitForThreads()

        Dim ThreadsRunning As Boolean = False

        Do While True

            ThreadsRunning = False

            If Not CopyThread Is Nothing Then
                If CopyThread.IsAlive Then
                    ThreadsRunning = True
                End If
            End If
            If Not CountThread Is Nothing Then
                If CountThread.IsAlive Then
                    ThreadsRunning = True
                End If
            End If
            If Not MirrorThread Is Nothing Then
                If MirrorThread.IsAlive Then
                    ThreadsRunning = True
                End If
            End If

            If Not ThreadsRunning Then Exit Do

            Threading.Thread.Sleep(5000)
        Loop



    End Sub

End Class
Public Class BackupEventArgs
    Inherits EventArgs

    Private _folderCount As Long
    Public Property FolderCount() As Long
        Get
            Return _folderCount
        End Get
        Set(ByVal value As Long)
            _folderCount = value
        End Set
    End Property

    Private _fileCount As Long
    Public Property FileCount() As Long
        Get
            Return _fileCount
        End Get
        Set(ByVal value As Long)
            _fileCount = value
        End Set
    End Property
    Private _filePath As String
    Public Property FilePath() As String
        Get
            Return _filePath
        End Get
        Set(ByVal value As String)
            _filePath = value
        End Set
    End Property

    Private _filesize As String
    Public Property FileSize() As Long
        Get
            Return _filesize
        End Get
        Set(ByVal value As Long)
            _filesize = value
        End Set
    End Property

    Public Sub New(ByVal FilePathV As String, ByVal FileSizeV As Long, ByVal FileCountV As Long, ByVal FolderCountV As Long)
        FilePath = FilePathV
        FileSize = FileSizeV
        FileCount = FileCountV
        FolderCount = FolderCountV
    End Sub
    Public Sub New()

    End Sub
End Class