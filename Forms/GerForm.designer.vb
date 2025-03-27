<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GerForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtGer = New System.Windows.Forms.TextBox()
        Me.txtUserKey = New System.Windows.Forms.TextBox()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdReg = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "easybackup.license"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(283, 49)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(30, 22)
        Me.btnBrowse.TabIndex = 29
        Me.btnBrowse.Text = "..."
        '
        'txtGer
        '
        Me.txtGer.BackColor = System.Drawing.SystemColors.Control
        Me.txtGer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGer.Location = New System.Drawing.Point(88, 50)
        Me.txtGer.Name = "txtGer"
        Me.txtGer.Size = New System.Drawing.Size(192, 20)
        Me.txtGer.TabIndex = 28
        '
        'txtUserKey
        '
        Me.txtUserKey.Location = New System.Drawing.Point(88, 16)
        Me.txtUserKey.Name = "txtUserKey"
        Me.txtUserKey.Size = New System.Drawing.Size(225, 20)
        Me.txtUserKey.TabIndex = 27
        Me.txtUserKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelVersion
        '
        Me.LabelVersion.AutoSize = True
        Me.LabelVersion.Location = New System.Drawing.Point(21, 51)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(66, 13)
        Me.LabelVersion.TabIndex = 26
        Me.LabelVersion.Text = "License File:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "User Key:"
        '
        'cmdReg
        '
        Me.cmdReg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReg.Location = New System.Drawing.Point(157, 84)
        Me.cmdReg.Name = "cmdReg"
        Me.cmdReg.Size = New System.Drawing.Size(75, 23)
        Me.cmdReg.TabIndex = 24
        Me.cmdReg.Text = "&Register"
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(238, 84)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 23
        Me.OKButton.Text = "&Close"
        '
        'GerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 120)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtGer)
        Me.Controls.Add(Me.txtUserKey)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdReg)
        Me.Controls.Add(Me.OKButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GerForm"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Register"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtGer As System.Windows.Forms.TextBox
    Friend WithEvents txtUserKey As System.Windows.Forms.TextBox
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdReg As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button

End Class
