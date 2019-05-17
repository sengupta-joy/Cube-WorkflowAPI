Imports System.Net
Imports System.Net.Http
Imports System.Threading
Imports System.Threading.Tasks

Public Class CrossDomainHandler : Inherits DelegatingHandler

    Const Origin As String = "Origin"
    Const AccessControlRequestMethod As String = "Access-Control-Request-Method"
    Const AccessControlRequestHeaders As String = "Access-Control-Request-Headers"
    Const AccessControlAllowOrigin As String = "Access-Control-Allow-Origin"
    Const AccessControlAllowMethods As String = "Access-Control-Allow-Methods"
    Const AccessControlAllowHeaders As String = "Access-Control-Allow-Headers"


    Protected Overrides Function SendAsync(request As HttpRequestMessage, cancellationToken As CancellationToken) As Task(Of HttpResponseMessage)
        Dim isCorsRequest = request.Headers.Contains(Origin)
        Dim isPreflightRequest As Boolean = request.Method = HttpMethod.Options
        If isCorsRequest Then

            If isPreflightRequest Then
                Return Task.Factory.StartNew(Function()
                                                 Dim response As HttpResponseMessage = New HttpResponseMessage(HttpStatusCode.OK)
                                                 response.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First())
                                                 Dim accessControlRequestMethod As String = request.Headers.GetValues(accessControlRequestMethod).FirstOrDefault()

                                                 If accessControlRequestMethod IsNot Nothing Then
                                                     response.Headers.Add(AccessControlAllowMethods, accessControlRequestMethod)
                                                 End If

                                                 Dim requestedHeaders As String = String.Join(", ", request.Headers.GetValues(AccessControlRequestHeaders))

                                                 If Not String.IsNullOrEmpty(requestedHeaders) Then
                                                     response.Headers.Add(AccessControlAllowHeaders, requestedHeaders)
                                                 End If

                                                 Return response
                                             End Function, cancellationToken)
            Else
                Return MyBase.SendAsync(request, cancellationToken).ContinueWith(Function(t)
                                                                                     Dim resp As HttpResponseMessage = t.Result
                                                                                     resp.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First())
                                                                                     Return resp
                                                                                 End Function)
            End If
        Else
            Return MyBase.SendAsync(request, cancellationToken)
        End If

    End Function



End Class
