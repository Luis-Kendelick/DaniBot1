using System;

namespace Avanade.HackathonAzul.DaniBot.Models
{
    public class FlightInformationModel
    {
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string Number { get; set; }
        public FlightStatus Status { get; set; }
    }
}