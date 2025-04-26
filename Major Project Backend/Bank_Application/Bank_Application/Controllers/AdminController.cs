using System.Reflection.Metadata.Ecma335;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;
using Bank_Application.Model.SalaryDistrubutionDto;
using Bank_Application.Model.TransactionDto;
using Bank_Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        

        public AdminController(IAdminService adminService ) 
        {
            this.adminService = adminService;
            
            
        }


        

        [HttpPost("AddAdmin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddAdmin( [FromForm] AddAdminDto addAdminDto)
        {
            string password = BCrypt.Net.BCrypt.EnhancedHashPassword(addAdminDto.AdminPassword);
            addAdminDto.AdminPassword = password;
            var result = adminService.AddAdmin(addAdminDto);
            return Ok(result);
        }


        [HttpPut("AdminActivation/{AdminId:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult updateAdminActivation(int AdminId ,[FromForm] AdminActivationDto activationDto)
        {
            var adminEntity = adminService.updateAdminActivation(AdminId, activationDto);
            return Ok(adminEntity);
        }


        [HttpGet("GetAllAdmin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllAdmin ()
        {
            var result = adminService.GetAllAdmin();
            return Ok(result);
        }

        [HttpPut("VerifyCompanyDocument")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult VerifyOutBoundCompany(int BenificiaryId, [FromForm]  VerifyOutBoundCompanyDto verifyOutBoundCompanyDto)
        {
            var result = adminService.VerifyOutBoundCompany(BenificiaryId , verifyOutBoundCompanyDto);
            return Ok(result);
        }

        [HttpGet("GetAllApprovedOutBoundCompany")]
        public IActionResult GetAllApprovedOutBenificiaryBoundCompany()
        {
            var result = adminService.GetAllApprovedOutBenificiaryBoundCompany();
            return Ok(result);
        }


        [HttpGet("GetAllPendingTransaction")]
        public IActionResult GetAllPendingTransactionRequest()
        {
            var result = adminService.GetAllPendingTransactionRequest();
            return Ok(result);
        }

        [HttpPut("VerifyTransaction")]
        [Authorize(Roles = "Admin")]
        public IActionResult VerifyTransactionRequest([FromQuery]  int TransactionId,[FromForm] VerifyTransactionDto verifyTransactionDto)
        {
            var result = adminService.VerifyTransactionRequest(TransactionId, verifyTransactionDto);
            return Ok(result);
        }

        [HttpGet("GetAllApprovedTransaction")]
        public IActionResult GetAllApprovedTransaction()
        {
            var result = adminService.GetAllApprovedTransaction();
            return Ok(result);
        }

        [HttpGet("Get-AllPending-SalaryDistribution-Request")]

        public IActionResult GetAllPendingSalaryDistributions()
        {
            var reult = adminService.GetAllPendingSalaryDistributions();
            return Ok(reult);
        }

        [HttpGet("Get-AllApproved-SalaryDistribution-Request")]
        public IActionResult GetAllApprovedSalaryDistributions()
        {
            var result = adminService.GetAllApprovedSalaryDistributions();
            return Ok(result);
        }

        [HttpPut("Verify-Salary-Distribution/{SalaryDistributionId:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult VerifySalaryDistribution( int SalaryDistributionId, [FromForm]  VerifySalaryDistributionDto verifySalaryDistributionDto)
        {
            var result = adminService.VerifySalaryDistribution(SalaryDistributionId, verifySalaryDistributionDto);
            return Ok(result);
        }

    }
}
