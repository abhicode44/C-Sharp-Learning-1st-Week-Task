using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Method_Design_Pattern
{
    internal class Adapter : ILegacyServices
    {
        public  NewServices  NewService {get ;}

        public Adapter(NewServices newServices) 
        { 
            NewService = newServices;
        }

        public void LegacyRequest()
        {
            NewService.NewRequest();
        }
    }
}
