<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParamsConfig
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
        Me.panMenu = New System.Windows.Forms.Panel()
        Me.panOreLavoro = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFestaMese = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFestaGiorno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTrasfertaEsteroLunga = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTrasfertaEstero = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTrasfertaItalia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDiariaEstero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDiariaItalia = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCostoKm = New System.Windows.Forms.TextBox()
        Me.dgvActivities = New System.Windows.Forms.DataGridView()
        Me.mnu = New OreLavoro.ucMenu()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvSectors = New System.Windows.Forms.DataGridView()
        Me.panMenu.SuspendLayout()
        Me.panOreLavoro.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvActivities, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvSectors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panMenu
        '
        Me.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panMenu.Controls.Add(Me.mnu)
        Me.panMenu.Location = New System.Drawing.Point(5, 5)
        Me.panMenu.Name = "panMenu"
        Me.panMenu.Size = New System.Drawing.Size(136, 446)
        Me.panMenu.TabIndex = 154
        '
        'panOreLavoro
        '
        Me.panOreLavoro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panOreLavoro.Controls.Add(Me.TabControl1)
        Me.panOreLavoro.Location = New System.Drawing.Point(144, 5)
        Me.panOreLavoro.Name = "panOreLavoro"
        Me.panOreLavoro.Size = New System.Drawing.Size(280, 447)
        Me.panOreLavoro.TabIndex = 155
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtFestaMese)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtFestaGiorno)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 182)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 55)
        Me.GroupBox1.TabIndex = 276
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Festa patronale"
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(118, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 20)
        Me.Label13.TabIndex = 276
        Me.Label13.Text = "Mese"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFestaMese
        '
        Me.txtFestaMese.Location = New System.Drawing.Point(160, 21)
        Me.txtFestaMese.Name = "txtFestaMese"
        Me.txtFestaMese.Size = New System.Drawing.Size(30, 20)
        Me.txtFestaMese.TabIndex = 275
        Me.txtFestaMese.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(23, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 20)
        Me.Label12.TabIndex = 274
        Me.Label12.Text = "Giorno"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFestaGiorno
        '
        Me.txtFestaGiorno.Location = New System.Drawing.Point(65, 21)
        Me.txtFestaGiorno.Name = "txtFestaGiorno"
        Me.txtFestaGiorno.Size = New System.Drawing.Size(30, 20)
        Me.txtFestaGiorno.TabIndex = 273
        Me.txtFestaGiorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(222, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 20)
        Me.Label9.TabIndex = 273
        Me.Label9.Text = "€"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 137)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(141, 20)
        Me.Label11.TabIndex = 272
        Me.Label11.Text = "Trasferta Estero lunga"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTrasfertaEsteroLunga
        '
        Me.txtTrasfertaEsteroLunga.Location = New System.Drawing.Point(159, 137)
        Me.txtTrasfertaEsteroLunga.Name = "txtTrasfertaEsteroLunga"
        Me.txtTrasfertaEsteroLunga.Size = New System.Drawing.Size(61, 20)
        Me.txtTrasfertaEsteroLunga.TabIndex = 271
        Me.txtTrasfertaEsteroLunga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(222, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 20)
        Me.Label7.TabIndex = 270
        Me.Label7.Text = "€"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 20)
        Me.Label8.TabIndex = 269
        Me.Label8.Text = "Trasferta Estero"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTrasfertaEstero
        '
        Me.txtTrasfertaEstero.Location = New System.Drawing.Point(159, 115)
        Me.txtTrasfertaEstero.Name = "txtTrasfertaEstero"
        Me.txtTrasfertaEstero.Size = New System.Drawing.Size(61, 20)
        Me.txtTrasfertaEstero.TabIndex = 268
        Me.txtTrasfertaEstero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(222, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 20)
        Me.Label5.TabIndex = 267
        Me.Label5.Text = "€"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 20)
        Me.Label6.TabIndex = 266
        Me.Label6.Text = "Trasferta Italia"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTrasfertaItalia
        '
        Me.txtTrasfertaItalia.Location = New System.Drawing.Point(159, 93)
        Me.txtTrasfertaItalia.Name = "txtTrasfertaItalia"
        Me.txtTrasfertaItalia.Size = New System.Drawing.Size(61, 20)
        Me.txtTrasfertaItalia.TabIndex = 265
        Me.txtTrasfertaItalia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(222, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 20)
        Me.Label3.TabIndex = 264
        Me.Label3.Text = "€"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 20)
        Me.Label4.TabIndex = 263
        Me.Label4.Text = "Diaria Estero"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiariaEstero
        '
        Me.txtDiariaEstero.Location = New System.Drawing.Point(159, 62)
        Me.txtDiariaEstero.Name = "txtDiariaEstero"
        Me.txtDiariaEstero.Size = New System.Drawing.Size(61, 20)
        Me.txtDiariaEstero.TabIndex = 262
        Me.txtDiariaEstero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(222, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 20)
        Me.Label1.TabIndex = 261
        Me.Label1.Text = "€"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 20)
        Me.Label2.TabIndex = 260
        Me.Label2.Text = "Diaria Italia"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiariaItalia
        '
        Me.txtDiariaItalia.Location = New System.Drawing.Point(159, 40)
        Me.txtDiariaItalia.Name = "txtDiariaItalia"
        Me.txtDiariaItalia.Size = New System.Drawing.Size(61, 20)
        Me.txtDiariaItalia.TabIndex = 259
        Me.txtDiariaItalia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(222, 10)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(12, 20)
        Me.Label33.TabIndex = 258
        Me.Label33.Text = "€"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(141, 20)
        Me.Label10.TabIndex = 208
        Me.Label10.Text = "Costo Km"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCostoKm
        '
        Me.txtCostoKm.Location = New System.Drawing.Point(159, 10)
        Me.txtCostoKm.Name = "txtCostoKm"
        Me.txtCostoKm.Size = New System.Drawing.Size(61, 20)
        Me.txtCostoKm.TabIndex = 207
        Me.txtCostoKm.Text = "123.99"
        Me.txtCostoKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvActivities
        '
        Me.dgvActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActivities.Location = New System.Drawing.Point(4, 4)
        Me.dgvActivities.Name = "dgvActivities"
        Me.dgvActivities.Size = New System.Drawing.Size(253, 403)
        Me.dgvActivities.TabIndex = 277
        '
        'mnu
        '
        Me.mnu.Location = New System.Drawing.Point(-1, -2)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(135, 447)
        Me.mnu.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(270, 439)
        Me.TabControl1.TabIndex = 156
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtCostoKm)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtTrasfertaEsteroLunga)
        Me.TabPage1.Controls.Add(Me.Label33)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtDiariaItalia)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtTrasfertaEstero)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtDiariaEstero)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtTrasfertaItalia)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(262, 413)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Parametri"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage2.Controls.Add(Me.dgvActivities)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(262, 413)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Attività"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage3.Controls.Add(Me.dgvSectors)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(262, 413)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Settori"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvSectors
        '
        Me.dgvSectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSectors.Location = New System.Drawing.Point(4, 4)
        Me.dgvSectors.Name = "dgvSectors"
        Me.dgvSectors.Size = New System.Drawing.Size(253, 403)
        Me.dgvSectors.TabIndex = 278
        '
        'frmParamsConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 458)
        Me.Controls.Add(Me.panMenu)
        Me.Controls.Add(Me.panOreLavoro)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParamsConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmParamsConfig"
        Me.panMenu.ResumeLayout(False)
        Me.panOreLavoro.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvActivities, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvSectors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panMenu As Panel
    Friend WithEvents mnu As ucMenu
    Friend WithEvents panOreLavoro As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCostoKm As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTrasfertaItalia As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDiariaEstero As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDiariaItalia As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTrasfertaEsteroLunga As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTrasfertaEstero As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtFestaMese As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtFestaGiorno As TextBox
    Friend WithEvents dgvActivities As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgvSectors As DataGridView
End Class
