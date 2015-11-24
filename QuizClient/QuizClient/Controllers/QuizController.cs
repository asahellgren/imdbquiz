using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using QuizBLL;

namespace QuizClient.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public async Task<ActionResult> Index()
        {
            RandomMovie movie;
            do
            {
                ViewBag.SyncOrAsync = "Asynchronous";
                var apiGetter = new ApiGetter();
                movie = await apiGetter.GetRandomMovieAsync();
            } while (movie.Title == null);
            
            return View(movie);


        }

        public async Task<ActionResult> GetMoreInfoClue(string title)
        {
            ViewBag.SyncOrAsync = "Asynchronous";
            var apiGetter = new ApiGetter();
            return View(await apiGetter.GetMetaDataAsync(title));
        }
    }
}