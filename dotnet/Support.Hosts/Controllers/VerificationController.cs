using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Hosts.Filters;

namespace Support.Hosts.Controllers
{

    public class VerificationController : ApiController
    {
        private readonly IAuthorizationService _authorizationService;
        public VerificationController(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }

        [JwtAuthentication]
        public LoginResultDTO Post([FromUri]VerificationDTO code)
        {
            var mobile = UserManagementTools.GetCurrentPersonUser();
            var claims = _authorizationService.Verification(code, mobile);
            if (claims != null)
                return JwtManager.GenerateToken(claims);

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }
}