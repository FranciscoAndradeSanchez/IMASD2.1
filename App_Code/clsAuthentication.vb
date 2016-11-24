Imports Microsoft.VisualBasic
Imports System.Web
Imports System
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class clsAuthentication

    Public Enum AuthenticationStatusList
        NotAuthenticated = -1
        NotValidUser = 0
        NotValidPassword = 1
        NotValidEmail = 2
        Autheticated = 3
    End Enum

    Public Enum DatabaseResults
        None = 0
        Updated = 1
        Inserted = 2
        Deleted = 3
        PwdUpdated = 4
        PwdReseted = 5
        NotUpdated = 6
        NotInserted = 7
        NotDeleted = 8
        PwdNotUpdated = 9
        PwdNotReseted = 10
        ExistingUsr = 11
        ExistingEmail = 12
    End Enum

    Public Enum AuthorizationLevelList
        None = -1
        Consulting = 1
        Financial = 2
        Administering = 3
        LimitedUpdating = 4
    End Enum

    Private intAuthenticationStatus As Integer = AuthenticationStatusList.NotAuthenticated
    Private intAuthorizationLevel As Integer = AuthorizationLevelList.None
    Private intDatabaseResult As Integer = DatabaseResults.None
    Private strSQLDatabaseConexion As String = String.Empty
    Private strUsr As String = String.Empty
    Private strName As String = String.Empty
    Private strFirstSurname As String = String.Empty
    Private strSecondSurname As String = String.Empty
    Private intGrade As Integer = -1
    Private intInstitution As Integer = -1
    Private strDepartment As String = String.Empty
    Private strProfession As String = String.Empty
    Private strOccupation As String = String.Empty
    Private strEmail As String = String.Empty
    Private intInformationUsing As Integer = -1
    Private intAccessLevel As Integer = AuthorizationLevelList.None
    Private strState As String = String.Empty
    Private strPassword As String = String.Empty
    Private strNewPassword As String = String.Empty
    Private strSalt As String = String.Empty
    Private strConfirmationHash As String = String.Empty
    Private strURLResetPassword As String = String.Empty

    Public Sub New()
        MyBase.New()
    End Sub

    Public ReadOnly Property AthenticationStatus() As Integer
        Get
            Return intAuthenticationStatus
        End Get
    End Property

    Public ReadOnly Property AuthorizationLevel() As Integer
        Get
            Return intAuthorizationLevel
        End Get
    End Property

    Public Property UserName() As String
        Get
            Return (strUsr)
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New ArgumentException("El nombre de usuario no puede ser una cadena vacía")
            ElseIf value.Length > 15 Then
                Throw New ArgumentException("El nombre de usuario no puede exceder a quince carácteres")
            End If
            strUsr = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return (strName)
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New ArgumentException("El nombre del usuario no puede ser una cadena vacía")
            ElseIf value.Length > 50 Then
                Throw New ArgumentException("El nombre del usuario no puede exceder a cincuenta carácteres")
            End If
            strName = value
        End Set
    End Property

    Public Property FirstSurname() As String
        Get
            Return (strFirstSurname)
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New ArgumentException("El apellido paterno del usuario no puede ser una cadena vacía")
            ElseIf value.Length > 30 Then
                Throw New ArgumentException("El apellido paterno del usuario no puede exceder a treinta carácteres")
            End If
            strFirstSurname = value
        End Set
    End Property

    Public Property SecondSurname() As String
        Get
            Return (strSecondSurname)
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New ArgumentException("El apellido materno del usuario no puede ser una cadena vacía")
            ElseIf value.Length > 30 Then
                Throw New ArgumentException("El apellido materno del usuario no puede exceder a treinta carácteres")
            End If
            strSecondSurname = value
        End Set
    End Property

    Public Property Grade() As Integer
        Get
            Return intGrade
        End Get
        Set(ByVal value As Integer)
            intGrade = value
        End Set
    End Property

    Public Property Institution() As Integer
        Get
            Return (intInstitution)
        End Get
        Set(ByVal value As Integer)
            intInstitution = value
        End Set
    End Property

    Public Property Department() As String
        Get
            Return (strDepartment)
        End Get
        Set(ByVal value As String)
            'If value = String.Empty Then
            '    Throw New ArgumentException("El departamento no puede ser una cadena vacía")
            'ElseIf value.Length > 150 Then
            '    Throw New ArgumentException("El departamento no puede exceder a ciento cincuenta carácteres")
            'End If
            strDepartment = value
        End Set
    End Property

    Public Property Profession() As String
        Get
            Return (strProfession)
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New ArgumentException("La profesión no puede ser una cadena vacía")
            ElseIf value.Length > 100 Then
                Throw New ArgumentException("La profesión no puede exceder a cien carácteres")
            End If
            strProfession = value
        End Set
    End Property

    Public Property Occupation() As String
        Get
            Return (strOccupation)
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New ArgumentException("La ocupación no puede ser una cadena vacía")
            ElseIf value.Length > 100 Then
                Throw New ArgumentException("La ocupación no puede exceder a cien carácteres")
            End If
            strOccupation = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return (strEmail)
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New ArgumentException("Correo electrónico no puede ser una cadena vacía")
            ElseIf value.Length > 100 Then
                Throw New ArgumentException("Correo electrónico no puede exceder a cien carácteres")
            End If
            strEmail = value
        End Set
    End Property

    Public Property InformationUsing() As Integer
        Get
            Return (intInformationUsing)
        End Get
        Set(ByVal value As Integer)
            intInformationUsing = value
        End Set
    End Property

    Public Property AccesLevel() As Integer
        Get
            Return (intAccessLevel)
        End Get
        Set(ByVal value As Integer)
            intAccessLevel = value
        End Set
    End Property

    Public Property State() As String
        Get
            Return (strState)
        End Get
        Set(ByVal value As String)
            strState = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return (strPassword)
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New ArgumentException("La contraseña no puede ser una cadena vacía")
            ElseIf value.Length > 20 Then
                Throw New ArgumentException("La contraseña no puede exceder a veinte carácteres")
            End If
            strPassword = value
        End Set
    End Property

    Public Property newPassword() As String
        Get
            Return strNewPassword
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New ArgumentException("La contraseña nueva no puede ser una cadena vacía")
            ElseIf value.Length > 20 Then
                Throw New ArgumentException("La contraseña nueva no puede exceder a veinte carácteres")
            End If
            strNewPassword = value
        End Set
    End Property

    Public WriteOnly Property ConfirmationHash() As String
        Set(ByVal value As String)
            If value.Length > 255 Then
                strConfirmationHash = value.Substring(0, 255)
            Else
                strConfirmationHash = value
            End If
        End Set
    End Property

    Public Property URLResetPassword() As String
        Get
            Return strURLResetPassword
        End Get
        Set(ByVal value As String)
            strURLResetPassword = value
        End Set
    End Property

    Public Function NewUser() As Integer
        Return RegisterUser()
    End Function

    Public Function NewUser(ByVal User As String, ByVal Name As String, _
    ByVal FirstSurname As String, ByVal SecondSurname As String, ByVal Grade As Integer, _
    ByVal Institution As Int16, ByVal Department As String, ByVal Profession As String, _
    ByVal Occupation As String, ByVal Email As String, ByVal InformationUsing As Integer, _
    ByVal AccessLevel As Integer, ByVal State As String, _
    ByVal Password As String) As Integer

        strUsr = User
        strName = Name
        strFirstSurname = FirstSurname
        strSecondSurname = SecondSurname
        intGrade = Grade
        intInstitution = Institution
        strDepartment = Department
        strProfession = Profession
        strOccupation = Occupation
        strEmail = Email
        intInformationUsing = InformationUsing
        intAccessLevel = AccessLevel
        strState = State
        strPassword = Password
        Return RegisterUser()

    End Function

    Public Function DeleteUser() As Integer
        Return UnregisterUser()
    End Function

    Public Function DeleteUser(ByVal Email As String) As Integer
        strEmail = Email
        Return UnregisterUser()
    End Function

    Public Function AuthenticateUser() As Integer
        Return ValidateUser()
    End Function

    Public Function AuthenticateUser(ByVal User As String, ByVal Password As String) As Integer
        strUsr = User
        strPassword = Password
        Return ValidateUser()
    End Function

    Public Function AuthenticateEmail() As Integer
        Return ValidateUserUsingEmail()
    End Function

    Public Function AuthenticateEmail(ByVal Email As String, ByVal Hash As String) As Integer
        strEmail = Email
        strConfirmationHash = Hash
        Return ValidateUserUsingEmail()
    End Function

    Public Function ResetPassword() As Integer
        Return RestorePassword()
    End Function

    Public Function ResetPassword(ByVal Email As String, ByVal Hash As String, ByVal newPassword As String) As Integer
        strEmail = Email
        strConfirmationHash = Hash
        strPassword = newPassword
        Return RestorePassword()
    End Function

    Public Function ChangePassword() As Integer
        Return SetNewPassword()
    End Function

    Public Function ChangePassword(ByVal User As String, ByVal Password As String, ByVal NewPassword As String) As Integer
        strUsr = User
        strPassword = Password
        strNewPassword = NewPassword
        Return SetNewPassword()
    End Function

    Public Function ModifyUser() As Integer
        Return UpdateUser()
    End Function

    Public Function ModifyUser(ByVal User As String) As Integer
        Return UpdateUser()
    End Function

    Public Function SendResetConfirmation(ByVal Email As String) As Integer
        strEmail = Email
        If ValidateUserUsingEmail() = AuthenticationStatusList.Autheticated Then
            Return SendConfirmationEmail()
        End If
    End Function


    Protected Function SetNewPassword() As Integer
        If strUsr = String.Empty Then
            Throw New ArgumentException("El nombre de usuario no puede ser una cadena vacía")
        ElseIf strUsr.Length > 15 Then
            Throw New ArgumentException("El nombre de usuario no puede exceder a quince carácteres")
        End If
        If strPassword = String.Empty Then
            Throw New ArgumentException("Contraseña nueva del usuario no puede ser una cadena vacía")
        ElseIf strPassword.Length > 20 Then
            Throw New ArgumentException("Contraseña nueva del usuario no puede exceder a veinte carácteres")
        End If
        If strNewPassword = String.Empty Then
            Throw New ArgumentException("Contraseña anterior del usuario no puede ser una cadena vacía")
        ElseIf strNewPassword = String.Empty Then
            Throw New ArgumentException("Contraseña anterior del usuario no puede exceder a veinte carácteres")
        End If



        Dim intResult As Int16 = -1
       

        Dim taUsers As New dsUsuariosTableAdapters.CatUsuarioTableAdapter


        Dim slthHashingPWD As New clsSaltedHashing()

        Try
            If ValidateUser() = AuthenticationStatusList.Autheticated Then

                slthHashingPWD.Original = strNewPassword
                strNewPassword = slthHashingPWD.Hashed
                intResult = taUsers.CambiarContrasenia(strNewPassword, slthHashingPWD.Salt, strUsr)
                If intResult = 1 Then
                    intDatabaseResult = DatabaseResults.PwdUpdated
                Else
                    intDatabaseResult = DatabaseResults.PwdNotUpdated
                End If
            Else
                intDatabaseResult = DatabaseResults.PwdNotUpdated
            End If
        Catch ex As Exception
            intDatabaseResult = DatabaseResults.PwdNotUpdated
        Finally
            taUsers.Dispose()
        End Try

        Return intDatabaseResult
    End Function

    Protected Function RestorePassword() As Integer
        If strEmail = String.Empty Then
            Throw New ArgumentException("El correo electrónico del usuario no puede ser una cadena vacía")
        ElseIf strEmail.Length > 100 Then
            Throw New ArgumentException("El correo electrónico del usuario no puede exceder a cien carácteres")
        End If
        If strConfirmationHash = String.Empty Then
            Throw New ArgumentException("Hash de confirmación no puede ser una cadena vacía")
        ElseIf strConfirmationHash.Length > 255 Then
            Throw New ArgumentException("Hash de confirmación no puede exceder a doscientos cincuenta y cinco carácteres")
        End If
        If strPassword = String.Empty Then
            Throw New ArgumentException("Contraseña nueva del usuario no puede ser una cadena vacía")
        ElseIf strPassword.Length > 20 Then
            Throw New ArgumentException("Contraseña nueva del usuario no puede exceder a veinte carácteres")
        End If

        Dim intResult As Int16 = -1

        Dim taUsers As New dsUsuariosTableAdapters.CatUsuarioTableAdapter()
        Dim slthHashingPWD As New clsSaltedHashing()

        Try
            If ValidateUserUsingEmail() = AuthenticationStatusList.Autheticated Then

                slthHashingPWD.Original = strPassword
                strPassword = slthHashingPWD.Hashed

                intResult = taUsers.ReiniciarContrasenia(slthHashingPWD.Hashed, slthHashingPWD.Salt, strEmail, strConfirmationHash)

                If intResult = 1 Then
                    intDatabaseResult = DatabaseResults.PwdUpdated
                Else
                    intDatabaseResult = DatabaseResults.PwdNotUpdated
                End If
            Else
                intDatabaseResult = DatabaseResults.PwdNotUpdated
            End If
        Catch ex As Exception
            intDatabaseResult = DatabaseResults.PwdNotUpdated
        Finally
            taUsers.Dispose()
        End Try

        Return intDatabaseResult
    End Function

    Protected Function SendConfirmationEmail() As Integer

        Dim envcCorreo As New clsEnviarCorreo
        Dim sltdhRandomStr As New clsSaltedHashing
        Dim intResult As Integer = AuthenticationStatusList.NotValidEmail

        envcCorreo.remitente = System.Web.Configuration.WebConfigurationManager.AppSettings("Remitente").ToString
        envcCorreo.destinatarios = Email
        sltdhRandomStr.Original = Email
        sltdhRandomStr.Original = sltdhRandomStr.Hashed
        sltdhRandomStr.Original = sltdhRandomStr.Salt
        strConfirmationHash = sltdhRandomStr.Hashed
        If SaveConfirmationHash() = DatabaseResults.Updated Then
            envcCorreo.asunto = "Confirmación de reinicio de contraseña"
            envcCorreo.Cuerpo = "<p>Estimado usuario,<p>Hemos recibido su solicitud para reiniciar " & _
                            "su contraseña del Sistema de Información y Consulta de Proyectos de Investigación " & _
                            "y Desarrollo de la Comisión Nacional Forestal.</p><p>Para confirmar dicha solicitud " & _
                            "le rogamos que vaya a la dirección electrónica siguiente </p><p><a href=""" & _
                            System.Web.Configuration.WebConfigurationManager.AppSettings("URLResetPWD").ToString & _
                            "?hash=" & strConfirmationHash & "&email=" & Email & """>" & _
                            System.Web.Configuration.WebConfigurationManager.AppSettings("URLResetPWD").ToString & _
                            "?hash=" & strConfirmationHash & "&email=" & Email & "</a></p>" & _
                            "<p>Si el hipervínculo no funciona copie y pegue el texto en la barra de direcciones de su explorador.</p>"
            envcCorreo.ServidorSMTP = System.Web.Configuration.WebConfigurationManager.AppSettings("ServidorMail").ToString
            envcCorreo.PortSMTP = System.Web.Configuration.WebConfigurationManager.AppSettings("ServidorMailPORT").ToString
            envcCorreo.Dominio = System.Web.Configuration.WebConfigurationManager.AppSettings("NombreDominio").ToString
            envcCorreo.usuario = System.Web.Configuration.WebConfigurationManager.AppSettings("Usuario").ToString
            envcCorreo.contrasenia = System.Web.Configuration.WebConfigurationManager.AppSettings("PWDUsuario").ToString
            envcCorreo.TextoDesuscribir = "<p>Has recibido este correo porque estas registrado en un servicio que ofrece la Comisión Nacional Forestal</p>" & _
                        "<p>Si deseas terminar tu suscripción a dicho servicio por favor ingresa a esta dirección</p><p><a href=""" & _
                        System.Web.Configuration.WebConfigurationManager.AppSettings("URLDesuscribir").ToString & _
                        """>" & System.Web.Configuration.WebConfigurationManager.AppSettings("URLDesuscribir").ToString & "</a></p>"
            envcCorreo.EnviarCorreo()
            intResult = AuthenticationStatusList.Autheticated
        End If
        Return intResult
    End Function

    Protected Function SaveConfirmationHash() As Integer
        If strConfirmationHash = String.Empty Then
            Throw New ArgumentException("Hash de confirmación no puede ser una cadena vacía")
        ElseIf strConfirmationHash.Length > 255 Then
            Throw New ArgumentException("Hash de confirmación no puede exceder a doscientos cincuenta y cinco carácteres")
        End If
        If strEmail = String.Empty Then
            Throw New ArgumentException("Correo electrónico es obligatorio")
        ElseIf strEmail.Length > 100 Then
            Throw New ArgumentException("Correo electrónico no puede ser una cadena de mas de cien caracteres")
        End If

        Dim intResult As Integer = -1
        Dim taConfirmationHash As New dsUsuariosTableAdapters.CatUsuarioTableAdapter
        Try
            intResult = taConfirmationHash.HashConfirmacion(strConfirmationHash, strEmail)

            If intResult = 0 Then
                intDatabaseResult = DatabaseResults.NotUpdated
            Else
                intDatabaseResult = DatabaseResults.Updated
            End If
        Catch exRegistro As Exception
            If exRegistro.Message.Contains("PK_CatUsuario") Then
                intDatabaseResult = DatabaseResults.ExistingUsr
            ElseIf exRegistro.Message.Contains("IX_Correo") Then
                intDatabaseResult = DatabaseResults.ExistingEmail
            Else
                intDatabaseResult = DatabaseResults.NotUpdated
            End If
        Finally
            taConfirmationHash.Dispose()

        End Try
        Return intDatabaseResult

    End Function



    Protected Function ValidateUserUsingEmail() As Integer
        If strEmail = String.Empty Then
            Throw New ArgumentException("El nombre de usuario no puede ser una cadena vacía")
        End If
        If strEmail.Length > 100 Then
            Throw New ArgumentException("El nombre de usuario no puede exceder los cien caracteres")
        End If
        If strConfirmationHash.Length > 255 Then
            Throw New ArgumentException("La cadena de confirmacion no puede exceder los doscientos cincuenta y cinco caracteres")
        End If


        Dim taUsers As New dsUsuariosTableAdapters.CatUsuarioTableAdapter
        Dim dtblUsers As New dsUsuarios.CatUsuarioDataTable

        Try

            dtblUsers = taUsers.GetDataByEmail(strEmail)
            If dtblUsers.Rows.Count = 0 Then
                intAuthenticationStatus = AuthenticationStatusList.NotValidEmail
            ElseIf dtblUsers.Rows.Count = 1 Then
                If Not (strConfirmationHash = String.Empty) Then
                    If strConfirmationHash = dtblUsers.Rows(0)(dtblUsers.HashConfirmacionColumn.ColumnName) Then
                        intAuthenticationStatus = AuthenticationStatusList.Autheticated
                    Else
                        intAuthenticationStatus = AuthenticationStatusList.NotAuthenticated
                    End If
                Else
                    intAuthenticationStatus = AuthenticationStatusList.Autheticated
                End If
            End If

        Catch ex As Exception
            intAuthenticationStatus = AuthenticationStatusList.NotAuthenticated
        Finally
            taUsers.Dispose()
            dtblUsers.Dispose()
        End Try

        Return intAuthenticationStatus
    End Function

    Protected Function ValidateUser() As Integer
        If strUsr = String.Empty Then
            Throw New ArgumentException("El nombre de usuario no puede ser una cadena vacía")
        End If
        If strUsr.Length > 15 Then
            Throw New ArgumentException("El nombre de usuario no puede exceder los dieciseis caracteres")
        End If
        If strPassword = String.Empty Then
            Throw New ArgumentException("Contraseña del usuario no puede ser una cadena vacía")
        End If
        If strPassword.Length > 20 Then
            Throw New ArgumentException("Contraseña del usuario no puede exceder los veinte caracteres")
        End If

        Dim adapUsers As New dsUsuariosTableAdapters.CatUsuarioTableAdapter
        Dim dtblUsers As New dsUsuarios.CatUsuarioDataTable

        Try
            Dim slthHashingPWD As New clsSaltedHashing()
            dtblUsers = adapUsers.GetDataByCveUsuario(strUsr)
            If dtblUsers.Rows.Count = 0 Then
                intAuthenticationStatus = AuthenticationStatusList.NotAuthenticated
            Else
                If Not IsDBNull(dtblUsers.Rows(0)(dtblUsers.SaltColumn.ColumnName)) Then
                    slthHashingPWD.Salt = dtblUsers.Rows(0)(dtblUsers.SaltColumn.ColumnName)
                    slthHashingPWD.Original = strPassword
                    Dim strStoredHashedPassword As String = dtblUsers.Rows(0)(dtblUsers.PasswordColumn.ColumnName)

                    If strStoredHashedPassword = slthHashingPWD.Hashed Then
                        intAuthenticationStatus = AuthenticationStatusList.Autheticated
                        Name = dtblUsers.Rows(0)(dtblUsers.NombreColumn.ColumnName) & " " & _
                            dtblUsers.Rows(0)(dtblUsers.APaternoColumn.ColumnName) & " " & _
                            dtblUsers.Rows(0)(dtblUsers.AmaternoColumn.ColumnName)
                        AccesLevel = dtblUsers.Rows(0)(dtblUsers.NivelColumn.ColumnName)
                    Else
                        intAuthenticationStatus = AuthenticationStatusList.NotValidPassword
                    End If
                Else
                    intAuthenticationStatus = AuthenticationStatusList.NotAuthenticated
                End If
            End If

        Catch ex As Exception

            intAuthenticationStatus = AuthenticationStatusList.NotAuthenticated

        Finally

            adapUsers.Dispose()
            dtblUsers.Dispose()

        End Try

        Return intAuthenticationStatus
    End Function

    Protected Function RegisterUser() As Integer
        If strUsr = String.Empty Then
            Throw New ArgumentException("Usuario es obligatorio")
        ElseIf strUsr.Length > 15 Then
            Throw New ArgumentException("Usuario no puede ser una cadena de mas de quince caracteres")
        End If
        If strName = String.Empty Then
            Throw New ArgumentException("Nombre del usuario es obligatorio")
        ElseIf strName.Length > 50 Then
            Throw New ArgumentException("Nombre del usuario no puede ser una cadena de mas de cincuenta caracteres")
        End If
        If strName = String.Empty Then
            Throw New ArgumentException("Apellido paterno del usuario es obligatorio")
        ElseIf strName.Length > 30 Then
            Throw New ArgumentException("Apellido paterno no puede ser una cadena de mas de treinta caracteres")
        End If
        If strName.Length > 30 Then
            Throw New ArgumentException("Apellido materno no puede ser una cadena de mas de treinta caracteres")
        End If
        If intGrade = -1 Then
            Throw New ArgumentException("Escolaridad es obligatoria")
        End If
        If intInstitution = -1 Then
            Throw New ArgumentException("Institución es obligatoria")
        End If
        'If strDepartment = String.Empty Then
        '   Throw New ArgumentException("Departamento es obligatorio")
        'ElseIf strName.Length > 150 Then
        '   Throw New ArgumentException("Departamento no puede ser una cadena de mas de ciento cincuenta caracteres")
        'End If
        If strProfession = String.Empty Then
            Throw New ArgumentException("Profesión es obligatoria")
        ElseIf strProfession.Length > 100 Then
            Throw New ArgumentException("Profesión no puede ser una cadena de mas de cien caracteres")
        End If
        If strOccupation = String.Empty Then
            Throw New ArgumentException("Ocupación es obligatoria")
        ElseIf strOccupation.Length > 100 Then
            Throw New ArgumentException("Ocupación no puede ser una cadena de mas de cien caracteres")
        End If
        If strEmail = String.Empty Then
            Throw New ArgumentException("Correo electrónico es obligatorio")
        ElseIf strEmail.Length > 100 Then
            Throw New ArgumentException("Correo electrónico no puede ser una cadena de mas de cien caracteres")
        End If
        If intInformationUsing = -1 Then
            Throw New ArgumentException("Uso de la información es obligatorio")
        End If
        If intAccessLevel = -1 Then
            Throw New ArgumentException("Nivel de acceso del usuario es obligatorio")
        End If
        If strState = String.Empty Then
            Throw New ArgumentException("Estado es obligatorio")
        ElseIf strState.Length > 2 Then
            Throw New ArgumentException("Estado no puede ser una cadena de mas de dos caracteres")
        End If
        If strPassword = String.Empty Then
            Throw New ArgumentException("Contraseña es obligatoria")
        ElseIf strPassword.Length > 20 Then
            Throw New ArgumentException("Contrasena no puede ser una cadena de mas de veinte caracteres")
        End If

        Dim intResultado As Integer = -1
        Dim slthHashingPWD As New clsSaltedHashing()
        Dim taRegistrar As New dsUsuariosTableAdapters.CatUsuarioTableAdapter

        slthHashingPWD.Original = strPassword

        Try
            intResultado = taRegistrar.Insert(strUsr, strName, strFirstSurname, strSecondSurname, _
                                intGrade, intInstitution, strDepartment, strOccupation, _
                                strProfession, strEmail, intInformationUsing, intAccessLevel, _
                                slthHashingPWD.Hashed, slthHashingPWD.Salt, _
                                strConfirmationHash, strState)
            If intResultado = 0 Then
                intDatabaseResult = DatabaseResults.NotInserted
            ElseIf intResultado = 1 Then
                intDatabaseResult = DatabaseResults.Inserted
            End If
        Catch exRegistro As Exception
            If exRegistro.Message.Contains("PK_CatUsuario") Then
                intDatabaseResult = DatabaseResults.ExistingUsr
            ElseIf exRegistro.Message.Contains("IX_Correo") Then
                intDatabaseResult = DatabaseResults.ExistingEmail
            Else
                intDatabaseResult = DatabaseResults.NotInserted
            End If
        Finally
            taRegistrar.Dispose()
        End Try
        Return intDatabaseResult
    End Function

    Protected Function UnregisterUser() As Integer
        If strEmail = String.Empty Then
            Throw New ArgumentException("Correo electrónico es obligatorio")
        ElseIf strEmail.Length > 100 Then
            Throw New ArgumentException("Correo electrónico no puede ser una cadena de mas de cien caracteres")
        End If

        Dim taUsuarios As New dsUsuariosTableAdapters.CatUsuarioTableAdapter
        Try
            If taUsuarios.TerminarSuscripcion(strEmail) = 0 Then
                intDatabaseResult = DatabaseResults.Deleted
            End If
        Catch exRegistro As Exception
            intDatabaseResult = DatabaseResults.NotDeleted
        Finally
            taUsuarios.Dispose()
        End Try
        Return intDatabaseResult

    End Function

    Protected Function UpdateUser() As Integer
        If strUsr = String.Empty Then
            Throw New ArgumentException("Usuario es obligatorio")
        ElseIf strUsr.Length > 15 Then
            Throw New ArgumentException("Usuario no puede ser una cadena de mas de quince caracteres")
        End If
        If strName = String.Empty Then
            Throw New ArgumentException("Nombre del usuario es obligatorio")
        ElseIf strName.Length > 50 Then
            Throw New ArgumentException("Nombre del usuario no puede ser una cadena de mas de cincuenta caracteres")
        End If
        If strName = String.Empty Then
            Throw New ArgumentException("Apellido paterno del usuario es obligatorio")
        ElseIf strName.Length > 30 Then
            Throw New ArgumentException("Apellido paterno no puede ser una cadena de mas de treinta caracteres")
        End If
        If strName.Length > 30 Then
            Throw New ArgumentException("Apellido materno no puede ser una cadena de mas de treinta caracteres")
        End If
        If intGrade = -1 Then
            Throw New ArgumentException("Escolaridad es obligatoria")
        End If
        If intInstitution = -1 Then
            Throw New ArgumentException("Institución es obligatoria")
        End If
        'If strDepartment = String.Empty Then
        '    Throw New ArgumentException("Departamento es obligatorio")
        'ElseIf strName.Length > 150 Then
        '    Throw New ArgumentException("Departamento no puede ser una cadena de mas de ciento cincuenta caracteres")
        'End If
        If strProfession = String.Empty Then
            Throw New ArgumentException("Profesión es obligatoria")
        ElseIf strProfession.Length > 100 Then
            Throw New ArgumentException("Profesión no puede ser una cadena de mas de cien caracteres")
        End If
        If strOccupation = String.Empty Then
            Throw New ArgumentException("Ocupación es obligatoria")
        ElseIf strOccupation.Length > 100 Then
            Throw New ArgumentException("Ocupación no puede ser una cadena de mas de cien caracteres")
        End If
        If strEmail = String.Empty Then
            Throw New ArgumentException("Correo electrónico es obligatorio")
        ElseIf strEmail.Length > 100 Then
            Throw New ArgumentException("Correo electrónico no puede ser una cadena de mas de cien caracteres")
        End If
        If intInformationUsing = -1 Then
            Throw New ArgumentException("Uso de la información es obligatorio")
        End If
        If intAccessLevel = -1 Then
            Throw New ArgumentException("Nivel de acceso del usuario es obligatorio")
        End If
        If strState = String.Empty Then
            Throw New ArgumentException("Estado es obligatorio")
        ElseIf strState.Length > 2 Then
            Throw New ArgumentException("Estado no puede ser una cadena de mas de dos caracteres")
        End If
        If strPassword = String.Empty Then
            Throw New ArgumentException("Contraseña es obligatoria")
        ElseIf strPassword.Length > 20 Then
            Throw New ArgumentException("Contrasena no puede ser una cadena de mas de veinte caracteres")
        End If

        Dim intResultado As Integer = -1
        Dim slthHashingPWD As New clsSaltedHashing()
        Dim taActualizar As New dsUsuariosTableAdapters.CatUsuarioTableAdapter
        slthHashingPWD.Original = strPassword

        Try
            intResultado = taActualizar.Update(strUsr, strName, strFirstSurname, strSecondSurname, _
                                intGrade, intInstitution, strDepartment, strOccupation, _
                                strProfession, strEmail, intInformationUsing, intAccessLevel, _
                                slthHashingPWD.Hashed, slthHashingPWD.Salt, _
                                strConfirmationHash, strState, strUsr)
            If intResultado = 0 Then
                intDatabaseResult = DatabaseResults.NotUpdated
            ElseIf intResultado = 1 Then
                intDatabaseResult = DatabaseResults.Updated
            End If
        Catch exRegistro As Exception
            If exRegistro.Message.Contains("PK_CatUsuario") Then
                intDatabaseResult = DatabaseResults.ExistingUsr
            ElseIf exRegistro.Message.Contains("IX_Correo") Then
                intDatabaseResult = DatabaseResults.ExistingEmail
            Else
                intDatabaseResult = DatabaseResults.NotUpdated
            End If
        Finally
            taActualizar.Dispose()
        End Try
        Return intDatabaseResult
    End Function

    'Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema

    'End Function

    'Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml

    'End Sub

    'Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml

    'End Sub
End Class


