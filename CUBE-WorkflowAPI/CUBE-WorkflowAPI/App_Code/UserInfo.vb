
Imports System
Imports System.Data
Imports System.Collections.Generic
Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW
Imports CUBE_WorkflowAPI.App_Code.Framework.AutoMapper
Imports CUBE_WorkflowAPI.App_Code.DB
Imports System.Web
Imports CUBE_WorkflowAPI.App_Code.WorkflowFramework

<Serializable>
Public Class UserInfo : Inherits WorkflowFrameworkBase(Of UserInfo)


    Private _eml As String
    Private _actv As Boolean
    Private _desig As String
    Private _dept As String
    Private _brn As String
    Private _bs As String
    Private _comp As String

    Private _about As String
    Private _phone As String
    Private _address As String
    Private _city As String
    Private _country As String
    Private _groups As New Dictionary(Of String, String)
    Private _subs As New Dictionary(Of String, String)


#Region "Properties"
    <SQLParam("Email")>
    Public Property Email As String
        Get
            Return _eml
        End Get
        Set(value As String)
            _eml = value
        End Set
    End Property
    <SQLParam("Active", ParamTypes.BooleanType)>
    Public Property Active As Boolean
        Get
            Return _actv
        End Get
        Set(value As Boolean)
            _actv = value
        End Set
    End Property
    <SQLParam("Designation")>
    Public Property Designation As String
        Get
            Return _desig
        End Get
        Set(value As String)
            _desig = value
        End Set
    End Property
    <SQLParam("Depertment")>
    Public Property Depertment As String
        Get
            Return _dept
        End Get
        Set(value As String)
            _dept = value
        End Set
    End Property
    <SQLParam("Branch")>
    Public Property Branch As String
        Get
            Return _brn
        End Get
        Set(value As String)
            _brn = value
        End Set
    End Property
    <SQLParam("Boss")>
    Public Property Boss As String
        Get
            Return _bs
        End Get
        Set(value As String)
            _bs = value
        End Set
    End Property
    <SQLParam("Company")>
    Public Property Company As String
        Get
            Return _comp
        End Get
        Set(value As String)
            _comp = value
        End Set
    End Property
    <SQLParam("About")>
    Public Property About As String
        Get
            Return _about
        End Get
        Set(value As String)
            _about = value
        End Set
    End Property
    <SQLParam("Phone")>
    Public Property Phone As String
        Get
            Return _phone
        End Get
        Set(value As String)
            _phone = value
        End Set
    End Property
    <SQLParam("Address")>
    Public Property Address As String
        Get
            Return _address
        End Get
        Set(value As String)
            _address = value
        End Set
    End Property
    <SQLParam("City")>
    Public Property City As String
        Get
            Return _city
        End Get
        Set(value As String)
            _city = value
        End Set
    End Property
    <SQLParam("Country")>
    Public Property Country As String
        Get
            Return _country
        End Get
        Set(value As String)
            _country = value
        End Set
    End Property

    Public ReadOnly Property Groups As Dictionary(Of String, String)
        Get
            Return _groups
        End Get
    End Property
    Public ReadOnly Property SubOrdinates As Dictionary(Of String, String)
        Get
            Return _subs
        End Get
    End Property

#End Region


    Private Sub New(uid As String)
        _id = uid
        LoadItem(uid)
        loadGroup(Me)
        loadChildren(Me)
    End Sub



    Private Sub New(company As Entity)

    End Sub

    Private Sub loadGroup(userInfo As UserInfo)
        Dim dl As New DataLayer(WORKFLOWDB)
        Dim sql As String


        sql = "exec USP_GET_USER_GROUPS @USERID='" + userInfo.ID + "'"
        Dim resp = dl.SelectData(sql)

        If resp.Success Then
            If resp.HasTable Then
                For Each row In resp.GetData(0).Rows
                    userInfo.Groups.Add(row("id"), row("Name"))
                Next
            End If
        End If

    End Sub
    Private Sub loadChildren(userInfo As UserInfo)
        Dim dl As New DataLayer(WORKFLOWDB)
        Dim sql As String


        sql = "SELECT * FROM DBO.UFN_GETCHILDREN('" + userInfo.ID + "')"
        Dim resp = dl.SelectData(sql)

        If resp.Success Then
            If resp.HasTable Then
                For Each row In resp.GetData(0).Rows
                    userInfo.SubOrdinates.Add(row("id"), row("Name"))
                Next
            End If
        End If
    End Sub

    Friend Shared Function getItem(id As String) As UserInfo
        Return New UserInfo(id)
    End Function
    Friend Shared Function createItem(company As Entity) As UserInfo
        Return New UserInfo(company)
    End Function

    Public Shared Function validateLogin(uid As String, password As String) As LoginCls
        Dim dl As New DataLayer(WORKFLOWDB)
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



        Dim Response = dl.ExecuteSP("[SP_VALIDATE_LOGIN]", CommandType.StoredProcedure, params)

        If Response.Success And Response.HasTable Then
            If Response.GetData(0).Rows.Count > 0 Then
                Return New LoginCls(Response.GetData(0, 0, 0), Response.GetData(0, 0, 1))
            End If
        End If

        Return Nothing
    End Function

    Friend Shared Function isValidKey(token As String) As Boolean
        Dim sql As String = "SELECT dbo.udf_validateKey('" + token + "')"
        Dim dl As New DataLayer(WORKFLOWDB)

        Dim resp = dl.SelectData(sql)

        If resp.Success Then
            If resp.HasTable Then
                If resp.GetData(0).Rows.Count > 0 Then
                    HttpContext.Current.Request.Headers.Add("userid", resp.GetData(0, 0, 0))
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If

        Return False
    End Function



    Friend Shared Function getItems() As Dictionary(Of String, String)
        Dim SQL As String
        Dim user = HttpContext.Current.Request.Headers("userid")
        Dim dl As New DataLayer(WORKFLOWDB)
        Dim lst As New Dictionary(Of String, String)()

        SQL = "SELECT * FROM [dbo].[FM_LOAD_GET_USERS] ('" + user + "')"
        Dim rsp = dl.SelectData(SQL)

        If rsp.Success Then
            For Each item In rsp.GetData(0).Rows
                lst.Add(item("ID"), item("NAME"))
            Next
        End If

        Return lst
    End Function
End Class
