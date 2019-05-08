using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Support.Domain.IRepository;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly dbContext _context;
        public LogRepository(dbContext context)
        {
            this._context = context;
        }

        public Log GetById(int logId)
        {
            return _context.Logs.Find(logId);
        }
        public List<Log> GetAll()
        {
            return _context.Logs.ToList();
        }
        public List<Log> Get(Expression<Func<Log, bool>> predicate)
        {
            return _context.Logs.Where(predicate).ToList();
        }
        public void Create(Log log)
        {
            _context.Logs.Add(log);
        }
        public void Edit(Log log)
        {
        }
        public void Delete(int logId)
        {
            _context.Logs.Remove(_context.Logs.Find(logId));
        }


    }
}