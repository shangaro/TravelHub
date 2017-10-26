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
        public string Code { get; set; }
        public string Geonames_Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Location Location { get; set; }
        //note geo location of city is different than that of airport
        public int LocationId { get; set; }
        public string Timezone { get; set; }
    }
}
