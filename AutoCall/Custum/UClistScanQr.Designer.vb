<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UClistScanQr
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LbNo = New System.Windows.Forms.Label()
        Me.LblSeassionId = New System.Windows.Forms.Label()
        Me.BtnLOut = New System.Windows.Forms.Button()
        Me.Btnstt = New System.Windows.Forms.Button()
        Me.PnState = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AturToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HapusHistoryPesanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LbNo
        '
        Me.LbNo.AutoSize = True
        Me.LbNo.Font = New System.Drawing.Font("Segoe UI Symbol", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbNo.ForeColor = System.Drawing.Color.White
        Me.LbNo.Location = New System.Drawing.Point(3, 8)
        Me.LbNo.Name = "LbNo"
        Me.LbNo.Size = New System.Drawing.Size(28, 17)
        Me.LbNo.TabIndex = 0
        Me.LbNo.Text = "No"
        '
        'LblSeassionId
        '
        Me.LblSeassionId.Font = New System.Drawing.Font("Segoe UI Symbol", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeassionId.ForeColor = System.Drawing.Color.White
        Me.LblSeassionId.Location = New System.Drawing.Point(42, 0)
        Me.LblSeassionId.Name = "LblSeassionId"
        Me.LblSeassionId.Size = New System.Drawing.Size(220, 32)
        Me.LblSeassionId.TabIndex = 1
        Me.LblSeassionId.Text = "BotValid"
        Me.LblSeassionId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnLOut
        '
        Me.BtnLOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnLOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLOut.FlatAppearance.BorderSize = 0
        Me.BtnLOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLOut.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnLOut.Location = New System.Drawing.Point(366, 6)
        Me.BtnLOut.Name = "BtnLOut"
        Me.BtnLOut.Size = New System.Drawing.Size(62, 25)
        Me.BtnLOut.TabIndex = 164
        Me.BtnLOut.Text = "LogOut"
        Me.BtnLOut.UseVisualStyleBackColor = False
        '
        'Btnstt
        '
        Me.Btnstt.BackColor = System.Drawing.Color.White
        Me.Btnstt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnstt.FlatAppearance.BorderSize = 0
        Me.Btnstt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnstt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnstt.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Btnstt.Location = New System.Drawing.Point(268, 6)
        Me.Btnstt.Name = "Btnstt"
        Me.Btnstt.Size = New System.Drawing.Size(92, 25)
        Me.Btnstt.TabIndex = 163
        Me.Btnstt.Text = "Start Service"
        Me.Btnstt.UseVisualStyleBackColor = False
        '
        'PnState
        '
        Me.PnState.BackColor = System.Drawing.Color.Linen
        Me.PnState.ForeColor = System.Drawing.Color.Transparent
        Me.PnState.Location = New System.Drawing.Point(1, 34)
        Me.PnState.Name = "PnState"
        Me.PnState.Size = New System.Drawing.Size(441, 3)
        Me.PnState.TabIndex = 165
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AturToolStripMenuItem, Me.HapusHistoryPesanToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(184, 70)
        '
        'AturToolStripMenuItem
        '
        Me.AturToolStripMenuItem.Name = "AturToolStripMenuItem"
        Me.AturToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.AturToolStripMenuItem.Text = "Setting Session"
        '
        'HapusHistoryPesanToolStripMenuItem
        '
        Me.HapusHistoryPesanToolStripMenuItem.Name = "HapusHistoryPesanToolStripMenuItem"
        Me.HapusHistoryPesanToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.HapusHistoryPesanToolStripMenuItem.Text = "Hapus History Pesan"
        '
        'UClistScanQr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Controls.Add(Me.PnState)
        Me.Controls.Add(Me.BtnLOut)
        Me.Controls.Add(Me.Btnstt)
        Me.Controls.Add(Me.LblSeassionId)
        Me.Controls.Add(Me.LbNo)
        Me.Name = "UClistScanQr"
        Me.Size = New System.Drawing.Size(434, 40)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LbNo As Label
    Friend WithEvents LblSeassionId As Label
    Friend WithEvents BtnLOut As Button
    Friend WithEvents Btnstt As Button
    Friend WithEvents PnState As Panel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AturToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HapusHistoryPesanToolStripMenuItem As ToolStripMenuItem
End Class
