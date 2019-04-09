

Namespace AutoMapper
    Public Class SQLParam : Inherits System.Attribute

        Public Property ParameterName As String
        Public Property ParameterType As AutoMapperConstant.ParamTypes

        Public Sub New(ParamName As String, Optional ParamType As AutoMapperConstant.ParamTypes = AutoMapperConstant.ParamTypes.StringType)
            ParameterName = ParamName
            ParameterType = ParamType
        End Sub

    End Class
End Namespace