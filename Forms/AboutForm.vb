﻿Public NotInheritable Class AboutForm

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
            Me.LabelCompanyName.Text = "Developer: " & My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description
            If dtEventDate = False Then
                cmdReg.Visible = True
                Me.lblReg.Text = "Not Registered"
            Else
                cmdReg.Visible = False
                Me.lblReg.Text = "Registered"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    
    Private Sub cmdReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReg.Click
        GerForm.ShowDialog()
        Me.DialogResult = DialogResult.None
    End Sub
End Class
