<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formfuncwa
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
        Me.rd1 = New System.Windows.Forms.RadioButton()
        Me.rd0 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComApk = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComDev = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Number = New System.Windows.Forms.RadioButton()
        Me.QRcode = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Code = New System.Windows.Forms.RadioButton()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.ForeColor = System.Drawing.Color.White
        Me.rd1.Location = New System.Drawing.Point(70, 210)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(43, 17)
        Me.rd1.TabIndex = 149
        Me.rd1.TabStop = True
        Me.rd1.Text = "true"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'rd0
        '
        Me.rd0.AutoSize = True
        Me.rd0.ForeColor = System.Drawing.Color.White
        Me.rd0.Location = New System.Drawing.Point(17, 210)
        Me.rd0.Name = "rd0"
        Me.rd0.Size = New System.Drawing.Size(47, 17)
        Me.rd0.TabIndex = 148
        Me.rd0.TabStop = True
        Me.rd0.Text = "false"
        Me.rd0.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(14, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 16)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "Dual Apps"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(14, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "WhatsApps :"
        '
        'ComApk
        '
        Me.ComApk.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ComApk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComApk.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComApk.ForeColor = System.Drawing.Color.White
        Me.ComApk.FormattingEnabled = True
        Me.ComApk.Location = New System.Drawing.Point(12, 142)
        Me.ComApk.Name = "ComApk"
        Me.ComApk.Size = New System.Drawing.Size(185, 28)
        Me.ComApk.TabIndex = 145
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(14, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = "Device :"
        '
        'ComDev
        '
        Me.ComDev.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ComDev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComDev.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComDev.ForeColor = System.Drawing.Color.White
        Me.ComDev.FormattingEnabled = True
        Me.ComDev.Location = New System.Drawing.Point(12, 76)
        Me.ComDev.Name = "ComDev"
        Me.ComDev.Size = New System.Drawing.Size(185, 28)
        Me.ComDev.TabIndex = 143
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(13, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(239, 30)
        Me.Label7.TabIndex = 150
        Me.Label7.Text = "Fitur Whatsapp Lain"
        '
        'Number
        '
        Me.Number.AutoSize = True
        Me.Number.ForeColor = System.Drawing.Color.White
        Me.Number.Location = New System.Drawing.Point(303, 86)
        Me.Number.Name = "Number"
        Me.Number.Size = New System.Drawing.Size(62, 17)
        Me.Number.TabIndex = 153
        Me.Number.TabStop = True
        Me.Number.Text = "Number"
        Me.Number.UseVisualStyleBackColor = True
        '
        'QRcode
        '
        Me.QRcode.AutoSize = True
        Me.QRcode.ForeColor = System.Drawing.Color.White
        Me.QRcode.Location = New System.Drawing.Point(231, 86)
        Me.QRcode.Name = "QRcode"
        Me.QRcode.Size = New System.Drawing.Size(66, 17)
        Me.QRcode.TabIndex = 152
        Me.QRcode.TabStop = True
        Me.QRcode.Text = "QRCode"
        Me.QRcode.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(224, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 16)
        Me.Label3.TabIndex = 151
        Me.Label3.Text = "Metode Login Or Recovery"
        '
        'Code
        '
        Me.Code.AutoSize = True
        Me.Code.ForeColor = System.Drawing.Color.White
        Me.Code.Location = New System.Drawing.Point(371, 86)
        Me.Code.Name = "Code"
        Me.Code.Size = New System.Drawing.Size(50, 17)
        Me.Code.TabIndex = 154
        Me.Code.TabStop = True
        Me.Code.Text = "Code"
        Me.Code.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSave.Location = New System.Drawing.Point(293, 8)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(128, 30)
        Me.BtnSave.TabIndex = 155
        Me.BtnSave.Text = "Eksekusi"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'formfuncwa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(818, 282)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Code)
        Me.Controls.Add(Me.Number)
        Me.Controls.Add(Me.QRcode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.rd1)
        Me.Controls.Add(Me.rd0)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComApk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComDev)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "formfuncwa"
        Me.Text = "formfuncwa"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rd1 As RadioButton
    Friend WithEvents rd0 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComApk As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ComDev As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Number As RadioButton
    Friend WithEvents QRcode As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Code As RadioButton
    Friend WithEvents BtnSave As Button
End Class
