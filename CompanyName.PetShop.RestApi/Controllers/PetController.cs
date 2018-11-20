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
    public class PetsController : ControllerBase
    {
        private readonly IPetShopService _petService;
        public PetsController(IPetShopService petService)
        {
            _petService = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] Filter filter)
        {
            if (filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
            {
                return Ok(_petService.GetAllPets());
            }
            return Ok(_petService.GetFilteredPets(filter));
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID must be greater than 0");
            }
            return _petService.FindPetByID(id);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Race))
            {
                return BadRequest("Race is required");
            }
            else if (string.IsNullOrEmpty(pet.Type))
            {
                return BadRequest("Type is required");
            }
            return Ok(_petService.CreatePet(pet));
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.ID)
            {
                return BadRequest("ID is not correct");
            }
            return Ok(_petService.UpdatePet(pet));
        }
        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var petToDelete = _petService.RemovePet(id);
            if (petToDelete == null)
            {
                return StatusCode(404, "Pet could not be found");
            }
            return Ok("Pet has been deleted");
        }
    }
}
