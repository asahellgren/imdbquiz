using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Repositories;

namespace QuizBLL
{
    public class JsonConverter
    {
        public static OmdbMovie DeserializeObject(string json)
        {
            return JsonConvert.DeserializeObject<OmdbMovie>(json);
        }

        public static string SerializeObject(OmdbMovie movie)
        {
            return JsonConvert.SerializeObject(movie);
        }
    }
}
