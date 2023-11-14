Imports Core

Public Class frmCambioAttivita

    Public Property Activity As String

    Private Sub frmCambioAttivita_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Cambio attività"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        lblActivity.Text = Activity
        LoadActivityComboBox()

    End Sub

    Private Sub LoadActivityComboBox()
        'Load orders
        cboActivity.Items.Clear()
        Dim Activity As New List(Of String)
        Activity = xDatabase.GetActivityList()
        For Each str As String In Activity
            cboActivity.Items.Add(str.ToUpper)
        Next
    End Sub


    Private Sub plsConfirm_Click(sender As Object, e As EventArgs) Handles plsConfirm.Click
        DialogResult = DialogResult.OK
        Activity = cboActivity.Text
    End Sub

    Private Sub plsCancel_Click(sender As Object, e As EventArgs) Handles plsCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub


End Class