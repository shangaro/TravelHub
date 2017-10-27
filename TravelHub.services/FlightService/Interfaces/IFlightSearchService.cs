using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TravelHub.Models;

namespace TravelHub.services.FlightService.Interfaces
{
    public interface IFlightSearchService
    {
        //void GetFlightXtensiveSearch();
        //void GetFlightLowFareSearch();
        //void GetFlightAffiliateSearch();
        //NearbyAirport GetNearbyAirport(decimal latitude, decimal longtitube, string apiKey);
        object GetIataCode(string iatacode);

    }
}
