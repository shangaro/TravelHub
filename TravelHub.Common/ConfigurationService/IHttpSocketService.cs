using System.Net.Http;

namespace TravelHub.Common.ConfigurationService
{
    public interface IHttpSocketService
    {
        
        HttpClient GetClient();

    }
}