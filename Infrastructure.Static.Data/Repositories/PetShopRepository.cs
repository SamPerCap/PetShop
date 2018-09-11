using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Static.Data.Repositories
{
    public class PetShopRepository : IPetShopRepository
    {
        List<Pet> _petList = new List<Pet>();
        public Pet CreatePet(Pet pet)
        {
            pet.ID = FakeDB.petID++;
            var petList = FakeDB.Pets.ToList();
            petList.Add(pet);
            FakeDB.Pets = petList;
            return pet;

        }

        public Pet ReadByID(int id)
        {
            foreach (var pet in FakeDB.Pets)
            {
                if (pet.ID == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public IEnumerable<Pet> ReadByPrice()
        {
            return FakeDB.Pets.OrderByDescending(p => p.Price).ToList();
        }

        public Pet ReadByType(string type)
        {
            foreach (var pet in _petList)
            {
                if (pet.Type == type)
                {
                    return pet;
                }

            }
            return null;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }

        public Pet RemovePet(int idSelection)
        {
            FakeDB.petID = FakeDB.petID - 1;
            var petList = FakeDB.Pets.ToList();
            var pet2Remove = petList.FirstOrDefault(pet => pet.ID == idSelection);
            petList.Remove(pet2Remove);
            FakeDB.Pets = petList;
            return pet2Remove;
        }

        public Pet Update(Pet petUpdated)
        {
            var petSave = this.ReadByID(petUpdated.ID);
            if (petSave != null)
            {
                petSave.Owner = petUpdated.Owner;
                petSave.Price = petUpdated.Price;
                petSave.SoldDate = petUpdated.SoldDate;
                return petSave;
            }
            return null;
        }
    }
}
