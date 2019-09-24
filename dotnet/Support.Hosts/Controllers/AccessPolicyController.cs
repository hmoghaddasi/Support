using System.Web.Http;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Hosts.Filters;

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
        [JwtAuthentication]
        public string Get()
        {
            var user = UserManagementTools.GetCurrentPersonUser();
            return  _accessPolicyService.GetUserAccess(user);
        }
        [HttpPost]
        [JwtAuthentication]
        public BaseResponseDTO Post(AccessPolicyDTO dto)
        {
            return _accessPolicyService.Create(dto);
        }

        [HttpDelete]

        [JwtAuthentication]
        public BaseResponseDTO Delete(int accessPolicyId)
        {
            return _accessPolicyService.Delete(accessPolicyId);
        }

        [HttpPost]
        [JwtAuthentication]
        [Route("ChangePersonAccess")]
        public BaseResponseDTO ChangePersonAccess(ChangePersonAccessDTO request)
        {
            return _accessPolicyService.ChangePersonAccess(request);
        }
    }
}