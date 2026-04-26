<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCDeviceUse
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCDeviceUse))
        Me.BtnStat = New System.Windows.Forms.Button()
        Me.lburut = New System.Windows.Forms.Label()
        Me.lbname = New System.Windows.Forms.Label()
        Me.lbstatus = New System.Windows.Forms.Label()
        Me.KlikAnan = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BtnStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnNext = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnVlog = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMirrorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnState = New System.Windows.Forms.Panel()
        Me.KlikAnan.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnStat
        '
        Me.BtnStat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnStat.BackColor = System.Drawing.Color.Transparent
        Me.BtnStat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStat.FlatAppearance.BorderSize = 0
        Me.BtnStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStat.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStat.ForeColor = System.Drawing.Color.Black
        Me.BtnStat.Image = CType(resources.GetObject("BtnStat.Image"), System.Drawing.Image)
        Me.BtnStat.Location = New System.Drawing.Point(468, 0)
        Me.BtnStat.Name = "BtnStat"
        Me.BtnStat.Size = New System.Drawing.Size(33, 30)
        Me.BtnStat.TabIndex = 131
        Me.BtnStat.Tag = "next"
        Me.BtnStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStat.UseVisualStyleBackColor = False
        Me.BtnStat.Visible = False
        '
        'lburut
        '
        Me.lburut.Dock = System.Windows.Forms.DockStyle.Left
        Me.lburut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lburut.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lburut.ForeColor = System.Drawing.Color.White
        Me.lburut.Location = New System.Drawing.Point(0, 0)
        Me.lburut.Name = "lburut"
        Me.lburut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lburut.Size = New System.Drawing.Size(20, 30)
        Me.lburut.TabIndex = 132
        Me.lburut.Text = "1"
        Me.lburut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbname
        '
        Me.lbname.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbname.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbname.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbname.ForeColor = System.Drawing.Color.White
        Me.lbname.Location = New System.Drawing.Point(27, -1)
        Me.lbname.Name = "lbname"
        Me.lbname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbname.Size = New System.Drawing.Size(140, 30)
        Me.lbname.TabIndex = 133
        Me.lbname.Text = " Device Name"
        Me.lbname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbstatus
        '
        Me.lbstatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbstatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbstatus.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbstatus.ForeColor = System.Drawing.Color.White
        Me.lbstatus.Location = New System.Drawing.Point(181, 0)
        Me.lbstatus.Name = "lbstatus"
        Me.lbstatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbstatus.Size = New System.Drawing.Size(281, 30)
        Me.lbstatus.TabIndex = 134
        Me.lbstatus.Text = "Keterangan"
        Me.lbstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KlikAnan
        '
        Me.KlikAnan.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.KlikAnan.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KlikAnan.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnStop, Me.BtnNext, Me.btnVlog, Me.OpenMirrorToolStripMenuItem})
        Me.KlikAnan.Name = "KlikAnan"
        Me.KlikAnan.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.KlikAnan.ShowImageMargin = False
        Me.KlikAnan.Size = New System.Drawing.Size(142, 100)
        '
        'BtnStop
        '
        Me.BtnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStop.ForeColor = System.Drawing.Color.White
        Me.BtnStop.Image = CType(resources.GetObject("BtnStop.Image"), System.Drawing.Image)
        Me.BtnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(141, 24)
        Me.BtnStop.Text = "Stop Service"
        '
        'BtnNext
        '
        Me.BtnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNext.ForeColor = System.Drawing.Color.White
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), System.Drawing.Image)
        Me.BtnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(141, 24)
        Me.BtnNext.Text = "Next Data"
        '
        'btnVlog
        '
        Me.btnVlog.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVlog.ForeColor = System.Drawing.Color.White
        Me.btnVlog.Image = CType(resources.GetObject("btnVlog.Image"), System.Drawing.Image)
        Me.btnVlog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnVlog.Name = "btnVlog"
        Me.btnVlog.Size = New System.Drawing.Size(141, 24)
        Me.btnVlog.Text = "ViewLog"
        '
        'OpenMirrorToolStripMenuItem
        '
        Me.OpenMirrorToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenMirrorToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.OpenMirrorToolStripMenuItem.Image = CType(resources.GetObject("OpenMirrorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenMirrorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OpenMirrorToolStripMenuItem.Name = "OpenMirrorToolStripMenuItem"
        Me.OpenMirrorToolStripMenuItem.Size = New System.Drawing.Size(141, 24)
        Me.OpenMirrorToolStripMenuItem.Text = "Open Mirror"
        '
        'PnState
        '
        Me.PnState.BackColor = System.Drawing.Color.Linen
        Me.PnState.ForeColor = System.Drawing.Color.Transparent
        Me.PnState.Location = New System.Drawing.Point(-1, 27)
        Me.PnState.Name = "PnState"
        Me.PnState.Size = New System.Drawing.Size(504, 3)
        Me.PnState.TabIndex = 166
        '
        'UCDeviceUse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Controls.Add(Me.PnState)
        Me.Controls.Add(Me.lbstatus)
        Me.Controls.Add(Me.lbname)
        Me.Controls.Add(Me.lburut)
        Me.Controls.Add(Me.BtnStat)
        Me.Name = "UCDeviceUse"
        Me.Size = New System.Drawing.Size(504, 30)
        Me.KlikAnan.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnStat As Button
    Friend WithEvents lburut As Label
    Friend WithEvents lbname As Label
    Friend WithEvents lbstatus As Label
    Friend WithEvents KlikAnan As ContextMenuStrip
    Friend WithEvents BtnNext As ToolStripMenuItem
    Friend WithEvents BtnStop As ToolStripMenuItem
    Friend WithEvents btnVlog As ToolStripMenuItem
    Friend WithEvents OpenMirrorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PnState As Panel
End Class
