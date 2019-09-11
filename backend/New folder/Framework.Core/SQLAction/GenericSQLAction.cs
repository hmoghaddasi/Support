using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Framework.Core.SQLAction
{
    public class GenericSQLAction<T> : IGenericSQLAction<T> where T : class
    {
        internal DbContext db;

        public GenericSQLAction(DbContext db)
        {
            this.db = db;
        }

        public List<T> ExecuteSqlStoredProcedureList(string spName, string parameterName,
            params SqlParameter[] spParamerList)
        {

            if (parameterName != "")
            {
                var result = db.Database.SqlQuery<T>("Exec " + spName + " " + parameterName, spParamerList).ToList();
                return result;
            }
            else
            {
                var result = db.Database.SqlQuery<T>("Exec " + spName).ToList();
                return result;
            }
        }

        public C CallSqlFunction<C>(string functionName, string parameterName, params SqlParameter[] paramerList) where C : struct
        {

            var obj = db.Database.SqlQuery<C>("select " + functionName + " ( " + parameterName + " ) ", paramerList).First();

            return obj;
        }

        public object ExecuteSqlStoredProcedure(string spName, string parameterName, params SqlParameter[] spParamerList)
        {
            var result = db.Database.ExecuteSqlCommand("Exec " + spName + " " + parameterName, spParamerList);
            return result;
        }
    }
}
