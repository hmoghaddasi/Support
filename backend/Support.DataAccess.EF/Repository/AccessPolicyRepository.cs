using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Support.Domain.IRepositories;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Repository
{
    public class AccessPolicyRepository : IAccessPolicyRepository
    {
        private readonly SupportDbContext context;
        public AccessPolicyRepository(SupportDbContext context)
        {
            this.context = context;
        }
        public void Create(AccessPolicy accessPolicy)
        {
            context.AccessPolicies.Add(accessPolicy);
            context.SaveChanges();
        }
        public void Delete(AccessPolicy accessPolicy)
        {
            context.AccessPolicies.Remove(accessPolicy);
            context.SaveChanges();
        }
        public void Edit(AccessPolicy accessPolicy)
        {
            context.SaveChanges();
        }
        public List<AccessPolicy> GetAll()
        {
            return context.AccessPolicies.Include(a => a.Access).Include(a => a.Person).ToList();
        }
        public AccessPolicy GetById(int accessPolicyId)
        {
            return context.AccessPolicies.Find(accessPolicyId);
        }
        public List<AccessPolicy> Get(Expression<Func<AccessPolicy, bool>> predicate)
        {
            return context.AccessPolicies.Include(a => a.Access).Include(a => a.Person).Where(predicate).ToList();
        }

        public void AddRange(List<AccessPolicy> accessPolicies)
        {
            context.AccessPolicies.AddRange(accessPolicies);
        }
    }
}