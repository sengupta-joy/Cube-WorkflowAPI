﻿Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Web.Http
Imports Newtonsoft.Json

<CustomAuthorization>
Public Class logincontroller
    Inherits ApiController

    ' GET api/<controller>
    <HttpGet>
    Public Function GetValues() As List(Of String)
        Dim resp As HttpResponseMessage
        Dim lst = New String() {"value1", "value2"}

        Return lst.ToList()

    End Function

    ' GET api/<controller>/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
