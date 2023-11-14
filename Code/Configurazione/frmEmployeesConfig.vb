Imports Core
Imports System.Data.SqlClient

Public Class frmEmployeesConfig

    Private CheckInputData As Core.CheckInputData

    Private dtData As DataTable


    Private Sub frmEmployeesConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Configurazione dipendenti"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        Call ShowMenu()

        CheckInputData = New Core.CheckInputData()

        LoadData()

    End Sub

    Private Sub LoadData()

        dgv.RowTemplate.Height = 22

        dtData = xDatabase.ReadEmployeesConfig()

        If IsNothing(dtData) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
        Else
            dgv.DataSource = dtData 'bsTrace
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgv.RowHeadersWidth = 24
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
                        mnu.SuspendMenu()
                        Me.Cursor = Cursors.WaitCursor
                        xDatabase.WriteEmployeesConfig(dtData)
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
    Private Sub OnlyIntegerOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyInteger(sender, e.KeyChar, "+")
    End Sub
    Private Sub OnlyRealOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyNumber(sender, e.KeyChar, "+")
    End Sub


    Private Function CheckData() As Boolean

        Return True

    End Function


#End Region

End Class