using System.Transactions;
using Bank_Application.Model;
using Bank_Application.Model.TransactionDto;

namespace Bank_Application.Interface.lRepository
{
    public interface ITransactionRepository
    {
        public Transactionn  AddTransaction (AddTransactionDto addTransactionDto);

        public List<Transactionn> GetAllPendingTransactionRequest();

        public List<Transactionn> GetAllApprovedTransactionRequest();

    }
}
