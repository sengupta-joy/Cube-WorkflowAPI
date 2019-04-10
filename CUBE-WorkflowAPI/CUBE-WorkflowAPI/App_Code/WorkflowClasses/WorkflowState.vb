Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW


Namespace App_Code.WorkflowFramework
    Public Class WorkflowState : Inherits WorkflowFrameworkBase(Of WorkflowState)

        Dim EntryConditions As New List(Of WorkflowStateCondition)()


        Public Overrides Function GetItem(id As String) As WorkflowState

        End Function
    End Class
End Namespace