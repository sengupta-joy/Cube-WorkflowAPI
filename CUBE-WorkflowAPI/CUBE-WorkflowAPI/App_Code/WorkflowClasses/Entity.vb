
Imports CUBE_WorkflowAPI.App_Code.DB
Imports CUBE_WorkflowAPI.App_Code.Framework.AutoMapper
Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW

Namespace App_Code.WorkflowFramework
    Public Class Entity : Inherits WorkflowFrameworkBase(Of Entity)



        Friend Sub New()
            LoadItem(UserID)
        End Sub

        Public Shared Function getItem() As Entity
            Return New Entity()
        End Function
        Public Shared Function createItem(company As Entity) As WorkflowCls

        End Function

    End Class
End Namespace