Imports System.Data
Imports System.IO
Public Class BackupData
    Private Shared _Instance As BackupData
    Private UserFile As String = strCurPath + "\Data\BackupData.db"
    Public BackupList As List(Of BackupRecord) = New List(Of BackupRecord)()
    Public BackupTable As DataTable = New DataTable()

    Public Shared Property Instance() As BackupData
        Get
            If BackupData._Instance Is Nothing Then
                BackupData._Instance = New BackupData()
            End If
            Return BackupData._Instance
        End Get
        Set(ByVal value As BackupData)
            BackupData._Instance = value
        End Set
    End Property
    Private Sub Init()
        Me.BackupTable.Reset()
        Me.BackupTable.Columns.Add("TID", GetType(Integer))
        Me.BackupTable.Columns.Add("TName", GetType(String))
        Me.BackupTable.Columns.Add("DSize", GetType(Double))
        Me.BackupTable.Columns.Add("TStatus", GetType(Boolean))
        Me.BackupTable.Columns.Add("TType", GetType(String))
        Me.BackupTable.Columns.Add("TDate", GetType(String))
        Me.BackupTable.Columns.Add("TAtEach", GetType(Integer))
        Me.BackupTable.Columns.Add("TEvery", GetType(Integer))
        Me.BackupTable.Columns.Add("TElement", GetType(Integer))
        Me.BackupTable.Columns.Add("T0", GetType(String))
        Me.BackupTable.Columns.Add("T1", GetType(String))
        Me.BackupTable.Columns.Add("T2", GetType(String))
        Me.BackupTable.Columns.Add("T3", GetType(String))
        Me.BackupTable.Columns.Add("T4", GetType(String))

        Me.BackupTable.Columns.Add("WeekDays", GetType(String))

        Me.BackupTable.Columns.Add("Zip", GetType(Boolean))
        Me.BackupTable.Columns.Add("ZipEnc", GetType(String))
        Me.BackupTable.Columns.Add("ZipEncP", GetType(String))
        Me.BackupTable.Columns.Add("LocalBack", GetType(Boolean))
        Me.BackupTable.Columns.Add("DestDirPath", GetType(String))
        Me.BackupTable.Columns.Add("DestDirT", GetType(String))
        Me.BackupTable.Columns.Add("Other", GetType(String))
        Me.BackupTable.Columns.Add("FTPS", GetType(String))
        Me.BackupTable.Columns.Add("FTPSPort", GetType(Integer))
        Me.BackupTable.Columns.Add("FTPU", GetType(String))
        Me.BackupTable.Columns.Add("FTPP", GetType(String))

        Me.BackupTable.Columns.Add("SourceDirPath", GetType(String))
        Me.BackupTable.Columns.Add("SourceDirT", GetType(Integer))
        Me.BackupTable.Columns.Add("DirFilter", GetType(String))
        Me.BackupTable.Columns.Add("DirFilterT", GetType(Integer))
        Me.BackupTable.Columns.Add("BMode", GetType(String))

        Me.BackupTable.Columns.Add("EC", GetType(Integer))
        Me.BackupTable.Columns.Add("ET", GetType(String))

        Me.BackupTable.Columns.Add("TDir", GetType(Boolean))
        Me.BackupTable.Columns.Add("TStart", GetType(Boolean))
        Me.BackupTable.Columns.Add("TZip", GetType(Boolean))
        Me.BackupTable.Columns.Add("TDone", GetType(String))

        'Me.BackupTable.PrimaryKey = New DataColumn() {Me.BackupTable.Columns("TDiaMax")}
    End Sub
    Public Function ReadTMSettings() As List(Of BackupRecord)
        Try
            Me.Init()
            Dim iniFile As New clsINI(Me.UserFile)
            Dim sectionNames As String()
            If IO.File.Exists(Me.UserFile) = False Then Return BackupList
            Try
                sectionNames = iniFile.GetSectionNames(Me.UserFile)
            Catch ex As Exception
                Return BackupList
            End Try

            Me.BackupList.Clear()
            Me.BackupTable.Rows.Clear()
            If sectionNames Is Nothing Then Return BackupList
            For i As Integer = sectionNames.GetLowerBound(0) To sectionNames.GetUpperBound(0)
                Dim dataRow As DataRow = Me.BackupTable.NewRow()
                Dim tmPara1 As BackupRecord = New BackupRecord()
                dataRow("TID") = Double.Parse(iniFile.ReadValue(sectionNames(i), "TID")) 'i + 1 
                dataRow("TName") = iniFile.ReadValue(sectionNames(i), "TName")
                dataRow("DSize") = Double.Parse(iniFile.ReadValue(sectionNames(i), "DSize"))
                dataRow("TStatus") = Boolean.Parse(iniFile.ReadValue(sectionNames(i), "TStatus")) & ""
                dataRow("TType") = iniFile.ReadValue(sectionNames(i), "TType")
                dataRow("TDate") = If(iniFile.ReadValue(sectionNames(i), "TAtEach") <> String.Empty, iniFile.ReadValue(sectionNames(i), "TDate"), String.Empty)
                dataRow("TAtEach") = If(iniFile.ReadValue(sectionNames(i), "TAtEach") <> String.Empty, Integer.Parse(iniFile.ReadValue(sectionNames(i), "TAtEach")), 0)
                dataRow("TEvery") = If(iniFile.ReadValue(sectionNames(i), "TEvery") <> String.Empty, Integer.Parse(iniFile.ReadValue(sectionNames(i), "TEvery")), 0)
                dataRow("TElement") = If(iniFile.ReadValue(sectionNames(i), "TElement") <> String.Empty, Integer.Parse(iniFile.ReadValue(sectionNames(i), "TElement")), 0)
                dataRow("T0") = If(iniFile.ReadValue(sectionNames(i), "T0") <> String.Empty, iniFile.ReadValue(sectionNames(i), "T0"), String.Empty)
                dataRow("T1") = If(iniFile.ReadValue(sectionNames(i), "T1") <> String.Empty, iniFile.ReadValue(sectionNames(i), "T1"), String.Empty)
                dataRow("T2") = If(iniFile.ReadValue(sectionNames(i), "T2") <> String.Empty, iniFile.ReadValue(sectionNames(i), "T2"), String.Empty)
                dataRow("T3") = If(iniFile.ReadValue(sectionNames(i), "T3") <> String.Empty, iniFile.ReadValue(sectionNames(i), "T3"), String.Empty)
                dataRow("T4") = If(iniFile.ReadValue(sectionNames(i), "T4") <> String.Empty, iniFile.ReadValue(sectionNames(i), "T4"), String.Empty)
                dataRow("WeekDays") = If(iniFile.ReadValue(sectionNames(i), "WeekDays") <> String.Empty, iniFile.ReadValue(sectionNames(i), "WeekDays"), String.Empty)

                dataRow("Zip") = If(iniFile.ReadValue(sectionNames(i), "Zip") <> String.Empty, Boolean.Parse(iniFile.ReadValue(sectionNames(i), "Zip")), False)
                dataRow("ZipEnc") = If(iniFile.ReadValue(sectionNames(i), "ZipEnc") <> String.Empty, iniFile.ReadValue(sectionNames(i), "ZipEnc"), String.Empty)
                dataRow("ZipEncP") = If(iniFile.ReadValue(sectionNames(i), "ZipEncP") <> String.Empty, iniFile.ReadValue(sectionNames(i), "ZipEncP"), String.Empty)
                dataRow("LocalBack") = If(iniFile.ReadValue(sectionNames(i), "LocalBack") <> String.Empty, Boolean.Parse(iniFile.ReadValue(sectionNames(i), "LocalBack")), False)
                dataRow("DestDirPath") = If(iniFile.ReadValue(sectionNames(i), "DestDirPath") <> String.Empty, iniFile.ReadValue(sectionNames(i), "DestDirPath"), String.Empty)
                dataRow("DestDirT") = If(iniFile.ReadValue(sectionNames(i), "DestDirT") <> String.Empty, iniFile.ReadValue(sectionNames(i), "DestDirT"), String.Empty)


                dataRow("Other") = If(iniFile.ReadValue(sectionNames(i), "Other") <> String.Empty, iniFile.ReadValue(sectionNames(i), "Other"), String.Empty)
                dataRow("FTPS") = If(iniFile.ReadValue(sectionNames(i), "FTPS") <> String.Empty, iniFile.ReadValue(sectionNames(i), "FTPS"), String.Empty)
                dataRow("FTPSPort") = If(iniFile.ReadValue(sectionNames(i), "FTPSPort") <> String.Empty, Integer.Parse(iniFile.ReadValue(sectionNames(i), "FTPSPort")), 0)
                dataRow("FTPU") = If(iniFile.ReadValue(sectionNames(i), "FTPU") <> String.Empty, iniFile.ReadValue(sectionNames(i), "FTPU"), String.Empty)
                dataRow("FTPP") = If(iniFile.ReadValue(sectionNames(i), "FTPP") <> String.Empty, iniFile.ReadValue(sectionNames(i), "FTPP"), String.Empty)

                dataRow("SourceDirT") = If(iniFile.ReadValue(sectionNames(i), "SourceDirT") <> String.Empty, Integer.Parse(iniFile.ReadValue(sectionNames(i), "SourceDirT")), 0)
                dataRow("SourceDirPath") = If(iniFile.ReadValue(sectionNames(i), "SourceDirPath") <> String.Empty, iniFile.ReadValue(sectionNames(i), "SourceDirPath"), String.Empty)
                dataRow("DirFilter") = If(iniFile.ReadValue(sectionNames(i), "DirFilter") <> String.Empty, (iniFile.ReadValue(sectionNames(i), "DirFilter")), String.Empty)
                dataRow("DirFilterT") = If(iniFile.ReadValue(sectionNames(i), "DirFilterT") <> String.Empty, Integer.Parse(iniFile.ReadValue(sectionNames(i), "DirFilterT")), 0)

                dataRow("BMode") = If(iniFile.ReadValue(sectionNames(i), "BMode") <> String.Empty, iniFile.ReadValue(sectionNames(i), "BMode"), String.Empty)

                dataRow("EC") = If(iniFile.ReadValue(sectionNames(i), "EC") <> String.Empty, Integer.Parse(iniFile.ReadValue(sectionNames(i), "EC")), 0)
                dataRow("ET") = If(iniFile.ReadValue(sectionNames(i), "ET") <> String.Empty, Integer.Parse(iniFile.ReadValue(sectionNames(i), "ET")), 0)

                dataRow("TStart") = If(iniFile.ReadValue(sectionNames(i), "TStart") <> String.Empty, Boolean.Parse(iniFile.ReadValue(sectionNames(i), "TStart")), False)
                dataRow("TZip") = If(iniFile.ReadValue(sectionNames(i), "TZip") <> String.Empty, Boolean.Parse(iniFile.ReadValue(sectionNames(i), "TZip")), False)
                dataRow("TDir") = If(iniFile.ReadValue(sectionNames(i), "TDir") <> String.Empty, Boolean.Parse(iniFile.ReadValue(sectionNames(i), "TDir")), False)
                dataRow("TDone") = If(iniFile.ReadValue(sectionNames(i), "TDone") <> String.Empty, iniFile.ReadValue(sectionNames(i), "TDone"), String.Empty)

                tmPara1.TID = dataRow("TID")
                tmPara1.TName = dataRow("TName")
                tmPara1.DSize = dataRow("DSize")
                tmPara1.TStatus = dataRow("TStatus")
                tmPara1.TType = dataRow("TType")
                tmPara1.TDate = dataRow("TDate")
                tmPara1.TAtEach = dataRow("TAtEach")
                tmPara1.TEvery = dataRow("TEvery")
                tmPara1.TElement = dataRow("TElement")
                tmPara1.WeekDays = dataRow("Weekdays")
                tmPara1.T0 = dataRow("T0")
                tmPara1.T1 = dataRow("T1")
                tmPara1.T2 = dataRow("T2")
                tmPara1.T3 = dataRow("T3")
                tmPara1.T4 = dataRow("T4")

                tmPara1.Zip = dataRow("Zip")
                tmPara1.ZipEnc = dataRow("ZipEnc")
                tmPara1.LocalBack = dataRow("LocalBack")

                tmPara1.DestDirPath = dataRow("DestDirPath")
                tmPara1.Other = dataRow("Other")
                tmPara1.FTPinfo.FTPS = dataRow("FTPS")
                tmPara1.FTPinfo.FTPSPort = dataRow("FTPSPort")
                tmPara1.FTPinfo.FTPU = dataRow("FTPU")
                tmPara1.FTPinfo.FTPP = dataRow("FTPP")

                tmPara1.SourceDirPath = dataRow("SourceDirPath")
                tmPara1.SourceDirT = dataRow("SourceDirT")
                tmPara1.DirFilterT = dataRow("DirFilterT")
                tmPara1.DirFilter = dataRow("DirFilter")

                tmPara1.DestDirT = dataRow("DestDirT")

                tmPara1.EC = dataRow("EC")
                tmPara1.EC = dataRow("ET")
                tmPara1.BMode = dataRow("BMode")

                tmPara1.TStart = dataRow("TStart")
                tmPara1.TZip = dataRow("TZip")
                tmPara1.TZip = dataRow("TDir")
                tmPara1.TDone = dataRow("TDone")

                Me.BackupTable.Rows.Add(dataRow)
                Me.BackupList.Add(tmPara1)
            Next

            Return BackupList
            iniFile = Nothing
        Catch ex As Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("TableMarkingFile-ReadTMSettings" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
            '            Dim mgx As MsgBoxExt = New MsgBoxExt(ex.Message.ToString, DialogTypes.Exclamation)
        End Try
    End Function
    Public Sub WriteTMSettings()
        Try

            If File.Exists(UserFile) Then
                File.Delete(Me.UserFile)
            End If
            Dim iniFile As New clsINI(Me.UserFile)
            For i As Integer = 1 To Me.BackupTable.Rows.Count
                iniFile.WriteValue("Value" + i.ToString(), "TID", i)
                'iniFile.WriteValue("Value" + i.ToString(), "TID", Me.BackupTable.Rows(i - 1)("TID").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "TName", Me.BackupTable.Rows(i - 1)("TName").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "TStatus", Me.BackupTable.Rows(i - 1)("TStatus").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "TType", Me.BackupTable.Rows(i - 1)("TType").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "TDate", Me.BackupTable.Rows(i - 1)("TDate").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "TAtEach", Me.BackupTable.Rows(i - 1)("TAtEach").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "TEvery", Me.BackupTable.Rows(i - 1)("TEvery").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "TElement", Me.BackupTable.Rows(i - 1)("TElement").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "T0", Me.BackupTable.Rows(i - 1)("T0").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "T1", Me.BackupTable.Rows(i - 1)("T1").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "T2", Me.BackupTable.Rows(i - 1)("T2").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "T3", Me.BackupTable.Rows(i - 1)("T3").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "T4", Me.BackupTable.Rows(i - 1)("T4").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "DSize", Me.BackupTable.Rows(i - 1)("DSize").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "SourceDirT", Me.BackupTable.Rows(i - 1)("SourceDirT").ToString())
                'Source Directory
                iniFile.WriteValue("Value" + i.ToString(), "SourceDirPath", Me.BackupTable.Rows(i - 1)("SourceDirPath").ToString())

                iniFile.WriteValue("Value" + i.ToString(), "DirFilter", Me.BackupTable.Rows(i - 1)("DirFilter").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "DirFilterT", Me.BackupTable.Rows(i - 1)("DirFilterT").ToString())

                iniFile.WriteValue("Value" + i.ToString(), "WeekDays", Me.BackupTable.Rows(i - 1)("WeekDays").ToString())

                iniFile.WriteValue("Value" + i.ToString(), "Zip", Me.BackupTable.Rows(i - 1)("Zip").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "ZipEnc", Me.BackupTable.Rows(i - 1)("ZipEnc").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "LocalBack", Me.BackupTable.Rows(i - 1)("LocalBack").ToString())
                'Destination Directory
                iniFile.WriteValue("Value" + i.ToString(), "DestDirT", Me.BackupTable.Rows(i - 1)("DestDirT").ToString())

                iniFile.WriteValue("Value" + i.ToString(), "DestDirPath", Me.BackupTable.Rows(i - 1)("DestDirPath").ToString)

                iniFile.WriteValue("Value" + i.ToString(), "Other", Me.BackupTable.Rows(i - 1)("Other").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "FTPS", Me.BackupTable.Rows(i - 1)("FTPS").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "FTPSPort", Me.BackupTable.Rows(i - 1)("FTPSPort").ToString())

                iniFile.WriteValue("Value" + i.ToString(), "FTPU", Me.BackupTable.Rows(i - 1)("FTPU").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "FTPP", Me.BackupTable.Rows(i - 1)("FTPP").ToString())

                iniFile.WriteValue("Value" + i.ToString(), "EC", Me.BackupTable.Rows(i - 1)("EC").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "ET", Me.BackupTable.Rows(i - 1)("ET").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "BMode", Me.BackupTable.Rows(i - 1)("BMode").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "TStart", Me.BackupTable.Rows(i - 1)("TStart").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "TZip", Me.BackupTable.Rows(i - 1)("TZip").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "TDir", Me.BackupTable.Rows(i - 1)("TDir").ToString())
                iniFile.WriteValue("Value" + i.ToString(), "TDone", Me.BackupTable.Rows(i - 1)("TDone").ToString())

            Next
                iniFile = Nothing
        Catch ex As Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            'AddLog("TableMarkingFile-WriteTMSettings" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            '            WriteLog()
        End Try
    End Sub
End Class
