Imports System.Net
Imports System.Web.Http
Imports CUBE_WorkflowAPI.App_Code.WorkflowFramework

Namespace Controllers
    Public Class entityController
        Inherits ApiController

        ' GET: api/entity/5
        Public Function GetValue() As Entity
            Return Entity.getItem()
        End Function

        Public Function GetValue(ByVal id As String) As String
            Return "Company name"
        End Function

        ' POST: api/entity
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/entity/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/entity/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace