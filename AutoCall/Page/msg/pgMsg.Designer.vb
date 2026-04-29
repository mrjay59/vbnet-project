<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class pgMsg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pgMsg))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panelgb = New System.Windows.Forms.Panel()
        Me.BtnNotRead = New System.Windows.Forms.Button()
        Me.BtnAll = New System.Windows.Forms.Button()
        Me.TextSearch = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PnChatList = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnNewMsg = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PnMessage = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.TextMessage = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnWA = New System.Windows.Forms.Button()
        Me.BtnSIP = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panelgb)
        Me.Panel1.Controls.Add(Me.BtnNotRead)
        Me.Panel1.Controls.Add(Me.BtnAll)
        Me.Panel1.Controls.Add(Me.TextSearch)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PnChatList)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 643)
        Me.Panel1.TabIndex = 0
        '
        'Panelgb
        '
        Me.Panelgb.BackColor = System.Drawing.Color.DarkOrange
        Me.Panelgb.Location = New System.Drawing.Point(185, 135)
        Me.Panelgb.Name = "Panelgb"
        Me.Panelgb.Size = New System.Drawing.Size(100, 2)
        Me.Panelgb.TabIndex = 217
        Me.Panelgb.Visible = False
        '
        'BtnNotRead
        '
        Me.BtnNotRead.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnNotRead.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNotRead.FlatAppearance.BorderSize = 0
        Me.BtnNotRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNotRead.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNotRead.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNotRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNotRead.Location = New System.Drawing.Point(65, 110)
        Me.BtnNotRead.Name = "BtnNotRead"
        Me.BtnNotRead.Size = New System.Drawing.Size(93, 21)
        Me.BtnNotRead.TabIndex = 216
        Me.BtnNotRead.Text = "Belum dibaca"
        Me.BtnNotRead.UseVisualStyleBackColor = False
        '
        'BtnAll
        '
        Me.BtnAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAll.FlatAppearance.BorderSize = 0
        Me.BtnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAll.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAll.Location = New System.Drawing.Point(5, 110)
        Me.BtnAll.Name = "BtnAll"
        Me.BtnAll.Size = New System.Drawing.Size(54, 21)
        Me.BtnAll.TabIndex = 215
        Me.BtnAll.Text = "Semua"
        Me.BtnAll.UseVisualStyleBackColor = False
        '
        'TextSearch
        '
        Me.TextSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextSearch.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSearch.ForeColor = System.Drawing.Color.White
        Me.TextSearch.Location = New System.Drawing.Point(5, 60)
        Me.TextSearch.Name = "TextSearch"
        Me.TextSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextSearch.Size = New System.Drawing.Size(309, 37)
        Me.TextSearch.TabIndex = 202
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Location = New System.Drawing.Point(0, 54)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(320, 86)
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'PnChatList
        '
        Me.PnChatList.AutoScroll = True
        Me.PnChatList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnChatList.Location = New System.Drawing.Point(0, 146)
        Me.PnChatList.Name = "PnChatList"
        Me.PnChatList.Size = New System.Drawing.Size(320, 497)
        Me.PnChatList.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Panel3.Controls.Add(Me.BtnNewMsg)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(320, 54)
        Me.Panel3.TabIndex = 0
        '
        'BtnNewMsg
        '
        Me.BtnNewMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BtnNewMsg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNewMsg.FlatAppearance.BorderSize = 0
        Me.BtnNewMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNewMsg.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNewMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNewMsg.Location = New System.Drawing.Point(205, 12)
        Me.BtnNewMsg.Name = "BtnNewMsg"
        Me.BtnNewMsg.Size = New System.Drawing.Size(112, 30)
        Me.BtnNewMsg.TabIndex = 217
        Me.BtnNewMsg.Text = "New Message"
        Me.BtnNewMsg.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 31)
        Me.Label3.TabIndex = 215
        Me.Label3.Text = "ChatList"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PnMessage)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(320, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(720, 643)
        Me.Panel2.TabIndex = 1
        '
        'PnMessage
        '
        Me.PnMessage.AutoScroll = True
        Me.PnMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnMessage.Location = New System.Drawing.Point(0, 54)
        Me.PnMessage.Name = "PnMessage"
        Me.PnMessage.Size = New System.Drawing.Size(720, 514)
        Me.PnMessage.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Button3)
        Me.Panel6.Controls.Add(Me.Button4)
        Me.Panel6.Controls.Add(Me.Button5)
        Me.Panel6.Controls.Add(Me.ComboBox1)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.Button6)
        Me.Panel6.Controls.Add(Me.btnSend)
        Me.Panel6.Controls.Add(Me.TextMessage)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 568)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(720, 75)
        Me.Panel6.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(234, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 219
        Me.Label5.Text = "Label5"
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(520, 37)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(30, 30)
        Me.Button3.TabIndex = 218
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button4
        '
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(556, 37)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(30, 30)
        Me.Button4.TabIndex = 217
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button5
        '
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(592, 37)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(30, 30)
        Me.Button5.TabIndex = 216
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.ForeColor = System.Drawing.Color.White
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(121, 5)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(108, 21)
        Me.ComboBox1.TabIndex = 215
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(53, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 16)
        Me.Label4.TabIndex = 214
        Me.Label4.Text = "Pengirim :"
        '
        'Button6
        '
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(6, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(41, 23)
        Me.Button6.TabIndex = 213
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.btnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSend.FlatAppearance.BorderSize = 0
        Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSend.Image = CType(resources.GetObject("btnSend.Image"), System.Drawing.Image)
        Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSend.Location = New System.Drawing.Point(628, 33)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(87, 36)
        Me.btnSend.TabIndex = 212
        Me.btnSend.Text = "  Kirim"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'TextMessage
        '
        Me.TextMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TextMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMessage.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMessage.ForeColor = System.Drawing.Color.White
        Me.TextMessage.Location = New System.Drawing.Point(6, 32)
        Me.TextMessage.Multiline = True
        Me.TextMessage.Name = "TextMessage"
        Me.TextMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextMessage.Size = New System.Drawing.Size(508, 40)
        Me.TextMessage.TabIndex = 211
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Controls.Add(Me.BtnWA)
        Me.Panel5.Controls.Add(Me.BtnSIP)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(720, 54)
        Me.Panel5.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(67, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 215
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(65, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 25)
        Me.Label1.TabIndex = 214
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(19, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 213
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnWA
        '
        Me.BtnWA.FlatAppearance.BorderSize = 0
        Me.BtnWA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnWA.Image = CType(resources.GetObject("BtnWA.Image"), System.Drawing.Image)
        Me.BtnWA.Location = New System.Drawing.Point(678, 12)
        Me.BtnWA.Name = "BtnWA"
        Me.BtnWA.Size = New System.Drawing.Size(30, 30)
        Me.BtnWA.TabIndex = 212
        Me.BtnWA.UseVisualStyleBackColor = True
        Me.BtnWA.Visible = False
        '
        'BtnSIP
        '
        Me.BtnSIP.FlatAppearance.BorderSize = 0
        Me.BtnSIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSIP.Image = CType(resources.GetObject("BtnSIP.Image"), System.Drawing.Image)
        Me.BtnSIP.Location = New System.Drawing.Point(639, 11)
        Me.BtnSIP.Name = "BtnSIP"
        Me.BtnSIP.Size = New System.Drawing.Size(30, 30)
        Me.BtnSIP.TabIndex = 211
        Me.BtnSIP.UseVisualStyleBackColor = True
        Me.BtnSIP.Visible = False
        '
        'pgMsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1040, 643)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "pgMsg"
        Me.Text = "pgMsg"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PnChatList As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents PnMessage As Panel
    Friend WithEvents BtnWA As Button
    Friend WithEvents BtnSIP As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextSearch As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnNotRead As Button
    Friend WithEvents BtnAll As Button
    Friend WithEvents Panelgb As Panel
    Friend WithEvents BtnNewMsg As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents btnSend As Button
    Friend WithEvents TextMessage As TextBox
    Friend WithEvents Label5 As Label
End Class
