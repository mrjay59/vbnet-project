<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCformtext
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCformtext))
        Me.Lblname = New System.Windows.Forms.Label()
        Me.txtinput = New System.Windows.Forms.TextBox()
        Me.Btneyes = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Lblname
        '
        Me.Lblname.AutoSize = True
        Me.Lblname.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblname.ForeColor = System.Drawing.Color.White
        Me.Lblname.Location = New System.Drawing.Point(14, 7)
        Me.Lblname.Name = "Lblname"
        Me.Lblname.Size = New System.Drawing.Size(58, 16)
        Me.Lblname.TabIndex = 99
        Me.Lblname.Text = "Label Form"
        '
        'txtinput
        '
        Me.txtinput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtinput.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.txtinput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtinput.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinput.ForeColor = System.Drawing.Color.White
        Me.txtinput.Location = New System.Drawing.Point(12, 26)
        Me.txtinput.Name = "txtinput"
        Me.txtinput.ReadOnly = True
        Me.txtinput.Size = New System.Drawing.Size(226, 32)
        Me.txtinput.TabIndex = 98
        '
        'Btneyes
        '
        Me.Btneyes.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Btneyes.FlatAppearance.BorderSize = 0
        Me.Btneyes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btneyes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btneyes.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Btneyes.Image = CType(resources.GetObject("Btneyes.Image"), System.Drawing.Image)
        Me.Btneyes.Location = New System.Drawing.Point(210, 30)
        Me.Btneyes.Name = "Btneyes"
        Me.Btneyes.Size = New System.Drawing.Size(25, 25)
        Me.Btneyes.TabIndex = 100
        Me.Btneyes.UseVisualStyleBackColor = False
        Me.Btneyes.Visible = False
        '
        'UCformtext
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Btneyes)
        Me.Controls.Add(Me.Lblname)
        Me.Controls.Add(Me.txtinput)
        Me.Name = "UCformtext"
        Me.Size = New System.Drawing.Size(258, 62)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lblname As Label
    Friend WithEvents txtinput As TextBox
    Friend WithEvents Btneyes As Button
End Class
