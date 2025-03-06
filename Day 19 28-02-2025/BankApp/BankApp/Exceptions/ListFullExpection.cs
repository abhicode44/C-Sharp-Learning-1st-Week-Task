using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Exceptions
{
    internal class ListFullExpection : Exception
    {
        public ListFullExpection(string message) : base(message) { }
    }
}
