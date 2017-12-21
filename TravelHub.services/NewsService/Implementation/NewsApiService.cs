using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using TravelHub.Common.ConfigurationService;
using TravelHub.Models;

namespace TravelHub.services.NewsService.Implementation
{
    public class NewsApiService:INewsApiService
    {
        private readonly IHttpSocketService _httpSocketService;

        public NewsApiService(IHttpSocketService httpSocketService)
        {
            _httpSocketService = httpSocketService;
        }


        public string GetTopHeadLines(string sourceName)
        {
            
            string apiKey = ApiKeyRegistry.NewsApiKey;
            //var serialize = new DataContractJsonSerializer(typeof(object));
            var url = "top-headlines" + $"?sources={sourceName}" + $"&apiKey={apiKey}";
            var client = _httpSocketService.GetClient();
            var stream = client.GetStreamAsync(url).Result;
            string json = new StreamReader(stream).ReadToEnd();
            return json;

            //WebRequest webRequest = WebRequest.Create(url);
            //HttpWebResponse response = (HttpWebResponse)webRequest.GetResponseAsync().Result;
            //Stream stream = new StreamReader(response.GetResponseStream()).BaseStream;
        }
    }
}
