using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.Exceptions;
using Inventory_Management_System.Models;
using Inventory_Management_System.Repository;
using Microsoft.Data.SqlClient;

namespace Inventory_Management_System.Services
{
    internal class TransactionOperation : ITransactionServices
    {
        public void ChooseMenu(SqlConnection connection)
        {
            try
            {
                bool continueMenu = true;

                while (continueMenu)
                {
                    Console.WriteLine("\nWelcome to Transaction Manager ");
                    Console.WriteLine();
                    Console.WriteLine("1. Add Stock");
                    Console.WriteLine("2. Remove Stock ");
                    Console.WriteLine("3. View Stock");
                    Console.WriteLine("4. Go To The Main Menu");

                    Console.Write("\nWhich Action Do you Want To Perform From Transaction Manangement Menu :- ");
                    int userInput = Convert.ToInt32(Console.ReadLine());

                    switch (userInput)
                    {
                        case 1:
                            Add_Stock(connection);
                            break;

                        case 2:
                            Remove_Stock(connection);
                            break;

                        case 3:
                            View_All_Details(connection);
                            break;

                        case 4:
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
                Console.WriteLine(ex.Message);
            }
        }

        public void Add_Stock(SqlConnection connection)
        {
            try
            {
                DisplayAllProducts(connection);


                Console.Write("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());
                Console.Write("Enter Quantity to Add: ");
                int quantity = int.Parse(Console.ReadLine());


                CheckProductID_FindQuantityCountQuery(connection, ref productId);

                UpdateAddQuantityCountQuery(connection, ref quantity, ref productId);

                Insert_AddUpdatedQuantityCountQuery(connection, ref quantity, ref productId);

                Console.WriteLine("\nUpdated Product List:");
                DisplayAllProducts(connection);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void Remove_Stock(SqlConnection connection)
        {
            try
            {
                DisplayAllProducts(connection);

                Console.Write("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());
                Console.Write("Enter Quantity to Remove: ");
                int quantity = int.Parse(Console.ReadLine());

                CheckProductId_FindQuantityCount_DeleteQuery(connection, ref productId, ref quantity);

                UpdateDeleteQuantityCountQuery(connection, ref quantity, ref productId);

                Insert_DeleteUpdatedQuantityCountQuery(connection, ref quantity, ref productId);

                Console.WriteLine("\nUpdated Product List:");
                DisplayAllProducts(connection);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        public void View_All_Details(SqlConnection connection)
        {
            try
            {
                string query = "SELECT * FROM [Transaction]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to Yellow for all output

                        Console.WriteLine("\n--------------------- Transaction History ---------------------\n");
                        Console.WriteLine("+----------------+------------+--------------+----------+------------+");
                        Console.WriteLine("| Transaction ID | Product ID | Type         | Quantity | Date       |");
                        Console.WriteLine("+----------------+------------+--------------+----------+------------+");

                        while (reader.Read())
                        {
                            string typeValue = reader["Type"].ToString();
                            TransactionEnum transactionType = (TransactionEnum)Enum.Parse(typeof(TransactionEnum), typeValue);

                            // Use ToShortDateString to display only the date part
                            string date = Convert.ToDateTime(reader["TransactionDate"]).ToShortDateString();

                            Console.WriteLine($"| {reader["TransactionId"],-14} | {reader["ProductId"],-10} | {transactionType,-12} | {reader["Quantity"],-8} | {date,-10} |");
                        }

                        Console.WriteLine("+----------------+------------+--------------+----------+------------+");

                        Console.ResetColor(); // Reset to default console color
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        public void CheckProductID_FindQuantityCountQuery(SqlConnection connection, ref int productId)
        {
            string checkQuery = "SELECT Quantity FROM Product WHERE ProductID = @ProductID ";
            int currentQuantity;
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@ProductID", productId);
                var result = checkCommand.ExecuteScalar();
                if (result == null)
                {
                    throw new ProductIdNotFoundException("Product not found.");
                    return;
                }
                currentQuantity = (int)result;
            }

        }

        public void UpdateAddQuantityCountQuery(SqlConnection connection, ref int quantity, ref int productId)
        {
            string updateQuery = "UPDATE Product SET Quantity = Quantity + @Quantity WHERE ProductID = @ProductID";
            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@Quantity", quantity);
                updateCommand.Parameters.AddWithValue("@ProductID", productId);

                updateCommand.ExecuteNonQuery();

            }
        }

        public void Insert_AddUpdatedQuantityCountQuery(SqlConnection connection, ref int productId, ref int quantity)
        {
            string insertQuery = "INSERT INTO [Transaction] (ProductID, Type, Quantity) VALUES (@ProductID, @Type, @Quantity)";
            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@ProductID", productId);
                insertCommand.Parameters.AddWithValue("@Type", TransactionEnum.AddStock.ToString());
                insertCommand.Parameters.AddWithValue("@Quantity", quantity);


                int rowsAffected = insertCommand.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void CheckProductId_FindQuantityCount_DeleteQuery(SqlConnection connection, ref int productId, ref int quantity)
        {
            string checkQuery = "SELECT Quantity FROM Product WHERE ProductID = @ProductID";
            int currentQuantity;
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@ProductID", productId);
                var result = checkCommand.ExecuteScalar();
                if (result == null)
                {
                    throw new ProductIdNotFoundException("Product not found.");
                    return;
                }
                currentQuantity = (int)result;

                if (currentQuantity < quantity)
                {
                    throw new InsufficientExecutionStackException("Insufficient stock available.");
                    return;
                }
            }
        }

        public void UpdateDeleteQuantityCountQuery(SqlConnection connection, ref int quantity, ref int productId)
        {
            string updateQuery = "UPDATE Product SET Quantity = Quantity - @Quantity WHERE ProductID = @ProductID";
            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@Quantity", quantity);
                updateCommand.Parameters.AddWithValue("@ProductID", productId);
                updateCommand.ExecuteNonQuery();
            }
        }

        public void Insert_DeleteUpdatedQuantityCountQuery(SqlConnection connection, ref int productId, ref int quantity)
        {
            string insertQuery = "INSERT INTO [Transaction] (ProductID, Type, Quantity) VALUES (@ProductID, @Type, @Quantity)";
            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@ProductID", productId);
                insertCommand.Parameters.AddWithValue("@Type", TransactionEnum.RemoveStock.ToString());
                insertCommand.Parameters.AddWithValue("@Quantity", quantity);

                int rowsAffected = insertCommand.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void DisplayAllProducts(SqlConnection connection)
        {
            string query = "SELECT * FROM Product";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("\n------------------- All Products -------------------\n");
                    Console.WriteLine("+------------+----------------------+----------------------+----------+---------+-------------+");
                    Console.WriteLine("| ProductID  | Name                 | Description          | Quantity | Price   | InventoryID |");
                    Console.WriteLine("+------------+----------------------+----------------------+----------+---------+-------------+");

                    while (reader.Read())
                    {
                        Console.WriteLine($"| {reader["ProductID"],-10} | {reader["Name"],-20} | {reader["Description"],-20} | {reader["Quantity"],-8} | {reader["Price"],-7} | {reader["InventoryId"],-11} |");
                    }

                    Console.WriteLine("+------------+----------------------+----------------------+----------+---------+-------------+");

                    Console.ResetColor();
                }
            }
        }
    }
}
