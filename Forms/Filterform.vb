Public Class Filterform
    Private _mstrTmp As String
    Public Property MyValue() As String
        Get
            Return _mstrTmp
        End Get
        Set(ByVal value As String)
            _mstrTmp = value
        End Set
    End Property
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtPattern.Text.Length = 0 Then
            MsgBox("Please provide name or pattern!", MsgBoxStyle.Information, "Information")
            txtPattern.Focus()
            Me.DialogResult = Windows.Forms.DialogResult.None
            Exit Sub
        End If
        _mstrTmp = cmbFilter.Text.Substring(0, 1) + "|" + txtPattern.Text
        Me.Close()
    End Sub

    Private Sub Filterform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbFilter.SelectedIndex = 0
    End Sub
End Class