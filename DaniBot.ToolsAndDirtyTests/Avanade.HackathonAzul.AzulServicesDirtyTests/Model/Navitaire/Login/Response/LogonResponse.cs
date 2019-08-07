using Newtonsoft.Json;
using System;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Login.Response
{
    public class LogonResponse
    {
        [JsonProperty("data")]
        public DataResponse Data { get; set; }

        [JsonProperty("metadata")]
        public MetadataResponse Metadata { get; set; }
    }

    public class DataResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("idleTimeoutInMinutes")]
        public int IdleTimeoutInMinutes { get; set; }
    }

    public class MetadataResponse
    {
        [JsonProperty("documentation_url")]
        public string Documentation_url { get; set; }
    }
}
