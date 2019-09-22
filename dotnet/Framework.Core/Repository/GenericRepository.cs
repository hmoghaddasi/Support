using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Framework.Core.Filtering;


namespace Framework.Core.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, string[] Includes)
        {
            var query = context.Set<TEntity>().AsQueryable();

            foreach (string include in Includes)
            {
                query = query.Include(include); //got to reaffect it.
            }
             
            return query.Where(predicate).ToList<TEntity>().AsEnumerable();

        }
        public FilterResponse<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate, GridRequest request, string[] Includes)
        {
            var query = context.Set<TEntity>().AsQueryable();

            foreach (string include in Includes)
            {
                query = query.Include(include); //got to reaffect it.
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ApplyFilters(request);
        }

        public virtual IEnumerable<TEntity> GetOrderBy(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params string[] Includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (Includes != null)
                foreach (var include in Includes)
                {
                    query = query.Include(include);
                }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IEnumerable<TEntity> GetAll(params string[] Includes)
        {
            var query = dbSet as IQueryable<TEntity>;
            foreach (string include in Includes)
            {
                query = query.Include(include);
            }
            return query;

        }



        public virtual TEntity GetById(int id, params string[] Includes)
        {
            //var query = dbSet as IQueryable<TEntity>;

            //Includes.ToList().ForEach(x => query = dbSet.Include(x));
            //return query.First(keySelector);
            //return query..Find(id);


            return dbSet.Find(id);

        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual long Create(TEntity entity,bool isSave=false)
        {
            dbSet.Add(entity);

            if (isSave) this.Save();

            var propId = $@"{typeof(TEntity).Name}Id";
            var Id = Convert.ToInt64(entity.GetType().GetProperty(propId).GetValue(entity, null));

            return Id;
       
        }

        public virtual void Delete(object id,bool isSave=false)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete, isSave);           
        }

        public virtual void Delete(TEntity entityToDelete, bool isSave = false)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            if (isSave) this.Save();
        }


        public virtual long Edit(TEntity entityToUpdate, bool isSave = false)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;


            var propId = $@"{typeof(TEntity).Name}Id";
            if (isSave) this.Save();
            return long.Parse(entityToUpdate.GetType().GetProperty(propId).GetValue(entityToUpdate, null).ToString());
        }
    }
}
