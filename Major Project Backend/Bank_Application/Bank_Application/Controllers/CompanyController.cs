using Bank_Application.Interface.IServices;
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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }



        [HttpPost("AddCompany")]
        public async Task<IActionResult> AddCompany([FromForm] AddCompanyDto addCompanyDto)
        {
            string password = BCrypt.Net.BCrypt.EnhancedHashPassword(addCompanyDto.CompanyPassword);
            addCompanyDto.CompanyPassword = password;
            var companyEntity = await companyService.AddCompany(addCompanyDto);
            return Ok(new { message = "New Company Added" });
        }


        [HttpPost("AddInboundCompany")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> AddInBoundBenificiary([FromForm] AddInBoundBenificiaryDto addInBoundBenificiaryDto)
        {
            var benificiaryEntity = await companyService.AddInBoundBenificiary(addInBoundBenificiaryDto);
            return Ok(benificiaryEntity);
        }



        [HttpPost("AddOutBoundCompany")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> AddOutBoundBenificiary([FromForm] AddOutBoundBenificiaryDto addOutBoundBenificiary)
        {
            var result = await companyService.AddOutBoundBenificiary(addOutBoundBenificiary);
            return Ok(result);
        }

        [HttpPost("AddTransation")]
        public async Task<IActionResult> AddTransaction([FromForm] AddTransactionDto addTransactionDto)
        {
            var result = await companyService.AddTransaction(addTransactionDto);
            return Ok(result);
        }


        [HttpPost("UploadEmpolyees")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> AddEmploye(IFormFile csvFile)
        {
            if (csvFile == null || csvFile.Length == 0)
            {
                return BadRequest("Please upload a valid CSV file.");
            }

            await companyService.AddEmploye(csvFile);
            return Ok("Employees added successfully.");
        }


        [HttpGet("GetAllEmployeesList")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await companyService.GetAllEmployees();
            return Ok(result);
        }

        [HttpGet("GetAllInboundCompany")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> GetAllInboundBenificiary()
        {
            var result = await companyService.GetAllInboundBenificiary();
            return Ok(result);
        }

        [HttpGet("GetAllOutboundCompany")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> GetAllOutboundBenificiary()
        {
            var result = await companyService.GetAllOutboundBenificiary();
            return Ok(result);
        }

        [HttpGet("GetAllApprovedBenificiaryCompany")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> GetAllApprovedBenificiary()
        {
            var result = await companyService.GetAllApprovedBenificiary();
            return Ok(result);
        }




        [HttpPost("AddSalaryDistribution")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> AddSalaryDistribution([FromBody] AddSalaryDistributionDto addSalaryDistributionDto)
        {
            var result =  await companyService.AddSalaryDistribution(addSalaryDistributionDto);
            return Ok(result);
        }



    }
}
