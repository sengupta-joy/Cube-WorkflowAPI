



Imports System
Imports CUBE_WorkflowAPI.App_Code.DB
Imports CUBE_WorkflowAPI.App_Code.Framework.AutoMapper
Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW

Namespace App_Code.WorkflowFramework
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


        Friend Sub New()

        End Sub
        Friend Sub New(workflowid As String)
            LoadItem(workflowid)
        End Sub

        Public Shared Function getItem(id As String) As WorkflowCls
            Return New WorkflowCls(id)
        End Function
        Public Shared Function createItem(company As Entity) As WorkflowCls
            Dim obj As New WorkflowCls()

            obj.Company = company.ID
            Return obj
        End Function


    End Class
End Namespace
