using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MovieApp.Model;

namespace MovieApp.Services
{
    internal class DataSerialization
    {   

        public void Serializer(List<DetailsOfMovies> detailsOfMovies)
        {
            string fileName = "Movie.json";
            //List<DetailsOfMovies> movie_serilize = new List<DetailsOfMovies>();

            string jsonString;
            //movie_serilize.Add(detailsOfMovies);
            jsonString = JsonSerializer.Serialize(detailsOfMovies);
            File.WriteAllText(fileName, jsonString);

            //File.AppendAllText(fileName, jsonString);
            Console.WriteLine(" Serialization Completed ");
        }

        public List<DetailsOfMovies> DeSerializer ()
        {
            string fileName = "Movie.json";
            List<DetailsOfMovies> movie_deserilize = new List<DetailsOfMovies>();
            string jsonString;
            if (File.Exists(fileName)) 
            { 
                jsonString = File.ReadAllText(fileName);
                movie_deserilize = JsonSerializer.Deserialize<List<DetailsOfMovies>>(jsonString);
            }
            return movie_deserilize ;
        }

    }
}
