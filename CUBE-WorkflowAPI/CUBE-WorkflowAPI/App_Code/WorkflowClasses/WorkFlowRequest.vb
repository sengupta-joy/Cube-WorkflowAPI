Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW

Namespace App_Code.WorkflowFramework
    Public Class WorkflowRequest : Inherits WorkflowFrameworkBase(Of WorkflowRequest)

        Public Property Creator As String
        Public Property WorklfowID As String
        Public Property WorkflowStateID As String
    End Class
End Namespace