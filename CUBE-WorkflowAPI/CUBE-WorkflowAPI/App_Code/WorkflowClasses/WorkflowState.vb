Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW


Namespace App_Code.WorkflowFramework
    Public Class WorkflowState : Inherits WorkflowFrameworkBase(Of WorkflowState)

        Public ReadOnly Property Actions As List(Of WorkflowStateAction)
            Get

            End Get
        End Property

        Public Property Visibility As Integer
            Get
                Return Nothing
            End Get
            Set(value As Integer)
            End Set
        End Property
    End Class
End Namespace