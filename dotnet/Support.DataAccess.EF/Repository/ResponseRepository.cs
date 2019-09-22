using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Support.Domain.Model;
using System.Data.Entity;
using Support.Domain.IRepository;

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
            return _context.Responses.Include(a => a.CreateBy).Include(a => a.Request).ToList();
        }
        public List<Response> Get(Expression<Func<Response, bool>> predicate)
        {
            return _context.Responses.Include(a => a.CreateBy).Include(a => a.Request).Where(predicate).ToList();
        }
        public void Create(Response response)
        {
            _context.Responses.Add(response);
            _context.SaveChanges();
        }
        public void Edit(Response response)
        {
            _context.SaveChanges();

        }
        public void Delete(int responseId)
        {
            _context.Responses.Remove(_context.Responses.Find(responseId));
            _context.SaveChanges();

        }


    }
}