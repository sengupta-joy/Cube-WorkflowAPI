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
    Public Function GetValue(ByVal id As String, password As String) As LoginResponse
        Return UserInfo.validateLogin(id, password)
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
