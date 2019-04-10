Namespace App_Code.Framework.WFFW
    Public Interface IActionContext(Of T)



        Function GetItems() As Dictionary(Of String, String)
        Function GetItem(id As String) As T
    End Interface
End Namespace
