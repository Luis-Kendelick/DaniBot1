using Newtonsoft.Json;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.GetBookingByCustomerNumber.Response
{
    public class GetBookengByCustomerNumberResponse
    {
        [JsonProperty("recordLocator")]
        public string RecordLocator { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }
    }
}
