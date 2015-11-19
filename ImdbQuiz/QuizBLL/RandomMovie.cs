using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;

namespace QuizBLL
{
    public class RandomMovie
    {
        public Movie GetRandomMovie()
        {
            var random = new Random();
            var randomNumber = random.Next(1, 251);
            return new ImdbRepository().GetById(randomNumber);
        }

        

    }
}
