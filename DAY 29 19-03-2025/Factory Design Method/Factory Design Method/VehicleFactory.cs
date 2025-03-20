using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Method
{
    internal class VehicleFactory : IVehicleFactory
    {
        public Vehicle Build (VehicleType vehicleType) 
        {

            switch (vehicleType) 
            {
                case VehicleType.Bike:
                    return new Bike();
                case VehicleType.Rickshaw:
                    return new RickShaw();
                case VehicleType.Car:
                    return new Car();
                default :
                    return null;
            }
        }
    }
}
