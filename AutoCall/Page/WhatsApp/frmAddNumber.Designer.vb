<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddNumber
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ComDev = New System.Windows.Forms.ComboBox()
        Me.Lblname = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComApk = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rd0 = New System.Windows.Forms.RadioButton()
        Me.rd1 = New System.Windows.Forms.RadioButton()
        Me.num1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.num2 = New System.Windows.Forms.TextBox()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TotSend1 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TotSend2 = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.ViewTabel = New System.Windows.Forms.DataGridView()
        Me.dev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Platform = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WaNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idwa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.action = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.Btn4 = New System.Windows.Forms.Button()
        CType(Me.TotSend1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotSend2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPusat.SuspendLayout()
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComDev
        '
        Me.ComDev.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ComDev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComDev.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComDev.ForeColor = System.Drawing.Color.White
        Me.ComDev.FormattingEnabled = True
        Me.ComDev.Location = New System.Drawing.Point(5, 89)
        Me.ComDev.Name = "ComDev"
        Me.ComDev.Size = New System.Drawing.Size(164, 28)
        Me.ComDev.TabIndex = 73
        '
        'Lblname
        '
        Me.Lblname.AutoSize = True
        Me.Lblname.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblname.ForeColor = System.Drawing.Color.White
        Me.Lblname.Location = New System.Drawing.Point(26, 136)
        Me.Lblname.Name = "Lblname"
        Me.Lblname.Size = New System.Drawing.Size(0, 16)
        Me.Lblname.TabIndex = 101
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Device :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "WhatsApps :"
        '
        'ComApk
        '
        Me.ComApk.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ComApk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComApk.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComApk.ForeColor = System.Drawing.Color.White
        Me.ComApk.FormattingEnabled = True
        Me.ComApk.Location = New System.Drawing.Point(5, 155)
        Me.ComApk.Name = "ComApk"
        Me.ComApk.Size = New System.Drawing.Size(158, 28)
        Me.ComApk.TabIndex = 103
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(7, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(239, 30)
        Me.Label7.TabIndex = 138
        Me.Label7.Text = "Add Number WhatsApp"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 16)
        Me.Label4.TabIndex = 140
        Me.Label4.Text = "Have Dual Apps Or 2 Account :"
        '
        'rd0
        '
        Me.rd0.AutoSize = True
        Me.rd0.ForeColor = System.Drawing.Color.White
        Me.rd0.Location = New System.Drawing.Point(10, 223)
        Me.rd0.Name = "rd0"
        Me.rd0.Size = New System.Drawing.Size(47, 17)
        Me.rd0.TabIndex = 141
        Me.rd0.TabStop = True
        Me.rd0.Text = "false"
        Me.rd0.UseVisualStyleBackColor = True
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.ForeColor = System.Drawing.Color.White
        Me.rd1.Location = New System.Drawing.Point(63, 223)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(43, 17)
        Me.rd1.TabIndex = 142
        Me.rd1.TabStop = True
        Me.rd1.Text = "true"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'num1
        '
        Me.num1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.num1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.num1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num1.Enabled = False
        Me.num1.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.num1.ForeColor = System.Drawing.Color.White
        Me.num1.Location = New System.Drawing.Point(171, 86)
        Me.num1.Name = "num1"
        Me.num1.ReadOnly = True
        Me.num1.Size = New System.Drawing.Size(147, 32)
        Me.num1.TabIndex = 143
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(168, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 16)
        Me.Label5.TabIndex = 145
        Me.Label5.Text = "Account 1 (Exp :6281xxxx )"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(168, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 16)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "Account 2 (Exp :6281xxxx )"
        '
        'num2
        '
        Me.num2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.num2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.num2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num2.Enabled = False
        Me.num2.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.num2.ForeColor = System.Drawing.Color.White
        Me.num2.Location = New System.Drawing.Point(171, 152)
        Me.num2.Name = "num2"
        Me.num2.ReadOnly = True
        Me.num2.Size = New System.Drawing.Size(147, 32)
        Me.num2.TabIndex = 146
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSave.Location = New System.Drawing.Point(236, 9)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(144, 36)
        Me.BtnSave.TabIndex = 149
        Me.BtnSave.Text = "Save Number "
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(321, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 16)
        Me.Label8.TabIndex = 150
        Me.Label8.Text = "Max Send :"
        '
        'TotSend1
        '
        Me.TotSend1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotSend1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotSend1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotSend1.ForeColor = System.Drawing.Color.White
        Me.TotSend1.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.TotSend1.Location = New System.Drawing.Point(324, 87)
        Me.TotSend1.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.TotSend1.Name = "TotSend1"
        Me.TotSend1.ReadOnly = True
        Me.TotSend1.Size = New System.Drawing.Size(58, 29)
        Me.TotSend1.TabIndex = 151
        Me.TotSend1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotSend1.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(320, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 152
        Me.Label3.Text = "Max Send :"
        '
        'TotSend2
        '
        Me.TotSend2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotSend2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotSend2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotSend2.ForeColor = System.Drawing.Color.White
        Me.TotSend2.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.TotSend2.Location = New System.Drawing.Point(323, 154)
        Me.TotSend2.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.TotSend2.Name = "TotSend2"
        Me.TotSend2.ReadOnly = True
        Me.TotSend2.Size = New System.Drawing.Size(58, 29)
        Me.TotSend2.TabIndex = 153
        Me.TotSend2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotSend2.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(422, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 16)
        Me.Label9.TabIndex = 184
        Me.Label9.Text = "List WA Number"
        '
        'PanelPusat
        '
        Me.PanelPusat.AutoScroll = True
        Me.PanelPusat.Controls.Add(Me.ViewTabel)
        Me.PanelPusat.Location = New System.Drawing.Point(388, 31)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(425, 243)
        Me.PanelPusat.TabIndex = 183
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
        Me.ViewTabel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dev, Me.Platform, Me.WaNumber, Me.idwa, Me.action})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel.DefaultCellStyle = DataGridViewCellStyle3
        Me.ViewTabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTabel.EnableHeadersVisualStyles = False
        Me.ViewTabel.GridColor = System.Drawing.Color.Lime
        Me.ViewTabel.Location = New System.Drawing.Point(0, 0)
        Me.ViewTabel.Name = "ViewTabel"
        Me.ViewTabel.ReadOnly = True
        Me.ViewTabel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.ViewTabel.RowHeadersVisible = False
        Me.ViewTabel.RowHeadersWidth = 40
        Me.ViewTabel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ViewTabel.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ViewTabel.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewTabel.RowTemplate.Height = 20
        Me.ViewTabel.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ViewTabel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ViewTabel.ShowCellToolTips = False
        Me.ViewTabel.Size = New System.Drawing.Size(425, 243)
        Me.ViewTabel.TabIndex = 75
        '
        'dev
        '
        Me.dev.HeaderText = "Devices"
        Me.dev.Name = "dev"
        Me.dev.ReadOnly = True
        Me.dev.Width = 70
        '
        'Platform
        '
        Me.Platform.HeaderText = "Platform"
        Me.Platform.Name = "Platform"
        Me.Platform.ReadOnly = True
        Me.Platform.Width = 70
        '
        'WaNumber
        '
        Me.WaNumber.HeaderText = "WA NUMBER"
        Me.WaNumber.Name = "WaNumber"
        Me.WaNumber.ReadOnly = True
        Me.WaNumber.Width = 93
        '
        'idwa
        '
        Me.idwa.HeaderText = "ID WA"
        Me.idwa.Name = "idwa"
        Me.idwa.ReadOnly = True
        Me.idwa.Width = 61
        '
        'action
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.NullValue = "Hapus"
        Me.action.DefaultCellStyle = DataGridViewCellStyle2
        Me.action.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.action.HeaderText = "Aksi"
        Me.action.Name = "action"
        Me.action.ReadOnly = True
        Me.action.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.action.Text = "Hapus"
        Me.action.UseColumnTextForButtonValue = True
        Me.action.Width = 52
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete.Location = New System.Drawing.Point(700, 3)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(113, 24)
        Me.BtnDelete.TabIndex = 186
        Me.BtnDelete.Text = "Delete All"
        Me.BtnDelete.UseVisualStyleBackColor = False
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
        Me.Btn4.Location = New System.Drawing.Point(207, 206)
        Me.Btn4.Name = "Btn4"
        Me.Btn4.Size = New System.Drawing.Size(163, 34)
        Me.Btn4.TabIndex = 187
        Me.Btn4.Text = "Open Scrpy With USB"
        Me.Btn4.UseVisualStyleBackColor = False
        '
        'frmAddNumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(818, 282)
        Me.Controls.Add(Me.ComApk)
        Me.Controls.Add(Me.Btn4)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PanelPusat)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TotSend2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TotSend1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.num2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.num1)
        Me.Controls.Add(Me.rd1)
        Me.Controls.Add(Me.rd0)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Lblname)
        Me.Controls.Add(Me.ComDev)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAddNumber"
        Me.Text = "frmAddNumber"
        CType(Me.TotSend1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotSend2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPusat.ResumeLayout(False)
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComDev As ComboBox
    Friend WithEvents Lblname As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComApk As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents rd0 As RadioButton
    Friend WithEvents rd1 As RadioButton
    Friend WithEvents num1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents num2 As TextBox
    Friend WithEvents BtnSave As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents TotSend1 As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents TotSend2 As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents PanelPusat As Panel
    Friend WithEvents BtnDelete As Button
    Friend WithEvents ViewTabel As DataGridView
    Friend WithEvents Btn4 As Button
    Friend WithEvents dev As DataGridViewTextBoxColumn
    Friend WithEvents Platform As DataGridViewTextBoxColumn
    Friend WithEvents WaNumber As DataGridViewTextBoxColumn
    Friend WithEvents idwa As DataGridViewTextBoxColumn
    Friend WithEvents action As DataGridViewButtonColumn
End Class
