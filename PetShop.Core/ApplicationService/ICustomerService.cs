using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer FindCustomerByID(int id);
        Customer UpdateCustomer(Customer customerUpdate);
        Customer CreateCustomer(Customer customer);
        Customer RemoveCustomer(int idSelection);
    }
}
