using Avanade.HackathonAzul.DaniBot.Cards.Builders;
using Microsoft.Bot.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Bot.Builder
{
	public static class ITurnContextExtensions
	{
		public static Task<ResourceResponse> SendActivityAsyncFromAdaptiveCard(this ITurnContext turnContext, ICardBuilder cardBuilder, CancellationToken cancellationToken = default, bool isCarousel = false)
		{
			var attachment = MessageFactory.Attachment(cardBuilder.Build());

			if (isCarousel)
				attachment.AttachmentLayout = AttachmentLayoutTypes.Carousel;

			return turnContext.SendActivityAsync(attachment, cancellationToken);
		}
	}
}
