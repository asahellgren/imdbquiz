using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuizBLL
{
    public class OmdbApiConnection
    {
        private const string Address = "http://www.omdbapi.com/?tomatoes=true&t=";

        public OmdbMovie GetOmdbMovie(string title)
        {
            var client = new WebClient();
            var fullUri = new Uri(Address + title);
            var jsonResult = client.DownloadString(fullUri);
            return JsonConverter.DeserializeObject(jsonResult);
            

        }
    }
}
