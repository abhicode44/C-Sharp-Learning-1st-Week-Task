using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.Exceptions;
using Inventory_Management_System.Repository;
using Microsoft.Data.SqlClient;

namespace Inventory_Management_System.Services
{
    internal class ProductOperation : IService
    {
        public void ChooseMenu(SqlConnection connection)
        {

            {
                try
                {
                    bool continueMenu = true;

                    while (continueMenu)
                    {
                        Console.WriteLine("\nWelcome to Product Manager ");
                        Console.WriteLine();
                        Console.WriteLine("1. Add a New Product");
                        Console.WriteLine("2. Update Prodcut");
                        Console.WriteLine("3. Delete Product");
                        Console.WriteLine("4. View Product Details");
                        Console.WriteLine("5. View All Products");
                        Console.WriteLine("6. Go To The Main Menu");

                        Console.Write("\nWhich Action Do you Want To Perform From Product Manangement Menu :- ");
                        int userInput = Convert.ToInt32(Console.ReadLine());

                        switch (userInput)
                        {
                            case 1:
                                Add(connection);
                                break;

                            case 2:
                                Update(connection);
                                break;

                            case 3:
                                Delete(connection);
                                break;

                            case 4:
                                View_Specific_Details(connection);
                                break;

                            case 5:
                                View_All_Details(connection);
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
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public void Add(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Product Description: ");
                string description = Console.ReadLine();
                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.Write("Enter Price: ");
                int price = int.Parse(Console.ReadLine());



                DisplayInventory(connection);


                Console.Write("Enter Inventory ID: ");
                int inventoryId = int.Parse(Console.ReadLine());

                CheckProductName(connection, ref name, ref inventoryId);


                InsertQueryAddProduct(connection, ref name, ref description, ref quantity, ref price, ref inventoryId);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void Update(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Product ID to Update: ");
                int productId = int.Parse(Console.ReadLine());


                if (!CheckProducIdExists(connection, ref productId))
                {
                    throw new ProductIdNotFoundException($"Product with ID {productId} does not exist.");
                    return; 
                }


                Console.Write("Enter New Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter New Description: ");
                string description = Console.ReadLine();
                Console.Write("Enter New Price: ");
                int price = int.Parse(Console.ReadLine());


                UpdateProductQuery(connection, ref name, ref description, ref price, ref productId);

                Console.WriteLine("\n Updated Prduct Table ");
                View_All_Details(connection);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Delete(SqlConnection connection)
        {
            try
            {

                Console.Write("Enter Product ID to Delete: ");
                int productId = int.Parse(Console.ReadLine());

                if (!CheckProducIdExists(connection, ref productId))
                {
                    throw new ProductIdNotFoundException($"Product with ID {productId} does not exist.");
                    return;
                }

                DeleteProductQuery(connection, ref productId);

                Console.WriteLine("\n Updated Product List");
                View_All_Details(connection);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void View_Specific_Details(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Product ID to View: ");
                int productId = int.Parse(Console.ReadLine());

                if (!CheckProducIdExists(connection, ref productId))
                {
                    throw new ProductIdNotFoundException($"Product with ID {productId} does not exist.");
                    return;
                }

                ViewSpecificProductQuery(connection, ref productId);

                


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void View_All_Details(SqlConnection connection)
        {
            try
            {
                string query = "SELECT * FROM Product";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Set text color to Green

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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving all products: {ex.Message}");
            }
        }


        public void DisplayInventory(SqlConnection connection)
        {
            string query3 = "SELECT * FROM Inventory";
            using (SqlCommand command = new SqlCommand(query3, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("\n---- All Inventories ----\n");
                    Console.WriteLine("+------------+----------------------+");
                    Console.WriteLine("| InventoryID | Location             |");
                    Console.WriteLine("+------------+----------------------+");
                    while (reader.Read())
                    {

                        Console.WriteLine($"| {reader["InventoryID"],-10} | {reader["Location"],-20} |");

                    }
                    Console.WriteLine("+------------+----------------------+");
                }
            }
        }

        public void CheckProductName(SqlConnection connection, ref string name, ref int inventoryId)
        {


            string query2 = "SELECT COUNT(*) FROM Product WHERE Name = @Name AND InventoryId = @InventoryId ";
            using (SqlCommand command2 = new SqlCommand(query2, connection))
            {
                command2.Parameters.AddWithValue("@Name", name);
                command2.Parameters.AddWithValue("@InventoryId", inventoryId);
                int count = (int)command2.ExecuteScalar();
                if (count > 0)
                {
                    throw new ProductNameAlredyExistException("Product Name Already Exist");

                }
            }


        }

        public void InsertQueryAddProduct(SqlConnection connection, ref string name, ref string description, ref int quantity, ref int price, ref int inventoryId)
        {
            string query = "INSERT INTO Product (Name, Description, Quantity, Price, InventoryId) VALUES (@Name, @Description, @Quantity, @Price, @InventoryId)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@InventoryId", inventoryId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }


        public void UpdateProductQuery(SqlConnection connection, ref string name, ref string description, ref int price, ref int productId)
        {
            string query = "UPDATE Product SET Name = @Name, Description = @Description, Price = @Price WHERE ProductID = @ProductID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@ProductID", productId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void DeleteProductQuery(SqlConnection connection, ref int productId)
        {
            string query = "DELETE FROM Product WHERE ProductID = @ProductID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductID", productId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void ViewSpecificProductQuery(SqlConnection connection, ref int productId)
        {
            string query = "SELECT * FROM Product WHERE ProductID = @ProductID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductID", productId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n---- Product Details ----\n");
                        Console.WriteLine("+----------------+----------------------+");
                        Console.WriteLine("| Field          | Value                |");
                        Console.WriteLine("+----------------+----------------------+");
                        Console.WriteLine($"| Product ID     | {reader["ProductID"],-20} |");
                        Console.WriteLine($"| Name           | {reader["Name"],-20} |");
                        Console.WriteLine($"| Description    | {reader["Description"],-20} |");
                        Console.WriteLine($"| Quantity       | {reader["Quantity"],-20} |");
                        Console.WriteLine($"| Price          | {reader["Price"],-20} |");
                        Console.WriteLine("+----------------+----------------------+");
                        Console.ResetColor();
                    }
                    else
                    {
                        throw new ProductIdNotFoundException("Product ID Not Found...");
                    }
                }
            }
        }


        private bool CheckProducIdExists(SqlConnection connection, ref int productId)
        {
            string query = "SELECT COUNT(*) FROM Product WHERE ProductID = @ProductID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductID", productId);

                int count = (int)command.ExecuteScalar();
                return count > 0; // Returns true if product exists, false otherwise
            }
        }

    }

}
