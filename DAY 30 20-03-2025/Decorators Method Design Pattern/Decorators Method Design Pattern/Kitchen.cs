using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators_Method_Design_Pattern
{
    internal class Kitchen : House_Decorator
    {
        public Kitchen(IContractor house) : base(house)
        {
        }

        public override void BuildHouse()
        {
            base.BuildHouse();
            Console.WriteLine("Kitchen Added to House ");
        }
    }
}
