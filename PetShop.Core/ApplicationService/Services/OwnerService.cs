using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.CreateOwner(owner);
        }

        public Owner FindOwnerByID(int id)
        {
            return _ownerRepo.ReadOwnerByID(id);
        }

        public List<Owner> GetAllOwner()
        {
            return _ownerRepo.ReadOwners().ToList();
        }

        public Owner RemoveOwner(int idSelection)
        {
            return _ownerRepo.RemoveOwner(idSelection);
        }

        public Owner UpdateOwner(Owner ownerUpdated)
        {
            var owner = _ownerRepo.ReadOwnerByID(ownerUpdated.ID);
            owner.Address = ownerUpdated.Address;
            owner.Email = ownerUpdated.Email;
            owner.FirstName = ownerUpdated.FirstName;
            owner.LastName = ownerUpdated.LastName;
            owner.PhoneNumber = ownerUpdated.PhoneNumber;
            return owner;
        }
    }
}
