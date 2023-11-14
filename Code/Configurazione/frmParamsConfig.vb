Imports System.Data.SqlClient
Imports Core

Public Class frmParamsConfig

    Private CheckInputData As Core.CheckInputData

    Private ActivityAdapter As New SqlDataAdapter
    Dim ActivityTable As New DataTable


    Private Sub frmParamsConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Configurazione parametri"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        Call ShowMenu()

        CheckInputData = New Core.CheckInputData()

        xConfig.OreLavoro = xDatabase.GetConfigurations

        LoadDataIntoControls()


    End Sub


    Private Sub LoadDataIntoControls()

        txtCostoKm.Text = Format(xConfig.OreLavoro.CostoKm, "#0.00")
        txtDiariaItalia.Text = Format(xConfig.OreLavoro.DiariaItalia, "#0.00")
        txtDiariaEstero.Text = Format(xConfig.OreLavoro.DiariaEstero, "#0.00")
        txtTrasfertaItalia.Text = Format(xConfig.OreLavoro.TrasfertaItalia, "#0.00")
        txtTrasfertaEstero.Text = Format(xConfig.OreLavoro.TrasfertaEstero, "#0.00")
        txtTrasfertaEsteroLunga.Text = Format(xConfig.OreLavoro.TrasfertaEsteroWeekEnd, "#0.00")

        txtFestaGiorno.Text = xConfig.OreLavoro.FestaPatronale.Day
        txtFestaMese.Text = xConfig.OreLavoro.FestaPatronale.Month

        LoadActivities()
        LoadSectors()

    End Sub

    Private Sub LoadActivities()

        Try
            dgvActivities.DataSource = xDatabase.GetActivityTable
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadSectors()

        Try
            dgvSectors.DataSource = xDatabase.GetSectiorsTable
        Catch ex As Exception

        End Try

    End Sub


    Private Sub SaveControlsToData()

        If CheckData() Then
            xConfig.OreLavoro.CostoKm = TextToSingle(txtCostoKm.Text)
            xConfig.OreLavoro.DiariaItalia = TextToSingle(txtDiariaItalia.Text)
            xConfig.OreLavoro.DiariaEstero = TextToSingle(txtDiariaEstero.Text)
            xConfig.OreLavoro.TrasfertaItalia = TextToSingle(txtTrasfertaItalia.Text)
            xConfig.OreLavoro.TrasfertaEstero = TextToSingle(txtTrasfertaEstero.Text)
            xConfig.OreLavoro.TrasfertaEsteroWeekEnd = TextToSingle(txtTrasfertaEsteroLunga.Text)

            Dim year As Integer = Date.Now.Year
            Dim month As Integer = TextToInt(txtFestaMese.Text)
            Dim day As Integer = TextToInt(txtFestaGiorno.Text)
            xConfig.OreLavoro.FestaPatronale = New Date(year, month, day)

            xDatabase.WriteConfigurations(xConfig.OreLavoro)


            SaveActivities()
            SaveSectors()

        Else
            MsgBox("Dati non salvati", vbOKOnly)
        End If


    End Sub
    Private Sub SaveActivities()

        Dim Activities As New List(Of String)
        For Each r In dgvActivities.Rows
            If Not IsNothing(r.cells(0).value) Then
                If Not IsDBNull(r.cells(0).value) Then
                    If r.cells(0).value <> "" Then
                        Activities.Add(r.cells(0).value.ToString)
                    End If
                End If
            End If
        Next
        Try
            xDatabase.UpdateActivityTable(Activities)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SaveSectors()

        Dim Sectors As New List(Of String)
        For Each r In dgvSectors.Rows
            If Not IsNothing(r.cells(0).value) Then
                If Not IsDBNull(r.cells(0).value) Then
                    If r.cells(0).value <> "" Then
                        Sectors.Add(r.cells(0).value.ToString)
                    End If
                End If
            End If
        Next
        Try
            xDatabase.UpdateSectorsTable(Sectors)

        Catch ex As Exception

        End Try

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
                        mnu.SuspendMenu()
                        Me.Cursor = Cursors.WaitCursor
                        SaveControlsToData()
                        mnu.ActivateMenuSuspended()
                        Me.Cursor = Cursors.Default

                        Shut()
                End Select
        End Select

    End Sub

    Private Sub Shut()
        Me.Close()
        Me.Dispose()
    End Sub


#End Region


#Region "Check data input"

    Private Sub SelectOnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        sender.backcolor = Color.White
    End Sub
    Private Sub OnlyIntegerOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtFestaGiorno.KeyPress, txtFestaMese.KeyPress

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyInteger(sender, e.KeyChar, "+")
    End Sub
    Private Sub OnlyRealOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCostoKm.KeyPress, txtDiariaItalia.KeyPress, txtDiariaEstero.KeyPress,
            txtTrasfertaItalia.KeyPress, txtTrasfertaEstero.KeyPress, txtTrasfertaEsteroLunga.KeyPress

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyNumber(sender, e.KeyChar, "+")
    End Sub


    Private Function CheckData() As Boolean

        If Not CheckInputData.IsValueNumericOk(txtFestaMese, 1, 12) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtFestaGiorno, 1, 31) Then Return False
        Return True

    End Function


#End Region
End Class