using Avanade.HackathonAzul.DaniBot.Cards.Builders;

namespace Avanade.HackathonAzul.DaniBot.Cards.Factory
{
    public static class CardFactory
    {
		public static WelcomeCardBuilder CreateWelcomeCardBuilder()
		{
			return new WelcomeCardBuilder();
		}

		public static FAQCardBuilder CreateFAQCardBuilder()
		{
			return new FAQCardBuilder();
		}
	}
}