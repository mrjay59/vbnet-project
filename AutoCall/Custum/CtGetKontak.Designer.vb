<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtGetKontak
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtGetKontak))
        Me.BtnDel = New System.Windows.Forms.Button()
        Me.Chk = New System.Windows.Forms.CheckBox()
        Me.lbuserkont = New System.Windows.Forms.Label()
        Me.lbKontak = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnDel
        '
        Me.BtnDel.BackColor = System.Drawing.Color.Transparent
        Me.BtnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDel.FlatAppearance.BorderSize = 0
        Me.BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDel.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(272, 4)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(25, 25)
        Me.BtnDel.TabIndex = 182
        Me.BtnDel.UseVisualStyleBackColor = False
        '
        'Chk
        '
        Me.Chk.AutoSize = True
        Me.Chk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Chk.Location = New System.Drawing.Point(5, 11)
        Me.Chk.Name = "Chk"
        Me.Chk.Size = New System.Drawing.Size(12, 11)
        Me.Chk.TabIndex = 181
        Me.Chk.UseVisualStyleBackColor = True
        '
        'lbuserkont
        '
        Me.lbuserkont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbuserkont.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbuserkont.ForeColor = System.Drawing.Color.White
        Me.lbuserkont.Location = New System.Drawing.Point(119, 5)
        Me.lbuserkont.Name = "lbuserkont"
        Me.lbuserkont.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbuserkont.Size = New System.Drawing.Size(153, 25)
        Me.lbuserkont.TabIndex = 180
        Me.lbuserkont.Text = "Nama Lengkap"
        Me.lbuserkont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbKontak
        '
        Me.lbKontak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbKontak.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbKontak.ForeColor = System.Drawing.Color.White
        Me.lbKontak.Location = New System.Drawing.Point(19, 4)
        Me.lbKontak.Name = "lbKontak"
        Me.lbKontak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbKontak.Size = New System.Drawing.Size(96, 25)
        Me.lbKontak.TabIndex = 179
        Me.lbKontak.Text = "Nomer Hp"
        Me.lbKontak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CtGetKontak
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Controls.Add(Me.BtnDel)
        Me.Controls.Add(Me.Chk)
        Me.Controls.Add(Me.lbuserkont)
        Me.Controls.Add(Me.lbKontak)
        Me.Name = "CtGetKontak"
        Me.Size = New System.Drawing.Size(302, 35)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnDel As Button
    Friend WithEvents Chk As CheckBox
    Friend WithEvents lbuserkont As Label
    Friend WithEvents lbKontak As Label
End Class
