'Clase para manejar las excepciones de forma centralizada
'Creada por: Ing. Luis Alberto Rangel Garcia
'Fecha de creación: 07 de Enero de 2008
'Permitido su uso libre siempre y cuando se dejen las referencias al creador de la misma
'
'
'---------------------------------------------------------------------------------------
'Sección de aportaciones
'---------------------------------------------------------------------------------------
'Última modificación:
'
Imports Microsoft.VisualBasic
Imports System.Data
Imports System

Public Class clsErrorHandler
    Public Sub New()
        MyBase.New()
    End Sub

    Public Function Handler(ByVal ex As Exception, ByVal strMensajeDefault As String) As String
        Dim strMsg As String
        strMsg = HandlerMain(ex)
        If (strMsg = String.Empty) Then
            strMsg = strMensajeDefault
        End If
        Return strMsg
    End Function
    Public Function Handler(ByVal ex As Exception) As String
        Dim strMsg As String
        strMsg = HandlerMain(ex)
        If (strMsg = String.Empty) Then
            strMsg = "Error en la base de datos"
        End If
        Return strMsg
    End Function

    Private Function HandlerMain(ByVal ex As Exception) As String
        Dim strMsg As String = String.Empty
        If (GetType(DBConcurrencyException).Equals(ex.GetType())) Then
            strMsg = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
        ElseIf (GetType(ConstraintException).Equals(ex.GetType())) Then
            strMsg = "Error de llaves duplicadas"
        ElseIf (GetType(DeletedRowInaccessibleException).Equals(ex.GetType())) Then
            strMsg = "Fila no accesible"
        ElseIf (GetType(DuplicateNameException).Equals(ex.GetType())) Then
            strMsg = "Nombre duplicado"
        ElseIf (GetType(InRowChangingEventException).Equals(ex.GetType())) Then
            strMsg = "Fila esta siendo modificada"
        ElseIf (GetType(InvalidConstraintException).Equals(ex.GetType())) Then
            strMsg = "Restricción no válida"
        ElseIf (GetType(InvalidExpressionException).Equals(ex.GetType())) Then
            strMsg = "Expresión no válida"
        ElseIf (GetType(MissingPrimaryKeyException).Equals(ex.GetType())) Then
            strMsg = "No se encontró una llave principal"
        ElseIf (GetType(NoNullAllowedException).Equals(ex.GetType())) Then
            strMsg = "Valor nulo no permitido"
        ElseIf (GetType(OperationAbortedException).Equals(ex.GetType())) Then
            strMsg = "Operacion abortada por el usuario"
        ElseIf (GetType(ReadOnlyException).Equals(ex.GetType())) Then
            strMsg = "La base de datos es de solo lectura"
        ElseIf (GetType(RowNotInTableException).Equals(ex.GetType())) Then
            strMsg = "La fila solicitada no esta en la base de datos"
        ElseIf (GetType(StrongTypingException).Equals(ex.GetType())) Then
            strMsg = "Error en tipos de datos"
        ElseIf (GetType(TypedDataSetGeneratorException).Equals(ex.GetType())) Then
            strMsg = "No fue posible generar el conjunto de datos"
        ElseIf (GetType(VersionNotFoundException).Equals(ex.GetType())) Then
            strMsg = "Versión no encontrada"
        ElseIf (GetType(DataException).Equals(ex.GetType())) Then
            strMsg = "Error de datos"
        ElseIf (GetType(System.Data.SqlClient.SqlException).Equals(ex.GetType())) Then
            Dim tempEx As SqlClient.SqlException
            tempEx = CType(ex, SqlClient.SqlException)
            Select Case tempEx.Errors(0).Number
                Case 2627 'Violation of %ls constraint '%.*ls'. Cannot insert duplicate key in object '%.*ls'.
                    strMsg = "No puede insertar dos registros con la misma clave principal"
                Case Else
                    strMsg = "Error " & tempEx.Errors(0).Number & ": " & tempEx.Errors(0).Message
            End Select

        End If
        Return strMsg
    End Function
End Class
