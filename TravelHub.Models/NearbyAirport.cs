using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Models
{
    public class NearbyAirport
    {
        //primary key
        public int id { get; set; }

        public string airportcode { get; set; }
        public string airportname { get; set; }
        public string cityname { get; set; }
        public string distance { get; set; }
        public Location location { get; set; }
        public int aircraftmovement { get; set; }
        // timezone
        public string timezone { get; set; }
    }
}
