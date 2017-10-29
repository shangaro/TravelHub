using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Models
{
    public class City
    {
        public int Id { get; set; }
        public string code { get; set; }
        public string geonames_ID { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Location location { get; set; }
        //note geo location of city is different than that of airport
        public int locationId { get; set; }
        public string timezone { get; set; }
    }
}
