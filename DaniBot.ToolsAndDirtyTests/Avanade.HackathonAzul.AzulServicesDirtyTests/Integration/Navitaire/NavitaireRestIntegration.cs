using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests.Integration.Navitaire
{
    public class NavitaireRestIntegration
    {
        protected static string Uri = "https://adtestr3xdotrezapi.navitaire.com";

        private HttpClient _client;


        public NavitaireRestIntegration()
        {
            _client = new HttpClient() { BaseAddress = new Uri(Uri) };
        }

        public async Task<string> RequestAsync(HttpMethod httpMethod, string uri, object content, string token = null)
        {
            HttpResponseMessage response = null;

            string result = null;

            if (!string.IsNullOrWhiteSpace(token))
            {
                _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
            }

            switch (httpMethod.Method)
            {
                case "DELETE":
                    response = await _client.DeleteAsync(uri);
                    break;
                case "GET":
                    response = await _client.GetAsync(uri);
                    break;
                default:
                    var contentRequest = (content is string) ? (content as string) : JsonConvert.SerializeObject(content);
                    var httpContent = new StringContent(contentRequest, Encoding.UTF8, "application/json");
                    response = (httpMethod == HttpMethod.Post) ? await _client.PostAsync(uri, httpContent) : await _client.PutAsync(uri, httpContent);
                    break;
            }

            if (response != null)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}
