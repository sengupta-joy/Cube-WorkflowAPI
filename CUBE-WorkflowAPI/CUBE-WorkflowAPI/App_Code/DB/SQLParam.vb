Imports App_Code.Util.AutoMapper

Namespace App_Code.DB
    Public Class SQLParam : Inherits System.Attribute

        Public Property ParameterName As String
        Public Property ParameterType As App_Code.Util.AutoMapper.ParamTypes

        Public Sub New(ParamName As String, Optional ParamType As App_Code.Util.AutoMapper.ParamTypes = App_Code.Util.AutoMapper.ParamTypes.StringType)
            ParameterName = ParamName
            ParameterType = ParamType
        End Sub

    End Class
End Namespace