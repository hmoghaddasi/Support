using System.Collections.Generic;
using System.Security.Claims;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IAuthorizationService : IApplicationService
    {
        List<Claim> RegisterPerson(PersonRegisterDTO dto);
        List<Claim> CreateClaimsFor(TokenDTO dto);
        List<Claim> Verification(VerificationDTO dto, string mobile);
        void ResendVerificationCode(string mobile);
    }
}
