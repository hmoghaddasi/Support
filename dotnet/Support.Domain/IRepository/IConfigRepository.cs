using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Core.Filtering;
using Support.Domain.Model;

namespace Support.Domain.IRepository
{
	public interface IConfigRepository: Framework.Core.OnionClass.IRepository
	{	    
		void Create(Config config);
		void Delete(Config config);
	    void Edit(Config config);		   
		List<Config> GetAll();
        Config GetById(int ConfigId);
        List<Config> Get(Expression<Func<Config, bool>> predicate);
        FilterResponse<Config> GetForGrid(GridRequest request, int parentId);
    }
}