using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Method
{
    internal class Bike : Vehicle
    {
        public override void PrintVehicleInfo()
        {
            Console.WriteLine("I am two wheeler Bike ");
        }
    }
}
