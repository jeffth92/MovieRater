using MovieRater.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.GenreModles
{
    public class GenreDetail //look up one genre and what's in it.
    {
        public int GenreID { get; set; }

        public string GenreName { get; set; }

        public List<Show> Shows { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
