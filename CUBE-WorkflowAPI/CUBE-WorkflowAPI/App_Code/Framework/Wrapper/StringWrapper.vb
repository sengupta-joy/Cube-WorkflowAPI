Public Class StringWrapper : Inherits WrapperBase

    Public Sub New()

    End Sub

    Public Overrides ReadOnly Property DataType As String
        Get
            Return "text"
        End Get
    End Property
End Class
