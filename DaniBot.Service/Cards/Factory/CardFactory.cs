using Avanade.HackathonAzul.DaniBot.Cards.Builders.AuthenticatedMenu;
using Avanade.HackathonAzul.DaniBot.Cards.Builders.FAQ;
using Avanade.HackathonAzul.DaniBot.Cards.Builders.Login;
using Avanade.HackathonAzul.DaniBot.Cards.Builders.WelcomeMenu;
using Avanade.HackathonAzul.DaniBot.Models;
using System.Collections.Generic;

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

        public static FAQViewCardBuilder CreateFAQViewCardBuilder(FAQViewModel fAQModel)
        {
            return new FAQViewCardBuilder(fAQModel);
        }

        public static AuthenticateCardBuilder CreateLoginCardBuilder()
        {
            return new AuthenticateCardBuilder();
        }

        public static AuthenticatedMenuCardBuilder CreateAuthenticatedMenuCardBuilder(List<IAuthenticatedMenuAttachmentBuilder> authenticatedMenuAttachmentBuilders)
        {
            return new AuthenticatedMenuCardBuilder(authenticatedMenuAttachmentBuilders);
        }

		public static AuthenticateByTextCardBuilder CreateAuthenticateByTextCardBuilder()
		{
			return new AuthenticateByTextCardBuilder();
		}
	}
}