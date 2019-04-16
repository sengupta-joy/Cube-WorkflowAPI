Imports CUBE_WorkflowAPI
Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW


Namespace App_Code.WorkflowFramework
    Public Class WorkflowDestination : Inherits WorkflowFrameworkBase(Of WorkflowDestination)

        'jump to state if all condition satisfies

        Public Property Conditions As List(Of WorkflowCondition)

        Public Property StateToMoveOnSuccess As WorkflowState

        Public Function execute() As Boolean
            If Not Conditions.Select(Function(x) Not x.isValid()).ToList().Count() > 0 Then
                ' move state
            End If
        End Function

    End Class
End Namespace