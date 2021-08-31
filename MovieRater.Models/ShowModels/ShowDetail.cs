using MovieRater.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.ShowModels
{
    public class ShowDetail
    {
        public int ShowId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Genre> Genres { get; set; }
        public int NumberofSeasons { get; set; }
        public double AverageRating
        {
            get
            {
                double averageRating = 0;
                foreach(var rating in Ratings)
                {
                    averageRating += rating.RatingStar;
                }
                return Ratings.Count > 0
                    ? Math.Round(averageRating / Ratings.Count, 2)
                    : 0;

            }
        }
    }
}
