using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImdbQuiz;

namespace Repositories
{
    public class ScoreRepository
    {

        private readonly ImdbContext _context;

        public ScoreRepository()
        {
            _context = new ImdbContext();
        }

        public List<GameScore> GetAll()
        {
            List<Score> movieList = _context.Scores.ToList();
            return movieList.Select(ConvertToGameScoreObject).ToList();
        }

        public void PostScore(GameScore score)
        {
            var scoreToAdd = new Score
            {
                Score1 = score.Score1,
                Name = score.Name
            };

            _context.Scores.Add(scoreToAdd);
            _context.SaveChanges();
        }


        private GameScore ConvertToGameScoreObject(Score score)
        {
            return new GameScore
            {
                Score1 = score.Score1,
                Name = score.Name
            };
        }
    }
}
