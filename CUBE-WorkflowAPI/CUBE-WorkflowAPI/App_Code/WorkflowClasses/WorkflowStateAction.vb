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

        Public Property Processes As List(Of IProcessProvider)
            Get

            End Get
            Set(value As List(Of IProcessProvider))

            End Set
        End Property

        Public Function executeAction() As Boolean
            For Each p In Me.Processes
                p.executeProcess()
            Next
        End Function
    End Class
End Namespace
