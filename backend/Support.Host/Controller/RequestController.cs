using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Domain.Model;

namespace Support.Host.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestServices _requestService;
        public RequestController(IRequestServices requestService)
        {
            this._requestService = requestService;
        }
        public IActionResult Post(RequestCreateDTO model)
        {
            _requestService.Create(model);
            return Ok();
        }
        public List<RequestListDTO> Get()
        {
            return _requestService.GetAll();
        }
        [Route("api/GetForGrid")]
        [HttpGet]
        public FilterResponse<RequestListDTO> Get(GridRequest gridRequest)
        {
            return _requestService.GetAllFilter(gridRequest);
        }
        public RequestEditDTO Get(int id)
        {
            return _requestService.GetById(id);
        }
        public bool Delete(int id)
        {
            try
            {
                _requestService.Delete(id);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}