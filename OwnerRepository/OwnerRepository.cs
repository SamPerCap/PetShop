using Data;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwnerRepository
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
            throw new NotImplementedException();
        }

        public Owner ReadOwnerByID(int id)
        {
            return _pac.Owners.FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _pac.Owners;
        }

        public Owner RemoveOwner(int idOwner)
        {
            throw new NotImplementedException();
        }

        public Owner UpdateOwner(Owner ownerUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
