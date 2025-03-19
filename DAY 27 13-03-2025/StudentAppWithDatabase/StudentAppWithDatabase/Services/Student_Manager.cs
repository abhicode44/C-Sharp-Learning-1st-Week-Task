using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace StudentAppWithDatabase.Services
{
    internal class Student_Manager
    {
        string connectionString = ConfigurationManager.AppSettings["connectionStringName"];
        public Student_Manager() 
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) ;
        }

        public void CreateStudent(SqlConnection connection)
        {
            Console.WriteLine("Enter student details:");
            Console.WriteLine("Student Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Student Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Roll Number:");
            int rollNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Address:");
            string address = Console.ReadLine();


            string query = "INSERT INTO student (student_id, student_name, roll_number, email, address) VALUES (@Id, @Name, @RollNumber, @Email, @Address)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@RollNumber", rollNumber);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Address", address);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void ReadStudents(SqlConnection connection)
        {
            string query = "SELECT * FROM student";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["student_id"]}, {reader["student_name"]}, {reader["roll_number"]}, {reader["email"]}, {reader["address"]}");
                    }
                }
            }
        }

        public void UpdateStudentEmail(SqlConnection connection, int id, string newEmail)
        {
            string query = "UPDATE student SET email = @Email WHERE student_id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Email", newEmail);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows updated: {rowsAffected}");
            }
        }

     
        public  void DeleteStudent(SqlConnection connection, int id)
        {
            string query = "DELETE FROM student WHERE student_id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows deleted: {rowsAffected}");
            }
        }

    }
}
