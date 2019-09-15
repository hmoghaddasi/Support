using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Host.Tools;
using Microsoft.AspNetCore.Authorization;

namespace Support.Hosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPolicyController : ControllerBase
    {
        private readonly IAccessPolicyServices _accessPolicyService;
        public AccessPolicyController(IAccessPolicyServices accessPolicyService)
        {
            this._accessPolicyService = accessPolicyService;
        }
        [HttpGet]
        [Authorize]
        public string Get()
        {
            var user = User.GetLoggedInUserName();
            return _accessPolicyService.GetUserAccess(user);
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
        [Route("api/ChangePersonAccess")]
        public BaseResponseDTO ChangePersonAccess(ChangePersonAccessDTO request)
        {
            return _accessPolicyService.ChangePersonAccess(request);
        }
    }
}