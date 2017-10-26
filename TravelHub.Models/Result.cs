using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Models
{
    public class Result
    {
        public string destination { get; set; }
        public DateTime departure_date { get; set; }
        public DateTime return_date { get; set; }
        public string price { get; set; }
        public string airline { get; set; }

    }
}
