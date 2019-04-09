Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult

        ' Dim u As New WorkflowFramework.WorkflowCls()

        ' ViewData("Title") = u.Name

        Return View()
    End Function
End Class
