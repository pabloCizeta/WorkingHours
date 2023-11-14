<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAnalisiOreLavoro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnalisiOreLavoro))
        Me.panMenu = New System.Windows.Forms.Panel()
        Me.mnu = New OreLavoro.ucMenu()
        Me.plsFilter = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboSector = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboActivity = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboOrderName = New System.Windows.Forms.ComboBox()
        Me.lblData = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEmployee = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.panData = New System.Windows.Forms.Panel()
        Me.grpOreLavoro = New System.Windows.Forms.GroupBox()
        Me.lblOreViaggioTotale = New System.Windows.Forms.Label()
        Me.lblOreLavoroTotale = New System.Windows.Forms.Label()
        Me.lblOreViaggioCommessa = New System.Windows.Forms.Label()
        Me.lblOreLavoroCommessa = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCommessa = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.panFilter = New System.Windows.Forms.Panel()
        Me.panMenu.SuspendLayout()
        Me.grpOreLavoro.SuspendLayout()
        Me.panFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'panMenu
        '
        Me.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panMenu.Controls.Add(Me.mnu)
        Me.panMenu.Location = New System.Drawing.Point(4, 5)
        Me.panMenu.Name = "panMenu"
        Me.panMenu.Size = New System.Drawing.Size(136, 620)
        Me.panMenu.TabIndex = 147
        '
        'mnu
        '
        Me.mnu.Location = New System.Drawing.Point(-1, -2)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(135, 619)
        Me.mnu.TabIndex = 1
        '
        'plsFilter
        '
        Me.plsFilter.Image = CType(resources.GetObject("plsFilter.Image"), System.Drawing.Image)
        Me.plsFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsFilter.Location = New System.Drawing.Point(296, 37)
        Me.plsFilter.Name = "plsFilter"
        Me.plsFilter.Size = New System.Drawing.Size(25, 26)
        Me.plsFilter.TabIndex = 228
        Me.plsFilter.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 20)
        Me.Label7.TabIndex = 227
        Me.Label7.Text = "Settore"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSector
        '
        Me.cboSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSector.FormattingEnabled = True
        Me.cboSector.Location = New System.Drawing.Point(70, 92)
        Me.cboSector.Name = "cboSector"
        Me.cboSector.Size = New System.Drawing.Size(220, 21)
        Me.cboSector.TabIndex = 226
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 20)
        Me.Label6.TabIndex = 225
        Me.Label6.Text = "Attività"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboActivity
        '
        Me.cboActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActivity.FormattingEnabled = True
        Me.cboActivity.Location = New System.Drawing.Point(70, 66)
        Me.cboActivity.Name = "cboActivity"
        Me.cboActivity.Size = New System.Drawing.Size(220, 21)
        Me.cboActivity.TabIndex = 224
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 20)
        Me.Label5.TabIndex = 223
        Me.Label5.Text = "Commessa"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOrderName
        '
        Me.cboOrderName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrderName.Location = New System.Drawing.Point(70, 40)
        Me.cboOrderName.Name = "cboOrderName"
        Me.cboOrderName.Size = New System.Drawing.Size(220, 21)
        Me.cboOrderName.TabIndex = 222
        '
        'lblData
        '
        Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblData.Location = New System.Drawing.Point(490, 10)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(41, 20)
        Me.lblData.TabIndex = 221
        Me.lblData.Text = "Da"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(531, 10)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(203, 20)
        Me.dtpFrom.TabIndex = 220
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 230
        Me.Label1.Text = "Nome"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEmployee
        '
        Me.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployee.FormattingEnabled = True
        Me.cboEmployee.Location = New System.Drawing.Point(70, 9)
        Me.cboEmployee.Name = "cboEmployee"
        Me.cboEmployee.Size = New System.Drawing.Size(220, 21)
        Me.cboEmployee.TabIndex = 229
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(490, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 20)
        Me.Label2.TabIndex = 232
        Me.Label2.Text = "A"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(531, 49)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(203, 20)
        Me.dtpTo.TabIndex = 231
        '
        'panData
        '
        Me.panData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panData.Location = New System.Drawing.Point(147, 128)
        Me.panData.Name = "panData"
        Me.panData.Size = New System.Drawing.Size(854, 496)
        Me.panData.TabIndex = 233
        '
        'grpOreLavoro
        '
        Me.grpOreLavoro.Controls.Add(Me.lblOreViaggioTotale)
        Me.grpOreLavoro.Controls.Add(Me.lblOreLavoroTotale)
        Me.grpOreLavoro.Controls.Add(Me.lblOreViaggioCommessa)
        Me.grpOreLavoro.Controls.Add(Me.lblOreLavoroCommessa)
        Me.grpOreLavoro.Controls.Add(Me.Label9)
        Me.grpOreLavoro.Controls.Add(Me.lblCommessa)
        Me.grpOreLavoro.Controls.Add(Me.Label4)
        Me.grpOreLavoro.Controls.Add(Me.Label3)
        Me.grpOreLavoro.Location = New System.Drawing.Point(750, 5)
        Me.grpOreLavoro.Name = "grpOreLavoro"
        Me.grpOreLavoro.Size = New System.Drawing.Size(251, 117)
        Me.grpOreLavoro.TabIndex = 234
        Me.grpOreLavoro.TabStop = False
        Me.grpOreLavoro.Text = "Totali ore [hh:mm]"
        '
        'lblOreViaggioTotale
        '
        Me.lblOreViaggioTotale.BackColor = System.Drawing.Color.White
        Me.lblOreViaggioTotale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOreViaggioTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOreViaggioTotale.Location = New System.Drawing.Point(189, 74)
        Me.lblOreViaggioTotale.Name = "lblOreViaggioTotale"
        Me.lblOreViaggioTotale.Size = New System.Drawing.Size(56, 20)
        Me.lblOreViaggioTotale.TabIndex = 240
        Me.lblOreViaggioTotale.Text = "999.99"
        Me.lblOreViaggioTotale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOreLavoroTotale
        '
        Me.lblOreLavoroTotale.BackColor = System.Drawing.Color.White
        Me.lblOreLavoroTotale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOreLavoroTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOreLavoroTotale.Location = New System.Drawing.Point(136, 74)
        Me.lblOreLavoroTotale.Name = "lblOreLavoroTotale"
        Me.lblOreLavoroTotale.Size = New System.Drawing.Size(56, 20)
        Me.lblOreLavoroTotale.TabIndex = 239
        Me.lblOreLavoroTotale.Text = "999.59"
        Me.lblOreLavoroTotale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOreViaggioCommessa
        '
        Me.lblOreViaggioCommessa.BackColor = System.Drawing.Color.White
        Me.lblOreViaggioCommessa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOreViaggioCommessa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOreViaggioCommessa.Location = New System.Drawing.Point(189, 38)
        Me.lblOreViaggioCommessa.Name = "lblOreViaggioCommessa"
        Me.lblOreViaggioCommessa.Size = New System.Drawing.Size(56, 20)
        Me.lblOreViaggioCommessa.TabIndex = 238
        Me.lblOreViaggioCommessa.Text = "99999.99"
        Me.lblOreViaggioCommessa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOreLavoroCommessa
        '
        Me.lblOreLavoroCommessa.BackColor = System.Drawing.Color.White
        Me.lblOreLavoroCommessa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOreLavoroCommessa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOreLavoroCommessa.Location = New System.Drawing.Point(136, 38)
        Me.lblOreLavoroCommessa.Name = "lblOreLavoroCommessa"
        Me.lblOreLavoroCommessa.Size = New System.Drawing.Size(56, 20)
        Me.lblOreLavoroCommessa.TabIndex = 237
        Me.lblOreLavoroCommessa.Text = "99999.59"
        Me.lblOreLavoroCommessa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 20)
        Me.Label9.TabIndex = 236
        Me.Label9.Text = "Totale"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCommessa
        '
        Me.lblCommessa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCommessa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCommessa.Location = New System.Drawing.Point(6, 38)
        Me.lblCommessa.Name = "lblCommessa"
        Me.lblCommessa.Size = New System.Drawing.Size(129, 20)
        Me.lblCommessa.TabIndex = 235
        Me.lblCommessa.Text = "Commessa"
        Me.lblCommessa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(189, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 20)
        Me.Label4.TabIndex = 223
        Me.Label4.Text = "Viaggio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(136, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 20)
        Me.Label3.TabIndex = 222
        Me.Label3.Text = "Lavoro"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panFilter
        '
        Me.panFilter.Controls.Add(Me.Label1)
        Me.panFilter.Controls.Add(Me.cboOrderName)
        Me.panFilter.Controls.Add(Me.Label5)
        Me.panFilter.Controls.Add(Me.cboActivity)
        Me.panFilter.Controls.Add(Me.Label6)
        Me.panFilter.Controls.Add(Me.cboEmployee)
        Me.panFilter.Controls.Add(Me.cboSector)
        Me.panFilter.Controls.Add(Me.plsFilter)
        Me.panFilter.Controls.Add(Me.Label7)
        Me.panFilter.Location = New System.Drawing.Point(146, 5)
        Me.panFilter.Name = "panFilter"
        Me.panFilter.Size = New System.Drawing.Size(328, 119)
        Me.panFilter.TabIndex = 236
        '
        'frmAnalisiOreLavoro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 628)
        Me.Controls.Add(Me.panFilter)
        Me.Controls.Add(Me.grpOreLavoro)
        Me.Controls.Add(Me.panData)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.panMenu)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAnalisiOreLavoro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmAnalisiOreLavoro"
        Me.panMenu.ResumeLayout(False)
        Me.grpOreLavoro.ResumeLayout(False)
        Me.panFilter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panMenu As Panel
    Friend WithEvents mnu As ucMenu
    Friend WithEvents plsFilter As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cboSector As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cboActivity As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboOrderName As ComboBox
    Friend WithEvents lblData As Label
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents cboEmployee As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents panData As Panel
    Friend WithEvents grpOreLavoro As GroupBox
    Friend WithEvents lblOreViaggioTotale As Label
    Friend WithEvents lblOreLavoroTotale As Label
    Friend WithEvents lblOreViaggioCommessa As Label
    Friend WithEvents lblOreLavoroCommessa As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblCommessa As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents panFilter As Panel
End Class
