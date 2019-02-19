using Microsoft.EntityFrameworkCore;
using MovieReviewSPA.web.Models;

namespace MovieReviewSPA.web.Data {
    public class MovieReviewDbContext : DbContext {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieReview> MovieReviews { get; set; }
        public MovieReviewDbContext(DbContextOptions<MovieReviewDbContext> options)
            : base(options) { }
    }
}