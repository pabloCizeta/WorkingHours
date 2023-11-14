Imports Core

Public Class ucViewOreLavoroData

    Public Property OreLavoro As New TimeSpan
    Public Property OreViaggio As New TimeSpan

    Public Sub LoadData(dtData As DataTable)


        If IsNothing(dtData) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
            OreLavoro = New TimeSpan
            OreViaggio = New TimeSpan
        Else
            If dtData.Rows.Count > 0 Then
                dgv.DataSource = dtData
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                dgv.RowHeadersWidth = 10
                dgv.Columns(0).Width = 80
                dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(1).Width = 200
                dgv.Columns(2).Width = 120
                dgv.Columns(3).Width = 100
                dgv.Columns(4).Width = 60
                dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(5).Width = 60
                dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Dim ore As udtOre = GetOre(dtData, 4, 5)
                OreViaggio = ore.Viaggio
                OreLavoro = ore.Lavoro
            End If
        End If

    End Sub


End Class
