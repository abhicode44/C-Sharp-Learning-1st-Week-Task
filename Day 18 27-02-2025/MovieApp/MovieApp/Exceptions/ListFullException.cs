using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Exceptions
{
    internal class ListFullException : Exception
    {
        public ListFullException()
        {

        }

        public ListFullException(string message) : base(message) { }

    }
}
