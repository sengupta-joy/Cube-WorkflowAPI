Imports System.Web
Imports System.Web.Mvc

Public Module FilterConfig
    Public Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
        filters.Add(New CUBE_WorkflowAPI.CustomAuthorization())
    End Sub
End Module