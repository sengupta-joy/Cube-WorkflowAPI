Imports System.Collections.Generic

Namespace App_Code.Framework.WFFW
    Public Interface IActionContext(Of T)



        Function GetItems() As Dictionary(Of String, String)
        Function Save() As Boolean
    End Interface
End Namespace
