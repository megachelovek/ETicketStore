using ETicketStore.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ETicketStore.Api.Admin.Controllers
{
    [Authorize]
    [ApiController]
    [Route("login/[controller]")]
    public class AccountController : ControllerBase
    {
        private ApplicationContext _context;
        private IConfiguration _configuration;

        public AccountController(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("GetToken")]
        public async Task<string> GetToken()//(Login model)
        {
            await _context.UpdateUsersAndRoles();
            User user = _context.Users
                .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password && u.Role.Name == "Admin");

            if (user != null)
            {
                //return GenerateToken(user);
            }
            return "Unauthorized";
        }

        
    }
}
