using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwner();
        List<Owner> FindOwnerByID(int id);
        Owner UpdateOwner(Owner ownerUpdated);
        Owner CreateOwner(Owner owner);
        Owner RemoveOwner(int idSelection);
    }
}
