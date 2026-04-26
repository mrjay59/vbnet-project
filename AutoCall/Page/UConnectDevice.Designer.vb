<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UConnectDevice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UConnectDevice))
        Me.lbname = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbstatus = New System.Windows.Forms.Label()
        Me.lblnum = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BtnSetup = New System.Windows.Forms.Button()
        Me.BtnCon = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbname
        '
        Me.lbname.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbname.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbname.Font = New System.Drawing.Font("Segoe UI Historic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbname.ForeColor = System.Drawing.Color.White
        Me.lbname.Location = New System.Drawing.Point(31, 5)
        Me.lbname.Name = "lbname"
        Me.lbname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbname.Size = New System.Drawing.Size(157, 26)
        Me.lbname.TabIndex = 108
        Me.lbname.Text = " Device Name"
        Me.lbname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbstatus)
        Me.Panel1.Controls.Add(Me.BtnSetup)
        Me.Panel1.Controls.Add(Me.lblnum)
        Me.Panel1.Controls.Add(Me.BtnCon)
        Me.Panel1.Controls.Add(Me.lbname)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(337, 54)
        Me.Panel1.TabIndex = 109
        '
        'lbstatus
        '
        Me.lbstatus.AutoSize = True
        Me.lbstatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lbstatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbstatus.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbstatus.ForeColor = System.Drawing.Color.White
        Me.lbstatus.Location = New System.Drawing.Point(32, 34)
        Me.lbstatus.Name = "lbstatus"
        Me.lbstatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbstatus.Size = New System.Drawing.Size(65, 14)
        Me.lbstatus.TabIndex = 186
        Me.lbstatus.Text = "Keterangan"
        Me.lbstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblnum
        '
        Me.lblnum.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblnum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblnum.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnum.ForeColor = System.Drawing.Color.White
        Me.lblnum.Location = New System.Drawing.Point(0, 0)
        Me.lblnum.Name = "lblnum"
        Me.lblnum.Size = New System.Drawing.Size(31, 54)
        Me.lblnum.TabIndex = 109
        Me.lblnum.Text = "1"
        Me.lblnum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 15000
        '
        'BtnSetup
        '
        Me.BtnSetup.BackColor = System.Drawing.Color.Transparent
        Me.BtnSetup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSetup.FlatAppearance.BorderSize = 0
        Me.BtnSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSetup.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSetup.Image = CType(resources.GetObject("BtnSetup.Image"), System.Drawing.Image)
        Me.BtnSetup.Location = New System.Drawing.Point(293, 6)
        Me.BtnSetup.Name = "BtnSetup"
        Me.BtnSetup.Size = New System.Drawing.Size(32, 38)
        Me.BtnSetup.TabIndex = 110
        Me.BtnSetup.UseVisualStyleBackColor = False
        '
        'BtnCon
        '
        Me.BtnCon.BackColor = System.Drawing.Color.Transparent
        Me.BtnCon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCon.FlatAppearance.BorderSize = 0
        Me.BtnCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCon.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCon.Image = Global.AutoCall.My.Resources.Resources.icons8_setup_25
        Me.BtnCon.Location = New System.Drawing.Point(247, 6)
        Me.BtnCon.Name = "BtnCon"
        Me.BtnCon.Size = New System.Drawing.Size(40, 40)
        Me.BtnCon.TabIndex = 107
        Me.BtnCon.Tag = "Setup"
        Me.BtnCon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon.UseVisualStyleBackColor = False
        '
        'UConnectDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UConnectDevice"
        Me.Size = New System.Drawing.Size(337, 54)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnCon As Button
    Friend WithEvents lbname As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblnum As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BtnSetup As Button
    Friend WithEvents lbstatus As Label
End Class
