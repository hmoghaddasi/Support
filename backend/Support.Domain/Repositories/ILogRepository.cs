using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Support.Domain.Model;

namespace Support.Domain.Repositories
{
    public interface ILogRepository /*: Framework.Core.OnionClass.IRepository*/
    {
        List<Log> GetAll();
        List<Log> Get(Expression<Func<Log, bool>> predicate);
        void Create(Log log);
    }
}

