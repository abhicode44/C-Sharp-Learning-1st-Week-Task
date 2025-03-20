using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Method
{
    internal class Car : Vehicle
    {
        public override void PrintVehicleInfo()
        {
            Console.WriteLine("I am Four wheeler Car");
        }
    }
}
