using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieRater.Models.MovieModels
{
    public class MovieCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(25, ErrorMessage = "You can have NO more than 25 characters.")]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }


    }
}



