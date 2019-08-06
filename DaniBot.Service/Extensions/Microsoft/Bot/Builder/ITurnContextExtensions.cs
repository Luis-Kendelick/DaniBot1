using Avanade.HackathonAzul.DaniBot.Cards;
using Microsoft.Bot.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Bot.Builder
{
	public static class ITurnContextExtensions
	{
        public static Task<ResourceResponse> SendActivityAsyncFromAdaptiveCard(this ITurnContext turnContext, ICardBuilder cardBuilder, CancellationToken cancellationToken = default)
        {
            return turnContext.SendActivityAsync(MessageFactory.Attachment(cardBuilder.Build()), cancellationToken);
        }
	}
}
