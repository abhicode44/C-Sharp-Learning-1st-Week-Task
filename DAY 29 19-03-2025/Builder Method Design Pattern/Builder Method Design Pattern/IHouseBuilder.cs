using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Method_Design_Pattern
{
    internal interface IHouseBuilder
    {
        public void BuildBasement();
        public void BuildStructure();
        public void BuildRoof();
        public void BuildInterior();

        public House GetHouse();

    }
}
