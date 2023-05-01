using AdproApi.Context;
using AdproApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdproApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        DataBaseContext _context;
        IConfiguration _configuration;
        public AuthenticationController(DataBaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var users = _context.Users.Where(a => a.Username == user.Username && a.Password == user.Password).ToList();
            
            return Ok(users);

        }

        [HttpPut]
        [Route("changepassword/{id}/{oldpassword}/{newpassword}")]

        public async Task<IActionResult> Changepassword([FromRoute] int id, [FromRoute] string oldpassword, [FromRoute] string newpassword)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();
            if (user.Password.Equals(oldpassword))
            {
                user.Password = newpassword;
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            else
            {
                return NotFound();
            }


        }

    }
}
