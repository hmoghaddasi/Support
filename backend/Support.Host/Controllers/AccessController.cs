using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Framework.Core.Filtering;
using Newtonsoft.Json;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Microsoft.AspNetCore.Authorization;
using Support.Host.Tools;

namespace Support.Hosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
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
        public FilterResponse<AccessDTO> Get([FromQuery]GridRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                request.FilterX = JsonConvert.DeserializeObject<GridFilter>(request.Filter);
            }

            return _accessService.GetForGrid(request);
        }

        [HttpGet]
        [Authorize]
        [Route("PersonAccess")]
        public List<PersonAccessDTO> PersonAccess(int id)
        {
            return _accessService.PersonAccess(id);
        }
        [HttpGet]
        [Authorize]
        public string Get()
        {
            var user = User.GetLoggedInUserName();
            return _accessPolicyService.GetUserAccess(user);
        }
        [AllowAnonymous]
        [HttpPost]
        public BaseResponseDTO Post(AccessDTO dto)
        {

            return _accessService.Create(dto);
        }
        [HttpPut]
        [AllowAnonymous]
        public BaseResponseDTO Put(int id, AccessDTO dto)
        {
            dto.AccessId = id;
            return _accessService.Edit(dto);

        }
    }
}
