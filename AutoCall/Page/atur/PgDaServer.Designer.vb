<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PgDaServer
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
        Me.PnListH = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PnPaging = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextSearch = New System.Windows.Forms.TextBox()
        Me.PnListServer = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PnScanQR = New System.Windows.Forms.Panel()
        Me.PnDScanQr = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PnAddForm = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PnListH.SuspendLayout()
        Me.PnScanQR.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnListH
        '
        Me.PnListH.Controls.Add(Me.Label6)
        Me.PnListH.Controls.Add(Me.Label4)
        Me.PnListH.Controls.Add(Me.Label2)
        Me.PnListH.Controls.Add(Me.PnPaging)
        Me.PnListH.Controls.Add(Me.Label5)
        Me.PnListH.Controls.Add(Me.TextSearch)
        Me.PnListH.Controls.Add(Me.PnListServer)
        Me.PnListH.Controls.Add(Me.Panel2)
        Me.PnListH.Location = New System.Drawing.Point(12, 12)
        Me.PnListH.Name = "PnListH"
        Me.PnListH.Size = New System.Drawing.Size(461, 566)
        Me.PnListH.TabIndex = 193
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(328, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(25, 20)
        Me.Label4.TabIndex = 207
        Me.Label4.Text = "10"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(328, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(25, 20)
        Me.Label2.TabIndex = 206
        Me.Label2.Text = "10"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Visible = False
        '
        'PnPaging
        '
        Me.PnPaging.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnPaging.Location = New System.Drawing.Point(0, 525)
        Me.PnPaging.Name = "PnPaging"
        Me.PnPaging.Size = New System.Drawing.Size(461, 41)
        Me.PnPaging.TabIndex = 205
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 13)
        Me.Label5.TabIndex = 204
        Me.Label5.Text = "Cari Session By Number :"
        '
        'TextSearch
        '
        Me.TextSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextSearch.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSearch.ForeColor = System.Drawing.Color.White
        Me.TextSearch.Location = New System.Drawing.Point(9, 57)
        Me.TextSearch.Name = "TextSearch"
        Me.TextSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextSearch.Size = New System.Drawing.Size(170, 31)
        Me.TextSearch.TabIndex = 203
        '
        'PnListServer
        '
        Me.PnListServer.AutoScroll = True
        Me.PnListServer.Location = New System.Drawing.Point(0, 92)
        Me.PnListServer.Name = "PnListServer"
        Me.PnListServer.Size = New System.Drawing.Size(461, 427)
        Me.PnListServer.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(461, 41)
        Me.Panel2.TabIndex = 3
        '
        'PnScanQR
        '
        Me.PnScanQR.Controls.Add(Me.PnDScanQr)
        Me.PnScanQR.Controls.Add(Me.Panel4)
        Me.PnScanQR.Location = New System.Drawing.Point(479, 240)
        Me.PnScanQR.Name = "PnScanQR"
        Me.PnScanQR.Size = New System.Drawing.Size(549, 338)
        Me.PnScanQR.TabIndex = 202
        '
        'PnDScanQr
        '
        Me.PnDScanQr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnDScanQr.Location = New System.Drawing.Point(0, 41)
        Me.PnDScanQr.Name = "PnDScanQr"
        Me.PnDScanQr.Size = New System.Drawing.Size(549, 297)
        Me.PnDScanQr.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gray
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(549, 41)
        Me.Panel4.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Scan QR"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PnAddForm)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Location = New System.Drawing.Point(479, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(549, 222)
        Me.Panel1.TabIndex = 203
        '
        'PnAddForm
        '
        Me.PnAddForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnAddForm.Location = New System.Drawing.Point(0, 41)
        Me.PnAddForm.Name = "PnAddForm"
        Me.PnAddForm.Size = New System.Drawing.Size(549, 181)
        Me.PnAddForm.TabIndex = 4
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gray
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(549, 41)
        Me.Panel7.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Silahkan dipilih Data Server"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.Font = New System.Drawing.Font("Yu Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(185, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(25, 20)
        Me.Label6.TabIndex = 208
        Me.Label6.Text = "10"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Visible = False
        '
        'PgDaServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1040, 590)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnScanQR)
        Me.Controls.Add(Me.PnListH)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PgDaServer"
        Me.Text = "PgDaServer"
        Me.PnListH.ResumeLayout(False)
        Me.PnListH.PerformLayout()
        Me.PnScanQR.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnListH As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PnScanQR As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PnListServer As Panel
    Friend WithEvents PnDScanQr As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PnAddForm As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextSearch As TextBox
    Friend WithEvents PnPaging As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
End Class
