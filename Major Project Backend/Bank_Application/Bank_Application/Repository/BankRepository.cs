using Bank_Application.Data;
using Bank_Application.Interface.lRepository;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.BankDto;
using Microsoft.EntityFrameworkCore;

namespace Bank_Application.Repository
{
    public class BankRepository : IBankRepository
    {

        private readonly MyContext context;
        DbSet<Bank> dbset;

        public BankRepository(MyContext context)
        {
            this.context = context;
            dbset = context.Set<Bank>();
        }
        public Bank AddBank(AddBankDto addbankDto)
        {
            var bankEntity = new Bank
            {
               BankName = addbankDto.BankName,
               BankBranchCode = addbankDto.BankBranchCode,
               BankBranchName = addbankDto.BankBranchName,
               BankUserName = addbankDto.BankUserName,
               BankPassword = addbankDto.BankPassword,
               RoleId = 2 ,

            };

            dbset.Add(bankEntity);
            context.SaveChanges();
            return bankEntity;
        }

        public List<Bank> GetAllBank()
        {
            return dbset.ToList();
        }
    }
}
