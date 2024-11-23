using DBOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DBOperationsWithEFCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;

        public StudentController(AppDbContext appDbContext, IConfiguration configuration)
        {
            this._appDbContext = appDbContext;
            this._configuration = configuration;
        }
        [HttpPost()]
        
        public IActionResult Login()
        {
            var users = _appDbContext.UserAccounts.FirstOrDefault();
            if (users != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Id", users.Id.ToString()),
                    new Claim("UserName", users.UserName.ToString())

                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn
                    );
                var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = tokenValue, User = users });
            }
            return NoContent();
        }
        [HttpGet("")]
        [Authorize]
        public IActionResult GetAllStudent()
        {
            var student = _appDbContext.Students.ToList();
            return Ok(student);
        }

    }
}
