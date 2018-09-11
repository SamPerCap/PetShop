using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        List<Owner> _ownerList = new List<Owner>();
        public Owner CreateOwner(Owner owner)
        {
            owner.ID = FakeDB.ownerID++;
            var ownerList = FakeDB.Owners.ToList();
            ownerList.Add(owner);
            FakeDB.Owners = _ownerList;
            return owner;
        }

        public Owner ReadOwnerByID(int id)
        {
            foreach (var owner in FakeDB.Owners)
            {
                if (owner.ID == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return FakeDB.Owners;
        }

        public Owner RemoveOwner(int idOwner)
        {
            FakeDB.ownerID = FakeDB.ownerID - 1;
            var ownerList = FakeDB.Owners.ToList();
            var owner2Remove = ownerList.FirstOrDefault(owner => owner.ID == idOwner);
            ownerList.Remove(owner2Remove);
            FakeDB.Owners = ownerList.ToList();
            return owner2Remove;
        }

        public Owner UpdateOwner(Owner ownerUpdated)
        {
            var ownerSave = this.ReadOwnerByID(ownerUpdated.ID);
            if (ownerSave != null)
            {
                ownerSave.Address = ownerSave.Address;
                ownerSave.Email = ownerSave.Email;
                ownerSave.FirstName = ownerSave.FirstName;
                ownerSave.LastName = ownerSave.LastName;
                ownerSave.PhoneNumber = ownerSave.PhoneNumber;
                return ownerSave;
            }
            return null;
        }
    }
}
