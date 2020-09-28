using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace json2mssql
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Datum
    {
        public string countrycode { get; set; }
        public string date { get; set; }
        public string cases { get; set; }
        public string deaths { get; set; }
        public string recovered { get; set; }
    }

    class Corona
    {
        public List<Datum> data { get; set; }
        public List<string> tokens { get; set; }
    }
}
