using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary.Exceptions
{
    internal class InvalidLastName : Exception
    {
        public InvalidLastName(string message) : base(message) { }
    }
}
