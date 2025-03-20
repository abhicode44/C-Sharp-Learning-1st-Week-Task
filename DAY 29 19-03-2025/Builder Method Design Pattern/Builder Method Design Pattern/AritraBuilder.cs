using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Method_Design_Pattern
{
    internal class AritraBuilder : IHouseBuilder
    {
        private House house { get; set; }

        public AritraBuilder()
        {
            house = new House();
        }

        public void BuildBasement()
        {
            house.SetBasement("Aritra Basement");
        }

        public void BuildStructure()
        {
            house.SetStructure("Aritra Structure");
        }

        public void BuildRoof()
        {
            house.SetRoof("Aritra Roof");
        }

        public void BuildInterior()
        {
            house.SetInterior("Aritra Interior");
        }

        public House GetHouse()
        {
            return house;
        }

    }
}
