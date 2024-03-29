﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Core.Filtering;
using Support.Domain.Model;

namespace Support.Domain.IRepositories
{
    public interface IPersonRepository /*: Framework.Core.OnionClass.IRepository*/
    {
     
        List<Person> GetAll();
        Person GetById(int Id);
        List<Person> Get(Expression<Func<Person, bool>> predicate);
        int Create(Person person);
        void Edit(Person person);
        void Delete(int personId);
        FilterResponse<Person> GetForGrid(GridRequest request, int statusId);
    }
}

