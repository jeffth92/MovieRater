using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieRater.Services;
using MovieRater.Models;
using MovieRater.Models.MovieModels;
using Microsoft.AspNet.Identity;

namespace MovieRaterAPI.Controllers
{
    [Authorize]
    public class MovieController : ApiController
    {
        public IHttpActionResult Get()
        {
            MovieService movieService = CreateMovieService();
            var movie = movieService.GetAllMovies();
            return Ok(movie);
        }
        public IHttpActionResult Movie(MovieCreate movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMovieService();

            if (!service.CreateMovie(movie))
                return InternalServerError();

            return Ok();
        }
        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var movieService = new MovieService(userId);
            return movieService;
        }
    }
}
