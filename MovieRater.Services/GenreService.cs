using MovieRater.Data;
using MovieRater.Models.GenreModles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class GenreService
    {
        private readonly Guid _userID;

        public GenreService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateGenre(GenreCreate model)
        {
            var entity =
                new Genre()
                {
                    OwnerID = _userID,
                    GenreID = model.GenreID,
                    GenreName = model.GenreName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GenreDetail> GetGenreByName(int GenreName) //once used GenreID, but was swapped to GenreName for ease of search
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Genres
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new GenreDetail
                                {
                                    GenreName = e.GenreName
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<GenreListItem> GetAllGenre()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Genres
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                        new GenreListItem
                        {
                            GenreID = e.GenreID,
                            GenreName = e.GenreName,
                        }
                );

                return query.ToArray();
            }
        }
    }
}
