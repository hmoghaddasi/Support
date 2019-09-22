using System.Net;
using System.Web.Http;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Hosts.Filters;

namespace Support.Hosts.Controllers
{
    public class TokenController : ApiController
    {
        private readonly IAuthorizationService _authorizationService;
        public TokenController(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }

        [AllowAnonymous]
        public LoginResultDTO Post([FromBody]TokenDTO dto)
        {
            if (dto == null || !ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var claims = _authorizationService.CreateClaimsFor(dto);
            if (claims != null)
            {
                return JwtManager.GenerateToken(claims);
            }

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

       
    }
}