using Avanade.HackathonAzul.DaniBot.Cards.Builders;
using Avanade.HackathonAzul.DaniBot.Cards.Builders.FAQ;
using Avanade.HackathonAzul.DaniBot.Models;

namespace Avanade.HackathonAzul.DaniBot.Cards.Factory
{
    public static class CardFactory
    {
		public static WelcomeMenuCardBuilder CreateWelcomeCardBuilder()
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
    }
}