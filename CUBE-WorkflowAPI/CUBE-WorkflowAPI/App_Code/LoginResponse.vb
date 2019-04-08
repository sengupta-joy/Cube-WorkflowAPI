
Imports CUBE_WorkflowAPI

<Serializable>
Public Class LoginResponse
    Private _uinfo As UserInfo
    Private _tok As String

    Public ReadOnly Property UserInfo As UserInfo
        Get
            Return _uinfo
        End Get
    End Property
    Public ReadOnly Property Tocken As String
        Get
            Return _tok
        End Get
    End Property

    Public Sub New(uid As String, token As String)
        _uinfo = New UserInfo(uid)
        _tok = token
    End Sub

End Class
