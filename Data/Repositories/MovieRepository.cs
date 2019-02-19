using MovieReviewSPA.web.Data.Contracts.IRepositories;
using MovieReviewSPA.web.Models;

namespace MovieReviewSPA.web.Data.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieReviewDbContext dbContext)
            : base(dbContext) { }
    }
}