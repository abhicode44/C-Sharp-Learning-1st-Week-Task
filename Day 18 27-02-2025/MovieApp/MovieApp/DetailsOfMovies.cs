using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    internal class DetailsOfMovies
    {

        public string Name { get; set; }
        public int Id { get; set; }

        public int YearOfRelease { get; set; }
        public string Genre { get; set; }

        public DetailsOfMovies(string name , int id , int yearofrelease , string genre)
        {
            Name = name;
            Id = id;
            YearOfRelease = yearofrelease;
            Genre = genre;
        }

    }
}
