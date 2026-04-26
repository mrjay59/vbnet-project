<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PgCAtur
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panelgb = New System.Windows.Forms.Panel()
        Me.Btn2 = New System.Windows.Forms.Button()
        Me.Btn1 = New System.Windows.Forms.Button()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.Panelgb)
        Me.Panel3.Controls.Add(Me.Btn2)
        Me.Panel3.Controls.Add(Me.Btn1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1040, 41)
        Me.Panel3.TabIndex = 4
        '
        'Panelgb
        '
        Me.Panelgb.BackColor = System.Drawing.Color.DarkOrange
        Me.Panelgb.Location = New System.Drawing.Point(376, 12)
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
        Me.Btn2.Text = "Manual Call"
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
        Me.Btn1.Text = "Multi Call"
        Me.Btn1.UseVisualStyleBackColor = False
        '
        'PanelPusat
        '
        Me.PanelPusat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelPusat.Location = New System.Drawing.Point(0, 41)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(1040, 602)
        Me.PanelPusat.TabIndex = 5
        '
        'PgCAtur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1040, 643)
        Me.Controls.Add(Me.PanelPusat)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PgCAtur"
        Me.Text = "PgCAtur"
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panelgb As Panel
    Friend WithEvents Btn2 As Button
    Friend WithEvents Btn1 As Button
    Friend WithEvents PanelPusat As Panel
End Class
