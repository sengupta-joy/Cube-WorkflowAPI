Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Web.Http
Imports Newtonsoft.Json

<CustomAuthorization>
Public Class logincontroller
    Inherits ApiController



    ' GET api/<controller>/5
    <HttpGet>
    Public Function GetValue(ByVal id As String, password As String) As LoginCls
        Dim resp = UserInfo.validateLogin(id, password)

        If resp Is Nothing Then
            HttpContext.Current.Response.Write("{'message':'invalid login'}")
        Else
            Return resp
        End If
    End Function

    ' PUT api/<controller>/5
    <HttpPut>
    Public Sub PutValue(ByVal userid As String, ByVal password As String)
        Dim resp = LoginCls.save(userid, password)
    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
