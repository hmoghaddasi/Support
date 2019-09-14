using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Core.Filtering;
using Support.Domain.Model;

namespace Support.Domain.IRepositories
{
    public interface IConfigRepository : IRepository
    {
        List<Config> GetAll();
        Config GetById(int Id);
        List<Config> Get(Expression<Func<Config, bool>> predicate);
        void Create(Config config);
        void Edit(Config config);
        void Delete(Config config);
        FilterResponse<Config> GetForGrid(GridRequest request, int parentId);

    }
}

