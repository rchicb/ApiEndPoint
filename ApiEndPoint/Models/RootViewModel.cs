
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEndPoint.Models
{
    public class RootViewModel
    {

        [JsonProperty(PropertyName = "resultCount")]
        public int resultCount { get; set; }

        [JsonProperty(PropertyName = "results")]
        public object[] results { get; set; }

    }

    public class Root2ViewModel
    {
        //public List<object> data { get; set; }
        
       
        public string score { get; set; }
        public object show { get; set; }
        /*
        [JsonProperty(PropertyName = "image")]
        public object[] image { get; set; }
        */
    }


}
