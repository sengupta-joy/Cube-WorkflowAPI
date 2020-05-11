
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Web
Imports CUBE_WorkflowAPI.App_Code.DB
Imports CUBE_WorkflowAPI.App_Code.Framework.AutoMapper

Namespace App_Code.Framework.WFFW
    <Serializable>
    Public MustInherit Class WorkflowFrameworkBase(Of T) : Inherits AutoMapperCls : Implements IActionContext(Of T), IDefaultPropProvider

        Shared EventBindings As New EventBinder()
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
        Public Property ID As String Implements IDefaultPropProvider.Id
            Get
                Return _id
            End Get
            Set(value As String)
                _id = value
            End Set
        End Property
#End Region

        Shared Sub New()
            Dim sql As String = "EXEC USP_FRAMEWORK_INIT"
            Dim dl As New DataLayer(WORKFLOWDB)

            Dim resp = dl.SelectData(sql)

            If resp.Success And resp.HasTable Then
                For Each r As DataRow In resp.GetData(0).Rows
                    EventBindings.add(r("event"), r("sp"), r("objName"))
                Next
            Else
                Throw New Exception("Event bindings not found")
            End If
        End Sub

        Public Sub New()
            Init()
        End Sub

        Private Sub Init()
            'Dim sql As String = "EXEC USP_FRAMEWORK_INIT"
            'Dim dl As New DataLayer(WORKFLOWDB)

            'Dim resp = dl.SelectData(sql)

            'If resp.Success And resp.HasTable Then
            '    For Each r As DataRow In resp.GetData(0).Rows
            '        EventBindings.Add(r("event"), r("sp"))
            '    Next
            'Else
            '    Throw New Exception("Event bindings not found for " + TypeName)
            'End If
        End Sub


        Public Function GetItems() As Dictionary(Of String, String) Implements IActionContext(Of T).GetItems
            Dim sql As String
            Dim dl As New DataLayer(WORKFLOWDB)
            Dim lst As New Dictionary(Of String, String)
            sql = "exec " + EventBindings.getEvent(EventBindingTypes.INIT, Me.TypeName) + " @userid ='" + UserID + "'"

            Dim resp = dl.SelectData(sql)

            If resp.Success And resp.HasTable Then
                For Each row As DataRow In resp.GetData(0).Rows
                    lst.Add(row(0), row(1))
                Next
            Else
                Throw New Exception("Init SP not found for " + TypeName)
            End If


            Return lst
        End Function
        Public Function LoadItem(itemID As String) As T
            Dim sql As String
            Dim dl As New DataLayer(WORKFLOWDB)
            Dim resp As SelectResponse
            '_id = itemID

            sql = "exec " + EventBindings.getEvent(EventBindingTypes.LOAD_ITEM, Me.TypeName) + " @ITEMID ='" + itemID + "'"

            resp = dl.SelectData(sql)
            If resp.Success Then
                mapFromDB(resp.GetData(0))
            Else
                Throw New Exception("Error loading workflow")
            End If
        End Function
        Public Function LoadItem() As T
            Dim sql As String
            Dim dl As New DataLayer(WORKFLOWDB)
            Dim resp As SelectResponse
            '_id = itemID

            sql = "exec " + EventBindings.getEvent(EventBindingTypes.LOAD_ITEM, Me.TypeName) + " @ITEMID ='" + ID + "'"

            resp = dl.SelectData(sql)
            If resp.Success Then
                mapFromDB(resp.GetData(0))
            Else
                Throw New Exception("Error loading workflow")
            End If


        End Function

        Public Function Save() As Boolean Implements IActionContext(Of T).Save
            Dim params = map2DB()
            Dim dl As New DataLayer(WORKFLOWDB)
            Dim spName As String = EventBindings.getEvent(EventBindingTypes.SAVE, Me.TypeName)
            Dim resp As SelectResponse

            resp = dl.ExecuteSP(spName, CommandType.StoredProcedure, params)

            Return resp.Success
        End Function


        Protected Function loadFormfield() As String
            Dim x = Me.TypeName
            Return x
        End Function

    End Class
End Namespace