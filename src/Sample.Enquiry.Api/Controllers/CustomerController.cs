using System.Linq;
using Sample.Enquiry.Core;
using Sample.Enquiry.Core.Entities;
using Sample.Enquiry.Core.Interfaces;
using Sample.Enquiry.Core.Query;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Enquiry.Api
{
    public class CustomerController : BaseApiController
    {
        private readonly IRepository _repository;

        public CustomerController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/customers
        [HttpGet("/api/customers")]
        public IActionResult GetList()
        {
            var customers = _repository.List<Customer>()
                .Select(  c => c.ToDto());
            return Ok(customers);
        }

        // GET: api/customer/123456
        [HttpGet("{id:int}")]
        public IActionResult GetById(ulong id)
        {
            var customer = _repository.GetById<Customer>(id);
            if( customer != null)
            {
                return Ok(customer.ToDto());
            }
            return NotFound();
        }

        // GET: api/customer?email=test@test.com
        [HttpGet]
        public IActionResult GetByParams( [FromQuery] QueryParameters queryParameters)
        {
            if( ModelState.IsValid)
            {
                var customer = _repository.GetByParams<Customer>(queryParameters);
                if( customer != null)
                {
                    return Ok(customer.ToDto());
                }
                return NotFound();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // GET: api/customer?email=test@test.com
        [HttpGet("populate")]
        public IActionResult PopulateSampleData()
        {
            int addedCount = DatabasePopulator.PopulateDatabase(_repository);
            return Ok(addedCount);
        }
    }
}
