Imports CUBE_WorkflowAPI.WorkflowFramework.Framework

Namespace WorkflowFramework
    Public Class WorkflowCls : Inherits WorkflowFrameworkBase(Of WorkflowCls)

        Private Sub New()
            Dim i
        End Sub


        Public Shared Function getItems() As Dictionary(Of String, String)
            Dim wf As WorkflowFrameworkBase(Of WorkflowCls)
            wf = New WorkflowCls()

            Return wf.GetItems()
        End Function

        Public Overrides Function GetItem(id As String) As WorkflowCls

        End Function


    End Class
End Namespace
