Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Imports System.IO
Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.Text

Public Class Conexion
    ' Retrieves a connection string by name.
    ' Returns Nothing if the name is not found.
    Public Function GetConnection() As String

        Dim con As String
        con = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringName").ConnectionString

        Return con
    End Function

End Class