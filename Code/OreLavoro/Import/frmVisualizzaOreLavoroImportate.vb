Imports Core

Public Class frmVisualizzaOreLavoroImportate


    Public Property dtImport As New DataTable
    Public Property dtOreLavoro As New DataTable
    Public Property dgvPadre As DataGridView

    Private Sub frmVisualizzaOreLavoroImportate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Importa ore lavoro"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        ShowData()

    End Sub

    Private Sub ShowData()

        If IsNothing(dtImport) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
        Else
            dgv.DataSource = dtImport
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgv.RowHeadersWidth = 24
            dgv.RowHeadersVisible = False
            If dgv.ColumnCount > 1 Then
                dgv.Columns(0).Width = 50
                dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(1).Width = 230
                dgv.Columns(2).Width = 120
                dgv.Columns(3).Width = 100
                dgv.Columns(4).Width = 60
                dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(5).Width = 60
                dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

        End If

        For iRow As Integer = 0 To dgv.Rows.Count - 1
            If ExistIn(dgv.Rows(iRow), dtOreLavoro) Then
                For iCol As Integer = 0 To dgv.ColumnCount - 1
                    dgv.Rows(iRow).Cells(iCol).Style.BackColor = Color.Lime
                Next
            End If
        Next
        dgv.ClearSelection()

    End Sub

    Private Function ExistIn(row As DataGridViewRow, dt As DataTable) As Boolean
        Dim bRes As Boolean = True
        For iRow As Integer = 0 To dt.Rows.Count - 1
            bRes = True
            For iCol As Integer = 0 To dt.Columns.Count - 1
                If dt.Rows(iRow)(iCol) <> row.Cells(iCol).Value Then
                    bRes = False
                End If
            Next
            If bRes Then Return True
        Next
        Return False
    End Function

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        'dgvPadre.Rows.Add(dgv.Rows(e.RowIndex))
        Dim row As DataRow = dtOreLavoro.NewRow
        row("Giorno") = dgv.Rows(e.RowIndex).Cells(0).Value
        row("Commessa") = dgv.Rows(e.RowIndex).Cells(1).Value
        row("Attività") = dgv.Rows(e.RowIndex).Cells(2).Value
        row("Settore") = dgv.Rows(e.RowIndex).Cells(3).Value
        row("OreLavoro") = dgv.Rows(e.RowIndex).Cells(4).Value
        row("OreViaggio") = dgv.Rows(e.RowIndex).Cells(5).Value

        Dim customerRow() As Data.DataRow
        Dim sqlq As String = "Giorno = '" & dgv.Rows(e.RowIndex).Cells(0).Value & "'"
        sqlq = sqlq & " AND Commessa = '" & dgv.Rows(e.RowIndex).Cells(1).Value & "'"
        sqlq = sqlq & " AND Attività = '" & dgv.Rows(e.RowIndex).Cells(2).Value & "'"
        sqlq = sqlq & " AND Settore = '" & dgv.Rows(e.RowIndex).Cells(3).Value & "'"
        customerRow = dtOreLavoro.Select(sqlq)

        If customerRow.Count = 0 Then
            dtOreLavoro.Rows.Add(row)
        Else
            Dim result As DialogResult = MessageBox.Show("Confirm update?", "Title", MessageBoxButtons.YesNo)
            If (result = DialogResult.Yes) Then
                customerRow(0)("OreLavoro") = dgv.Rows(e.RowIndex).Cells(4).Value
                customerRow(0)("OreViaggio") = dgv.Rows(e.RowIndex).Cells(5).Value
            End If
        End If

        dgvPadre.Refresh()
        dgvPadre.Sort(dgvPadre.Columns("Giorno"), System.ComponentModel.ListSortDirection.Ascending)

        ShowData()

    End Sub

    Private Function FindRowInTable(ByVal table As DataTable, ValuesToFind As Object()) As DataRow
        'Dim findTheseVals As Object() = New Object(2) {}
        'findTheseVals(0) = "John"
        'findTheseVals(1) = "Smith"
        'findTheseVals(2) = "5 Main St."
        Dim foundRow As DataRow = table.Rows.Find(ValuesToFind)
        If foundRow IsNot Nothing Then
            ' Console.WriteLine(foundRow(1))
            Return foundRow(1)
        End If
        Return Nothing
    End Function

    Private Sub dgv_MouseUp(sender As Object, e As MouseEventArgs) Handles dgv.MouseUp
        dgv.ClearSelection()
        dgv.CurrentCell = Nothing
    End Sub
End Class