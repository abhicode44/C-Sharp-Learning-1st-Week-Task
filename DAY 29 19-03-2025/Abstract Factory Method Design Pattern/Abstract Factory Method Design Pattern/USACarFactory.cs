using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Method_Design_Pattern
{
    internal class USACarFactory
    {
        public static Car BuildCar(CarType model)
        {
            switch (model)
            {
                case CarType.MICRO:
                    return new MicroCar(Location.USA);

                case CarType.MINI:
                    return new MiniCar(Location.USA);

                case CarType.LUXURY:
                    return new LuxuryCar(Location.USA);

                default:
                    return null;
            }

        }
    }
}

