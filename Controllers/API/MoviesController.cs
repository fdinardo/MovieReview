using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieReviewSPA.web.Data.Contracts.IRepositories;
using MovieReviewSPA.web.Models;
using System.Collections.Generic;

namespace MovieReviewSPA.web.Controllers.API
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _repo;

        public MoviesController(IMovieRepository context)
        {
            _repo = context;
        }

        // GET api/movies
        [HttpGet("api/movies")]
        public IEnumerable<Movie> Get()
        {
            return _repo.GetAll();
        }

        [HttpPut("api/movies")]
        public IActionResult Update([FromBody] Movie movie)
        {
            _repo.Update(movie);
            return NoContent();
        }
    }
}