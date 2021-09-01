using MovieRater.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.ShowModels
{
    public class CreateShow
    {
        [Required]
        [MinLength(1, ErrorMessage ="Titles have a minimum length of 1 character.")]
        [MaxLength(100, ErrorMessage ="Titles have a maximum lenght of 100 characters.")]
        public string Title { get; set; }

        [MaxLength(1000, ErrorMessage ="Descriptions have a maximum length of 1000 characters.")]
        public string Description  { get; set; }
        public int NumberOfSeasons { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
