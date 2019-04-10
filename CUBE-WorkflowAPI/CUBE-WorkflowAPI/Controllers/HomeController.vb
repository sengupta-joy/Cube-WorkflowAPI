Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult



        ViewData("Title") = Boolean.Parse("True").ToString()

        Return View()
    End Function
End Class
