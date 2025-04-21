using System.Reflection.Metadata.Ecma335;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService) 
        {
            this.adminService = adminService;
            
        }

        [HttpPost("AddAdmin")]
        public IActionResult AddAdmin(AddAdminDto addAdminDto)
        {
            var result = adminService.AddAdmin(addAdminDto);
            return Ok(result);
        }



    }
}
