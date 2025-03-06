using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Services;

namespace MovieApp.Model
{
    internal class DetailsOfMovies
    {
        
        public string Name { get; set; }
        public int Id { get; set; }

        public int YearOfRelease { get; set; }
        public  GenreList Genre { get; set; }

        public DetailsOfMovies(string name, int id, int yearofrelease, GenreList genre)
        {
            Name = name;
            Id = id;
            YearOfRelease = yearofrelease;
            Genre = genre;
        }

    }
}
