using AutoMapper;
using ContactApp_WebAPI.Interface;
using ContactApp_WebAPI.Interface.IServices;
using ContactApp_WebAPI.Mapper;
using ContactApp_WebAPI.Model.Entity;
using ContactApp_WebAPI.Model.UserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices userServices;
        IMapper mapper;
        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            // this.mapper = mapper;
        }
        [HttpGet("all-users")]
        public IActionResult GetAllUsers()
        {
            var allUsers = userServices.GetAllUsers();
            var getUsers = mapper.Map<List<GetAllUserDto>>(allUsers);
            return Ok(allUsers);
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] LoginUserDto loginDto)
        {
            var users = userServices.LoginUser(loginDto.UserId, loginDto.Password);
            if (users != null)
            {
                var userSuccessDto = mapper.Map<LoginUserSuccessDto>(users);
                return Ok(userSuccessDto);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("add-users-staff")]
        public IActionResult AddStaff(AddUserDto addUserDto)
        {
            string passwd = BCrypt.Net.BCrypt.EnhancedHashPassword(addUserDto.Password);
            addUserDto.Password = passwd;
            var user = mapper.Map<User>(addUserDto);
            var userEntity = userServices.AddStaff(user);
            return Ok();
        }
        [HttpPut("update-user-name-staff/{userId:int}")]
        public IActionResult UpdateStaffName(int userId, UpdateUserNameDto updateUserNameDto)
        {
            var userEntity = userServices.UpdateStaffName(userId, updateUserNameDto);
            return Ok(userEntity);
        }
        [HttpPut("update-user-activation-staff/{userId:int}")]
        public IActionResult UpdateStaffActivation(int userId, UpdateUserActivationDto updateUserActivationDto)
        {
            var userEntity = userServices.UpdateStaffActivation(userId, updateUserActivationDto);
            return Ok(userEntity);
        }
        [HttpGet("get-by-user-id/{userId:int}")]
        public IActionResult GetByID(int userId)
        {
            var user = userServices.GetByID(userId);
            return Ok(user);
        }
        [HttpDelete("remove-user-access/{userId:int}")]
        public IActionResult DeleteEmployees(int userId)
        {
            userServices.DeleteEmployees(userId);
            return Ok();
        }
    }
}
