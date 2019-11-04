using Support.Application.Contract.DTO;
using Support.Domain.Model;

namespace Support.Application.Mapper
{
    public class AccessMapper
    {
        public static AccessDTO Map(Access access)
        {
            return new AccessDTO()
            {
                AccessId = access.AccessId,
                AccessName = access.AccessName,
                AccessDesc = access.AccessDesc,
                IsGeneral = access.IsGeneral,

            };
        }
        public static PersonAccessDTO MapToPeronAccessDTO(Access model)
        {
            return new PersonAccessDTO()
            {
                AccessId = model.AccessId,
                AccessName = model.AccessName,
                AccessDesc = model.AccessDesc,
                IsGeneral = model.IsGeneral,
            };
        }
        public static Access MapToModel(AccessDTO access)
        {
            return new Access()
            {
                AccessId = access.AccessId,
                AccessName = access.AccessName,
                AccessDesc = access.AccessDesc,
                IsGeneral = access.IsGeneral,

            };
        }

        public static Access MapToUpdate(Access model, AccessDTO dto)
        {
            model.AccessId = dto.AccessId;
            model.AccessName = dto.AccessName;
            model.AccessDesc = dto.AccessDesc;
            model.IsGeneral = dto.IsGeneral;
            return model;
        }
    }
}
