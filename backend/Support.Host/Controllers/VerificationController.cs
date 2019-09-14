using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Host.HttpStatus;
using Support.Host.Tools;
using System.Net;

namespace Support.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationController : ControllerBase
    {
        private readonly Application.Contract.IService.IAuthorizationService _authorizationService;
        public VerificationController(Application.Contract.IService.IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }

        [HttpPost, Authorize]
        public string Post([FromBody]VerificationDTO code)
        {
            var mobile = UserManagementTools.GetCurrentPersonUser();
            var claims = _authorizationService.Verification(code, mobile);
            if (claims != null)
                return JwtManager.GenerateToken(claims);

            throw new StatusCodeException(HttpStatusCode.Unauthorized);
        }
    }
}