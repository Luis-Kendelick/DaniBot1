using Avanade.HackathonAzul.DaniBot.Cards;
using Microsoft.Bot.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Bot.Builder
{
	public static class ITurnContextExtensions
	{
		public static Task<ResourceResponse> SendAdaptiveCardsActivityAsyncFrom(this ITurnContext turnContext, ICardBuilder cardBuilder, CancellationToken cancellationToken = default)
		{
			IMessageActivity activity = MessageFactory.Attachment(cardBuilder.Build());

			return turnContext.SendActivityAsync(activity, cancellationToken);
		}
	}
}
