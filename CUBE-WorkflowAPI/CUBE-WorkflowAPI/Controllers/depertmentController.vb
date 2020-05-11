Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class depertmentController
        Inherits ApiController

        ' GET: api/depertment
        Public Function GetValues() As Dictionary(Of String, String)
            Return Depertment.getItems()
        End Function

        ' GET: api/depertment/5
        Public Function GetValue(ByVal id As String) As Depertment

            Return Depertment.getItem(id)

        End Function

        ' POST: api/depertment
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/depertment/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/depertment/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace