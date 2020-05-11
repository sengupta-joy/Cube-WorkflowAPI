Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class usersController
        Inherits ApiController

        ' GET: api/users
        Public Function GetValues() As Dictionary(Of String, String)

            Return UserInfo.getItems()
        End Function

        ' GET: api/users/5
        Public Function GetValue(ByVal id As String) As UserInfo
            Dim u As UserInfo

            u = UserInfo.getItem(id)
            Return u
        End Function

        ' POST: api/users
        <HttpPost>
        Public Sub PostValue(ByVal value As Object)
            Dim i As Integer
            i = 5
        End Sub

        ' PUT: api/users/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/users/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace