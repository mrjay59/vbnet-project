<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddDevices
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddDevices))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panelgb = New System.Windows.Forms.Panel()
        Me.BtnListA = New System.Windows.Forms.Button()
        Me.BtnNewA = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PilPrefix = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.txtnum1 = New System.Windows.Forms.TextBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.txtnum2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtuser = New System.Windows.Forms.TextBox()
        Me.BtnConnect = New System.Windows.Forms.Button()
        Me.rd1 = New System.Windows.Forms.RadioButton()
        Me.rd0 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComApk = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lblname = New System.Windows.Forms.Label()
        Me.ComDev = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ViewTabel = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.app = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.edit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnRef = New System.Windows.Forms.Button()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelPusat
        '
        Me.PanelPusat.AutoScroll = True
        Me.PanelPusat.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelPusat.Location = New System.Drawing.Point(0, 74)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(376, 505)
        Me.PanelPusat.TabIndex = 143
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panelgb)
        Me.Panel1.Controls.Add(Me.BtnListA)
        Me.Panel1.Controls.Add(Me.BtnNewA)
        Me.Panel1.Controls.Add(Me.PanelPusat)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(1, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(376, 579)
        Me.Panel1.TabIndex = 189
        '
        'Panelgb
        '
        Me.Panelgb.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Panelgb.Location = New System.Drawing.Point(9, 69)
        Me.Panelgb.Name = "Panelgb"
        Me.Panelgb.Size = New System.Drawing.Size(100, 5)
        Me.Panelgb.TabIndex = 200
        Me.Panelgb.Visible = False
        '
        'BtnListA
        '
        Me.BtnListA.BackColor = System.Drawing.Color.Gray
        Me.BtnListA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnListA.FlatAppearance.BorderSize = 0
        Me.BtnListA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnListA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnListA.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnListA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnListA.Location = New System.Drawing.Point(139, 47)
        Me.BtnListA.Name = "BtnListA"
        Me.BtnListA.Size = New System.Drawing.Size(119, 21)
        Me.BtnListA.TabIndex = 199
        Me.BtnListA.Text = "Cloud Android"
        Me.BtnListA.UseVisualStyleBackColor = False
        '
        'BtnNewA
        '
        Me.BtnNewA.BackColor = System.Drawing.Color.Gray
        Me.BtnNewA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNewA.FlatAppearance.BorderSize = 0
        Me.BtnNewA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNewA.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNewA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNewA.Location = New System.Drawing.Point(11, 47)
        Me.BtnNewA.Name = "BtnNewA"
        Me.BtnNewA.Size = New System.Drawing.Size(122, 21)
        Me.BtnNewA.TabIndex = 198
        Me.BtnNewA.Text = "Local Android"
        Me.BtnNewA.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.BtnRefresh)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(376, 41)
        Me.Panel3.TabIndex = 3
        '
        'BtnRefresh
        '
        Me.BtnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.BtnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRefresh.FlatAppearance.BorderSize = 0
        Me.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRefresh.ForeColor = System.Drawing.Color.Transparent
        Me.BtnRefresh.Image = CType(resources.GetObject("BtnRefresh.Image"), System.Drawing.Image)
        Me.BtnRefresh.Location = New System.Drawing.Point(324, 5)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Padding = New System.Windows.Forms.Padding(5)
        Me.BtnRefresh.Size = New System.Drawing.Size(40, 30)
        Me.BtnRefresh.TabIndex = 78
        Me.BtnRefresh.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(5, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(182, 23)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "List Android Connect"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Location = New System.Drawing.Point(383, 7)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(406, 331)
        Me.Panel2.TabIndex = 190
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.PilPrefix)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.txtuser)
        Me.Panel4.Controls.Add(Me.BtnConnect)
        Me.Panel4.Controls.Add(Me.rd1)
        Me.Panel4.Controls.Add(Me.rd0)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.ComApk)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Lblname)
        Me.Panel4.Controls.Add(Me.ComDev)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 41)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(406, 290)
        Me.Panel4.TabIndex = 143
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(184, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 195
        Me.Label6.Text = "Prefix"
        '
        'PilPrefix
        '
        Me.PilPrefix.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.PilPrefix.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PilPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PilPrefix.ForeColor = System.Drawing.Color.White
        Me.PilPrefix.FormattingEnabled = True
        Me.PilPrefix.Items.AddRange(New Object() {"Blank", "062", "62", "0"})
        Me.PilPrefix.Location = New System.Drawing.Point(186, 166)
        Me.PilPrefix.Name = "PilPrefix"
        Me.PilPrefix.Size = New System.Drawing.Size(89, 28)
        Me.PilPrefix.TabIndex = 194
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl2)
        Me.GroupBox1.Controls.Add(Me.txtnum1)
        Me.GroupBox1.Controls.Add(Me.lbl1)
        Me.GroupBox1.Controls.Add(Me.txtnum2)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(11, 200)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 80)
        Me.GroupBox1.TabIndex = 193
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data SIM"
        '
        'lbl2
        '
        Me.lbl2.AutoSize = True
        Me.lbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.ForeColor = System.Drawing.Color.White
        Me.lbl2.Location = New System.Drawing.Point(172, 20)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(35, 13)
        Me.lbl2.TabIndex = 196
        Me.lbl2.Text = "SIM 2"
        Me.lbl2.Visible = False
        '
        'txtnum1
        '
        Me.txtnum1.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.txtnum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnum1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnum1.ForeColor = System.Drawing.Color.White
        Me.txtnum1.Location = New System.Drawing.Point(6, 36)
        Me.txtnum1.Name = "txtnum1"
        Me.txtnum1.Size = New System.Drawing.Size(133, 26)
        Me.txtnum1.TabIndex = 193
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.White
        Me.lbl1.Location = New System.Drawing.Point(3, 18)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(35, 13)
        Me.lbl1.TabIndex = 194
        Me.lbl1.Text = "SIM 1"
        '
        'txtnum2
        '
        Me.txtnum2.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.txtnum2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnum2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnum2.ForeColor = System.Drawing.Color.White
        Me.txtnum2.Location = New System.Drawing.Point(175, 36)
        Me.txtnum2.Name = "txtnum2"
        Me.txtnum2.Size = New System.Drawing.Size(133, 26)
        Me.txtnum2.TabIndex = 195
        Me.txtnum2.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(182, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 192
        Me.Label5.Text = "User "
        Me.Label5.Visible = False
        '
        'txtuser
        '
        Me.txtuser.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.txtuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuser.ForeColor = System.Drawing.Color.White
        Me.txtuser.Location = New System.Drawing.Point(185, 106)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(90, 26)
        Me.txtuser.TabIndex = 191
        Me.txtuser.Visible = False
        '
        'BtnConnect
        '
        Me.BtnConnect.BackColor = System.Drawing.Color.Transparent
        Me.BtnConnect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConnect.FlatAppearance.BorderSize = 0
        Me.BtnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnConnect.ForeColor = System.Drawing.Color.Transparent
        Me.BtnConnect.Image = CType(resources.GetObject("BtnConnect.Image"), System.Drawing.Image)
        Me.BtnConnect.Location = New System.Drawing.Point(177, 39)
        Me.BtnConnect.Name = "BtnConnect"
        Me.BtnConnect.Padding = New System.Windows.Forms.Padding(5)
        Me.BtnConnect.Size = New System.Drawing.Size(25, 25)
        Me.BtnConnect.TabIndex = 159
        Me.BtnConnect.UseVisualStyleBackColor = False
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.ForeColor = System.Drawing.Color.White
        Me.rd1.Location = New System.Drawing.Point(88, 170)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(38, 17)
        Me.rd1.TabIndex = 150
        Me.rd1.TabStop = True
        Me.rd1.Text = "Ya"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'rd0
        '
        Me.rd0.AutoSize = True
        Me.rd0.Checked = True
        Me.rd0.ForeColor = System.Drawing.Color.White
        Me.rd0.Location = New System.Drawing.Point(16, 170)
        Me.rd0.Name = "rd0"
        Me.rd0.Size = New System.Drawing.Size(52, 17)
        Me.rd0.TabIndex = 149
        Me.rd0.TabStop = True
        Me.rd0.Text = "Tidak"
        Me.rd0.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 13)
        Me.Label4.TabIndex = 148
        Me.Label4.Text = "Have Dual Apps Or Cloning"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "Aplikasi Android :"
        '
        'ComApk
        '
        Me.ComApk.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ComApk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComApk.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComApk.ForeColor = System.Drawing.Color.White
        Me.ComApk.FormattingEnabled = True
        Me.ComApk.Location = New System.Drawing.Point(9, 105)
        Me.ComApk.Name = "ComApk"
        Me.ComApk.Size = New System.Drawing.Size(164, 28)
        Me.ComApk.TabIndex = 146
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "Device Android :"
        '
        'Lblname
        '
        Me.Lblname.AutoSize = True
        Me.Lblname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblname.ForeColor = System.Drawing.Color.White
        Me.Lblname.Location = New System.Drawing.Point(30, 86)
        Me.Lblname.Name = "Lblname"
        Me.Lblname.Size = New System.Drawing.Size(0, 13)
        Me.Lblname.TabIndex = 144
        '
        'ComDev
        '
        Me.ComDev.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ComDev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComDev.ForeColor = System.Drawing.Color.White
        Me.ComDev.FormattingEnabled = True
        Me.ComDev.Location = New System.Drawing.Point(9, 39)
        Me.ComDev.Name = "ComDev"
        Me.ComDev.Size = New System.Drawing.Size(164, 28)
        Me.ComDev.TabIndex = 143
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Controls.Add(Me.BtnSave)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(406, 41)
        Me.Panel5.TabIndex = 3
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.Location = New System.Drawing.Point(294, 0)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(112, 41)
        Me.BtnSave.TabIndex = 151
        Me.BtnSave.Text = "Simpan Data"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(229, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Add Aplikasi Local Android"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Location = New System.Drawing.Point(383, 344)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(406, 242)
        Me.Panel6.TabIndex = 191
        '
        'Panel7
        '
        Me.Panel7.AutoScroll = True
        Me.Panel7.Controls.Add(Me.ViewTabel)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 41)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(406, 201)
        Me.Panel7.TabIndex = 143
        '
        'ViewTabel
        '
        Me.ViewTabel.AllowUserToAddRows = False
        Me.ViewTabel.AllowUserToDeleteRows = False
        Me.ViewTabel.AllowUserToResizeColumns = False
        Me.ViewTabel.AllowUserToResizeRows = False
        Me.ViewTabel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ViewTabel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ViewTabel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ViewTabel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ViewTabel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.ViewTabel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ViewTabel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ViewTabel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.dev, Me.app, Me.stat, Me.edit})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel.DefaultCellStyle = DataGridViewCellStyle2
        Me.ViewTabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTabel.EnableHeadersVisualStyles = False
        Me.ViewTabel.GridColor = System.Drawing.Color.Lime
        Me.ViewTabel.Location = New System.Drawing.Point(0, 0)
        Me.ViewTabel.Name = "ViewTabel"
        Me.ViewTabel.ReadOnly = True
        Me.ViewTabel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ViewTabel.RowHeadersVisible = False
        Me.ViewTabel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.ViewTabel.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ViewTabel.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewTabel.RowTemplate.Height = 20
        Me.ViewTabel.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.ViewTabel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ViewTabel.ShowCellToolTips = False
        Me.ViewTabel.Size = New System.Drawing.Size(406, 201)
        Me.ViewTabel.TabIndex = 76
        '
        'No
        '
        Me.No.Frozen = True
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.Width = 44
        '
        'dev
        '
        Me.dev.Frozen = True
        Me.dev.HeaderText = "Devices"
        Me.dev.Name = "dev"
        Me.dev.ReadOnly = True
        Me.dev.Width = 70
        '
        'app
        '
        Me.app.Frozen = True
        Me.app.HeaderText = "Application"
        Me.app.Name = "app"
        Me.app.ReadOnly = True
        Me.app.Width = 84
        '
        'stat
        '
        Me.stat.Frozen = True
        Me.stat.HeaderText = "STATE"
        Me.stat.Name = "stat"
        Me.stat.ReadOnly = True
        Me.stat.Width = 62
        '
        'edit
        '
        Me.edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.edit.HeaderText = "edit"
        Me.edit.Name = "edit"
        Me.edit.ReadOnly = True
        Me.edit.Text = "EDIT"
        Me.edit.UseColumnTextForButtonValue = True
        Me.edit.Width = 29
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Gray
        Me.Panel8.Controls.Add(Me.Label9)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(406, 41)
        Me.Panel8.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(12, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(226, 23)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "List Data Aplikasi Android "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.Font = New System.Drawing.Font("Bodoni MT", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(5, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(230, 28)
        Me.Label8.TabIndex = 183
        Me.Label8.Text = "User Guide"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnRef
        '
        Me.BtnRef.BackColor = System.Drawing.Color.Transparent
        Me.BtnRef.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRef.FlatAppearance.BorderSize = 0
        Me.BtnRef.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRef.ForeColor = System.Drawing.Color.Transparent
        Me.BtnRef.Image = CType(resources.GetObject("BtnRef.Image"), System.Drawing.Image)
        Me.BtnRef.Location = New System.Drawing.Point(264, 4)
        Me.BtnRef.Name = "BtnRef"
        Me.BtnRef.Padding = New System.Windows.Forms.Padding(5)
        Me.BtnRef.Size = New System.Drawing.Size(40, 30)
        Me.BtnRef.TabIndex = 184
        Me.BtnRef.UseVisualStyleBackColor = False
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Label7)
        Me.Panel9.Controls.Add(Me.Label12)
        Me.Panel9.Controls.Add(Me.BtnRef)
        Me.Panel9.Controls.Add(Me.Label8)
        Me.Panel9.Location = New System.Drawing.Point(792, 7)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(242, 579)
        Me.Panel9.TabIndex = 192
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label7.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(19, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(205, 28)
        Me.Label7.TabIndex = 186
        Me.Label7.Text = "A. Local Android"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Microsoft JhengHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(4, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(231, 430)
        Me.Label12.TabIndex = 185
        '
        'frmAddDevices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1040, 590)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAddDevices"
        Me.Text = "frmAddDevices"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelPusat As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents BtnRefresh As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents rd1 As RadioButton
    Friend WithEvents rd0 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComApk As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Lblname As Label
    Friend WithEvents ComDev As ComboBox
    Friend WithEvents BtnSave As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents BtnConnect As Button
    Friend WithEvents ViewTabel As DataGridView
    Friend WithEvents BtnListA As Button
    Friend WithEvents BtnNewA As Button
    Friend WithEvents Panelgb As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents txtuser As TextBox
    Friend WithEvents txtnum1 As TextBox
    Friend WithEvents txtnum2 As TextBox
    Friend WithEvents lbl1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnRef As Button
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents PilPrefix As ComboBox
    Friend WithEvents lbl2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents dev As DataGridViewTextBoxColumn
    Friend WithEvents app As DataGridViewTextBoxColumn
    Friend WithEvents stat As DataGridViewTextBoxColumn
    Friend WithEvents edit As DataGridViewButtonColumn
End Class
