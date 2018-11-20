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
        readonly IOwnerRepository _ownerRepo;

        public PetShopService(IPetShopRepository petShopRepository, IOwnerRepository ownerRepository)
        {
            _petShopRepo = petShopRepository;
            _ownerRepo = ownerRepository;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petShopRepo.CreatePet(pet);
        }

        public Pet FindPetByID(int id)
        {
            return _petShopRepo.ReadByID(id);
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
        public Pet FindPetByIDIncludeOwner(int id)
        {
            throw new NotImplementedException();
            //var pet = _petShopRepo.ReadByID(id);
            //pet.Owner = _ownerRepo.ReadOwners()
            //    .Where(owner => owner.Pet. == pet.ID)
            //    .ToList();
            //return pet;
        }

        public List<Pet> GetFilteredPets(Filter filter)
        {
            return _petShopRepo.ReadPets(filter).ToList();
        }
    }
}
