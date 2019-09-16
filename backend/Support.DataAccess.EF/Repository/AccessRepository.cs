using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Core.Filtering;
using Support.Domain.IRepositories;
using Support.Domain.Model;
using Microsoft.EntityFrameworkCore;
namespace Support.DataAccess.EF.Repository
{
    public class AccessRepository : IAccessRepository
    {
        private readonly SupportDbContext _context;
        public AccessRepository(SupportDbContext context)
        {
            this._context = context;
        }

        public Access GetById(int accessId)
        {
            return _context.Accesses.Find(accessId);
        }
        public List<Access> GetAll()
        {
            return _context.Accesses.Include(d => d.AccessPolicies).ToList();
        }
        public List<Access> Get(Expression<Func<Access, bool>> predicate)
        {
            return _context.Accesses.Where(predicate).ToList();
        }
        public void Create(Access access)
        {
            _context.Accesses.Add(access);
            _context.SaveChanges();
        }
        public void Edit(Access access)
        {
            _context.SaveChanges();
        }

        public void Delete(Access access)
        {
            _context.Accesses.Remove(access);
            _context.SaveChanges();
        }
        public FilterResponse<Access> GetForGrid(GridRequest request)
        {
            return _context.Accesses.Include(x => x.AccessPolicies).AsQueryable().ApplyFilters(request);
        }

    }
}