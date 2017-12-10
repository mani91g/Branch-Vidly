using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]        
        public string MovieName { get; set; }
        
        public float ImdbRating { get; set; }
                       
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public GenreDTO Genre { get; set; }
        public int GenreId { get; set; }

        [Range(1, 20)]
        [Required]
        public int Stock { get; set; }
    }
}