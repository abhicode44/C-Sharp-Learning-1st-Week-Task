using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Interface;
using ContactApp.Models;
using ContactApp.Repository;
using ContactApp.Services;

namespace ContactApp
{
    internal class Contactapp
    {

        IuserService userService = new userService();

        IContactService contactService = new contactService();

        public void TakeInput()
        {
            Console.Write("Enter User ID :-  ");
            int id = Convert.ToInt32(Console.ReadLine());


            using (var context = new MyContext())
            {
                User user = context.User.FirstOrDefault(u => u.User_ID == id);


                if (user.User_ID == id)
                {
                    if (user.IsActive)
                    {
                        if (user.IsAdmin)
                        {
                            Console.Write($"Hello {user.F_Name} ");
                            Console.WriteLine("\n");
                            ShowAdminMenu();
                        }
                        else
                        {
                            Console.Write($"Hello {user.F_Name}");
                            Console.WriteLine("\n");
                            ShowStaffMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("User is not Active");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid User ID.");
                }
            }
        }


        public void ShowAdminMenu()
        {
            bool continueAdmin = true;
            while (continueAdmin)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Remove Users");
                Console.WriteLine("3. Update Users");
                Console.WriteLine("4. View User By ID");
                Console.WriteLine("5. View All User");
                Console.WriteLine("6. Exit");

                Console.Write("Enter Choice :-  ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        userService.AddUser();
                        break;
                    case 2:
                        userService.RemoveUser();
                        break;
                    case 3:
                        userService.UpdateUser();
                        break;
                    case 4:
                        userService.ViewDeatailsById();
                        break;
                    case 5:
                        userService.ViewAllDetails();
                        break;
                    case 6:
                        continueAdmin = false;
                        Console.WriteLine("\nExiting the application . . .");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        public void ShowStaffMenu()
        {
            bool continueStaff = true;
            while (continueStaff)
            {
                Console.WriteLine("Staff Menu:");
                Console.WriteLine("1. Create Contact");
                Console.WriteLine("2. Remove Contacts");
                Console.WriteLine("3. Update Contact");
                Console.WriteLine("4. View Contact By ID");
                Console.WriteLine("5. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        contactService.AddContact();
                        break;
                    case 2:
                        contactService.RemoveContact();
                        break;
                    case 3:
                        contactService.UpdateContact();
                        break;
                    case 4:
                        contactService.ViewContactDeatailsById();
                        break;
                    //case 5:
                    //    contactService.ViewAllContact();
                    //    break;
                    case 5:
                        continueStaff = false;
                        Console.WriteLine("\nExiting the application . . .");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }


    }
}
