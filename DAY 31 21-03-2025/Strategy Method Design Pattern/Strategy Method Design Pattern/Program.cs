
using Strategy_Method_Design_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        PaymentContext paymentContext = new PaymentContext(new PaypalPayment());

        paymentContext.ProcessPayment(100);

        paymentContext.SetPaymentStrategy(new BitcoinPaymnet());
        paymentContext.ProcessPayment(100);

        paymentContext.SetPaymentStrategy(new CreditcardPayment());
        paymentContext.ProcessPayment(100);

    }
}