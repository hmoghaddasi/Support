using System;
using System.Linq;
using Framework.Core.DateTime;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;
using Support.Domain.Model;

namespace Support.Application.Mapper
{
    public static class RequestMapper
    {
        public static RequestDTO Map(Request model)
        {
            return new RequestDTO()
            {
                RequestId = model.RequestId,
                RequestDate = model.RequestDate,
                RequestById = model.RequestById,
                StatusId = model.StatusId,
                AssignedId = model.AssignedId,
                Assigned = model.Assigned?.FirstName + " " + model.Assigned?.LastName,
                Title = model.Title,
                Description = model.Description,
                RequestBy = model.RequestBy.FirstName + " " + model.RequestBy.LastName,
                Status = model.Status.ConfigName,
                TypeId = model.TypeId,
                Type = model.Type.ConfigName,
                PriorityId = model.PriorityId,
                RequestShDate = DateConvert.GetShamsiDate(model.RequestDate),
                Priority = model.Priority.ConfigName,
                ProjectId = model.ProjectId,
                Project = model.Project.ConfigName
            };
        }
        public static RequestDetailDTO MapDto(Request model)
        {
            return new RequestDetailDTO()
            {
                RequestId = model.RequestId,
                RequestDate = model.RequestDate,
                RequestById = model.RequestById,
                StatusId = model.StatusId,
                AssignedId = model.AssignedId,
                Assigned = model.Assigned?.FirstName + " " + model.Assigned?.LastName,
                Title = model.Title,
                Description = model.Description,
                RequestBy = model.RequestBy.FirstName + " " + model.RequestBy.LastName,
                Status = model.Status.ConfigName,
                TypeId = model.TypeId,
                Type = model.Type.ConfigName,
                PriorityId = model.PriorityId,
                RequestShDate = DateConvert.GetShamsiDate(model.RequestDate),
                Priority = model.Priority.ConfigName,
                ProjectId = model.ProjectId,                
                Project = model.Project.ConfigName,
                Responses = model.Responses.Select(ResponseMapper.Map).ToList()
            };
        }
        public static Request MapToModel(RequestCreateDTO dto,int personId)
        {
            return new Request()
            {
                RequestDate = DateTime.Now,
                RequestById = personId,
                StatusId = RequestStatus.Open,
                Title = dto.Title,
                Description = dto.Description,
                TypeId = dto.TypeId,
                PriorityId = dto.PriorityId,
                ProjectId = dto.PriorityId,
                AssignedId = 0,                
            };
        }
    }
}
