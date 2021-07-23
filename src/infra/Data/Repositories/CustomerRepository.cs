using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context.Context _context;
        private readonly DbSet<Customer> _dbSet;


        public CustomerRepository(
            Context.Context context)
        {
            _context = context;
            _dbSet = context.Set<Customer>();
        }

        public async Task<Customer> Create(Customer customer)
        {
            await _dbSet.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task Delete(Customer customer)
        {
            _dbSet.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Customer> FindAll() => _dbSet;

        public async Task<Customer> FindById(Guid id) => await _dbSet.SingleOrDefaultAsync(c => c.Id == id);

        public async Task<Customer> Update(Customer customer)
        {
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
