using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Rating
    {
        [Key] 
        public int RatingID { get; set; }
        public Guid OwnerID { get; set; }

        public double RatingStar { get; set; }
        public string Comment { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }

        [ForeignKey(nameof(Show))]
        public int ShowID { get; set; }
        public virtual Show Show { get; set; }
    }
}
