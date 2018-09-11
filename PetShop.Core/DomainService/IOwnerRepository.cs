using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> ReadOwners();
        Owner UpdateOwner(Owner ownerUpdated);
        Owner CreateOwner(Owner owner);
        Owner RemoveOwner(int idOwner);
        Owner ReadOwnerByID(int id);
    }
}
