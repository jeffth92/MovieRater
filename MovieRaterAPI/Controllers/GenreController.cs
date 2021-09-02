using Microsoft.AspNet.Identity;
using MovieRater.Models.GenreModles;
using MovieRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRaterAPI.Controllers
{
    public class GenreController : ApiController
    {
        private GenreService CreateGenreService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var genreService = new GenreService(userID);
            return genreService;
        }
        public IHttpActionResult Post(GenreCreate genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();

            if (!service.CreateGenre(genre))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get() //get all genres 
        {
            GenreService genreService = CreateGenreService();
            var genres = genreService.GetAllGenre();
            return Ok(genres);
        }
        public IHttpActionResult GetShowsMoviesByGenre(int ID) //get all by which genre
        {
            GenreService genreService = CreateGenreService();
            var showsMovies = genreService.GetGenreByName(ID);
            return Ok(showsMovies);
        }
    }
}
