using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;

namespace QuizBLL
{
    public class Randomize
    {
        public Movie GetRandomMovie()
        {
            var rand = new Random();
            var randomNumber = rand.Next(1, 251);
            return new ImdbRepository().GetById(randomNumber);
        }

        public string[] GetRandomYears(string year)
        {
            var intYear = Convert.ToInt32(year);
            var rand = new Random();
            var yearArray = new string[3];

            for (var i = 0; i < yearArray.Length-1; i++)
            {
                int randomYear;
                do
                {
                    randomYear = rand.Next(intYear - 10, intYear + 11);
                } while (randomYear == intYear);
                yearArray[i] = randomYear.ToString();
            }
            yearArray[2] = intYear.ToString();
            string[] shuffledArray = yearArray.OrderBy(x => rand.Next()).ToArray();
            return shuffledArray;
        }
    }
}
