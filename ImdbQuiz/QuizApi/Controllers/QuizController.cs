using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApi.Models;
using QuizBLL;
using Repositories;
using System.Web.Http.Cors;

namespace QuizApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = false)]
    [RoutePrefix("api/quiz")]
    public class QuizController : ApiController
    {

        /// <summary>
        /// Returns only the title of a imdb 250 movie.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("RandomImdbMovie")]
        public string GetRandomImdbMovie()
        {
            var randomMovie = new Randomize().GetRandomMovie();
            return randomMovie.Title;

        }

        /// <summary>
        ///  Returns a random movie from the IMDB top 250.
        /// Shows only basic data such as title, poster and reviews
        /// </summary>
        /// <returns></returns>     
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
        /// <summary>
        /// To be used as a first "clue". Returns meta data about the movie such as director, actors, plot etc.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
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
                Writer = omdbMovie.Writer
            };
        }

        /// <summary>
        /// To bue used as a second clue and returns an array of three different options, randomized within a 10 year span.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Will check if guess is correct and return string "true", else return the correct year (yyyy).
        /// </summary>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("randommovie/{title}/{year}")]
        public string GetResult(string title, string year)
        {
            var movie = new ImdbRepository().GetByTitle(title);
            return movie.Year == year ? "True" : movie.Year;
        }

        /// <summary>
        /// Returns Top 10 current high scores with name and score
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("randommovie/gethighscore/")]
        public GameScore[] GetHighScore()
        {
            return new ScoreRepository().GetAll().OrderBy(x => x.Score1).Take(10).ToArray();
        }

        /// <summary>
        /// Posts the final result after 20 rounds to the score board. 
        /// </summary>
        /// <param name="score"></param>
        [HttpPost]
        [Route("randommovie/")]
        public IHttpActionResult PostScore([FromBody]string score)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameScore = JsonConvert.DeserializeObject<GameScore>(score);
           new ScoreRepository().PostScore(gameScore);

           return CreatedAtRoute("DefaultApi", new { id = gameScore.Score1 }, score);
        }


    }
}
