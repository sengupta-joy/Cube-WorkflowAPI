
Imports CUBE_WorkflowAPI
Imports CUBE_WorkflowAPI.App_Code.DB

<Serializable>
Public Class LoginCls
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
        _uinfo = UserInfo.getItem(uid, False)
        _tok = token
    End Sub

    Friend Shared Function save(userid As String, password As String) As Object
        Dim dl As New DataLayer(WORKFLOWDB)
        Dim sql As String = "exec USP_LOGIN_CHANGE_PASSWORD @USERID='" + userid + "', @PASSWORD='" + password + "' "
        Dim resp As SelectResponse


        resp = dl.SelectData(sql)
        Return resp.Success

    End Function
End Class
