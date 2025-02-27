using System;
using MovieApp;

internal class Program
{


    private static void Main(string[] args)
    {

        int max_movie = 5 ;
        int choice;
        int movie_count = 0;  // count movies in the array


        DetailsOfMovies [] moviearray  = new DetailsOfMovies[max_movie];
       
  


        do
        {
            Console.WriteLine("\nWelcome to Movie Store developed by: Abhishek");
            Console.WriteLine("1. Add new Movie");
            Console.WriteLine("2. Display All Movies");
            Console.WriteLine("3. Find Movie by ID");
            Console.WriteLine("4. Remove Movie by ID");
            Console.WriteLine("5. Clear All Movies");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            


            //Add new movie 
            if (choice == 1)
            {
                if(movie_count >= max_movie)
                {
                    Console.WriteLine("Can not add more movies Array full");
                }
                else
                {
                    Console.Write("Enter The Movie Name :- ");
                    string name = Console.ReadLine();



                    Console.Write("Enter The Movie Id :- ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter The Year of Release:  :- ");
                    int yearofrelease = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter The Movie Genre :- ");
                    string genre = Console.ReadLine();

                    moviearray[movie_count] = new DetailsOfMovies(name, id , yearofrelease , genre);
                    movie_count++;
                    Console.WriteLine("Movie added successfully!");
                }
            } 
            
            // Display Movies 


            else if (choice == 2)
            {
                if (movie_count == 0)
                {
                    Console.WriteLine("No movies available array is empty.");
                }
                else
                {
                    foreach (DetailsOfMovies movie in moviearray)
                        if (movie == null)
                    {
                        //break;
                    }
                        else
                        {
                            Console.WriteLine(movie.Name);
                            Console.WriteLine(movie.Id);
                            Console.WriteLine(movie.YearOfRelease);
                            Console.WriteLine(movie.Genre);
                        }
                }
            }


            // Find Movie by Id 
            else if (choice == 3)
            {
                Console.Write("Enter Movie ID to search movie : ");
                int searchId = Convert.ToInt32(Console.ReadLine());

                bool id_found = false;

                 foreach (DetailsOfMovies movie in moviearray)
                {
                    if (movie != null && movie.Id == searchId)
                    {   
                        Console.WriteLine(movie.Name);
                        Console.WriteLine(movie.Id);
                        Console.WriteLine(movie.YearOfRelease);
                        Console.WriteLine(movie.Genre);
                        id_found = true;
                        break;
                    }
                }

                 if (!id_found)
                {
                    Console.WriteLine("Movie id not found");
                }

            }


            // Remove Movie by Id 

            else if (choice == 4)
            {
                Console.Write("Enter Movie ID to search movie : ");
                int removemovie = Convert.ToInt32(Console.ReadLine());


                for (int i = 0; i < moviearray.Length; i++)
                   {

                    
                        if (moviearray[i] != null && moviearray[i].Id == removemovie) // Check if movie exists and matches the ID
                        {
                            moviearray[i] = null;
                            Console.WriteLine("Movie removed successfully.");
                            movie_count--;

                           for (int j = i; j < moviearray.Length - 1 ; j++)
                           {
                            moviearray[j] = moviearray[j + 1];
                            moviearray[j + 1] = null;   
                           }



                       
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Movie id not found");
                        }
                   

                        
                 }

    
                  

            }


            else if (choice == 5)
            {
                if (movie_count == 0)
                {
                    Console.WriteLine("No Movies Found");
                }
                else
                {
                    for (int i = 0; i < movie_count; i++ )
                    {
                        moviearray[i] = null;
                      
                    }
                    movie_count = 0;
                    Console.WriteLine("all movie remove succesfully");
                }
            }

            else if (choice == 6)
            {
                break;
            }
        } while (choice != 6);

    }
}