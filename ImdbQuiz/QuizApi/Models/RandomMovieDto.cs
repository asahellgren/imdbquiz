using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApi.Models
{
    public class RandomMovieDto
    {
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string ImdbRating { get; set; }
        public string TomatoRating { get; set; }

    }
}