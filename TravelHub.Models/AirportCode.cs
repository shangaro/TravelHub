using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Models
{
    public class AirportCode
    {
        public City City { get; set; }
        //public int CityId { get; set; }
        public IList<Airport> Airports { get; set; }
        //public int AirportId { get; set; }
    }
}
