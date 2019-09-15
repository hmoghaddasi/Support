using System.Net;
using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Host.HttpStatus;

namespace Support.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IAuthenticateService _authenticateService;

        public RegisterController(IAuthorizationService authorizationService, IAuthenticateService authenticateService)
        {
            this._authorizationService = authorizationService;
            this._authenticateService = authenticateService;

        }

        [HttpPost]
        public string Post(PersonRegisterDTO dto)
        {
            var claims = _authorizationService.RegisterPerson(dto);
            if (claims != null)
                return _authenticateService.IsAuthenticated(claims);

            throw new StatusCodeException(HttpStatusCode.Unauthorized);
        }
    }
}