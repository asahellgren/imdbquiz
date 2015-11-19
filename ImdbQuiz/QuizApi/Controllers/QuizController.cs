using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using QuizBLL;
using Repositories;

namespace QuizApi.Controllers
{
    public class QuizController : ApiController
    {
        private Movie _randomMovie;

        // GET: api/Quiz/RandomMovie

        [HttpGet]
        [GET("Quiz/GetRandomMovie/")]
        public string GetRandomMovie()
        {
            _randomMovie = new RandomMovie().GetRandomMovie();
            return _randomMovie.Title;
        }
       
        // GET: api/Quiz/RandomMovie
        [HttpGet]
        [GET("Quiz/GetRandomMovie/{year}")]
        public string GetRandomMovie(string year)
        {
            
            return _randomMovie.Year == year ? "Correct answer" : "Wrong answer, the year is " + _randomMovie.Year;
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
