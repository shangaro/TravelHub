using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Models.NewsSpecific
{
    public class News
    {
        public string Title { get; set; }
        public Image Image { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

    }
}
