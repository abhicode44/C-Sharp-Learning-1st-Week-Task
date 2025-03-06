using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Exceptions
{
    internal class ListEmptyException : Exception
    {
        public ListEmptyException(string message) : base(message) { }
    }

}
