using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Exceptions
{
    internal class InvalidLastName : Exception
    {
        public InvalidLastName(string message) : base(message) { }
    }
}
