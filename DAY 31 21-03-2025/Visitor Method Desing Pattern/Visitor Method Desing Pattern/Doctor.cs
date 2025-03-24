using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Method_Desing_Pattern
{
    internal class Doctor : IVisitor
    {
        public string Name { get; set; }

        public Doctor (string name)
        {
            Name = name;
        }

        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Console.WriteLine($"Doctor : {Name}  Did Health Checkup Of The Child : {kid.KidName}");
        }
    }
}
