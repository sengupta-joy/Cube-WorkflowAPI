Namespace App_Code.Framework.WFFW
    Public Interface IActionContext(Of T)



        Function GetItems() As Dictionary(Of String, String)
        Function save() As Boolean
    End Interface
End Namespace
