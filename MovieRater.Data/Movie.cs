using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Movie
    {
        [Key] 
        public int MovieID { get; set; }
        public Guid OwnerID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual List<Genre> Genres { get; set; }
    }
}
