using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Booking.Response
{
    public class BookingCommitResponse
    {
        [JsonProperty("bookingKey")]
        public string BookingKey { get; set; }

        [JsonProperty("recordLocator")]
        public string RecordLocator { get; set; }

        [JsonProperty("breakdown")]
        public Breakdown Breakdown { get; set; }
    }

    public class Breakdown
    {
        [JsonProperty("balanceDue")]
        public decimal? BalanceDue { get; set; }

        [JsonProperty("pointsBalanceDue")]
        public decimal? PointsBalanceDue { get; set; }

        [JsonProperty("authorizedBalanceDue")]
        public decimal AuthorizedBalanceDue { get; set; }

        [JsonProperty("totalAmount")]
        public decimal? TotalAmount { get; set; }
    }
}
