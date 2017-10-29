using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Remotion.Linq.Clauses.ResultOperators;
using TravelHub.services.FlightService.Interfaces;

namespace TravelHub.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/AirportLocation")]
    public class AirportLocationController : Controller
    {
        private readonly IFlightSearchService _flightSearchService;

        public AirportLocationController(IFlightSearchService flightSearchService)
        {
            _flightSearchService = flightSearchService;
        }

        [HttpGet("")]
        public JsonResult GetAirPortLocation()
        {
            var codes = _flightSearchService.GetLocationByIATA("par");

            var json=new JsonResult(codes);
            return json;
        }
    }
}