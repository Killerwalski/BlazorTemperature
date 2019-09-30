using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemperatureApi.Models;

namespace BlazorTemperature.Data
{
    public class TemperatureDataService
    {
        private readonly IHttpClientFactory _clientFactory;
        // Feels like this will need an httpclient to access https://localhost:44370/
        // Or wherever our API is exposed


        public TemperatureDataService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<TemperatureEntry[]> GetTemperaturesAsync()
        {
            List<TemperatureEntry> temps = new List<TemperatureEntry>();
            
            var request = new HttpRequestMessage(HttpMethod.Get,
           "https://localhost:44370/api/temperatureEntries");
            // request.Headers.Add("Accept", "application/vnd.github.v3+json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                temps = JsonConvert.DeserializeObject<List<TemperatureEntry>>(result);
            }

            temps = temps.Where((x, i) => i % 50 == 0).ToList();
            return temps.ToArray();
        }
    }
}
