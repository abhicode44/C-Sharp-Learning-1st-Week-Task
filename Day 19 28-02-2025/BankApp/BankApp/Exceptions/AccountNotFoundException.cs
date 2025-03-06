using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Exceptions
{
    internal class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) : base(message) { }
    }
}
