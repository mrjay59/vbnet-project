<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChatUser
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
        Me.idUser = New System.Windows.Forms.Label()
        Me.ImgUser = New System.Windows.Forms.PictureBox()
        Me.LblTime = New System.Windows.Forms.Label()
        Me.Lblfrom = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LblMsg = New System.Windows.Forms.Label()
        CType(Me.ImgUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'idUser
        '
        Me.idUser.AutoSize = True
        Me.idUser.BackColor = System.Drawing.Color.Transparent
        Me.idUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.idUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.idUser.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idUser.ForeColor = System.Drawing.Color.White
        Me.idUser.Location = New System.Drawing.Point(61, 5)
        Me.idUser.Name = "idUser"
        Me.idUser.Size = New System.Drawing.Size(134, 23)
        Me.idUser.TabIndex = 4
        Me.idUser.Text = "081-0555-5556"
        Me.idUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImgUser
        '
        Me.ImgUser.Location = New System.Drawing.Point(5, 9)
        Me.ImgUser.Name = "ImgUser"
        Me.ImgUser.Size = New System.Drawing.Size(50, 50)
        Me.ImgUser.TabIndex = 5
        Me.ImgUser.TabStop = False
        '
        'LblTime
        '
        Me.LblTime.AutoSize = True
        Me.LblTime.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTime.Location = New System.Drawing.Point(243, 63)
        Me.LblTime.Name = "LblTime"
        Me.LblTime.Size = New System.Drawing.Size(34, 13)
        Me.LblTime.TabIndex = 6
        Me.LblTime.Text = "08:00"
        '
        'Lblfrom
        '
        Me.Lblfrom.AutoSize = True
        Me.Lblfrom.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Lblfrom.Location = New System.Drawing.Point(3, 63)
        Me.Lblfrom.Name = "Lblfrom"
        Me.Lblfrom.Size = New System.Drawing.Size(101, 13)
        Me.Lblfrom.TabIndex = 7
        Me.Lblfrom.Text = "Sumber: WA Server"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.LblMsg)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(61, 28)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(214, 32)
        Me.FlowLayoutPanel1.TabIndex = 8
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("Cambria", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FloralWhite
        Me.LblMsg.Location = New System.Drawing.Point(3, 0)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(30, 11)
        Me.LblMsg.TabIndex = 0
        Me.LblMsg.Text = "Label2"
        '
        'ChatUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Controls.Add(Me.Lblfrom)
        Me.Controls.Add(Me.LblTime)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.ImgUser)
        Me.Controls.Add(Me.idUser)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "ChatUser"
        Me.Size = New System.Drawing.Size(280, 79)
        CType(Me.ImgUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents idUser As Label
    Friend WithEvents ImgUser As PictureBox
    Friend WithEvents LblTime As Label
    Friend WithEvents Lblfrom As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents LblMsg As Label
End Class
