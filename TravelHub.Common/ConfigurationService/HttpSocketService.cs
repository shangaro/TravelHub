using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TravelHub.Models;

namespace TravelHub.Common.ConfigurationService
{
    public class HttpSocketService:IHttpSocketService
    {
        public HttpClient Client;
        private static readonly string BaseUrl = ApiEndpoints.NewsAPIBaseUri;
        public HttpSocketService()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };

            Initialize();
        }
        private void Initialize()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

        }

        public HttpClient GetClient() => Client;
    }
}
