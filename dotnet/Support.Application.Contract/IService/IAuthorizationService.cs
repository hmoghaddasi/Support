using System.Collections.Generic;
using System.Security.Claims;
using Support.Application.Contract.DTO;
using Support.Domain.Model;

namespace Support.Application.Contract.IService
{
    public interface IAuthorizationService : Framework.Core.OnionClass.IApplicationService
    {
        List<Claim> CreateClaimsFor(TokenDTO dto);
        List<Claim> Verification(VerificationDTO code, string user);
        List<Claim> CreateClaims(Person person);
        void ResendVerificationCode(string mobile);
        object GetAllAccess(string loginName);
        bool GetAuthenticated(TokenDTO dto);
        bool ChangePassword(PasswordChangeDTO dto);
        List<Claim> RegisterPerson(PersonRegisterDTO dto);
    }
}
