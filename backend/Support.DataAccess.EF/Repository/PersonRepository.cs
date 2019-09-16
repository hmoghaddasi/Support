using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Core.Filtering;
using Microsoft.EntityFrameworkCore;
using Support.Application.Contract.Constant;
using Support.Domain.Exception;
using Support.Domain.IRepositories;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SupportDbContext _context;
        public PersonRepository(SupportDbContext context)
        {
            this._context = context;
        }

        public Person GetById(int personId)
        {
            return _context.Persons.Find(personId);
        }
        public List<Person> GetAll()
        {
            return _context.Persons
                 .Include(a => a.Status)
                .ToList();
        }

        public List<Person> Get(Expression<Func<Person, bool>> predicate)
        {
            return _context.Persons
                .Include(a => a.Status)
                .Where(predicate).ToList();
        }
        public List<Person> GetDropDown(Expression<Func<Person, bool>> predicate)
        {
            return _context.Persons
                .Where(predicate).ToList();
        }
        public bool GetAuthenticated(string loginName, string password)
        {
            return _context.Persons.Any(a => a.LoginName == loginName && a.Password == password);
        }

        public int Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person.PersonId;
        }
        public void Edit(Person person)
        {
            _context.SaveChanges();
        }
        public void Delete(int personId)
        {
            var model = GetForDelete(personId);
            _context.Persons.Remove(_context.Persons.Find(personId));
            _context.SaveChanges();
        }
        private Person GetForDelete(int personId)
        {
            return _context.Persons.Where(a => a.PersonId == personId)
                .Include(a => a.AccessPolicies).Include(a => a.CreateResponses).Include(a => a.AssignResponses)
                .Include(a => a.Requests).First();
        }
        public int CreateClient(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person.PersonId;
        }

        public Person GetByUsername(string userName, string password)
        {
            var person = Get(a => a.LoginName.ToLower() == userName
                             && a.Password == password);
            if (person.Any())
            {
                return person.First();
            }
            throw new PersonNotFoundException();
        }

        public FilterResponse<Person> GetForGrid(GridRequest request, int statusId)
        {
            if (statusId != PersonStatus.All)
            {
                return _context.Persons.Where(a => a.StatusId == statusId || statusId == 0)
                .Include(a => a.Status)
                .AsQueryable().ApplyFilters(request);
            }
            else
            {
                return _context.Persons                
                .Include(a => a.Status)
                .AsQueryable().ApplyFilters(request);
            }
        }
    }
}