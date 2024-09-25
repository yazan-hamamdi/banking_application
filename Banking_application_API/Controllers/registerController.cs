using Banking_application_API.DTOs;
using banking_application_Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Banking_application_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class registerController : ControllerBase
    {
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public registerController(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCustomerDto model)
        {
            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                return BadRequest(new { message = "Role does not exist." });
            }

            var user = new Customer
            {
                UserName = model.FirstName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(user, model.Role);

            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return BadRequest(roleResult.Errors);
            }

            return Ok(new { message = "User registered successfully with role: " + model.Role });
        }
    }
}
