using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Models
{
    public class ApiKey
    {
        public int id { get; set; }
        public string apiKey { get; set; }
        public bool Active { get; set; }
        public string ApiSource { get; set; }

    }
}

