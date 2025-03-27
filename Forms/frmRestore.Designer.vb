<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRestore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRestore))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lvBackupName = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cMnuPause = New System.Windows.Forms.ToolStripMenuItem()
        Me.LVTaskName = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.chkwShowFTP = New System.Windows.Forms.CheckBox()
        Me.fbdRestore = New System.Windows.Forms.FolderBrowserDialog()
        Me.paUnzip = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.paFTP = New System.Windows.Forms.Panel()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.lvBackup = New System.Windows.Forms.ListView()
        Me.paMessage = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.paDirCopy = New System.Windows.Forms.Panel()
        Me.btnDirCancel = New System.Windows.Forms.Button()
        Me.WorkingLabel = New System.Windows.Forms.Label()
        Me.WorkingBar = New System.Windows.Forms.ProgressBar()
        Me.FileStatusTextbox = New System.Windows.Forms.TextBox()
        Me.CopyStatusLabel = New System.Windows.Forms.Label()
        Me.ProgressBar3 = New System.Windows.Forms.ProgressBar()
        Me.paUnzip.SuspendLayout()
        Me.paFTP.SuspendLayout()
        Me.paMessage.SuspendLayout()
        Me.paDirCopy.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Image = CType(resources.GetObject("Cancel_Button.Image"), System.Drawing.Image)
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_Button.Location = New System.Drawing.Point(808, 423)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Cancel_Button.Size = New System.Drawing.Size(79, 25)
        Me.Cancel_Button.TabIndex = 5
        Me.Cancel_Button.Text = " &Close"
        '
        'lvBackupName
        '
        Me.lvBackupName.AllowDrop = True
        Me.lvBackupName.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvBackupName.FullRowSelect = True
        Me.lvBackupName.Location = New System.Drawing.Point(252, 5)
        Me.lvBackupName.Name = "lvBackupName"
        Me.lvBackupName.Size = New System.Drawing.Size(635, 412)
        Me.lvBackupName.TabIndex = 1
        Me.lvBackupName.UseCompatibleStateImageBehavior = False
        Me.lvBackupName.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Backup Name"
        Me.ColumnHeader1.Width = 270
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Type"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Size"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 70
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Location"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Date"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 80
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Time"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 70
        '
        'cMnuPause
        '
        Me.cMnuPause.Image = CType(resources.GetObject("cMnuPause.Image"), System.Drawing.Image)
        Me.cMnuPause.Name = "cMnuPause"
        Me.cMnuPause.Size = New System.Drawing.Size(152, 22)
        Me.cMnuPause.Text = "Pause"
        '
        'LVTaskName
        '
        Me.LVTaskName.AllowDrop = True
        Me.LVTaskName.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8})
        Me.LVTaskName.FullRowSelect = True
        Me.LVTaskName.Location = New System.Drawing.Point(5, 5)
        Me.LVTaskName.Name = "LVTaskName"
        Me.LVTaskName.Size = New System.Drawing.Size(241, 412)
        Me.LVTaskName.TabIndex = 0
        Me.LVTaskName.UseCompatibleStateImageBehavior = False
        Me.LVTaskName.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Code"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Task Name"
        Me.ColumnHeader8.Width = 235
        '
        'btnRestore
        '
        Me.btnRestore.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRestore.ForeColor = System.Drawing.Color.Black
        Me.btnRestore.Image = CType(resources.GetObject("btnRestore.Image"), System.Drawing.Image)
        Me.btnRestore.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnRestore.Location = New System.Drawing.Point(252, 423)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(159, 25)
        Me.btnRestore.TabIndex = 3
        Me.btnRestore.Text = "&Restore Selected Item"
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnDelete.Location = New System.Drawing.Point(417, 423)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.btnDelete.Size = New System.Drawing.Size(159, 25)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "&Delete Selected Item"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'chkwShowFTP
        '
        Me.chkwShowFTP.AutoSize = True
        Me.chkwShowFTP.Location = New System.Drawing.Point(5, 428)
        Me.chkwShowFTP.Name = "chkwShowFTP"
        Me.chkwShowFTP.Size = New System.Drawing.Size(138, 17)
        Me.chkwShowFTP.TabIndex = 2
        Me.chkwShowFTP.Text = "Show FTP Backup also"
        Me.chkwShowFTP.UseVisualStyleBackColor = True
        '
        'paUnzip
        '
        Me.paUnzip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.paUnzip.Controls.Add(Me.btnCancel)
        Me.paUnzip.Controls.Add(Me.Label3)
        Me.paUnzip.Controls.Add(Me.lblStatus)
        Me.paUnzip.Controls.Add(Me.ProgressBar1)
        Me.paUnzip.Location = New System.Drawing.Point(335, 203)
        Me.paUnzip.Name = "paUnzip"
        Me.paUnzip.Size = New System.Drawing.Size(476, 93)
        Me.paUnzip.TabIndex = 22
        Me.paUnzip.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(434, 58)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(24, 24)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Unzip Progress"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(18, 59)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(19, 13)
        Me.lblStatus.TabIndex = 23
        Me.lblStatus.Text = "----"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(18, 34)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(440, 15)
        Me.ProgressBar1.TabIndex = 22
        '
        'paFTP
        '
        Me.paFTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.paFTP.Controls.Add(Me.ProgressBar2)
        Me.paFTP.Location = New System.Drawing.Point(335, 140)
        Me.paFTP.Name = "paFTP"
        Me.paFTP.Size = New System.Drawing.Size(476, 57)
        Me.paFTP.TabIndex = 24
        Me.paFTP.Visible = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(18, 19)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(440, 16)
        Me.ProgressBar2.TabIndex = 0
        '
        'lvBackup
        '
        Me.lvBackup.AllowDrop = True
        Me.lvBackup.FullRowSelect = True
        Me.lvBackup.Location = New System.Drawing.Point(252, 5)
        Me.lvBackup.Name = "lvBackup"
        Me.lvBackup.Size = New System.Drawing.Size(635, 412)
        Me.lvBackup.TabIndex = 10
        Me.lvBackup.UseCompatibleStateImageBehavior = False
        Me.lvBackup.View = System.Windows.Forms.View.Details
        '
        'paMessage
        '
        Me.paMessage.Controls.Add(Me.lblMessage)
        Me.paMessage.Location = New System.Drawing.Point(376, 84)
        Me.paMessage.Name = "paMessage"
        Me.paMessage.Size = New System.Drawing.Size(389, 44)
        Me.paMessage.TabIndex = 25
        Me.paMessage.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(2, 1)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(384, 42)
        Me.lblMessage.TabIndex = 24
        Me.lblMessage.Text = "Please be patient, Getting file list from FTP server may take some time depending" & _
    " upon your internet speed. !"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'paDirCopy
        '
        Me.paDirCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.paDirCopy.Controls.Add(Me.btnDirCancel)
        Me.paDirCopy.Controls.Add(Me.WorkingLabel)
        Me.paDirCopy.Controls.Add(Me.WorkingBar)
        Me.paDirCopy.Controls.Add(Me.FileStatusTextbox)
        Me.paDirCopy.Controls.Add(Me.CopyStatusLabel)
        Me.paDirCopy.Controls.Add(Me.ProgressBar3)
        Me.paDirCopy.Location = New System.Drawing.Point(265, 150)
        Me.paDirCopy.Name = "paDirCopy"
        Me.paDirCopy.Size = New System.Drawing.Size(609, 135)
        Me.paDirCopy.TabIndex = 26
        Me.paDirCopy.Visible = False
        '
        'btnDirCancel
        '
        Me.btnDirCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDirCancel.Image = CType(resources.GetObject("btnDirCancel.Image"), System.Drawing.Image)
        Me.btnDirCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDirCancel.Location = New System.Drawing.Point(568, 104)
        Me.btnDirCancel.Name = "btnDirCancel"
        Me.btnDirCancel.Size = New System.Drawing.Size(24, 24)
        Me.btnDirCancel.TabIndex = 27
        Me.btnDirCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDirCancel.UseVisualStyleBackColor = True
        '
        'WorkingLabel
        '
        Me.WorkingLabel.AutoSize = True
        Me.WorkingLabel.Location = New System.Drawing.Point(486, 11)
        Me.WorkingLabel.Name = "WorkingLabel"
        Me.WorkingLabel.Size = New System.Drawing.Size(50, 13)
        Me.WorkingLabel.TabIndex = 17
        Me.WorkingLabel.Text = "Working:"
        Me.WorkingLabel.Visible = False
        '
        'WorkingBar
        '
        Me.WorkingBar.Enabled = False
        Me.WorkingBar.Location = New System.Drawing.Point(536, 13)
        Me.WorkingBar.MarqueeAnimationSpeed = 200
        Me.WorkingBar.Name = "WorkingBar"
        Me.WorkingBar.Size = New System.Drawing.Size(65, 11)
        Me.WorkingBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.WorkingBar.TabIndex = 16
        Me.WorkingBar.Visible = False
        '
        'FileStatusTextbox
        '
        Me.FileStatusTextbox.BackColor = System.Drawing.SystemColors.Control
        Me.FileStatusTextbox.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FileStatusTextbox.Location = New System.Drawing.Point(5, 56)
        Me.FileStatusTextbox.Multiline = True
        Me.FileStatusTextbox.Name = "FileStatusTextbox"
        Me.FileStatusTextbox.ReadOnly = True
        Me.FileStatusTextbox.Size = New System.Drawing.Size(596, 72)
        Me.FileStatusTextbox.TabIndex = 10
        '
        'CopyStatusLabel
        '
        Me.CopyStatusLabel.AutoSize = True
        Me.CopyStatusLabel.Location = New System.Drawing.Point(3, 11)
        Me.CopyStatusLabel.Name = "CopyStatusLabel"
        Me.CopyStatusLabel.Size = New System.Drawing.Size(97, 13)
        Me.CopyStatusLabel.TabIndex = 9
        Me.CopyStatusLabel.Text = "Status: Not Started"
        '
        'ProgressBar3
        '
        Me.ProgressBar3.Location = New System.Drawing.Point(5, 27)
        Me.ProgressBar3.Maximum = 0
        Me.ProgressBar3.Name = "ProgressBar3"
        Me.ProgressBar3.Size = New System.Drawing.Size(596, 23)
        Me.ProgressBar3.TabIndex = 8
        '
        'frmRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(892, 453)
        Me.Controls.Add(Me.paMessage)
        Me.Controls.Add(Me.paDirCopy)
        Me.Controls.Add(Me.paFTP)
        Me.Controls.Add(Me.paUnzip)
        Me.Controls.Add(Me.chkwShowFTP)
        Me.Controls.Add(Me.btnRestore)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.LVTaskName)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.lvBackupName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRestore"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restore"
        Me.paUnzip.ResumeLayout(False)
        Me.paUnzip.PerformLayout()
        Me.paFTP.ResumeLayout(False)
        Me.paMessage.ResumeLayout(False)
        Me.paDirCopy.ResumeLayout(False)
        Me.paDirCopy.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lvBackupName As System.Windows.Forms.ListView
    Friend WithEvents cMnuPause As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LVTaskName As System.Windows.Forms.ListView
    Private WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents chkwShowFTP As System.Windows.Forms.CheckBox
    Friend WithEvents fbdRestore As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents paUnzip As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents paFTP As System.Windows.Forms.Panel
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents lvBackup As System.Windows.Forms.ListView
    Friend WithEvents paMessage As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents paDirCopy As System.Windows.Forms.Panel
    Friend WithEvents WorkingLabel As System.Windows.Forms.Label
    Friend WithEvents WorkingBar As System.Windows.Forms.ProgressBar
    Friend WithEvents FileStatusTextbox As System.Windows.Forms.TextBox
    Friend WithEvents CopyStatusLabel As System.Windows.Forms.Label
    Friend WithEvents ProgressBar3 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnDirCancel As System.Windows.Forms.Button

End Class
