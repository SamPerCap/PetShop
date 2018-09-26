using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
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
            var changeTracker = _pac.ChangeTracker.Entries<Owner>();
            if (pet.Owner != null && 
                _pac.ChangeTracker.Entries<Owner>().FirstOrDefault(pe => pe.Entity.ID == pet.Owner.ID) == null)
            {
                _pac.Attach(pet.Owner);

            }
            var pet2Add = _pac.Pets.Add(pet).Entity;
            _pac.SaveChanges();

            return pet2Add;
        }
        public Pet ReadByID(int id)
            
        {
           
            var changeTracker = _pac.ChangeTracker.Entries<Owner>();
            var petById = _pac.Pets.Where(p => p.ID == id).Include(p => p.Owner).FirstOrDefault();
            return petById;
        }

        public IEnumerable<Pet> ReadByPrice()
        {
            return _pac.Pets.OrderByDescending(p => p.Price).ToList();
        }

        public Pet ReadByType(string type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadPets()
        {
            var getPet = _pac.Pets.Include(p => p.Owner);
            return getPet;
        }

        public Pet RemovePet(int idSelection)
        {
            //var owner2remove = _pac.Owners.Where(p => p.ID == idSelection);
            var pet2removeFromList = ReadByID(idSelection);
            var pet2remove = _pac.Pets.Remove(pet2removeFromList).Entity;
            _pac.SaveChanges();
            return pet2remove;

        }

        public Pet Update(Pet petUpdated)
        {
            _pac.Attach(petUpdated).State = EntityState.Modified;
            _pac.Entry(petUpdated).Reference(o => o.Owner).IsModified = true;
            _pac.SaveChanges();

            return petUpdated;
        }
        public Pet ReadByIDIncludeCustomer(int id)
        {
            return _pac.Pets.Include(c => c.Owner).FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            if (filter == null)
            {
                return _pac.Pets;
            }
            return _pac.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage).Take(filter.ItemsPrPage);
        }
    }
}
