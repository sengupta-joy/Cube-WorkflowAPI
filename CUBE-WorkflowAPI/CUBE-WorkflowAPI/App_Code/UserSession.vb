
Imports System
Imports System.Data
Imports CUBE_WorkflowAPI
Imports App_Code.DB

<Serializable>
Public Class UserInfo



    Public Name As String = "joy"
    Public id As Integer = 1234


    Public Shared Function validateLogin(uid As String, password As String) As UserInfo
        Dim dl As New DBContext(USERDB)
        Dim params As New List(Of SqlClient.SqlParameter)()
        Dim param As New SqlClient.SqlParameter()


        param.ParameterName = "@userid"
        param.Value = uid
        param.SqlDbType = SqlDbType.NVarChar
        params.Add(param)

        param = New SqlClient.SqlParameter()
        param.ParameterName = "@password"
        param.Value = password
        param.SqlDbType = SqlDbType.NVarChar
        params.Add(param)

        param = New SqlClient.SqlParameter()
        param.ParameterName = "@TOKEN"
        param.Value = ""
        param.SqlDbType = SqlDbType.NVarChar
        param.Direction = ParameterDirection.Output
        params.Add(param)

        dl.ExecuteSP("[SP_VALIDATE_LOGIN]", CommandType.StoredProcedure, params)

        Return Nothing
    End Function

    Friend Shared Function isValidKey(key As String) As Boolean
        If key = "key" Then
            Return True
        End If
        Return False
    End Function
End Class
