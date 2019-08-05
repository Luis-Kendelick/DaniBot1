using Avanade.HackathonAzul.DaniBot.Cards;

namespace Microsoft.Bot.Schema
{
    public static class IActivityExtensions
    {
        public static Activity CreateFrom(this IActivity activity, CardFactoryType cardFactoryType)
        {
            return CreateFrom(activity, cardFactoryType, null);
        }

        public static Activity CreateFrom(this IActivity activity, CardFactoryType cardFactoryType, CardParameter parameter)
        {
            Activity response = ((Activity)activity).CreateReply();

            response.Attachments = CardFactory.CreateBuilder(cardFactoryType).Build();

            return response;
        }
    }
}