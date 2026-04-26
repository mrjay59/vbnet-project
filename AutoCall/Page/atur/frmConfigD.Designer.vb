<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigD
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.lbltext = New System.Windows.Forms.Label()
        Me.DAkunSIP = New AutoCall.UCformtext()
        Me.DDomainSIP = New AutoCall.UCformtext()
        Me.DServerSIP = New AutoCall.UCformtext()
        Me.DUserSIP = New AutoCall.UCformtext()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Controls.Add(Me.lbltext)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(498, 45)
        Me.Panel1.TabIndex = 142
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
        Me.btnclose.Location = New System.Drawing.Point(448, 0)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(50, 45)
        Me.btnclose.TabIndex = 140
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'lbltext
        '
        Me.lbltext.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltext.ForeColor = System.Drawing.Color.White
        Me.lbltext.Location = New System.Drawing.Point(3, 9)
        Me.lbltext.Name = "lbltext"
        Me.lbltext.Size = New System.Drawing.Size(267, 30)
        Me.lbltext.TabIndex = 139
        Me.lbltext.Text = "Config Akun"
        '
        'DAkunSIP
        '
        Me.DAkunSIP.BackColor = System.Drawing.Color.Transparent
        Me.DAkunSIP.Location = New System.Drawing.Point(7, 67)
        Me.DAkunSIP.Name = "DAkunSIP"
        Me.DAkunSIP.Size = New System.Drawing.Size(200, 62)
        Me.DAkunSIP.TabIndex = 143
        '
        'DDomainSIP
        '
        Me.DDomainSIP.BackColor = System.Drawing.Color.Transparent
        Me.DDomainSIP.Location = New System.Drawing.Point(203, 67)
        Me.DDomainSIP.Name = "DDomainSIP"
        Me.DDomainSIP.Size = New System.Drawing.Size(283, 62)
        Me.DDomainSIP.TabIndex = 144
        '
        'DServerSIP
        '
        Me.DServerSIP.BackColor = System.Drawing.Color.Transparent
        Me.DServerSIP.Location = New System.Drawing.Point(203, 135)
        Me.DServerSIP.Name = "DServerSIP"
        Me.DServerSIP.Size = New System.Drawing.Size(283, 62)
        Me.DServerSIP.TabIndex = 145
        '
        'DUserSIP
        '
        Me.DUserSIP.BackColor = System.Drawing.Color.Transparent
        Me.DUserSIP.Location = New System.Drawing.Point(7, 135)
        Me.DUserSIP.Name = "DUserSIP"
        Me.DUserSIP.Size = New System.Drawing.Size(200, 62)
        Me.DUserSIP.TabIndex = 146
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSave.Location = New System.Drawing.Point(316, 5)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(111, 36)
        Me.BtnSave.TabIndex = 148
        Me.BtnSave.Text = "Save Setting"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'frmConfigD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(498, 219)
        Me.Controls.Add(Me.DUserSIP)
        Me.Controls.Add(Me.DServerSIP)
        Me.Controls.Add(Me.DDomainSIP)
        Me.Controls.Add(Me.DAkunSIP)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmConfigD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmConfigD"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnclose As Button
    Friend WithEvents lbltext As Label
    Friend WithEvents DAkunSIP As UCformtext
    Friend WithEvents DDomainSIP As UCformtext
    Friend WithEvents DServerSIP As UCformtext
    Friend WithEvents DUserSIP As UCformtext
    Friend WithEvents BtnSave As Button
End Class
