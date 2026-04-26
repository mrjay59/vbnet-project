<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCaller
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaller))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TotDial = New System.Windows.Forms.NumericUpDown()
        Me.TotRecall = New System.Windows.Forms.NumericUpDown()
        Me.TotClose = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TotDurasi = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCaller = New System.Windows.Forms.Button()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtNumber = New System.Windows.Forms.TextBox()
        Me.BtnPaste = New System.Windows.Forms.Button()
        Me.BtnTxt = New System.Windows.Forms.Button()
        Me.BtnCsv = New System.Windows.Forms.Button()
        Me.LblTotData = New System.Windows.Forms.Label()
        Me.TxtCaller = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.rd1 = New System.Windows.Forms.RadioButton()
        Me.rd0 = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnStat = New System.Windows.Forms.Button()
        Me.BtnContact = New System.Windows.Forms.Button()
        CType(Me.TotDial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotRecall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotDurasi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(261, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 16)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = "Recall"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(114, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Use Device"
        '
        'TotDial
        '
        Me.TotDial.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotDial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotDial.Enabled = False
        Me.TotDial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotDial.ForeColor = System.Drawing.Color.White
        Me.TotDial.Location = New System.Drawing.Point(117, 163)
        Me.TotDial.Name = "TotDial"
        Me.TotDial.ReadOnly = True
        Me.TotDial.Size = New System.Drawing.Size(55, 20)
        Me.TotDial.TabIndex = 120
        Me.TotDial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TotRecall
        '
        Me.TotRecall.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotRecall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotRecall.ForeColor = System.Drawing.Color.White
        Me.TotRecall.Location = New System.Drawing.Point(263, 163)
        Me.TotRecall.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.TotRecall.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TotRecall.Name = "TotRecall"
        Me.TotRecall.ReadOnly = True
        Me.TotRecall.Size = New System.Drawing.Size(55, 20)
        Me.TotRecall.TabIndex = 121
        Me.TotRecall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotRecall.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TotClose
        '
        Me.TotClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotClose.ForeColor = System.Drawing.Color.White
        Me.TotClose.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.TotClose.Location = New System.Drawing.Point(330, 163)
        Me.TotClose.Maximum = New Decimal(New Integer() {45, 0, 0, 0})
        Me.TotClose.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.TotClose.Name = "TotClose"
        Me.TotClose.ReadOnly = True
        Me.TotClose.Size = New System.Drawing.Size(64, 20)
        Me.TotClose.TabIndex = 126
        Me.TotClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotClose.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(181, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 16)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Durasi"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(327, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 16)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "Delay"
        '
        'TotDurasi
        '
        Me.TotDurasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotDurasi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotDurasi.ForeColor = System.Drawing.Color.White
        Me.TotDurasi.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.TotDurasi.Location = New System.Drawing.Point(184, 163)
        Me.TotDurasi.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.TotDurasi.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TotDurasi.Name = "TotDurasi"
        Me.TotDurasi.ReadOnly = True
        Me.TotDurasi.Size = New System.Drawing.Size(64, 20)
        Me.TotDurasi.TabIndex = 124
        Me.TotDurasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotDurasi.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(119, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Nama File"
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
        Me.btnCaller.Location = New System.Drawing.Point(264, 204)
        Me.btnCaller.Name = "btnCaller"
        Me.btnCaller.Size = New System.Drawing.Size(130, 34)
        Me.btnCaller.TabIndex = 129
        Me.btnCaller.Text = "Create Call"
        Me.btnCaller.UseVisualStyleBackColor = False
        '
        'BtnSelect
        '
        Me.BtnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.BtnSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSelect.FlatAppearance.BorderSize = 0
        Me.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelect.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelect.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSelect.Location = New System.Drawing.Point(12, 6)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(85, 26)
        Me.BtnSelect.TabIndex = 130
        Me.BtnSelect.Text = "Select WA"
        Me.BtnSelect.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(115, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 16)
        Me.Label7.TabIndex = 134
        Me.Label7.Text = "Enter Number :"
        '
        'TxtNumber
        '
        Me.TxtNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtNumber.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.ForeColor = System.Drawing.Color.White
        Me.TxtNumber.Location = New System.Drawing.Point(117, 32)
        Me.TxtNumber.Multiline = True
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.ReadOnly = True
        Me.TxtNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtNumber.Size = New System.Drawing.Size(294, 90)
        Me.TxtNumber.TabIndex = 133
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
        Me.BtnPaste.Location = New System.Drawing.Point(290, 5)
        Me.BtnPaste.Name = "BtnPaste"
        Me.BtnPaste.Size = New System.Drawing.Size(25, 25)
        Me.BtnPaste.TabIndex = 152
        Me.BtnPaste.UseVisualStyleBackColor = False
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
        Me.BtnTxt.Location = New System.Drawing.Point(321, 5)
        Me.BtnTxt.Name = "BtnTxt"
        Me.BtnTxt.Size = New System.Drawing.Size(25, 25)
        Me.BtnTxt.TabIndex = 151
        Me.BtnTxt.UseVisualStyleBackColor = False
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
        Me.BtnCsv.Location = New System.Drawing.Point(352, 5)
        Me.BtnCsv.Name = "BtnCsv"
        Me.BtnCsv.Size = New System.Drawing.Size(25, 25)
        Me.BtnCsv.TabIndex = 150
        Me.BtnCsv.UseVisualStyleBackColor = False
        '
        'LblTotData
        '
        Me.LblTotData.AutoSize = True
        Me.LblTotData.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.LblTotData.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotData.ForeColor = System.Drawing.Color.White
        Me.LblTotData.Location = New System.Drawing.Point(304, 125)
        Me.LblTotData.Name = "LblTotData"
        Me.LblTotData.Size = New System.Drawing.Size(58, 16)
        Me.LblTotData.TabIndex = 153
        Me.LblTotData.Text = "Total Data"
        '
        'TxtCaller
        '
        Me.TxtCaller.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtCaller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCaller.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtCaller.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCaller.ForeColor = System.Drawing.Color.White
        Me.TxtCaller.Location = New System.Drawing.Point(3, 32)
        Me.TxtCaller.Multiline = True
        Me.TxtCaller.Name = "TxtCaller"
        Me.TxtCaller.ReadOnly = True
        Me.TxtCaller.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtCaller.Size = New System.Drawing.Size(107, 242)
        Me.TxtCaller.TabIndex = 154
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(414, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 16)
        Me.Label8.TabIndex = 182
        Me.Label8.Text = "Log Activity"
        '
        'PanelPusat
        '
        Me.PanelPusat.AutoScroll = True
        Me.PanelPusat.Location = New System.Drawing.Point(417, 31)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(399, 243)
        Me.PanelPusat.TabIndex = 181
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.ForeColor = System.Drawing.Color.White
        Me.rd1.Location = New System.Drawing.Point(176, 223)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(52, 17)
        Me.rd1.TabIndex = 185
        Me.rd1.TabStop = True
        Me.rd1.Text = "Tidak"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'rd0
        '
        Me.rd0.AutoSize = True
        Me.rd0.ForeColor = System.Drawing.Color.White
        Me.rd0.Location = New System.Drawing.Point(123, 223)
        Me.rd0.Name = "rd0"
        Me.rd0.Size = New System.Drawing.Size(38, 17)
        Me.rd0.TabIndex = 184
        Me.rd0.TabStop = True
        Me.rd0.Text = "Ya"
        Me.rd0.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(115, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 16)
        Me.Label5.TabIndex = 183
        Me.Label5.Text = "Bisa melakukan komunikasi ?"
        '
        'BtnStat
        '
        Me.BtnStat.BackColor = System.Drawing.Color.Red
        Me.BtnStat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStat.FlatAppearance.BorderSize = 0
        Me.BtnStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStat.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStat.ForeColor = System.Drawing.Color.Black
        Me.BtnStat.Location = New System.Drawing.Point(758, 2)
        Me.BtnStat.Name = "BtnStat"
        Me.BtnStat.Size = New System.Drawing.Size(58, 27)
        Me.BtnStat.TabIndex = 186
        Me.BtnStat.Text = "Stop All"
        Me.BtnStat.UseVisualStyleBackColor = False
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
        Me.BtnContact.Location = New System.Drawing.Point(383, 5)
        Me.BtnContact.Name = "BtnContact"
        Me.BtnContact.Size = New System.Drawing.Size(25, 25)
        Me.BtnContact.TabIndex = 187
        Me.BtnContact.UseVisualStyleBackColor = False
        '
        'frmCaller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(818, 282)
        Me.Controls.Add(Me.BtnContact)
        Me.Controls.Add(Me.BtnStat)
        Me.Controls.Add(Me.rd1)
        Me.Controls.Add(Me.rd0)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PanelPusat)
        Me.Controls.Add(Me.TxtCaller)
        Me.Controls.Add(Me.LblTotData)
        Me.Controls.Add(Me.BtnPaste)
        Me.Controls.Add(Me.BtnTxt)
        Me.Controls.Add(Me.BtnCsv)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.btnCaller)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TotDial)
        Me.Controls.Add(Me.TotRecall)
        Me.Controls.Add(Me.TotClose)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TotDurasi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCaller"
        Me.Text = "frmCaller"
        CType(Me.TotDial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotRecall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotDurasi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TotDial As NumericUpDown
    Friend WithEvents TotRecall As NumericUpDown
    Friend WithEvents TotClose As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TotDurasi As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCaller As Button
    Friend WithEvents BtnSelect As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtNumber As TextBox
    Friend WithEvents BtnPaste As Button
    Friend WithEvents BtnTxt As Button
    Friend WithEvents BtnCsv As Button
    Friend WithEvents LblTotData As Label
    Friend WithEvents TxtCaller As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents PanelPusat As Panel
    Friend WithEvents rd1 As RadioButton
    Friend WithEvents rd0 As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnStat As Button
    Friend WithEvents BtnContact As Button
End Class
