using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace CompanyName.PetShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customService;
        public CustomersController(ICustomerService customService)
        {
            _customService = customService;
        }

        // GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {

            return _customService.GetAllCustomers();
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID must be greater than 0");
            }
            return _customService.FindCustomerByID(id);
        }

        // POST api/customers
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FirstName))
            {
                return BadRequest("First name is required");
            }
            return Ok(_customService.CreateCustomer(customer));
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            if (id < 1 || id != customer.ID)
            {
                return BadRequest("ID is not correct");
            }
            return Ok(_customService.UpdateCustomer(customer));
        }
        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            var customer2Delete = _customService.RemoveCustomer(id);
            if (customer2Delete == null)
            {
                return StatusCode(404, "Customer could not be found");
            }
            return Ok("Customer has been deleted");
        }
    }
}
