using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Method_Desing_Pattern
{
    internal interface IElement
    {
        public void Accept(IVisitor visitor);

    }
}
