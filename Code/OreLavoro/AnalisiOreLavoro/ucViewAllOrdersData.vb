
Imports Core

Public Class ucViewAllOrdersData

    Public Property OreLavoro As New TimeSpan
    Public Property OreViaggio As New TimeSpan

    Public Event ItemSelected(sender As ucViewAllOrdersData, EmployeeName As String, OrderName As String, Activity As String, Sector As String)
    Public Event DoubleClickOnItem(sender As ucViewAllOrdersData, EmployeeName As String, OrderName As String, Activity As String, Sector As String)


    Public Sub LoadData(Filter As DatabaseManagement.udtFilterOreLavoro)

        Dim dtData As New DataTable
        dtData = xDatabase.GetWorkInProgressOrders(Filter)

        If IsNothing(dtData) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
            OreLavoro = New TimeSpan
            OreViaggio = New TimeSpan
        Else
            If dtData.Rows.Count > 0 Then

                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
                dgv.DefaultCellStyle.BackColor = Color.Lavender

                'Add row for total
                Dim iRowsToAdd As New List(Of Integer)
                Dim act As String = ""
                For iRow As Integer = 0 To dtData.Rows.Count - 1
                    If act = "" Then
                        act = dtData.Rows(iRow).Item(1).ToString
                    End If
                    If act <> dtData.Rows(iRow).Item(1).ToString Then
                        act = dtData.Rows(iRow).Item(1).ToString
                        iRowsToAdd.Add(iRow)
                    End If
                Next
                iRowsToAdd.Add(dtData.Rows.Count)
                iRowsToAdd.Reverse()
                Dim bLastRow As Boolean = True
                For Each iRow As Integer In iRowsToAdd
                    Dim LastRow = dtData.NewRow
                    LastRow.ItemArray = New String() {"", "", "", "Totale"}
                    dtData.Rows.InsertAt(LastRow, iRow)
                    If bLastRow Then
                        bLastRow = False
                    Else
                        LastRow = dtData.NewRow
                        LastRow.ItemArray = New String() {"", "", "", ""}
                        dtData.Rows.InsertAt(LastRow, iRow + 1)
                    End If
                Next

                dgv.DataSource = dtData
                ' dgv.Sort(dgv.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                dgv.RowHeadersWidth = 10

                Dim OreLavoroCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreLavoro", .HeaderText = "OreLavoro"}
                Dim OreViaggioCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreViaggio", .HeaderText = "OreViaggio"}
                dgv.Columns.AddRange(OreLavoroCol, OreViaggioCol)

                'Order
                dgv.Columns(0).Width = 200
                dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                'Acrivity
                dgv.Columns(1).Width = 120
                dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                'Sector
                dgv.Columns(2).Width = 120
                dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                'Nome
                dgv.Columns(3).Width = 150
                dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                Dim OreLavoroTot As New TimeSpan
                Dim OreViaggiotot As New TimeSpan

                OreLavoro = New TimeSpan
                OreViaggio = New TimeSpan
                For iRow As Integer = 0 To dtData.Rows.Count - 1
                    Dim f As New DatabaseManagement.udtFilterOreLavoro
                    f.EmployeeName = dgv.Rows(iRow).Cells(3).Value.ToString
                    f.OrderName = dgv.Rows(iRow).Cells(0).Value.ToString
                    f.Activity = dgv.Rows(iRow).Cells(1).Value.ToString
                    f.Sector = dgv.Rows(iRow).Cells(2).Value.ToString
                    f.BeginDate = Filter.BeginDate
                    f.EndDate = Filter.EndDate

                    Dim dt As New DataTable
                    dt = xDatabase.GetWorkedHours(f)
                    Dim ore As udtOre = GetOre(dt, 4, 5)
                    dgv.Rows(iRow).Cells(4).Value = TimeSpanToText(ore.Lavoro)
                    dgv.Rows(iRow).Cells(5).Value = TimeSpanToText(ore.Viaggio)

                    OreLavoro = OreLavoro.Add(ore.Lavoro)
                    OreViaggio = OreViaggio.Add(ore.Viaggio)

                    OreLavoroTot = OreLavoroTot.Add(ore.Lavoro)
                    OreViaggiotot = OreViaggiotot.Add(ore.Viaggio)
                    If dgv.Rows(iRow).Cells(3).Value = "Totale" Then
                        dgv.Rows(iRow).Cells(4).Value = TimeSpanToText(OreLavoroTot)
                        dgv.Rows(iRow).Cells(5).Value = TimeSpanToText(OreViaggiotot)
                        OreLavoroTot = New TimeSpan
                        OreViaggiotot = New TimeSpan

                        dgv.Rows(iRow).Cells(0).Style.BackColor = Color.LightYellow
                        dgv.Rows(iRow).Cells(1).Style.BackColor = Color.LightYellow
                        dgv.Rows(iRow).Cells(2).Style.BackColor = Color.LightYellow
                        dgv.Rows(iRow).Cells(3).Style.BackColor = Color.LightYellow
                        dgv.Rows(iRow).Cells(4).Style.BackColor = Color.LightYellow
                        dgv.Rows(iRow).Cells(5).Style.BackColor = Color.LightYellow
                    End If

                    If dgv.Rows(iRow).Cells(3).Value = "" Then
                        dgv.Rows(iRow).Cells(4).Value = ""
                        dgv.Rows(iRow).Cells(5).Value = ""
                        dgv.Rows(iRow).Cells(0).Style.BackColor = Color.White
                        dgv.Rows(iRow).Cells(1).Style.BackColor = Color.White
                        dgv.Rows(iRow).Cells(2).Style.BackColor = Color.White
                        dgv.Rows(iRow).Cells(3).Style.BackColor = Color.White
                        dgv.Rows(iRow).Cells(4).Style.BackColor = Color.White
                        dgv.Rows(iRow).Cells(5).Style.BackColor = Color.White
                    End If
                Next

            End If
        End If

    End Sub

    Public Sub LoadData(dtData As DataTable)

        If IsNothing(dtData) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
        Else
            If dtData.Rows.Count > 0 Then
                dgv.DataSource = dtData
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                dgv.RowHeadersWidth = 10

                Dim OreLavoro As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreLavoro", .HeaderText = "OreLavoro"}
                Dim OreViaggio As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreViaggio", .HeaderText = "OreViaggio"}
                dgv.Columns.AddRange(OreLavoro, OreViaggio)

                'Order
                dgv.Columns(0).Width = 200
                dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                'Acrivity
                dgv.Columns(1).Width = 120
                dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                'Sector
                dgv.Columns(2).Width = 120
                dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                'Nome
                dgv.Columns(3).Width = 150
                dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


            End If
        End If

    End Sub

    Private Sub dgv_DoubleClick(sender As Object, e As EventArgs) Handles dgv.DoubleClick
        RaiseEvent DoubleClickOnItem(Me, dgv.SelectedRows(0).Cells(3).Value, dgv.SelectedRows(0).Cells(0).Value, dgv.SelectedRows(0).Cells(1).Value, dgv.SelectedRows(0).Cells(2).Value)
    End Sub

    Private Sub dgv_SelectionChanged(sender As Object, e As EventArgs) Handles dgv.SelectionChanged
        Try
            RaiseEvent ItemSelected(Me, dgv.SelectedRows(0).Cells(3).Value, dgv.SelectedRows(0).Cells(0).Value, dgv.SelectedRows(0).Cells(1).Value, dgv.SelectedRows(0).Cells(2).Value)
        Catch ex As Exception

        End Try

    End Sub
End Class
