using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.services.NewsService.Interface
{
    public interface IGoogleNewsService
    {
        object BingSearch(string searchItem);
        object GoogleSearch(string searchItem);
       
    }
}
