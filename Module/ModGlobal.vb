Imports IntelliLock.Licensing
Module ModGlobal
    Public dtEventDate As Boolean = False
    Public strCurPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Easy Backup"
    Public strLang As Char = "E"
    Public intOEM As Byte = 0 'OEM Version name change
    Private fLog As New FileLog(My.Application.Info.Title, My.Computer.FileSystem.SpecialDirectories.Desktop)
    Private Const InternetConnectionIsConfigured As Integer = &H40S
    Private Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpdwFlags As Integer, ByVal dwReserved As Integer) As Integer
    Public ReadOnly Property Log() As FileLog
        Get
            Return fLog
        End Get
    End Property

    Public Function boolFilterCompareExclude(strSource As String) As Boolean
        '-----Exclude List-------------'
        For i = 0 To MainForm.lbFilterE.Items.Count - 1
            If MainForm.lbFilterE.Items(i).ToString.Contains("*.") Then
                Dim dotPosition As Integer = strSource.LastIndexOf(".")
                '  MsgBox(MainForm.lbFilterE.Items(i).ToString.Replace("*.", ""))
                If strSource.Substring(dotPosition + 1) = MainForm.lbFilterE.Items(i).ToString.Replace("*.", "") Then
                    Return True
                End If
            Else
                If strSource.Contains(MainForm.lbFilterE.Items(i).ToString) = True Then Return True
            End If
        Next
        Return False
    End Function
    Public Function boolFilterCompareInclude(strSource As String) As Boolean
        '-----Include List-------------'
        For i = 0 To MainForm.lbFilterI.Items.Count - 1
            If MainForm.lbFilterI.Items(i).ToString.Contains("*.") Then
                Dim dotPosition As Integer = strSource.LastIndexOf(".")
                'MsgBox(MainForm.lbFilterI.Items(i).ToString.Replace("*.", ""))
                If strSource.Substring(dotPosition + 1) = MainForm.lbFilterI.Items(i).ToString.Replace("*.", "") Then
                    Return True
                End If

            Else
                If strSource.Contains(MainForm.lbFilterI.Items(i).ToString) = True Then Continue For
            End If
        Next
        '----------include list ends-------------'
        Return False
    End Function
    Public Function DirectorySize(ByVal dInfo As System.IO.DirectoryInfo, ByVal includeSubDir As Boolean) As Long
        Try
            ' Enumerate all the files
            Dim totalSize As Long = dInfo.EnumerateFiles() _
              .Sum(Function(file) file.Length)

            ' If Subdirectories are to be included
            If includeSubDir Then
                ' Enumerate all sub-directories
                totalSize += dInfo.EnumerateDirectories() _
                 .Sum(Function(dir) DirectorySize(dir, True))
            End If
            Return totalSize
        Catch ex As Exception
            'MsgBox(Err.Description)
            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")

            Call errHandlerForm(ex)
            Return 0
        End Try
    End Function
    Public Function SizeToMBStr(ByVal lngParam As Long) As String
        Try

            Dim strTmp As String = ""

            Dim oneByte As Integer = 1
            Dim kiloByte As Integer = 1024
            Dim megaByte As Integer = 1048576
            Dim gigaByte As Integer = 1073741824
            Dim terraByte As Long = 1099511627776
            Dim pettaByte As Long = 1125899906842624


            Select Case CLng(lngParam)
                Case 0 To kiloByte - 1
                    If ((lngParam / oneByte) >= 1000) = False Then
                        strTmp = CStr((lngParam) / 1) + " Bytes"
                    Else : strTmp = "1,00 KB" : End If

                Case kiloByte To megaByte - 1
                    If ((lngParam / kiloByte) >= 1000) = False Then
                        strTmp = CStr(FormatNumber((lngParam) / kiloByte, 2)) + " KB"
                    Else : strTmp = "1,00 MB" : End If

                Case megaByte To gigaByte - 1
                    If ((lngParam / megaByte) >= 1000) = False Then
                        strTmp = CStr(FormatNumber(lngParam / megaByte, 2)) + " MB"
                    Else : strTmp = "1,00 GB" : End If

                Case gigaByte To terraByte - 1
                    If ((lngParam / gigaByte) >= 1000) = False Then
                        strTmp = CStr(FormatNumber(lngParam / gigaByte, 2)) + " GB"
                    Else : strTmp = "1,00 TB" : End If

                Case terraByte To pettaByte - 1
                    If ((lngParam / terraByte) >= 1000) = False Then
                        strTmp = CStr(FormatNumber(lngParam / terraByte, 2)) + " TB"
                    Else : strTmp = "1,00 PB" : End If
            End Select
            Return strTmp
        Catch ex As Exception

            'Log.WriteException(ex, TraceEventType.Error)
            'MsgBox("Error logged.", MsgBoxStyle.Information, "Error")
            Call errHandlerForm(ex)
            Return 0
        End Try
    End Function
    Public Function CheckForInternetConnection() As Boolean

        'Try
        'Using client = New System.Net.WebClient()
        'Using stream = client.OpenRead("http://www.google.com")
        'Return True
        'End Using
        '   End Using
        'Catch
        'Return False
        'End Try
        ' Returns True if connection is available 
        ' Replace www.yoursite.com with a site that
        ' is guaranteed to be online - perhaps your 
        ' corporate site, or microsoft.com
        If InternetGetConnectedState(InternetConnectionIsConfigured, 0) = 0 Then
            Return False
        ElseIf InternetGetConnectedState(InternetConnectionIsConfigured, 0) = 1 Then
            Return True
        End If
    End Function
    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function Event_Done() As Boolean
        Try
            'remove these two lines for licensing
            dtEventDate = True
            Return True
            '---------
            If IO.File.Exists(Application.StartupPath & "\easybackup.license") = True Then
                If EvaluationMonitor.CurrentLicense.LicenseStatus <> IntelliLock.Licensing.LicenseStatus.Licensed Then
                    dtEventDate = False
                    'MsgBox("License information is invalid!", MsgBoxStyle.Information, "Information")
                    Return False
                Else
                    If HardwareID.GetHardwareID(True, True, True, True, True, False) = EvaluationMonitor.CurrentLicense.HardwareID Then
                        dtEventDate = True
                    Else
                        dtEventDate = False
                    End If
                    Return dtEventDate
                End If
                Return False
            Else
                Return False
            End If
        Catch ex As Exception
            Log.WriteException(ex, TraceEventType.Error)
            Return False
        End Try
    End Function
    Public Function CheckIfFtpFileExists(ByVal fileUri As String, ByVal strU As String, ByVal strP As String) As Boolean
        Dim request As System.Net.FtpWebRequest = System.Net.WebRequest.Create(fileUri)
        request.Credentials = New System.Net.NetworkCredential(strU, strP)
        request.Method = System.Net.WebRequestMethods.Ftp.GetFileSize
        Try
            Dim response As System.Net.FtpWebResponse = request.GetResponse()
            ' THE FILE EXISTS
        Catch ex As System.Net.WebException
            Dim response As System.Net.FtpWebResponse = ex.Response
            If System.Net.FtpStatusCode.ActionNotTakenFileUnavailable = response.StatusCode Then
                ' MsgBox(response.StatusDescription)
                Return False
            End If

        End Try
        Return True
    End Function
    Public Function FTPGetCreationTime(ByVal fileUri As String, ByVal strU As String, ByVal strP As String) As String
        Dim request As System.Net.FtpWebRequest = System.Net.WebRequest.Create(fileUri)
        request.Credentials = New System.Net.NetworkCredential(strU, strP)
        request.Method = System.Net.WebRequestMethods.Ftp.GetDateTimestamp
        Try
            Dim response As System.Net.FtpWebResponse = request.GetResponse()
            Return response.LastModified.ToString()
        Catch ex As System.Net.WebException
            ' MsgBox(response.StatusDescription)
            Return "0"
        End Try
    End Function
    Public Function DeleteFTPFIle(ByVal fileUri As String, ByVal strU As String, ByVal strP As String) As Boolean
        Dim ftp As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(fileUri), System.Net.FtpWebRequest)
        Try
            ftp.Credentials = New System.Net.NetworkCredential(strU, strP)
            ftp.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            Dim ftpResponse As System.Net.FtpWebResponse = CType(ftp.GetResponse(), System.Net.FtpWebResponse)
            ftpResponse = ftp.GetResponse()
            ftpResponse.Close()
            Return True
        Catch ex As Exception
            'MsgBox(Err.Description)
            Return False
        End Try
    End Function
    Public Sub errHandlerForm(ByRef errText As Exception)
        Dim CrashReport As New ErrorHandlerForm
        CrashReport.ErrorText(errText)
        CrashReport.ShowDialog()
    End Sub
End Module
