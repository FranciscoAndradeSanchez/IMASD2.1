Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.Web.Security
Imports System

Public Class clsSaltedHashing

    Private Const intTamSalt As Integer = 15

    Private strOriginal As String = String.Empty
    Private strSalt As String = String.Empty
    Private bytSalt(intTamSalt) As Byte
    Private strHashed As String = String.Empty

    Public Sub New()
        MyBase.New()
    End Sub

    Public Property Salt() As String
        Get
            Return strSalt
        End Get
        Set(ByVal value As String)
            strSalt = value
        End Set
    End Property

    Public WriteOnly Property Original() As String
        Set(ByVal value As String)
            strOriginal = value
        End Set
    End Property

    Public ReadOnly Property Hashed() As String
        Get
            Return Hashed_String()
        End Get
    End Property

    Protected Function Hashed_String() As String
        If strSalt = String.Empty Then
            Dim rngCryptoPrvdr As New RNGCryptoServiceProvider()
            rngCryptoPrvdr.GetBytes(bytSalt)
            strSalt = Convert.ToBase64String(bytSalt)
        End If
        Hashed_String = FormsAuthentication.HashPasswordForStoringInConfigFile(strSalt & strOriginal, "SHA1")
    End Function

End Class
