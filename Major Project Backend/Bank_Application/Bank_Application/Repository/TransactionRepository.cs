using System.Reflection.Metadata.Ecma335;
using System.Transactions;
using Bank_Application.Data;
using Bank_Application.Interface.lRepository;
using Bank_Application.Model;
using Bank_Application.Model.TransactionDto;
using Microsoft.EntityFrameworkCore;


namespace Bank_Application.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MyContext context;
        DbSet<Transactionn> dbset;

        public TransactionRepository(MyContext context)
        {
            this.context = context;
            dbset = context.Set<Transactionn>();
        }

        public Transactionn AddTransaction(AddTransactionDto addTransactionDto)
        {
            var transactionEntity = new Transactionn
            {
                TransferFromCompanyEmail = addTransactionDto.TransferFromCompanyEmail,
                TransferToBenificaryCompanyEmail = addTransactionDto.TransferToBenificaryCompanyEmail,
                TransactionAmount = addTransactionDto.TransactionAmount,
                IsTransactionApproved = false,
                TransactionDescription = "",
                PaymentDate = DateTime.Now,
            };
            dbset.Add(transactionEntity);
            context.SaveChanges();
            return transactionEntity;
        }


        public List<Transactionn> GetAllPendingTransactionRequest()
        {
            return dbset.Where(c => c.IsTransactionApproved == false).ToList();
        }

        public List<Transactionn> GetAllApprovedTransactionRequest()
        {
            return dbset.Where(c => c.IsTransactionApproved == true).ToList();
        }





    }
}
