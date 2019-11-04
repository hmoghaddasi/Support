using System.Collections.Generic;
using System.Data.SqlClient;
using Framework.Core.OnionClass;

namespace Framework.Core.SQLAction
{
    public interface IGenericSQLAction<T> : IRegisterClass where T : class
    {
        List<T> ExecuteSqlStoredProcedureList(string spName, string parameterName, params SqlParameter[] spParamerList);
        C CallSqlFunction<C>(string functionName, string parameterName, params SqlParameter[] paramerList) where C : struct;
        object ExecuteSqlStoredProcedure(string spName, string parameterName, params SqlParameter[] spParamerList);
    }
}