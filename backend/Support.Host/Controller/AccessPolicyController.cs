using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;

namespace Support.Host.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccessPolicyController: ControllerBase
    {
	    private readonly IAccessPolicyServices _accessPolicyService;       
        public AccessPolicyController(IAccessPolicyServices accessPolicyService)
        {            
            this._accessPolicyService = accessPolicyService;           
        }

		[AllowAnonymous]
        public List<AccessPolicyDTO> Get()
        {
            return _accessPolicyService.GetAll();
        }
        [AllowAnonymous]
        public IActionResult Post(AccessPolicyDTO dto)
        {
            _accessPolicyService.Create(dto);
            return Ok();
        }

     
		[AllowAnonymous]
        public IActionResult Delete(int accessPolicyId)
        {
            _accessPolicyService.Delete(accessPolicyId);
            return Ok();
        }

        //[HttpPost]
        //[Route("api/ChangePersonAccess")]
        //public BaseResponseDTO ChangePersonAccess(ChangePersonAccessDTO request)
        //{
        //    return _accessPolicyService.ChangePersonAccess(request);
        //}
    }
}