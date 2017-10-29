using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Security.Permissions;
using System.Threading.Tasks;
using TravelHub.Common.ConfigurationService;
using TravelHub.Models;
using TravelHub.services.FlightService.Interfaces;

namespace TravelHub.services.FlightService.Implementation
{
    public class FlightSearchService:IFlightSearchService
    {
        private readonly IHttpSocketService _httpSocketService;

        public FlightSearchService(IHttpSocketService httpSocketService)
        {
            _httpSocketService = httpSocketService;
        }
       
        public void GetFlightXtensiveSearch()
        {
            throw new System.NotImplementedException();
        }

        public void GetFlightLowFareSearch()
        {
            throw new System.NotImplementedException();
        }

        public void GetFlightAffiliateSearch()
        {
            throw new System.NotImplementedException();
        }

        public NearbyAirport GetNearbyAirport(decimal latitude, decimal longtitube, string apiKey)
        {
            throw new System.NotImplementedException();
        }

        public object GetLocationByIATA(string IATA)
        {
            var serialize = new DataContractJsonSerializer(typeof(AirportCode));
            var client = _httpSocketService.GetClient();
            var url = IATA + "/?apikey=" + ApiKeyRegistry.AmdApiKey;
            var streamTask = client.GetStreamAsync(url).Result;

            object code = serialize.ReadObject(streamTask) as AirportCode;
            return code;
        }
    }
}
