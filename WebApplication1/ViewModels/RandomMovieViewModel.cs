using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;


namespace WebApplication1.ViewModels
{
    public class RandomMovieViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }

        public int? Id { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Required]
        [Display(Name = "Imdb Rating")]
        public float ImdbRating { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }        

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [Range(1, 20)]
        [Required]
        public int Stock { get; set; }

        public String Title
        {
            get
            {
                if ( Id != 0 && Id != null)
                    return "Edit Movie";
                else
                    return "New Movie";
            }
        }

        public RandomMovieViewModel()
        {

        }

        public RandomMovieViewModel(Movies MovieDetails)
        {            
            Id = MovieDetails.Id;
            MovieName = MovieDetails.MovieName;
            ReleaseDate = MovieDetails.ReleaseDate;
            ImdbRating = MovieDetails.ImdbRating;
            Stock = MovieDetails.Stock;
            GenreId = MovieDetails.GenreId;
        }


    }
}