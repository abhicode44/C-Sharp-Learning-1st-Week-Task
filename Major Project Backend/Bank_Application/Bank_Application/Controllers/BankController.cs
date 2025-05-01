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


       

       

        

    }

    
}

