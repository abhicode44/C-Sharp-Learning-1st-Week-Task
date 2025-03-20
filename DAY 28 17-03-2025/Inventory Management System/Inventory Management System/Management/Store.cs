using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.Exceptions;
using Inventory_Management_System.Models;
using Inventory_Management_System.Repository;
using Inventory_Management_System.Services;
using Microsoft.Data.SqlClient;

namespace Inventory_Management_System.Management
{
    internal class Store
    {
        IService productStore = new ProductOperation();
        IService supplierStore = new SupplierOperation();
        ITransactionServices transactionStore = new TransactionOperation();
        IService inventoryStore = new InventoryOperation();
        Report_Management report_Management = new Report_Management();

        public void MainMenu()
        {
            string connectionString = ConfigurationManager.AppSettings["connectionStringName"];

            {
                using (SqlConnection connection = new SqlConnection(connectionString))

                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection opened successfully.");


                        //1. Product Management
                        // 2.Supplier Management
                        //3.Transaction Management
                        //4.Generate Report
                        //5.Exit

                        bool continueMenu = true;

                        while (continueMenu)
                        {
                            Console.WriteLine("\nWelcome to the Inventory Management System");
                            Console.WriteLine();
                            Console.WriteLine("1. Inventory Management");
                            Console.WriteLine("2. Product Management");
                            Console.WriteLine("3. Supplier Management");
                            Console.WriteLine("4. Transaction Management");
                            Console.WriteLine("5. Generate Report");
                            Console.WriteLine("6. Exit");

                            Console.Write("\nEnter The Choice From Inventory Management Menu :- ");
                            int userInput = Convert.ToInt32(Console.ReadLine());

                            switch (userInput)
                            {
                                case 1:
                                    inventoryStore.ChooseMenu(connection);
                                    break;
                                case 2:
                                    productStore.ChooseMenu(connection);
                                    break;

                                case 3:
                                    supplierStore.ChooseMenu(connection);
                                    break;


                                case 4:
                                    transactionStore.ChooseMenu(connection);
                                    break;

                                case 5:
                                    report_Management.Show_Generate_Report_Menu(connection);
                                    break;

                                case 6:
                                    continueMenu = false;
                                    Console.WriteLine("Exiting the application.");
                                    break;
                                default:
                                    throw new InvalidChoiceException("Invalid option, please choose again.");
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }



        }

    }
}