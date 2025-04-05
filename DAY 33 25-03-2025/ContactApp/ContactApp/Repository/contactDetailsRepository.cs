using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Interface;
using ContactApp.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ContactApp.Repository
{
    internal class contactDetailsRepository
    {
        public void AddContactDetails( )
        {
            Console.WriteLine("Enter Contact Id :- ");
            int inputcontactid = Convert.ToInt32(Console.ReadLine());

            using (var context = new MyContext())
            {
                Contact contactToUpdate = context.Contact.FirstOrDefault(u => u.Contact_Id == inputcontactid);

                if (contactToUpdate != null)
                {
                    Console.WriteLine(" 1 : Number ");
                    Console.WriteLine(" 2 : Email ");

                    Console.Write("Enter The  Type: ");
                    int inputtype = Convert.ToInt32(Console.ReadLine());

                    if (!Enum.IsDefined(typeof(ContactDetails_Enum), inputtype))
                    {

                        Console.WriteLine("Invalid Imputttt");
                    }
                    ContactDetails_Enum number_emailType = (ContactDetails_Enum)inputtype;
                    Console.WriteLine($"Type Selected By User :- {number_emailType}");

                    Console.Write("Enter The Values :- ");
                    string inputValues = Console.ReadLine();

                   
                        Contact_Details newContactDetails = new Contact_Details
                        {
                            Type = inputtype.ToString(),
                            Values = inputValues,
                            Contact_Id = inputcontactid,
                        };

                        context.Contact_Details.Add(newContactDetails);
                        context.SaveChanges();
                        Console.WriteLine("Contact Details added successfully.");

                    
                }

                else
                {
                    Console.WriteLine("Contact Not Found");
                }
            }
        }



        public void RemoveContactDetails()
        {
            Console.WriteLine("Enter Contact Details ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var context = new MyContext())
            {
                var contactdetails = context.Contact_Details.Find(id);


                context.Contact_Details.Remove(contactdetails);
                context.SaveChanges();
                Console.WriteLine("Contact removed successfully.");


            }
        }

        public void UpdateContactDetails()
        {
            Console.WriteLine("Enter ContactDetails ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (MyContext context = new MyContext())
            {
                Contact_Details contactToUpdate = context.Contact_Details.FirstOrDefault(u => u.Contact_Details_Id == id);

       
                if (contactToUpdate != null)
                {
                        Console.Write("Enter The New Type: ");
                        Console.WriteLine(" 1 : Number ");
                        Console.WriteLine(" 2 : Email ");

                        Console.Write("Enter The  Type: ");
                        int inputtype = Convert.ToInt32(Console.ReadLine());

                        if (!Enum.IsDefined(typeof(ContactDetails_Enum), inputtype))
                        {

                            Console.WriteLine("Invalid Imputttt");
                        }

                        ContactDetails_Enum number_emailType = (ContactDetails_Enum)inputtype;
                        Console.WriteLine($"Type Selected By User :- {number_emailType}");

                        Console.Write("Enter New Values: ");
                        string Values = Console.ReadLine();
                        
                        contactToUpdate.Type = number_emailType.ToString();
                        contactToUpdate.Values = Values;
                        

                        context.Contact_Details.Update(contactToUpdate);
                        context.SaveChanges();

                        Console.WriteLine("ContactDetails updated successfully!");
                    }

                    else
                    {
                    Console.WriteLine("Contact ID not found.");
                    }
                }
            }


        public void ViewContactDetails()
        {
            using (var context = new MyContext()) 
            {
                var contacts = context.Contact_Details.ToList();

                if (contacts.Count == 0)
                {
                    Console.WriteLine("No users found.");
                    return;
                }

                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("| Contact_Details_Id| Type  | Values  | Contact_ID |");
                Console.WriteLine("----------------------------------------------------");

                // Print table rows
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"| {contact.Contact_Details_Id,-7} | {contact.Type.ToString(),-10} | {contact.Values.ToString(),-10} | {contact.Contact_Id,-8} |");
                }

                Console.WriteLine("------------------------------------------------------");

            }
        }
    }
}
