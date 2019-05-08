using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Support.Domain.IRepository;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Repository
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly dbContext _context;
        public ResponseRepository(dbContext context)
        {
            this._context = context;
        }

        public Response GetById(int responseId)
        {
            return _context.Responses.Find(responseId);
        }
        public List<Response> GetAll()
        {
            return _context.Responses.ToList();
        }
        public List<Response> Get(Expression<Func<Response, bool>> predicate)
        {
            return _context.Responses.Where(predicate).ToList();
        }
        public void Create(Response response)
        {
            _context.Responses.Add(response);
        }
        public void Edit(Response response)
        {
        }
        public void Delete(int responseId)
        {
            _context.Responses.Remove(_context.Responses.Find(responseId));
        }


    }
}