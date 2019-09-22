using System.Collections.Generic;
using System.Web.Http;
using Framework.Core.Filtering;
using Newtonsoft.Json;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Hosts.Filters;

namespace Support.Hosts.Controllers
{
    public class AccessController : ApiController
    {
        private readonly IAccessServices _accessService;
        private readonly IAccessPolicyServices _accessPolicyService;

        public AccessController(IAccessServices accessService, IAccessPolicyServices accessPolicyService)
        {
            this._accessService = accessService;
            this._accessPolicyService = accessPolicyService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("AccessGrid")]
        public FilterResponse<AccessDTO> Get([FromBody]GridRequest request)
        {
          
            return _accessService.GetForGrid(request);
        }

        [HttpGet]
        [JwtAuthentication]
        [Route("PersonAccess")]
        public List<PersonAccessDTO> PersonAccess(int id)
        {
            return _accessService.PersonAccess(id);
        }
        [HttpGet]
        public string Get()
        {
            var user = UserManagementTools.GetCurrentPersonUser();
            return _accessPolicyService.GetUserAccess(user);
        }
        [AllowAnonymous]
        [HttpPost]
        public BaseResponseDTO Post(AccessDTO dto)
        {

            return _accessService.Create(dto);
        }
        [HttpPut]
        [JwtAuthentication]
        public BaseResponseDTO Put(int id, AccessDTO dto)
        {
            dto.AccessId = id;
            return _accessService.Edit(dto);

        }
    }
}
