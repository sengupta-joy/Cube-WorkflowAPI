Imports System.Net
Imports System.Web.Http
Imports CUBE_WorkflowAPI.WorkflowFramework

Namespace Controllers
    Public Class WorkflowController
        Inherits ApiController

        ' GET: api/Workflow
        Public Function GetValues() As Dictionary(Of String, String)
            Return WorkflowCls.getItems()
        End Function

        ' GET: api/Workflow/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST: api/Workflow
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Workflow/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Workflow/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace