using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly private PetAppContext _pac;

        public CustomerRepository(PetAppContext pac)
        {
            _pac = pac;
        }
        public Customer CreateCustomer(Customer customer)
        {
            var customer2add = _pac.Customers.Add(customer).Entity;
            _pac.SaveChanges();
            return customer2add;
        }

        public Customer ReadCustomerById(int id)
        {
            return _pac.Customers.FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Customer> ReadCustomers()
        {
            return _pac.Customers;
        }

        public Customer RemoveCustomer(int idCustomer)
        {
            var customer2removeFromList = ReadCustomerById(idCustomer);
            var customer2remove = _pac.Customers.Remove(customer2removeFromList).Entity;
            _pac.SaveChanges();
            return customer2remove;
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            var customerFromDB = ReadCustomerById(customerUpdate.ID);
            if (customerFromDB == null) return null;

            customerFromDB.FirstName = customerUpdate.FirstName;
            customerFromDB.LastName = customerUpdate.LastName;
            customerFromDB.Address = customerUpdate.Address;
            return customerFromDB;
        }
    }
}
