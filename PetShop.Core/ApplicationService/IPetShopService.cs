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

        List<Pet> FindPetByID(int id);
        Pet UpdatePet(Pet petUpdated);
        Pet CreatePet(Pet pet);
        Pet NewPet(string type, string race, string color, DateTime birthday, int price, DateTime soldDate, string oldOwner);
        void RemovePet(int idSelection);
    }
}
