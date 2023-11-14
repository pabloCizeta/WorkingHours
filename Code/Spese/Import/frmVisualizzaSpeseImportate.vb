Imports Core

Public Class frmVisualizzaSpeseImportate

    Public Property dtImport As New DataTable
    Public Property dtSpese As New DataTable
    Public Property dgvPadre As DataGridView

    Private Sub frmVisualizzaSpeseImportate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Importa spese e rimborsi"
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
            If dgv.ColumnCount > 12 Then
                dgv.Columns(0).Width = 40       'Giorno
                dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(1).Width = 180      'Commessa
                dgv.Columns(2).Width = 120      'Localita
                dgv.Columns(3).Width = 40       'KM
                dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(4).Width = 60       'autostrada
                dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(5).Width = 50       'Mezzi
                dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(6).Width = 40       'Vitto
                dgv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(7).Width = 50       'Alloggio
                dgv.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(8).Width = 50       'Varie
                dgv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(9).Width = 50       'Carta
                dgv.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(10).Width = 40       'Valuta
                dgv.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(11).Width = 30       'Rimborso
                dgv.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(12).Width = 30       'Motivo
                dgv.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(13).Width = 40       'Diaria
                'dgv.Columns(13).Visible = False
                dgv.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

        End If

        For iRow As Integer = 0 To dgv.Rows.Count - 1
            If ExistIn(dgv.Rows(iRow), dtSpese) Then
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
        Dim row As DataRow = dtSpese.NewRow
        row("Giorno") = dgv.Rows(e.RowIndex).Cells(0).Value
        row("Commessa") = dgv.Rows(e.RowIndex).Cells(1).Value
        row("Località") = dgv.Rows(e.RowIndex).Cells(2).Value
        row("Km") = dgv.Rows(e.RowIndex).Cells(3).Value
        row("Autostrada") = dgv.Rows(e.RowIndex).Cells(4).Value
        row("Mezzi") = dgv.Rows(e.RowIndex).Cells(5).Value
        row("Vitto") = dgv.Rows(e.RowIndex).Cells(6).Value
        row("Alloggio") = dgv.Rows(e.RowIndex).Cells(7).Value
        row("Varie") = dgv.Rows(e.RowIndex).Cells(8).Value
        row("Carta") = dgv.Rows(e.RowIndex).Cells(9).Value
        row("Valuta") = dgv.Rows(e.RowIndex).Cells(10).Value
        row("R") = dgv.Rows(e.RowIndex).Cells(11).Value
        row("M") = dgv.Rows(e.RowIndex).Cells(12).Value
        row("Diaria") = dgv.Rows(e.RowIndex).Cells(13).Value


        Dim customerRow() As Data.DataRow
        Dim sqlq As String = "Giorno = '" & dgv.Rows(e.RowIndex).Cells(0).Value & "'"
        sqlq = sqlq & " AND Commessa = '" & dgv.Rows(e.RowIndex).Cells(1).Value & "'"
        sqlq = sqlq & " AND Località = '" & dgv.Rows(e.RowIndex).Cells(2).Value & "'"
        customerRow = dtSpese.Select(sqlq)

        If customerRow.Count = 0 Then
            dtSpese.Rows.Add(row)
        Else
            Dim result As DialogResult = MessageBox.Show("Confirm update?", "Title", MessageBoxButtons.YesNo)
            If (result = DialogResult.Yes) Then
                customerRow(0)("Km") = dgv.Rows(e.RowIndex).Cells(3).Value
                customerRow(0)("Autostrada") = dgv.Rows(e.RowIndex).Cells(4).Value
                customerRow(0)("Mezzi") = dgv.Rows(e.RowIndex).Cells(5).Value
                customerRow(0)("Vitto") = dgv.Rows(e.RowIndex).Cells(6).Value
                customerRow(0)("Alloggio") = dgv.Rows(e.RowIndex).Cells(7).Value
                customerRow(0)("Varie") = dgv.Rows(e.RowIndex).Cells(8).Value
                customerRow(0)("Carta") = dgv.Rows(e.RowIndex).Cells(9).Value
                customerRow(0)("Valuta") = dgv.Rows(e.RowIndex).Cells(10).Value
                customerRow(0)("R") = dgv.Rows(e.RowIndex).Cells(11).Value
                customerRow(0)("M") = dgv.Rows(e.RowIndex).Cells(12).Value
                customerRow(0)("Diaria") = dgv.Rows(e.RowIndex).Cells(13).Value
            End If
        End If

        dgvPadre.Refresh()
        dgvPadre.Sort(dgvPadre.Columns("Giorno"), System.ComponentModel.ListSortDirection.Ascending)

        ShowData()

    End Sub

    Private Sub dgv_MouseUp(sender As Object, e As MouseEventArgs) Handles dgv.MouseUp
        dgv.ClearSelection()
        dgv.CurrentCell = Nothing
    End Sub

End Class