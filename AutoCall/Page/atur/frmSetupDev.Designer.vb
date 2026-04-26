<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSetupDev
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetupDev))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnDel = New System.Windows.Forms.Button()
        Me.BtnRestar = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.lbltext = New System.Windows.Forms.Label()
        Me.Btn4 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtusbname = New AutoCall.UCformtext()
        Me.txtusbserial = New AutoCall.UCformtext()
        Me.Btn1 = New System.Windows.Forms.Button()
        Me.txtwifIp = New AutoCall.UCformtext()
        Me.txtwifPort = New AutoCall.UCformtext()
        Me.Btn2 = New System.Windows.Forms.Button()
        Me.figSize = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Btn3 = New System.Windows.Forms.Button()
        Me.Ukur = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtbitR = New System.Windows.Forms.TextBox()
        Me.aot = New System.Windows.Forms.CheckBox()
        Me.tso = New System.Windows.Forms.CheckBox()
        Me.sta = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Btn6 = New System.Windows.Forms.Button()
        Me.RUsb = New System.Windows.Forms.RadioButton()
        Me.RWifi = New System.Windows.Forms.RadioButton()
        Me.lbstatus = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnMenu = New System.Windows.Forms.Button()
        Me.BtnHome = New System.Windows.Forms.Button()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.termux = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnLimitCall = New System.Windows.Forms.Button()
        Me.BtnLimitMsg = New System.Windows.Forms.Button()
        Me.WAO_Caller = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.WAB_Caller = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TLC_Caller = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.WAO_Message = New System.Windows.Forms.NumericUpDown()
        Me.WAB_Message = New System.Windows.Forms.NumericUpDown()
        Me.SMS = New System.Windows.Forms.NumericUpDown()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.SMS_mspam = New System.Windows.Forms.NumericUpDown()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.WAB_Message_mspam = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.WAO_Message_mspam = New System.Windows.Forms.NumericUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TLC_Caller_recall = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.WAB_Caller_recall = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.WAO_Caller_recall = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.WAO_Caller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WAB_Caller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLC_Caller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WAO_Message, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WAB_Message, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.SMS_mspam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WAB_Message_mspam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WAO_Message_mspam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLC_Caller_recall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WAB_Caller_recall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WAO_Caller_recall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnDel)
        Me.Panel1.Controls.Add(Me.BtnRestar)
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Controls.Add(Me.lbltext)
        Me.Panel1.Controls.Add(Me.Btn4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(504, 45)
        Me.Panel1.TabIndex = 141
        '
        'BtnDel
        '
        Me.BtnDel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnDel.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.BtnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDel.FlatAppearance.BorderSize = 0
        Me.BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDel.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(273, 5)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(35, 35)
        Me.BtnDel.TabIndex = 142
        Me.BtnDel.UseVisualStyleBackColor = False
        '
        'BtnRestar
        '
        Me.BtnRestar.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnRestar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRestar.FlatAppearance.BorderSize = 0
        Me.BtnRestar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRestar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRestar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnRestar.Location = New System.Drawing.Point(385, 4)
        Me.BtnRestar.Name = "BtnRestar"
        Me.BtnRestar.Size = New System.Drawing.Size(57, 36)
        Me.BtnRestar.TabIndex = 141
        Me.BtnRestar.Text = "Restart"
        Me.BtnRestar.UseVisualStyleBackColor = False
        '
        'btnclose
        '
        Me.btnclose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnclose.FlatAppearance.BorderSize = 0
        Me.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.White
        Me.btnclose.Location = New System.Drawing.Point(454, 0)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(50, 45)
        Me.btnclose.TabIndex = 140
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'lbltext
        '
        Me.lbltext.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.lbltext.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltext.ForeColor = System.Drawing.Color.White
        Me.lbltext.Location = New System.Drawing.Point(11, 5)
        Me.lbltext.Name = "lbltext"
        Me.lbltext.Size = New System.Drawing.Size(256, 30)
        Me.lbltext.TabIndex = 139
        '
        'Btn4
        '
        Me.Btn4.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Btn4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn4.FlatAppearance.BorderSize = 0
        Me.Btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Btn4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn4.Location = New System.Drawing.Point(313, 5)
        Me.Btn4.Name = "Btn4"
        Me.Btn4.Size = New System.Drawing.Size(67, 34)
        Me.Btn4.TabIndex = 130
        Me.Btn4.Text = "Mirror"
        Me.Btn4.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label9.Font = New System.Drawing.Font("Bodoni MT", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(12, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(225, 28)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Setup"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Bodoni MT", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 175)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 28)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Setup Wifi"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Bodoni MT", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(240, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 28)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Start Config"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtusbname
        '
        Me.txtusbname.BackColor = System.Drawing.Color.Transparent
        Me.txtusbname.Location = New System.Drawing.Point(0, 45)
        Me.txtusbname.Name = "txtusbname"
        Me.txtusbname.Size = New System.Drawing.Size(237, 62)
        Me.txtusbname.TabIndex = 95
        '
        'txtusbserial
        '
        Me.txtusbserial.BackColor = System.Drawing.Color.Transparent
        Me.txtusbserial.Location = New System.Drawing.Point(0, 106)
        Me.txtusbserial.Name = "txtusbserial"
        Me.txtusbserial.Size = New System.Drawing.Size(237, 62)
        Me.txtusbserial.TabIndex = 96
        '
        'Btn1
        '
        Me.Btn1.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Btn1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn1.FlatAppearance.BorderSize = 0
        Me.Btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Btn1.Location = New System.Drawing.Point(167, 12)
        Me.Btn1.Name = "Btn1"
        Me.Btn1.Size = New System.Drawing.Size(70, 24)
        Me.Btn1.TabIndex = 107
        Me.Btn1.Text = "save"
        Me.Btn1.UseVisualStyleBackColor = False
        '
        'txtwifIp
        '
        Me.txtwifIp.BackColor = System.Drawing.Color.Transparent
        Me.txtwifIp.Location = New System.Drawing.Point(3, 206)
        Me.txtwifIp.Name = "txtwifIp"
        Me.txtwifIp.Size = New System.Drawing.Size(234, 62)
        Me.txtwifIp.TabIndex = 108
        '
        'txtwifPort
        '
        Me.txtwifPort.BackColor = System.Drawing.Color.Transparent
        Me.txtwifPort.Location = New System.Drawing.Point(3, 268)
        Me.txtwifPort.Name = "txtwifPort"
        Me.txtwifPort.Size = New System.Drawing.Size(100, 62)
        Me.txtwifPort.TabIndex = 109
        '
        'Btn2
        '
        Me.Btn2.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Btn2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn2.FlatAppearance.BorderSize = 0
        Me.Btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Btn2.Location = New System.Drawing.Point(167, 177)
        Me.Btn2.Name = "Btn2"
        Me.Btn2.Size = New System.Drawing.Size(70, 24)
        Me.Btn2.TabIndex = 110
        Me.Btn2.Text = "save"
        Me.Btn2.UseVisualStyleBackColor = False
        '
        'figSize
        '
        Me.figSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.figSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.figSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.figSize.ForeColor = System.Drawing.Color.White
        Me.figSize.FormattingEnabled = True
        Me.figSize.Items.AddRange(New Object() {"500", "640", "720", "1080", "1280", "1920"})
        Me.figSize.Location = New System.Drawing.Point(243, 153)
        Me.figSize.Name = "figSize"
        Me.figSize.Size = New System.Drawing.Size(94, 28)
        Me.figSize.TabIndex = 111
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(243, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Max Size"
        '
        'Btn3
        '
        Me.Btn3.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Btn3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn3.FlatAppearance.BorderSize = 0
        Me.Btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Btn3.Location = New System.Drawing.Point(422, 94)
        Me.Btn3.Name = "Btn3"
        Me.Btn3.Size = New System.Drawing.Size(70, 24)
        Me.Btn3.TabIndex = 113
        Me.Btn3.Text = "save"
        Me.Btn3.UseVisualStyleBackColor = False
        '
        'Ukur
        '
        Me.Ukur.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Ukur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Ukur.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ukur.ForeColor = System.Drawing.Color.White
        Me.Ukur.FormattingEnabled = True
        Me.Ukur.Items.AddRange(New Object() {"Mbps", "Kbps"})
        Me.Ukur.Location = New System.Drawing.Point(433, 154)
        Me.Ukur.Name = "Ukur"
        Me.Ukur.Size = New System.Drawing.Size(59, 28)
        Me.Ukur.TabIndex = 114
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(343, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Bit Rate"
        '
        'txtbitR
        '
        Me.txtbitR.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.txtbitR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbitR.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbitR.ForeColor = System.Drawing.Color.White
        Me.txtbitR.Location = New System.Drawing.Point(346, 154)
        Me.txtbitR.Name = "txtbitR"
        Me.txtbitR.Size = New System.Drawing.Size(81, 28)
        Me.txtbitR.TabIndex = 116
        '
        'aot
        '
        Me.aot.AutoSize = True
        Me.aot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aot.ForeColor = System.Drawing.Color.White
        Me.aot.Location = New System.Drawing.Point(253, 203)
        Me.aot.Name = "aot"
        Me.aot.Size = New System.Drawing.Size(119, 20)
        Me.aot.TabIndex = 117
        Me.aot.Text = "--always-on-top"
        Me.aot.UseVisualStyleBackColor = True
        '
        'tso
        '
        Me.tso.AutoSize = True
        Me.tso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tso.ForeColor = System.Drawing.Color.White
        Me.tso.Location = New System.Drawing.Point(253, 229)
        Me.tso.Name = "tso"
        Me.tso.Size = New System.Drawing.Size(119, 20)
        Me.tso.TabIndex = 118
        Me.tso.Text = "--turn-screen-off"
        Me.tso.UseVisualStyleBackColor = True
        '
        'sta
        '
        Me.sta.AutoSize = True
        Me.sta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sta.ForeColor = System.Drawing.Color.White
        Me.sta.Location = New System.Drawing.Point(388, 203)
        Me.sta.Name = "sta"
        Me.sta.Size = New System.Drawing.Size(104, 20)
        Me.sta.TabIndex = 119
        Me.sta.Text = "--stay-awake"
        Me.sta.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Bodoni MT", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(243, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(249, 28)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Set Connection"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Btn6
        '
        Me.Btn6.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Btn6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn6.FlatAppearance.BorderSize = 0
        Me.Btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Btn6.Location = New System.Drawing.Point(422, 14)
        Me.Btn6.Name = "Btn6"
        Me.Btn6.Size = New System.Drawing.Size(70, 24)
        Me.Btn6.TabIndex = 133
        Me.Btn6.Text = "save"
        Me.Btn6.UseVisualStyleBackColor = False
        '
        'RUsb
        '
        Me.RUsb.AutoSize = True
        Me.RUsb.ForeColor = System.Drawing.Color.White
        Me.RUsb.Location = New System.Drawing.Point(266, 54)
        Me.RUsb.Name = "RUsb"
        Me.RUsb.Size = New System.Drawing.Size(47, 17)
        Me.RUsb.TabIndex = 134
        Me.RUsb.TabStop = True
        Me.RUsb.Text = "USB"
        Me.RUsb.UseVisualStyleBackColor = True
        '
        'RWifi
        '
        Me.RWifi.AutoSize = True
        Me.RWifi.ForeColor = System.Drawing.Color.White
        Me.RWifi.Location = New System.Drawing.Point(324, 54)
        Me.RWifi.Name = "RWifi"
        Me.RWifi.Size = New System.Drawing.Size(81, 17)
        Me.RWifi.TabIndex = 135
        Me.RWifi.TabStop = True
        Me.RWifi.Text = "NETWORK"
        Me.RWifi.UseVisualStyleBackColor = True
        '
        'lbstatus
        '
        Me.lbstatus.AutoSize = True
        Me.lbstatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lbstatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbstatus.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbstatus.ForeColor = System.Drawing.Color.White
        Me.lbstatus.Location = New System.Drawing.Point(180, 217)
        Me.lbstatus.Name = "lbstatus"
        Me.lbstatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbstatus.Size = New System.Drawing.Size(37, 14)
        Me.lbstatus.TabIndex = 187
        Me.lbstatus.Text = "Ofline"
        Me.lbstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSalmon
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Bodoni MT", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(243, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(249, 28)
        Me.Label5.TabIndex = 188
        Me.Label5.Text = "Control Shortcut"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnMenu
        '
        Me.BtnMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMenu.FlatAppearance.BorderSize = 0
        Me.BtnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMenu.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnMenu.Location = New System.Drawing.Point(258, 293)
        Me.BtnMenu.Name = "BtnMenu"
        Me.BtnMenu.Size = New System.Drawing.Size(70, 37)
        Me.BtnMenu.TabIndex = 189
        Me.BtnMenu.Text = "Menu"
        Me.BtnMenu.UseVisualStyleBackColor = False
        '
        'BtnHome
        '
        Me.BtnHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnHome.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnHome.FlatAppearance.BorderSize = 0
        Me.BtnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHome.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnHome.Location = New System.Drawing.Point(334, 293)
        Me.BtnHome.Name = "BtnHome"
        Me.BtnHome.Size = New System.Drawing.Size(70, 37)
        Me.BtnHome.TabIndex = 190
        Me.BtnHome.Text = "Home"
        Me.BtnHome.UseVisualStyleBackColor = False
        '
        'BtnBack
        '
        Me.BtnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnBack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBack.FlatAppearance.BorderSize = 0
        Me.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBack.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnBack.Location = New System.Drawing.Point(410, 293)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(70, 37)
        Me.BtnBack.TabIndex = 191
        Me.BtnBack.Text = "Back"
        Me.BtnBack.UseVisualStyleBackColor = False
        '
        'termux
        '
        Me.termux.AutoSize = True
        Me.termux.ForeColor = System.Drawing.Color.White
        Me.termux.Location = New System.Drawing.Point(411, 54)
        Me.termux.Name = "termux"
        Me.termux.Size = New System.Drawing.Size(71, 17)
        Me.termux.TabIndex = 192
        Me.termux.TabStop = True
        Me.termux.Text = "TERMUX"
        Me.termux.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.RosyBrown
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label7.Font = New System.Drawing.Font("Bodoni MT", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(12, 356)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(205, 28)
        Me.Label7.TabIndex = 193
        Me.Label7.Text = "Limit Caller"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.RosyBrown
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.Font = New System.Drawing.Font("Bodoni MT", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(243, 356)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(246, 28)
        Me.Label8.TabIndex = 194
        Me.Label8.Text = "Limit Message"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnLimitCall
        '
        Me.BtnLimitCall.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnLimitCall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLimitCall.FlatAppearance.BorderSize = 0
        Me.BtnLimitCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLimitCall.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLimitCall.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnLimitCall.Location = New System.Drawing.Point(145, 358)
        Me.BtnLimitCall.Name = "BtnLimitCall"
        Me.BtnLimitCall.Size = New System.Drawing.Size(70, 24)
        Me.BtnLimitCall.TabIndex = 201
        Me.BtnLimitCall.Text = "save"
        Me.BtnLimitCall.UseVisualStyleBackColor = False
        '
        'BtnLimitMsg
        '
        Me.BtnLimitMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnLimitMsg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLimitMsg.FlatAppearance.BorderSize = 0
        Me.BtnLimitMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLimitMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLimitMsg.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnLimitMsg.Location = New System.Drawing.Point(417, 358)
        Me.BtnLimitMsg.Name = "BtnLimitMsg"
        Me.BtnLimitMsg.Size = New System.Drawing.Size(70, 24)
        Me.BtnLimitMsg.TabIndex = 202
        Me.BtnLimitMsg.Text = "save"
        Me.BtnLimitMsg.UseVisualStyleBackColor = False
        '
        'WAO_Caller
        '
        Me.WAO_Caller.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.WAO_Caller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WAO_Caller.ForeColor = System.Drawing.Color.White
        Me.WAO_Caller.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.WAO_Caller.Location = New System.Drawing.Point(15, 414)
        Me.WAO_Caller.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.WAO_Caller.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.WAO_Caller.Name = "WAO_Caller"
        Me.WAO_Caller.ReadOnly = True
        Me.WAO_Caller.Size = New System.Drawing.Size(62, 20)
        Me.WAO_Caller.TabIndex = 204
        Me.WAO_Caller.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.WAO_Caller.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(15, 398)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(138, 13)
        Me.Label10.TabIndex = 203
        Me.Label10.Text = "WhatsApp Message (WAO)"
        '
        'WAB_Caller
        '
        Me.WAB_Caller.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.WAB_Caller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WAB_Caller.ForeColor = System.Drawing.Color.White
        Me.WAB_Caller.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.WAB_Caller.Location = New System.Drawing.Point(18, 468)
        Me.WAB_Caller.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.WAB_Caller.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.WAB_Caller.Name = "WAB_Caller"
        Me.WAB_Caller.ReadOnly = True
        Me.WAB_Caller.Size = New System.Drawing.Size(59, 20)
        Me.WAB_Caller.TabIndex = 206
        Me.WAB_Caller.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.WAB_Caller.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(18, 452)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 13)
        Me.Label11.TabIndex = 205
        Me.Label11.Text = "WhatsApp Bisnis (WAB)"
        '
        'TLC_Caller
        '
        Me.TLC_Caller.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TLC_Caller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLC_Caller.ForeColor = System.Drawing.Color.White
        Me.TLC_Caller.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.TLC_Caller.Location = New System.Drawing.Point(18, 519)
        Me.TLC_Caller.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.TLC_Caller.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TLC_Caller.Name = "TLC_Caller"
        Me.TLC_Caller.ReadOnly = True
        Me.TLC_Caller.Size = New System.Drawing.Size(59, 20)
        Me.TLC_Caller.TabIndex = 208
        Me.TLC_Caller.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TLC_Caller.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(18, 503)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 13)
        Me.Label12.TabIndex = 207
        Me.Label12.Text = "Telepon Selular (TLC)"
        '
        'WAO_Message
        '
        Me.WAO_Message.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.WAO_Message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WAO_Message.ForeColor = System.Drawing.Color.White
        Me.WAO_Message.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.WAO_Message.Location = New System.Drawing.Point(260, 414)
        Me.WAO_Message.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.WAO_Message.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.WAO_Message.Name = "WAO_Message"
        Me.WAO_Message.ReadOnly = True
        Me.WAO_Message.Size = New System.Drawing.Size(68, 20)
        Me.WAO_Message.TabIndex = 210
        Me.WAO_Message.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.WAO_Message.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'WAB_Message
        '
        Me.WAB_Message.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.WAB_Message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WAB_Message.ForeColor = System.Drawing.Color.White
        Me.WAB_Message.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.WAB_Message.Location = New System.Drawing.Point(263, 468)
        Me.WAB_Message.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.WAB_Message.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.WAB_Message.Name = "WAB_Message"
        Me.WAB_Message.ReadOnly = True
        Me.WAB_Message.Size = New System.Drawing.Size(65, 20)
        Me.WAB_Message.TabIndex = 212
        Me.WAB_Message.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.WAB_Message.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'SMS
        '
        Me.SMS.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.SMS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SMS.ForeColor = System.Drawing.Color.White
        Me.SMS.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.SMS.Location = New System.Drawing.Point(263, 519)
        Me.SMS.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.SMS.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SMS.Name = "SMS"
        Me.SMS.ReadOnly = True
        Me.SMS.Size = New System.Drawing.Size(65, 20)
        Me.SMS.TabIndex = 214
        Me.SMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SMS.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.SMS_mspam)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.WAB_Message_mspam)
        Me.Panel2.Controls.Add(Me.Label27)
        Me.Panel2.Controls.Add(Me.WAO_Message_mspam)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.TLC_Caller_recall)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.WAB_Caller_recall)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.WAO_Caller_recall)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.SMS)
        Me.Panel2.Controls.Add(Me.WAB_Message)
        Me.Panel2.Controls.Add(Me.WAO_Message)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.TLC_Caller)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.WAB_Caller)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.WAO_Caller)
        Me.Panel2.Controls.Add(Me.BtnLimitMsg)
        Me.Panel2.Controls.Add(Me.BtnLimitCall)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.termux)
        Me.Panel2.Controls.Add(Me.BtnBack)
        Me.Panel2.Controls.Add(Me.BtnHome)
        Me.Panel2.Controls.Add(Me.BtnMenu)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lbstatus)
        Me.Panel2.Controls.Add(Me.RWifi)
        Me.Panel2.Controls.Add(Me.RUsb)
        Me.Panel2.Controls.Add(Me.Btn6)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.sta)
        Me.Panel2.Controls.Add(Me.tso)
        Me.Panel2.Controls.Add(Me.aot)
        Me.Panel2.Controls.Add(Me.txtbitR)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Ukur)
        Me.Panel2.Controls.Add(Me.Btn3)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.figSize)
        Me.Panel2.Controls.Add(Me.Btn2)
        Me.Panel2.Controls.Add(Me.txtwifPort)
        Me.Panel2.Controls.Add(Me.txtwifIp)
        Me.Panel2.Controls.Add(Me.Btn1)
        Me.Panel2.Controls.Add(Me.txtusbserial)
        Me.Panel2.Controls.Add(Me.txtusbname)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 45)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(504, 564)
        Me.Panel2.TabIndex = 142
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(443, 526)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(55, 13)
        Me.Label25.TabIndex = 235
        Me.Label25.Text = "Max spam"
        '
        'SMS_mspam
        '
        Me.SMS_mspam.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.SMS_mspam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SMS_mspam.ForeColor = System.Drawing.Color.White
        Me.SMS_mspam.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.SMS_mspam.Location = New System.Drawing.Point(386, 519)
        Me.SMS_mspam.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.SMS_mspam.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SMS_mspam.Name = "SMS_mspam"
        Me.SMS_mspam.ReadOnly = True
        Me.SMS_mspam.Size = New System.Drawing.Size(55, 20)
        Me.SMS_mspam.TabIndex = 234
        Me.SMS_mspam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SMS_mspam.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(443, 475)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(55, 13)
        Me.Label26.TabIndex = 233
        Me.Label26.Text = "Max spam"
        '
        'WAB_Message_mspam
        '
        Me.WAB_Message_mspam.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.WAB_Message_mspam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WAB_Message_mspam.ForeColor = System.Drawing.Color.White
        Me.WAB_Message_mspam.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.WAB_Message_mspam.Location = New System.Drawing.Point(386, 468)
        Me.WAB_Message_mspam.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.WAB_Message_mspam.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.WAB_Message_mspam.Name = "WAB_Message_mspam"
        Me.WAB_Message_mspam.ReadOnly = True
        Me.WAB_Message_mspam.Size = New System.Drawing.Size(55, 20)
        Me.WAB_Message_mspam.TabIndex = 232
        Me.WAB_Message_mspam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.WAB_Message_mspam.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(443, 421)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 13)
        Me.Label27.TabIndex = 231
        Me.Label27.Text = "Max spam"
        '
        'WAO_Message_mspam
        '
        Me.WAO_Message_mspam.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.WAO_Message_mspam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WAO_Message_mspam.ForeColor = System.Drawing.Color.White
        Me.WAO_Message_mspam.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.WAO_Message_mspam.Location = New System.Drawing.Point(386, 414)
        Me.WAO_Message_mspam.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.WAO_Message_mspam.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.WAO_Message_mspam.Name = "WAO_Message_mspam"
        Me.WAO_Message_mspam.ReadOnly = True
        Me.WAO_Message_mspam.Size = New System.Drawing.Size(55, 20)
        Me.WAO_Message_mspam.TabIndex = 230
        Me.WAO_Message_mspam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.WAO_Message_mspam.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(191, 526)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(46, 13)
        Me.Label24.TabIndex = 229
        Me.Label24.Text = "/ ReCall"
        '
        'TLC_Caller_recall
        '
        Me.TLC_Caller_recall.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TLC_Caller_recall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLC_Caller_recall.ForeColor = System.Drawing.Color.White
        Me.TLC_Caller_recall.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.TLC_Caller_recall.Location = New System.Drawing.Point(134, 519)
        Me.TLC_Caller_recall.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.TLC_Caller_recall.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TLC_Caller_recall.Name = "TLC_Caller_recall"
        Me.TLC_Caller_recall.ReadOnly = True
        Me.TLC_Caller_recall.Size = New System.Drawing.Size(55, 20)
        Me.TLC_Caller_recall.TabIndex = 228
        Me.TLC_Caller_recall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TLC_Caller_recall.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(191, 475)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(46, 13)
        Me.Label23.TabIndex = 227
        Me.Label23.Text = "/ ReCall"
        '
        'WAB_Caller_recall
        '
        Me.WAB_Caller_recall.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.WAB_Caller_recall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WAB_Caller_recall.ForeColor = System.Drawing.Color.White
        Me.WAB_Caller_recall.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.WAB_Caller_recall.Location = New System.Drawing.Point(134, 468)
        Me.WAB_Caller_recall.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.WAB_Caller_recall.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.WAB_Caller_recall.Name = "WAB_Caller_recall"
        Me.WAB_Caller_recall.ReadOnly = True
        Me.WAB_Caller_recall.Size = New System.Drawing.Size(55, 20)
        Me.WAB_Caller_recall.TabIndex = 226
        Me.WAB_Caller_recall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.WAB_Caller_recall.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(191, 421)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(46, 13)
        Me.Label22.TabIndex = 225
        Me.Label22.Text = "/ ReCall"
        '
        'WAO_Caller_recall
        '
        Me.WAO_Caller_recall.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.WAO_Caller_recall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WAO_Caller_recall.ForeColor = System.Drawing.Color.White
        Me.WAO_Caller_recall.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.WAO_Caller_recall.Location = New System.Drawing.Point(134, 414)
        Me.WAO_Caller_recall.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.WAO_Caller_recall.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.WAO_Caller_recall.Name = "WAO_Caller_recall"
        Me.WAO_Caller_recall.ReadOnly = True
        Me.WAO_Caller_recall.Size = New System.Drawing.Size(55, 20)
        Me.WAO_Caller_recall.TabIndex = 224
        Me.WAO_Caller_recall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.WAO_Caller_recall.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(331, 526)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 223
        Me.Label19.Text = "/ Hari"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(331, 475)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(34, 13)
        Me.Label20.TabIndex = 222
        Me.Label20.Text = "/ Hari"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(331, 421)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(34, 13)
        Me.Label21.TabIndex = 221
        Me.Label21.Text = "/ Hari"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(83, 526)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 13)
        Me.Label18.TabIndex = 220
        Me.Label18.Text = "/ Hari"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(83, 475)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 13)
        Me.Label17.TabIndex = 219
        Me.Label17.Text = "/ Hari"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(83, 421)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 218
        Me.Label16.Text = "/ Hari"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(260, 503)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 217
        Me.Label13.Text = "SMS"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(260, 452)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(121, 13)
        Me.Label14.TabIndex = 216
        Me.Label14.Text = "WhatsApp Bisnis (WAB)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(257, 398)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(138, 13)
        Me.Label15.TabIndex = 215
        Me.Label15.Text = "WhatsApp Message (WAO)"
        '
        'frmSetupDev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(504, 609)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSetupDev"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSetupDev"
        Me.Panel1.ResumeLayout(False)
        CType(Me.WAO_Caller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WAB_Caller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLC_Caller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WAO_Message, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WAB_Message, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.SMS_mspam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WAB_Message_mspam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WAO_Message_mspam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLC_Caller_recall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WAB_Caller_recall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WAO_Caller_recall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnclose As Button
    Friend WithEvents lbltext As Label
    Friend WithEvents Btn4 As Button
    Friend WithEvents BtnRestar As Button
    Friend WithEvents BtnDel As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtusbname As UCformtext
    Friend WithEvents txtusbserial As UCformtext
    Friend WithEvents Btn1 As Button
    Friend WithEvents txtwifIp As UCformtext
    Friend WithEvents txtwifPort As UCformtext
    Friend WithEvents Btn2 As Button
    Friend WithEvents figSize As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Btn3 As Button
    Friend WithEvents Ukur As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtbitR As TextBox
    Friend WithEvents aot As CheckBox
    Friend WithEvents tso As CheckBox
    Friend WithEvents sta As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Btn6 As Button
    Friend WithEvents RUsb As RadioButton
    Friend WithEvents RWifi As RadioButton
    Friend WithEvents lbstatus As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnMenu As Button
    Friend WithEvents BtnHome As Button
    Friend WithEvents BtnBack As Button
    Friend WithEvents termux As RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnLimitCall As Button
    Friend WithEvents BtnLimitMsg As Button
    Friend WithEvents WAO_Caller As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents WAB_Caller As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents TLC_Caller As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents WAO_Message As NumericUpDown
    Friend WithEvents WAB_Message As NumericUpDown
    Friend WithEvents SMS As NumericUpDown
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents WAO_Caller_recall As NumericUpDown
    Friend WithEvents Label24 As Label
    Friend WithEvents TLC_Caller_recall As NumericUpDown
    Friend WithEvents Label23 As Label
    Friend WithEvents WAB_Caller_recall As NumericUpDown
    Friend WithEvents Label25 As Label
    Friend WithEvents SMS_mspam As NumericUpDown
    Friend WithEvents Label26 As Label
    Friend WithEvents WAB_Message_mspam As NumericUpDown
    Friend WithEvents Label27 As Label
    Friend WithEvents WAO_Message_mspam As NumericUpDown
End Class
