
Imports System

<Serializable>
Public Class UserInfo



    Public Name As String = "joy"
    Public id As Integer = 1234


    Public Shared Function validateLogin(uid As String, password As String) As UserInfo
        Return New UserInfo()
    End Function

    Friend Shared Function isValidKey(key As String) As Boolean
        If key = "key" Then
            Return True
        End If
        Return False
    End Function
End Class
