using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public class PetShopService : IPetShopService
    {
        readonly IPetShopRepository _petShopRepo;

        public PetShopService(IPetShopRepository petShopRepository)
        {
            _petShopRepo = petShopRepository;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petShopRepo.CreatePet(pet);
        }

        public List<Pet> FindPetByID(int id)
        {
            var list = _petShopRepo.ReadPets();
            var IDList = list.Where(pet => pet.ID.Equals(id));
                return IDList.ToList();
        }

        public List<Pet> GetAllPets()
        {

            return _petShopRepo.ReadPets().ToList();
        }

        public List<Pet> GetAllPetsByPrice()
        {
            var list = _petShopRepo.ReadPets();
            return list.OrderByDescending(pet => pet.Price).ToList();

        }

        public List<Pet> GetAllPetsByType(string type)
        {
            var list = _petShopRepo.ReadPets();
            var qC = list.Where(pet => pet.Type.Equals(type));  
            qC.OrderBy(pt => pt.Type);
            return qC.ToList();
        }

        public List<Pet> GetCheapestPets()
        {
            var list = _petShopRepo.ReadByPrice().Reverse();
            return list.Take(5).ToList();
        }

        public Pet NewPet(string type, string race, string color, DateTime birthday, int price, DateTime soldDate, Owner owner)
        {
            var newPet = new Pet()
            {
                Type = type,
                Race = race,
                Color = color,
                Birthday = birthday,
                Price = price,
                SoldDate = soldDate,
                Owner = owner
            };

            return newPet;
        }

        public Pet RemovePet(int idSelection)
        {

          return  _petShopRepo.RemovePet(idSelection);
        }

        public Pet UpdatePet(Pet petUpdated)
        {
            var pet = _petShopRepo.ReadByID(petUpdated.ID);
            pet.Owner = petUpdated.Owner;
            pet.Price = petUpdated.Price;
            pet.SoldDate = petUpdated.SoldDate;
            return pet;
        }
    }
}
