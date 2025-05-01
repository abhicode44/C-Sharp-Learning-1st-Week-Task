using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.BankDto;

namespace Bank_Application.Services
{
    public class BankService : IBankService
    {
        IGenericRepository<Bank> repository;

        public BankService(IGenericRepository<Bank> bankRepository)
        {
            this.repository = bankRepository;
        }

       


        
    }
}
