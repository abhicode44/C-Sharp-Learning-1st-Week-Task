using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AccountLibrary.Services;
using AccountLibrary.Exceptions;
using AccountLibrary.Model;

namespace Bank_Application.Services
{
    internal class AccountStore
    {   
        AccountManager accountManager;

        public AccountStore() { 
           accountManager = new AccountManager();
        }


        public void showMenu()
        {
            string choice = "";
            do
            {
                try
                {
                    Console.WriteLine("\nWelcome to Movie Store developed by: Abhishek");
                    Console.WriteLine("1. Add New Account");
                    Console.WriteLine("2. Display All Account");
                    Console.WriteLine("3. Find Account by Account Number");
                    Console.WriteLine("4. Remove Account by Account Number");
                    Console.WriteLine("5. Delete All Account");
                    Console.WriteLine("6. Exit");
                    Console.Write("Enter your choice: ");
                    choice = (Console.ReadLine());

                    // Add New Account
                    if (choice == "1")
                    {
                        accountManager.AddAccount();
                    }

                    // Display All Account
                    else if (choice == "2")
                    {
                        accountManager.DisplayAccount();
                    }


                    // Find Account by Account Number
                    else if (choice == "3")
                    {
                        accountManager.FindAccountByNumber();
                    }


                    // Remove Account by Account Number
                    else if (choice == "4")
                    {
                        accountManager.RemoveAccountByNumber();
                    }

                    // Delete All Account
                    else if (choice == "5")
                    {
                        accountManager.DeleteAllAccount();
                    }

                    // Exit 
                    else if (choice == "6")
                    {
                        break;
                    }

                    else if (choice == " ")
                    {
                        throw new InvalidChoiceException("Enter Valid Input Between 1 To 6");
                    }
                }
                catch(Exception e) 
                { 
                    Console.WriteLine(e.ToString());
                }
            }
            while (choice != "6" );
        }
    }
}
