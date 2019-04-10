Imports System.Net
Imports System.Web.Http
Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW
Imports CUBE_WorkflowAPI.App_Code.WorkflowFramework

Namespace Controllers
    Public Class WorkflowController
        Inherits ApiController

        ' GET: api/Workflow
        Public Function GetValues() As Dictionary(Of String, String)
            Dim obj As WorkflowFrameworkBase(Of WorkflowCls)

            obj = New WorkflowCls()
            Return obj.GetItems()
        End Function

        ' GET: api/Workflow/5
        Public Function GetValue(ByVal id As Integer) As WorkflowCls
            Return WorkflowCls.getIte(id)
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