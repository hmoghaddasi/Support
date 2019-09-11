using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        }
        public void Edit(Config config)
        {
        }
        public void Delete(Config config)
        {
            _context.Configs.Remove(config);
        }
        public void Delete(int configId)
        {
            _context.Configs.Remove(_context.Configs.Find(configId));
        }


    }
}