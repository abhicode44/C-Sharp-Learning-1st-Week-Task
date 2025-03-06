using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary.Exceptions
{
    public class InvalidPanCardNumber : Exception
    {
        public InvalidPanCardNumber(string message) : base(message) { }
    }
}
