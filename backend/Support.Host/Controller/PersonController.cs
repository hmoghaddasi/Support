using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.Grid;
using Support.Application.Contract.IService;
using Support.Domain.Model;

namespace Support.Host.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personService;
      
        public PersonController(IPersonServices personService)
        {
            this._personService = personService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/PersonGrid")]
        public FilterResponse<PersonDTO> GetValidation(GridRequest request)
        {
            return _personService.GetForGrid(request);
        }
        [AllowAnonymous]
        public PersonDTO Get(int id)
        {
            return _personService.GetById(id);
        }

        [HttpGet]
        [Route("api/Validate")]
        public BaseResponseDTO Post(int id)
        {
            return _personService.ValidateUser(id);
        }

        [HttpGet]
        [Route("api/Activate")]
        public BaseResponseDTO Activate(int id)
        {
            return _personService.ActivateUser(id);
        }

        [HttpGet]
        [Route("api/DeActivate")]
        public BaseResponseDTO DeActivate(int id)
        {
            return _personService.DeActivateUser(id);
        }
    }
}