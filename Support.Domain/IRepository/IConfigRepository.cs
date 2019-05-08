using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Support.Domain.Model;

namespace Support.Domain.IRepository
{
    public interface IConfigRepository /*: Framework.Core.OnionClass.IRepository*/
    {
        List<Config> GetAll();
        Config GetById(int Id);
        List<Config> Get(Expression<Func<Config, bool>> predicate);
        void Create(Config config);
        void Edit(Config config);
        void Delete(Config config);

    }
}

