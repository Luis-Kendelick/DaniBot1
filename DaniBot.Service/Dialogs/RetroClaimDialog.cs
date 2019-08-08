using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.Azul.DaniBot.Dialogs
{
	public class RetroClaimDialog : ComponentDialog
	{
		public RetroClaimDialog()
			: base(nameof(RetroClaimDialog))
		{
			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
			{
				IntroStep,
				ActStep
			}));

			InitialDialogId = nameof(WaterfallDialog);
		}

		private async Task<DialogTurnResult> IntroStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
            await stepContext.Context.SendActivityAsyncFromAdaptiveCard(CardFactory.CreateRetroClaimCardBuilder(), cancellationToken, isCarousel: true);
			return new DialogTurnResult(DialogTurnStatus.Waiting);
		}

		private async Task<DialogTurnResult> ActStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			RetroClaimModel userModel = JsonConvert.DeserializeObject<RetroClaimModel>(stepContext.Context.Activity.Value.ToString());
			return await stepContext.EndDialogAsync(cancellationToken);
		}
	}
}