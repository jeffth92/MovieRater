using Microsoft.AspNet.Identity;
using MovieRater.Models.RatingModels;
using MovieRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRaterAPI.Controllers
{
    [Authorize]
    public class RatingController : ApiController
    {
        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ratingService = new RatingService(userId);
            return ratingService;
        }
        [Route("api/rating/{movieID}")]
        public IHttpActionResult GetMovie(int movieID)
        {
            RatingService ratingService = CreateRatingService();
            var rating = ratingService.GetRatingsByMovieID(movieID);
            return Ok(rating);
        }
        //[Route("api/rating/{showID}")]
        //public IHttpActionResult GetShow(int showID)
        //{
        //  RatingService ratingService = CreateRatingService();
        //   var rating = ratingService.GetRatingsByShowID(showID);
        //   return Ok(rating);
        //}

        /*public IHttpActionResult Post(CreateMovieRating rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRatingService();

            if (!service.CreateMovieRating(rating))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Post(CreateShowRating rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRatingService();

            if (!service.CreateShowRating(rating))
                return InternalServerError();

            return Ok();
        }*/
    }
}
