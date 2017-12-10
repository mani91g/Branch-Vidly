using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie

        ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

      
        public ActionResult Index()
        {
            if (User.IsInRole(Constants.CanManageMovie)) 
                return View("List");

            return View("ListReadOnly");
        }

        [Route("Movies/ByReleaseDate/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year+"/"+month);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        [Authorize(Roles = Constants.CanManageMovie)]
        public ActionResult AddNewMovie()
        {
            ViewBag.PageTitle = "New Movie";
            var genreList = _context.Genre.ToList();
            var viewModel = new RandomMovieViewModel()
            {                
                Genre = genreList

            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constants.CanManageMovie)]
        public ActionResult Save(Movies Movie)
        {
            

            if(Movie.Id == 0)
            {
                Movie.DateAdded = DateTime.Now;
                _context.Movies.Add(Movie);
                
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == Movie.Id);

                movieInDb.GenreId = Movie.GenreId;
                movieInDb.Id = Movie.Id;
                movieInDb.MovieName = Movie.MovieName;
                movieInDb.ImdbRating = Movie.ImdbRating;
                
                movieInDb.Stock = Movie.Stock;
                movieInDb.ReleaseDate = Movie.ReleaseDate;
                movieInDb.DateAdded = DateTime.Now;

            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            return RedirectToAction("Index", "Movie");
        }

        [Authorize(Roles = Constants.CanManageMovie)]
        public ActionResult EditMovie(int id)
        {
            ViewBag.PageTitle = "Edit Movie";

            var MovieDetails = _context.Movies.Single(c => c.Id == id);
            var viewModel = new RandomMovieViewModel()
            {
                Genre = _context.Genre.ToList(),
                Id = MovieDetails.Id,
                MovieName = MovieDetails.MovieName,
                ReleaseDate= MovieDetails.ReleaseDate,
                ImdbRating = MovieDetails.ImdbRating,
                Stock = MovieDetails.Stock,
                GenreId = MovieDetails.GenreId

            };

            return View("MovieForm", viewModel);
        }
    }
}