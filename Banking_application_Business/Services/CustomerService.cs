using AutoMapper;
using Banking_application_Business.DTOs;
using Banking_application_Business.IServices;
using banking_application_Data.Entities;
using banking_application_Data.IRepositories;

namespace Banking_application_Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<CustomerWithId> AddAsync(CustomerWithId customer)
        {
            var realCustomer = _mapper.Map<Customer>(customer); 
            await _customerRepo.AddAsync(realCustomer);
            var customerWithId = _mapper.Map<CustomerWithId>(realCustomer);
            return customerWithId;
        }

        public async Task DeleteAsync(int id)
        {
            await _customerRepo.DeleteAsync(id);
        }

        public async Task<ICollection<CustomerWithoutId>> GetAllAsync()
        {
            var customers = await _customerRepo.GetAllAsync();
            return _mapper.Map<ICollection<CustomerWithoutId>>(customers); 
        }

        public async Task<CustomerWithoutId> GetByIdAsync(int id)
        {
            var customer = await _customerRepo.GetByIdAsync(id);
            return _mapper.Map<CustomerWithoutId>(customer); 
        }

        public async Task<CustomerWithoutId> UpdateAsync(CustomerWithId customer, int id)
        {
            var realCustomer = _mapper.Map<Customer>(customer); 
            var updatedCustomer = await _customerRepo.UpdateAsync(realCustomer, id);
            return _mapper.Map<CustomerWithoutId>(updatedCustomer); 
        }
    }
}
