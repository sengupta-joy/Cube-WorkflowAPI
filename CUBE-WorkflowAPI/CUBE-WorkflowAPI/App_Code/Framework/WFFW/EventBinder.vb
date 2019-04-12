


Namespace App_Code.Framework.WFFW

    Public Class EventBinder

        Private dicObj As New Dictionary(Of EventBindingTypes, String)

        Public Sub add(key As String, sp As String)
            If key.ToUpper().Equals("init".ToUpper()) Then
                dicObj.Add(EventBindingTypes.INIT, sp)
            ElseIf key.ToUpper().Equals("loadItem".ToUpper()) Then
                dicObj.Add(EventBindingTypes.LOAD_ITEM, sp)
            ElseIf key.ToUpper().Equals("save".ToUpper()) Then
                dicObj.Add(EventBindingTypes.SAVE, sp)
            End If
        End Sub

        Public Function getEvent(evt As EventBindingTypes) As String
            Return dicObj(evt)
        End Function

    End Class

End Namespace