using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Support.Domain.Model;

namespace Support.Domain.Repositories
{
    public interface IResponseRepository /*: Framework.Core.OnionClass.IRepository*/
    {

        Response GetById(int responseId);
        List<Response> GetAll();
        List<Response> Get(Expression<Func<Response, bool>> predicate);
        void Create(Response response);
        void Edit(Response response);
        void Delete(int responseId);

    }
}