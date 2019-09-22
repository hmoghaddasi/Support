using System.Collections.Generic;
using System.Security.Claims;

namespace Support.Application.Contract.IService
{
    public interface IAuthenticateService : IApplicationService
    {
        string IsAuthenticated(List<Claim> claims);
        
    }
}
