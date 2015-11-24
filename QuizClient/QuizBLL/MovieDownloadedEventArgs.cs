using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBLL
{
    public class MovieDownloadedEventArgs : EventArgs
    {
        private readonly string _jsonObject;

         public string JsonObject
        {
            get { return _jsonObject; }
        }

        public MovieDownloadedEventArgs(string jsonObject)
        {
            _jsonObject = jsonObject;
        }
    }
}
