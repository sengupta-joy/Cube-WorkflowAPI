Imports System
Imports System.Configuration
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices

Public Module AppConstant

    Public Const WORKFLOWDB As String = "WORKFLOWDB"





    <Extension>
    Public Function isNull(obj As Object, defaultValue As Object) As Object
        If obj Is Nothing Then
            Return defaultValue
        Else
            Return obj
        End If
    End Function

    Public Function isDBNull(obj As Object, Optional defaultValue As Object = "") As Object
        If obj Is DBNull.Value Then
            Return defaultValue
        Else
            Return obj
        End If
    End Function

    <Extension>
    Public Function isin(obj As Object, ParamArray values As Object()) As Boolean

        If values.ToList().Contains(obj) Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
