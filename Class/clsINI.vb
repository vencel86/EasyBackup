Public Class clsINI

    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
        (ByVal lpApplicationName As String, _
         ByVal lpKeyName As String, _
         ByVal lpDefault As String, _
         ByVal lpReturnedString As System.Text.StringBuilder, _
         ByVal nSize As Integer, _
         ByVal lpFileName As String) _
     As Integer

    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
        (ByVal lpApplicationName As String, _
         ByVal lpKeyName As String, _
         ByVal lpString As String, _
         ByVal lpFileName As String) _
    As Integer

    Public Property Path As String

    ''' <summary>
    ''' IniFile Constructor
    ''' </summary>
    ''' <param name="IniPath">The path to the INI file.</param>
    Public Sub New(ByVal IniPath As String)
        _Path = IniPath
    End Sub

    ''' <summary>
    ''' Read value from INI file
    ''' </summary>
    ''' <param name="section">The section of the file to look in</param>
    ''' <param name="key">The key in the section to look for</param>
    Public Function ReadValue(ByVal section As String, ByVal key As String) As String
        Dim sb As New System.Text.StringBuilder(255)
        Dim i = GetPrivateProfileString(section, key, "", sb, 255, Path)
        Return sb.ToString()
    End Function

    ''' <summary>
    ''' Write value to INI file
    ''' </summary>
    ''' <param name="section">The section of the file to write in</param>
    ''' <param name="key">The key in the section to write</param>
    ''' <param name="value">The value to write for the key</param>
    Public Sub WriteValue(ByVal section As String, ByVal key As String, ByVal value As String)
        WritePrivateProfileString(section, key, value, Path)
    End Sub
    Public Function GetSectionNames(ByVal fileName As String) As String()
        Dim sectionName As String = String.Empty
        Dim array As String()
        Dim cnt As Integer = 0
        Using reader As New System.IO.StreamReader(fileName)
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine
                If line.StartsWith("[") AndAlso line.EndsWith("]") Then
                    sectionName = line.Substring(1, line.Length - 2)

                    ReDim Preserve array(cnt)
                    array(cnt) = sectionName
                    cnt = cnt + 1
                ElseIf line.StartsWith(";") Then
                ElseIf line.Contains("=") Then
                Dim idx As Integer = line.IndexOf("="c)
                    'Item(sectionName).Item(line.Substring(0, idx)) = line.Substring(idx + 1, line.Length - idx - 1)
                End If
            End While
        End Using
        Return array
    End Function
End Class