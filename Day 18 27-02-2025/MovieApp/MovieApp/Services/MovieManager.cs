using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Exceptions;
using MovieApp.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieApp.Services
{
    internal class MovieManager
    {

        List<DetailsOfMovies> movieList = new List<DetailsOfMovies>();
        DataSerialization dataSerialization;

       


        public MovieManager()
        {   

            dataSerialization = new DataSerialization();
            movieList = dataSerialization.DeSerializer();

        }

       

        public void AddMovie()
        {

            try
            {
                if (movieList.Count >= 5)
                {
                    throw new ListFullException(" The Movie List is Full you can not add new movie...");
                }

                Console.Write("Enter The Movie Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter The Movie Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter The Year of Release: ");
                int yearOfRelease = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Choose the genre of the movie");
                int i = 1;
                foreach ( var typeofgenre in Enum.GetValues(typeof(GenreList)).Cast<GenreList>())
                {
                    Console.WriteLine($" {i} { typeofgenre}");
                    i++;
                }


                Console.Write("Enter The Movie Genre: ");
                int genrenumber = Convert.ToInt32(Console.ReadLine());

                var genre = (GenreList)genrenumber;

               

                DetailsOfMovies newmovie = new DetailsOfMovies(name, id, yearOfRelease, genre);
                movieList.Add(newmovie);
                dataSerialization.Serializer(movieList);
                Console.WriteLine("Movie added successfully!");

            }

            catch (Exception e) { 
               Console.WriteLine(e.ToString());
            }
        }


        public void DisplayMovie()
        {

            try
            {
                if (movieList.Count == 0)
                {
                    throw new ListEmptyException(" No movies available, list is empty.");
                }
                else
                {
                    foreach (DetailsOfMovies movie in movieList)
                    {
                        Console.WriteLine($"Name: {movie.Name}");
                        Console.WriteLine($"ID: {movie.Id}");
                        Console.WriteLine($"Year of Release: {movie.YearOfRelease}");
                        Console.WriteLine($"Genre: {movie.Genre}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e) { 
              Console.WriteLine(e.ToString());
            }
            
        }


        public void FindMovieById()
        {
            try
            {
                Console.Write("Enter Movie ID to search movie : ");
                int searchId = Convert.ToInt32(Console.ReadLine());

                bool id_found = false;

                foreach (DetailsOfMovies movie in movieList)
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
                    throw new MovieIdNotFoundException("Movie id not found");
                }
            }
            catch (Exception e) { 
               Console.WriteLine(e.ToString());
            }
           

        }

        public void RemoveMovieById()
        {
            try
            {
                Console.Write("Enter Movie ID to remove: ");
                int removeMovieId = Convert.ToInt32(Console.ReadLine());

                bool idFound = false;


                foreach (DetailsOfMovies movie in movieList)
                {
                    if (movie.Id == removeMovieId)
                    {
                        movieList.Remove(movie);
                        Console.WriteLine("Movie removed successfully.");
                        idFound = true;
                        break;
                    }
                }

                if (!idFound)
                {
                    throw new MovieIdNotFoundException("Movie ID not found.");
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void ClearAllMovie()


        {
            try
            {
                if (movieList.Count == 0)
                {
                    throw new ListEmptyException("No Movies Found.");
                }
                else
                {
                    movieList.Clear();
                    Console.WriteLine("All movies removed successfully.");
                }
            }
            catch (Exception e) { 
              Console.WriteLine(e.ToString());
            }
           
        }

        

    }
}
