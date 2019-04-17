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


        Public Property Confirmations As List(Of IConfirmationProvider)
            Get

            End Get
            Set(value As List(Of IConfirmationProvider))

            End Set
        End Property

        Public Property Validation As List(Of IValidationProvider)
            Get

            End Get
            Set(value As List(Of IValidationProvider))

            End Set
        End Property

        Public Property Processes As List(Of IProcessProvider)
            Get

            End Get
            Set(value As List(Of IProcessProvider))

            End Set
        End Property

        Public Function renderAction() As String

        End Function


        Public Function executeAction() As Boolean

            'check confirmation
            'check validation

            For Each p In Me.Processes
                p.executeProcess()
            Next
        End Function
    End Class
End Namespace
