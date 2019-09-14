using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public RegisterController(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }

        [HttpPost]
        public string Post(PersonRegisterDTO dto)
        {
            var claims = _authorizationService.RegisterPerson(dto);
            if (claims != null)
                return JwtManager.GenerateToken(claims);

            throw new StatusCodeException(HttpStatusCode.Unauthorized);
        }
    }
}