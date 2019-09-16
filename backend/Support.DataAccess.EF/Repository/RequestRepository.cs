using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Core.Filtering;
using Microsoft.EntityFrameworkCore;
using Support.Domain.IRepositories;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly SupportDbContext _context;
        public RequestRepository(SupportDbContext context)
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
            _context.SaveChanges();
        }
        public void Edit(Request request)
        {
            _context.SaveChanges();

        }
        public void Delete(int requestId)
        {
            var model = GetForDelete(requestId);
            GaurdDeleteForignKey(model);
            _context.Requests.Remove(model);
            _context.SaveChanges();
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
        public FilterResponse<Request> GetForGrid(GridRequest request, Expression<Func<Request, bool>> predicate)
        {
            var reportRow = _context.Requests.Include(a => a.Responses)
                .Include(a => a.Assigned)
                .Include(a => a.RequestBy)
                .Include(d => d.Status)
                .Include(d => d.Type)
                .Include(d => d.Priority)
                .Include(d => d.Project)
           .AsQueryable();
            if (predicate != null)
            {
                reportRow = reportRow.Where(predicate);
            }
            return reportRow.ApplyFilters(request);
        }
    }
    internal class ForignkeyDeleteException : Exception
    {
    }
}