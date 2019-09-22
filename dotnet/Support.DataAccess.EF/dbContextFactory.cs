using System.Data.Entity.Infrastructure;
using Framework.Core.Data;

namespace Support.DataAccess.EF
{
    public class DbContextFactory : IDbContextFactory<dbContext>
    {
        public dbContext Create()
        {
            var sqlConnection = ConnectionFactory.Create("DBConnection");
            return new dbContext(sqlConnection, true);
        }
    }

}
