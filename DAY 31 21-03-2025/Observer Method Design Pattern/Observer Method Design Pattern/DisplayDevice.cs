using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Method_Design_Pattern
{
    internal class DisplayDevice : IObserver
    {
        public string mobile;

        public DisplayDevice (string mobilename)
        {
            mobile = mobilename;
        }

        public void Update(string update)
        {
            Console.WriteLine($" {mobile} Current update :- {update}");
        }
    }

}
