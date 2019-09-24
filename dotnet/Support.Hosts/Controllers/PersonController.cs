using System.Web.Http;
using Framework.Core.Filtering;
using Newtonsoft.Json;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Hosts.Filters;

namespace Support.Hosts.Controllers
{
  
    public class PersonController : ApiController
    {
        private readonly IPersonServices _personService;

        public PersonController(IPersonServices personService)
        {
            this._personService = personService;
        }

        [HttpGet]
        [JwtAuthentication]
        [Route("api/PersonGrid")]
        public FilterResponse<PersonDTO> Get([FromUri]GridRequest request, int id)
        {
          return _personService.GetForGrid(request, id);
        }

        [HttpGet]
        public PersonDTO Get(int id)
        {
            return _personService.GetById(id);
        }

        [HttpGet]

        [JwtAuthentication]
        [Route("api/Validate")]
        public BaseResponseDTO Post(int id)
        {
            return _personService.ValidateUser(id);
        }

        [HttpGet]

        [JwtAuthentication]
        [Route("api/Activate")]
        public BaseResponseDTO Activate(int id)
        {
            return _personService.ActivateUser(id);
        }

        [HttpGet]

        [JwtAuthentication]
        [Route("api/DeActivate")]
        public BaseResponseDTO DeActivate(int id)
        {
            return _personService.DeActivateUser(id);
        }
    }
}