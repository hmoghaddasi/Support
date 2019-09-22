using System.Collections.Generic;
using System.Web.Http;
using Framework.Core.Filtering;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Hosts.Filters;

namespace Support.Hosts.Controllers
{
	public class LogController: ApiController
	{
	    private readonly ILogServices _logService;       
        public LogController(ILogServices logService)
        {            
            this._logService = logService;           
        }

	
        [JwtAuthentication]
        public IHttpActionResult Post(LogDTO dto)
        {
            _logService.Create(dto);
            return Ok();
        }


	}
}