using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ImdbQuiz;

namespace Repositories
{
    public class ImdbRepository
    {
        private readonly ImdbContext _context;

        public ImdbRepository()
        {
            _context = new ImdbContext();
        }

        public List<Movie> GetAll()
        {
            List<top250imdb> movieList = _context.top250imdb.ToList();
            return movieList.Select(ConvertToMovieObject).ToList();
        }

        public Movie GetByTitle(string title)
        {
            return ConvertToMovieObject(_context.top250imdb.SingleOrDefault(x => x.Title == title));

        }

        public Movie GetById(int id)
        {
            return ConvertToMovieObject(_context.top250imdb.SingleOrDefault(x => x.Id == id));
        }

        private Movie ConvertToMovieObject(top250imdb movie)
        {
            return new Movie
            {
                Rank = movie.Rank,
                Title = movie.Title,
                Votes = movie.Votes,
                Year = movie.Year
            };
        }
    }
}
