<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pgSheet
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LblNameF = New System.Windows.Forms.Label()
        Me.Txtspid = New System.Windows.Forms.TextBox()
        Me.BtnLoad = New System.Windows.Forms.Button()
        Me.col0 = New System.Windows.Forms.NumericUpDown()
        Me.row1 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.row2 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtshname = New System.Windows.Forms.TextBox()
        Me.ViewTabel = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotNum = New System.Windows.Forms.Label()
        Me.ViewTabel1 = New System.Windows.Forms.DataGridView()
        Me.number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Chk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ChkAll = New System.Windows.Forms.CheckBox()
        Me.col1 = New System.Windows.Forms.NumericUpDown()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnPilih = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.colname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totdata = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.col0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.row1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.row2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewTabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.col1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblNameF
        '
        Me.LblNameF.AutoSize = True
        Me.LblNameF.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNameF.ForeColor = System.Drawing.Color.White
        Me.LblNameF.Location = New System.Drawing.Point(5, 22)
        Me.LblNameF.Name = "LblNameF"
        Me.LblNameF.Size = New System.Drawing.Size(120, 18)
        Me.LblNameF.TabIndex = 185
        Me.LblNameF.Text = "Spreadsheet-id:"
        '
        'Txtspid
        '
        Me.Txtspid.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Txtspid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtspid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtspid.ForeColor = System.Drawing.Color.White
        Me.Txtspid.Location = New System.Drawing.Point(5, 45)
        Me.Txtspid.Multiline = True
        Me.Txtspid.Name = "Txtspid"
        Me.Txtspid.Size = New System.Drawing.Size(214, 28)
        Me.Txtspid.TabIndex = 183
        Me.Txtspid.WordWrap = False
        '
        'BtnLoad
        '
        Me.BtnLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.BtnLoad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLoad.FlatAppearance.BorderSize = 0
        Me.BtnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoad.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLoad.Location = New System.Drawing.Point(108, 276)
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(88, 27)
        Me.BtnLoad.TabIndex = 184
        Me.BtnLoad.Text = "Load Data"
        Me.BtnLoad.UseVisualStyleBackColor = False
        '
        'col0
        '
        Me.col0.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.col0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.col0.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.col0.ForeColor = System.Drawing.Color.White
        Me.col0.Location = New System.Drawing.Point(8, 167)
        Me.col0.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.col0.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.col0.Name = "col0"
        Me.col0.ReadOnly = True
        Me.col0.Size = New System.Drawing.Size(63, 27)
        Me.col0.TabIndex = 186
        Me.col0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col0.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'row1
        '
        Me.row1.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.row1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.row1.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.row1.ForeColor = System.Drawing.Color.White
        Me.row1.Location = New System.Drawing.Point(7, 228)
        Me.row1.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.row1.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.row1.Name = "row1"
        Me.row1.ReadOnly = True
        Me.row1.Size = New System.Drawing.Size(64, 27)
        Me.row1.TabIndex = 189
        Me.row1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.row1.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bookman Old Style", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(36, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 188
        Me.Label3.Text = "Start Row Data"
        '
        'row2
        '
        Me.row2.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.row2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.row2.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.row2.ForeColor = System.Drawing.Color.White
        Me.row2.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.row2.Location = New System.Drawing.Point(113, 228)
        Me.row2.Maximum = New Decimal(New Integer() {4000, 0, 0, 0})
        Me.row2.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.row2.Name = "row2"
        Me.row2.ReadOnly = True
        Me.row2.Size = New System.Drawing.Size(64, 27)
        Me.row2.TabIndex = 190
        Me.row2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.row2.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(82, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 18)
        Me.Label1.TabIndex = 191
        Me.Label1.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 18)
        Me.Label2.TabIndex = 193
        Me.Label2.Text = "Sheet Name :"
        '
        'txtshname
        '
        Me.txtshname.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.txtshname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtshname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtshname.ForeColor = System.Drawing.Color.White
        Me.txtshname.Location = New System.Drawing.Point(5, 108)
        Me.txtshname.Multiline = True
        Me.txtshname.Name = "txtshname"
        Me.txtshname.Size = New System.Drawing.Size(214, 28)
        Me.txtshname.TabIndex = 192
        Me.txtshname.WordWrap = False
        '
        'ViewTabel
        '
        Me.ViewTabel.AllowUserToAddRows = False
        Me.ViewTabel.AllowUserToDeleteRows = False
        Me.ViewTabel.AllowUserToResizeColumns = False
        Me.ViewTabel.AllowUserToResizeRows = False
        Me.ViewTabel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ViewTabel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ViewTabel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ViewTabel.BorderStyle = System.Windows.Forms.BorderStyle.None
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
        Me.ViewTabel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colname, Me.totdata})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel.DefaultCellStyle = DataGridViewCellStyle2
        Me.ViewTabel.EnableHeadersVisualStyles = False
        Me.ViewTabel.GridColor = System.Drawing.Color.Lime
        Me.ViewTabel.Location = New System.Drawing.Point(228, 22)
        Me.ViewTabel.Name = "ViewTabel"
        Me.ViewTabel.ReadOnly = True
        Me.ViewTabel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
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
        Me.ViewTabel.Size = New System.Drawing.Size(221, 290)
        Me.ViewTabel.TabIndex = 194
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(225, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 16)
        Me.Label4.TabIndex = 195
        Me.Label4.Text = "List Data (Double Klik)"
        '
        'lblTotNum
        '
        Me.lblTotNum.AutoSize = True
        Me.lblTotNum.Font = New System.Drawing.Font("Century", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotNum.ForeColor = System.Drawing.Color.White
        Me.lblTotNum.Location = New System.Drawing.Point(464, 3)
        Me.lblTotNum.Name = "lblTotNum"
        Me.lblTotNum.Size = New System.Drawing.Size(37, 16)
        Me.lblTotNum.TabIndex = 196
        Me.lblTotNum.Text = "Pilih"
        '
        'ViewTabel1
        '
        Me.ViewTabel1.AllowUserToAddRows = False
        Me.ViewTabel1.AllowUserToDeleteRows = False
        Me.ViewTabel1.AllowUserToResizeColumns = False
        Me.ViewTabel1.AllowUserToResizeRows = False
        Me.ViewTabel1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ViewTabel1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ViewTabel1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ViewTabel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ViewTabel1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.ViewTabel1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.ViewTabel1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ViewTabel1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.number, Me.Chk})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel1.DefaultCellStyle = DataGridViewCellStyle6
        Me.ViewTabel1.EnableHeadersVisualStyles = False
        Me.ViewTabel1.GridColor = System.Drawing.Color.Lime
        Me.ViewTabel1.Location = New System.Drawing.Point(464, 22)
        Me.ViewTabel1.Name = "ViewTabel1"
        Me.ViewTabel1.ReadOnly = True
        Me.ViewTabel1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel1.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.ViewTabel1.RowHeadersVisible = False
        Me.ViewTabel1.RowHeadersWidth = 40
        Me.ViewTabel1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ViewTabel1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ViewTabel1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewTabel1.RowTemplate.Height = 20
        Me.ViewTabel1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ViewTabel1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ViewTabel1.ShowCellToolTips = False
        Me.ViewTabel1.Size = New System.Drawing.Size(167, 248)
        Me.ViewTabel1.TabIndex = 197
        '
        'number
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.number.DefaultCellStyle = DataGridViewCellStyle5
        Me.number.HeaderText = "Number"
        Me.number.Name = "number"
        Me.number.ReadOnly = True
        Me.number.Width = 68
        '
        'Chk
        '
        Me.Chk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Chk.HeaderText = "Chk All"
        Me.Chk.Name = "Chk"
        Me.Chk.ReadOnly = True
        Me.Chk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Chk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Chk.Width = 63
        '
        'ChkAll
        '
        Me.ChkAll.AutoSize = True
        Me.ChkAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkAll.Location = New System.Drawing.Point(572, 3)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(68, 17)
        Me.ChkAll.TabIndex = 198
        Me.ChkAll.Text = "Check All"
        Me.ChkAll.UseVisualStyleBackColor = True
        '
        'col1
        '
        Me.col1.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.col1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.col1.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.col1.ForeColor = System.Drawing.Color.White
        Me.col1.Location = New System.Drawing.Point(113, 167)
        Me.col1.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.col1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.col1.Name = "col1"
        Me.col1.ReadOnly = True
        Me.col1.Size = New System.Drawing.Size(64, 27)
        Me.col1.TabIndex = 199
        Me.col1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col1.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.Location = New System.Drawing.Point(14, 276)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(88, 27)
        Me.BtnSave.TabIndex = 201
        Me.BtnSave.Text = "Simpan Link"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnPilih
        '
        Me.BtnPilih.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.BtnPilih.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPilih.FlatAppearance.BorderSize = 0
        Me.BtnPilih.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPilih.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPilih.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnPilih.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPilih.Location = New System.Drawing.Point(551, 276)
        Me.BtnPilih.Name = "BtnPilih"
        Me.BtnPilih.Size = New System.Drawing.Size(88, 27)
        Me.BtnPilih.TabIndex = 202
        Me.BtnPilih.Text = "Pilih Data"
        Me.BtnPilih.UseVisualStyleBackColor = False
        '
        'BtnClear
        '
        Me.BtnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.BtnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClear.FlatAppearance.BorderSize = 0
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClear.Location = New System.Drawing.Point(457, 276)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(88, 27)
        Me.BtnClear.TabIndex = 203
        Me.BtnClear.Text = "Clear Data"
        Me.BtnClear.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Bookman Old Style", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(46, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 17)
        Me.Label5.TabIndex = 204
        Me.Label5.Text = "Start Column"
        '
        'colname
        '
        Me.colname.HeaderText = "NAMA COLUM"
        Me.colname.Name = "colname"
        Me.colname.ReadOnly = True
        Me.colname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colname.Width = 81
        '
        'totdata
        '
        Me.totdata.HeaderText = "DATA"
        Me.totdata.Name = "totdata"
        Me.totdata.ReadOnly = True
        Me.totdata.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.totdata.Width = 39
        '
        'pgSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(643, 315)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnPilih)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.col1)
        Me.Controls.Add(Me.ChkAll)
        Me.Controls.Add(Me.ViewTabel1)
        Me.Controls.Add(Me.lblTotNum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ViewTabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtshname)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.row2)
        Me.Controls.Add(Me.col0)
        Me.Controls.Add(Me.row1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblNameF)
        Me.Controls.Add(Me.Txtspid)
        Me.Controls.Add(Me.BtnLoad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "pgSheet"
        Me.Text = "pgSheet"
        CType(Me.col0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.row1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.row2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewTabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.col1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblNameF As Label
    Friend WithEvents Txtspid As TextBox
    Friend WithEvents BtnLoad As Button
    Friend WithEvents col0 As NumericUpDown
    Friend WithEvents row1 As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents row2 As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtshname As TextBox
    Friend WithEvents ViewTabel As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTotNum As Label
    Friend WithEvents ViewTabel1 As DataGridView
    Friend WithEvents ChkAll As CheckBox
    Friend WithEvents col1 As NumericUpDown
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnPilih As Button
    Friend WithEvents BtnClear As Button
    Friend WithEvents number As DataGridViewTextBoxColumn
    Friend WithEvents Chk As DataGridViewCheckBoxColumn
    Friend WithEvents Label5 As Label
    Friend WithEvents colname As DataGridViewTextBoxColumn
    Friend WithEvents totdata As DataGridViewTextBoxColumn
End Class
