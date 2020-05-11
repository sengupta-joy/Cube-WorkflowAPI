Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW


<Serializable>
Public Class Designation : Inherits WorkflowFrameworkBase(Of Designation)

    Shared Sub New()

    End Sub

    Private Sub New(_id As String)
        MyBase.ID = _id
    End Sub

    Friend Shared Function getItems() As Dictionary(Of String, String)
        Dim SQL As String
        Dim user = HttpContext.Current.Request.Headers("userid")
        Dim dl As New DataLayer(WORKFLOWDB)
        Dim lst As New Dictionary(Of String, String)()

        SQL = "SELECT * FROM [dbo].[FM_LOAD_GET_DESIGNATION] ('" + user + "')"
        Dim rsp = dl.SelectData(SQL)

        If rsp.Success Then
            For Each item In rsp.GetData(0).Rows
                lst.Add(item("ID"), item("NAME"))
            Next
        End If

        Return lst
    End Function

    Friend Shared Function getItem(id As String) As Designation
        Dim x = New Designation(id)
        x.LoadItem()

        Return x
    End Function
End Class
