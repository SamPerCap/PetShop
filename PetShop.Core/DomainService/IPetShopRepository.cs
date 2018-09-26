using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IPetShopRepository
    {
        IEnumerable<Pet> ReadPets(Filter filter = null);
        Pet Update(Pet petUpdated);
        Pet CreatePet(Pet pet);
        Pet RemovePet(int idSelection);
        IEnumerable<Pet> ReadByPrice();
        Pet ReadByType(string type);
        Pet ReadByID(int id);
        Pet ReadByIDIncludeCustomer(int id);
    }
}
