namespace Avanade.HackathonAzul.DaniBot.Localization
{
	public partial struct Localization
	{
		public FAQMenuMessages FAQDialog { get; set; }
		public FAQViewMessages FAQView { get; set; }

		public struct FAQMenuMessages
		{
			public string URL { get; set; }
			public string Title { get; set; }
            public string CheckIn { get; set; }
			public string CheckInTitle { get; set; }
			public string TudoAzul { get; set; }
			public string TudoAzulTitle { get; set; }
			public string Dani { get; set; }
			public string DaniTitle { get; set; }
		}

		public struct FAQViewMessages
		{
			public string ContentCheckIn { get; set; }
			public string UrlCheckIn { get; set; }
			public string ContentTudoAzul { get; set; }
			public string UrlTudoAzul { get; set; }
			public string ContentDani { get; set; }
			public string UrlDani { get; set; }

		}
	}
}
