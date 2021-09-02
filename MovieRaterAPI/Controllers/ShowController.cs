using Microsoft.AspNet.Identity;
using MovieRater.Models.ShowModels;
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
    public class ShowController : ApiController
    {
        public IHttpActionResult Post(CreateShow show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.CreateShow(show))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get()
        {
            ShowService showService = CreateShowService();
            var shows = showService.GetAllShows();
            return Ok(shows);
        }
        private ShowService CreateShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var showService = new ShowService(userId);
            return showService;
        }
    }
}
