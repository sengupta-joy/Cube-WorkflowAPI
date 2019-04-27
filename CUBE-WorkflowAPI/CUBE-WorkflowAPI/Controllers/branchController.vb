Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class branchController
        Inherits ApiController

        ' GET: api/branch
        Public Function GetValues() As Dictionary(Of String, String)
            Return Branch.GetItems()
        End Function

        ' GET: api/branch/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST: api/branch
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/branch/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/branch/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace