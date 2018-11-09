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

        public List<Customer> FindCustomerByID(int id)
        {
            var list = _customRepo.ReadCustomers();
            var IDList = list.Where(cust => cust.ID.Equals(id));
            return IDList.ToList();
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
            var customer = _customRepo.ReadCustomerById(customerUpdate.ID);
            customer.Address = customerUpdate.Address;
            customer.FirstName = customerUpdate.FirstName;
            customer.LastName = customerUpdate.LastName;
            return customer;
        }
    }
}
