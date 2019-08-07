namespace Avanade.HackathonAzul.DaniBot.Localization
{
	public partial struct Localization
	{
		public RetroClaimMessages RetroClaim { get; set; }
		public RetroClaimCompanysNames RetroClaimComapnys { get; set; }
		public RetroClaimReservationCode RetroClaimReservation { get; set; }
		public RetroClaimFlightNumber RetroClaimFlight { get; set; }
		public RetroClaimOriginCity RetroClaimCity { get; set; }

		public struct RetroClaimMessages
		{
			public string Title { get; set; }
            public string Company { get; set; }
			public string DepartureDate { get; set; }
			public string DepartureDateId { get; set; }
        }

		public struct RetroClaimCompanysNames
		{
			public string Azul { get; set; }
			public string Tap { get; set; }
			public string United { get; set; }
			public string CopaAirlines { get; set; }
		}

		public struct RetroClaimReservationCode
		{
			public string ReservationCode { get; set; }
			public string ReservationCodeId { get; set; }
			public string ReservationCodePlaceHold { get; set; }
		}

		public struct RetroClaimFlightNumber
		{
			public string FlightNumber { get; set; }
			public string FlightNumberId { get; set; }
			public string FlightNumberPlaceHold { get; set; }
		}

		public struct RetroClaimOriginCity
		{
			public string OriginCity { get; set; }
			public string OriginCityId { get; set; }
			public string OriginCityPlaceHold { get; set; }
		}
	}
}
