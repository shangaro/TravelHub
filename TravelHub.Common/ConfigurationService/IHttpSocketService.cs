using System.Net.Http;

namespace TravelHub.Common.ConfigurationService
{
    public interface IHttpSocketService
    {
        void Initialize();
        HttpClient GetClient();

    }
}