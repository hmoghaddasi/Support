using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;

namespace Support.Host.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IPersonServices _personService;
        public ProfileController(IPersonServices personService)
        {
            this._personService = personService;
        }


        public ProfileDTO Get()
        {
            var currentUserName = UserManagementTools.GetCurrentPersonUser();
            return _personService.GetProfile(currentUserName);
        }

        [HttpPost]
        public BaseResponseDTO Post(ProfileDTO request)
        {
            var currentUserName = UserManagementTools.GetCurrentPersonUser();
            return _personService.Edit(currentUserName, request);
        }
    }
}