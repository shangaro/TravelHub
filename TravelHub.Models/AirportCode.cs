using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Models
{
    public class AirportCode
    {
        public int Id { get; set; }
        public City city { get; set; }
        //public int CityId { get; set; }
        public IList<Airport> airports { get; set; }
        public int AirportId { get; set; }
    }
}
