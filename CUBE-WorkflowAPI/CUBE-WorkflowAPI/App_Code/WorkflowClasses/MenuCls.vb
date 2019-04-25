

Imports CUBE_WorkflowAPI.App_Code.DB
Imports CUBE_WorkflowAPI.App_Code.Framework.AutoMapper
Imports CUBE_WorkflowAPI.App_Code.Framework.WFFW

Namespace App_Code.WorkflowFramework
    Public Class MenuCls : Inherits WorkflowFrameworkBase(Of MenuCls)


        Private _prnt As String
        Private _address As String
        Private _order As Integer

        <SQLParam("MENUPARENT")>
        Public Property Parent As String
            Get
                Return _prnt
            End Get
            Set(value As String)
                _prnt = value
            End Set
        End Property

        <SQLParam("MENUADDRESS")>
        Public Property Address As String
            Get
                Return _address
            End Get
            Set(value As String)
                _address = value
            End Set
        End Property

        <SQLParam("MENUORDER", ParamTypes.IntType)>
        Public Property Order As Integer
            Get
                Return _order
            End Get
            Set(value As Integer)
                _order = value
            End Set
        End Property


        Friend Sub New()

        End Sub
        Friend Sub New(menuid As String)
            LoadItem(menuid)
        End Sub


    End Class
End Namespace
