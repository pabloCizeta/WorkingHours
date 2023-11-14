Imports Core

Public Class frmCambioNomeCommessa

    Private Const cOrderSeparator = "----------"

    Public Property OrderName As String

    Private Sub frmCambioNomeCommessa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Cambio nome commessa"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        lblCommessa.Text = OrderName
        LoadOrdersComboBox("%")

    End Sub


    Private Sub LoadOrdersComboBox(Filter As String)
        LoadOrdersComboBox(Filter, False)

    End Sub
    Private Sub LoadOrdersComboBox(Filter As String, ShowValue As Boolean)
        cboOrderName.Items.Clear()
        cboOrderName.Items.Add("Nuova")
        cboOrderName.Items.Add("Ferie")
        cboOrderName.Items.Add("Mutua")
        cboOrderName.Items.Add(cOrderSeparator)
        Dim orders As New List(Of String)
        orders = xDatabase.GetOrderList(Filter)
        For Each str As String In orders
            cboOrderName.Items.Add(str)
        Next
        If ShowValue Then
            If orders.Count > 0 Then
                cboOrderName.Text = orders(0)
            End If
        End If
    End Sub

    Private Sub plsFilter_Click(sender As Object, e As EventArgs) Handles plsFilter.Click
        Using dlg As New frmFilter
            If dlg.ShowDialog() = DialogResult.OK Then
                LoadOrdersComboBox(dlg.Filter & "%", True)
            End If
        End Using
    End Sub

    Private Sub cboOrderName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrderName.SelectedIndexChanged
        If cboOrderName.Text = "Nuova" Then
            Dim OrderNameAdded As String = ""
            Dim frm As New frmOrders
            frm.ShowDialog(Me)
            OrderNameAdded = frm.OrderNameAdded
            frm.Dispose()
            frm = Nothing

            LoadOrdersComboBox("%")
            cboOrderName.Text = OrderNameAdded
        End If
    End Sub

    Private Sub plsConfirm_Click(sender As Object, e As EventArgs) Handles plsConfirm.Click
        If cboOrderName.Text = "" Then
            MsgBox("Nome commessa non valido!")
            Return
        End If
        DialogResult = DialogResult.OK
        OrderName = cboOrderName.Text
        Me.Close()
    End Sub

    Private Sub plsCancel_Click(sender As Object, e As EventArgs) Handles plsCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub


End Class