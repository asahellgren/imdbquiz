using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using QuizApi.Models;
using QuizBLL;
using Repositories;

namespace QuizApi.Controllers
{
    [RoutePrefix("api/quiz")]
    public class QuizController : ApiController
    {
        // GET: api/Quiz/RandomMovie
        [HttpGet]
        [Route("randommovie")]
        public RandomMovieDto GetRandomMovie()
        {
            var randomMovie = new Randomize().GetRandomMovie();
            var omdbMovie = new OmdbApiConnection().GetOmdbMovie(randomMovie.Title);


            return new RandomMovieDto
            {
                ImdbRating = omdbMovie.imdbRating,
                PosterUrl = omdbMovie.Poster,
                Title = omdbMovie.Title,
                TomatoRating = omdbMovie.tomatoRating
            };
        }

        [HttpGet]
        [Route("randommovie/moreinfo/{title}")]
        public MetaDataClueDto GetMoreInfo(string title)
        {

            var omdbMovie = new OmdbApiConnection().GetOmdbMovie(title);



            return new MetaDataClueDto
            {
                Actors = omdbMovie.Actors,
                Awards = omdbMovie.Awards,
                Country = omdbMovie.Country,
                Director = omdbMovie.Director,
                Genre = omdbMovie.Genre,
                Plot = omdbMovie.Plot,
                Title = omdbMovie.Title,
                Writer = omdbMovie.Writer
            };
        }

        [HttpGet]
        [Route("randommovie/yearoption/{title}")]
        public YearOptionsClue GetYearOption(string title)
        {
            var omdbMovie = new OmdbApiConnection().GetOmdbMovie(title);
            return new YearOptionsClue
            {
                Years = new Randomize().GetRandomYears(omdbMovie.Year)
            };
        }

        // GET: api/Quiz/RandomMovie/1989
        [HttpGet]
        [Route("randommovie/{title}&{year}")]
        public string GetResult(string title, string year)
        {
            var movie = new ImdbRepository().GetByTitle(title);
            return movie.Year == year ? "Correct" : "Wrong, the year is " + movie.Year;
        }

        // POST: api/Quiz
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Quiz/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Quiz/5
        public void Delete(int id)
        {
        }
    }
}
