Imports Core

Public Class frmCambioSettore
    Public Property Sector As String

    Private Sub frmCambioSettore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Cambio settore"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        lblSector.Text = Sector
        LoadSectorComboBox()
    End Sub

    Private Sub LoadSectorComboBox()
        'Load orders
        cboSector.Items.Clear()
        Dim Sectors As New List(Of String)
        Sectors = xDatabase.GetSectorList()
        For Each str As String In Sectors
            cboSector.Items.Add(str.ToUpper)
        Next
    End Sub

    Private Sub plsConfirm_Click(sender As Object, e As EventArgs) Handles plsConfirm.Click
        DialogResult = DialogResult.OK
        Sector = cboSector.Text
    End Sub

    Private Sub plsCancel_Click(sender As Object, e As EventArgs) Handles plsCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class