using System.Diagnostics.CodeAnalysis;

namespace Bank_Application.Model
{
    public class Transaction
    {
        public int TransactionId { get; set; }


        public string TransactionDescription { get; set; }

        public bool IsTransactionApproved { get; set; }

        [NotNull]
        public string TransferFromCompanyEmail { get; set; }
        [NotNull]
        public string TransferToBenificaryCompanyEmail { get; set; }

        public DateTime PaymentDate { get; set; }

    }
}
