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
    public class ResponseController : ControllerBase
    {
        private readonly IResponseService _responseService;

        public ResponseController(IResponseService responseService)
        {
            this._responseService = responseService;
        }
        
        [HttpGet]
        public List<ResponseDTO> GetAll(int requestid)
        {
            var user = User.GetLoggedInUserName();
            return _responseService.GetAll(requestid, user);
        }

        [HttpPost]
        [Authorize]
        public BaseResponseDTO Post(ResponseCreateDTO dto)
        {
            var user = User.GetLoggedInUserName();
            return _responseService.Create(dto,user);
        }

        [HttpDelete]
        public BaseResponseDTO Delete(int id)
        {
            var user = User.GetLoggedInUserName();
            return _responseService.Delete(id, user);
        }
    }
}