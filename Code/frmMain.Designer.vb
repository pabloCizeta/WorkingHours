<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lblUserRole = New System.Windows.Forms.Label()
        Me.picUserLogged = New System.Windows.Forms.PictureBox()
        Me.lblLoginName = New System.Windows.Forms.Label()
        Me.panMenu = New System.Windows.Forms.Panel()
        Me.mnu = New OreLavoro.ucMenu()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.panLogin = New System.Windows.Forms.Panel()
        Me.panUserLogged = New System.Windows.Forms.Panel()
        Me.panUserLogin = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.txtLoginName = New System.Windows.Forms.TextBox()
        Me.plsLogin = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblRelease = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label0 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.picUserLogged, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panMenu.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.panLogin.SuspendLayout()
        Me.panUserLogged.SuspendLayout()
        Me.panUserLogin.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblUserRole
        '
        Me.lblUserRole.AutoEllipsis = True
        Me.lblUserRole.BackColor = System.Drawing.Color.Transparent
        Me.lblUserRole.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUserRole.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserRole.Location = New System.Drawing.Point(102, 55)
        Me.lblUserRole.Name = "lblUserRole"
        Me.lblUserRole.Size = New System.Drawing.Size(211, 23)
        Me.lblUserRole.TabIndex = 7
        Me.lblUserRole.Text = "Administrator"
        Me.lblUserRole.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picUserLogged
        '
        Me.picUserLogged.Cursor = System.Windows.Forms.Cursors.Default
        Me.picUserLogged.Image = CType(resources.GetObject("picUserLogged.Image"), System.Drawing.Image)
        Me.picUserLogged.Location = New System.Drawing.Point(13, 16)
        Me.picUserLogged.Name = "picUserLogged"
        Me.picUserLogged.Size = New System.Drawing.Size(73, 73)
        Me.picUserLogged.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picUserLogged.TabIndex = 6
        Me.picUserLogged.TabStop = False
        '
        'lblLoginName
        '
        Me.lblLoginName.AutoEllipsis = True
        Me.lblLoginName.BackColor = System.Drawing.Color.Transparent
        Me.lblLoginName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLoginName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginName.Location = New System.Drawing.Point(102, 16)
        Me.lblLoginName.Name = "lblLoginName"
        Me.lblLoginName.Size = New System.Drawing.Size(208, 27)
        Me.lblLoginName.TabIndex = 5
        Me.lblLoginName.Text = "LoginName"
        Me.lblLoginName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'panMenu
        '
        Me.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panMenu.Controls.Add(Me.mnu)
        Me.panMenu.Location = New System.Drawing.Point(4, 3)
        Me.panMenu.Name = "panMenu"
        Me.panMenu.Size = New System.Drawing.Size(136, 533)
        Me.panMenu.TabIndex = 141
        '
        'mnu
        '
        Me.mnu.Location = New System.Drawing.Point(-1, -6)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(135, 537)
        Me.mnu.TabIndex = 0
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label24.Location = New System.Drawing.Point(28, 21)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 17)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "cizeta"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(28, 5)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 17)
        Me.Label25.TabIndex = 14
        Me.Label25.Text = "Powered by"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.Label24)
        Me.Panel4.Controls.Add(Me.Label25)
        Me.Panel4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel4.Location = New System.Drawing.Point(4, 771)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(124, 51)
        Me.Panel4.TabIndex = 145
        '
        'panLogin
        '
        Me.panLogin.Controls.Add(Me.panUserLogged)
        Me.panLogin.Controls.Add(Me.panUserLogin)
        Me.panLogin.Controls.Add(Me.lblRelease)
        Me.panLogin.Controls.Add(Me.PictureBox1)
        Me.panLogin.Controls.Add(Me.Label9)
        Me.panLogin.Controls.Add(Me.Label0)
        Me.panLogin.Controls.Add(Me.Label8)
        Me.panLogin.Location = New System.Drawing.Point(164, 12)
        Me.panLogin.Name = "panLogin"
        Me.panLogin.Size = New System.Drawing.Size(367, 510)
        Me.panLogin.TabIndex = 143
        '
        'panUserLogged
        '
        Me.panUserLogged.Controls.Add(Me.lblUserRole)
        Me.panUserLogged.Controls.Add(Me.picUserLogged)
        Me.panUserLogged.Controls.Add(Me.lblLoginName)
        Me.panUserLogged.Location = New System.Drawing.Point(26, 435)
        Me.panUserLogged.Name = "panUserLogged"
        Me.panUserLogged.Size = New System.Drawing.Size(328, 60)
        Me.panUserLogged.TabIndex = 223
        '
        'panUserLogin
        '
        Me.panUserLogin.Controls.Add(Me.Label10)
        Me.panUserLogin.Controls.Add(Me.lblInfo)
        Me.panUserLogin.Controls.Add(Me.txtLoginName)
        Me.panUserLogin.Controls.Add(Me.plsLogin)
        Me.panUserLogin.Controls.Add(Me.Label11)
        Me.panUserLogin.Controls.Add(Me.txtPassword)
        Me.panUserLogin.Location = New System.Drawing.Point(26, 329)
        Me.panUserLogin.Name = "panUserLogin"
        Me.panUserLogin.Size = New System.Drawing.Size(328, 100)
        Me.panUserLogin.TabIndex = 222
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 20)
        Me.Label10.TabIndex = 206
        Me.Label10.Text = "Utente"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Red
        Me.lblInfo.Location = New System.Drawing.Point(24, 69)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(39, 13)
        Me.lblInfo.TabIndex = 220
        Me.lblInfo.Text = "Utente"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblInfo.Visible = False
        '
        'txtLoginName
        '
        Me.txtLoginName.Location = New System.Drawing.Point(86, 20)
        Me.txtLoginName.Name = "txtLoginName"
        Me.txtLoginName.Size = New System.Drawing.Size(162, 20)
        Me.txtLoginName.TabIndex = 1
        '
        'plsLogin
        '
        Me.plsLogin.Image = CType(resources.GetObject("plsLogin.Image"), System.Drawing.Image)
        Me.plsLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsLogin.Location = New System.Drawing.Point(265, 20)
        Me.plsLogin.Name = "plsLogin"
        Me.plsLogin.Size = New System.Drawing.Size(42, 43)
        Me.plsLogin.TabIndex = 219
        Me.plsLogin.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(24, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 20)
        Me.Label11.TabIndex = 211
        Me.Label11.Text = "Password"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(86, 43)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(162, 20)
        Me.txtPassword.TabIndex = 2
        '
        'lblRelease
        '
        Me.lblRelease.BackColor = System.Drawing.Color.Transparent
        Me.lblRelease.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelease.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRelease.Location = New System.Drawing.Point(83, 296)
        Me.lblRelease.Name = "lblRelease"
        Me.lblRelease.Size = New System.Drawing.Size(222, 19)
        Me.lblRelease.TabIndex = 221
        Me.lblRelease.Text = "rel. 0.0.0"
        Me.lblRelease.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(123, 154)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(134, 129)
        Me.PictureBox1.TabIndex = 75
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(35, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(319, 33)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "ORE LAVORO "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label0
        '
        Me.Label0.AutoEllipsis = True
        Me.Label0.BackColor = System.Drawing.Color.Transparent
        Me.Label0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label0.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label0.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label0.Location = New System.Drawing.Point(46, 15)
        Me.Label0.Name = "Label0"
        Me.Label0.Size = New System.Drawing.Size(290, 73)
        Me.Label0.TabIndex = 73
        Me.Label0.Text = "cizeta"
        Me.Label0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(35, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(319, 20)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "CIZETA AUTOMAZIONE s.r.l."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 542)
        Me.Controls.Add(Me.panLogin)
        Me.Controls.Add(Me.panMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.picUserLogged, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panMenu.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.panLogin.ResumeLayout(False)
        Me.panUserLogged.ResumeLayout(False)
        Me.panUserLogin.ResumeLayout(False)
        Me.panUserLogin.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblUserRole As System.Windows.Forms.Label
    Friend WithEvents picUserLogged As System.Windows.Forms.PictureBox
    Friend WithEvents lblLoginName As System.Windows.Forms.Label
    Friend WithEvents panMenu As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents mnu As ucMenu
    Friend WithEvents panLogin As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label0 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents plsLogin As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtLoginName As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents lblInfo As Label
    Friend WithEvents lblRelease As Label
    Friend WithEvents panUserLogged As Panel
    Friend WithEvents panUserLogin As Panel
    ' Friend WithEvents ucMasterMonitor As LasCore.ucMasterMonitor

End Class
