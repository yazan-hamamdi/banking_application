using Banking_application_Business.IServices;
using banking_application_Data.Entities;
using banking_application_Data.IEntities;
using Microsoft.AspNetCore.Mvc;

namespace Banking_application_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCustomer = await _customerService.AddAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedCustomer = await _customerService.UpdateAsync(customer, id);
            if (updatedCustomer == null)
                return NotFound();

            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
