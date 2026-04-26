<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCScanQR
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
        Me.PnlogActivty = New System.Windows.Forms.Panel()
        Me.LblR = New System.Windows.Forms.Label()
        Me.picQRCode = New System.Windows.Forms.PictureBox()
        Me.lstLog = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.LbWAnm = New System.Windows.Forms.Label()
        Me.PnlogActivty.SuspendLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlogActivty
        '
        Me.PnlogActivty.AutoScroll = True
        Me.PnlogActivty.Controls.Add(Me.LblR)
        Me.PnlogActivty.Controls.Add(Me.picQRCode)
        Me.PnlogActivty.Controls.Add(Me.lstLog)
        Me.PnlogActivty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlogActivty.Location = New System.Drawing.Point(0, 35)
        Me.PnlogActivty.Name = "PnlogActivty"
        Me.PnlogActivty.Size = New System.Drawing.Size(425, 211)
        Me.PnlogActivty.TabIndex = 145
        '
        'LblR
        '
        Me.LblR.BackColor = System.Drawing.Color.Transparent
        Me.LblR.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblR.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblR.ForeColor = System.Drawing.Color.White
        Me.LblR.Location = New System.Drawing.Point(12, 55)
        Me.LblR.Name = "LblR"
        Me.LblR.Size = New System.Drawing.Size(191, 86)
        Me.LblR.TabIndex = 178
        Me.LblR.Text = "Ready"
        Me.LblR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblR.Visible = False
        '
        'picQRCode
        '
        Me.picQRCode.Location = New System.Drawing.Point(10, 6)
        Me.picQRCode.Name = "picQRCode"
        Me.picQRCode.Size = New System.Drawing.Size(195, 195)
        Me.picQRCode.TabIndex = 177
        Me.picQRCode.TabStop = False
        '
        'lstLog
        '
        Me.lstLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstLog.Dock = System.Windows.Forms.DockStyle.Right
        Me.lstLog.Font = New System.Drawing.Font("Microsoft New Tai Lue", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLog.ForeColor = System.Drawing.Color.White
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.ItemHeight = 15
        Me.lstLog.Location = New System.Drawing.Point(216, 0)
        Me.lstLog.Margin = New System.Windows.Forms.Padding(10)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(209, 211)
        Me.lstLog.TabIndex = 175
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(213, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 16)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "Log "
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.LbWAnm)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(425, 35)
        Me.Panel5.TabIndex = 144
        '
        'LbWAnm
        '
        Me.LbWAnm.AutoSize = True
        Me.LbWAnm.BackColor = System.Drawing.Color.Transparent
        Me.LbWAnm.Cursor = System.Windows.Forms.Cursors.Default
        Me.LbWAnm.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbWAnm.ForeColor = System.Drawing.Color.White
        Me.LbWAnm.Location = New System.Drawing.Point(7, 7)
        Me.LbWAnm.Name = "LbWAnm"
        Me.LbWAnm.Size = New System.Drawing.Size(65, 16)
        Me.LbWAnm.TabIndex = 3
        Me.LbWAnm.Text = "WA NAME"
        Me.LbWAnm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UCScanQR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Controls.Add(Me.PnlogActivty)
        Me.Controls.Add(Me.Panel5)
        Me.Name = "UCScanQR"
        Me.Size = New System.Drawing.Size(425, 246)
        Me.PnlogActivty.ResumeLayout(False)
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PnlogActivty As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LbWAnm As Label
    Friend WithEvents picQRCode As PictureBox
    Friend WithEvents Label2 As Label
    Public WithEvents lstLog As ListBox
    Friend WithEvents LblR As Label
End Class
