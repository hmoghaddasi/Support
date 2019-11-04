using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Core.Filtering;
using Support.Domain.Model;

namespace Support.Domain.IRepository
{
	public interface IPersonRepository: Framework.Core.OnionClass.IRepository
	{	    
		void Delete(Person person);
	    void Edit(Person person);		   
		List<Person> GetAll();
        Person GetById(int PersonId);
        List<Person> Get(Expression<Func<Person, bool>> predicate);      
		FilterResponse<Person> GetForGrid(GridRequest request, int statusId);
        Person GetByUsername(string dtoUserName, string hashPass);
        void Create(Person person);
    }
}