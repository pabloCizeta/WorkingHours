
Imports Core
Public Class ucViewAllOrdersRefound

    Public Event ItemSelected(sender As ucViewAllOrdersRefound, EmployeeName As String, OrderName As String)
    Public Event DoubleClickOnItem(sender As ucViewAllOrdersRefound, EmployeeName As String, OrderName As String)

    Public Property SpesaTotale As Single = 0.0

    Public Sub LoadData(Filter As DatabaseManagement.udtFilterRefound)

        Dim dtData As New DataTable
        dtData = xDatabase.GetUserAnalysisRefound(Filter)


        If IsNothing(dtData) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
            SpesaTotale = 0.0
        Else
            If dtData.Rows.Count > 0 Then
                SpesaTotale = 0.0
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
                dgv.DefaultCellStyle.BackColor = Color.Lavender

                ''Add row for total
                'Dim iRowsToAdd As New List(Of Integer)
                'Dim act As String = ""
                'For iRow As Integer = 0 To dtData.Rows.Count - 1
                '    If act = "" Then
                '        act = dtData.Rows(iRow).Item(1).ToString
                '    End If
                '    If act <> dtData.Rows(iRow).Item(1).ToString Then
                '        act = dtData.Rows(iRow).Item(1).ToString
                '        iRowsToAdd.Add(iRow)
                '    End If
                'Next
                'iRowsToAdd.Add(dtData.Rows.Count)
                'iRowsToAdd.Reverse()
                'Dim bLastRow As Boolean = True
                'For Each iRow As Integer In iRowsToAdd
                '    Dim LastRow = dtData.NewRow
                '    LastRow.ItemArray = New String() {"", "", "", "Totale"}
                '    dtData.Rows.InsertAt(LastRow, iRow)
                '    If bLastRow Then
                '        bLastRow = False
                '    Else
                '        LastRow = dtData.NewRow
                '        LastRow.ItemArray = New String() {"", "", "", ""}
                '        dtData.Rows.InsertAt(LastRow, iRow + 1)
                '    End If
                'Next

                dgv.DataSource = dtData
                ' dgv.Sort(dgv.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                dgv.RowHeadersWidth = 10

                'Nome
                dgv.Columns(0).Width = 100
                dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Data
                dgv.Columns(1).Width = 180
                dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Commessa
                dgv.Columns(2).Width = 120
                dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Località
                dgv.Columns(3).Width = 80
                dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'KM
                dgv.Columns(4).Width = 60
                dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Autostrada
                dgv.Columns(5).Width = 50
                dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Mezzi
                dgv.Columns(6).Width = 40
                dgv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Vitto
                dgv.Columns(7).Width = 50
                dgv.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Alloggio
                dgv.Columns(8).Width = 50
                dgv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Varie
                dgv.Columns(9).Width = 50
                dgv.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


                For iRow As Integer = 0 To dtData.Rows.Count - 1
                    Dim f As New DatabaseManagement.udtFilterRefound
                    f.EmployeeName = dgv.Rows(iRow).Cells(0).Value.ToString
                    f.OrderName = dgv.Rows(iRow).Cells(1).Value.ToString
                    f.BeginDate = Filter.BeginDate
                    f.EndDate = Filter.EndDate

                    Dim dt As New DataTable
                    dt = xDatabase.GetUserAnalysisRefound(f)

                    SpesaTotale += TextToSingle(dgv.Rows(iRow).Cells(5).Value) + TextToSingle(dgv.Rows(iRow).Cells(6).Value) + TextToSingle(dgv.Rows(iRow).Cells(7).Value) + TextToSingle(dgv.Rows(iRow).Cells(8).Value) + TextToSingle(dgv.Rows(iRow).Cells(9).Value)
                    'If dgv.Rows(iRow).Cells(3).Value = "Totale" Then
                    '    dgv.Rows(iRow).Cells(4).Value = TimeSpanToText(OreLavoroTot)
                    '    dgv.Rows(iRow).Cells(5).Value = TimeSpanToText(OreViaggiotot)
                    '    OreLavoroTot = New TimeSpan
                    '    OreViaggiotot = New TimeSpan

                    '    dgv.Rows(iRow).Cells(0).Style.BackColor = Color.LightYellow
                    '    dgv.Rows(iRow).Cells(1).Style.BackColor = Color.LightYellow
                    '    dgv.Rows(iRow).Cells(2).Style.BackColor = Color.LightYellow
                    '    dgv.Rows(iRow).Cells(3).Style.BackColor = Color.LightYellow
                    '    dgv.Rows(iRow).Cells(4).Style.BackColor = Color.LightYellow
                    '    dgv.Rows(iRow).Cells(5).Style.BackColor = Color.LightYellow
                    'End If

                    'If dgv.Rows(iRow).Cells(3).Value = "" Then
                    '    dgv.Rows(iRow).Cells(4).Value = ""
                    '    dgv.Rows(iRow).Cells(5).Value = ""
                    '    dgv.Rows(iRow).Cells(0).Style.BackColor = Color.White
                    '    dgv.Rows(iRow).Cells(1).Style.BackColor = Color.White
                    '    dgv.Rows(iRow).Cells(2).Style.BackColor = Color.White
                    '    dgv.Rows(iRow).Cells(3).Style.BackColor = Color.White
                    '    dgv.Rows(iRow).Cells(4).Style.BackColor = Color.White
                    '    dgv.Rows(iRow).Cells(5).Style.BackColor = Color.White
                    'End If
                Next

            End If
        End If

    End Sub

    Private Sub dgv_DoubleClick(sender As Object, e As EventArgs) Handles dgv.DoubleClick
        RaiseEvent DoubleClickOnItem(Me, dgv.SelectedRows(0).Cells(0).Value, dgv.SelectedRows(0).Cells(1).Value)
    End Sub

    Private Sub dgv_SelectionChanged(sender As Object, e As EventArgs) Handles dgv.SelectionChanged
        Try
            RaiseEvent ItemSelected(Me, dgv.SelectedRows(0).Cells(0).Value, dgv.SelectedRows(0).Cells(1).Value)
        Catch ex As Exception

        End Try

    End Sub

End Class
