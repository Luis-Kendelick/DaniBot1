using Avanade.HackathonAzul.DaniBot.Cards.Builders;
using Avanade.HackathonAzul.DaniBot.Cards.Builders.FAQ;

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