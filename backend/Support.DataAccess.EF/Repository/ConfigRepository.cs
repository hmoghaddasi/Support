using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Core.Filtering;
using Support.Domain.IRepositories;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Repository
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly SupportDbContext _context;
        public ConfigRepository(SupportDbContext context)
        {
            this._context = context;
        }

        public Config GetById(int configId)
        {
            return _context.Configs.Find(configId);
        }
        public List<Config> GetAll()
        {
            return _context.Configs.ToList();
        }
        public List<Config> Get(Expression<Func<Config, bool>> predicate)
        {
            return _context.Configs.Where(predicate).ToList();
        }
        public void Create(Config config)
        {
            _context.Configs.Add(config);
            _context.SaveChanges();
        }
        public void Edit(Config config)
        {
            _context.SaveChanges();
        }
        public void Delete(Config config)
        {
            _context.Configs.Remove(config);
            _context.SaveChanges();
        }
        public void Delete(int configId)
        {
            _context.Configs.Remove(_context.Configs.Find(configId));
        }

        public FilterResponse<Config> GetForGrid(GridRequest request, int parentId)
        {
            return _context.Configs.Where(a => a.ConfigHdrId == parentId)
           .AsQueryable().ApplyFilters(request);
        }
    }
}