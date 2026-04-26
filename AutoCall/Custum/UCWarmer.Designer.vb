<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCWarmer
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Tema = New System.Windows.Forms.ComboBox()
        Me.CmNumber2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmNumber1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Tema
        '
        Me.Tema.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Tema.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Tema.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tema.ForeColor = System.Drawing.Color.White
        Me.Tema.FormattingEnabled = True
        Me.Tema.Location = New System.Drawing.Point(281, 28)
        Me.Tema.Name = "Tema"
        Me.Tema.Size = New System.Drawing.Size(194, 26)
        Me.Tema.TabIndex = 235
        '
        'CmNumber2
        '
        Me.CmNumber2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.CmNumber2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmNumber2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmNumber2.ForeColor = System.Drawing.Color.White
        Me.CmNumber2.FormattingEnabled = True
        Me.CmNumber2.Location = New System.Drawing.Point(146, 28)
        Me.CmNumber2.Name = "CmNumber2"
        Me.CmNumber2.Size = New System.Drawing.Size(129, 26)
        Me.CmNumber2.TabIndex = 233
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(278, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 16)
        Me.Label2.TabIndex = 236
        Me.Label2.Text = "Tema Percakapan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(143, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 234
        Me.Label1.Text = "Penerima :"
        '
        'CmNumber1
        '
        Me.CmNumber1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.CmNumber1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmNumber1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmNumber1.ForeColor = System.Drawing.Color.White
        Me.CmNumber1.FormattingEnabled = True
        Me.CmNumber1.Location = New System.Drawing.Point(12, 28)
        Me.CmNumber1.Name = "CmNumber1"
        Me.CmNumber1.Size = New System.Drawing.Size(128, 26)
        Me.CmNumber1.TabIndex = 231
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 232
        Me.Label4.Text = "Pengirim :"
        '
        'UCWarmer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Controls.Add(Me.Tema)
        Me.Controls.Add(Me.CmNumber2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmNumber1)
        Me.Controls.Add(Me.Label4)
        Me.Name = "UCWarmer"
        Me.Size = New System.Drawing.Size(478, 70)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Tema As ComboBox
    Friend WithEvents CmNumber2 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CmNumber1 As ComboBox
    Friend WithEvents Label4 As Label
End Class
