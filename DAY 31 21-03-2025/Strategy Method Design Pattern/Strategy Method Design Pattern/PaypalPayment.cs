using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Method_Design_Pattern
{
    internal class PaypalPayment : IPaymentStrategy
    {
        public void ProcessPayment(float amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount} dollars.");
        }
    }
}
