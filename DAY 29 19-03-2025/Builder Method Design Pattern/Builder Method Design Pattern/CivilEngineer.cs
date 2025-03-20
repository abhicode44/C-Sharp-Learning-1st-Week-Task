using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Method_Design_Pattern
{
    internal class CivilEngineer
    {   
        private IHouseBuilder houseBuilderName { get; set; }
        public CivilEngineer(IHouseBuilder houseBuilder ) 
        {   
            houseBuilderName = houseBuilder;
        }  

        public House GetHouse()
        {
            return houseBuilderName.GetHouse();
        }

        public void ConstructHouse ()
        {
            houseBuilderName.BuildBasement();
            houseBuilderName.BuildStructure();
            houseBuilderName.BuildRoof();
            houseBuilderName.BuildInterior();

        }
    }
}
