Imports System.Net
Imports System.Web.Http


<CustomAuthorization>
Public Class logincontroller
    Inherits ApiController

    ' GET api/<controller>



    ' GET api/<controller>/5
    Public Function GetValue(ByVal id As String, password As String) As UserSession
        Return UserSession.validateLogin(id, password)
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
