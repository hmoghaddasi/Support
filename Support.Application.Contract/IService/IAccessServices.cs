using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IAccessServices:IApplicationService
    {
         int CreateOrUpdate(AccessDTO dto);
        AccessDTO GetById(int Id);
        string GetAllAccessId(string loginName);
        void Create(AccessDTO accessvm);
        void Delete(int Id);
        void Edit(AccessDTO accessvm);

    }
}
