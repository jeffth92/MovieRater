using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Show
    {
        [Key]
        public int ShowID { get; set; }
        public Guid OwnerID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public int NumberOfSeasons { get; set; }
    }
}
