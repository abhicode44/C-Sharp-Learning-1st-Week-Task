using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.Data.SqlClient;
using StudentAppWithDatabase.Services;

namespace StudentAppWithDatabase.Model
{
    internal class Student_Store
    {   


        
            Student_Manager student_manager = new Student_Manager();
       
        
        public void ChooseMenu()
        {
            string connectionString = ConfigurationManager.AppSettings["connectionStringName"];

            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection opened successfully.");

                        bool continueMenu = true;
                        Console.WriteLine("\nWelcome to Student Manager App");

                        while (continueMenu)
                        {
                            Console.WriteLine("What action do you want to perform?");
                            Console.WriteLine("1. Create a new Student");
                            Console.WriteLine("2. Display all Students");
                            Console.WriteLine("3. Update Student Email");
                            Console.WriteLine("4. Delete a Student Record");
                            Console.WriteLine("5. Exit");

                            int userInput = Convert.ToInt32(Console.ReadLine());

                            switch (userInput)
                            {
                                case 1:
                                    student_manager.CreateStudent(connection);
                                    break;

                                case 2:
                                    student_manager.ReadStudents(connection);
                                    break;

                                case 3:
                                    Console.WriteLine("Enter Student Id to update:");
                                    int updateId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter New Email :- ");
                                    string newEmail = Console.ReadLine();
                                    student_manager.UpdateStudentEmail(connection, updateId, newEmail);
                                    break;

                                case 4:
                                    Console.WriteLine("Enter Student Id to delete:");
                                    int deleteId = Convert.ToInt32(Console.ReadLine());
                                    student_manager.DeleteStudent(connection, deleteId);
                                    break;

                                case 5:
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
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
            



        }

    }
}
