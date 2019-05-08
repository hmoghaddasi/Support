using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Support.Domain.IRepository;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly dbContext _context;
        public RequestRepository(dbContext context)
        {
            this._context = context;
        }

        public Request GetById(int requestId)
        {
            return _context.Requests.Find(requestId);
        }
        public List<Request> GetAll()
        {
            return _context.Requests.Include(a => a.Status).Include(a => a.Type)
                .Include(a => a.Priority).Include(a => a.RequestBy)
                .Include(a => a.Responses).Include(a => a.Assigned)
                .Include("Responses.CreateBy")
                .ToList();
        }
        public List<Request> Get(Expression<Func<Request, bool>> predicate)
        {
            return _context.Requests.Include(a => a.Status).Include(a => a.Type)
                .Include(a => a.Priority).Include(a => a.RequestBy)
                .Include(a => a.Responses).Include(a => a.Assigned)
                .Include("Responses.CreateBy")
                .Where(predicate).ToList();
        }


        public void Create(Request request)
        {
            _context.Requests.Add(request);
        }
        public void Edit(Request request)
        {
        }
        public void Delete(int requestId)
        {

            var model = GetForDelete(requestId);
            GaurdDeleteForignKey(model);
            _context.Requests.Remove(model);
        }

        private static void GaurdDeleteForignKey(Request model)
        {
            if (model.Responses.Any())
            {
                throw new ForignkeyDeleteException();
            }
        }

        private Request GetForDelete(int requestId)
        {
            return _context.Requests.Where(a => a.RequestId == requestId)
                .Include(a => a.Responses).First();
        }

    }
}