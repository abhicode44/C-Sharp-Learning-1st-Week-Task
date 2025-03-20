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
    internal class SupplierOperation : IService
    {

        public void ChooseMenu(SqlConnection connection)
        {
            try
            {
                bool continueMenu = true;

                while (continueMenu)
                {
                    Console.WriteLine("\nWelcome to Supplier Manager ");
                    Console.WriteLine();
                    Console.WriteLine("1. Add  New Supplier");
                    Console.WriteLine("2. Update Supplier ");
                    Console.WriteLine("3. Delete Supplier");
                    Console.WriteLine("4. View Supplier's Details");
                    Console.WriteLine("5. View All Suppliers");
                    Console.WriteLine("6. Go To The Main Menu");

                    Console.Write("\nWhich Action Do you Want To Perform From Supplier Manangement Menu :- ");
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

        public void Add(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Supplier Name :- ");
                string name = Console.ReadLine();
                Console.Write("Enter Contact Number :- ");
                string contact = Console.ReadLine();
                Console.Write("Enter The Information :- ");
                string information = (Console.ReadLine());


                DisplayInventory(connection);


                Console.Write("Enter Inventory ID: ");
                int inventoryId = int.Parse(Console.ReadLine());

                SupplierAddQuery(connection, ref name, ref contact, ref information, ref inventoryId);

                Console.WriteLine("\nUpdated Supplier List");
                View_All_Details(connection);

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
                Console.Write("Enter Supplier ID to Update: ");
                int supplierId = int.Parse(Console.ReadLine());

                if (!CheckSupplierIdExists(connection, ref supplierId))
                {
                    throw new SupplierIdNotFoundException($"Supplier with ID {supplierId} does not exist.");
                    return;
                }


                Console.Write("Enter New Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter New Contact : ");
                string contact = Console.ReadLine();

                SupplierUpdateQuery(connection, ref name, ref contact, ref supplierId);

                Console.WriteLine("\nUpdated Supplier List");
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
                Console.Write("Enter Supplier ID to Delete: ");
                int supplierId = int.Parse(Console.ReadLine());


                if (!CheckSupplierIdExists(connection, ref supplierId))
                {
                    throw new SupplierIdNotFoundException($"Supplier with ID {supplierId} does not exist.");
                    return;
                }

                DeleteSupplierQuery(connection, ref supplierId);

                Console.WriteLine("\nUpdated Supplier List");
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
                Console.Write("Enter Supplier ID to View: ");
                int supplierId = int.Parse(Console.ReadLine());


                if (!CheckSupplierIdExists(connection, ref supplierId))
                {
                    throw new SupplierIdNotFoundException($"Supplier with ID {supplierId} does not exist.");
                    return;
                }

                ViewSpecificSupplierQuery(connection, ref supplierId);

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
                string query = "SELECT * FROM Supplier";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n---- All Suppliers ----\n");

                        Console.WriteLine("+------------+----------------------+------------+----------------+-------------+");
                        Console.WriteLine("| SupplierID | Name                 | Contact    | Information    | InventoryID |");
                        Console.WriteLine("+------------+----------------------+------------+----------------+-------------+");

                        while (reader.Read())
                        {
                            Console.WriteLine(
                            $"| {reader["SupplierId"],-10} | {reader["Name"],-20} | {reader["Contact"],-10} | {reader["Information"],-14} | {reader["InventoryID"],-11} |");
                        }
                        Console.WriteLine("+------------+----------------------+------------+----------------+-------------+");
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

        public void SupplierAddQuery(SqlConnection connection, ref string name, ref string contact, ref string information, ref int inventoryId)
        {
            string query = "INSERT INTO Supplier (Name, Contact, Information , InventoryId) VALUES (@Name, @Contact , @Information , @InventoryId)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Contact", contact);
                command.Parameters.AddWithValue("@Information", information);
                command.Parameters.AddWithValue("@InventoryId", inventoryId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");

            }
        }

        public void SupplierUpdateQuery(SqlConnection connection, ref string name, ref string contact, ref int supplierId)
        {
            string query = "UPDATE Supplier SET Name = @Name, Contact = @Contact WHERE SupplierID = @SupplierID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Contact", contact);
                command.Parameters.AddWithValue("@SupplierID", supplierId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void DeleteSupplierQuery(SqlConnection connection, ref int supplierId)
        {
            string query = "DELETE FROM Supplier WHERE SupplierID = @SupplierID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SupplierID", supplierId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void ViewSpecificSupplierQuery(SqlConnection connection, ref int supplierId)
        {
            string query = "SELECT * FROM Supplier WHERE SupplierID = @SupplierID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SupplierID", supplierId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n---- Supplier Details ----\n");

                        Console.WriteLine("+-------------+----------------------+");
                        Console.WriteLine("| Field       | Value                |");
                        Console.WriteLine("+-------------+----------------------+");

                        Console.WriteLine($"| Supplier ID | {reader["SupplierID"],-20} |");
                        Console.WriteLine($"| Name        | {reader["Name"],-20} |");
                        Console.WriteLine($"| Contact     | {reader["Contact"],-20} |");
                        Console.WriteLine($"| Inventory ID| {reader["InventoryId"],-20} |");

                        Console.WriteLine("+-------------+----------------------+");
                        Console.ResetColor();
                    }
                    else
                    {
                        throw new Exception("Supplier ID not found.");
                    }
                }
            }
        }


        private bool CheckSupplierIdExists(SqlConnection connection, ref int supplierId)
        {
            string query = "SELECT COUNT(*) FROM Supplier WHERE SupplierID = @SupplierID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SupplierID", supplierId);

                int count = (int)command.ExecuteScalar();
                return count > 0; // Returns true if product exists, false otherwise
            }
        }

    }
}
