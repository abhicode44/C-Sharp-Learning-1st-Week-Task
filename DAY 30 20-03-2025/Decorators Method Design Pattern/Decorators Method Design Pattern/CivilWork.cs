using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators_Method_Design_Pattern
{
    internal class CiviWork : IContractor
    {
        public void BuildHouse()
        {
            Console.WriteLine(" House Build ");
        }
    }
}
