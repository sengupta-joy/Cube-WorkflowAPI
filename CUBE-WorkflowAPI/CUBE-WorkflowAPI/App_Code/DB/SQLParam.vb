Public Class SQLParam : Inherits Attribute

    Public Property ParameterName As String
    Public Property ParameterType As ParamTypes

    Public Sub New(ParamName As String, Optional ParamType As ParamTypes = ParamTypes.StringType)
        ParameterName = ParamName
        ParameterType = ParamType
    End Sub

End Class
