using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using iTextSharp.text;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.IRepository;
using Support.Domain.Model;

namespace Support.Application.Service
{
    public class LogServices : ILogServices
    {
        private readonly ILogRepository repository;
        public LogServices(ILogRepository repository)
        {
            this.repository = repository;

        }


        public List<LogDTO> Get(Expression<Func<Log, bool>> predicate)
        {
            return repository.Get(predicate).Select(LogMapper.Map).ToList();
        }


        public void Create(LogDTO log)
        {
            repository.Create(LogMapper.MapToModel(log));
        }

      
    }
}
