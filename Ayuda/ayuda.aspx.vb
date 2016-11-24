
Partial Class ayuda
    Inherits System.Web.UI.Page

    Public ReadOnly Property nivelAyuda() As Integer
        Get
            If (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) IsNot Nothing) Or _
               (Not (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) = String.Empty)) Then
                Select Case CInt(Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString))
                    Case clsAuthentication.AuthorizationLevelList.Consulting
                        Return 1
                    Case clsAuthentication.AuthorizationLevelList.LimitedUpdating
                        Return 2
                    Case clsAuthentication.AuthorizationLevelList.Administering
                        Return 3
                    Case clsAuthentication.AuthorizationLevelList.Financial
                        Return 4
                    Case Else
                        Return 1
                End Select
            Else
                Return 1
            End If
        End Get
    End Property
End Class
