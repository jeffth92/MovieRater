using MovieRater.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.ShowModels
{
    public class ShowListItem
    {
        public int ShowId { get; set; }
        public string Title { get; set; }
        public List<Rating> Ratings { get; set; }
        public double? AverageRating { get; set; }

    }
}
