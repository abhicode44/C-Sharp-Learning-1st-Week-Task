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
        public IActionResult AddCompany([FromForm] AddCompanyDto addCompanyDto)
        {
            string password = BCrypt.Net.BCrypt.EnhancedHashPassword(addCompanyDto.CompanyPassword);
            addCompanyDto.CompanyPassword = password;
            var companyEntity = companyService.AddCompany(addCompanyDto);
            return Ok(companyEntity);
        }


        [HttpPost("AddInboundCompany")]
        [Authorize(Roles = "Company")]
        public IActionResult AddInBoundBenificiary([FromForm] AddInBoundBenificiaryDto addInBoundBenificiaryDto)
        {
            var benificiaryEntity = companyService.AddInBoundBenificiary(addInBoundBenificiaryDto);
            return Ok(benificiaryEntity);
        }



        [HttpPost("AddOutBoundCompany")]
        [Authorize(Roles = "Company")]
        public IActionResult AddOutBoundBenificiary([FromForm] AddOutBoundBenificiaryDto addOutBoundBenificiary)
        {
            var result = companyService.AddOutBoundBenificiary(addOutBoundBenificiary);
            return Ok(result);
        }

        [HttpPost("AddTransation")]
        public IActionResult AddTransaction([FromForm] AddTransactionDto addTransactionDto)
        {
            var result = companyService.AddTransaction(addTransactionDto);
            return Ok(result);
        }


        [HttpPost("UploadEmpolyees")]
        [Authorize(Roles = "Company")]
        public IActionResult AddEmploye(IFormFile csvFile)
        {
            if (csvFile == null || csvFile.Length == 0)
            {
                return BadRequest("Please upload a valid CSV file.");
            }

            companyService.AddEmploye(csvFile);
            return Ok("Employees added successfully.");
        }

        [HttpGet("GetAllEmployeesList")]
        [Authorize(Roles = "Company")]
        public IActionResult GetAllEmployees()
        {
            var result = companyService.GetAllEmployees();
            return Ok(result);
        }


        [HttpPost("AddSalaryDistribution")]
        [Authorize(Roles = "Company")]
        public IActionResult AddSalaryDistribution([FromForm] AddSalaryDistributionDto addSalaryDistributionDto)
        {
            var result = companyService.AddSalaryDistribution(addSalaryDistributionDto);
            return Ok(result);
        }

    }
}
