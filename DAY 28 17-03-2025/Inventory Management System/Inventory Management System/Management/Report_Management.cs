using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Inventory_Management_System.Management
{
    internal class Report_Management
    {   
        public Report_Management() { }

        public void Show_Generate_Report_Menu(SqlConnection connection)


        {
            try
            {
                bool continueMenu = true;

                while (continueMenu)
                {
                    Console.WriteLine("\nWelcome to Transaction Manager ");
                    Console.WriteLine();
                    Console.WriteLine("1. View Generate Report");
                    Console.WriteLine("2. Go To The Main Menu");

                    Console.Write("\nWhich Action Do you Want To Perform From Generate  Manangement Menu :- ");
                    int userInput = Convert.ToInt32(Console.ReadLine());

                    switch (userInput)
                    {
                        case 1:
                                GenerateReport(connection);
                            break;

                        case 2:
                            continueMenu = false;
                            Console.WriteLine("Exiting the application.");
                            break;

                        default:
                            Console.WriteLine("Invalid option, please choose again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void GenerateReport(SqlConnection connection)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n------------------ Inventory Management System Report ------------------\n");
                

                
                Console.WriteLine("+----------------------+----------------------+");
                Console.WriteLine("|        Metric        |        Value         |");
                Console.WriteLine("+----------------------+----------------------+");
               

                string totalProductsQuery = "SELECT COUNT(*) FROM Product";
                using (SqlCommand command = new SqlCommand(totalProductsQuery, connection))
                {
                    int totalProducts = (int)command.ExecuteScalar();
                    
                    Console.WriteLine($"| Total Products       | {totalProducts,-20} |");
                    
                }

                string totalSuppliersQuery = "SELECT COUNT(*) FROM Supplier";
                using (SqlCommand command = new SqlCommand(totalSuppliersQuery, connection))
                {
                    int totalSuppliers = (int)command.ExecuteScalar();
                    
                    Console.WriteLine($"| Total Suppliers      | {totalSuppliers,-20} |");
                    
                }

                string totalTransactionsQuery = "SELECT COUNT(*) FROM [Transaction]";
                using (SqlCommand command = new SqlCommand(totalTransactionsQuery, connection))
                {
                    int totalTransactions = (int)command.ExecuteScalar();
                   
                    Console.WriteLine($"| Total Transactions   | {totalTransactions,-20} |");
                    
                }

                string totalStockValueQuery = "SELECT SUM(Quantity * Price) FROM Product";
                using (SqlCommand command = new SqlCommand(totalStockValueQuery, connection))
                {
                    var totalStockValue = command.ExecuteScalar();
                    
                    Console.WriteLine($"| Total Stock Value    | {totalStockValue,-20 }  |");
                    
                }

                
                Console.WriteLine("+----------------------+----------------------+\n");
                Console.ResetColor();
            }
            catch (System.Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
