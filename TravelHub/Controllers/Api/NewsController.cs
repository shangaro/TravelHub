using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHub.services.NewsService.Implementation;

namespace TravelHub.Web.Controllers.Api
{
    [Produces("application/json")]
   
    public class NewsController : Controller
    {
        private readonly INewsApiService _newsApiService;
        public NewsController(INewsApiService newsApiService)
        {
            _newsApiService = newsApiService;
        }

        [HttpGet]
        [Route("api/News/GetTopHeadlines/{source}")]
        public ActionResult GetTopHeadlines(string source)
        {
            return Content(_newsApiService.GetTopHeadLines(source),"application/json");
        }
    }
}