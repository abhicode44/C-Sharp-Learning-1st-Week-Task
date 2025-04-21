using Bank_Application.Model;
using Bank_Application.Model.BankDto;

namespace Bank_Application.Interface.IServices
{
    public interface IBankService
    {
        public Bank AddBank(AddBankDto addbankDto);

    }
}
