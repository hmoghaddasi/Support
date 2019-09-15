using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Host.HttpStatus;
using Support.Host.Tools;
using System.Net;
using System.Security.Claims;

namespace Support.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationController : ControllerBase
    {
        private readonly Application.Contract.IService.IAuthorizationService _authorizationService;
        private readonly IAuthenticateService _authenticateService;
        public VerificationController(Application.Contract.IService.IAuthorizationService authorizationService, IAuthenticateService authenticateService)
        {
            this._authorizationService = authorizationService;
            this._authenticateService = authenticateService;
        }

        [HttpPost, Authorize]
        public string Post([FromBody]VerificationDTO code)
        {
            var mobile = User.GetLoggedInUserName();
            var claims = _authorizationService.Verification(code, mobile);
            if (claims != null)
                return _authenticateService.IsAuthenticated(claims);

            throw new StatusCodeException(HttpStatusCode.Unauthorized);
        }
    }
}