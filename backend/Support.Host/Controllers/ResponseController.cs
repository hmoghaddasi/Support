using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Route("GetRequestResponseList")]
        public List<ResponseDTO> GetRequestResponseList(int id)
        {
            var user = User.GetLoggedInUserName();
            return _responseService.GetAll(id, user);
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