using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieReviewSPA.web.Data.Contracts.IRepositories;
using MovieReviewSPA.web.Models;
using MovieReviewSPA.web.ViewModels.Movie;

namespace MovieReviewSPA.web.Controllers.API
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _repo;

        public MoviesController(IMovieRepository context)
        {
            _repo = context;
        }

        // GET api/movies
        [HttpGet]
        public IActionResult GetAll()
        {
            var viewModelMovies = _repo.GetAll()
                .OrderByDescending(m => m.Reviews.Count)
                .Select(m => new MovieViewModel()
                {
                    /*fixformat ignore:start */
                    Id = m.Id,
                    MovieName = m.MovieName,
                    MovieCover = m.MovieCover,
                    DirectorName = m.DirectorName,
                    ReleaseYear = m.ReleaseYear,
                    NoOfReviews = m.Reviews.Count()
                    /*fixformat ignore:end */
                });

            return Ok(viewModelMovies);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Movie movie)
        {
            _repo.Update(movie);
            _repo.Commit();
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repo.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Movie movie)
        {
            _repo.Add(movie);
            _repo.Commit();
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
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