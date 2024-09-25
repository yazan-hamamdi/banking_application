using banking_application_Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly SignInManager<Customer> _signInManager;
    private readonly UserManager<Customer> _userManager;
    private readonly JwtService _jwtService;

    public LoginController(SignInManager<Customer> signInManager, UserManager<Customer> userManager, JwtService jwtService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtService = jwtService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
            return Unauthorized(new { message = "Invalid login attempt." });

        var result = await _signInManager.PasswordSignInAsync(user.UserName, loginDto.Password, false, false);

        if (!result.Succeeded)
            return Unauthorized(new { message = "Invalid login attempt." });

        var roles = await _userManager.GetRolesAsync(user);
        var token = _jwtService.GenerateJwtToken(user, roles);

        return Ok(new
        {
            token = token
        });
    }
}
