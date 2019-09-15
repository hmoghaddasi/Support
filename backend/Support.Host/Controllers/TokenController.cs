using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Host.HttpStatus;
using System.Net;

namespace Support.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly Application.Contract.IService.IAuthorizationService _authorizationService;

        public TokenController(IAuthenticateService authenticateService, Application.Contract.IService.IAuthorizationService authorizationService)
        {
            this._authenticateService = authenticateService;
            this._authorizationService = authorizationService;

        }


        [HttpPost]
        public string Post([FromBody]TokenDTO dto)
        {
            if (dto == null || !ModelState.IsValid)
                throw new StatusCodeException(HttpStatusCode.NotFound);

            var claims = _authorizationService.CreateClaimsFor(dto);
            if (claims != null)
                return _authenticateService.IsAuthenticated(claims);
           
            throw new StatusCodeException(HttpStatusCode.Unauthorized);
        }
    }
}