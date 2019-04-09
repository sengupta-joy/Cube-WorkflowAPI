Imports System.Data

Namespace App_Code.DB
    Public Class SelectResponse

        Private _data As New DataSet
        Private _success As Boolean
        Private _msg As String


        Public Sub New(isSuccess As Boolean, Msg As String)
            _success = isSuccess
            _msg = Msg
        End Sub

        Public ReadOnly Property Data As DataSet
            Get
                Return _data
            End Get
        End Property
        Public ReadOnly Property Success As Boolean
            Get
                Return _success
            End Get
        End Property
        Public ReadOnly Property Message As String
            Get
                Return _msg
            End Get
        End Property

        Public ReadOnly Property HasTable As Boolean
            Get
                Return IIf(Data.Tables.Count > 0, True, False)
            End Get
        End Property

        Public Function GetData(tableIndex As Integer) As DataTable
            Return Me.Data.Tables(tableIndex)
        End Function

        Public Function GetData(tableIndex As Integer, rowIndex As Integer, colIndex As Integer) As Object
            Return Me.Data.Tables(tableIndex).Rows(rowIndex)(colIndex)
        End Function

        Public Function GetData(tableIndex As Integer, rowIndex As Integer) As DataRow
            Return Me.Data.Tables(tableIndex).Rows(rowIndex)
        End Function
    End Class
End Namespace
