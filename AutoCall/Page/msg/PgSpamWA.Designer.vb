<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PgSpamWA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PgSpamWA))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PnlogActivty = New System.Windows.Forms.Panel()
        Me.lstLog = New System.Windows.Forms.ListBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnSSpam = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtSender = New System.Windows.Forms.TextBox()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCreaForm = New System.Windows.Forms.Button()
        Me.JCount = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtMessage = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TotSender = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Delay = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.PnlogActivty.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.JCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotSender, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Delay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PnlogActivty)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Location = New System.Drawing.Point(531, 12)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(400, 435)
        Me.Panel4.TabIndex = 225
        '
        'PnlogActivty
        '
        Me.PnlogActivty.AutoScroll = True
        Me.PnlogActivty.Controls.Add(Me.lstLog)
        Me.PnlogActivty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlogActivty.Location = New System.Drawing.Point(0, 41)
        Me.PnlogActivty.Name = "PnlogActivty"
        Me.PnlogActivty.Size = New System.Drawing.Size(400, 394)
        Me.PnlogActivty.TabIndex = 144
        '
        'lstLog
        '
        Me.lstLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstLog.Font = New System.Drawing.Font("Microsoft New Tai Lue", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLog.ForeColor = System.Drawing.Color.White
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.ItemHeight = 15
        Me.lstLog.Location = New System.Drawing.Point(0, 0)
        Me.lstLog.Margin = New System.Windows.Forms.Padding(10)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(400, 394)
        Me.lstLog.TabIndex = 176
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Panel5.Controls.Add(Me.BtnSSpam)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(400, 41)
        Me.Panel5.TabIndex = 4
        '
        'BtnSSpam
        '
        Me.BtnSSpam.BackColor = System.Drawing.Color.DimGray
        Me.BtnSSpam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSSpam.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSSpam.FlatAppearance.BorderSize = 0
        Me.BtnSSpam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSSpam.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSSpam.ForeColor = System.Drawing.Color.Black
        Me.BtnSSpam.Image = CType(resources.GetObject("BtnSSpam.Image"), System.Drawing.Image)
        Me.BtnSSpam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSSpam.Location = New System.Drawing.Point(282, 0)
        Me.BtnSSpam.Name = "BtnSSpam"
        Me.BtnSSpam.Size = New System.Drawing.Size(118, 41)
        Me.BtnSSpam.TabIndex = 183
        Me.BtnSSpam.Text = "Stop All"
        Me.BtnSSpam.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(5, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 23)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Log Activity"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtSender
        '
        Me.TxtSender.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtSender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSender.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSender.ForeColor = System.Drawing.Color.White
        Me.TxtSender.Location = New System.Drawing.Point(8, 53)
        Me.TxtSender.Multiline = True
        Me.TxtSender.Name = "TxtSender"
        Me.TxtSender.ReadOnly = True
        Me.TxtSender.Size = New System.Drawing.Size(116, 344)
        Me.TxtSender.TabIndex = 241
        '
        'BtnSelect
        '
        Me.BtnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.BtnSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSelect.FlatAppearance.BorderSize = 0
        Me.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelect.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSelect.Location = New System.Drawing.Point(21, 24)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(95, 24)
        Me.BtnSelect.TabIndex = 242
        Me.BtnSelect.Text = "Pilih WA"
        Me.BtnSelect.UseVisualStyleBackColor = False
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.btnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSend.FlatAppearance.BorderSize = 0
        Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSend.Image = CType(resources.GetObject("btnSend.Image"), System.Drawing.Image)
        Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSend.Location = New System.Drawing.Point(432, 12)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(93, 36)
        Me.btnSend.TabIndex = 245
        Me.btnSend.Text = "  Kirim"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Location = New System.Drawing.Point(130, 54)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(395, 206)
        Me.Panel1.TabIndex = 246
        '
        'BtnCreaForm
        '
        Me.BtnCreaForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.BtnCreaForm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCreaForm.FlatAppearance.BorderSize = 0
        Me.BtnCreaForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCreaForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCreaForm.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCreaForm.Location = New System.Drawing.Point(219, 27)
        Me.BtnCreaForm.Name = "BtnCreaForm"
        Me.BtnCreaForm.Size = New System.Drawing.Size(122, 24)
        Me.BtnCreaForm.TabIndex = 247
        Me.BtnCreaForm.Text = "Tambahkan No Spam"
        Me.BtnCreaForm.UseVisualStyleBackColor = False
        '
        'JCount
        '
        Me.JCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.JCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.JCount.ForeColor = System.Drawing.Color.White
        Me.JCount.Location = New System.Drawing.Point(138, 31)
        Me.JCount.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.JCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.JCount.Name = "JCount"
        Me.JCount.ReadOnly = True
        Me.JCount.Size = New System.Drawing.Size(75, 20)
        Me.JCount.TabIndex = 259
        Me.JCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.JCount.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(135, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 258
        Me.Label3.Text = "Jumlah Number"
        '
        'TxtMessage
        '
        Me.TxtMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMessage.Font = New System.Drawing.Font("Lucida Bright", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMessage.ForeColor = System.Drawing.Color.White
        Me.TxtMessage.Location = New System.Drawing.Point(133, 297)
        Me.TxtMessage.Name = "TxtMessage"
        Me.TxtMessage.Size = New System.Drawing.Size(392, 100)
        Me.TxtMessage.TabIndex = 260
        Me.TxtMessage.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Book Antiqua", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(131, 275)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 18)
        Me.Label4.TabIndex = 261
        Me.Label4.Text = "Pesan teks:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(351, 410)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 16)
        Me.Label12.TabIndex = 274
        Me.Label12.Text = "Use Sender"
        '
        'TotSender
        '
        Me.TotSender.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotSender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotSender.Enabled = False
        Me.TotSender.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotSender.ForeColor = System.Drawing.Color.White
        Me.TotSender.Location = New System.Drawing.Point(354, 428)
        Me.TotSender.Name = "TotSender"
        Me.TotSender.ReadOnly = True
        Me.TotSender.Size = New System.Drawing.Size(55, 20)
        Me.TotSender.TabIndex = 275
        Me.TotSender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(486, 430)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 16)
        Me.Label6.TabIndex = 271
        Me.Label6.Text = "Second"
        '
        'Delay
        '
        Me.Delay.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Delay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Delay.ForeColor = System.Drawing.Color.White
        Me.Delay.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.Delay.Location = New System.Drawing.Point(416, 428)
        Me.Delay.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Delay.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.Delay.Name = "Delay"
        Me.Delay.ReadOnly = True
        Me.Delay.Size = New System.Drawing.Size(64, 20)
        Me.Delay.TabIndex = 267
        Me.Delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Delay.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(413, 410)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 266
        Me.Label2.Text = "Delay Per Message"
        '
        'PgSpamWA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(943, 460)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TotSender)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Delay)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtMessage)
        Me.Controls.Add(Me.JCount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnCreaForm)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.TxtSender)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PgSpamWA"
        Me.Text = "PgSpamWA"
        Me.Panel4.ResumeLayout(False)
        Me.PnlogActivty.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.JCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotSender, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Delay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents PnlogActivty As Panel
    Public WithEvents lstLog As ListBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents BtnSSpam As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtSender As TextBox
    Friend WithEvents BtnSelect As Button
    Friend WithEvents btnSend As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnCreaForm As Button
    Friend WithEvents JCount As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtMessage As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TotSender As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Delay As NumericUpDown
    Friend WithEvents Label2 As Label
End Class
