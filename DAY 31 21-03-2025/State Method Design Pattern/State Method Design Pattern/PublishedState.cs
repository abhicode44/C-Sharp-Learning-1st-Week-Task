using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Method_Design_Pattern
{
    internal class PublishedState : IState
    {
        public void Handle()
        {
            Console.WriteLine("Document is in Published state. Editing is not allowed. It is publicly available.");
        }
    }
}
