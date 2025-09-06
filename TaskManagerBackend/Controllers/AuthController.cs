using Microsoft.AspNetCore.Mvc;
using TaskManagerBackend.Models;
using TaskManagerBackend.Repositories;
using TaskManagerBackend.Utils;
namespace TaskManagerBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    
    public AuthController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] RegisterRequestModel request)
    {
        if (request.Password != request.ConfirmPassword)
        {
            return BadRequest("Passwords do not match.");
        }
        string hashedPassword = PasswordHash.HashPassword(request.Password);
        var user = new User
        {
           Username = request.Username,
           Email = request.Email,
           PasswordHash = hashedPassword,
           Projects = new List<Project>()
        };
        await _userRepository.AddUserAsync(user);
        
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginRequestModel request)
    {
        var token = await _userRepository.Validate(request.Username, request.Password);
        if (token == null)
        {
            return Unauthorized("Invalid username or password");
        }
        
        return Ok(new { message = "Login successful", token });
    }
}