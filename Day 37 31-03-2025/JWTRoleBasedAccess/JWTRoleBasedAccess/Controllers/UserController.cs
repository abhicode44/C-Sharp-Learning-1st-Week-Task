using JWTRoleBasedAccess.Data;
using JWTRoleBasedAccess.Model;
using JWTRoleBasedAccess.Model.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTRoleBasedAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly MyContext _myContext;
        public UserController(MyContext _myContext)
        {
            this._myContext = _myContext;
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]

        public IActionResult AddUser(AddUserDto addUserDto)
        {
            var newuser = new Users()
            {
                UserName = addUserDto.UserName,
                Password = addUserDto.Password,
                RoleId = 2

            };

            _myContext.users.Add(newuser);
            _myContext.SaveChanges();
            return Ok(newuser);

        }


        [HttpGet]
        [Authorize (Roles = "User")]
        public IActionResult GetAllEmployees()
        {
            return Ok(_myContext.users.ToList()); 
        }



    }
}
