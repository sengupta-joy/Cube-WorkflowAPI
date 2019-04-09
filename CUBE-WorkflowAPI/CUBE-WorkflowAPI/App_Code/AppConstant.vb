﻿Imports System.Runtime.CompilerServices

Public Module AppConstant
    Public USERDB As String = ConfigurationManager.ConnectionStrings.Item("UserDB").ConnectionString

    Public Enum ParamTypes
        BooleanType
        StringType
        IntType
        LongType
        DateType
        FloatType
        DoubleType
    End Enum

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
        If values.Contains(obj) Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
