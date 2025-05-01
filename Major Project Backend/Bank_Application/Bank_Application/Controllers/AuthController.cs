using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bank_Application.Data;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.LoginDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Bank_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration _configuration;
        MyContext _myContext;
        IAuditService _auditService;
        IHttpContextAccessor _httpContextAccessor;

        public AuthController(IConfiguration configuration, MyContext myContext, IAuditService auditService, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _myContext = myContext;
            _auditService = auditService;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var adminEntity = _myContext.Admin.SingleOrDefault(u => u.AdminEmail == loginDto.username);
            var companyEntity = _myContext.Companies.SingleOrDefault(c => c.CompanyEmail == loginDto.username);
            var bankEntity = _myContext.Banks.SingleOrDefault(p => p.BankUserName == loginDto.username);

            if (adminEntity != null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(loginDto.password, adminEntity.AdminPassword))
                {
                    return await GenerateTokenForAdmin(adminEntity, _configuration);
                }
                return Unauthorized("Invalid Admin Email or Password.");
            }

            if (companyEntity != null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(loginDto.password, companyEntity.CompanyPassword))
                {
                    return await GenerateTokenForCompany(companyEntity, _configuration);
                }
                return Unauthorized("Invalid Company Email or Password.");
            }

            if (bankEntity != null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(loginDto.password, bankEntity.BankPassword))
                {
                    return await GenerateTokenForBank(bankEntity, _configuration);
                }
                return Unauthorized("Invalid Bank Username or Password.");
            }

            return NotFound("User not found.");
        }

      


        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GenerateTokenForAdmin(Admin loggeduser, IConfiguration configuration)
        {
            Role role = _myContext.Roles.Find(loggeduser.RoleId);

            var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(ClaimTypes.Role, role.RoleName),
                        new Claim("EmailId",loggeduser.AdminEmail),
                        new Claim("AdminFirstName" , loggeduser.AdminFirstName),
                        new Claim("AdminLastName" , loggeduser.AdminLastName),
                        new Claim("ProfileImage", loggeduser.AdminProfilePhoto),


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


                 _auditService.AddToAuditLog(
                emailId: loggeduser.AdminEmail,
                activityPerformed: $"{loggeduser.AdminEmail} Admin logged in",
                roleName: role.RoleName
                );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }



        [ApiExplorerSettings(IgnoreApi = true)]

        public async Task<IActionResult> GenerateTokenForBank(Bank loggeduser, IConfiguration configuration)
        {
            Role role = _myContext.Roles.Find(loggeduser.RoleId);
            var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(ClaimTypes.Role, role.RoleName),
                         new Claim("EmailId",loggeduser.BankUserName),

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

            _auditService.AddToAuditLog(
               emailId: loggeduser.BankUserName,
               activityPerformed: $"{loggeduser.BankUserName} Bank logged in",
               roleName: role.RoleName
               );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }



        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GenerateTokenForCompany(Company loggeduser, IConfiguration configuration)
        {
            Role role = _myContext.Roles.Find(loggeduser.RoleId);
            var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(ClaimTypes.Role, role.RoleName),
                        new Claim("EmailId",loggeduser.CompanyEmail),
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

            _auditService.AddToAuditLog(
               emailId: loggeduser.CompanyEmail,
               activityPerformed: $"{loggeduser.CompanyEmail} Company logged in",
               roleName: role.RoleName
               );
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }







    }
}
