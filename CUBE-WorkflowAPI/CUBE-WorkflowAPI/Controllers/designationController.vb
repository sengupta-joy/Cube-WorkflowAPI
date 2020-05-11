Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class designationController
        Inherits ApiController

        ' GET: api/designation
        Public Function GetValues() As Dictionary(Of String, String)
            Return Designation.getItems()
        End Function

        ' GET: api/designation/5
        Public Function GetValue(ByVal id As String) As Designation
            Return Designation.getItem(id)
        End Function

        ' POST: api/designation
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/designation/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/designation/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace