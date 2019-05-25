using System;
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
                Assigned = model.Assigned.FirstName + " " + model.Assigned.LastName,
                Title = model.Title,
                Description = model.Description,
                RequestBy = model.RequestBy.FirstName + " " + model.RequestBy.LastName,
                Status = model.Status.ConfigName,
                TypeId = model.TypeId,
                Type = model.Type.ConfigName,
                PriorityId = model.PriorityId,
                Priority = model.Priority.ConfigName,
                //Responses = model.Responses.Select(ResponseMapper.Map).ToList()
            };
        }
        public static Request MapToModel(RequestDTO dto)
        {
            return new Request()
            {
                RequestId = dto.RequestId,
                RequestDate = DateTime.Now,
                RequestById = dto.RequestById,
                StatusId = dto.StatusId,
                Title = dto.Title,
                AssignedId = dto.AssignedId,
                Description = dto.Description,
                TypeId = dto.TypeId,
                PriorityId = dto.PriorityId,

            };
        }
    }
}
