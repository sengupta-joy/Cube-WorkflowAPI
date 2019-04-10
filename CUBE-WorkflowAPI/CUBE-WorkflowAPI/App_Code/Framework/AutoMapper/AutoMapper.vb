
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Reflection
Imports CUBE_WorkflowAPI.App_Code.DB


Namespace App_Code.Framework.AutoMapper
    Public MustInherit Class AutoMapperCls : Implements iMapper

        Protected Sub mapFromDB(Data As DataTable) Implements iMapper.map
            MapDataFromDB(Data, Me)
        End Sub
        Protected Function map2DB() As List(Of SqlClient.SqlParameter)
            Return MapDataToDB(Me)
        End Function

        Private Sub MapDataFromDB(dt As DataTable, ByRef obj As iMapper)
            For Each p As PropertyInfo In obj.GetType().GetProperties().ToList()
                For Each attr In p.GetCustomAttributes().ToList()
                    If TypeOf attr Is SQLParam Then
                        Dim paramName = DirectCast(attr, SQLParam).ParameterName
                        Dim paramType = DirectCast(attr, SQLParam).ParameterType
                        Dim paramValue = dt.Rows(0)(DirectCast(attr, SQLParam).ParameterName)

                        If p.CanWrite Then
                            If Not paramType = ParamTypes.StringType Then
                                setValue(p, obj, paramValue, paramType)
                            Else
                                p.SetValue(obj, paramValue)
                            End If
                        End If
                    End If
                Next
            Next
        End Sub

        Private Sub setValue(p As PropertyInfo, obj As iMapper, paramValue As Object, paramType As ParamTypes)
            If paramType = ParamTypes.BooleanType Then
                p.SetValue(obj, Boolean.Parse(paramValue))
            ElseIf paramType = ParamTypes.IntType Then
                p.SetValue(obj, Integer.Parse(paramValue))
            ElseIf paramType = ParamTypes.DateType Then
                p.SetValue(obj, Date.Parse(paramValue))
            End If
        End Sub

        Private Function MapDataToDB(obj As iMapper) As List(Of SqlClient.SqlParameter)
            Dim SQLParams As New List(Of SqlClient.SqlParameter)

            For Each p As PropertyInfo In obj.GetType().GetProperties().ToList()
                For Each attr In p.GetCustomAttributes().ToList()
                    If TypeOf attr Is SQLParam Then
                        Dim paramName = DirectCast(attr, SQLParam).ParameterName
                        Dim paramType = DirectCast(attr, SQLParam).ParameterType

                        If p.CanRead Then
                            Dim param As New SqlClient.SqlParameter()

                            param.ParameterName = paramName
                            param.SqlDbType = mapSQLDBType(paramType)
                            param.Value = p.GetValue(obj)

                            SQLParams.Add(param)
                        End If


                    End If
                Next
            Next


            Return SQLParams
        End Function

        Private Function mapSQLDBType(paramType As ParamTypes) As SqlDbType
            If paramType = ParamTypes.BooleanType Then
                Return SqlDbType.VarChar
            End If

            Return SqlDbType.VarChar
        End Function
    End Class
End Namespace


