using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Filtering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Host.Tools;

namespace Support.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            this._requestService = requestService;
        }

        [HttpGet]
        [Route("RequestGrid")]
        public FilterResponse<RequestDTO> Get([FromQuery]GridRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                request.FilterX = JsonConvert.DeserializeObject<GridFilter>(request.Filter);
            }
            return _requestService.GetForGrid(request);
        }

        [HttpGet]
        [Route("RequestByCurrentUserGrid")]
        public FilterResponse<RequestDTO> GetByCurrentuser([FromQuery]GridRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                request.FilterX = JsonConvert.DeserializeObject<GridFilter>(request.Filter);
            }
            var user = User.GetLoggedInUserName();
            return _requestService.GetForGrid(request,user);
        }

        [HttpPost]
        [Authorize]
        public BaseResponseDTO Post(RequestCreateDTO dto)
        {
            var user = User.GetLoggedInUserName();
            return _requestService.Create( dto,user);
        }

        [HttpPut]
        [Authorize]
        public BaseResponseDTO Put(int id)
        {
            return _requestService.UpdateStatus(id);
        }

        [HttpDelete]
        public BaseResponseDTO Delete(int id)
        {
            return _requestService.Delete(id);
        }
    }
}