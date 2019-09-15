using System.Collections.Generic;
using System.Security.Claims;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IAuthenticateService : IApplicationService
    {
        string IsAuthenticated(List<Claim> claims);
        
    }
}
