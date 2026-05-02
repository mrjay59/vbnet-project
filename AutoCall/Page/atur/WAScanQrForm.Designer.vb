<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WAScanQrForm
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
        Me.CountWa = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnADD = New System.Windows.Forms.Button()
        Me.seassionid = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rqQrcode = New System.Windows.Forms.RadioButton()
        Me.RqRegCode = New System.Windows.Forms.RadioButton()
        Me.naprovider = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.CountWa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CountWa
        '
        Me.CountWa.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.CountWa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CountWa.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountWa.ForeColor = System.Drawing.Color.White
        Me.CountWa.Location = New System.Drawing.Point(252, 104)
        Me.CountWa.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.CountWa.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.CountWa.Name = "CountWa"
        Me.CountWa.ReadOnly = True
        Me.CountWa.Size = New System.Drawing.Size(80, 31)
        Me.CountWa.TabIndex = 204
        Me.CountWa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CountWa.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(251, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
        Me.Label6.TabIndex = 205
        Me.Label6.Text = "Jumlah WA"
        '
        'BtnADD
        '
        Me.BtnADD.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.BtnADD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnADD.FlatAppearance.BorderSize = 0
        Me.BtnADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnADD.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnADD.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnADD.Location = New System.Drawing.Point(252, 165)
        Me.BtnADD.Name = "BtnADD"
        Me.BtnADD.Size = New System.Drawing.Size(147, 37)
        Me.BtnADD.TabIndex = 207
        Me.BtnADD.Text = "Create "
        Me.BtnADD.UseVisualStyleBackColor = False
        '
        'seassionid
        '
        Me.seassionid.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.seassionid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.seassionid.Enabled = False
        Me.seassionid.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seassionid.ForeColor = System.Drawing.Color.White
        Me.seassionid.Location = New System.Drawing.Point(12, 166)
        Me.seassionid.Name = "seassionid"
        Me.seassionid.ReadOnly = True
        Me.seassionid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.seassionid.Size = New System.Drawing.Size(234, 37)
        Me.seassionid.TabIndex = 208
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(10, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 15)
        Me.Label9.TabIndex = 206
        Me.Label9.Text = "Buat Nama SeassionID"
        '
        'rqQrcode
        '
        Me.rqQrcode.AutoSize = True
        Me.rqQrcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rqQrcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rqQrcode.ForeColor = System.Drawing.Color.White
        Me.rqQrcode.Location = New System.Drawing.Point(12, 12)
        Me.rqQrcode.Name = "rqQrcode"
        Me.rqQrcode.Size = New System.Drawing.Size(121, 24)
        Me.rqQrcode.TabIndex = 209
        Me.rqQrcode.TabStop = True
        Me.rqQrcode.Text = "Pakai Qrcode"
        Me.rqQrcode.UseVisualStyleBackColor = True
        '
        'RqRegCode
        '
        Me.RqRegCode.AutoSize = True
        Me.RqRegCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RqRegCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RqRegCode.ForeColor = System.Drawing.Color.White
        Me.RqRegCode.Location = New System.Drawing.Point(12, 42)
        Me.RqRegCode.Name = "RqRegCode"
        Me.RqRegCode.Size = New System.Drawing.Size(171, 24)
        Me.RqRegCode.TabIndex = 210
        Me.RqRegCode.TabStop = True
        Me.RqRegCode.Text = "Pakai Request Kode"
        Me.RqRegCode.UseVisualStyleBackColor = True
        '
        'naprovider
        '
        Me.naprovider.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.naprovider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.naprovider.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.naprovider.ForeColor = System.Drawing.Color.White
        Me.naprovider.FormattingEnabled = True
        Me.naprovider.Location = New System.Drawing.Point(14, 103)
        Me.naprovider.Name = "naprovider"
        Me.naprovider.Size = New System.Drawing.Size(233, 32)
        Me.naprovider.TabIndex = 211
        Me.naprovider.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 15)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Provider WhatsApp"
        '
        'WAScanQrForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(523, 228)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.naprovider)
        Me.Controls.Add(Me.RqRegCode)
        Me.Controls.Add(Me.rqQrcode)
        Me.Controls.Add(Me.CountWa)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnADD)
        Me.Controls.Add(Me.seassionid)
        Me.Controls.Add(Me.Label9)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WAScanQrForm"
        Me.Text = "WAScanQrForm"
        CType(Me.CountWa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CountWa As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents BtnADD As Button
    Friend WithEvents seassionid As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents rqQrcode As RadioButton
    Friend WithEvents RqRegCode As RadioButton
    Friend WithEvents naprovider As ComboBox
    Friend WithEvents Label1 As Label
End Class
