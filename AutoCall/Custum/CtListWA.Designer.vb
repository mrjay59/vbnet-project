<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtListWA
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
        Me.lbplatform = New System.Windows.Forms.Label()
        Me.lbDevice = New System.Windows.Forms.Label()
        Me.LbNomorWA = New System.Windows.Forms.Label()
        Me.LbLogin = New System.Windows.Forms.Label()
        Me.LbUse = New System.Windows.Forms.Label()
        Me.LbCon = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Chk
        '
        Me.Chk.AutoSize = True
        Me.Chk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Chk.Location = New System.Drawing.Point(8, 9)
        Me.Chk.Name = "Chk"
        Me.Chk.Size = New System.Drawing.Size(12, 11)
        Me.Chk.TabIndex = 184
        Me.Chk.UseVisualStyleBackColor = True
        '
        'lbplatform
        '
        Me.lbplatform.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbplatform.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbplatform.ForeColor = System.Drawing.Color.White
        Me.lbplatform.Location = New System.Drawing.Point(117, 2)
        Me.lbplatform.Name = "lbplatform"
        Me.lbplatform.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbplatform.Size = New System.Drawing.Size(92, 25)
        Me.lbplatform.TabIndex = 183
        Me.lbplatform.Text = "Nama Platform"
        Me.lbplatform.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbDevice
        '
        Me.lbDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbDevice.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDevice.ForeColor = System.Drawing.Color.White
        Me.lbDevice.Location = New System.Drawing.Point(25, 2)
        Me.lbDevice.Name = "lbDevice"
        Me.lbDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbDevice.Size = New System.Drawing.Size(86, 25)
        Me.lbDevice.TabIndex = 182
        Me.lbDevice.Text = "Nama Device"
        Me.lbDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbNomorWA
        '
        Me.LbNomorWA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.LbNomorWA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LbNomorWA.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbNomorWA.ForeColor = System.Drawing.Color.White
        Me.LbNomorWA.Location = New System.Drawing.Point(215, 1)
        Me.LbNomorWA.Name = "LbNomorWA"
        Me.LbNomorWA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LbNomorWA.Size = New System.Drawing.Size(112, 25)
        Me.LbNomorWA.TabIndex = 185
        Me.LbNomorWA.Text = "Nomor WhatsApp"
        Me.LbNomorWA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbLogin
        '
        Me.LbLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LbLogin.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbLogin.ForeColor = System.Drawing.Color.White
        Me.LbLogin.Location = New System.Drawing.Point(333, 2)
        Me.LbLogin.Name = "LbLogin"
        Me.LbLogin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LbLogin.Size = New System.Drawing.Size(70, 25)
        Me.LbLogin.TabIndex = 186
        Me.LbLogin.Text = "Login Y"
        Me.LbLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbUse
        '
        Me.LbUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LbUse.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbUse.ForeColor = System.Drawing.Color.White
        Me.LbUse.Location = New System.Drawing.Point(435, 2)
        Me.LbUse.Name = "LbUse"
        Me.LbUse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LbUse.Size = New System.Drawing.Size(75, 25)
        Me.LbUse.TabIndex = 187
        Me.LbUse.Text = "Use Y"
        Me.LbUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbCon
        '
        Me.LbCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LbCon.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCon.ForeColor = System.Drawing.Color.White
        Me.LbCon.Location = New System.Drawing.Point(516, 3)
        Me.LbCon.Name = "LbCon"
        Me.LbCon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LbCon.Size = New System.Drawing.Size(94, 25)
        Me.LbCon.TabIndex = 189
        Me.LbCon.Text = "Connect"
        Me.LbCon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CtListWA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Controls.Add(Me.LbCon)
        Me.Controls.Add(Me.LbUse)
        Me.Controls.Add(Me.LbLogin)
        Me.Controls.Add(Me.LbNomorWA)
        Me.Controls.Add(Me.Chk)
        Me.Controls.Add(Me.lbplatform)
        Me.Controls.Add(Me.lbDevice)
        Me.Name = "CtListWA"
        Me.Size = New System.Drawing.Size(612, 30)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chk As CheckBox
    Friend WithEvents lbplatform As Label
    Friend WithEvents lbDevice As Label
    Friend WithEvents LbNomorWA As Label
    Friend WithEvents LbLogin As Label
    Friend WithEvents LbUse As Label
    Friend WithEvents LbCon As Label
End Class
