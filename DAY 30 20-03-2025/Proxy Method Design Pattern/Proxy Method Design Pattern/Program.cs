using Proxy_Method_Design_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        IBankAccount account = new SecureBankAccountProxy("secret");


        account.Deposit(1000);
        account.Deposit(5000);
        account.Withdraw(500);
        double balance = account.GetBalance();

        Console.WriteLine($"Current Balance: {balance}");
    }
}