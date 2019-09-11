using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Support.Domain.Model;

namespace Support.Domain.IRepositories
{
    public interface IAccessRepository /*: Framework.Core.OnionClass.IRepository*/
    {
        List<Access> GetAll();
        Access GetById(int Id);
        List<Access> Get(Expression<Func<Access, bool>> predicate);
        void Create(Access access);
        void Edit(Access access);
        void Delete(Access access);

    }
}

