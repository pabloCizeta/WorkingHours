Imports Core

Public Class frmMain


#Region "Private data"

    Private Const cOrderSeparator = "----------"

    Private WithEvents tmrVisual As Windows.Forms.Timer
    Private WithEvents tmrVisualFast As Windows.Forms.Timer

    Private dtOreLavoro As New DataTable

    Private LastDateShown As Date = Now

    Private CheckInputData As Core.CheckInputData

    Private dtpDateChanging As Boolean = False


#End Region


#Region " Form events "

    Private Sub frmMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtLoginName.Focus()

    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub frmMain_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim EndProgramForced As Boolean = False

        xGlobals = New Globals

        Dim DiskDrive As String = System.IO.Path.GetPathRoot(System.Windows.Forms.Application.StartupPath)

        Dim DiskApplication As String = Application.StartupPath.Replace("\App", "")

        'xGlobals.DataPath = Application.StartupPath & "\..\Data\"
        'xGlobals.DatabasePath = Application.StartupPath & "\..\Database\"
        'xGlobals.PicturePath = Application.StartupPath & "\..\Data\Pictures\"

        xGlobals.DataPath = DiskApplication & "\Data\"
        xGlobals.DatabasePath = DiskApplication & "\Database\"
        xGlobals.PicturePath = DiskApplication & "\Data\Pictures\"


        xGlobals.Release = String.Format("Rev. {0}.{1}.{2}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
        lblRelease.Text = xGlobals.Release
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release

        'Config
        xConfig = New Configuration
        If Not xConfig.ReadAppConfig(xGlobals.DataPath & "myConfig.xml") Then EndProgramForced = True
        If Not xConfig.ReadMenusConfig(xGlobals.DataPath & "Menus.xml") Then EndProgramForced = True
        If EndProgramForced Then
            MsgBox("Lettura configurazione fallita", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End
        End If


        '**********************************************
        '... e vai con il database...
        '********************************************** 
        Application.DoEvents()
        If Not CheckConnectionsToDatabases() Then
            MsgBox("Connessione ad database fallita", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End
        End If

        xDatabase = New DatabaseManagement()



        'Users
        xUsers = New Users()
        xUsers.LevelsForUserRole = "1"
        xUsers.LevelsForMaintenanceRole = "1"
        xUsers.LevelsForAdministratorRole = "1"


        'Configurazione ore lavoro (da database)
        xConfig.OreLavoro = xDatabase.GetConfigurations



        CheckInputData = New Core.CheckInputData()


        KeyPreview = True

        ' dgvOreLavoro.Rows.Clear()

        'Start chaos
        tmrVisual = New Windows.Forms.Timer
        tmrVisual.Enabled = True
        tmrVisual.Interval = 2000
        tmrVisualFast = New Windows.Forms.Timer
        tmrVisualFast.Enabled = True
        tmrVisualFast.Interval = 50

        'Me.Size = New Size(841, 682)
        'panOreLavoro.Size = New Size(676, 638)
        'panOreLavoro.Location = New Point(-10000, 3)
        'panMenu.Location = New Point(-10000, 3)
        'panLogin.Location = New Point(220, 50)
        'panLogin.Size = New Size(395, 423)
        ' panOreLavoro.Enabled = False
        panMenu.Enabled = False

        panUserLogged.Location = New Point(-10000, 329)
        panUserLogged.Size = New Size(328, 100)

        'Try
        '    mnu.CreateMenu(Me, xConfig.GetFormMenus(MyBase.Name))
        'Catch ex As Exception

        'End Try

    End Sub




#End Region


#Region "Private"

    Private Function CreateEventSource() As Boolean

        Try
            If Not EventLog.SourceExists(Application.ProductName) Then
                ' Create the source, if it does not already exist.
                ' An event log source should not be created and immediately used.
                ' There is a latency time to enable the source, it should be created
                ' prior to executing the application that uses the source.
                ' Execute this sample a second time to use the new source.
                EventLog.CreateEventSource(Application.ProductName, "UnhandledException")
                'The source is created.  Exit the application to allow it to be registered.
                Return False
            Else
                ' EventLog.DeleteEventSource(Application.ProductName)
                ' EventLog.Delete("UnhandledException")
            End If
        Catch ex As Exception

        End Try

        Return True

    End Function


    Private Function CheckConnectionsToDatabases() As Boolean

        'Test connections
        For Each item As Configuration.udtAppConfig.udtSqlConnectionConfig In xConfig.App.Params.SqlConnections
            If item.Enabled Then
                Dim dbTest As New Core.czDatabase
                If dbTest.CheckConnection(item.ConnectionString) Then
                Else
                    Dim sMsg As String = "Problems On Connecting Database" & " " & item.DatabaseName & vbCrLf
                    sMsg += " - " & dbTest.Status
                    MsgBox(sMsg, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                    Return False
                End If
            End If
        Next

        Return True
    End Function


#End Region

#Region "Gestione Login"

    Private Sub frmMain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        If (sender.ActiveControl.Name = "txtLoginName") Or (sender.ActiveControl.Name = "txtPassword") Then
            If e.KeyChar = vbCr Then
                plsLogin_Click(sender, New EventArgs)
            End If

        End If
    End Sub

    Private Sub plsLogin_Click(sender As Object, e As EventArgs) Handles plsLogin.Click

        If xUsers.Login(txtLoginName.Text, txtPassword.Text) Then
            lblInfo.Visible = False
            Login()
            mnu.CreateMenu(Me, xConfig.GetFormMenus(MyBase.Name))
            mnu.ShowMenu("Main")
        Else
            ' The user name/password is invalid.
            lblInfo.Visible = True
            If Not xUsers.IsLoginNameOK(txtLoginName.Text) Then
                lblInfo.Text = "WrongUser"
                txtLoginName.Focus()
                txtLoginName.SelectAll()
            Else
                lblInfo.Text = "WrongPassword"
                txtPassword.Focus()
                txtPassword.SelectAll()
            End If
        End If

    End Sub

    Private Sub txtLoginName_TextChanged(sender As Object, e As EventArgs) Handles txtLoginName.TextChanged
        lblInfo.Visible = False
    End Sub

    Private Sub Login()
        Me.lblLoginName.Text = xUsers.UserLogged.Name
        Me.lblUserRole.Text = xUsers.UserLogged.Role.ToString
        picUserLogged.Image = xUsers.UserLogged.Photo

        'panOreLavoro.Location = New Point(146, 3)
        'panLogin.Location = New Point(-10000, 166)

        panMenu.Location = New Point(4, 3)
        panUserLogin.Location = New Point(-10000, 329)
        panUserLogged.Location = New Point(26, 329)


        'panOreLavoro.Enabled = True
        panMenu.Enabled = True

        'LoadEmpolyeeComboBox()
        'LoadOrdersComboBox("%")
        'LoadActivityComboBox()
        'LoadSectorComboBox()

        'cboEmployeeName.Text = xUsers.UserLogged.Name

        'LoadData()

    End Sub

    Private Sub Logout()

        'Scarica tutte le form eccetto me
        Dim frm() As Form
        Dim iFrm As Integer = 0
        ReDim Preserve frm(iFrm)
        Try
            For Each f As Form In My.Application.OpenForms
                Select Case f.Name
                    Case Me.Name
                    Case Else
                        'f.Close()
                        ReDim Preserve frm(iFrm)
                        frm(iFrm) = f
                        iFrm += 1
                End Select
            Next

            For iFrm = 0 To iFrm - 1
                frm(iFrm).Close()
            Next

        Catch ex As Exception

        End Try

        'panOreLavoro.Location = New Point(-10000, 3)
        'panLogin.Location = New Point(220, 50)
       ' panMenu.Location = New Point(-10000, 3)

        panUserLogin.Location = New Point(26, 329)
        panUserLogged.Location = New Point(-10000, 329)

        txtLoginName.Text = ""
        txtPassword.Text = ""
        txtLoginName.Focus()
        'panOreLavoro.Enabled = False
        panMenu.Enabled = False

    End Sub

#End Region


#Region "Timers"

    Private Sub tmrVisual_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrVisual.Tick




    End Sub

    Private Sub tmrVisualFast_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrVisualFast.Tick




    End Sub


#End Region

#Region "Menu"

    Private Sub mnu_ButtonClick(MenuName As String, ButtonName As String, Checked As CheckState) Handles mnu.ButtonClick
        Select Case MenuName
            Case "Main"
                MenuMainButtonPressed(ButtonName)

            Case "Config"
                MenuConfigButtonPressed(ButtonName)

        End Select

    End Sub

    Private Sub MenuMainButtonPressed(ButtonName As String)

        Select Case ButtonName
            Case "OreLavoro"
                mnu.SuspendMenu()
                Dim frm As New frmWorkingDiary
                frm.Show(Me)
                'frm.Dispose()
                'frm = Nothing
                mnu.ActivateMenuSuspended()

            Case "Refound"
                mnu.SuspendMenu()
                Dim frm As New frmExpenses
                frm.Show(Me)
                'frm.Dispose()
                'frm = Nothing
                mnu.ActivateMenuSuspended()

            Case "Orders"
                mnu.SuspendMenu()
                Dim frm As New frmOrders
                frm.ShowDialog(Me)
                frm.Dispose()
                frm = Nothing
                mnu.ActivateMenuSuspended()


            Case "Config"
                mnu.ShowMenu("Config")

            Case "Logout"
                Logout()


            Case "End"
                Me.Close()
        End Select



    End Sub

    Private Sub MenuConfigButtonPressed(ButtonName As String)

        Select Case ButtonName
            Case "Back", "Escape", "Close"
                mnu.ShowMenu("Main")

            Case "Employees"
                mnu.SuspendMenu()
                Dim frm As New frmEmployeesConfig  '   frmUsers
                frm.ShowDialog(Me)
                frm.Dispose()
                frm = Nothing
                mnu.ActivateMenuSuspended()

            Case "Parametri"
                mnu.SuspendMenu()
                Dim frm As New frmParamsConfig
                frm.ShowDialog(Me)
                frm.Dispose()
                frm = Nothing
                mnu.ActivateMenuSuspended()


        End Select



    End Sub




#End Region



#Region "Check data input"

    Private Sub SelectOnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        'sender.SelectAll()
    End Sub
    Private Sub OnlyTimeOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyTime(sender, e.KeyChar)
    End Sub
    Private Sub OnlyRealOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyNumber(sender, e.KeyChar, "+")
    End Sub


    Private Function CheckData() As Boolean

        'If Not CheckInputData.IsTime(txtOreLavoro) Then Return False
        'If Not CheckInputData.IsTime(txtOreViaggio) Then Return False

        'If cboOrderName.Text = cOrderSeparator Then
        '    CheckInputData.NokResult = CheckInputData.enumNokResult.ValoreErrato
        '    cboOrderName.Focus()
        '    cboOrderName.BackColor = Color.Coral
        '    Return False
        'End If

        Return True

    End Function

    'Private Sub cboOrderName_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    cboOrderName.BackColor = Color.White
    'End Sub



    'Private Sub cboOrderName_DropDown(sender As Object, e As EventArgs)
    '    cboOrderName.BackColor = Color.White
    'End Sub


#End Region






End Class
