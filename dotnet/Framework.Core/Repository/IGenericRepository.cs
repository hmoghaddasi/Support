using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Core.Filtering;

namespace Framework.Core.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        long Create(TEntity entity, bool isSave=false);

        long Edit(TEntity entity, bool isSave = false);
        void Delete(TEntity entityToDelete, bool isSave = false);
        void Delete(object id,bool isSave = false);
        //void Edit(TEntity entityToUpdate);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params string[] Includes);
        IEnumerable<TEntity> GetAll(params string[] Includes);
        //FilterResponse<TEntity> GetAllF(GridRequest request, Expression<Func<TEntity, bool>> filter = null, params string[] Includes);
        FilterResponse<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate, GridRequest request, params string[] Includes);
        IEnumerable<TEntity> GetOrderBy(Expression<Func<TEntity, bool>> filter = null,

        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params string[] Includes);
        TEntity GetById(int id, params string[] Includes);

        void Save();
        //  int GetPersonIdByLoginName(string loginName);
    }
}