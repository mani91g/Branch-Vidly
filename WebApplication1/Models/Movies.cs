using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Movies
    {
        public int Id { get; set; }
     
        [Required]
        [Display(Name ="Movie Name")]
        public string MovieName { get; set; }

        [Display(Name = "Imdb Rating")]
        public float ImdbRating { get; set; }


        public Genre Genre { get; set; }        
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Range(1,20)]
        [Required]
        public int Stock { get; set; }
    }
}