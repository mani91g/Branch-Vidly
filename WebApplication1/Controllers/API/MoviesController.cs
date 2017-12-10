using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.DTOs;
using AutoMapper;

namespace WebApplication1.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.Include(c=> c.Genre).ToList().Select(Mapper.Map<Movies,MovieDTO>));
        }

        [Authorize(Roles = Constants.CanManageMovie)]
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList().Single(c => c.Id == id);

            if (!ModelState.IsValid)
                return BadRequest();

            if (movie == null)
                return NotFound();
                
            return Ok(Mapper.Map<Movies, MovieDTO>(movie));
        }

        //POST /api/movies
        [HttpPost]
        [Authorize(Roles = Constants.CanManageMovie)]
        public IHttpActionResult CreateMovies(MovieDTO movieDto)
        {            

            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movies>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);

        }


        [HttpPut]
        [Authorize(Roles = Constants.CanManageMovie)]
        public IHttpActionResult updateMovie(int id, MovieDTO movieDto)
        {
            var movieInDb = _context.Movies.ToList().Single(m => m.Id == id);

            if (!ModelState.IsValid)
                return BadRequest();

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok(movieInDb);

        }

        [HttpDelete]
        [Authorize(Roles = Constants.CanManageMovie)]
        public IHttpActionResult deleteMovie(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.ToList().Single(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
