using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Support.Host.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        //[HttpGet]
        //public List<Customer> Get()
        //{
        //    return _context.Customers.ToList();
        //}

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