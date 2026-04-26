<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserButton
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LbCount = New System.Windows.Forms.Label()
        Me.lbtitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(6, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'LbCount
        '
        Me.LbCount.AutoSize = True
        Me.LbCount.BackColor = System.Drawing.Color.MediumTurquoise
        Me.LbCount.Dock = System.Windows.Forms.DockStyle.Right
        Me.LbCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCount.Location = New System.Drawing.Point(116, 0)
        Me.LbCount.Name = "LbCount"
        Me.LbCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LbCount.Size = New System.Drawing.Size(27, 20)
        Me.LbCount.TabIndex = 1
        Me.LbCount.Text = "10"
        Me.LbCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbtitle
        '
        Me.lbtitle.AutoSize = True
        Me.lbtitle.Font = New System.Drawing.Font("Malgun Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtitle.ForeColor = System.Drawing.Color.White
        Me.lbtitle.Location = New System.Drawing.Point(71, 21)
        Me.lbtitle.Name = "lbtitle"
        Me.lbtitle.Size = New System.Drawing.Size(61, 32)
        Me.lbtitle.TabIndex = 2
        Me.lbtitle.Text = "Title"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LbCount)
        Me.Panel1.Location = New System.Drawing.Point(71, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(143, 20)
        Me.Panel1.TabIndex = 3
        '
        'UserButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbtitle)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "UserButton"
        Me.Size = New System.Drawing.Size(218, 78)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LbCount As Label
    Friend WithEvents lbtitle As Label
    Friend WithEvents Panel1 As Panel
End Class
