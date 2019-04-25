Imports System.Net
Imports System.Web.Http
Imports CUBE_WorkflowAPI.App_Code.WorkflowFramework

Namespace Controllers
    Public Class MenuController
        Inherits ApiController

        ' GET: api/Menu
        Public Function GetValues() As List(Of MenuCls)
            Dim mn As New MenuCls()
            Dim lst As New List(Of MenuCls)
            Dim dic = mn.GetItems()

            For Each kv As KeyValuePair(Of String, String) In dic
                Dim m As New MenuCls(kv.Key)
                lst.Add(m)
            Next

            Return lst

        End Function

        ' GET: api/Menu/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST: api/Menu
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Menu/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Menu/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace