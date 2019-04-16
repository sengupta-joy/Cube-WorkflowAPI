Imports CUBE_WorkflowAPI
Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW


Namespace App_Code.WorkflowFramework
    Public Class WorkflowDestination : Inherits WorkflowFrameworkBase(Of WorkflowDestination)

        'jump to state if all condition satisfies

        Public Property Conditions As List(Of WorkflowCondition)

        Public Property StateToMoveOnSuccess As WorkflowState
        Public Property StateToMoveOnFail As WorkflowState

    End Class
End Namespace