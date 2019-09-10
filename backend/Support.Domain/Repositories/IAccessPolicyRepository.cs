﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Support.Domain.Model;

namespace Support.Domain.Repositories
{
    public interface IAccessPolicyRepository /*: Framework.Core.OnionClass.IRepository*/
    {
        List<AccessPolicy> GetAll();
        AccessPolicy GetById(int accessPolicyId);
        List<AccessPolicy> Get(Expression<Func<AccessPolicy, bool>> predicate);
        void Create(AccessPolicy accessPolicy);
        void Delete(int accessPolicyId);

        void AddRange(List<AccessPolicy> list);
    }
}
