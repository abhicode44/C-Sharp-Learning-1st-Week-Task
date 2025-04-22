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
        public Bank AddBank(AddBankDto addBankDto)
        {
            var bankEntity = new Bank
            {
                BankName = addBankDto.BankName,
                BankBranchCode = addBankDto.BankBranchCode,
                BankBranchName = addBankDto.BankBranchName,
                BankUserName = addBankDto.BankUserName,
                BankPassword = addBankDto.BankPassword, 
                RoleId = 2
            };
            repository.Add(bankEntity);
            return bankEntity;
        }

        public List<Bank> GetAllBank()
        {
            return repository.GetAll();
        }
    }
}
