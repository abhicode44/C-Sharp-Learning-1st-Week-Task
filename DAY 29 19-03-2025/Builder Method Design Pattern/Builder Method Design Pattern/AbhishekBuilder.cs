using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Method_Design_Pattern
{
    internal class AbhishekBuilder : IHouseBuilder
    {
        private House house { get; set; }

        public AbhishekBuilder()
        {
            house = new House();
        }

        public void BuildBasement()
        {
            house.SetBasement("Abhishek Basement");
        }

        public void BuildStructure()
        {
            house.SetStructure("Abhishek Structure");
        }

        public void BuildRoof()     
        {
            house.SetRoof("Abhishek Roof");
        }

        public void BuildInterior()
        {
            house.SetInterior("Abhishek Interior");
        }

        public House GetHouse() 
        {
            return house;
        }

    }
}
