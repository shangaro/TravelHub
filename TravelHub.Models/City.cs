using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Models
{
    public class City
    {
        public string Code { get; set; }
        public string Geonames_ID { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Location location { get; set; }
        public string timezone { get; set; }
    }
}
