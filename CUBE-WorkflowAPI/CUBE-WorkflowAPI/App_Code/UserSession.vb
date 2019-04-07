
Imports System
Imports System.Data
Imports CUBE_WorkflowAPI
Imports App_Code.DB

<Serializable>
Public Class UserInfo

    Private _nm As String
    Private _id As String
    Private _eml As String
    Private _actv As Boolean
    Private _desig As String
    Private _dept As String
    Private _brn As String
    Private _bs As String
    Private _comp As String

    Public Sub New(uid As String)

    End Sub


    Public Property Name As String
        Get
            Return _nm
        End Get
        Set(value As String)
            _nm = value
        End Set
    End Property

    Public ReadOnly Property Id As String
        Get
            Return _id
        End Get
    End Property

    Public Property Email As String
        Get
            Return _eml
        End Get
        Set(value As String)
            _eml = value
        End Set
    End Property

    Public Property Active As Boolean
        Get
            Return _actv
        End Get
        Set(value As Boolean)
            _actv = value
        End Set
    End Property

    Public Property Designation As String
        Get
            Return _desig
        End Get
        Set(value As String)
            _desig = value
        End Set
    End Property

    Public Property Depertment As String
        Get
            Return _dept
        End Get
        Set(value As String)
            _dept = value
        End Set
    End Property

    Public Property Branch As String
        Get
            Return _brn
        End Get
        Set(value As String)
            _brn = value
        End Set
    End Property

    Public Property Boss As String
        Get
            Return _bs
        End Get
        Set(value As String)
            _bs = value
        End Set
    End Property

    Public Property Company As String
        Get
            Return _comp
        End Get
        Set(value As String)
            _comp = value
        End Set
    End Property

    Public Function saveUser() As Boolean

    End Function

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



        Dim Response = dl.ExecuteSP("[SP_VALIDATE_LOGIN]", CommandType.StoredProcedure, params)

        Return New UserInfo(Response.Data.Tables(0).Rows(0)(0))

        Return Nothing
    End Function

    Friend Shared Function isValidKey(key As String) As Boolean
        If key = "key" Then
            Return True
        End If
        Return False
    End Function
End Class
