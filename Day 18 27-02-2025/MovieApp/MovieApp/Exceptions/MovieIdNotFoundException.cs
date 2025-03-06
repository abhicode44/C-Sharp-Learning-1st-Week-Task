using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Exceptions
{
    internal class MovieIdNotFoundException : Exception 
    {
        public MovieIdNotFoundException(string message) : base(message) { }

    }
}
