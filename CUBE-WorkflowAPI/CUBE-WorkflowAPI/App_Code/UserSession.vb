
Imports System
Imports System.Data
Imports CUBE_WorkflowAPI.AutoMapper
Imports System.Collections.Generic

<Serializable>
Public Class UserInfo : Inherits AutoMapperCls

    Private _nm As String
    Private _id As String
    Private _eml As String
    Private _actv As Boolean
    Private _desig As String
    Private _dept As String
    Private _brn As String
    Private _bs As String
    Private _comp As String


#Region "Properties"
    <SQLParam("UserName")>
    Public Property Name As String
        Get
            Return _nm
        End Get
        Set(value As String)
            _nm = value
        End Set
    End Property
    <SQLParam("UserID")>
    Public ReadOnly Property Id As String
        Get
            Return _id
        End Get
    End Property
    <SQLParam("Email")>
    Public Property Email As String
        Get
            Return _eml
        End Get
        Set(value As String)
            _eml = value
        End Set
    End Property
    <SQLParam("Active", AutoMapperConstant.ParamTypes.BooleanType)>
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
#End Region


    Public Sub New(uid As String)
        _id = uid
        loadUser(uid)
    End Sub

    Private Sub loadUser(uid As String)
        Dim dl As New DataLayer(USERDB)

        Dim resp = dl.SelectData("exec USP_USERS_GET @USERID='" + uid + "'")
        If resp.Success Then
            'AutoMapper.Mapper.MapDataFromDB(resp.Data.Tables(0), Me)
            map(resp.GetData(0))
        Else
            Throw New Exception("Error loading user")
        End If

    End Sub

    Public Function saveUser() As Boolean

    End Function

    Public Shared Function validateLogin(uid As String, password As String) As LoginResponse
        Dim dl As New DataLayer(USERDB)
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

        Return New LoginResponse(Response.Data.Tables(0).Rows(0)(0), Response.Data.Tables(0).Rows(0)(1))

    End Function

    Friend Shared Function isValidKey(key As String) As Boolean
        If key = "key" Then
            Return True
        End If
        Return False
    End Function
End Class
