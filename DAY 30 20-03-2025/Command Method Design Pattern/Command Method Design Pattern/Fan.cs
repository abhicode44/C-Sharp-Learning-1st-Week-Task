using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Method_Design_Pattern
{
    internal class Fan
    {
        public void ON()
        {
            Console.WriteLine(" Fan is on");
        }

        public void OFF()
        {
            Console.WriteLine(" Fan is off");
        }
    }
}
