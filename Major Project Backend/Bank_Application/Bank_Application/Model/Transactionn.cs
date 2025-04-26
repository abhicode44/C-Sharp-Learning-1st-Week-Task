using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Bank_Application.Model
{
    public class Transactionn
    {
        [Key]
        public int TransactionId { get; set; }
        public string TransactionDescription { get; set; }
        public bool IsTransactionApproved { get; set; }

        [NotNull]
        public int TransactionAmount { get; set; }

        [NotNull]
        public string TransferFromCompanyEmail { get; set; }
        [NotNull]
        public string TransferToBenificaryCompanyEmail { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
