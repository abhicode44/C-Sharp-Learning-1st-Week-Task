using System;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AccountLibrary.Exceptions;
using AccountLibrary.Model;

namespace AccountLibrary.Services
{
    public class AccountManager
    {
        List<DetailsOfAccounts> accountList = new List<DetailsOfAccounts>();

        DataSerialization dataSerialization ;

        public AccountManager() 
        {
            dataSerialization = new DataSerialization();
            accountList = dataSerialization.DeSerializer();
        }

        public void AddAccount ()
        {
            if (accountList.Count >= 5) {
                throw new ListFullExpection("The Account List is Full you can not add new movie...");
            }


            string firstname;
            while (true)
            {
                try
                {
                    Console.Write("Enter The First Name : ");
                    firstname = Console.ReadLine().ToUpper();



                    string[] number = { "A" , "B" , "C" , "D" , "E" , "F" ,  "G" , "H" , "I" ,
                                          "J" , "K" , "L" , "M" , "N" , "O" , "P" , "Q" , "R" ,
                                          "S" , "T" , "U" , "V" , "W" , "X" , "Y" , "Z"
                                       };

                    bool isInvalid = false;

                    foreach (char c in firstname)
                    {
                        bool found = false;
                        foreach (string num in number)
                        {
                            if (num == c.ToString())
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            isInvalid = true;
                            break;
                        }
                    }

                    if (isInvalid)
                    {
                        throw new InvalidFirstName("Invalid Input! firstname must be contains only characters");
                    }

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            string middlename;

            while (true)
            {
                try
                {
                    Console.Write("Enter The Middle Name : ");
                    middlename = Console.ReadLine().ToUpper();



                    string[] number = { "A" , "B" , "C" , "D" , "E" , "F" ,  "G" , "H" , "I" ,
                                          "J" , "K" , "L" , "M" , "N" , "O" , "P" , "Q" , "R" ,
                                          "S" , "T" , "U" , "V" , "W" , "X" , "Y" , "Z"
                                       };

                    bool isInvalid = false;

                    foreach (char c in middlename)
                    {
                        bool found = false;
                        foreach (string num in number)
                        {
                            if (num == c.ToString())
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            isInvalid = true;
                            break;
                        }
                    }

                    if (isInvalid)
                    {
                        throw new InvalidMiddleName("Invalid Input! middlename must be contains only characters.");
                    }

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }


            string lastname;
            while (true)
            {
                try
                {
                    Console.Write("Enter The Last Name : ");
                    lastname = Console.ReadLine().ToUpper();



                    string[] number = {  "A" , "B" , "C" , "D" , "E" , "F" ,  "G" , "H" , "I" ,
                                          "J" , "K" , "L" , "M" , "N" , "O" , "P" , "Q" , "R" ,
                                          "S" , "T" , "U" , "V" , "W" , "X" , "Y" , "Z"
                                       };

                    bool isInvalid = false;

                    foreach (char c in lastname)
                    {
                        bool found = false;
                        foreach (string num in number)
                        {
                            if (num == c.ToString())
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            isInvalid = true;
                            break;
                        }
                    }

                    if (isInvalid)
                    {
                        throw new InvalidLastName("Invalid Input! lastname must be contains only characters.");
                    }

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }


            string aadharnumber;
            while (true)
            {
                try
                {
                    Console.Write("Enter The Aadhar Card Number: ");
                    aadharnumber = Console.ReadLine();

                    if (aadharnumber.Length != 12)
                    {
                        throw  new InvalidAadharCardNumber("Please Enter a 12-Digit Aadhar Card Number.");
                    }

                    string[] number = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                    bool isInvalid = false;

                    foreach (char c in aadharnumber)
                    {
                        bool found = false;
                        foreach (string num in number)
                        {
                            if (num == c.ToString())
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            isInvalid = true;
                            break;
                        }
                    }

                    if (isInvalid)
                    {
                        throw new InvalidAadharCardNumber ("Invalid Input Aadhar Card Number must be contain Numberic value only.");
                    }

                    break; 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }



            string pannumber;
            while (true)
            {
                try
                {
                    Console.Write("Enter The Pan Card Number: ");
                    pannumber = Console.ReadLine();

                    if (pannumber.Length != 10)
                    {
                        throw new InvalidPanCardNumber("Please Enter a 10-Digit Pan Card Number.");
                    }

                    string[] number = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" ,
                                         "A" , "B" , "C" , "D" , "E" , "F" ,  "G" , "H" , "I" ,
                                          "J" , "K" , "L" , "M" , "N" , "O" , "P" , "Q" , "R" ,
                                          "S" , "T" , "U" , "V" , "W" , "X" , "Y" , "Z"
                                       };

                    bool isInvalid = false;

                    foreach (char c in pannumber)
                    {
                        bool found = false;
                        foreach (string num in number)
                        {
                            if (num == c.ToString())
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            isInvalid = true;
                            break;
                        }
                    }

                    if (isInvalid)
                    {
                        throw new InvalidPanCardNumber("Invalid Input! Please enter a Valid Pan Card Number.");
                    }

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }



            Random rand = new Random();
            string accountnumber = Convert.ToString(rand.Next(100000, 999999)) + Convert.ToString(rand.Next(100000, 999999));




            Console.WriteLine("Select The Type Of Account:- ");
            int i = 1;
            foreach (var typeofaccount in Enum.GetValues(typeof(AccountMode)).Cast<AccountMode>()) { 
               Console.WriteLine($"{i} {typeofaccount}");
                i++;
            }

            Console.Write("Enter The Account Type: ");
            int accounttypenumber = Convert.ToInt32(Console.ReadLine());

            var accounttype = (AccountMode)accounttypenumber;

            Console.WriteLine($"Account Number :- {accountnumber}");

            DetailsOfAccounts newaccountlist = new DetailsOfAccounts(firstname , middlename , lastname , aadharnumber , pannumber , accountnumber , accounttype);
            accountList.Add(newaccountlist);
            dataSerialization.Serialize(accountList);
            Console.WriteLine("Account added successfully!");


        }

        public void DisplayAccount() 
        {

            try
            {
                if (accountList.Count == 0)
                {
                    throw new ListEmptyException(" No Accounts available, list is empty.");
                }
                else
                {
                    foreach (DetailsOfAccounts account in accountList)
                    {
                        Console.WriteLine($"First Name: {account.FirstName}");
                        Console.WriteLine($"Middle Name: {account.MiddleName}");
                        Console.WriteLine($"Last Name: {account.LastName}");
                        Console.WriteLine($"Aadhar Card Number: {account.AadharNumber}");
                        Console.WriteLine($"Pan Card Number : {account.PanNumber}");
                        Console.WriteLine($"Account Type : {account.AccountType}");
                        Console.WriteLine($"Account Number: {account.AccountNumber}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void FindAccountByNumber()
        {
            try
            {
                Console.Write("Enter Account Number To Find Account : ");
                string search_account_number = (Console.ReadLine());

                bool account_found = false;

                foreach (DetailsOfAccounts account in accountList)
                {
                    if (account != null && account.AccountNumber == search_account_number)
                    {
                        Console.WriteLine($"First Name: {account.FirstName}");
                        Console.WriteLine($"Middle Name: {account.MiddleName}");
                        Console.WriteLine($"Last Name: {account.LastName}");
                        Console.WriteLine($"Aadhar Card Number: {account.AadharNumber}");
                        Console.WriteLine($"Pan Card Number : {account.PanNumber}");
                        Console.WriteLine($"Account Type : {account.AccountType}");
                        Console.WriteLine($"Account Number: {account.AccountNumber}");
                        Console.WriteLine();
                        account_found = true;
                        break;
                    }
                }

                if (!account_found)
                {
                    throw new AccountNotFoundException("Account Number Not Found");
                }
            }
            catch (Exception e) { 
              Console.WriteLine(e.ToString());  
            }
        }

        public void RemoveAccountByNumber() 
        {
            try
            {
                Console.Write("Enter Account Number To Remove Account : ");
                string remove_account_number = Console.ReadLine();

                bool account_Found = false;


                foreach (DetailsOfAccounts account in accountList)
                {
                    if (account.AccountNumber == remove_account_number)
                    {
                        accountList.Remove(account);
                        Console.WriteLine("Account removed successfully.");
                        dataSerialization.Serialize(accountList); 
                        account_Found = true;
                        break;
                    }
                }

                if (!account_Found)
                {
                    throw new AccountNotFoundException("Account Number Not Found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void DeleteAllAccount()
        {
            try
            {
                if (accountList.Count == 0)
                {
                    throw new ListEmptyException("No Account Found List is Empty.");
                }
                else
                {
                    accountList.Clear();
                    dataSerialization.Serialize(accountList);
                    Console.WriteLine("All account removed successfully.");


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }



    }
}
