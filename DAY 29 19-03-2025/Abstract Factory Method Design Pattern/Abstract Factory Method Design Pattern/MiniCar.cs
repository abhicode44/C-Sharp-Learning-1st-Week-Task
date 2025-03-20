using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Method_Design_Pattern
{
    internal class MiniCar : Car
    {
        public MiniCar(Location location) : base(CarType.MINI, location)
        {
            Construct();
        }

        public override void Construct()
        {
            Console.WriteLine("Connecting to mini car");
        }
    }
}
