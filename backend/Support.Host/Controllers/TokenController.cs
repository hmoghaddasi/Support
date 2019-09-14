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
        private readonly IAuthorizationService _authorizationService;
        public TokenController(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }

        [HttpPost]
        public string Post([FromBody]TokenDTO dto)
        {
            if (dto == null || !ModelState.IsValid)
                throw new StatusCodeException(HttpStatusCode.NotFound);

            var claims = _authorizationService.CreateClaimsFor(dto);
            if (claims != null)
                return JwtManager.GenerateToken(claims);

            throw new StatusCodeException(HttpStatusCode.Unauthorized);
        }
    }
}