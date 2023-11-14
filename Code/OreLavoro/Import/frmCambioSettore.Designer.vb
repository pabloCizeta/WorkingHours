<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambioSettore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambioSettore))
        Me.plsCancel = New System.Windows.Forms.Button()
        Me.plsConfirm = New System.Windows.Forms.Button()
        Me.lblSector = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSector = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'plsCancel
        '
        Me.plsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.plsCancel.Image = CType(resources.GetObject("plsCancel.Image"), System.Drawing.Image)
        Me.plsCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsCancel.Location = New System.Drawing.Point(49, 147)
        Me.plsCancel.Name = "plsCancel"
        Me.plsCancel.Size = New System.Drawing.Size(87, 28)
        Me.plsCancel.TabIndex = 287
        Me.plsCancel.Text = "Annulla"
        Me.plsCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.plsCancel.UseVisualStyleBackColor = True
        '
        'plsConfirm
        '
        Me.plsConfirm.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.plsConfirm.Image = CType(resources.GetObject("plsConfirm.Image"), System.Drawing.Image)
        Me.plsConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsConfirm.Location = New System.Drawing.Point(203, 147)
        Me.plsConfirm.Name = "plsConfirm"
        Me.plsConfirm.Size = New System.Drawing.Size(87, 28)
        Me.plsConfirm.TabIndex = 288
        Me.plsConfirm.Text = "Conferma"
        Me.plsConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.plsConfirm.UseVisualStyleBackColor = True
        '
        'lblSector
        '
        Me.lblSector.BackColor = System.Drawing.Color.White
        Me.lblSector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSector.Location = New System.Drawing.Point(113, 31)
        Me.lblSector.Name = "lblSector"
        Me.lblSector.Size = New System.Drawing.Size(177, 20)
        Me.lblSector.TabIndex = 286
        Me.lblSector.Text = "Settore"
        Me.lblSector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 285
        Me.Label1.Text = "Settore"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 20)
        Me.Label5.TabIndex = 284
        Me.Label5.Text = "Settore"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSector
        '
        Me.cboSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSector.Location = New System.Drawing.Point(113, 92)
        Me.cboSector.Name = "cboSector"
        Me.cboSector.Size = New System.Drawing.Size(177, 21)
        Me.cboSector.TabIndex = 283
        '
        'frmCambioSettore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 214)
        Me.Controls.Add(Me.plsCancel)
        Me.Controls.Add(Me.plsConfirm)
        Me.Controls.Add(Me.lblSector)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboSector)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambioSettore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmCambioSettore"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents plsCancel As Button
    Friend WithEvents plsConfirm As Button
    Friend WithEvents lblSector As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboSector As ComboBox
End Class
