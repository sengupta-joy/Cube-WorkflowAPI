Public MustInherit Class WrapperBase
    Private _DataType As String
    Private _value As Object
    Private _lable As String

    Public MustOverride ReadOnly Property DataType As String


    Public Property Value As Object
        Get
            Return _value
        End Get
        Set(value As Object)
            _value = value
        End Set
    End Property

    Public Property Lable As String
        Get
            Return _lable
        End Get
        Set(value As String)
            _lable = value
        End Set
    End Property
End Class
