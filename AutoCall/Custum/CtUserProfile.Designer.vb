<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtUserProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtUserProfile))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lblname = New System.Windows.Forms.Label()
        Me.BtnStat = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(224, 2)
        Me.Panel1.TabIndex = 0
        '
        'Lblname
        '
        Me.Lblname.AutoSize = True
        Me.Lblname.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblname.ForeColor = System.Drawing.Color.White
        Me.Lblname.Location = New System.Drawing.Point(26, 5)
        Me.Lblname.Name = "Lblname"
        Me.Lblname.Size = New System.Drawing.Size(79, 19)
        Me.Lblname.TabIndex = 191
        Me.Lblname.Text = "Token Exp :"
        Me.Lblname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnStat
        '
        Me.BtnStat.BackColor = System.Drawing.Color.Transparent
        Me.BtnStat.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnStat.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnStat.FlatAppearance.BorderSize = 0
        Me.BtnStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStat.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStat.ForeColor = System.Drawing.Color.Black
        Me.BtnStat.Image = CType(resources.GetObject("BtnStat.Image"), System.Drawing.Image)
        Me.BtnStat.Location = New System.Drawing.Point(0, 0)
        Me.BtnStat.Name = "BtnStat"
        Me.BtnStat.Size = New System.Drawing.Size(20, 30)
        Me.BtnStat.TabIndex = 192
        Me.BtnStat.Tag = "next"
        Me.BtnStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStat.UseVisualStyleBackColor = False
        '
        'CtUserProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Controls.Add(Me.BtnStat)
        Me.Controls.Add(Me.Lblname)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CtUserProfile"
        Me.Size = New System.Drawing.Size(224, 30)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Lblname As Label
    Friend WithEvents BtnStat As Button
End Class
