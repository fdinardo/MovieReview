using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieReviewSPA.web.Data.Contracts.IRepositories;
using MovieReviewSPA.web.Models;

namespace MovieReviewSPA.web.Controllers.API
{
    [Route("api/[controller]")]
    public class MovieReviewsController : Controller
    {
        private readonly IMovieReviewRepository _repo;

        public MovieReviewsController(IMovieReviewRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reviews = _repo.GetAll()
                .OrderBy(m => m.MovieId);

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = _repo.GetAll()
                .Where(m => m.MovieId == id);

            return Ok(review);
        }

        // GET: /api/moviereviews/getbyreviewer?name=<Spielberg>
        [HttpGet("[action]")]
        public IActionResult GetByReviewer(string name)
        {
            var reviewsByReviewer = _repo.GetAll().Where(m => m.ReviewerName.StartsWith(name));
            if (reviewsByReviewer == null || reviewsByReviewer?.Count() == 0)
            {
                return NotFound();
            }

            return Ok(reviewsByReviewer);
        }

        [HttpPut]
        public IActionResult Update([FromBody] MovieReview review)
        {
            _repo.Update(review);
            _repo.Commit();
            return NoContent();
        }

        [HttpPost("{id}")]
        public IActionResult Create(int id, [FromBody] MovieReview review)
        {
            review.MovieId = id;
            _repo.Add(review);
            _repo.Commit();

            return CreatedAtAction(nameof(Get), new { id = review.Id }, review);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            _repo.Commit();

            return NoContent();
        }
    }
}