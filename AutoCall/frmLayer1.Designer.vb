<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLayer1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLayer1))
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.lbheader = New System.Windows.Forms.Label()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnSignup = New System.Windows.Forms.Button()
        Me.BtnLogin = New System.Windows.Forms.Button()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.PanelHeader.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelHeader.Controls.Add(Me.lbheader)
        Me.PanelHeader.Controls.Add(Me.btnclose)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Location = New System.Drawing.Point(0, 0)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(689, 52)
        Me.PanelHeader.TabIndex = 2
        '
        'lbheader
        '
        Me.lbheader.AutoSize = True
        Me.lbheader.BackColor = System.Drawing.Color.Transparent
        Me.lbheader.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbheader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbheader.ForeColor = System.Drawing.Color.White
        Me.lbheader.Location = New System.Drawing.Point(13, 14)
        Me.lbheader.Name = "lbheader"
        Me.lbheader.Size = New System.Drawing.Size(104, 23)
        Me.lbheader.TabIndex = 3
        Me.lbheader.Text = "Form Login"
        Me.lbheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.Color.Transparent
        Me.btnclose.FlatAppearance.BorderSize = 0
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.ForeColor = System.Drawing.Color.Transparent
        Me.btnclose.Image = CType(resources.GetObject("btnclose.Image"), System.Drawing.Image)
        Me.btnclose.Location = New System.Drawing.Point(644, 11)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(33, 34)
        Me.btnclose.TabIndex = 2
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 52)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(451, 368)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnSignup)
        Me.Panel2.Controls.Add(Me.BtnLogin)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(451, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(238, 37)
        Me.Panel2.TabIndex = 5
        '
        'BtnSignup
        '
        Me.BtnSignup.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnSignup.FlatAppearance.BorderSize = 0
        Me.BtnSignup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSignup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSignup.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSignup.Location = New System.Drawing.Point(122, 6)
        Me.BtnSignup.Name = "BtnSignup"
        Me.BtnSignup.Size = New System.Drawing.Size(110, 25)
        Me.BtnSignup.TabIndex = 90
        Me.BtnSignup.Text = "Sign Up"
        Me.BtnSignup.UseVisualStyleBackColor = False
        '
        'BtnLogin
        '
        Me.BtnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnLogin.FlatAppearance.BorderSize = 0
        Me.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLogin.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnLogin.Location = New System.Drawing.Point(6, 6)
        Me.BtnLogin.Name = "BtnLogin"
        Me.BtnLogin.Size = New System.Drawing.Size(110, 25)
        Me.BtnLogin.TabIndex = 89
        Me.BtnLogin.Text = "Login"
        Me.BtnLogin.UseVisualStyleBackColor = False
        '
        'PanelPusat
        '
        Me.PanelPusat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelPusat.Location = New System.Drawing.Point(451, 89)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(238, 331)
        Me.PanelPusat.TabIndex = 6
        '
        'frmLayer1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(689, 420)
        Me.Controls.Add(Me.PanelPusat)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PanelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLayer1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLayer1"
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents lbheader As Label
    Friend WithEvents btnclose As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnSignup As Button
    Friend WithEvents BtnLogin As Button
    Friend WithEvents PanelPusat As Panel
End Class
