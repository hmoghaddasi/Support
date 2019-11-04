using Support.Application.Contract.DTO;
using Support.Domain.Model;

namespace Support.Application.Mapper
{
    public class LogMapper
    {
        public static LogDTO Map(Log log)
        {
            return new LogDTO()
            {
                LogId = log.LogId,
                //Date = DateConvert.ConvertToPersian(log.Date),
                EntityName = log.EntityName,
                PersonId = log.PersonId,
                Description = log.Description,
                PrimaryKey = log.PrimaryKey,
                PersonName = log.Person.FirstName+" "+log.Person.LastName
            };
        }
      
        public static Log MapToModel(LogDTO log)
        {
            return new Log()
            {
                LogId = log.LogId,
                //Date = DateConvert.ConvertToMiladi(log.Date),
                EntityName = log.EntityName,
                PersonId = log.PersonId,
                PrimaryKey = log.PrimaryKey,
                Description = log.Description
                
            };
        }
    }
}
