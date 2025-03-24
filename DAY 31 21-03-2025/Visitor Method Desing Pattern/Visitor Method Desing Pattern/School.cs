using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Method_Desing_Pattern
{
    internal class School
    {
        private static readonly List<IElement> elements = new List<IElement>(); 

        static School()
        {
            elements = new List<IElement>
            {
                new Kid("Ram"),
                new Kid("Abhishek"),
                new Kid("Shubham")

            };
        }

        public void PerformOperation(IVisitor visitor)
        {
            foreach (var kid in elements) 
            {
                kid.Accept(visitor);
            }

        }
    }
}
