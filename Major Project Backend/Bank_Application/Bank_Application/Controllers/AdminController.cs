using System.Reflection.Metadata.Ecma335;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.BankDto;
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
        
        public async Task<IActionResult> AddAdmin( [FromForm] AddAdminDto addAdminDto)
        {
            string password = BCrypt.Net.BCrypt.EnhancedHashPassword(addAdminDto.AdminPassword);
            addAdminDto.AdminPassword = password;
            var result =await  adminService.AddAdmin(addAdminDto);

            return Ok(new { message = "Admin Added Successfully" });
        }


        [HttpPost("AddBank")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBank([FromForm] AddBankDto addBankDto)
        {
            try
            {
                
                string password = BCrypt.Net.BCrypt.EnhancedHashPassword(addBankDto.BankPassword);
                addBankDto.BankPassword = password;

                
                var bankEntity = await adminService.AddBank(addBankDto);

               
                return Ok(new { message = "Bank Added Successfully" });
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An error occurred while adding the bank. Please try again later.");
            }
        }

        [HttpGet("GetAllBank")]
        [Authorize(Roles = "Admin")]
        public  async Task<IActionResult> GetAllBank()
        {
            var result = await adminService.GetAllBank();

            return Ok(result);
        }


        [HttpPut("AdminActivation/{AdminId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> updateAdminActivation(int AdminId ,[FromForm] AdminActivationDto activationDto)
        {
            var adminEntity = await adminService.updateAdminActivation(AdminId, activationDto);
            return Ok(adminEntity);
        }


        [HttpGet("GetAllAdmin")]
        [Authorize(Roles = "Admin")]
        public async  Task<IActionResult> GetAllAdmin()
        {
            var result = await adminService.GetAllAdmin();
            return Ok(result);
        }


        [HttpPut("VerifyCompanyDocument")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDocumentVerify([FromQuery] string CompanyEmail, [FromBody] DocumentVerifyDto documentVerifyDto)
        {
            var result = await adminService.UpdateDocumentVerify(CompanyEmail, documentVerifyDto);
            return Ok(result);
        }


        [HttpGet("GetAllApprovedCompaines")]
        public async Task<IActionResult> GetAllApprovedCompanies()
        {
            var result = await  adminService.GetAllApprovedCompanies();
            return Ok(result);

        }



        [HttpGet("GetAllPendingCompaines")]
        public async Task<IActionResult> GetAllPendingCompanies()
        {
            var result = await adminService.GetAllPendingCompanies();
            return Ok(result);
        }

        [HttpGet("GetAllPendingOutBoundCompany")]
        public async Task<IActionResult> GetAllPendingOutBenificiaryBoundCompany()
        {
            var result = await adminService.GetAllPendingOutBenificiaryBoundCompany();
            return Ok(result);
        }


        [HttpPut("VerifyOutBoundCompany/{BenificiaryId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> VerifyOutBoundCompany(int BenificiaryId, [FromForm]  VerifyOutBoundCompanyDto verifyOutBoundCompanyDto)
        {
            var result = await  adminService.VerifyOutBoundCompany(BenificiaryId , verifyOutBoundCompanyDto);
            return Ok(result);
        }

        [HttpGet("GetAllApprovedOutBoundCompany")]
        public async Task<IActionResult> GetAllApprovedOutBenificiaryBoundCompany()
        {
            var result = await adminService.GetAllApprovedOutBenificiaryBoundCompany();
            return Ok(result);
        }


        [HttpGet("GetAllPendingTransaction")]
        public async Task<IActionResult> GetAllPendingTransactionRequest()
        {
            var result = await adminService.GetAllPendingTransactionRequest();
            return Ok(result);
        }

        [HttpPut("VerifyTransaction")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> VerifyTransactionRequest([FromQuery]  int TransactionId,[FromForm] VerifyTransactionDto verifyTransactionDto)
        {
            var result = await  adminService.VerifyTransactionRequest(TransactionId, verifyTransactionDto);
            return Ok(result);
        }

        [HttpGet("GetAllApprovedTransaction")]
        public async Task<IActionResult> GetAllApprovedTransaction()
        {
            var result = await  adminService.GetAllApprovedTransaction();
            return Ok(result);
        }

        [HttpGet("Get-AllPending-SalaryDistribution-Request")]

        public async Task<IActionResult> GetAllPendingSalaryDistributions()
        { 
            var reult =  await adminService.GetAllPendingSalaryDistributions();
            return Ok(reult);
        }



        [HttpGet("Get-AllApproved-SalaryDistribution-Request")]
        public async Task<IActionResult> GetAllApprovedSalaryDistributions()
        {
            var result = await  adminService.GetAllApprovedSalaryDistributions();
            return Ok(result);
        }



        [HttpPut("VerifySalaryDistribution")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> VerifySalaryDistribution([FromBody] VerifySalaryDistributionDto verifySalaryDistributionDto)
        {
            try
            {
                var result = await adminService.VerifySalaryDistribution(0, verifySalaryDistributionDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetAllAuditLogs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAuditsLogs()
        {
            var result = await adminService.GetAllAuditsLogs();
            return Ok(result);
        }

    }
}
