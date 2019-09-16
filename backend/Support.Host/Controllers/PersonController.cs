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

namespace Support.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personService;

        public PersonController(IPersonServices personService)
        {
            this._personService = personService;
        }

        [HttpGet]
        [Route("PersonGrid")]
        public FilterResponse<PersonDTO> Get([FromQuery]GridRequestWithArgument request)
        {
            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                request.FilterX = JsonConvert.DeserializeObject<GridFilter>(request.Filter);
            }
            return _personService.GetForGrid(request);
        }

        [HttpGet]
        public PersonDTO Get(int id)
        {
            return _personService.GetById(id);
        }

        [HttpGet]
        [Authorize]
        [Route("Validate")]
        public BaseResponseDTO Post(int id)
        {
            return _personService.ValidateUser(id);
        }

        [HttpGet]
        [Authorize]
        [Route("Activate")]
        public BaseResponseDTO Activate(int id)
        {
            return _personService.ActivateUser(id);
        }

        [HttpGet]
        [Authorize]
        [Route("DeActivate")]
        public BaseResponseDTO DeActivate(int id)
        {
            return _personService.DeActivateUser(id);
        }
    }
}