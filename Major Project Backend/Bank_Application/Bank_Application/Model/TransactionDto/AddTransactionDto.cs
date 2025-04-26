using System.Diagnostics.CodeAnalysis;

namespace Bank_Application.Model.TransactionDto
{
    public class AddTransactionDto
    {
        [NotNull]
        public string TransferFromCompanyEmail { get; set; }

        
        [NotNull]
        public string TransferToBenificaryCompanyEmail { get; set; }

        [NotNull]
        public int TransactionAmount { get; set; }

    }
}
