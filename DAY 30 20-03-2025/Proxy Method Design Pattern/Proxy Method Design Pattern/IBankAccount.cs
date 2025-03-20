using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Method_Design_Pattern
{
    internal interface IBankAccount
    {
        public void Deposit(double amount);
        public void Withdraw(double amount);
        public double GetBalance(); 

    }
}
