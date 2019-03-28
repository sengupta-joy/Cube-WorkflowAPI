Imports System.Net
Imports System.Web.Http.Filters
Imports System.Web.Mvc
Imports System.Web.Mvc.Filters

Public Class CustomAuthorization : Inherits System.Web.Mvc.AuthorizeAttribute : Implements System.Web.Http.Filters.IFilter

    Private ReadOnly Property IFilter_AllowMultiple As Boolean Implements IFilter.AllowMultiple
        Get
            Return False
        End Get
    End Property

    Public Overrides Sub OnAuthorization(filterContext As AuthorizationContext)
        If Not authorized(filterContext) Then

            filterContext.HttpContext.Response.Write("Unauthorized")
        End If
    End Sub

    Private Function authorized(filterContext As AuthorizationContext) As Boolean

        If Not filterContext.Controller.ToString() = "login" And filterContext.ActionDescriptor.ActionName = "GetValues" Then
            Return False
        End If

        Return True
    End Function
End Class
