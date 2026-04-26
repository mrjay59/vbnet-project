<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtListSeOrCall
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
        Me.Chk = New System.Windows.Forms.CheckBox()
        Me.lbpath = New System.Windows.Forms.Label()
        Me.lbSeOrCa = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Chk
        '
        Me.Chk.AutoSize = True
        Me.Chk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Chk.Location = New System.Drawing.Point(7, 9)
        Me.Chk.Name = "Chk"
        Me.Chk.Size = New System.Drawing.Size(12, 11)
        Me.Chk.TabIndex = 177
        Me.Chk.UseVisualStyleBackColor = True
        '
        'lbpath
        '
        Me.lbpath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbpath.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbpath.ForeColor = System.Drawing.Color.White
        Me.lbpath.Location = New System.Drawing.Point(102, 2)
        Me.lbpath.Name = "lbpath"
        Me.lbpath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbpath.Size = New System.Drawing.Size(212, 25)
        Me.lbpath.TabIndex = 176
        Me.lbpath.Text = "Path"
        Me.lbpath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbSeOrCa
        '
        Me.lbSeOrCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbSeOrCa.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSeOrCa.ForeColor = System.Drawing.Color.White
        Me.lbSeOrCa.Location = New System.Drawing.Point(21, 2)
        Me.lbSeOrCa.Name = "lbSeOrCa"
        Me.lbSeOrCa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbSeOrCa.Size = New System.Drawing.Size(75, 25)
        Me.lbSeOrCa.TabIndex = 175
        Me.lbSeOrCa.Text = "Nama"
        Me.lbSeOrCa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CtListSeOrCall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Controls.Add(Me.Chk)
        Me.Controls.Add(Me.lbpath)
        Me.Controls.Add(Me.lbSeOrCa)
        Me.Name = "CtListSeOrCall"
        Me.Size = New System.Drawing.Size(314, 31)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chk As CheckBox
    Friend WithEvents lbpath As Label
    Friend WithEvents lbSeOrCa As Label
End Class
