<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cloud_device
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextSearch = New System.Windows.Forms.TextBox()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.PanelPusat = New AutoCall.RoundedPanel()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 217
        Me.Label7.Text = "Cari Device"
        '
        'TextSearch
        '
        Me.TextSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.TextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextSearch.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSearch.ForeColor = System.Drawing.Color.White
        Me.TextSearch.Location = New System.Drawing.Point(73, 6)
        Me.TextSearch.Name = "TextSearch"
        Me.TextSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextSearch.Size = New System.Drawing.Size(188, 37)
        Me.TextSearch.TabIndex = 216
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdd.FlatAppearance.BorderSize = 0
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Black
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAdd.Location = New System.Drawing.Point(267, 6)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(90, 37)
        Me.BtnAdd.TabIndex = 215
        Me.BtnAdd.Text = "Add Devices"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'PanelPusat
        '
        Me.PanelPusat.AutoSizeHeight = False
        Me.PanelPusat.BorderColor = System.Drawing.Color.Gray
        Me.PanelPusat.BorderWidth = 1
        Me.PanelPusat.CornerRadius = 10
        Me.PanelPusat.Location = New System.Drawing.Point(7, 53)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.RoundingStyle = AutoCall.RoundedPanel.RoundStyle.All
        Me.PanelPusat.Size = New System.Drawing.Size(353, 523)
        Me.PanelPusat.TabIndex = 214
        '
        'cloud_device
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(367, 584)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextSearch)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.PanelPusat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "cloud_device"
        Me.Text = "cloud_device"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents TextSearch As TextBox
    Friend WithEvents BtnAdd As Button
    Friend WithEvents PanelPusat As RoundedPanel
End Class
