<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PgEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PgEmail))
        Me.lblCountState = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TotSender = New System.Windows.Forms.NumericUpDown()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PnlogActivty = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnStopCall = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtSender = New System.Windows.Forms.TextBox()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.TxtNumber = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.BtnContact = New System.Windows.Forms.Button()
        Me.BtnPaste = New System.Windows.Forms.Button()
        Me.LblTotData = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LblTilte = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.TotSender, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCountState
        '
        Me.lblCountState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCountState.AutoSize = True
        Me.lblCountState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCountState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountState.ForeColor = System.Drawing.Color.White
        Me.lblCountState.Location = New System.Drawing.Point(760, 10)
        Me.lblCountState.Name = "lblCountState"
        Me.lblCountState.Size = New System.Drawing.Size(0, 13)
        Me.lblCountState.TabIndex = 295
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(138, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 300
        Me.Label12.Text = "Use Sender"
        '
        'TotSender
        '
        Me.TotSender.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotSender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotSender.Enabled = False
        Me.TotSender.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotSender.ForeColor = System.Drawing.Color.White
        Me.TotSender.Location = New System.Drawing.Point(129, 35)
        Me.TotSender.Name = "TotSender"
        Me.TotSender.ReadOnly = True
        Me.TotSender.Size = New System.Drawing.Size(84, 20)
        Me.TotSender.TabIndex = 301
        Me.TotSender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PnlogActivty)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Location = New System.Drawing.Point(509, 30)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(427, 419)
        Me.Panel4.TabIndex = 290
        '
        'PnlogActivty
        '
        Me.PnlogActivty.AutoScroll = True
        Me.PnlogActivty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlogActivty.Location = New System.Drawing.Point(0, 41)
        Me.PnlogActivty.Name = "PnlogActivty"
        Me.PnlogActivty.Size = New System.Drawing.Size(427, 378)
        Me.PnlogActivty.TabIndex = 144
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Controls.Add(Me.BtnStopCall)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(427, 41)
        Me.Panel5.TabIndex = 4
        '
        'BtnStopCall
        '
        Me.BtnStopCall.BackColor = System.Drawing.Color.DimGray
        Me.BtnStopCall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStopCall.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnStopCall.FlatAppearance.BorderSize = 0
        Me.BtnStopCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStopCall.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStopCall.ForeColor = System.Drawing.Color.Black
        Me.BtnStopCall.Image = CType(resources.GetObject("BtnStopCall.Image"), System.Drawing.Image)
        Me.BtnStopCall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStopCall.Location = New System.Drawing.Point(309, 0)
        Me.BtnStopCall.Name = "BtnStopCall"
        Me.BtnStopCall.Size = New System.Drawing.Size(118, 41)
        Me.BtnStopCall.TabIndex = 182
        Me.BtnStopCall.Text = "Stop All"
        Me.BtnStopCall.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(432, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(5)
        Me.Button1.Size = New System.Drawing.Size(40, 30)
        Me.Button1.TabIndex = 78
        Me.Button1.UseVisualStyleBackColor = False
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
        Me.TxtSender.Location = New System.Drawing.Point(7, 35)
        Me.TxtSender.Multiline = True
        Me.TxtSender.Name = "TxtSender"
        Me.TxtSender.ReadOnly = True
        Me.TxtSender.Size = New System.Drawing.Size(116, 101)
        Me.TxtSender.TabIndex = 274
        '
        'BtnSelect
        '
        Me.BtnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.BtnSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSelect.FlatAppearance.BorderSize = 0
        Me.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelect.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSelect.Location = New System.Drawing.Point(16, 7)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(95, 24)
        Me.BtnSelect.TabIndex = 275
        Me.BtnSelect.Text = "Pilih "
        Me.BtnSelect.UseVisualStyleBackColor = False
        '
        'TxtNumber
        '
        Me.TxtNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumber.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.ForeColor = System.Drawing.Color.White
        Me.TxtNumber.Location = New System.Drawing.Point(129, 88)
        Me.TxtNumber.Multiline = True
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.ReadOnly = True
        Me.TxtNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtNumber.Size = New System.Drawing.Size(375, 48)
        Me.TxtNumber.TabIndex = 276
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(125, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 277
        Me.Label7.Text = "Enter Email :"
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
        Me.btnSend.Location = New System.Drawing.Point(410, 10)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(93, 36)
        Me.btnSend.TabIndex = 278
        Me.btnSend.Text = "  Kirim"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'BtnContact
        '
        Me.BtnContact.BackColor = System.Drawing.Color.Transparent
        Me.BtnContact.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnContact.FlatAppearance.BorderSize = 0
        Me.BtnContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnContact.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnContact.Image = CType(resources.GetObject("BtnContact.Image"), System.Drawing.Image)
        Me.BtnContact.Location = New System.Drawing.Point(479, 57)
        Me.BtnContact.Name = "BtnContact"
        Me.BtnContact.Size = New System.Drawing.Size(25, 25)
        Me.BtnContact.TabIndex = 282
        Me.BtnContact.UseVisualStyleBackColor = False
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
        Me.BtnPaste.Location = New System.Drawing.Point(446, 57)
        Me.BtnPaste.Name = "BtnPaste"
        Me.BtnPaste.Size = New System.Drawing.Size(25, 25)
        Me.BtnPaste.TabIndex = 280
        Me.BtnPaste.UseVisualStyleBackColor = False
        '
        'LblTotData
        '
        Me.LblTotData.AutoSize = True
        Me.LblTotData.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.LblTotData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotData.ForeColor = System.Drawing.Color.White
        Me.LblTotData.Location = New System.Drawing.Point(210, 70)
        Me.LblTotData.Name = "LblTotData"
        Me.LblTotData.Size = New System.Drawing.Size(57, 13)
        Me.LblTotData.TabIndex = 281
        Me.LblTotData.Text = "Total Data"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(7, 168)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(497, 33)
        Me.TextBox1.TabIndex = 303
        '
        'LblTilte
        '
        Me.LblTilte.AutoSize = True
        Me.LblTilte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTilte.ForeColor = System.Drawing.Color.White
        Me.LblTilte.Location = New System.Drawing.Point(4, 152)
        Me.LblTilte.Name = "LblTilte"
        Me.LblTilte.Size = New System.Drawing.Size(43, 13)
        Me.LblTilte.TabIndex = 304
        Me.LblTilte.Text = "Subject"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 216)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 305
        Me.Label1.Text = "Body :"
        '
        'PgEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(943, 460)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LblTilte)
        Me.Controls.Add(Me.lblCountState)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TotSender)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.TxtSender)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.BtnContact)
        Me.Controls.Add(Me.BtnPaste)
        Me.Controls.Add(Me.LblTotData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PgEmail"
        Me.Text = "PgEmail"
        CType(Me.TotSender, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCountState As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TotSender As NumericUpDown
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PnlogActivty As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents BtnStopCall As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtSender As TextBox
    Friend WithEvents BtnSelect As Button
    Friend WithEvents TxtNumber As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnSend As Button
    Friend WithEvents BtnContact As Button
    Friend WithEvents BtnPaste As Button
    Friend WithEvents LblTotData As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents LblTilte As Label
    Friend WithEvents Label1 As Label
End Class
