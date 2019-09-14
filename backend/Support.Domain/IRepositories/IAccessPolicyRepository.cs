using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Support.Domain.Model;

namespace Support.Domain.IRepositories
{
    public interface IAccessPolicyRepository /*: Framework.Core.OnionClass.IRepository*/
    {
        void Create(AccessPolicy accessPolicy);
        void Delete(AccessPolicy accessPolicy);
        void Edit(AccessPolicy accessPolicy);
        List<AccessPolicy> GetAll();
        AccessPolicy GetById(int AccessPolicyId);
        List<AccessPolicy> Get(Expression<Func<AccessPolicy, bool>> predicate);
        void AddRange(List<AccessPolicy> accessPolicies);
    }
}

