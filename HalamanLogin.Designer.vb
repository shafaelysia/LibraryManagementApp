<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HalamanLogin
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
        Me.BtnLogin = New System.Windows.Forms.Button()
        Me.PnlLeft = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PBLogo = New System.Windows.Forms.PictureBox()
        Me.PnlRight = New System.Windows.Forms.Panel()
        Me.TBPass = New System.Windows.Forms.TextBox()
        Me.LblPass = New System.Windows.Forms.Label()
        Me.TBUsername = New System.Windows.Forms.TextBox()
        Me.LblUsername = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnlLeft.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PBLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnLogin
        '
        Me.BtnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.BtnLogin.FlatAppearance.BorderSize = 0
        Me.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLogin.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.BtnLogin.Location = New System.Drawing.Point(108, 319)
        Me.BtnLogin.Name = "BtnLogin"
        Me.BtnLogin.Size = New System.Drawing.Size(138, 37)
        Me.BtnLogin.TabIndex = 0
        Me.BtnLogin.Text = "Login"
        Me.BtnLogin.UseVisualStyleBackColor = False
        '
        'PnlLeft
        '
        Me.PnlLeft.BackgroundImage = Global.MyLib.My.Resources.Resources._01
        Me.PnlLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PnlLeft.Controls.Add(Me.Panel1)
        Me.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.PnlLeft.Name = "PnlLeft"
        Me.PnlLeft.Size = New System.Drawing.Size(354, 445)
        Me.PnlLeft.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PBLogo)
        Me.Panel1.Location = New System.Drawing.Point(75, 108)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(201, 148)
        Me.Panel1.TabIndex = 1
        '
        'PBLogo
        '
        Me.PBLogo.BackColor = System.Drawing.Color.Transparent
        Me.PBLogo.BackgroundImage = Global.MyLib.My.Resources.Resources.LOGO
        Me.PBLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PBLogo.Location = New System.Drawing.Point(-44, -50)
        Me.PBLogo.Name = "PBLogo"
        Me.PBLogo.Size = New System.Drawing.Size(288, 248)
        Me.PBLogo.TabIndex = 0
        Me.PBLogo.TabStop = False
        '
        'PnlRight
        '
        Me.PnlRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.PnlRight.Controls.Add(Me.TBPass)
        Me.PnlRight.Controls.Add(Me.LblPass)
        Me.PnlRight.Controls.Add(Me.TBUsername)
        Me.PnlRight.Controls.Add(Me.LblUsername)
        Me.PnlRight.Controls.Add(Me.Label1)
        Me.PnlRight.Controls.Add(Me.BtnLogin)
        Me.PnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlRight.Location = New System.Drawing.Point(354, 0)
        Me.PnlRight.Name = "PnlRight"
        Me.PnlRight.Size = New System.Drawing.Size(355, 445)
        Me.PnlRight.TabIndex = 2
        '
        'TBPass
        '
        Me.TBPass.Location = New System.Drawing.Point(75, 251)
        Me.TBPass.Name = "TBPass"
        Me.TBPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TBPass.Size = New System.Drawing.Size(209, 23)
        Me.TBPass.TabIndex = 5
        '
        'LblPass
        '
        Me.LblPass.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LblPass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.LblPass.Location = New System.Drawing.Point(2, 221)
        Me.LblPass.Name = "LblPass"
        Me.LblPass.Padding = New System.Windows.Forms.Padding(80, 0, 0, 0)
        Me.LblPass.Size = New System.Drawing.Size(355, 27)
        Me.LblPass.TabIndex = 4
        Me.LblPass.Text = "Password:"
        Me.LblPass.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TBUsername
        '
        Me.TBUsername.Location = New System.Drawing.Point(75, 182)
        Me.TBUsername.Name = "TBUsername"
        Me.TBUsername.Size = New System.Drawing.Size(209, 23)
        Me.TBUsername.TabIndex = 3
        '
        'LblUsername
        '
        Me.LblUsername.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblUsername.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LblUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.LblUsername.Location = New System.Drawing.Point(0, 132)
        Me.LblUsername.Name = "LblUsername"
        Me.LblUsername.Padding = New System.Windows.Forms.Padding(80, 0, 0, 0)
        Me.LblUsername.Size = New System.Drawing.Size(355, 47)
        Me.LblUsername.TabIndex = 2
        Me.LblUsername.Text = "Username:"
        Me.LblUsername.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(355, 132)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Login"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'HalamanLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 445)
        Me.Controls.Add(Me.PnlRight)
        Me.Controls.Add(Me.PnlLeft)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "HalamanLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MyLib - Login"
        Me.PnlLeft.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PBLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlRight.ResumeLayout(False)
        Me.PnlRight.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnLogin As Button
    Friend WithEvents PnlLeft As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PBLogo As PictureBox
    Friend WithEvents PnlRight As Panel
    Friend WithEvents TBPass As TextBox
    Friend WithEvents LblPass As Label
    Friend WithEvents TBUsername As TextBox
    Friend WithEvents LblUsername As Label
    Friend WithEvents Label1 As Label
End Class
