Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult

        ' Dim u As New UserInfo("AUBUSR190690000T")

        ViewData("Title") = "Home Page"

        Return View()
    End Function
End Class
