using BankApp.Services;

internal class Program
{
    private static void Main(string[] args)
    {
       AccountStore accountStore = new AccountStore();
        accountStore.showMenu();
    }
}