using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> ReadCustomers();
        Customer UpdateCustomer(Customer customerUpdate);
        Customer CreateCustomer(Customer customer);
        Customer RemoveCustomer(int idCustomer);
        Customer ReadCustomerById(int id);
    }
}
