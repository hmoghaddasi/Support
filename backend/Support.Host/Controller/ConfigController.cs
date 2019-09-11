using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Support.Application.Contract.DTO;
using Support.Application.Contract.Grid;
using Support.Application.Contract.IService;

namespace Support.Host.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;
        public ConfigController(IConfigService configService)
        {
            this._configService = configService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ConfigDTO Get(int id)
        {
            return _configService.GetById(id);
        }

        [HttpGet]
        [Authorize]
        [Route("api/ConfigChild")]
        public List<ConfigDTO> ConfigChild(int id)
        {
            return _configService.GetChild(id);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/ConfigGrid")]
        public FilterResponse<ConfigDTO> Get(GridRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                request.FilterX = JsonConvert.DeserializeObject<GridFilter>(request.Filter);
            }
            return _configService.GetForGrid(request);
        }

        [HttpPost]
        public BaseResponseDTO Post(ConfigDTO dto)
        {
            return _configService.Create(dto);
        }

        public BaseResponseDTO Put(ConfigDTO dto)
        {
            return _configService.Edit(dto);
        }

        public BaseResponseDTO Delete(int id)
        {
            return _configService.Delete(id);
        }
    }
}
