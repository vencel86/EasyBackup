<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorHandlerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ErrorHandlerForm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.btnRetry = New System.Windows.Forms.Button()
        Me.btnIgnore = New System.Windows.Forms.Button()
        Me.btnOpenFolder = New System.Windows.Forms.Button()
        Me.btnEmail = New System.Windows.Forms.Button()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(466, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "We are sorry, the application encountered an error, please email our support depa" & _
    "rtment the steps that caused this error and we will fix the issue"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(487, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "---------------------------------------------------------------------------------" & _
    "-------------------------------------------------------------------------------"
        '
        'btnAbort
        '
        Me.btnAbort.Location = New System.Drawing.Point(265, 55)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(73, 26)
        Me.btnAbort.TabIndex = 3
        Me.btnAbort.Text = "Abort"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'btnRetry
        '
        Me.btnRetry.Location = New System.Drawing.Point(344, 55)
        Me.btnRetry.Name = "btnRetry"
        Me.btnRetry.Size = New System.Drawing.Size(73, 26)
        Me.btnRetry.TabIndex = 4
        Me.btnRetry.Text = "Retry"
        Me.btnRetry.UseVisualStyleBackColor = True
        '
        'btnIgnore
        '
        Me.btnIgnore.Location = New System.Drawing.Point(423, 55)
        Me.btnIgnore.Name = "btnIgnore"
        Me.btnIgnore.Size = New System.Drawing.Size(73, 26)
        Me.btnIgnore.TabIndex = 5
        Me.btnIgnore.Text = "Ignore"
        Me.btnIgnore.UseVisualStyleBackColor = True
        '
        'btnOpenFolder
        '
        Me.btnOpenFolder.Location = New System.Drawing.Point(12, 84)
        Me.btnOpenFolder.Name = "btnOpenFolder"
        Me.btnOpenFolder.Size = New System.Drawing.Size(121, 30)
        Me.btnOpenFolder.TabIndex = 6
        Me.btnOpenFolder.Text = "Open error log"
        Me.btnOpenFolder.UseVisualStyleBackColor = True
        '
        'btnEmail
        '
        Me.btnEmail.Location = New System.Drawing.Point(139, 84)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New System.Drawing.Size(121, 30)
        Me.btnEmail.TabIndex = 7
        Me.btnEmail.Text = "Email to author"
        Me.btnEmail.UseVisualStyleBackColor = True
        '
        'richTextBox1
        '
        Me.richTextBox1.Location = New System.Drawing.Point(-2, 120)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.ReadOnly = True
        Me.richTextBox1.Size = New System.Drawing.Size(515, 274)
        Me.richTextBox1.TabIndex = 8
        Me.richTextBox1.Text = ""
        Me.richTextBox1.WordWrap = False
        '
        'ErrorHandlerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 394)
        Me.Controls.Add(Me.richTextBox1)
        Me.Controls.Add(Me.btnEmail)
        Me.Controls.Add(Me.btnOpenFolder)
        Me.Controls.Add(Me.btnIgnore)
        Me.Controls.Add(Me.btnRetry)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ErrorHandlerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unexpected Error"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAbort As System.Windows.Forms.Button
    Friend WithEvents btnRetry As System.Windows.Forms.Button
    Friend WithEvents btnIgnore As System.Windows.Forms.Button
    Friend WithEvents btnOpenFolder As System.Windows.Forms.Button
    Friend WithEvents btnEmail As System.Windows.Forms.Button
    Private WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
End Class
