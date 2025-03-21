using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Method_Design_Pattern
{
    internal class PaymentContext
    {
        private IPaymentStrategy strategy;

        public PaymentContext(IPaymentStrategy paymentStrategy)
        {
            strategy = paymentStrategy; 
        }

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            strategy = paymentStrategy;
        }

        public void ProcessPayment(float amount)
        {
            strategy.ProcessPayment(amount);
        }
    }
}
