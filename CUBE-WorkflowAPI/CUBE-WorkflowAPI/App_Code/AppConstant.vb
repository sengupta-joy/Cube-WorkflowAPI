Public Module AppConstant
    Public USERDB As String = ConfigurationManager.ConnectionStrings.Item("UserDB").ConnectionString

    Public Enum ParamTypes
        BooleanType
        StringType
        IntType
        LongType
        DateType
        FloatType
        DoubleType
    End Enum


End Module
