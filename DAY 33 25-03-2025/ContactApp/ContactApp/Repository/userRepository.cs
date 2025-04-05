using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Repository
{
    internal class userRepository
    {
        public void AddUser()
        {
            Console.Write("Enter First Name: ");
            string firstname = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter User Activation (ON/OFF): ");
            string isActive = Console.ReadLine().ToUpper();

            using (var context = new MyContext())
            {
            

                User newUser = new User
                {
                    F_Name = firstname,
                    L_Name = lastName,
                    IsActive = isActive == "ON"

                };

                context.User.Add(newUser);
                context.SaveChanges();

                Console.WriteLine($"User added successfully! {(newUser.IsAdmin ? "This user is the Admin." : "This user is a Staff member.")}");
            }

        }

        public void RemoveUser()
        {
            Console.WriteLine("Enter User ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var context = new MyContext())
            {
                User userToDelete = context.User.FirstOrDefault(u => u.User_ID == id);

                if (userToDelete != null)
                {

                    userToDelete.IsActive = false;  // Deactivate the user
                    context.SaveChanges(); // Save changes

                    Console.WriteLine($"User with ID {id} has been deactivated.");

                }
                else
                {
                    Console.WriteLine("User not found.");
                }

            }

        }
        public void UpdateUser()
        {
            Console.WriteLine("Enter User ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var context = new MyContext())
            {
                User userToUpdate = context.User.FirstOrDefault(u => u.User_ID == id);

                if (userToUpdate != null)
                {
                    Console.Write("Enter New User Name: ");
                    userToUpdate.F_Name = Console.ReadLine();

                    

                    Console.Write("Enter User Activation (ON/OFF): ");
                    string isActive = Console.ReadLine().ToUpper();

                   
                    if (isActive == "ON")
                    {
                        userToUpdate.IsActive = true;
                    }
                    else if (isActive == "OFF")
                    {
                        userToUpdate.IsActive = false;
                    }
                    context.User.Update(userToUpdate);
                    context.SaveChanges();

                    Console.WriteLine("User updated successfully!");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }


        }
        public void ViewDeatailsById()
        {
            Console.WriteLine("Enter User ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var context = new MyContext())
            {
                User user = context.User.FirstOrDefault(u => u.User_ID == id);

                if (user != null)
                {
                    Console.WriteLine($"User ID: {user.User_ID}, Name: {user.F_Name}, IsAdmin: {user.IsAdmin}, IsActive: {user.IsActive}");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }

            }
        }
        public void ViewAllDetails()
        {
            using (var context = new MyContext())
            {
                var users = context.User.ToList();

                if (users.Count == 0)
                {
                    Console.WriteLine("No users found.");
                    return;
                }

                // Print table header
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("| User_ID | First Name  | Last Name  | IsAdmin | IsActive |");
                Console.WriteLine("-----------------------------------------------------------");

                // Print table rows
                foreach (var user in users)
                {
                    Console.WriteLine($"| {user.User_ID,-7} | {user.F_Name,-10} | {user.L_Name,-10} | {user.IsAdmin,-7} | {user.IsActive,-8} |");
                }

                Console.WriteLine("------------------------------------------------------");
            }



        }

    }
}
