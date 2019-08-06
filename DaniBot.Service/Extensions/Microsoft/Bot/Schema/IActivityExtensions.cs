using Avanade.HackathonAzul.DaniBot.Cards;

namespace Microsoft.Bot.Schema
{
    public static class IActivityExtensions
    {
        public static Activity CreateFrom(this IActivity activity, ICardBuilder cardBuilder)
        {
            Activity response = ((Activity)activity).CreateReply();

            response.Attachments = cardBuilder.Build();

            return response;
        }
    }
}