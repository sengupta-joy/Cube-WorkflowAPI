Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW

Namespace App_Code.WorkflowFramework
    Public Class WorkflowStateAction : Inherits WorkflowFrameworkBase(Of WorkflowStateAction)

        Public Property Visibility As Integer
            Get
                Return Nothing
            End Get
            Set(value As Integer)
            End Set
        End Property

        Public ReadOnly Property Destination As List(Of WorkflowDestination)
            Get
                Return Nothing
            End Get
        End Property

        Public Function executeAction() As Boolean

        End Function
    End Class
End Namespace
