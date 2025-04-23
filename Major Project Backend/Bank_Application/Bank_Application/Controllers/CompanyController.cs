using Bank_Application.Interface.IServices;
using Bank_Application.Model.BankDto;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService )
        {
            this.companyService = companyService;
        }


        [HttpPost("AddCompany")]
        public IActionResult AddCompany([FromForm]AddCompanyDto addCompanyDto)
        {
            var companyEntity = companyService.AddCompany(addCompanyDto);
            return Ok(companyEntity);
        }


        [HttpPost("AddInboundCompany")]

        public IActionResult AddInBoundBenificiary([FromForm] AddInBoundBenificiaryDto addInBoundBenificiaryDto)
        {
            var benificiaryEntity = companyService.AddInBoundBenificiary(addInBoundBenificiaryDto);
            return Ok(benificiaryEntity);
        }



        [HttpPost("AddOutBoundCompany")]

        public IActionResult AddOutBoundBenificiary( [FromForm] AddOutBoundBenificiaryDto addOutBoundBenificiary)
        {
            var result = companyService.AddOutBoundBenificiary(addOutBoundBenificiary);
            return Ok(result);  
        }

        

    }
}
