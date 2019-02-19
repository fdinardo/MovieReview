using System.Collections.Generic;
using System.Linq;
using MovieReviewSPA.web.Models;

namespace MovieReviewSPA.web.Data.DbSeeds
{
    public class InitialData
    {
        private MovieReviewDbContext _dbContext;

        public InitialData(MovieReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            if (_dbContext.Movies.Any())
            {
                return;
            }

            var movie = new Movie()
            {
                MovieName = "Avatar",
                DirectorName = "James Cameron",
                ReleaseYear = "2009",
            };

            _dbContext.Movies.Add(movie);

            var secondMovie = new Movie()
            {
                MovieName = "Titanic",
                DirectorName = "James Cameron",
                ReleaseYear = "1997"
            };

            _dbContext.Movies.Add(secondMovie);

            var thirdMovie = new Movie()
            {
                MovieName = "Die Another Day",
                DirectorName = "Lee Tamahori",
                ReleaseYear = "2002"
            };

            _dbContext.Movies.Add(thirdMovie);

            var anotherMovieWithReview = new Movie()
            {
                MovieName = "Godzilla",
                DirectorName = "Gareth Edwards",
                ReleaseYear = "2014",
                Reviews = new List<MovieReview>()
                {
                    new MovieReview()
                    {
                        ReviewerRating = 5,
                        ReviewerComments = "Excellent",
                        ReviewerName = "Rahul Sahay"
                    },
                    new MovieReview()
                    {
                        ReviewerRating = 5,
                        ReviewerComments = "Awesome",
                        ReviewerName = "John"
                    },
                    new MovieReview()
                    {
                        ReviewerRating = 5,
                        ReviewerComments = "Mind Blowing",
                        ReviewerName = "Black Dave"
                    }
                }
            };

            _dbContext.Movies.Add(anotherMovieWithReview);
            _dbContext.MovieReviews.AddRange(anotherMovieWithReview.Reviews);
            _dbContext.SaveChanges();

        }
    }
}