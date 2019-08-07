using Newtonsoft.Json;
using System;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Login.Request
{
    public class LogonRequest
    {
        [JsonProperty("credentials")]
        public CredentialsLogonRequest credentials { get; set; }

        [JsonProperty("applicationName")]
        public string applicationName { get; set; }
    }

    public class CredentialsLogonRequest
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("alternateIdentifier")]
        public string AlternateIdentifier { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("channelType")]
        public string ChannelType { get; set; }
    }
}
