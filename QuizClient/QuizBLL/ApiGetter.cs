using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuizBLL
{
    public class ApiGetter
    {

        const string Uri = "http://localhost:63998/api/quiz/randommovie/";

        public async Task<RandomMovie> GetRandomMovieAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(Uri);
                var jsonObject = await (response.Content.ReadAsStringAsync());
                return JsonConvert.DeserializeObject<RandomMovie>(jsonObject);
            }
        }
    }
}
