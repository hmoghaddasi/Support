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
        void Create(LogDTO accessvm);
      
    }
}
