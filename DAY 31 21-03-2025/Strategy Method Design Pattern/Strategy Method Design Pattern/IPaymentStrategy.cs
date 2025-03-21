using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Method_Design_Pattern
{
    internal interface IPaymentStrategy
    {
        public void ProcessPayment(float amount);

    }
}
