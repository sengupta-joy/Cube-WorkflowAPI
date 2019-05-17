Imports System.Net
Imports System.Web.Http.Controllers
Imports System.Web.Http.Filters
Imports System.Web.Mvc
Imports System.Web.Mvc.Filters

Public Class CustomAuthorization : Inherits System.Web.Http.AuthorizeAttribute : Implements System.Web.Mvc.IAuthorizationFilter

    Public Overrides Sub OnAuthorization(actionContext As HttpActionContext)
        If Not authorized(actionContext) Then
            actionContext.Response = New System.Net.Http.HttpResponseMessage(HttpStatusCode.Unauthorized)
        End If
    End Sub

    Public Overloads Sub OnAuthorization(filterContext As AuthorizationContext) Implements Mvc.IAuthorizationFilter.OnAuthorization
        If Not authorized(filterContext.ActionDescriptor.ActionName, filterContext.Controller.ControllerContext.Controller.ToString()) Then
            filterContext.HttpContext.Response.Write("unauthorized")
        End If
    End Sub

    Private Function authorized(actionName As String, controlername As String) As Boolean
        If Not controlername = "login" And actionName = "GetValues" Then
            Return False
        End If

        Return True
    End Function

    Private Function authorized(filterContext As HttpActionContext) As Boolean

        If filterContext.ControllerContext.ControllerDescriptor.ControllerName = "login" And filterContext.ActionDescriptor.ActionName = "GetValue" Then
            Return True
        End If

        Dim token = HttpContext.Current.Request.Headers("token")
        If token Is Nothing Then
            Return False
        End If

        If UserInfo.isValidKey(token) Then
            Return True
        End If



        Return False
    End Function
End Class
