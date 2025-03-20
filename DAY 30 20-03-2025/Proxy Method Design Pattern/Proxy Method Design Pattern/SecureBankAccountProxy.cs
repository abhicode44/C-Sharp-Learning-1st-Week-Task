using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Method_Design_Pattern
{
    internal class SecureBankAccountProxy : IBankAccount
    {
        private RealBankAccount realBankAccount;
        

        private string Password { get; set; }

        public SecureBankAccountProxy( string password)
        {
           Password = password;
            Authenticate();
        }

        private void Authenticate()
        {
            if (Password == "secret")
            {
                realBankAccount = new RealBankAccount();
                Console.WriteLine("Authentication successful.");
            }
            else
            {
                Console.WriteLine("Authentication failed. Access denied.");
            }
        }

        public void Deposit(double amount)
        {
            if (realBankAccount != null)
            {
                realBankAccount.Deposit(amount);
            }
        }

        public void Withdraw(double amount)
        {
            if (realBankAccount != null)
            {
                realBankAccount.Withdraw(amount);
            }
        }

        public double GetBalance()
        {
            return (realBankAccount != null) ? realBankAccount.GetBalance() : 0.0;
        }

    }
}
