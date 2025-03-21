using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Method_Design_Pattern
{
    internal class ReviewState : IState
    {
        public void Handle()
        {
            Console.WriteLine("Document is in Review state. Editing is restricted. Reviewers can provide feedback.");
        }
    }
}
