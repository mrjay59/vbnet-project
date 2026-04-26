<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSender
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSender))
        Me.TxtMessage = New System.Windows.Forms.RichTextBox()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.TxtSender = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TotDial = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtNumber = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.TotDel1 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TotDel2 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnCsv = New System.Windows.Forms.Button()
        Me.BtnTxt = New System.Windows.Forms.Button()
        Me.BtnPaste = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblTotData = New System.Windows.Forms.Label()
        Me.BtnStat = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.BtnContact = New System.Windows.Forms.Button()
        CType(Me.TotDial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotDel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotDel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtMessage
        '
        Me.TxtMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMessage.Font = New System.Drawing.Font("Lucida Bright", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMessage.ForeColor = System.Drawing.Color.White
        Me.TxtMessage.Location = New System.Drawing.Point(102, 97)
        Me.TxtMessage.Name = "TxtMessage"
        Me.TxtMessage.Size = New System.Drawing.Size(309, 131)
        Me.TxtMessage.TabIndex = 90
        Me.TxtMessage.Text = ""
        '
        'BtnSelect
        '
        Me.BtnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.BtnSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSelect.FlatAppearance.BorderSize = 0
        Me.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelect.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSelect.Location = New System.Drawing.Point(8, 3)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(89, 24)
        Me.BtnSelect.TabIndex = 133
        Me.BtnSelect.Text = "Select WA"
        Me.BtnSelect.UseVisualStyleBackColor = False
        '
        'TxtSender
        '
        Me.TxtSender.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtSender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSender.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSender.ForeColor = System.Drawing.Color.White
        Me.TxtSender.Location = New System.Drawing.Point(3, 28)
        Me.TxtSender.Multiline = True
        Me.TxtSender.Name = "TxtSender"
        Me.TxtSender.ReadOnly = True
        Me.TxtSender.Size = New System.Drawing.Size(94, 247)
        Me.TxtSender.TabIndex = 131
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(99, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "Use Device"
        '
        'TotDial
        '
        Me.TotDial.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotDial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotDial.Enabled = False
        Me.TotDial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotDial.ForeColor = System.Drawing.Color.White
        Me.TotDial.Location = New System.Drawing.Point(102, 254)
        Me.TotDial.Name = "TotDial"
        Me.TotDial.ReadOnly = True
        Me.TotDial.Size = New System.Drawing.Size(55, 22)
        Me.TotDial.TabIndex = 135
        Me.TotDial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotDial.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(96, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 16)
        Me.Label7.TabIndex = 138
        Me.Label7.Text = "Enter Number :"
        '
        'TxtNumber
        '
        Me.TxtNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumber.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.ForeColor = System.Drawing.Color.White
        Me.TxtNumber.Location = New System.Drawing.Point(100, 27)
        Me.TxtNumber.Multiline = True
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.ReadOnly = True
        Me.TxtNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtNumber.Size = New System.Drawing.Size(311, 48)
        Me.TxtNumber.TabIndex = 137
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
        Me.btnSend.Location = New System.Drawing.Point(311, 237)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(99, 36)
        Me.btnSend.TabIndex = 141
        Me.btnSend.Text = "  Kirim"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'TotDel1
        '
        Me.TotDel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotDel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotDel1.ForeColor = System.Drawing.Color.White
        Me.TotDel1.Location = New System.Drawing.Point(170, 255)
        Me.TotDel1.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.TotDel1.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.TotDel1.Name = "TotDel1"
        Me.TotDel1.ReadOnly = True
        Me.TotDel1.Size = New System.Drawing.Size(48, 20)
        Me.TotDel1.TabIndex = 143
        Me.TotDel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotDel1.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(189, 236)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 16)
        Me.Label3.TabIndex = 142
        Me.Label3.Text = "Set Delay Per Msg"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(96, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = "Pesan teks:"
        '
        'TotDel2
        '
        Me.TotDel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotDel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotDel2.ForeColor = System.Drawing.Color.White
        Me.TotDel2.Location = New System.Drawing.Point(249, 255)
        Me.TotDel2.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.TotDel2.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.TotDel2.Name = "TotDel2"
        Me.TotDel2.ReadOnly = True
        Me.TotDel2.Size = New System.Drawing.Size(48, 20)
        Me.TotDel2.TabIndex = 145
        Me.TotDel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotDel2.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(224, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 16)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "s/d"
        '
        'BtnCsv
        '
        Me.BtnCsv.BackColor = System.Drawing.Color.Transparent
        Me.BtnCsv.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCsv.FlatAppearance.BorderSize = 0
        Me.BtnCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCsv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCsv.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCsv.Image = CType(resources.GetObject("BtnCsv.Image"), System.Drawing.Image)
        Me.BtnCsv.Location = New System.Drawing.Point(349, 0)
        Me.BtnCsv.Name = "BtnCsv"
        Me.BtnCsv.Size = New System.Drawing.Size(25, 25)
        Me.BtnCsv.TabIndex = 147
        Me.BtnCsv.UseVisualStyleBackColor = False
        '
        'BtnTxt
        '
        Me.BtnTxt.BackColor = System.Drawing.Color.Transparent
        Me.BtnTxt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTxt.FlatAppearance.BorderSize = 0
        Me.BtnTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTxt.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnTxt.Image = CType(resources.GetObject("BtnTxt.Image"), System.Drawing.Image)
        Me.BtnTxt.Location = New System.Drawing.Point(318, 0)
        Me.BtnTxt.Name = "BtnTxt"
        Me.BtnTxt.Size = New System.Drawing.Size(25, 25)
        Me.BtnTxt.TabIndex = 148
        Me.BtnTxt.UseVisualStyleBackColor = False
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
        Me.BtnPaste.Location = New System.Drawing.Point(287, 0)
        Me.BtnPaste.Name = "BtnPaste"
        Me.BtnPaste.Size = New System.Drawing.Size(25, 25)
        Me.BtnPaste.TabIndex = 149
        Me.BtnPaste.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(226, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 16)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "Nama File"
        '
        'LblTotData
        '
        Me.LblTotData.AutoSize = True
        Me.LblTotData.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.LblTotData.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotData.ForeColor = System.Drawing.Color.White
        Me.LblTotData.Location = New System.Drawing.Point(340, 78)
        Me.LblTotData.Name = "LblTotData"
        Me.LblTotData.Size = New System.Drawing.Size(58, 16)
        Me.LblTotData.TabIndex = 154
        Me.LblTotData.Text = "Total Data"
        '
        'BtnStat
        '
        Me.BtnStat.BackColor = System.Drawing.Color.Red
        Me.BtnStat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStat.FlatAppearance.BorderSize = 0
        Me.BtnStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStat.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStat.ForeColor = System.Drawing.Color.Black
        Me.BtnStat.Location = New System.Drawing.Point(756, 1)
        Me.BtnStat.Name = "BtnStat"
        Me.BtnStat.Size = New System.Drawing.Size(58, 27)
        Me.BtnStat.TabIndex = 189
        Me.BtnStat.Text = "Stop All"
        Me.BtnStat.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(411, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 16)
        Me.Label8.TabIndex = 188
        Me.Label8.Text = "Log Activity"
        '
        'PanelPusat
        '
        Me.PanelPusat.AutoScroll = True
        Me.PanelPusat.Location = New System.Drawing.Point(414, 30)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(400, 243)
        Me.PanelPusat.TabIndex = 187
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
        Me.BtnContact.Location = New System.Drawing.Point(380, 0)
        Me.BtnContact.Name = "BtnContact"
        Me.BtnContact.Size = New System.Drawing.Size(25, 25)
        Me.BtnContact.TabIndex = 190
        Me.BtnContact.UseVisualStyleBackColor = False
        '
        'frmSender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(818, 282)
        Me.Controls.Add(Me.BtnContact)
        Me.Controls.Add(Me.BtnStat)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PanelPusat)
        Me.Controls.Add(Me.LblTotData)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnPaste)
        Me.Controls.Add(Me.BtnTxt)
        Me.Controls.Add(Me.BtnCsv)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TotDel2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TotDel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TotDial)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.TxtSender)
        Me.Controls.Add(Me.TxtMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSender"
        Me.Text = "frmSender"
        CType(Me.TotDial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotDel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotDel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtMessage As RichTextBox
    Friend WithEvents BtnSelect As Button
    Friend WithEvents TxtSender As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TotDial As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtNumber As TextBox
    Friend WithEvents btnSend As Button
    Friend WithEvents TotDel1 As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TotDel2 As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnCsv As Button
    Friend WithEvents BtnTxt As Button
    Friend WithEvents BtnPaste As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents LblTotData As Label
    Friend WithEvents BtnStat As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents PanelPusat As Panel
    Friend WithEvents BtnContact As Button
End Class
