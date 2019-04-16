
Namespace App_Code.WorkflowFramework.Processes
    Public Class MoveStateProcess : Implements IProcessProvider

        Private _dest As List(Of WorkflowDestination)

        Private ReadOnly Property Destinations As List(Of WorkflowDestination)
            Get
                Return _dest
            End Get
        End Property

        Public Function executeProcess() As Boolean Implements IProcessProvider.executeProcess
            For Each d In Destinations
                d.execute()
            Next
        End Function
    End Class
End Namespace