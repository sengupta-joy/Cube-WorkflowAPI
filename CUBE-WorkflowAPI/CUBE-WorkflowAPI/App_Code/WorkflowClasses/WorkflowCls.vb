



Imports CUBE_WorkflowAPI.App_Code.DB
Imports CUBE_WorkflowAPI.App_Code.Framework.AutoMapper
Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW

Namespace App_Code.WorkflowFramework

    <Serializable>
    Public Class WorkflowCls : Inherits WorkflowFrameworkBase(Of WorkflowCls)

        Private _actv As String
        Private _enbl As String
        Private _comp As String
        Private _crtdby As String
        Private _crtdon As Date

#Region "Properties"
        <SQLParam("Active", ParamTypes.BooleanType)>
        Public Property Active As String
            Get
                Return _actv
            End Get
            Set(value As String)
                _actv = value
            End Set
        End Property

        <SQLParam("Enable", ParamTypes.BooleanType)>
        Public Property Enable As String
            Get
                Return _enbl
            End Get
            Set(value As String)
                _enbl = value
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

        <SQLParam("CreatedBy")>
        Public Property CreatedBy As String
            Get
                Return _crtdby
            End Get
            Set(value As String)
                _crtdby = value
            End Set
        End Property

        <SQLParam("CreatedOn", ParamTypes.DateType)>
        Public Property CreatedOn As Date
            Get
                Return _crtdon
            End Get
            Set(value As Date)
                _crtdon = value
            End Set
        End Property
#End Region


        Protected Friend Sub New()

        End Sub
        Friend Sub New(workflowid As String)

            LoadItem(workflowid)

            'Dim sql As String
            'Dim dl As New DataLayer(WORKFLOWDB)
            'Dim resp As SelectResponse
            '_id = workflowid

            'sql = "exec " + EventBindings(EventBindingTypes.LOAD_ITEM) + " @ITEMID ='" + workflowid + "'"

            'resp = dl.SelectData(sql)
            'If resp.Success Then
            '    mapFromDB(resp.GetData(0))
            'Else
            '    Throw New Exception("Error loading workflow")
            'End If

        End Sub

        Public Shared Function getIte(id As String) As WorkflowCls
            Return New WorkflowCls(id)
        End Function



    End Class
End Namespace
