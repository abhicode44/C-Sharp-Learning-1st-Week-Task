using Bank_Application.Interface.IServices;
using Bank_Application.Model.BankDto;
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

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }


        [HttpPost("AddCompany")]
        public IActionResult AddBank([FromForm]AddCompanyDto addCompanyDto)
        {
            var companyEntity = companyService.AddCompany(addCompanyDto);
            return Ok(companyEntity);
        }
    }
}
