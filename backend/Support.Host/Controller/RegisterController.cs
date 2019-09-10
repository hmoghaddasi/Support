using System.Net;
using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;

namespace Support.Host.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        public RegisterController(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }
        public string Post(PersonRegisterDTO dto)
        {
            var claims = _authorizationService.RegisterPerson(dto);
            if (claims != null)
                return JwtManager.GenerateToken(claims);

            throw new HttpResponseException(HttpStatusCode.Unauthorized);

        }

    }
}