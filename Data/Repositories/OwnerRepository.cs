    using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        readonly private PetAppContext _pac;

        public OwnerRepository(PetAppContext pac)
        {
            _pac = pac;
        }
        public Owner CreateOwner(Owner owner)
        {
            var changeTracker = _pac.ChangeTracker.Entries<Pet>();
            if (owner.Pet != null)
            {
                _pac.Attach(owner.Pet);

            }
            var owner2add = _pac.Owners.Add(owner).Entity;
            _pac.SaveChanges();
            return owner2add;
        }

        public Owner ReadOwnerByID(int id)
        {
            var changeTracker = _pac.ChangeTracker.Entries<Pet>();

            return _pac.Owners.FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _pac.Owners;
        }

        public Owner RemoveOwner(int idOwner)
        {
            var owner2removeFromList = ReadOwnerByID(idOwner);
            var owner2remove = _pac.Owners.Remove(owner2removeFromList).Entity;
            _pac.SaveChanges();
            return owner2remove;
        }

        public Owner UpdateOwner(Owner ownerUpdated)
        {
            _pac.Attach(ownerUpdated).State = EntityState.Modified;
            _pac.Entry(ownerUpdated).Reference(o => o.Pet).IsModified = true;
            _pac.SaveChanges();

            return ownerUpdated;
        }
    }
}
