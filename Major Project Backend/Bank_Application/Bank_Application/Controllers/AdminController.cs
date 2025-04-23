using System.Reflection.Metadata.Ecma335;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;
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
        

        public AdminController(IAdminService adminService , ICompanyService companyService) 
        {
            this.adminService = adminService;
            
            
        }

        [HttpPost("AddAdmin")]
        public IActionResult AddAdmin( [FromForm] AddAdminDto addAdminDto)
        {
            var result = adminService.AddAdmin(addAdminDto);
            return Ok(result);
        }


        [HttpPut("AdminActivation/{AdminId:int}")]

        public IActionResult updateAdminActivation(int AdminId ,[FromForm] AdminActivationDto activationDto)
        {
            var adminEntity = adminService.updateAdminActivation(AdminId, activationDto);
            return Ok(adminEntity);
        }


        [HttpGet("GetAllAdmin")]

        public IActionResult GetAllAdmin ()
        {
            var result = adminService.GetAllAdmin();
            return Ok(result);
        }

        [HttpPut("VerifyCompanyDocument")]
        public IActionResult UpdateDocumentVerify([FromQuery] string CompanyEmail, [FromBody] DocumentVerifyDto documentVerifyDto)
        {
            var result = adminService.UpdateDocumentVerify(CompanyEmail, documentVerifyDto);
            return Ok(result);
        }


        [HttpGet("GetAllApprovedCompaines")]
        public   IActionResult GetAllApprovedCompanies()
        {
            var result =  adminService.GetAllApprovedCompanies();
            return Ok(result);

        }



        [HttpGet("GetAllPendingCompaines")]
        public IActionResult GetAllPendingCompanies()
        {
            var result = adminService.GetAllPendingCompanies();
            return Ok(result);
        }

        [HttpGet("GetAllPendingOutBoundCompany")]
        public IActionResult GetAllPendingOutBenificiaryBoundCompany()
        {
            var result = adminService.GetAllPendingOutBenificiaryBoundCompany();
            return Ok(result);
        }

        [HttpPut("VerifyOutBoundCompany/{BenificiaryId:int}")]
        public IActionResult VerifyOutBoundCompany(int BenificiaryId, [FromForm]  VerifyOutBoundCompanyDto verifyOutBoundCompanyDto)
        {
            var result = adminService.VerifyOutBoundCompany(BenificiaryId , verifyOutBoundCompanyDto);
            return Ok(result);
        }

         








    }
}
