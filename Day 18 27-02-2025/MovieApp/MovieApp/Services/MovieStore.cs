using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Model;
using MovieApp.Exceptions;

namespace MovieApp.Services
{
    internal class MovieStore
    {
        MovieManager movieManager;

        public MovieStore() {
 
              movieManager = new MovieManager();

        }

        public void ShowMenu()
        {
            string choice = "";

            do{
                try
                {
                  
                    Console.WriteLine("\nWelcome to Movie Store developed by: Abhishek");
                    Console.WriteLine("1. Add new Movie");
                    Console.WriteLine("2. Display All Movies");
                    Console.WriteLine("3. Find Movie by ID");
                    Console.WriteLine("4. Remove Movie by ID");
                    Console.WriteLine("5. Clear All Movies");
                    Console.WriteLine("6. Exit");
                    Console.Write("Enter your choice: ");
                    choice = (Console.ReadLine());




                    //Add new movie 
                    if (choice == "1")
                    {
                        movieManager.AddMovie();
                    }

                    // Display Movies 
                    else if (choice == "2")
                    {
                        movieManager.DisplayMovie();
                    }

                    // Find Movie by Id 
                    else if (choice == "3")
                    {
                        movieManager.FindMovieById();
                    }

                    // Remove Movie by Id 
                    else if (choice == "4")
                    {
                        movieManager.RemoveMovieById();
                    }

                    // Clear All Movies
                    else if (choice == "5")
                    {
                        movieManager.ClearAllMovie();
                    }

                    // Exit
                    else if (choice == "6")
                    {
                        break;
                    }

                    else if (choice == " ")
                    {
                        throw new InvalidChoiceException("Enter Valid Input Between 1 To 6");
                    }


                }
                 catch (Exception e)
                { 
                 Console.WriteLine(e.ToString());
                }
            } while (choice != "6");
            
        }
        


    }
}
