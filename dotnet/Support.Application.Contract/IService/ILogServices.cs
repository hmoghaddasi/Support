using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Support.Application.Contract.DTO;
using Support.Domain.Model;

namespace Support.Application.Contract.IService
{
    public interface ILogServices : Framework.Core.OnionClass.IApplicationService
    {
         List<LogDTO> Get(Expression<Func<Log, bool>> predicate);
        void Create(LogDTO accessvm);
      
    }
}
