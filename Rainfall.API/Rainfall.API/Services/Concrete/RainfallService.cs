using Newtonsoft.Json;
using Rainfall.API.Models;
using Rainfall.API.Services.Abstract;
using System.Net.Http.Headers;

namespace Rainfall.API.Services.Concrete
{
    public class RainfallService: IRainfallService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string RainfallBaseURL = "https://environment.data.gov.uk";

        public RainfallService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<RainfallResponse> GetRainfallResponse(string stationId)
        {
            try
            {
                var client = CreateClient();

                var response = await client.GetAsync($"/flood-monitoring/id/stations/{stationId}/readings?_sorted&_limit=100");

                if (response.Content != null)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(stringResponse) && stringResponse != null)
                    {
                        return JsonConvert.DeserializeObject<RainfallResponse>(stringResponse);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private HttpClient CreateClient()
        {
            var clientFactory = _clientFactory.CreateClient();

            clientFactory.BaseAddress = new Uri(RainfallBaseURL);
            clientFactory.DefaultRequestHeaders.Accept.Clear();
            clientFactory.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return clientFactory;
        }
    }
}
