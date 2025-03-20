using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Method
{
    internal class Client
    {
        private Vehicle _pVehicle;

        public Client ()
        {
            _pVehicle = null;
        }

        public void BuildVehicle(VehicleType vehicleType)
        {
            IVehicleFactory vf =  new VehicleFactory();
            _pVehicle = vf.Build(vehicleType);

        }

        public Vehicle GetVehicle()     
        {   
            return _pVehicle;
        }

    }
}
