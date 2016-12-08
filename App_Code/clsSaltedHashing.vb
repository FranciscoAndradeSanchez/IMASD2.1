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
            Try
                'Dim rngCryptoPrvdr As New RNGCryptoServiceProvider()
                'rngCryptoPrvdr.GetBytes(bytSalt)
                'strSalt = Convert.ToBase64String(bytSalt)
                Dim result As String = String.Empty
                Dim decryted As Byte() = Convert.FromBase64String(strOriginal)
                'result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                result = System.Text.Encoding.Unicode.GetString(decryted)
                Return result
            Catch ex As Exception

            End Try
        End If
        Hashed_String = encrypt(strOriginal)
        'Hashed_String = Decrypt(strOriginal, "SHA1")
    End Function

    'Protected Function Hashed_String() As String
    '    If strSalt = String.Empty Then
    '        Dim rngCryptoPrvdr As New RNGCryptoServiceProvider()
    '        rngCryptoPrvdr.GetBytes(bytSalt)
    '        strSalt = Convert.ToBase64String(bytSalt)
    '    End If
    '    Hashed_String = FormsAuthentication.HashPasswordForStoringInConfigFile(strSalt & strOriginal, "SHA1")
    'End Function

    Public Function encrypt(input As String) As String
        Dim result As String = String.Empty
        Dim encryted As Byte() = System.Text.Encoding.Unicode.GetBytes(input)
        result = Convert.ToBase64String(encryted)
        Return result
    End Function

    Public Function Decrypt(imput As String) As String
        Dim result As String = String.Empty
        Dim decryted As Byte() = Convert.FromBase64String(imput)
        'result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
        result = System.Text.Encoding.Unicode.GetString(decryted)
        Return result
    End Function

End Class
