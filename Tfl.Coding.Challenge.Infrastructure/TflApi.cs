using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Tfl.Coding.Challenge.Infrastructure
{
    public class TflApi : ITflApi
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public TflApi (IConfiguration config)
        {
            _config = config;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri (_config["BaseUrl"]);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public async Task<RoadStatusModel> Status(string id, CancellationToken token = default)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri($"road/{id}?app_id={_config["AppId"]}&app_key={_config["AppKey"]}", UriKind.Relative));
            HttpResponseMessage response = await _httpClient.SendAsync(request, token);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var roadStatusModel = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<RoadStatusModel>>(roadStatusModel);
                result[0].SuccessCode = response.StatusCode.ToString();
                return result[0];
            }
            else
            {
                return new RoadStatusModel { Id= id, SuccessCode = response.StatusCode.ToString()};
            }
        }
    }
}
