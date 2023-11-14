<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambioAttivita
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambioAttivita))
        Me.plsCancel = New System.Windows.Forms.Button()
        Me.plsConfirm = New System.Windows.Forms.Button()
        Me.lblActivity = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboActivity = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'plsCancel
        '
        Me.plsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.plsCancel.Image = CType(resources.GetObject("plsCancel.Image"), System.Drawing.Image)
        Me.plsCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsCancel.Location = New System.Drawing.Point(47, 143)
        Me.plsCancel.Name = "plsCancel"
        Me.plsCancel.Size = New System.Drawing.Size(87, 28)
        Me.plsCancel.TabIndex = 281
        Me.plsCancel.Text = "Annulla"
        Me.plsCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.plsCancel.UseVisualStyleBackColor = True
        '
        'plsConfirm
        '
        Me.plsConfirm.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.plsConfirm.Image = CType(resources.GetObject("plsConfirm.Image"), System.Drawing.Image)
        Me.plsConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsConfirm.Location = New System.Drawing.Point(201, 143)
        Me.plsConfirm.Name = "plsConfirm"
        Me.plsConfirm.Size = New System.Drawing.Size(87, 28)
        Me.plsConfirm.TabIndex = 282
        Me.plsConfirm.Text = "Conferma"
        Me.plsConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.plsConfirm.UseVisualStyleBackColor = True
        '
        'lblActivity
        '
        Me.lblActivity.BackColor = System.Drawing.Color.White
        Me.lblActivity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblActivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivity.Location = New System.Drawing.Point(111, 27)
        Me.lblActivity.Name = "lblActivity"
        Me.lblActivity.Size = New System.Drawing.Size(177, 20)
        Me.lblActivity.TabIndex = 280
        Me.lblActivity.Text = "Attività"
        Me.lblActivity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 279
        Me.Label1.Text = "Attività"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(44, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 20)
        Me.Label5.TabIndex = 278
        Me.Label5.Text = "Attività"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboActivity
        '
        Me.cboActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActivity.Location = New System.Drawing.Point(111, 88)
        Me.cboActivity.Name = "cboActivity"
        Me.cboActivity.Size = New System.Drawing.Size(177, 21)
        Me.cboActivity.TabIndex = 277
        '
        'frmCambioAttivita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 225)
        Me.Controls.Add(Me.plsCancel)
        Me.Controls.Add(Me.plsConfirm)
        Me.Controls.Add(Me.lblActivity)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboActivity)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambioAttivita"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmCambioAttivita"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents plsCancel As Button
    Friend WithEvents plsConfirm As Button
    Friend WithEvents lblActivity As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboActivity As ComboBox
End Class
