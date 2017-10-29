using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHub.services.FlightService.Interfaces;

namespace TravelHub.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Location")]
    public class LocationController : Controller
    {
        private readonly IFlightSearchService _flightSearchService;
        public LocationController()
        {
            _flightSearchService.get
        }
    }

    