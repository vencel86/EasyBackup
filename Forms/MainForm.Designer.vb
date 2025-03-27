<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuTask = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTaskNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTaskEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTaskDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTaskRun = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTaskPause = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsWarnings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuToolsLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuToolSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContent = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRun = New System.Windows.Forms.ToolStripButton()
        Me.btnPause = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFailed = New System.Windows.Forms.ToolStripButton()
        Me.btnLog = New System.Windows.Forms.ToolStripButton()
        Me.btnRestore = New System.Windows.Forms.ToolStripButton()
        Me.btnSettings = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAbout = New System.Windows.Forms.ToolStripButton()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.nfy = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMnuOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.cMnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.cMnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsTotalTask = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSlblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.cmnuRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cMnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cMnuRunNow = New System.Windows.Forms.ToolStripMenuItem()
        Me.cMnuPause = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrEvents = New System.Windows.Forms.Timer(Me.components)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvwPics = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.paZip = New System.Windows.Forms.Panel()
        Me.lblDelZipFile = New System.Windows.Forms.Label()
        Me.lblZipFileNM = New System.Windows.Forms.Label()
        Me.lblStrCode = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lbDir = New System.Windows.Forms.ListBox()
        Me.lbFiles = New System.Windows.Forms.ListBox()
        Me.dtpDirInfo = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblToFTPTempFile = New System.Windows.Forms.Label()
        Me.FileStatusTextbox = New System.Windows.Forms.TextBox()
        Me.StopCopy = New System.Windows.Forms.Button()
        Me.WorkingLabel = New System.Windows.Forms.Label()
        Me.WorkingBar = New System.Windows.Forms.ProgressBar()
        Me.CopyStatusLabel = New System.Windows.Forms.Label()
        Me.ProgressBar3 = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblHeading2 = New System.Windows.Forms.Label()
        Me.lblHeading1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtLogWindow = New System.Windows.Forms.TextBox()
        Me.lblBackupLog = New System.Windows.Forms.Label()
        Me.txtAppName = New System.Windows.Forms.TextBox()
        Me.dtpLastRun = New System.Windows.Forms.DateTimePicker()
        Me.lbFilterE = New System.Windows.Forms.ListBox()
        Me.lbFilterI = New System.Windows.Forms.ListBox()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.paFTP = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.stopFTP = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PBFTP = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.cmnuRightClick.SuspendLayout()
        Me.paZip.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.paFTP.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTask, Me.mnuTools, Me.mnuHelp})
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'mnuTask
        '
        Me.mnuTask.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTaskNew, Me.mnuTaskEdit, Me.mnuTaskDelete, Me.ToolStripMenuItem1, Me.mnuTaskRun, Me.mnuTaskPause, Me.ToolStripMenuItem2, Me.mnuExit})
        resources.ApplyResources(Me.mnuTask, "mnuTask")
        Me.mnuTask.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.mnuTask.Name = "mnuTask"
        '
        'mnuTaskNew
        '
        resources.ApplyResources(Me.mnuTaskNew, "mnuTaskNew")
        Me.mnuTaskNew.Name = "mnuTaskNew"
        '
        'mnuTaskEdit
        '
        resources.ApplyResources(Me.mnuTaskEdit, "mnuTaskEdit")
        Me.mnuTaskEdit.Name = "mnuTaskEdit"
        '
        'mnuTaskDelete
        '
        resources.ApplyResources(Me.mnuTaskDelete, "mnuTaskDelete")
        Me.mnuTaskDelete.Name = "mnuTaskDelete"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuTaskRun
        '
        resources.ApplyResources(Me.mnuTaskRun, "mnuTaskRun")
        Me.mnuTaskRun.Name = "mnuTaskRun"
        '
        'mnuTaskPause
        '
        resources.ApplyResources(Me.mnuTaskPause, "mnuTaskPause")
        Me.mnuTaskPause.Name = "mnuTaskPause"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuExit
        '
        resources.ApplyResources(Me.mnuExit, "mnuExit")
        Me.mnuExit.Name = "mnuExit"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolsRestore, Me.mnuToolsWarnings, Me.ToolStripMenuItem4, Me.mnuToolsLog, Me.ToolStripMenuItem5, Me.mnuToolSettings})
        resources.ApplyResources(Me.mnuTools, "mnuTools")
        Me.mnuTools.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.mnuTools.Name = "mnuTools"
        '
        'mnuToolsRestore
        '
        resources.ApplyResources(Me.mnuToolsRestore, "mnuToolsRestore")
        Me.mnuToolsRestore.Name = "mnuToolsRestore"
        '
        'mnuToolsWarnings
        '
        resources.ApplyResources(Me.mnuToolsWarnings, "mnuToolsWarnings")
        Me.mnuToolsWarnings.Name = "mnuToolsWarnings"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'mnuToolsLog
        '
        Me.mnuToolsLog.Checked = True
        Me.mnuToolsLog.CheckOnClick = True
        Me.mnuToolsLog.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.mnuToolsLog, "mnuToolsLog")
        Me.mnuToolsLog.Name = "mnuToolsLog"
        Me.mnuToolsLog.Tag = "0"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        resources.ApplyResources(Me.ToolStripMenuItem5, "ToolStripMenuItem5")
        '
        'mnuToolSettings
        '
        resources.ApplyResources(Me.mnuToolSettings, "mnuToolSettings")
        Me.mnuToolSettings.Name = "mnuToolSettings"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContent, Me.mnuUpdate, Me.mnuAbout})
        resources.ApplyResources(Me.mnuHelp, "mnuHelp")
        Me.mnuHelp.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.mnuHelp.Name = "mnuHelp"
        '
        'mnuContent
        '
        resources.ApplyResources(Me.mnuContent, "mnuContent")
        Me.mnuContent.Name = "mnuContent"
        '
        'mnuUpdate
        '
        Me.mnuUpdate.Name = "mnuUpdate"
        resources.ApplyResources(Me.mnuUpdate, "mnuUpdate")
        '
        'mnuAbout
        '
        resources.ApplyResources(Me.mnuAbout, "mnuAbout")
        Me.mnuAbout.Name = "mnuAbout"
        '
        'ToolStrip1
        '
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.ToolStripSeparator1, Me.btnRun, Me.btnPause, Me.ToolStripSeparator2, Me.btnFailed, Me.btnLog, Me.btnRestore, Me.btnSettings, Me.ToolStripSeparator4, Me.btnAbout, Me.btnExit})
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'btnNew
        '
        resources.ApplyResources(Me.btnNew, "btnNew")
        Me.btnNew.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'btnEdit
        '
        resources.ApplyResources(Me.btnEdit, "btnEdit")
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.btnEdit.Name = "btnEdit"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 2, 2)
        Me.btnDelete.Name = "btnDelete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'btnRun
        '
        resources.ApplyResources(Me.btnRun, "btnRun")
        Me.btnRun.Margin = New System.Windows.Forms.Padding(2, 1, 5, 2)
        Me.btnRun.Name = "btnRun"
        '
        'btnPause
        '
        resources.ApplyResources(Me.btnPause, "btnPause")
        Me.btnPause.Margin = New System.Windows.Forms.Padding(0, 1, 1, 2)
        Me.btnPause.Name = "btnPause"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnFailed
        '
        resources.ApplyResources(Me.btnFailed, "btnFailed")
        Me.btnFailed.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.btnFailed.Name = "btnFailed"
        '
        'btnLog
        '
        Me.btnLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnLog, "btnLog")
        Me.btnLog.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.btnLog.Name = "btnLog"
        '
        'btnRestore
        '
        resources.ApplyResources(Me.btnRestore, "btnRestore")
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(1, 1, 0, 2)
        Me.btnRestore.Name = "btnRestore"
        '
        'btnSettings
        '
        resources.ApplyResources(Me.btnSettings, "btnSettings")
        Me.btnSettings.Name = "btnSettings"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'btnAbout
        '
        resources.ApplyResources(Me.btnAbout, "btnAbout")
        Me.btnAbout.Margin = New System.Windows.Forms.Padding(3, 1, 2, 2)
        Me.btnAbout.Name = "btnAbout"
        '
        'btnExit
        '
        resources.ApplyResources(Me.btnExit, "btnExit")
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 1, 0, 2)
        Me.btnExit.Name = "btnExit"
        '
        'nfy
        '
        Me.nfy.ContextMenuStrip = Me.ContextMenuStrip1
        resources.ApplyResources(Me.nfy, "nfy")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMnuOpen, Me.ToolStripMenuItem6, Me.cMnuSettings, Me.cMnuAbout, Me.CMnuExit})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        '
        'CMnuOpen
        '
        resources.ApplyResources(Me.CMnuOpen, "CMnuOpen")
        Me.CMnuOpen.Name = "CMnuOpen"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        resources.ApplyResources(Me.ToolStripMenuItem6, "ToolStripMenuItem6")
        '
        'cMnuSettings
        '
        resources.ApplyResources(Me.cMnuSettings, "cMnuSettings")
        Me.cMnuSettings.Name = "cMnuSettings"
        '
        'cMnuAbout
        '
        resources.ApplyResources(Me.cMnuAbout, "cMnuAbout")
        Me.cMnuAbout.Name = "cMnuAbout"
        '
        'CMnuExit
        '
        resources.ApplyResources(Me.CMnuExit, "CMnuExit")
        Me.CMnuExit.Name = "CMnuExit"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsTotalTask, Me.ToolStripStatusLabel3, Me.tsDate, Me.ToolStripStatusLabel5, Me.TSlblTime, Me.ToolStripProgressBar1})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        '
        'tsTotalTask
        '
        Me.tsTotalTask.Name = "tsTotalTask"
        resources.ApplyResources(Me.tsTotalTask, "tsTotalTask")
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        resources.ApplyResources(Me.ToolStripStatusLabel3, "ToolStripStatusLabel3")
        '
        'tsDate
        '
        Me.tsDate.Name = "tsDate"
        resources.ApplyResources(Me.tsDate, "tsDate")
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        resources.ApplyResources(Me.ToolStripStatusLabel5, "ToolStripStatusLabel5")
        '
        'TSlblTime
        '
        Me.TSlblTime.Name = "TSlblTime"
        resources.ApplyResources(Me.TSlblTime, "TSlblTime")
        Me.TSlblTime.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        resources.ApplyResources(Me.ToolStripProgressBar1, "ToolStripProgressBar1")
        '
        'cmnuRightClick
        '
        Me.cmnuRightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMnuEdit, Me.cMnuDelete, Me.ToolStripMenuItem3, Me.cMnuRunNow, Me.cMnuPause})
        Me.cmnuRightClick.Name = "cmnuRightClick"
        resources.ApplyResources(Me.cmnuRightClick, "cmnuRightClick")
        '
        'CMnuEdit
        '
        resources.ApplyResources(Me.CMnuEdit, "CMnuEdit")
        Me.CMnuEdit.Name = "CMnuEdit"
        '
        'cMnuDelete
        '
        resources.ApplyResources(Me.cMnuDelete, "cMnuDelete")
        Me.cMnuDelete.Name = "cMnuDelete"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'cMnuRunNow
        '
        resources.ApplyResources(Me.cMnuRunNow, "cMnuRunNow")
        Me.cMnuRunNow.Name = "cMnuRunNow"
        '
        'cMnuPause
        '
        resources.ApplyResources(Me.cMnuPause, "cMnuPause")
        Me.cMnuPause.Name = "cMnuPause"
        '
        'tmrEvents
        '
        Me.tmrEvents.Enabled = True
        Me.tmrEvents.Interval = 59000
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        '
        'ColumnHeader2
        '
        resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
        '
        'ColumnHeader3
        '
        resources.ApplyResources(Me.ColumnHeader3, "ColumnHeader3")
        '
        'ColumnHeader4
        '
        resources.ApplyResources(Me.ColumnHeader4, "ColumnHeader4")
        '
        'ColumnHeader5
        '
        resources.ApplyResources(Me.ColumnHeader5, "ColumnHeader5")
        '
        'ColumnHeader6
        '
        resources.ApplyResources(Me.ColumnHeader6, "ColumnHeader6")
        '
        'ColumnHeader7
        '
        resources.ApplyResources(Me.ColumnHeader7, "ColumnHeader7")
        '
        'lvwPics
        '
        Me.lvwPics.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lvwPics.FullRowSelect = True
        resources.ApplyResources(Me.lvwPics, "lvwPics")
        Me.lvwPics.MultiSelect = False
        Me.lvwPics.Name = "lvwPics"
        Me.lvwPics.UseCompatibleStateImageBehavior = False
        Me.lvwPics.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        resources.ApplyResources(Me.ColumnHeader8, "ColumnHeader8")
        '
        'ColumnHeader9
        '
        resources.ApplyResources(Me.ColumnHeader9, "ColumnHeader9")
        '
        'paZip
        '
        Me.paZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.paZip.Controls.Add(Me.lblDelZipFile)
        Me.paZip.Controls.Add(Me.lblZipFileNM)
        Me.paZip.Controls.Add(Me.lblStrCode)
        Me.paZip.Controls.Add(Me.lblStatus)
        Me.paZip.Controls.Add(Me.btnCancel)
        Me.paZip.Controls.Add(Me.Label4)
        Me.paZip.Controls.Add(Me.Label3)
        Me.paZip.Controls.Add(Me.ProgressBar2)
        Me.paZip.Controls.Add(Me.ProgressBar1)
        resources.ApplyResources(Me.paZip, "paZip")
        Me.paZip.Name = "paZip"
        '
        'lblDelZipFile
        '
        resources.ApplyResources(Me.lblDelZipFile, "lblDelZipFile")
        Me.lblDelZipFile.Name = "lblDelZipFile"
        '
        'lblZipFileNM
        '
        resources.ApplyResources(Me.lblZipFileNM, "lblZipFileNM")
        Me.lblZipFileNM.Name = "lblZipFileNM"
        '
        'lblStrCode
        '
        resources.ApplyResources(Me.lblStrCode, "lblStrCode")
        Me.lblStrCode.Name = "lblStrCode"
        '
        'lblStatus
        '
        resources.ApplyResources(Me.lblStatus, "lblStatus")
        Me.lblStatus.Name = "lblStatus"
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'ProgressBar2
        '
        resources.ApplyResources(Me.ProgressBar2, "ProgressBar2")
        Me.ProgressBar2.Name = "ProgressBar2"
        '
        'ProgressBar1
        '
        resources.ApplyResources(Me.ProgressBar1, "ProgressBar1")
        Me.ProgressBar1.Name = "ProgressBar1"
        '
        'lbDir
        '
        Me.lbDir.FormattingEnabled = True
        resources.ApplyResources(Me.lbDir, "lbDir")
        Me.lbDir.Name = "lbDir"
        Me.lbDir.TabStop = False
        '
        'lbFiles
        '
        Me.lbFiles.FormattingEnabled = True
        resources.ApplyResources(Me.lbFiles, "lbFiles")
        Me.lbFiles.Name = "lbFiles"
        Me.lbFiles.TabStop = False
        '
        'dtpDirInfo
        '
        resources.ApplyResources(Me.dtpDirInfo, "dtpDirInfo")
        Me.dtpDirInfo.Name = "dtpDirInfo"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblToFTPTempFile)
        Me.Panel2.Controls.Add(Me.FileStatusTextbox)
        Me.Panel2.Controls.Add(Me.StopCopy)
        Me.Panel2.Controls.Add(Me.WorkingLabel)
        Me.Panel2.Controls.Add(Me.WorkingBar)
        Me.Panel2.Controls.Add(Me.CopyStatusLabel)
        Me.Panel2.Controls.Add(Me.ProgressBar3)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'lblToFTPTempFile
        '
        resources.ApplyResources(Me.lblToFTPTempFile, "lblToFTPTempFile")
        Me.lblToFTPTempFile.Name = "lblToFTPTempFile"
        '
        'FileStatusTextbox
        '
        Me.FileStatusTextbox.BackColor = System.Drawing.SystemColors.Control
        Me.FileStatusTextbox.ForeColor = System.Drawing.SystemColors.WindowText
        resources.ApplyResources(Me.FileStatusTextbox, "FileStatusTextbox")
        Me.FileStatusTextbox.Name = "FileStatusTextbox"
        Me.FileStatusTextbox.ReadOnly = True
        '
        'StopCopy
        '
        resources.ApplyResources(Me.StopCopy, "StopCopy")
        Me.StopCopy.Name = "StopCopy"
        Me.StopCopy.UseVisualStyleBackColor = True
        '
        'WorkingLabel
        '
        resources.ApplyResources(Me.WorkingLabel, "WorkingLabel")
        Me.WorkingLabel.Name = "WorkingLabel"
        '
        'WorkingBar
        '
        resources.ApplyResources(Me.WorkingBar, "WorkingBar")
        Me.WorkingBar.MarqueeAnimationSpeed = 200
        Me.WorkingBar.Name = "WorkingBar"
        Me.WorkingBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'CopyStatusLabel
        '
        resources.ApplyResources(Me.CopyStatusLabel, "CopyStatusLabel")
        Me.CopyStatusLabel.Name = "CopyStatusLabel"
        '
        'ProgressBar3
        '
        resources.ApplyResources(Me.ProgressBar3, "ProgressBar3")
        Me.ProgressBar3.Maximum = 1000
        Me.ProgressBar3.Name = "ProgressBar3"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Controls.Add(Me.lblHeading2)
        Me.Panel1.Controls.Add(Me.lblHeading1)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Name = "Panel1"
        '
        'lblHeading2
        '
        resources.ApplyResources(Me.lblHeading2, "lblHeading2")
        Me.lblHeading2.BackColor = System.Drawing.Color.Transparent
        Me.lblHeading2.ForeColor = System.Drawing.Color.Wheat
        Me.lblHeading2.Name = "lblHeading2"
        '
        'lblHeading1
        '
        resources.ApplyResources(Me.lblHeading1, "lblHeading1")
        Me.lblHeading1.BackColor = System.Drawing.Color.Transparent
        Me.lblHeading1.ForeColor = System.Drawing.Color.Silver
        Me.lblHeading1.Name = "lblHeading1"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'txtLogWindow
        '
        Me.txtLogWindow.BackColor = System.Drawing.Color.White
        Me.txtLogWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtLogWindow, "txtLogWindow")
        Me.txtLogWindow.Name = "txtLogWindow"
        Me.txtLogWindow.ReadOnly = True
        '
        'lblBackupLog
        '
        resources.ApplyResources(Me.lblBackupLog, "lblBackupLog")
        Me.lblBackupLog.Name = "lblBackupLog"
        '
        'txtAppName
        '
        resources.ApplyResources(Me.txtAppName, "txtAppName")
        Me.txtAppName.Name = "txtAppName"
        '
        'dtpLastRun
        '
        Me.dtpLastRun.Format = System.Windows.Forms.DateTimePickerFormat.Time
        resources.ApplyResources(Me.dtpLastRun, "dtpLastRun")
        Me.dtpLastRun.Name = "dtpLastRun"
        '
        'lbFilterE
        '
        Me.lbFilterE.FormattingEnabled = True
        resources.ApplyResources(Me.lbFilterE, "lbFilterE")
        Me.lbFilterE.Name = "lbFilterE"
        Me.lbFilterE.TabStop = False
        '
        'lbFilterI
        '
        Me.lbFilterI.FormattingEnabled = True
        resources.ApplyResources(Me.lbFilterI, "lbFilterI")
        Me.lbFilterI.Name = "lbFilterI"
        Me.lbFilterI.TabStop = False
        '
        'paFTP
        '
        Me.paFTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.paFTP.Controls.Add(Me.Label6)
        Me.paFTP.Controls.Add(Me.stopFTP)
        Me.paFTP.Controls.Add(Me.Label7)
        Me.paFTP.Controls.Add(Me.PBFTP)
        resources.ApplyResources(Me.paFTP, "paFTP")
        Me.paFTP.Name = "paFTP"
        Me.HelpProvider1.SetShowHelp(Me.paFTP, CType(resources.GetObject("paFTP.ShowHelp"), Boolean))
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        Me.HelpProvider1.SetShowHelp(Me.Label6, CType(resources.GetObject("Label6.ShowHelp"), Boolean))
        '
        'stopFTP
        '
        resources.ApplyResources(Me.stopFTP, "stopFTP")
        Me.stopFTP.Name = "stopFTP"
        Me.HelpProvider1.SetShowHelp(Me.stopFTP, CType(resources.GetObject("stopFTP.ShowHelp"), Boolean))
        Me.stopFTP.UseVisualStyleBackColor = True
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        Me.HelpProvider1.SetShowHelp(Me.Label7, CType(resources.GetObject("Label7.ShowHelp"), Boolean))
        '
        'PBFTP
        '
        resources.ApplyResources(Me.PBFTP, "PBFTP")
        Me.PBFTP.Name = "PBFTP"
        Me.HelpProvider1.SetShowHelp(Me.PBFTP, CType(resources.GetObject("PBFTP.ShowHelp"), Boolean))
        '
        'MainForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.paFTP)
        Me.Controls.Add(Me.lbFilterI)
        Me.Controls.Add(Me.lbFilterE)
        Me.Controls.Add(Me.dtpLastRun)
        Me.Controls.Add(Me.txtAppName)
        Me.Controls.Add(Me.lblBackupLog)
        Me.Controls.Add(Me.txtLogWindow)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lbFiles)
        Me.Controls.Add(Me.lbDir)
        Me.Controls.Add(Me.dtpDirInfo)
        Me.Controls.Add(Me.paZip)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lvwPics)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.cmnuRightClick.ResumeLayout(False)
        Me.paZip.ResumeLayout(False)
        Me.paZip.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.paFTP.ResumeLayout(False)
        Me.paFTP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuTask As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTaskNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTaskEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTaskDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTaskRun As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTaskPause As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuToolsWarnings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRun As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPause As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAbout As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents nfy As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CMnuOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsTotalTask As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmnuRightClick As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CMnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cMnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cMnuRunNow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cMnuPause As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrEvents As System.Windows.Forms.Timer
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwPics As System.Windows.Forms.ListView
    Friend WithEvents paZip As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblZipFileNM As System.Windows.Forms.Label
    Friend WithEvents lblStrCode As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TSlblTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents mnuToolsRestore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRestore As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuToolsLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFailed As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLog As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuToolSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbDir As System.Windows.Forms.ListBox
    Friend WithEvents lbFiles As System.Windows.Forms.ListBox
    Friend WithEvents mnuUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpDirInfo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents FileStatusTextbox As System.Windows.Forms.TextBox
    Friend WithEvents StopCopy As System.Windows.Forms.Button
    Friend WithEvents WorkingLabel As System.Windows.Forms.Label
    Friend WithEvents WorkingBar As System.Windows.Forms.ProgressBar
    Friend WithEvents CopyStatusLabel As System.Windows.Forms.Label
    Friend WithEvents ProgressBar3 As System.Windows.Forms.ProgressBar
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblHeading1 As System.Windows.Forms.Label
    Friend WithEvents lblHeading2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblDelZipFile As System.Windows.Forms.Label
    Friend WithEvents lblToFTPTempFile As System.Windows.Forms.Label
    Friend WithEvents txtLogWindow As System.Windows.Forms.TextBox
    Friend WithEvents lblBackupLog As System.Windows.Forms.Label
    Friend WithEvents txtAppName As System.Windows.Forms.TextBox
    Friend WithEvents dtpLastRun As System.Windows.Forms.DateTimePicker
    Public WithEvents lbFilterE As System.Windows.Forms.ListBox
    Public WithEvents lbFilterI As System.Windows.Forms.ListBox
    Friend WithEvents cMnuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cMnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents paFTP As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents stopFTP As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PBFTP As System.Windows.Forms.ProgressBar

End Class
