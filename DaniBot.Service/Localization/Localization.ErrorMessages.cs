namespace Avanade.HackathonAzul.DaniBot.Localization
{
	public partial struct Localization
	{
		public ErrorMessages Error { get; set; }
		public struct ErrorMessages
		{
			public string TooManyAttempts { get; set; }
			public string AccessDenied { get; set; }
			public string InternalServerError { get; set; }
			public string WrongUserAndPassword { get; set; }
		}
	}
}
