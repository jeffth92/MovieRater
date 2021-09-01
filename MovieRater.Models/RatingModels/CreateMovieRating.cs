using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.RatingModels
{
    public class CreateMovieRating
    {
        public int MovieID { get; set; }

        [Required, Range(0, 5)]
        public double RatingStar { get; set; }
        public string Comment { get; set; }
    }
}
