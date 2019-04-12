

Namespace App_Code.Framework.WFFW
    Public Enum EventBindingTypes
        <EventBindingAttribute("Init")>
        INIT
        <EventBindingAttribute("LoadItem")>
        LOAD_ITEM
        <EventBindingAttribute("Save")>
        SAVE
    End Enum

    Public Class EventBindingAttribute : Inherits Attribute

        Private _nm As String

        Public ReadOnly Property Name As String
            Get
                Return _nm
            End Get
        End Property


        Public Sub New(nm As String)
            _nm = nm
        End Sub
    End Class


End Namespace

