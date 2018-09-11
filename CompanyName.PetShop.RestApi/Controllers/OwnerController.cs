using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace CompanyName.PetShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET api/owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {

            return _ownerService.GetAllOwner();
        }

        // GET api/owners/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Owner>> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID must be greater than 0");
            }
            return _ownerService.FindOwnerByID(id);
        }

        // POST api/owners
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                return BadRequest("First name is required");
            }
            else if (string.IsNullOrEmpty(owner.Address))
            {
                return BadRequest("Address is required");
            }
            return Ok(_ownerService.CreateOwner(owner));
        }

        // PUT api/owner/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.ID)
            {
                return BadRequest("ID is not correct");
            }
            return Ok(_ownerService.UpdateOwner(owner));
        }
        // DELETE api/owner/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner2Delete = _ownerService.RemoveOwner(id);
            if (owner2Delete == null)
            {
                return StatusCode(404, "Owner could not be found");
            }
            return Ok("Owner has been deleted");
        }
    }
}
