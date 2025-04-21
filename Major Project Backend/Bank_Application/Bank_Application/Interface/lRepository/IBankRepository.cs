using Bank_Application.Model;
using Bank_Application.Model.BankDto;

namespace Bank_Application.Interface.lRepository
{
    public interface IBankRepository
    {
        public Bank AddBank (AddBankDto addbankDto);

    }
}
