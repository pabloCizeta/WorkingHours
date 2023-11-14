Public Class Configuration

    Public Class udtAppConfig
        Private ser As Serialization
        Private FileNameXml As String

        Public Class udtSqlConnectionConfig
            Public Property Name As String = ""
            Public Property Enabled As Boolean = False
            Public Property ServerIpAddress As String = "127.0.0.0"
            Public Property DatabaseName As String = ""
            Public Property ConnectionString As String = ""
            Public Property Catalog As String = ""
            Public Property ServerName As String = ""
            Public Property UsedID As String = ""
            Public Property Password As String = ""
            Public Sub New()
            End Sub
            Public Overloads Function DeepCopy() As udtSqlConnectionConfig
                Dim other As udtSqlConnectionConfig = DirectCast(Me.MemberwiseClone(), udtSqlConnectionConfig)
                Return other
            End Function

        End Class

        Public Class udtParams
            Public Property SqlConnections As New List(Of udtSqlConnectionConfig)
            Public Sub New()
            End Sub
            Public Overloads Function DeepCopy() As udtParams
                Dim other As udtParams = DirectCast(Me.MemberwiseClone(), udtParams)
                other.SqlConnections = New List(Of udtSqlConnectionConfig)
                For Each item As udtSqlConnectionConfig In SqlConnections
                    other.SqlConnections.Add(item.DeepCopy)
                Next
                Return other
            End Function
        End Class

        Public Property Params As New udtParams

        Public Sub New()
        End Sub
        Public Sub New(ByVal ConfigFileName As String)
            FileNameXml = ConfigFileName
            Params = New udtParams
            ser = New Serialization(ConfigFileName, Params)
            ser.IgnoreEnabled = True
        End Sub
        Public Function ReadDataFromFile() As String

            Dim ret As String = String.Empty
            Try
                Params = ser.Deserialize()
                ret = ser.Result
            Catch ex As Exception
                ret = ex.Message
            Finally
            End Try
            Return ret

        End Function
        Public Sub WriteDataToFile()
            ser.Serialize()
        End Sub

    End Class

    Public Class MenusConfig

        Private ser As Serialization
        Private FileNameXml As String

        Public Enum enumButtonType
            Push
            Switch
        End Enum

        Public Class udtMenuButtonConfig
            Public Property Name As String = ""
            Public Property ImageFileName As String = ""
            Public Property Text As New TextsManagement.udtMultiLanguageText
            Public Property HotKey As String = ""
            Public Property Enabled As Boolean = False
            Public Property Type As enumButtonType = enumButtonType.Push
            Public Property EnabledUsers As New List(Of Users.enumUserRole)
            Public Sub New()
            End Sub
            Public Overloads Function DeepCopy() As udtMenuButtonConfig
                Dim other As udtMenuButtonConfig = DirectCast(Me.MemberwiseClone(), udtMenuButtonConfig)
                other.Text = Text.DeepCopy
                other.EnabledUsers.Clear()
                For Each item As Users.enumUserRole In EnabledUsers
                    other.EnabledUsers.Add(item)
                Next
                Return other
            End Function
        End Class

        Public Class udtMenu
            Public Property Name As String = ""
            Public Property Heading As New TextsManagement.udtMultiLanguageText
            Public Property FunctionKeyEnabled As Boolean = True
            Public Property Buttons As New List(Of udtMenuButtonConfig)
            Public Sub New()
            End Sub
            Public Overloads Function DeepCopy() As udtMenu
                Dim other As udtMenu = DirectCast(Me.MemberwiseClone(), udtMenu)
                other.Heading = Heading.DeepCopy
                other.Buttons.Clear()
                For Each item As udtMenuButtonConfig In Buttons
                    other.Buttons.Add(item)
                Next
                Return other
            End Function
        End Class

        Public Class udtFormMenus
            Public Property FormName As String = ""
            Public Property PicturesFolder As String = ""
            Public Property Menus As New List(Of udtMenu)
            Public Sub New()
            End Sub
            Public Overloads Function DeepCopy() As udtFormMenus
                Dim other As udtFormMenus = DirectCast(Me.MemberwiseClone(), udtFormMenus)
                other.Menus.Clear()
                For Each item As udtMenu In Menus
                    other.Menus.Add(item)
                Next
                Return other
            End Function
        End Class


        Public Property Forms As New List(Of udtFormMenus)

        Public Sub New()

        End Sub
        Public Sub New(ByVal ConfigFileName As String)
            FileNameXml = ConfigFileName
            Forms = New List(Of udtFormMenus)
            ser = New Serialization(ConfigFileName, Forms)
            ser.IgnoreEnabled = True
        End Sub
        Public Function ReadDataFromFile() As String

            Dim ret As String = String.Empty

            Try
                Forms = ser.Deserialize()
                ret = ser.Result

            Catch ex As Exception
                ret = ex.Message
            Finally
            End Try

            Return ret

        End Function

        Public Sub WriteDataToFile()
            ser.Serialize()
        End Sub

    End Class

    Public Property OreLavoro As New DatabaseManagement.udtConfigurations
    Public Property App As New udtAppConfig
    Public Property Menus As New MenusConfig


    Public Sub New()

    End Sub

    Public Function ReadAppConfig(ByVal AppConfigFileName As String) As Boolean
        App = New udtAppConfig(AppConfigFileName)
        If App.ReadDataFromFile() <> "" Then Return False

        Return True
    End Function

    Public Function ReadMenusConfig(ByVal MenusConfigFileName As String) As Boolean
        Menus = New MenusConfig(MenusConfigFileName)

        If Menus.ReadDataFromFile() <> "" Then Return False

        Return True
    End Function

    Public Function GetMenus(FormName As String) As List(Of Configuration.MenusConfig.udtMenu)

        For Each item As MenusConfig.udtFormMenus In Menus.Forms
            If item.FormName = FormName Then
                Return item.Menus
            End If
        Next
        Return Nothing
    End Function

    Public Function GetFormMenus(FormName As String) As Configuration.MenusConfig.udtFormMenus

        For Each item As MenusConfig.udtFormMenus In Menus.Forms
            If item.FormName = FormName Then
                Return item
            End If
        Next
        Return Nothing
    End Function


    Public Function GetSqlConnection(ByVal Name As String) As udtAppConfig.udtSqlConnectionConfig
        For Each item As udtAppConfig.udtSqlConnectionConfig In App.Params.SqlConnections
            If item.Name = Name Then

                Dim arystr As String() = item.ConnectionString.Split(";")
                For i = 0 To arystr.Count - 1
                    If arystr(i).Contains("Server=") Then
                        item.ServerName = arystr(i).Substring(arystr(i).LastIndexOf("=") + 1)
                    End If
                    If arystr(i).Contains("User ID=") Then
                        item.UsedID = arystr(i).Substring(arystr(i).LastIndexOf("=") + 1)
                    End If
                    If arystr(i).Contains("Password=") Then
                        item.Password = arystr(i).Substring(arystr(i).LastIndexOf("=") + 1)
                    End If
                    If arystr(i).Contains("Initial Catalog =") Then
                        item.Catalog = arystr(i).Substring(arystr(i).LastIndexOf("=") + 1)
                    End If
                Next

                Return item
            End If
        Next
        Return Nothing
    End Function



End Class
