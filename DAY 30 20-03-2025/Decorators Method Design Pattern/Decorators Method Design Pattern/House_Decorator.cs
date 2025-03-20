using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators_Method_Design_Pattern
{
    internal class House_Decorator : IContractor
    {
        public IContractor House { get; set; } // property

        public House_Decorator(IContractor house)
        {
            House = house;
        }

        public virtual  void BuildHouse()
        {
            House.BuildHouse();

        }
    }
}
