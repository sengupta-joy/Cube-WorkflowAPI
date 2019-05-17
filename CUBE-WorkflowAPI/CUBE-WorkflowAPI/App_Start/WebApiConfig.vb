Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.Http.Headers
Imports System.Web.Http
Imports Newtonsoft.Json.Serialization

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        'Dim jsonP As New WebApiContrib.Formatting.Jsonp.JsonpMediaTypeFormatter(config.Formatters.JsonFormatter)


        ' Web API configuration and services

        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )


        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(New MediaTypeHeaderValue("text/html"))
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = New DefaultContractResolver()
        config.Filters.Add(New CUBE_WorkflowAPI.CustomAuthorization())
        'config.Formatters.Insert(0, jsonP)
        'config.MessageHandlers.Add(New CrossDomainHandler())


    End Sub
End Module
