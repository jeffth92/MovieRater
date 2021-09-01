using MovieRater.Data;
using MovieRater.Models.RatingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class RatingService
    {
  private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMovieRating(CreateMovieRating model)
        {
            var entity =
                new Rating()
                {
                    OwnerID = _userId,
                    MovieID = model.MovieID,
                    RatingStar = model.RatingStar,
                    Comment = model.Comment
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateShowRating(CreateShowRating model)
        {
            var entity =
                new Rating()
                {
                    OwnerID = _userId,
                    ShowID = model.ShowID,
                    RatingStar = model.RatingStar,
                    Comment = model.Comment
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RatingListItem> GetRatingsByMovieID(int movieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ratings
                        .Where(e => e.MovieID == movieId)
                        .Select(
                            e =>
                                new RatingListItem
                                {
                                    MovieID = e.MovieID,
                                    Ratings = new List<Rating>(),
                                    Title = e.Movie.Title
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
