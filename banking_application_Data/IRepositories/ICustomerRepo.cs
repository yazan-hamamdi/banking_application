using banking_application_Data.Entities;
using banking_application_Data.IEntities;

namespace banking_application_Data.IRepositories
{
    public interface ICustomerRepo
    {
        Task<ICollection<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer, int id);
        Task DeleteAsync(int id);
    }
}
