using System.Collections.Generic;
using Framework.Core.Filtering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
namespace Support.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;
        public ConfigController(IConfigService configService)
        {
            this._configService = configService;
        }

        [HttpGet("{id:int}")]
        public ConfigDTO Get(int id)
        {
            return _configService.GetById(id);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ConfigChild")]
        public List<ConfigDTO> ConfigChild(int id)
        {
            return _configService.GetConfigChildsByParentId(id);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ConfigGrid")]
        public FilterResponse<ConfigDTO> Get([FromQuery]GridRequestWithArgument request)
        {
            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                request.FilterX = JsonConvert.DeserializeObject<GridFilter>(request.Filter);
            }
            return _configService.GetForGrid(request);
        }

        [HttpPost]
        [Authorize]
        public BaseResponseDTO Post(ConfigDTO dto)
        {
            return _configService.Create(dto);
        }
        [HttpPut]
        [Authorize]
        public BaseResponseDTO Put(ConfigDTO dto)
        {
            return _configService.Edit(dto);
        }
        [Authorize]
        [HttpDelete]
        public BaseResponseDTO Delete(int id)
        {
            return _configService.Delete(id);
        }
    }
}
