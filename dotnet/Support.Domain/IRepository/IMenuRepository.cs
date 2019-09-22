using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Support.Domain.Model;

namespace Support.Domain.IRepository
{
    public interface IMenuRepository : Framework.Core.OnionClass.IRepository
    {
        List<Menu> GetAll();
        Menu GetById(int menuId);
        List<Menu> Get(Expression<Func<Menu, bool>> predicate);
        void Create(Menu menuId);
        void Edit(Menu menu);
        void Delete(Menu menu);

    }
}

