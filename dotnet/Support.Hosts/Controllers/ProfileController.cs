using System.Web.Http;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Hosts.Filters;

namespace Support.Hosts.Controllers
{
 
    public class ProfileController : ApiController
    {
        private readonly IPersonServices _personService;
        public ProfileController(IPersonServices personService)
        {
            this._personService = personService;
        }


        [JwtAuthentication]
        [HttpGet]
        public ProfileDTO Get()
        {
            var user = UserManagementTools.GetCurrentPersonUser();
            return _personService.GetProfile(user);
        }


        [JwtAuthentication]
        [HttpPost]
        public BaseResponseDTO Post(ProfileDTO request)
        {
            var user = UserManagementTools.GetCurrentPersonUser();
            return _personService.Edit(user, request);
        }
    }
}