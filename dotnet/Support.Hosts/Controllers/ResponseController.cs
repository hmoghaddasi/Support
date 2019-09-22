using System.Collections.Generic;
using System.Web.Http;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Hosts.Filters;

namespace Support.Hosts.Controllers
{
    public class ResponseController : ApiController
    {
        private readonly IResponseService _responseService;

        public ResponseController(IResponseService responseService)
        {
            this._responseService = responseService;
        }
        
        [HttpGet]

        [JwtAuthentication]
        [Route("GetRequestResponseList")]
        public List<ResponseDTO> GetRequestResponseList(int id)
        {
            var user = UserManagementTools.GetCurrentPersonUser();
            return _responseService.GetAll(id, user);
        }

        [HttpPost]

        [JwtAuthentication]
        public BaseResponseDTO Post(ResponseCreateDTO dto)
        {
            var user = UserManagementTools.GetCurrentPersonUser();
            return _responseService.Create(dto,user);
        }

        [JwtAuthentication]
        [HttpDelete]
        public BaseResponseDTO Delete(int id)
        {
            var user = UserManagementTools.GetCurrentPersonUser();
            return _responseService.Delete(id, user);
        }
    }
}