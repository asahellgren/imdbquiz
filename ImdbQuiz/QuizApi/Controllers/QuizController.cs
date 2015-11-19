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
    [RoutePrefix("api/quiz")]
    public class QuizController : ApiController
    {
        // GET: api/Quiz/RandomMovie
        [HttpGet]
        [Route("randommovie")]
        public string GetRandomMovie()
        {
            return new RandomMovie().GetRandomMovie().Title;
        }
       
        // GET: api/Quiz/RandomMovie/1989
        [HttpGet]
        [Route("randommovie/{title}/{year}")]
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
