using System.Collections.Generic;
using System.Web.Http;
using Framework.Core.Filtering;
using Newtonsoft.Json;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Hosts.Filters;

namespace Support.Hosts.Controllers
{
    public class ConfigController : ApiController
    {
        private readonly IConfigService _configService;
        public ConfigController(IConfigService configService)
        {
            this._configService = configService;
        }

        public ConfigDTO Get(int id)
        {
            return _configService.GetById(id);
        }

        [HttpGet]
        [JwtAuthentication]
        [Route("ConfigChild")]
        public List<ConfigDTO> ConfigChild(int id)
        {
            return _configService.GetConfigChildsByParentId(id);
        }

        [HttpGet]
        [JwtAuthentication]
        [Route("ConfigGrid")]
        public FilterResponse<ConfigDTO> Get([FromBody]GridRequestWithArgument request)
        {
            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                request.FilterX = JsonConvert.DeserializeObject<GridFilter>(request.Filter);
            }
            return _configService.GetForGrid(request);
        }

        [HttpPost]

        [JwtAuthentication]
        public BaseResponseDTO Post(ConfigDTO dto)
        {
            return _configService.Create(dto);
        }
        [HttpPut]

        [JwtAuthentication]
        public BaseResponseDTO Put(ConfigDTO dto)
        {
            return _configService.Edit(dto);
        }

        [JwtAuthentication]
        [HttpDelete]
        public BaseResponseDTO Delete(int id)
        {
            return _configService.Delete(id);
        }
    }
}
