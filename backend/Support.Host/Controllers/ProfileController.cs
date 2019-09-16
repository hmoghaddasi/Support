using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Host.Tools;

namespace Support.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IPersonServices _personService;
        public ProfileController(IPersonServices personService)
        {
            this._personService = personService;
        }

        [Authorize]
        [HttpGet]
        public ProfileDTO Get()
        {
            var user = User.GetLoggedInUserName();
            return _personService.GetProfile(user);
        }

        [Authorize]
        [HttpPost]
        public BaseResponseDTO Post(ProfileDTO request)
        {
            var user = User.GetLoggedInUserName();
            return _personService.Edit(user, request);
        }
    }
}