using System.Web.Http;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;

namespace Support.Hosts.Controllers
{
    public class AccessPolicyController : ApiController
    {
        private readonly IAccessPolicyServices _accessPolicyService;
        public AccessPolicyController(IAccessPolicyServices accessPolicyService)
        {
            this._accessPolicyService = accessPolicyService;
        }
        [HttpGet]
        [Authorize]
        public CurrentAccessPolicyDTO Get()
        {
            var user = UserManagementTools.GetCurrentPersonUser();
            return new CurrentAccessPolicyDTO { Access = _accessPolicyService.GetUserAccess(user) };
        }
        [HttpPost]
        [AllowAnonymous]
        public BaseResponseDTO Post(AccessPolicyDTO dto)
        {
            return _accessPolicyService.Create(dto);
        }

        [HttpDelete]
        [AllowAnonymous]
        public BaseResponseDTO Delete(int accessPolicyId)
        {
            return _accessPolicyService.Delete(accessPolicyId);
        }

        [HttpPost]
        [Authorize]
        [Route("ChangePersonAccess")]
        public BaseResponseDTO ChangePersonAccess(ChangePersonAccessDTO request)
        {
            return _accessPolicyService.ChangePersonAccess(request);
        }
    }
}