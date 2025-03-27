Imports System.Data
Public Class DataMgmt
    Private Shared _Instance As DataMgmt
    Private FileName As String = strCurPath + "\Data\BackupData.dat"
    Public BackupDataRow As DataTable = New DataTable()
    Public BackupDataList As List(Of BackupTable) = New List(Of BackupTable)()
    Private Sub Init()
        Me.BackupDataRow.Reset()
        Me.BackupDataRow.Columns.Add("Id", GetType(Short))
        Me.BackupDataRow.Columns.Add("Dia", GetType(Double))
    End Sub
    Public Sub ReadStones()
        Me.Init()
        Try
            Dim file As New clsINI(Me.FileName)
            Dim sectionNames As String() = file.GetSectionNames(Me.FileName)
            Me.BackupDataRow.Rows.Clear()
            Me.BackupDataList.Clear()
            Dim i As Integer = sectionNames.GetLowerBound(0)
            Do While (i <= sectionNames.GetUpperBound(0))
                Dim row As DataRow = Me.BackupDataRow.NewRow
                Dim item As New BackupTable
                row.Item("Id") = Short.Parse(file.ReadValue(sectionNames(i), "ID"))
                row.Item("Dia") = Double.Parse(file.ReadValue(sectionNames(i), "DIA"))
                Me.BackupDataRow.Rows.Add(row)
                Me.BackupDataList.Add(item)
                i += 1
            Loop
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub WriteStones()
        If System.IO.File.Exists(Me.FileName) Then
            IO.File.Delete(Me.FileName)
        End If
        Dim file As New clsINI(Me.FileName)
        Dim i As Integer = 1
        Do While (i <= Me.BackupDataRow.Rows.Count)
            file.WriteValue("Stone" & i.ToString, "ID", Me.BackupDataRow.Rows.Item((i - 1)).Item("ID").ToString)
            file.WriteValue("Stone" & i.ToString, "DIA", Me.BackupDataRow.Rows.Item((i - 1)).Item("DIA").ToString)
            i += 1
        Loop
        file = Nothing
    End Sub
    Public Shared Property Instance As DataMgmt
        Get
            If (DataMgmt._Instance Is Nothing) Then
                DataMgmt._Instance = New DataMgmt
            End If
            Return DataMgmt._Instance
        End Get
        Set(ByVal value As DataMgmt)
            DataMgmt._Instance = value
        End Set
    End Property
End Class
