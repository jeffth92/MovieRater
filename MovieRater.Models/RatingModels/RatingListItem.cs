using MovieRater.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.RatingModels
{
    public class RatingListItem
    {
        
        public int MovieID { get; set; }
        public int ShowID { get; set; }

        public List<Rating> Ratings { get; set; }
        public string Title { get; set; }
    }
}
