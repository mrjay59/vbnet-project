<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PgKirim
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.PnStateBar = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Btn4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panelgb = New System.Windows.Forms.Panel()
        Me.Btn2 = New System.Windows.Forms.Button()
        Me.Btn1 = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.PanelPusat.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 194
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PanelPusat)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(943, 501)
        Me.Panel1.TabIndex = 224
        '
        'PanelPusat
        '
        Me.PanelPusat.Controls.Add(Me.PnStateBar)
        Me.PanelPusat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelPusat.Location = New System.Drawing.Point(0, 41)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(943, 460)
        Me.PanelPusat.TabIndex = 143
        '
        'PnStateBar
        '
        Me.PnStateBar.Location = New System.Drawing.Point(1, 2)
        Me.PnStateBar.Name = "PnStateBar"
        Me.PnStateBar.Size = New System.Drawing.Size(741, 5)
        Me.PnStateBar.TabIndex = 222
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.Btn4)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.Panelgb)
        Me.Panel3.Controls.Add(Me.Btn2)
        Me.Panel3.Controls.Add(Me.Btn1)
        Me.Panel3.Controls.Add(Me.btnclose)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(943, 41)
        Me.Panel3.TabIndex = 3
        '
        'Btn4
        '
        Me.Btn4.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Btn4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn4.FlatAppearance.BorderSize = 0
        Me.Btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn4.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Btn4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn4.Location = New System.Drawing.Point(321, 2)
        Me.Btn4.Name = "Btn4"
        Me.Btn4.Size = New System.Drawing.Size(100, 36)
        Me.Btn4.TabIndex = 236
        Me.Btn4.Text = "Email HTML"
        Me.Btn4.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(215, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 36)
        Me.Button1.TabIndex = 235
        Me.Button1.Text = "Spam WA"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panelgb
        '
        Me.Panelgb.BackColor = System.Drawing.Color.DarkOrange
        Me.Panelgb.Location = New System.Drawing.Point(505, 12)
        Me.Panelgb.Name = "Panelgb"
        Me.Panelgb.Size = New System.Drawing.Size(100, 2)
        Me.Panelgb.TabIndex = 234
        Me.Panelgb.Visible = False
        '
        'Btn2
        '
        Me.Btn2.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Btn2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn2.FlatAppearance.BorderSize = 0
        Me.Btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn2.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Btn2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn2.Location = New System.Drawing.Point(109, 2)
        Me.Btn2.Name = "Btn2"
        Me.Btn2.Size = New System.Drawing.Size(100, 36)
        Me.Btn2.TabIndex = 233
        Me.Btn2.Text = "Traning WA"
        Me.Btn2.UseVisualStyleBackColor = False
        '
        'Btn1
        '
        Me.Btn1.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Btn1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn1.FlatAppearance.BorderSize = 0
        Me.Btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn1.Font = New System.Drawing.Font("Malgun Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Btn1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn1.Location = New System.Drawing.Point(3, 2)
        Me.Btn1.Name = "Btn1"
        Me.Btn1.Size = New System.Drawing.Size(100, 36)
        Me.Btn1.TabIndex = 232
        Me.Btn1.Text = "Kirim Pesan"
        Me.Btn1.UseVisualStyleBackColor = False
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.Color.Gray
        Me.btnclose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnclose.FlatAppearance.BorderSize = 0
        Me.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.White
        Me.btnclose.Location = New System.Drawing.Point(901, 0)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(42, 41)
        Me.btnclose.TabIndex = 181
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'PgKirim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(943, 501)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PgKirim"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PgKirim"
        Me.Panel1.ResumeLayout(False)
        Me.PanelPusat.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelPusat As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnclose As Button
    Friend WithEvents PnStateBar As Panel
    Friend WithEvents Btn2 As Button
    Friend WithEvents Btn1 As Button
    Friend WithEvents Panelgb As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Btn4 As Button
End Class
