


Imports System.Data

Namespace App_Code.Framework.WFFW

    Public Class EventBinder

        Private dicObj As New List(Of EventBinderListItem)


        Public Sub add(key As String, sp As String, objName As String)

            If key.ToUpper().Equals("init".ToUpper()) Then
                dicObj.Add(New EventBinderListItem(objName, EventBindingTypes.INIT, sp))
            ElseIf key.ToUpper().Equals("loadItem".ToUpper()) Then
                dicObj.Add(New EventBinderListItem(objName, EventBindingTypes.LOAD_ITEM, sp))
            ElseIf key.ToUpper().Equals("save".ToUpper()) Then
                dicObj.Add(New EventBinderListItem(objName, EventBindingTypes.SAVE, sp))
            End If

        End Sub

        Public Function getEvent(evt As EventBindingTypes, objName As String) As String
            Dim retVal = dicObj.Where(Function(x) x.ObjName = objName And x.EvtType = evt).ToList()(0).SP
            Return retVal
        End Function

    End Class

    Public Structure EventBinderListItem
        Public ObjName As String
        Public EvtType As EventBindingTypes
        Public SP As String

        Public Sub New(_obj As String, _type As EventBindingTypes, _sp As String)
            ObjName = _obj
            EvtType = _type
            SP = _sp
        End Sub


    End Structure
End Namespace