<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pgSetSession
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pgSetSession))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnDelSesi = New System.Windows.Forms.Button()
        Me.BtnDelMess = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.lbltext = New System.Windows.Forms.Label()
        Me.Btn1 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MaxSPDay = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MaxSPNum = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.UCformtext7 = New AutoCall.UCformtext()
        Me.UCformtext6 = New AutoCall.UCformtext()
        Me.UCformtext5 = New AutoCall.UCformtext()
        Me.UCformtext4 = New AutoCall.UCformtext()
        Me.UCformtext3 = New AutoCall.UCformtext()
        Me.UCformtext2 = New AutoCall.UCformtext()
        Me.UCformtext1 = New AutoCall.UCformtext()
        Me.UCformtext8 = New AutoCall.UCformtext()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.state_wa = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.MaxSPDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaxSPNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnDelSesi)
        Me.Panel1.Controls.Add(Me.BtnDelMess)
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Controls.Add(Me.lbltext)
        Me.Panel1.Controls.Add(Me.Btn1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(665, 45)
        Me.Panel1.TabIndex = 142
        '
        'BtnDelSesi
        '
        Me.BtnDelSesi.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnDelSesi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDelSesi.FlatAppearance.BorderSize = 0
        Me.BtnDelSesi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelSesi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelSesi.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnDelSesi.Image = CType(resources.GetObject("BtnDelSesi.Image"), System.Drawing.Image)
        Me.BtnDelSesi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelSesi.Location = New System.Drawing.Point(520, 6)
        Me.BtnDelSesi.Name = "BtnDelSesi"
        Me.BtnDelSesi.Size = New System.Drawing.Size(86, 34)
        Me.BtnDelSesi.TabIndex = 147
        Me.BtnDelSesi.Text = "Delete Session"
        Me.BtnDelSesi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelSesi.UseVisualStyleBackColor = False
        '
        'BtnDelMess
        '
        Me.BtnDelMess.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnDelMess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDelMess.FlatAppearance.BorderSize = 0
        Me.BtnDelMess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelMess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelMess.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnDelMess.Image = CType(resources.GetObject("BtnDelMess.Image"), System.Drawing.Image)
        Me.BtnDelMess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelMess.Location = New System.Drawing.Point(426, 6)
        Me.BtnDelMess.Name = "BtnDelMess"
        Me.BtnDelMess.Size = New System.Drawing.Size(91, 34)
        Me.BtnDelMess.TabIndex = 141
        Me.BtnDelMess.Text = "Delete Message"
        Me.BtnDelMess.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelMess.UseVisualStyleBackColor = False
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
        Me.btnclose.Location = New System.Drawing.Point(615, 0)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(50, 45)
        Me.btnclose.TabIndex = 140
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'lbltext
        '
        Me.lbltext.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltext.ForeColor = System.Drawing.Color.White
        Me.lbltext.Location = New System.Drawing.Point(3, 7)
        Me.lbltext.Name = "lbltext"
        Me.lbltext.Size = New System.Drawing.Size(289, 30)
        Me.lbltext.TabIndex = 139
        '
        'Btn1
        '
        Me.Btn1.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Btn1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn1.FlatAppearance.BorderSize = 0
        Me.Btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Btn1.Location = New System.Drawing.Point(353, 5)
        Me.Btn1.Name = "Btn1"
        Me.Btn1.Size = New System.Drawing.Size(70, 36)
        Me.Btn1.TabIndex = 146
        Me.Btn1.Text = "Simpan"
        Me.Btn1.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(19, 151)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(288, 28)
        Me.Label9.TabIndex = 143
        Me.Label9.Text = "Atur jumlah kirim/hari"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(366, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(265, 28)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Masa Langganan"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(365, 437)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(266, 28)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "Platform"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(19, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 15)
        Me.Label3.TabIndex = 272
        Me.Label3.Text = "Maksimal Send Per hari"
        '
        'MaxSPDay
        '
        Me.MaxSPDay.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.MaxSPDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MaxSPDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxSPDay.ForeColor = System.Drawing.Color.White
        Me.MaxSPDay.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.MaxSPDay.Location = New System.Drawing.Point(22, 228)
        Me.MaxSPDay.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.MaxSPDay.Name = "MaxSPDay"
        Me.MaxSPDay.ReadOnly = True
        Me.MaxSPDay.Size = New System.Drawing.Size(81, 22)
        Me.MaxSPDay.TabIndex = 271
        Me.MaxSPDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MaxSPDay.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(109, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 273
        Me.Label6.Text = "Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(109, 299)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 276
        Me.Label4.Text = "Kali"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(19, 273)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 15)
        Me.Label5.TabIndex = 275
        Me.Label5.Text = "Maksimal Send Per Number"
        '
        'MaxSPNum
        '
        Me.MaxSPNum.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.MaxSPNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MaxSPNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxSPNum.ForeColor = System.Drawing.Color.White
        Me.MaxSPNum.Location = New System.Drawing.Point(22, 294)
        Me.MaxSPNum.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.MaxSPNum.Name = "MaxSPNum"
        Me.MaxSPNum.ReadOnly = True
        Me.MaxSPNum.Size = New System.Drawing.Size(81, 22)
        Me.MaxSPNum.TabIndex = 274
        Me.MaxSPNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MaxSPNum.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(19, 335)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(288, 28)
        Me.Label7.TabIndex = 278
        Me.Label7.Text = "Akun Telegram"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(20, 437)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(287, 28)
        Me.Label8.TabIndex = 279
        Me.Label8.Text = "Server WhatsApp"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(177, 299)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 283
        Me.Label10.Text = "Isi 0:Unlimited"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(177, 232)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 284
        Me.Label11.Text = "Isi 0:Unlimited"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(19, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(288, 26)
        Me.Label12.TabIndex = 285
        Me.Label12.Text = "Data Session"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UCformtext7
        '
        Me.UCformtext7.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext7.Location = New System.Drawing.Point(353, 81)
        Me.UCformtext7.Name = "UCformtext7"
        Me.UCformtext7.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext7.TabIndex = 287
        '
        'UCformtext6
        '
        Me.UCformtext6.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext6.Location = New System.Drawing.Point(15, 81)
        Me.UCformtext6.Name = "UCformtext6"
        Me.UCformtext6.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext6.TabIndex = 286
        '
        'UCformtext5
        '
        Me.UCformtext5.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext5.Location = New System.Drawing.Point(15, 468)
        Me.UCformtext5.Name = "UCformtext5"
        Me.UCformtext5.Size = New System.Drawing.Size(292, 62)
        Me.UCformtext5.TabIndex = 282
        '
        'UCformtext4
        '
        Me.UCformtext4.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext4.Location = New System.Drawing.Point(353, 468)
        Me.UCformtext4.Name = "UCformtext4"
        Me.UCformtext4.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext4.TabIndex = 277
        '
        'UCformtext3
        '
        Me.UCformtext3.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext3.Location = New System.Drawing.Point(353, 341)
        Me.UCformtext3.Name = "UCformtext3"
        Me.UCformtext3.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext3.TabIndex = 150
        '
        'UCformtext2
        '
        Me.UCformtext2.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext2.Location = New System.Drawing.Point(353, 265)
        Me.UCformtext2.Name = "UCformtext2"
        Me.UCformtext2.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext2.TabIndex = 149
        '
        'UCformtext1
        '
        Me.UCformtext1.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext1.Location = New System.Drawing.Point(353, 197)
        Me.UCformtext1.Name = "UCformtext1"
        Me.UCformtext1.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext1.TabIndex = 148
        '
        'UCformtext8
        '
        Me.UCformtext8.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext8.Location = New System.Drawing.Point(15, 366)
        Me.UCformtext8.Name = "UCformtext8"
        Me.UCformtext8.Size = New System.Drawing.Size(292, 62)
        Me.UCformtext8.TabIndex = 288
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(365, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(152, 26)
        Me.Label13.TabIndex = 289
        Me.Label13.Text = "Status :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'state_wa
        '
        Me.state_wa.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.state_wa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.state_wa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.state_wa.ForeColor = System.Drawing.Color.White
        Me.state_wa.Location = New System.Drawing.Point(523, 52)
        Me.state_wa.Name = "state_wa"
        Me.state_wa.Size = New System.Drawing.Size(108, 26)
        Me.state_wa.TabIndex = 290
        Me.state_wa.Text = "WORKING"
        Me.state_wa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pgSetSession
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(665, 542)
        Me.Controls.Add(Me.state_wa)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.UCformtext8)
        Me.Controls.Add(Me.UCformtext7)
        Me.Controls.Add(Me.UCformtext6)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.UCformtext5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.UCformtext4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MaxSPNum)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MaxSPDay)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.UCformtext3)
        Me.Controls.Add(Me.UCformtext2)
        Me.Controls.Add(Me.UCformtext1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "pgSetSession"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "pgSetSession"
        Me.Panel1.ResumeLayout(False)
        CType(Me.MaxSPDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaxSPNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnclose As Button
    Friend WithEvents lbltext As Label
    Friend WithEvents Btn1 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents UCformtext1 As UCformtext
    Friend WithEvents UCformtext2 As UCformtext
    Friend WithEvents UCformtext3 As UCformtext
    Friend WithEvents BtnDelMess As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents MaxSPDay As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents MaxSPNum As NumericUpDown
    Friend WithEvents UCformtext4 As UCformtext
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents UCformtext5 As UCformtext
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents UCformtext6 As UCformtext
    Friend WithEvents Label12 As Label
    Friend WithEvents UCformtext7 As UCformtext
    Friend WithEvents UCformtext8 As UCformtext
    Friend WithEvents Label13 As Label
    Friend WithEvents state_wa As Label
    Friend WithEvents BtnDelSesi As Button
End Class
