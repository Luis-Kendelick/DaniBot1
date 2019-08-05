using System;

namespace Avanade.HackathonAzul.DaniBot.Cards
{
    public class CardFactory
    {
        public static ICardBuilder CreateBuilder(CardFactoryType cardFactoryType)
        {
            switch (cardFactoryType)
            {
                case CardFactoryType.Welcome:
                    return new WelcomeCardBuilder();

                default:
                    throw new Exception("Card builder not implemented");
            }
        }
    }
}