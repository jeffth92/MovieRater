using MovieRater.Data;
using MovieRater.Models.ShowModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class ShowService
    {
        private readonly Guid _userId;

        public ShowService(Guid userId)
        {
            _userId = userId;
        }

        
        public bool CreateShow(CreateShow model)
        {
            var entity =
                new Show()
                {
                    OwnerID = _userId,
                    Title = model.Title,
                    Description = model.Description,
                    NumberOfSeasons = model.NumberOfSeasons,
                    Genres = new List<Genre>()              //not sure if this is correct for adding a genre or genres when creating a show?
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        
        public IEnumerable<ShowListItem> GetAllShows()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Shows
                    .Where(e => e.OwnerID == _userId)
                    .Select(e =>
                    new ShowListItem
                    {
                        ShowId = e.ShowID,
                        Title = e.Title,
                        AverageRating = e.Ratings.Average(a => a.RatingStar)
                    });
                return query.ToArray();
            }
        }

        //public IEnumerable<ShowListItem> GetShowsRatedHighestToLowest()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .Shows
        //            .Where(e => e.OwnerID == _userId)
        //            .Select(e =>
        //            new ShowListItem
        //            {
        //                ShowId = e.ShowID,
        //                Title = e.Title,
        //                AverageRating = e.Ratings.Average(a => a.RatingStar)        //get average rating?
        //            });
        //        return query.ToArray();
        //    }
        //}
    }
}
