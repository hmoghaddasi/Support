using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface ILogServices : IApplicationService
    {
        IQueryable<LogDTO> GetAllIQueryable();
        List<LogDTO> Get(Expression<Func<Log, bool>> predicate);
        void Create(LogDTO accessvm);
      
    }
}
