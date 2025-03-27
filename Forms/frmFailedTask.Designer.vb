<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFailedTask
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFailedTask))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lvwPics = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cMnuPause = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Image = CType(resources.GetObject("Cancel_Button.Image"), System.Drawing.Image)
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_Button.Location = New System.Drawing.Point(471, 367)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.Cancel_Button.Size = New System.Drawing.Size(87, 26)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "&Close"
        '
        'lvwPics
        '
        Me.lvwPics.AllowDrop = True
        Me.lvwPics.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvwPics.FullRowSelect = True
        Me.lvwPics.Location = New System.Drawing.Point(2, 5)
        Me.lvwPics.Name = "lvwPics"
        Me.lvwPics.Size = New System.Drawing.Size(556, 358)
        Me.lvwPics.TabIndex = 0
        Me.lvwPics.UseCompatibleStateImageBehavior = False
        Me.lvwPics.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Code"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Task Name"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Task Type"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Reason"
        Me.ColumnHeader4.Width = 230
        '
        'cMnuPause
        '
        Me.cMnuPause.Image = CType(resources.GetObject("cMnuPause.Image"), System.Drawing.Image)
        Me.cMnuPause.Name = "cMnuPause"
        Me.cMnuPause.Size = New System.Drawing.Size(152, 22)
        Me.cMnuPause.Text = "Pause"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(2, 367)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.Button1.Size = New System.Drawing.Size(87, 26)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Open"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRemove.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove.Location = New System.Drawing.Point(95, 367)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(87, 26)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "&Remove"
        '
        'frmFailedTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(562, 397)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.lvwPics)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFailedTask"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Failed Task"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lvwPics As System.Windows.Forms.ListView
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cMnuPause As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button

End Class
