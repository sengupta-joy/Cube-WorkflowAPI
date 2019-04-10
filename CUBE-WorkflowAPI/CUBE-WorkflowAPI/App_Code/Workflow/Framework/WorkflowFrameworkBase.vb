
Imports System.Data
Imports CUBE_WorkflowAPI.App_Code.Util.AutoMapper

Namespace WorkflowFramework.Framework
    Public MustInherit Class WorkflowFrameworkBase(Of T) : Inherits AutoMapperCls : Implements IActionContext(Of T), IDefaultPropProvider

        Protected Eventbindings As New Dictionary(Of String, String)
        Protected _nm As String
        Protected _id As String

        Protected ReadOnly Property UserID As String
            Get
                Return HttpContext.Current.Request.Headers("userid")
            End Get
        End Property

        Public ReadOnly Property TypeName As String
            Get
                Return Me.GetType().Name
            End Get
        End Property

#Region "Default property"
        <App_Code.DB.SQLParam("Name")>
        Public Property Name As String Implements IDefaultPropProvider.Name
            Get
                Return _nm
            End Get
            Set(value As String)
                _nm = value
            End Set
        End Property

        <App_Code.DB.SQLParam("ID")>
        Public ReadOnly Property Id As String Implements IDefaultPropProvider.Id
            Get
                Return _id
            End Get
        End Property
#End Region


        Public Sub New()
            init()
        End Sub

        Public Sub init()
            Dim sql As String = "EXEC USP_FRAMEWORK_INIT @OBJECT_NAME='" + TypeName + "'"
            Dim dl As New DataLayer(WORKFLOWDB)

            Dim resp = dl.SelectData(sql)

            If resp.Success And resp.HasTable Then
                For Each r As DataRow In resp.GetData(0).Rows
                    Eventbindings.Add(r("event"), r("sp"))
                Next
            Else

            End If



        End Sub


        Public Function GetItems() As Dictionary(Of String, String) Implements IActionContext(Of T).GetItems
            Dim sql As String
            Dim dl As New DataLayer(WORKFLOWDB)
            Dim lst As New Dictionary(Of String, String)
            sql = "exec " + Eventbindings("init") + " @userid ='" + UserID + "'"

            Dim resp = dl.SelectData(sql)

            If resp.Success And resp.HasTable Then
                For Each row As DataRow In resp.GetData(0).Rows
                    lst.Add(row(0), row(1))
                Next

            End If


            Return lst
        End Function

        Public MustOverride Function GetItem(id As String) As T Implements IActionContext(Of T).GetItem




    End Class
End Namespace