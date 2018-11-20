using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IPetShopService
    {
        List<Pet> GetAllPets();
        List<Pet> GetAllPetsByPrice();
        List<Pet> GetAllPetsByType(string type);
        List<Pet> GetCheapestPets();
        Pet FindPetByIDIncludeOwner(int id);

        Pet FindPetByID(int id);
        Pet UpdatePet(Pet petUpdated);
        Pet CreatePet(Pet pet);
        Pet NewPet(string type, string race, string color, DateTime birthday, int price, DateTime soldDate, Owner owner);
        Pet RemovePet(int idSelection);
        List<Pet> GetFilteredPets(Filter filter);
    }
}
