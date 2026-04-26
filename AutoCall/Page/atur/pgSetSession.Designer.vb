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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnDel = New System.Windows.Forms.Button()
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
        Me.Rd0 = New System.Windows.Forms.RadioButton()
        Me.Rd1 = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Rd2 = New System.Windows.Forms.RadioButton()
        Me.UCformtext7 = New AutoCall.UCformtext()
        Me.UCformtext6 = New AutoCall.UCformtext()
        Me.UCformtext5 = New AutoCall.UCformtext()
        Me.UCformtext4 = New AutoCall.UCformtext()
        Me.UCformtext3 = New AutoCall.UCformtext()
        Me.UCformtext2 = New AutoCall.UCformtext()
        Me.UCformtext1 = New AutoCall.UCformtext()
        Me.Panel1.SuspendLayout()
        CType(Me.MaxSPDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaxSPNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnDel)
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Controls.Add(Me.lbltext)
        Me.Panel1.Controls.Add(Me.Btn1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(665, 45)
        Me.Panel1.TabIndex = 142
        '
        'BtnDel
        '
        Me.BtnDel.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDel.FlatAppearance.BorderSize = 0
        Me.BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDel.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDel.Location = New System.Drawing.Point(537, 5)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(72, 34)
        Me.BtnDel.TabIndex = 141
        Me.BtnDel.Text = "Delete Message"
        Me.BtnDel.UseVisualStyleBackColor = False
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
        Me.lbltext.Size = New System.Drawing.Size(411, 30)
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
        Me.Btn1.Location = New System.Drawing.Point(461, 3)
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
        Me.Label9.Location = New System.Drawing.Point(19, 55)
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
        Me.Label1.Location = New System.Drawing.Point(365, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(288, 28)
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
        Me.Label2.Location = New System.Drawing.Point(365, 322)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 28)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "Link Web Chat"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(19, 100)
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
        Me.MaxSPDay.Location = New System.Drawing.Point(22, 121)
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
        Me.Label6.Location = New System.Drawing.Point(109, 125)
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
        Me.Label4.Location = New System.Drawing.Point(109, 192)
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
        Me.Label5.Location = New System.Drawing.Point(19, 166)
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
        Me.MaxSPNum.Location = New System.Drawing.Point(22, 187)
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
        Me.Label7.Location = New System.Drawing.Point(19, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(288, 28)
        Me.Label7.TabIndex = 278
        Me.Label7.Text = "Fungsi Session Ini Sebagai"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 322)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(295, 28)
        Me.Label8.TabIndex = 279
        Me.Label8.Text = "Server WhatsApp"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Rd0
        '
        Me.Rd0.AutoSize = True
        Me.Rd0.ForeColor = System.Drawing.Color.White
        Me.Rd0.Location = New System.Drawing.Point(50, 279)
        Me.Rd0.Name = "Rd0"
        Me.Rd0.Size = New System.Drawing.Size(68, 17)
        Me.Rd0.TabIndex = 280
        Me.Rd0.TabStop = True
        Me.Rd0.Text = "Receiver"
        Me.Rd0.UseVisualStyleBackColor = True
        '
        'Rd1
        '
        Me.Rd1.AutoSize = True
        Me.Rd1.ForeColor = System.Drawing.Color.White
        Me.Rd1.Location = New System.Drawing.Point(138, 279)
        Me.Rd1.Name = "Rd1"
        Me.Rd1.Size = New System.Drawing.Size(59, 17)
        Me.Rd1.TabIndex = 281
        Me.Rd1.TabStop = True
        Me.Rd1.Text = "Sender"
        Me.Rd1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(177, 192)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 283
        Me.Label10.Text = "Isi 0:Unlimited"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(177, 125)
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
        Me.Label12.Location = New System.Drawing.Point(11, 437)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(642, 28)
        Me.Label12.TabIndex = 285
        Me.Label12.Text = "Data Session"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Rd2
        '
        Me.Rd2.AutoSize = True
        Me.Rd2.ForeColor = System.Drawing.Color.White
        Me.Rd2.Location = New System.Drawing.Point(218, 279)
        Me.Rd2.Name = "Rd2"
        Me.Rd2.Size = New System.Drawing.Size(63, 17)
        Me.Rd2.TabIndex = 288
        Me.Rd2.TabStop = True
        Me.Rd2.Text = "Forward"
        Me.Rd2.UseVisualStyleBackColor = True
        '
        'UCformtext7
        '
        Me.UCformtext7.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext7.Location = New System.Drawing.Point(353, 468)
        Me.UCformtext7.Name = "UCformtext7"
        Me.UCformtext7.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext7.TabIndex = 287
        '
        'UCformtext6
        '
        Me.UCformtext6.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext6.Location = New System.Drawing.Point(12, 468)
        Me.UCformtext6.Name = "UCformtext6"
        Me.UCformtext6.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext6.TabIndex = 286
        '
        'UCformtext5
        '
        Me.UCformtext5.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext5.Location = New System.Drawing.Point(12, 353)
        Me.UCformtext5.Name = "UCformtext5"
        Me.UCformtext5.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext5.TabIndex = 282
        '
        'UCformtext4
        '
        Me.UCformtext4.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext4.Location = New System.Drawing.Point(353, 353)
        Me.UCformtext4.Name = "UCformtext4"
        Me.UCformtext4.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext4.TabIndex = 277
        '
        'UCformtext3
        '
        Me.UCformtext3.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext3.Location = New System.Drawing.Point(353, 226)
        Me.UCformtext3.Name = "UCformtext3"
        Me.UCformtext3.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext3.TabIndex = 150
        '
        'UCformtext2
        '
        Me.UCformtext2.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext2.Location = New System.Drawing.Point(353, 158)
        Me.UCformtext2.Name = "UCformtext2"
        Me.UCformtext2.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext2.TabIndex = 149
        '
        'UCformtext1
        '
        Me.UCformtext1.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext1.Location = New System.Drawing.Point(353, 90)
        Me.UCformtext1.Name = "UCformtext1"
        Me.UCformtext1.Size = New System.Drawing.Size(300, 62)
        Me.UCformtext1.TabIndex = 148
        '
        'pgSetSession
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(665, 542)
        Me.Controls.Add(Me.Rd2)
        Me.Controls.Add(Me.UCformtext7)
        Me.Controls.Add(Me.UCformtext6)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.UCformtext5)
        Me.Controls.Add(Me.Rd1)
        Me.Controls.Add(Me.Rd0)
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
    Friend WithEvents BtnDel As Button
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
    Friend WithEvents Rd0 As RadioButton
    Friend WithEvents Rd1 As RadioButton
    Friend WithEvents UCformtext5 As UCformtext
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents UCformtext6 As UCformtext
    Friend WithEvents Label12 As Label
    Friend WithEvents UCformtext7 As UCformtext
    Friend WithEvents Rd2 As RadioButton
End Class
