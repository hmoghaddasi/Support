using System;
using Framework.Core.DateTime;
using Support.Application.Contract.DTO;
using Support.Domain.Model;

namespace Support.Application.Mapper
{
    public class ResponseMapper
    {
        public static ResponseDTO Map(Response model)
        {
            return new ResponseDTO()
            {
                ResponseId = model.ResponseId,
                CreateById = model.CreateById,
                RequestId = model.RequestId,
                ResponseDate = model.ResponseDate,
                ResponseShDate = DateConvert.GetShamsiDate(model.ResponseDate),
                Note = model.Note,
                Private = model.Private,
                CreateBy = model.CreateBy.FirstName + " " + model.CreateBy.LastName,
                Request = model.Request.Title
            };
        }
        public static Response MapToModel(ResponseCreateDTO dto, int personId)
        {
            return new Response()
            {
                ResponseDate = DateTime.Now,
                CreateById = personId,
                RequestId = dto.RequestId,
                Note = dto.Note,
                Private = false
            };
        }
    }
}
