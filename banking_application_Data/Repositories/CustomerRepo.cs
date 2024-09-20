using banking_application_Data.Entities;
using banking_application_Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace banking_application_Data.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync(); 
            return customer;
        }

        public async Task DeleteAsync(int id)
        {
            var customerToDelete = await _context.Customers.FindAsync(id); 
            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete); 
                await _context.SaveChangesAsync(); 
            }
        }

        public async Task<ICollection<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync(); 
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id); 
        }

        public async Task<Customer> UpdateAsync(Customer updatedCustomer, int id)
        {
            if (updatedCustomer == null || id != updatedCustomer.Id)
            {
                return null; 
            }
            _context.Customers.Update(updatedCustomer); 
            await _context.SaveChangesAsync(); 

            return updatedCustomer;
        }
    }
}
