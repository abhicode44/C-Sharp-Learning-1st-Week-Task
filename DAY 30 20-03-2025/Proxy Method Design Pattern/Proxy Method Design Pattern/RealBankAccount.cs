using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Method_Design_Pattern
{
    internal class RealBankAccount : IBankAccount
    {
        private double balance = 100; 

        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}");
        }

        public double GetBalance()
        {
            return balance;
        }

        public void Withdraw(double amount)
        {
            if (balance >= amount )
            {
                balance -= amount;
                Console.WriteLine($"Withdraw: {amount}");
            }
            else
            {
                Console.WriteLine("Insuficient Balance");
            }
            
        }
    }
}
