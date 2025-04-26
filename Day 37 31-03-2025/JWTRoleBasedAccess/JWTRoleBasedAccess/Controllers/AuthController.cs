using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTRoleBasedAccess.Data;
using JWTRoleBasedAccess.Model;
using JWTRoleBasedAccess.Model.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTRoleBasedAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration _configuration;
        MyContext _myContext;

        public AuthController (IConfiguration configuration , MyContext myContext)
        {
            _configuration = configuration;
            _myContext = myContext;

        }


        [HttpPost("login")]
        public async Task <IActionResult> Login([FromBody] AddUserDto addUserDto) 
        {
            Users loggeduser = _myContext.users.SingleOrDefault(u => u.UserName == addUserDto.UserName && u.Password == addUserDto.Password);
            return await GenerateToken(loggeduser, _configuration);

        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GenerateToken(Users loggeduser, IConfiguration configuration)
        {
            Role role = _myContext.roles.Find(loggeduser.RoleId);
            var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(ClaimTypes.Role, role.RoleName)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(10),
                signingCredentials: signIn
                );
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

    }
}
