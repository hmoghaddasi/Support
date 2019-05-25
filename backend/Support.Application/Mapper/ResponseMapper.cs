using System;
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
                //ResponseShDate = DateConvert.GetShamsiDateTime(model.ResponseDate),
                Note = model.Note,
                Private = model.Private,
                CreateBy = model.CreateBy.FirstName + " " + model.CreateBy.LastName
            };
        }
        public static Response MapToModel(ResponseDTO dto)
        {
            return new Response()
            {
                ResponseId = dto.ResponseId,
                ResponseDate = DateTime.Now,
                CreateById = dto.CreateById,
                RequestId = dto.RequestId,
                Note = dto.Note,
                Private = dto.Private

            };
        }
    }
}
