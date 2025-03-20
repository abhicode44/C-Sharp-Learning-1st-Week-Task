using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Method_Design_Pattern
{
    internal class UkCarFactory
    {
        public static Car BuildCar(CarType model)
        {
            switch (model)
            {
                case CarType.MICRO:
                    return new MicroCar(Location.UK);

                case CarType.MINI:
                    return new MiniCar(Location.UK);

                case CarType.LUXURY:
                    return new LuxuryCar(Location.UK);

                default:
                    return null;
            }
        }
    }
}
