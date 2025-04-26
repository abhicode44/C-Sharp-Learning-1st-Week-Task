using Bank_Application.Interface.IServices;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.BankDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService bankService;

        public BankController(IBankService bankService)
        {
            this.bankService = bankService;
        }


        [HttpPost("AddBank")]
        public IActionResult AddBank (AddBankDto addBankDto)
        {
            string password = BCrypt.Net.BCrypt.EnhancedHashPassword(addBankDto.BankPassword);
            addBankDto.BankPassword = password; 
            var bankEntity = bankService.AddBank(addBankDto);   
            return Ok (bankEntity);
        }

        [HttpGet("GetAllBank")]

        public IActionResult GetAllBank()
        {
            var result = bankService.GetAllBank();
            return Ok (result);
        }

        

    }

    
}

