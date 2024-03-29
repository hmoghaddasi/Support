﻿using System.Web.Http;
using Framework.Core.Filtering;
using Newtonsoft.Json;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Hosts.Filters;

namespace Support.Hosts.Controllers
{
    public class RequestController : ApiController
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            this._requestService = requestService;
        }

        [HttpGet]
        [JwtAuthentication]
        [Route("api/RequestGrid")]
        public FilterResponse<RequestDTO> Get([FromUri]GridRequest request)
        {
            return _requestService.GetForGrid(request);
        }

        [HttpGet]
        [JwtAuthentication]
        [Route("api/UserRequestGrid")]
        public FilterResponse<RequestDTO> GetUserGrid([FromUri]GridRequest request)
        {
            var user = UserManagementTools.GetCurrentPersonUser();
            return _requestService.GetForGrid(request,user);
        }
        [HttpGet]

        [JwtAuthentication]
        public RequestDetailDTO Get(int id)
        {
            var user = UserManagementTools.GetCurrentPersonUser();
            return _requestService.GetDetail(id,user);
        }

        [HttpPost]

        [JwtAuthentication]
        public BaseResponseDTO Post(RequestCreateDTO dto)
        {
            var user = UserManagementTools.GetCurrentPersonUser();
            return _requestService.Create( dto,user);
        }

        [HttpGet]

        [JwtAuthentication]
        [Route("api/CloseTicket")]
        public BaseResponseDTO CloseTicket(int id)
        {
            return _requestService.UpdateStatus(id);
        }

        [JwtAuthentication]
        [HttpDelete]
        public BaseResponseDTO Delete(int id)
        {
            return _requestService.Delete(id);
        }
    }
}