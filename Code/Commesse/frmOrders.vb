Imports Core

Public Class frmOrders

    Private dt As New DataTable

    Private Filter As String = "%"

    Public Property OrderNameAdded As String = ""


    Private Sub frmOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Commesse"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        Call ShowMenu()
        Filter = "%"
        LoadData(Filter)

    End Sub


    Private Sub LoadData(Filter As String)

        dt = xDatabase.GetOrders(Filter)

        If IsNothing(dt) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
        Else
            dgv.DataSource = dt
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        End If

    End Sub

    Private Sub dgv_SelectionChanged(sender As Object, e As EventArgs) Handles dgv.SelectionChanged

        If dgv.SelectedRows.Count > 0 Then
            txtOrderName.Text = dgv.SelectedRows(0).Cells("Commessa").Value
            If IsDBNull(dgv.SelectedRows(0).Cells("Cliente").Value) Then
                txtCustomerName.Text = ""
            Else
                txtCustomerName.Text = dgv.SelectedRows(0).Cells("Cliente").Value
            End If
            chkOrdedEnded.Checked = dgv.SelectedRows(0).Cells("Terminata").Value
        Else

        End If

    End Sub




#Region "Menu"

    Private Sub ShowMenu()
        Try

            mnu.CreateMenu(Me, xConfig.GetFormMenus(MyBase.Name))
            mnu.ShowMenu("Main")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnu_ButtonClick(MenuName As String, ButtonName As String, Checked As CheckState) Handles mnu.ButtonClick
        Select Case MenuName
            Case "Main"
                Select Case ButtonName
                    Case "Close"
                        Call Shut()

                    Case "Save"
                        Write()

                    Case "Delete"
                        Delete()

                    Case "Filter"
                        mnu.SuspendMenu()
                        Using dlg As New frmFilter
                            If dlg.ShowDialog() = DialogResult.OK Then
                                Filter = dlg.Filter & "%"
                                LoadData(Filter)
                            End If
                        End Using
                        mnu.ActivateMenuSuspended()



                End Select
        End Select



    End Sub

    Private Sub Write()

        Dim rec As New DatabaseManagement.udtRecordOrder
        rec.OrderName = txtOrderName.Text
        rec.Customer = txtCustomerName.Text
        rec.Ended = chkOrdedEnded.Checked
        If xDatabase.OrderExists(rec.OrderName) Then
            If MsgBox("Dati esistenti. Vuoi sovrascriverli?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim RowSelected As Integer = dgv.SelectedRows(0).Index
                xDatabase.UpdateOrder(rec)
                LoadData(Filter)
                dgv.ClearSelection()
                dgv.Rows(RowSelected).Selected = True
                If RowSelected > 5 Then
                    dgv.FirstDisplayedScrollingRowIndex = RowSelected - 5
                Else
                    dgv.FirstDisplayedScrollingRowIndex = 0
                End If
            Else
            End If
        Else
            'Add new record
            xDatabase.AddOrder(rec)
            LoadData(Filter)
            dgv.ClearSelection()
            Dim RowIndex As Integer = 0
            For Each r As DataGridViewRow In dgv.Rows
                If r.Cells("Commessa").Value = rec.OrderName Then
                    r.Selected = True
                    RowIndex = r.Index
                End If
            Next
            If RowIndex > 5 Then
                dgv.FirstDisplayedScrollingRowIndex = RowIndex - 5
            Else
                dgv.FirstDisplayedScrollingRowIndex = 0
            End If
            OrderNameAdded = rec.OrderName
        End If

    End Sub

    Private Sub Delete()
        Dim rec As New DatabaseManagement.udtRecordOrder
        rec.OrderName = txtOrderName.Text
        rec.Customer = txtCustomerName.Text
        rec.Ended = chkOrdedEnded.Checked

        If xDatabase.OrderExists(rec.OrderName) Then
            If MsgBox("Cancello la commessa " & rec.OrderName & ". Sei DAVVERO sicuro?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim RowSelected As Integer = dgv.SelectedRows(0).Index
                xDatabase.DeleteOrder(rec.OrderName)
                LoadData(Filter )
            End If
        End If
    End Sub


    Private Sub Shut()
        Me.Close()
        Me.Dispose()
    End Sub


#End Region

End Class