using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Movie
    {
        public int Id { get; set; }
        public int? Votes { get; set; }
        public decimal? Rank { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
    }
}

