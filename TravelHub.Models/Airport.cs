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
        public string Code { get; set; }  // IATA code
        public string Name { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Location Location { get; set; }
        //public int LocationId { get; set; }
        public int AircraftMovements { get; set; }
        public string Timezone { get; set; }
        public City City { get; set; }
        //public int CityId { get; set; }


    }
}
