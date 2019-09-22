using Support.Application.Contract.DTO;
using Support.Domain.Model;

namespace Support.Application.Mapper
{
    public class AccessPolicyMapper
    {
        public static AccessPolicyDTO Map(AccessPolicy access)
        {
            return new AccessPolicyDTO()
            {
                AccessPolicyId = access.AccessPolicyId,
                AccessId = access.AccessId,
                PersonId = access.PersonId,
                AccessName = access.Access.AccessName,
                FullName = access.Person.FirstName + " " + access.Person.LastName

            };
        }

        public static AccessPolicy MapToModel(AccessPolicyDTO dto)
        {
            return new AccessPolicy()
            {
                AccessPolicyId = dto.AccessPolicyId,
                AccessId = dto.AccessId,
                PersonId = dto.PersonId,
            };
        }
    }
}
