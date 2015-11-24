using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApi.Models
{
    public class MetaDataClueDto
    {        
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
    }
}
