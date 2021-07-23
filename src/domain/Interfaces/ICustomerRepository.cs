using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> FindAll();
        Task<Customer> FindById(Guid id);
        Task<Customer> Create(Customer customer);
        Task<Customer> Update(Customer customer);
        Task Delete(Customer customer);
    }
}
