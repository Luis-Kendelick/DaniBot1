using Avanade.HackathonAzul.DaniBot.Cards.Builders;
using Avanade.HackathonAzul.DaniBot.Cards.Builders.FAQ;
using Avanade.HackathonAzul.DaniBot.Cards.Builders.Login;

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

		public static AuthenticateCardBuilder CreateLoginCardBuilder()
		{
			return new AuthenticateCardBuilder();
		}

		public static AuthenticatedCardBuilder CreateAuthenticatedCardBuilder()
		{
			return new AuthenticatedCardBuilder();
		}
	}
}