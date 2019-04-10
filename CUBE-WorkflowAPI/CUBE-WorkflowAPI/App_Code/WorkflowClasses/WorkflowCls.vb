



Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW

Namespace App_Code.WorkflowFramework
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
