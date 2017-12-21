using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Models.NewsSpecific
{
    public class SearchItem
    {
        public string Category { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public string NewsPaperAgency { get; set; }
    }
}
