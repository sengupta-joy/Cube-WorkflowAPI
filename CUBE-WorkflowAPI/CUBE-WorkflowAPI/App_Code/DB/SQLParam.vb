


Imports CUBE_WorkflowAPI.App_Code.Framework.AutoMapper

Namespace App_Code.DB
    Public Class SQLParam : Inherits System.Attribute

        Public Property ParameterName As String
        Public Property ParameterType As ParamTypes

        Public Sub New(ParamName As String, Optional ParamType As ParamTypes = ParamTypes.StringType)
            ParameterName = ParamName
            ParameterType = ParamType
        End Sub

    End Class
End Namespace