using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Data;
using ProductManagementSystem.DTOs;


namespace ProductManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Username == request.Username ||
                    u.Email == request.Email);

            if (existingUser != null)
            {
                return BadRequest("Username or email already exists.");
            }

            return Ok();
        }

    }
}
