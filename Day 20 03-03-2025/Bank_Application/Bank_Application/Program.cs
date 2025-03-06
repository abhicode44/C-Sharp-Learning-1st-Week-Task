using Bank_Application.Services;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {

        AccountStore accountStore = new AccountStore();
        accountStore.showMenu();
    }
}