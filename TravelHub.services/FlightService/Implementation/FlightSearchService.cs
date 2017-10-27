using System.Configuration;
using System.Net;
using System.Net.Http;
using Microsoft.IdentityModel.Protocols;
using TravelHub.services.FlightService.Interfaces;

namespace TravelHub.services.FlightService.Implementation
{
    public class FlightSearchService:IFlightSearchService
    {
        
        public object GetIataCode(string iatacode)
        {
           HttpClient client=new HttpClient();
           

        }
    }
}
