Imports System.Data
Imports CUBE_WorkflowAPI.App_Code.DB

Public Class DBContext

    Private _cs As String

    Public Sub New(connectionString As String)
        _cs = connectionString
    End Sub


    Public Function SelectData(sql As String, Optional params As List(Of SqlClient.SqlParameter) = Nothing) As SelectResponse
        Dim cn As New SqlClient.SqlConnection(_cs)
        Dim cmd As New SqlClient.SqlCommand(sql, cn)
        Dim da As New SqlClient.SqlDataAdapter(cmd)
        Dim result As SelectResponse


        Try
            If Not params Is Nothing Then
                For Each p In params
                    cmd.Parameters.Add(p)
                Next
            End If


            cn.Open()
            result = New SelectResponse(True, "")
            da.Fill(result.Data)
            cn.Close()
        Catch ex As Exception
            result = New SelectResponse(False, ex.Message)
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If

        End Try

        Return result

    End Function

    Public Function ExecuteSP(sql As String, Optional cmdType As CommandType = CommandType.Text, Optional params As List(Of SqlClient.SqlParameter) = Nothing) As SelectResponse
        Dim cn As New SqlClient.SqlConnection(_cs)
        Dim cmd As New SqlClient.SqlCommand(sql, cn)
        Dim da As New SqlClient.SqlDataAdapter(cmd)
        Dim result As SelectResponse


        Try
            If Not params Is Nothing Then
                For Each p In params
                    cmd.Parameters.Add(p)
                Next
            End If


            cn.Open()
            cmd.CommandType = cmdType
            result = New SelectResponse(True, "")
            da.Fill(result.Data)
            cn.Close()
        Catch ex As Exception
            result = New SelectResponse(False, ex.Message)
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If

        End Try

        Return result

    End Function


End Class
