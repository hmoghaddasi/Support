using System.Net;
using System.Web.Http;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;

namespace Support.Hosts.Controllers
{
   
    public class RegisterController : ApiController
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IAuthenticateService _authenticateService;

        public RegisterController(IAuthorizationService authorizationService, IAuthenticateService authenticateService)
        {
            this._authorizationService = authorizationService;
            this._authenticateService = authenticateService;

        }

        [AllowAnonymous]
        public LoginResultDTO Post(PersonRegisterDTO dto)
        {
            var claims = _authorizationService.RegisterPerson(dto);
            if (claims != null)
                return JwtManager.GenerateToken(claims);

            throw new HttpResponseException(HttpStatusCode.Unauthorized);

        }
    }
}