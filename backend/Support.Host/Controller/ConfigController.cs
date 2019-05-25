using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
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
            _configService = configService;
        }

        [HttpGet]
        public List<ConfigDTO> Get()
        {
            return _configService.GetAll();
        }

        //[HttpGet("{id}")]
        //public Customer Get(long id)
        //{
        //    return _context.Customers.FirstOrDefault(a => a.Id == id);
        //}

        //[HttpPost]
        //public void Post(Customer customer)
        //{
        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();
        //}
    }
}