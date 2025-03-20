using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Method_Design_Pattern
{
    internal class INDIACarFactory 
    {
        public static Car BuildCar(CarType model)
        {
            switch (model)
            {
                case CarType.MICRO:
                    return new MicroCar(Location.INDIA);

                case CarType.MINI:
                    return new MiniCar(Location.INDIA);

                case CarType.LUXURY:
                    return new LuxuryCar(Location.INDIA);

                default:
                    return null;
            }
        }
    }
}
