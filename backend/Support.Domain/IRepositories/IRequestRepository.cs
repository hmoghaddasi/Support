using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Support.Domain.Model;

namespace Support.Domain.IRepositories
{
    public interface IRequestRepository /*: Framework.Core.OnionClass.IRepository*/
    {

        Request GetById(int requestId);
        List<Request> GetAll();
        List<Request> Get(Expression<Func<Request, bool>> predicate);
        void Create(Request request);
        void Edit(Request request);
        void Delete(int requestId);

    }
}