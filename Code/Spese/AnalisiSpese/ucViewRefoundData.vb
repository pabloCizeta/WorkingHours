Imports Core
Public Class ucViewRefoundData

    Public Property SpesaTotale As Single = 0.0
    Public Sub LoadData(dtData As DataTable)


        If IsNothing(dtData) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
            SpesaTotale = 0.0
        Else
            If dtData.Rows.Count > 0 Then
                SpesaTotale = 0.0
                dgv.DataSource = dtData
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                dgv.RowHeadersWidth = 10
                'Nome
                dgv.Columns(0).Width = 140
                dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Data
                dgv.Columns(1).Width = 100
                dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Commessa
                dgv.Columns(2).Width = 140
                dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Località
                dgv.Columns(3).Width = 90
                dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'KM
                dgv.Columns(4).Width = 50
                dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Autostrada
                dgv.Columns(5).Width = 80
                dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Mezzi
                dgv.Columns(6).Width = 40
                dgv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Vitto
                dgv.Columns(7).Width = 40
                dgv.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Alloggio
                dgv.Columns(8).Width = 50
                dgv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Varie
                dgv.Columns(9).Width = 40
                dgv.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                For iRow As Integer = 0 To dtData.Rows.Count - 1
                    SpesaTotale += TextToSingle(dgv.Rows(iRow).Cells(5).Value) + TextToSingle(dgv.Rows(iRow).Cells(6).Value) + TextToSingle(dgv.Rows(iRow).Cells(7).Value) + TextToSingle(dgv.Rows(iRow).Cells(8).Value) + TextToSingle(dgv.Rows(iRow).Cells(9).Value)
                Next



            End If
        End If

    End Sub

End Class
