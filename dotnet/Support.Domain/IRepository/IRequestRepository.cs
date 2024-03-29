using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Core.Filtering;
using Support.Domain.Model;

namespace Support.Domain.IRepository
{
    public interface IRequestRepository : Framework.Core.OnionClass.IRepository
    {

        Request GetById(int requestId);
        List<Request> GetAll();
        List<Request> Get(Expression<Func<Request, bool>> predicate);
        void Create(Request request);
        void Edit(Request request);
        void Delete(int requestId);
        FilterResponse<Request> GetForGrid(GridRequest request, Expression<Func<Request, bool>> predicate);
        Request GetByIdExtended(int id);
    }
}