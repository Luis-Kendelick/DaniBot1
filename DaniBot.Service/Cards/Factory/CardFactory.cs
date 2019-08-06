using Avanade.HackathonAzul.DaniBot.Cards.Builders;
using Avanade.HackathonAzul.DaniBot.Cards.Builders.FAQ;
using Avanade.HackathonAzul.DaniBot.Cards.Builders.Login;
using Avanade.HackathonAzul.DaniBot.Models;

namespace Avanade.HackathonAzul.DaniBot.Cards.Factory
{
    public static class CardFactory
    {
        public static WelcomeMenuCardBuilder CreateWelcomeMenuCardBuilder()
        {
            return new WelcomeMenuCardBuilder();
        }

        public static FAQMenuCardBuilder CreateFAQMenuCardBuilder()
        {
            return new FAQMenuCardBuilder();
        }

        public static FAQViewCardBuilder CreateFAQViewCardBuilder(FAQModel fAQModel)
        {
            return new FAQViewCardBuilder(fAQModel);
        }

        public static AuthenticateCardBuilder CreateLoginCardBuilder()
        {
            return new AuthenticateCardBuilder();
        }

        public static AuthenticatedCardBuilder CreateAuthenticatedCardBuilder()
        {
            return new AuthenticatedCardBuilder();
        }

		public static AuthenticateByTextCardBuilder CreateAuthenticateByTextCardBuilder()
		{
			return new AuthenticateByTextCardBuilder();
		}
	}
}