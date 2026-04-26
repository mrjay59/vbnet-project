<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PgChPassword
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
        Me.btnclose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnChPass = New System.Windows.Forms.Button()
        Me.UCformtext3 = New AutoCall.UCformtext()
        Me.UCformtext2 = New AutoCall.UCformtext()
        Me.UCformtext1 = New AutoCall.UCformtext()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btnclose.Location = New System.Drawing.Point(203, 0)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(50, 45)
        Me.btnclose.TabIndex = 140
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(253, 45)
        Me.Panel1.TabIndex = 142
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Bodoni MT Condensed", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 45)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Update Password"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnChPass
        '
        Me.BtnChPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnChPass.FlatAppearance.BorderSize = 0
        Me.BtnChPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnChPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChPass.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnChPass.Location = New System.Drawing.Point(128, 256)
        Me.BtnChPass.Name = "BtnChPass"
        Me.BtnChPass.Size = New System.Drawing.Size(111, 44)
        Me.BtnChPass.TabIndex = 146
        Me.BtnChPass.Text = "Ganti Password"
        Me.BtnChPass.UseVisualStyleBackColor = False
        '
        'UCformtext3
        '
        Me.UCformtext3.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext3.Location = New System.Drawing.Point(0, 188)
        Me.UCformtext3.Name = "UCformtext3"
        Me.UCformtext3.Size = New System.Drawing.Size(258, 62)
        Me.UCformtext3.TabIndex = 145
        '
        'UCformtext2
        '
        Me.UCformtext2.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext2.Location = New System.Drawing.Point(0, 120)
        Me.UCformtext2.Name = "UCformtext2"
        Me.UCformtext2.Size = New System.Drawing.Size(258, 62)
        Me.UCformtext2.TabIndex = 144
        '
        'UCformtext1
        '
        Me.UCformtext1.BackColor = System.Drawing.Color.Transparent
        Me.UCformtext1.Location = New System.Drawing.Point(0, 52)
        Me.UCformtext1.Name = "UCformtext1"
        Me.UCformtext1.Size = New System.Drawing.Size(258, 62)
        Me.UCformtext1.TabIndex = 143
        '
        'PgChPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(253, 312)
        Me.Controls.Add(Me.BtnChPass)
        Me.Controls.Add(Me.UCformtext3)
        Me.Controls.Add(Me.UCformtext2)
        Me.Controls.Add(Me.UCformtext1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PgChPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PgChPassword"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnclose As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnChPass As Button
    Friend WithEvents UCformtext3 As UCformtext
    Friend WithEvents UCformtext2 As UCformtext
    Friend WithEvents UCformtext1 As UCformtext
End Class
