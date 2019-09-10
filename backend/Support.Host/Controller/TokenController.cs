using System.Net;
using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
namespace Support.Host.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        public TokenController(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }

        public string Post([FromBody]TokenDTO dto)
        {
            if (dto == null || !ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var claims = _authorizationService.CreateClaimsFor(dto);
            if (claims != null)
                return JwtManager.GenerateToken(claims);

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

    }
}