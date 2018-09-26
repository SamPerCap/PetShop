using Data;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetRepository
{
    public class PetRepository : IPetShopRepository
    {
        readonly private PetAppContext _pac;

        public PetRepository(PetAppContext pac)
        {
            _pac = pac;
        }


        public Pet CreatePet(Pet pet)
        {
            var pet2Add = _pac.Pets.Add(pet).Entity;
            _pac.SaveChanges();
            return pet2Add;
        }

        public Pet ReadByID(int id)
        {
          
            return _pac.Pets.FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Pet> ReadByPrice()
        {
            throw new NotImplementedException();
        }

        public Pet ReadByType(string type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _pac.Pets;
        }

        public Pet RemovePet(int idSelection)
        {
            throw new NotImplementedException();
        }

        public Pet Update(Pet petUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
