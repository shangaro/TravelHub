using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string code { get; set; }  // IATA code
        public string name { get; set; }
        public string city_code { get; set; }
        public string city_name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Location location { get; set; }
        //public int LocationId { get; set; }
        public int aircraft_movements { get; set; }
        public string timezone { get; set; }
        public City city { get; set; }
        //public int CityId { get; set; }


    }
}
