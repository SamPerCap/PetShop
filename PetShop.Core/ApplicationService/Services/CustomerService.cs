using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customRepo;

        public CustomerService(ICustomerRepository customRepository)
        {
            _customRepo = customRepository;
        }

        public Customer CreateCustomer(Customer customer)
        {
            return _customRepo.CreateCustomer(customer);
        }

        public Customer FindCustomerByID(int id)
        {
            return _customRepo.ReadCustomerById(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customRepo.ReadCustomers().ToList();
        }

        public Customer RemoveCustomer(int idSelection)
        {
            return _customRepo.RemoveCustomer(idSelection);
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            var customerFromDB = _customRepo.ReadCustomerById(customerUpdate.ID);
            if (customerFromDB == null) return null;

            customerFromDB.FirstName = customerUpdate.FirstName;
            customerFromDB.LastName = customerUpdate.LastName;
            customerFromDB.Address = customerUpdate.Address;
            return customerFromDB;
        }
    }
}
