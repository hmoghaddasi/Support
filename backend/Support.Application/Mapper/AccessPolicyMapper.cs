using System.Collections.Generic;
using System.Linq;
using Support.Application.Contract.DTO;
using Support.Domain.Model;

namespace Support.Application.Mapper
{
    public class AccessPolicyMapper
    {
        public static AccessPolicyDTO MapToDTO(AccessPolicy model)
        {
            return new AccessPolicyDTO()
            {
                AccessPolicyId = model.AccessPolicyId,
                AccessId = model.AccessId,
                PersonId = model.PersonId,
                AccessName = model.Access.AccessName,
            };
        }


        public static AccessPolicy MapToModel(AccessPolicyDTO dto)
        {
            return new AccessPolicy()
            {
                AccessId = dto.AccessId,
                PersonId = dto.PersonId,
            };
        }


        public static AccessPolicy MapEditDTO(AccessPolicy model, AccessPolicyDTO editDTO)
        {
            model.AccessPolicyId = editDTO.AccessPolicyId;
            model.AccessId = editDTO.AccessId;
            model.PersonId = editDTO.PersonId;


            return model;
        }
    }
}
