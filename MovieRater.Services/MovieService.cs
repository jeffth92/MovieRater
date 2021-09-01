using MovieRater.Data;
using MovieRater.Models.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class MovieService
    {
        private readonly Guid _userId;
        public MovieService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMovie(MovieCreate model)
        {
            var entity =
                new Movie()
                {
                    OwnerID = _userId,
                    Title = model.Title,
                    Description = model.Description,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MovieListItem> GetAllMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Movies
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new MovieListItem
                        {
                            Id = e.MovieID,
                            Title = e.Title,
                        }
                );

                return query.ToArray();
            }
        }
    }
}
