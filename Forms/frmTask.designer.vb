<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTask
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTask))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.txtBackupName = New System.Windows.Forms.TextBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gbCustom = New System.Windows.Forms.GroupBox()
        Me.txtAtEvery = New System.Windows.Forms.TextBox()
        Me.cmbAtEvery = New System.Windows.Forms.ComboBox()
        Me.rbCustomTime = New System.Windows.Forms.RadioButton()
        Me.rbAtEvery = New System.Windows.Forms.RadioButton()
        Me.dtpC1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpC2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpC3 = New System.Windows.Forms.DateTimePicker()
        Me.dtpC4 = New System.Windows.Forms.DateTimePicker()
        Me.gbDaily = New System.Windows.Forms.GroupBox()
        Me.rbDExcludeSunday = New System.Windows.Forms.RadioButton()
        Me.rbDWeekDays = New System.Windows.Forms.RadioButton()
        Me.rbDEveryDay = New System.Windows.Forms.RadioButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.gbSelectedDays = New System.Windows.Forms.GroupBox()
        Me.chkSun = New System.Windows.Forms.CheckBox()
        Me.chkSat = New System.Windows.Forms.CheckBox()
        Me.chkFri = New System.Windows.Forms.CheckBox()
        Me.chkThu = New System.Windows.Forms.CheckBox()
        Me.chkWen = New System.Windows.Forms.CheckBox()
        Me.chkTue = New System.Windows.Forms.CheckBox()
        Me.chkMon = New System.Windows.Forms.CheckBox()
        Me.gbWhenDT = New System.Windows.Forms.GroupBox()
        Me.chkCustomTime = New System.Windows.Forms.CheckBox()
        Me.dtpBDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpAlwaysTime = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboBackupType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.pnlMYSQL = New System.Windows.Forms.Panel()
        Me.rbSourceMYSQL = New System.Windows.Forms.RadioButton()
        Me.rbSourceFiles = New System.Windows.Forms.RadioButton()
        Me.pnlFiles = New System.Windows.Forms.Panel()
        Me.btnAddFilter = New System.Windows.Forms.Button()
        Me.btnAddRemove = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lvFilter = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalSize = New System.Windows.Forms.TextBox()
        Me.lblTotalSize = New System.Windows.Forms.Label()
        Me.btnExclude = New System.Windows.Forms.Button()
        Me.btnAddFiles = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lvwPics = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BrowseFrom = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbDestWEBDAV = New System.Windows.Forms.RadioButton()
        Me.rbDestSFTP = New System.Windows.Forms.RadioButton()
        Me.rbDestFTP = New System.Windows.Forms.RadioButton()
        Me.rbDestLocal = New System.Windows.Forms.RadioButton()
        Me.gbDFTP = New System.Windows.Forms.GroupBox()
        Me.txtFTPPort = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFTPServerName = New System.Windows.Forms.TextBox()
        Me.txtFTPU = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFTPP = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbDLocal = New System.Windows.Forms.GroupBox()
        Me.lbLocal = New System.Windows.Forms.ListBox()
        Me.btnDRemove = New System.Windows.Forms.Button()
        Me.btnDFolder = New System.Windows.Forms.Button()
        Me.gbWEBDAV = New System.Windows.Forms.GroupBox()
        Me.txtWebDAVPort = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnWebDAVOk = New System.Windows.Forms.Button()
        Me.txtWebDAVServer = New System.Windows.Forms.TextBox()
        Me.btnWebDAVCancel = New System.Windows.Forms.Button()
        Me.txtWebDAVUser = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtWebDAVPassword = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbFullBackup = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.rbDifferential = New System.Windows.Forms.RadioButton()
        Me.rbIncremental = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.gbZipOptions = New System.Windows.Forms.GroupBox()
        Me.txtZipPassConfirm = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtZipPass = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboZipEncryption = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.rbZip = New System.Windows.Forms.RadioButton()
        Me.rbNoZip = New System.Windows.Forms.RadioButton()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblHeadingDesc = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.ErrTask = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbCustom.SuspendLayout()
        Me.gbDaily.SuspendLayout()
        Me.gbSelectedDays.SuspendLayout()
        Me.gbWhenDT.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.pnlFiles.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbDFTP.SuspendLayout()
        Me.gbDLocal.SuspendLayout()
        Me.gbWEBDAV.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbZipOptions.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.ItemSize = New System.Drawing.Size(110, 18)
        Me.TabControl1.Location = New System.Drawing.Point(4, 55)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(555, 362)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(547, 336)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Schedule"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cboStatus)
        Me.Panel2.Controls.Add(Me.txtBackupName)
        Me.Panel2.Controls.Add(Me.lblCode)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.cboBackupType)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.ForeColor = System.Drawing.Color.Blue
        Me.Panel2.Location = New System.Drawing.Point(6, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(535, 324)
        Me.Panel2.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(348, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Current Status:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Backup Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Monitoring", "Paused"})
        Me.cboStatus.Location = New System.Drawing.Point(430, 42)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(91, 21)
        Me.cboStatus.TabIndex = 32
        '
        'txtBackupName
        '
        Me.txtBackupName.Location = New System.Drawing.Point(94, 12)
        Me.txtBackupName.Name = "txtBackupName"
        Me.txtBackupName.Size = New System.Drawing.Size(247, 20)
        Me.txtBackupName.TabIndex = 0
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(459, 11)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(13, 13)
        Me.lblCode.TabIndex = 19
        Me.lblCode.Text = "0"
        Me.lblCode.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gbCustom)
        Me.GroupBox2.Controls.Add(Me.gbDaily)
        Me.GroupBox2.Controls.Add(Me.gbSelectedDays)
        Me.GroupBox2.Controls.Add(Me.gbWhenDT)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 68)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(515, 245)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'gbCustom
        '
        Me.gbCustom.Controls.Add(Me.txtAtEvery)
        Me.gbCustom.Controls.Add(Me.cmbAtEvery)
        Me.gbCustom.Controls.Add(Me.rbCustomTime)
        Me.gbCustom.Controls.Add(Me.rbAtEvery)
        Me.gbCustom.Controls.Add(Me.dtpC1)
        Me.gbCustom.Controls.Add(Me.dtpC2)
        Me.gbCustom.Controls.Add(Me.dtpC3)
        Me.gbCustom.Controls.Add(Me.dtpC4)
        Me.gbCustom.Enabled = False
        Me.gbCustom.Location = New System.Drawing.Point(14, 152)
        Me.gbCustom.Name = "gbCustom"
        Me.gbCustom.Size = New System.Drawing.Size(487, 78)
        Me.gbCustom.TabIndex = 18
        Me.gbCustom.TabStop = False
        Me.gbCustom.Text = "Custom Time"
        '
        'txtAtEvery
        '
        Me.txtAtEvery.Location = New System.Drawing.Point(105, 19)
        Me.txtAtEvery.Name = "txtAtEvery"
        Me.txtAtEvery.Size = New System.Drawing.Size(42, 20)
        Me.txtAtEvery.TabIndex = 34
        '
        'cmbAtEvery
        '
        Me.cmbAtEvery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAtEvery.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAtEvery.FormattingEnabled = True
        Me.cmbAtEvery.Items.AddRange(New Object() {"Minutes", "Hours"})
        Me.cmbAtEvery.Location = New System.Drawing.Point(153, 19)
        Me.cmbAtEvery.Name = "cmbAtEvery"
        Me.cmbAtEvery.Size = New System.Drawing.Size(61, 21)
        Me.cmbAtEvery.TabIndex = 32
        '
        'rbCustomTime
        '
        Me.rbCustomTime.AutoSize = True
        Me.rbCustomTime.ForeColor = System.Drawing.Color.Black
        Me.rbCustomTime.Location = New System.Drawing.Point(13, 50)
        Me.rbCustomTime.Name = "rbCustomTime"
        Me.rbCustomTime.Size = New System.Drawing.Size(89, 17)
        Me.rbCustomTime.TabIndex = 30
        Me.rbCustomTime.TabStop = True
        Me.rbCustomTime.Text = "Specific Time"
        Me.rbCustomTime.UseVisualStyleBackColor = True
        '
        'rbAtEvery
        '
        Me.rbAtEvery.AutoSize = True
        Me.rbAtEvery.ForeColor = System.Drawing.Color.Black
        Me.rbAtEvery.Location = New System.Drawing.Point(13, 20)
        Me.rbAtEvery.Name = "rbAtEvery"
        Me.rbAtEvery.Size = New System.Drawing.Size(65, 17)
        Me.rbAtEvery.TabIndex = 29
        Me.rbAtEvery.TabStop = True
        Me.rbAtEvery.Text = "At Every"
        Me.rbAtEvery.UseVisualStyleBackColor = True
        '
        'dtpC1
        '
        Me.dtpC1.Checked = False
        Me.dtpC1.CustomFormat = "hh:mm tt"
        Me.dtpC1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpC1.Location = New System.Drawing.Point(105, 49)
        Me.dtpC1.Name = "dtpC1"
        Me.dtpC1.ShowCheckBox = True
        Me.dtpC1.ShowUpDown = True
        Me.dtpC1.Size = New System.Drawing.Size(84, 20)
        Me.dtpC1.TabIndex = 19
        '
        'dtpC2
        '
        Me.dtpC2.Checked = False
        Me.dtpC2.CustomFormat = "hh:mm tt"
        Me.dtpC2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpC2.Location = New System.Drawing.Point(198, 49)
        Me.dtpC2.Name = "dtpC2"
        Me.dtpC2.ShowCheckBox = True
        Me.dtpC2.ShowUpDown = True
        Me.dtpC2.Size = New System.Drawing.Size(84, 20)
        Me.dtpC2.TabIndex = 20
        '
        'dtpC3
        '
        Me.dtpC3.Checked = False
        Me.dtpC3.CustomFormat = "hh:mm tt"
        Me.dtpC3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpC3.Location = New System.Drawing.Point(384, 49)
        Me.dtpC3.Name = "dtpC3"
        Me.dtpC3.ShowCheckBox = True
        Me.dtpC3.ShowUpDown = True
        Me.dtpC3.Size = New System.Drawing.Size(84, 20)
        Me.dtpC3.TabIndex = 21
        '
        'dtpC4
        '
        Me.dtpC4.Checked = False
        Me.dtpC4.CustomFormat = "hh:mm tt"
        Me.dtpC4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpC4.Location = New System.Drawing.Point(291, 49)
        Me.dtpC4.Name = "dtpC4"
        Me.dtpC4.ShowCheckBox = True
        Me.dtpC4.ShowUpDown = True
        Me.dtpC4.Size = New System.Drawing.Size(84, 20)
        Me.dtpC4.TabIndex = 22
        '
        'gbDaily
        '
        Me.gbDaily.Controls.Add(Me.rbDExcludeSunday)
        Me.gbDaily.Controls.Add(Me.rbDWeekDays)
        Me.gbDaily.Controls.Add(Me.rbDEveryDay)
        Me.gbDaily.Controls.Add(Me.CheckBox1)
        Me.gbDaily.Location = New System.Drawing.Point(12, 18)
        Me.gbDaily.Name = "gbDaily"
        Me.gbDaily.Size = New System.Drawing.Size(151, 127)
        Me.gbDaily.TabIndex = 3
        Me.gbDaily.TabStop = False
        Me.gbDaily.Text = "Daily"
        '
        'rbDExcludeSunday
        '
        Me.rbDExcludeSunday.AutoSize = True
        Me.rbDExcludeSunday.ForeColor = System.Drawing.Color.Black
        Me.rbDExcludeSunday.Location = New System.Drawing.Point(15, 84)
        Me.rbDExcludeSunday.Name = "rbDExcludeSunday"
        Me.rbDExcludeSunday.Size = New System.Drawing.Size(124, 17)
        Me.rbDExcludeSunday.TabIndex = 6
        Me.rbDExcludeSunday.TabStop = True
        Me.rbDExcludeSunday.Text = "Exclude Sunday only"
        Me.rbDExcludeSunday.UseVisualStyleBackColor = True
        '
        'rbDWeekDays
        '
        Me.rbDWeekDays.AutoSize = True
        Me.rbDWeekDays.ForeColor = System.Drawing.Color.Black
        Me.rbDWeekDays.Location = New System.Drawing.Point(15, 58)
        Me.rbDWeekDays.Name = "rbDWeekDays"
        Me.rbDWeekDays.Size = New System.Drawing.Size(76, 17)
        Me.rbDWeekDays.TabIndex = 5
        Me.rbDWeekDays.TabStop = True
        Me.rbDWeekDays.Text = "Weekdays"
        Me.rbDWeekDays.UseVisualStyleBackColor = True
        '
        'rbDEveryDay
        '
        Me.rbDEveryDay.AutoSize = True
        Me.rbDEveryDay.ForeColor = System.Drawing.Color.Black
        Me.rbDEveryDay.Location = New System.Drawing.Point(15, 32)
        Me.rbDEveryDay.Name = "rbDEveryDay"
        Me.rbDEveryDay.Size = New System.Drawing.Size(69, 17)
        Me.rbDEveryDay.TabIndex = 4
        Me.rbDEveryDay.TabStop = True
        Me.rbDEveryDay.Text = "Everyday"
        Me.rbDEveryDay.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(296, 44)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(62, 17)
        Me.CheckBox1.TabIndex = 23
        Me.CheckBox1.Text = "Sunday"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'gbSelectedDays
        '
        Me.gbSelectedDays.Controls.Add(Me.chkSun)
        Me.gbSelectedDays.Controls.Add(Me.chkSat)
        Me.gbSelectedDays.Controls.Add(Me.chkFri)
        Me.gbSelectedDays.Controls.Add(Me.chkThu)
        Me.gbSelectedDays.Controls.Add(Me.chkWen)
        Me.gbSelectedDays.Controls.Add(Me.chkTue)
        Me.gbSelectedDays.Controls.Add(Me.chkMon)
        Me.gbSelectedDays.Location = New System.Drawing.Point(181, 18)
        Me.gbSelectedDays.Name = "gbSelectedDays"
        Me.gbSelectedDays.Size = New System.Drawing.Size(151, 127)
        Me.gbSelectedDays.TabIndex = 7
        Me.gbSelectedDays.TabStop = False
        Me.gbSelectedDays.Text = "Weely"
        '
        'chkSun
        '
        Me.chkSun.AutoSize = True
        Me.chkSun.ForeColor = System.Drawing.Color.Black
        Me.chkSun.Location = New System.Drawing.Point(88, 100)
        Me.chkSun.Name = "chkSun"
        Me.chkSun.Size = New System.Drawing.Size(45, 17)
        Me.chkSun.TabIndex = 14
        Me.chkSun.Text = "Sun"
        Me.chkSun.UseVisualStyleBackColor = True
        '
        'chkSat
        '
        Me.chkSat.AutoSize = True
        Me.chkSat.ForeColor = System.Drawing.Color.Black
        Me.chkSat.Location = New System.Drawing.Point(88, 74)
        Me.chkSat.Name = "chkSat"
        Me.chkSat.Size = New System.Drawing.Size(42, 17)
        Me.chkSat.TabIndex = 13
        Me.chkSat.Text = "Sat"
        Me.chkSat.UseVisualStyleBackColor = True
        '
        'chkFri
        '
        Me.chkFri.AutoSize = True
        Me.chkFri.ForeColor = System.Drawing.Color.Black
        Me.chkFri.Location = New System.Drawing.Point(88, 49)
        Me.chkFri.Name = "chkFri"
        Me.chkFri.Size = New System.Drawing.Size(37, 17)
        Me.chkFri.TabIndex = 12
        Me.chkFri.Text = "Fri"
        Me.chkFri.UseVisualStyleBackColor = True
        '
        'chkThu
        '
        Me.chkThu.AutoSize = True
        Me.chkThu.ForeColor = System.Drawing.Color.Black
        Me.chkThu.Location = New System.Drawing.Point(88, 24)
        Me.chkThu.Name = "chkThu"
        Me.chkThu.Size = New System.Drawing.Size(45, 17)
        Me.chkThu.TabIndex = 11
        Me.chkThu.Text = "Thu"
        Me.chkThu.UseVisualStyleBackColor = True
        '
        'chkWen
        '
        Me.chkWen.AutoSize = True
        Me.chkWen.ForeColor = System.Drawing.Color.Black
        Me.chkWen.Location = New System.Drawing.Point(24, 74)
        Me.chkWen.Name = "chkWen"
        Me.chkWen.Size = New System.Drawing.Size(49, 17)
        Me.chkWen.TabIndex = 10
        Me.chkWen.Text = "Wed"
        Me.chkWen.UseVisualStyleBackColor = True
        '
        'chkTue
        '
        Me.chkTue.AutoSize = True
        Me.chkTue.ForeColor = System.Drawing.Color.Black
        Me.chkTue.Location = New System.Drawing.Point(24, 49)
        Me.chkTue.Name = "chkTue"
        Me.chkTue.Size = New System.Drawing.Size(45, 17)
        Me.chkTue.TabIndex = 9
        Me.chkTue.Text = "Tue"
        Me.chkTue.UseVisualStyleBackColor = True
        '
        'chkMon
        '
        Me.chkMon.AutoSize = True
        Me.chkMon.ForeColor = System.Drawing.Color.Black
        Me.chkMon.Location = New System.Drawing.Point(24, 24)
        Me.chkMon.Name = "chkMon"
        Me.chkMon.Size = New System.Drawing.Size(47, 17)
        Me.chkMon.TabIndex = 8
        Me.chkMon.Text = "Mon"
        Me.chkMon.UseVisualStyleBackColor = True
        '
        'gbWhenDT
        '
        Me.gbWhenDT.Controls.Add(Me.chkCustomTime)
        Me.gbWhenDT.Controls.Add(Me.dtpBDate)
        Me.gbWhenDT.Controls.Add(Me.dtpAlwaysTime)
        Me.gbWhenDT.Controls.Add(Me.Label4)
        Me.gbWhenDT.Controls.Add(Me.Label3)
        Me.gbWhenDT.Location = New System.Drawing.Point(350, 18)
        Me.gbWhenDT.Name = "gbWhenDT"
        Me.gbWhenDT.Size = New System.Drawing.Size(151, 127)
        Me.gbWhenDT.TabIndex = 15
        Me.gbWhenDT.TabStop = False
        Me.gbWhenDT.Text = "When"
        '
        'chkCustomTime
        '
        Me.chkCustomTime.AutoSize = True
        Me.chkCustomTime.ForeColor = System.Drawing.Color.Black
        Me.chkCustomTime.Location = New System.Drawing.Point(45, 95)
        Me.chkCustomTime.Name = "chkCustomTime"
        Me.chkCustomTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkCustomTime.Size = New System.Drawing.Size(87, 17)
        Me.chkCustomTime.TabIndex = 28
        Me.chkCustomTime.Text = "Custom Time"
        Me.chkCustomTime.UseVisualStyleBackColor = True
        '
        'dtpBDate
        '
        Me.dtpBDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBDate.Enabled = False
        Me.dtpBDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBDate.Location = New System.Drawing.Point(49, 34)
        Me.dtpBDate.Name = "dtpBDate"
        Me.dtpBDate.Size = New System.Drawing.Size(84, 20)
        Me.dtpBDate.TabIndex = 16
        '
        'dtpAlwaysTime
        '
        Me.dtpAlwaysTime.CustomFormat = "hh:mm tt"
        Me.dtpAlwaysTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAlwaysTime.Location = New System.Drawing.Point(48, 66)
        Me.dtpAlwaysTime.Name = "dtpAlwaysTime"
        Me.dtpAlwaysTime.ShowCheckBox = True
        Me.dtpAlwaysTime.ShowUpDown = True
        Me.dtpAlwaysTime.Size = New System.Drawing.Size(85, 20)
        Me.dtpAlwaysTime.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(15, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Time:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Date:"
        '
        'cboBackupType
        '
        Me.cboBackupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBackupType.FormattingEnabled = True
        Me.cboBackupType.Items.AddRange(New Object() {"Daily", "Weekly", "Computer starts", "One time only", "Manual Start"})
        Me.cboBackupType.Location = New System.Drawing.Point(94, 41)
        Me.cboBackupType.Name = "cboBackupType"
        Me.cboBackupType.Size = New System.Drawing.Size(91, 21)
        Me.cboBackupType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(36, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Schedule:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.pnlMYSQL)
        Me.TabPage2.Controls.Add(Me.rbSourceMYSQL)
        Me.TabPage2.Controls.Add(Me.rbSourceFiles)
        Me.TabPage2.Controls.Add(Me.pnlFiles)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(547, 336)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Source"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'pnlMYSQL
        '
        Me.pnlMYSQL.Location = New System.Drawing.Point(324, 9)
        Me.pnlMYSQL.Name = "pnlMYSQL"
        Me.pnlMYSQL.Size = New System.Drawing.Size(57, 17)
        Me.pnlMYSQL.TabIndex = 43
        '
        'rbSourceMYSQL
        '
        Me.rbSourceMYSQL.AutoSize = True
        Me.rbSourceMYSQL.Location = New System.Drawing.Point(125, 10)
        Me.rbSourceMYSQL.Name = "rbSourceMYSQL"
        Me.rbSourceMYSQL.Size = New System.Drawing.Size(62, 17)
        Me.rbSourceMYSQL.TabIndex = 42
        Me.rbSourceMYSQL.Text = "MYSQL"
        Me.rbSourceMYSQL.UseVisualStyleBackColor = True
        Me.rbSourceMYSQL.Visible = False
        '
        'rbSourceFiles
        '
        Me.rbSourceFiles.AutoSize = True
        Me.rbSourceFiles.Checked = True
        Me.rbSourceFiles.Location = New System.Drawing.Point(14, 10)
        Me.rbSourceFiles.Name = "rbSourceFiles"
        Me.rbSourceFiles.Size = New System.Drawing.Size(83, 17)
        Me.rbSourceFiles.TabIndex = 41
        Me.rbSourceFiles.TabStop = True
        Me.rbSourceFiles.Text = "Files-Folders"
        Me.rbSourceFiles.UseVisualStyleBackColor = True
        '
        'pnlFiles
        '
        Me.pnlFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiles.Controls.Add(Me.btnAddFilter)
        Me.pnlFiles.Controls.Add(Me.btnAddRemove)
        Me.pnlFiles.Controls.Add(Me.Label20)
        Me.pnlFiles.Controls.Add(Me.lvFilter)
        Me.pnlFiles.Controls.Add(Me.Label5)
        Me.pnlFiles.Controls.Add(Me.txtTotalSize)
        Me.pnlFiles.Controls.Add(Me.lblTotalSize)
        Me.pnlFiles.Controls.Add(Me.btnExclude)
        Me.pnlFiles.Controls.Add(Me.btnAddFiles)
        Me.pnlFiles.Controls.Add(Me.Label6)
        Me.pnlFiles.Controls.Add(Me.lvwPics)
        Me.pnlFiles.Controls.Add(Me.BrowseFrom)
        Me.pnlFiles.ForeColor = System.Drawing.Color.Blue
        Me.pnlFiles.Location = New System.Drawing.Point(6, 35)
        Me.pnlFiles.Name = "pnlFiles"
        Me.pnlFiles.Size = New System.Drawing.Size(535, 293)
        Me.pnlFiles.TabIndex = 7
        '
        'btnAddFilter
        '
        Me.btnAddFilter.ForeColor = System.Drawing.Color.Black
        Me.btnAddFilter.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnAddFilter.Location = New System.Drawing.Point(354, 263)
        Me.btnAddFilter.Name = "btnAddFilter"
        Me.btnAddFilter.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnAddFilter.Size = New System.Drawing.Size(83, 25)
        Me.btnAddFilter.TabIndex = 19
        Me.btnAddFilter.Text = "Add"
        Me.btnAddFilter.UseVisualStyleBackColor = True
        '
        'btnAddRemove
        '
        Me.btnAddRemove.ForeColor = System.Drawing.Color.Black
        Me.btnAddRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddRemove.Location = New System.Drawing.Point(442, 264)
        Me.btnAddRemove.Name = "btnAddRemove"
        Me.btnAddRemove.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnAddRemove.Size = New System.Drawing.Size(83, 25)
        Me.btnAddRemove.TabIndex = 18
        Me.btnAddRemove.Text = "Remove"
        Me.btnAddRemove.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(4, 175)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(34, 13)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "Rules"
        '
        'lvFilter
        '
        Me.lvFilter.AllowDrop = True
        Me.lvFilter.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvFilter.FullRowSelect = True
        Me.lvFilter.Location = New System.Drawing.Point(7, 191)
        Me.lvFilter.Name = "lvFilter"
        Me.lvFilter.Size = New System.Drawing.Size(519, 68)
        Me.lvFilter.TabIndex = 16
        Me.lvFilter.UseCompatibleStateImageBehavior = False
        Me.lvFilter.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Action"
        Me.ColumnHeader5.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Name/Pattern"
        Me.ColumnHeader6.Width = 380
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 307)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(244, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Note : You can drag and drop from Computer also."
        '
        'txtTotalSize
        '
        Me.txtTotalSize.Location = New System.Drawing.Point(118, 151)
        Me.txtTotalSize.Name = "txtTotalSize"
        Me.txtTotalSize.Size = New System.Drawing.Size(113, 20)
        Me.txtTotalSize.TabIndex = 14
        Me.txtTotalSize.TabStop = False
        Me.txtTotalSize.Text = "0"
        Me.txtTotalSize.Visible = False
        '
        'lblTotalSize
        '
        Me.lblTotalSize.AutoSize = True
        Me.lblTotalSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalSize.Location = New System.Drawing.Point(4, 153)
        Me.lblTotalSize.Name = "lblTotalSize"
        Me.lblTotalSize.Size = New System.Drawing.Size(68, 13)
        Me.lblTotalSize.TabIndex = 13
        Me.lblTotalSize.Text = "Total Size:"
        '
        'btnExclude
        '
        Me.btnExclude.ForeColor = System.Drawing.Color.Black
        Me.btnExclude.Image = CType(resources.GetObject("btnExclude.Image"), System.Drawing.Image)
        Me.btnExclude.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExclude.Location = New System.Drawing.Point(433, 150)
        Me.btnExclude.Name = "btnExclude"
        Me.btnExclude.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnExclude.Size = New System.Drawing.Size(92, 25)
        Me.btnExclude.TabIndex = 12
        Me.btnExclude.Text = " - R&emove"
        Me.btnExclude.UseVisualStyleBackColor = True
        '
        'btnAddFiles
        '
        Me.btnAddFiles.ForeColor = System.Drawing.Color.Black
        Me.btnAddFiles.Image = CType(resources.GetObject("btnAddFiles.Image"), System.Drawing.Image)
        Me.btnAddFiles.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnAddFiles.Location = New System.Drawing.Point(237, 150)
        Me.btnAddFiles.Name = "btnAddFiles"
        Me.btnAddFiles.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnAddFiles.Size = New System.Drawing.Size(92, 25)
        Me.btnAddFiles.TabIndex = 11
        Me.btnAddFiles.Text = "+ File(s)"
        Me.btnAddFiles.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(4, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Files / Folders to be copied:"
        '
        'lvwPics
        '
        Me.lvwPics.AllowDrop = True
        Me.lvwPics.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvwPics.FullRowSelect = True
        Me.lvwPics.Location = New System.Drawing.Point(7, 25)
        Me.lvwPics.Name = "lvwPics"
        Me.lvwPics.Size = New System.Drawing.Size(519, 119)
        Me.lvwPics.TabIndex = 9
        Me.lvwPics.UseCompatibleStateImageBehavior = False
        Me.lvwPics.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Path"
        Me.ColumnHeader1.Width = 392
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Size in MB"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 105
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Width = 0
        '
        'BrowseFrom
        '
        Me.BrowseFrom.ForeColor = System.Drawing.Color.Black
        Me.BrowseFrom.Image = CType(resources.GetObject("BrowseFrom.Image"), System.Drawing.Image)
        Me.BrowseFrom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BrowseFrom.Location = New System.Drawing.Point(335, 150)
        Me.BrowseFrom.Name = "BrowseFrom"
        Me.BrowseFrom.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.BrowseFrom.Size = New System.Drawing.Size(92, 25)
        Me.BrowseFrom.TabIndex = 8
        Me.BrowseFrom.Text = " + Folder(s)"
        Me.BrowseFrom.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(547, 336)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Destination"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDestWEBDAV)
        Me.GroupBox1.Controls.Add(Me.rbDestSFTP)
        Me.GroupBox1.Controls.Add(Me.rbDestFTP)
        Me.GroupBox1.Controls.Add(Me.rbDestLocal)
        Me.GroupBox1.Controls.Add(Me.gbDFTP)
        Me.GroupBox1.Controls.Add(Me.gbDLocal)
        Me.GroupBox1.Controls.Add(Me.gbWEBDAV)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(520, 311)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Where to put backup"
        '
        'rbDestWEBDAV
        '
        Me.rbDestWEBDAV.AutoSize = True
        Me.rbDestWEBDAV.Enabled = False
        Me.rbDestWEBDAV.Location = New System.Drawing.Point(393, 28)
        Me.rbDestWEBDAV.Name = "rbDestWEBDAV"
        Me.rbDestWEBDAV.Size = New System.Drawing.Size(104, 17)
        Me.rbDestWEBDAV.TabIndex = 45
        Me.rbDestWEBDAV.Text = "WebDAV Server"
        Me.rbDestWEBDAV.UseVisualStyleBackColor = True
        '
        'rbDestSFTP
        '
        Me.rbDestSFTP.AutoSize = True
        Me.rbDestSFTP.Enabled = False
        Me.rbDestSFTP.Location = New System.Drawing.Point(290, 28)
        Me.rbDestSFTP.Name = "rbDestSFTP"
        Me.rbDestSFTP.Size = New System.Drawing.Size(86, 17)
        Me.rbDestSFTP.TabIndex = 42
        Me.rbDestSFTP.Text = "SFTP Server"
        Me.rbDestSFTP.UseVisualStyleBackColor = True
        '
        'rbDestFTP
        '
        Me.rbDestFTP.AutoSize = True
        Me.rbDestFTP.Location = New System.Drawing.Point(140, 28)
        Me.rbDestFTP.Name = "rbDestFTP"
        Me.rbDestFTP.Size = New System.Drawing.Size(133, 17)
        Me.rbDestFTP.TabIndex = 41
        Me.rbDestFTP.Text = "FTP Server (SSL/TSL)"
        Me.rbDestFTP.UseVisualStyleBackColor = True
        '
        'rbDestLocal
        '
        Me.rbDestLocal.AutoSize = True
        Me.rbDestLocal.Checked = True
        Me.rbDestLocal.Location = New System.Drawing.Point(23, 28)
        Me.rbDestLocal.Name = "rbDestLocal"
        Me.rbDestLocal.Size = New System.Drawing.Size(100, 17)
        Me.rbDestLocal.TabIndex = 40
        Me.rbDestLocal.TabStop = True
        Me.rbDestLocal.Text = "Local - Network"
        Me.rbDestLocal.UseVisualStyleBackColor = True
        '
        'gbDFTP
        '
        Me.gbDFTP.Controls.Add(Me.txtFTPPort)
        Me.gbDFTP.Controls.Add(Me.Label18)
        Me.gbDFTP.Controls.Add(Me.Label11)
        Me.gbDFTP.Controls.Add(Me.Label7)
        Me.gbDFTP.Controls.Add(Me.txtFTPServerName)
        Me.gbDFTP.Controls.Add(Me.txtFTPU)
        Me.gbDFTP.Controls.Add(Me.Label10)
        Me.gbDFTP.Controls.Add(Me.txtFTPP)
        Me.gbDFTP.Controls.Add(Me.Label9)
        Me.gbDFTP.Location = New System.Drawing.Point(23, 61)
        Me.gbDFTP.Name = "gbDFTP"
        Me.gbDFTP.Size = New System.Drawing.Size(474, 186)
        Me.gbDFTP.TabIndex = 44
        Me.gbDFTP.TabStop = False
        Me.gbDFTP.Text = "FTP Server information"
        '
        'txtFTPPort
        '
        Me.txtFTPPort.Location = New System.Drawing.Point(409, 25)
        Me.txtFTPPort.Name = "txtFTPPort"
        Me.txtFTPPort.Size = New System.Drawing.Size(50, 20)
        Me.txtFTPPort.TabIndex = 23
        Me.txtFTPPort.Text = "21"
        Me.txtFTPPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(377, 26)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 13)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Port:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 157)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(211, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "* Example: ftp://myftp.com or ftp.myftp.com"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "* FTP Server Address:"
        '
        'txtFTPServerName
        '
        Me.txtFTPServerName.Location = New System.Drawing.Point(127, 25)
        Me.txtFTPServerName.Name = "txtFTPServerName"
        Me.txtFTPServerName.Size = New System.Drawing.Size(244, 20)
        Me.txtFTPServerName.TabIndex = 0
        '
        'txtFTPU
        '
        Me.txtFTPU.Location = New System.Drawing.Point(127, 60)
        Me.txtFTPU.Name = "txtFTPU"
        Me.txtFTPU.Size = New System.Drawing.Size(173, 20)
        Me.txtFTPU.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(65, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Password:"
        '
        'txtFTPP
        '
        Me.txtFTPP.Location = New System.Drawing.Point(127, 95)
        Me.txtFTPP.Name = "txtFTPP"
        Me.txtFTPP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtFTPP.Size = New System.Drawing.Size(173, 20)
        Me.txtFTPP.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(89, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "User:"
        '
        'gbDLocal
        '
        Me.gbDLocal.Controls.Add(Me.lbLocal)
        Me.gbDLocal.Controls.Add(Me.btnDRemove)
        Me.gbDLocal.Controls.Add(Me.btnDFolder)
        Me.gbDLocal.Location = New System.Drawing.Point(23, 61)
        Me.gbDLocal.Name = "gbDLocal"
        Me.gbDLocal.Size = New System.Drawing.Size(475, 173)
        Me.gbDLocal.TabIndex = 43
        Me.gbDLocal.TabStop = False
        Me.gbDLocal.Text = "Please specify local or network drive location"
        '
        'lbLocal
        '
        Me.lbLocal.FormattingEnabled = True
        Me.lbLocal.Location = New System.Drawing.Point(11, 23)
        Me.lbLocal.Name = "lbLocal"
        Me.lbLocal.Size = New System.Drawing.Size(453, 108)
        Me.lbLocal.TabIndex = 0
        '
        'btnDRemove
        '
        Me.btnDRemove.ForeColor = System.Drawing.Color.Black
        Me.btnDRemove.Image = CType(resources.GetObject("btnDRemove.Image"), System.Drawing.Image)
        Me.btnDRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnDRemove.Location = New System.Drawing.Point(109, 137)
        Me.btnDRemove.Name = "btnDRemove"
        Me.btnDRemove.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnDRemove.Size = New System.Drawing.Size(92, 24)
        Me.btnDRemove.TabIndex = 27
        Me.btnDRemove.Text = " - Remove"
        Me.btnDRemove.UseVisualStyleBackColor = True
        '
        'btnDFolder
        '
        Me.btnDFolder.ForeColor = System.Drawing.Color.Black
        Me.btnDFolder.Image = CType(resources.GetObject("btnDFolder.Image"), System.Drawing.Image)
        Me.btnDFolder.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnDFolder.Location = New System.Drawing.Point(11, 137)
        Me.btnDFolder.Name = "btnDFolder"
        Me.btnDFolder.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnDFolder.Size = New System.Drawing.Size(92, 24)
        Me.btnDFolder.TabIndex = 26
        Me.btnDFolder.Text = "+ Add"
        Me.btnDFolder.UseVisualStyleBackColor = True
        '
        'gbWEBDAV
        '
        Me.gbWEBDAV.Controls.Add(Me.txtWebDAVPort)
        Me.gbWEBDAV.Controls.Add(Me.Label19)
        Me.gbWEBDAV.Controls.Add(Me.Label21)
        Me.gbWEBDAV.Controls.Add(Me.btnWebDAVOk)
        Me.gbWEBDAV.Controls.Add(Me.txtWebDAVServer)
        Me.gbWEBDAV.Controls.Add(Me.btnWebDAVCancel)
        Me.gbWEBDAV.Controls.Add(Me.txtWebDAVUser)
        Me.gbWEBDAV.Controls.Add(Me.Label22)
        Me.gbWEBDAV.Controls.Add(Me.txtWebDAVPassword)
        Me.gbWEBDAV.Controls.Add(Me.Label23)
        Me.gbWEBDAV.Location = New System.Drawing.Point(23, 61)
        Me.gbWEBDAV.Name = "gbWEBDAV"
        Me.gbWEBDAV.Size = New System.Drawing.Size(474, 186)
        Me.gbWEBDAV.TabIndex = 46
        Me.gbWEBDAV.TabStop = False
        Me.gbWEBDAV.Text = "WebDAV Server"
        '
        'txtWebDAVPort
        '
        Me.txtWebDAVPort.Location = New System.Drawing.Point(413, 25)
        Me.txtWebDAVPort.Name = "txtWebDAVPort"
        Me.txtWebDAVPort.Size = New System.Drawing.Size(50, 20)
        Me.txtWebDAVPort.TabIndex = 23
        Me.txtWebDAVPort.Text = "443"
        Me.txtWebDAVPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(381, 27)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 13)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Port:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 27)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(124, 13)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = " WebDAV Server (https):"
        '
        'btnWebDAVOk
        '
        Me.btnWebDAVOk.ForeColor = System.Drawing.Color.Black
        Me.btnWebDAVOk.Image = CType(resources.GetObject("btnWebDAVOk.Image"), System.Drawing.Image)
        Me.btnWebDAVOk.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnWebDAVOk.Location = New System.Drawing.Point(281, 149)
        Me.btnWebDAVOk.Name = "btnWebDAVOk"
        Me.btnWebDAVOk.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnWebDAVOk.Size = New System.Drawing.Size(88, 24)
        Me.btnWebDAVOk.TabIndex = 19
        Me.btnWebDAVOk.Text = "&OK"
        Me.btnWebDAVOk.UseVisualStyleBackColor = True
        '
        'txtWebDAVServer
        '
        Me.txtWebDAVServer.Location = New System.Drawing.Point(131, 25)
        Me.txtWebDAVServer.Name = "txtWebDAVServer"
        Me.txtWebDAVServer.Size = New System.Drawing.Size(244, 20)
        Me.txtWebDAVServer.TabIndex = 0
        '
        'btnWebDAVCancel
        '
        Me.btnWebDAVCancel.Image = CType(resources.GetObject("btnWebDAVCancel.Image"), System.Drawing.Image)
        Me.btnWebDAVCancel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnWebDAVCancel.Location = New System.Drawing.Point(373, 149)
        Me.btnWebDAVCancel.Name = "btnWebDAVCancel"
        Me.btnWebDAVCancel.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.btnWebDAVCancel.Size = New System.Drawing.Size(88, 24)
        Me.btnWebDAVCancel.TabIndex = 20
        Me.btnWebDAVCancel.Text = "&Cancel"
        Me.btnWebDAVCancel.UseVisualStyleBackColor = True
        '
        'txtWebDAVUser
        '
        Me.txtWebDAVUser.Location = New System.Drawing.Point(131, 68)
        Me.txtWebDAVUser.Name = "txtWebDAVUser"
        Me.txtWebDAVUser.Size = New System.Drawing.Size(173, 20)
        Me.txtWebDAVUser.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(75, 113)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "Password:"
        '
        'txtWebDAVPassword
        '
        Me.txtWebDAVPassword.Location = New System.Drawing.Point(131, 111)
        Me.txtWebDAVPassword.Name = "txtWebDAVPassword"
        Me.txtWebDAVPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtWebDAVPassword.Size = New System.Drawing.Size(173, 20)
        Me.txtWebDAVPassword.TabIndex = 2
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(99, 70)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(32, 13)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "User:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(547, 336)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "Backup Settings"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbFullBackup)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.rbDifferential)
        Me.GroupBox4.Controls.Add(Me.rbIncremental)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 135)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(520, 189)
        Me.GroupBox4.TabIndex = 38
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Backup Settings"
        '
        'rbFullBackup
        '
        Me.rbFullBackup.AutoSize = True
        Me.rbFullBackup.Location = New System.Drawing.Point(38, 29)
        Me.rbFullBackup.Name = "rbFullBackup"
        Me.rbFullBackup.Size = New System.Drawing.Size(81, 17)
        Me.rbFullBackup.TabIndex = 40
        Me.rbFullBackup.Text = "Full Backup"
        Me.rbFullBackup.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(54, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(350, 18)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "(Always overwrite previous backup)"
        '
        'rbDifferential
        '
        Me.rbDifferential.AutoSize = True
        Me.rbDifferential.Checked = True
        Me.rbDifferential.Location = New System.Drawing.Point(38, 131)
        Me.rbDifferential.Name = "rbDifferential"
        Me.rbDifferential.Size = New System.Drawing.Size(115, 17)
        Me.rbDifferential.TabIndex = 38
        Me.rbDifferential.TabStop = True
        Me.rbDifferential.Text = "Differential Backup"
        Me.rbDifferential.UseVisualStyleBackColor = True
        '
        'rbIncremental
        '
        Me.rbIncremental.AutoSize = True
        Me.rbIncremental.Location = New System.Drawing.Point(38, 73)
        Me.rbIncremental.Name = "rbIncremental"
        Me.rbIncremental.Size = New System.Drawing.Size(120, 17)
        Me.rbIncremental.TabIndex = 37
        Me.rbIncremental.Text = "Incremental Backup"
        Me.rbIncremental.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(54, 151)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(328, 13)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "(Backup all the files that have changed since the last backup made)"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(54, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(443, 29)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "(Backup all the files that have changed since the last Full backup made, create n" &
    "ew backup each time compared with last backup)"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.gbZipOptions)
        Me.GroupBox3.Controls.Add(Me.rbZip)
        Me.GroupBox3.Controls.Add(Me.rbNoZip)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(520, 112)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "General"
        '
        'gbZipOptions
        '
        Me.gbZipOptions.Controls.Add(Me.txtZipPassConfirm)
        Me.gbZipOptions.Controls.Add(Me.Label17)
        Me.gbZipOptions.Controls.Add(Me.txtZipPass)
        Me.gbZipOptions.Controls.Add(Me.Label16)
        Me.gbZipOptions.Controls.Add(Me.cboZipEncryption)
        Me.gbZipOptions.Controls.Add(Me.Label15)
        Me.gbZipOptions.Location = New System.Drawing.Point(12, 45)
        Me.gbZipOptions.Name = "gbZipOptions"
        Me.gbZipOptions.Size = New System.Drawing.Size(496, 56)
        Me.gbZipOptions.TabIndex = 45
        Me.gbZipOptions.TabStop = False
        Me.gbZipOptions.Text = "Zip Options"
        '
        'txtZipPassConfirm
        '
        Me.txtZipPassConfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZipPassConfirm.Location = New System.Drawing.Point(404, 22)
        Me.txtZipPassConfirm.Name = "txtZipPassConfirm"
        Me.txtZipPassConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(88)
        Me.txtZipPassConfirm.Size = New System.Drawing.Size(85, 22)
        Me.txtZipPassConfirm.TabIndex = 35
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(310, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(94, 13)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Confirm Password:"
        '
        'txtZipPass
        '
        Me.txtZipPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZipPass.Location = New System.Drawing.Point(217, 22)
        Me.txtZipPass.Name = "txtZipPass"
        Me.txtZipPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(88)
        Me.txtZipPass.Size = New System.Drawing.Size(85, 22)
        Me.txtZipPass.TabIndex = 34
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(161, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Password:"
        '
        'cboZipEncryption
        '
        Me.cboZipEncryption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZipEncryption.FormattingEnabled = True
        Me.cboZipEncryption.Items.AddRange(New Object() {"None", "AES - 128", "AES - 256"})
        Me.cboZipEncryption.Location = New System.Drawing.Point(66, 21)
        Me.cboZipEncryption.Name = "cboZipEncryption"
        Me.cboZipEncryption.Size = New System.Drawing.Size(87, 21)
        Me.cboZipEncryption.TabIndex = 33
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(4, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 17)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Encryption:"
        '
        'rbZip
        '
        Me.rbZip.AutoSize = True
        Me.rbZip.Checked = True
        Me.rbZip.Location = New System.Drawing.Point(38, 22)
        Me.rbZip.Name = "rbZip"
        Me.rbZip.Size = New System.Drawing.Size(74, 17)
        Me.rbZip.TabIndex = 31
        Me.rbZip.TabStop = True
        Me.rbZip.Text = "Create Zip"
        Me.rbZip.UseVisualStyleBackColor = True
        '
        'rbNoZip
        '
        Me.rbNoZip.AutoSize = True
        Me.rbNoZip.Location = New System.Drawing.Point(123, 22)
        Me.rbNoZip.Name = "rbNoZip"
        Me.rbNoZip.Size = New System.Drawing.Size(141, 17)
        Me.rbNoZip.TabIndex = 32
        Me.rbNoZip.Text = "Mirror Copy (Exact Copy)"
        Me.rbNoZip.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnExit.Location = New System.Drawing.Point(8, 423)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.btnExit.Size = New System.Drawing.Size(87, 25)
        Me.btnExit.TabIndex = 18
        Me.btnExit.Text = "   &Close"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnSave.Location = New System.Drawing.Point(131, 424)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnSave.Size = New System.Drawing.Size(87, 25)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "&OK"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.lblHeadingDesc)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.lblHeading)
        Me.Panel3.Location = New System.Drawing.Point(-2, -1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(563, 55)
        Me.Panel3.TabIndex = 22
        '
        'lblHeadingDesc
        '
        Me.lblHeadingDesc.AutoSize = True
        Me.lblHeadingDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblHeadingDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadingDesc.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.lblHeadingDesc.Location = New System.Drawing.Point(55, 32)
        Me.lblHeadingDesc.Name = "lblHeadingDesc"
        Me.lblHeadingDesc.Size = New System.Drawing.Size(264, 16)
        Me.lblHeadingDesc.TabIndex = 2
        Me.lblHeadingDesc.Text = "Schedule the task, select frequency and time"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lblHeading
        '
        Me.lblHeading.AutoSize = True
        Me.lblHeading.BackColor = System.Drawing.Color.Transparent
        Me.lblHeading.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.lblHeading.Location = New System.Drawing.Point(54, 10)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.Size = New System.Drawing.Size(226, 23)
        Me.lblHeading.TabIndex = 0
        Me.lblHeading.Text = "Backup Task Wizard"
        '
        'btnBack
        '
        Me.btnBack.Enabled = False
        Me.btnBack.Location = New System.Drawing.Point(379, 423)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(87, 25)
        Me.btnBack.TabIndex = 23
        Me.btnBack.Text = "< Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(472, 423)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(87, 25)
        Me.btnNext.TabIndex = 24
        Me.btnNext.Text = "Next >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'ErrTask
        '
        Me.ErrTask.ContainerControl = Me
        '
        'frmTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 454)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnExit)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTask"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add/Edit Backup Task"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.gbCustom.ResumeLayout(False)
        Me.gbCustom.PerformLayout()
        Me.gbDaily.ResumeLayout(False)
        Me.gbDaily.PerformLayout()
        Me.gbSelectedDays.ResumeLayout(False)
        Me.gbSelectedDays.PerformLayout()
        Me.gbWhenDT.ResumeLayout(False)
        Me.gbWhenDT.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.pnlFiles.ResumeLayout(False)
        Me.pnlFiles.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbDFTP.ResumeLayout(False)
        Me.gbDFTP.PerformLayout()
        Me.gbDLocal.ResumeLayout(False)
        Me.gbWEBDAV.ResumeLayout(False)
        Me.gbWEBDAV.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbZipOptions.ResumeLayout(False)
        Me.gbZipOptions.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents pnlFiles As System.Windows.Forms.Panel
    Friend WithEvents BrowseFrom As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lvwPics As System.Windows.Forms.ListView
    Friend WithEvents btnExclude As System.Windows.Forms.Button
    Friend WithEvents btnAddFiles As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTotalSize As System.Windows.Forms.Label
    Friend WithEvents txtTotalSize As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBackupName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboBackupType As System.Windows.Forms.ComboBox
    Friend WithEvents gbSelectedDays As System.Windows.Forms.GroupBox
    Friend WithEvents chkSun As System.Windows.Forms.CheckBox
    Friend WithEvents chkSat As System.Windows.Forms.CheckBox
    Friend WithEvents chkFri As System.Windows.Forms.CheckBox
    Friend WithEvents chkThu As System.Windows.Forms.CheckBox
    Friend WithEvents chkWen As System.Windows.Forms.CheckBox
    Friend WithEvents chkTue As System.Windows.Forms.CheckBox
    Friend WithEvents chkMon As System.Windows.Forms.CheckBox
    Friend WithEvents gbWhenDT As System.Windows.Forms.GroupBox
    Friend WithEvents dtpBDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAlwaysTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbDaily As System.Windows.Forms.GroupBox
    Friend WithEvents rbDExcludeSunday As System.Windows.Forms.RadioButton
    Friend WithEvents rbDWeekDays As System.Windows.Forms.RadioButton
    Friend WithEvents rbDEveryDay As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents gbCustom As System.Windows.Forms.GroupBox
    Friend WithEvents dtpC2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpC3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpC4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpC1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkCustomTime As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFTPP As System.Windows.Forms.TextBox
    Friend WithEvents txtFTPU As System.Windows.Forms.TextBox
    Friend WithEvents txtFTPServerName As System.Windows.Forms.TextBox
    Friend WithEvents btnDRemove As System.Windows.Forms.Button
    Friend WithEvents btnDFolder As System.Windows.Forms.Button
    Friend WithEvents lbLocal As System.Windows.Forms.ListBox
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbZip As System.Windows.Forms.RadioButton
    Friend WithEvents rbNoZip As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rbDifferential As System.Windows.Forms.RadioButton
    Friend WithEvents rbIncremental As System.Windows.Forms.RadioButton
    Friend WithEvents rbFullBackup As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblHeading As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents lblHeadingDesc As System.Windows.Forms.Label
    Friend WithEvents gbZipOptions As System.Windows.Forms.GroupBox
    Friend WithEvents txtZipPassConfirm As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtZipPass As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboZipEncryption As System.Windows.Forms.ComboBox
    Friend WithEvents rbDestSFTP As System.Windows.Forms.RadioButton
    Friend WithEvents rbDestFTP As System.Windows.Forms.RadioButton
    Friend WithEvents rbDestLocal As System.Windows.Forms.RadioButton
    Friend WithEvents gbDLocal As System.Windows.Forms.GroupBox
    Friend WithEvents gbDFTP As System.Windows.Forms.GroupBox
    Friend WithEvents txtFTPPort As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ErrTask As System.Windows.Forms.ErrorProvider
    Friend WithEvents rbDestWEBDAV As System.Windows.Forms.RadioButton
    Friend WithEvents gbWEBDAV As System.Windows.Forms.GroupBox
    Friend WithEvents txtWebDAVPort As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnWebDAVOk As System.Windows.Forms.Button
    Friend WithEvents txtWebDAVServer As System.Windows.Forms.TextBox
    Friend WithEvents btnWebDAVCancel As System.Windows.Forms.Button
    Friend WithEvents txtWebDAVUser As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtWebDAVPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents rbCustomTime As System.Windows.Forms.RadioButton
    Friend WithEvents rbAtEvery As System.Windows.Forms.RadioButton
    Friend WithEvents txtAtEvery As System.Windows.Forms.TextBox
    Friend WithEvents cmbAtEvery As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lvFilter As System.Windows.Forms.ListView
    Private WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAddFilter As System.Windows.Forms.Button
    Friend WithEvents btnAddRemove As System.Windows.Forms.Button
    Friend WithEvents rbSourceMYSQL As System.Windows.Forms.RadioButton
    Friend WithEvents rbSourceFiles As System.Windows.Forms.RadioButton
    Friend WithEvents pnlMYSQL As System.Windows.Forms.Panel
End Class
