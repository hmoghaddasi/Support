using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Support.Domain.Model;
using Support.Domain.Repositories;

namespace Support.DataAccess.EF.Repository
{
    public class AccessPolicyRepository : IAccessPolicyRepository
    {
        private readonly SupportDbContext _context;
        public AccessPolicyRepository(SupportDbContext context)
        {
            this._context = context;
        }

        public AccessPolicy GetById(int accessPolicyId)
        {
            return _context.AccessPolicies.Find(accessPolicyId);
        }
        public List<AccessPolicy> GetAll()
        {
            return _context.AccessPolicies
                            .Include(a => a.Person).Include(a => a.Access)
                            .ToList();
        }
        public List<AccessPolicy> Get(Expression<Func<AccessPolicy, bool>> predicate)
        {
            return _context.AccessPolicies
                            .Include(a => a.Person).Include(a => a.Access)
                            .Where(predicate).ToList();
        }
        public void Create(AccessPolicy accessPolicy)
        {
            _context.AccessPolicies.Add(accessPolicy);
        }
        public void Edit(AccessPolicy accessPolicy)
        {
        }
        public void Delete(int accessPolicyId)
        {
            _context.AccessPolicies.Remove(_context.AccessPolicies.Find(accessPolicyId));
        }

        public void AddRange(List<AccessPolicy> list)
        {
            _context.AccessPolicies.AddRange(list);
        }
    }
}