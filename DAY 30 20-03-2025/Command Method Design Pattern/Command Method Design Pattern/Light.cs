using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Method_Design_Pattern
{
    internal class Light
    {
        public void ON()
        {
            Console.WriteLine(" Light is on");
        }

        public void OFF()
        {
            Console.WriteLine(" Light is off");
        }

    }
}
