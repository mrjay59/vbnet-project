<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PgCall
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PgCall))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtCaller = New System.Windows.Forms.TextBox()
        Me.LblTotData = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtNumber = New System.Windows.Forms.TextBox()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Rc0 = New System.Windows.Forms.RadioButton()
        Me.Rc1 = New System.Windows.Forms.RadioButton()
        Me.LcAndroid = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PnlogActivty = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ClAndroid = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.TotDurasi = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TotClose = New System.Windows.Forms.NumericUpDown()
        Me.TotRecall = New System.Windows.Forms.NumericUpDown()
        Me.TotDial = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rd0 = New System.Windows.Forms.RadioButton()
        Me.rd1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RD_WD = New System.Windows.Forms.RadioButton()
        Me.lblCountState = New System.Windows.Forms.Label()
        Me.DatTable1 = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reqid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.method = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createcall = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Concurrent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.detail = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnStateC = New System.Windows.Forms.Button()
        Me.BtnLog = New System.Windows.Forms.Button()
        Me.BtnRemoveCall = New System.Windows.Forms.Button()
        Me.BtnResumeCall = New System.Windows.Forms.Button()
        Me.BtnPaste = New System.Windows.Forms.Button()
        Me.btnCaller = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.TotDurasi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotRecall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotDial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DatTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCaller
        '
        Me.TxtCaller.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtCaller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCaller.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtCaller.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCaller.ForeColor = System.Drawing.Color.White
        Me.TxtCaller.Location = New System.Drawing.Point(7, 91)
        Me.TxtCaller.Multiline = True
        Me.TxtCaller.Name = "TxtCaller"
        Me.TxtCaller.ReadOnly = True
        Me.TxtCaller.Size = New System.Drawing.Size(149, 312)
        Me.TxtCaller.TabIndex = 200
        '
        'LblTotData
        '
        Me.LblTotData.AutoSize = True
        Me.LblTotData.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.LblTotData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotData.ForeColor = System.Drawing.Color.White
        Me.LblTotData.Location = New System.Drawing.Point(466, 293)
        Me.LblTotData.Name = "LblTotData"
        Me.LblTotData.Size = New System.Drawing.Size(57, 13)
        Me.LblTotData.TabIndex = 199
        Me.LblTotData.Text = "Total Data"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(172, 166)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 13)
        Me.Label7.TabIndex = 195
        Me.Label7.Text = "Enter Number : min 2 s.d 1000 "
        '
        'TxtNumber
        '
        Me.TxtNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtNumber.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.ForeColor = System.Drawing.Color.White
        Me.TxtNumber.Location = New System.Drawing.Point(169, 189)
        Me.TxtNumber.Multiline = True
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.ReadOnly = True
        Me.TxtNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtNumber.Size = New System.Drawing.Size(370, 101)
        Me.TxtNumber.TabIndex = 194
        '
        'BtnSelect
        '
        Me.BtnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.BtnSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSelect.FlatAppearance.BorderSize = 0
        Me.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelect.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSelect.Location = New System.Drawing.Point(24, 63)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(117, 26)
        Me.BtnSelect.TabIndex = 193
        Me.BtnSelect.Text = "Pilih"
        Me.BtnSelect.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(166, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 19)
        Me.Label8.TabIndex = 215
        Me.Label8.Text = "Metode Call Melalui "
        '
        'Rc0
        '
        Me.Rc0.AutoSize = True
        Me.Rc0.ForeColor = System.Drawing.Color.White
        Me.Rc0.Location = New System.Drawing.Point(169, 100)
        Me.Rc0.Name = "Rc0"
        Me.Rc0.Size = New System.Drawing.Size(71, 17)
        Me.Rc0.TabIndex = 216
        Me.Rc0.TabStop = True
        Me.Rc0.Text = "SIP Local"
        Me.Rc0.UseVisualStyleBackColor = True
        '
        'Rc1
        '
        Me.Rc1.AutoSize = True
        Me.Rc1.ForeColor = System.Drawing.Color.White
        Me.Rc1.Location = New System.Drawing.Point(264, 100)
        Me.Rc1.Name = "Rc1"
        Me.Rc1.Size = New System.Drawing.Size(76, 17)
        Me.Rc1.TabIndex = 217
        Me.Rc1.TabStop = True
        Me.Rc1.Text = "SIP Server"
        Me.Rc1.UseVisualStyleBackColor = True
        '
        'LcAndroid
        '
        Me.LcAndroid.AutoSize = True
        Me.LcAndroid.ForeColor = System.Drawing.Color.White
        Me.LcAndroid.Location = New System.Drawing.Point(169, 123)
        Me.LcAndroid.Name = "LcAndroid"
        Me.LcAndroid.Size = New System.Drawing.Size(90, 17)
        Me.LcAndroid.TabIndex = 218
        Me.LcAndroid.TabStop = True
        Me.LcAndroid.Text = "Local Android"
        Me.LcAndroid.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PnlogActivty)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Location = New System.Drawing.Point(545, 39)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(493, 558)
        Me.Panel2.TabIndex = 224
        '
        'PnlogActivty
        '
        Me.PnlogActivty.AutoScroll = True
        Me.PnlogActivty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlogActivty.Location = New System.Drawing.Point(0, 41)
        Me.PnlogActivty.Name = "PnlogActivty"
        Me.PnlogActivty.Size = New System.Drawing.Size(493, 517)
        Me.PnlogActivty.TabIndex = 143
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(493, 41)
        Me.Panel5.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(444, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(5)
        Me.Button1.Size = New System.Drawing.Size(40, 30)
        Me.Button1.TabIndex = 78
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(5, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 23)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Log Activity"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ClAndroid
        '
        Me.ClAndroid.AutoSize = True
        Me.ClAndroid.ForeColor = System.Drawing.Color.White
        Me.ClAndroid.Location = New System.Drawing.Point(264, 123)
        Me.ClAndroid.Name = "ClAndroid"
        Me.ClAndroid.Size = New System.Drawing.Size(91, 17)
        Me.ClAndroid.TabIndex = 225
        Me.ClAndroid.TabStop = True
        Me.ClAndroid.Text = "Cloud Android"
        Me.ClAndroid.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Malgun Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(250, 32)
        Me.Label10.TabIndex = 227
        Me.Label10.Text = "Multi Pusat Panggilan"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Panel10.Location = New System.Drawing.Point(7, 43)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(500, 2)
        Me.Panel10.TabIndex = 229
        '
        'TotDurasi
        '
        Me.TotDurasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotDurasi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotDurasi.ForeColor = System.Drawing.Color.White
        Me.TotDurasi.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.TotDurasi.Location = New System.Drawing.Point(278, 322)
        Me.TotDurasi.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.TotDurasi.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TotDurasi.Name = "TotDurasi"
        Me.TotDurasi.ReadOnly = True
        Me.TotDurasi.Size = New System.Drawing.Size(64, 20)
        Me.TotDurasi.TabIndex = 188
        Me.TotDurasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotDurasi.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(417, 306)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 189
        Me.Label3.Text = "Delay (s)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(278, 306)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 187
        Me.Label4.Text = "Durasi (m)"
        '
        'TotClose
        '
        Me.TotClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotClose.ForeColor = System.Drawing.Color.White
        Me.TotClose.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.TotClose.Location = New System.Drawing.Point(420, 322)
        Me.TotClose.Maximum = New Decimal(New Integer() {45, 0, 0, 0})
        Me.TotClose.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.TotClose.Name = "TotClose"
        Me.TotClose.ReadOnly = True
        Me.TotClose.Size = New System.Drawing.Size(64, 20)
        Me.TotClose.TabIndex = 190
        Me.TotClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotClose.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'TotRecall
        '
        Me.TotRecall.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotRecall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotRecall.ForeColor = System.Drawing.Color.White
        Me.TotRecall.Location = New System.Drawing.Point(353, 322)
        Me.TotRecall.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.TotRecall.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TotRecall.Name = "TotRecall"
        Me.TotRecall.ReadOnly = True
        Me.TotRecall.Size = New System.Drawing.Size(55, 20)
        Me.TotRecall.TabIndex = 185
        Me.TotRecall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotRecall.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TotDial
        '
        Me.TotDial.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotDial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotDial.Enabled = False
        Me.TotDial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotDial.ForeColor = System.Drawing.Color.White
        Me.TotDial.Location = New System.Drawing.Point(207, 322)
        Me.TotDial.Name = "TotDial"
        Me.TotDial.ReadOnly = True
        Me.TotDial.Size = New System.Drawing.Size(55, 20)
        Me.TotDial.TabIndex = 184
        Me.TotDial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(208, 306)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 183
        Me.Label1.Text = "Use Dial"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(350, 306)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 186
        Me.Label6.Text = "Recall (x)"
        '
        'rd0
        '
        Me.rd0.AutoSize = True
        Me.rd0.ForeColor = System.Drawing.Color.White
        Me.rd0.Location = New System.Drawing.Point(30, 23)
        Me.rd0.Name = "rd0"
        Me.rd0.Size = New System.Drawing.Size(62, 17)
        Me.rd0.TabIndex = 202
        Me.rd0.TabStop = True
        Me.rd0.Text = "Putaran"
        Me.rd0.UseVisualStyleBackColor = True
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.ForeColor = System.Drawing.Color.White
        Me.rd1.Location = New System.Drawing.Point(126, 23)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(68, 17)
        Me.rd1.TabIndex = 203
        Me.rd1.TabStop = True
        Me.rd1.Text = "Beruntun"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rd1)
        Me.GroupBox1.Controls.Add(Me.rd0)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(175, 348)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(236, 59)
        Me.GroupBox1.TabIndex = 228
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Akan Di Call Secara ..?"
        '
        'RD_WD
        '
        Me.RD_WD.AutoSize = True
        Me.RD_WD.ForeColor = System.Drawing.Color.White
        Me.RD_WD.Location = New System.Drawing.Point(353, 100)
        Me.RD_WD.Name = "RD_WD"
        Me.RD_WD.Size = New System.Drawing.Size(118, 17)
        Me.RD_WD.TabIndex = 230
        Me.RD_WD.TabStop = True
        Me.RD_WD.Text = "WhatsApp Desktop"
        Me.RD_WD.UseVisualStyleBackColor = True
        '
        'lblCountState
        '
        Me.lblCountState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCountState.AutoSize = True
        Me.lblCountState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCountState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountState.ForeColor = System.Drawing.Color.White
        Me.lblCountState.Location = New System.Drawing.Point(879, 17)
        Me.lblCountState.Name = "lblCountState"
        Me.lblCountState.Size = New System.Drawing.Size(0, 13)
        Me.lblCountState.TabIndex = 260
        '
        'DatTable1
        '
        Me.DatTable1.AllowUserToAddRows = False
        Me.DatTable1.AllowUserToDeleteRows = False
        Me.DatTable1.AllowUserToResizeColumns = False
        Me.DatTable1.AllowUserToResizeRows = False
        Me.DatTable1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DatTable1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DatTable1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.DatTable1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DatTable1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DatTable1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatTable1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DatTable1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DatTable1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.reqid, Me.method, Me.createcall, Me.CData, Me.Concurrent, Me.detail})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DatTable1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DatTable1.EnableHeadersVisualStyles = False
        Me.DatTable1.GridColor = System.Drawing.Color.Lime
        Me.DatTable1.Location = New System.Drawing.Point(7, 448)
        Me.DatTable1.Name = "DatTable1"
        Me.DatTable1.ReadOnly = True
        Me.DatTable1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatTable1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DatTable1.RowHeadersVisible = False
        Me.DatTable1.RowHeadersWidth = 40
        Me.DatTable1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DatTable1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DatTable1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatTable1.RowTemplate.Height = 20
        Me.DatTable1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DatTable1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DatTable1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DatTable1.ShowCellToolTips = False
        Me.DatTable1.Size = New System.Drawing.Size(532, 142)
        Me.DatTable1.TabIndex = 261
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 39
        '
        'reqid
        '
        Me.reqid.HeaderText = "req_id"
        Me.reqid.Name = "reqid"
        Me.reqid.ReadOnly = True
        Me.reqid.Width = 61
        '
        'method
        '
        Me.method.HeaderText = "method"
        Me.method.Name = "method"
        Me.method.ReadOnly = True
        Me.method.Width = 66
        '
        'createcall
        '
        Me.createcall.HeaderText = "create_call"
        Me.createcall.Name = "createcall"
        Me.createcall.ReadOnly = True
        Me.createcall.Width = 84
        '
        'CData
        '
        Me.CData.HeaderText = "CountData"
        Me.CData.Name = "CData"
        Me.CData.ReadOnly = True
        Me.CData.Width = 81
        '
        'Concurrent
        '
        Me.Concurrent.HeaderText = "ConCurrent"
        Me.Concurrent.Name = "Concurrent"
        Me.Concurrent.ReadOnly = True
        Me.Concurrent.Width = 86
        '
        'detail
        '
        Me.detail.HeaderText = "Cek Detail"
        Me.detail.Name = "detail"
        Me.detail.ReadOnly = True
        Me.detail.Text = "Cek Detail"
        Me.detail.UseColumnTextForButtonValue = True
        Me.detail.Width = 59
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Bodoni MT", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 417)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 28)
        Me.Label2.TabIndex = 262
        Me.Label2.Text = "Detail History Call"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnStateC
        '
        Me.BtnStateC.BackColor = System.Drawing.Color.DimGray
        Me.BtnStateC.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnStateC.FlatAppearance.BorderSize = 0
        Me.BtnStateC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStateC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStateC.ForeColor = System.Drawing.Color.Black
        Me.BtnStateC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStateC.Location = New System.Drawing.Point(1005, 5)
        Me.BtnStateC.Name = "BtnStateC"
        Me.BtnStateC.Size = New System.Drawing.Size(30, 30)
        Me.BtnStateC.TabIndex = 182
        Me.BtnStateC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnStateC.UseVisualStyleBackColor = False
        '
        'BtnLog
        '
        Me.BtnLog.BackColor = System.Drawing.Color.DimGray
        Me.BtnLog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLog.FlatAppearance.BorderSize = 0
        Me.BtnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLog.ForeColor = System.Drawing.Color.Black
        Me.BtnLog.Image = Global.AutoCall.My.Resources.Resources.icons8_log_20
        Me.BtnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLog.Location = New System.Drawing.Point(750, 5)
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(86, 30)
        Me.BtnLog.TabIndex = 264
        Me.BtnLog.Text = "Check Log"
        Me.BtnLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnLog.UseVisualStyleBackColor = False
        '
        'BtnRemoveCall
        '
        Me.BtnRemoveCall.BackColor = System.Drawing.Color.DimGray
        Me.BtnRemoveCall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRemoveCall.FlatAppearance.BorderSize = 0
        Me.BtnRemoveCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRemoveCall.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemoveCall.ForeColor = System.Drawing.Color.Black
        Me.BtnRemoveCall.Image = CType(resources.GetObject("BtnRemoveCall.Image"), System.Drawing.Image)
        Me.BtnRemoveCall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRemoveCall.Location = New System.Drawing.Point(842, 5)
        Me.BtnRemoveCall.Name = "BtnRemoveCall"
        Me.BtnRemoveCall.Size = New System.Drawing.Size(75, 30)
        Me.BtnRemoveCall.TabIndex = 263
        Me.BtnRemoveCall.Text = "Clear All"
        Me.BtnRemoveCall.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRemoveCall.UseVisualStyleBackColor = False
        '
        'BtnResumeCall
        '
        Me.BtnResumeCall.BackColor = System.Drawing.Color.DimGray
        Me.BtnResumeCall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnResumeCall.FlatAppearance.BorderSize = 0
        Me.BtnResumeCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnResumeCall.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnResumeCall.ForeColor = System.Drawing.Color.Black
        Me.BtnResumeCall.Image = Global.AutoCall.My.Resources.Resources.icons8_stop_20
        Me.BtnResumeCall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnResumeCall.Location = New System.Drawing.Point(924, 5)
        Me.BtnResumeCall.Name = "BtnResumeCall"
        Me.BtnResumeCall.Size = New System.Drawing.Size(75, 30)
        Me.BtnResumeCall.TabIndex = 183
        Me.BtnResumeCall.Text = "Stop All"
        Me.BtnResumeCall.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnResumeCall.UseVisualStyleBackColor = False
        '
        'BtnPaste
        '
        Me.BtnPaste.BackColor = System.Drawing.Color.Transparent
        Me.BtnPaste.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPaste.FlatAppearance.BorderSize = 0
        Me.BtnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPaste.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPaste.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnPaste.Image = CType(resources.GetObject("BtnPaste.Image"), System.Drawing.Image)
        Me.BtnPaste.Location = New System.Drawing.Point(514, 158)
        Me.BtnPaste.Name = "BtnPaste"
        Me.BtnPaste.Size = New System.Drawing.Size(25, 25)
        Me.BtnPaste.TabIndex = 198
        Me.BtnPaste.UseVisualStyleBackColor = False
        '
        'btnCaller
        '
        Me.btnCaller.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.btnCaller.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCaller.FlatAppearance.BorderSize = 0
        Me.btnCaller.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCaller.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCaller.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCaller.Image = CType(resources.GetObject("btnCaller.Image"), System.Drawing.Image)
        Me.btnCaller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCaller.Location = New System.Drawing.Point(420, 366)
        Me.btnCaller.Name = "btnCaller"
        Me.btnCaller.Size = New System.Drawing.Size(119, 41)
        Me.btnCaller.TabIndex = 192
        Me.btnCaller.Text = "Create Call"
        Me.btnCaller.UseVisualStyleBackColor = False
        '
        'PgCall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1040, 602)
        Me.Controls.Add(Me.BtnLog)
        Me.Controls.Add(Me.BtnRemoveCall)
        Me.Controls.Add(Me.BtnStateC)
        Me.Controls.Add(Me.BtnResumeCall)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DatTable1)
        Me.Controls.Add(Me.lblCountState)
        Me.Controls.Add(Me.RD_WD)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ClAndroid)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LcAndroid)
        Me.Controls.Add(Me.Rc1)
        Me.Controls.Add(Me.Rc0)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtCaller)
        Me.Controls.Add(Me.LblTotData)
        Me.Controls.Add(Me.BtnPaste)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.btnCaller)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TotDial)
        Me.Controls.Add(Me.TotRecall)
        Me.Controls.Add(Me.TotClose)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TotDurasi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PgCall"
        Me.Text = "PgCall"
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.TotDurasi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotRecall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotDial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DatTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCaller As TextBox
    Friend WithEvents LblTotData As Label
    Friend WithEvents BtnPaste As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtNumber As TextBox
    Friend WithEvents BtnSelect As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Rc0 As RadioButton
    Friend WithEvents Rc1 As RadioButton
    Friend WithEvents LcAndroid As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PnlogActivty As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents BtnStateC As Button
    Friend WithEvents ClAndroid As RadioButton
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents TotDurasi As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TotClose As NumericUpDown
    Friend WithEvents TotRecall As NumericUpDown
    Friend WithEvents TotDial As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnCaller As Button
    Friend WithEvents rd0 As RadioButton
    Friend WithEvents rd1 As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RD_WD As RadioButton
    Friend WithEvents lblCountState As Label
    Friend WithEvents DatTable1 As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents reqid As DataGridViewTextBoxColumn
    Friend WithEvents method As DataGridViewTextBoxColumn
    Friend WithEvents createcall As DataGridViewTextBoxColumn
    Friend WithEvents CData As DataGridViewTextBoxColumn
    Friend WithEvents Concurrent As DataGridViewTextBoxColumn
    Friend WithEvents detail As DataGridViewButtonColumn
    Friend WithEvents BtnResumeCall As Button
    Friend WithEvents BtnRemoveCall As Button
    Friend WithEvents BtnLog As Button
End Class
