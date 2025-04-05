using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Repository
{
    internal class contactRepository
    {
        contactDetailsRepository contact_details = new contactDetailsRepository();
        public void AddContact(int id)
        {
            Console.Write("Enter First Name: ");
            string firstname = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            using (var context = new MyContext())
            {
                
                var user = context.Contact.Find(id);
               

                Contact newContact = new Contact
                {
                    F_Name = firstname,
                    L_Name = lastName,
                    User_ID = id  
                };

                context.Contact.Add(newContact);
                context.SaveChanges();
                Console.WriteLine("Contact added successfully.");

                //int contactid = newContact.Contact_Id;
                //int contactDetailsId = contact_details.AddContactDetails(contactid);
            }
        }



       
        public void RemoveContact()
        {
            Console.WriteLine("Enter Contact ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var context = new MyContext())
            {
                var contact = context.Contact.Find(id);

                if (contact == null)
                {
                    Console.WriteLine("Error: Contact does not exist.");
                    return;
                }

                context.Contact.Remove(contact);
                context.SaveChanges();
                Console.WriteLine("Contact removed successfully.");
            }
        }
        public void UpdateContact()
        {
            Console.WriteLine("Enter Contact ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var context = new MyContext())
            {
                Contact contactToUpdate = context.Contact.FirstOrDefault(u => u.Contact_Id == id);

                if (contactToUpdate != null)
                {
                    Console.Write("Enter New First Name: ");
                    contactToUpdate.F_Name = Console.ReadLine();

                    Console.Write("Enter New Last Name: ");
                    contactToUpdate.L_Name = Console.ReadLine();

                    context.Contact.Update(contactToUpdate);
                    context.SaveChanges();

                    Console.WriteLine("Contact updated successfully!");
                }
                else
                {
                    Console.WriteLine("Contact ID not found.");
                }
            }
        }

        public void ViewContactDeatailsById()
        {

            Console.WriteLine("Enter Contact ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var context = new MyContext())
            {
                Contact contact = context.Contact.FirstOrDefault(u => u.Contact_Id == id);

                if (contact != null)
                {
                    Console.WriteLine($" Contact ID: {contact.Contact_Id}, First Name: {contact.F_Name}, Last Name : {contact.L_Name}, User_ID: {contact.User_ID}");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }


            }
        }

        public void ViewAllContact()
        {
            using (var context = new MyContext())
            {
                var contacts = context.Contact.ToList();

                if (contacts.Count == 0)
                {
                    Console.WriteLine("No users found.");
                    return;
                }

                // Print table header
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("| Contact_ID | First Name  | Last Name  | User_ID |");
                Console.WriteLine("----------------------------------------------------");

                // Print table rows
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"| {contact.Contact_Id,-7} | {contact.F_Name,-10} | {contact.L_Name,-10} | {contact.User_ID,-8} |");
                }

                Console.WriteLine("------------------------------------------------------");
            }
        }
    }
}
